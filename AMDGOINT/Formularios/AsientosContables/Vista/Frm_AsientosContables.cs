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
using AMDGOINT.Formularios.AsientosContables.MC;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Frm_AsientosContables : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();
        private Notificacionesbd notificacionesbd = new Notificacionesbd();
        private SqlConnection SqlConnection = new SqlConnection();
        
        private Usr_Detalles UsrDetalles = new Usr_Detalles();
        private AsientosEnc Asiento = new AsientosEnc();
        private List<AsientosEnc> Asientos = new List<AsientosEnc>();
        private Impresion Impresioncls = new Impresion();
        private bool ImpresionOk = false;
        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();
                        
        private Point LocationSplash = new Point();
        private decimal sumaPiecol { get; set; } = 0;
        private AsientosEnc _asiento;     
        
        public Frm_AsientosContables()
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
            Asiento.SqlConnection = SqlConnection;            
            Permiso.SqlConnection = SqlConnection;
            Impresioncls.SqlConnection = SqlConnection;
            
            notificacionesbd.ID_Consulta = 208;
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
                if (bgwObtienereg.IsBusy) { return; }

                timerEscucha.Stop();
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                HabilitaControles(false);
                gridView.BeginDataUpdate();

                
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
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
                Asientos.Clear();               
                Asientos.AddRange(Asiento.GetRegistros());                
                
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
                gridControl.DataSource = Asientos;
                gridView.EndDataUpdate();
                HabilitaControles(true);
                
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
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
            btnConciliacionBancaria.Enabled = _estado;
            btnCierreAnual.Enabled = _estado;
        }

        private void Iimpresion(short modoimpresion)
        {
            try
            {
                if (modoimpresion != 4)
                {
                    Usr_PrintParams pr = new Usr_PrintParams();

                    if (XtraDialog.Show(pr, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }


                    if (pr.FechaDesde > pr.FechaHasta)
                    {
                        ctrls.MensajeInfo("La fecha DESDE no puede ser MAYOR a la fecha HASTA.", 1);
                        pr.Dispose();
                        return;
                    }

                    //DIFERENCIA EN AÑOS
                    if ((pr.FechaHasta.Year - pr.FechaDesde.Year) > 1)
                    {
                        ctrls.MensajeInfo("El intervalo de de búsqueda no puede ser superior a un año.", 1);
                        pr.Dispose();
                        return;
                    }

                    //SELECCION DE CUENTA SI ES MODO 1 O 2
                    if ((modoimpresion == 1 || modoimpresion == 2) && pr.IDPlanCuenta == 0)
                    {
                        ctrls.MensajeInfo("Para mayorizar una cuenta o imprimir un libro diario, debe seleccionar un plan contable.", 1);
                        pr.Dispose();
                        return;
                    }

                    Impresioncls.Ejercicio = pr.Ejercicio;
                    Impresioncls.FechaDesde = pr.FechaDesde;
                    Impresioncls.FechaHasta = pr.FechaHasta;
                    Impresioncls.IDPlanCuenta = pr.IDPlanCuenta;
                    Impresioncls.IDPlanSubCuenta = pr.IDPlanSubCuenta;
                    Impresioncls.ModoImpresion = modoimpresion;
                    Impresioncls.IncluirCuentasCero = pr.IncluirCuentasCero;
                }
                else //IMPRESION ASIENTO
                {

                }

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                if (bgwImpresion.IsBusy) { if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }  return; }
                bgwImpresion.RunWorkerAsync();
            }
            catch (Exception e)
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return;
            }
        }

        private void Impresion()
        {
            try
            {
                ImpresionOk = Impresioncls.GetRegistros();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return;
            }
        }

        private void Fimpresion()
        {
            try
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                if (ImpresionOk) { Impresioncls.MuestraReporte(); }
            }
            catch (Exception e)
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return;
            }
        }
               
        //GENERACION DE COMPROBANTE
        private void GeneraComprobante(string acc = "N")
        {
            try
            {

                //PERMISOS GENERAL
                if (!Permisos.Where(w => w.Clave == "CntNew" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar nuevos asientos.", 1);
                    return;
                }
                                
                Frm_AsientoContable frm = new Frm_AsientoContable();                
                frm.SqlConnection = SqlConnection;
                frm.AsientoManual = true;                
                if (frm.ShowDialog(this) == DialogResult.OK){ IBusqRegistros();  }                
                frm.Dispose();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //IMPRESION DE ASIENTO
        private void ImprimeAsiento()
        {
            try
            {
                if (_asiento != null)
                {
                    List<AsientosEnc> asientos = new List<AsientosEnc>();
                    asientos.Add(_asiento);

                    Xtra_AsientoComprobante xrpt = new Xtra_AsientoComprobante();
                    xrpt.DataSource = asientos;

                    ReportPrintTool printTool = new ReportPrintTool(xrpt);
                    printTool.ShowPreviewDialog();
                    printTool.Dispose();
                    xrpt.Dispose();
                }
                
            }
            catch (Exception)
            {
                return;
            }
        }

        //INICIO CIERRE 
        private void CierreMensual()
        {
            try
            {
                /*if (!Permisos.Where(w => w.Clave == "CntCierreMens" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar ésta acción.", 1);
                    return;
                }

                if (ctrls.MensajePregunta("Está a punto de hacer un cierre contable <b>MENSUAL</b>¿Continuar?") != DialogResult.Yes) { return; }

                List<AsientosDet> asientos = new List<AsientosDet>();

                Asientos.Where(w => w.Estado).ToList().ForEach(f => asientos.Add(new AsientosContables.MC.AsientosDet
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
                */
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al procesar el cierre de caja.\n{e.Message}", 1);                
                return;
            }
        }

        private void CierreAnual()
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "CntCierreAnual" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar ésta acción.", 1);
                    return;
                }

                if (ctrls.MensajePregunta($"¿Está segura de realizar el cierre del ejercicio {DateTime.Today.Year}?") != DialogResult.Yes) { return; }

                Frm_CierreEjercicio frm = new Frm_CierreEjercicio();
                frm.SqlConnection = SqlConnection;

                timerEscucha.Stop();
                if (frm.ShowDialog() == DialogResult.OK) { IBusqRegistros(); } else { timerEscucha.Start(); }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return;
            }
        }

        private void ConciliacionBancaria()
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "CntConciliacion" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar ésta acción.", 1);
                    return;
                }

                Frm_ConciliacionBancaria frm = new Frm_ConciliacionBancaria();
                frm.SqlConnection = SqlConnection;

                frm.Show();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
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
                    case "btnLibroDiario": Iimpresion(1) ; break;                    
                    case "btnMayorCuenta": Iimpresion(2); break;                    
                    case "btnBalanceintegracion": Iimpresion(3); break;                    
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
                _asiento = null;
                _asiento = gridView.GetRow(gridView.FocusedRowHandle) as AsientosEnc;
                UsrDetalles.Asientos = _asiento?.Detalles;
                
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
               /* if (e.RowHandle != GridControl.NewItemRowHandle && (e.Column.FieldName == "EstadoDescripcion"))
                {
                    if (e.CellValue.ToString() == "Computable")
                    { e.RepositoryItem = repositoryTextSI; }
                    else { e.RepositoryItem = repositoryTextNO; }
                }*/
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
                        //if (gridView.GetRowCellValue(e.RowHandle, colEstado).ToString() == "Computable"){}
                        
                        sumaPiecol += Convert.ToDecimal(e.FieldValue);
                        
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

                    if (e.Column == colhaber && Asientos.Sum(s => s.ImporteDebe) > Asientos.Sum(s => s.ImporteHaber))
                    {
                        e.Cache.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128), 5), e.Bounds);

                    }
                    else if (e.Column == colDebe && Asientos.Sum(s => s.ImporteDebe) < Asientos.Sum(s => s.ImporteHaber))
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
        
        private void btnCierreAnual_ElementClick(object sender, NavElementEventArgs e)
        {
            CierreAnual();
        }

        private void bgwImpresion_DoWork(object sender, DoWorkEventArgs e)
        {
            Impresion();
        }

        private void bgwImpresion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fimpresion();
        }

        private void btnConciliacionBancaria_ElementClick(object sender, NavElementEventArgs e)
        {
            ConciliacionBancaria();
        }

        private void btnImprimirAsiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImprimeAsiento();
        }
    }
    
}