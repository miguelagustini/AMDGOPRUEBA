using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class ComprobanteDet
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES
        private static string tablaname = "FACTPRESDET";
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private long _idregistro = 0;
        private long _idencabezado = 0;
        private string _periodo = "";
        private string _descripcion = "";
        private string _descripcionmanual = "";
        private string _descripcionrel = "";
        private long _nrodocumento = 0;
        private string _paciente = "";
        private decimal _cantidad = 0;
        private decimal _neto = 0;
        private decimal _gastos = 0;
        private decimal _honorarios = 0;
        private decimal _iva = 0;
        private decimal _total = 0;
        private long _puntero = 0;
        private string _origen = "";

        private int _prestadoracuentaid = 0;
        private int _cuentaidprofesional = 0;
        private string _prestadorivaabeviatura = "";
        private string _codigoprofesional = "";
        private string _nombreprofesional = "";
        private short _condivaprofesional = 0;
        private DateTime _fechapractica = DateTime.Now;
        private string _codpractica = "";
        private string _descpractica = "";
        private string _comprobanteletra = "";
        private string _funcioncodigo = "";
        private string _practicaadmision = "";
        private bool _seleccionado = false;
        
        public long IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public long IDEncabezado
        {
            get { return _idencabezado; }
            set { _idencabezado = _idencabezado != value ? value : _idencabezado; }
        }

        public string Periodo
        {
            get { return _periodo.Replace("-", ""); }
            set { _periodo = _periodo != value.Trim() ? value.Trim() : _periodo; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion; }
        }

        public string DescripcionManual
        {
            get { return _descripcionmanual; }
            set { _descripcionmanual = _descripcionmanual != value.Trim() ? value.Trim() : _descripcionmanual; }
        }

        public string DescripcionRelacion
        {
            get { return _descripcionrel; }
            set { _descripcionrel = _descripcionrel != value.Trim() ? value.Trim() : _descripcionrel; }
        }
               
        public string ComprobanteLetra
        {
            get { return _comprobanteletra; }
            set { _comprobanteletra = _comprobanteletra != value.Trim() ? value.Trim() : _comprobanteletra; }
        }

        public long PacienteDocumento
        {
            get { return _nrodocumento; }
            set { _nrodocumento = _nrodocumento != value ? value : _nrodocumento; }
        }

        public string PacienteNombre
        {
            get { return _paciente.Replace("'", ""); }
            set { _paciente = _paciente != value.Trim() ? value.Trim() : _paciente; }
        }
             
        public decimal Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = _cantidad != value ? value : _cantidad; }
        }

        public decimal ImporteNeto
        {
            get { return _neto; }
            set { _neto = _neto != value ? value : _neto; }
        }

        public decimal ImporteGastos
        {
            get { return _gastos; }
            set { _gastos = _gastos != value ? value : _gastos; }
        }

        public decimal ImporteHonorarios
        {
            get { return _honorarios; }
            set { _honorarios = _honorarios != value ? value : _honorarios; }
        }

        public decimal ImporteIva
        {            
            get { return _iva; }
            set { _iva = _iva != value ? value : _iva; }            
        }

        public decimal ImporteTotal
        {
            get { return _total; }
            set { _total = _total != value ? value : _total; }
        }

        public int PrestadoraCuentaID
        {
            get { return _prestadoracuentaid; }
            set { _prestadoracuentaid = _prestadoracuentaid != value ? value : _prestadoracuentaid; }
        }

        public int PrestadorCuentaID
        {
            get { return _cuentaidprofesional; }
            set { _cuentaidprofesional = _cuentaidprofesional != value ? value : _cuentaidprofesional; }
        }

        public string PrestadorCuentaCodigo
        {
            get { return _codigoprofesional; }
            set { _codigoprofesional = _codigoprofesional != value.Trim() ? value.Trim() : _codigoprofesional; }
        }

        public string PrestadorNombre
        {
            get { return _nombreprofesional; }
            set { _nombreprofesional = _nombreprofesional != value.Trim() ? value.Trim() : _nombreprofesional; }
        }

        public short PrestadorIvaID
        {
            get { return _condivaprofesional; }
            set { _condivaprofesional = _condivaprofesional != value ? value : _condivaprofesional; }
        }

        public string PrestadorIvaAbreviatura
        {
            get { return _prestadorivaabeviatura; }
            set { _prestadorivaabeviatura = _prestadorivaabeviatura != value.Trim() ? value.Trim() : _prestadorivaabeviatura; }
        }

        public DateTime PracticaFecha
        {
            get { return _fechapractica.Year <= 1900 ? DateTime.MinValue : _fechapractica; }
            set { _fechapractica = _fechapractica != value ? value : _fechapractica; }
        }

        public string PracticaCodigo
        {
            get { return _codpractica; }
            set { _codpractica = _codpractica != value.Trim() ? value.Trim() : _codpractica; }
        }

        public string PracticaFuncionCodigo
        {
            get { return _funcioncodigo; }
            set { _funcioncodigo = _funcioncodigo != value.Trim() ? value.Trim() : _funcioncodigo; }
        }

        public string PracticaDescripcion
        {
            get { return _descpractica.Replace("'", ""); }
            set { _descpractica = _descpractica != value.Trim() ? value.Trim() : _descpractica; }
        }

        public string PracticaOrigen
        {
            get
            {
                try
                {
                    return string.IsNullOrEmpty(_origen) ? Periodo.Substring(Periodo.Length - 1, 1) : _origen;
                }
                catch (Exception)
                {
                    return "";                    
                }
                
            }
            set { _origen = _origen.Trim() != value ? value.Trim() : _origen; }
        }

        public string DescripcionGrupoRegistros
        {
            get
            {
                if (PracticaOrigen == "1" || PracticaOrigen == "2" || PracticaOrigen == "7")
                { return $"Por Facturación de Prácticas Ambulatorias {Periodo}"; }
                else if (PracticaOrigen == "3" || PracticaOrigen == "4" || PracticaOrigen == "8")
                { return $"Por Facturación de Prácticas de Internación {Periodo}"; }
                else if (PracticaOrigen == "6") { return $"Por Facturación de Prácticas Covid-19 {Periodo}"; }
                else { return ""; }
            }            
        }

        public long PracticaPunteroAsocTran
        {
            get { return _puntero; }
            set { _puntero = _puntero != value ? value : _puntero; }
        }

        public string PracticaNumeroAdmision
        {
            get { return _practicaadmision; }
            set { _practicaadmision = _practicaadmision != value.Trim() ? value.Trim() : _practicaadmision; }
            
        }

        public long IDReclamoDetalle { get; set; } = 0;

        public bool Seleccionado
        {
            get { return _seleccionado; }
            set { _seleccionado = _seleccionado != value ? value : _seleccionado; }
        }

        public bool DescripcionFacturaOriginal { get; set; } = false;

        //PROPIEDADES DE IGUALACION BD
        public long ID_Encabezado { get { return IDEncabezado; } }
        public long NroDocumento { get { return PacienteDocumento; } }
        public string Paciente { get { return PacienteNombre; } }
        public decimal Neto { get { return ImporteNeto; } }
        public decimal Gastos { get { return ImporteGastos; } }
        public decimal Honorarios { get { return ImporteHonorarios; } }
        public decimal Iva { get { return ImporteIva; } }
        public decimal Total { get { return ImporteTotal; } }
        public long Puntero { get { return PracticaPunteroAsocTran; } }
        public string Origen { get { return PracticaOrigen; } }
        public string CodProfesional { get { return PrestadorCuentaCodigo; } }
        public string Profesional { get { return PrestadorNombre; } }
        public string ProfCndIva { get { return PrestadorIvaID.ToString(); } }
        public string FechaPractica { get { return PracticaFecha.ToString("dd/MM/yyyy"); } }
        public string CodPractica { get { return PracticaCodigo; } }
        public string DescPractica { get { return PracticaDescripcion; } }
                
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ComprobanteDet() { }

        public ComprobanteDet(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONE
        #region CLONACION

        //CLONE 
        public ComprobanteDet Clone()
        {
            ComprobanteDet d = (ComprobanteDet)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<ComprobanteDet> Clone(List<ComprobanteDet> lst)
        {
            List<ComprobanteDet> lista = new List<ComprobanteDet>();

            foreach (ComprobanteDet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA REGISTROS
        #region CONSULTA DE DATOS

        public List<ComprobanteDet> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ComprobanteDet> lista = new List<ComprobanteDet>();

                string c = $"SELECT" +
                            $" FA.ID_Encabezado AS IDEncabezado" +
                            $" ,FA.Periodo" +
                            $" ,FA.Descripcion" +
                            $" ,FA.DescripcionManual" +
                            $" ,FA.NroDocumento AS PacienteDocumento" +
                            $" ,FA.Paciente AS PacienteNombre" +
                            $" ,FA.Cantidad" +
                            $" ,FA.Neto as ImporteNeto" +
                            $" ,FA.Gastos as ImporteGastos" +
                            $" ,FA.Honorarios as ImporteHonorarios" +
                            $" ,FA.Iva as ImporteIva" +
                            $" ,FA.Total as ImporteTotal" +
                            $" ,FA.Puntero AS PracticaPunteroAsocTran" +
                            $" ,FA.Origen AS PracticaOrigen" +
                            $" ,FA.CodProfesional as PrestadorCuentaCodigo" +
                            $" ,FA.Profesional as PrestadorNombre" +
                            $" ,ISNULL(CI.Abreviatura, '') as PrestadorIvaAbreviatura" +
                            $" ,TRY_CONVERT(datetime, ltrim(rtrim(FA.FechaPractica)), 105) as PracticaFecha" +
                            $" ,FA.CodPractica as PracticaCodigo" +
                            $" ,FA.DescPractica as PracticaDescripcion" +
                            //$" ,'' AS PracticaNumeroAdmision" +
                            //$" ,'' AS PracticaFuncionCodigo" +
                            $" ,ISNULL(TR.movpadmi,'') AS PracticaNumeroAdmision" +
                            $" ,ISNULL(TR.MOVPFUNC,'') AS PracticaFuncionCodigo" +
                            $" ,FA.IDReclamoDetalle" +                            
                            $" FROM AmdgoInterno.dbo.{tablaname} FA" +
                            $" LEFT OUTER JOIN dbo.CONDSIVA CI ON(CI.ID_Registro = FA.ProfCndIva)" +
                            $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCTRAN TR ON(TR.movpcoda = FA.Puntero)";

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ComprobanteDet>(rdr));
                }

                return lista;                             
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ComprobanteDet>();
            }
        }

        public List<ComprobanteDet> GetRegistrosPorComprobante(long idcomprobante)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ComprobanteDet> lista = new List<ComprobanteDet>();

                string c = $"SELECT" +
                            $" FA.ID_Registro as IDRegistro" +
                            $" ,FA.ID_Encabezado AS IDEncabezado" +
                            $" ,FA.Periodo" +
                            $" ,FA.Descripcion" +
                            $" ,FA.DescripcionManual" +
                            $" ,FA.NroDocumento AS PacienteDocumento" +
                            $" ,FA.Paciente AS PacienteNombre" +
                            $" ,FA.Cantidad" +
                            $" ,FA.Neto as ImporteNeto" +
                            $" ,FA.Gastos as ImporteGastos" +
                            $" ,FA.Honorarios as ImporteHonorarios" +
                            $" ,FA.Iva as ImporteIva" +
                            $" ,FA.Total as ImporteTotal" +
                            $" ,FA.Puntero AS PracticaPunteroAsocTran" +
                            $" ,FA.Origen AS PracticaOrigen" +
                            $" ,FA.CodProfesional as PrestadorCuentaCodigo" +
                            $" ,FA.Profesional as PrestadorNombre" +
                            $" ,ISNULL(CI.Abreviatura, '') as PrestadorIvaAbreviatura" +
                            $" ,TRY_CONVERT(datetime, ltrim(rtrim(FA.FechaPractica)), 105) as PracticaFecha" +
                            $" ,FA.CodPractica as PracticaCodigo" +
                            $" ,FA.DescPractica as PracticaDescripcion" +
                            $" ,ISNULL(TR.movpadmi,'') AS PracticaNumeroAdmision" +
                            $" ,ISNULL(TR.MOVPFUNC,'') AS PracticaFuncionCodigo" +
                            $" ,FA.IDReclamoDetalle" +
                            //$" ,'' AS PracticaNumeroAdmision" +
                            //$" ,'' AS PracticaFuncionCodigo" +
                            $" FROM AmdgoInterno.dbo.{tablaname} FA" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CI ON(CI.ID_Registro = FA.ProfCndIva)" +
                            $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCTRAN TR ON(TR.MOVPCOMAM IS NOT NULL AND TR.movpcoda = FA.Puntero)" +
                            $" WHERE FA.ID_Encabezado = {idcomprobante}";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ComprobanteDet>(rdr));
                }


               #region DETALLES NO VINCULADOS

                c = $"SELECT FE.ID_Registro AS IDEncabezado, FE.Total AS ImporteTotal," +
                    $" IIF(FC.Numero > 0, CONCAT('Según factura Nº ', FC.Letra, ' ', FORMAT(FC.PuntoVenta, '0000'), ' - ', FORMAT(FC.Numero, '00000000'))," +
                    $" CONCAT('Según factura Nº ', FR.Comprobante)) AS DescripcionRelacion, CAST(1 AS BIT) AS DescripcionFacturaOriginal" +
                    $" FROM AmdgoInterno.dbo.FACTPRESENC FE" +
                    $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTPRESREL FR ON(" +
                    $" (CASE WHEN FR.ID_NotaCredito > 0 THEN FR.ID_NotaCredito WHEN FR.ID_NotaDebito > 0" +
                    $" THEN FR.ID_NotaDebito else FR.ID_NotaCredito end) = FE.ID_Registro)" +
                    $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTPRESENC FC ON(FC.ID_Registro = FR.ID_Factura)" +
                    $" WHERE (FC.Numero > 0 OR FR.Comprobante <> '')  AND FE.ID_Registro = {idcomprobante}";


                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnn.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ComprobanteDet>(rdr));
                }

                cnn.Desconectar();

                #endregion


                cnn.Desconectar();                
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ComprobanteDet>();
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm(List<ComprobanteDet> abmlista = null)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            if (IDRegistro <= 0)
            {
                //ABM POR LISTA
                if (abmlista != null)
                {
                    return AltaLista(abmlista);
                }
                //ABM POR REGISTRO
                else { return Alta(); }                 
            }            
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("ID_Encabezado");
            campos.Add("Periodo");
            campos.Add("Descripcion");
            campos.Add("DescripcionManual");
            campos.Add("NroDocumento");
            campos.Add("Paciente");
            campos.Add("Cantidad");
            campos.Add("Neto");
            campos.Add("Gastos");
            campos.Add("Honorarios");
            campos.Add("Iva");
            campos.Add("Total");
            campos.Add("Puntero");
            campos.Add("Origen");
            campos.Add("CodProfesional");
            campos.Add("Profesional");
            campos.Add("ProfCndIva");
            campos.Add("FechaPractica");
            campos.Add("CodPractica");
            campos.Add("DescPractica");
            campos.Add("IDReclamoDetalle");            

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

        private Dictionary<short, string> AltaLista(List<ComprobanteDet> abmlista)
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

                string a = $"INSERT INTO [dbo].[{tablaname}] (ID_Encabezado, Periodo, Descripcion, NroDocumento, Paciente, Cantidad, Neto, Gastos, Honorarios, " +
                           $" Iva, Total, Puntero, Origen, CodProfesional, Profesional, ProfCndIva, FechaPractica, CodPractica, DescPractica, DescripcionManual, IDReclamoDetalle) VALUES";

                for (int i = 0; i < abmlista.Count; i += 1000)
                {                    
                    List<ComprobanteDet> insertlist = abmlista.Skip(i).Take(1000).ToList();

                    foreach (ComprobanteDet av in insertlist)
                    {
                        query.Append(a + $"({av.IDEncabezado}, '{av.Periodo}', '{av.Descripcion}', {av.PacienteDocumento}, '{av.PacienteNombre}'," +
                                $" {av.Cantidad.ToString(new CultureInfo("en-US"))}, {av.ImporteNeto.ToString(new CultureInfo("en-US"))}, {av.ImporteGastos.ToString(new CultureInfo("en-US"))}," +
                                $" {av.ImporteHonorarios.ToString(new CultureInfo("en-US"))}, {av.ImporteIva.ToString(new CultureInfo("en-US"))}, {av.ImporteTotal.ToString(new CultureInfo("en-US"))}," +
                                $" {av.PracticaPunteroAsocTran}, '{av.PracticaOrigen}', '{av.PrestadorCuentaCodigo}', '{av.PrestadorNombre}', '{av.PrestadorIvaID}'," +
                                $" '{av.PracticaFecha.ToString("dd/MM/yyyy")}', '{av.PracticaCodigo}', '{av.PracticaDescripcion}', '{av.DescripcionManual}', {av.IDReclamoDetalle});");                                
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
