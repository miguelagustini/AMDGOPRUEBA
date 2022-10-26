using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraGrid;
using System.IO;
using System.Net;

namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    public partial class Frm_Prestatarias : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();

        private MC.Prestataria Prestataria = new MC.Prestataria();
        private List<MC.Prestataria> Prestatarias = new List<MC.Prestataria>();
        
        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();               
        
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();
                
        private MC.Prestataria _prestataria;

        private Usr_Planes UsrPlanes = new Usr_Planes();
        private Usr_Contactos UsrContactos = new Usr_Contactos();
        private Usr_MovimientosCmpr UsrCuentaCorriente = new Usr_MovimientosCmpr();

        public Frm_Prestatarias()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            SetControles();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Prestataria.SqlConnection = SqlConnection;
            notificacionesBD.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;

            notificacionesBD.ID_Consulta = 1;
            notificacionesBD.ListenerChange();

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());
            VisualizacionControles();
        }

        private void VisualizacionControles()
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "MovCmpr" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).DefaultIfEmpty(false).FirstOrDefault())
                {
                    panelCtasCtes.Hide();
                }
                else { panelCtasCtes.Show(); }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetControles()
        {
            try
            {
                panelPlanes.Controls.Add(UsrPlanes);
                UsrPlanes.Dock = DockStyle.Fill;
                panelContactos.Controls.Add(UsrContactos);
                UsrContactos.Dock = DockStyle.Fill;
                panelCtasCtes.Controls.Add(UsrCuentaCorriente);
                UsrCuentaCorriente.Dock = DockStyle.Fill;                                                
            }
            catch (Exception)
            {

            }
        }

        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {
                tmrEscucha.Stop();

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;

            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Prestatarias.Clear();
                
                Prestatarias.AddRange(Prestataria.GetRegistros());                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al obtener los registros.\n{e.Message}", 1);
                return;
            }
        }

        //FIN DE CONSULTA REGISTROS
        private void FBusqRegistros()
        {

            try
            {
                gridControl.DataSource = Prestatarias;
                gridView.EndDataUpdate();

                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                tmrEscucha.Start();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;

            }
            
        }

        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Prestataria formulario = new Frm_Prestataria();
                formulario.SqlConnection = SqlConnection;

                if (!Permisos.Where(w => w.UsuarioID == glb.GetIdUsuariolog() && w.Clave == "PrestEdit").Select(s => s.Acceso).DefaultIfEmpty(false).FirstOrDefault())
                {
                    ctrls.MensajeInfo("No tiene permisos para realziar ésta acción.", 1);
                    return;
                }


                formulario.Prestataria = acc == "N" ? new MC.Prestataria() : _prestataria.Clone();

                ctrls.AgregaFormulario(formulario, glb.GetMaintab(), true);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al iniciar.\n {e.Message}", 0);
                return;
            }
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            IBusqRegistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {            
            ConexionBD.Desconectar();
            SqlConnection.Dispose();
            ctrls.PreferencesGrid(this, gridView, "S");
            ctrls.PreferencesGrid(this, dockManager, "S");
        }


        //******************* EVENTOS BACKGROUND *************************
     
        private void bgwObtienereg_DoWork(object sender, DoWorkEventArgs e)
        {
            GetRegistros();            
        }

        private void bgwObtienereg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FBusqRegistros();
        }
               
        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            if (popupMenu.Visible) { popupMenu.HidePopup(); }

            try
            {
                _prestataria = gridView.GetRow(gridView.FocusedRowHandle) as MC.Prestataria;

                if (_prestataria != null)
                {
                    MC.Plan P = new MC.Plan();
                    UsrPlanes.Planes.Clear();
                    UsrPlanes.Planes = P.Clone(_prestataria.Planes);

                    MC.AreaTrabajo a = new MC.AreaTrabajo();
                    UsrContactos.AreasTrabajo.Clear();
                    UsrContactos.AreasTrabajo = a.Clone(_prestataria.AreaTrabajo);
                                        
                    UsrCuentaCorriente.MovimientosComprobantes = _prestataria.MovimientosComprobantes.OrderByDescending(o => o.FechaEmision).ToList();
                    
                    
                }
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar los detalles de la prestataria.", 1);
            }

        }

        private void btnNuevo_ElementClick(object sender, NavElementEventArgs e)
        {            
            MuestroFormulario("N");
        }

        private void btnEditar_ElementClick(object sender, NavElementEventArgs e)
        {
            MuestroFormulario("E");

        }

        private void tmrEscucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                IBusqRegistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }
    }
    
}