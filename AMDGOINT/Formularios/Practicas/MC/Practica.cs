using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Practicas.MC
{
    public class Practica : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "PRACTAM";

        private int _idregistro = 0;
        private string _codigo = "";
        private string _descripcion = "";
        private int _idgaleno = 0;
        private int _idgasto = 0;
        private int _idfuncion = 0;
        private int _idgrupo = 0;
        private short _tipopractica = 0;
        private bool _estado = true;

        private string _codigogal = "";
        private string _descrgal = "";
        private string _codigogasto = "";
        private string _descrgasto = "";
        private string _codfuncion = "";
        private string _descfuncion = "";
        private string _letrafuncion = "";

        private string _descrgrupo = "";
        private short _ordengrupo = 0;
        private string _observacgrupo = "";

        private decimal _unidadgaleno = 0;
        private decimal _unidadgasto = 0;
        private short _ayudantecantidad = 0;
        private decimal _ayudanteunidad = 0;

        private byte _esnomenclada = 0;

        public int IDRegistro
        {
            get { return _idregistro; }
            set
            {
                if (_idregistro != value)
                {
                    _idregistro = value;
                }
            }
        }

        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (_codigo != value.Trim())
                {
                    _codigo = value.Trim();
                }
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion;
            }
        }

        public int IDGaleno
        {
            get { return _idgaleno; }
            set
            {
                _idgaleno = _idgaleno != value ? value : _idgaleno;
            }
        }

        public int IDGasto
        {
            get { return _idgasto; }
            set
            {
                _idgasto = _idgasto != value ? value : _idgasto;
            }
        }

        public int IDFuncion
        {
            get { return _idfuncion; }
            set
            {
                _idfuncion = _idfuncion != value ? value : _idfuncion;
            }
        }

        public int IDGrupo
        {
            get { return _idgrupo; }
            set { _idgrupo = _idgrupo != value ? value : _idgrupo; }
        }

        public short TipoPractica
        {
            get { return _tipopractica; }
            set
            {
                _tipopractica = _tipopractica != value ? value : _tipopractica;
            }
        }

        public bool Estado
        {
            get { return _estado; }
            set
            {
                _estado = _estado != value ? value : _estado;
            }
        }
        
        public string FuncionCodigo
        {
            get { return _codfuncion.Trim(); }
            set { _codfuncion = _codfuncion != value.Trim() ? value.Trim() : _codfuncion; }
        }

        public string FuncionDescripcion
        {
            get { return _descfuncion.Trim(); }
            set { _descfuncion = _descfuncion != value.Trim() ? value.Trim() : _descfuncion; }
        }

        public string FuncionLetra
        {
            get { return _letrafuncion.Trim(); }
            set { _letrafuncion = _letrafuncion != value.Trim() ? value.Trim() : _letrafuncion; }
        }

        public string GalenoCodigo
        {
            get { return _codigogal; }
            set { _codigogal = _codigogal != value.Trim() ? value.Trim() : _codigogal; }
        }

        public string GalenoDescripcion
        {
            get { return _descrgal; }
            set { _descrgal = _descrgal != value.Trim() ? value.Trim() : _descrgal; }
        }
        
        public string GastoCodigo
        {
            get { return _codigogasto; }
            set { _codigogasto = _codigogasto != value.Trim() ? value.Trim() : _codigogasto; }
        }

        public string GastoDescripcion
        {
            get { return _descrgasto; }
            set { _descrgasto = _descrgasto != value.Trim() ? value.Trim() : _descrgasto; }
        }

        public string GrupoDescripcion
        {
            get { return _descrgrupo; }
            set { _descrgrupo = _descrgrupo != value.Trim() ? value.Trim() : _descrgrupo; }
        }

        public short GrupoOrden
        {
            get { return _ordengrupo; }
            set { _ordengrupo = _ordengrupo != value ? value : _ordengrupo; }
        }

        public string GrupoObservacion
        {
            get { return _observacgrupo; }
            set { _observacgrupo = _observacgrupo != value.Trim() ? value.Trim() : _observacgrupo; }
        }

        public decimal UnidadGaleno
        {
            get { return _unidadgaleno; }
            set { _unidadgaleno = _unidadgaleno != value ? value : _unidadgaleno; }
        }

        public decimal UnidadGasto
        {
            get { return _unidadgasto; }
            set { _unidadgasto = _unidadgasto != value ? value : _unidadgasto; }
        }

        public short AyudanteCantidad
        {
            get { return _ayudantecantidad; }
            set { _ayudantecantidad = _ayudantecantidad != value ? value : _ayudantecantidad; }
        }

        public decimal AyudanteUnidad
        {
            get { return _ayudanteunidad; }
            set { _ayudanteunidad = _ayudanteunidad != value ? value : _ayudanteunidad; }
        }

        public byte EsNomenclada
        {
            get { return _esnomenclada; }
            set { _esnomenclada = _esnomenclada != value ? value : _esnomenclada; }
        }

        public List<Convenidas> Convenidas { get; set; } = new List<Convenidas>();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public int ID_Arancel { get { return IDGaleno; } }
        public int ID_Gasto { get { return IDGasto; } }
        public int ID_Funcion { get { return IDFuncion; } }
        public int ID_Grupo { get { return IDGrupo; } }
        
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Practica() { }

        public Practica(SqlConnection conexion) { SqlConnection = conexion; }

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
        public Practica Clone()
        {
            Practica d = (Practica)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Practica> Clone(List<Practica> lst)
        {
            List<Practica> lista = new List<Practica>();

            foreach (Practica d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS

        public List<Practica> GetRegistros()
        {
            try
            {
                List<Practica> lista = new List<Practica>();

                string c = $"SELECT PM.ID_Registro AS IDRegistro, PM.Codigo, PM.Descripcion," +                           
                           $" PM.ID_Arancel AS IDGaleno, PM.ID_Gasto AS IDGasto, PM.ID_Funcion AS IDFuncion," +
                           $" PM.ID_Grupo AS IDGrupo, PM.TipoPractica, PM.Estado, AR.Codigo AS GalenoCodigo, AR.Descripcion AS GalenoDescripcion, GA.Codigo AS GastoCodigo," +
                           $" GA.Descripcion AS GastoDescripcion, PG.Descripcion AS GrupoDescripcion, PG.Orden AS GrupoOrden, PG.Observacion AS GrupoObservacion," +
                           $" FU.Codigo AS FuncionCodigo, FU.Letra AS FuncionLetra, FU.Descripcion AS FuncionDescripcion," +
                           $" CAST(IIF(PN.Codigo IS NULL, 0, 1) AS tinyint) AS EsNomenclada" +
                           $" FROM {tablaname} PM" +
                           $" LEFT OUTER JOIN ARANCELES AR ON(AR.ID_Registro = PM.ID_Arancel)" +
                           $" LEFT OUTER JOIN GASTOS GA ON(GA.ID_Registro = PM.ID_Gasto)" +
                           $" LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                           $" LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                           $" LEFT OUTER JOIN PRACTNOMECLADAS PN ON(PN.Codigo = PM.Codigo)";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Practica>(rdr));
                }

                cnn.Desconectar();

                #region CONVENIDAS
                Convenidas cnv = new Convenidas(SqlConnection);
                List<Convenidas> cnvlist = cnv.GetRegistros();

                foreach (Practica p in lista)
                {
                    p.Convenidas = cnv.Clone(cnvlist.Where(w => w.PracticaID == p.IDRegistro).ToList());
                }

                #endregion

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las prácticas.\n{e.Message}", 0);
                return new List<Practica>();
            }
        }

        public List<Practica> GetNomencladas()
        {
            try
            {
                List<Practica> lista = new List<Practica>();

                string c = $"SELECT PN.ID_Registro AS IDRegistro, PN.Codigo, PN.Descripcion, PN.ID_Galeno AS IDGaleno, PN.UnidadGaleno, PN.ID_Gasto AS IDGasto," +
                           $" PN.UnidadGasto, PN.AyudanteCantidad, PN.AyudanteUnidad, ISNULL(GA.Codigo,'') AS GastoCodigo, ISNULL(AR.Codigo,'') as GalenoCodigo" +
                           $" FROM PRACTNOMECLADAS PN" +
                           $" LEFT OUTER JOIN GASTOS GA ON(GA.ID_Registro = PN.ID_Gasto)" +
                           $" LEFT OUTER JOIN ARANCELES AR ON(AR.ID_Registro = PN.ID_Galeno)";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Practica>(rdr));
                }

                cnn.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las prácticas nomencladas.\n{e.Message}", 0);
                return new List<Practica>();
            }
        }

        //CONSULTO SI EXISTE EL REGISTRO (EVITA REPETIDOS)
        public int ExisteRegistro()
        {
            int retorno = 0;

            try
            {
                string c = $"SELECT ID_Registro FROM PRACTAM WHERE Codigo = '{Codigo}' AND ID_Funcion = {IDFuncion}" +
                    $" AND ID_Arancel = {IDGaleno} AND ID_Gasto = {IDGasto} AND ID_Registro <> {IDRegistro}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    retorno = Convert.ToInt32(r["ID_Registro"]);
                }

                return retorno;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        //DETERMINO SI LA PRÁCTICA SE ENCUENTRA EN USO (DE SER ASI, NO PERMITO MODIFICAR)
        public bool PermitoModificarrel()
        {
            bool retorno = false;

            try
            {
                string c = $"SELECT AD.ID_PractAm AS IDPractica, AE.Estado FROM ARANVALORIZADET AD" +
                           $" LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = AD.ID_Encabezado)" +
                           $" WHERE AD.ID_PractAm = {IDRegistro}" +
                           $" UNION" +
                           $" SELECT DD.ID_Practica AS IDPractica, DE.Estado FROM DISCUSIONDET DD" +
                           $" LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DD.ID_Encabezado)" + 
                           $" WHERE DD.ID_Practica = {IDRegistro}";
                    
                    
                if (func.getColecciondatos(c).Rows.Count <= 0) { retorno = true; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar la disponibilidad de modificación.\n {e.Message}", 0);
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

            campos.Add("Codigo");
            campos.Add("Descripcion");
            campos.Add("ID_Arancel");
            campos.Add("ID_Gasto");
            campos.Add("ID_Funcion");
            campos.Add("ID_Grupo");
            campos.Add("TipoPractica");
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
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
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
                retorno.Add(-1, $"Prácticas Alta.\n{e.Message}");
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
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
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
                retorno.Add(-1, $"Prácticas Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        #endregion
        #endregion
    }
}
