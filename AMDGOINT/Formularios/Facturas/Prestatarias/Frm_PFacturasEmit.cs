using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using AMDGOINT.Datos;
using System.Collections;
using System.Linq;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Frm_PFacturasEmit : XtraForm
    {
        private ConexionBD cb = new ConexionBD();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Impresionglob impresion = new Impresionglob();
        private PrestFactura facturas = new PrestFactura();
        public List<ComprobPE> listacomprobantes = new List<ComprobPE>();
        private List<ComprobPE> encabezadoslst = new List<ComprobPE>();
        private Reportes dsreportes = new Reportes();

        MC.ComprobantesRel Comprobantesrel = new MC.ComprobantesRel();

        private Frm_PFacturasDet frmdetalle = new Frm_PFacturasDet();
        private Vista.Frm_Comprobantesrel frmComprobantes = new Vista.Frm_Comprobantesrel();

        private string periodo { get; set; } = "";
        private string Pathexport { get; set; } = "";
        private long IDRegistro { get; set; } = 0;
        private bool Imprimirlst { get; set; } = true;
        private bool Imprimirdetailed { get; set; } = false;
        private bool IncluirPacientes { get; set; } = false;
        private decimal Summaryg { get; set; } = 0;
        private bool CambiaRow { get; set; } = false;
        private short Exportaweb { get; set; } = 0;
        private string Origenctrl { get; set; } = "";

        public Frm_PFacturasEmit()
        {          
            InitializeComponent();
                        
            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            bgridView.CustomSummaryCalculate += new CustomSummaryEventHandler(ViewSummaryCalculate);
            bgridView.CustomDrawFooterCell += new FooterCellCustomDrawEventHandler(ViewCustomDrawFooterCell);
            ctrls.setSplitter(splitControl);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;
            Comprobantesrel.SqlConnection = SqlConnection;

            colIva.SummaryItem.SummaryType = SummaryItemType.Custom;
            colNeto.SummaryItem.SummaryType = SummaryItemType.Custom;
            colTotal.SummaryItem.SummaryType = SummaryItemType.Custom;

            tableLayoutPanel1.RowStyles[1].Height = 0;
            ctrls.PreferencesGrid( this, bgridView, "R");

            // Detalles            
            frmdetalle.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmdetalle, TabDetalles);            
            frmComprobantes.Comprobanteslst = Comprobantesrel.GetRegistros();
            ctrls.AgregaFormulario(frmComprobantes, TabDetalles);

            //ICONOS            
            TabDetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;
            TabDetalles.TabPages[1].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;
            TabDetalles.SelectedTabPageIndex = 0;
            tmrDetalles.Start();

            btnComprobmanual.Enabled = func.DevuelvePermiso("PrestCompman");
            btnCalculaIntereses.Enabled = func.DevuelvePermiso("PrestCalcInt");
        }
                
        //INICIO BUSQUEDA PENDIENTES
        private void Ibusqemitidos()
        {                                   
            bgridView.BeginDataUpdate();
            ppGenerando.Caption = "Consultando Registros";
            flyoutPanel.ShowPopup();

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            
            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA PENDIENTES
        private void Fbusqemitidos()
        {            
            flyoutPanel.HidePopup();            
            gridControl.DataSource = listacomprobantes;
            bgridView.EndDataUpdate();
            
        }
        
        //INICIA IMPRESION
        private void Iimpresion()
        {

            if (Imprimirlst)
            {
                if (ctrls.MensajePregunta("¿Imprimir Detalles?") == DialogResult.Yes)
                {
                    Imprimirdetailed = true;

                    if (ctrls.MensajePregunta("¿IncluirPacientes?") == DialogResult.Yes)
                    {
                        IncluirPacientes = true;
                    }
                    else { IncluirPacientes = false; }
                }
                else { Imprimirdetailed = false; }
            }

            navImpresion.Enabled = false;
            btnPrintone.Enabled = false;
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
            impresion.Imprimirdetallado = Imprimirdetailed;
            impresion.InclPaciente = IncluirPacientes;

            if (Imprimirlst)
            {
                impresion.Clearingfcprestat();

                //RECORRO LOS ITEMS VISIBLES.
                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    if (bgridView.GetRowCellValue(i, colID_Registro).ToString() != "")
                    {
                        impresion.IDRegistro = Convert.ToInt64(bgridView.GetRowCellValue(i, colID_Registro));
                        impresion.CargaDatosfcprestat(1);
                    }
                }
            }
            else
            {
                //SOLO UN REGISTRO (SELECCIONADO)
                impresion.IDRegistro = IDRegistro;
                impresion.CargaDatosfcprestat();
            }

        }

        //FINALIZA IMPRESIONA
        private void Fimpresion()
        {
            flyoutPanel.HidePopup();
            navImpresion.Enabled = true;
            btnPrintone.Enabled = true;
            ppGenerando.Caption = "Obteniendo Facturas";
            Imprimirlst = true;
            impresion.MuestraReporteFcprest();
        }

        //EXPORTA PDF
        private void Iexpotarpdf()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Imprimir Detalles?") == DialogResult.Yes)
                {
                    Imprimirdetailed = true;
                    if (ctrls.MensajePregunta("¿IncluirPacientes?") == DialogResult.Yes)
                    {
                        IncluirPacientes = true;
                    }
                    else { IncluirPacientes = false; }
                }
                else { Imprimirdetailed = false; }

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();                

                    if (result == DialogResult.OK)
                    {                        
                        Pathexport = fbd.SelectedPath;
                        navImpresion.Enabled = false;
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
                impresion.Imprimirdetallado = Imprimirdetailed;
                impresion.InclPaciente = IncluirPacientes;
                impresion.datosrep = dsreportes;
                impresion.GuardaPdffcprest(Getidcomprobs(), Pathexport, Exportaweb);
            

            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        private void Fexportapdf()
        {            
            flyoutPanel.HidePopup();
            navImpresion.Enabled = true;
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

        //SET PERIODO DE FACTURA
        private decimal ImporteComprobantes()
        {
            try
            {
                // initialize a new XtraInputBoxArgs instance
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                // set required Input Box options
                args.Caption = "Antes de comenzar...";
                args.Prompt = "Introduzca el importe del comprobante.";
                args.DefaultButtonIndex = 0;
                args.Showing += ctrls.Args_Showingglob;
                // initialize a DateEdit editor with custom settings
                TextEdit editor = new TextEdit();
                editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                editor.Properties.Mask.EditMask = "[0-9]*([.,][0-9]{2})?";//@"\d+(\,\d{1,2})?";
                editor.Properties.Mask.UseMaskAsDisplayFormat = true;
                args.Editor = editor;
                // a default DateEdit value
                args.DefaultResponse = 0;
                // display an Input Box with the custom editor
                var result = XtraInputBox.Show(args);
                                
                if (result != null)
                {                    
                    return Convert.ToDecimal(result.ToString().Replace(".", ","));
                }
                else { return 0; }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el Importe.\n" + e.Message, 0);
                return 0;
            }
        }
        
        //VALIDO SI EL IMPORTE DE LA NCD ES CORRECTO PARA LA FACTURA
        private bool ValidaImporte(decimal imp)
        {
            try
            {
                bool retorno = false;

                if (IDRegistro <= 0) { return retorno; }

                string c = "SELECT ISNULL(SUM(FC.Total),0) - ISNULL((SELECT ISNULL(SUM(FC1.Total),0) AS Total " +
                            "                                                      FROM FACTPRESREL RE" +
                            "                                                      LEFT OUTER JOIN FACTPRESENC FC1 ON(FC1.ID_Registro = RE.ID_NotaCredito " +
                            "                                                     AND RE.ID_Factura = FC.ID_Registro " +
                            "                                                     AND FC1.EstadoAf = 'A')),0) " +
                            "                             + ISNULL((SELECT ISNULL(SUM(FC2.Total), 0) AS Total" +
                            "                                                     FROM FACTPRESREL RE1 " +
                            "                                                     LEFT OUTER JOIN FACTPRESENC FC2 ON(FC2.ID_Registro = RE1.ID_NotaDebito" +
                            "                                                     AND RE1.ID_Factura = FC.ID_Registro" +
                            "                                                     AND FC2.EstadoAf = 'A')),0) " +
                            " AS IPendiente" +
                            " FROM FACTPRESENC FC"+
                            " WHERE FC.ID_Registro = " + IDRegistro + " AND EstadoAf = 'A'" +
                            " GROUP BY FC.ID_Registro";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    if (r["IPendiente"] != DBNull.Value && Convert.ToDecimal(r["IPendiente"]) > 0
                        && Convert.ToDecimal(r["IPendiente"]) >= imp)
                    { retorno = true; }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar el Importe.\n" + e.Message, 0);
                return false;
            }
        }

        //GENERO LA NOTA DE CRÉDITO
        private void GeneraNcre()
        {
            var letra = bgridView.GetFocusedRowCellValue(colLetra);

            if (letra.ToString().ToUpper() == "X") { return; }

            var tic = bgridView.GetFocusedRowCellValue(colTipoComprob);

            if (tic == null) { ctrls.MensajeInfo("No logramos obtener el tipo de comprobante.", 1); return; }

            string tipocom = "";

            if (tic.ToString() == "FC") { tipocom = "NC"; } else { tipocom = "NCE"; }

            decimal importe = ImporteComprobantes();
            bool valimp = ValidaImporte(importe);
            bool nulaprevia = false;

            if (tic.ToString() == "FCE" && ctrls.MensajePregunta("¿El comprobante fue anulado por el receptor?") == DialogResult.Yes) { nulaprevia = true; }

            if (importe > 0 && valimp)
            {
                if (ctrls.MensajePregunta("¿Generar la Nota de crédito por $ " + importe + "?") == DialogResult.Yes)
                {
                    List<ComprobPE> l = listacomprobantes.Where(r => r.ID_Factura == IDRegistro).ToList();
                    facturas.GeneraNCD(l, IDRegistro, importe, tipocom, nulaprevia);
                    if (facturas.GlobalIDcomp > 0)
                    {
                        impresion.datosrep = dsreportes;
                        impresion.IDRegistro = facturas.GlobalIDcomp;
                        impresion.CargaDatosfcprestat();
                        impresion.MuestraReporteFcprest();
                    }
                    Ibusqemitidos();
                }
            }
            else
            {
                if (importe <= 0) { return; }
                else if (!valimp) { ctrls.MensajeInfo("No se puede generar una nota de crédito\nde éste monto para ésta factura.", 1); }
            }
        }

        //GENERO LA NOTA DE DEBITO
        private void GeneraNdre()
        {
            var tic = bgridView.GetFocusedRowCellValue(colTipoComprob);

            var letra = bgridView.GetFocusedRowCellValue(colLetra);

            if (letra.ToString().ToUpper() == "X") { return; }

            if (tic == null) { ctrls.MensajeInfo("No logramos obtener el tipo de comprobante.", 1); return; }

            string tipocom = "";

            if (tic.ToString() == "FC") { tipocom = "ND"; } else { tipocom = "NDE"; }

            bool nulaprevia = false;
            if (tic.ToString() == "FCE" && ctrls.MensajePregunta("¿El comprobante fue anulado por el receptor?") == DialogResult.Yes) { nulaprevia = true; }

            decimal importe = ImporteComprobantes();            

            if (importe > 0)
            {
                if (ctrls.MensajePregunta("¿Generar la Nota de débito por $ " + importe + "?") == DialogResult.Yes)
                {
                    List<ComprobPE> l = listacomprobantes.Where(r => r.ID_Factura == IDRegistro).ToList();
                    facturas.GeneraNCD(l, IDRegistro, importe, tipocom, nulaprevia);
                    if (facturas.GlobalIDcomp > 0)
                    {
                        impresion.datosrep = dsreportes;
                        impresion.IDRegistro = facturas.GlobalIDcomp;
                        impresion.CargaDatosfcprestat();
                        impresion.MuestraReporteFcprest();
                    }
                    Ibusqemitidos();
                }
            }
            else
            {
                if (importe <= 0) { return; }                
            }
        }

        //INICIO LA IMPRESION PPP
        private void IimpresionPPP()
        {
            if (Origenctrl == "") { return; }
            navImpresion.Enabled = false;
            btnPrintone.Enabled = false;
            ppGenerando.Caption = "Preparando Impresión";
            flyoutPanel.ShowPopup();

            if (bgwControlppp.IsBusy) { bgwControlppp.CancelAsync(); }
            while (bgwControlppp.CancellationPending)
            { if (!bgwControlppp.CancellationPending) { break; } }

            bgwControlppp.RunWorkerAsync();
        }

        //GENERO LA IMPRESION PPP
        private void ComplementarRegistrosppp()
        {
            try
            {
                encabezadoslst.Clear();

                //OBTENER ENCABEZADO FILTRADO, NEW LISTA DESDE GRID
                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    ComprobPE e = bgridView.GetRow(i) as ComprobPE;
                    encabezadoslst.Add(e);

                }

                List<ComprobPD> detalleslst = new List<ComprobPD>();
                long min = encabezadoslst.Min(r => r.ID_Factura);
                long max = encabezadoslst.Max(r => r.ID_Factura);

                //OBTENGO TODOS LOS DETALLES DEL RANGO DE ENCABEZADOS
                string c = "SELECT ID_Registro, ID_Encabezado, Periodo, Descripcion, NroDocumento, Paciente, Cantidad," +
                                 " Neto, Gastos, Honorarios, Iva, Total, Puntero, Origen, CodProfesional, Profesional," +
                                 " CASE WHEN ProfCndIva = '1' THEN 'RI'" +
                                 " WHEN ProfCndIva = '4' THEN 'EX'" +
                                 " WHEN ProfCndIva = '6' THEN 'MO'" +
                                 " ELSE '' END AS ProfCndIva, FechaPractica, CodPractica, DescPractica" +
                                 " FROM FACTPRESDET" +
                                 " WHERE Origen = '" + Origenctrl + "' AND ID_ENCABEZADO >= " + min + "" +
                                 " AND ID_ENCABEZADO <= " + max;
                                                
                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    detalleslst.Add(new ComprobPD
                    {
                        IDDetalle = Convert.ToInt64(f["ID_Registro"]),
                        IDFactura = Convert.ToInt64(f["ID_Encabezado"]),
                        Periodo = f["Periodo"].ToString(),
                        Descripcion = f["Descripcion"].ToString(),
                        DocumPaciente = f["NroDocumento"].ToString(),
                        NombrePaciente = f["Paciente"].ToString().Trim(),
                        Cantidad = Convert.ToDecimal(f["Cantidad"]),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Gastos = Convert.ToDecimal(f["Gastos"]),
                        Honorarios = Convert.ToDecimal(f["Honorarios"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        Puntero = Convert.ToInt64(f["Puntero"]),
                        Origen = f["Origen"].ToString(),
                        CodProfesional = f["CodProfesional"].ToString(),
                        Profesional = f["Profesional"].ToString(),
                        ProfCond = f["ProfCndIva"].ToString(),
                        FechaPractica = f["FechaPractica"].ToString(),
                        CodPractica = f["CodPractica"].ToString(),
                        DescPractica = f["DescPractica"].ToString()

                    });
                }


                //OBTENGO LOS DETALLES PARA CADA ENCABEZZADO
                foreach (ComprobPE p in encabezadoslst)
                {
                    p.Detalles = detalleslst.Where(r => r.IDFactura == p.ID_Factura).ToList();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        //FIN IMPRESION PPP
        private void FimpresionPPP()
        {
            flyoutPanel.HidePopup();
            navImpresion.Enabled = true;
            btnPrintone.Enabled = true;
            ppGenerando.Caption = "Obteniendo Facturas";

            Xtra_ControlAmbuppp rep = new Xtra_ControlAmbuppp();
            rep.DataSource = encabezadoslst;
            ReportPrintTool printTool = new ReportPrintTool(rep);
            printTool.ShowPreviewDialog();
            
        }

        //MARCAR COMO PAGADA
        private void MarcarPagada()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Pagada");
                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");

                parametros.Add(1);
                parametros.Add(globales.GetIdUsuariolog());
                parametros.Add(func.Getfechorserver());

                func.AccionBD(campos, parametros, "U", "FACTPRESENC", IDRegistro);

                bgridView.SetFocusedRowCellValue(colPagada, 1);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al actualizar {e.Message}", 0);
                return;
            }
        }


        private void RecalculaIntereses()
        {                        
            try
            {
                if (ctrls.MensajePregunta("¿Está seguro de recalcular los intereses de los comprobantes?") != DialogResult.Yes) { return; }

                if (!splashManager.IsSplashFormVisible) { splashManager.ShowWaitForm(); }

                using (var command = new SqlCommand("sp_CalculaIntereses", SqlConnection) {CommandType = CommandType.StoredProcedure})
                {                    
                    command.ExecuteNonQuery();
                }

                if (splashManager.IsSplashFormVisible) { splashManager.CloseWaitForm(); }

                Ibusqemitidos();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al ejecutar el cálculo.\n" + e.Message, 0);
                if (splashManager.IsSplashFormVisible) { splashManager.CloseWaitForm(); }
                return;
            }
            
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            Ibusqemitidos();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            ctrls.PreferencesGrid(this, bgridView, "S");
        }
        
        //******************* EVENTOS botones *************************
       
        private void bgwPendientes_DoWork(object sender, DoWorkEventArgs e)
        {            
            listacomprobantes = facturas.GetEmitidos();
        }

        private void bgwPendientes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusqemitidos();
        }
        
        private void btnPrintone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            Imprimirlst = false;
            Imprimirdetailed = false;
            IncluirPacientes = false;

            if (ctrls.MensajePregunta("¿Imprimir Detalles?") == DialogResult.Yes)
            {
                Imprimirdetailed = true;
                if (ctrls.MensajePregunta("¿IncluirPacientes?") == DialogResult.Yes)
                {
                    IncluirPacientes = true;
                }                
            }
            
                        
            Iimpresion();
        }


        private void btnQuesucedio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_InfoGeneral formu = new Frm_InfoGeneral();
            formu.Es_Popup = true;
            var str = bgridView.GetFocusedRowCellValue(colObservaciones);

            if (str != null) { formu.Informacion = str.ToString(); }
            
            formu.ShowDialog();
        }

        private void bgridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            bool permiso = func.DevuelvePermiso("PrestCompman");

            if (bgridView.RowCount <= 0)
            {
                btnNotaCredito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnNotaDebito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnQuesucedio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPrintone.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnPagadas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                return;
            }
            var obs = bgridView.GetFocusedRowCellValue(colEstadoAf);

            if (obs != null && obs.ToString().ToUpper() == "R")
            { btnQuesucedio.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }
            else { btnQuesucedio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }

            var tipo = bgridView.GetFocusedRowCellValue(colTipoComprob);
            var letra = bgridView.GetFocusedRowCellValue(colLetra);
            if (tipo != null && (tipo.ToString() == "FC" || tipo.ToString() == "FCE") 
                && letra.ToString().ToUpper() == "C" && obs.ToString().ToUpper() != "R")
            {
                btnNotaCredito.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnNotaDebito.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnNotaCredito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnNotaDebito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            
            //PAGADAS 
            var pagada = bgridView.GetFocusedRowCellValue(colPagada);
            if (tipo.ToString() != "NC" && !Convert.ToBoolean(pagada)) { btnPagadas.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }
            else { btnPagadas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }

            if (!permiso)
            {
                btnNotaCredito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnNotaDebito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void bgwExportpdf_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportarPdf();
        }

        private void bgwExportpdf_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fexportapdf();
        }

        private void bgwImprimir_DoWork(object sender, DoWorkEventArgs e)
        {
            Imprimir();
        }

        private void bgwImprimir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fimpresion();
        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            IDRegistro = 0;

            var idreg = bgridView.GetFocusedRowCellValue(colID_Registro);

            if (idreg != null)
            {
                IDRegistro = Convert.ToInt64(idreg);
                frmdetalle.IDEncabezado = IDRegistro;
                frmComprobantes.IDFactura = IDRegistro;
            }
            else { frmdetalle.IDEncabezado = 0; }
            CambiaRow = true;
            
        }

        private void NavPanel_ElementClick(object sender, NavElementEventArgs e)
        {
            if (e.IsTile)
            {
                if (bgridView.RowCount <= 0) { return; }
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnImpcomp": Iimpresion(); break;
                    case "btnExpPdf": Exportaweb = 0; Iexpotarpdf(); break;
                    case "btnExpExls": ctrls.ExportaraExcelgrd(gridControl); break;
                    case "btnWebpdfexp": Exportaweb = 1; Iexpotarpdf(); break;
                  
                }

            }
        }

        private void btnNotaCredito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GeneraNcre();
        }

        private void btnNotaDebito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GeneraNdre();
        }

        private void btnActualizar_ElementClick(object sender, NavElementEventArgs e)
        {
            Ibusqemitidos();
        }


        private void bgridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column == colTotal || e.Column == colNeto || e.Column == colIva)
            { e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; }
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
                        if (view.GetRowCellValue(e.RowHandle, colEstadoAf).ToString() == "A")
                        {
                            tipo = view.GetRowCellValue(e.RowHandle, colTipoComprob).ToString();
                            decimal importe = Convert.ToDecimal(e.FieldValue);
                            if (tipo == "FC" || tipo == "ND" || tipo == "NDE" || tipo == "FCE")
                            { Summaryg += Convert.ToDecimal(importe.ToString("0.00")); }
                            else if (tipo == "NCE" || tipo == "NC" ) { Summaryg -= Convert.ToDecimal(importe.ToString("0.00")); }
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
            if (e.Column == colTotal || e.Column == colNeto || e.Column == colIva)
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                // Obtain the total summary's value.  
                Decimal summaryValue = Convert.ToDecimal(summary.SummaryValue);
                string summaryText = String.Format("$ {2:n2}", "", "", summaryValue);
                e.Info.DisplayText = summaryText;
            }
        }

        private void btnComprobmanual_ElementClick(object sender, NavElementEventArgs e)
        {
            Frm_PFacturaUnica f = new Frm_PFacturaUnica();

            f.ShowDialog();

            Ibusqemitidos();
        }

        private void btnFacturasxc_ElementClick(object sender, NavElementEventArgs e)
        {/*
            if (ctrls.MensajePregunta("¿Emitir Facturacion C sobre Comprobantes X?") == DialogResult.Yes)
            {
                EmisionXC emision = new EmisionXC();
                emision.GenerarFacturasXC();
            }*/
            
        }

        private void tmrDetalles_Tick(object sender, EventArgs e)
        {
            if (CambiaRow) { frmdetalle.Ibusquedareg(); }
            CambiaRow = false;
        }

        private void bgwControlppp_DoWork(object sender, DoWorkEventArgs e)
        {
            ComplementarRegistrosppp();
        }

        private void bgwControlppp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FimpresionPPP();
        }

        private void btnPagadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IDRegistro <= 0){ return; }

            if (ctrls.MensajePregunta("¿Marcar ésta factura como Pagada?") == DialogResult.Yes)
            {
                MarcarPagada();
            }
        }

        private void btnCalculaIntereses_ElementClick(object sender, NavElementEventArgs e)
        {
            RecalculaIntereses();
        }
    }
}