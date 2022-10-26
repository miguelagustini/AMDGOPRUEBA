using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Drawing;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Frm_MuestraAsiento : XtraForm
    {
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private OverlayPanel OverlayPanel = new OverlayPanel();
        public List<MC.AsientosDet> Pases { get; set; } = new List<MC.AsientosDet>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public bool OrigenOrdenPago { get; set; } = false;

        public Frm_MuestraAsiento()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {
            try
            {
                ctrl.PreferencesGrid(this, gridView, "R");
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                IbusqDetalles();

            }
            catch (Exception)
            {

            }
        }

        private void CargaCombos(short cmb = 0, byte planesSeleccionables = 0, object sndr = null)
        {
            try
            {
                if (cmb == 0 || cmb == 1) //PLAN DE CUENTAS
                {
                    //planesSeleccionables
                    CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                    List<CuentasContables.MC.Cuentas> lst = ctas.GetRegistros().Where(w => w.CuentaTipo == 1).ToList();

                    //PLANES HABILITADOS RECIBOS PARA PRESTATARIAS
                    cmbPlanCuenta.DataSource = lst;

                    if (sndr != null)
                    {
                        SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                        srch.Properties.DataSource = lst;
                    }
                }

                if (cmb == 0 || cmb == 2) //SUBCUENTAS
                {
                    //planesSeleccionables
                    CuentasContables.MC.SubCuentas ctas = new CuentasContables.MC.SubCuentas(SqlConnection);
                    List<CuentasContables.MC.SubCuentas> lst = ctas.GetRegistros();

                    //PLANES HABILITADOS RECIBOS PARA PRESTATARIAS
                    cmbPlanSubCuenta.DataSource = lst;

                    if (sndr != null)
                    {
                        SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                        srch.Properties.DataSource = lst;
                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar las listas.\n{e.Message}", 1);
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
                    List<CuentasContables.MC.Cuentas> cuentas = cmbPlanCuenta.DataSource as List<CuentasContables.MC.Cuentas>;
                    if (cuentas == null) { return; }
                    List<CuentasContables.MC.SubCuentas> sbc = cuentas.Where(w => w.IDRegistro == _rd.PlanCuentaID).Select(s => s.SubCuentas).DefaultIfEmpty(new List<CuentasContables.MC.SubCuentas>()).FirstOrDefault().ToList();// FirstOrDefault();

                    cmbPlanSubCuenta.DataSource = null;
                    cmbPlanSubCuenta.DataSource = sbc;

                    if (sndr != null)
                    {
                        SearchLookUpEdit cmb = sndr as SearchLookUpEdit;
                        cmb.Properties.DataSource = null;
                        cmb.Properties.DataSource = sbc;
                    }

                   // _rd.PlanSubCuentaID = IDSubCuentaDetalle > 0 ? IDSubCuentaDetalle : _rd.PlanSubCuentaID;

                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el ds a la subcuenta.\n{e.Message}", 1);
                return;
            }
        }

        private void IbusqDetalles()
        {
            try
            {
                if (bgwRegistros.IsBusy) { return; }
                OverlayPanel.Mostrar(this);
                gridView.BeginDataUpdate();
                bgwRegistros.RunWorkerAsync();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                return;
            }
        }

        private void BusqDetalles()
        {
            try
            {
                CargaCombos();
                gridControl.DataSource = new BindingList<MC.AsientosDet>(Pases); ;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        private void FbusqDetalles()
        {
            try
            {
                gridView.EndDataUpdate();
                OverlayPanel.Ocultar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }

        }

        //MARCA SELECCION DE FILAS EN ORIGEN DATOS
        private void MarcaSeleccionado(bool esgrupo)
        {
            try
            {
                gridView.BeginDataUpdate();

                if (esgrupo)
                {
                }
                else
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        Retiros.MC.Retiros d = gridView.GetRow(i) as Retiros.MC.Retiros;
                        if (d == null) { return; }
                        d.Seleccionado = gridView.IsRowSelected(i);
                    }
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

        private void BorrarAsiento()
        {
            try
            {
                MC.AsientosDet _tmp = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;

                if (_tmp != null && ctrl.MensajePregunta("¿Está segura quitar éste movimiento?\nSi lo hace, deberá asentarlo manualmente luego.") == System.Windows.Forms.DialogResult.Yes)
                {
                    gridView.BeginDataUpdate();
                    gridView.DeleteRow(gridView.FocusedRowHandle);
                    gridView.EndDataUpdate();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al quitar el asiento.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }

        }

        private void InvertirAsiento()
        {
            try
            {
                MC.AsientosDet _tmp = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;

                if (_tmp != null)
                {
                    gridView.BeginDataUpdate();

                    decimal Olddebe = _tmp.ImporteDebe;
                    decimal Oldhaber = _tmp.ImporteHaber;

                    _tmp.ImporteDebe = Oldhaber;
                    _tmp.ImporteHaber = Olddebe;


                    gridView.EndDataUpdate();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al quitar el asiento.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }

        }

        private void AgregarAsiento()
        {
            try
            {
                gridView.AddNewRow();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al quitar el asiento.\n{e.Message}", 1);
                //gridView.EndDataUpdate();
                return;
            }

        }

        //VALIOD SI EL PLAN DE CUENTAS LLEVA SUBCUENTA, NO PERMITO GUARDAR
        private bool DebeSeleccionarSubCuenta(int plancuentaidsel)
        {
            try
            {
                bool retorno = false;

                List<CuentasContables.MC.Cuentas> cuentas = cmbPlanCuenta.DataSource as List<CuentasContables.MC.Cuentas>;

                if (cuentas == null) { retorno = true; }
                if (cuentas.Where(w => w.IDRegistro == plancuentaidsel).SelectMany(s => s.SubCuentas).ToList().Count() > 0) { retorno = true; }

                return retorno;

            }
            catch (Exception)
            {
                return false;
            }


        }

        private bool Validaciones()
        {
            try
            {
                bool retorno = true;

                //recorro la grilla
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    //creo el registro
                    MC.AsientosDet _det = gridView.GetRow(i) as MC.AsientosDet;
                    if(_det == null) { continue; }

                    //obtengo la lista de cmb cuentas
                    List<CuentasContables.MC.Cuentas> cuentas = cmbPlanCuenta.DataSource as List<CuentasContables.MC.Cuentas>;

                    if (cuentas == null) { continue; }
                    else
                    {
                        if ( cuentas.Where(w => w.IDRegistro == _det.PlanCuentaID).SelectMany(s => s.SubCuentas).ToList().Count() > 0
                            && _det.PlanSubCuentaID <= 0) { retorno = false; }
                    }
                    
                }

                return retorno;
    
            }
            catch (Exception)
            {
                return true;
            }
        }

        #endregion

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            BusqDetalles();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FbusqDetalles();
        }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Frm_RetirosSelector_Load(object sender, EventArgs e)
        {

        }

        private void Frm_RetirosSelector_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_RetirosSelector_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ctrl.PreferencesGrid(this, gridView, "S");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!Validaciones())
            {
                ctrl.MensajeInfo("No debe hacer Cuentas contables con subcuentas sin seleccionar.", 1);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void btnQuitarAsiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrarAsiento();
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            gridView.Focus();
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void btnInvertirImporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InvertirAsiento();
        }

        private void btnAgregarAsiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgregarAsiento();
        }

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                MC.AsientosDet _tmp = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;
                _tmp._AjusteManualOrigenAutomaticos = true;
            }
            catch (Exception)
            {

            }
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
                        e.Valid = false; c = colCuenta;
                    }

                    //SI EL PLAN LLEVA SUBCUENTA Y NO SE ELIGIO
                    if (det.PlanSubCuentaID == 0 && DebeSeleccionarSubCuenta(det.PlanCuentaID))
                    {
                        errorstring = "Debe seleccionar una sub cuenta contable para continuar.";
                        e.Valid = false; c = colSubCuenta;
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

        private void gridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == colDebe || e.Column == colHaber)
                {                  
                    e.DefaultDraw();

                    if (e.Column == colHaber && Pases.Sum(s => s.ImporteDebe) > Pases.Sum(s => s.ImporteHaber))
                    {
                        e.Cache.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128), 5), e.Bounds);

                    }
                    else if (e.Column == colDebe && Pases.Sum(s => s.ImporteDebe) < Pases.Sum(s => s.ImporteHaber))
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

        private void cmbPlanSubCuenta_BeforePopup(object sender, EventArgs e)
        {
            SetSubCuentads(sender);
        }
    }
}
