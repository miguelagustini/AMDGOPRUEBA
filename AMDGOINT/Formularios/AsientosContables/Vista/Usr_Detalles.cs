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
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Usr_Detalles : DevExpress.XtraEditors.XtraUserControl
    {
        private Controles ctrl = new Controles();
        private List<MC.AsientosDet> _asientos = new List<MC.AsientosDet>();
        public List<MC.AsientosDet> Asientos
        {
            get { return _asientos; }
            set { _asientos = _asientos != value ? value : _asientos; setBindings(); }
        }

        public Usr_Detalles()
        {
            InitializeComponent();
            setBindings();
        }

        private void setBindings()
        {
            try
            {
                gridViewAsientosdet.BeginDataUpdate();
                gridControl.DataSource = Asientos;
                gridViewAsientosdet.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar los detalles.\n{e.Message}", 1);
                return;
            }
        }
    }
}
