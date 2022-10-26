using AMDGOINT.Clases;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Reclamos.MC
{
    public class ImportaDebitosCreditos
    {
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private Funciones func = new Funciones();
        public List<ImportacionDebitosEstructura> ItemsImportados { get; set; } = new List<ImportacionDebitosEstructura>();

        public Dictionary<short, string> ImportaExcels(string path)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                Dictionary<short, string> diccion = new Dictionary<short, string>();

                ItemsImportados.Clear();
                string[] strFiles = Directory.GetFiles(path);

                int col_movpcoda = -1, col_movpdebito = -1, col_movpcredito = -1, col_movpmotivo = -1, col_movpcdob = -1, col_movpprof = -1, col_movpadmi = -1, col_movppefa = -1,
                    col_movpcomprobante = -1;


                int _movpcoda = 0;
                decimal _movpdebito = 0, _movpcredito = 0;
                string _movpmotivo = "", _movpcdob = "", _movpprof = "", _movpadmi = "", _movppefa = "", _movpcomprobante = "";


                //POR CADA EXCEL
                foreach (string xls in strFiles)
                {
                    //COLUMNAS
                    col_movpcoda = -1; col_movpdebito = -1; col_movpcredito = -1; col_movpmotivo = -1; col_movpcdob = -1; col_movpprof = -1; col_movpadmi = -1; col_movppefa = -1;
                    col_movpcomprobante = -1;
                    //FILAS
                    _movpcoda = 0;
                    _movpdebito = 0; _movpcredito = 0;
                    _movpmotivo = ""; _movpcdob = ""; _movpprof = ""; _movpadmi = ""; _movppefa = ""; _movpcomprobante = "";

                    try
                    {
                        //CARGO LA LISTA DE PRACTICAS NOMENCLADAS OBTENIDAS DEL EXCEL
                        using (var stream = File.Open(xls, FileMode.Open, FileAccess.Read))
                        {
                            IExcelDataReader excelreader = ExcelReaderFactory.CreateReader(stream);
                            DataTable dt = excelreader.AsDataSet().Tables[0]; //SIEMPRE LA HOJA 1
                                                        
                            //DETERMINO LAS POSICIONES DE LAS COLUMNAS DESDE LA FILA 0
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && dt.Rows[0].ItemArray[j].ToString().ToLower() == "id") { col_movpcoda = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && dt.Rows[0].ItemArray[j].ToString().ToLower() == "debito") { col_movpdebito = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && dt.Rows[0].ItemArray[j].ToString().ToLower() == "creditos") { col_movpcredito = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && (dt.Rows[0].ItemArray[j].ToString().ToLower() == "obra social" || dt.Rows[0].ItemArray[j].ToString().ToLower() == "prestataria")) { col_movpcdob = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && dt.Rows[0].ItemArray[j].ToString().ToLower() == "codigo") { col_movpprof = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && (dt.Rows[0].ItemArray[j].ToString().ToLower() == "descripcion-motivo debito credito" || dt.Rows[0].ItemArray[j].ToString().ToLower() == "motivo")) { col_movpmotivo = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && (dt.Rows[0].ItemArray[j].ToString().ToLower() == "num.adm. autorizac" || dt.Rows[0].ItemArray[j].ToString().ToLower() == "autorizacion")) { col_movpadmi = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && dt.Rows[0].ItemArray[j].ToString().ToLower() == "periodo") { col_movppefa = j; continue; }
                                if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[j].ToString()) && dt.Rows[0].ItemArray[j].ToString().ToLower() == "comprobante") { col_movpcomprobante = j; continue; }
                                
                            }

                            if (col_movpcoda < 0 || col_movpdebito < 0 || col_movpcredito < 0 || col_movpmotivo < 0 || col_movpcdob < 0 || col_movpprof < 0 || col_movpadmi < 0 || col_movppefa < 0)
                            {                                   
                                diccion.Add(0, xls + "-" + $"NO SE ENCONTRARON TODAS LAS COLUMNAS OBLIGATORIAS |" +
                                    $" {col_movpcoda} {col_movpdebito} {col_movpcredito} {col_movpmotivo} {col_movpcdob} {col_movpprof} {col_movpadmi} {col_movppefa}");
                                func.PreparaRetorno(retorno, diccion);
                                diccion.Clear();
                                continue;
                            }

                            for (int i = 1; i < dt.Rows.Count; i++) //INICIO DESDE LA FILA 1
                            {

                                diccion.Clear();
                                DataRow r = dt.Rows[i];

                                //VALIDACION DE DATOS COMO STRINGS
                                if (string.IsNullOrWhiteSpace(r[col_movpcoda].ToString()))
                                {
                                    diccion.Add(0, xls + "-" + "SIN ID");
                                    func.PreparaRetorno(retorno, diccion);
                                    diccion.Clear();
                                    continue;
                                } //SIN ID
                                if (string.IsNullOrWhiteSpace(r[col_movpdebito].ToString()) && string.IsNullOrWhiteSpace(r[col_movpcredito].ToString())) { continue; } //SIN DEBITO NI CREDITO
                                if (string.IsNullOrWhiteSpace(r[col_movpcdob].ToString()))
                                { diccion.Add(0, xls + "-" + "SIN OBRA SOCIAL");  func.PreparaRetorno(retorno, diccion); diccion.Clear(); continue; } //SIN OBRA SOCIAL
                                if (string.IsNullOrWhiteSpace(r[col_movpprof].ToString()))
                                { diccion.Add(0, xls + "-" + "SIN PRESTADOR"); func.PreparaRetorno(retorno, diccion); diccion.Clear(); continue; } //SIN PRESTADOR

                                //ASIGNACION DE VARIABLES
                                int.TryParse(r[col_movpcoda].ToString().Trim(), out _movpcoda); //ID CODA
                                decimal.TryParse(r[col_movpdebito].ToString().Trim(), out _movpdebito); //DEBITOS
                                decimal.TryParse(r[col_movpcredito].ToString().Trim(), out _movpcredito); //CREDITOS
                                _movpcdob = Regex.Match(r[col_movpcdob].ToString(), @"\d+").Value; //PRESTADORA CODIGO
                                _movpprof = Regex.Match(r[col_movpprof].ToString(), @"\d+").Value; //PROFESIONAL CODIGO
                                _movpmotivo = r[col_movpmotivo].ToString().Trim().Length > 500 ? r[col_movpmotivo].ToString().Trim().Substring(0, 500) : r[col_movpmotivo].ToString().Trim();
                                _movpadmi = r[col_movpadmi].ToString().Trim(); //NUMERO DE ADMISION
                                _movppefa = r[col_movppefa].ToString().Trim();                                                                
                                if (col_movpcomprobante >= 0) { _movpcomprobante = r[col_movpcomprobante].ToString().Trim().Length > 50 ? r[col_movpcomprobante].ToString().Trim().Substring(0, 50) : r[col_movpcomprobante].ToString().Trim(); }                                
                                
                                //VALIDACION FORMATEADO EN VARIABLES
                                if (_movpcoda == 0)
                                {
                                    diccion.Add(0, xls + "-" + "SIN ID");
                                    func.PreparaRetorno(retorno, diccion);
                                    diccion.Clear();
                                    continue;
                                } //SIN ID REGISTRO
                                if (_movpdebito == 0 && _movpcredito == 0) { continue; } //DEBITO Y CREDITO EN CERO
                                if (string.IsNullOrEmpty(_movpcdob))
                                { diccion.Add(0, xls + "-" + "SIN OBRA SOCAIL"); func.PreparaRetorno(retorno, diccion); diccion.Clear(); continue; } //SIN OBRA SOCIAL
                                if (string.IsNullOrEmpty(_movpprof))
                                { diccion.Add(0, xls + "-" + "SIN PROFESIONAL"); func.PreparaRetorno(retorno, diccion); diccion.Clear(); continue; } //SIN PROFESIONAL
                                if (_movpadmi.Length > 11)
                                { diccion.Add(0, xls + "-" + "NUMERO DE ADMISION > 11"); func.PreparaRetorno(retorno, diccion); diccion.Clear(); continue; } //CON NUMERO DE ADMISION > 11 CARACTERES

                                ItemsImportados.Add(new ImportacionDebitosEstructura
                                {
                                    movpcoda = _movpcoda,
                                    movpdebito = _movpdebito,
                                    movpcredito = _movpcredito,
                                    movpmotivo = _movpmotivo.Replace("'", ""),
                                    movpcdob = _movpcdob,
                                    movpprof = _movpprof,
                                    movpadmi = _movpadmi.Replace("'", ""),
                                    movppefa = _movppefa.Replace("'", ""),
                                    movpcomprobante = _movpcomprobante.Replace("'", "")
                                });
                            }


                        }
                    }
                    catch (Exception n)
                    {
                        Dictionary<short, string> r = new Dictionary<short, string>();
                        r.Add(0, xls + "-" + n.Message);
                        func.PreparaRetorno(retorno, r);                        
                    }
                    
                    
                }
              
                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Alta.\n{e.Message}");
                return retorno;
                
            }
        }

        
        #region INSERT && DELETE

        public Dictionary<short, string> Abm(List<ImportacionDebitosEstructura> listaalta)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            if (listaalta.Count <= 0)
            {
                retorno.Add(0, $"{GetType().Name}. No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
            
            var d = BorraDatosTabla();
            func.PreparaRetorno(retorno, d);

            var n = AltaLista(listaalta);
            func.PreparaRetorno(retorno, n);

            return retorno;
        }

        private Dictionary<short, string> BorraDatosTabla()
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

                //INICIO DEL DELETE
                query.Append($"DELETE FROM [AmdgoSis].[dbo].[importaciondebitoscreditos]");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                cbd.Desconectar();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} BORRAR Lista.\n{e.Message}");
                return retorno;
            }
        }

        private Dictionary<short, string> AltaLista(List<ImportacionDebitosEstructura> abmlista)
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

                string a = $"INSERT INTO [AmdgoSis].[dbo].[importaciondebitoscreditos] (movpcoda, movpdebito, movpcredito, movpmotivo, movpcdob, movpprof, movpadmi, movppefa," +
                                                                                     $" movpcomprobante) VALUES";

                for (int i = 0; i < abmlista.Count; i += 1000)
                {
                    List<ImportacionDebitosEstructura> insertlist = abmlista.Skip(i).Take(1000).ToList();

                    foreach (ImportacionDebitosEstructura av in insertlist)
                    {
                        query.Append(a + $"({av.movpcoda}, {av.movpdebito.ToString(new CultureInfo("en-US"))}, {av.movpcredito.ToString(new CultureInfo("en-US"))}, '{av.movpmotivo}'," +                            
                                         $"'{av.movpcdob}', '{av.movpprof}', '{av.movpadmi}', '{av.movppefa}', '{av.movpcomprobante}');");
                    }

                    using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (query.ToString() != "")
                            {
                                command.Connection = SqlConnection;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = query.ToString();
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }

                        }
                    }

                    query.Clear();

                }

                cbd.Desconectar();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Alta Lista.\n{e.Message}");
                return retorno;
            }

        }
        
        #endregion


    }
}
