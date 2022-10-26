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

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    public partial class Frm_Faltantes : DevExpress.XtraEditors.XtraForm
    {
        private List<Faltantes> faltanteslst = new List<Faltantes>();

        public Frm_Faltantes()
        {
            InitializeComponent();
        }

        public void IniciaCarga(List<Faltantes> faltantes)
        {
            faltanteslst = faltantes;
            gridControl.DataSource = faltanteslst;
        }
    }
}