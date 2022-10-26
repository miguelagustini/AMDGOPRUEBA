using DevExpress.XtraEditors;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Usr_PrintParams : XtraUserControl
    {
        private short cantidad = 1;
        private bool incluyepacientes = false;
        private bool incluyedetalles = false;
        private bool incluyeprestador = true;
        private bool incluyeleyendaoriginal = false;

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

        public bool IncluirPrestador
        {
            get { return incluyeprestador; }
            set
            {
                if (incluyeprestador != value)
                {
                    incluyeprestador = value;
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

        public bool IncluirDetalles
        {
            get { return incluyedetalles; }
            set
            {
                if (incluyedetalles != value)
                {
                    incluyedetalles = value;
                }
            }
        }

        public bool IncluirLeyendaOriginal
        {
            get { return incluyeleyendaoriginal; }
            set
            {
                if (incluyeleyendaoriginal != value)
                {
                    incluyeleyendaoriginal = value;
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
            tglPrestadorinfo.DataBindings.Add("EditValue", this, nameof(IncluirPrestador));
            tglPacientes.DataBindings.Add("EditValue", this, nameof(IncluirPacientes));
            tglDetalles.DataBindings.Add("EditValue", this, nameof(IncluirDetalles));
            tglLeyendaOriginal.DataBindings.Add("EditValue", this, nameof(IncluirLeyendaOriginal));
        }

        private void tglLeyendaOriginal_Toggled(object sender, System.EventArgs e)
        {
            try
            {
                ToggleSwitch tgl = sender as ToggleSwitch;

                if (tgl != null && (bool)tgl.EditValue)
                {
                    tglPrestadorinfo.EditValue = false; IncluirPrestador = false;
                    tglDetalles.EditValue = true; IncluirDetalles = true;
                }
            }
            catch (System.Exception)
            {
                
            }            
        }

        private void tglPrestadorinfo_Toggled(object sender, System.EventArgs e)
        {
            try
            {
                ToggleSwitch tgl = sender as ToggleSwitch;

                if (tgl != null && (bool)tgl.EditValue) { tglLeyendaOriginal.EditValue = false; IncluirLeyendaOriginal = false; }
            }
            catch (System.Exception)
            {
            }
            
        }
    }
}
