using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    class FacturasStruct
    {        
    }

    public class FacturasEmitEncStruct
    {
        public long ID_Registro { get; set; } = 0;
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; } = "";
        public string Letra { get; set; } = "";
        public int PuntoVenta { get; set; } = 0;
        public long Numero { get; set; } = 0;
        public bool Anulada { get; set; } = false;
        public int ID_Profesional { get; set; } = 0;
        public string CodigoProf { get; set; } = "";
        public string NombreProf { get; set; } = "";
        public long CuitProf { get; set; } = 0;
        public string IvaProf { get; set; } = "";
        public int ID_Prestataria { get; set; } = 0;
        public string CodigoPres { get; set; } = "";
        public string NombrePres { get; set; } = "";
        public long CuitPres { get; set; } = 0;
        public string IvaPres { get; set; } = "";
        public decimal PorcIvaPres { get; set; } = 0;
        public string Guid { get; set; } = "";
        public decimal Neto { get; set; } = 0;
        public decimal Neto21 { get; set; } = 0;
        public decimal Neto105 { get; set; } = 0;
        public decimal NoGravado { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Iva21 { get; set; } = 0;
        public decimal Iva105 { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public string EstadoAf { get; set; } = "";
        public string CaeNroAf { get; set; } = "";
        public string BarrasAf { get; set; } = "";        
        public string VtoCaeAf { get; set; }
        public string ObservAf { get; set; } = "";
        public string Comprobante { get; set; } = "";
        public string EmailProf { get; set; } = "";
        public string EmailPrestat { get; set; } = "";
    }

    public class FacturasEmitdetStruct
    {
        public long IDRegistro { get; set; } = 0;
        public long IDEncabezado { get; set; } = 0;
        public DateTime Fecha { get; set; } = new DateTime();
        public string Practica { get; set; } = "";
        public string PracticaNom { get; set; } = "";
        public string Funcion { get; set; } = "";
        public long DocuPaci { get; set; } = 0;
        public string NombrePaci { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal NoGravado { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal IvaPorc { get; set; } = 0;
        public decimal Total { get; set; } = 0;                        
    }
}
