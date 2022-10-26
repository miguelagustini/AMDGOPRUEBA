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
    public class MovimientosDetalles
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE        
        public long ComprobanteID { get; set; } = 0;
        public long FacturaID { get; set; } = 0;
        public long ReciboEncID { get; set; } = 0; 
        public string ComprobanteTipo { get; set; } = "";
        public string ComprobanteLetra { get; set; } = "";
        public int ComprobantePuntoVenta { get; set; } = 0;
        public long ComprobanteNumero { get; set; } = 0;
        public string Comprobante { get { return $"{ComprobanteTipo} {ComprobanteLetra} {ComprobantePuntoVenta.ToString("0000")}-{ComprobanteNumero.ToString("00000000")}"; } }
        public string Concepto { get; set; } = "";
        public string Periodo { get; set; } = "";
        public DateTime FechaEmision { get; set; } = DateTime.MinValue;
        public decimal ComprobanteImporte { get; set; } = 0;
        public decimal ImporteDebe { get { return ComprobanteTipo == "RC" || ComprobanteTipo == "NC" || ComprobanteTipo == "NCE" ? ComprobanteImporte : 0; } }
        public decimal ImporteHaber { get { return ComprobanteTipo != "RC" && ComprobanteTipo != "NC" && ComprobanteTipo != "NCE" ? ComprobanteImporte : 0; } }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public MovimientosDetalles() { }

        public MovimientosDetalles(SqlConnection conexion)
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
        public MovimientosDetalles Clone()
        {
            MovimientosDetalles d = (MovimientosDetalles)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<MovimientosDetalles> Clone(List<MovimientosDetalles> lst)
        {
            List<MovimientosDetalles> lista = new List<MovimientosDetalles>();

            foreach (MovimientosDetalles d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<MovimientosDetalles> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<MovimientosDetalles> lista = new List<MovimientosDetalles>();

                string c = $"SELECT " +
                           $" 0 ReciboEncID," +
                           $" FNC.Fecha AS FechaEmision," +
                           $" FNC.Periodo," +
                           $" FR.ID_NotaCredito AS ComprobanteID," +
                           $" FR.ID_Factura as FacturaID, " +
                           $" FNC.TipoComprobante AS ComprobanteTipo," +
                           $" FNC.Letra AS ComprobanteLetra," +
                           $" FNC.PuntoVenta AS ComprobantePuntoVenta," +
                           $" FNC.Numero AS ComprobanteNumero," +
                           $" FNC.Total AS ComprobanteImporte," +
                           $" ISNULL(CO.Concepto, '') AS Concepto" +
                           $" FROM FACTPRESREL FR" +
                           $" LEFT OUTER JOIN FACTPRESENC FNC ON(FNC.ID_Registro = FR.ID_NotaCredito)" +
                           $" LEFT OUTER JOIN CONCEPTOSCOMPROBANTES CO ON(CO.IDRegistro = FNC.IDConcepto)" +
                           $" WHERE FNC.EstadoAf = 'A'" +
                           $" UNION" +
                           $" SELECT" +
                           $" 0 ReciboEncID," +
                           $" FND.Fecha AS FechaEmision," +
                           $" FND.Periodo," +
                           $" FR.ID_NotaDebito AS ComprobanteID," +
                           $" FR.ID_Factura as FacturaID, " +
                           $" FND.TipoComprobante AS ComprobanteTipo," +
                           $" FND.Letra AS ComprobanteLetra," +
                           $" FND.PuntoVenta AS ComprobantePuntoVenta," +
                           $" FND.Numero AS ComprobanteNumero," +
                           $" FND.Total AS ComprobanteImporte," +
                           $" ISNULL(CO.Concepto, '') AS Concepto" +
                           $" FROM FACTPRESREL FR" +
                           $" LEFT OUTER JOIN FACTPRESENC FND ON(FND.ID_Registro = FR.ID_NotaDebito)" +
                           $" LEFT OUTER JOIN CONCEPTOSCOMPROBANTES CO ON(CO.IDRegistro = FND.IDConcepto)" +
                           $" WHERE FND.EstadoAf = 'A'" +
                           $" UNION" +
                           $" SELECT" +
                           $" RE.IDRegistro AS ReciboEncID," +
                           $" RE.FechaEmision," +
                           $" RE.PeriodoPago as Periodo," +
                           $" RE.IDRegistro AS ComprobanteID," +
                           $" ISNULL(IIF(FR.ID_Factura > 0, FR.ID_Factura, RD.ComprobanteAmdgoID) ,0) AS FacturaID," +
                           $" RE.ComprobanteTipo, " +
                           $" RE.ComprobanteLetra, " +
                           $" RE.ComprobantePuntoVenta, " +
                           $" RE.ComprobanteNumero," +
                           $" ISNULL(RD.ImporteCancelado, 0) as ComprobanteImporte," +
                           $" ISNULL(RD.Descripcion, '') AS Concepto" +
                           $" FROM RECIBOSENC RE" +
                           $" LEFT OUTER JOIN RECIBOSDET RD ON(RD.IDEncabezado = RE.IDRegistro)" +
                           $" LEFT OUTER JOIN FACTPRESREL FR ON(FR.ID_NotaDebito = RD.ComprobanteAmdgoID)" +
                           $" WHERE RD.ComprobanteAmdgoID > 0";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<MovimientosDetalles>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<MovimientosDetalles>();
            }
        }

        #endregion

    }
}
