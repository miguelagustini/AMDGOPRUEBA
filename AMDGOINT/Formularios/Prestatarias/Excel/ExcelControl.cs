using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Prestatarias.Excel
{
    class ExcelControl
    {
    }

    //ALMACENO LAS FACTURAS OBTENIDAS POR AMDGO
    class Encabezado
    {
        public string ID_Registro { get; set; } = Guid.NewGuid().ToString();
        public string Epoca { get; set; } = "";
        public string CodProf { get; set; } = "";
        public string NombreProf { get; set; } = "";
        public string IvaProf { get; set; } = "";
        public string Comprobante { get; set; } = "";
        public decimal Neto { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public decimal Pagado { get; set; } = 0;
        public decimal Diferencia { get; set; } = 0;

    }

    //ALMACENO TODAS LAS FACTURAS DEL EXCEL ENVIADO POR LA RPESTATARIA
    class Detalle
    {
        public string ID_Registro { get; set; } = Guid.NewGuid().ToString();
        public string ID_Encabezado { get; set; } = "";
        public string Comprobante { get; set; } = "";
        public decimal Total { get; set; } = 0;
        public decimal Pago { get; set; } = 0;
        public decimal Correcion { get; set; } = 0;
    }
}
