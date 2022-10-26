using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace AMDGOINT.Formularios.Profesionales.CuentasConjuntas
{
    public partial class Frm_CuentasConjuntas : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cnb = new ConexionBD();                
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glb = new Globales();

        private MC.Cuentas Cuenta = new MC.Cuentas();
        private List<MC.Cuentas> CuentasCtes = new List<MC.Cuentas>();
                
        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Point LocationSplash = new Point();
                
        public Frm_CuentasConjuntas()
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
            Cuenta.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;
            ctrls.PreferencesGrid(this, gridView, "R");
                        
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
                        
        }
        
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            try
            {               
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                               
                if (bgwRegistros.IsBusy) { return; }

                gridView.BeginDataUpdate();
                CuentasCtes.Clear();
                btnBuscar.Enabled = false;

                bgwRegistros.RunWorkerAsync();
            }
            catch (Exception e)
            {                
                ctrls.MensajeInfo($"Hubo un inconveniente al iniciar la búsqueda.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                btnBuscar.Enabled = true;
                return;

            }            
        }

        //BUSQUEDA
        private void Ebusqregistros()
        {
            try
            {
                //EJECUTO LA BUSQUEDA DE REGISTROS
                //AL MISMO TIEMPO, ASIGNO EL COMBO DE CUENTAS CONJUNTAS YA QUE DEBE SER LA LISTA COMPLETA DE CUENTAS
                CuentasCtes.AddRange(Cuenta.GetRegistros());
                cmbCuentaConjunta.DataSource = CuentasCtes;


                //CARGA PERMISOS
                if (Permisos.Count <= 0) { Permisos.AddRange(Permiso.GetPermisoUsuario()); }
                
            }
            catch (Exception)
            {
                return;
            }
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            try
            {
                gridControl.DataSource = CuentasCtes;
                gridView.EndDataUpdate();
                btnBuscar.Enabled = true;
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                btnBuscar.Enabled = true;
                return;
            }
            
        }

        private void ActualizaCuentaPrestador()
        {
            try
            {
                MC.Cuentas det = gridView.GetRow(gridView.FocusedRowHandle) as MC.Cuentas;

                if (det != null)
                {
                    det.SqlConnection = SqlConnection;
                    det.Abm();
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al guardar la cuenta.\n{e.Message}", 1);
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
            Ebusqregistros();
            
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }
        
        private void btnBuscar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Ibusqregistros();
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.RowHandle != GridControl.NewItemRowHandle && e.Column.FieldName == "EsProfesionalDescripcion")
                {
                    if (e.CellValue.ToString() == "Profesional")
                    { e.RepositoryItem = repositoryTextSI; }
                    else { e.RepositoryItem = repositoryTextNO; }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnExportaExcel_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (!Permisos.Where(w => w.Clave == "CtasCjtExp" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene permisos para realizar exportaciones.", 1);                
                return;
            }

            ctrls.ExportaraExcelgrd(gridControl);
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }

        private void gridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            //CENTRADO DE FORM
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_EditFormShowing(object sender, DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs e)
        {
            if (!Permisos.Where(w => w.Clave == "CtasCjtEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene permisos para realizar ediciones.", 1);
                e.Allow = false;
                return;
            }
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView v = gridView;
                GridColumn c = new GridColumn();

                MC.Cuentas det = v.GetRow(v.FocusedRowHandle) as MC.Cuentas;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    // IMPORTE CANCELADO
                    if (det.IDCuentaConjuntoContable <= 0)
                    { e.Valid = false; c = colCuentaConjunta; }
                    
                    if (!e.Valid) { v.SetColumnError(c, errorstring); }
                }

                
            }
            catch (Exception)
            {

            }
        }

        private void gridView_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            ActualizaCuentaPrestador();
        }
    }
}