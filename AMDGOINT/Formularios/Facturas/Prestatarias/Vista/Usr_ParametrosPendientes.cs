using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Usr_ParametrosPendientes : XtraUserControl
    {
        private Controles ctrls = new Controles();

        private string _periodo = "";
        private List<string> _tiposcomprobante = new List<string>();
        
        public string Periodo
        {
            get { return _periodo; }
            private set { _periodo = _periodo != value.Trim() ? value.Trim() : _periodo; }
        }

        public List<string> TiposComprobantes { get; set; } = new List<string>();

        public Usr_ParametrosPendientes()
        {
            InitializeComponent();
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
                TiposComprobantes.Clear();
                for (int i = 0; i < d.Properties.Items.Count; i++)
                {
                    if (d.Properties.Items[i].CheckState == CheckState.Checked)
                    {
                        TiposComprobantes.Add(d.Properties.Items[i].Value.ToString());
                    }
                }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar tipo de comprobante", 1);
            }
        }

    }
}
