using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;
using System.Drawing;
using DevExpress.XtraSplashScreen;

namespace AMDGOINT.Formularios.Prestatarias
{
    public partial class Frm_PrestatariasMain : DevExpress.XtraEditors.XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private PrestatariasControlador prestatctrl = new PrestatariasControlador();
        private List<PrestatariasStrc> Prestatariaslist = new List<PrestatariasStrc>();
        private Frm_PrDetalles frmdetalles = new Frm_PrDetalles();        

        private int IDRegistro { get; set; } = 0;
        private int indexrow = -1;
        private bool Cambiarow = false;
        private Point LocationSplash = new Point();

        public Frm_PrestatariasMain()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            ctrls.setSplitter(splitter);

            ctrls.setSplitter(splitter);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {            
            ctrls.PreferencesGrid(this, bgridView, "R");
            
            ctrls.AgregaFormulario(frmdetalles, tabdetalles);            

            //ICONOS            
            tabdetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;            

            notificacionesBD.ID_Consulta = 1;
            notificacionesBD.ListenerChange();

            tmrDetalles.Start();

            tabdetalles.SelectedTabPageIndex = 0;
                        
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            ControlAcceso();
        }

        //Control de acceso usuario
        private void ControlAcceso()
        {
            try
            {
                btnEditarbar.Enabled = func.DevuelvePermiso("PrestEdit");
                btNuevoBar.Enabled = func.DevuelvePermiso("PrestNew");
                
            }
            catch (Exception)
            {
                btnEditarbar.Enabled = false;
                btNuevoBar.Enabled = false;
                return;
            }
        }

        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

            tmrescucha.Stop();
            bgridView.BeginDataUpdate();            
            Prestatariaslist.Clear();

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {           
            
            gridControl.DataSource = Prestatariaslist;
            bgridView.EndDataUpdate();
            
                        
            if (bgridView.RowCount >= indexrow) { bgridView.FocusedRowHandle = indexrow; }

            tmrescucha.Start();
            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }

        //PROCESO LA ACTUALIZACION DEL IVA OCULTO
        private void ProcesoIvaoculto()
        {
            try
            {
                indexrow = bgridView.FocusedRowHandle;

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("IvaOculto");
               // parametros.Add(!Convert.ToBoolean(bgridView.GetFocusedRowCellValue(colIvaOculto)));

                prestatctrl.ActualizoPrestataria(IDRegistro, campos, parametros);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al actualizar el registro.\n" + e.Message, 0);
                return;
            }
            
        }

        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Prestataria formulario = new Frm_Prestataria();
                formulario.Es_Popup = true;

                if (acc == "N") { formulario.IDRegistro = 0; } else { formulario.IDRegistro = IDRegistro; }

                if (formulario.ShowDialog(this) == DialogResult.OK)
                { indexrow = bgridView.FocusedRowHandle; Ibusqregistros(); }
            }
            catch (Exception)
            {

                throw;
            }
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
            splitter.SplitterPosition = (splitter.Height / 2);
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridView, "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {            
            Prestatariaslist =  prestatctrl.CargarRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void btnIvaOculto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcesoIvaoculto();
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            
        }
        

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
           // if (popupMenu.Visible) { popupMenu.HidePopup(); }

            IDRegistro = 0;

            if (bgridView.RowCount <= 0) { return; }

            var idreg = bgridView.GetFocusedRowCellValue(colID_Registro);

            if (idreg != null)
            {
                IDRegistro = Convert.ToInt32(idreg);
                Cambiarow = true;
            }
        }

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }
        
        private void btNuevoBar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void tmrDetalles_Tick(object sender, EventArgs e)
        {
            if (Cambiarow)
            {
                frmdetalles.IDPrestataria = IDRegistro;
                frmdetalles.CargarRegistro();                
                Cambiarow = false;
            }
        }
    }
}