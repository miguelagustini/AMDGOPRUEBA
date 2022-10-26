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

namespace AMDGOINT.Formularios.Negociacion.MC
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
        private static string tablaname = "XDISCUSIONDET";
        private static string tablaname2 = "XDISCUSIONENC";

        private long _idregistro = 0;
        private int _idencabezado = 0;
        private DateTime _fechaneg = DateTime.Now;
        private int _idpractica = 0;
        private string _practicacodigoos = "";
        private int _idfuncion = 0;
        private string _observacion = "";
        private string _codigogasto = "";
        private decimal _valor = 0;
        private decimal _valorcoseguro = 0;
        private decimal _valorcopago = 0;
        private bool _esamdgo = false; // FALSE = PRESTATARIA / TRUE = ES AMDGO
        private short _aplicado = 0;
        private decimal _valoranterior = 0;
        private decimal _valoranteriorpactado = 0;
        private decimal _valornomenclado = 0;        

        private string _practicacod = "";
        private string _practicadesc = "";
        private string _funcletra = "";
        private string _funcdescripc = "";
        private string _funccodigo = "";
        private int _idgrupopract = 0;
        private string _grupocodigo = "";
        private string _grupodescripcion = "";
        private string _grupoobs = "";
        private short _grupoorden = 0;
        private int _idagrupador = 0;
        private int _idarancelb = 0;
        private int _idgaleno = 0;
        private int _idgasto = 0;

        private DateTime _fechaimpacto = new DateTime();
        private int _ordenlst = 0;

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

        public DateTime FechaNegociacion
        {
            get { return _fechaneg; }
            set { _fechaneg = _fechaneg != value ? value : _fechaneg; }
        }

        public TimeSpan HoraNegociacion
        {
            get { return FechaNegociacion.TimeOfDay; }
            
        }
        
        public int Anio
        {
           get { return FechaNegociacion.Year; }           
        }

        public int Mes
        {
            get { return FechaNegociacion.Month; }
        }

        public int Dia
        {
            get { return FechaNegociacion.Day; }
        }

        public TimeSpan Hora
        {
            get { return FechaNegociacion.TimeOfDay; }
        }

        public int PracticaID
        {
            get { return _idpractica; }
            set { _idpractica = _idpractica != value ? value : _idpractica; }
        }

        public string PracticaCodigo
        {
            get { return _practicacod; }
            set { _practicacod = _practicacod != value.Trim() ? value.Trim() : _practicacod; }
        }

        public string PracticaDescripcion
        {
            get { return _practicadesc; }
            set { _practicadesc = _practicadesc != value.Trim() ? value.Trim() : _practicadesc; }
        }

        public string PracticaCodigoos
        {
            get { return _practicacodigoos; }
            set { _practicacodigoos = _practicacodigoos != value.Trim() ? value.Trim() : _practicacodigoos; }
        }

        public int GalenoID
        {
            get { return _idgaleno; }
            set { _idgaleno = _idgaleno != value ? value : _idgaleno; }
        }

        public int GastoID
        {
            get { return _idgasto; }
            set { _idgasto = _idgasto != value ? value : _idgasto; }
        }
        
        public int GrupoID
        {
            get { return _idgrupopract; }
            set { _idgrupopract = _idgrupopract != value ? value : _idgrupopract; }
        }

        public string GrupoCodigo
        {
            get { return _grupocodigo; }
            set { _grupocodigo = _grupocodigo != value.Trim() ? value.Trim() : _grupocodigo; }
        }

        public string GrupoDescripcion
        {
            get { return _grupodescripcion; }
            set { _grupodescripcion = _grupodescripcion != value.Trim() ? value.Trim() : _grupodescripcion; }
        }

        public string GrupoObservacion
        {
            get { return _grupoobs; }
            set { _grupoobs = _grupoobs != value.Trim() ? value.Trim() : _grupoobs; }
        }

        public short GrupoOrden
        {
            get { return _grupoorden; }
            set { _grupoorden = _grupoorden != value ? value : _grupoorden; }
        }

        public int FuncionID
        {
            get { return _idfuncion; }
            set { _idfuncion = _idfuncion != value ? value : _idfuncion; }
        }

        public string FuncionCodigo
        {
            get { return _funccodigo; }
            set { _funccodigo = _funccodigo != value.Trim() ? value.Trim() : _funccodigo; }
        }

        public string FuncionDescripcion
        {
            get { return _funcdescripc; }
            set { _funcdescripc = _funcdescripc != value.Trim() ? value.Trim() : _funcdescripc; }
        }

        public string FuncionLetra
        {
            get { return _funcletra; }
            set { _funcletra = _funcletra != value.Trim() ? value.Trim() : _funcletra; }
        }

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public string GastoCodigo
        {
            get { return _codigogasto; }
            set { _codigogasto = _codigogasto != value.Trim() ? value.Trim() : _codigogasto; }
        }

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = _valor != value ? value : _valor; }
        }

        public decimal ValorCoseguro
        {
            get { return _valorcoseguro; }
            set { _valorcoseguro = _valorcoseguro != value ? value : _valorcoseguro; }
        }

        public decimal ValorCopago
        {
            get { return _valorcopago; }
            set { _valorcopago = _valorcopago != value ? value : _valorcopago; }
        }

        public bool EsAmdgo
        {
            get { return _esamdgo; }
            set { _esamdgo = _esamdgo != value ? value : _esamdgo; }
        }

        public string PropuestoPor
        {
            get { return EsAmdgo ? "AM" : "OS"; }            
        }

        public short Aplicado
        {
            get { return _aplicado; }
            set { _aplicado = _aplicado != value ? value : _aplicado; }
        }

        //VALOR ANTERIOR NEGOCIADO
        public decimal ValorAnterior
        {
            get { return _valoranterior; }
            set { _valoranterior = _valoranterior != value ? value : _valoranterior; }
        }
        //VALOR ANTERIOR PACTADO
        public decimal ValorAnteriorPactado
        {
            get { return _valoranteriorpactado; }
            set { _valoranteriorpactado = _valoranteriorpactado != value ? value : _valoranteriorpactado; }
        }

        public decimal ValorNomenclado
        {
            get { return _valornomenclado; }
            set { _valornomenclado = _valornomenclado != value ? value : _valornomenclado; }
        }

        public decimal DifPactadoFijo
        {
            get
            {
                decimal calc = 0;

                if (Valor > 0 && ValorAnteriorPactado > 0)
                {
                    calc = Valor - ValorAnteriorPactado;
                }

                return calc;
            }
        }

        public decimal DifPactadoPorc
        {
            get
            {
                decimal calc = 0;

                if (ValorAnteriorPactado > 0 && Valor > 0)
                {
                    calc = Math.Round(((Valor / ValorAnteriorPactado) * 100) - 100, 2);
                }

                return calc;
            }
        }

        public decimal DifPedidoFijo
        {
            get
            {
                decimal calc = 0;

                if (Valor > 0 && ValorAnterior > 0)
                {
                    calc = Valor - ValorAnterior;
                }

                return calc;
            }
        }

        public decimal DifPedidoPorc
        {
            get
            {
                decimal calc = 0;

                if (ValorAnterior > 0 && Valor > 0)
                {
                    calc = Math.Round(((Valor / ValorAnterior) * 100) - 100, 2);
                }

                return calc;
            }
        }

        public decimal DifNomencladoFijo
        {
            get
            {
                decimal calc = 0;

                if (Valor > 0 && ValorNomenclado > 0)
                {
                    calc = Valor - ValorNomenclado;
                }

                return calc;
            }
        }

        public decimal DifNomencladoPorc
        {
            get
            {
                decimal calc = 0;

                if (ValorNomenclado > 0 && Valor > 0)
                {
                    calc = Math.Round(((Valor / ValorNomenclado) * 100) - 100, 2);
                }

                return calc;
            }
        }

        public int AgrupadorID
        {
            get { return _idagrupador; }
            set { _idagrupador = _idagrupador != value ? value : _idagrupador; }
        }

        public int ArancelID
        {
            get { return _idarancelb; }
            set { _idarancelb = _idarancelb != value ? value : _idarancelb; }
        }

        public DateTime FechaImpacto
        {
            get { return _fechaimpacto; }
            set { _fechaimpacto = _fechaimpacto != value ? value : _fechaimpacto; }
        }

        public int OrdenLista
        {
            get { return _ordenlst; }
            set { _ordenlst = _ordenlst != value ? value : _ordenlst; }
        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD        
        public int ID_UsuNew { get => glb.GetIdUsuariolog(); }
        public int ID_UsuModif { get => glb.GetIdUsuariolog(); }        
        public DateTime TimeModif { get => DateTime.Now; }

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

        #region PROPERTYCHANGED
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
        public Detalles Clone()
        {
            Detalles d = (Detalles)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Detalles> Clone(List<Detalles> lst)
        {
            List<Detalles> lista = new List<Detalles>();

            lst.ForEach(f => lista.Add(f.Clone()));
            
            return lista;
        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Detalles> GetRegistros(int idencabezado, bool s = true)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Detalles> lista = new List<Detalles>();

                string c = $"SELECT DD.ID_Registro AS IDRegistro, DD.ID_Encabezado AS IDEncabezado, DD.FechaNeg AS FechaNegociacion, DD.ID_Practica AS PracticaID, DD.ID_Funcion AS FuncionID," +
                           $" FU.Codigo AS FuncionCodigo, FU.Descripcion as FuncionDescripcion, FU.Letra as FuncionLetra, PM.ID_Gasto AS GastoID, PM.ID_Arancel AS GalenoID," +
                           $" DD.Valor, DD.ValorCoseguro, DD.ValorCopago, PM.Codigo AS PracticaCodigo, PM.Descripcion AS PracticaDescripcion," +
                           $" PG.Descripcion As GrupoDescripcion, PG.Orden as GrupoOrden, PM.ID_Grupo AS GrupoID, PG.Observacion AS GrupoObservacion," +
                           $" DD.CodigoOs AS PracticaCodigoos, DD.Observacion, DD.EsAmdgo, DD.Aplicado, DD.CodigoGasto AS GastoCodigo," +
                           $" DE.ID_GrupoValor AS AgrupadorID, DE.ID_AranValoriza AS ArancelID, DE.FechaImpacto," +
                           $" ISNULL((SELECT TOP 1 DT.Valor" +
                                    $" FROM DISCUSIONDET DT" +
                                    $" WHERE DT.Aplicado = 2 AND DT.ID_Practica = DD.ID_Practica" +
                                    $" AND DT.ID_Encabezado = (SELECT TOP 1 F.ID_Registro" +
                                    $" FROM DISCUSIONENC F" +
                                    $" WHERE F.FechaImpacto < DE.FechaImpacto" +
                                    $" AND F.ID_GrupoValor = DE.ID_GrupoValor" +
                                    $" AND F.ID_AranValoriza<> DE.ID_AranValoriza" +
                                    $" AND F.Estado = 2" +
                                    $" ORDER BY F.FechaImpacto DESC)),0) AS ValorAnteriorPactado," +
                           $" ISNULL((SELECT TOP 1 DT.Valor" +
                                   $" FROM DISCUSIONDET DT" +
                                   $" WHERE DT.Aplicado = 2 AND DT.ID_Practica = DD.ID_Practica" +
                                   $" AND DT.ID_Encabezado = (SELECT TOP 1 F.ID_Registro" +
                                   $" FROM DISCUSIONENC F" +
                                   $" WHERE F.FechaImpacto < DE.FechaImpacto" +
                                   $" AND F.ID_GrupoValor = DE.ID_GrupoValor" +
                                   $" ORDER BY F.FechaImpacto DESC)),0) AS ValorAnterior" +
                           $" FROM {tablaname2} DE" +
                           $" LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = DE.ID_AranValoriza)" +
                           $" LEFT OUTER JOIN {tablaname} DD ON(DD.ID_Encabezado = DE.ID_Registro)" +
                           $" LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = DD.ID_Funcion)" +
                           $" LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                           $" LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                           $" WHERE DE.ID_Registro = {idencabezado}";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Detalles>(rdr));
                }
                
                cnn.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Detalles>();
            }
        }



        //PARA GENERAR DETALLES
        public List<Detalles> GetRegistros(int idagrupador)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Detalles> lista = new List<Detalles>();

                string c = $"SELECT DD.ID_Registro AS IDRegistro, DD.ID_Encabezado AS IDEncabezado, DD.FechaNeg AS FechaNegociacion, DD.ID_Practica AS PracticaID, DD.ID_Funcion AS FuncionID," +
                           $" FU.Codigo AS FuncionCodigo, FU.Descripcion as FuncionDescripcion, FU.Letra as FuncionLetra, PM.ID_Gasto AS GastoID, PM.ID_Arancel AS GalenoID," +
                           $" DD.Valor, DD.ValorCoseguro, DD.ValorCopago, PM.Codigo AS PracticaCodigo, PM.Descripcion AS PracticaDescripcion," +
                           $" PG.Descripcion As GrupoDescripcion, PG.Orden as GrupoOrden, PM.ID_Grupo AS GrupoID, PG.Observacion AS GrupoObservacion," +
                           $" DD.CodigoOs AS PracticaCodigoos, DD.Observacion, DD.EsAmdgo, DD.Aplicado, DD.CodigoGasto AS GastoCodigo," +
                           $" DE.ID_GrupoValor AS AgrupadorID, DE.ID_AranValoriza AS ArancelID, DE.FechaImpacto" +                          
                           $" FROM {tablaname} DD" +                           
                           $" LEFT OUTER JOIN {tablaname2} DE ON(DD.ID_Encabezado = DE.ID_Registro)" +                           
                           $" LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = DD.ID_Funcion)" +
                           $" LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                           $" LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                           $" WHERE DE.ID_GrupoValor = {idagrupador}" +
                           $" AND DE.FechaImpacto = (SELECT MAX(DE1.FechaImpacto) FROM DISCUSIONENC DE1 WHERE DE1.ID_GrupoValor = {idagrupador} AND DE1.Estado = 2)";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Detalles>(rdr));
                }

                cnn.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Detalles>();
            }
        }

        public void OrdenaLista(List<Detalles> detallesaran)
        {
            try
            {
                int[] grupos = new int[6] { 1, 2, 3, 5, 30, 32 };

                //ORDENO POR ENCABEZADO Y RECORRO                
                foreach (int x in detallesaran.GroupBy(g => g.IDEncabezado).Select(s => s.First().IDEncabezado).ToList())
                {
                    int ordnum = 0;

                     foreach (Detalles d in detallesaran.Where(w => w.IDEncabezado == x).GroupBy(g => g.GrupoID).Select(s => s.First()).OrderBy(o => o.GrupoOrden))
                     {
                          foreach (Detalles k in detallesaran.Where(w => w.GrupoID == d.GrupoID && w.IDEncabezado == x).GroupBy(g => g.PracticaID)
                                                             .OrderBy(o => grupos.Contains(d.GrupoID) ? o.First().PracticaCodigo : o.First().PracticaDescripcion).ToList()
                                                             .Select(s => s.First()))

                          {

                              detallesaran.Where(w => w.GrupoID == d.GrupoID && w.IDEncabezado == x && w.PracticaID == k.PracticaID).ToList()
                                  .ForEach(f => f.OrdenLista = ordnum);

                              ordnum++;
                          }
                     }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        public void DefineValorPactado(List<Detalles> globaldetails, List<Detalles> destinodetails)
        {
            try
            {
                foreach (Detalles n in destinodetails)
                {
                    n.ValorAnteriorPactado = globaldetails.Where(w => w.PracticaID == n.PracticaID && w.AgrupadorID == n.AgrupadorID && w.ArancelID != n.ArancelID && w.Aplicado == 2 &&
                                                            w.FechaImpacto < n.FechaImpacto).OrderByDescending(o => o.FechaImpacto)
                                                            .Select(s => s.Valor).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el ultimo valor pactado.\n{e.Message}", 1);
                return;
            }
        }

        public void DefineValorAnterior(List<Detalles> globaldetails, List<Detalles> destinodetails)
        {
            try
            {
                foreach (Detalles n in destinodetails)
                {
                    n.ValorAnterior = globaldetails.Where(w => w.PracticaID == n.PracticaID && w.AgrupadorID == n.AgrupadorID && w.FechaNegociacion < n.FechaNegociacion).OrderByDescending(o => o.FechaNegociacion)
                                                            .Select(s => s.Valor).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el ultimo valor pactado.\n{e.Message}", 1);
                return;
            }
        }

        public void DefineValorNomenclado(List<Detalles> detalleslst)
        {
            try
            {
                Practicas.MC.Practica pnomenclada = new Practicas.MC.Practica(SqlConnection);
                List<Practicas.MC.Practica> nomencladas = pnomenclada.GetNomencladas();

                decimal costogaleno = 0;
                decimal costogasto = 0;
                decimal costoayudante = 0;
                decimal total = 0;

                foreach (Detalles d in detalleslst.Where(w => nomencladas.Any(c => c.Codigo.Contains(w.PracticaCodigo))))
                {
                    Practicas.MC.Practica _practica = nomencladas.Where(w => w.Codigo == d.PracticaCodigo).FirstOrDefault();

                    if (_practica == null) { continue; }

                    costogaleno = 0;
                    costogasto = 0;
                    costoayudante = 0;
                    total = 0;
                    
                    //SI LA PRACTICA ES FUNCION HONORARIOS
                    if (d.FuncionLetra == "H" || d.FuncionLetra == "P")
                    {
                        costogaleno = detalleslst.Where(w => w.FechaNegociacion == d.FechaNegociacion && w.GalenoID == _practica.IDGaleno)
                                              .Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault() * _practica.UnidadGaleno;
                    }

                    if (d.FuncionLetra == "HA" || d.FuncionLetra == "P")
                    {
                        costoayudante = (detalleslst.Where(w => w.FechaNegociacion == d.FechaNegociacion && w.GalenoID == _practica.IDGaleno)
                                            .Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault() * (_practica.AyudanteCantidad * _practica.AyudanteUnidad));
                    }

                    if (d.FuncionLetra == "G" || d.FuncionLetra == "P")
                    {
                        costogasto = detalleslst.Where(w => w.FechaNegociacion == d.FechaNegociacion && w.GastoID == _practica.IDGasto)
                                              .Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault() * _practica.UnidadGasto;
                    }

                    total = costogaleno + costogasto + costoayudante;

                    d.ValorNomenclado = decimal.Round(total, MidpointRounding.AwayFromZero);
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al obtener el valor nomenclado.\n{e.Message}", 1);
                return;
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

            campos.Add("Guid");
          

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
