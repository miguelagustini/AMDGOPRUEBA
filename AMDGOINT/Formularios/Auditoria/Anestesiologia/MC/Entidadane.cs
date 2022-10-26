using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.MC
{
    public class Entidadane : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablename = "AUDIANESENTI";

        private short idregistro = 0;        
        private string nombre = "";
        
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
        
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                }
            }
        }
              
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Entidadane() { }

        public Entidadane(SqlConnection q) { SqlConnection = q; }

        #endregion

        //EVENTOS
        #region EVENTOS Y  METODOS

        //PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        //CLONE 
        #region CLONACION
        public Entidadane Clone()
        {
            Entidadane d = (Entidadane)MemberwiseClone();

            return d;

        }

        //CLONE CON LISTAS
        public List<Entidadane> Clone(List<Entidadane> lst)
        {
            List<Entidadane> lista = new List<Entidadane>();

            foreach (Entidadane d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        public BindingList<Entidadane> Clone(BindingList<Entidadane> lst)
        {
            BindingList<Entidadane> lista = new BindingList<Entidadane>();

            foreach (Entidadane d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //CONSULTA DE DATOS
        #region CONSULTA DE DATOS

        //RETORNO LISTA 
        public List<Entidadane> GetRegistros()
        {
            try
            {
                List<Entidadane> lista = new List<Entidadane>();

                string c = $"SELECT ID_Registro AS IDRegistro, Nombre FROM {tablename}";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Entidadane a = new Entidadane();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        GetType().GetProperty(co.ColumnName).SetValue(a, r[co]);
                    }

                    lista.Add(a);
                }

                //dispongo de la memoria table
                tbl.Dispose();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las entidades.\n{e.Message}", 0);
                return new List<Entidadane>();
            }
        }

        //DETERMINO SI LA DESCRIPCION YA ESTA CARGADA
        public bool ExisteNombre()
        {
            bool retorno = false;

            try
            {
                string c = $"SELECT ID_Registro FROM {tablename} WHERE Nombre = '{Nombre}'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    retorno = r["ID_Registro"] != DBNull.Value && Convert.ToInt32(r["ID_Registro"]) > 0 ? true : false;
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar el nombre.\n{e.Message}", 0);
                return retorno;
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

            campos.Add("Nombre");            
            campos.Add("ID_UsuNew");
            campos.Add("ID_UsuModif");

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
                query.Append($"INSERT INTO {tablename} (");

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
                campos.Remove("ID_UsuNew");

                //INICIO DEL INSERT
                query.Append($"UPDATE {tablename} SET ");

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
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this));
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
