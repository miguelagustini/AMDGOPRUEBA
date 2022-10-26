using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;
using System.Linq;
using System.Data;
using System.Drawing;
using AMDGOINT.Formularios.Informes;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_ArancelesMain : DevExpress.XtraEditors.XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Arancelesclass aranceles = new Arancelesclass();

        private int IDRegistro { get; set; } = 0;
        private int indexrow = -1;
        private bool Cambiarow = false;
        private Point LocationSplash = new Point();

        public Frm_ArancelesMain()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            ctrls.setSplitter(splitter);
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250,
                                      workingArea.Top + 73);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {            
            ctrls.PreferencesGrid(this, bgridView, accion: "R");

            notificacionesBD.ID_Consulta = 6;
            notificacionesBD.ListenerChange();

            tmrDetalles.Start();

            
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            screenManager.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;
            screenManager.ShowWaitForm();

            tmrescucha.Stop();
            bgridView.BeginDataUpdate();
            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {            
            bgridView.EndDataUpdate();
            gridControl.DataSource = aranceles.aranencabezados;

            screenManager.CloseWaitForm();

            if (bgridView.RowCount >= indexrow) { bgridView.FocusedRowHandle = indexrow; }

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
                    formulario.arancelmain = new ArancelesEncabezado();
                }
                else
                {
                    if (!PuedoEditar())
                    {
                        ctrls.MensajeInfo("No se puede editar una valorización que pertenece a discusiones cerradas.", 1);
                        return;
                    }

                    formulario.arancelmain = aranceles.aranencabezados.Where(r => r.IDRegistro == IDRegistro).First().Clone();                    
                }

                ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DETERMINO SI EL ARANCEL PUEDE SER EDITADO
        private bool PuedoEditar()
        {
            bool retorno = true;

            try
            {
                if (IDRegistro <= 0) { return retorno; }

                string c = $"SELECT * FROM DISCUSIONENC WHERE ID_AranValoriza = {IDRegistro} AND Estado = 1";

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
                if (IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Estado");
                parametros.Add(estado);

                func.AccionBD(campos, parametros, "U", "ARANVALORIZAENC", IDRegistro);
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

            ctrls.PreferencesGrid(this, bgridView, accion: "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            aranceles.ListarAranceles();
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

        private void tmrDetalles_Tick(object sender, EventArgs e)
        {
            if (Cambiarow)
            {
                //frmdetalles.IDPrestataria = IDRegistro;
                //frmdetalles.CargarRegistro();
                
                Cambiarow = false;
            }
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
            var v = bgridView.GetFocusedRowCellValue(colEstado);

            if (v != null && !Convert.ToBoolean(v)) { btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }
            else { btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }
        }

        private void btnHistoaranc_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Frm_AranEstadistica frm = new Frm_AranEstadistica();            
            ctrls.AgregaFormulario(frm, globales.GetMaintab(), false);
        }

    }
}