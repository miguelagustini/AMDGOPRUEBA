using AMDGOINT.Clases;
using AMDGOINT.Formularios.OrdenesPago.Vista;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AMDGOINT.Formularios.OrdenesPago.MC
{
    public class Impresion
    {
        private Controles ctrl = new Controles();

        private List<Copias> Copias { get; set; } = new List<Copias>();

        public List<OrdenPagoEnc> Ordenes { get; set; } = new List<OrdenPagoEnc>();

        //GENERO LOS DATOS DE PDF INDIVIDUALES
        public void GeneraDatosPdf(List<OrdenPagoEnc> facturas, short cant, string path)
        {
            try
            {
                foreach (OrdenPagoEnc f in facturas)
                {
                    string archivoname = $"{Regex.Replace(f.ReceptorRazonSocial, "[^A-Za-z0-9- ]", "")}, {f.ComprobanteLetra} {f.ComprobantePuntoVenta.ToString("0000")}-{f.ComprobanteNumero.ToString("00000000")}";
                        
                    PreparaDatos(f, cant);
                    GuardaPdfFisico(path, archivoname);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar los datos.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO EL PDF EN FISICO
        private void GuardaPdfFisico(string ubicacion, string archivoname)
        {
            try
            {
                Xtra_OrdenPago report = new Xtra_OrdenPago();
                report.DataSource = Copias;

                //Ubicacion
                string path = ubicacion + @"\Ordenes " + DateTime.Today.ToString("dd-MM-yyyy");
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

                //Creacion
                report.ExportToPdf(path + @"\" + archivoname + ".pdf");

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al guardar los archivos.\n" + e.Message, 0);
                return;
            }
        }

        //RETORNO EL COMPROBANTE EN BYTES PARA USO EN MEMORIA        
        public byte[] GetComprobantesMS(OrdenPagoEnc f, short cantcopias)
        {
            byte[] retorno = null;

            try
            {
                PreparaDatos(f, cantcopias);

                MemoryStream ms = new MemoryStream();

                Xtra_OrdenPago report = new Xtra_OrdenPago();
                report.DataSource = Copias;
                report.ExportToPdf(ms);

                TextWriter textWriter = new StreamWriter(ms);
                textWriter.Flush(); // added this line
                retorno = ms.ToArray(); // simpler way of converting to array
                ms.Close();

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al guardar los archivos en memoria.\n" + e.Message, 0);
                return retorno;
            }
        }

        public Impresion(){}

        public void Imprimir(short cantcopias, bool incluirctas)
        {
            try
            {
                if (Ordenes.Count <= 0) { return; }

                PreparaDatos(cantcopias);

                if (Copias.Count <= 0) { return; }

                MuestraReporte(incluirctas, cantcopias);

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar la impresión.\n{e.Message}", 1);
                return;
            }


        }

        private void PreparaDatos(short cantcopias)
        {
            try
            {
                Copias.Clear();

                if (Ordenes.Count <= 0) { return; }

                Copias c = new Copias();                
                Copias = c.GetCopias(Ordenes.OrderBy(o => o.ReceptorRazonSocial).ToList(), cantcopias);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar los datos.\n{e.Message}", 1);
                return;
            }
        }

        private void PreparaDatos(OrdenPagoEnc f, short cantcopias)
        {
            try
            {
                Copias.Clear();
                List<OrdenPagoEnc> lista = new List<OrdenPagoEnc>();
                lista.Add(f);
                Copias c = new Copias();
                Copias = c.GetCopias(lista, cantcopias);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar los datos.\n{e.Message}", 1);
                return;
            }
        }

        private void MuestraReporte(bool incluirctas, short cantcopias)
        {
            try
            {
                Xtra_OrdenPago rpt = new Xtra_OrdenPago();
                rpt.DataSource = Copias;
                rpt.Parameters["ImprimeCuentaContable"].Value = incluirctas;
                //rpt.Parameters["CantidadCopias"].Value = cantcopias;
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.ShowPreviewDialog();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al moestrar el reporte.\n{e.Message}", 1);
                return;
            }
        }
    }
}
