using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Linq;

namespace AMDGOINT.Formularios.Practicas.Vista
{
    public partial class Frm_PracticasMain : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();        
        private MC.Practica Practica = new MC.Practica();
        private List<MC.Practica> Practicas = new List<MC.Practica>();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private MC.Practica _practicatmp { get; set; } = new MC.Practica();

        private int indexrow = -1;


        private Frm_Convenidas UsrConvenidas = new Frm_Convenidas();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Point LocationSplash = new Point();

        private bool _canedit = false;
        private bool _cannew = false;

        public Frm_PracticasMain()
        {            
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            ctrls.setSplitter(splitter);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State == System.Data.ConnectionState.Open ? SqlConnection : cnb.Conectar();
            notificacionesBD.SqlConnection = SqlConnection;
            Practica.SqlConnection = SqlConnection; 
                        
            ctrls.PreferencesGrid(this, bgridView, "R");

            notificacionesBD.ID_Consulta = 4;
            notificacionesBD.ListenerChange();

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            _canedit = func.DevuelvePermiso("PracEdit", SqlConnection);
            _cannew = func.DevuelvePermiso("PracNew", SqlConnection);

            btnEditarbar.Enabled = _canedit;
            btNuevoBar.Enabled = _cannew;
                       
            
            ctrls.AgregaFormulario(UsrConvenidas, tabdetalles);
            //ICONOS            
            tabdetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BOContact2_16x16;
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

            tmrescucha.Stop();
            bgridView.BeginDataUpdate();
            Practicas.Clear();

            if (bgwRegistros.IsBusy) { return; }
            
            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            gridControl.DataSource = Practicas;
            bgridView.EndDataUpdate();            
                        
            if (bgridView.RowCount >= indexrow) { bgridView.FocusedRowHandle = indexrow; }

            tmrescucha.Start();

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }
             
        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Practica formulario = new Frm_Practica();
                formulario.Es_Popup = true;

                formulario.Practica = acc == "N" ? new MC.Practica() :
                                                     Practicas.Where(w => w == _practicatmp).
                                                     DefaultIfEmpty(new MC.Practica()).FirstOrDefault().Clone();

                if (formulario.ShowDialog(this) == DialogResult.OK)
                { indexrow = bgridView.FocusedRowHandle; Ibusqregistros(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario.\n{e.Message}", 0);
                return;
            }
        }

        //CAMBIO EL ESTADO DE LA PRÁCTICA
        private void Setestado()
        {
            try
            {

                string c = _practicatmp.Estado ? "deshabilitada" : "habilitada";
                if (ctrls.MensajePregunta($"¿Cambiar a {c} ésta práctica?") != DialogResult.Yes) { return; }

                MC.Practica pr = Practicas.Where(w => w == _practicatmp).FirstOrDefault()?.Clone();

                if (pr != null)
                {
                    Dictionary<short, string> retorno = new Dictionary<short, string>();
                    pr.SqlConnection = SqlConnection;
                    pr.Estado = !pr.Estado;
                    retorno = pr.Abm();

                    if (retorno.Count > 0)
                    {
                        string mensajes = "";

                        retorno.Where(w => w.Key != 1).Select(s => s.Value).ToList().ForEach(f => mensajes += $"{f.Trim()}\n");

                        if (!string.IsNullOrWhiteSpace(mensajes))
                        { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
                    }
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al ejecutar el cambio de estado.\n{e.Message}", 1);
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
            cnb.Desconectar();
            SqlConnection.Dispose();
            ctrls.PreferencesGrid(this, bgridView, "S");
        }
        
        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            Practicas = Practica.GetRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (bgridView.RowCount > 0 && _canedit) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }            
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            var est = bgridView.GetFocusedRowCellValue(colEstado);

            if (est != null && Convert.ToBoolean(est)) { btnEstadopract.Caption = "Deshabilitar"; }
            else { btnEstadopract.Caption = "Habilitar"; }            
            
        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            _practicatmp = new MC.Practica();

            if (bgridView.RowCount <= 0) { return; }
            _practicatmp = bgridView.GetRow(bgridView.FocusedRowHandle) as MC.Practica;

            if (_practicatmp != null)
            {
                UsrConvenidas.Detalles = _practicatmp.Convenidas;
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

        private void btnEstadopract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Setestado();
            
        }
    }
}