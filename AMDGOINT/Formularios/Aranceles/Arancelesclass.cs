using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ExcelDataReader;
using System.IO;
using DataTable = System.Data.DataTable;
using AMDGOINT.Formularios.Practicas;

namespace AMDGOINT.Formularios.Aranceles
{
    class Arancelesclass
    {
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Practicasclass practicascls = new Practicasclass();

        public List<ArancelesValoriza> arancelesdetallelst = new List<ArancelesValoriza>();
        public List<ArancelesEncabezado> aranencabezados = new List<ArancelesEncabezado>();
        private List<ArancelesValoriza> arancelesdetalle = new List<ArancelesValoriza>();
        public List<ArancelesHistorico> aranceleshistorico = new List<ArancelesHistorico>();
        private List<Practicas.Practicas> practicaslst = new List<Practicas.Practicas>();
        private List<Funcionesstruct> funcioneslst = new List<Funcionesstruct>();
        private List<Arancelesstruct> aranceleslst = new List<Arancelesstruct>();
        private List<Gastosstruct> gastoslst = new List<Gastosstruct>();

        public void ListarAranceles()
        {
            try
            {
                aranencabezados.Clear();

                string c = "SELECT AE.ID_Registro, AE.Fecha, AE.Observaciones, AE.Estado" +
                           " FROM ARANVALORIZAENC AE";

                //LISTO LOS ENCABEZADOS
                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    aranencabezados.Add(new ArancelesEncabezado
                    {
                        IDRegistro = Convert.ToInt32(r["ID_Registro"]),
                        Fecha = Convert.ToDateTime(r["Fecha"]),
                        Observacion = r["Observaciones"].ToString().Trim(),
                        Estado = Convert.ToBoolean(r["Estado"])

                    });
                }

                //DETALLES
                Listardetalles();

                foreach (var r in aranencabezados)
                {
                    r.detalles = arancelesdetalle.Where(s => s.IDEncabezado == r.IDRegistro).ToList();
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los datos.\n {e.Message}", 0);
                return;

            }
        }

