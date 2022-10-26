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

namespace AMDGOINT.Formularios.Aranceles.Vista
{
    public partial class Frm_Simulacion : XtraForm
    {
        public List<Negociacion.MC.Negociacion> Negociaciones { get; set; } = new List<Negociacion.MC.Negociacion>();
                
        public Frm_Simulacion()
        {
            InitializeComponent();
        }



    }
}