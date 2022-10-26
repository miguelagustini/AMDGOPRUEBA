using System;
using System.Collections;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace AMDGOINT.Clases
{
    class EmailsAutomaticos
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        public void Sendemails(short tipo)
        {
            //PRESTATARIAS
            if (tipo == 0)
            {
                Sendprestatarias();                                
            }
            //PRESTADORES
            
            /*else if (tipo == 1)
            {
                if (ctrls.MensajePregunta("A continuación se notificará a todos los prestadores en lista y al personal de Amdgo\n" +
                    "la disponibilidad de las liquidaciones en la web.\n" +
                    "¿Continuar?") == System.Windows.Forms.DialogResult.Yes)
                {
                    Sendprestadores();
                }
                    
            }*/     
        }

        //PRESTADORES
        /*private void Sendprestadores()
        {
            try
            {
                string mensaje = "Estimado prestador, <br><br>" +
                          " Notificamos que ya se encuentra disponible en la pagina web su liquidación.<br><br>" +
                          " Asociación Médica Del Departamento General Obligado.<br><br>" +
                          " Sin más, saludos.<br><br>" +
                          " Este es un e-mail automático, no responda a ésta dirección.";                          

                string c = "SELECT DISTINCT Email FROM AUTOEMAILS WHERE TipoPersona = 1 AND Estado = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    Enviar(r["Email"].ToString(), mensaje, "Notificación Amdgo");
                }

                Sendpersonal(1);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enviar los emails de prestadores.\n" + e.Message, 0);
                return;
            }
        }
        */
        //PRESTATARIAS
        private void Sendprestatarias()
        {
            try
            {
                string mensaje = "<font face=" + "\"" + "Bookman Old Style" + "\"" + ">"+
                          "A PARTIR DE ESTE MOMENTO!!! el detalle de facturación y comprobante AFIP se encuentra disponible en nuestra web. <br><br>" +
                          "Para ello: acceda a www.amdgo.com.ar/ Prestatarias, ingrese su CUIT y Clave, seleccione el período deseado," +
                          "y de esta manera podrá obtener la documentación referida con un click en el botón de descarga, importante para su planificación financiera.<br><br>" +
                          "Además, aprovechamos la oportunidad para informarle que el procedimiento arriba descripto será la única manera autorizada por AMDGO para que usted acceda a la documentación.<br><br>" +
                          "Nos encontramos a disposición para responder sus inquietudes.<br><br>" +
                          "<u><i>Gerencia AMDGO.<i></u></font>";

                string c = "SELECT DISTINCT Email FROM AUTOEMAILS WHERE TipoPersona = 0 AND Estado = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    Enviar(r["Email"].ToString(), mensaje, "Notificación Amdgo");                                                            
                }

                Sendpersonal(0);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enviar los emails de prestadores.\n" + e.Message, 0);
                return;
            }
        }

        //PERSONAL
        private void Sendpersonal(short tipo)
        {
            try
            {
                string ex = "";
               /* //PRESTATARIAS
                if (tipo == 0) { ex = " Notificamos que ya se encuentra disponible la facturación de las prestatarias en la pagina web.<br><br>"; }
                //PRESTADORES
                else { ex = "A partir de éste momento el detalle de facturación y comprobante AFIP se encuentra disponible en nuestra web. <br><br>" +
                         "Para ello: acceda a www.amdgo.com.ar / Prestatarias, ingrese su CUIT y Clave, seleccione el período deseado," +
                         "y de esta manera podrá obtener la documentación referida con un click en el botón de descarga, importante para su planificación financiera.<br><br>" +
                         "Además, aprovechamos la oportunidad para informarle que el procedimiento arriba descripto será la única manera autorizada por AMDGO para que usted acceda a la documentación.<br><br>" +
                         "Nos encontramos a disposición para responder sus inquietudes.<br><br>" +
                         "Gerencia AMDGO.";
                }*/

                ex = "<font face=" + "\"" + "Bookman Old Style" + "\"" + ">"+
                          "A PARTIR DE ESTE MOMENTO!!! el detalle de facturación y comprobante AFIP se encuentra disponible en nuestra web. <br><br>" +
                          "Para ello: acceda a www.amdgo.com.ar/ Prestatarias, ingrese su CUIT y Clave, seleccione el período deseado," +
                          "y de esta manera podrá obtener la documentación referida con un click en el botón de descarga, importante para su planificación financiera.<br><br>" +
                          "Además, aprovechamos la oportunidad para informarle que el procedimiento arriba descripto será la única manera autorizada por AMDGO para que usted acceda a la documentación.<br><br>" +
                          "Nos encontramos a disposición para responder sus inquietudes.<br><br>" +
                          "<u><i>Gerencia AMDGO.<i></u></font>";

                string c = "SELECT DISTINCT Email FROM AUTOEMAILS WHERE TipoPersona = 2 AND Estado = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    Enviar(r["Email"].ToString(), ex, "Notificación Amdgo");                    
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enviar los emails de prestadores.\n" + e.Message, 0);
                return;
            }
        }

        //ENVIAR EL EMAIL
        public void Enviar(string destino, string mensaje, string encabezado)
        {
            try
            {
                //FRAGMENTO PARA QUE ACEPTE LAS CREDENCIALES Y PODER ENVIAR DESDE EL CORREO DE ASOCIACION
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object sender, X509Certificate certificate, X509Chain chain,
                            SslPolicyErrors sslPolicyErrors) { return true; };

                using (SmtpClient cli = new SmtpClient("mail.playcomla.com.ar", 587))
                {
                    cli.EnableSsl = true;
                    cli.UseDefaultCredentials = false;                    
                    cli.Credentials = new NetworkCredential("facturacion@asociacion-medica.com.ar", "Corralito20");
                    cli.DeliveryMethod = SmtpDeliveryMethod.Network;
                    
                    MailMessage email = new MailMessage("facturacion@asociacion-medica.com.ar", destino, encabezado, mensaje);
                    
                    email.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    email.IsBodyHtml = true;
                    email.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(mensaje, new ContentType("text/html")));
                    
                    cli.Send(email);

                    cli.Dispose();
                    
                    Abmemail(destino, encabezado, mensaje);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enviar el email.\n" + e.Message,0);
                return;
            }                       
          
        }

        //GUARDO EL REGISTRO DEL EMAIL ENVIADO
        private void Abmemail(string dest, string enc, string cuer)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Destino");
                campos.Add("Encabezado");
                campos.Add("Cuerpo");

                parametros.Add(dest);
                parametros.Add(enc);
                parametros.Add(cuer);

                func.AccionBD(campos, parametros, "I", "MAILSENVIADOS");
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar el registro de emails.\n" + e.Message, 0);
                return;
            }
        }
    }
}
