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
    public class CategoriaCondicionesIva: INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "[AmdgoInterno].[dbo].PROFEXCONDICIONIVA";

        private int _idregistro = 0;
        private int _idprofesional = 0;
        private short _idcondicioniva = 0;
        private DateTime _fechadesde = DateTime.MinValue;        
        private string _observacion = "";


        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public int IDProfesional
        {
            get { return _idprofesional; }
            set { _idprofesional = _idprofesional != value ? value : _idprofesional; }
        }

        public short IDCondicionIva
        {
            get { return _idcondicioniva; }
            set { _idcondicioniva = _idcondicioniva != value ? value : _idcondicioniva; }
        }

        public DateTime FechaDesde
        {
            get { return _fechadesde; }
            set { _fechadesde = _fechadesde != value ? value : _fechadesde; }

        }

        public string Observaciones
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public int IDUsuNew { get { return glb.GetIdUsuariolog(); } }
        public int IDUsuModif { get { return glb.GetIdUsuariolog(); } }
        public DateTime TimeModif { get { return DateTime.Now; } }
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public CategoriaCondicionesIva() { }

        public CategoriaCondicionesIva(SqlConnection conexion) { SqlConnection = conexion; }

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
        public CategoriaCondicionesIva Clone()
        {
            CategoriaCondicionesIva d = (CategoriaCondicionesIva)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<CategoriaCondicionesIva> Clone(List<CategoriaCondicionesIva> lst)
        {
            List<CategoriaCondicionesIva> lista = new List<CategoriaCondicionesIva>();

            foreach (CategoriaCondicionesIva d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS

        public List<CategoriaCondicionesIva> GetRegistros()
        {
            try
            {
                List<CategoriaCondicionesIva> lista = new List<CategoriaCondicionesIva>();

                string c = $"SELECT IDRegistro, IDProfesional, IDCondicionIva, FechaDesde, Observaciones FROM {tablaname}";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<CategoriaCondicionesIva>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name} Consulta.\n{e.Message}", 0);
                return new List<CategoriaCondicionesIva>();
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
            campos.Add("IDCondicionIva");
            campos.Add("FechaDesde");            
            campos.Add("Observaciones");
            campos.Add("IDUsuNew");
            campos.Add("IDUsuModif");

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

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = new List<string>(RetornaCampos());
                campos.Remove("IDUsuNew");

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
                retorno.Add(-1, $"{GetType().Name} Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        #endregion
        #endregion
    }
}
