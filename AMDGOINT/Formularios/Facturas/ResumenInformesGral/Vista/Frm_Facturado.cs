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
using AMDGOINT.Formularios.Recibos.MC;

namespace AMDGOINT.Formularios.Facturas.ResumenInformesGral.Vista
{
    public partial class Frm_Facturado : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();        
        private Funciones func = new Funciones();

        private MC.FacturacionResumen clsFacturacion = new MC.FacturacionResumen();
        private List<MC.FacturacionResumen> FacturacionLst = new List<MC.FacturacionResumen>();
                
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();
                
        public Frm_Facturado()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
                        
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            clsFacturacion.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, gridView, "R");
            
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

        }
        
        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {                
                Frm_ParametrosFacturado parametros = new Frm_ParametrosFacturado();
                if (parametros.ShowDialog() != DialogResult.OK)
                { parametros.Dispose(); return; }

                if (parametros.PrestatariaPlanCodigo == "" || parametros.Periodo == "")
                {
                    ctrls.MensajeInfo("No se puede continuar sin parámetros.", 1);
                    parametros.Dispose();
                    return;
                }

                clsFacturacion._filterctaprestataria = parametros.PrestatariaPlanCodigo;
                clsFacturacion._filterperiodo = parametros.Periodo;

                parametros.Dispose();

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }                
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {                
                gridView.EndDataUpdate();                
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                FacturacionLst.Clear();
                FacturacionLst.AddRange(clsFacturacion.GetRegistros());                
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
                gridControl.DataSource = FacturacionLst;
                gridView.EndDataUpdate();                                

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();                
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
                
        private void btnBuscar_ElementClick(object sender, NavElementEventArgs e)
        {
            IBusqRegistros();
        }

        private void btnExportExcel_ElementClick(object sender, NavElementEventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);
        }
    }
    
}