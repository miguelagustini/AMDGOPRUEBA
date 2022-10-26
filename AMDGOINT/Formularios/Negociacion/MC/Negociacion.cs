using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Negociacion.MC
{
    public class Negociacion : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "XDISCUSIONENC";

        private int _idregistro = 0;
        private int _idaranvaloriza = 0;
        private int _idgrupovalor = 0;        
        private DateTime _fechainicio = DateTime.Now;
        private DateTime _fechaimpacto = DateTime.MinValue;
        private DateTime _fechacierre = DateTime.MinValue;
        private short _estado = 0;

        private string _grupocodigo = "";
        private string _grupodescripcion = "";
        private string _presttipo = "";
        private string _presttipodescr = "";

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public int IDArancelValoriza
        {
            get { return _idaranvaloriza; }
            set { _idaranvaloriza = _idaranvaloriza != value ? value : _idaranvaloriza; }
        }

        public int AgrupadorID
        {
            get { return _idgrupovalor; }
            set { _idgrupovalor = _idgrupovalor != value ? value : _idgrupovalor; }
        }

        public string AgrupadorCodigo
        {
            get { return _grupocodigo; }
            set { _grupocodigo = _grupocodigo != value.Trim() ? value.Trim() : _grupocodigo; }
        }

        public string AgrupadorDescripcion
        {
            get { return _grupodescripcion; }
            set { _grupodescripcion = _grupodescripcion != value.Trim() ? value.Trim() : _grupodescripcion; }
        }

        public DateTime FechaInicio
        {
            get { return _fechainicio; }
            set { _fechainicio = _fechainicio != value ? value : _fechainicio; }
        }

        public DateTime FechaImpacto
        {
            get { return _fechaimpacto; }
            set { _fechaimpacto = _fechaimpacto != value ? value : _fechaimpacto; }
        }

        public DateTime FechaCierre
        {
            get { return _fechacierre; }
            set { _fechacierre = _fechacierre != value ? value : _fechacierre; }
        }
               
        public short Estado
        {
            get { return _estado; }
            set { _estado = _estado != value ? value : _estado; }
        }

        public string PrestadoraTipoCodigo
        {
            get { return _presttipo; }
            set { _presttipo = _presttipo != value.Trim() ? value.Trim() : _presttipo; }
        }

        public string PrestadoraTipoDescripcion
        {
            get { return _presttipodescr; }
            set { _presttipodescr = _presttipodescr != value.Trim() ? value.Trim() : _presttipodescr; }
        }

        public string PrestatriasAsociadas
        {
            get
            {
                string c = "";

                Prestatarias?.ForEach(f => c = $"{f.Codigo} - {f.NombreFiscal} {f.Cuit}");

                return c;
            }
        }

        public List<Prestadoras> Prestatarias
        {
            get
            {
                return AgrupadorInfo?.PrestatariasHisto?.Where(w => w.IDEncabezado == IDRegistro).ToList();
            }
        }


        public AgrupadorInfo AgrupadorInfo { get; set; } = new AgrupadorInfo();

        public List<Detalles> Detalles { get; set; } = new List<Detalles>();

        public List<GrupoObservaciones> GrupoObservaciones { get; set; } = new List<GrupoObservaciones>();
        public List<Extra> Extras { get; set; } = new List<Extra>();
        public List<Anexo> Anexos { get; set; } = new List<Anexo>();

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD        
        public int ID_AranValoriza { get => IDArancelValoriza; }
        public int ID_GrupoValor { get => AgrupadorID; }
        public string Guid { get => IDLocal; }

        public int ID_UsuNew { get => glb.GetIdUsuariolog(); }
        public int ID_UsuModif { get => glb.GetIdUsuariolog(); }        
        public DateTime TimeModif { get => DateTime.Now; }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Negociacion() { }

        public Negociacion(SqlConnection conexion)
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
        public Negociacion Clone()
        {
            Negociacion d = (Negociacion)MemberwiseClone();
            
            Detalles deta = new Detalles();
            d.Detalles = deta.Clone(Detalles);

            GrupoObservaciones grp = new GrupoObservaciones();
            d.GrupoObservaciones = grp.Clone(GrupoObservaciones);

            Extra ext = new Extra();
            d.Extras = ext.Clone(Extras);

            Anexo anx = new Anexo();
            d.Anexos = anx.Clone(Anexos);

            return d;

        }

        //CLONE CON LISTAS
        public List<Negociacion> Clone(List<Negociacion> lst)
        {
            List<Negociacion> lista = new List<Negociacion>();

            foreach (Negociacion d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS
        public List<Negociacion> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Negociacion> lista = new List<Negociacion>();

                string c = $"SELECT DE.ID_Registro AS IDRegistro, DE.ID_AranValoriza as IDArancelValoriza, DE.ID_GrupoValor as AgrupadorID," +
                           $" DE.Guid AS IDLocal, DE.FechaInicio, DE.FechaCierre, DE.FechaImpacto, DE.Estado, " +
                           $" PG.Codigo as AgrupadorCodigo, PG.Descripcion as AgrupadorDescripcion, PT.Codigo AS PrestadoraTipoCodigo," +
                           $" PT.Descripcion AS PrestadoraTipoDescripcion" +
                           $" FROM {tablaname} DE" +
                           $" LEFT OUTER JOIN PRESTGRPVAL PG ON(PG.ID_Registro = DE.ID_GrupoValor)" +
                           $" LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = PG.ID_PrestaTipo)";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Negociacion>(rdr));
                }

                cnn.Desconectar();

                //AGRUPADOR INGO
                #region AGRUPADOR INFO
                AgrupadorInfo ag = new AgrupadorInfo();
                List<AgrupadorInfo> lstag = ag.GetRegistros();
                lista.ForEach(f => f.AgrupadorInfo = lstag.Where(w => w.IDRegistro == f.AgrupadorID).FirstOrDefault().Clone());
                
                #endregion
                                
                //DETALLES DE NEGOCIACION
                #region DETALLES
               /* Detalles de = new Detalles(SqlConnection);
                List<Detalles> t1 = de.GetRegistros();

                lista.ForEach(f => f.Detalles = de.Clone(t1.Where(w => w.IDEncabezado == f.IDRegistro).ToList()));
                */
                #endregion

                //OBSERVACIONES
                #region OBSERVACIONES
                GrupoObservaciones go = new GrupoObservaciones(SqlConnection);
                List<GrupoObservaciones> obslst = go.GetRegistros();

                lista.ForEach(f => f.GrupoObservaciones = go.Clone(obslst.Where(w => w.IDEncabezado == f.IDRegistro).ToList()));

                #endregion

                //EXTRAS
                #region EXTRAS
                Extra ext = new Extra(SqlConnection);
                List<Extra> extlst = ext.GetRegistros();

                lista.ForEach(f => f.Extras = ext.Clone(extlst.Where(w => w.IDEncabezado == f.IDRegistro).ToList()));

                #endregion

                // ANEXOS
                #region ANEXOS
                Anexo anx = new Anexo(SqlConnection);
                List<Anexo> anxlst = anx.GetRegistros();

                lista.ForEach(f => f.Anexos = anx.Clone(anxlst.Where(w => w.IDEncabezado == f.IDRegistro).ToList()));

                #endregion

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Negociacion>();
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

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0 && IDLocal.Length > 0)
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
                    foreach (Detalles reg in Detalles)
                    {
                        //ASIGNO CONNEXION
                        reg.SqlConnection = SqlConnection;
                        reg.IDEncabezado = IDRegistro;
                        var dic = reg.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //OBSERVACIONES
                    foreach (GrupoObservaciones reg in GrupoObservaciones)
                    {
                        //ASIGNO CONNEXION
                        reg.SqlConnection = SqlConnection;
                        reg.IDEncabezado = IDRegistro;
                        var dic = reg.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //EXTRAS
                    foreach (Extra reg in Extras)
                    {
                        //ASIGNO CONNEXION
                        reg.SqlConnection = SqlConnection;
                        reg.IDEncabezado = IDRegistro;
                        var dic = reg.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //ANEXOS
                    foreach (Anexo reg in Anexos)
                    {
                        //ASIGNO CONNEXION
                        reg.SqlConnection = SqlConnection;
                        reg.IDEncabezado = IDRegistro;
                        var dic = reg.Abm();
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
                foreach (Detalles reg in Detalles)
                {
                    //ASIGNO CONNEXION
                    reg.SqlConnection = SqlConnection;
                    reg.IDEncabezado = IDRegistro;
                    var dic = reg.Abm();
                    func.PreparaRetorno(retorno, dic);
                }

                //OBSERVACIONES
                foreach (GrupoObservaciones reg in GrupoObservaciones)
                {
                    //ASIGNO CONNEXION
                    reg.SqlConnection = SqlConnection;
                    reg.IDEncabezado = IDRegistro;
                    var dic = reg.Abm();
                    func.PreparaRetorno(retorno, dic);
                }

                //EXTRAS
                foreach (Extra reg in Extras)
                {
                    //ASIGNO CONNEXION
                    reg.SqlConnection = SqlConnection;
                    reg.IDEncabezado = IDRegistro;
                    var dic = reg.Abm();
                    func.PreparaRetorno(retorno, dic);
                }

                //ANEXOS
                foreach (Anexo reg in Anexos)
                {
                    //ASIGNO CONNEXION
                    reg.SqlConnection = SqlConnection;
                    reg.IDEncabezado = IDRegistro;
                    var dic = reg.Abm();
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


        #endregion
    }
}
