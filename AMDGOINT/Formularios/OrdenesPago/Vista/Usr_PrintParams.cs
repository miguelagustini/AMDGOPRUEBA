using DevExpress.XtraEditors;

namespace AMDGOINT.Formularios.OrdenesPago.Vista
{
    public partial class Usr_PrintParams : XtraUserControl
    {
        private short cantidad = 1;
                
        public short Cantidad
        {
            get { return cantidad; }
            set
            {
                if (cantidad != value)
                {
                    cantidad = value;
                }
            }
        }

        public bool IncluirCuentas { get; set; } = true;

        public Usr_PrintParams()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            spnCantidad.DataBindings.Add("EditValue", this, nameof(Cantidad));
            tglIncluirctas.DataBindings.Add("EditValue", this, nameof(IncluirCuentas));
        }

    }
}
