using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Frm_InfoGeneral : XtraForm
    {
        private Propiedadesgral prop = new Propiedadesgral();
        private Controles ctrls = new Controles();

        public bool Es_Popup { get; set; } = true;
        public string Informacion { get; set; } = "";

        public Frm_InfoGeneral()
        {
            InitializeComponent();
        }

        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                prop.RecuperaUbicacion(8, this);
            }

            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);

            txtMemo.Text = Informacion;
        }

        private void txtMemo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void Frm_InfoGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            prop.GuardarUbicacion(8, this);
        }

        private void Frm_InfoGeneral_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }
    }
}