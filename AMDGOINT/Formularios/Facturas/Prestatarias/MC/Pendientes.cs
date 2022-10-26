using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class Pendientes
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private string _periodobase = "";

        private int _prestadoracuentaid = 0;
        private string _prestadoracuentacodigo = "";
        private short _prestadoracuentaivaid = 0;
        private string _prestadoraivaabrevia = "";
        private decimal _prestadoracuentaivaporc = 0;
        private string _prestadorarazonsocial = "";
        private long _prestadoracuit = 0;
        private string _pacientenombre = "";
        private long _pacientedocumento = 0;
        private decimal _cantidad = 0;
        private decimal _neto = 0;
        private decimal _iva = 0;
        private decimal _gastos = 0;
        private decimal _honorarios = 0;
        private decimal _total = 0;
        private long _puntero = 0;
        private bool _comprobxpaciente = false;
        private bool _aceptacomprobantex = false;

        private string _comprobantecargado = "";

        private int _profesionalcuentaid = 0;
        private string _profesionalcuentacodigo = "";
        private string _profesionalcuentadescripcion = "";
        private string _profesionalnombre = "";
        private long _profesionalcuit = 0;
        private short _profesionalidiva = 0;

        private string _practicacodigo = "";
        private string _practicaDescripcion = "";
        private string _funcioncodigo = "";
        private DateTime _practicafecha = DateTime.MinValue;
        private string _practicaperiodo = "";
        private string _prestadoraart = "";
        private string _prestadoradomfiscal = "";
        private bool _esmipyme = false;
        private int _diasvencimientofact = 0;
        private string _prestadorivaabeviatura = "";
        private string _letra = "";

        private List<string> _periodocompletado { get; set; } = new List<string>();
        
        public string ParamPeriodo
        {
            get { return _periodobase; }
            set { _periodobase = _periodobase != value.Trim() ? value.Trim() : _periodobase; }
        }
        
        public List<string> ParamTipoComrpobante { get; set; } = new List<string>();

        public List<string> ParamOrigenPracticas { get; set; } = new List<string>();

        public int PrestadoraCuentaID
        {
            get { return _prestadoracuentaid; }
            set { _prestadoracuentaid = _prestadoracuentaid != value ? value : _prestadoracuentaid; }
        }

        public string PrestadoraCuentaCodigo
        {
            get { return _prestadoracuentacodigo; }
            set { _prestadoracuentacodigo = _prestadoracuentacodigo != value.Trim() ? value.Trim() : _prestadoracuentacodigo; }
        }

        public short PrestadoraCuentaIvaID
        {
            get { return _prestadoracuentaivaid; }
            set { _prestadoracuentaivaid = _prestadoracuentaivaid != value ? value : _prestadoracuentaivaid; }
        }

        public string PrestadoraIvaAbreviatura
        {
            get { return _prestadoraivaabrevia; }
            set { _prestadoraivaabrevia = _prestadoraivaabrevia != value.Trim() ? value.Trim() : _prestadoraivaabrevia; }
        }

        public decimal PrestadoraCuentaIvaPorcentaje
        {
            get { return _prestadoracuentaivaporc; }
            set { _prestadoracuentaivaporc = _prestadoracuentaivaporc != value ? value : _prestadoracuentaivaporc; }
        }

        public string PrestadoraRazonSocial
        {
            get { return _prestadorarazonsocial; }
            set { _prestadorarazonsocial = _prestadorarazonsocial != value.Trim() ? value.Trim() : _prestadorarazonsocial; }
        }

        public string PrestadoraDomicilioFiscal
        {
            get { return _prestadoradomfiscal; }
            set { _prestadoradomfiscal = _prestadoradomfiscal != value.Trim() ? value.Trim() : _prestadoradomfiscal; }
        }

        public long PrestadoraCuit
        {
            get { return _prestadoracuit; }
            set { _prestadoracuit = _prestadoracuit != value ? value : _prestadoracuit; }
        }

        public string PrestadoraArt
        {
            get { return _prestadoraart; }
            set { _prestadoraart = _prestadoraart != value.Trim() ? value.Trim() : _prestadoraart; }
        }

        public bool PrestadoraMiPyme
        {
            get { return _esmipyme; }
            set { _esmipyme = _esmipyme != value ? value : _esmipyme; }
        }

        public int PrestadoraDiasVencimiento
        {
            get { return _diasvencimientofact; }
            set { _diasvencimientofact = _diasvencimientofact != value ? value : _diasvencimientofact; }
        }

        public bool PrestadoraComprobantePorPaciente
        {
            get { return _comprobxpaciente; }
            set { _comprobxpaciente = _comprobxpaciente != value ? value : _comprobxpaciente; }
        }
        
        public bool PrestadoraAceptaComprobanteX
        {
            get { return _aceptacomprobantex; }
            set { _aceptacomprobantex = _aceptacomprobantex != value ? value : _aceptacomprobantex; }
        }

        public string PacienteNombre
        {
            get { return _pacientenombre; }
            set { _pacientenombre = _pacientenombre != value.Trim() ? value.Trim() : _pacientenombre; }
        }

        public long PacienteDocumento
        {
            get { return _pacientedocumento; }
            set { _pacientedocumento = _pacientedocumento != value ? value : _pacientedocumento; }
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

        public decimal ImporteIva
        {
            get { return _iva; }
            set { _iva = _iva != value ? value : _iva; }
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

        public decimal ImporteTotal
        {
            get { return _total; }
            set { _total = _total != value ? value : _total; }
        }

        public long Puntero
        {
            get { return _puntero; }
            set { _puntero = _puntero != value ? value : _puntero; }
        }

        public string ComprobanteCargado
        {
            get { return _comprobantecargado; }
            set { _comprobantecargado = _comprobantecargado != value.Trim() ? value.Trim() : _comprobantecargado; }
        }

        public int PrestadorCuentaID
        {
            get { return _profesionalcuentaid; }
            set { _profesionalcuentaid = _profesionalcuentaid != value ? value : _profesionalcuentaid; }
        }

        public string PrestadorCuentaCodigo
        {
            get { return _profesionalcuentacodigo; }
            set { _profesionalcuentacodigo = _profesionalcuentacodigo != value.Trim() ? value.Trim() : _profesionalcuentacodigo; }
        }

        public string PrestadorCuentaDescripcion
        {
            get { return _profesionalcuentadescripcion; }
            set { _profesionalcuentadescripcion = _profesionalcuentadescripcion != value.Trim() ? value.Trim() : _profesionalcuentadescripcion; }
        }

        public string PrestadorNombre
        {
            get { return _profesionalnombre; }
            set { _profesionalnombre = _profesionalnombre != value.Trim() ? value.Trim() : _profesionalnombre; }
        }

        public long PrestadorCuit
        {
            get { return _profesionalcuit; }
            set { _profesionalcuit = _profesionalcuit != value ? value : _profesionalcuit; }
        }

        public short PrestadorIvaID
        {
            get { return _profesionalidiva; }
            set { _profesionalidiva = _profesionalidiva != value ? value : _profesionalidiva; }
        }

        public string PrestadorIvaAbreviatura
        {
            get { return _prestadorivaabeviatura; }
            set { _prestadorivaabeviatura = _prestadorivaabeviatura != value.Trim() ? value.Trim() : _prestadorivaabeviatura; }
        }

        public string PracticaCodigo
        {
            get { return _practicacodigo; }
            set { _practicacodigo = _practicacodigo != value.Trim() ? value.Trim() : _practicacodigo; }
        }

        public string PracticaDescripcion
        {
            get { return _practicaDescripcion; }
            set { _practicaDescripcion = _practicaDescripcion != value.Trim() ? value.Trim() : _practicaDescripcion; }
        }

        public DateTime PracticaFecha
        {
            get { return _practicafecha; }
            set { _practicafecha = _practicafecha != value ? value : _practicafecha; }
        }

        public string FuncionCodigo
        {
            get { return _funcioncodigo; }
            set { _funcioncodigo = _funcioncodigo != value.Trim() ? value.Trim() : _funcioncodigo; }
        }

        public string PracticaPeriodo
        {
            get { return _practicaperiodo; }
            set { _practicaperiodo = _practicaperiodo != value.Trim() ? value.Trim() : _practicaperiodo; }
        }

        public string PeriodoIdentificacion
        {
            get
            {                
                return PracticaPeriodo.Length > 0 ? PracticaPeriodo.Substring(PracticaPeriodo.Length - 1, 1) : "";
            }
        
        }
                        
        public string ComprobanteLetra
        {
            get { return _letra; }
            set { _letra = _letra != value.Trim() ? value.Trim() : _letra; }
        }

        public string PacienteNombreProcesado
        {
            get
            {
                string c = "";

                if ((PrestadoraArt.ToUpper() == "S" || PeriodoIdentificacion == "6") && PrestadoraComprobantePorPaciente)
                {
                    c = PacienteNombre;
                }

                return c;
            }            

        }

        public long PacienteDocumentoProcesado
        {
            get
            {
                long c = 0;

                if ((PrestadoraArt.ToUpper() == "S" || PeriodoIdentificacion == "6") && PrestadoraComprobantePorPaciente)
                {
                    c = PacienteDocumento;
                }
                
                return c;
            }

        }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Pendientes() { }

        public Pendientes(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONE
        #region CLONACION

        //CLONE 
        public Pendientes Clone()
        {
            Pendientes d = (Pendientes)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Pendientes> Clone(List<Pendientes> lst)
        {
            List<Pendientes> lista = new List<Pendientes>();

            foreach (Pendientes d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA REGISTROS
        #region CONSULTA DE DATOS

        public List<Pendientes> GetRegistros()
        {
            try
            {
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Pendientes> lista = new List<Pendientes>();

                //ARMO LA LISTA A BUSCAR SEGUN PERIODOS
                ConformaParametrosBusqueda();

                if (_periodocompletado.Count <= 0) { return lista; }
                
                //DEFINO EL PARAMETRO DE BUSQUEDA DE PERIODO (TIPO FACTURACION, ORIGEN DE PRACTICA Y FECHA)
                string orcondicional = "";
                _periodocompletado.ForEach(f => orcondicional += orcondicional.Length > 0 ? " OR TR.movppefa = '" + f + "'" : "TR.movppefa = '" + f + "'");

                string c = "SELECT " +
                            " PD.ID_Registro AS PrestadoraCuentaID," +
                            " PD.Codigo AS PrestadoraCuentaCodigo," +
                            " PR.ID_Iva AS PrestadoraCuentaIvaID," +
                            " CI.Abreviatura AS PrestadoraIvaAbreviatura," +
                            " OB.OBRAPORC_IVA AS PrestadoraCuentaIvaPorcentaje," +
                            " PR.Nombre AS PrestadoraRazonSocial," +
                            " PR.Cuit AS PrestadoraCuit," +
                            " PR.MiPyme as PrestadoraMiPyme," +
                            " PR.DiasVencimiento as PrestadoraDiasVencimiento," +
                            " PR.DomicilioFiscal as PrestadoraDomicilioFiscal," +
                            " ISNULL(OB.OBRADART, '') AS PrestadoraArt," +
                            " PR.CompPaciente AS PrestadoraComprobantePorPaciente," +
                            " PR.AceptaCompx AS PrestadoraAceptaComprobanteX," +
                            " PC.ID_Registro AS PrestadorCuentaID," +
                            " PC.Codigo AS PrestadorCuentaCodigo," +
                            " PC.Descripcion AS PrestadorCuentaDescripcion," +
                            " PRF.Nombre AS PrestadorNombre," +
                            " PRF.Cuit AS PrestadorCuit," +
                            " PRF.ID_Iva AS PrestadorIvaID," +
                            " CIP.Abreviatura AS PrestadorIvaAbreviatura," +
                            " ISNULL(TR.movppaci, '') as PacienteNombre," +
                            " IIF(ISNULL(LEFT(LTRIM(RTRIM(TR.movpdocp)), PATINDEX('%[^0-9]%', LTRIM(RTRIM(TR.movpdocp)) + 't') - 1), 0) = 0, 0, LEFT(LTRIM(RTRIM(TR.movpdocp)), PATINDEX('%[^0-9]%', LTRIM(RTRIM(TR.movpdocp)) + 't') - 1)) as PacienteDocumento," +
                            " TR.movpcant as Cantidad," +
                            " TR.movpneto as ImporteNeto," +
                            " TR.movpiiva as ImporteIva," +
                            " TR.movpgast as ImporteGastos," +
                            " TR.movphono as ImporteHonorarios, " +
                            " TR.movptoim as ImporteTotal," +
                            " TR.movpcoda AS Puntero," +
                            " TR.movpcomp as ComprobanteCargado," +
                            " ISNULL(TR.movpprac, '') AS PracticaCodigo," +
                            " ISNULL(TR.movpdesc, '') AS PracticaDescripcion," +
                            " TR.movpfepr AS PracticaFecha," +
                            " ISNULL(TR.movppefa, '') AS PracticaPeriodo," +
                            " ISNULL(TR.movpfunc, '') as FuncionCodigo" +
                            " FROM AmdgoSis.dbo.ASOCTRAN TR" +
                            " LEFT OUTER JOIN AmdgoSis.dbo.ASOCOBRA OB ON(OB.OBRACODI = TR.movpcdob)" +
                            " LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = OB.OBRACODI)" +
                            " LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                            " LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CI on(CI.ID_Registro = PR.ID_Iva)" +
                            " LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(TR.movpcopr)))" +
                            " LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PRF ON(PRF.ID_Registro = PC.ID_Profesional)" +
                            " LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CIP on(CIP.ID_Registro = PRF.ID_Iva)" +
                            " WHERE (" + orcondicional + ") AND (TR.movpcomAM IS NULL OR RTRIM(LTRIM(TR.movpcomAM)) = '') ";
                                            
                            //" WHERE (TR.movppefa = '2022061' OR TR.movppefa = '2022063') AND (TR.movpcomAM IS NOT NULL)";
                            //" AND (TR.movpcdob = '444' OR TR.movpcdob = '437' OR TR.movpcdob = '741' OR TR.movpcdob = '635' OR TR.movpcdob = '306' OR TR.movpcdob = '0344' OR TR.movpcdob = '343')";
                            //" WHERE TR.movppefa = '202201X' AND TR.movpcomAM IS NULL OR RTRIM(LTRIM(TR.movpcomAM)) = ''"; 326


                ConexionBD cnb = new ConexionBD();
                
                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Pendientes>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Pendientes>();
            }
        }

        private void ConformaParametrosBusqueda()
        {
            try
            {
                _periodocompletado.Clear();
                
                if (string.IsNullOrEmpty(ParamPeriodo) || ParamTipoComrpobante.Count <= 0)
                {
                    return;
                }
                else
                {                    
                    foreach (string t in ParamTipoComrpobante)
                    {
                        _periodocompletado.Add(ParamPeriodo + t);
                    }                    
                }

                return;
            }
            catch (Exception )
            {
                ctrl.MensajeInfo("No se pudo definir los parámetros de búsqueda.", 1);
                return;
            }
        }
        
        #endregion
    }
}
