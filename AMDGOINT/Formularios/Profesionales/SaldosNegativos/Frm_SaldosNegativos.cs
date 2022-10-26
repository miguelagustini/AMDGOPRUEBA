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

namespace AMDGOINT.Formularios.Profesionales.SaldosNegativos
{
    public partial class Frm_SaldosNegativos : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cnb = new ConexionBD();                
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private MC.Cuentas Cuenta = new MC.Cuentas();
        private List<MC.Cuentas> CuentasCtes = new List<MC.Cuentas>();

        private DateTime _fechabusqueda = DateTime.Today;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Point LocationSplash = new Point();
                
        public Frm_SaldosNegativos()
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
                        
            ctrls.PreferencesGrid(this, gridView, "R");
                        
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
                                  
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            try
            {
                Usr_ParametrosBusqueda parametros = new Usr_ParametrosBusqueda();

                if (XtraDialog.Show(parametros, "Parámetros de búsqueda", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }
                _fechabusqueda = parametros.FechaHasta;
                parametros.Dispose();

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
            CuentasCtes.AddRange(Cuenta.GetSaldosNegativos(_fechabusqueda));
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
            ctrls.ExportaraExcelgrd(gridControl);
        }
    }
}