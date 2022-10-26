using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;
using System.Data;
using DevExpress.XtraSplashScreen;
using System.Drawing;
using System.Threading;
using DevExpress.XtraPivotGrid;
using System.Collections;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_AranEstadistica : DevExpress.XtraEditors.XtraForm
    {        
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Arancelesclass aranceles = new Arancelesclass();
        
        private List<ArancelesHistorico> aranhisto = new List<ArancelesHistorico>();
        
        public Frm_AranEstadistica()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            ctrls.setSplitter(splitter);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {            
            ctrls.PreferencesPivot(formulario: this, grilla: pivotControl, accion: "R");
            fieldGrupoPractica.SortMode = PivotSortMode.Custom;
        }
         
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            ScreenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScreenManager.SplashFormLocation = new Point(NavPanel.Width - 198, 61);
            ScreenManager.ShowWaitForm();   
            
            pivotControl.Visible = false;
            pivotControl.DataSource = "";            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //CARGA DE REGISTROS
        private void CargarRegistros()
        {
            try
            {
                aranhisto.Clear();
                aranceles.CargarHistorico();
                aranhisto = aranceles.aranceleshistorico;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los registros.\n" + e.Message, 0);
                return;
            }
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {

            ScreenManager.CloseWaitForm();
            pivotControl.DataSource = aranhisto;
            pivotControl.RefreshData();
            pivotControl.Visible = true;

        }


        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            //splitter.SplitterPosition = (splitter.Height / 2);
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {            
            ctrls.PreferencesPivot(formulario: this, grilla: pivotControl, accion: "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            CargarRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }
                
        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
           
        }

        private void btnExpexcel_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            ctrls.ExportaraExcelpvgr(pivotControl);            
            
        }

        private void btnActualiza_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Ibusqregistros();            
        }

        private void pivotControl_CustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
        {
            if (e.Field.FieldName == "GrupoPractica")
            {
                if (e.SortLocation == PivotSortLocation.Pivot)
                {
                    object orderValue1 = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "GrupoOrden"),
                        orderValue2 = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "GrupoOrden");
                    e.Result = Comparer.Default.Compare(orderValue1, orderValue2);
                }
                else
                {
                    e.Result = Comparer.Default.Compare(e.Value1.ToString().Split(' ')[1], e.Value2.ToString().Split(' ')[1]);
                }
                e.Handled = true;
            }
        }
    }
}