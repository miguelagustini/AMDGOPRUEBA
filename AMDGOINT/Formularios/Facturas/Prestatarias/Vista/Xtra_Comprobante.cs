using System;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Xtra_Comprobante : DevExpress.XtraReports.UI.XtraReport
    {        
        private float cantidadwidth = 0;
        private float totalwidht = 0;
        private float prestadornomwidht = 0;
        private float prestadorcodwidht = 0;

        public Xtra_Comprobante()
        {
            InitializeComponent();
        }

        private void xrTableDetallesC_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRTable tabla = sender as XRTable;
                if (tabla == null) { return; }

                //PRINCIPAL ---> SI DEBO OCULTAR INFORMACION DEL PRESTADOR (SE OCULTA TODO, PRESTADOR Y PACIENTE, SOLO QUEDA LA DESCRIPCION CALCULADA)
                if (!(bool)MostrarInformacionPrestador.Value)
                {
                    cantidadwidth = xrcolCantidadC.WidthF;
                    totalwidht = xrcolTotalC.WidthF;

                    tabla.BeginInit();

                    tabla.DeleteColumn(xrcolPrestadorcodC);                    
                    tabla.DeleteColumn(xrcolPrestadornomC);                    
                    tabla.DeleteColumn(xrcolPacienteC);

                    xrcolTotalC.WidthF = totalwidht;
                    xrcolCantidadC.WidthF = cantidadwidth;

                    tabla.EndInit();
                }
                else
                {
                    //SI PUEDO MOSTRAR INFORMACION DEL PRESTADOR, VALIDO SI SE DEBE MOSTRAR INFORMACION DEL PACIENTE
                    if (!(bool)IncluirPaciente.Value)
                    {
                        cantidadwidth = xrcolCantidadC.WidthF;
                        totalwidht = xrcolTotalC.WidthF;
                        prestadornomwidht = xrcolPrestadornomC.WidthF;
                        prestadorcodwidht = xrcolPrestadorcodC.WidthF;

                        tabla.BeginInit();

                        tabla.DeleteColumn(xrcolPacienteC);

                        xrcolCantidadC.WidthF = cantidadwidth;
                        xrcolTotalC.WidthF = totalwidht;
                        xrcolPrestadornomC.WidthF = prestadornomwidht;
                        xrcolPrestadorcodC.WidthF = prestadorcodwidht;

                        tabla.EndInit();
                    }
                }
                
            }
            catch (Exception)
            {

            }

        }

        private void xrTableDetallesX_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRTable tabla = sender as XRTable;
                if (tabla == null) { return; }

                //PRINCIPAL ---> SI DEBO OCULTAR INFORMACION DEL PRESTADOR (SE OCULTA TODO, PRESTADOR Y PACIENTE, SOLO QUEDA LA DESCRIPCION CALCULADA)
                if (!(bool)MostrarInformacionPrestador.Value)
                {
                    cantidadwidth = xrcolCantidadX.WidthF;
                    totalwidht = xrcolTotalX.WidthF;

                    tabla.BeginInit();

                    tabla.DeleteColumn(xrcolPrestadorcodX);
                    tabla.DeleteColumn(xrcolPrestadornomX);
                    tabla.DeleteColumn(xrcolPacienteX);

                    xrcolCantidadX.WidthF = cantidadwidth;
                    xrcolTotalX.WidthF = totalwidht;

                    tabla.EndInit();
                }
                else
                {
                    //SI DEBO BORRAR UNA DE LAS COLUMNAS
                    if (!(bool)IncluirPaciente.Value)
                    {
                        cantidadwidth = xrcolCantidadX.WidthF;
                        totalwidht = xrcolTotalX.WidthF;
                        prestadornomwidht = xrcolPrestadornomX.WidthF;
                        prestadorcodwidht = xrcolPrestadorcodX.WidthF;

                        tabla.BeginInit();

                        tabla.DeleteColumn(xrcolPacienteX);

                        xrcolCantidadX.WidthF = cantidadwidth;
                        xrcolTotalX.WidthF = totalwidht;
                        xrcolPrestadornomX.WidthF = prestadornomwidht;
                        xrcolPrestadorcodX.WidthF = prestadorcodwidht;

                        tabla.EndInit();
                    }
                }

                
            }
            catch (Exception)
            {

            }
        }
    }
}
