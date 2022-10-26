using DevExpress.XtraEditors;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Usr_PrintParams : XtraUserControl
    {
        private short cantidad = 1;
        private bool incluyepacientes = false;
        private bool incluyefacturas = false;        

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

        public bool IncluirPacientes
        {
            get { return incluyepacientes; }
            set
            {
                if (incluyepacientes != value)
                {
                    incluyepacientes = value;
                }
            }
        }

        public bool IncluirFactura
        {
            get { return incluyefacturas; }
            set
            {
                if (incluyefacturas != value)
                {
                    incluyefacturas = value;
                }
            }
        }

        public Usr_PrintParams()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            spnCantidad.DataBindings.Add("EditValue", this, nameof(Cantidad));
            tglPacientes.DataBindings.Add("EditValue", this, nameof(IncluirPacientes));
            tglIncluyeFactura.DataBindings.Add("EditValue", this, nameof(IncluirFactura));            
        }

        private void labelControl3_Click(object sender, System.EventArgs e)
        {

        }
    }
}
