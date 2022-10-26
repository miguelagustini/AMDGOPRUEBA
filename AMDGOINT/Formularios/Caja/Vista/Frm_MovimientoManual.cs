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

namespace AMDGOINT.Formularios.Caja.Vista
{
    public partial class Frm_MovimientoManual : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.CajaMovimientos Movimiento { get; set; } = new MC.CajaMovimientos();       
        public List<MC.CajaMovimientos> Movimientos { get; set; } = new List<MC.CajaMovimientos>();
        private bool ComprobanteGenerado = true;


        private Point LocationSplash = new Point();
        
        private int IDSubCuentaDetalle = 0;
        private bool CargaInicialCmb = true;
        private bool PlanAutomatico { get; set; } = false;

        public Frm_MovimientoManual()
        {
            InitializeComponent();
                        
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            reposFechas.NullDate = DateTime.MinValue;
            reposFechas.NullText = string.Empty;            
        }

        #region Metodos Manuales
        
        private void IniciaConexiones()
        {
            try
            {
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Movimiento.SqlConnection = SqlConnection;                
            }
            catch (Exception)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al inciar las conexiones.", 1);
                return;
            }
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
                
                //BANCOS
                if (cmb == 0 || cmb == 2) 
                {
                    Bancos.MC.Banco banc = new Bancos.MC.Banco(SqlConnection);
                    cmbBancos.DataSource = banc.GetRegistros();                    
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
                gridControl.DataSource = new BindingList<MC.CajaMovimientos>(Movimientos); 
                gridView.EndDataUpdate();
                                
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
                MC.CajaMovimientos _rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.CajaMovimientos;

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

                    if (IDSubCuentaDetalle > 0) { _rd.PlanSubCuentaID = IDSubCuentaDetalle; }
            
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
                    if (ctrl.MensajePregunta("¿Está seguro de generar éstos movimientos?") != DialogResult.Yes) { return; }
                    GeneraComprobante();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el movimiento.\n{e.Message}", 1);
                return;
            }
        }

        //FIN EMISION FACTURA
        private void FEmiteComprobante()
        {
            try
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }

                btnGenerar.Enabled = true;
                gridControl.Enabled = true;

                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                Close();
            }            
            
        }
             
        //VALIDO ANTES DE EMITIR EL COMPROBANTE
        private bool ValidacionPreviaEmision()
        {
            try
            {                
                if (Movimientos.Where(w => !w._BorrarRegistro && w.PlanCuentaID <= 0).Count() > 0)
                {
                    ctrl.MensajeInfo("Todos los pases deben contener una cuenta contable al menos.", 1);
                    return false;
                }

                if (Movimientos.Where(w => !w._BorrarRegistro && w.ImporteDebe == 0 && w.ImporteHaber == 0).Count() > 0)
                {
                    ctrl.MensajeInfo("No se pueden agregar pases con importes en 0.", 1);
                    return false;
                }
                              
                /*TOTALES
                if (Movimiento.ImporteTotal == 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante con importe total igual a cero ($ 0).", 1);
                    return false;
                }

                if (Movimiento.Detalles.Where(w => !w._BorraRegistro).Count() <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin detalles.", 1);
                    return false;
                }
                                               
                //NO PERMITO SELECCIONAR PROFESIONAL Y PRESTADORA AL MISMO TIEMPO
                if (Movimiento.IDEmpresa > 0 && Movimiento.IDPrestadorCuenta > 0 && Movimiento.IDEmpleado > 0)
                {
                    ctrl.MensajeInfo("Solo se pueden generar comprobantes a prestador, empleado o tercero, no todos al mismo tiempo.", 1);
                    return false;
                }
              
                //QUE NO BORRE TODOS LOS DETALLES
                if (Movimiento.Detalles.Where(w => w._BorraRegistro).Count() > 0 && Movimiento.Detalles.Where(w => !w._BorraRegistro).Count() <= 0)
                {
                    ctrl.MensajeInfo("No se puede guardar un recibo sin sus detalles.\nSi pretende borrar todos los detalles, debe anular la orden.", 1);
                    return false;
                }

                //NO PUEDE HABER DETALLES SIN CUENTA
                if (Movimiento.Detalles.Where(w => w.PlanCuentaID == 0).Count() > 0)
                {
                    ctrl.MensajeInfo("No se puede guardar un recibo con detalles sin una cuenta asignada.", 1);
                    return false;
                }*/
                                
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

                foreach (MC.CajaMovimientos c in Movimientos)
                {
                    c.SqlConnection = SqlConnection;
                    retorno = c.Abm();

                    if (retorno.Count > 0)
                    {
                        string mensajes = "";

                        foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                        {
                            mensajes += $"{i.Trim()}\n";
                        }

                        if (!string.IsNullOrWhiteSpace(mensajes))
                        { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); ComprobanteGenerado = false; }
                    }
                }
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir la orden.\n{e.Message}", 1);
                ComprobanteGenerado = false;
                return;
            }
        }
   
        //MARCA REGISTRO BORRAR
        private void MarcaRegistroBorrar()
        {
            try
            {                                
                gridView.BeginDataUpdate();
                
                MC.CajaMovimientos d = gridView.GetRow(gridView.FocusedRowHandle) as MC.CajaMovimientos;
                if (d != null)
                {
                    if (d.IDRegistro <= 0) { Movimientos.Remove(d); }
                    else { ctrl.MensajeInfo("<b>NO</b> se puede eliminar un movimiento guardado.\nDe ser necesario, solo puede anularse.", 1); }
                }
                
                gridView.EndDataUpdate();

            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        //AGREGO RETIROS POR ENCABEZADO
        private void AgregarRetiros()
        {
            try
            {                
                Retiros.Vista.Frm_RetirosSelector parametros = new Retiros.Vista.Frm_RetirosSelector();
                parametros.SqlConnection = SqlConnection;
                
                if (parametros.ShowDialog() != DialogResult.OK || parametros.Detalles.Where(w => w.Seleccionado).Count() <= 0)
                {
                    parametros.Dispose();
                    return;
                }


                gridView.BeginDataUpdate();

                var retirosagrupados = parametros.Detalles.Where(w => w.Seleccionado).ToList()
                    .GroupBy(g => new
                    {
                        g.IDEncabezado,
                        g.IDCuentaAmdgo                        
                    })
                    .Select(s => new
                    {
                        ID = s.Key.IDEncabezado,
                        IDCuenta = s.Key.IDCuentaAmdgo,                        
                        Total = s.Sum(r => r.Importe)
                    }).ToList();

                if (retirosagrupados != null)
                {
                    foreach (var v in retirosagrupados)
                    {
                        //SI YA EXISTE, NO LO AGREGO
                        //if (Movimientos.Select(s => s.RetiroEncabezadoID).Contains(v.ID)) { continue; }

                        Movimientos.Add(new MC.CajaMovimientos
                        {
                            RetiroEncabezadoID = v.ID,
                            Descripcion = "Retiro Nro. " + v.ID.ToString("0000") + " " + (v.IDCuenta == 546 ? "AMDGO" : v.IDCuenta == 547 ? "MGM" : ""),
                            ModoPago = 0,
                            BancoID = 0,
                            ImporteDebe = v.Total
                        });
                    }
                }
                               
                gridView.EndDataUpdate();
                parametros.Dispose();                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al mostrar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        //VALIOD SI EL PLAN DE CUENTAS LLEVA SUBCUENTA, NO PERMITO GUARDAR
        private bool DebeSeleccionarSubCuenta(int plancuentaidsel)
        {
            try
            {
                bool retorno = false;

                List<CuentasContables.MC.Cuentas> cuentas = reposCmbCuenta.DataSource as List<CuentasContables.MC.Cuentas>;

                if (cuentas == null) { retorno = true; }                                
                if (cuentas.Where(w => w.IDRegistro == plancuentaidsel).SelectMany(s => s.SubCuentas).ToList().Count() > 0) { retorno = true; }

                return retorno;

            }
            catch (Exception)
            {
                return false;
            }            

        }

        private void AsignaCuentasRegistros()
        {
            try
            {
                if (gridView.RowCount <= 0) { return; }
                gridView.BeginDataUpdate();

                MC.CajaMovimientos d = gridView.GetRow(gridView.FocusedRowHandle) as MC.CajaMovimientos;

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (d != null)
                    {
                        MC.CajaMovimientos n = gridView.GetRow(i) as MC.CajaMovimientos;
                        n.PlanCuentaID = d.PlanCuentaID;
                        n.PlanSubCuentaID = d.PlanSubCuentaID;
                    }
                }

                gridView.EndDataUpdate();

            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                return;
            }
        }

        private void AsignaBancoRegistros()
        {
            try
            {
                if (gridView.RowCount <= 0) { return; }
                gridView.BeginDataUpdate();

                MC.CajaMovimientos d = gridView.GetRow(gridView.FocusedRowHandle) as MC.CajaMovimientos;

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (d != null)
                    {
                        MC.CajaMovimientos n = gridView.GetRow(i) as MC.CajaMovimientos;
                        n.BancoID = d.BancoID;
                        n.ModoPago = d.ModoPago;
                    }
                }

                gridView.EndDataUpdate();

            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
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

                MC.CajaMovimientos det = v.GetRow(v.FocusedRowHandle) as MC.CajaMovimientos;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    //SIN PLAN DE CUENTAS
                    if (det.PlanCuentaID <= 0)
                    {
                        errorstring = "Debe seleccionar una cuenta contable para continuar.";
                        e.Valid = false; c = colCuentaID;
                    }

                    //SI EL PLAN LLEVA SUBCUENTA Y NO SE ELIGIO
                    if (det.PlanSubCuentaID == 0 && DebeSeleccionarSubCuenta(det.PlanCuentaID))
                    {
                        errorstring = "Debe seleccionar una sub cuenta contable para continuar.";
                        e.Valid = false; c = colSubCuentaID;
                    }

                    //BANCO SIN TIPO DE PAGO CORRECTO
                    if (e.Valid && det.ModoPago == 0 && det.BancoID > 0)
                    {
                        errorstring = "Si el modo de pago es efectivo NO debe seleccionar un banco.";
                        e.Valid = false; c = colBanco;
                    }
                    if (e.Valid && det.ModoPago > 0 && det.BancoID <= 0)
                    {
                        errorstring = "Si el modo de pago es transferencia / cheque, debe seleccionar un banco.";
                        e.Valid = false; c = colBanco;
                    }


                    //CUENTA BANCO / CAJA NO COINCIDE CON LOS MODOS DE PAGO SELECCIONADOS
                    if ( (det.ModoPago != 0 && det.PlanCuentaID == 3) || (det.ModoPago == 0 && det.PlanCuentaID >= 6 && det.PlanCuentaID <= 8))
                    {
                        errorstring = "La cuenta contable seleccionada y el modo de pago no coinciden."; e.Valid = false; c = colModoPago;
                    }

                    if ( (det.BancoID > 0 && det.PlanCuentaID == 3) || (det.BancoID == 0 && det.PlanCuentaID >= 6 && det.PlanCuentaID <= 8))
                    {
                        errorstring = "La cuenta contable seleccionada y el banco no coinciden."; e.Valid = false; c = colBanco;
                    }                            

                    // IMPORTE CERO
                    if (e.Valid && det.ImporteDebe == 0 && det.ImporteHaber == 0)
                    {
                        errorstring = "Debe completar al menos un campo de importes para continuar.";
                        e.Valid = false; c = colDebe;
                    }

                    // DOS IMPORTES
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

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //AutoPlanCuentas();
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
                if (Movimientos.Count <= 0)
                {
                    btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnUsarCuenta.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnUsarModoPago.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnUsarCuenta.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnUsarModoPago.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }                                
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

        private void btnRetiros_Click(object sender, EventArgs e)
        {
            AgregarRetiros();
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCuentaID && e.Value != null)
            {
                if ((int)e.Value == 3) //CAJA
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colModoPago, 0);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colBanco, 0);
                }
                else if ((int)e.Value == 6) //BANCO PROVINCIA
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colModoPago, 1);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colBanco, 2);
                }
                else if ((int)e.Value == 7) //BANCO NACION
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colModoPago, 1);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colBanco, 102);
                }
                else if ((int)e.Value == 8) //BANCO MACRO
                {
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colModoPago, 1);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colBanco, 1);
                }                
            }
        }

        private void btnUsarCuenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsignaCuentasRegistros();
        }

        private void btnUsarModoPago_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsignaBancoRegistros();
        }
    }
}