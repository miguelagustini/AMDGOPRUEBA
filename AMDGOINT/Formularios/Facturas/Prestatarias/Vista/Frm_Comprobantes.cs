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
using System.Linq;
using DevExpress.XtraGrid;
using AMDGOINT.Formularios.Facturas.Prestataria.Vista;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Collections;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Frm_Comprobantes : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();

        private Facturacion Facturacion = new Facturacion();
        private List<ComprobanteEnc> FacturasEncabezados = new List<ComprobanteEnc>();
        
        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private ComprobanteEnc Facturascls = new ComprobanteEnc();
        private ComprobanteDet Detallescls = new ComprobanteDet();
        private ComprobantesRel Comprobantesrelcls = new ComprobantesRel();

        private Impresion Impresion = new Impresion();

        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();

        private Usr_Detalles UsrDetallesindividual = new Usr_Detalles();
        private Usr_ComprobantesRel UsrComprobantesrel = new Usr_ComprobantesRel();

        private ComprobanteEnc _encabezado;

        private List<ComprobanteEnc> ListaPrint { get; set; } = new List<ComprobanteEnc>();
        private short CantCopias { get; set; } = 0;
        private bool Incluyepaci { get; set; } = false;
        private bool Incluyedetalles { get; set; } = false;
        private bool Incluyeprestador { get; set; } = true;
        private bool Incluyeleyendaorg { get; set; } = false;
        private short Modo { get; set; } = 0;
        private bool ExportacionWeb { get; set; } = false;
        private string Pathexport { get; set; } = "";
        private bool _lanzaactualizacion = false;

        public bool LanzaActualizacion
        {
            get { return _lanzaactualizacion; }
            set
            {
                if (_lanzaactualizacion != value)
                {
                    IBusqRegistros();
                }
            }
        }

        public Frm_Comprobantes()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
                     
            SetControles();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Facturacion.SqlConnection = SqlConnection;
            Facturascls.SqlConnection = SqlConnection;
            Detallescls.SqlConnection = SqlConnection;
            Comprobantesrelcls.SqlConnection = SqlConnection;
            UsrDetallesindividual.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());

            btnCalcintereses.Enabled = Permisos.Where(w => w.Clave == "PrestCalcInt" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First();
            
        }

        private void SetControles()
        {
            try
            {
                panelDetalles.Controls.Add(UsrDetallesindividual);
                UsrDetallesindividual.Dock = DockStyle.Fill;                
                panelComprobrel.Controls.Add(UsrComprobantesrel);
                UsrComprobantesrel.Dock = DockStyle.Fill;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo inconvenientes en la asignacion de controles.\n{e.Message}", 1);
            }
        }

        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                btnImpresion.Enabled = false;
                titleComprobanteAfip.Enabled = false;
                btnActualizar.Enabled = false;

                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                btnImpresion.Enabled = true;
                titleComprobanteAfip.Enabled = true;
                btnActualizar.Enabled = true;
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                FacturasEncabezados.Clear();                
                FacturasEncabezados.AddRange(Facturascls.GetRegistros());                
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
                gridControl.DataSource = FacturasEncabezados;
                gridView.EndDataUpdate();                                               
                
                btnImpresion.Enabled = true;
                titleComprobanteAfip.Enabled = true;
                btnActualizar.Enabled = true;

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                btnImpresion.Enabled = true;
                titleComprobanteAfip.Enabled = true;
                btnActualizar.Enabled = true;
            }
            
        }
              
        //PREPARO IMPRESION
        public void PreparaImpresion(short mode = 0, bool unicoreg = false, long findbyid = 0)
        {
            try
            {
                Impresion.Facturas.Clear();
                ListaPrint.Clear();
                Modo = mode;

                if (!Permisos.Where(w => w.Clave == "AmfactImpresion" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de comprobantes", 1);
                    return;
                }

                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                CantCopias = parametros.Cantidad;
                Incluyepaci = parametros.IncluirPacientes;
                Incluyedetalles = parametros.IncluirDetalles;
                Incluyeprestador = parametros.IncluirPrestador;
                Incluyeleyendaorg = parametros.IncluirLeyendaOriginal;

                if (unicoreg)
                {
                    //SI DEBO ENCONTRAR POR ID (USADO PARA IMPRIMIR DESDE FUERA DEL FORM)
                    if (findbyid > 0)
                    {
                        ComprobanteEnc p = FacturasEncabezados.Where(w => w.IDRegistro == findbyid).FirstOrDefault();

                        if (p != null)
                        {
                            if (p.EstadoAf != "A") {
                                ctrls.MensajeInfo("El comprobante no está autorizado por AFIP.", 1);
                                return;
                            }

                            p.Detalles.Clear();
                            p.Detalles.AddRange(Detallescls.GetRegistrosPorComprobante(p.IDRegistro));
                            ListaPrint.Add(p);
                        }
                        else
                        {
                            ctrls.MensajeInfo("No se encontró el comprobante a visualizar.", 1);
                            return;
                        }

                    }
                    else
                    {
                        ComprobanteEnc p = gridView.GetRow(gridView.FocusedRowHandle) as ComprobanteEnc;

                        if (p != null)
                        {
                            if (p.EstadoAf != "A")
                            {
                                ctrls.MensajeInfo("El comprobante no está autorizado por AFIP.", 1);
                                return;
                            }

                            if (p.Detalles.Count <= 0) { p.Detalles.AddRange(Detallescls.GetRegistrosPorComprobante(p.IDRegistro)); }
                            ListaPrint.Add(p);
                        }
                        else
                        {
                            ctrls.MensajeInfo("No se encontró el comprobante a visualizar.", 1);
                            return;
                        }

                            
                    }

                    Impresion.Facturas = ListaPrint;
                    if (mode == 0) { Impresion.Imprimir(CantCopias, Incluyepaci, Incluyedetalles, Incluyeprestador, Incluyeleyendaorg); }
                    if (mode == 1) { Iexpotarpdf(); }
                }
                else
                {
                    if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }


                    if (bgwDetallesbak.IsBusy) { bgwDetallesbak.CancelAsync(); }
                    while (bgwDetallesbak.CancellationPending)
                    { if (!bgwDetallesbak.CancellationPending) { break; } }

                    bgwDetallesbak.RunWorkerAsync();
                }

                parametros.Dispose();
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la impresión.\n{e.Message}", 1);
                return;                
            }
        }
       
        //EXPORTA PDF
        private void Iexpotarpdf()
        {
            try
            {
                if (CantCopias <= 0) { return; }
                btnImpresion.Enabled = false;

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                        Pathexport = fbd.SelectedPath;                                                                        

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
                btnImpresion.Enabled = true;
                return;
            }
        }

        private void ExportarPdf()
        {
            try
            {
                if (Pathexport == "") { return; }
                Impresion.GeneraDatosPdf(CantCopias, Pathexport, Incluyedetalles, Incluyepaci, Incluyeprestador, ExportacionWeb);
                ExportacionWeb = false;

            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        private void Fexportapdf()
        {

            btnImpresion.Enabled = true;
            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            Pathexport = "";
        }

        //EXPORTA EXCEL (parametro de grid para acceso public0)
        public void ExportaExcel(GridControl grid = null)
        {
            if (!Permisos.Where(w => w.Clave == "Amfactexportaxls" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene acceso a la exportacion de comprobantes en lista.", 1);
                return;
            }

            ctrls.ExportaraExcelgrd(grid != null ? grid : gridControl);
        }

        //GENERACION DE COMPROBANTE
        private void GeneraComprobante(short tipoc = 0)
        {
            try
            {

                if (!Permisos.Where(w => w.Clave == "Amfactman" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar comprobantes electrónicos.", 1);
                    return;
                }
                                
                Frm_Comprobante frm = new Frm_Comprobante();
                frm.FormularioPadre = this;
                frm.SqlConnection = SqlConnection;

                if (_encabezado != null && tipoc == 1)
                {
                    if (_encabezado.TipoComprobante != "FC" && _encabezado.TipoComprobante != "FCE")
                    {
                        ctrls.MensajeInfo("No se pueden generar comprobantes en base a un subcomprobante.", 1);
                        frm.Dispose();
                        return;
                    }

                    _encabezado.Detalles.Clear();
                    _encabezado.Detalles.AddRange(UsrDetallesindividual.Detalles.Where(w => w.IDEncabezado == _encabezado.IDRegistro));
                    _encabezado.ComprobantesRelacion.Clear();
                    _encabezado.ComprobantesRelacion.AddRange(UsrComprobantesrel.Comprobanteslst);

                    frm.ComprobanteOriginal = _encabezado.Clone();
                    frm.FromZero = false;
                }
                else
                {
                    frm.ComprobanteOriginal = new ComprobanteEnc();
                    frm.FromZero = true;
                }

                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }


        private void RecalculaIntereses()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Está seguro de recalcular los intereses de los comprobantes?") != DialogResult.Yes) { return; }

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                using (var command = new SqlCommand("sp_CalculaIntereses", SqlConnection) { CommandType = CommandType.StoredProcedure })
                {
                    command.ExecuteNonQuery();
                }

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }

                IBusqRegistros();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al ejecutar el cálculo.\n" + e.Message, 0);
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                return;
            }
        }

        private void MarcaPagado()
        {
            try
            {

                if (!Permisos.Where(w => w.Clave == "PrestfactPago" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para marcar el pago de comprobantes.", 1);
                    return;
                }


                if (ctrls.MensajePregunta("¿Cambiar el estado del comprobante?") != DialogResult.Yes) { return; }

                ComprobanteEnc co = gridView.GetRow(gridView.FocusedRowHandle) as ComprobanteEnc;

                if (co == null)
                {
                    ctrls.MensajeInfo("No se pudo cambiar el estado del comprobante", 1);
                    return;
                }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Pagada");
                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");

                parametros.Add(1);
                parametros.Add(glb.GetIdUsuariolog());
                parametros.Add(DateTime.Now);

                Funciones f = new Funciones();
                f.AccionBD(campos, parametros, "U", "FACTPRESENC", co.IDRegistro);

                gridView.BeginDataUpdate();
                gridView.SetFocusedRowCellValue(colPagada, 1);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al actualizar {e.Message}", 0);
                return;
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
            ctrls.PreferencesGrid(this, dockManager, "S");
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

        private void NavPanel_ElementClick(object sender, NavElementEventArgs e)
        {
            if (e.IsTile)
            {                
                NavPanel.HideDropDownWindow();

                if (gridView.RowCount > 0)
                {
                    if (e.Element.Name == "btnPrevisualizacion") { PreparaImpresion(0); }
                    else if (e.Element.Name == "btnPdf") { PreparaImpresion(1); }
                    else if (e.Element.Name == "btnExcel") { ExportaExcel(); }
                    else if (e.Element.Name == "btnComprobanterel") { GeneraComprobante(1); }
                    else if (e.Element.Name == "btnExportaweb") { ExportacionWeb = true; PreparaImpresion(1); }                    
                }

                if (e.Element.Name == "btnComprobantecero") { GeneraComprobante(0); }

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

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            if (popupMenu.Visible) { popupMenu.HidePopup(); }

            try
            {
                _encabezado = gridView.GetRow(gridView.FocusedRowHandle) as ComprobanteEnc;
                UsrDetallesindividual.IDFactura = _encabezado != null ? _encabezado.IDRegistro : 0;
                UsrComprobantesrel.IDFactura = _encabezado != null ? _encabezado.IDRegistro : 0;
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar los detalles de la factura.", 1);
            }

        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PreparaImpresion(0, true);
        }

        private void btnActualizar_ElementClick(object sender, NavElementEventArgs e)
        {
            IBusqRegistros();
        }

        private void gridView_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            try
            {
                GridGroupRowInfo info = e.Info as GridGroupRowInfo;
                GridView view = sender as GridView;
                var rowValue = view.GetGroupRowValue(info.RowHandle, info.Column);
                info.GroupText = rowValue.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void bgwDetallesbak_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                ComprobanteEnc p = gridView.GetRow(i) as ComprobanteEnc;
                if (p != null && p.EstadoAf == "A")
                {
                    if (p.Detalles.Count <= 0) { p.Detalles.AddRange(Detallescls.GetRegistrosPorComprobante(p.IDRegistro)); }
                    ListaPrint.Add(p);
                }
                
            }
        }

        private void bgwDetallesbak_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Impresion.Facturas = ListaPrint;
            if (Modo == 0) { Impresion.Imprimir(CantCopias, Incluyepaci, Incluyedetalles, Incluyeprestador, Incluyeleyendaorg); }
            if (Modo == 1) { Iexpotarpdf(); }

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }

        private void btnCalcintereses_ElementClick(object sender, NavElementEventArgs e)
        {
            RecalculaIntereses();
        }

        private void btnPagado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MarcaPagado();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {
                ComprobanteEnc p = gridView.GetRow(gridView.FocusedRowHandle) as ComprobanteEnc;

                btnPagado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (p != null)
                {
                    if (p.ComprobanteTipo != "NC" && p.ComprobanteTipo != "NCE") { btnPagado.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }
                }                

            }
            catch (Exception)
            {

            }
            
        }
    }
    
}