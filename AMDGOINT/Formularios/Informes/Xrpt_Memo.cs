using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Informes
{
    public partial class Xrpt_Memo : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_Memo()
        {
            InitializeComponent();
        }

        private void Xrpt_Memo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            //POR AGRUPADOR
            if (!Convert.ToBoolean(Parameters["GrupoSeleccion"].Value))
            {
                if (GroupHeaderPlanes.GroupFields.Count >= 1) { GroupHeaderPlanes.GroupFields.RemoveAt(0); }
                ReportPrintOptions.DetailCount = 1;
                ReportPrintOptions.DetailCountAtDesignTime = 1; 

            }
            //POR PLAN
            else { if (GroupHeaderAgrupador.GroupFields.Count >= 1) { GroupHeaderAgrupador.GroupFields.RemoveAt(0); } }
        }

        private void GroupHeaderAgrupador_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Convert.ToBoolean(Parameters["GrupoSeleccion"].Value)) { e.Cancel = true; }
        }

        private void GroupHeaderPlanes_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!Convert.ToBoolean(Parameters["GrupoSeleccion"].Value)) { e.Cancel = true; }
        }
    }
}
