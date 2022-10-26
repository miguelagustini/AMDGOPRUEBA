using DevExpress.XtraReports.UI;
using System.Linq;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Xtra_Factura : XtraReport
    {
        public Xtra_Factura()
        {
            InitializeComponent();
        }

        private void Detail2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var v = GetCurrentRow() as MC.Copias;

            var s = v.CopiasInfo.First()?.Factura.First()?.Letra;
            if (s != null)
            {

                if (s.ToString() == "A")
                {
                    DetallesB.Visible = false;
                    DetallesA.Visible = true;
                }
                else
                {
                    DetallesB.Visible = true;
                    DetallesA.Visible = false;
                }
            }
            else
            {                
                DetallesB.Visible = false;
                DetallesA.Visible = false;
            }
        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var v = GetCurrentRow() as MC.Copias;

            var s = v.CopiasInfo.First()?.Factura.First()?.Letra;
            if (s != null)
            {

                if (s.ToString() == "A")
                {
                    lblNetgrv.Visible = true;
                    lblIva21.Visible = true;
                    lbliva105.Visible = true;
                    lblNogravado.Visible = true;
                    numNeto.Visible = true;
                    numNogravado.Visible = true;
                    numIva21.Visible = true;
                    numIva105.Visible = true;

                }
                else
                {
                    lblNetgrv.Visible = false;
                    lblIva21.Visible = false;
                    lbliva105.Visible = false;
                    lblNogravado.Visible = false;
                    numNeto.Visible = false;
                    numNogravado.Visible = false;
                    numIva21.Visible = false;
                    numIva105.Visible = false;
                }
            }
            else
            {
                lblNetgrv.Visible = false;
                lblIva21.Visible = false;
                lbliva105.Visible = false;
                lblNogravado.Visible = false;
                numNeto.Visible = false;
                numNogravado.Visible = false;
                numIva21.Visible = false;
                numIva105.Visible = false;
            }
        }
    }
}
