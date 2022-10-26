using System;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Usr_Parametros : UserControl
    {

        private bool _propuestopor = true;

        public bool PropuestoPor
        {
            get { return _propuestopor; }
            set { _propuestopor = _propuestopor != value ? value : _propuestopor; }
        }

        public Usr_Parametros()
        {
            InitializeComponent();
            SetBindigs();
        }

        private void SetBindigs()
        {
            try
            {
                tglTipo.DataBindings.Clear();
                tglTipo.DataBindings.Add("EditValue", this, nameof(PropuestoPor));                                
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
