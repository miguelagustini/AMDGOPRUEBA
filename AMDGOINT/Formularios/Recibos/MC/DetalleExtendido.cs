using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Recibos.MC
{
    /// <summary>
    /// SE UTIIZA ESTA CLASE A FIN DE OBTENER RECIBOS ENCABEZADOS Y DETALLES EN UN REGISTRO, PARA PROCESAMIENTO DE INFORMES Y ESTADISTICAS
    /// </summary>
    public class DetalleExtendido : ReciboDet, INotifyPropertyChanged
    {

        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        
        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        
        public string ComprobanteRcTipo { get; set; } = "RC";
        public string ComprobanteRcLetra { get; set; } = "X";
        public int ComprobanteRcPuntoVenta { get; set; } = 10;
        public long ComprobanteRcNumero { get; set; } = 0;
        public string Comprobante
        {
            get
            {
                return ComprobanteRcTipo + " " + ComprobanteRcLetra + ComprobanteRcPuntoVenta.ToString("0000") + ComprobanteRcNumero.ToString("00000000");
            }
        }
        public DateTime FechaEmision { get; set; } = DateTime.Now;        
        public long ReceptorCuit { get; set; } = 0;
        public string ReceptorRazonSocial { get; set; } = "";
        public string ReceptorCuentaCodigo { get; set; } = "";
        public decimal ImporteTotal { get; set; } = 0;
        public decimal ImporteAcreditado { get; set; } = 0;
        public decimal ImporteDebitado { get; set; } = 0;
        public string Observacion { get; set; } = "";        
                        
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public DetalleExtendido() { }

        public DetalleExtendido(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

        //EVENTOS DE PROPERTY CHANGED
        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public new DetalleExtendido Clone()
        {
            DetalleExtendido r = (DetalleExtendido)MemberwiseClone();            
            return r;

        }

        //CLONE CON LISTAS
        public List<DetalleExtendido> Clone(List<DetalleExtendido> lst)
        {
            List<DetalleExtendido> lista = new List<DetalleExtendido>();

            foreach (DetalleExtendido d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

    }
}
