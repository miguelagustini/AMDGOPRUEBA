using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Linq;

namespace AMDGOINT.Formularios.Empresas.Vista
{
    public partial class Frm_Empresas : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();        
        private MC.Empresa Empresa = new MC.Empresa();
        private List<MC.Empresa> Empresas = new List<MC.Empresa>();

        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glb = new Globales();

        private MC.Empresa _empresa { get; set; } = new MC.Empresa();

        private int indexrow = -1;
                        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Point LocationSplash = new Point();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();
        
        public Frm_Empresas()
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
            Empresa.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, gridView, "R");

            notificacionesBD.ID_Consulta = 203;
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
            Empresas.Clear();

            if (bgwRegistros.IsBusy) { return; }
            
            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            gridControl.DataSource = Empresas;
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
                if (!Permisos.Where(w => w.Clave == "EmprEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la edición de empresas", 1);
                    return;
                }


                Frm_Empresa formulario = new Frm_Empresa();
                formulario.Es_Popup = true;

                formulario.Empresa = acc == "N" ? new MC.Empresa() : (_empresa != null ? _empresa.Clone() : new MC.Empresa());                                                     

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
            Empresas.Clear();
            Empresas.AddRange(Empresa.GetRegistros());
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            
            _empresa = new MC.Empresa();

            if (gridView.RowCount <= 0) { return; }
            _empresa = gridView.GetRow(gridView.FocusedRowHandle) as MC.Empresa;                        
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