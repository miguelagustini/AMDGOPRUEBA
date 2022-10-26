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

namespace AMDGOINT.Formularios.Facturas.ResumenInformesGral.Vista
{
    public partial class Frm_ParametrosFacturado : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private string _periodo = "";        

        public int PrestatariaPlanID { get; set; } = 0;
        public string PrestatariaPlanCodigo { get; set; } = "";
        public string Periodo { get; set; } = "";
        

        private OverlayPanel OverlayPanel = new OverlayPanel();
        private SqlConnection SqlConnection = new SqlConnection();
        private Point LocationSplash = new Point();

        public Frm_ParametrosFacturado()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);          
        }
       
        #region METODOS MANUALES
                      
        #endregion
    

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
                    }

                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No se puedo setear el codigo de la prestataria.\n{e.Message}", 1);
                return;
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

        private void Frm_GeneradorLiquidacion_Shown(object sender, EventArgs e)
        {
            CargaPlanes();
        }

    }
}