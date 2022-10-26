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
    public class Detalles : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "ARANVALORIZADET";

        private long _idregistro = 0;
        private int _idencabezado = 0;
        private int _idpractica = 0;
        private decimal _valorprepaga = 0;
        private string _obsprepaga = "";
        private decimal _valorobrasocial = 0;
        private string _obsobrasocial = "";
        private decimal _valorart = 0;
        private string _obsart = "";
        private decimal _valorcaja = 0;
        private string _obscaja = "";
             
        private decimal _valor = 0;
        private decimal _valordefecto = 0;
        private bool _tipovalor = false; // false  = PORCENTAJE / true = VALOR FIJO

        private string _practicacod = "";
        private string _practicadecr = "";
        private string _funcioncod = "";
        private string _funciondescr = "";
        private string _funcionletra = "";
        private string _grupodescr = "";
        private short _grupoorden = 0;
        private int _grupoid = 0;
        private int _ordenlst = 0;
        private bool _practicaincluida = true;
        private int _idfuncion = 0;

        public long IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public int IDEncabezado
        {
            get { return _idencabezado; }
            set { _idencabezado = _idencabezado != value ? value : _idencabezado; }
        }

        public int IDPractica
        {
            get { return _idpractica; }
            set { _idpractica = _idpractica != value ? value : _idpractica; }
        }

        public decimal ValorPrepaga
        {
            get { return _valorprepaga; }
            set { _valorprepaga = _valorprepaga != value ? value : _valorprepaga; }
        }

        public string ObservacionPrepaga
        {
            get { return _obsprepaga; }
            set { _obsprepaga = _obsprepaga != value.Trim() ? value.Trim() : _obsprepaga; }
        }

        public decimal ValorObrasocial
        {
            get { return _valorobrasocial; }
            set { _valorobrasocial = _valorobrasocial != value ? value : _valorobrasocial; }
        }

        public string ObservacionObrasocial
        {
            get { return _obsobrasocial; }
            set { _obsobrasocial = _obsobrasocial != value.Trim() ? value.Trim() : _obsobrasocial; }
        }

        public decimal ValorArt
        {
            get { return _valorart; }
            set { _valorart = _valorart != value ? value : _valorart; }
        }

        public string ObservacionArt
        {
            get { return _obsart; }
            set { _obsart = _obsart != value.Trim() ? value.Trim() : _obsart; }
        }

        public decimal ValorCaja
        {
            get { return _valorcaja; }
            set { _valorcaja = _valorcaja != value ? value : _valorcaja; }
        }

        public string ObservacionCaja
        {
            get { return _obscaja; }
            set { _obscaja = _obscaja != value.Trim() ? value.Trim() : _obscaja; }
        }

        public string PracticaCodigo
        {
            get { return _practicacod; }
            set { _practicacod = _practicacod != value.Trim() ? value.Trim() : _practicacod; }
        }

        public string PracticaDescripcion
        {
            get { return _practicadecr; }
            set { _practicadecr = _practicadecr != value.Trim() ? value.Trim() : _practicadecr; }
        }

        public int FuncionID
        {
            get { return _idfuncion; }
            set { _idfuncion = _idfuncion != value ? value : _idfuncion; }
        }

        public string FuncionCodigo
        {
            get { return _funcioncod; }
            set { _funcioncod = _funcioncod != value.Trim() ? value.Trim() : _funcioncod; }
        }

        public string FuncionDescripcion
        {
            get { return _funciondescr; }
            set { _funciondescr = _funciondescr != value.Trim() ? value.Trim() : _funciondescr; }
        }

        public string FuncionLetra
        {
            get { return _funcionletra; }
            set { _funcionletra = _funcionletra != value.Trim() ? value.Trim() : _funcionletra; }
        }

        public string GrupoDescripcion
        {
            get { return _grupodescr; }
            set { _grupodescr = _grupodescr != value.Trim() ? value.Trim() : _grupodescr; }
        }

        public short GrupoOrden
        {
            get { return _grupoorden; }
            set { _grupoorden = _grupoorden != value ? value : _grupoorden; }
        }

        public int GrupoId
        {
            get { return _grupoid; }
            set { _grupoid = _grupoid != value ? value : _grupoid; }         
        }
               
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = _valor != value ? value : _valor; }
        }

        public bool ValorTipo
        {
            get { return _tipovalor; }
            set { _tipovalor = _tipovalor != value ? value : _tipovalor; }                
        }

        public decimal ValorDefecto
        {
            get { return _valordefecto; }
            set { _valordefecto = _valordefecto != value ? value : _valordefecto; }
        }

        public int OrdenLista
        {
            get { return _ordenlst; }
            set { _ordenlst = _ordenlst != value ? value : _ordenlst; }          
        }

        public bool PracticaIncluir
        {
            get { return _practicaincluida; }
            set { _practicaincluida = _practicaincluida != value ? value : _practicaincluida; }
        }


        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD      
        
        public int ID_Encabezado { get => IDEncabezado; }
        public int ID_PractAm { get => IDPractica;  }

        public string ObsPrepaga { get => ObservacionPrepaga;  }

        public decimal ValorOs { get => ValorObrasocial; }

        public string ObsOs { get => ObservacionObrasocial;  }

        public string ObsArt { get => ObservacionArt;  }

        public string ObsCaja { get => ObservacionCaja;  }
        public bool Incluir { get => PracticaIncluir; }
        public bool TipoValor { get => ValorTipo; }

        public int ID_UsuNew { get => glb.GetIdUsuariolog();  }
        public int ID_UsuModif { get => glb.GetIdUsuariolog();  }
        public DateTime TimeModif { get => DateTime.Now;  }



        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Detalles() { }

        public Detalles(SqlConnection conexion)
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
        public Detalles Clone()
        {
            Detalles d = (Detalles)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Detalles> Clone(List<Detalles> lst)
        {
            List<Detalles> lista = new List<Detalles>();

            foreach (Detalles d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS
        public List<Detalles> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Detalles> lista = new List<Detalles>();

                string c = $"SELECT AD.ID_Registro AS IDRegistro, AD.ID_Encabezado AS IDEncabezado, AD.ID_PractAm AS IDPractica, AD.ValorPrepaga, AD.ObsPrepaga AS ObservacionPrepaga," +
                           $" AD.ValorOs AS ValorObrasocial, AD.ObsOs AS ObservacionObrasocial, AD.ValorArt, AD.ObsArt AS ObservacionArt, AD.ValorCaja, AD.ObsCaja AS ObservacionCaja," +
                           $" PM.Codigo AS PracticaCodigo, UPPER(LEFT(PM.Descripcion,1))+LOWER(SUBSTRING(PM.Descripcion,2,LEN(PM.Descripcion))) AS PracticaDescripcion," +
                           $" FU.Codigo AS FuncionCodigo, FU.Descripcion AS FuncionDescripcion, FU.Letra as FuncionLetra," +
                           $" PG.Orden AS GrupoOrden, PG.Descripcion AS GrupoDescripcion, PM.ID_Grupo AS GrupoId, AD.Valor, AD.TipoValor AS ValorTipo, AD.ValorDefecto," +
                           $" AD.Incluir AS PracticaIncluir, PM.ID_Funcion AS FuncionID" +
                           $" FROM ARANVALORIZADET AD" +
                           $" LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = AD.ID_PractAm)" +
                           $" LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                           $" LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)";                           

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Detalles a = new Detalles();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                //ORDENAMIENTO DE LISTA
                OrdenaLista(lista);
                
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Detalles>();
            }
        }

        //RETORNO LOS DETALLES DE LA MAXIMA VALORIZACION ARANCELARIA CERRADA, PARA CREAR NUEVAS LISTAS
        public List<Detalles> GetLastDetalle()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Detalles> lista = new List<Detalles>();
                
                string c = "SELECT DISTINCT ISNULL(FU.Codigo,'') AS FuncionCodigo, ISNULL(FU.Descripcion, '') as FuncionDescripcion, ISNULL(FU.Letra, '') as FuncionLetra," +
                            " DD.ID_Practica AS IDPractica, ISNULL(PM.Codigo, '') AS PracticaCodigo, " +
                            " UPPER(LEFT(PM.Descripcion,1))+LOWER(SUBSTRING(PM.Descripcion,2,LEN(PM.Descripcion))) AS PracticaDescripcion," +
                            " ISNULL(PG.Descripcion, '') As GrupoDescripcion, PG.Orden as GrupoOrden, PM.ID_Grupo AS GrupoId, " +
                            " PM.ID_Funcion AS FuncionID" +
                            " FROM DISCUSIONDET DD" +                                                        
                            " LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                            " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                            " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                            " WHERE DD.Aplicado = 2 AND DD.ID_Funcion <> 4 AND DD.ID_Funcion <> 10 AND DD.ID_Encabezado > 122";
                
                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Detalles a = new Detalles();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                //ORDENAMIENTO DE LISTA
                OrdenaLista(lista);

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al obtener los últimos detalles.\n{e.Message}", 0);
                return new List<Detalles>();
            }
        }

        public void OrdenaLista(List<Detalles> detallesaran)
        {
            try
            {
                int[] grupos = new int[6] { 1, 2, 3, 5, 30, 32};                 

                //ORDENO POR ENCABEZADO Y RECORRO                
                foreach (int x in detallesaran.GroupBy(g => g.IDEncabezado).Select(s => s.First().IDEncabezado).ToList())
                {
                    int ordnum = 0;

                    foreach (Detalles d in detallesaran.Where(w => w.IDEncabezado == x).GroupBy(g => g.GrupoId).Select(s => s.First()).OrderBy(o => o.GrupoOrden))
                    {
                                                
                        detallesaran.Where(w => w.GrupoId == d.GrupoId && w.IDEncabezado == x)
                                .OrderBy(o => grupos.Contains(d.GrupoId) ? o.PracticaCodigo : o.PracticaDescripcion).ToList()
                                .ForEach(f => f.OrdenLista = ordnum++);                        
                        
                    }
                }
                
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0 && IDEncabezado > 0)
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

          
            campos.Add("ID_Encabezado");
            campos.Add("ID_PractAm");
            campos.Add("ValorPrepaga");
            campos.Add("ObsPrepaga");
            campos.Add("ValorOs");
            campos.Add("ObsOs");
            campos.Add("ValorArt");
            campos.Add("ObsArt");
            campos.Add("ValorCaja");
            campos.Add("ObsCaja");

            campos.Add("Valor");
            campos.Add("TipoValor");
            campos.Add("ValorDefecto");
            campos.Add("Incluir");
                        
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


        #endregion
    }
}
