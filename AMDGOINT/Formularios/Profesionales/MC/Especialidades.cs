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
    public class Especialidades : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "PROFESPECIALIDAD";

        private int idregistro = 0;
        private int idprofesional = 0;
        private short idespecialidad = 0;
        private long nroregistro = 0;
        private DateTime vencimiento = DateTime.MinValue;
        private bool recertificado = false;
        private string observacion = "";
        private string especialidad = "";

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

        public short IDEspecialidad
        {
            get { return idespecialidad; }
            set
            {
                if (idespecialidad != value)
                {
                    idespecialidad = value;                   
                }
            }
        }

        public long NroRegistro
        {
            get { return nroregistro; }
            set
            {
                if (nroregistro != value)
                {
                    nroregistro = value;
                }
            }
        }

        public DateTime Vencimiento
        {
            get { return vencimiento; }
            set
            {
                if (vencimiento != value)
                {
                    vencimiento = value;
                }
            }
        }

        public bool Recertificado
        {
            get { return recertificado; }
            set
            {
                if (recertificado != value)
                {
                    recertificado = value;
                }
            }
        }

        public string Observacion
        {
            get { return observacion; }
            set
            {
                if (observacion != value.Trim())
                {
                    observacion = value.Trim();
                }
            }

        }

        public string Especialidad
        {
            get { return especialidad; }
            set
            {
                if (especialidad != value.Trim())
                {
                    especialidad = value.Trim();
                }
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        //DE IGUALACION CON CAMPOS DE BD
        public short ID_Especialidad { get { return IDEspecialidad; } }
        public int ID_Profesional { get { return IDProfesional; } }
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public DateTime TimeModif { get { return DateTime.Now; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Especialidades() { }

        public Especialidades(SqlConnection conexion) { SqlConnection = conexion; }

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
        public Especialidades Clone()
        {
            Especialidades d = (Especialidades)MemberwiseClone();            
            return d;
        }
                
        //CLONE CON LISTAS
        public List<Especialidades> Clone(List<Especialidades> lst)
        {
            List<Especialidades> lista = new List<Especialidades>();

            foreach (Especialidades d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        
        #endregion

        #region CONSULTA DE DATOS
        //RETORNO LISTA 
        public List<Especialidades> GetEspecialidad()
        {
            try
            {
                List<Especialidades> lista = new List<Especialidades>();

                string c = $"SELECT PE.ID_Registro AS IDRegistro, PE.ID_Especialidad AS IDEspecialidad, PE.ID_Profesional AS IDProfesional, PE.NroRegistro, PE.Vencimiento," +
                           $" PE.Recertificado, PE.Observacion, EM.Descripcion AS Especialidad" +
                           $" FROM {tablaname} PE" +
                           $" LEFT OUTER JOIN ESPECIALIDADESMED EM ON(EM.ID_Registro = PE.ID_Especialidad)";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Especialidades>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las especialidades.\n{e.Message}", 0);
                return new List<Especialidades>();
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
            campos.Add("ID_Especialidad");
            campos.Add("NroRegistro");
            campos.Add("Vencimiento");
            campos.Add("Recertificado");
            campos.Add("Observacion");
            campos.Add("ID_UsuNew");
            campos.Add("ID_UsuModif");       
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
                if (IDProfesional <= 0) { retorno.Add(0, "Sin id de profesional para alta."); return retorno; }

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

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, $"Especialidades Alta.\n{e.Message}");
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
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this, null)) == DateTime.MinValue)
                    { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value); }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this)); }
                    
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
                retorno.Add(-1, $"Especialidades Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        #endregion

        #endregion
    }
}
