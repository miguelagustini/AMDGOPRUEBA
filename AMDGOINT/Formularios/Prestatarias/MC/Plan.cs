using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Prestatarias.MC
{
    public class Plan : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "AmdgoInterno.dbo.PRESTDETALLES";

        private int _idregistro = 0;
        private int _idprestataria = 0;
        private int _idagrupador = 0;
        private string _codigo = "";
        private string _codagrupador = "";
        private string _abreviatura = "";
        private string _descripcion = "";
        private decimal _porciva = 0;
        private short _idtipoprest = 0;
        private bool _visible = true;
        private short _idplansubcuenta = 0;
            

        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public int PrestatariaID
        {
            get { return _idprestataria; }
            set { _idprestataria = _idprestataria != value ? value : _idprestataria; }
        }

        public int AgrupadorID
        {
            get { return _idagrupador; }
            set { _idagrupador = _idagrupador != value ? value : _idagrupador; }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = _codigo != value.Trim() ? value.Trim() : _codigo; }
        }

        public string CodigoAgrupador
        {
            get { return _codagrupador; }
            set { _codagrupador = _codagrupador != value.Trim() ? value.Trim() : _codagrupador; }
        }

        public string Abreviatura
        {
            get { return _abreviatura; }
            set { _abreviatura = _abreviatura != value.Trim() ? value.Trim() : _abreviatura; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion; }
        }

        public decimal IvaPorcentaje
        {
            get { return _porciva; }
            set { _porciva = _porciva != value ? value : _porciva; }
        }

        public short PrestatariaTipoID
        {
            get { return _idtipoprest; }
            set { _idtipoprest = _idtipoprest != value ? value : _idtipoprest; }
        }
        
        public bool Visible
        {
            get { return _visible; }
            set { _visible = _visible != value ? value : _visible; }
        }

        public short IDPlanSubCuenta
        {
            get { return _idplansubcuenta; }
            set { _idplansubcuenta = _idplansubcuenta != value ? value : _idplansubcuenta; }
        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //IGUALACION
        public int ID_Prestataria { get { return PrestatariaID; } }
        public int ID_Agrupador { get { return AgrupadorID; } }
        public decimal PorcIva { get { return IvaPorcentaje; } }
        public short IDTipoPrestatarira { get { return PrestatariaTipoID;  } }

        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public DateTime TimeModif { get { return DateTime.Now; } }


        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Plan() { }

        public Plan(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //NOTIFY
        #region NOTIFY

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
        public Plan Clone()
        {
            Plan d = (Plan)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Plan> Clone(List<Plan> lst)
        {
            List<Plan> lista = new List<Plan>();

            foreach (Plan d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Plan> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Plan> lista = new List<Plan>();

                string c = $"SELECT PD.ID_Registro AS IDRegistro, PD.ID_Prestataria AS PrestatariaID, PD.Codigo, PD.Descripcion, PD.PorcIva AS IvaPorcentaje," +
                           $" PA.Codigo as CodigoAgrupador, PD.Abreviatura, PD.ID_Agrupador AS AgrupadorID, PD.IDPlanSubCuenta" +
                           $" FROM {tablaname} PD" +
                           $" LEFT OUTER JOIN PRESTGRPVAL PA ON(PA.ID_Registro = PD.ID_Agrupador)" +
                           $" WHERE PD.Visible = 1";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Plan>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Plan>();
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

            campos.Add("ID_Prestataria");
            campos.Add("ID_Agrupador");
            campos.Add("Codigo");
            campos.Add("Abreviatura");
            campos.Add("Descripcion");
            campos.Add("PorcIva");
            //campos.Add("IDTipoPrestataria");
            campos.Add("Visible");
            campos.Add("IDPlanSubCuenta");
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

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
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

        #endregion
    }
}
