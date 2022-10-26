using AMDGOINT.Afip;
using AmdgoInterno.Afip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace AMDGOINT.Clases
{
    class Funciones
    {
        private ConexionBD conn = new ConexionBD();
        private ConexionAmdgoSis connamsis = new ConexionAmdgoSis();
        private Controles ctrls = new Controles();
        private Globales glbls = new Globales();
        private AfipPadron conspadron = new AfipPadron();

        //OBTENGO LA COLECCION DE CAMPOS
        public DataTable getColecciondatos(string consulta, SqlConnection conexion = null)
        {
            DataTable retorno = new DataTable();

            try
            {                                
                SqlDataAdapter da = new SqlDataAdapter("sp_Consultas", conexion != null && conexion.State == ConnectionState.Open ? conexion : conn.Conectar());
                
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("consulta", consulta);
                da.SelectCommand.CommandTimeout = 120;
                da.Fill(retorno);
                da.Dispose();

                conn.Desconectar(); 

                return retorno;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al obtener la colección de datos.\n" + e.Message, 0);
                return retorno;
            }
        }

        //OBTENGO LA COLECCION DE CAMPOS DE AMDGOSIS
        public DataTable getColecciondatosamsis(string consulta)
        {
            DataTable retorno = new DataTable();

            try
            {
                //SALGO SI NO HAY CONEXION
                if (!hayConexion()) { return retorno; }

                SqlDataAdapter da = new SqlDataAdapter("sp_Consultas", connamsis.Conectar());

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("consulta", consulta);

                da.Fill(retorno);

                connamsis.Desconectar();

                da.Dispose();

                return retorno;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al obtener la colección de datos.\n" + e.Message, 0);
                return retorno;
            }
        }

        public List<T> ConvertToList<T>(DataTable dt)
        {
            try
            {
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
                var properties = typeof(T).GetProperties();

                return dt.AsEnumerable().Select(row => {

                    var objT = Activator.CreateInstance<T>();

                    foreach (var pro in properties)
                    {
                        try
                        {
                            if (columnNames.Contains(pro.Name.ToLower()))
                            {
                                if (row[pro.Name.ToLower()] != DBNull.Value) { pro.SetValue(objT, row[pro.Name]); }
                            }                                
                        }
                        catch (Exception ) { }
                    }
                    return objT;
                }).ToList();
            }
            catch (Exception )
            {
                return new List<T>();
            }          
        }

        public List<T> ConvertToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();

            try
            {                
                T obj = default(T);                
                var columnNames = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();

                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (columnNames.Contains(prop.Name))
                        {
                            if (!Equals(dr[prop.Name], DBNull.Value))
                            {                                
                                prop.SetValue(obj, dr[prop.Name]);
                            }
                        }

                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No se puedo asignar la lista generica.\n{e.Message}", 1);
                return list;
            }
            
        }

        //PROCESO LAS ACCIONES ABM A LA BASE DE DATOS
        public void AccionBD(ArrayList camposlist, ArrayList parametros, string accion,
            string tabla, long idmodif = 0, string campoid = "ID_Registro")
        {
            string query = "";
            string campos = "";
            string values = "";
            string subUpdate = "";

            try
            {
                //SOLO SI ES INSERT PROCESO LOS CAMPOS, 
                //DE LO CONTRARIO NO TIENE RAZON DE HACERLO
                if (accion == "I")
                {
                    //ARMO LISTADO DE CAMPOS
                    for (int i = 0; i < camposlist.Count; i++)
                    {
                        if (camposlist.Count == 1)
                        {
                            campos += camposlist[i].ToString();
                        }
                        else
                        {
                            if (i == 0)
                            {
                                campos += camposlist[i].ToString();
                            }
                            else
                            {
                                campos += ", " + camposlist[i].ToString();
                            }

                        }
                    }

                    //ARMO LISTADO DE PARAMETROS (VALUES
                    for (int i = 0; i < camposlist.Count; i++)
                    {
                        if (camposlist.Count == 1)
                        {
                            values += "@p" + i.ToString();
                        }
                        else
                        {
                            if (i == 0)
                            {
                                values += "@p" + i.ToString();
                            }
                            else
                            {
                                values += ", @p" + i.ToString();
                            }

                        }
                    }
                }

                //ARMO LA CONSULTA
                if (accion == "I") //INSERT
                {                    
                    query = "INSERT INTO " + tabla + "(" + campos + ")" + " VALUES(" + values + ");";
                }
                else if (accion == "U") //UPDATE
                {                    
                    for (int n = 0; n < camposlist.Count; n++)
                    {
                        if (n == 0)
                        {
                            subUpdate = camposlist[n].ToString() + " = " + "@p" + n.ToString();
                        }
                        else
                        {
                            subUpdate = subUpdate + ", " + camposlist[n].ToString() + " = " + "@p" + n.ToString();
                        }

                    }

                    query = "UPDATE " + tabla + " SET " + subUpdate + " WHERE (" + campoid + " = " + idmodif + ");";



                }
                else if (accion == "D") //DELETE
                {
                    query = "DELETE FROM " + tabla + " WHERE (" + campoid + " = " + idmodif + ");";
                }

                SqlCommand cmd = new SqlCommand(query, conn.Conectar());

                //SOLO SI ES INSERT O UPDATE USO LOS PRAMETROS
                if ((accion == "I") || (accion == "U"))
                {
                    for (int i = 0; i < parametros.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("p" + i.ToString(), parametros[i]);
                    }
                }

                //EJECUTO LA CONSULTA ELABORADA
                cmd.ExecuteNonQuery();

                //CIERRO LA CONEXION
                conn.Desconectar();
              
                

            }
            catch (Exception e)
            {
                string a = "";

                for (int i = 0; i < parametros.Count; i++)
                {
                    a += camposlist[i].ToString() + "-" + parametros[i].ToString() + "\n";
                }

                ctrls.MensajeInfo("Ocurrió un error al ejectuar el ABM del registro.\n" + e.Message + "\n " + a, 0);
                conn.Desconectar();
                return;
            }

        }

        public void AccionBD2(ArrayList camposlist, ArrayList parametros, string accion,
           string tabla, SqlConnection conn, long idmodif = 0, string campoid = "ID_Registro")
        {
            string query = "";
            string campos = "";
            string values = "";
            string subUpdate = "";

            try
            {
                //SOLO SI ES INSERT PROCESO LOS CAMPOS, 
                //DE LO CONTRARIO NO TIENE RAZON DE HACERLO
                if (accion == "I")
                {
                    //ARMO LISTADO DE CAMPOS
                    for (int i = 0; i < camposlist.Count; i++)
                    {
                        if (camposlist.Count == 1)
                        {
                            campos += camposlist[i].ToString();
                        }
                        else
                        {
                            if (i == 0)
                            {
                                campos += camposlist[i].ToString();
                            }
                            else
                            {
                                campos += ", " + camposlist[i].ToString();
                            }

                        }
                    }

                    //ARMO LISTADO DE PARAMETROS (VALUES
                    for (int i = 0; i < camposlist.Count; i++)
                    {
                        if (camposlist.Count == 1)
                        {
                            values += "@p" + i.ToString();
                        }
                        else
                        {
                            if (i == 0)
                            {
                                values += "@p" + i.ToString();
                            }
                            else
                            {
                                values += ", @p" + i.ToString();
                            }

                        }
                    }
                }

                //ARMO LA CONSULTA
                if (accion == "I") //INSERT
                {
                    query = "INSERT INTO " + tabla + "(" + campos + ")" + " VALUES(" + values + ");";
                }
                else if (accion == "U") //UPDATE
                {
                    for (int n = 0; n < camposlist.Count; n++)
                    {
                        if (n == 0)
                        {
                            subUpdate = camposlist[n].ToString() + " = " + "@p" + n.ToString();
                        }
                        else
                        {
                            subUpdate = subUpdate + ", " + camposlist[n].ToString() + " = " + "@p" + n.ToString();
                        }

                    }

                    query = "UPDATE " + tabla + " SET " + subUpdate + " WHERE (" + campoid + " = " + idmodif + ");";



                }
                else if (accion == "D") //DELETE
                {
                    query = "DELETE FROM " + tabla + " WHERE (" + campoid + " = " + idmodif + ");";
                }
                                
                SqlCommand cmd = new SqlCommand(query, conn);

                //SOLO SI ES INSERT O UPDATE USO LOS PRAMETROS
                if ((accion == "I") || (accion == "U"))
                {
                    for (int i = 0; i < parametros.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("p" + i.ToString(), parametros[i]);
                    }
                }

                //EJECUTO LA CONSULTA ELABORADA
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                /*string a = "";

                for (int i = 0; i < parametros.Count; i++)
                {
                    a += camposlist[i].ToString() + "-" + parametros[i].ToString() + "\n";
                }

                ctrls.MensajeInfo("Ocurrió un error al ejectuar el ABM del registro.\n" + e.Message + "\n " + a, 0); 
                return;*/
            }

        }


        //VALIDO SI HAY CONEXION A INTERNET
        public Boolean hayConexion()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://google.com/generate_204"))
                    { return true; }
                }
                
                    
            }
            catch
            {
                return false;
            }
           
        }

        //DEVUELVE LA HORA DEL SERVIDOR
        public DateTime Getfechorserver()
        {
            try
            {
                //if (!hayConexion()) { return DateTime.Now; }

                DateTime retorno = new DateTime();
                DataTable dt = new DataTable();

                string consulta = "SELECT CONVERT (smalldatetime, GETDATE()) AS Fecha";
                dt = getColecciondatos(consulta);

                if (dt.Rows.Count >= 0)
                {
                    DataRow fila = dt.Rows[0];

                    if (fila["Fecha"] != DBNull.Value) { retorno = Convert.ToDateTime(fila["Fecha"]); }
                }

                return retorno;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        //SETEO ID USUARIO LOG POR CUIT
        public void SetIdusuariolog(string cuit)
        {
            try
            {
                string c = "SELECT ID_Registro, Usuario FROM USUARIOS WHERE NroDocumento = '" + cuit + "'";

                foreach (DataRow r in getColecciondatos(c).Rows)
                {
                    glbls.SetIdUsuariolog(Convert.ToInt32(r["ID_Registro"]));
                    glbls.SetNomUsuariolog(r["Usuario"].ToString());
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo(e.Message, 0);
                return;
                
            }
        }

        //VALIDA LOS PERMISOS QUE POSEE EL USUARIO
        public bool DevuelvePermiso(string clave, SqlConnection con = null)
        {
            try
            {
                if (glbls.GetIdUsuariolog() <= 0) { return false; }

                bool retorno = false;
                
                string consulta = $"SELECT RO.Acceso FROM USUARIOS US" +
                    $" LEFT OUTER JOIN ROLESGRUPO RO ON(RO.ID_Grupo = US.ID_Grupo)" +
                    $" LEFT OUTER JOIN PERMISOS PE ON(PE.ID_Registro = RO.ID_Permiso)" +
                    $" WHERE(US.ID_Registro = {glbls.GetIdUsuariolog()}) AND (PE.Clave = '{clave}')" +
                    $" AND Estadoreg = 1";


                foreach (DataRow fila in getColecciondatos(consulta, con != null && con.State == ConnectionState.Open ? con : null).Rows)
                {
                    if (fila["Acceso"] != DBNull.Value)
                    { retorno = Convert.ToBoolean(fila["Acceso"]); }
                }

                return retorno;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar los permisos.\n" + e.Message, 0);                
                return false;
            }
        }

        //OBTENER LETRA DE COMPROBANTE
        public string GetLetracomprob(short ivaemis, short ivarece, decimal ivamont, bool ivaoculto)
        {
            if (ivaemis == 1 && ivarece == 1 && !ivaoculto) { return "A"; }
            else if (ivaemis == 1 && ivarece == 1 && ivaoculto) { return "B"; }
            else if (ivaemis == 1 && (ivarece == 4 || ivarece == 6)) { return "B"; }
            else if (ivaemis == 4 || ivarece == 6) { return "C"; }
            else { return ""; }
        }
               
        //OBTENGO EL ID DE PROFESIONAL POR CODIGO
        public int Getidprofesional(string codigo, SqlConnection sql)
        {
            int retorno = 0;

            try
            {                
                string consulta = "SELECT ID_Registro FROM PROFESIONALES WHERE Codigo = '" + codigo + "'";

                foreach (DataRow f in getColecciondatos(consulta, sql).Rows) { retorno = Convert.ToInt32(f["ID_Registro"]); }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al obtener el id del profesional.\n" + e.Message, 0);
                return retorno;
            }
        }
                               
        //DEVUELVO EL NUMERO DE RECIBO X
        public long GetNumerox(string tipo)
        {
            try
            {
                long retorno = 0;

                string consulta = "SELECT ISNULL(MAX(Numero),0) AS Numero FROM NUMERACIONX WHERE Tipo = '" + tipo + "'";

                foreach (DataRow f in getColecciondatos(consulta).Rows) { retorno = Convert.ToInt64(f["Numero"]) + 1; }
                
                return retorno;
            }
            catch (Exception)
            {

                //ctrls.MensajeInfo("Ocurrió un error al consultar la numeración.", 0);
                return 0;
            }
        }

        //ACTUALIZO EL NUMERO DE RECIBO X
        public void SetNumerox(long numero, string tipo)
        {
            try
            {
                SqlConnection cn = conn.Conectar();

                string query = "UPDATE NUMERACIONX SET " +
                        " Numero = " + numero + " WHERE Tipo = '" + tipo + "'";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                //ctrls.MensajeInfo("Ocurrió un error al actualizar la numeración.", 0);
                return;
            }
        }

        //CONSULTO DATOS AFIP UNICO
        public DatosAfip GetInfoAfipunico(long cuit)
        {
            DatosAfip dato = new DatosAfip();

            try
            {                
                if (!hayConexion()) { return dato; }

                long[] cuitcons = new long[1];
                cuitcons[0] = cuit;

                ListaPersonas ent = conspadron.GetEntidad(cuitcons, Application.StartupPath + @"\Afip\PROD\PD-CR20078779250.pfx", "2048", 20078779250);

                foreach (Persona p in ent.personaListReturn.persona)
                {
                    if (p.datosGenerales != null && p.datosGenerales.razonSocial != null)
                    {
                        dato.RazonSocial = p.datosGenerales.razonSocial;                        
                         
                    }


                    if (p.datosGenerales != null && p.datosGenerales.nombre != null)
                    {
                        dato.Nombre = p.datosGenerales.apellido + " " + p.datosGenerales.nombre;

                    }
                    
                    if (p.datosGenerales != null && p.datosGenerales.domicilioFiscal != null)
                    {
                        dato.DomicilioFiscal = p.datosGenerales.domicilioFiscal.direccion + ", " +
                            p.datosGenerales.domicilioFiscal.localidad + " " +
                            p.datosGenerales.domicilioFiscal.codPostal + ", " +
                            p.datosGenerales.domicilioFiscal.descripcionProvincia;
                    }

                    if (p.datosRegimenGeneral != null && p.datosRegimenGeneral.impuesto != null)
                    {
                        for (int m = 0; m < p.datosRegimenGeneral.actividad.Count; m++)
                        {
                            switch (p.datosRegimenGeneral.actividad[m].orden)
                            {
                                case "1":
                                    string dat = p.datosRegimenGeneral.actividad[m].periodo;
                                    if (dat != "")
                                    {
                                        dato.FechaInicio = dat.Substring(0, 4) + "-" + dat.Substring(4, 2) + "-01";                                        
                                    }
                                    break;

                            }
                        }
                    }

                    if (p.datosRegimenGeneral != null && p.datosRegimenGeneral.impuesto != null)
                    {
                        for (int m = 0; m < p.datosRegimenGeneral.impuesto.Count; m++)
                        {
                            switch (p.datosRegimenGeneral.impuesto[m].idImpuesto)
                            {
                                case "30": dato.IDIva = 1;  break;
                                case "32": dato.IDIva = 4; break;
                            }
                        }
                    }
                }

                return dato;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar los datos de afip.\n" + e.Message, 0);
                return dato;
            }
        }

        //ENVIO DE EMAILS
        public void EnviarEmail(List<Mailing> mailing = null, 
            string encab = "AMDGO - Notificación de Comprobantes")
        {
            try
            {        
                //FRAGMENTO PARA QUE ACEPTE LAS CREDENCIALES Y PODER ENVIAR DESDE EL CORREO DE ASOCIACION
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain chain,
                            SslPolicyErrors sslPolicyErrors) { return true; };
                

                string mailorigen = "facturacion@asociacion-medica.com.ar";
                string contrasena = "Corralito20";                

                //AGRUPO LA LISTA POR DESTINATARIOS
                var grupos = mailing.GroupBy(u => u.EmailReceptor).Select(u => u.First()).ToList();
                        
                //ESTABLEZCO LA CONEXION CON EL SERVER DE EMAIL
                SmtpClient cliente = new SmtpClient("mail.playcomla.com.ar");
                cliente.EnableSsl = true;
                cliente.UseDefaultCredentials = false;
                cliente.Port = 587;
                cliente.Credentials = new NetworkCredential(mailorigen, contrasena);

                //RECORRO LA LISTA AGRUPADA
                foreach (var m in grupos)
                {   
                    //SI NO HAY DIRECCION, PASO AL SIGUIENTE
                    if (m.EmailReceptor.Trim() == "") { continue; }

                    //SI HAY DIRECCION. OBTENGO TODOS LOS ADJUNTOS DE ESA LISTA Y MANDO
                    var detalles = mailing.Where(s => s.EmailReceptor == m.EmailReceptor).ToList();

                    string c = "Estimado prestador, <br><br>" +
                               " Adjuntamos los comprobantes emitidos a través del software de" +
                               " Asociación Médica Del Departamento General Obligado.<br><br>" +
                               " Este es un e-mail automático, no responda a ésta dirección.<br><br>" +
                               " Sin más, saludos.";

                    MailMessage email = new MailMessage(mailorigen, m.EmailReceptor, encab, c);
                    //MailMessage email = new MailMessage(mailorigen, "jonatan.pereyra@asociacion-medica.com.ar", encab, c);
                    email.Bcc.Add("claudia.baru@asociacion-medica.com.ar");
                    email.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    email.IsBodyHtml = true;
                    email.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(c, new ContentType("text/html")));
                    //email.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(c, new ContentType("text/plain")));

                    //RECORRO TODOS LOS DETALLES Y LOS AGREGO AL EMAIL CORRESPONDIENTE
                    foreach (Mailing d in detalles)
                    {
                        if (d.Adjunto != null && d.Adjunto.Length > 0)
                        {
                            email.Attachments.Add(new Attachment(new MemoryStream(d.Adjunto), d.Comprobante + ".pdf"));
                        }
                    }

                    cliente.Send(email);
                }

                cliente.Dispose();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enviar el email.\n" + e.Message, 0);
                return;
            }
        }

        //OBTENGO EL VALOR MINIMO PARA MIPYME
        public decimal GetMinimoPyme(SqlConnection sqlConnection = null)
        {
            try
            {
                decimal retorno = 0;

                string consulta = "SELECT MinPyme FROM PARAMSCBU";

                foreach (DataRow f in getColecciondatos(consulta, sqlConnection != null ? sqlConnection : null).Rows) { retorno = Convert.ToDecimal(f["MinPyme"]); }

                return retorno;
            }
            catch (Exception)
            {

                ctrls.MensajeInfo("Ocurrió un error al consultar el valor mínimo mipyme.", 0);
                return 0;
            }
        }

        // OBTENGO EL CBU DE PARA FACTURAS DE CREDITO
        public string GetCbucreditos(SqlConnection sqlConnection)
        {
            try
            {
                string retorno = "";

                string c = "SELECT Cbu FROM PARAMSCBU WHERE Codigo = 'fccpres'";

                foreach (DataRow f in getColecciondatos(c, sqlConnection).Rows)
                {
                    retorno = f["Cbu"].ToString();
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar el Cbu.\n" + e.Message, 0);
                return "";
            }
        }

        // OBTENGO EL ALIAS DE PARA FACTURAS DE CREDITO
        public string GetAliascreditos(SqlConnection sqlConnection)
        {
            try
            {
                string retorno = "";

                string c = "SELECT Alias FROM PARAMSCBU WHERE Codigo = 'fccpres'";

                foreach (DataRow f in getColecciondatos(c, sqlConnection).Rows)
                {
                    retorno = f["Alias"].ToString();
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar el Alias.\n" + e.Message, 0);
                return "";
            }
        }

        //PROCESO SI EXISTE EL CERTIFICADO PARA GENERAR LA FACTURA
        public string ExisteCertificado(short produccion, string cuitemis)
        {
            try
            {
                string retorno = "";

                //HOMOLOGACION
                if (produccion == 0)
                {
                    if (File.Exists(Application.StartupPath + @"\Afip\HOMO\H-CR" + cuitemis + ".pfx"))
                    {
                        retorno = Application.StartupPath + @"\Afip\HOMO\H-CR" + cuitemis + ".pfx";
                    }

                }//PRODUCCION 1
                else
                {
                    if (File.Exists(Application.StartupPath + @"\Afip\PROD\P-CR" + cuitemis + ".pfx"))
                    {
                        retorno = Application.StartupPath + @"\Afip\PROD\P-CR" + cuitemis + ".pfx";
                    }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al buscar las credenciales.\n" + e.Message, 0);
                return "";
            }
        }

        //HAGO EL LOGIN CON AFIP AL MODULO CORRESPONDIENTE
        public bool LoginAfip(short produccion, string cuitemis, AfipHomoDatos afiphomo = null, 
            AfipProdDatos afipprod = null)
        {
            try
            {
                bool retorno = false;
                string path = ExisteCertificado(produccion, cuitemis);

                //HOMOLOGACION 0
                if (produccion == 0 && afiphomo != null)
                {
                    if (path != "" && afiphomo.loginafip(path, "248", Convert.ToInt64(cuitemis))) { retorno = true; } else { retorno = false; }
                }
                //PRODUCCION 1
                else if(produccion == 1 && afipprod != null)
                {
                    if (path != "" && afipprod.loginafip(path, "248", Convert.ToInt64(cuitemis))) { retorno = true; } else { retorno = false; }
                }
                

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al logarse con afip.\n" + e.Message, 0);
                return false;
            }

        }

        //CONVERSION STRING A DECIMAL
        public decimal Trydecimalconvert(string input)
        {
            Decimal dummy;
            Decimal.TryParse(input, out dummy);
            return dummy;
        }

        public DateTime Trydatetimeconvert(string input)
        {
            DateTime dummy = DateTime.Now;
            DateTime.TryParse(input, out dummy);
            return dummy;
        }

        //OBTENGO EL NUMERO DE COLUMNA EXCEL SEGUN LETRA
        public int GetIndexbyletterxls(string s)
        {
            // This process is similar to  
            // binary-to-decimal conversion  
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result *= 26;
                result += s[i] - 'A';
            }
            return result;
        }

        public string ValidaCadena(string cadena)
        {
            try
            {

                string nuevacadena = "";

                //RECORRO LOS CARACTERES DE LA CADENA
                for (int i = 0; i < cadena.Length; i++)
                {
                    string newcaracter = "";

                    int caracter = Encoding.UTF32.GetBytes(cadena.Substring(i, 1))[0];

                    switch (caracter)
                    {
                        case 26: newcaracter = Convert.ToChar("é").ToString(); break;
                        case 160: newcaracter = Convert.ToChar("á").ToString(); break;
                        case 161: newcaracter = Convert.ToChar("í").ToString(); break;
                        case 162: newcaracter = Convert.ToChar("ó").ToString(); break;
                        case 163: newcaracter = Convert.ToChar("ú").ToString(); break;
                        case 164: newcaracter = Convert.ToChar("ñ").ToString(); break;
                        case 253: newcaracter = Convert.ToChar("ó").ToString(); break;
                        default: newcaracter = Convert.ToChar(caracter).ToString(); ; break;
                    }

                    nuevacadena += newcaracter;
                }

                return nuevacadena.Trim();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al procesar el nombre de la monodroga.\n" +
                    e.Message, "AMDGO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
        }

        //DEVUELVO LOS NOMBRES DEL MES
        public string GetMes(int valor)
        {
            switch (valor)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return "";
            }
        }

        public void PreparaRetorno(Dictionary<short, string> retorno, Dictionary<short, string> proc)
        {
            foreach (var y in proc)
            {
                if (retorno.Where(w => w.Key == y.Key).Count() <= 0)
                {
                    retorno.Add(y.Key, y.Value);
                }
                else
                {
                    retorno.Add((short)(retorno.Max(m => m.Key) + 1), y.Value);
                }
            }

        }
    }

    public class DatosAfip
    {
        public string Nombre { get; set; } = "";
        public string RazonSocial { get; set; } = "";
        public string DomicilioFiscal { get; set; } = "";
        public short IDIva { get; set; } = 0;
        public string FechaInicio { get; set; }
    }

    public class NumeroaLetras
    {
        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }


    }

    public class Mailing
    {
        public byte[] Adjunto { get; set; } = null;
        public string Comprobante { get; set; } = "";
        public string EmailReceptor { get; set; } = "";
    }
}
