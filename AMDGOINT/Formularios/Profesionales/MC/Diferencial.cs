using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Profesionales.MC
{
    public class Diferencial
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "[AmdgoInterno].[dbo].[PROFDIFERENCIAL]";
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private short _idregistro = 0;
        private int _idprofesional = 0;
        private DateTime _fechainicio = DateTime.MinValue;
        private DateTime _fechafin = DateTime.MinValue;
        private string _observacion = "";

        public short IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public int IDProfesional
        {
            get { return _idprofesional; }
            set { _idprofesional = _idprofesional != value ? value : _idprofesional; }
        }

        public DateTime FechaInicio
        {
            get { return _fechainicio; }
            set { _fechainicio = _fechainicio != value ? value : _fechainicio; }
        }

        public DateTime FechaFin
        {
            get { return _fechafin; }
            set { _fechafin = _fechafin != value ? value : _fechafin; }
        }

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public short IDUsuarioNew { get { return Convert.ToInt16(glb.GetIdUsuariolog()); } }

        public short IDUsuarioModif { get { return Convert.ToInt16(glb.GetIdUsuariolog()); } }

        public DateTime TimeModif { get { return DateTime.Now; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Diferencial() { }

        public Diferencial(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //CLONE 
        #region CLONACION
        public Diferencial Clone()
        {
            Diferencial d = (Diferencial)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Diferencial> Clone(List<Diferencial> lst)
        {
            List<Diferencial> lista = new List<Diferencial>();

            foreach (Diferencial d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS

        public List<Diferencial> GetRegistros()
        {
            try
            {
                List<Diferencial> lista = new List<Diferencial>();

                string c = $"SELECT IDRegistro" +
                           $" ,IDProfesional" +
                           $" ,FechaInicio" +
                           $" ,FechaFin" +
                           $" ,Observacion" +
                           $" FROM {tablaname}";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Diferencial>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las lista diferencial.\n{e.Message}", 0);
                return new List<Diferencial>();
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

            campos.Add("IDProfesional");
            campos.Add("FechaInicio");
            campos.Add("FechaFin");
            campos.Add("Observacion");
            campos.Add("IDUsuarioNew");
            campos.Add("IDUsuarioModif");
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
                if (IDProfesional <= 0)
                {
                    retorno.Add(0, "Sin id de profesionaL para registro de alta.");
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
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null));
                    paramnro++;
                }

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, $"Diferencial Alta.\n{e.Message}");
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
                campos.Remove("IDUsuarioNew");

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
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this));
                    paramnro++;
                }

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();


                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, $"Diferencial Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        #endregion
    }
}
