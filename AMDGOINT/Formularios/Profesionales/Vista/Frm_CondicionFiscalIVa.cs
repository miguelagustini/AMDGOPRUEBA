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
    public partial class Frm_CondicionFiscalIVa : XtraForm
    {
        private Funciones func = new Funciones();
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();
        private int idprofesional = 0;
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public List<MC.CategoriaCondicionesIva> CondicionFiscalIva = new List<MC.CategoriaCondicionesIva>();

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
                
        public bool Editable { get; set; } = false;
        
        public Frm_CondicionFiscalIVa()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();

            FormBorderStyle = FormBorderStyle.None;                         
            gridView.OptionsBehavior.Editable = Editable;
            CargaCombos();
            AsignaDatos();
        }
        
        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {           
            if (propertyname == "IDProfesional") { AsignaDatos(); }
            
        }
             
        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.CategoriaCondicionesIva>(CondicionFiscalIva);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{GetType().Name} AsignaDatos.\n{e.Message}", 1);
                return;
            }
        }

        //CARGA DE COMBOS
        private void CargaCombos()
        {
            try
            {
                //CONDICIONES DE IVA 
                string c = $"SELECT ID_Registro, Descripcion, Abreviatura" +
                    $" FROM CONDSIVA" +
                    $" WHERE Abreviatura <> 'CF'" +
                    $" ORDER BY Descripcion ASC";

                reposCondicionesiva.DataSource = func.getColecciondatos(c, SqlConnection);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
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
            try
            {
                GridView v = gridView;
                GridColumn c = new GridColumn();

                MC.RetencionIngresosBrutos _tmp = v.GetRow(v.FocusedRowHandle) as MC.RetencionIngresosBrutos;

                if (_tmp != null)
                {
                    string errcode = "";
                                        
                    if (_tmp.FechaDesde <= DateTime.MinValue) { e.Valid = false; c = colDesde; errcode = "Fecha no válida"; }                    

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

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4) { e.SuppressKeyPress = true; }
        }
    }

}