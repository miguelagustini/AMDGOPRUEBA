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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;

namespace AMDGOINT.Formularios.OrdenesPago.Vista
{
    public partial class Frm_OrdenPago : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.OrdenPagoEnc Orden { get; set; } = new MC.OrdenPagoEnc();       
        
        private List<Binding> Binding = new List<Binding>();
        public List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        
        private Point LocationSplash = new Point();
        private bool ComprobanteGenerado = true;        
        private int IDSubCuentaDetalle = 0;
        private bool CargaInicialCmb = true;
        private bool PlanAutomatico { get; set; } = false;

        public Form FormularioPadre { get; set; } = new Form();

        public Frm_OrdenPago()
        {
            InitializeComponent();
                        
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            reposFechas.NullDate = DateTime.MinValue;
            reposFechas.NullText = string.Empty;
            tglImpresion.EditValue = Properties.Settings.Default.Ord_Impresion;
        }

        #region Metodos Manuales
                
        private void HabilitaSelectores()
        {
            cmbProfesional.Enabled = Orden.IDEmpresa == 0 && Orden.IDEmpleado == 0 ? true : false;
            cmbEmpresa.Enabled = Orden.IDPrestadorCuenta == 0 && Orden.IDEmpleado == 0 ? true : false;
            cmbPersonal.Enabled = Orden.IDPrestadorCuenta == 0 && Orden.IDEmpresa == 0 ? true : false;          
        }
        
