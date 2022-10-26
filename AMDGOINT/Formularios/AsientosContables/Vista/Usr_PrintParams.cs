using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Usr_PrintParams : XtraUserControl
    {
        public DateTime FechaDesde { get; set; } = DateTime.Today;
        public DateTime FechaHasta { get; set; } = DateTime.Today;
        public int IDPlanCuenta { get; set; } = 0;
        public int IDPlanSubCuenta { get; set; } = 0;        
        public bool IncluirCuentasCero { get; set; } = true;
        public string Ejercicio { get; set; } = "A";
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private List<CuentasContables.MC.Cuentas> Cuentasenc { get; set; } = new List<CuentasContables.MC.Cuentas>();

        public Usr_PrintParams()
        {
            InitializeComponent();

            datDesde.Properties.MinValue = DateTime.MinValue;
            datDesde.Properties.NullText = string.Empty;

            datHasta.Properties.MinValue = DateTime.MinValue;
            datHasta.Properties.NullText = string.Empty;
            
            CargaCombos();
            SetBindings();
            
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible && !Disposing)
            {
                datDesde.Focus();
            }
            
        }

        private void SetBindings()
        {            
            datDesde.DataBindings.Add("EditValue", this, nameof(FechaDesde));
            datHasta.DataBindings.Add("EditValue", this, nameof(FechaHasta));
            tglIncluirCuentaCero.DataBindings.Add("EditValue", this, nameof(IncluirCuentasCero));
            tglEjercicio.DataBindings.Add("EditValue", this, nameof(Ejercicio));
            cmbPlanCuenta.DataBindings.Add("EditValue", this, nameof(IDPlanCuenta));
            cmbPlanSubCuenta.DataBindings.Add("EditValue", this, nameof(IDPlanSubCuenta));
        }

        private void CargaCombos(short cmb = 0, object sndr = null)
        {
            try
            {

                //PLAN DE CUENTAS
                if (cmb == 0 || cmb == 1)
                {
                    Cuentasenc.Clear();

                    //planesSeleccionables
                    CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                    Cuentasenc.AddRange(ctas.GetRegistros().Where(w => w.Estado && w.Seleccionable).ToList());
                                        
                    cmbPlanCuenta.Properties.DataSource = null;
                    cmbPlanCuenta.Properties.DataSource = Cuentasenc;

                    
                }

                if (cmb == 2)
                {

                    int _cuentap = 0;
                    int.TryParse(Convert.ToString(cmbPlanCuenta.EditValue != null ? cmbPlanCuenta.EditValue : string.Empty) , out _cuentap);
                    cmbPlanSubCuenta.Properties.DataSource = null;
                    List<CuentasContables.MC.SubCuentas> lst = Cuentasenc.SelectMany(s => s.SubCuentas).Where(w => w.Estado && w.IDEncabezado == _cuentap).ToList();

                    cmbPlanSubCuenta.Properties.DataSource = lst;

                    if (sndr != null)
                    {
                        SearchLookUpEdit srch = sndr as SearchLookUpEdit;
                        srch.Properties.DataSource = null;
                        srch.Properties.DataSource = lst;
                    }
                }



            }
            catch (Exception e)
            {
                //ctrls.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                //return;
            }
        }

        private void cmbPlanCuenta_EditValueChanged(object sender, EventArgs e)
        {
            CargaCombos(2);
        }
    }
}
