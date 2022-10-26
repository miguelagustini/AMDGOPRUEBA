using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Xrpt_Balance : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_Balance()
        {
            InitializeComponent();
        }

        decimal ImporteActivo = 0;
        decimal ImportePasivo = 0;
        decimal ImportePatrimonio = 0;
        decimal ImporteGastos = 0;
        decimal ImporteRecursos = 0;

        private void calcSaldo_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = GetSum(DataSource as List<CuentasContables.MC.Cuentas>, (e.Row as CuentasContables.MC.Cuentas).IDRegistro);
        }

        public decimal GetSum(IEnumerable<CuentasContables.MC.Cuentas> items, int id)
        {
            var itemsToSum = items.Where(i => i.IDRegistro == id).ToList();
            var oldCount = 0;
            var currentCount = itemsToSum.Count();

            while (currentCount != oldCount)
            {
                oldCount = currentCount;
                var matchedItems = items
                    .Join(itemsToSum, item => item.IDCuentaAgrupadora, sum => sum.IDRegistro, (item, sum) => item)
                    .Except(itemsToSum)
                    .ToList();
                itemsToSum.AddRange(matchedItems);
                currentCount = itemsToSum.Count;
            }

            decimal suma = itemsToSum.Sum(i => i.Saldo);
            //DETERMINO A QUE CUENTA TOTALIZA (ORIGEN)
            switch (items.Where(i => i.IDRegistro == id).FirstOrDefault().IDRegistro)
            {
                case 1: ImporteActivo = suma;  break; //ACTIVO
                case 45: ImportePasivo = suma; break;  //PASIVO
                case 71: ImportePatrimonio = suma; break;  //PATRIMONIO
                case 77: ImporteRecursos = suma; break;  //RECURSOS
                case 93: ImporteGastos = suma; break;  //GASTOS         
                    //Y CUENTAS DE ORDEN??
            }
            
            return suma;
        }

        private void calcNodesQ_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = GetCantidades(DataSource as List<CuentasContables.MC.Cuentas>, (e.Row as CuentasContables.MC.Cuentas).IDRegistro);
        }

        public int GetCantidades(IEnumerable<CuentasContables.MC.Cuentas> items, int id)
        {
            var itemsToSum = items.Where(i => i.IDRegistro == id).ToList();
            var oldCount = 0;
            var currentCount = itemsToSum.Count();

            while (currentCount != oldCount)
            {
                oldCount = currentCount;
                var matchedItems = items
                    .Join(itemsToSum, item => item.IDCuentaAgrupadora, sum => sum.IDRegistro, (item, sum) => item)
                    .Except(itemsToSum)
                    .ToList();
                itemsToSum.AddRange(matchedItems);
                currentCount = itemsToSum.Count;
            }

            return itemsToSum.Count();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = !(bool)InlcuirCuentasCero.Value && Convert.ToDecimal(GetCurrentColumnValue("calcSaldo")) == 0;
        }

        private void calcRecursos_GetValue(object sender, GetValueEventArgs e)
        {
            try
            {
                List<CuentasContables.MC.Cuentas>  cuentas = DataSource as List<CuentasContables.MC.Cuentas>;
                decimal _calc = (decimal)cuentas?.Where(w => w.CuentaOrigen == 4)?.Sum(s => s.Saldo);

                e.Value = Math.Abs(_calc);

            }
            catch (Exception)
            {

            }
        }

        private void calcGastos_GetValue(object sender, GetValueEventArgs e)
        {
            try
            {
                List<CuentasContables.MC.Cuentas> cuentas = DataSource as List<CuentasContables.MC.Cuentas>;                
                e.Value = cuentas.Count > 0 ? cuentas?.Where(w => w.CuentaOrigen == 5)?.Sum(s => s.Saldo) : 0;
            }
            catch (Exception)
            {

            }
        }

        private void calcDebe_GetValue(object sender, GetValueEventArgs e)
        {
            List<CuentasContables.MC.Cuentas> cuentas = DataSource as List<CuentasContables.MC.Cuentas>;
                     
            decimal _suma = (ImporteActivo > 0 ? Math.Abs(ImporteActivo) : 0) + (ImportePasivo > 0 ? Math.Abs(ImportePasivo) : 0) + (ImportePatrimonio > 0 ? Math.Abs(ImportePatrimonio) : 0)
                + (ImporteRecursos > 0 ? Math.Abs(ImporteRecursos) : 0) + (ImporteGastos > 0 ? Math.Abs(ImporteGastos) : 0);

            e.Value = _suma;         
        }

        private void calcHaber_GetValue(object sender, GetValueEventArgs e)
        {
            List<CuentasContables.MC.Cuentas> cuentas = DataSource as List<CuentasContables.MC.Cuentas>;

            decimal _suma = (ImporteActivo < 0 ? Math.Abs(ImporteActivo) : 0) + (ImportePasivo < 0 ? Math.Abs(ImportePasivo) : 0) + (ImportePatrimonio < 0 ? Math.Abs(ImportePatrimonio) : 0)
              + (ImporteRecursos < 0 ? Math.Abs(ImporteRecursos) : 0) + (ImporteGastos < 0 ? Math.Abs(ImporteGastos) : 0);

            e.Value = _suma*-1;

        }
    }
}
