using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Frm_AsientoContable : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.AsientosEnc Encabezado { get; set; } = new MC.AsientosEnc();               
        public List<MC.AsientosDet> Asientos { get; set; } = new List<MC.AsientosDet>();

        
        public bool AsientoManual { get; set; } = false;
        private Point LocationSplash = new Point();    
        private bool PlanAutomatico { get; set; } = false;
        private bool AsientoGenerado { get; set; } = false;

        public bool ValidaCaja { get; set; } = false;

        public Frm_AsientoContable()
        {
            InitializeComponent();
                        
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
                        
        }

        #region Metodos Manuales
        
        private void IniciaConexiones()
        {
            try
            {
                VisibilidadControles();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Encabezado.SqlConnection = SqlConnection;                
            }
            catch (Exception)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al inciar las conexiones.", 1);
                return;
            }
        }

        private void VisibilidadControles()
        {
            lblFechaAsiento.Visible = AsientoManual;
            datFechaAsiento.Visible = AsientoManual;
        }

        private void CargaCombos(short cmb = 0, object sndr = null)
        {
            try
            {
                
                //PLAN DE CUENTAS
                if (cmb == 0 || cmb == 1) 
                {
                    //planesSeleccionables
                    CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                    List<CuentasContables.MC.Cuentas> lst = ctas.GetRegistros().Where(w => w.Estado && w.Seleccionable).ToList();

                    reposCmbCuenta.DataSource = null;
                    reposCmbCuenta.DataSource = lst;
                    reposCmbSubcuenta.DataSource = null;
                    reposCmbSubcuenta.DataSource = lst.SelectMany(s => s.SubCuentas).Where(w => w.Estado).ToList();

                    if (sndr != null)
                    {
                        SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                        srch.Properties.DataSource = null;
                        srch.Properties.DataSource = lst;
                    }                                                            
                }
                               
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void SetBindings()
        {
            try
            {                
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.AsientosDet>(Asientos); 
                gridView.EndDataUpdate();

                txtMemo.DataBindings.Add("EditValue", Encabezado, nameof(Encabezado.Observacion));
                datFechaAsiento.DataBindings.Add("EditValue", Encabezado, nameof(Encabezado.AsientoFecha));                

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }

        //SET DATASOURCE SUB CUENTAS
        private void SetSubCuentads(object sndr)
        {
            try
            {
                MC.AsientosDet _rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;

                if (_rd != null)
                {                    
                    List<CuentasContables.MC.Cuentas> cuentas = reposCmbCuenta.DataSource as List<CuentasContables.MC.Cuentas>;
                    if (cuentas == null) { return; }
                    List<CuentasContables.MC.SubCuentas> sbc = cuentas.Where(w => w.IDRegistro == _rd.PlanCuentaID).Select(s => s.SubCuentas.Where(w => w.Estado)).DefaultIfEmpty(new List<CuentasContables.MC.SubCuentas>()).FirstOrDefault().ToList(); 

                    reposCmbSubcuenta.DataSource = null;
                    reposCmbSubcuenta.DataSource = sbc;

                    if (sndr != null)
                    {
                        SearchLookUpEdit cmb = sndr as SearchLookUpEdit;
                            
                        cmb.Properties.DataSource = null;
                        cmb.Properties.DataSource = sbc;
                            
                    }                                                                        
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el ds a la subcuenta.\n{e.Message}", 1);
                return;
            }
        }
               
        //INICIA EMISION FACTURA
        private void IEmiteComprobante()
        {
            try
            {
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                btnGenerar.Enabled = false;
                gridControl.Enabled = false;

                if (bgwEmiteFactura.IsBusy) { return; }
                bgwEmiteFactura.RunWorkerAsync();
            }
            catch (Exception)
            {
                gridControl.Enabled = true;
                btnGenerar.Enabled = true;
            }
        }

        //GENERA REGISTRO/S
        private void EmitirComprobante()
        {
            try
            {
                if (!ValidacionPreviaEmision())
                {                    
                    return;
                }
                else
                {
                    /*if (!ValidaCaja)
                    {
                        if (ctrl.MensajePregunta("¿Está seguro de generar éstos asientos?") != DialogResult.Yes)
                        { return; }
                    }*/
                    
                    GeneraComprobante();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento.\n{e.Message}", 1);
                return;
            }
        }

        private void Impresion()
        {
            try
            {
                if (ValidaCaja) { return; }

                List<MC.AsientosEnc> lst = new List<MC.AsientosEnc>();
                lst.Add(Encabezado);

                Xtra_AsientoComprobante xrpt = new Xtra_AsientoComprobante();
                xrpt.DataSource = lst;

                ReportPrintTool printTool = new ReportPrintTool(xrpt);
                printTool.ShowPreviewDialog();
                printTool.Dispose();
                xrpt.Dispose();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. No se pudo imprimir.\n{e.Message}", 0);
                return;
            }
            
        }

        //FIN EMISION
        private void FEmiteComprobante()
        {
            try
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }

                if (AsientoGenerado) { Impresion(); }

                btnGenerar.Enabled = true;
                gridControl.Enabled = true;

                if (AsientoGenerado) { DialogResult = DialogResult.OK; }
                
            }
            catch (Exception)
            {
                DialogResult = DialogResult.Abort;
            }            
            
        }
             
        //VALIDO ANTES DE EMITIR EL COMPROBANTE
        private bool ValidacionPreviaEmision()
        {
            try
            {                                  
                //NO PUEDE HABER DETALLES SIN CUENTA
                if (Asientos.Where(w => w.PlanCuentaID == 0).Count() > 0)
                {
                    ctrl.MensajeInfo("No se puede guardar un asiento con detalles sin una cuenta asignada.", 1);
                    return false;
                }

                //SIN DIFERENCIAS ENTRE DEBE Y HABER CUANDO LOS ASIENTOS SON AUTOMATICOS
                if ((Asientos.Sum(s => s.ImporteDebe) - Asientos.Sum(s => s.ImporteHaber)) != 0)
                {
                    ctrl.MensajeInfo("No se puede generar un asiento con diferencias entre debe y haber.", 1);
                    return false;
                }

                //FECHA SUPERIOR AL DIA
                if (Encabezado.AsientoFecha > DateTime.Now)
                {
                    ctrl.MensajeInfo("No se puede generar un asiento con fecha posterior a la actual.", 1);
                    return false;
                }

                //SIN OBSERVACION
                if (string.IsNullOrEmpty(Encabezado.Observacion))
                {
                    ctrl.MensajeInfo("Debe ingresar una descripción del asiento.", 1);
                    return false;
                }

                if (Encabezado.AsientoEnPeriodoAnualCerrado())
                {
                    if (!Permisos.Where(w => w.Clave == "CtnAsienCierre" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                    {
                        ctrl.MensajeInfo("No tiene permisos para realizar un asiento en período cerrado.", 1);
                        return false;
                    }

                    if (ctrl.MensajePregunta("¿Está seguro de realizar un asiento en periodo cerrado?") != DialogResult.Yes)
                    {
                        return false;
                    }                                        
                    
                }                          

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
               
        //GENERA COMPROBANTE
        private void GeneraComprobante()
        {
            try
            {
                Dictionary<short, string> retorno = new Dictionary<short, string>();
                                
                Encabezado.Detalles.Clear();
                Encabezado.Detalles.AddRange(Asientos);
                

                retorno = Encabezado.Abm();

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); }
                }
                else { AsientoGenerado = true; }
                
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento.\n{e.Message}", 1);                
                return;
            }
        }
   
        //MARCA REGISTRO BORRAR
        private void MarcaRegistroBorrar()
        {
            try
            {                                
                gridView.BeginDataUpdate();
                
                MC.AsientosDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;
                if (d != null)
                {                    
                    if (d.IDRegistro <= 0 && d.MovimientoCajaID <= 0) { Asientos.Remove(d); }
                    else
                    {
                        if (d.MovimientoCajaID > 0) { ctrl.MensajeInfo("<b>NO</b> se puede eliminar un movimiento generado en caja.\nDe ser necesario, solo puede anularse.", 1); }
                        else { ctrl.MensajeInfo("<b>NO</b> se puede eliminar un movimiento guardado.\nDe ser necesario, solo puede anularse.", 1); }
                    }
                }
                
                gridView.EndDataUpdate();

            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo borrar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }            

        //ASIGNO LOS VALORES A LAS PROPIEDADES ASOCIADAS
        private void SetValoresPlanCuenta(short esplancuenta)
        {
            try
            {
                MC.AsientosDet _rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;
                if (_rd == null) { return; }

                CuentasContables.MC.Cuentas cuentas = (reposCmbCuenta.DataSource as List<CuentasContables.MC.Cuentas>)?.Where(w => w.IDRegistro == _rd.PlanCuentaID).FirstOrDefault()
                                                            as CuentasContables.MC.Cuentas;
                if (cuentas == null) { return; }

                //PLAN DE CUENTAS
                if (esplancuenta == 1)
                {                    
                    _rd.PlanCuentaCodigoCorto = cuentas.CodigoCorto;
                    _rd.PlanCuentaCodigoLargo = cuentas.CodigoLargo;
                    _rd.PlanCuentaNombre = cuentas.Descripcion;
                    
                }//SUCUENTAS
                else
                {
                    CuentasContables.MC.SubCuentas sbc = cuentas.SubCuentas.Where(w => w.IDRegistro == _rd.PlanSubCuentaID).FirstOrDefault();                        

                    if (sbc == null) { return; }

                    _rd.PlanSubCuentaCodigoCorto = sbc.Codigo;
                    _rd.PlanSubCuentaNombre = sbc.Descripcion;
                                                                

                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un error al asignar los valores.\n{e.Message}", 1);
                return;
            }
        }

        #endregion

        private void Frm_ComprobanteElectronico_Shown(object sender, EventArgs e)
        {
            IniciaConexiones();
            CargaCombos();
            SetBindings();            
        }

        private void Frm_ComprobanteElectronico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Parent is XtraTabPage)
            {
                XtraTabPage c = Parent as XtraTabPage;
                XtraTabControl x = c.Parent as XtraTabControl;
                x.TabPages.Remove(c);
            }
        }
                
        #region GRILLA DETALLES

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView v = gridView;
                GridColumn c = new GridColumn();

                MC.AsientosDet det = v.GetRow(v.FocusedRowHandle) as MC.AsientosDet;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    //SIN PLAN DE CUENTAS
                    if (det.PlanCuentaID <= 0)
                    {
                        errorstring = "Debe seleccionar una cuenta contable para continuar.";
                        e.Valid = false; c = colCuentaID;
                    }

                    // IMPORTE CERO
                    if (e.Valid && det.ImporteDebe == 0 && det.ImporteHaber == 0)
                    {
                        errorstring = "Debe completar al menos un campo de importes para continuar.";
                        e.Valid = false; c = colDebe;
                    }

                    // DOBLE IMPORTE 
                    if (e.Valid && det.ImporteDebe > 0 && det.ImporteHaber > 0)
                    {
                        errorstring = "No puede generar un asiento con importes en debe y haber.";
                        e.Valid = false; c = colDebe;
                    }

                    if (!e.Valid) { v.SetColumnError(c, errorstring); }
                }
            }
            catch (Exception)
            {

            }
        }
     
        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2) { gridView.AddNewRow(); }
            else if (e.KeyData == Keys.F4) { MarcaRegistroBorrar(); }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }


        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            gridView.Focus();
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));            
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            gridView.UpdateTotalSummary();
        }

        private void reposTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }
                
        #endregion
                      
        #region COMBOS
                     
        private void reposCmbSubcuenta_BeforePopup(object sender, EventArgs e)
        {
            if (!PlanAutomatico) { SetSubCuentads(sender); }
        }

        #endregion
                
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            IEmiteComprobante();                                    
        }

        private void bgwEmiteFactura_DoWork(object sender, DoWorkEventArgs e)
        {
            EmitirComprobante();
        }

        private void bgwEmiteFactura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FEmiteComprobante();
        }
                          
        private void btnBorrarRegistro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MarcaRegistroBorrar();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {                
                //SI NO HAY DETALLES, NO DEJO BORRAR
                if (Asientos.Count <= 0) { btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }
                else { btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }                                
            }
            catch (Exception)
            {
                
            }           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            gridView.Focus();
            gridView.AddNewRow();
            gridView.ShowEditForm();
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void gridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            try
            {
                e.DefaultDraw();

                if (e.Column == colHaber && Asientos.Sum(s => s.ImporteDebe) > Asientos.Sum(s => s.ImporteHaber))
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
            catch (Exception)
            {
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "PlanCuentaID") { SetValoresPlanCuenta(1); }
                else if (e.Column.FieldName == "PlanSubCuentaID") { SetValoresPlanCuenta(2); }
            }
            catch (Exception)
            {
            }
        }
    }
}