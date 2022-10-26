using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class ComprobantesRel
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "AmdgoInterno.dbo.FACTAMBUREL";

        private long _idregistro = 0;
        private long _idnotacredito = 0;
        private long _idnotadebito = 0;
        private long _idfactura = 0;
        private int _pvtand = 0;
        private long _numerond = 0;
        private decimal _totalnd = 0;
        private string _letrand = "";
        private int _pvtanc = 0;
        private long _numeronc = 0;
        private decimal _totalnc = 0;
        private string _letranc = "";
        private DateTime _fechand = DateTime.MinValue;
        private DateTime _fechanc = DateTime.MinValue;
        private string _comprobantemanual = "";        

        public long IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public long IDNotaCredito
        {
            get { return _idnotacredito; }
            set { _idnotacredito = _idnotacredito != value ? value : _idnotacredito; }
        }

        public long IDNotaDebito
        {
            get { return _idnotadebito; }
            set { _idnotadebito = _idnotadebito != value ? value : _idnotadebito; }
        }

        public long IDFactura
        {
            get { return _idfactura; }
            set { _idfactura = _idfactura != value ? value : _idfactura; }
        }

        public string ComprobanteManual
        {
            get { return _comprobantemanual; }
            set { _comprobantemanual = _comprobantemanual != value.Trim() ? value.Trim() : _comprobantemanual; }
        }

        public DateTime FechaND
        {
            get { return _fechand; }
            set { _fechand = _fechand != value ? value : _fechand; }
        }

        public string LetraND
        {
            get { return _letrand; }
            set { _letrand = _letrand != value.Trim() ? value.Trim() : _letrand; }
        }

        public int PuntoVentaND
        {
            get { return _pvtand; }
            set { _pvtand = _pvtand != value ? value : _pvtand; }
        }

        public long NumeroND
        {
            get { return _numerond; }
            set { _numerond = _numerond != value ? value : _numerond; }
        }

        public decimal TotalND
        {
            get { return _totalnd; }
            set { _totalnd = _totalnd != value ? value : _totalnd; }
        }

        public string LetraNC
        {
            get { return _letranc; }
            set { _letranc = _letranc != value.Trim() ? value.Trim() : _letranc; }
        }

        public int PuntoVentaNC
        {
            get { return _pvtanc; }
            set { _pvtanc = _pvtanc != value ? value : _pvtanc; }
        }

        public long NumeroNC
        {
            get { return _numeronc; }
            set { _numeronc = _numeronc != value ? value : _numeronc; }
        }

        public decimal TotalNC
        {
            get { return _totalnc; }
            set { _totalnc = _totalnc != value ? value : _totalnc; }
        }

        public DateTime FechaNC
        {
            get { return _fechanc; }
            set { _fechanc = _fechanc != value ? value : _fechanc; }
        }

        public string Comprobante
        {
            get
            {
                if (IDNotaCredito > 0)
                {
                    return $"NC {LetraNC} {PuntoVentaNC.ToString("0000")}-{NumeroNC.ToString("00000000")}";
                }
                else if (IDNotaDebito > 0)
                {
                    return $"ND {LetraND} {PuntoVentaND.ToString("0000")}-{NumeroND.ToString("00000000")}";
                }
                else
                {
                    return ComprobanteManual;
                }

            }

        }

        public decimal Total
        {
            get
            {
                if (IDNotaCredito > 0)
                {
                    return TotalNC;
                }
                else 
                {
                    return TotalND;
                }
            }
        }

        public DateTime Fecha
        {
            get
            {
                if (IDNotaCredito > 0)
                {
                    return FechaNC;
                }
                else
                {
                    return FechaND;
                }
            }
        }

        public long IDComprobante
        {
            get
            {
                if (IDNotaCredito > 0) { return IDNotaCredito; } else  { return IDNotaDebito; }
            }

        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
                
        //DE IGUALACION PARA ENVIO BD        
        public long ID_NotaCredito { get { return IDNotaCredito; } }
        public long ID_NotaDebito { get { return IDNotaDebito; } }
        public long ID_Factura { get { return IDFactura; } }


        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ComprobantesRel() { }

        public ComprobantesRel(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion
             
        #region PROPERTYCHANGED
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
        public ComprobantesRel Clone()
        {
            ComprobantesRel d = (ComprobantesRel)MemberwiseClone();            
            return d;
        }

        //CLONE CON LISTAS
        public List<ComprobantesRel> Clone(List<ComprobantesRel> lst)
        {
            List<ComprobantesRel> lista = new List<ComprobantesRel>();

            foreach (ComprobantesRel d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ComprobantesRel> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ComprobantesRel> lista = new List<ComprobantesRel>();

                string c = $"SELECT T1.ID_Registro AS IDRegistro, T1.ID_NotaCredito AS IDNotaCredito, T1.ID_NotaDebito AS IDNotaDebito," +
                           $" ID_Factura AS IDFactura, Comprobante AS ComprobanteManual, " +
                           $" ND.Letra AS LetraND, ND.PuntoVenta AS PuntoVentaND, ND.Numero as NumeroND, ND.Total AS TotalND, ND.Fecha as FechaND," +
                           $" NC.Letra AS LetraNC, NC.PuntoVenta AS PuntoVentaNC, NC.Numero as NumeroNC, NC.Total AS TotalNC, NC.Fecha as FechaNC" +                           
                           $" FROM {tablaname} T1" +
                           $" LEFT OUTER JOIN FACTAMBUENC NC ON(NC.ID_Registro = T1.ID_NotaCredito AND NC.EstadoAf = 'A')" +
                           $" LEFT OUTER JOIN FACTAMBUENC ND ON(ND.ID_Registro = T1.ID_NotaDebito AND ND.EstadoAf = 'A')";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    ComprobantesRel a = new ComprobantesRel();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();
                
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ComprobantesRel>();
            }
        }

        #endregion


        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0)
            {
                return Alta();
            }            
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();
                        
            campos.Add("ID_NotaCredito");
            campos.Add("ID_NotaDebito");
            campos.Add("ID_Factura");
            
            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //CONEXION
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();

                //INICIO DEL INSERT
                query.Append($"INSERT INTO {tablaname} (");

                //AGREGO LOS CAMPOS
                foreach (string c in campos)
                {
                    query.Append($"{c},");
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                query.Replace(",", ")", query.Length - 1, 1);

                //AGREGO VALORES AL BULDIER
                query.Append(" VALUES (");

                //CREO TANTO PARAMETROS COMO CAMPOS HAY
                for (int i = 0; i < campos.Count; i++)
                {
                    query.Append($"@p{i.ToString()},");
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                query.Replace(",", ")", query.Length - 1, 1);


                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                short paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null)); }

                    paramnro++;
                }
                //EJECUTO LA INSTRUCCION
                cmd.ExecuteNonQuery();                               
                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Alta.\n{e.Message}");
                return retorno;
            }

        }             

        #endregion
    }
}
