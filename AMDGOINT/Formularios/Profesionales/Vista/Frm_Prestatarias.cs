using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_Prestatarias : XtraForm, INotifyPropertyChanged
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private MC.Prestatarias Prestatariascl = new MC.Prestatarias();
        private int idprofesional = 0;        

        public List<MC.Prestatarias> Prestatariaslst { get; set; } = new List<MC.Prestatarias>();
        

        public SqlConnection SqlConnection = new SqlConnection();
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
        public bool Editable { get; set; } = true;
        
        #region MANUALES                
        public Frm_Prestatarias()
        {
            InitializeComponent();
        }

        #region NOTIFY      
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (propertyname == "IDProfesional") { AsignaDatos(); }
        }

        #endregion
        
        private void ParametrosInicio()
        {
            if (Es_Popup) { this.FormBorderStyle = FormBorderStyle.Sizable; }
            else { this.FormBorderStyle = FormBorderStyle.None; }

            CargaCombos();
            AsignaDatos();
            gridView.OptionsBehavior.Editable = Editable;
        }

        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Prestatarias>(Prestatariaslst);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las prestatarias.\n{e.Message}", 1);
                return;
            }
        }

        private void CargaCombos(short i = 0, object c = null)
        {
            try
            {
                if (i == 0 || i == 1)
                {
                    string cs = "SELECT ID_Registro AS IDRegistro, Nombre, '' AS Abreviatura" +
                                " FROM PRESTATARIAS WHERE Estado = 1";

                    cmbPrestataria.DataSource = func.getColecciondatos(cs, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                    
                }
            }
            catch (Exception )
            {
                ctrls.MensajeInfo("No se pudo cargar la lista de prestatarias", 0);
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
            if (v.GetFocusedRowCellValue(colID_Prestataria) == DBNull.Value
                || Convert.ToInt32(v.GetFocusedRowCellValue(colID_Prestataria)) <= 0)
            { e.Valid = false; c = colID_Prestataria; }

            if (!e.Valid) { v.SetColumnError(c, "Debe completar el campo para continuar."); }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }

}