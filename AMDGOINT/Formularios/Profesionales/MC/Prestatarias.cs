using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Profesionales.MC
{
    public class Prestatarias
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion
        
        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "PROFPRESTATARIAS";

        private int idregistro = 0;
        private int idprofesional = 0;
        private int idprestataria = 0;
        private bool estado = false;

        public int IDRegistro
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

        public int IDProfesional
        {
            get { return idprofesional; }
            set
            {
                if (idprofesional != value)
                {
                    idprofesional = value;

                }
            }
        }

        public int IDPrestataria
        {
            get { return idprestataria; }
            set
            {
                if (idprestataria != value)
                {
                    idprestataria = value;
                }
            }
        }
              
        public bool Estado
        {
            get { return estado; }
            set
            {
                if (estado != value)
                {
                    estado = value;
                }
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public int ID_Profesional { get { return IDProfesional; } }
        public int ID_Prestataria { get { return IDPrestataria; } }
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Prestatarias() { }

        public Prestatarias(SqlConnection conexion) { SqlConnection = conexion; }

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
        public Prestatarias Clone()
        {
            Prestatarias d = (Prestatarias)MemberwiseClone();

            return d;

        }

        //CLONE CON LISTAS
        public List<Prestatarias> Clone(List<Prestatarias> lst)
        {
            List<Prestatarias> lista = new List<Prestatarias>();

            foreach (Prestatarias d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        public BindingList<Prestatarias> Clone(BindingList<Prestatarias> lst)
        {
            BindingList<Prestatarias> lista = new BindingList<Prestatarias>();

            foreach (Prestatarias d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS
        public List<Prestatarias> GetRegistros()
        {
            try
            {
                List<Prestatarias> lista = new List<Prestatarias>();

                string c = $"SELECT ID_Registro AS IDRegistro, ID_Profesional AS IDProfesional, ID_Prestataria AS IDPrestataria, Estado" +
                           $" FROM {tablaname}";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Prestatarias>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los contactos.\n{e.Message}", 0);
                return new List<Prestatarias>();
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

            campos.Add("ID_Profesional");
            campos.Add("ID_Prestataria");
            campos.Add("Estado");            
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

                retorno.Add(1, "OK");

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, $"Prestatarias Alta.\n{e.Message}");
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
                retorno.Add(-1, $"Prestatarias Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        #endregion


        #endregion
        
    }
}
