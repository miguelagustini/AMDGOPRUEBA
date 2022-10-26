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
using AMDGOINT.Formularios.Facturas.Internacion.MC;

namespace AMDGOINT.Formularios.Facturas.Internacion.Vista
{
    public partial class Frm_Pendientes : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Facturacion Facturacion = new Facturacion();
        private List<Ambulatorio.MC.FacturaEnc> facturaslst = new List<Ambulatorio.MC.FacturaEnc>();
                
        public bool CanClose { get; set; } = true;
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();
        private Dictionary<short, string> ErroresGeneracion = new Dictionary<short, string>();

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

            ctrls.PreferencesGrid(this, gridView, "R");
                        
            btnExportar.Visible = globales.GetIdUsuariolog() == 1 ? true : false;
            
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
            splashScreen.WaitForSplashFormClose();
        }
                
        //INICIO BUSQUEDA PENDIENTES
        private void Ibusqpendientes()
        {            
            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
            splashScreen.SetWaitFormCaption("Obteniendo Registros");
            splashScreen.SetWaitFormDescription("Espere...");


            btnPendientes.Enabled = false;
            btnGenerafact.Enabled = false;

            gridView.BeginDataUpdate();            

            if (bgwPendientes.IsBusy) { bgwPendientes.CancelAsync(); }
            while (bgwPendientes.CancellationPending)
            { if (!bgwPendientes.CancellationPending) { break; } }

            bgwPendientes.RunWorkerAsync();
        }

        //FIN BUSQUEDA PENDIENTES
        private void Fbusqpendientes()
        {
            btnPendientes.Enabled = true;
            btnGenerafact.Enabled = true;            
            gridControl.DataSource = new BindingList<Ambulatorio.MC.FacturaEnc>(facturaslst);
            gridView.EndDataUpdate();

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }

        //SET PERIODO DE FACTURA
        private bool SetPeriodofactura()
        {
            try
            {                
                // initialize a new XtraInputBoxArgs instance
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                // set required Input Box options
                args.Caption = "Antes de comenzar...";
                args.Prompt = "¿A qué período corresponden los comprobantes?";
                args.DefaultButtonIndex = 0;
                args.Showing += Args_Showing;
                // initialize a DateEdit editor with custom settings
                DateEdit editor = new DateEdit();
                editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
                editor.Properties.Mask.EditMask = "yyyy/MM/dd";
                editor.Properties.Mask.UseMaskAsDisplayFormat = true;
                args.Editor = editor;
                // a default DateEdit value
                args.DefaultResponse = DateTime.Today;
                // display an Input Box with the custom editor
                var result = XtraInputBox.Show(args);

                if (result != null) { Facturacion.Periodo = $"{Convert.ToDateTime(result).ToString("yyyyMM")}1" ; return true; }
                else { return false; }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el período.\n" + e.Message, 0);
                return false;
            }
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
            CanClose = true;

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
            ctrls.PreferencesGrid(this, gridView, "S");
        }


        //******************* EVENTOS botones *************************
        private void btnPendientes_ElementClick(object sender, NavElementEventArgs e)
        {
            Ibusqpendientes();
        }

        private void btnGenerafact_ElementClick(object sender, NavElementEventArgs e)
        {                       

            if (ctrls.MensajePregunta("Esta operación no puede ser deshecha ni cancelada\n" +
                "y todos aquellos prestadores sin punto de venta serán omitidos.\n" +
                "¿Desea Continuar?") == DialogResult.Yes)
            {
                if (!SetPeriodofactura())
                {
                    ctrls.MensajeInfo("No se puede continuar con la generación de comprobantes.", 1);
                    return;
                }           
                
                IFacturasemis();
            }
        }

        private void bgwPendientes_DoWork(object sender, DoWorkEventArgs e)
        {
            facturaslst.Clear();

            if (Facturacion.ProcesaPendientes())
            {
                Ambulatorio.MC.FacturaEnc f = new Ambulatorio.MC.FacturaEnc();
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