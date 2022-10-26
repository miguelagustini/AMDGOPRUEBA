using AMDGOINT.Clases;
using AMDGOINT.Formularios.Facturas.Prestatarias.Vista;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class Impresion
    {
        private Controles ctrl = new Controles();

        private List<Copias> Copias { get; set; } = new List<Copias>();

        public List<ComprobanteEnc> Facturas { get; set; } = new List<ComprobanteEnc>();

        //GENERO LOS DATOS DE PDF INDIVIDUALES
        public void GeneraDatosPdf(short cant, string path, bool incluyedetalles, bool incluyepaciente, bool inlcuyeprestador, bool pdfweb = false, bool leyendaorg = false)
        {
            try
            {
                foreach (ComprobanteEnc f in Facturas)
                {
                    string archivoname = "";

                    if (!pdfweb)
                    {
                        archivoname = $"{Regex.Replace(f.PrestadoraRazonSocial, "[^A-Za-z0-9- ]", "")}, {f.TipoComprobante} {f.ComprobanteLetra} " +
                        $"{f.ComprobantePuntoVenta.ToString("0000")}-{f.ComprobanteNumero.ToString("00000000")}";
                    }
                    else {
                        archivoname = $"{f.Letra}{f.PuntoVenta.ToString("0000")}-{f.ComprobanteNumero.ToString("00000000")}";
                    }

                    PreparaDatos(cant, incluyepaciente, f.IDRegistro, leyendaorg);
                    GuardaPdfFisico(path, archivoname, incluyedetalles, incluyepaciente, inlcuyeprestador);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar los datos.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO EL PDF EN FISICO
        private void GuardaPdfFisico(string ubicacion, string archivoname, bool incluyedetalles, bool incluyepaciente, bool inlcuyeprestador)
        {
            try
            {
                Xtra_Comprobante report = new Xtra_Comprobante();
                report.DataSource = Copias;
                report.Parameters["DetalleVisible"].Value = incluyedetalles;
                report.Parameters["IncluirPaciente"].Value = incluyepaciente;
                report.Parameters["MostrarInformacionPrestador"].Value = inlcuyeprestador;

                //Ubicacion
                string path = ubicacion + @"\Facturas " + DateTime.Today.ToString("dd-MM-yyyy");
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


        public Impresion() { }

        public void Imprimir(short cantcopias, bool incluyepaciente, bool incluyedetalles, bool inlcuyeprestador, bool inlcuyeleyendaorg)
        {
            try
            {
                if (Facturas.Count <= 0) { return; }

                PreparaDatos(cantcopias, incluyepaciente, leyendaorg: inlcuyeleyendaorg);

                if (Copias.Count <= 0) { return; }

                MuestraReporte(incluyedetalles, incluyepaciente, inlcuyeprestador, inlcuyeleyendaorg);

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar la impresión.\n{e.Message}", 1);
                return;
            }


        }

        private void PreparaDatos(short cantcopias, bool incluyepaciente, long byID = 0, bool leyendaorg = false)
        {
            try
            {
                Copias.Clear();

                if (Facturas.Count <= 0) { return; }

                Copias c = new Copias();
                if (byID <= 0) { Copias = c.GetCopias(Facturas.OrderBy(o => o.PrestadoraRazonSocial).ToList(), cantcopias, incluyepaciente, leyendaorg); }
                else { Copias = c.GetCopias(Facturas.Where(w => w.IDRegistro == byID).OrderBy(o => o.PrestadoraRazonSocial).ToList(), cantcopias, incluyepaciente, leyendaorg); }
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar los datos.\n{e.Message}", 1);
                return;
            }
        }

        private void MuestraReporte(bool incluyedetalles, bool incluyepaciente, bool inlcuyeprestador, bool inlcuyeleyendaorg)
        {
            try
            {
                Xtra_Comprobante rpt = new Xtra_Comprobante();
                rpt.DataSource = Copias;
                rpt.Parameters["DetalleVisible"].Value = incluyedetalles;
                rpt.Parameters["IncluirPaciente"].Value = incluyepaciente;
                rpt.Parameters["MostrarInformacionPrestador"].Value = inlcuyeprestador;
                rpt.Parameters["MostrarLeyendaOriginal"].Value = inlcuyeleyendaorg;

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
