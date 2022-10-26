using System;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Usr_Exportacion : DevExpress.XtraEditors.XtraUserControl
    {

        private bool vercoseguro = false;
        private bool vercopago = false;
        private bool printagrupcodigo = false;

        public bool VerCoseguro
        {
            get { return vercoseguro; }
            set
            {
                if (vercoseguro != value)
                {
                    vercoseguro = value;
                }
            }
        }

        public bool VerCopago
        {
            get { return vercopago; }
            set
            {
                if (vercopago != value)
                {
                    vercopago = value;
                }
            }
        }

        public bool ImpresionAgrupadorCodigo
        {
            get { return printagrupcodigo; }
            set { printagrupcodigo = printagrupcodigo != value ? value : printagrupcodigo; }
        }

        public Usr_Exportacion()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            try
            {
                tglCoseguro.DataBindings.Add("EditValue", this, nameof(VerCoseguro));
                tglCopago.DataBindings.Add("EditValue", this, nameof(VerCopago));           
                tglImpresionmodo.DataBindings.Add("EditValue", this, nameof(ImpresionAgrupadorCodigo));

            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
