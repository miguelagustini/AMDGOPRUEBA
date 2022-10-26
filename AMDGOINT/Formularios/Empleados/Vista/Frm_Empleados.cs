using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Linq;

namespace AMDGOINT.Formularios.Empleados.Vista
{
    public partial class Frm_Empleados : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();        
        private MC.Empleado Empleado = new MC.Empleado();
        private List<MC.Empleado> Empleados = new List<MC.Empleado>();

        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glb = new Globales();

        private MC.Empleado _Empleado { get; set; } = new MC.Empleado();

        private int indexrow = -1;
                        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Point LocationSplash = new Point();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();
        
        public Frm_Empleados()
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
            Empleado.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, gridView, "R");

            notificacionesBD.ID_Consulta = 204;
            notificacionesBD.ListenerChange();

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

            tmrescucha.Stop();
            gridView.BeginDataUpdate();
            Empleados.Clear();

            if (bgwRegistros.IsBusy) { return; }
            
            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            gridControl.DataSource = Empleados;
            gridView.EndDataUpdate();            
                        
            if (gridView.RowCount >= indexrow) { gridView.FocusedRowHandle = indexrow; }

            tmrescucha.Start();

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }
             
        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                if (acc == "N" && !Permisos.Where(w => w.Clave == "EmplNew" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para crear Empleados", 1);
                    return;
                }
                else if (acc != "N" && !Permisos.Where(w => w.Clave == "EmplEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para editar Empleados", 1);
                    return;
                }


                Frm_Empleado formulario = new Frm_Empleado();
                formulario.Es_Popup = true;

                formulario.Empleado = acc == "N" ? new MC.Empleado() : (_Empleado != null ? _Empleado.Clone() : new MC.Empleado());                                                     

                if (formulario.ShowDialog(this) == DialogResult.OK)
                { indexrow = gridView.FocusedRowHandle; Ibusqregistros(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario.\n{e.Message}", 0);
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
            ctrls.PreferencesGrid(this, gridView, "S");
        }
        
        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            Empleados.Clear();
            Empleados.AddRange(Empleado.GetRegistros());
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            
            _Empleado = new MC.Empleado();

            if (gridView.RowCount <= 0) { return; }
            _Empleado = gridView.GetRow(gridView.FocusedRowHandle) as MC.Empleado;                        
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
    }
}