using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExcelDataReader;
using System.IO;
using System.Data;
using System.Linq;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Frm_Importacion : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        
        public string PathExcel = ""; public int FromRow = 0; public int Hoja = 0; public int ToRow = 0; public int ColCodAm = 0; public int ColCodos = 0;
        public int ColDescr = 0; public int ColObser = 0; public int Colvalor = 0; public int ColFunc = 0; public int Colgasto = 0;
        public byte TratamDecimal { get; set; } = 1;
                        
        public Frm_Importacion()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {   
            FormBorderStyle = ctrls.EstiloBordesform(true);            
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(true);
        }       
      
        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            txtExcelpath.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //PATH EXCEL
            if (txtExcelpath.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar un archivo para generara la importación.", 1);
                txtExcelpath.Focus();
                return;
            }

            //NUMERO DE HOJA
            if (spnHoja.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una hoja para generara la importación.", 1);
                spnHoja.Focus();
                return;
            }

            //NUMERO DE FILA DESDE
            if (spnFiladesde.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una fila inicial para generara la importación.", 1);
                spnFiladesde.Focus();
                return;
            }

            //NUMERO DE FILA HASTA
            if (spnFilahasta.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una fila final para generara la importación.", 1);
                spnFilahasta.Focus();
                return;
            }


            //COLUMNA COD OS
            if (txtColOs.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de codigo Obra social para generara la importación.", 1);
                txtColOs.Focus();
                return;
            }

            //COLUMNA COD AM
            if (txtColAm.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de codigo AM para generara la importación.", 1);
                txtColAm.Focus();
                return;
            }

            //COLUMNA DESCRIPCION
            if (txtColDesc.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de descripción para generara la importación.", 1);
                txtColDesc.Focus();
                return;
            }

            //COLUMNA OBSERVACION
            if (txtColObser.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de descripción para generara la importación.", 1);
                txtColObser.Focus();
                return;
            }

            //COLUMNA FUNCION
            if (txtColFunc.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de función para generara la importación.", 1);
                txtColFunc.Focus();
                return;
            }

            //COLUMNA DE NUEVO VALOR
            if (txtColvalor.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de valor para generara la importación.", 1);
                txtColvalor.Focus();
                return;
            }

            //GASTOS NO NECESARIOS
            int gasto = -1;
            if (txtColGasto.Text.Trim() != "") { gasto = func.GetIndexbyletterxls(txtColGasto.Text.Trim()); }

            PathExcel = txtExcelpath.Text.Trim();
            FromRow = Convert.ToInt32(spnFiladesde.Text);
            ToRow = Convert.ToInt32(spnFilahasta.Text);
            Hoja = Convert.ToInt32(spnHoja.Text);
            ColCodAm = func.GetIndexbyletterxls(txtColAm.Text.Trim());
            ColCodos = func.GetIndexbyletterxls(txtColOs.Text.Trim());
            ColDescr = func.GetIndexbyletterxls(txtColDesc.Text.Trim());
            ColObser = func.GetIndexbyletterxls(txtColObser.Text.Trim());
            Colvalor = func.GetIndexbyletterxls(txtColvalor.Text.Trim());
            ColFunc = func.GetIndexbyletterxls(txtColFunc.Text.Trim());
            Colgasto = gasto;

            DialogResult = DialogResult.OK;            
            
        }

        private void txtExcelpath_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            using (var fbd = new XtraOpenFileDialog())
            {
                fbd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK) { txtExcelpath.Text = fbd.FileName; }
            }
        }

        private void rdgDecimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            TratamDecimal = (byte)rdgDecimals.SelectedIndex;                        
        }
    }
}