using DevExpress.XtraEditors;
using System;

namespace AMDGOINT.Formularios.Profesionales.SaldosNegativos
{
    public partial class Usr_ParametrosBusqueda : XtraUserControl
    {
        public DateTime FechaHasta { get; set; } = DateTime.Today;
        
        public Usr_ParametrosBusqueda()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            datFecha.DataBindings.Add("EditValue", this, nameof(FechaHasta));            
        }

    }
}
