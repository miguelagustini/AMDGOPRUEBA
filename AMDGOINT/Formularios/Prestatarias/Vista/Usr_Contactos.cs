using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    public partial class Usr_Contactos : UserControl
    {
        private Controles ctrls = new Controles();        
        private List<MC.AreaTrabajo> detalles = new List<MC.AreaTrabajo>();
        private int idprestataria = 0;
        private bool editable = false;

        public List<MC.AreaTrabajo> AreasTrabajo
        {
            get { return detalles; }
            set
            {
                detalles = detalles != value ? value : detalles;
                SetBindings();
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        public int IDPrestataria
        {
            get { return idprestataria; }
            set
            {
                idprestataria = idprestataria != value ? value : idprestataria;
                SetBindings();
            }
        }

        public bool Editable
        {
            get { return editable; }
            set { editable = editable != value ? value : editable; SetEdicion(); }
        }

        public Usr_Contactos()
        {
            InitializeComponent();
            SetEdicion();
        }

        #region METODOS MANUALES

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                gridViewAreas.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.AreaTrabajo>(AreasTrabajo);
                gridViewAreas.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }

        private void SetEdicion()
        {            
            gridViewAreas.OptionsBehavior.Editable = Editable;
            gridViewContactos.OptionsBehavior.Editable = Editable;
        }

        private void CargaCombos(short i = 0, object n = null)
        {
            try
            {

                if (i == 0 || i == 1)
                {
                    //CARGAR LISTA AREA PARA COMBO
                    MC.Area a = new MC.Area(SqlConnection);
                    List<MC.Area> arealst = a.GetRegistros();
                    cmbAreas.DataSource = arealst;

                    if (n != null)
                    {
                        SearchLookUpEdit se = n as SearchLookUpEdit;
                        se.Properties.DataSource = arealst;
                    }
                }
                               
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un error al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }


        private void AltaArea(object slookup)
        {
            try
            {
                Frm_Area a = new Frm_Area();
                a.SqlConnection = SqlConnection;

                if (a.ShowDialog() == DialogResult.OK)
                {
                    CargaCombos(0,slookup);
                }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al generar el alta del área.", 1);
                return;
            }
        }

        private void AgregaRegistro()
        {
            try
            {
                GridView v = gridControl.FocusedView as GridView;

                if (v != null)
                {
                    v.AddNewRow();
                    //v.ShowEditForm();
                }
                else { ctrls.MensajeInfo("No se logró generar el registro.", 1); }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Ocurrió un error al generar el registro.", 1);
                return;
            }
        }

        #endregion

        private void Usr_Contactos_Load(object sender, EventArgs e)
        {
            CargaCombos();            
        }
               
        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void gridViewContactos_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //gridViewContactos.ShowEditForm();
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;                
            }
        }

        private void cmbAreas_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {                
                AltaArea(sender);
            }
        }

        private void gridViewAreas_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (Editable) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }
        }

        private void gridViewContactos_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (Editable) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }
        }

        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgregaRegistro();
        }

        private void gridViewAreas_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyCode == Keys.F2)
            {
                gridViewAreas.AddNewRow();

            }
            else if (e.KeyData == Keys.F4)
            {
                gridViewAreas.ExpandMasterRow(gridViewAreas.FocusedRowHandle);
                GridView view = gridViewAreas.GetDetailView(gridViewAreas.FocusedRowHandle, 0) as GridView;
                if (view != null)
                {
                    view.AddNewRow();
                    view.ShowEditForm();
                }
            }
        }

        private void gridViewContactos_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyData == Keys.F4)
            {
                gridViewAreas.ExpandMasterRow(gridViewAreas.FocusedRowHandle);
                GridView view = gridViewAreas.GetDetailView(gridViewAreas.FocusedRowHandle, 0) as GridView;
                if (view != null)
                {
                    view.AddNewRow();                    
                }
            }
        }
    }
}
