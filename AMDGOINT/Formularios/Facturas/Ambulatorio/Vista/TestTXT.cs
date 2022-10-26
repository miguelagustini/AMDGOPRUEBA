using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class TestTXT : Form
    {
        public TestTXT()
        {
            InitializeComponent();
        }

        private void TestTXT_Shown(object sender, EventArgs e)
        {
            MC.ExportacionSN sn = new MC.ExportacionSN();
            gridView1.BeginDataUpdate();
            gridControl1.DataSource = sn.GetRegistros();
            gridView1.EndDataUpdate();
            
        }
    }
}
