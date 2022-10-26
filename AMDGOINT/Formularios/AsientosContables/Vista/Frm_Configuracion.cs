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
    public partial class Frm_Configuracion : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();        
        public List<MC.ConfiguracionDet> Configuraciones { get; set; } = new List<MC.ConfiguracionDet>();
                
        private Point LocationSplash = new Point();    
        
        public Frm_Configuracion()
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
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();                
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

                if (cmb == 0 || cmb == 2) //PROFESIONAL
                {
                    string c = "SELECT PC.ID_Registro AS IDRegistro, PC.Codigo AS CodigoCuenta, PF.Nombre as Profesional, PF.Cuit as Cuit," +
                               " CONCAT(PC.Codigo, ' ', PF.Nombre) AS NombreDisplay" +
                               " FROM PROFESIONALES PF" +
                               " LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PF.ID_Iva)" +
                               " WHERE PC.Codigo is not null AND PF.Visible = 1" +
                               " ORDER BY PF.Nombre ASC";

                    cmbPrestadorCuenta.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                if (cmb == 0 || cmb == 3) //PRESTATARIA
                {

                    string c = "SELECT PD.ID_Registro AS IDRegistro, PD.ID_Prestataria, PD.Codigo, PD.Abreviatura, PD.Descripcion," +
                               " CONCAT(PD.Codigo,' ', PD.Abreviatura) AS NombreDisplay" +
                               " FROM PRESTDETALLES PD" +
                               " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                               " WHERE PR.Estado = 1 AND PD.Visible = 1";

                    cmbPrestatariaCuenta.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                if (cmb == 0 || cmb == 4) //TERCERO
                {
                    Empresas.MC.Empresa emp = new Empresas.MC.Empresa(SqlConnection);
                    cmbTercero.DataSource = emp.GetRegistros();
                    
                }

                if (cmb == 0 || cmb == 5) //EMPLEADO
                {
                    Empleados.MC.Empleado empl = new Empleados.MC.Empleado(SqlConnection);
                    cmbEmpleado.DataSource = empl.GetRegistros();
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
                gridControl.DataSource = new BindingList<MC.ConfiguracionDet>(Configuraciones); 
                gridView.EndDataUpdate();                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }

        //SET DATASOURCE SUB CUENTAS
        private void SetSubCuentads(object sndr, object name)
        {
            try
            {
                MC.ConfiguracionDet _rd = gridView.GetRow(gridView.FocusedRowHandle) as MC.ConfiguracionDet;

                if (_rd != null)
                {                    
                    List<CuentasContables.MC.Cuentas> cuentas = reposCmbCuenta.DataSource as List<CuentasContables.MC.Cuentas>;
                    if (cuentas == null || name == null) { return; }
                    
                    string origen = (name.Equals("DebePlanSubCuentaID") ? "D" : "H");                                        
                    
                    List<CuentasContables.MC.SubCuentas> sbc = cuentas.Where(w => w.IDRegistro == (origen == "D" ? _rd.DebePlanCuentaID : _rd.HaberPlanCuentaID))
                                                                       .Select(s => s.SubCuentas.Where(w => w.Estado))
                                                                       .DefaultIfEmpty(new List<CuentasContables.MC.SubCuentas>()).FirstOrDefault().ToList();
                    //List<CuentasContables.MC.SubCuentas> sbc = cuentas.SelectMany(s => s.SubCuentas.Where(w => w.Estado && w.IDEncabezado == (origen == "D" ? _rd.DebePlanCuentaID : _rd.HaberPlanCuentaID))).ToList();
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
        private void IGeneraRegistros()
        {
            try
            {

                if (!ValidacionPreviaEmision())
                {
                    return;
                }

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
                             
        //FIN EMISION
        private void FGeneraRegistros()
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
                DialogResult = DialogResult.Abort;
            }            
            
        }
             
        //VALIDO ANTES DE EMITIR EL COMPROBANTE
        private bool ValidacionPreviaEmision()
        {
            try
            {                                  
                //NO PUEDE HABER DETALLES SIN CUENTA
                if (Configuraciones.Where(w => w.DebePlanCuentaID == 0 && w.HaberPlanCuentaID == 0).Count() > 0)
                {
                    ctrl.MensajeInfo("No se puede guardar un asiento con detalles sin una cuenta asignada.", 1);
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

                foreach (MC.ConfiguracionDet d in Configuraciones)
                {
                    retorno = d.Abm();

                    if (retorno.Count > 0)
                    {
                        string mensajes = "";

                        foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                        {
                            mensajes += $"{i.Trim()}\n";
                        }

                        if (!string.IsNullOrWhiteSpace(mensajes))
                        { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); }
                        return;
                    }

                }                                
                
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
                
                MC.ConfiguracionDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.ConfiguracionDet;
                if (d != null)
                {                    
                    if (d.IDRegistro <= 0) { Configuraciones.Remove(d); }
                    else
                    {
                        //if (d.MovimientoCajaID > 0) { ctrl.MensajeInfo("<b>NO</b> se puede eliminar un movimiento generado en caja.\nDe ser necesario, solo puede anularse.", 1); }
                       //else { ctrl.MensajeInfo("<b>NO</b> se puede eliminar un movimiento guardado.\nDe ser necesario, solo puede anularse.", 1); }
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

                MC.ConfiguracionDet det = v.GetRow(v.FocusedRowHandle) as MC.ConfiguracionDet;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    //SIN PLAN DE CUENTAS DEBE NI HABER
                    if (det.DebePlanCuentaID <= 0 && det.HaberPlanCuentaID <= 0)
                    {
                        errorstring = "Debe seleccionar una cuenta contable para continuar.";
                        e.Valid = false; c = colCuentaIDD;
                    }

                    int[] arrs = new int[4] { det.PrestadorCuentaID, det.PrestatariaCuentaID, det.TerceroID, det.PersonalID };
                    //sin destinatario
                    if (arrs.Where(w => w == 0).Count() == 0)
                    {
                        errorstring = "Debe seleccionar un destinatario para continuar.";
                        e.Valid = false; c = colPrestataria;
                    }
                    //mas de un destinatario
                    if (arrs.Where(w => w > 0).Count() > 1)
                    {
                        errorstring = "No puede seleccionar mas de un destinatario en la misma configuracion.";
                        e.Valid = false; c = colPrestataria;
                    }

                    //no deben elegir pago prestatarias con orden de pago
                    if (det.Area == 1 && det.ComprobanteTipo == "OP")
                    {
                        errorstring = "No puede seleccionar orden de pago con pago a prestatarias.";
                        e.Valid = false; c = colArea;
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


        #endregion

        #region COMBOS

        private void reposCmbSubcuenta_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit n = sender as SearchLookUpEdit;
                SetSubCuentads(sender, n.DataBindings[0].BindingMemberInfo.BindingField);
            }
            catch (Exception)
            {

            }
            
        }

        #endregion
                
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            IGeneraRegistros();                                    
        }

        private void bgwEmiteFactura_DoWork(object sender, DoWorkEventArgs e)
        {
            GeneraComprobante();
        }

        private void bgwEmiteFactura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FGeneraRegistros();
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
                if (Configuraciones.Count <= 0) { btnBorrarRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }
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

    }
}