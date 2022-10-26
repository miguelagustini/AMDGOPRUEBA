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
using AMDGOINT.Formularios.OrdenesPago.MC;

namespace AMDGOINT.Formularios.OrdenesPago.Vista
{
    public partial class Frm_OrdenesPago : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();

        private OrdenPagoEnc Orden = new OrdenPagoEnc();
        private List<OrdenPagoEnc> Ordenes = new List<OrdenPagoEnc>();
        private List<OrdenPagoEnc> ListaPrint = new List<OrdenPagoEnc>();
        private Usr_Detalles UsrDetalles = new Usr_Detalles();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();
        private Notificacionesbd notificacionesbd = new Notificacionesbd();
        private Impresion Impresion = new Impresion();
        private short CantCopias = 1;
        private bool IncluirCuentas = false;
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();

        private OrdenPagoEnc _encabezado;
                
        private string Pathexport { get; set; } = "";

        public Frm_OrdenesPago()
        {

            InitializeComponent();

            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            SetControles();

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Orden.SqlConnection = SqlConnection;            
            Permiso.SqlConnection = SqlConnection;


            notificacionesbd.ID_Consulta = 206;            
            notificacionesbd.ListenerChange();

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());            
        }

        private void SetControles()
        {
            try
            {
                panelDetalles.Controls.Add(UsrDetalles);
                UsrDetalles.Dock = DockStyle.Fill;                
            }
            catch (Exception)
            {

            }
        }

        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {
                timerEscucha.Stop();
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                btnImpresion.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
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
                btnNuevo.Enabled = true;
                btnActualizar.Enabled = true;
                btnEditar.Enabled = true;
                gridView.EndDataUpdate();
                timerEscucha.Start();
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Ordenes.Clear();               
                Ordenes.AddRange(Orden.GetRegistros());                
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
                gridControl.DataSource = Ordenes;
                gridView.EndDataUpdate();                
                btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnActualizar.Enabled = true;

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnActualizar.Enabled = true;
                timerEscucha.Start();
            }
            
        }
              
        //PREPARO IMPRESION
        public void PreparaImpresion(short mode = 0,  bool unicoreg = false, long findbyid = 0)
        {
            try
            {                
                ListaPrint.Clear();

                if (!Permisos.Where(w => w.Clave == "OrdPrint" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de comprobantes", 1);
                    return;
                }
                    

                if (unicoreg)
                {
                    //SI DEBO ENCONTRAR POR ID (USADO PARA IMPRIMIR DESDE FUERA DEL FORM)
                    if (findbyid > 0)
                    {
                        OrdenPagoEnc p = Ordenes.Where(w => w.IDRegistro == findbyid).FirstOrDefault();

                        if (p != null){ ListaPrint.Add(p); }
                        else
                        {
                            ctrls.MensajeInfo("No se encontró el comprobante a visualizar.", 1);
                            return;
                        }
                    }
                    else
                    {
                        OrdenPagoEnc p = gridView.GetRow(gridView.FocusedRowHandle) as OrdenPagoEnc;
                        if (p != null)
                        {                            
                            ListaPrint.Add(p);
                        }
                    }
                    
                }
                else
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        OrdenPagoEnc p = gridView.GetRow(i) as OrdenPagoEnc;                        
                        if (p != null) { ListaPrint.Add(p); }
                        
                    }
                }

                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                CantCopias = parametros.Cantidad;
                IncluirCuentas = parametros.IncluirCuentas;

                Impresion.Ordenes = ListaPrint;

                if (mode == 0) { Impresion.Imprimir(CantCopias, IncluirCuentas); }
                if (mode == 1) { Iexpotarpdf(); }

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
                Impresion.GeneraDatosPdf(ListaPrint, CantCopias, Pathexport);

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
            if (!Permisos.Where(w => w.Clave == "OrdExl" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene acceso a la exportacion de comprobantes en lista.", 1);
                return;
            }

            ctrls.ExportaraExcelgrd(grid != null ? grid : gridControl);
        }

        //GENERACION DE COMPROBANTE
        private void GeneraComprobante(string acc = "N")
        {
            try
            {

                //PERMISOS GENERAL
                if (!Permisos.Where(w => w.Clave == "OrdEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar Órdenes de pago.", 1);
                    return;
                }

                if (_encabezado != null && _encabezado.IDRegistro > 0 && acc == "E" && !_encabezado.PuedoModificar())
                {
                    ctrls.MensajeInfo("<b>No</b> se puede modificar una orden que pertenece a una caja cerrada.", 1);
                    return;
                }

                Frm_OrdenPago frm = new Frm_OrdenPago();
                frm.FormularioPadre = this;
                frm.SqlConnection = SqlConnection;

                frm.Permisos.Clear();
                frm.Permisos.AddRange(Permisos);

                frm.Orden = _encabezado != null && acc == "E" ? _encabezado.Clone() : new OrdenPagoEnc();                
                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //ANULACION DEL REGISTRO
        private void AnularOrden()
        {
            try
            {

                if (!Permisos.Where(w => w.Clave == "OrdAnula" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar Anulaciones.", 1);
                    return;
                }

                if (!_encabezado.PuedoModificar())
                {
                    ctrls.MensajeInfo("<b>No</b> se puede anular una orden que pertenece a una caja cerrada.", 1);
                    return;
                }

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                OrdenPagoEnc d = gridView.GetRow(gridView.FocusedRowHandle) as OrdenPagoEnc;
                                
                if (d != null)
                {
                                      
                    gridView.BeginDataUpdate();
                    string palabra = !d.Estado ? "Incluir" : "Excluir";
                    if (ctrls.MensajePregunta($"¿{palabra} la órden seleccionada?.\nSe hará lo mismo para los movimientos de caja generados.") == DialogResult.Yes)
                    { d.Estado = !d.Estado; }
                                        
                    //ENCABEZADO
                    d.SqlConnection = SqlConnection;
                    d.Abm(false);

                    //MOVIMIENTOS CAJA
                    Caja.MC.CajaMovimientos _caja = new Caja.MC.CajaMovimientos(SqlConnection);
                    d.Detalles.ForEach(f => _caja.ModificacionAsociados("OrdenPagoDetalleID", f.IDRegistro, d.Estado));
                    gridView.EndDataUpdate();
                }
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
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
                if (gridView.RowCount <= 0) { return; }
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnPrevisualizacion": PreparaImpresion(0) ; break;
                    case "btnPdf": PreparaImpresion(1); break;
                    case "btnExcel": ExportaExcel(); break;
                    case "btnExportacionweb": PreparaImpresion(1); break;                     
                }

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

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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
                _encabezado = gridView.GetRow(gridView.FocusedRowHandle) as OrdenPagoEnc;
                if (_encabezado != null)
                {                    
                    UsrDetalles.Detalles = _encabezado.Detalles;
                    UsrDetalles.IDOrdenPago = _encabezado.IDRegistro;
                }                
                
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

        private void btnNuevo_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraComprobante();
        }

        private void btnEditar_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraComprobante("E");
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {                
                if (e.RowHandle != GridControl.NewItemRowHandle && (e.Column.FieldName == "PagoRecibidoDescripcion"))
                {
                    if (e.CellValue.ToString() == "SI")
                    { e.RepositoryItem = repositoryTextSI; }
                    else { e.RepositoryItem = repositoryTextNO; }
                }
            }
            catch (Exception)
            {
                return;                
            }
        }

        private void timerEscucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesbd.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                IBusqRegistros();

                notificacionesbd.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }

        private void btnActualizar_ElementClick(object sender, NavElementEventArgs e)
        {
            IBusqRegistros();
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnularOrden();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {
                OrdenPagoEnc d = gridView.GetRow(gridView.FocusedRowHandle) as OrdenPagoEnc;
                if (d != null)
                {
                    string palabra = !d.Estado ? "Incluir Orden" : "Excluir Orden";
                    btnAnular.Caption = palabra;
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
    
}