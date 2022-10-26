using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_AranImportxls : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private Arancelesclass aranceles = new Arancelesclass();

        public List<EstructuraExcel> excelimport = new List<EstructuraExcel>();

        private byte TratamDecimal { get; set; } = 1;
        public string ColumnaImpacto { get; private set; } = "";
        //public DateTime FechaImpacto { get; set; } = DateTime.Today;
        public bool OrigenValoriza { get; set; } = true;
        public string Archivo { get; set; } = "";
        
        public Frm_AranImportxls()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES
                      
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            
            this.FormBorderStyle = ctrls.EstiloBordesform(true);            
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(true);

            //VISIBILIDAD COLUMNA IMPACTO (YA QUE EN DISCUSION NO ES NECESARIA LA ACLARACION DE VALOR IMPACTO)            
            lblColImpacto.Visible = OrigenValoriza ? true : OrigenValoriza;
            cmbColumnaimpacto.Visible = OrigenValoriza ? true : OrigenValoriza;
            cmbColumnaimpacto.TabStop = OrigenValoriza ? true : OrigenValoriza;
            spnFilahasta.Text = "300";
            CargaCombos();
                        
        }

        private void CargaCombos(short cmb = 0)
        {
            try
            {
                cmbColumnaimpacto.Properties.Items.Clear();

                cmbColumnaimpacto.Properties.Items.Add("Val. OS");
                cmbColumnaimpacto.Properties.Items.Add("Val. Prepaga");
                cmbColumnaimpacto.Properties.Items.Add("Val. Caja");
                cmbColumnaimpacto.Properties.Items.Add("Val. ART");

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
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

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
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

            //COLUMNA DE IMPACTO
            if (OrigenValoriza)
            {
                if (cmbColumnaimpacto.Text == "")
                {
                    ctrls.MensajeInfo("Debe seleccionar una columna de impacto para generara la importación.", 1);
                    cmbColumnaimpacto.Focus();
                    return;
                }

                ColumnaImpacto = cmbColumnaimpacto.Text;
            }
            else
            {
                /*if (datFecha.Text.Trim() == "")
                {
                    ctrls.MensajeInfo("Debe seleccionar una fecha para generara la importación.", 1);
                    datFecha.Focus();
                    return;
                }

                FechaImpacto = Convert.ToDateTime(datFecha.Text);*/
            }
                        
            excelimport = aranceles.ReadExcelos(txtExcelpath.Text, func.GetIndexbyletterxls(txtColOs.Text.Trim()), func.GetIndexbyletterxls(txtColAm.Text.Trim()),
                func.GetIndexbyletterxls(txtColDesc.Text.Trim()), func.GetIndexbyletterxls(txtColObser.Text.Trim()), func.GetIndexbyletterxls(txtColFunc.Text.Trim()),
                func.GetIndexbyletterxls(txtColvalor.Text.Trim()), gasto, Convert.ToInt32(spnFiladesde.Text),
                Convert.ToInt32(spnFilahasta.Text), Convert.ToInt32(spnHoja.Text), TratamDecimal);

            if (excelimport.Count > 0)
            {               
                Archivo = txtExcelpath.Text;
                this.DialogResult = DialogResult.OK;
            }

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