using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Prestatarias.MC
{
    public class MovimientosEncabezado
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        public int PrestatariaID { get; set; } = 0;
        public int PrestatariaCuentaID { get; set; } = 0;
        public string PrestatariaCuentaCodigo { get; set; } = "";
        public long ComprobanteID { get; set; } = 0;
        public string ComprobanteTipo { get; set; } = "";
        public string ComprobanteLetra { get; set; } = "";
        public int ComprobantePuntoVenta { get; set; } = 0;
        public long ComprobanteNumero { get; set; } = 0;
        public string Comprobante { get { return $"{ComprobanteLetra} {ComprobantePuntoVenta.ToString("0000")}-{ComprobanteNumero.ToString("00000000")}"; }  } 
        public string Concepto { get; set; } = "";
        public string Periodo { get; set; } = "";
        public DateTime FechaEmision { get; set; } = DateTime.MinValue;
        public decimal Importe { get; set; } = 0;        
        public decimal ImporteDebe { get { return Detalles.Sum(s => s.ImporteDebe); } }
        public decimal ImporteHaber { get { return ComprobanteTipo == "FC" || ComprobanteTipo == "FCE" ? (Importe + Detalles.Sum(s => s.ImporteHaber)) : 0; } }
        public decimal Saldo { get { return ImporteHaber - ImporteDebe; } }
        public virtual List<MovimientosDetalles> Detalles { get; set; } = new List<MovimientosDetalles>();

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public MovimientosEncabezado() { }

        public MovimientosEncabezado(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //NOTIFY
        #region NOTIFY

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public MovimientosEncabezado Clone()
        {
            MovimientosEncabezado d = (MovimientosEncabezado)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<MovimientosEncabezado> Clone(List<MovimientosEncabezado> lst)
        {
            List<MovimientosEncabezado> lista = new List<MovimientosEncabezado>();

            foreach (MovimientosEncabezado d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<MovimientosEncabezado> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<MovimientosEncabezado> lista = new List<MovimientosEncabezado>();
                
                string c = $"SELECT PD.ID_Prestataria AS PrestatariaID, PD.ID_Registro AS PrestatariaCuentaID, PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" FE.ID_Registro AS ComprobanteID, FE.TipoComprobante as ComprobanteTipo, FE.Letra as ComprobanteLetra, FE.PuntoVenta as ComprobantePuntoVenta," +
                           $" FE.Numero as ComprobanteNumero, ISNULL(CO.Concepto, '') AS Concepto," +
                           $" FE.Periodo, FE.Fecha AS FechaEmision," +
                           $" FE.Total AS Importe" +
                           $" FROM PRESTDETALLES PD" +
                           $" LEFT OUTER JOIN FACTPRESENC FE ON(FE.ID_PrestDetalle = PD.ID_Registro)" +
                           $" LEFT OUTER JOIN CONCEPTOSCOMPROBANTES CO ON(CO.IDRegistro = FE.IDConcepto)" +
                           $" WHERE FE.ID_Registro IS NOT NULL AND (FE.TipoComprobante = 'FC' OR FE.TipoComprobante = 'FCE')";
                          /* $" UNION" +
                           $" SELECT  PD.ID_Prestataria AS PrestatariaID, PD.ID_Registro AS PrestatariaCuentaID, PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" RE.IDRegistro AS ComprobanteID, RE.ComprobanteTipo, RE.ComprobanteLetra, RE.ComprobantePuntoVenta, RE.ComprobanteNumero," +
                           $" '' AS Concepto, RE.PeriodoPago AS Periodo, RE.FechaEmision," +
                           $" RE.ImporteTotal AS Importe" +
                           $" FROM PRESTDETALLES PD" +
                           $" LEFT OUTER JOIN RECIBOSENC RE ON(RE.IDPrestatariaCuenta = PD.ID_Registro)" +
                           $" WHERE RE.IDRegistro IS NOT NULL"*/;

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<MovimientosEncabezado>(rdr));
                }

                #region DETALLES DE COMPROBANTES
                MovimientosDetalles detcls = new MovimientosDetalles(SqlConnection);
                List<MovimientosDetalles> det = detcls.GetRegistros();

                /*foreach (MovimientosEncabezado en in lista)
                {
                    if (en.ComprobanteTipo == "RC")
                    {
                        List<long> grpfact = det.Where(w => w.ReciboEncID == en.ComprobanteID).GroupBy(g => g.FacturaID).Select(s => s.First().FacturaID).ToList();                        
                        if (grpfact != null) { en.Detalles.AddRange(det.Where(w => grpfact.Contains(w.FacturaID))); }
                        
                    }
                    else { en.Detalles.AddRange(det.Where(w => w.FacturaID == en.ComprobanteID)); }
                }*/

                lista.ForEach(f => f.Detalles.AddRange(det.Where(w => w.FacturaID == f.ComprobanteID)));
                
                #endregion


                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<MovimientosEncabezado>();
            }
        }

        #endregion

    }
}
