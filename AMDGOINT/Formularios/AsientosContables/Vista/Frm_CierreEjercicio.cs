using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Frm_CierreEjercicio : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private OverlayPanel OverlayPanel = new OverlayPanel();
                
        public MC.CierreEjercicio CierreEjercicio  = new MC.CierreEjercicio();        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private Dictionary<short, string> ResultadoProceso = new Dictionary<short, string>();

        public Frm_CierreEjercicio()
        {
            InitializeComponent();                        
        }

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            CierreEjercicio.SqlConnection = SqlConnection;
            
        }

        #region EVENTOS FORMULARIO
        private void Frm_Exportacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnb.Desconectar();  
        }

        private void Frm_CierreEjercicio_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_ResumenFacturas_Shown(object sender, EventArgs e)
        {
            Iprocesacierre();
        }


        #endregion

        #region METODOS MANUALES

        private void Iprocesacierre()
        {
            try
            {
                OverlayPanel.Mostrar(this);

                if (bgwProcesaCierre.IsBusy) { return; }
                tmrLabel.Start();
                bgwProcesaCierre.RunWorkerAsync();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                tmrLabel.Stop();
                return;
            }
        }

        private void ProcesaCierre()
        {
            try
            {
                ResultadoProceso = CierreEjercicio.CierraEjercicioContable();
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return;
            }
        }

        private void Fprocesacierre()
        {
            try
            {
                OverlayPanel.Ocultar();
                tmrLabel.Stop();
                if (ResultadoProceso.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in ResultadoProceso.Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); }

                    DialogResult = DialogResult.Abort;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                tmrLabel.Stop();
                return;
            }
        }

        #endregion

        private void bgwProcesaCierre_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcesaCierre();
        }

        private void bgwProcesaCierre_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void bgwProcesaCierre_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fprocesacierre();            
        }

        private void tmrLabel_Tick(object sender, EventArgs e)
        {
            lblInformacion.Text = CierreEjercicio.ProcesoActual;
        }
    }
}
