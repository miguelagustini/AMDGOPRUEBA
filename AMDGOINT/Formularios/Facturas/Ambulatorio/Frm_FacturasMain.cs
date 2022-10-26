using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AmdgoInterno.Afip;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    public partial class Frm_FacturasMain : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Impresionglob impresion = new Impresionglob();
        private FacturasClass facturas = new FacturasClass();
        public List<ComprobPE> listacomprobantes = new List<ComprobPE>();

        public bool CanClose { get; set; } = true;

        public Frm_FacturasMain()
        {

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
            if (globales.GetIdUsuariolog() == 1) { btnPruebacuit.Visible = true; }
            else { btnPruebacuit.Visible = false; }
        }
                
        //INICIO BUSQUEDA PENDIENTES
        private void Ibusqpendientes()
        {
            btnPendientes.Enabled = false;
            btnGenerafact.Enabled = false;

            bgridView.BeginDataUpdate();
            ppGenerando.Caption = "Obteniendo Pendientes";
            ppGenerando.Description = "Espere...";
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

                if (result != null) { facturas.Periodo = Convert.ToDateTime(result).ToString("yyyy/MM/dd").Replace("/","") ; return true; }
                else { return false; }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el período.\n" + e.Message, 0);
                return false;
            }
        }

        //SET PERIODO DE FACTURA
        private void SetPuntoventa(string codprof)
        {
            try
            {
                // initialize a new XtraInputBoxArgs instance
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                // set required Input Box options
                args.Caption = "Asignación de punto de venta";
                args.Prompt = "Ingrese el punto de venta correspondiente a " + codprof;
                args.DefaultButtonIndex = 0;
                args.Showing += Args_Showing;
                // initialize a DateEdit editor with custom settings
                TextEdit editor = new TextEdit();
                editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                editor.Properties.Mask.EditMask = "[0-9]{1,4}";
                editor.Properties.Mask.UseMaskAsDisplayFormat = true;                
                args.Editor = editor;
                // a default DateEdit value
                args.DefaultResponse = "0";
                // display an Input Box with the custom editor
                var result = XtraInputBox.Show(args);

                if (result != null && result.ToString() != "")
                { ActualizaPuntovta(Convert.ToInt32(result)); }
                

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el período.\n" + e.Message, 0);
                return;
            }
        }

        //CAMBIO EL PUNTO DE VENTA DE TODOS LOS REGISTROS CON ESE CUIT
        private void ActualizaPuntovta(int punto)
        {
            try
            {
                string cuit = "";
                bgridView.BeginDataUpdate();                

                if (bgridView.GetFocusedRowCellValue(colEmisorCuit) != null)
                { cuit = bgridView.GetFocusedRowCellValue(colEmisorCuit).ToString(); }

                if (cuit == "") { return; }

                //LISTA LOCAL
                var resultados = listacomprobantes.Where(s => s.EmisorCuit == cuit).ToList();

                foreach (var r in resultados)
                {
                    if (r.EmisorCuit == cuit) { r.EmisorPuntoVta = punto; }                    
                }

                bgridView.EndDataUpdate();

                //LISTA GLOBAL
                var res = facturas.Comprobplst.Where(s => s.EmisorCuit == cuit).ToList();

                foreach (var r in res)
                {
                    if (r.EmisorCuit == cuit) { r.EmisorPuntoVta = punto; }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            e.Form.Icon = this.Icon;
        }

        //INICIO EMISION DE FACTURAS
        private void IFacturasemis()
        {
            ppGenerando.Caption = "Generando Facturas";
            btnGenerafact.Enabled = false;
            btnPendientes.Enabled = false;
            flyoutPanel.ShowPopup();
            timer1.Start();
            
            if (bgwFacturas.IsBusy) { return; }
            
            CanClose = false;
            bgwFacturas.RunWorkerAsync();
        }

        //FIN EMISION DE FACTURAS
        private void FFacturasemis()
        {
            //flyoutPanel.HidePopup();
            timer1.Stop();
            btnGenerafact.Enabled = true;
            btnPendientes.Enabled = true;
            CanClose = true;

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
            if (bgwPendientes.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridView, "S");
        }


        //******************* EVENTOS botones *************************
        private void btnPendientes_ElementClick(object sender, NavElementEventArgs e)
        {
            Ibusqpendientes();
        }

        private void btnGenerafact_ElementClick(object sender, NavElementEventArgs e)
        {

            /*List<Faltantes> f = facturas.ChequearFaltantes();

            if (f.Count > 0)
            {
                Frm_Faltantes fr = new Frm_Faltantes();
                fr.IniciaCarga(f);
                fr.ShowDialog(this);
                return;
            }*/

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
            facturas.ProcesarAmbulatorio(DSDatos);
            listacomprobantes = facturas.Comprobplst;
        }

        private void bgwPendientes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusqpendientes();
        }

        private void bgwFacturas_DoWork(object sender, DoWorkEventArgs e)
        {
            
            facturas.FacturaAmbulatorio();
        }

        private void bgwFacturas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FFacturasemis();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ppGenerando.Description = "Espere... " + facturas.Procesadas;
        }

        private void btnPventa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var valor = bgridView.GetFocusedRowCellValue(colEmisorPuntovta);
            if (valor != null && valor.ToString() != "" && Convert.ToInt32(valor) > 0)
            {
                if (ctrls.MensajePregunta("Éste prestador ya posee un punto de venta,\n" +
                     "¿Desea cambiarlo de todas formas?") != DialogResult.Yes)
                {
                    return;
                }
            }

            SetPuntoventa(bgridView.GetFocusedRowCellValue(colEmisorCodigo).ToString());
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (bgridView.RowCount <= 0) { return; }

            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        //PROCESO SI EXISTE EL CERTIFICADO PARA GENERAR LA FACTURA
        private string ExisteCertificado(short produccion, string cuitemis)
        {
            try
            {
                string retorno = "";

                //HOMOLOGACION
                if (produccion == 0)
                {
                    if (File.Exists(Application.StartupPath + @"\Afip\HOMO\H-CR" + cuitemis + ".pfx"))
                    {
                        retorno = Application.StartupPath + @"\Afip\HOMO\H-CR" + cuitemis + ".pfx";
                    }

                }//PRODUCCION 1
                else
                {
                    if (File.Exists(Application.StartupPath + @"\Afip\PROD\P-CR" + cuitemis + ".pfx"))
                    {
                        retorno = Application.StartupPath + @"\Afip\PROD\P-CR" + cuitemis + ".pfx";
                    }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al buscar las credenciales.\n" + e.Message, 0);
                return "";
            }
        }

        //HAGO EL LOGIN CON AFIP AL MODULO CORRESPONDIENTE
        private bool LoginAfip(short produccion, string cuitemis)
        {
            try
            {
                AfipProdDatos afip = new AfipProdDatos();

                bool retorno = false;
                string path = ExisteCertificado(produccion, cuitemis);

                if (path != "" && afip.loginafip(path, "248", Convert.ToInt64(cuitemis))) { retorno = true; } else { retorno = false; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al logarse con afip.\n" + e.Message, 0);
                return false;
            }
        }

        private void navButton2_ElementClick(object sender, NavElementEventArgs e)
        {
            // initialize a new XtraInputBoxArgs instance
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            // set required Input Box options
            args.Caption = "Asignación de punto de venta";
            args.Prompt = "Ingrese el punto de venta correspondiente a ";
            args.DefaultButtonIndex = 0;
            args.Showing += Args_Showing;
            // initialize a DateEdit editor with custom settings
            TextEdit editor = new TextEdit();
            editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            editor.Properties.Mask.EditMask = "[0-9]{1,11}";
            editor.Properties.Mask.UseMaskAsDisplayFormat = true;
            args.Editor = editor;
            // a default DateEdit value
            args.DefaultResponse = "0";
            // display an Input Box with the custom editor
            var result = XtraInputBox.Show(args);

            if (result == null) { return; }


            //HAGO EL LOGIN HOMOLOG
            if (!LoginAfip(1, result.ToString()))
            {
                ctrls.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                return;
            }
            else
            {
                ctrls.MensajeInfo("OK.", 1);
                return;
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);
        }
    }

    
}