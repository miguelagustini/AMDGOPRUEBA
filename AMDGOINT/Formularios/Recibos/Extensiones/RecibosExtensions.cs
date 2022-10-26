using AMDGOINT.Formularios.Recibos.MC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Recibos.Extensiones
{
    public static class RecibosExtensions
    {
        public static ReciboDet reciboDto(this ReciboEnc recibo)
        {
            ReciboDet rd = new ReciboDet();
            rd.IDEncabezado = recibo.IDRegistro;

            return rd; 
        }
    }
}