        private void IniciaConexiones()
        {
            try
            {
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Orden.SqlConnection = SqlConnection;
                
            }
            catch (Exception)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al inciar las conexiones.", 1);
                return;
            }
        }

        private void CargaCombos(short cmb = 0, byte planesSeleccionables = 0, object sndr = null)
        {
            try
            {
                //PROFESIONAL
                if (cmb == 0 || cmb == 1) 
                {
                    string c = "SELECT PC.ID_Registro AS IDCuenta, PC.Codigo AS CodigoCuenta, PF.Nombre as Profesional, PF.Cuit as Cuit, CONCAT(PC.Codigo, ' ', PF.Nombre) AS ProfesionalCompleto" +
                               " FROM PROFESIONALES PF" +
                               " LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +                               
                               " WHERE PC.Codigo is not null AND PF.Estado = 1" + 
                               " ORDER BY PF.Nombre ASC";

                    DataTable dt = func.getColecciondatos(c, SqlConnection);

                    cmbProfesional.Properties.DataSource = dt;                                        
                }

                //TERCERO
                if (cmb == 0 || cmb == 3) 
                {
                    string c = "SELECT IDRegistro, Nombre, Cuit, Descripcion, PlanSubCuentaID FROM [AmdgoContable].[dbo].[EMPRESAS]";
                    cmbEmpresa.Properties.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                //PLAN DE CUENTAS
                if (cmb == 4) 
                {
                    //planesSeleccionables
                    CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                    List<CuentasContables.MC.Cuentas> lst = ctas.GetRegistros().Where(w => w.Estado && w.Seleccionable).ToList();
                                      
                    //PLANES HABILITADOS RECIBOS PARA PRESTADORES
                    if (planesSeleccionables == 2)
                    {
                        reposCmbCuenta.DataSource = lst.Where(w => w.UsoOrdenPagoPrestador).ToList();

                        if (sndr != null)
                        {
                            SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                            srch.Properties.DataSource = lst.Where(w => w.UsoOrdenPagoPrestador).ToList();
                        }
                    }
                    //PLANES HABILITADOS RECIBOS PARA TERCEROS
                    else if (planesSeleccionables == 3)
                    {
                        reposCmbCuenta.DataSource = lst.Where(w => w.UsoOrdenPagoTercero).ToList();
                        if (sndr != null)
                        {
                            SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                            srch.Properties.DataSource = lst.Where(w => w.UsoOrdenPagoTercero).ToList();
                        }
                    }
                    //PLANES HABILITADOS RECIBOS PARA EMPLEADOS
                    else if (planesSeleccionables == 4)
                    {
                        reposCmbCuenta.DataSource = lst.Where(w => w.UsoOrdenPagoEmpleado).ToList();
                        if (sndr != null)
                        {
                            SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                            srch.Properties.DataSource = lst.Where(w => w.UsoOrdenPagoEmpleado).ToList();
                        }                        
                    }
                    if (CargaInicialCmb)
                    {
                        List<CuentasContables.MC.SubCuentas> sbc = lst.SelectMany(s => s.SubCuentas).ToList();
                        reposCmbSubcuenta.DataSource = sbc;
                    }
                    
                }

                //EMPLEADOS
                if (cmb == 0 || cmb == 5) 
                {
                    Empleados.MC.Empleado empl = new Empleados.MC.Empleado(SqlConnection);
                    cmbPersonal.Properties.DataSource = empl.GetRegistros();
                }

                //BANCOS
                if (cmb == 0 || cmb == 6) 
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
                cmbProfesional.DataBindings.Add("EditValue", Orden, nameof(Orden.IDPrestadorCuenta));                
                cmbEmpresa.DataBindings.Add("EditValue", Orden, nameof(Orden.IDEmpresa));
                cmbPersonal.DataBindings.Add("EditValue", Orden, nameof(Orden.IDEmpleado));                                                               
                memObservaciones.DataBindings.Add("EditValue", Orden, nameof(Orden.Observacion));

                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.OrdenPagoDet>(Orden.Detalles); ;
                gridView.EndDataUpdate();
                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }

        //CAMBIO LOS DATOS DEL PROFESIONAL SEGUN SELECCION
        private void SetProfesionaldata()
        {
            try
            {
                int _id = 0;
                
                IDSubCuentaDetalle = 0;
                if (cmbProfesional.EditValue != null && int.TryParse(cmbProfesional.EditValue.ToString(), out _id))
                {
                    DataTable dt = cmbProfesional.Properties.DataSource as DataTable;

                    DataRow r = dt.Select("IDCuenta = " + _id).FirstOrDefault();
                    if (r != null)
                    {                  
                        
                        Orden.ReceptorCuit = Convert.ToInt64(r["Cuit"]);
                        Orden.ReceptorRazonSocial = r["Profesional"].ToString();
                    }
                    
                }
                else
                {
                    cmbProfesional.EditValue = Orden.IDPrestadorCuenta;
                }

                if (_id > 0) { CargaCombos(4, 2); CargaInicialCmb = false; }
                ctrl.RefrescarValorcontrols(Binding);                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el profesional.\n{e.Message}", 1);
                return;
            }
        }

        //CAMBIO LOS DATOS DEL PROFESIONAL SEGUN SELECCION
        private void SetTercerodata()
        {
            try
            {
                int _id = 0;

                IDSubCuentaDetalle = 0;

                if (cmbEmpresa.EditValue != null && int.TryParse(cmbEmpresa.EditValue.ToString(), out _id))
                {
                    DataTable dt = cmbEmpresa.Properties.DataSource as DataTable;

                    DataRow r = dt.Select("IDRegistro = " + _id).FirstOrDefault();
                    if (r != null)
                    {
                       // Orden.ReceptorCuentaCodigo = "";
                        Orden.ReceptorCuit = Convert.ToInt64(r["Cuit"]);
                        Orden.ReceptorRazonSocial = r["Nombre"].ToString();
                        IDSubCuentaDetalle = Convert.ToInt32(r["PlanSubCuentaID"]);
                    }
                  
                }
                else
                {
                    cmbEmpresa.EditValue = Orden.IDEmpresa;
                }

                if (_id > 0) { CargaCombos(4, 3); CargaInicialCmb = false; }
                ctrl.RefrescarValorcontrols(Binding);
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar la empresa.\n{e.Message}", 1);
                return;
            }
        }

        //CAMBIO LOS DATOS DEL PROFESIONAL SEGUN SELECCION
        private void SetEmpleadodata()
        {
            try
            {
                int _id = 0;
                                                
                IDSubCuentaDetalle = 0;
                if (cmbPersonal.EditValue != null && int.TryParse(cmbPersonal.EditValue.ToString(), out _id))
                {
                    List<Empleados.MC.Empleado> dt = cmbPersonal.Properties.DataSource as List<Empleados.MC.Empleado>;

                    Empleados.MC.Empleado r = dt.Where(w => w.IDRegistro == _id).FirstOrDefault();
                    if (r != null)
                    {                        
                        Orden.ReceptorCuit = r.DocumentoNumero;
                        Orden.ReceptorRazonSocial = r.Nombre;
                        IDSubCuentaDetalle = r.IDPlanSubCuenta;
                    }                    
                }
                else
                {
                    cmbPersonal.EditValue = Orden.IDEmpleado;
                }

                if (_id > 0) { CargaCombos(4, 4); CargaInicialCmb = false; }
                ctrl.RefrescarValorcontrols(Binding);

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el empleado.\n{e.Message}", 1);
                return;
            }
        }
        
        //SET DATASOURCE SUB CUENTAS
        private void SetSubCuentads(object sndr)
        {
            try
            {
                MC.OrdenPagoDet _rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;

                if (_rd != null)
                {                    
                    List<CuentasContables.MC.Cuentas> cuentas = reposCmbCuenta.DataSource as List<CuentasContables.MC.Cuentas>;
                    if (cuentas == null) { return; }
                    List<CuentasContables.MC.SubCuentas> sbc = cuentas.Where(w => w.IDRegistro == _rd.PlanCuentaID).Select(s => s.SubCuentas).FirstOrDefault();

                    reposCmbSubcuenta.DataSource = null;

                    if (sbc != null)
                    {                        
                        reposCmbSubcuenta.DataSource = sbc;

                        if (sndr != null)
                        {
                            SearchLookUpEdit cmb = sndr as SearchLookUpEdit;
                            
                            cmb.Properties.DataSource = null;
                            cmb.Properties.DataSource = sbc;
                            
                        }
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

        //TOTALIZO LOS DETALLES SELECCIONADOS EN EL ENCABEZADO
        private void CalculaTotalesEncabezado()
        {
            try
            {   
                Orden.ImporteTotal = Orden.Detalles.Where(w => !w._BorraRegistro).Sum(s => s.Importe);                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"No se pudo calcular el total de la factura.\n{e.Message}", 1);
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

        //EMITE FACTURA
        private void EmitirComprobante()
        {
            try
            {
                if (!ValidacionPreviaEmision())
                {
                    ComprobanteGenerado = false;
                    return;
                }
                else
                {
                    if (ctrl.MensajePregunta("¿Está seguro de generar éste comprobante?") != DialogResult.Yes) { return; }
                    GeneraComprobante();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir la factura.\n{e.Message}", 1);
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

                if (ComprobanteGenerado)
                {
                    if ((bool)tglImpresion.EditValue) { ImpresionComprobante(); }
                    Close();
                }
                else
                {
                    ComprobanteGenerado = true;
                }
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
                if (Orden.IDPrestadorCuenta <= 0 && Orden.IDEmpresa <= 0 && Orden.IDEmpleado <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin completar el receptor.", 1);
                    return false;
                }
                              
                //TOTALES
                if (Orden.ImporteTotal == 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante con importe total igual a cero ($ 0).", 1);
                    return false;
                }

                if (Orden.Detalles.Where(w => !w._BorraRegistro).Count() <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin detalles.", 1);
                    return false;
                }
                                               
                //NO PERMITO SELECCIONAR PROFESIONAL Y PRESTADORA AL MISMO TIEMPO
                if (Orden.IDEmpresa > 0 && Orden.IDPrestadorCuenta > 0 && Orden.IDEmpleado > 0)
                {
                    ctrl.MensajeInfo("Solo se pueden generar comprobantes a prestador, empleado o tercero, no todos al mismo tiempo.", 1);
                    return false;
                }
              
                //QUE NO BORRE TODOS LOS DETALLES
                if (Orden.Detalles.Where(w => w._BorraRegistro).Count() > 0 && Orden.Detalles.Where(w => !w._BorraRegistro).Count() <= 0)
                {
                    ctrl.MensajeInfo("No se puede guardar un recibo sin sus detalles.\nSi pretende borrar todos los detalles, debe anular la orden.", 1);
                    return false;
                }

                //NO PUEDE HABER DETALLES SIN CUENTA
                if (Orden.Detalles.Where(w => w.PlanCuentaID == 0).Count() > 0)
                {
                    ctrl.MensajeInfo("No se puede guardar un recibo con detalles sin una cuenta asignada.", 1);
                    return false;
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

                if (!RealizaAsientoContable()) { ComprobanteGenerado = false;  return; }

                retorno = Orden.Abm();

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
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir la orden.\n{e.Message}", 1);
                ComprobanteGenerado = false;
                return;
            }
        }

        private bool RealizaAsientoContable()
        {
            try
            {
                bool retorno = false;

                //CREO ASIENTO CONTABLE POR CADA DETALLE
                //Orden.Detalles.ForEach(f => f.GeneraAsientos());
                Orden.GeneraAsientos();

                AsientosContables.Vista.Frm_MuestraAsiento frm = new AsientosContables.Vista.Frm_MuestraAsiento();
                frm.SqlConnection = SqlConnection;
                //frm.Pases.AddRange(Orden.Detalles.SelectMany(s => s.AsientosContables));
                frm.Pases.AddRange(Orden.AsientosContables);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //Orden.Detalles.FirstOrDefault().AsientosContables.AddRange(frm.Pases.Where(w => w._AjusteManualOrigenAutomaticos));
                    Orden.AsientosContables.AddRange(frm.Pases.Where(w => w._AjusteManualOrigenAutomaticos));
                    retorno = true;
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento contable.\n{e.Message}", 1);                
                return false;
            }
        }

        //PREPARO COMPROBANTE FACTURA
        private void ImpresionComprobante()
        {
            try
            {

                MC.Impresion Impresion = new MC.Impresion();
                List<MC.OrdenPagoEnc> ListaPrint = new List<MC.OrdenPagoEnc>();

                ListaPrint.Add(Orden);
                
                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }                                                               
                                
                Impresion.Ordenes = ListaPrint;

                Impresion.Imprimir(parametros.Cantidad, parametros.IncluirCuentas); 
                
                parametros.Dispose();

            }
            catch (Exception)
            {


            }
        }

        private void AgregarRetiros()
        {
            try
            {
                                
                Retiros.Vista.Frm_RetirosSelector parametros = new Retiros.Vista.Frm_RetirosSelector();
                parametros.SqlConnection = SqlConnection;
                //parametros.IDTercero = Orden.IDEmpresa;
                //parametros.IDPrestador = Orden.IDPrestadorCuenta;

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
                        //if (Orden.Detalles.Select(s => new { s.RetiroID, s.Descripcion }).Contains(v.ID && v.IDCuenta)) { continue; }

                        Orden.Detalles.Add(new MC.OrdenPagoDet
                        {
                            RetiroID = v.ID,
                            Descripcion = "Retiro Nro. " + v.ID.ToString("0000") + " " + (v.IDCuenta == 546 ? "AMDGO" : v.IDCuenta == 547 ? "MGM" : ""),
                            ModoPago = 1,
                            BancoID = 1,
                            Importe = v.Total

                        });
                    }
                }

                foreach (Retiros.MC.Retiros re in parametros.Detalles.Where(w => w.Seleccionado))
                {
                    
                }                
               
                gridView.EndDataUpdate();

                parametros.Dispose();
                CalculaTotalesEncabezado();
                SetDescripcionesCuenta();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al mostrar la lista.\n{e.Message}", 1);
                return;
            }
        }

        //MARCA REGISTRO BORRAR
        private void MarcaRegistroBorrar()
        {
            try
            {                                
                gridView.BeginDataUpdate();
                
                MC.OrdenPagoDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;
                if (d != null)
                {
                    string palabra = d._BorraRegistro ? "Incluir" : "Excluir";
                    if (ctrl.MensajePregunta($"¿{palabra} el registro seleccionado?") == DialogResult.Yes)
                    { d._BorraRegistro = !d._BorraRegistro; }
                }
                
                gridView.EndDataUpdate();

                CalculaTotalesEncabezado();
                
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }
              
        private void PreviaCierreForm()
        {
            try
            {                            
                cnb.Desconectar();
                Properties.Settings.Default.Ord_Impresion = (bool)tglImpresion.EditValue;
                Properties.Settings.Default.Save();
            }
            catch (Exception e)
            {

            }
        }

        //ASIGNO NOMBRE Y CODIGOS CUENTA COMTABLE COMPLETO
        private void SetDescripcionesCuenta(object cmb = null)
        {
            try
            {
                MC.OrdenPagoDet rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;
                if (rd == null) { return; }

                if (cmb != null)
                {
                    SearchLookUpEdit cm = cmb as SearchLookUpEdit;

                    if (cm != null)
                    {
                        int _id = 0;

                        if (cm.EditValue != null && int.TryParse(cm.EditValue.ToString(), out _id))
                        {
                            List<CuentasContables.MC.Cuentas> dt = cm.Properties.DataSource as List<CuentasContables.MC.Cuentas>;

                            CuentasContables.MC.Cuentas r = dt.Where(w => w.IDRegistro == _id).First();
                            if (r != null)
                            {
                                rd.PlanCuentaCodigoCorto = r.CodigoCorto;
                                rd.PlanCuentaNombre = r.Descripcion;

                            }

                        }
                    }
                }
                else
                {
                    RepositoryItemSearchLookUpEdit cm = reposCmbCuenta as RepositoryItemSearchLookUpEdit;

                    if (cm != null)
                    {                        
                        if (rd.PlanCuentaID > 0)
                        {
                            List<CuentasContables.MC.Cuentas> dt = cm.DataSource as List<CuentasContables.MC.Cuentas>;
                            CuentasContables.MC.Cuentas r = dt.Where(w => w.IDRegistro == rd.PlanCuentaID).First();
                            if (r != null)
                            {
                                rd.PlanCuentaCodigoCorto = r.CodigoCorto;
                                rd.PlanCuentaNombre = r.Descripcion;

                            }
                        }
                    }
                }

                
            }
            catch (Exception)
            {
                return;
            }
        }

        //ASIGNO NOMBRE Y CODIGOS SUBCUENTA COMTABLE COMPLETO
        private void SetDescripcionesSubCuenta(object cmb = null)
        {
            try
            {
                MC.OrdenPagoDet rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;
                if (rd == null) { return; }

                if (cmb != null)
                {
                    SearchLookUpEdit cm = cmb as SearchLookUpEdit;

                    if (cm != null)
                    {
                        int _id = 0;

                        if (cm.EditValue != null && int.TryParse(cm.EditValue.ToString(), out _id))
                        {
                            List<CuentasContables.MC.SubCuentas> dt = cm.Properties.DataSource as List<CuentasContables.MC.SubCuentas>;

                            CuentasContables.MC.SubCuentas r = dt.Where(w => w.IDRegistro == _id).First();
                            if (r != null)
                            {
                                rd.PlanSubCuentaCodigoCorto = r.Codigo;
                                rd.PlanSubCuentaNombre = r.Descripcion;

                            }

                        }
                    }
                }
                else
                {
                    RepositoryItemSearchLookUpEdit cm = reposCmbSubcuenta as RepositoryItemSearchLookUpEdit;

                    if (cm != null)
                    {
                        if (rd.PlanSubCuentaID > 0)
                        {
                            List<CuentasContables.MC.SubCuentas> dt = cm.DataSource as List<CuentasContables.MC.SubCuentas>;
                            CuentasContables.MC.SubCuentas r = dt.Where(w => w.IDRegistro == rd.PlanSubCuentaID).First();
                            if (r != null)
                            {
                                rd.PlanSubCuentaCodigoCorto = r.Codigo;
                                rd.PlanSubCuentaNombre = r.Descripcion;

                            }
                        }
                    }
                }


            }
            catch (Exception)
            {
                return;
            }
        }
        
        //ASIGNO PLAN DE CUENTAS AUTOMATICO
        private void AutoPlanCuentas()
        {
            try
            {
                PlanAutomatico = true;
                if (cmbPersonal.EditValue != null || cmbEmpresa.EditValue != null || cmbProfesional.EditValue != null)
                {
                    MC.OrdenPagoDet rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;
                    rd.BancoID = 1;

                    if (rd != null)
                    {
                        List<CuentasContables.MC.Cuentas> ctas = reposCmbCuenta.DataSource as List<CuentasContables.MC.Cuentas>;

                        if (ctas != null && ctas.Count > 0)
                        {
                            rd.PlanCuentaID = ctas.SelectMany(s => s.SubCuentas).Where(w => w.IDRegistro == IDSubCuentaDetalle).Select(s => s.IDEncabezado).FirstOrDefault();
                            SetSubCuentads(null);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el plan de cuentas automaticamente.\n{e.Message}", 1);
                PlanAutomatico = false;
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

                MC.OrdenPagoDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (d != null)
                    {
                        MC.OrdenPagoDet n = gridView.GetRow(i) as MC.OrdenPagoDet;
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

                MC.OrdenPagoDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (d != null)
                    {
                        MC.OrdenPagoDet n = gridView.GetRow(i) as MC.OrdenPagoDet;
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

        private void Frm_ComprobanteElectronico_FormClosing(object sender, FormClosingEventArgs e)
        {
            PreviaCierreForm();
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

                MC.OrdenPagoDet det = v.GetRow(v.FocusedRowHandle) as MC.OrdenPagoDet;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    // IMPORTE CANCELADO
                    if (det.Importe == 0)
                    { e.Valid = false; c = colImporte; }

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
                    if ((det.ModoPago != 0 && det.PlanCuentaID == 3) || (det.ModoPago == 0 && det.PlanCuentaID >= 6 && det.PlanCuentaID <= 8))
                    {
                        errorstring = "La cuenta contable seleccionada y el modo de pago no coinciden."; e.Valid = false; c = colModoPago;
                    }

                    if ((det.BancoID > 0 && det.PlanCuentaID == 3) || (det.BancoID == 0 && det.PlanCuentaID >= 6 && det.PlanCuentaID <= 8))
                    {
                        errorstring = "La cuenta contable seleccionada y el banco no coinciden."; e.Valid = false; c = colBanco;
                    }

                    if (!e.Valid) { v.SetColumnError(c, errorstring); }
                }

                CalculaTotalesEncabezado();
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
            AutoPlanCuentas();
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

        private void cmbProfesional_EditValueChanged(object sender, EventArgs e)
        {
            SetProfesionaldata();
        }
                    
        private void cmbEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            SetTercerodata();
        }

        private void cmbPersonal_EditValueChanged(object sender, EventArgs e)
        {
            SetEmpleadodata();
        }

        private void cmb_Validated(object sender, EventArgs e)
        {
            try
            {
                HabilitaSelectores();
            }
            catch (Exception n)
            {
                ctrl.MensajeInfo($"No se pudo validar la lista.\n{n.Message}", 1);
                return;
            }
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                SearchLookUpEdit cmb = sender as SearchLookUpEdit;

                if (e.KeyData == Keys.Delete) { cmb.EditValue = 0; }
            }
            catch (Exception n)
            {
                ctrl.MensajeInfo($"No se pudo limpiar la lista.\n{n.Message}", 1);
                return;
            }

        }

        private void cmb_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                SearchLookUpEdit c = (SearchLookUpEdit)sender;
                c.EditValue = 0;                
            }
        }

        private void reposCmbCuenta_BeforePopup(object sender, EventArgs e)
        {            
            if (cmbProfesional.EditValue != null && (int)cmbProfesional.EditValue > 0) { CargaCombos(4, 2, sender); }
            if (cmbEmpresa.EditValue != null && (short)cmbEmpresa.EditValue > 0) { CargaCombos(4, 3, sender); }
            if (cmbPersonal.EditValue != null && (short)cmbPersonal.EditValue > 0) { CargaCombos(4, 4, sender); }
        }

        private void reposCmbCuenta_EditValueChanged(object sender, EventArgs e)
        {
            MC.OrdenPagoDet rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;

            if (!PlanAutomatico)
            {
                if (rd != null)
                {
                    rd.PlanSubCuentaID = 0;
                }                                
            }

            PlanAutomatico = false;
            SetDescripcionesCuenta(sender);
        }

        private void reposCmbSubcuenta_BeforePopup(object sender, EventArgs e)
        {
            if (!PlanAutomatico) { SetSubCuentads(sender); }
        }

        private void reposCmbSubcuenta_EditValueChanged(object sender, EventArgs e)
        {
            SetDescripcionesSubCuenta(sender);
        }
        
        #endregion

        private void btnAgregaComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgregarRetiros();
        }
               
        private void memObservaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4) { e.SuppressKeyPress = true; }
        }

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
                //SI NO HAY DETALLES
                if (Orden.Detalles.Count <= 0)
                {
                    btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnBanco.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnAsignarCuentaTodos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnBanco.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnAsignarCuentaTodos.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }

                MC.OrdenPagoDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.OrdenPagoDet;
                if (d != null)
                {
                    string palabra = d._BorraRegistro ? "Incluir Registro" : "Excluir Registro";
                    btnBorrarRegistro.Caption = palabra;
                }
            }
            catch (Exception)
            {
                
            }           
        }
        
        private void gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;
                if (view.FocusedColumn.FieldName == "PlanCuentaID")
                {
                    SearchLookUpEdit se = (SearchLookUpEdit)view.ActiveEditor;
                    SetSubCuentads(se);                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsignaCuentasRegistros();
        }

        private void btnBanco_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsignaBancoRegistros();
        }

        private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
          
        }
    }
}