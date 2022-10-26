using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using AMDGOINT.Formularios.Facturas.Prestatarias.MC;
using System.Data.SqlClient;
using System.IO;
using AmdgoInterno.Afip;
using System.Linq;
using DevExpress.XtraGrid;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Frm_Pendientes : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Facturacion Facturacion = new Facturacion();
        private List<ComprobanteEnc> facturaslst = new List<ComprobanteEnc>();
                
        public bool CanClose { get; set; } = true;
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();
        private Dictionary<short, string> ErroresGeneracion = new Dictionary<short, string>();

        private string periodo = "";
        private List<string> tiposcomprobante = new List<string>();

        public Frm_Pendientes()
        {

            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
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
            Facturacion.SqlConnection = SqlConnection;

            //ctrls.PreferencesGrid(this, gridView, "R");
                        
            btnExportar.Visible = globales.GetIdUsuariolog() == 1 ? true : false;
            
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
            splashScreen.WaitForSplashFormClose();
        }
                
        //INICIO BUSQUEDA PENDIENTES
        private void Ibusqpendientes()
        {
            try
            {

                if (string.IsNullOrEmpty(periodo) || tiposcomprobante.Count <= 0)
                {
                    Usr_ParametrosPendientes parametros = new Usr_ParametrosPendientes();

                    if (XtraDialog.Show(parametros, "Parámetros de búsqueda", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                    if (string.IsNullOrEmpty(parametros.Periodo) || parametros.TiposComprobantes.Count <= 0)
                    {
                        ctrls.MensajeInfo("Se deben completar los parámetros para continuar.", 1);
                        return;
                    }

                    bool continua = true;
                    if (parametros.TiposComprobantes.Count > 1)
                    {
                        //SOLO FACTURACION MENSUAL
                        if (parametros.TiposComprobantes.Contains("1") && parametros.TiposComprobantes.Contains("3")
                            && parametros.TiposComprobantes.Where(w => !w.Equals("1") && !w.Equals("3")).Count() > 0)
                        {
                            continua = false;
                        }

                        //SOLO REFACTURACION
                        if (parametros.TiposComprobantes.Contains("7") && parametros.TiposComprobantes.Contains("8")
                            && parametros.TiposComprobantes.Where(w => !w.Equals("7") && !w.Equals("8")).Count() > 0)
                        {
                            continua = false;
                        }

                        //SOLO FUERA DE TERMINO
                        if (parametros.TiposComprobantes.Contains("2") && parametros.TiposComprobantes.Contains("4")
                            && parametros.TiposComprobantes.Where(w => !w.Equals("2") && !w.Equals("4")).Count() > 0)
                        {
                            continua = false;
                        }

                        //SOLO COVID
                        if (parametros.TiposComprobantes.Contains("6") && parametros.TiposComprobantes.Where(w => !w.Equals("6")).Count() > 0)
                        {
                            continua = false;
                        }
                    }

                    if (!continua)
                    {
                        ctrls.MensajeInfo("No se pueden mezaclar los tipos de facturación.", 1);
                        return;
                    }

                    periodo = parametros.Periodo;
                    tiposcomprobante.AddRange(parametros.TiposComprobantes);
                }                
                
                

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                splashScreen.SetWaitFormCaption("Obteniendo Registros");
                splashScreen.SetWaitFormDescription("Espere...");

                btnPendientes.Enabled = false;
                btnGenerafact.Enabled = false;
                btnExportar.Enabled = false;

                gridView.BeginDataUpdate();

                if (bgwPendientes.IsBusy) { bgwPendientes.CancelAsync(); }
                while (bgwPendientes.CancellationPending)
                { if (!bgwPendientes.CancellationPending) { break; } }

                bgwPendientes.RunWorkerAsync();
            }
            catch (Exception)
            {
                btnPendientes.Enabled = true;
                btnGenerafact.Enabled = true;
                btnExportar.Enabled = true;
            }
            
        }

        //FIN BUSQUEDA PENDIENTES
        private void Fbusqpendientes()
        {
            btnPendientes.Enabled = true;
            btnGenerafact.Enabled = true;
            btnExportar.Enabled = true;
            gridControl.DataSource = new BindingList<ComprobanteEnc>(facturaslst);
            gridView.EndDataUpdate();

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }
                              
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.Icon = Icon;
        }

        //INICIO EMISION DE FACTURAS
        private void IFacturasemis()
        {            
            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
            splashScreen.SetWaitFormCaption("Emitiendo Facturas");

            btnGenerafact.Enabled = false;
            btnPendientes.Enabled = false;
            btnExportar.Enabled = false;
            timer1.Start();
            
            if (bgwFacturas.IsBusy) { return; }
            
            CanClose = false;
            bgwFacturas.RunWorkerAsync();
        }

        //FIN EMISION DE FACTURAS
        private void FFacturasemis()
        {            
            timer1.Stop();
            btnGenerafact.Enabled = true;
            btnPendientes.Enabled = true;
            btnExportar.Enabled = true;
            CanClose = true;

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }

            if (ErroresGeneracion.Count > 0)
            {
                string mensajes = "";

                foreach (string i in ErroresGeneracion.Select(s => s.Value))
                {
                    mensajes += $"{i.Trim()}\n";
                }

                if (!string.IsNullOrWhiteSpace(mensajes))
                { ctrls.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); }
            }
                                          
            Ibusqpendientes();
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
            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {            
            ConexionBD.Desconectar();
            SqlConnection.Dispose();
            //ctrls.PreferencesGrid(this, gridView, "S");
        }


        //******************* EVENTOS botones *************************
        private void btnPendientes_ElementClick(object sender, NavElementEventArgs e)
        {
            Ibusqpendientes();
        }

        private void btnGenerafact_ElementClick(object sender, NavElementEventArgs e)
        {                       

            if (ctrls.MensajePregunta("Esta operación no puede ser deshecha ni cancelada\n" +                
                "¿Desea Continuar?") == DialogResult.Yes)
            {                              
                IFacturasemis();
            }
        }

        private void bgwPendientes_DoWork(object sender, DoWorkEventArgs e)
        {
            facturaslst.Clear();

            if (Facturacion.ProcesaPendientes(periodo, tiposcomprobante))
            {
                ComprobanteEnc f = new ComprobanteEnc();
                facturaslst = f.Clone(Facturacion.Encabezados);
            }            
        }

        private void bgwPendientes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusqpendientes();
        }

        private void bgwFacturas_DoWork(object sender, DoWorkEventArgs e)
        {
            ErroresGeneracion.Clear();
            ErroresGeneracion = Facturacion.GenerarFacturas();
        }

        private void bgwFacturas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FFacturasemis();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            splashScreen.SetWaitFormCaption($"Emitiendo Facturas {Facturacion.Procesados}");
            splashScreen.SetWaitFormDescription($"Procesando... {DateTime.Now.ToString("mm:ss")}");
        }             
         
        private void btnExportar_ElementClick(object sender, NavElementEventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);
        }

    }

    
}