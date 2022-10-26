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
using AMDGOINT.Formularios.CuentasContables.MC;

namespace AMDGOINT.Formularios.CuentasContables.Vista
{
    public partial class Frm_PlanContable : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.Cuentas Cuenta { get; set; } = new MC.Cuentas();
        public List<MC.Cuentas> Cuentas{ get; set; } = new List<MC.Cuentas>(); //ASIGNO LA LISTA PRECARGADA, YA QUE SERIA REDUNDANTE CARGARLA DOS VECES.

        private List<Binding> Binding = new List<Binding>();
        public List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
               
        private Point LocationSplash = new Point();        
        
        public Frm_PlanContable()
        {
            InitializeComponent();
                                    
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
        }

        #region Metodos Manuales

        private void HabilitaSelectores()
        {
            txtCodigoLargo.Enabled = Cuenta.IDRegistro == 0;
            txtCodigoCorto.Enabled = Cuenta.IDRegistro == 0;
            txtDescripcion.Enabled = Cuenta.IDRegistro == 0;
            tglCuentaTipo.Enabled = Cuenta.IDRegistro == 0;
            cmbPrincipal.Enabled = Cuenta.IDRegistro == 0;
        }

        private void IniciaConexiones()
        {
            try
            {
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Cuenta.SqlConnection = SqlConnection;                
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
                //CUENTAS CONTABLES
                if (cmb == 0 || cmb == 1) 
                {
                    cmbPrincipal.Properties.DataSource = Cuentas;
                    
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
                txtCodigoLargo.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.CodigoLargo));
                txtCodigoCorto.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.CodigoCorto));
                txtDescripcion.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.Descripcion));
                tglCuentaTipo.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.CuentaTipo));

                tglUsoRcPrestataria.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoReciboPrestataria));
                tglUsoRcPrestador.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoReciboPrestador));
                tglUsoRcEmpleado.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoReciboEmpleado));
                tglUsoRcTercero.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoReciboTercero));

                tglUsoOpPrestador.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoOrdenPagoPrestador));
                tglUsoOpEmpleado.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoOrdenPagoEmpleado));
                tglUsoOpTercero.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.UsoOrdenPagoTercero));

                tglEstado.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.Estado));
                cmbPrincipal.DataBindings.Add("EditValue", Cuenta, nameof(Cuenta.IDCuentaAgrupadora));
                               
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.SubCuentas>(Cuenta.SubCuentas); ;
                gridView.EndDataUpdate();

                HabilitaSelectores();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }              
             
        //VALIDO ANTES DE EMITIR EL COMPROBANTE
        private bool ValidacionPreviaEmision()
        {
            try
            {                
                if (string.IsNullOrEmpty(Cuenta.CodigoLargo))
                {
                    ctrl.MensajeInfo("No se puede dar de alta una cuenta sin el codigo largo.", 1);
                    return false;
                }

                if (string.IsNullOrEmpty(Cuenta.CodigoCorto))
                {
                    ctrl.MensajeInfo("No se puede dar de alta una cuenta sin el codigo corto.", 1);
                    return false;
                }

                if (string.IsNullOrEmpty(Cuenta.Descripcion))
                {
                    ctrl.MensajeInfo("No se puede dar de alta una cuenta sin descripcion.", 1);
                    return false;
                }

                if (Cuenta.IDCuentaAgrupadora <= 0)
                {
                    ctrl.MensajeInfo("No se puede dar de alta una cuenta sin agrupador.", 1);
                    return false;
                }

                //EXISTE CODIGO LARGO
                if (Cuenta.ExisteByField("CodigoLargo", Cuenta.CodigoLargo))
                {
                    ctrl.MensajeInfo("Ya existe una cuenta con éste codigo largo.", 1);
                    txtCodigoLargo.Focus();
                    return false;
                }

                //EXISTE CODIGO CORTO
                if (Cuenta.ExisteByField("CodigoCorto", Cuenta.CodigoCorto))
                {
                    ctrl.MensajeInfo("Ya existe una cuenta con éste puntero.", 1);
                    txtCodigoCorto.Focus();
                    return false;
                }

                //EXISTE CODIGO SUBCUENTA
                foreach (SubCuentas c in Cuenta.SubCuentas)
                {
                    c.SqlConnection = SqlConnection;
                    if (c.ExisteCodigo())
                    {
                        ctrl.MensajeInfo($"El código {c.Codigo} ya se encuentra registrado.", 1);                        
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
        private void GuardaRegistro()
        {
            try
            {
                if (!ValidacionPreviaEmision()) { return; }

                if (ctrl.MensajePregunta("¿Está seguro de aplicar éstos cambios?") != DialogResult.Yes) { return; }

                Dictionary<short, string> retorno = new Dictionary<short, string>();

                retorno = Cuenta.Abm();

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

                Close();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir el recibo.\n{e.Message}", 1);                
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
            cnb.Desconectar();            
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
                
        #region GRILLA SUBCUENTAS

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            try
            {
                (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;                
                MC.SubCuentas _tmp = gridView.GetRow(gridView.FocusedRowHandle) as MC.SubCuentas;

                if (_tmp != null && _tmp.IDRegistro > 0)
                { colCodigo.OptionsColumn.ReadOnly = true; colCodigo.OptionsColumn.AllowEdit = false; }
                else { colCodigo.OptionsColumn.ReadOnly = false; colCodigo.OptionsColumn.AllowEdit = true; }

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

                MC.SubCuentas det = v.GetRow(v.FocusedRowHandle) as MC.SubCuentas;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    // IMPORTE CANCELADO
                    if (string.IsNullOrEmpty(det.Codigo))
                    { e.Valid = false; c = colCodigo; }
                    else if (string.IsNullOrEmpty(det.Descripcion))
                    { e.Valid = false; c = colDescripcion; }                                                                                
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
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            gridView.UpdateTotalSummary();
        }
                        
        #endregion
     
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GuardaRegistro();
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}