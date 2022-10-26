using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Recibos.Vista
{
    public partial class Xtra_Recibo : DevExpress.XtraReports.UI.XtraReport
    {
        private float width1 = 0;
        private float width2 = 0;


        public Xtra_Recibo()
        {
            InitializeComponent();
        }

        private void Xtra_Recibo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!(bool)MostrarCuentas.Value)
            {
                width1 = detCelltotal.WidthF;
                width2 = detCellComprobante.WidthF;

                xrTable2.BeginInit();

                xrTable2.DeleteColumn(detCellCuenta);
                xrTable2.DeleteColumn(detCellSubcuenta);

                detCelltotal.WidthF = width1;
                detCellComprobante.WidthF = width2;

                xrTable2.EndInit();
            }
        }
    }
}
