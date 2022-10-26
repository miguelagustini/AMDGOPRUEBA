using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AMDGOINT.Formularios.Retiros.Vista
{
    public partial class Usr_Visualizador : XtraUserControl
    {
        private byte[] _imagen = null;

        public byte[] Imagen
        {
            get { return _imagen; }
            set
            {
                if (_imagen != value)
                {
                    _imagen = value;
                    AsignaImagen();
                }
            }
        }

        public Usr_Visualizador()
        {
            InitializeComponent();            
        }

        private void AsignaImagen()
        {
            pictureEdit.EditValue = Imagen;
        }
    }
}
