using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Negociacion.MC
{
    public class Presentacion 
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();        

        #endregion

        private long _idregistro = 0;
        private int _idaranvaloriza = 0;
        private int _idgrupovalor = 0;
        private DateTime _fechaimpacto = DateTime.Now;
        private short _estado = 0;

        private string _grupocodigo = "";
        private string _grupodescripcion = "";
        private string _presttipo = "";
        private string _presttipodescr = "";


        public long IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public DateTime FechaImpacto
        {
            get { return _fechaimpacto; }
            set { _fechaimpacto = _fechaimpacto != value ? value : _fechaimpacto; }
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

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #region CONSULTA DE DATOS
        
        //GLOBAL DE DISCUSIONES PARA ANALISIS
        public List<Presentacion> GetDiscucionglobal(int idarancelenc)
        {
            List<Presentacion> lista = new List<Presentacion>();

            try
            {
             
               /* foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    lista.Add(new Presentacion
                    {
                        //CodigoPrestataria = r["CodigoPrestataria"].ToString().Trim(),
                       // DescPrestataria = r["Prestataria"].ToString().Trim(),
                        
                        
                    });
                }*/

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los datos.\n{e.Message}", 0);
                lista.Clear();
                return lista;
            }
        }

        public List<Presentacion> GetGlobales()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Presentacion> lista = new List<Presentacion>();

                string c = "SELECT DD.ID_Registro AS IDRegistro, DD.ID_Encabezado AS IDEncabezado, DE.FechaImpacto," +
                           " PT.Codigo AS PrestadoraTipoCodigo," +
                           " DD.ID_Practica AS PracticaID, PM.Codigo AS PracicaCodigo, PM.Descripcion AS PracticaDescripcion, PM.ID_Grupo AS GrupoID," +
                           " PG.Descripcion AS GrupoDescripcion, PG.Orden AS GrupoOrden, PG.Observacion AS GrupoObservacion, DD.ID_Funcion AS FuncionID," +
                           " FU.Codigo AS FuncionCodigo, FU.Descripcion AS FuncionDescripcion, FU.Letra AS FuncionLetra, DD.Valor, DD.ValorCoseguro, DD.ValorCopago," +
                           " DD.EsAmdgo," +
                           
                           " ISNULL(STUFF((SELECT DISTINCT ',' + CONCAT( '(', PD.Codigo, ' ', PR.Nombre, ' ', PR.Cuit, ')' )" +
                           " FROM DISCGRPVALHIST DH" +
                           " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           " WHERE DH.ID_Encabezado = DE.ID_Registro" +
                           " FOR XML PATH('')), 1, LEN(','), ''), '') AS Prestataria," +
                           " PRG.Codigo AS AgrupadorCodigo," +
                           " PRG.Descripcion as AgrupadorDescripcion" +

                           //" , ISNULL((SELECT DT.Valor" +
                           //" FROM DISCUSIONDET DT" +
                           //" LEFT OUTER JOIN DISCUSIONENC DE1 ON(DE1.ID_Registro = DT.ID_Encabezado)" +
                           //" WHERE DT.Aplicado = 2 AND DT.ID_Practica = DD.ID_Practica AND DE1.ID_GrupoValor = DE.ID_GrupoValor AND DE1.ID_AranValoriza <> DE.ID_AranValoriza" +
                           //" AND DE1.FechaImpacto = (SELECT MAX(F.FechaImpacto) FROM DISCUSIONENC F WHERE F.FechaImpacto < DE.FechaImpacto AND" +
                           //                                                 " F.ID_GrupoValor = DE.ID_GrupoValor)),0) AS ValorAnterior" +
                           

                           " FROM DISCUSIONDET DD" +
                           " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = DD.ID_Funcion)" +
                           " LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                           " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                           " LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DD.ID_Encabezado)" +
                           " LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = DE.ID_AranValoriza)" +
                           " LEFT OUTER JOIN ARANVALORIZADET AD ON(AD.ID_Encabezado = AE.ID_Registro AND AD.ID_PractAm = DD.ID_Practica)" +
                           " LEFT OUTER JOIN PRESTGRPVAL PRG ON(PRG.ID_Registro = DE.ID_GrupoValor)" +
                           " LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = PRG.ID_PrestaTipo)" +
                           " WHERE DD.Aplicado = 2 " +
                           " AND DE.FechaImpacto = (SELECT MAX(FF.FechaImpacto) FROM DISCUSIONENC FF WHERE FF.ID_AranValoriza = DE.ID_AranValoriza" +
                                                   " AND FF.ID_GrupoValor = DE.ID_GrupoValor AND FF.Estado = 2)";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Presentacion a = new Presentacion();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { typeof(Presentacion).GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                //CALCULO LOCALMENTE EL VALOR ANTERIOR
                /*lista.ForEach(f => f.ValorAnterior = lista.Where(w => w.PracticaID == f.PracticaID && w.AgrupadorID == f.AgrupadorID
                                                                && w.FechaImpacto == lista.Where(r => r.FechaImpacto < f.FechaImpacto && r.AgrupadorID == f.AgrupadorID)
                                                                                           .OrderByDescending(o => o.FechaImpacto)
                                                                                           .Select(s => s.FechaImpacto).FirstOrDefault()
                                                                ).Select(s => s.Valor).FirstOrDefault());*/

                foreach (Presentacion p in lista)
                {
                  //  p.ValorAnterior = lista.Where(w => w.PracticaID == p.PracticaID && w.AgrupadorID == p.AgrupadorID &&
                   //                         w.FechaImpacto < p.FechaImpacto).OrderByDescending(o => o.FechaImpacto).Select(s => s.Valor).FirstOrDefault();
                }

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Presentacion>();
            }
        }


        #endregion


    }
}
