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

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_DirecCont : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private ConexionBD cb = new ConexionBD();
        private MC.Direcciones direcionescls = new MC.Direcciones();
        private int idprofesional = 0;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public List<MC.Direcciones> Direccioneslst { get; set; } = new List<MC.Direcciones>();

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
        private byte DirecContact { get; set; } = 0; //0 DIRECCION / 1 CONTACTO

        public Frm_DirecCont()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {
            
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;

            if (Es_Popup) { this.FormBorderStyle = FormBorderStyle.Sizable; }
            else { this.FormBorderStyle = FormBorderStyle.None; }

            CargaCombos();
            AsignaDatos();
            gridViewDomi.OptionsBehavior.Editable = Editable;
            gridViewConta.OptionsBehavior.Editable = Editable;
        }
        
        private void CargaCombos(short i = 0)
        {
            try
            {
                if (i == 0 || i == 1)
                {
                    string c = "SELECT LO.ID_Registro, LO.Descripcion AS Localidad, PR.Descripcion as Provincia" +
                    " FROM LOCALIDADES LO" +
                    " LEFT OUTER JOIN PROVINCIAS PR ON(PR.ID_Registro = LO.ID_Provincia)" +
                    " ORDER BY LO.Descripcion";

                    repCmblocalidades.DataSource = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                }
            }
            catch (Exception)
            {

                return;
            }

        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {           
            if (propertyname == "IDProfesional") { AsignaDatos(); }
            
        }
             
        private void AsignaDatos()
        {
            try
            {
                gridViewDomi.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Direcciones>(Direccioneslst);
                gridViewDomi.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }
        
        #endregion

        private void Frm_Contactos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void gridViewDomi_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyCode == Keys.F2)
            {
                gridViewDomi.AddNewRow();
                
            }           
            else if (e.KeyData == Keys.F4)
            {
                gridViewDomi.ExpandMasterRow(gridViewDomi.FocusedRowHandle);
                GridView view = gridViewDomi.GetDetailView(gridViewDomi.FocusedRowHandle, 0) as GridView;
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


        private void gridViewDomi_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
           // if (gridViewDomi.RowCount <= 0 || !Editable) { return; }
           // popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
           // DirecContact = 0;
        }

        private void gridViewConta_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            gridViewDomi.ExpandMasterRow(gridViewDomi.FocusedRowHandle);
            GridView view = gridViewDomi.GetDetailView(gridViewDomi.FocusedRowHandle, 0) as GridView;
            if (view == null || view.RowCount <= 0 || !Editable) { return; }
                        
            DirecContact = 1;
        }

        private void gridViewConta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!Editable) { return; }

                if (e.KeyData == Keys.F4)
                {
                    gridViewDomi.ExpandMasterRow(gridViewDomi.FocusedRowHandle);
                    GridView view = gridViewDomi.GetDetailView(gridViewDomi.FocusedRowHandle, 0) as GridView;
                    if (view != null)
                    {
                        view.AddNewRow();
                        view.ShowEditForm();
                    }
                }
                else if (e.KeyData == Keys.Delete)
                {
                    gridViewDomi.ExpandMasterRow(gridViewDomi.FocusedRowHandle);
                    GridView view = gridViewDomi.GetDetailView(gridViewDomi.FocusedRowHandle, 0) as GridView;
                    MC.Contactos cn = view.GetRow(view.FocusedRowHandle) as MC.Contactos;
                    if (cn != null)
                    {
                        view.BeginDataUpdate();
                        if (cn != null) { cn._BorraRegistro = !cn._BorraRegistro; }
                        view.EndDataUpdate();
                    }
                }
            }
            catch (Exception x)
            {
                ctrls.MensajeInfo($"Hubo un inconveninente al procesar los comando.\n{x.Message}", 1);
                return;
            }            
        }

        private void Frm_DirecCont_FormClosing(object sender, FormClosingEventArgs e)
        {
            cb.Desconectar();
        }
    }

}