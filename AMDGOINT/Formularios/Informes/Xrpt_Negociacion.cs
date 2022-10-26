using System;

namespace AMDGOINT.Formularios.Informes
{
    public partial class Xrpt_Negociacion : DevExpress.XtraReports.UI.XtraReport
    {
        private float width1 = 0;
        private float width2 = 0;
        private float width3 = 0;
        private float width4 = 0;
        private float width5 = 0;
        private float width6 = 0;
        private float width7 = 0;
        private float width8 = 0;
        private float width9 = 0;
        private float width10 = 0;
        private float width11 = 0;
        private float width12 = 0;

        public Xrpt_Negociacion()
        {
            InitializeComponent();
        }

        private void Xrpt_Negociacion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                //SI DEBO BORRAR UNA DE LAS COLUMNAS
                if (!(bool)HideCoseguro.Value || !(bool)HideCopago.Value)
                {
                    /*********** tabla encabezado  *****************************/
                    //GUARDO EL ANCHO DE LOS ENCABEZADOS QUE NO DEBEN REDIMENSIONARSE
                    width1 = colencAm.WidthF;
                    width2 = colencOs.WidthF;
                    width3 = colencDescrip.WidthF;
                    width4 = colencobs.WidthF;
                    width5 = colencfunc.WidthF;
                    width6 = colenccodgas.WidthF;

                    xrTable1.BeginInit();

                    if (!(bool)HideCoseguro.Value) { xrTable1.DeleteColumn(colHeadCoseguro); }
                    if (!(bool)HideCopago.Value) { xrTable1.DeleteColumn(colHeadCopago); }

                    colencAm.WidthF = width1;
                    colencOs.WidthF = width2;
                    colencDescrip.WidthF = width3;
                    colencobs.WidthF = width4;
                    colencfunc.WidthF = width5;
                    colenccodgas.WidthF = width6;

                    xrTable1.EndInit();


                    /****************** DETALLES *************************************/
                    //TABLA VALORES EN DETALLES

                    width7 = coldetam.WidthF;
                    width8 = coldetos.WidthF;
                    width9 = coldetdescr.WidthF;
                    width10 = coldetobs.WidthF;
                    width11 = coldetFunc.WidthF;
                    width12 = coldetGasto.WidthF;


                    xrTable5.BeginInit();

                    if (!(bool)HideCoseguro.Value) { xrTable5.DeleteColumn(colDetCoseguro); }
                    if (!(bool)HideCopago.Value) { xrTable5.DeleteColumn(colDetCopago); }

                    coldetam.WidthF = width7;
                    coldetos.WidthF = width8;
                    coldetdescr.WidthF = width9;
                    coldetobs.WidthF = width10;
                    coldetFunc.WidthF = width11;
                    coldetGasto.WidthF = width12;

                    xrTable5.EndInit();

                    /* ************* VALORES OTROS ************************/
                    //TABLA VALORES EN OTROS

                    width7 = colotroAm.WidthF;
                    width8 = colotroOs.WidthF;
                    width9 = colotroDescr.WidthF;
                    width10 = colotroObs.WidthF;

                    xrTable4.BeginInit();

                    if (!(bool)HideCoseguro.Value) { xrTable4.DeleteColumn(colOtroscose); }
                    if (!(bool)HideCopago.Value) { xrTable4.DeleteColumn(colOtroscopa); }

                    colotroAm.WidthF = width7;
                    colotroOs.WidthF = width8;
                    colotroDescr.WidthF = width9;
                    colotroObs.WidthF = width10;


                    xrTable4.EndInit();

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
