using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Retiros.Vista
{
    public partial class Frm_Importacion : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        
        public string Archivo { get; set; } = string.Empty;
        public List<MC.RegistrosImportacion> Registros { get; set; } = new List<MC.RegistrosImportacion>();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Importacion()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            FormBorderStyle = ctrls.EstiloBordesform(true);
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(true);
            spnFilahasta.Text = "400";

            datVencimiento.Properties.NullDate = DateTime.MinValue;
            datVencimiento.Properties.NullText = string.Empty;

            CargaCmbo();
        }

        //CARGA COMBO
        private void CargaCmbo()
        {
            try
            {
                MC.PagoForma Formapago = new MC.PagoForma(SqlConnection);
                cmbPagoForma.Properties.DataSource = Formapago.GetRegistros();

                Empresas.MC.Empresa Empresa = new Empresas.MC.Empresa(SqlConnection);
                cmbEmpresa.Properties.DataSource = Empresa.GetRegistros();

                MC.Concepto Concepto = new MC.Concepto(SqlConnection);
                cmbConcepto.Properties.DataSource = Concepto.GetRegistros();
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al cargar la lista de bancos.", 1);
                return;
            }
        }

        //IMPORTACION DEL ARCHIVO        
        private void ReadExcelos()
        {
            Registros.Clear();

            try
            {

                int hoja = Convert.ToInt32(spnHoja.EditValue);
                int fromrow = Convert.ToInt32(spnFiladesde.Text);
                int torow = Convert.ToInt32(spnFilahasta.Text);
                int colCodCuenta = func.GetIndexbyletterxls(txtNroCuenta.Text);
                int colvalor = func.GetIndexbyletterxls(txtImporte.Text);
                int colObserva = !string.IsNullOrEmpty(txtObservacion.Text) ? func.GetIndexbyletterxls(txtObservacion.Text) : -1;
                
                //CARGO LA LISTA DE PRACTICAS NOMENCLADAS OBTENIDAS DEL EXCEL
                using (var stream = File.Open(txtExcelpath.Text, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelreader = ExcelReaderFactory.CreateReader(stream);
                    DataTable dt = excelreader.AsDataSet().Tables[hoja - 1];

                    for (int i = (fromrow - 1); i <= torow; i++)
                    {
                        if (i > dt.Rows.Count - 1) { continue; }
                        
                        //CODIGO AM NULL
                        if (string.IsNullOrWhiteSpace(dt.Rows[i][colCodCuenta] != null ? dt.Rows[i][colCodCuenta].ToString() : "")) { continue; }                        
                        
                        //IMPORTE
                        if (func.Trydecimalconvert(dt.Rows[i][colvalor].ToString().Trim()) <= 0) { continue; }

                        Registros.Add(new MC.RegistrosImportacion
                        {
                            CodigoCuenta = dt.Rows[i][colCodCuenta].ToString().Trim(),
                            Importe = func.Trydecimalconvert(dt.Rows[i][colvalor].ToString().Trim()),
                            Observacion = colObserva >= 0 ? dt.Rows[i][colObserva].ToString().Trim() : "",                            
                            TipoMovimiento = tglTipomovimiento.IsOn ? Convert.ToByte(2) : Convert.ToByte(1),
                            Vencimiento = Convert.ToDateTime(datVencimiento.EditValue),                            
                            IDPagoForma = Convert.ToByte(cmbPagoForma.EditValue),
                            IDEmpresa = Convert.ToInt16(cmbEmpresa.EditValue),
                            IDConcepto = Convert.ToInt16(cmbConcepto.EditValue)

                        });
                    }
                }
            }
            catch (Exception e)
            {
                if (e.HResult == -2146233080)
                { ctrls.MensajeInfo($"{e.Message}", 0); }
                else if (e.HResult == -2147024864)
                { ctrls.MensajeInfo("Éste archivo ya esta siendo usado por otro programa, ciérrelo e intente nuevamente.", 1); }
                else { ctrls.MensajeInfo($"Ocurrió un error al leer el archivo excel {e.Message}", 0); }
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

            //COLUMNA CODIGO CUENTA
            if (txtNroCuenta.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de codigo Obra social para generara la importación.", 1);
                txtNroCuenta.Focus();
                return;
            }

            //COLUMNA IMPORTE
            if (txtImporte.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una columna de codigo AM para generara la importación.", 1);
                txtImporte.Focus();
                return;
            }

            //CONCEPTO
            if (cmbConcepto.EditValue is null || (short)cmbConcepto.EditValue <= 0)
            {
                ctrls.MensajeInfo("Debe seleccionar un concepto de retiro para continuar.", 1);
                cmbConcepto.Focus();
                return;
            }

            ReadExcelos();

            if (Registros.Count > 0)
            {
                Archivo = txtExcelpath.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
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
    }
}