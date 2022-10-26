using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AMDGOINT.Formularios.Medicamentos.MC
{
    class Asocdrog
    {
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private ConexionBD cbd = new ConexionBD();


        private static string tablaname = "[AmdgoSis].[dbo].[ASOCDROG]";
        private static string tablaname2 = "[AmdgoInterno].[dbo].[MEDICAMENTOS]";
        private string PuruebaDos = string.Empty;
        public string DROGCODI { get; set; } = string.Empty;
        public string DROGDENO { get; set; } = string.Empty;
        public string DROGLABO { get; set; } = string.Empty;
        public decimal DROGPREC { get; set; } = 0;
        public DateTime DROGFACT { get; set; } = DateTime.Now;
        public decimal DROGPOLD { get; set; } = 0;
        public string DROGIDEN { get; set; } = "S";
        public string DROGREST { get; set; } = "S";
        public int DROGTROQUEL { get; set; } = 0;
        public int NROREGISTROALF { get; set; } = 0;

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Asocdrog() { }

        public Asocdrog(SqlConnection conexion)
        {
        }

        #endregion

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("DROGCODI");
            campos.Add("DROGDENO");
            campos.Add("DROGPREC");
            campos.Add("DROGFACT");
            campos.Add("DROGREST");
            campos.Add("DROGTROQUEL");
            campos.Add("NROREGISTROALF");
            
            return campos;
        }


        private bool existeRegistroHomonimo()
        {
            List<Asocdrog> listaXasocdrog = GetRegistros();

            return listaXasocdrog.Exists(w => w.NROREGISTROALF == NROREGISTROALF);
        }


        public List<Asocdrog> GetRegistros()
        {
            try
            {
                //CONSULTO LA LISTA DE REGISTROS
                List<Asocdrog> lista = new List<Asocdrog>();

                string c = $"SELECT * FROM {tablaname}";


                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, glb.GetConexion().State != ConnectionState.Open ? cbd.Conectar() : glb.GetConexion()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Asocdrog>(rdr));
                }

                cbd.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Asocdrog>();
            }
        }


        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (!existeRegistroHomonimo()) { return Alta(); }
            else {return Modificacion(); }
        }

        private Dictionary<short, string> Alta()
        {

            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //CONEXION
                glb.GetConexion();

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

                SqlCommand cmd = new SqlCommand(query.ToString(), glb.GetConexion());


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

                //SI EXISTE REGISTRO CON EL MISMO HOMONIMO, BORRO EL ANTERIOR
                ModificacionAntiguos();

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

        //MODIFICACÓN DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
         private Dictionary<short, string> Modificacion()
         {
             //DICCIONARIO DE RETORNO
             Dictionary<short, string> retorno = new Dictionary<short, string>();
             try
             {
                //SI DROGREST ES "N", ELIMINAMOS EL REGISTRO
                if (DROGREST.Equals("N"))
                {
                    EliminarRegistroNoActivo();
                    return retorno;
                }

                 //DEFINO CONNEXION EN CASO DE NO HABER UNA
                 glb.GetConexion();

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
                query.Append($" WHERE (NROREGISTROALF = {NROREGISTROALF})");


                //CONEXION
                SqlCommand cmd = new SqlCommand(query.ToString(), glb.GetConexion());

                //PARAMETROS
                paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
                    else {cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this));}

                    paramnro++;
                }

                //EJECUTO LA ACTUALIZACION           
                cmd.ExecuteNonQuery();

                //SI EXISTE REGISTRO CON EL MISMO HOMONIMO, BORRO EL ANTERIOR
                ModificacionAntiguos();
                
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


        public Dictionary<short, string> ActualizarPrecios()
        {
            // DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            try
            {
                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                glb.GetConexion();

                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();

                //INICIO DEL UPDATE
                string a = $"UPDATE {tablaname} SET DROGPREC = MED.PRECIO FROM {tablaname} DROG " +
                    $"     left outer join {tablaname2} MED ON(MED.NROREGISTRO = DROG.NROREGISTROALF) WHERE UPPER(DROGREST) = 'S';";


                SqlCommand cmd = new SqlCommand(a, glb.GetConexion());

                //EJECUTO LA INSTRUCCION
                cmd.ExecuteNonQuery();


                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Modificación Lista.\n{e.Message}");
                ctrl.MensajeInfo(e.Message, 1);
                return retorno;
            }

        }


        private Dictionary<short, string> EliminarRegistroNoActivo()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            try
            {
                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                glb.GetConexion();


                string borrarRegistroNoActivo = $"DELETE FROM {tablaname} WHERE NROREGISTROALF = {NROREGISTROALF}";


                //CONEXION
                SqlCommand cmd = new SqlCommand(borrarRegistroNoActivo, glb.GetConexion());


                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} EliminarRegistroNoActivo.\n{e.Message}");
                return retorno;
            }

        }


        private Dictionary<short, string> ModificacionAntiguos()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            try
            {
                //DEFINO CONNEXION
                glb.GetConexion();
                
                string actualizarViejo = $"DELETE FROM {tablaname} WHERE NROREGISTROALF <> {NROREGISTROALF} AND DROGCODI = {DROGCODI}";
                
                //CONEXION
                SqlCommand cmd = new SqlCommand(actualizarViejo, glb.GetConexion());
                
                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} ModificacionAntiguos.\n{e.Message}");
                return retorno;
            }

        }


    }
}
