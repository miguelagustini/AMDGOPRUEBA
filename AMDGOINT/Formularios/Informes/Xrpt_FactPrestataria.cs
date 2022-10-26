using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Informes
{
    public partial class Xrpt_FactPrestataria : DevExpress.XtraReports.UI.XtraReport
    {
        private NumeroaLetras Numeroaletras = new NumeroaLetras();

        public Xrpt_FactPrestataria()
        {
            InitializeComponent();
        }

        private void xrLabel49_TextChanged(object sender, EventArgs e)
        {
            XRLabel lbl = sender as XRLabel;
            xrLabel50.Text = Numeroaletras.enletras(lbl.Text.ToString().Replace("$", "").Trim()).ToUpperInvariant();
        }

        private void xrLabel46_TextChanged(object sender, EventArgs e)
        {
            XRLabel lbl = sender as XRLabel;
            xrLabel47.Text = Numeroaletras.enletras(lbl.Text.ToString().Replace("$", "").Trim()).ToUpperInvariant();
        }

        private void xrLabel40_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
           
        }
    }
}
