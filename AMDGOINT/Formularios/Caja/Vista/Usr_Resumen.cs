using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;
using AMDGOINT.Formularios.Caja.MC;

namespace AMDGOINT.Formularios.Caja.Vista
{
    public partial class Usr_Resumen : UserControl
    {
        private Controles ctrls = new Controles();

        public CajaSaldoArrastre SaldoArrastrecls { get; set; } = new CajaSaldoArrastre();
        private List<CajaMovimientos> _movimientos = new List<CajaMovimientos>();
        public List<CajaMovimientos> Movimientos
        {
            get { return _movimientos; }
            set { _movimientos = _movimientos != value ? value : _movimientos; SetBindings(); }
        } 
    
        public Usr_Resumen()
        {
            InitializeComponent();                        

        }
        
        //EJECUTO LA BUSQUEDA DE REGISTROS
        private void SetBindings()
        {
            try
            {
                SaldoArrastrecls.Movimientos.Clear();
                SaldoArrastrecls.Movimientos.AddRange(Movimientos.Where(w => w.OrdenPagoDetalleID == 0).ToList());
                SaldoArrastrecls.setSaldoArrastre();
                
                txtEfectivo.EditValue = SaldoArrastrecls.SaldoEfectivo;
                txtTransferencias.EditValue = SaldoArrastrecls.SaldoTransferencias;
                txtCheques.EditValue = SaldoArrastrecls.SaldoCheques;

                txtSaldoArrastre.EditValue = SaldoArrastrecls.SaldoArrastre;
                
                txtSaldoDia.EditValue = SaldoArrastrecls.SaldoDia;
                txtSaldoActual.EditValue = SaldoArrastrecls.SaldoActual;
            }
            catch (Exception e)
            {
              
            }
        }
    }
}
