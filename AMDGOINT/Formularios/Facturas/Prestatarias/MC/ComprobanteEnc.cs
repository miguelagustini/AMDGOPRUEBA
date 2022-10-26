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

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class ComprobanteEnc : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private NumeroaLetras Numeroaletras = new NumeroaLetras();
        #endregion

        //PROPIEDADES
        #region PROPIEDADES

        private static string tablaname = "FACTPRESENC";

        private long _idregistro = 0;
        private string _periodo = "";
        private DateTime _fecha = DateTime.Today;
        private DateTime _fechavtopago = DateTime.MinValue;
        private string _tipocomprobante = "FC";
        private string _letra = "";
        private int _pventa = 0;
        private long _numero = 0;
        private string _paciente = "";
        private long _pacientenro = 0;
        private int _idprestdetalle = 0;
        private string _nombreprest = "";
        private string _codigoprest = "";
        private long _cuitprest = 0;
        private short _idivaprest = 0;
        private string _ivadescripcionprest = "";
        private string _domiciliofiscalprest = "";        
        private decimal _neto = 0;
        private decimal _gastos = 0;
        private decimal _honorarios = 0;
        private decimal _iva = 0;
        private decimal _total = 0;
        private DateTime _servdesde = DateTime.MinValue;
        private DateTime _servhasta = DateTime.MinValue;
        private string _estadoafip = "";
        private string _caenro = "";
        private string _codigobarras = "";
        private DateTime _vtocae = DateTime.MinValue;
        private string _observacionesafip = "";
        private bool _pagada = false;
        private bool _anulada = false;
        private decimal _prestadoracuentaivaporc = 0;
        private bool _esmipyme = false;
        private int _diasvencimientofact = 0;
        private string _emisorcbu = "";
        private string _emisoralias = "";
        private bool _anulacionpreviafce = false;
        private bool _comprobantesasociados = false;
        private string _usuarionombre = "";
        private DateTime _fechacreacion = DateTime.MinValue;
        private int _idcuentaasociado = 0;
        private string _cuentacodigoasociado = "";
        private string _nombreasociado = "";
        private long _cuitasociado = 0;
        private string _ivaabreviaasociado = "";
        private short _asociadoivaid = 0;
        private string _asociadodomicilio = "";
        private string textoqr = "";        
        private byte[] _byteqr = null;
        private short _diasvto = 0;
        private decimal _intereses = 0;
        private DateTime _fechafactura = DateTime.MinValue;
        private short _idconcepto = 1;
        private string _conceptodesc = "";

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        public long IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public string EmisorCbu
        {
            get { return _emisorcbu; }
            set { _emisorcbu = _emisorcbu != value.Trim() ? value.Trim() : _emisorcbu; }
        }

        public string EmisorAlias
        {
            get { return _emisoralias; }
            set { _emisoralias = _emisoralias != value.Trim() ? value.Trim() : _emisoralias; }
        }

        public bool ComprobanteAnuladoReceptor
        {
            get { return _anulacionpreviafce; }
            set { _anulacionpreviafce = _anulacionpreviafce != value ? value : _anulacionpreviafce; }
        }

        public string Periodo
        {
            get { return _periodo.Replace("-", ""); }
            set { _periodo = _periodo != value.Trim() ? value.Trim() : _periodo; }
        }

        public DateTime FacturaFecha
        {
            get { return _fechafactura; }
            set { _fechafactura = _fechafactura != value ? value : _fechafactura; }
        }

        public DateTime ComprobanteFecha
        {
            get { return _fecha; }
            set { _fecha = _fecha != value ? value : _fecha; }
        }

        public DateTime ComprobanteFechaVtoPago
        {
            get { return _fechavtopago; }
            set { _fechavtopago = _fechavtopago != value ? value : _fechavtopago; }
        }

        public string ComprobanteTipo
        {
            get { return _tipocomprobante; }
            set { _tipocomprobante = _tipocomprobante != value.Trim() ? value.Trim() : _tipocomprobante; }
        }

        public int TipoComprobanteNumero
        {
            get
            {
                int a = 0;

                switch (ComprobanteTipo + ComprobanteLetra)
                {
                    case "FCA":
                        a = 1;
                        break;
                    case "NDA":
                        a = 2;
                        break;
                    case "NCA":
                        a = 3;
                        break;
                    case "RCA":
                        a = 4;
                        break;
                    case "FCB":
                        a = 6;
                        break;
                    case "NDB":
                        a = 7;
                        break;
                    case "NCB":
                        a = 8;
                        break;
                    case "RCB":
                        a = 9;
                        break;
                    case "FCC":
                        a = 11;
                        break;
                    case "NDC":
                        a = 12;
                        break;
                    case "NCC":
                        a = 13;
                        break;
                    case "RCC":
                        a = 15;
                        break;
                    case "FCEC":
                        a = 211;
                        break;
                    case "NCEC":
                        a = 213;
                        break;
                    case "NDEC":
                        a = 212;
                        break;
                }

                return a;
            }
        }
        
        public string ComprobanteTipoDescripcion
        {
            get
            {                
                switch (ComprobanteTipo)
                {
                    case "FC": return "Factura";
                    case "NC": return "Nota de Crédito";
                    case "ND": return "Nota de Débito";
                    case "FCE": return "Factura de Crédito Electrónica Mi Pyme";
                    case "NCE": return "Nota de Cédito Electrónica Mi Pyme";
                    case "NDE": return "Nota de Débito Electrónica Mi Pyme";
                    default: return "";
                }
            }
        }

        public string ComprobanteLetra
        {
            get { return _letra; }
            set { _letra = _letra != value.Trim() ? value.Trim() : _letra; }
        }

        public string ComprobanteTipoCodigo
        {
            get
            {
               
                //TIPO DE COMPROBANTE - AFIP TG-B
                switch (ComprobanteTipo+ComprobanteLetra)
                {                    
                    case "FCC": return "011";                        
                    case "NDC": return "012";                        
                    case "NCC": return "013";                                            
                    case "FCEC": return "211";                        
                    case "NCEC": return "213";                        
                    case "NDEC": return "212";                        
                    default: return "";
                        
                }           
            }
        }

        public int ComprobantePuntoVenta
        {
            get { return _pventa; }
            set { _pventa = _pventa != value ? value : _pventa; }
        }

        public long ComprobanteNumero
        {
            get { return _numero; }
            set { _numero = _numero != value ? value : _numero; }
        }

        public string PacienteNombre
        {
            get { return _paciente; }
            set { _paciente = _paciente != value.Trim() ? value.Trim() : _paciente; }
        }

        public long PacienteDocumento
        {
            get { return _pacientenro; }
            set { _pacientenro = _pacientenro != value ? value : _pacientenro;  }
        }
        
        public int PrestadoraCuentaID
        {
            get { return _idprestdetalle; }
            set { _idprestdetalle = _idprestdetalle != value ? value : _idprestdetalle; }
        }

        public short PrestadoraIvaID
        {
            get { return _idivaprest; }
            set { _idivaprest = _idivaprest != value ? value : _idivaprest; }
        }

        public string PrestadoraIvaAbreviatura
        {
            get { return _ivadescripcionprest; }
            set { _ivadescripcionprest = _ivadescripcionprest != value.Trim() ? value.Trim() : _ivadescripcionprest; }
        }

        public decimal PrestadoraCuentaIvaPorcentaje
        {
            get { return _prestadoracuentaivaporc; }
            set { _prestadoracuentaivaporc = _prestadoracuentaivaporc != value ? value : _prestadoracuentaivaporc; }
        }

        public string PrestadoraRazonSocial
        {
            get { return _nombreprest.ToUpper(); }
            set { _nombreprest = _nombreprest != value.Trim() ? value.Trim() : _nombreprest; }
        }

        public string PrestadoraAbreviatura { get; set; } = "";

        public string PrestadoraDomicilioFiscal
        {
            get { return _domiciliofiscalprest; }
            set { _domiciliofiscalprest = _domiciliofiscalprest != value.Trim() ? value.Trim() : _domiciliofiscalprest; }
        }

        public string PrestadoraCuentaCodigo
        {
            get { return _codigoprest; }
            set { _codigoprest = _codigoprest != value.Trim() ? value.Trim() : _codigoprest; }
        }

        public long PrestadoraCuit
        {
            get { return _cuitprest; }
            set { _cuitprest = _cuitprest != value ? value : _cuitprest; }
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

        public int AsociadoCuentaID
        {
            get { return _idcuentaasociado; }
            set { _idcuentaasociado = _idcuentaasociado != value ? value : _idcuentaasociado; }
        }

        public string AsociadoCuentaCodigo
        {
            get { return _cuentacodigoasociado; }
            set { _cuentacodigoasociado = _cuentacodigoasociado != value.Trim() ? value.Trim() : _cuentacodigoasociado; }
        }

        public string AsociadoRazonSocial
        {
            get { return _nombreasociado; }
            set { _nombreasociado = _nombreasociado != value.Trim() ? value.Trim() : _nombreasociado; }
        }

        public string AsociadoDomicilioFiscal
        {
            get { return _asociadodomicilio; }
            set { _asociadodomicilio = _asociadodomicilio != value.Trim() ? value.Trim() : _asociadodomicilio; }
        }

        public long AsociadoCuit
        {
            get { return _cuitasociado; }
            set { _cuitasociado = _cuitasociado != value ? value : _cuitasociado; }
        }

        public string AsociadoIvaAbreviatura
        {
            get { return _ivaabreviaasociado; }
            set { _ivaabreviaasociado = _ivaabreviaasociado != value.Trim() ? value.Trim() : _ivaabreviaasociado; }
        }

        public short AsociadoIvaId
        {
            get { return _asociadoivaid; }
            set { _asociadoivaid = _asociadoivaid != value ? value : _asociadoivaid; }
        }

        public string ReceptorCuentaCodigo
        {
            get { return AsociadoCuentaID > 0 ? AsociadoCuentaCodigo : PrestadoraCuentaCodigo; }
        }

        public string ReceptorRazonSocial
        {
            get
            {
                return AsociadoCuentaID > 0 ? AsociadoRazonSocial : PrestadoraRazonSocial;
            }
        }

        public long ReceptorCuit
        {
            get
            {
                return AsociadoCuentaID > 0 ? AsociadoCuit : PrestadoraCuit;
            }
        }

        public string ReceptorDomicilioFiscal
        {
            get
            {
                return AsociadoCuentaID > 0 ? AsociadoDomicilioFiscal : PrestadoraDomicilioFiscal;
            }
        }

        public short ReceptorIvaID
        {
            get
            {
                return AsociadoCuentaID > 0 ? AsociadoIvaId : PrestadoraIvaID;
            }
        }

        public string ReceptorIvaAbreviatura
        {
            get
            {
                return AsociadoCuentaID > 0 ? AsociadoIvaAbreviatura : PrestadoraIvaAbreviatura;
            }
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

        public string ImporteTotalLetras
        {
            get
            {
               return Numeroaletras.enletras(ImporteTotal.ToString()).ToUpperInvariant();
            }
        }

        public decimal ImporteIvaExedido
        {
            get
            {
                decimal _ivaporc = PrestadoraCuentaCodigo.StartsWith("0") ? (decimal)0.105 : PrestadoraCuentaCodigo == "13" ? (decimal)21 : 0;
                decimal _calc = Math.Round(ImporteNeto * _ivaporc, 2);

                return Math.Truncate(ImporteIva) > Math.Truncate(_calc) ? _calc : 0;
            }
        }

        public DateTime FechaHasta
        {
            get { return _servhasta; }
            set { _servhasta = _servhasta != value ? value : _servhasta; }
        }

        public DateTime FechaDesde
        {
            get { return _servdesde; }
            set { _servdesde = _servdesde != value ? value : _servdesde; }
        }

        public string EstadoAfip
        {
            get { return _estadoafip; }
            set { _estadoafip = _estadoafip != value.Trim() ? value.Trim() : _estadoafip; }
        }

        public string CaeNumeroAfip
        {
            get { return _caenro; }
            set { _caenro = _caenro != value.Trim() ? value.Trim() : _caenro; }
        }

        public string CodigoBarrasAfip
        {
            get { return _codigobarras; }
            set { _codigobarras = _codigobarras != value.Trim() ? value.Trim() : _codigobarras; }
        }

        public DateTime VencimientoCaeAfip
        {
            get { return _vtocae; }
            set { _vtocae = _vtocae != value ? value : _vtocae; }
        }

        public string ObservacionesAfip
        {
            get { return _observacionesafip; }
            set { _observacionesafip = _observacionesafip != value.Trim() ? value.Trim() : _observacionesafip; }
        }

        public bool Pagada
        {
            get { return _pagada; }
            set { _pagada = _pagada != value ? value : _pagada; }
        }

        public bool Anulada
        {
            get { return _anulada; }
            set { _anulada = _anulada != value ? value : _anulada; }
        }

        public bool ComprobantesAsociados
        {
            get { return _comprobantesasociados; }
            set { _comprobantesasociados = _comprobantesasociados != value ? value : _comprobantesasociados; }
        }

        public short VencidoDias
        {
            get { return _diasvto; }
            set { _diasvto = _diasvto != value ? value : value; }
        }

        public decimal ImporteIntereses
        {
            get { return _intereses; }
            set { _intereses = _intereses != value ? value : _intereses; }
        }

        public string UsuarioNombre
        {
            get { return _usuarionombre; }
            set { _usuarionombre = _usuarionombre != value.Trim() ? value.Trim() : _usuarionombre; }
        }

        public short IDConcepto
        {
            get
            {                
                if (_idconcepto <= 0)
                {
                    if (Detalles.Where(w => w.PracticaOrigen.Any(n => n.Equals("1") || n.Equals("3"))).Count() > 0)
                    { _idconcepto = 1; }
                    else if (Detalles.Where(w => w.PracticaOrigen.Any(n => n.Equals("7") || n.Equals("8"))).Count() > 0)
                    { _idconcepto = 2; }
                    else if (Detalles.Where(w => w.PracticaOrigen.Any(n => n.Equals("2") || n.Equals("4"))).Count() > 0)
                    { _idconcepto = 4; }
                    else if (Detalles.Where(w => w.PracticaOrigen.Any(n => n.Equals("6"))).Count() > 0)
                    { _idconcepto = 3; }
                }

                return _idconcepto;
            }
            set { _idconcepto = _idconcepto != value ? value : _idconcepto; }
        }



        public string ConceptoDescripcion
        {
            get { return _conceptodesc; }
            set { _conceptodesc = _conceptodesc != value.Trim() ? value.Trim() : _conceptodesc; }
        }

        public string TextoQr
        {
            get { return textoqr; }
            set { textoqr = textoqr != value.Trim() ? value.Trim() : textoqr; }
        }

        public byte[] ByteQr
        {
            get { return _byteqr; }
            set { _byteqr = _byteqr != value ? value : _byteqr; }
        }

        public DateTime FechaCreacion
        {
            get { return _fechacreacion; }
            set { _fechacreacion = _fechacreacion != value ? value : _fechacreacion; }
        }

        public List<ComprobanteDet> Detalles { get; set; } = new List<ComprobanteDet>();

        public List<ComprobantesRel> ComprobantesRelacion { get; set; } = new List<ComprobantesRel>();

        //PROPIEDADES DE IGUALACION
        public DateTime Fecha { get { return ComprobanteFecha; } }
        public DateTime FechaVtoPago { get { return ComprobanteFechaVtoPago; } }
        public string TipoComprobante { get { return ComprobanteTipo; } }

        public string Letra { get { return ComprobanteLetra; } }
        public int PuntoVenta { get { return ComprobantePuntoVenta; } }        
        public long Numero { get { return ComprobanteNumero; } }
        public string Paciente { get { return PacienteNombre;  } }
        public long NroDocumento { get { return PacienteDocumento; } }


        public int ID_PrestDetalle { get { return PrestadoraCuentaID; } }
        public string NombrePres { get { return ReceptorRazonSocial; } }
        public long  CuitPres { get { return ReceptorCuit; } }
        public short IvaPres { get { return ReceptorIvaID; } }
        public string DomFiscalPres { get { return ReceptorDomicilioFiscal; } }


        public string Cbu { get { return EmisorCbu; } }
        public string Alias { get { return EmisorAlias; } }
        public string Guid { get { return IDLocal; } }
        public decimal Neto { get { return ImporteNeto; } }
        public decimal Gastos { get { return ImporteGastos; } }
        public decimal Honorarios { get { return ImporteHonorarios; } }
        public decimal Iva { get { return ImporteIva; } }
        public decimal Total { get { return ImporteTotal; } }
        public string EstadoAf { get { return EstadoAfip; } }
        public string CaeNroAf { get { return CaeNumeroAfip; } }
        public string BarrasAf { get { return CodigoBarrasAfip; } }
        public DateTime VtoCaeAf { get { return VencimientoCaeAfip; } }
        public string ObservAf { get { return ObservacionesAfip; } }
        public int ID_UsuNew { get { return  glb.GetIdUsuariolog();  } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ComprobanteEnc() { }

        public ComprobanteEnc(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONE
        #region CLONACION

        //CLONE 
        public ComprobanteEnc Clone()
        {
            ComprobanteEnc d = (ComprobanteEnc)MemberwiseClone();
            ComprobanteDet det = new ComprobanteDet();
            ComprobantesRel rel = new ComprobantesRel();

            d.Detalles = det.Clone(Detalles);
            d.ComprobantesRelacion = rel.Clone(ComprobantesRelacion);

            return d;
        }

        //CLONE CON LISTAS
        public List<ComprobanteEnc> Clone(List<ComprobanteEnc> lst)
        {
            List<ComprobanteEnc> lista = new List<ComprobanteEnc>();

            foreach (ComprobanteEnc d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //EVENTOS DE PROPERTY CHANGED
        #region  PROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion

        //RETORNO DE LISTA REGISTROS
        #region CONSULTA DE DATOS

        public List<ComprobanteEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ComprobanteEnc> lista = new List<ComprobanteEnc>();

                string c = $"SELECT FA.ID_Registro AS IDRegistro" +
                          $" ,FA.Periodo" + 
                          $" ,FA.Fecha as FacturaFecha" +
                          $" ,FA.Fecha as ComprobanteFecha" +
                          $" ,FA.FechaVtoPago as ComprobanteFechaVtoPago" +
                          $" ,FA.TipoComprobante as ComprobanteTipo" +
                          $" ,FA.Letra as ComprobanteLetra" +
                          $" ,FA.PuntoVenta as ComprobantePuntoVenta" +
                          $" ,FA.Numero as ComprobanteNumero" +
                          //PACIENTE
                          $" ,FA.Paciente as PacienteNombre" +
                          $" ,FA.NroDocumento as PacienteDocumento" +
                          //PRESTADORA
                          $" ,FA.ID_PrestDetalle as PrestadoraCuentaID" +
                          $" ,FA.NombrePres as PrestadoraRazonSocial" +
                          $" ,FA.CuitPres as PrestadoraCuit" +
                          $" ,FA.IvaPres as PrestadoraIvaID" +
                          $" ,PD.Codigo AS PrestadoraCuentaCodigo" +
                          $" ,PD.Abreviatura AS PrestadoraAbreviatura" +
                          $" ,CI.Abreviatura as PrestadoraIvaAbreviatura" +
                          $" ,FA.DomFiscalPres as PrestadoraDomicilioFiscal" +
                          $" ,FA.Cbu as EmisorCbu" +
                          $" ,FA.Alias as EmisorAlias" +
                          //ASOCIADO
                          $" ,FA.AsociadoCuentaID" +                          
                          $" ,PC.Codigo as AsociadoCuentaCodigo" +
                          $" ,FA.NombrePres as AsociadoRazonSocial" +
                          $" ,FA.CuitPres as AsociadoCuit" +
                          $" ,FA.IvaPres as AsociadoIvaID" +
                          $" ,FA.DomFiscalPres as AsociadoDomicilioFiscal" +
                          $" ,CI.Abreviatura as AsociadoIvaAbreviatura" +
                          //RESTO
                          $" ,FA.Guid as IDLocal" +
                          $" ,FA.Neto as ImporteNeto" +
                          $" ,FA.Gastos as ImporteGastos" +
                          $" ,FA.Honorarios as ImporteHonorarios" +
                          $" ,FA.Iva as ImporteIva" +
                          $" ,FA.Total as ImporteTotal" +
                          $" ,FA.FechaDesde" +
                          $" ,FA.FechaHasta" +
                          $" ,FA.EstadoAf as EstadoAfip" +
                          $" ,FA.CaeNroAf as CaeNumeroAfip" +
                          $" ,FA.BarrasAf as CodigoBarrasAfip" +
                          $" ,FA.VtoCaeAf as VencimientoCaeAfip" +
                          $" ,FA.ObservAf as ObservacionesAfip" +
                          $" ,FA.Pagada" +
                          $" ,FA.DiasVencidos AS VencidoDias" +
                          $" ,FA.InteresesVencimiento AS ImporteIntereses" +
                          $" ,US.Usuario AS UsuarioNombre" +
                          $" ,FA.TimeNew AS FechaCreacion" +
                          $" ,FA.IDConcepto" +
                          $" ,ISNULL(CO.Concepto,'') AS ConceptoDescripcion" +
                          $" ,CAST(IIF((SELECT COUNT(*) FROM FACTPRESREL RE WHERE RE.ID_Factura = FA.ID_REGISTRO) > 0, 1, 0) AS BIT) AS ComprobantesAsociados" +
                          $" ,CAST(IIF((FA.Total - ISNULL((SELECT SUM(FR.Total)" +
                                                        $" FROM FACTPRESREL NC" +
                                                        $" LEFT OUTER JOIN dbo.{tablaname} FR ON(FR.ID_Registro = NC.ID_NotaCredito AND NC.ID_NotaCredito > 0)" +
                                                        $" WHERE NC.ID_Factura = FA.ID_Registro AND FR.EstadoAf = 'A'), 0)" +
                                                        $" + ISNULL((SELECT SUM(FR1.Total)" +
                                                        $" FROM FACTPRESREL ND" +
                                                        $" LEFT OUTER JOIN dbo.{tablaname} FR1 ON(FR1.ID_Registro = ND.ID_NotaDebito AND ND.ID_NotaDebito > 0)" +
                                                        $" WHERE ND.ID_Factura = FA.ID_Registro AND FR1.EstadoAf = 'A'), 0)) <= 0, 1, 0) as bit) AS Anulada" +
                          $" FROM AmdgoInterno.dbo.{tablaname} FA" +
                          $" LEFT OUTER JOIN CONDSIVA CI ON(CI.ID_Registro = FA.IvaPres)" +
                          $" LEFT OUTER JOIN USUARIOS US ON(US.ID_Registro = FA.ID_UsuNew)" +
                          $" LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = FA.ID_PrestDetalle)" +
                          $" LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Registro = FA.AsociadoCuentaID)" +
                          $" LEFT OUTER JOIN CONCEPTOSCOMPROBANTES CO ON(CO.IDRegistro = FA.IDConcepto)";

                ConexionBD cnb = new ConexionBD();
                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ComprobanteEnc>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ComprobanteEnc>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void SetIdbyguid()
        {
            string c = $"SELECT ID_Registro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt64(r["ID_Registro"]);
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm(bool detallesporlote = true)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0 && IDLocal.Length > 0)
            {
                return Alta(detallesporlote);
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
            
            campos.Add("Periodo");
            campos.Add("Fecha");
            campos.Add("FechaVtoPago");
            campos.Add("TipoComprobante");
            campos.Add("Letra");
            campos.Add("PuntoVenta");
            campos.Add("Numero");
            campos.Add("Paciente");
            campos.Add("NroDocumento");
            campos.Add("AsociadoCuentaID");
            campos.Add("ID_PrestDetalle");
            campos.Add("NombrePres");
            campos.Add("CuitPres");
            campos.Add("IvaPres");
            campos.Add("DomFiscalPres");
            campos.Add("Cbu");
            campos.Add("Alias");
            campos.Add("Guid");
            campos.Add("Neto");
            campos.Add("Gastos");
            campos.Add("Honorarios");
            campos.Add("Iva");
            campos.Add("Total");
            campos.Add("FechaDesde");
            campos.Add("FechaHasta");
            campos.Add("EstadoAf");
            campos.Add("CaeNroAf");
            campos.Add("BarrasAf");
            campos.Add("VtoCaeAf");
            campos.Add("ObservAf");
            campos.Add("Pagada");
            campos.Add("IDConcepto");
            campos.Add("ID_UsuNew");
            

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta(bool detallesporlote)
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

                    //ACTUALIZO POR LOTES O DETALLADO
                    if (detallesporlote)
                    {
                        Detalles.ForEach(f => f.IDEncabezado = IDRegistro);
                        ComprobanteDet detalle = new ComprobanteDet();
                        detalle.SqlConnection = SqlConnection;
                        var dic = detalle.Abm(Detalles);
                        func.PreparaRetorno(retorno, dic);
                    }
                    else
                    {
                        //ACTUALIZO DETALLES
                        foreach (ComprobanteDet d in Detalles)
                        {
                            //ASIGNO CONNEXION
                            d.SqlConnection = SqlConnection;
                            d.IDEncabezado = IDRegistro;
                            var dic = d.Abm();
                            func.PreparaRetorno(retorno, dic);
                        }
                    }

                    //NOTAS DE CREDITO DEBITO
                    if (ComprobanteTipo == "NC" || ComprobanteTipo == "ND" || ComprobanteTipo == "NCE" || ComprobanteTipo == "NDE")
                    {
                        //AGREGO RELACION NC-D Y SOLO AQUELLAS RELACIONES NUEVAS
                        foreach (ComprobantesRel d in ComprobantesRelacion.Where(w => w.IDRegistro <= 0))
                        {
                            //ASIGNO CONNEXION
                            d.SqlConnection = SqlConnection;
                            d.IDNotaCredito = ComprobanteTipo == "NC" || ComprobanteTipo == "NCE" ? IDRegistro : 0;
                            d.IDNotaDebito = ComprobanteTipo == "ND" || ComprobanteTipo == "NDE" ? IDRegistro : 0;
                            var dic = d.Abm();
                            func.PreparaRetorno(retorno, dic);

                        }
                    }

                }
                else
                {
                    Dictionary<short, string> re = new Dictionary<short, string>();
                    re.Add(1, "No se pudo obtener el id luego del guardado del encabezado.");
                    func.PreparaRetorno(retorno, re);
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
                
        #endregion
    }
}
