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
using AMDGOINT.Formularios.Auditoria.Anestesiologia.MC;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System.Linq;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista
{
    public partial class Frm_AnestesiaAuditDet : XtraForm, INotifyPropertyChanged
    {
        private ConexionBD cbd = new ConexionBD();
        private Controles ctrls = new Controles();                
        private List<AnestesiaValoresAM> valoreslst = new List<AnestesiaValoresAM>();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public BindingList<Anestesiagrp> anestesiadetalles { get; set; } = new BindingList<Anestesiagrp>();
        
        private int idencabezado = 0;
        private bool editable = true;

        public int IDEncabezado
        {
            get
            {
                return this.idencabezado;
            }
            set
            {
                if (idencabezado != value || value == 0)
                {
                    idencabezado = value;
                    NotifyPropertyChanged();
                    
                }
            }
        }

        public bool Es_Popup { get; set; } = false;
        public bool Editable
        {
            get { return editable; }
            set
            {
                if (editable != value) { editable = value; }
            }
        } 
        
        public Frm_AnestesiaAuditDet()
        {
            InitializeComponent();
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cbd.Conectar() : SqlConnection;

            if (Es_Popup) { this.FormBorderStyle = FormBorderStyle.Sizable; }
            else { this.FormBorderStyle = FormBorderStyle.None; }

            //CARGA DE COMBOS
            CargaCombos();
            
            //PRIMERA VEZ
            AsignaDatos();
        }

        private void CargaCombos(short i = 0, object c = null)
        {
            try
            {
                if (i == 0 || i == 1)
                {
                    Entidadane ent = new Entidadane(SqlConnection);
                    List<Entidadane> lst = ent.Clone(ent.GetRegistros());
                    if (c != null)
                    {
                        SearchLookUpEdit se = c as SearchLookUpEdit;
                        cmbEntidades.DataSource = lst;
                        se.Properties.DataSource = lst;
                    }
                    else { cmbEntidades.DataSource = lst; }
                    
                }

                if (i == 0 || i == 2)
                {
                    Anestesista an = new Anestesista(SqlConnection);
                    List<Anestesista> lst = an.Clone(an.GetRegistros());
                    if (c != null)
                    {
                        SearchLookUpEdit se = c as SearchLookUpEdit;
                        cmbAnestesistas.DataSource = lst;
                        se.Properties.DataSource = lst;
                    }
                    else { cmbAnestesistas.DataSource = lst; }
                    
                }

                if (i == 0 || i == 3)
                {
                    Practicaane an = new Practicaane(SqlConnection);
                    List<Practicaane> lst = an.Clone(an.GetRegistros());

                    if (c != null)
                    {
                        SearchLookUpEdit se = c as SearchLookUpEdit;
                        cmbPracticas.DataSource = lst;
                        se.Properties.DataSource = lst;
                    }
                    else { cmbPracticas.DataSource = lst; }
                }

                if (i == 0 || i == 4)
                {
                    valoreslst.Clear();

                    Practicaane an = new Practicaane(SqlConnection);
                    valoreslst = an.GetValoresAmdgo();

                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al cargar los combos.\n{e.Message}", 0);
                return;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (propertyname == "IDEncabezado") { AsignaDatos(); }            
        }
             
        private void AsignaDatos()
        {
            try
            {
                gridViewgrp.BeginDataUpdate();
                gridControl.DataSource = anestesiadetalles;
                gridViewgrp.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }

        private void SetNivel(short idpract, GridView v)
        {
            //ASIGNO EL NIVEL
            List<Practicaane> p = cmbPracticas.DataSource as List<Practicaane>;
            byte nv = p.Where(w => w.IDRegistro == idpract).Select(s => s.Nivel).First();
            v.SetFocusedRowCellValue(colNivel,nv);


            //ASIGNO EL VALOR AMDGO SEGUN NIVEL
            DateTime fec = gridViewgrp.GetFocusedRowCellValue(colFecha) != null ? 
                           Convert.ToDateTime(gridViewgrp.GetFocusedRowCellValue(colFecha)) : 
                           DateTime.MinValue;
            decimal dec = 0;
            string prc = "";

            //determino la practica segun nivel
            switch (nv)
            {
                case 1: prc = "460101"; break;
                case 2: prc = "460102"; break;
                case 3: prc = "460103"; break;
                case 4: prc = "460104"; break;
                case 5: prc = "460105"; break;
                case 6: prc = "460106"; break;
                case 7: prc = "460107"; break;                
            }

            //obtengo el importe
            if (!string.IsNullOrWhiteSpace(prc))
            {
                dec = valoreslst.Where(w => w.Practica == prc && w.Fecha <= fec).OrderByDescending(o => o.Fecha)
                     .Select(s => s.Importe).FirstOrDefault();

            }
            
            //asigno el importe al registro
            v.SetFocusedRowCellValue(coldValNivelAmdgo, dec);
        }

        #endregion
        
        private void Frm_Contactos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void gridViewDomi_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.F2)
            {
                gridViewgrp.AddNewRow();
                gridViewgrp.ShowEditForm();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }           
            else if (e.KeyData == Keys.F4)
            {
                gridViewgrp.ExpandMasterRow(gridViewgrp.FocusedRowHandle);
                GridView view = gridViewgrp.GetDetailView(gridViewgrp.FocusedRowHandle, 0) as GridView;
                if (view != null)
                {
                    view.AddNewRow();
                    view.ShowEditForm();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
        }

        private void gridViewdet_KeyDown(object sender, KeyEventArgs e)
        {

            if (!Editable)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                return;
            }

            if (e.KeyData == Keys.F4)
            {
                gridViewgrp.ExpandMasterRow(gridViewgrp.FocusedRowHandle);
                GridView view = gridViewgrp.GetDetailView(gridViewgrp.FocusedRowHandle, 0) as GridView;
                if (view != null)
                {
                    view.AddNewRow();
                    view.ShowEditForm();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {            
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = gridControl.FocusedView as GridView;

            if(view != null)
            {
                if (!Editable)
                {
                    view.OptionsBehavior.EditingMode = GridEditingMode.Inplace;
                    e.Cancel = true;
                }
                else
                {
                    view.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
                }
            }
        }

        private void CombosaddButtons_Click(object sender, ButtonPressedEventArgs e)
        {
            SearchLookUpEdit c = sender as SearchLookUpEdit;
            if (c == null) { return; }

            if (e.Button.Kind == ButtonPredefines.Glyph && c.Properties.Name == "cmbAnestesistas")
            {
                Frm_Anestesista f = new Frm_Anestesista();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargaCombos(2, c);
                }
            }
            else if (e.Button.Kind == ButtonPredefines.Glyph && c.Properties.Name == "cmbEntidades")
            {
                Frm_Entidadesane f = new Frm_Entidadesane();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargaCombos(1, c);
                }
            }
            else if (e.Button.Kind == ButtonPredefines.Glyph && c.Properties.Name == "cmbPracticas")
            {
                Frm_Practicasanes f = new Frm_Practicasanes();

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargaCombos(3, c);                    
                }

            }
        }

        private void gridViewgrp_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView v = gridViewgrp;
            GridColumn c = new GridColumn();

            //NUMERO FACTURACION
            if (v.GetFocusedRowCellValue(colNumero) == DBNull.Value
                || Convert.ToInt32(v.GetFocusedRowCellValue(colNumero)) <= 0)
            { e.Valid = false; c = colNumero; }

            //ANESTESISTA
            if (v.GetFocusedRowCellValue(colAnestesista) == DBNull.Value
                || Convert.ToInt16(v.GetFocusedRowCellValue(colAnestesista)) <= 0)
            { e.Valid = false; c = colAnestesista; }

            //DOCUMENTO
            if (v.GetFocusedRowCellValue(colDocumento) == DBNull.Value
                || Convert.ToInt32(v.GetFocusedRowCellValue(colDocumento)) <= 0)
            { e.Valid = false; c = colDocumento; }

            //PACIENTE
            if (v.GetFocusedRowCellValue(colPaciente) == DBNull.Value
                || string.IsNullOrWhiteSpace(v.GetFocusedRowCellValue(colPaciente).ToString()))
            { e.Valid = false; c = colPaciente; }

            //ENTIDAD
            if (v.GetFocusedRowCellValue(colIDEntidad) == DBNull.Value
                || Convert.ToInt16(v.GetFocusedRowCellValue(colIDEntidad)) <= 0)
            { e.Valid = false; c = colIDEntidad; }

            //FECHA
            if (v.GetFocusedRowCellValue(colFecha) == DBNull.Value
                || Convert.ToDateTime(v.GetFocusedRowCellValue(colFecha)) <= DateTime.MinValue)
            { e.Valid = false; c = colFecha; }

            if (!e.Valid) { v.SetColumnError(c, "Debe completar el campo para continuar."); }
        }

        private void gridViewgrp_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewdet_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
            GridView v = gridViewgrp.GetDetailView(gridViewgrp.FocusedRowHandle, 0) as GridView;
            GridColumn c = new GridColumn();

            //ID DE PRACTICA
            if (v.GetFocusedRowCellValue(coldIDPractica) == DBNull.Value
                || Convert.ToInt16(v.GetFocusedRowCellValue(coldIDPractica)) <= 0)
            { e.Valid = false; c = coldIDPractica; }
            else { SetNivel(Convert.ToInt16(v.GetFocusedRowCellValue(coldIDPractica)), v); }
                       
            //PORCENTAJE
            if (v.GetFocusedRowCellValue(coldProcentaje) == DBNull.Value
                || Convert.ToDecimal(v.GetFocusedRowCellValue(coldProcentaje)) <= 0)
            { e.Valid = false; c = coldProcentaje; }

            //IMPORTE
            if (v.GetFocusedRowCellValue(coldImporte) == DBNull.Value
                || Convert.ToDecimal(v.GetFocusedRowCellValue(coldImporte)) <= 0)
            { e.Valid = false; c = coldImporte; }

            if (!e.Valid) { v.SetColumnError(c, "Debe completar el campo para continuar."); }
        }

        private void gridViewdet_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

    }

}