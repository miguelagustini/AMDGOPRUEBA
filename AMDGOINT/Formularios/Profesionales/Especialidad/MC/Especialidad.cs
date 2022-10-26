using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Profesionales.Especialidad.MC
{
    public class Especialidad : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "ESPECIALIDADESMED";

        private short idregistro = 0;        
        private string descripcion = "";

        public short IDRegistro
        {
            get { return idregistro; }
            set
            {
                if (idregistro != value)
                {
                    idregistro = value;
                }
            }
        }
               
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (descripcion != value.Trim())
                {
                    descripcion = value.Trim();

                }
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Especialidad() { }

        public Especialidad(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //EVENTOS
        #region EVENTOS Y  METODOS

        //PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #region CLONACION
        //CLONE 
        public Especialidad Clone()
        {
            Especialidad d = (Especialidad)MemberwiseClone();

            return d;

        }

        //CLONE CON LISTAS
        public List<Especialidad> Clone(List<Especialidad> lst)
        {
            List<Especialidad> lista = new List<Especialidad>();

            foreach (Especialidad d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        #region CONSULTA DE DATOS
        
        //RETORNO LISTA 
        public List<Especialidad> GetRegistros()
        {
            try
            {
                List<Especialidad> lista = new List<Especialidad>();

                string c = $"SELECT ID_Registro AS IDRegistro, Descripcion FROM {tablaname}";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Especialidad a = new Especialidad();

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
                ctrl.MensajeInfo($"Ocurrió un error al consultar las especialidades.\n{e.Message}", 0);
                return new List<Especialidad>();
            }
        }

        //CONSULTO SI EXISTE EL REGISTRO POR DESCRIPCION (EVITA REPETIDOS)
        public int Existeregbydesc()
        {
            int retorno = 0;

            try
            {
                string c = $"SELECT ID_Registro FROM {tablaname} WHERE Descripcion = '{Descripcion}' AND ID_Registro <> {IDRegistro}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    retorno = Convert.ToInt32(r["ID_Registro"]);
                }

                return retorno;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion
        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0) { return Alta(); }
            else if (IDRegistro > 0) { return Modificacion(); }
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("Descripcion");            

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //DEFINO CONNEXION EN CASO DE NO HABER UNA
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

                //CONEXION                
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                short paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this, null)) == DateTime.MinValue)
                    { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null)); }

                    paramnro++;
                }

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();

                retorno.Add(1, "OK");

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, e.Message);
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

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = new List<string>(RetornaCampos());
                //campos.Remove("ID_UsuNew");

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
                query.Append($" WHERE (ID_Registro = {IDRegistro})");

                //CONEXION                
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this, null)) == DateTime.MinValue)
                    { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this)); }

                    paramnro++;
                }

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();

                retorno.Add(1, "OK");

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, e.Message);
                return retorno;
            }

        }

        #endregion

        #endregion

    }
}
