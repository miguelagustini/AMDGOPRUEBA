using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.Linq;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_Cuentas : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private ConexionBD cb = new ConexionBD();
        private MC.Cuentas cuentascls = new MC.Cuentas();
        private int idprofesional = 0;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public List<MC.Cuentas> Cuentaslst { get; set; } = new List<MC.Cuentas>();
        private List<MC.Cuentas> Cuentascombo { get; set; } = new List<MC.Cuentas>();
        
        public int IDProfesional
        {
            get { return idprofesional; }
            set
            {
                if (idprofesional != value)
                {
                    idprofesional = value;                                        
                }

                NotifyPropertyChanged();
            }
        }

        public bool Es_Popup { get; set; } = false;
        public bool Editable { get; set; } = false;

        public bool VisualizaCtaCte { get; set; } = false;

        public Frm_Cuentas()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {
            
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;
            cuentascls.SqlConnection = SqlConnection;

            if (Es_Popup) { FormBorderStyle = FormBorderStyle.Sizable; }
            else { FormBorderStyle = FormBorderStyle.None; }
                        
            gridView.OptionsBehavior.Editable = Editable;

            Setcuentascombo();
            AsignaDatos();

            gridView.OptionsView.ShowGroupExpandCollapseButtons = VisualizaCtaCte;
            
        }
        
        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {           
            if (propertyname == "IDProfesional") { CargaCombos(); AsignaDatos(); }
            
        }
             
        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Cuentas>(Cuentaslst);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }

        private void Setcuentascombo()
        {
            try
            {
                Cuentascombo.Clear();
                Cuentascombo = cuentascls.GetRegistros();
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al cargar las listas.\n{e.Message}", 1);
                return;
            }
        }

        private void CargaCombos()
        {
            try
            {                
                cmbCtaprincipal.DataSource = Cuentascombo.Where(w => w.IDProfesional == IDProfesional).ToList();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al cargar las listas.\n{e.Message}", 1);
                return;
            }

        }

        private void MostrarCuentaCorriente()
        {
            try
            {                
                MC.Cuentas _cuenta = gridView.GetRow(gridView.FocusedRowHandle) as MC.Cuentas;

                if (_cuenta != null && _cuenta.IDRegistro > 0)
                {
                    Frm_CuentaCorrienteInfo frm = new Frm_CuentaCorrienteInfo();
                    frm.SqlConnection = SqlConnection;
                    frm.PrestadorCuentaID = _cuenta.IDRegistro;

                    frm.Show();
                }
                else
                {
                    ctrls.MensajeInfo("No se completaron los datos para mostrar información de la cuenta corriente.", 1);
                    return;
                }
               
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar la cuenta corriente.\n{e.Message}", 1);
                return;
            }
        }
        #endregion

        private void Frm_Contactos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_DirecCont_FormClosing(object sender, FormClosingEventArgs e)
        {
            cb.Desconectar();
        }

        private void gridViewDomi_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyCode == Keys.F2)
            {
                gridView.AddNewRow();
                
            }           
            else if (e.KeyData == Keys.F4)
            {
                gridView.ExpandMasterRow(gridView.FocusedRowHandle);
                GridView view = gridView.GetDetailView(gridView.FocusedRowHandle, 0) as GridView;
                if (view != null)
                {
                    view.AddNewRow();
                    view.ShowEditForm();
                }
            }
        }

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

                MC.Cuentas _cuenta = v.GetRow(v.FocusedRowHandle) as MC.Cuentas;

                if (_cuenta != null)
                {
                    string errcode = "";

                    _cuenta.SqlConnection = SqlConnection;

                    if (string.IsNullOrWhiteSpace(_cuenta.Codigo)) { e.Valid = false; c = colCodigo; errcode = "Código no válido"; }

                    if (_cuenta.ExisteRegbycodigo(_cuenta.Codigo) > 0) { e.Valid = false; c = colCodigo; errcode = "Código existente"; }

                    if (!e.Valid) { v.SetColumnError(c, errcode); }
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            e.Allow = VisualizaCtaCte;
        }

        private void btnCuentaCorriente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarCuentaCorriente();            
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (VisualizaCtaCte && gridView.RowCount > 0) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }
        }
    }

}