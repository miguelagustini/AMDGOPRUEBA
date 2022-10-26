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
using AMDGOINT.Formularios.Devoluciones.MC;

namespace AMDGOINT.Formularios.Devoluciones.Vista
{
    public partial class Frm_Devoluciones : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();

        private DevolucionesEnc Reclamo = new DevolucionesEnc();
        private List<DevolucionesEnc> Reclamos = new List<DevolucionesEnc>();
        
        private Usr_Detalles UsrDetalles = new Usr_Detalles(false);
        private Usr_Eventos UsrEventos = new Usr_Eventos(false);

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private Notificacionesbd notificacionesbd = new Notificacionesbd();

        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();

        private MC.DevolucionesEnc _encabezado;
                
        private string Pathexport { get; set; } = "";
        
        public Frm_Devoluciones()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

            SetControles();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Reclamo.SqlConnection = SqlConnection;            
            Permiso.SqlConnection = SqlConnection;


            notificacionesbd.ID_Consulta = 12;
            notificacionesbd.SqlConnection = SqlConnection;
            notificacionesbd.ListenerChange();

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());            
        }

        private void SetControles()
        {
            try
            {
                panelDetalles.Controls.Add(UsrDetalles);
                UsrDetalles.Dock = DockStyle.Fill;

                panelEventos.Controls.Add(UsrEventos);
                UsrEventos.Dock = DockStyle.Fill;
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
                timerEscucha.Stop();
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                btnImpresion.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnActualizar.Enabled = false;
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnActualizar.Enabled = true;
                btnEditar.Enabled = true;
                gridView.EndDataUpdate();
                timerEscucha.Start();
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Reclamos.Clear();               
                Reclamos.AddRange(Reclamo.GetRegistros());                
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
                gridControl.DataSource = Reclamos;
                gridView.EndDataUpdate();                
                btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnActualizar.Enabled = true;

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnActualizar.Enabled = true;
                timerEscucha.Start();
            }
            
        }
              
       
        //GENERACION DEVOLUCION
        private void GeneraDevolucion(string acc = "N")
        {
            try
            {

                //PERMISOS GENERAL
                if (!Permisos.Where(w => w.Clave == "DevoEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar devoluciones.", 1);
                    return;
                }                              

                Frm_Devolucion frm = new Frm_Devolucion();
                frm.FormularioPadre = this;
                frm.SqlConnection = SqlConnection;

                frm.Permisos.Clear();
                frm.Permisos.AddRange(Permisos);

                if (_encabezado != null && acc == "E")
                {
                    if (_encabezado.Estado > 0)
                    {
                        ctrls.MensajeInfo("Ésta devolución ya fue finalizada y <b>NO</b> puede ser modificada.", 1);
                        frm.Dispose();
                        return;
                    }                    
                    
                    frm.Devolucion = _encabezado.Clone();
                    
                }
                else
                {
                    frm.Devolucion = new DevolucionesEnc();
                }                

                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
               
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //CREACIÓN DE EVENTO
        private bool RegistrarEvento()
        {
            try
            {
                if (_encabezado is null || _encabezado.IDRegistro <= 0)
                {
                    ctrls.MensajeInfo("No se puede generar un evento sin un identificador de reclamo.", 1);
                    return false;
                }

                //VALIDAR NO  AGREGAR SI ESTA TERMINADO
                if (_encabezado.Estado > 0)
                {
                    ctrls.MensajeInfo("No se puede generar un evento para una devolución finalzada", 1);
                    return false;
                }

                Frm_EventoPopup frm = new Frm_EventoPopup();
                frm.SqlConnection = SqlConnection;
                frm.Evento.IDEncabezado = _encabezado.IDRegistro;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridView.BeginDataUpdate();
                    _encabezado.Eventos.Add(frm.Evento);
                    gridView.EndDataUpdate();
                    return true;
                }
                else { return false; }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al registrar el evento.\n{e.Message}", 1);
                return false;
            }
        }
        
       
        //CIERRE / ANULACION  DE DEVOLUCION
        private void EstadoDevolucion(byte estado)
        {
            try
            {
                if (_encabezado is null || _encabezado.Estado > 0) { return; }
                                
                string palabra = estado == 1 ? "cerrar" : "anular";
                if (ctrls.MensajePregunta($"¿Está seguro de {palabra} la devolución?\nDe ser si, se solicitará registrar un evento.\nLuego las urgencias del mismo\nserán marcadas como <b>Normal</b>.") != DialogResult.Yes) { return; }

                if (!RegistrarEvento())
                {
                    ctrls.MensajeInfo("No se puede cambiar el estado de la devolución sin un evento.", 1);
                    return;
                }
               
                gridView.BeginDataUpdate();
                _encabezado.Estado = estado;                
                _encabezado.FechaCierre = DateTime.Now;
                _encabezado.Abm(false);
                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {                
                ctrls.MensajeInfo($"Hubo un inconveniente al cerrar el reclamo.\n{e.Message}", 1);
                gridView.EndDataUpdate();
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

        private void NavPanel_ElementClick(object sender, NavElementEventArgs e)
        {
            /*if (e.IsTile)
            {
                if (gridView.RowCount <= 0) { return; }
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnPrevisualizacion": PreparaImpresion(0) ; break;
                    case "btnPdf": PreparaImpresion(1); break;
                    case "btnExcel": ExportaExcel(); break;
                    case "btnExportacionweb": PreparaImpresion(1); break;                     
                }

            }*/
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
                _encabezado = gridView.GetRow(gridView.FocusedRowHandle) as DevolucionesEnc;
                if (_encabezado != null)
                {
                    UsrDetalles.IDPrestador = _encabezado.PrestadorID;
                    UsrDetalles.Detalles = _encabezado.Detalles;
                    UsrDetalles.IDDevolucion = _encabezado.IDRegistro;                    

                    UsrEventos.Eventos = _encabezado.Eventos;
                    UsrEventos.IDDevolucion = _encabezado.IDRegistro;
                }
                
                
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar los detalles de la factura.", 1);
            }

        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  PreparaImpresion(0, true);
        }

        private void btnNuevo_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraDevolucion();
        }

        private void btnEditar_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraDevolucion("E");
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {                
                if (e.RowHandle != GridControl.NewItemRowHandle && e.Column.FieldName == "DevolucionNumero")
                {                    
                    var v = gridView.GetRowCellValue(e.RowHandle, "EstadoDescripcion");
                    if (v?.ToString() == "Finalizado"){ e.RepositoryItem = reposFinalizado; }
                    else if (v?.ToString() == "Anulado") { e.RepositoryItem = reposAnulado; }
                    else { e.RepositoryItem = reposProceso; }
                }
            }
            catch (Exception)
            {
                return;                
            }
        }

        private void timerEscucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesbd.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                IBusqRegistros();
                notificacionesbd.Accionejecutada = SqlNotificationInfo.Truncate;
                UsrEventos.FuerzaCargaCmb = !UsrEventos.FuerzaCargaCmb;
            }
        }

        private void btnActualizar_ElementClick(object sender, NavElementEventArgs e)
        {
            IBusqRegistros();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {
                btnCerrar.Visibility = _encabezado != null && _encabezado.Estado <= 0 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnEvento.Visibility = _encabezado != null && _encabezado.Estado <= 0 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnAnular.Visibility = _encabezado != null && _encabezado.Estado <= 0 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void btnCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EstadoDevolucion(1);
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EstadoDevolucion(2);
        }

        private void btnEvento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RegistrarEvento();
        }

    }
    
}