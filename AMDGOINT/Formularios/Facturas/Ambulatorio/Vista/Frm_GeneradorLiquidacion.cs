using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Frm_GeneradorLiquidacion : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private string _periodo = "";
        private List<string> _tiposcomprobante = new List<string>();

        public int PrestatariaPlanID { get; set; } = 0;
        public string PrestatariaPlanCodigo { get; set; } = "";
        public string PrestatariaNombre { get; set; } = "";
        public long PrestatariaCuit { get; set; } = 0;
        public short TipoImpresion { get; set; } = 0;
        public string Periodo { get; set; } = "";        
        public List<string> OrigenPracticas { get; set; } = new List<string>();
        private MC.LiquidacionEncabezado Liquidacion { get; set; } = new MC.LiquidacionEncabezado();
        private List<MC.LiquidacionEncabezado> Liquidaciones { get; set; } = new List<MC.LiquidacionEncabezado>();
        
        private OverlayPanel OverlayPanel = new OverlayPanel();
        private SqlConnection SqlConnection = new SqlConnection();
        private Point LocationSplash = new Point();

        public Frm_GeneradorLiquidacion()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);          
        }
       
        #region METODOS MANUALES

        //inicia carga listado
        private void Ilistar()
        {


            Liquidacion.PrestadoraCodigo = PrestatariaPlanCodigo;
            Liquidacion.PrestadoraNombre = PrestatariaNombre;
            Liquidacion.PrestadoraCuit = PrestatariaCuit;
            Liquidacion.Periodo = Periodo;
            Liquidacion.ParamTipoComrpobante = OrigenPracticas;
            Liquidacion.TipoImpresion = TipoImpresion;
            Liquidacion.SeparaRI = (bool)tglSepararRI.EditValue;

            if (Periodo == "" || OrigenPracticas.Count() <= 0)
            {
                ctrls.MensajeInfo("Faltan parámetros para generar la liquidación de prácticas.", 1);                
                return;
            }
                     
            
            if (bgwCargar.IsBusy)
            {
                ctrls.MensajeInfo("El proceso esta ocupado con otra acción.", 1);
                return;
            }

            OverlayPanel.Mostrar(this);            
            bgwCargar.RunWorkerAsync();
        }

        //CARGA LISTA ARANCELES
        private void Listar()
        {
            try
            {
                Liquidacion.GetRegistros();
                Liquidaciones.Clear();
                Liquidaciones.Add(Liquidacion);

            }
            catch (Exception)
            {
                return;
            }
        }

        //fin de carga
        private void Flistar()
        {
            try
            {   
                XtraReport rpt = new XtraReport();

                DateTime PeriodoFecha = !string.IsNullOrEmpty(Periodo) ? new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1) : DateTime.MinValue; 

                if (OrigenPracticas.Contains("1") || OrigenPracticas.Contains("2") || OrigenPracticas.Contains("7"))
                {                    
                    if (TipoImpresion == 0) { rpt = new Xtra_LiquidacionAmbP(); rpt.Parameters["SeparaRI"].Value = (bool)tglSepararRI.EditValue; }
                    else { rpt = new Xtra_LiquidacionAmbI(); }
                    rpt.Parameters["Periodo"].Value = PeriodoFecha;
                    rpt.DataSource = Liquidaciones;                    
                }
                else
                {
                    rpt = new Xtra_LiquidacionIntP();
                    rpt.Parameters["Periodo"].Value = PeriodoFecha;
                    rpt.DataSource = Liquidaciones;                    
                    
                }

                ReportPrintTool printTool = new ReportPrintTool(rpt);
                OverlayPanel.Ocultar();
                printTool.ShowPreviewDialog();
                printTool.Dispose();
                rpt.Dispose();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar la liquidación.\n{e.Message}", 1);
                return;
            }

           
        }
           
        #endregion
                
        private void bgwCargar_DoWork(object sender, DoWorkEventArgs e)
        {
            Listar();
        }

        private void bgwCargar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Flistar();
        }       
     
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Ilistar();
        }

        private void CargaPlanes()
        {
            try
            {
                string c = "SELECT PD.ID_Registro AS IDRegistro, PD.Codigo, PD.Abreviatura, PR.Nombre, PR.Cuit, CONCAT(PD.Codigo, ' ', PR.Nombre) AS PrestadoraCompleta" +
                             " FROM PRESTATARIAS PR" +
                             " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Prestataria = PR.ID_Registro)" +
                             " WHERE PD.ID_Registro IS NOT NULL AND PD.Visible = 1";

                cmbPrestatarias.Properties.DataSource = func.getColecciondatos(c);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo inconvenientes al cargar la lista.\n{e.Message}", 1);
                return;
            }
        }

        private void SetPrestadoradata()
        {
            try
            {
                int _id = 0;

                if (cmbPrestatarias.EditValue != null && int.TryParse(cmbPrestatarias.EditValue.ToString(), out _id))
                {
                    DataTable dt = cmbPrestatarias.Properties.DataSource as DataTable;

                    DataRow r = dt.Select("IDRegistro = " + _id).FirstOrDefault();
                    if (r != null)
                    {
                        PrestatariaPlanCodigo = r["Codigo"].ToString().Trim();
                        PrestatariaNombre = r["Nombre"].ToString().Trim();
                        PrestatariaCuit = Convert.ToInt64(r["Cuit"]);
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void cmbPrestatarias_EditValueChanged(object sender, EventArgs e)
        {
            SetPrestadoradata();
        }

        private void dateFecha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateEdit d = sender as DateEdit;
                Periodo = Convert.ToDateTime(d.EditValue).Year + Convert.ToDateTime(d.EditValue).Month.ToString("00");
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar el periodo", 1);
            }

        }

        private void cmbTipocomprobante_Validated(object sender, EventArgs e)
        {
            try
            {
                CheckedComboBoxEdit d = sender as CheckedComboBoxEdit;
                OrigenPracticas.Clear();
                for (int i = 0; i < d.Properties.Items.Count; i++)
                {
                    if (d.Properties.Items[i].CheckState == CheckState.Checked)
                    {
                        OrigenPracticas.Add(d.Properties.Items[i].Value.ToString());
                    }
                }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar tipo de comprobante", 1);
            }
        }

        private void radTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup grp = sender as RadioGroup;
            if (grp != null) { TipoImpresion = (short)grp.SelectedIndex; }

        }

        private void Frm_GeneradorLiquidacion_Shown(object sender, EventArgs e)
        {
            CargaPlanes();
        }

        private void cmbTipocomprobante_TextChanged(object sender, EventArgs e)
        {
            CheckedComboBoxEdit a = sender as CheckedComboBoxEdit;
            if (a != null && a.Text != "") { cmbTipocomprobanteInt.Enabled = false; }
            else { cmbTipocomprobanteInt.Enabled = true; }
            
        }

        private void cmbTipocomprobanteInt_TextChanged(object sender, EventArgs e)
        {
            CheckedComboBoxEdit a = sender as CheckedComboBoxEdit;
            if (a != null && a.Text != "") { cmbTipocomprobante.Enabled = false; }
            else { cmbTipocomprobante.Enabled = true; }
        }
    }
}