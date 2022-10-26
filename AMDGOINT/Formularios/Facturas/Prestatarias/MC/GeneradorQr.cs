using AMDGOINT.Clases;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class GeneradorQr
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Controles ctrl = new Controles();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public GeneradorQr() { }

        #endregion

        public void GeneraQr(ComprobanteEnc encabezado)
        {
            try
            {
                ProcesaJson(encabezado);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al generar el qr.\n{e.Message}", 1);
            }
        }

        public void ProcesaJson(ComprobanteEnc comprobante)
        {
            try
            {
                EstructuraQr Estructura = new EstructuraQr();

                var nuevoqr = new EstructuraQr()
                {
                    fecha = comprobante.ComprobanteFecha.ToString("yyyy-MM-dd"),
                    cuit = 30567506769,
                    ptoVta = comprobante.ComprobantePuntoVenta,
                    tipoCmp = comprobante.TipoComprobanteNumero,
                    nroCmp = comprobante.ComprobanteNumero,
                    importe = comprobante.ImporteTotal,
                    nroDocRec = comprobante.ReceptorCuit,
                    codAut = !string.IsNullOrEmpty(comprobante.CaeNumeroAfip) ? Convert.ToInt64(comprobante.CaeNumeroAfip) : 0
                };

                string json = JsonConvert.SerializeObject(nuevoqr);
                string base64EncodedExternalAccount = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
                string textoqr = !string.IsNullOrEmpty(base64EncodedExternalAccount) ? "https://www.afip.gob.ar/fe/qr/?p=" + base64EncodedExternalAccount : "";
                //byte[] byteArray = Convert.FromBase64String(base64EncodedExternalAccount);

                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeData data = qr.CreateQrCode(textoqr, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);

                comprobante.TextoQr = textoqr;
                ImageConverter converter = new ImageConverter();
                comprobante.ByteQr = (byte[])converter.ConvertTo(code.GetGraphic(5), typeof(byte[]));
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al generar el qr.\n{e.Message}", 1);
            }
        }
    }
}
