using AMDGOINT.Clases;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Drawing;
using System.Text;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
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

        public void GeneraQr(FacturaEnc encabezado)
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

        public void ProcesaJson(FacturaEnc comprobante)
        {
            try
            {
                EstructuraQr Estructura = new EstructuraQr();

                var nuevoqr = new EstructuraQr()
                {
                    fecha = comprobante.Fecha.ToString("yyyy-MM-dd"),
                    cuit = comprobante.CuitProf,
                    ptoVta = comprobante.PuntoVenta,
                    tipoCmp = comprobante.TipoComprobanteNumero,
                    nroCmp = comprobante.Numero,
                    importe = comprobante.Total,
                    nroDocRec = comprobante.CuitPres,
                    codAut = !string.IsNullOrEmpty(comprobante.CaeNroAf) ? Convert.ToInt64(comprobante.CaeNroAf) : 0
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
                comprobante.ByteQr = (byte[])converter.ConvertTo(code.GetGraphic(20), typeof(byte[]));
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al generar el qr.\n{e.Message}", 1);
            }
        }


    }
   
}
