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
using AMDGOINT.Formularios.Caja.MC;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Caja.Vista
{
    public partial class Frm_CajaMovimientos : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();
        private Notificacionesbd notificacionesbd = new Notificacionesbd();
        private SqlConnection SqlConnection = new SqlConnection();
        private Usr_Resumen UsrResumen = new Usr_Resumen();
        private CajaMovimientos Caja = new CajaMovimientos();
        private List<CajaMovimientos> Movimientos = new List<CajaMovimientos>();
        private CajaSaldoArrastre SaldoArrastrecls { get; set; } = new CajaSaldoArrastre();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();
                        
        private Point LocationSplash = new Point();
        private decimal sumaPiecol { get; set; } = 0;
        private CajaMovimientos _movimiento;        
        public Frm_CajaMovimientos()
        {

            InitializeComponent();

            colDebe.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colhaber.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;

            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            
            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

            SetControles();
        }

        #region METODOS MANUALES
                
        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Caja.SqlConnection = SqlConnection;            
            Permiso.SqlConnection = SqlConnection;
            SaldoArrastrecls.SqlConnection = SqlConnection;
            UsrResumen.SaldoArrastrecls = SaldoArrastrecls;

            notificacionesbd.ID_Consulta = 207;
            notificacionesbd.ListenerChange();

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());            
        }

        //RESUMEN DE MOVIMIENTOS
        private void SetControles()
        {
            try
            {
                panelResumen.Controls.Add(UsrResumen);
                UsrResumen.Dock = DockStyle.Fill;
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
                HabilitaControles(false);
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                HabilitaControles(true);
                gridView.EndDataUpdate();
                timerEscucha.Start();
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Movimientos.Clear();               
                Movimientos.AddRange(Caja.GetRegistros().OrderBy(O => O.IDRegistro).ToList());
               
              
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
                gridControl.DataSource = Movimientos;
                gridView.EndDataUpdate();
                HabilitaControles(true);

                UsrResumen.Movimientos = Movimientos;

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                HabilitaControles(true);
                timerEscucha.Start();
            }
            
        }

        //ESTADO DE CONTROLES
        private void HabilitaControles(bool _estado)
        {
            btnImpresion.Enabled = _estado;
            btnNuevo.Enabled = _estado;
            btnActualizar.Enabled = _estado;
            btnCerrarCaja.Enabled = _estado;
        }

        //PREPARO IMPRESION
        public void PreparaImpresion()
        {
            try
            {
                List<CajaSaldoArrastre> _saldos = new List<CajaSaldoArrastre>();
                _saldos.Add(SaldoArrastrecls);

                if (!Permisos.Where(w => w.Clave == "CajaPrint" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de caja", 1);
                    return;
                }

                Xtra_Caja rpt = new Xtra_Caja();
                rpt.DataSource = _saldos;
                
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.ShowPreviewDialog();


            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la impresión.\n{e.Message}", 1);
                return;                
            }
            
        }
             
        //EXPORTA EXCEL (parametro de grid para acceso public0)
        public void ExportaExcel(GridControl grid = null)
        {
            if (!Permisos.Where(w => w.Clave == "CajaExl" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
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
                if (!Permisos.Where(w => w.Clave == "CajaNew" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar movimientos en caja.", 1);
                    return;
                }
                                
                Frm_MovimientoManual frm = new Frm_MovimientoManual();                
                frm.SqlConnection = SqlConnection;

                if (acc != "N" && _movimiento != null)
                {
                    if (_movimiento.MovimientoManual) { ctrls.MensajeInfo("Éste es un movimiento automático, no puede editarse.", 1); return; }
                    frm.Movimientos.Add(_movimiento);
                }

                if (frm.ShowDialog(this) == DialogResult.OK) { IBusqRegistros();  }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //ANULACION DEL REGISTRO
        private void AnularMovimiento()
        {
            try
            {

                if (!Permisos.Where(w => w.Clave == "CajaAnula" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar Anulaciones.", 1);
                    return;
                }                                

                if (_movimiento != null)
                {                                        
                    gridView.BeginDataUpdate();

                    string palabra = !_movimiento.Estado ? "Computar" : "Anular";
                    if (ctrls.MensajePregunta($"¿{palabra} el movimiento seleccionado?") == DialogResult.Yes)
                    { _movimiento.Estado = !_movimiento.Estado; }

                    _movimiento.SqlConnection = SqlConnection;
                    _movimiento.Abm();

                    gridView.EndDataUpdate();
                }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        //INICIO CIERRE CAJA
        private void CerrarCaja()
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "CajaCierre" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar ésta acción.", 1);
                    return;
                }

                if (ctrls.MensajePregunta("Está a punto de hacer un cierre de caja;\ntodos aquellos movimientos anulados no generarán un asiento.\n ¿Continuar?") != DialogResult.Yes) { return; }

                List<AsientosContables.MC.AsientosDet> asientos = new List<AsientosContables.MC.AsientosDet>();

                Movimientos.Where(w => w.Estado).ToList().ForEach(f => asientos.Add(new AsientosContables.MC.AsientosDet
                {
                    PlanCuentaID = f.PlanCuentaID,
                    PlanSubCuentaID = f.PlanSubCuentaID,
                    ImporteDebe = f.ImporteDebe,
                    ImporteHaber = f.ImporteHaber,
                    MovimientoCajaID = f.IDRegistro,
                    Descripcion = f.DescripcionExtensa
                }));


                AsientosContables.Vista.Frm_AsientoContable frm = new AsientosContables.Vista.Frm_AsientoContable();
                frm.SqlConnection = SqlConnection;
                frm.ValidaCaja = true;
                frm.Asientos.AddRange(asientos);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SaldoArrastrecls.Abm(); //GUARDO EL SALDO DE ARRASTRE         
                    PreparaImpresion();
                    IBusqRegistros();
                }

                frm.Dispose();
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al procesar el cierre de caja.\n{e.Message}", 1);                
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
                    case "btnPrevisualizacion": PreparaImpresion() ; break;                    
                    case "btnExcel": ExportaExcel(); break;                    
                }

            }
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
                _movimiento = null;
                _movimiento = gridView.GetRow(gridView.FocusedRowHandle) as MC.CajaMovimientos;                                
                
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar los detalles de la factura.", 1);
            }

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
                if (e.RowHandle != GridControl.NewItemRowHandle && (e.Column.FieldName == "EstadoDescripcion"))
                {
                    if (e.CellValue.ToString() == "Computable")
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
            
        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {
                MC.CajaMovimientos  d = gridView.GetRow(gridView.FocusedRowHandle) as MC.CajaMovimientos;
                if (d != null)
                {
                    string palabra = !d.Estado ? "Computar movimiento" : "Anular movimiento";
                    btnEstadoMovimiento.Caption = palabra;
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void gridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary &&
                   ((e.Item as GridSummaryItem).FieldName == colDebe.FieldName) ||
                   ((e.Item as GridSummaryItem).FieldName == colhaber.FieldName))
            {
                GridSummaryItem item = e.Item as GridSummaryItem;

                switch (e.SummaryProcess)
                {
                    case DevExpress.Data.CustomSummaryProcess.Start:
                        sumaPiecol = 0;
                        break;

                    case DevExpress.Data.CustomSummaryProcess.Calculate:
                        if (gridView.GetRowCellValue(e.RowHandle, colEstado).ToString() == "Computable")
                        {
                            sumaPiecol += Convert.ToDecimal(e.FieldValue);
                        }
                        break;

                    case DevExpress.Data.CustomSummaryProcess.Finalize:
                        e.TotalValue = sumaPiecol;
                        break;
                }
            }
        }

        private void gridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {

            try
            {
                if (e.Column == colDebe || e.Column == colhaber)
                {
                    GridSummaryItem summary = e.Info.SummaryItem;
                    decimal summaryvalue = Convert.ToDecimal(summary.SummaryValue);
                    string summarytext = string.Format("{2:C2}", "", "", summaryvalue);
                    e.Info.DisplayText = summarytext;
                    
                    e.DefaultDraw();

                    if (e.Column == colhaber && Movimientos.Where(w => w.Estado).Sum(s => s.ImporteDebe) > Movimientos.Where(w => w.Estado).Sum(s => s.ImporteHaber))
                    {
                        e.Cache.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128), 5), e.Bounds);
                    }
                    else if (e.Column == colDebe && Movimientos.Where(w => w.Estado).Sum(s => s.ImporteDebe) < Movimientos.Where(w => w.Estado).Sum(s => s.ImporteHaber))
                    { e.Cache.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128), 5), e.Bounds); }
                    else
                    {
                        e.Cache.DrawRectangle(e.Cache.GetPen(Color.Transparent, 5), e.Bounds);
                    }
                    e.Handled = true;
                   
                }
            }
            catch (Exception)
            {

            }
          
        }

        private void btnEstadoMovimiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnularMovimiento();
        }

        private void btnCerrarCaja_ElementClick(object sender, NavElementEventArgs e)
        {
            CerrarCaja();
        }
    }
    
}