        private void Listardetalles()
        {
            arancelesdetalle.Clear();

            try
            {
                string c = "SELECT ARD.ID_Registro, ARD.ID_Encabezado, ISNULL(PM.ID_Registro,0) AS ID_PractAm, ISNULL(PM.Codigo, '') AS Codigo," +
                          " ISNULL(PM.Descripcion, '') AS Descripcion, ISNULL(FU.Codigo,'') AS CodFuncion," +
                          " ISNULL(FU.Descripcion,'') AS DescFuncion, ISNULL(PG.Descripcion,'') As Grupo, ARD.ValorPrepaga, ARD.ValorOs, ARD.ValorArt," +
                          " ARD.ValorCaja, ARD.ObsPrepaga, ARD.ObsOs, ARD.ObsArt, ARD.ObsCaja, ISNULL(PG.Orden,0) as GrupoOrden" +
                          " FROM ARANVALORIZADET ARD" +
                          " LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = ARD.ID_PractAm)" +
                          " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                          " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                          " ORDER BY PG.Orden, PM.Codigo ASC";
                          

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    arancelesdetalle.Add(new ArancelesValoriza
                    {
                        IDRegistro = Convert.ToInt64(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        IDPractAm = Convert.ToInt32(r["ID_PractAm"]),
                        CodigoPractica = r["Codigo"].ToString().Trim(),
                        DescripcionPractica = r["Descripcion"].ToString().Trim(),
                        CodigoFuncion = r["CodFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescFuncion"].ToString().Trim(),
                        GrupoPractica = r["Grupo"].ToString().Trim(),
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        ValorPrepaga = Convert.ToDecimal(r["ValorPrepaga"]),
                        ValorOs = Convert.ToDecimal(r["ValorOs"]),
                        ValorArt = Convert.ToDecimal(r["ValorArt"]),
                        ValorCaja = Convert.ToDecimal(r["ValorCaja"]),
                        ObsPrepaga = r["ObsPrepaga"].ToString().Trim(),
                        ObsOs = r["ObsOs"].ToString().Trim(),
                        ObsArt = r["ObsArt"].ToString().Trim(),
                        ObsCaja = r["ObsCaja"].ToString().Trim()

                    });
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los detalles.\n {e.Message}", 0);
                return;
            }
        }

        public void Agregardetalles()
        {
            try
            {
                arancelesdetallelst.Clear();

                int cantidad = 0;

                //VALIDO SI HAY REGISTROS EN EL ARANDETALLE 
                string ca = "SELECT ISNULL(COUNT(ID_Registro),0) as ID_Registro FROM ARANVALORIZADET";
                DataRow n = func.getColecciondatos(ca).Rows[0];
                cantidad = Convert.ToInt32(n["ID_Registro"]);

                string c = "";

                if (cantidad <= 0)
                {
                    c = "SELECT PM.ID_Registro, PM.Codigo, PM.Descripcion, ISNULL(FU.Codigo,'') AS CodFuncion, ISNULL(FU.Descripcion,'') AS DescFuncion," +
                          " ISNULL(PG.Descripcion,'') As Grupo, 0 AS ValorPrepaga, 0 AS ValorArt, 0 AS ValorOs, 0 AS ValorCaja," +
                          " '' as ObsPrepaga, '' as ObsOs, '' as ObsArt, '' as ObsCaja, PG.Orden AS GrupoOrden" +
                          " FROM PRACTAM PM" +
                          " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                          " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                          " WHERE PM.Estado = 1 AND PM.ID_Funcion <> 4 AND PM.ID_Funcion <> 10";
                }
                else
                {
                    c = "SELECT PM.ID_Registro, PM.Codigo, PM.Descripcion, ISNULL(FU.Codigo, '') AS CodFuncion, ISNULL(FU.Descripcion, '') AS DescFuncion," +
                         " ISNULL(PG.Descripcion, '') As Grupo, AD.ValorPrepaga, AD.ValorArt, AD.ValorOs, AD.ValorCaja," +
                         " AD.ObsPrepaga, AD.ObsOs, AD.ObsArt, AD.ObsCaja, PG.Orden AS GrupoOrden" +
                         " FROM PRACTAM PM" +
                         " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                         " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                         " LEFT OUTER JOIN ARANVALORIZADET AD ON(AD.ID_PractAm = PM.ID_Registro)" +
                         " LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = AD.ID_Encabezado)" +
                         " WHERE PM.Estado = 1 AND PM.ID_Funcion <> 4 AND PM.ID_Funcion <> 10" +
                         " AND AE.Fecha = CASE WHEN AE.Fecha IS NOT NULL THEN(SELECT MAX(ARR.Fecha) FROM ARANVALORIZAENC ARR) END";
                }

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    arancelesdetallelst.Add(new ArancelesValoriza
                    {
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoPractica = r["Codigo"].ToString().Trim(),
                        DescripcionPractica = r["Descripcion"].ToString().Trim(),
                        CodigoFuncion = r["CodFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescFuncion"].ToString().Trim(),
                        GrupoPractica = r["Grupo"].ToString().Trim(),
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        ValorPrepaga = Convert.ToDecimal(r["ValorPrepaga"]),
                        ValorOs = Convert.ToDecimal(r["ValorOs"]),
                        ValorArt = Convert.ToDecimal(r["ValorArt"]),
                        ValorCaja = Convert.ToDecimal(r["ValorCaja"]),
                        ObsPrepaga = r["ObsPrepaga"].ToString().Trim(),
                        ObsOs = r["ObsOs"].ToString().Trim(),
                        ObsArt = r["ObsArt"].ToString().Trim(),
                        ObsCaja = r["ObsCaja"].ToString().Trim()

                    });
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al agregar los detalles.\n {e.Message}", 0);
                return;
            }
        }

        public void CargarHistorico()
        {
            try
            {
                aranceleshistorico.Clear();

                string c = "SELECT AD.ID_Registro, PM.ID_Registro AS ID_PractAm, PM.Codigo AS CodigoPractica, PM.Descripcion as DescripcionPractica," +
                             " ISNULL(FU.Codigo, ' ') as CodigoFuncion, ISNULL(FU.Descripcion, '') AS DescripcionFuncion," +
                             " ISNULL(PG.Descripcion, '') As Grupo, AE.Fecha, AD.ValorOs, AD.ValorPrepaga, AD.ValorCaja, AD.ValorArt," +
                             " YEAR(AE.Fecha) AS Anio, MONTH(AE.Fecha) AS Mes, PG.Orden as GrupoOrden" +
                             " FROM PRACTAM PM" +
                             " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                             " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                             " LEFT OUTER JOIN ARANVALORIZADET AD ON(AD.ID_PractAm = PM.ID_Registro)" +
                             " LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = AD.ID_Encabezado)" +
                             " WHERE AE.Estado = 1 AND PM.ID_Funcion <> 4 AND PM.ID_Funcion <> 10";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    aranceleshistorico.Add(new ArancelesHistorico
                    {
                        IDRegistro = Convert.ToInt64(r["ID_Registro"]),
                        IDPractAm = Convert.ToInt32(r["ID_PractAm"]),
                        Anio = Convert.ToInt32(r["Anio"]),
                        Mes = func.GetMes(Convert.ToInt32(r["Mes"])),
                        CodigoPractica = r["CodigoPractica"].ToString(),
                        DescripcionPractica = r["DescripcionPractica"].ToString(),
                        CodigoFuncion = r["CodigoFuncion"].ToString(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString(),
                        GrupoPractica = r["Grupo"].ToString(),
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        ValorOs = Convert.ToDecimal(r["ValorOs"]),
                        ValorPrepaga = Convert.ToDecimal(r["ValorPrepaga"]),
                        ValorArt = Convert.ToDecimal(r["ValorArt"]),
                        ValorCaja = Convert.ToDecimal(r["ValorCaja"]),
                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al cargar los registros.\n" + e.Message, 0);
                return;
            }
        }

        //LEVANTO EXCEL VALORES OBRA SOCIAL
        public List<EstructuraExcel> ReadExcelos(string pathexcel, int colCodos, int colCodAm, int colDescr, int colObser, int colFunc, int colvalor, int colgasto,
            int fromrow, int torow, int hoja, byte tratdec = 0)
        {
            List<EstructuraExcel> excelimportlst = new List<EstructuraExcel>();

            try
            {
                ListarFunciones();                
                practicaslst.Clear();
                practicascls.GetPracticaslst();
                practicaslst = practicascls.practicaslst.Where(s => s.Estado == true).ToList();

                //CARGO LA LISTA DE PRACTICAS NOMENCLADAS OBTENIDAS DEL EXCEL
                using (var stream = File.Open(pathexcel, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelreader = ExcelReaderFactory.CreateReader(stream);
                    DataTable dt = excelreader.AsDataSet().Tables[hoja - 1];

                    for (int i = (fromrow - 1); i <= torow; i++)
                    {
                        if (i > dt.Rows.Count - 1)
                        {
                            continue;
                        }
                        //CODIGO AM NULL
                        if (string.IsNullOrWhiteSpace(dt.Rows[i][colCodAm] != null ? dt.Rows[i][colCodAm].ToString() : "")) { continue; }
                        //CODIGO DE DESCARTABLE
                        if (dt.Rows[i][colCodAm].ToString().Trim() == "920647") { continue; }
                        //SIN FUNCION POR PRESUPUESTO Y MENOR O IGUAL A CERO
                        if (func.Trydecimalconvert(dt.Rows[i][colvalor].ToString().Trim()) <= 0
                            && Getfuncionnro(dt.Rows[i][colFunc].ToString().Trim()) != 4 && !Esarancelnomenclado(dt.Rows[i][colCodAm].ToString().Trim())) { continue; }

                        excelimportlst.Add(new EstructuraExcel
                        {
                            CodigoOs = dt.Rows[i][colCodos].ToString().Trim(),
                            CodigoAM = dt.Rows[i][colCodAm].ToString().Trim(),
                            Descripcion = Getdescripcion(dt.Rows[i][colCodAm].ToString().Trim(), dt.Rows[i][colDescr].ToString()),
                            Observacion = dt.Rows[i][colObser].ToString().Trim(),
                            IDFuncion = Esarancelnomenclado(dt.Rows[i][colCodAm].ToString().Trim()) ? 0 : Getfuncionnro(dt.Rows[i][colFunc].ToString().Trim()),                                                        
                            Valor = GetValorproc(tratdec,  dt.Rows[i][colvalor].ToString().Trim(), dt.Rows[i][colCodAm].ToString().Trim()),
                            CodigoGasto = Getvaloropcional(dt.Rows[i], colgasto),
                            IDGrupo = GetIdgrupo(dt.Rows[i][colCodAm].ToString().Trim()),
                            GrupoOrden = GetOrdengrupo(dt.Rows[i][colCodAm].ToString().Trim()),
                            GrupoObservacion = GetObsgrupo(dt.Rows[i][colCodAm].ToString().Trim()),
                            GrupoPractica = GetDescgrupo(dt.Rows[i][colCodAm].ToString().Trim())
                        });

                    }

                }

                return excelimportlst;
            }
            catch (Exception e)
            {
                if (e.HResult == -2146233080)
                { ctrl.MensajeInfo($"{e.Message}", 0); }
                else if (e.HResult == -2147024864)
                { ctrl.MensajeInfo("Éste archivo ya esta siendo usado por otro programa, ciérrelo e intente nuevamente.", 1); }
                else { ctrl.MensajeInfo($"Ocurrió un error al leer el archivo excel {e.Message}", 0); }
                return new List<EstructuraExcel>();
            }
        }

        private void ListarFunciones()
        {
            try
            {
                funcioneslst.Clear();

                string c = "SELECT ID_Registro, Codigo, Descripcion, Letra FROM FUNCIONES WHERE Letra <> ''";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    funcioneslst.Add(new Funcionesstruct
                    {
                        IDRegistro = (int)r["ID_Registro"],
                        Codigo = r["Codigo"].ToString().Trim(),
                        Descripcion = r["Descripcion"].ToString().Trim(),
                        Letra = r["Letra"].ToString().Trim()
                    });
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las funciones {e.Message}", 0);
                return;
            }
        }

        private int Getfuncionnro(string letra)
        {
            return funcioneslst.Where(w => w.Letra == letra.ToUpper()).Select(s => s.IDRegistro).DefaultIfEmpty(0).First();
        }

        private decimal GetValorproc(byte tratdec, string val, string codam)
        {
            try
            {
                //VALIDA SI ESTOS CODIGOS VAN SIEMPRE CON DECIMALES. (GASTOS Y GALENOS)
                //CASO CONTRARIO HACE LO SELECCIONADO
                if (Valorcondecimales(codam)) { return decimal.Round(func.Trydecimalconvert(val.Trim()), 2); }
                else
                {
                    if (tratdec == 0) { return decimal.Round(func.Trydecimalconvert(val.Trim()), 2); }
                    else if (tratdec == 1) { return decimal.Round(func.Trydecimalconvert(val.Trim()), MidpointRounding.AwayFromZero); }
                    else if (tratdec == 2) { return decimal.Round(func.Trydecimalconvert(val.Trim()), MidpointRounding.ToEven); }
                    else { return 0; }
                }
                
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private bool Valorcondecimales(string codam)
        {
            switch (codam.ToUpper())
            {
                case "00": return true;
                case "01": return true;
                case "02": return true;
                case "03": return true;
                case "04": return true;
                case "05": return true;
                case "06": return true;
                case "07": return true;
                case "08": return true;
                case "09": return true;
                case "10": return true;
                case "GB": return true;
                case "GI": return true;
                case "GN": return true;
                case "GQ": return true;
                case "GR": return true;
                case "GT": return true;
                case "GU": return true;
                case "OG": return true;
                default: return false;
            }
        }

        private bool Esarancelnomenclado(string codam)
        {
            switch (codam.ToUpper())
            {
                case "00": return true;
                case "01": return true;
                case "02": return true;
                case "03": return true;
                case "04": return true;
                case "05": return true;
                case "06": return true;
                case "07": return true;
                case "08": return true;
                case "09": return true;
                case "10": return true;
                case "N1": return true;
                case "N2": return true;
                case "N3": return true;
                case "N4": return true;
                case "N5": return true;
                case "N6": return true;
                case "N7": return true;
                case "N8": return true;
                case "T1": return true;
                case "T2": return true;
                case "T3": return true;
                case "T4": return true;
                case "T5": return true;
                case "T6": return true;
                case "T7": return true;
                case "T8": return true;
                case "T9": return true;
                case "TA": return true;
                case "GB": return true;
                case "GI": return true;
                case "GN": return true;
                case "GQ": return true;
                case "GR": return true;
                case "GT": return true;
                case "GU": return true;
                case "OG": return true;
                case "G1": return true;
                case "G2": return true;
                case "G3": return true;
                case "G4": return true;
                case "G5": return true;
                case "G6": return true;
                case "G7": return true;
                case "G8": return true;
                case "G9": return true;
                case "P1": return true;
                case "P2": return true;
                case "P3": return true;
                case "P4": return true;
                case "P5": return true;
                case "P6": return true;
                case "P7": return true;
                case "P8": return true;
                case "P9": return true;
                default: return false;
            }
        }

        private string Getdescripcion(string codigo, string text)
        {
            var re = practicaslst.Where(s => s.Codigo == codigo).Select(s => s.Descripcion).FirstOrDefault();

            if (re != null) { return re.ToString(); }
            else { return text.Trim().Replace("'", ""); }

        }

        //PROCESO VALORES PARA AQUELLOS OPCIONALES, SIEMPRE DEVUELVO STRING
        public string Getvaloropcional(DataRow row, int col)
        {
            string retorno = "";

            try
            {
                if (row != null && col >= 0)
                {
                    var valor = row[col];

                    if (valor != null) { retorno = valor.ToString().Trim(); }
                }

                return retorno;
            }
            catch (Exception )
            {
                ctrl.MensajeInfo("Hubo un inconveniente en la importacion, intente nuevamente.", 1);
                return retorno;
            }
        }

        //OBTENGO ID DE GRUPO
        private int GetIdgrupo(string practicacod)
        {
            var re = practicaslst.Where(s => s.Codigo == practicacod).Select(s => s.ID_Grupo).DefaultIfEmpty(0).FirstOrDefault();

            return re;             

        }

        //OBTENGO ORDEN DEL GRUPO
        private int GetOrdengrupo(string practicacod)
        {
            var re = practicaslst.Where(s => s.Codigo == practicacod).Select(s => s.GrupoOrden).DefaultIfEmpty(0).FirstOrDefault();

            return re;

        }

        //OBTENGO OBSERVACION DEL GRUPO
        private string GetObsgrupo(string practicacod)
        {
            var re = practicaslst.Where(s => s.Codigo == practicacod).Select(s => s.GrupoObs).DefaultIfEmpty("").FirstOrDefault();

            return re;

        }

        //OBTENGO DESCRIPCION DEL GRUPO
        private string GetDescgrupo(string practicacod)
        {
            var re = practicaslst.Where(s => s.Codigo == practicacod).Select(s => s.Grupo).DefaultIfEmpty("").FirstOrDefault();

            return re;

        }
    }

    public class ArancelesEncabezado
    {
        public string IDLocal { get; set; } = Guid.NewGuid().ToString();
        public int IDRegistro { get; set; } = 0;
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string Observacion { get; set; } = "";
        public List<ArancelesValoriza> detalles { get; set; } = new List<ArancelesValoriza>();
        public bool Estado { get; set; } = false;

        public ArancelesEncabezado Clone()
        {
            ArancelesEncabezado n = (ArancelesEncabezado)this.MemberwiseClone();
            ArancelesValoriza d = new ArancelesValoriza();

            n.IDLocal = string.Copy(IDLocal);
            n.IDRegistro = this.IDRegistro;
            n.Fecha = this.Fecha;
            n.Observacion = string.Copy(this.Observacion);
            n.Estado = this.Estado;
            n.detalles = d.Clone(this.detalles);

            return n;
        }
    }

    public class ArancelesValoriza
    {
        //PRIVADAS
        private string _Funcion;

        //PUBLICAS        
        public long IDRegistro { get; set; } = 0;
        public int IDEncabezado { get; set; } = 0;
        public int IDPractAm { get; set; } = 0;
        
        public int IDGrupo { get; set; } = 0;
        public string GrupoPractica { get; set; } = "";
        public string GrupoObservacion { get; set; } = "";
        public int GrupoOrden { get; set; } = 0;
        public string CodigoPractica { get; set; } = "";
        public string DescripcionPractica { get; set; } = "";

        public string DescripcionPracticaPrint
        {
            get
            {
                return DescripcionPractica + "\n";
            }
        }

        public string CodigoFuncion { get; set; } = "";
        public string LetraFuncion { get; set; } = "";
        public string DescripcionFuncion { get; set; } = "";
        public string Funcion
        {
            get
            {
                if (CodigoFuncion != "") { _Funcion = CodigoFuncion + " " + DescripcionFuncion; }
                return _Funcion;
            }
        }
        public decimal ValorPrepaga { get; set; } = 0;
        public string ObsPrepaga { get; set; } = "";
        public decimal ValorOs { get; set; } = 0;
        public string ObsOs { get; set; } = "";
        public decimal ValorArt { get; set; } = 0;
        public string ObsArt { get; set; } = "";
        public decimal ValorCaja { get; set; } = 0;
        public string ObsCaja { get; set; } = "";

        public List<ArancelesValoriza> Clone(List<ArancelesValoriza> p)
        {
            List<ArancelesValoriza> n = new List<ArancelesValoriza>();

            foreach (ArancelesValoriza d in p)
            {
                n.Add(new ArancelesValoriza
                {
                    IDRegistro = d.IDRegistro,
                    IDGrupo = d.IDGrupo,
                    GrupoPractica = d.GrupoPractica,
                    GrupoOrden = d.GrupoOrden,
                    IDEncabezado = d.IDEncabezado,
                    IDPractAm = d.IDPractAm,
                    CodigoPractica = d.CodigoPractica,
                    DescripcionPractica = d.DescripcionPractica,
                    CodigoFuncion = d.CodigoFuncion,
                    LetraFuncion = d.LetraFuncion,
                    DescripcionFuncion = d.DescripcionFuncion,
                    ValorPrepaga = d.ValorPrepaga,
                    ObsPrepaga = d.ObsPrepaga,
                    ValorOs = d.ValorOs,
                    ObsOs = d.ObsOs,
                    ValorArt = d.ValorArt,
                    ObsArt = d.ObsArt,
                    ValorCaja = d.ValorCaja,
                    ObsCaja = d.ObsCaja,
                    GrupoObservacion = d.GrupoObservacion

                });
            }

            return n;
        }
    }

    public class ArancelesHistorico : ArancelesValoriza
    {
        public int Anio { get; set; } = 0;
        public string Mes { get; set; } = "";

    }

    public class EstructuraExcel
    {
        private string _newobs = "";

        public string IDRegistro { get; private set; } = Guid.NewGuid().ToString();
        public string CodigoOs { get; set; } = "";
        public string CodigoAM { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int IDFuncion { get; set; } = 0;
        public int IDGasto { get; set; } = 0;
        public int IDArancel { get; set; } = 0;
        public string Observacion { get; set; } = "";
        public string CodigoGasto { get; set; } = "";
        public decimal Valor { get; set; } = 0;
        public string NewObservacion
        {
            get
            {
                if (CodigoGasto.Trim() != "") { _newobs = Observacion + " " + CodigoGasto; }
                else { _newobs = Observacion; }

                return _newobs;
            }
        }
        public int IDGrupo { get; set; } = 0;
        public string GrupoPractica { get; set; } = "";
        public string GrupoObservacion { get; set; } = "";
        public int GrupoOrden { get; set; } = 0;
    }

    public class Funcionesstruct
    {
        public int IDRegistro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Letra { get; set; } = "";
    }

    public class Arancelesstruct
    {
        public int IDRegistro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";        
    }

    public class Gastosstruct
    {
        public int IDRegistro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
    }
}
