using AMDGOINT.Clases;
using AMDGOINT.Formularios.Facturas.Ambulatorio.Vista;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class Impresion
    {
        private Controles ctrl = new Controles();

        private List<Copias> Copias { get; set; } = new List<Copias>();

        public List<FacturaEnc> Facturas { get; set; } = new List<FacturaEnc>();

        //GENERO LOS DATOS DE PDF INDIVIDUALES
        public void GeneraDatosPdf(List<FacturaEnc> facturas, short cant, bool inclpaci, string path, bool incluyefact, bool paraweb = false)
        {
            try
            {
                foreach (FacturaEnc f in facturas)
                {
                    string archivoname = !paraweb ? $"{Regex.Replace(f.NombreProf, "[^A-Za-z0-9- ]", "")}, {f.Letra} {f.PuntoVenta.ToString("0000")}-{f.Numero.ToString("00000000")}" :
                        $"{f.CodigoProf}-{f.Letra}{f.PuntoVenta.ToString("0000")}{f.Numero.ToString("00000000")}";
                    PreparaDatos(f, cant, inclpaci, incluyefact);
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
                Xtra_Factura report = new Xtra_Factura();
                report.DataSource = Copias;

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

        //RETORNO EL COMPROBANTE EN BYTES PARA USO EN MEMORIA        
        public byte[] GetComprobantesMS(FacturaEnc f, short cantcopias, bool incluyepaciente, bool incluyefact)
        {
            byte[] retorno = null;

            try
            {
                PreparaDatos(f, cantcopias, incluyepaciente, incluyefact);

                MemoryStream ms = new MemoryStream();

                Xtra_Factura report = new Xtra_Factura();
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

        public void Imprimir(short cantcopias, bool incluyepaciente, bool incluyefact)
        {
            try
            {
                if (Facturas.Count <= 0) { return; }

                PreparaDatos(cantcopias, incluyepaciente, incluyefact);

                if (Copias.Count <= 0) { return; }

                MuestraReporte();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar la impresión.\n{e.Message}", 1);
                return;
            }


        }

        private void PreparaDatos(short cantcopias, bool incluyepaciente, bool incluyefact)
        {
            try
            {
                Copias.Clear();

                if (Facturas.Count <= 0) { return; }

                Copias c = new Copias();                
                Copias = c.GetCopias(Facturas.OrderBy(o => o.NombreProf).ToList(), cantcopias, incluyepaciente, incluyefact);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar los datos.\n{e.Message}", 1);
                return;
            }
        }

        private void PreparaDatos(FacturaEnc f, short cantcopias, bool incluyepaciente, bool incluyefact)
        {
            try
            {
                Copias.Clear();
                List<FacturaEnc> lista = new List<FacturaEnc>();
                lista.Add(f);
                Copias c = new Copias();
                Copias = c.GetCopias(lista, cantcopias, incluyepaciente, incluyefact);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al generar los datos.\n{e.Message}", 1);
                return;
            }
        }

        private void MuestraReporte()
        {
            try
            {
                Xtra_Factura rpt = new Xtra_Factura();
                rpt.DataSource = Copias;
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
