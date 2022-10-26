using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.CuentasContables.Vista
{
    public partial class Xtra_PlanCtas : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_PlanCtas()
        {
            InitializeComponent();
        }

        private void calcNodesQ_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = GetCantidades(DataSource as List<MC.Cuentas>, (e.Row as MC.Cuentas).IDRegistro);
        }

        public int GetCantidades(IEnumerable<MC.Cuentas> items, int id)
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
    }
}
