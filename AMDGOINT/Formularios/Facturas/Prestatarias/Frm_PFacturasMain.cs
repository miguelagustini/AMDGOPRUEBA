using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Frm_PFacturasMain : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Impresionglob impresion = new Impresionglob();
        private PrestFactura facturas = new PrestFactura();
        public List<ComprobPE> listacomprobantes = new List<ComprobPE>();

        private string periodo { get; set; } = "";
        private string periodobusq { get; set; } = "";
        private string Tipofactbusq { get; set; } = "";
        private string Origenbusq { get; set; } = "";
        public bool CanClose { get; set; } = true;

        public Frm_PFacturasMain()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            tableLayoutPanel1.RowStyles[1].Height = 0;
            ctrls.PreferencesGrid(this, bgridView, "R");
            
        }
                
        //INICIO BUSQUEDA PENDIENTES
        private void Ibusqpendientes()
        {
            /*if (periodo == "")
            {
                if (!SetPeriodofactura())
                {
                    ctrls.MensajeInfo("No se puede obtener comprobantes sin un período.", 1);
                    return;
                }
            }
            else { facturas.Periodo = periodo; }*/
            

            btnPendientes.Enabled = false;
            btnGenerafact.Enabled = false;
            
            bgridView.BeginDataUpdate();
            ppGenerando.Caption = "Obteniendo Pendientes";
            flyoutPanel.ShowPopup();

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
            
            flyoutPanel.HidePopup();            
            gridControl.DataSource = listacomprobantes;
            bgridView.EndDataUpdate();
            
        }

        //INICIO EMISION DE FACTURAS
        private void IFacturasemis()
        {
            ppGenerando.Caption = "Generando Facturas";
            btnGenerafact.Enabled = false;
            btnPendientes.Enabled = false;
            
            flyoutPanel.ShowPopup();
            timer1.Start();
            
            if (bgwFacturas.IsBusy) { bgwFacturas.CancelAsync(); }
            while (bgwFacturas.CancellationPending)
            { if (!bgwFacturas.CancellationPending) { break; } }

            CanClose = false;
            bgwFacturas.RunWorkerAsync();
        }

        //FIN EMISION DE FACTURAS
        private void FFacturasemis()
        {
            //flyoutPanel.HidePopup();                  
            timer1.Stop();
            ppGenerando.Description = "Espere... ";
            btnGenerafact.Enabled = true;
            btnPendientes.Enabled = true;
            
            CanClose = true;
            //RECARGO PENDIENTES POR SI QUEDO UNO SIN EMITIR
            Ibusqpendientes();
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

                periodo = "";
                if (result != null)
                {
                    periodo = Convert.ToDateTime(result).ToString("yyyy/MM").Replace("/", "");
                    //facturas.Periodo = periodo;
                    return true;
                }
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
            e.Form.Icon = this.Icon;
        }

        //PARAMETROS DE BUSQUEDA
        private bool SetParametrosBusqueda()
        {
            try
            {
                bool retorno = true;
                periodobusq = "";
                Tipofactbusq = "";
                Origenbusq = "";

                PeriodoSelector contr = new PeriodoSelector();
                
                if (XtraDialog.Show(contr, "Parámetros de búsqueda", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (contr.fecha.Text.ToString() != "")
                    {
                        periodobusq = Convert.ToDateTime(contr.fecha.Text).ToString("yyyyMM");
                    }
                    else { retorno = false; }

                    switch (contr.cmbTipofac.Text)
                    {   
                        //FACTURAS
                        case "Facturas":
                            Tipofactbusq = "F";
                            if (contr.cmbOrigen.Text == "Ambulatorio") { Origenbusq = "1"; }
                            else if (contr.cmbOrigen.Text == "Internación") { Origenbusq = "3"; }
                            else if (contr.cmbOrigen.Text == "Ambos") { Origenbusq = ""; }
                            else { retorno = false; }
                            break;
                        //REFAACTURACION
                        case "Refacturación por diferencia":
                            Tipofactbusq = "RFD";
                            if (contr.cmbOrigen.Text == "Ambulatorio") { Origenbusq = "7"; }
                            else if (contr.cmbOrigen.Text == "Internación") { Origenbusq = "8"; }
                            else if (contr.cmbOrigen.Text == "Ambos") { Origenbusq = ""; }
                            else { retorno = false; }
                            break;
                        //REFAACTURACION
                            case "Refacturación fuera de término":
                                Tipofactbusq = "RFT";
                        if (contr.cmbOrigen.Text == "Ambulatorio") { Origenbusq = "2"; }
                        else if (contr.cmbOrigen.Text == "Internación") { Origenbusq = "4"; }
                        else if (contr.cmbOrigen.Text == "Ambos") { Origenbusq = ""; }
                        else { retorno = false; }
                        break;
                        //FACTURACION UNICA COVID-19
                        case "Facturación Individual Covid-19":
                            Tipofactbusq = "FC19";
                            Origenbusq = "6";                            
                            break;
                        //VACIO
                        case "": retorno = false; break;
                    }

                }
                else { retorno = false; }


                if (retorno)
                {
                    if (Origenbusq == "")
                    {
                        if (Tipofactbusq == "F")
                        {
                            facturas.BusqPeriododesde = periodobusq + "1";
                            facturas.BusqPeriodohasta = periodobusq + "3";
                        }
                        else if(Tipofactbusq == "RFD")
                        {
                            facturas.BusqPeriododesde = periodobusq + "7";
                            facturas.BusqPeriodohasta = periodobusq + "8";
                        }
                        else if (Tipofactbusq == "RFT")
                        {
                            facturas.BusqPeriododesde = periodobusq + "2";
                            facturas.BusqPeriodohasta = periodobusq + "4";
                        }
                        else if (Tipofactbusq == "FC19")
                        {
                            facturas.BusqPeriododesde = periodobusq + "6";
                            facturas.BusqPeriodohasta = periodobusq + "6";
                        }
                    }
                    else
                    {
                        facturas.BusqPeriododesde = periodobusq + Origenbusq;
                        facturas.BusqPeriodohasta = periodobusq + Origenbusq;
                    }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al definir los parámetros de búsqueda." + e.Message, 0);
                return false;
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
            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwPendientes.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridView, "S");
        }
        
        //******************* EVENTOS botones *************************
        private void btnPendientes_ElementClick(object sender, NavElementEventArgs e)
        {            
            if (SetParametrosBusqueda())
            {
                Ibusqpendientes();
            }
        }

        private void btnGenerafact_ElementClick(object sender, NavElementEventArgs e)
        {
            if (ctrls.MensajePregunta("Esta operación no puede ser deshecha ni cancelada\n" +                
                "¿Desea Continuar?") == DialogResult.Yes)
            {
                if (facturas.GetCbucreditos() == "")
                {
                    if (ctrls.MensajePregunta("No existe información de CBU para posibles facturas de crédito.\n" +
                        "¿Desea Continuar de todas formas?") == DialogResult.No)
                    { return; }
                }

                IFacturasemis();
            }
        }

        private void bgwPendientes_DoWork(object sender, DoWorkEventArgs e)
        {            
            facturas.ListaPendientes();
            listacomprobantes = facturas.ListadoPendienteEnc;
        }

        private void bgwPendientes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusqpendientes();
        }

        private void bgwFacturas_DoWork(object sender, DoWorkEventArgs e)
        {            
            facturas.EmiteFacturas();
        }

        private void bgwFacturas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FFacturasemis();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           ppGenerando.Description = "Procesadas... " + facturas.Procesadas;
        }

        private void bgridView_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btnQuesucede_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var l = bgridView.GetFocusedRowCellValue(colReceptorrazin);

            if (l != null && l.ToString() != "")
            {
                Frm_InfoGeneral f = new Frm_InfoGeneral();

                f.Informacion = l.ToString().Trim();
                f.ShowDialog();
            }
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (bgridView.RowCount <= 0) { return; }

            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            var l = bgridView.GetFocusedRowCellValue(colReceptorrazin);

            if (l != null && l.ToString() != "")
            {
                btnQuesucede.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnQuesucede.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
    }

    public class PeriodoSelector : XtraUserControl
    {
        public DateEdit fecha = new DateEdit();
        public ComboBoxEdit cmbTipofac = new ComboBoxEdit();
        public ComboBoxEdit cmbOrigen = new ComboBoxEdit();
      
        public PeriodoSelector()
        {
            LayoutControl lc = new LayoutControl();
            lc.Dock = DockStyle.Fill;
            
            fecha.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            fecha.Properties.Mask.EditMask = "yyyy/MM/dd";
            fecha.Properties.Mask.UseMaskAsDisplayFormat = true;            

            cmbTipofac.Properties.Items.Add("Facturas");
            cmbTipofac.Properties.Items.Add("Refacturación por diferencia");
            cmbTipofac.Properties.Items.Add("Refacturación fuera de término");
            cmbTipofac.Properties.Items.Add("Facturación Individual Covid-19");
            cmbTipofac.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;            

            cmbOrigen.Properties.Items.Add("Ambulatorio");
            cmbOrigen.Properties.Items.Add("Internación");
            cmbOrigen.Properties.Items.Add("Ambos");
            cmbOrigen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;            

            SeparatorControl separatorControl = new SeparatorControl();
            lc.AddItem(String.Empty, fecha).TextVisible = false;
            lc.AddItem(String.Empty, cmbTipofac).TextVisible = false;
            lc.AddItem(String.Empty, cmbOrigen).TextVisible = false;
            Controls.Add(lc);
            Height = 100;
            Dock = DockStyle.Top;            
        }
    }
}