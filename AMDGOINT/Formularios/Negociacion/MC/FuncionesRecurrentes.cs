using AMDGOINT.Clases;
using AMDGOINT.Formularios.Negociacion.Vista;
using DevExpress.XtraEditors;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Negociacion.MC
{
    public class FuncionesRecurrentes
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private Practicas.MC.Practica Practica = new Practicas.MC.Practica();
        private List<Practicas.MC.Practica> Nomencladas = new List<Practicas.MC.Practica>();
        private List<Practicas.MC.Practica> Practicas = new List<Practicas.MC.Practica>();
        private List<Detalles> Importados = new List<Detalles>();
        private Practicas.MC.Funcion Funcion = new Practicas.MC.Funcion();
        private List<Practicas.MC.Funcion> Funciones = new List<Practicas.MC.Funcion>();
        private string[] ArancelesNomenclados = new string[46] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
                                                             "GI", "GB", "GN", "GQ", "GR", "GT", "GU", "OG",
                                                             "T1","T2","T3","T4","T5","T6","T7","T8","T9","TA",
                                                             "N1","N2","N3","N4","N5","N6","N7","N8",
                                                             "G1","G2","G3","G4","G5","G6","G7","G8","G9"};

        private string PathExcel = ""; private int FromRow = 0; private int Hoja = 0; private int ToRow = 0; private int ColCodAm = 0; private int ColCodos = 0;
        private int ColDescr = 0; private int ColObser = 0; private int Colvalor = 0; private int ColFunc = 0; private int Colgasto = 0; private byte TratDec = 0;

        #endregion

        #region PROPIEDADES
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public FuncionesRecurrentes() { }

        public FuncionesRecurrentes(SqlConnection conexion)
        {
            SqlConnection = conexion;
            Practica.SqlConnection = SqlConnection;
            Nomencladas.AddRange(Practica.GetNomencladas());
        }

        #endregion

        //RETORNO DE UNIDADES SEGUN PRACTICA
        public decimal Getunidadgaleno(string codigopractica)
        {
            try
            {
                return Nomencladas.Where(w => w.Codigo == codigopractica).Select(s => s.UnidadGaleno).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public decimal Getunidadgasto(string codigopractica)
        {
            try
            {
                return Nomencladas.Where(w => w.Codigo == codigopractica).Select(s => s.UnidadGasto).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public short Getcantidadayudantes(string codigopractica)
        {
            try
            {
                return Nomencladas.Where(w => w.Codigo == codigopractica).Select(s => s.AyudanteCantidad).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public decimal Getunidadayudantes(string codigopractica)
        {
            try
            {
                return Nomencladas.Where(w => w.Codigo == codigopractica).Select(s => s.AyudanteUnidad).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //PARAMETRO DE TIPO PROPUESTA   
        private bool GetPropuestoPor()
        {
            try
            {
                Usr_Parametros Parametros = new Usr_Parametros();

                XtraDialog.Show(Parametros, "Parámetros de edición", MessageBoxButtons.OKCancel);
                bool retorno = Parametros.PropuestoPor;
                Parametros.Dispose();
                return retorno;

            }
            catch (Exception)
            {
                return true;
            }
        }

        //COPIA DE VALORES
        public void CopiaValores(List<Detalles> detalles, DateTime fechacopia)
        {
            try
            {
                bool esamdgo = GetPropuestoPor();
                DateTime nuevafecha = DateTime.Now;
                Detalles _det = new Detalles();
                List<Detalles> nuevalista = _det.Clone(detalles.Where(w => w.FechaNegociacion == fechacopia).ToList());

                foreach (Detalles d in nuevalista)
                {
                    d.FechaNegociacion = nuevafecha;
                    d.EsAmdgo = esamdgo;
                    d.Aplicado = 0;
                }

                detalles.AddRange(nuevalista);
            }
            catch (Exception)
            {

            }
        }

        //AGREGAR DETALLES DESDE ULTIMA NEGOCIACION
        public void GeneraDetalles(Negociacion negociacion)
        {
            try
            {
                bool esamdgo = GetPropuestoPor();
                Detalles detalles = new Detalles(SqlConnection);
                List<Detalles> det = detalles.GetRegistros(negociacion.AgrupadorID);

                if (det.Count > 0)
                {
                    //Fijo la nueva fecha
                    DateTime date = DateTime.Now;

                    //Asigno los parámetros correctos
                    foreach (Detalles d in det)
                    {
                        d.FechaNegociacion = date;
                        d.IDEncabezado = negociacion.IDRegistro;
                        d.EsAmdgo = esamdgo;
                        d.Aplicado = 0;
                    }

                    //los inserto en la negociación
                    negociacion.Detalles.AddRange(det);
                }
                else
                {

                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el detalle.\n{e.Message}", 1);
                return;
            }
        }

        //EXPORTACION

        //IMPORTACION         
        #region IMPORTACIONES

        public void ProcesaExcel(Negociacion negociacion)
        {
            try
            {
                //PREPARO PRACTICAS Y FUNCIONES
                Importados.Clear();
                Practicas.Clear();
                Practicas.AddRange(Practica.GetRegistros());
                Funciones.Clear();
                Funciones.AddRange(Funcion.GetRegistros());

                bool esamdgo = GetPropuestoPor();
                Frm_Importacion frmimport = new Frm_Importacion();
                if (frmimport.ShowDialog() == DialogResult.OK)
                {
                    PathExcel = frmimport.PathExcel;
                    FromRow = frmimport.FromRow;
                    Hoja = frmimport.Hoja;
                    ToRow = frmimport.ToRow;
                    ColCodAm = frmimport.ColCodAm;
                    ColCodos = frmimport.ColCodos;
                    ColDescr = frmimport.ColDescr;
                    ColObser = frmimport.ColObser;
                    Colvalor = frmimport.Colvalor;
                    ColFunc = frmimport.ColFunc;
                    Colgasto = frmimport.Colgasto;
                    TratDec = frmimport.TratamDecimal;

                    LeerExcel(esamdgo);

                    negociacion.Detalles.AddRange(Importados);
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LeerExcel(bool esamdgo)
        {
            try
            {
                //CARGO LA LISTA DE PRACTICAS NOMENCLADAS OBTENIDAS DEL EXCEL
                using (var stream = File.Open(PathExcel, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelreader = ExcelReaderFactory.CreateReader(stream);
                    DataTable dt = excelreader.AsDataSet().Tables[Hoja - 1];
                    DateTime date = DateTime.Now;
                    for (int i = (FromRow - 1); i <= ToRow; i++)
                    {
                        if (i > dt.Rows.Count - 1) { continue; }

                        //CODIGO AM NULL
                        if (string.IsNullOrWhiteSpace(dt.Rows[i][ColCodAm] != null ? dt.Rows[i][ColCodAm].ToString() : "")) { continue; }

                        //CODIGO DE DESCARTABLE
                        if (dt.Rows[i][ColCodAm].ToString().Trim() == "920647") { continue; }

                        //SIN FUNCION POR PRESUPUESTO Y MENOR O IGUAL A CERO
                        if (func.Trydecimalconvert(dt.Rows[i][Colvalor].ToString().Trim()) <= 0 && Getfuncionnro(dt.Rows[i][ColFunc].ToString().Trim()) != 4
                                     && !Esarancelnomenclado(dt.Rows[i][ColCodAm].ToString().Trim())) { continue; }

                        string a = Practicas.Where(w => w.Codigo == dt.Rows[i][ColCodAm].ToString().Trim() && w.FuncionLetra == dt.Rows[i][ColFunc].ToString().Trim()).Select(s => s.Descripcion).DefaultIfEmpty(string.Empty).FirstOrDefault();
                        string something = dt.Rows[i][ColCodos].ToString().Trim() == "" ? dt.Rows[i][ColCodAm].ToString().Trim() : dt.Rows[i][ColCodos].ToString().Trim();
                        Importados.Add(new Detalles
                        {
                            PracticaID = Practicas.Where(w => w.Codigo == dt.Rows[i][ColCodAm].ToString().Trim() && w.FuncionLetra == dt.Rows[i][ColFunc].ToString().Trim()).Select(s => s.IDRegistro).DefaultIfEmpty(0).FirstOrDefault(),
                            PracticaCodigo = dt.Rows[i][ColCodAm].ToString().Trim(),
                            PracticaCodigoos = string.IsNullOrWhiteSpace(dt.Rows[i][ColCodos].ToString()) ? dt.Rows[i][ColCodAm].ToString().Trim() : dt.Rows[i][ColCodos].ToString().Trim(),
                            PracticaDescripcion = Practicas.Where(w => w.Codigo == dt.Rows[i][ColCodAm].ToString().Trim() && w.FuncionLetra == dt.Rows[i][ColFunc].ToString().Trim()).Select(s => s.Descripcion).DefaultIfEmpty(string.Empty).FirstOrDefault(),
                            FuncionCodigo = Funciones.Where(w => w.Letra == dt.Rows[i][ColFunc].ToString().Trim().ToUpper()).Select(s => s.Codigo).DefaultIfEmpty("").FirstOrDefault(),
                            FuncionDescripcion = Funciones.Where(w => w.Letra == dt.Rows[i][ColFunc].ToString().Trim().ToUpper()).Select(s => s.Descripcion).DefaultIfEmpty("").FirstOrDefault(),
                            FuncionLetra = Funciones.Where(w => w.Letra == dt.Rows[i][ColFunc].ToString().Trim().ToUpper()).Select(s => s.Letra).DefaultIfEmpty("").FirstOrDefault(),
                            FuncionID = Funciones.Where(w => w.Letra == dt.Rows[i][ColFunc].ToString().Trim().ToUpper()).Select(s => s.IDRegistro).DefaultIfEmpty(0).FirstOrDefault(),
                            GrupoID = Practicas.Where(w => w.Codigo == dt.Rows[i][ColCodAm].ToString().Trim() && w.FuncionLetra == dt.Rows[i][ColFunc].ToString().Trim()).Select(s => s.IDGrupo).DefaultIfEmpty(0).FirstOrDefault(),
                            GrupoOrden = Practicas.Where(w => w.Codigo == dt.Rows[i][ColCodAm].ToString().Trim() && w.FuncionLetra == dt.Rows[i][ColFunc].ToString().Trim()).Select(s => s.GrupoOrden).DefaultIfEmpty((short)0).FirstOrDefault(),
                            GrupoDescripcion = Practicas.Where(w => w.Codigo == dt.Rows[i][ColCodAm].ToString().Trim() && w.FuncionLetra == dt.Rows[i][ColFunc].ToString().Trim()).Select(s => s.GrupoDescripcion).DefaultIfEmpty(string.Empty).FirstOrDefault(),
                            GastoCodigo = Getvaloropcional(dt.Rows[i], Colgasto),
                            Observacion = dt.Rows[i][ColObser].ToString().Trim(),
                            Valor = GetValorproc(TratDec, dt.Rows[i][Colvalor].ToString().Trim(), dt.Rows[i][ColCodAm].ToString().Trim()),
                            FechaNegociacion = date,
                            EsAmdgo = esamdgo

                        });

                      /*  excelimportlst.Add(new EstructuraExcel
                        {
                            CodigoOs = dt.Rows[i][ColCodos].ToString().Trim(),
                            CodigoAM = dt.Rows[i][ColCodAm].ToString().Trim(),
                            Descripcion = Getdescripcion(dt.Rows[i][ColCodAm].ToString().Trim(), dt.Rows[i][ColDescr].ToString()),
                            Observacion = dt.Rows[i][ColObser].ToString().Trim(),
                            IDFuncion = Esarancelnomenclado(dt.Rows[i][ColCodAm].ToString().Trim()) ? 0 : Getfuncionnro(dt.Rows[i][ColFunc].ToString().Trim()),
                            Valor = GetValorproc(TratDec, dt.Rows[i][Colvalor].ToString().Trim(), dt.Rows[i][ColCodAm].ToString().Trim()),
                            CodigoGasto = Getvaloropcional(dt.Rows[i], Colgasto),
                            IDGrupo = GetIdgrupo(dt.Rows[i][ColCodAm].ToString().Trim()),
                            GrupoOrden = GetOrdengrupo(dt.Rows[i][ColCodAm].ToString().Trim()),
                            GrupoObservacion = GetObsgrupo(dt.Rows[i][ColCodAm].ToString().Trim()),
                            GrupoPractica = GetDescgrupo(dt.Rows[i][ColCodAm].ToString().Trim())
                        });*/

                    }

                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al importar el archivo.\n{e.Message}", 1);
                return;
            }
        }

        private int Getfuncionnro(string letra)
        {
            return Funciones.Where(w => w.Letra == letra.ToUpper()).Select(s => s.IDRegistro).DefaultIfEmpty(0).First();
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

        private string Getdescripcion(string codigo, string text)
        {
            var re = Practicas.Where(s => s.Codigo == codigo).Select(s => s.Descripcion).FirstOrDefault();

            if (re != null) { return re.ToString(); }
            else { return text.Trim().Replace("'", ""); }

        }

        private bool Esarancelnomenclado(string codam)
        {
            if (ArancelesNomenclados.Where(w => w == codam).ToList().Count > 0) { return true; }
            else { return false; }
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

        #endregion

    }
}
