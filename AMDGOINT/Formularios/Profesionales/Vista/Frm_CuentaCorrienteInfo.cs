using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.Linq;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_CuentaCorrienteInfo : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();        
        private ConexionBD cb = new ConexionBD();

        private MC.CuentaCorriente.CuentaCorriente CuentaCorriente = new MC.CuentaCorriente.CuentaCorriente();
        private List<MC.CuentaCorriente.CuentaCorriente> CuentasCorrientes = new List<MC.CuentaCorriente.CuentaCorriente>();
        
        private int idcuentaprof = 0;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        public int PrestadorCuentaID
        {
            get { return idcuentaprof; }
            set
            {
                if (idcuentaprof != value)
                {
                    idcuentaprof = value;                                        
                }
            }
        }
                
        public Frm_CuentaCorrienteInfo()
        {
            InitializeComponent();

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {            
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;
            CuentaCorriente.SqlConnection = SqlConnection;
        }
        
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            try
            {
                gridView.BeginDataUpdate();
                CuentasCorrientes.Clear();

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                if (bgwRegistros.IsBusy) { return; }                

                bgwRegistros.RunWorkerAsync();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
            }
            
        }

        //BUSQUEDA DE REGISTROS
        private void GetRegistros()
        {
            try
            {
                CuentaCorriente.PrestadorCuentaID = PrestadorCuentaID;
                CuentasCorrientes.AddRange(CuentaCorriente.GetRegistros());
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al obtener los registros.\n{e.Message}", 1);
                return;
            }
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {

            gridControl.DataSource = new BindingList<MC.CuentaCorriente.CuentaCorriente>(CuentasCorrientes);
            gridView.EndDataUpdate();

            string c = CuentasCorrientes.Select(s => s.PrestadorNombre).DefaultIfEmpty(string.Empty).FirstOrDefault() + " - " + CuentasCorrientes.Select(s => s.PrestadorCuentaCodigo).DefaultIfEmpty(string.Empty).FirstOrDefault();
            if (c.Trim().Replace("-", "") != string.Empty) { Text = c; }
            

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }

        #endregion

        private void Frm_Contactos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_DirecCont_FormClosing(object sender, FormClosingEventArgs e)
        {
            cb.Desconectar();
        }

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            GetRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusqregistros();
        }

        private void Frm_CuentaCorrienteInfo_Shown(object sender, EventArgs e)
        {
            Ibusqregistros();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }
    }

}