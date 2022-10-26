using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Prestatarias.MC
{
    public class Prestataria : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "AmdgoInterno.dbo.PRESTATARIAS";

        private int _idregistro = 0;
        private string _nombre = "";
        private string _abreviatura = "";
        private long _cuit = 0;
        private short _idiva = 0;
        private string _domfiscal = "";
        private bool _esart = false;
        private int _diasvto = 0;
        private bool _mipime = false;
        private bool _aceptax = false;
        private bool _factporpaciente = false;
        private bool _estado = true;
        private string _ivaabre = "";

        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public string RazonSocial
        {
            get { return _nombre.ToUpper(); }
            set { _nombre = _nombre != value.Trim() ? value.Trim() : _nombre; }
        }

        public string Abreviatura
        {
            get { return _abreviatura; }
            set { _abreviatura = _abreviatura != value.Trim() ? value.Trim() : _abreviatura; }
        }

        public long Cuit
        {
            get { return _cuit; }
            set { _cuit = _cuit != value ? value : _cuit; }
        }

        public short IvaID
        {
            get { return _idiva; }
            set { _idiva = _idiva != value ? value : _idiva; }
        }

        public string IvaAbreviatura
        {
            get { return _ivaabre; }
            set { _ivaabre = _ivaabre != value.Trim() ? value.Trim() : _ivaabre; }
        }

        public int DiasVencimiento
        {
            get { return _diasvto; }
            set { _diasvto = _diasvto != value ? value : _diasvto; }
        }

        public bool EsArt
        {
            get { return _esart; }
            set { _esart = _esart != value ? value : _esart; }
        }

        public string DomicilioFiscal
        {
            get { return _domfiscal.ToUpper(); }
            set { _domfiscal = _domfiscal != value.Trim() ? value.Trim() : _domfiscal; }
        }

        public bool MiPyme
        {
            get { return _mipime; }
            set { _mipime = _mipime != value ? value : _mipime; }
        }

        public string MiPymeDescripcion
        {
            get
            {
                if (MiPyme) { return "Si"; }
                else { return "No"; }
            }
        }

        public string AceptaComprobanteXDescripcion
        {
            get
            {
                if (AceptaComprobanteX) { return "Si"; }
                else { return "No"; }
            }
        }

        public bool AceptaComprobanteX
        {
            get { return _aceptax; }
            set { _aceptax = _aceptax != value ? value : _aceptax; }
        }

        public bool ComprobantePaciente
        {
            get { return _factporpaciente; }
            set { _factporpaciente = _factporpaciente != value ? value : _factporpaciente; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = _estado != value ? value : _estado; }
        }

        public List<Plan> Planes { get; set; } = new List<Plan>();
        public List<AreaTrabajo> AreaTrabajo { get; set; } = new List<AreaTrabajo>();
        public List<MovimientosEncabezado> MovimientosComprobantes { get; set; } = new List<MovimientosEncabezado>();

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //IGUALACION
        public string Nombre { get { return RazonSocial; } }
        public short ID_Iva { get { return IvaID; } }
        public bool Art { get { return EsArt; } }
        public bool AceptaCompx { get { return AceptaComprobanteX; } }
        public bool CompPaciente { get { return ComprobantePaciente; } }

        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public DateTime TimeModif { get { return DateTime.Now; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Prestataria() { }

        public Prestataria(SqlConnection conexion)
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
        public Prestataria Clone()
        {
            Prestataria d = (Prestataria)MemberwiseClone();
            Plan p = new Plan();
            AreaTrabajo c = new AreaTrabajo();

            d.Planes = p.Clone(Planes);
            d.AreaTrabajo = c.Clone(AreaTrabajo);

            return d;

        }

        //CLONE CON LISTAS
        public List<Prestataria> Clone(List<Prestataria> lst)
        {
            List<Prestataria> lista = new List<Prestataria>();

            foreach (Prestataria d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Prestataria> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Prestataria> lista = new List<Prestataria>();

                string c = $"SELECT PR.ID_Registro AS IDRegistro, PR.Nombre as RazonSocial, PR.Cuit, PR.ID_Iva as IvaID, " +
                           $" CD.Abreviatura AS IvaAbreviatura, PR.DiasVencimiento, PR.MiPyme, PR.Abreviatura AS Abreviatura," +
                           $" PR.AceptaCompX AS AceptaComprobanteX, PR.DomicilioFiscal" +
                           $" FROM {tablaname} PR" +
                           $" LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                           $" WHERE PR.Estado = 1";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Prestataria>(rdr));
                }

                cnb.Desconectar();
                                
                #region PLANES
                Plan plclass = new Plan(SqlConnection);
                List<Plan> d = plclass.GetRegistros();
                lista.ForEach(p => p.Planes = plclass.Clone(d.Where(w => w.PrestatariaID == p.IDRegistro).ToList()));

                #endregion
                                
                #region AREAS Y CONTACTOS
                MC.AreaTrabajo areacls = new AreaTrabajo(SqlConnection);
                List<AreaTrabajo> a = areacls.GetRegistros();
                lista.ForEach(p => p.AreaTrabajo = areacls.Clone(a.Where(w => w.IDPrestataria == p.IDRegistro).ToList()));

                #endregion

                #region CUENTA CORRIENTE
                MovimientosEncabezado ctactecls = new MovimientosEncabezado(SqlConnection);
                List<MovimientosEncabezado> ctalst = ctactecls.GetRegistros();
                lista.ForEach(p => p.MovimientosComprobantes = ctactecls.Clone(ctalst.Where(w => w.PrestatariaID == p.IDRegistro).ToList()));
                #endregion

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Prestataria>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void SetIdbyguid()
        {
            string c = $"SELECT ID_Registro FROM {tablaname} WHERE Cuit = {Cuit}";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt32(r["ID_Registro"]);
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

            campos.Add("Nombre");
            campos.Add("Abreviatura");
            campos.Add("Cuit");
            campos.Add("ID_Iva");
            campos.Add("DomicilioFiscal");
            campos.Add("Art");
            campos.Add("DiasVencimiento");
            campos.Add("MiPyme");
            campos.Add("AceptaCompx");
            campos.Add("CompPaciente");
            campos.Add("Estado");

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
                    //ACTUALIZO LOS PLANES
                    foreach (Plan dir in Planes)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.PrestatariaID = IDRegistro;
                        var dic = dir.Abm();

                        func.PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO AREAS DE TRABAJO
                    foreach (AreaTrabajo dir in AreaTrabajo)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.IDPrestataria = IDRegistro;
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

                //ACTUALIZO LOS PLANES
                foreach (Plan dir in Planes)
                {
                    //ASIGNO CONNEXION
                    dir.SqlConnection = SqlConnection;
                    dir.PrestatariaID = IDRegistro;
                    var dic = dir.Abm();

                    func.PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO AREAS DE TRABAJO
                foreach (AreaTrabajo dir in AreaTrabajo)
                {
                    //ASIGNO CONNEXION
                    dir.SqlConnection = SqlConnection;
                    dir.IDPrestataria = IDRegistro;
                    var dic = dir.Abm();

                    func.PreparaRetorno(retorno, dic);
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
    }
}
