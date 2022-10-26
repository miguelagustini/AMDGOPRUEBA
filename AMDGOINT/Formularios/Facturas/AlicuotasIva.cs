using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas
{
    public class AlicuotasIva
    {

        private decimal valor = 0;

        public decimal Valor
        {
            get { return valor; }
            set { valor = valor != value ? value : valor; }
        }


        public List<AlicuotasIva> GetAlicuotas()
        {
            List<AlicuotasIva> alicuotas = new List<AlicuotasIva>();


            alicuotas.Add(new AlicuotasIva { Valor = 0 });
            alicuotas.Add(new AlicuotasIva { Valor = (decimal)10.5 });
            alicuotas.Add(new AlicuotasIva { Valor = 21 });

            return alicuotas;
        }

    }
}
