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

namespace AMDGOINT.Formularios.MesaEntrada.MC
{
    public class Gestion : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "DOCUMENTALGESTION";
        
        private int _idregistro = 0;
        private int _idprofesionalcuenta = 0;
        private string _nrointernacion = "";
        private string _nrobusqueda = "";
        private byte _idaccion = 0;
        private string _acciondescr = "";
        private DateTime _fechaaccion = DateTime.Now;
        private string _observacion = "";
        private bool _borrareg = false;

        public string IDLocal { get; set; } = Guid.NewGuid().ToString();

        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public int IDProfesionalCuenta
        {
            get { return _idprofesionalcuenta; }
            set { _idprofesionalcuenta = _idprofesionalcuenta != value ? value : _idprofesionalcuenta; }
        }

        public string NroInternacion
        {
            get { return _nrointernacion; }
            set { _nrointernacion = _nrointernacion != value.Trim() ? value.Trim() : _nrointernacion; }
        }

        public string NroBusqueda
        {
            get { return _nrobusqueda; }
            set { _nrobusqueda = _nrobusqueda != value.Trim() ? value.Trim() : _nrobusqueda; }
        }

        public byte AccionID
        {
            get { return _idaccion; }
            set { _idaccion = _idaccion != value ? value : _idaccion; }
        }

        public string AccionDescripcion
        {
            get { return _acciondescr; }
            set { _acciondescr = _acciondescr != value.Trim() ? value.Trim() : _acciondescr; }
        }

        public DateTime AccionFecha
        {
            get { return _fechaaccion; }
            set { _fechaaccion = _fechaaccion != value ? value : _fechaaccion; }
        }

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public bool _BorraRegistro
        {
            get { return _borrareg; }
            set { _borrareg = _borrareg != value ? value : _borrareg; }
        }

        public short IDUsuModif { get => Convert.ToInt16(glb.GetIdUsuariolog()); }

        public DateTime TimeModif { get => DateTime.Now; }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Gestion() { }

        public Gestion(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region EVENTOS DE LA CLASE

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        //CLONACION
        #region CLONE

        //CLONE 
        public Gestion Clone()
        {
            Gestion d = (Gestion)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Gestion> Clone(List<Gestion> lst)
        {
            List<Gestion> lista = new List<Gestion>();

            foreach (Gestion d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Gestion> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Gestion> lista = new List<Gestion>();

                string c = $"SELECT DG.IDRegistro, DG.IDLocal, DG.IDProfesionalCuenta, DG.NroInternacion, DG.NroBusqueda, DG.AccionID," +
                           $" DA.Descripcion AS AccionDescripcion, DG.AccionFecha, DG.Observacion" +
                           $" FROM {tablaname} DG" +
                           $" LEFT OUTER JOIN DOCUMENTALACC DA ON(DA.IDRegistro = DG.AccionID)";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Gestion a = new Gestion();

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
                return new List<Gestion>();
            }
        }

        public Gestion GetRegistrosbyGuid()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                Gestion registro = new Gestion();

                string c = $"SELECT DG.IDRegistro, DG.IDLocal, DG.IDProfesionalCuenta, DG.NroInternacion, DG.NroBusqueda, DG.AccionID, DA.Descripcion AS AccionDescripcion," +
                           $" DG.AccionFecha, DG.Observacion" +
                           $" FROM {tablaname} DG" +
                           $" LEFT OUTER JOIN DOCUMENTALACC DA ON(DA.IDRegistro = DG.AccionID)" +
                           $" WHERE DG.IDLocal = '{IDLocal}'";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(registro, r[co]); }
                    }                    
                }

                tbl.Dispose();

                return registro;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new Gestion();
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0 && !_BorraRegistro)
            {
                return Alta();
            }
            else if (IDRegistro > 0)
            {
                return Modificacion();
            }
            else
            {
                retorno.Add(0, $"{GetType().Name}. No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("IDLocal");
            campos.Add("IDProfesionalCuenta");
            campos.Add("NroInternacion");
            campos.Add("NroBusqueda");
            campos.Add("AccionID");
            campos.Add("AccionFecha");
            campos.Add("Observacion");
            campos.Add("IDUsuModif");
            campos.Add("TimeModif");
                                          
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

        //MODIFICACION DE REGISTROS DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Modificacion()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (IDRegistro <= 0)
                {
                    retorno.Add(0, "Sin id de registro para modificación.");
                    return retorno;
                }

                //SI ESTA MARCADO PARA ELIMINACION
                if (_BorraRegistro)
                {
                    var e = Eliminacion();
                    func.PreparaRetorno(retorno, e);
                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();

                //INICIO DEL INSERT
                query.Append($"UPDATE {tablaname} SET ");

                //AGREGO LOS CAMPOS A ACTUALZIAR 
                short paramnro = 0;
                foreach (string c in campos)
                {
                    query.Append($"{c} = @p{paramnro.ToString()},");
                    paramnro++;
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                query.Replace(",", "", query.Length - 1, 1);

                //AGREGO AGREGO CLAUSULA WHERE
                query.Append($" WHERE (IDRegistro = {IDRegistro})");

                //CONEXION

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this)); }

                    paramnro++;
                }

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Modificación.\n{e.Message}");
                return retorno;
            }

        }
        
        private Dictionary<short, string> Eliminacion()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (IDRegistro <= 0)
                {
                    retorno.Add(0, "Sin id de registro para eliminacion.");
                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();

                //INICIO DEL INSERT
                query.Append($"DELETE FROM {tablaname} WHERE IDRegistro = {IDRegistro}");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, e.Message);
                return retorno;
            }

        }

        #endregion


        #endregion
    }
}
