using AMDGOINT.Clases;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AmdgoInterno.Afip
{
    public class AfipProdLog
    {
        private Funciones func = new Funciones();
        private Controles ctrls = new Controles();
        public SqlConnection Sqlconnection = new SqlConnection();

        private static UInt32 _globalId = 0;
        private static string urlLoginCms = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl";
        public string urlWSDL { get; set; } = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL";
        public string server { get; set; } = "wsfe";
        private string cert_path;
        private SecureString clave;
        private XmlDocument XmlLoginTicketRequest;
        private XmlDocument XmlLoginTicketResponse;

        public string serv { get => server; }
        public string urllogin { get => urlLoginCms; }
        public string urlwsdl { get => urlWSDL; }
        public string Token { get; set; }
        public string Sign { get; set; }
        public DateTime GenerationTime { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool Logeado { get { return Token != ""; } }

        public X509Certificate2 certificado { get; set; }

        public XDocument XDocRequest { get; set; }

        public XDocument XDocResponse { get; set; }

        public AfipProdLog(string cert_path, string clave)
        {
            this.cert_path = cert_path;
            this.clave = new SecureString();
            foreach (char character in clave)
                this.clave.AppendChar(character);
            this.clave.MakeReadOnly();
        }

        //0 = FACTURA, 1 = PADRON
        public void HacerLogin(long cuit, short factpadron = 0)
        {

            string cmsFirmadoBase64;
            string loginTicketResponse;

            XmlNode uniqueIdNode;
            XmlNode generationTimeNode;
            XmlNode ExpirationTimeNode;
            XmlNode ServiceNode;

            try
            {
                _globalId += 1;

                //VALIDO SI TENGO CREDENCIALES VALIDAS PARA CONTINUAR FACTURANDO SIN NECESIDAD DE SOLICITAR UNA NUEVA. (SI LO HAGO EXISTIENDO UNA VALIDA, DA ERROR)
                if (taValido(cuit, factpadron))
                {
                    //Obtenemos el Certificado
                    if (certificado == null)
                    {
                        certificado = new X509Certificate2();
                        if (clave.IsReadOnly()) { certificado.Import(File.ReadAllBytes(cert_path), clave, X509KeyStorageFlags.PersistKeySet); }
                        else { certificado.Import(File.ReadAllBytes(cert_path)); }
                    }

                    return;
                }

                //PREPARO EL XML REQUEST
                XmlLoginTicketRequest = new XmlDocument();
                XMLLoader.loadTemplate(XmlLoginTicketRequest, "LoginTemplate");

                uniqueIdNode = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                generationTimeNode = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                ExpirationTimeNode = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                ServiceNode = XmlLoginTicketRequest.SelectSingleNode("//service");
                generationTimeNode.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                ExpirationTimeNode.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                uniqueIdNode.InnerText = Convert.ToString(_globalId);
                ServiceNode.InnerText = serv;

                //OBTENGO EL CERTIFICADO
                certificado = new X509Certificate2();
                if (clave.IsReadOnly()) { certificado.Import(File.ReadAllBytes(cert_path), clave, X509KeyStorageFlags.PersistKeySet); }
                else { certificado.Import(File.ReadAllBytes(cert_path)); }


                Byte[] msgBytes = Encoding.UTF8.GetBytes(XmlLoginTicketRequest.OuterXml);

                //FIRMAMOS EL CERTIFICADO Y ALMACENAMOS EN LA VARIABLE cmsFirmadoBase64, ESTO ES LO QUE VOY A ENVIAR A AFIP PARA QUE NOS AUTORICE
                ContentInfo infoContenido = new ContentInfo(msgBytes);
                SignedCms cmsFirmado = new SignedCms(infoContenido);

                CmsSigner cmsFirmante = new CmsSigner(certificado);
                cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;
                
                cmsFirmado.ComputeSignature(cmsFirmante);
                cmsFirmadoBase64 = Convert.ToBase64String(cmsFirmado.Encode());

                //ACA HAGO EL LOGIN CON EL CERTIFICADO OBTENIDO                
                AMDGOINT.AFIP.PROD.WSAA.LoginCMSService servicio = new AMDGOINT.AFIP.PROD.WSAA.LoginCMSService();
                servicio.Url = urllogin;

                loginTicketResponse = servicio.loginCms(cmsFirmadoBase64);

                //SI TODO SALIO BIEN VOY A TENER EL XML RESPUESTA EN FORMA DE STRING, EL CUAL LO VOY A CONVERTIR EN XML DOCUMENT Y ANALIZARLO PARA VER
                //QUE RESPONDE EL SERVER DE AFIP
                // Analizamos la respuesta
                XmlLoginTicketResponse = new XmlDocument();
                XmlLoginTicketResponse.LoadXml(loginTicketResponse);

                Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
                Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;

                var exStr = XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText;
                var genStr = XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText;
                ExpirationTime = DateTime.Parse(exStr);
                GenerationTime = DateTime.Parse(genStr);

                //GUARDO LOS DATOS QUE CONFORMAN EL TA, YA QUE POR UN PERÍODO DE TIEMPO, ESTA CREDENCIAL VA A SERVIR
                //Y SI SOLICITO UNA NUEVA, DARÁ ERROR
                guardaTa(cuit, factpadron);

            }
            catch (Exception e)
            {                
                ctrls.MensajeInfo("Ocurrió un error al ejecutar el login en AFIP.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO EN LA BASE DE DATOS EL ULTIMO TA OBTENIDO
        private void guardaTa(long cuit, short facturapadron)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Token");
                campos.Add("Sign");
                campos.Add("ExpirationTime");
                campos.Add("GenerationTime");
                campos.Add("Tipo");
                campos.Add("Cuit");
                campos.Add("FacturaPadron");

                parametros.Add(Token);
                parametros.Add(Sign);
                parametros.Add(ExpirationTime);
                parametros.Add(GenerationTime);
                parametros.Add(1);
                parametros.Add(cuit);
                parametros.Add(facturapadron);

                func.AccionBD(campos, parametros, "I", "WSFEACCESO", 0);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar el TA.\n" + e.Message, 0);
                return;
            }
        }

        //VALIDO SI TENGO UN TA VALIDO EN MI BASE DE DATOS
        private bool taValido(long cuit, short factpadron)
        {
            try
            {                
                bool retorno = false;

                string consulta = "SELECT TOP 1 * FROM WSFEACCESO" +
                    " WHERE Tipo = 1 AND ExpirationTime > SYSDATETIME() AND FacturaPadron = " + factpadron +
                    " AND Cuit = " + cuit;

                foreach (DataRow fila in func.getColecciondatos(consulta, Sqlconnection.State != ConnectionState.Closed ? Sqlconnection : null).Rows)
                {                    
                    Token = fila["Token"].ToString();
                    Sign = fila["Sign"].ToString();
                    ExpirationTime = Convert.ToDateTime(fila["ExpirationTime"]);
                    GenerationTime = Convert.ToDateTime(fila["GenerationTime"]);

                    retorno = true;
                }

                return retorno;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar el TA.\n" + e.Message, 0);                
                return false;
            }
        }
    }    
}
