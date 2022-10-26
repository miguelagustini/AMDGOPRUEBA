using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;
using AMDGOINT.Datos;
using System.Collections;
using AmdgoInterno.Afip;
using AMDGOINT.Formularios.Facturas.Prestatarias;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    public partial class Frm_FacturasEmit : DevExpress.XtraEditors.XtraForm
    {
        private ConexionBD cb = new ConexionBD();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Impresionglob impresion = new Impresionglob();
        private List<FacturasEmitEncStruct> Listfactuenc = new List<FacturasEmitEncStruct>();
        private FacturasClass facturacion = new FacturasClass();
        private Reportes dsreportes = new Reportes();
        private WspucDatos afip = new WspucDatos();
        MC.ComprobantesRel Comprobantesrel = new MC.ComprobantesRel();

        private Frm_FacturasDet frmdetalles = new Frm_FacturasDet();
        private Vista.Frm_Comprobantesrel frmComprobantes = new Vista.Frm_Comprobantesrel();

        private long IDRegistro { get; set; } = 0;
        private decimal Summaryg { get; set; } = 0;
        private bool Cambiarow { get; set; } = false;
        private int RowIndex { get; set; } = -1;
        private bool Imprimirlst { get; set; } = true;
        private string Pathexport { get; set; } = "";
        private bool Incluyepaci { get; set; } = false;
        private bool Unico { get; set; } = true;

        public Frm_FacturasEmit()
        {           
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            bgridView.CustomSummaryCalculate += new CustomSummaryEventHandler(ViewSummaryCalculate);
            bgridView.CustomDrawFooterCell += new FooterCellCustomDrawEventHandler(ViewCustomDrawFooterCell);
            ctrls.setSplitter(splitter);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {

            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;
            Comprobantesrel.SqlConnection = SqlConnection;

            tableLayoutPanel1.RowStyles[1].Height = 0;
            ctrls.PreferencesGrid(this, bgridView, "R");
            
            colNoGravado.SummaryItem.SummaryType = SummaryItemType.Custom;
            colIva.SummaryItem.SummaryType = SummaryItemType.Custom;
            colNeto.SummaryItem.SummaryType = SummaryItemType.Custom;
            colTotal.SummaryItem.SummaryType = SummaryItemType.Custom;

            //Detalles
            ctrls.AgregaFormulario(frmdetalles, Tabdetalles);
            //comprobantes
            frmComprobantes.Comprobanteslst = Comprobantesrel.GetRegistros();
            ctrls.AgregaFormulario(frmComprobantes, Tabdetalles);
            //ICONOS            
            Tabdetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;
            Tabdetalles.TabPages[1].ImageOptions.Image = Properties.Resources.BOContact2_16x16;
            Tabdetalles.SelectedTabPageIndex = 0;
            tmrDetalles.Start();

            btnNcdmanual.Enabled = func.DevuelvePermiso("Amfactman");
        }

        //INICIO BUSQUEDA
        private void Ibusqemitidos()
        {
         
            bgridView.BeginDataUpdate();
            ppGenerando.Caption = "Obteniendo Comprobantes";
            flyoutPanel.ShowPopup();

            if (bgwEmitidos.IsBusy) { bgwEmitidos.CancelAsync(); }
            while (bgwEmitidos.CancellationPending)
            { if (!bgwEmitidos.CancellationPending) { break; } }

            bgwEmitidos.RunWorkerAsync();
            
        }

        //FIN BUSQUEDA DE COMPROBANTES
        private void Fbusqemitidos()
        {            
            flyoutPanel.HidePopup();
            bgridView.EndDataUpdate();
            gridControl.DataSource = Listfactuenc;
            if (bgridView.RowCount >= RowIndex) { bgridView.FocusedRowHandle = RowIndex; }
        }

        //BUSQUEDA DE COMPROBANTES
        private void Buscaremitidos()
        {
            try
            {
                Listfactuenc.Clear();

                string consulta = "SELECT EN.ID_Registro, EN.TipoComprobante, EN.Fecha, EN.Letra, EN.PuntoVenta, EN.Numero, EN.ID_Profesional," +
                    " PR.Codigo AS CodigoProf, EN.NombreProf, EN.CuitProf, CP.Abreviatura as IvaProf, EN.ID_PrestDetalle, PT.Codigo as CodigoPres," +
                    " EN.NombrePres, EN.CuitPres, CT.Abreviatura as IvaPres, EN.PorcIvaPres, EN.Guid, EN.Neto, EN.Iva, EN.Total, EN.EstadoAf," +
                    " EN.CaeNroAf, EN.BarrasAf, ISNULL(EN.VtoCaeAf, '') AS VtoCaeAf, EN.ObservAf, EN.NoGravado, EN.Neto21, EN.Neto105, EN.Iva21, EN.Iva105," +
                    " PR.Email as EmailProf," +
                    " IIF((ISNULL(EN.Total, 0)+ISNULL((SELECT SUM(FE1.Total)" +
                                                    " FROM FACTAMBUREL FR" +
                                                    " LEFT OUTER JOIN FACTAMBUENC FE1 ON(FE1.ID_Registro = FR.ID_NotaDebito AND FR.ID_NotaDebito > 0)" +
                                                    " WHERE FR.ID_Factura = EN.ID_Registro),0))-" +
                                                    " ISNULL((SELECT SUM(FE2.Total)" +
                                                    " FROM FACTAMBUREL FR1" +
                                                    " LEFT OUTER JOIN FACTAMBUENC FE2 ON(FE2.ID_Registro = FR1.ID_NotaCredito AND FR1.ID_NotaCredito > 0)" +
                                                    " WHERE FR1.ID_Factura = EN.ID_Registro),0)" +
                                                    " <= 0, 1, 0) as Anulada" +
                    " FROM FACTAMBUENC EN" +
                    " LEFT OUTER JOIN PROFESIONALES PR ON(PR.ID_Registro = EN.ID_Profesional)" +
                    " LEFT OUTER JOIN CONDSIVA CP ON(CP.ID_Registro = EN.IvaProf)" +
                    " LEFT OUTER JOIN CONDSIVA CT ON(CT.ID_Registro = EN.IvaPres)" +
                    " LEFT OUTER JOIN PRESTDETALLES PT ON(PT.ID_Registro = EN.ID_PrestDetalle)" +
                    " WHERE EN.Visible = 1";

                foreach (DataRow f in func.getColecciondatos(consulta, SqlConnection).Rows)
                {
                    Listfactuenc.Add(new FacturasEmitEncStruct {
                        ID_Registro = Convert.ToInt64(f["ID_Registro"]),
                        Fecha = Convert.ToDateTime(f["Fecha"]),
                        TipoComprobante = f["TipoComprobante"].ToString(),
                        Letra = f["Letra"].ToString(),
                        PuntoVenta = Convert.ToInt32(f["PuntoVenta"]),
                        Numero = Convert.ToInt64(f["Numero"]),
                        ID_Profesional = Convert.ToInt32(f["ID_Profesional"]),
                        CodigoProf = f["CodigoProf"].ToString(),
                        NombreProf = f["NombreProf"].ToString(),
                        CuitProf = Convert.ToInt64(f["CuitProf"]),
                        IvaProf = f["IvaProf"].ToString(),
                        ID_Prestataria = Convert.ToInt32(f["ID_PrestDetalle"]),
                        CodigoPres = f["CodigoPres"].ToString(),
                        NombrePres = f["NombrePres"].ToString(),
                        CuitPres = Convert.ToInt64(f["CuitPres"]),
                        IvaPres = f["IvaPres"].ToString(),
                        PorcIvaPres = Convert.ToDecimal(f["PorcIvaPres"]),
                        Guid = f["Guid"].ToString(),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Neto21 = Convert.ToDecimal(f["Neto21"]),
                        Neto105 = Convert.ToDecimal(f["Neto105"]),
                        NoGravado = Convert.ToDecimal(f["NoGravado"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Iva21 = Convert.ToDecimal(f["Iva21"]),
                        Iva105 = Convert.ToDecimal(f["Iva105"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        EstadoAf = f["EstadoAf"].ToString(),
                        CaeNroAf = f["CaeNroAf"].ToString(),
                        BarrasAf = f["BarrasAf"].ToString(),
                        VtoCaeAf = f["VtoCaeAf"].ToString(),
                        ObservAf = f["ObservAf"].ToString(),
                        Comprobante = f["Letra"].ToString() + "- " + 
                        Convert.ToInt32(f["PuntoVenta"]).ToString("0000") + " " + Convert.ToInt64(f["Numero"]).ToString("00000000"),
                        EmailProf = f["EmailProf"].ToString().Trim(),
                        Anulada = Convert.ToBoolean(f["Anulada"])
                    });
                }
            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al ejecutar la búsqueda.\n" + e.Message,0);
                return;
            }
        }

        //FORMUALRIO DE INGRESO DE IMPORTE A GENERAR NOTA DE CREDITO
        private void ParametrosNc(string tipo)
        {
            try
            {

                Frm_NotaCredParam f = new Frm_NotaCredParam();
                f.Tipo = tipo;
                f.ID_Factura = Convert.ToInt64(bgridView.GetFocusedRowCellValue(colID_Registro));
                f.Total21 = Convert.ToDecimal(bgridView.GetFocusedRowCellValue(colNeto21)) +
                    Convert.ToDecimal(bgridView.GetFocusedRowCellValue(colIva21));
                f.Total105 = Convert.ToDecimal(bgridView.GetFocusedRowCellValue(colNeto105)) +
                    Convert.ToDecimal(bgridView.GetFocusedRowCellValue(colIva105));
                f.NoGravado = Convert.ToDecimal(bgridView.GetFocusedRowCellValue(colNoGravado));
                    

                if (f.ShowDialog(this) == DialogResult.OK)
                {

                    facturacion.GeneraNotaCreditoDebito(IDRegistro, f.retTotal21, f.retTotal105, f.retNoGravado, tipo);
                    Ibusqemitidos();
                }                
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al solicitar parámetros.\n" + e.Message, 0);
                return;
            }            
        }
        
        //VALIDO SALDO PENDIENTE DE FACTURA
        private bool ValidoSaldopendiente(decimal importe, decimal total)
        {
            try
            {
                bool retorno = true;

                string consulta = "SELECT ISNULL(SUM(FC.Total),0) AS Total FROM FACTAMBUREL RE" +
                    " LEFT OUTER JOIN FACTAMBUENC FC ON(FC.ID_Registro = RE.ID_NotaCredito)" +
                    " WHERE RE.ID_Factura = " + IDRegistro;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    if (importe > (total - Convert.ToDecimal(f["Total"]))) { retorno = false; }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar la factura acutal.\n" + e.Message, 0);
                return false;
            }
        }

        //INICIA IMPRESION
        private void Iimpresion(bool preg)
        {
            if (preg)
            {
                if (ctrls.MensajePregunta("¿Incluir pacientes?") == DialogResult.Yes) { Incluyepaci = true; } else { Incluyepaci = false; }
            }

            navImprimir.Enabled = false;
            ppGenerando.Caption = "Imprimiendo Registro/s";
            flyoutPanel.ShowPopup();

            if (bgwImprimir.IsBusy) { bgwImprimir.CancelAsync(); }
            while (bgwImprimir.CancellationPending)
            { if (!bgwImprimir.CancellationPending) { break; } }

            bgwImprimir.RunWorkerAsync();
        }
        
        //IMPRESION
        private void Imprimir()
        {
            impresion.datosrep = dsreportes;
            impresion.InclPaciente = Incluyepaci;

            if (Imprimirlst)
            {
                impresion.Clearing();

                //RECORRO LOS ITEMS VISIBLES.
                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    if (bgridView.GetRowCellValue(i, colID_Registro).ToString() != "")
                    {
                        impresion.IDRegistro = Convert.ToInt64(bgridView.GetRowCellValue(i, colID_Registro));
                        impresion.CargaDatosfcambu(1, 1);
                    }
                }
            }
            else
            {
                //SOLO UN REGISTRO (SELECCIONADO)
                impresion.IDRegistro = IDRegistro;
                impresion.CargaDatosfcambu();
            }
            
        }

        //FINALIZA IMPRESIONA
        private void Fimpresion()
        {
            flyoutPanel.HidePopup();
            navImprimir.Enabled = true;
            ppGenerando.Caption = "Obteniendo Facturas";
            Imprimirlst = true;
            impresion.MuestraReporte();
        }

        //EXPORTA PDF
        private void Iexpotarpdf()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Incluir pacientes?") == DialogResult.Yes) { Incluyepaci = true; } else { Incluyepaci = false; }

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        tmrContadorreg.Start();
                        Pathexport = fbd.SelectedPath;
                        navImprimir.Enabled = false;
                        ppGenerando.Caption = "Exportando Registro/s";
                        flyoutPanel.ShowPopup();

                        if (bgwExportpdf.IsBusy) { bgwExportpdf.CancelAsync(); }
                        while (bgwExportpdf.CancellationPending)
                        { if (!bgwExportpdf.CancellationPending) { break; } }

                        bgwExportpdf.RunWorkerAsync();
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        private void ExportarPdf()
        {
            try
            {
                if (Pathexport == "") { return; }
                impresion.InclPaciente = Incluyepaci;
                impresion.datosrep = dsreportes;
                impresion.GuardaPdf(Getidcomprobs(), Pathexport);                
                
            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        private void Fexportapdf()
        {
            tmrContadorreg.Stop();
            flyoutPanel.HidePopup();
            navImprimir.Enabled = true;
            ppGenerando.Caption = "Obteniendo Facturas";
            Pathexport = "";
        }

        //OBTENGO LA LISTA DE IDS EN GRILLA Y GENERO LOS PDF
        private ArrayList Getidcomprobs()
        {
            ArrayList retorno = new ArrayList();
            try
            {
                //RECORRO LOS ITEMS VISIBLES.
                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    if (bgridView.GetRowCellValue(i, colID_Registro).ToString() != "")
                    {
                        retorno.Add(Convert.ToInt64(bgridView.GetRowCellValue(i, colID_Registro)));                        
                    }
                }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //INICIO ENVIO DE EMAILS
        private void IniciaMailingProf()
        {

            if (ctrls.MensajePregunta("¿Está seguro de enviar el/los e-mails?") == DialogResult.No)
            { return; }

            ppGenerando.Caption = "Enviando Emails";
            flyoutPanel.ShowPopup();
            btnMailProfUnico.Enabled = false;
            btnMailProfLista.Enabled = false;

            if (bgwMailing.IsBusy) { bgwMailing.CancelAsync(); }
            while (bgwMailing.CancellationPending)
            { if (!bgwMailing.CancellationPending) { break; } }

            bgwMailing.RunWorkerAsync();
        }

        //ENVIO DE EMAILS A PROFESIONALES
        private void EnviarMailsProf()
        {
            try
            {
                if (!func.hayConexion()) { ctrls.MensajeInfo("No hay conexión a internet para ejecutar ésta acción.", 1); }

                impresion.datosrep = dsreportes;
                List<Mailing> comprobs = new List<Mailing>();

                //RECORRO LOS ITEMS VISIBLES.
                if (Unico)
                {
                    if (bgridView.GetFocusedRowCellValue(colID_Registro).ToString() != "")
                    {                        
                        impresion.InclPaciente = Incluyepaci;
                        impresion.IDRegistro = Convert.ToInt64(bgridView.GetFocusedRowCellValue(colID_Registro));
                        impresion.CargaDatosfcambu(0, 2); //DOS, SOLO EL DUPLICADO

                        comprobs.Add(new Mailing
                        {
                            Adjunto = impresion.GetFacturamsambulatorio(),
                            Comprobante = bgridView.GetFocusedRowCellValue(colComprobante).ToString()
                            + " " + Convert.ToDateTime(bgridView.GetFocusedRowCellValue(colFecha)).ToString("yyyy-MM-yy"),
                            EmailReceptor = bgridView.GetFocusedRowCellValue(colEmailprof).ToString()
                        });

                    }
                }
                else
                {
                    for (int i = 0; i < bgridView.RowCount; i++)
                    {
                        if (bgridView.GetRowCellValue(i, colID_Registro).ToString() != "")
                        {

                            impresion.InclPaciente = Incluyepaci;
                            impresion.IDRegistro = Convert.ToInt64(bgridView.GetRowCellValue(i, colID_Registro));
                            impresion.CargaDatosfcambu(0, 2); //DOS, SOLO EL DUPLICADO

                            comprobs.Add(new Mailing
                            {
                                Adjunto = impresion.GetFacturamsambulatorio(),
                                Comprobante = bgridView.GetRowCellValue(i, colComprobante).ToString()
                                + " " + Convert.ToDateTime(bgridView.GetRowCellValue(i, colFecha)).ToString("yyyy-MM-yy"),
                                EmailReceptor = bgridView.GetRowCellValue(i, colEmailprof).ToString()
                            });

                        }
                    }
                }

                if (comprobs != null && comprobs.Count > 0)
                {
                    func.EnviarEmail(comprobs);
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enviar el email.\n" + e.Message, 0);
                return;
            }
        }

        //FINALIZA ENVIO EMAILS
        private void FinMailingProf()
        {
            flyoutPanel.HidePopup();
            btnMailProfLista.Enabled = true;
            btnMailProfUnico.Enabled = true;
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
            Ibusqemitidos();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwEmitidos.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridView, "S");
        }


        //******************* EVENTOS botones *************************
      
        private void bgwEmitidos_DoWork(object sender, DoWorkEventArgs e)
        {
            Buscaremitidos();
        }

        private void bgwEmitidos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusqemitidos();
        }

        private void bgridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (bgridView.RowCount <= 0) { return; }

            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            bool perm = func.DevuelvePermiso("Amfactman");

            var tipo = bgridView.GetFocusedRowCellValue(colTipo);
            if (tipo != null && tipo.ToString() == "FC" && perm)
            {
                btnNotaCredito.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnNotadebito.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnNotaCredito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnNotadebito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            var r = bgridView.GetFocusedRowCellValue(colEstado);

            if (r != null && r.ToString() == "R")
            {
                btnQueSucedio.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else { btnQueSucedio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }
        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            IDRegistro = 0;
            if (bgridView.RowCount <= 0) { return; }
            var id = bgridView.GetFocusedRowCellValue(colID_Registro);
            if (id != null)
            {
                IDRegistro = Convert.ToInt64(id);
                frmdetalles.IDEncabezado = IDRegistro;
                frmComprobantes.IDFactura = IDRegistro;
            }
            Cambiarow = true;
            RowIndex = e.RowHandle;
        }

        private void btnNotaCredito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tipo = bgridView.GetFocusedRowCellValue(colTipo);

            if (tipo != null && tipo.ToString() == "FC")
            {
                ParametrosNc("NC");
            }
            
        }

        private void btnNotadebito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tipo = bgridView.GetFocusedRowCellValue(colTipo);

            if (tipo != null && tipo.ToString() == "FC")
            {
                ParametrosNc("ND");
            }
        }

        private void bgridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            
            switch (e.Column.Name)
            {
                case "colNoGravado": e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; break;
                case "colNeto": e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;   break;
                case "colIva": e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; break;
                case "colTotal": e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; break;
            }
        }

        private void ViewSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary)
            {
                GridSummaryItem item = e.Item as GridSummaryItem;
                GridView view = sender as GridView;
                string tipo = "";                
                switch (e.SummaryProcess)
                {
                    //calculation entry point
                    case CustomSummaryProcess.Start:
                        Summaryg = 0;
                        break;
                    //consequent calculations
                    case CustomSummaryProcess.Calculate:
                        if (view.GetRowCellValue(e.RowHandle, colEstado).ToString() == "A")
                        {
                            tipo = view.GetRowCellValue(e.RowHandle, colTipo).ToString();
                            decimal importe = Convert.ToDecimal(e.FieldValue);
                            if (tipo == "FC" || tipo == "ND") { Summaryg += Convert.ToDecimal(importe.ToString("0.00")); }
                            if (tipo == "NC") { Summaryg -= Convert.ToDecimal(importe.ToString("0.00")); }
                        }
                        break;                        
                    //final summary value
                    case CustomSummaryProcess.Finalize:
                        e.TotalValue = Summaryg;
                        break;
                }
            }
        }

        private void ViewCustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {            
            if (e.Column.Name == "colTotal" || e.Column.Name == "colNeto" || e.Column.Name == "colIva" ||
                e.Column.Name == "colNoGravado")
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                // Obtain the total summary's value.  
                Decimal summaryValue = Convert.ToDecimal(summary.SummaryValue);
                string summaryText = String.Format("$ {2:n2}", "", "", summaryValue);
                e.Info.DisplayText = summaryText;
            }
        }

        private void tmrDetalles_Tick(object sender, EventArgs e)
        {
            if (Cambiarow) { frmdetalles.Ibusquedareg(); }
            Cambiarow = false;
        }

        private void NavPanel_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (e.IsTile)
            {
                if (bgridView.RowCount <= 0) { return; }
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnImprimir": Iimpresion(true); break;
                    case "btnExppdf": Iexpotarpdf(); break;
                    case "btnExpexel": ctrls.ExportaraExcelgrd(gridControl); break;
                }   
            }
        }

        private void bgwImprimir_DoWork(object sender, DoWorkEventArgs e)
        {
            Imprimir();
        }

        private void bgwImprimir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fimpresion();
        }

        private void btnImprimirunico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimirlst = false;
            if (bgridView.GetFocusedRowCellValue(colTipo).ToString() == "FC") { Iimpresion(true); }
            else { Iimpresion(false); }
        }

        private void bgwExportpdf_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportarPdf();
        }

        private void bgwExportpdf_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fexportapdf();
        }

        private void tmrContadorreg_Tick(object sender, EventArgs e)
        {
            ppGenerando.Description = "Procesando " + impresion.Registrosproces + "/" + impresion.Registrostotal;
        }

        private void btnActualiar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Ibusqemitidos();
        }

        private void btnMailProfUnico_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (ctrls.MensajePregunta("¿Incluir pacientes?") == DialogResult.Yes) { Incluyepaci = true; }
            else { Incluyepaci = false; }
            
            Unico = true;
            IniciaMailingProf();
        }

        private void btnMailProfLista_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ctrls.MensajePregunta("¿Incluir pacientes?") == DialogResult.Yes) { Incluyepaci = true; }
            else { Incluyepaci = false; }
            Unico = false;
            IniciaMailingProf();
        }

        private void bgwMailing_DoWork(object sender, DoWorkEventArgs e)
        {
            EnviarMailsProf();
        }

        private void bgwMailing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FinMailingProf();
        }

        private void btnQueSucedio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_InfoGeneral formu = new Frm_InfoGeneral();
            formu.Es_Popup = true;
            var str = bgridView.GetFocusedRowCellValue(colObservaciones);

            if (str != null) { formu.Informacion = str.ToString(); }

            formu.ShowDialog();
        }

        private void btnNcdmanual_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Frm_FacturaUnica f = new Frm_FacturaUnica();

            f.ShowDialog(this);
            Ibusqemitidos();
            
        }

        private void Igeneraglobal()
        {
            bgridView.BeginDataUpdate();
            ppGenerando.Caption = "EmitiendoComprobante";
            flyoutPanel.ShowPopup();

            if (bgwNotacreditoglb.IsBusy) { return; }

            bgwNotacreditoglb.RunWorkerAsync();
        }

        private void Fgeneraglobal()
        {
            flyoutPanel.HidePopup();
            bgridView.EndDataUpdate();
        }

        private void GeneraNCglobal()
        {
            try
            {
                List<FacturasEmitEncStruct> lista = new List<FacturasEmitEncStruct>();
                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    FacturasEmitEncStruct p = bgridView.GetRow(i) as FacturasEmitEncStruct;
                    lista.Add(p);
                }

                foreach (FacturasEmitEncStruct p in lista)
                {
                    facturacion.GeneraNotaCreditoDebito(p.ID_Registro, 0, 0, p.NoGravado, "NC");
                }

            }
            catch (Exception )
            {

            }
        }

        private void bgwNotacreditoglb_DoWork(object sender, DoWorkEventArgs e)
        {
            GeneraNCglobal();
        }

        private void bgwNotacreditoglb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fgeneraglobal();
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Igeneraglobal();
        }
    }
    
}