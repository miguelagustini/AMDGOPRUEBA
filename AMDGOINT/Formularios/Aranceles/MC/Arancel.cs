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

namespace AMDGOINT.Formularios.Aranceles.MC
{
    public class Arancel : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "ARANVALORIZAENC";

        private int _idregistro = 0;        
        private DateTime _fecha = DateTime.Now;
        private string _observacion = "";
        private bool _estado = false;
        private bool _aplprepaga = false;
        private bool _aplObrasocial = false;
        private bool _aplCaja = false;
        private bool _aplArt = false;

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();
        
        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = _fecha != value ? value : _fecha; }
        }

        public string Observaciones
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = _estado != value ? value : _estado; }
        }

        public bool AplicaPrepaga
        {
            get { return _aplprepaga; }
            set { _aplprepaga = _aplprepaga != value ? value : _aplprepaga; }
        }

        public bool AplicaObrasocial
        {
            get { return _aplObrasocial; }
            set { _aplObrasocial = _aplObrasocial != value ? value : _aplObrasocial; }
        }

        public bool AplicaArt
        {
            get { return _aplArt; }
            set { _aplArt = _aplArt != value ? value : _aplArt; }
        }

        public bool AplicaCaja
        {
            get { return _aplCaja; }
            set { _aplCaja = _aplCaja != value ? value : _aplCaja; }
        }

        public List<Detalles> Detalles { get; set; } = new List<Detalles>();

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD        
        public int ID_UsuNew { get => glb.GetIdUsuariolog(); }
        public int ID_UsuModif { get => glb.GetIdUsuariolog(); }
        public string Guid { get => IDLocal; }        
        public DateTime TimeModif { get => DateTime.Now; }
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Arancel() { }

        public Arancel(SqlConnection conexion)
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
        public Arancel Clone()
        {
            Arancel d = (Arancel)MemberwiseClone();

            Detalles deta = new Detalles();

            d.Detalles = deta.Clone(Detalles);

            return d;

        }

        //CLONE CON LISTAS
        public List<Arancel> Clone(List<Arancel> lst)
        {
            List<Arancel> lista = new List<Arancel>();

            foreach (Arancel d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS
        public List<Arancel> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Arancel> lista = new List<Arancel>();

                string c = $"SELECT ID_Registro AS IDRegistro, Guid AS IDLocal, Fecha, Observaciones, Estado, AplicaPrepaga, AplicaObrasocial, AplicaArt, AplicaCaja" +
                           $" FROM {tablaname}";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Arancel a = new Arancel();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                //DETALLES
                #region DETALLES
                Detalles det = new Detalles(SqlConnection);
                List<Detalles> d = det.GetRegistros();

                foreach (Arancel p in lista)
                {
                    p.Detalles = det.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion
                              
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Arancel>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void SetIdbyguid()
        {
            string c = $"SELECT ID_Registro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt32(r["ID_Registro"]);
            }
        }
             
        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm(bool procesadetalles = true)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0 && IDLocal.Length > 0)
            {
                return Alta();
            }
            else if (IDRegistro > 0)
            {
                return Modificacion(procesadetalles);
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

            campos.Add("Guid");          
            campos.Add("Fecha");          
            campos.Add("Observaciones");
            campos.Add("Estado");
            campos.Add("AplicaPrepaga");
            campos.Add("AplicaObrasocial");
            campos.Add("AplicaArt");
            campos.Add("AplicaCaja");
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

                //ASIGNO EL ID DE REGISTRO POR GUID
                SetIdbyguid();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES 
                    foreach (Detalles dir in Detalles)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.IDEncabezado = IDRegistro;
                        var dic = dir.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
                }

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
        private Dictionary<short, string> Modificacion(bool procesadetalles)
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
                campos.Remove("Guid");

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

                //ACTUALIZO DETALLES         
                if (procesadetalles)
                {
                    foreach (Detalles dir in Detalles)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.IDEncabezado = IDRegistro;
                        var dic = dir.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
                }

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


        #endregion
    }
}
