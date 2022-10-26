using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    public partial class Usr_Planes : UserControl
    {
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();        
        private Controles ctrls = new Controles();

        private List<MC.Plan> detalles = new List<MC.Plan>();
        private List<MC.Plan> codigos = new List<MC.Plan>();
        private MC.Plan plancls = new MC.Plan();

        private bool editable = false;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public List<MC.Plan> Planes
        {
            get { return detalles; }
            set
            {
                detalles = detalles != value ? value : detalles;
                SetBindings();
            }
        }

        public bool Editable
        {
            get { return editable; }
            set { editable = editable != value ? value : editable; SetEdicion(); }
        } 

        public Usr_Planes()
        {
            InitializeComponent();
            SetEdicion();
        }

        private void CargaCombos(short i = 0, object n = null)
        {
            try
            {

                if (i == 0 || i == 1)
                {
                    //AGRUPADOR
                    string c = "SELECT ID_Registro, Codigo, Descripcion FROM PRESTGRPVAL ORDER BY Descripcion ASC";
                    DataTable dt = func.getColecciondatos(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection);
                    cmbAgrupador.DataSource = dt;
                    
                    if (n != null)
                    {
                        SearchLookUpEdit se = n as SearchLookUpEdit;
                        se.Properties.DataSource = dt;
                    }
                }                                

                if (i == 0 || i == 2)
                {
                    codigos.Clear();
                    plancls.SqlConnection = SqlConnection;
                    codigos.AddRange(plancls.GetRegistros());
                }

                if (i == 0 || i == 3)
                {
                    //AGRUPADOR
                    string c = "SELECT IDRegistro, Codigo, Descripcion FROM [AmdgoContable].[dbo].[pc_PLANSUBCUENTAS]" +
                        " WHERE Estado = 1 AND (IDEncabezado = 15 OR IDEncabezado = 24 OR IDEncabezado = 129 OR IDEncabezado = 18)" +
                        " ORDER BY Codigo ASC";
                    DataTable dt = func.getColecciondatos(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection);
                    cmbPlanSubCuentas.DataSource = dt;
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un error al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Plan>(Planes);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;
            }
        }

        private void SetEdicion()
        {
            gridView.OptionsBehavior.Editable = Editable;            
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void Usr_Planes_Load(object sender, EventArgs e)
        {
            CargaCombos();
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView v = gridView;
                GridColumn c = new GridColumn();

                MC.Plan _tmp = v.GetRow(v.FocusedRowHandle) as MC.Plan;
                
                if (_tmp != null)
                {
                    string errcode = "";

                    if (string.IsNullOrEmpty(_tmp.Codigo))
                    { e.Valid = false; c = colCodigo; errcode = "Debe incluir un código"; }
                    else
                    {
                        if (codigos.Where(w => w.IDRegistro != _tmp.IDRegistro && w.Codigo == _tmp.Codigo).Count() > 0)
                        { e.Valid = false; c = colCodigo; errcode = "Éste código ya está registrado."; }
                    }

                    if (_tmp.AgrupadorID <= 0) { e.Valid = false; c = colAgrupador; errcode = "Debe incluir agrupador"; }

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

        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Editable)
            {
                gridView.AddNewRow();
                gridView.ShowEditForm();
            }
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (Editable) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }                
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyCode == Keys.F2)
            {
                gridView.AddNewRow();

            }
        }
    }
}
