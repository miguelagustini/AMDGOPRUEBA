using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Reportes
{
    public partial class Xrpt_Anestesiologia : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal importeEnti = 0;
        private decimal importeAm = 0;
        private decimal total = 0;


        public Xrpt_Anestesiologia()
        {
            InitializeComponent();
        }

        private void xrDiferencia_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            total = importeEnti - importeAm;
            ((XRLabel)sender).Text = total.ToString("#,#");
        }

        private void xrTableCell24_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            importeEnti = Convert.ToDecimal(e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()) ? e.Value : 0);
        }

        private void xrTableCell27_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            importeAm = Convert.ToDecimal(e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()) ? e.Value : 0);
        }
    }
}
