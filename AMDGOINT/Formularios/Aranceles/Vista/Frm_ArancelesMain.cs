using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Collections.Generic;

namespace AMDGOINT.Formularios.Aranceles.Vista
{
    public partial class Frm_ArancelesMain : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private MC.Arancel Arancel = new MC.Arancel();
        private MC.Arancel _aranceltmp = new MC.Arancel();
        private List<MC.Arancel> Aranceles = new List<MC.Arancel>();
        private MC.Detalles Detalles = new MC.Detalles();

        private Arancelesclass aranceles = new Arancelesclass();
        private bool _canedit = false;
        private int IDRegistro { get; set; } = 0;        
        private Point LocationSplash = new Point();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        public Frm_ArancelesMain()
        {            
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            ctrls.setSplitter(splitter);
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {

            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            notificacionesBD.SqlConnection = SqlConnection;
            Arancel.SqlConnection = SqlConnection;
            Detalles.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, gridView, accion: "R");

            notificacionesBD.ID_Consulta = 6;
            notificacionesBD.ListenerChange();

            splitter.SplitterPosition = (splitter.Height / 2);

            _canedit = func.DevuelvePermiso("AraEdit");
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            screenManager.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;
            if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); } 

            tmrescucha.Stop();
            gridView.BeginDataUpdate();
            gridView.BeginInit();
            
            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {            
            gridControl.DataSource = Aranceles.OrderByDescending(o => o.Fecha);
            gridView.EndDataUpdate();
            gridView.EndInit();

            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
            
            tmrescucha.Start();
        }               

        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Arancel formulario = new Frm_Arancel();

                if (acc == "N")
                {
                    MC.Arancel a = new MC.Arancel();                    
                    a.Detalles.AddRange(Detalles.GetLastDetalle());

                    formulario.Arancel = a;
                }
                else { formulario.Arancel = Aranceles.Where(w => w == _aranceltmp).FirstOrDefault().Clone(); }                
                

                if (!PuedoEditar())
                {
                    ctrls.MensajeInfo("No se puede editar una valorización que pertenece a discusiones cerradas.", 1);
                    return;
                }

                ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al iniciar la edición.\n{e.Message}", 1);
                return;
            }
        }

        //DETERMINO SI EL ARANCEL PUEDE SER EDITADO
        private bool PuedoEditar()
        {
            bool retorno = true;

            try
            {
                if (IDRegistro <= 0) { return retorno; }

                string c = $"SELECT * FROM DISCUSIONENC WHERE ID_AranValoriza = {IDRegistro} AND Estado >= 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows) { retorno = false; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al consultar la disponibilidad de Edición.\n {e.Message}", 0);
                return retorno;
            }
        }

        //CIERRO EL ESTADO DE LA VALORIZACION
        private void SetEstadovaloriza(bool estado)
        {
            try
            {
                if (!_canedit)
                {
                    ctrls.MensajeInfo("No tiene permisos de edición", 1);
                    return;
                }

                if (_aranceltmp.IDRegistro <= 0) { return; }

                _aranceltmp.Estado = !_aranceltmp.Estado;
                _aranceltmp.SqlConnection = SqlConnection;
                _aranceltmp.Abm(false);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al finalizar el estado.\n {e.Message}", 0);
                return;
            }
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, gridView, accion: "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            Aranceles.Clear();
            Aranceles.AddRange(Arancel.GetRegistros());
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }
        
        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            _aranceltmp = (gridView.GetRow(gridView.FocusedRowHandle) as MC.Arancel);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.RowCount > 0) { MuestroFormulario("E"); }
        }

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }

        private void btnNuevaprest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarprest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void btNuevoBar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void btnCerrarValoriza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            if (ctrls.MensajePregunta("¿Está seguro de finalizar ésta valorización?") == DialogResult.Yes)
            {                
                SetEstadovaloriza(true);
            }
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            if (gridView.RowCount <= 0)
            {
                btnEditarprest.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnEditarprest.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (!_aranceltmp.Estado) { btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }
                else { btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }
            }
            
        }

        private void btnHistoaranc_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Frm_AranEstadistica frm = new Frm_AranEstadistica();            
            ctrls.AgregaFormulario(frm, globales.GetMaintab(), false);
        }
    }
}