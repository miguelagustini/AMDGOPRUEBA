using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_Especialidades : XtraForm, INotifyPropertyChanged
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private ConexionBD cb = new ConexionBD();
        private MC.Especialidades especialidadescls = new MC.Especialidades();

        private int idprofesional = 0;
        public SqlConnection SqlConnection = new SqlConnection();

        public List<MC.Especialidades> Especialidadeslst { get; set; } = new List<MC.Especialidades>();

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

        public Frm_Especialidades()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        #region NOTIFY      
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (propertyname == "IDProfesional") { AsignaDatos(); }
        }

        #endregion

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;

            if (Es_Popup) { FormBorderStyle = FormBorderStyle.Sizable; }
            else { FormBorderStyle = FormBorderStyle.None; }

            CargaCombos();
            AsignaDatos();
            reposDate.NullDate = DateTime.MinValue;
            gridView.OptionsBehavior.Editable = Editable;
        }

        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Especialidades>(Especialidadeslst);
                gridView.EndDataUpdate();                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }

        private void CargaCombos(short i = 0, object c = null)
        {
            try
            {
                if (i == 0 || i == 1)
                {
                    Especialidad.MC.Especialidad ent = new Especialidad.MC.Especialidad(SqlConnection);
                    List<Especialidad.MC.Especialidad> lst = ent.Clone(ent.GetRegistros());

                    if (c != null)
                    {
                        SearchLookUpEdit se = c as SearchLookUpEdit;
                        cmbEspecialidad.DataSource = lst;
                        se.Properties.DataSource = lst;
                    }
                    else { cmbEspecialidad.DataSource = lst; }
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        #endregion

        private void Frm_Contactos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_ProfEspecialidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            cb.Desconectar();
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyCode == Keys.F2)
            {
                gridView.AddNewRow();
                
            }
           
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView v = gridView;
            GridColumn c = new GridColumn();

            //ID ESPECIALIDAD
            if (v.GetFocusedRowCellValue(colEspecialidad) == DBNull.Value
                || Convert.ToInt16(v.GetFocusedRowCellValue(colEspecialidad)) <= 0)
            { e.Valid = false; c = colEspecialidad; }
                       
            if (!e.Valid) { v.SetColumnError(c, "Debe completar el campo para continuar."); }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void cmbEspecialidad_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                SearchLookUpEdit c = sender as SearchLookUpEdit;
                Especialidad.Vista.Frm_Especialidad frm = new Especialidad.Vista.Frm_Especialidad();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargaCombos(0, c);
                }
                
            }

        }
    }
    
}