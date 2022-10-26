using System;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Xtra_ControlAmbuppp : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_ControlAmbuppp()
        {
            InitializeComponent();
        }

        private int c = 0;

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {            
            if (c <= 0) { e.Cancel = true; }
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // if (c <= 0) { e.Cancel = true; }
        }

        private void Detail1_AfterPrint(object sender, EventArgs e)
        {
            c++;
        }
    }
}
