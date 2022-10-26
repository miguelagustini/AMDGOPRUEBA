using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class FacturaEnc : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES
        private static string tablaname = "AmdgoInterno.dbo.FACTAMBUENC";

        private long idregistro = 0;
        private DateTime fecha = DateTime.Now;
        private string tipocomprobante = "FC";
        private string letra = "";
        private int puntoventa = 0;
        private long numero = 0;
        private int idprofesional = 0;
        private string codigoprof = "";
        private int idcuentaprof = 0;
        private DateTime inicioactividad = DateTime.MinValue;
        private string ingresosbrutos = "";
        private string nombreprof = "";
        private long cuitprof = 0;
        private short ivaprof = 0;
        private string ivaprofabre = "";
        private string ivaprofadesc = "";
        private string domicilioprof = "";
        private int idprestdetalle = 0;
        private string codigoprest = "";
        private string nombrepres = "";
        private long cuitpres = 0;
        private short ivapres = 0;
        private string ivapresabre = "";
        private string ivapresdesc = "";
        private decimal porcivapres = 0;
        private string domfiscalpres = "";
        private decimal neto = 0;
        private decimal neto0 = 0;
        private decimal neto21 = 0;
        private decimal neto105 = 0;
        private decimal nogravado = 0;
        private decimal iva = 0;
        private decimal iva21 = 0;
        private decimal iva105 = 0;
        private decimal total = 0;
        private DateTime fechadesde = DateTime.MinValue;
        private DateTime fechahasta = DateTime.MinValue;
        private string estadoaf = "";
        private string canro = "";
        private string barrasaf = "";
        private DateTime vtocaeaf = DateTime.MinValue;
        private DateTime fechavto = DateTime.MinValue;
        private string observaciones = "";
        private string textoqr = "";
        private bool visible = true;
        private string periodo = "";
        private bool _comprobantesasociados = false;
        private bool _anulada = false;
        private byte[] _byteqr = null;
        private int entidadcuentaid = 0;
        private string entidadcuentacodigo = "";
        private string entidadnombre = "";
        private string mailreceptor = "";

        private string _pacientenombre = "";
        private long _pacientedocumento = 0;
        private long _internacionpuntero = 0;
        private string _internacionnumero = "";

        //DATOS FACTURA FCE
        private bool emitefce = false;
        private string cbu = "";
        private string alias = "";
        private string tipocircuito = "";
        private bool prestmipyme = false;

        private DateTime fechafactura = DateTime.MinValue;
        private bool companulareceptor = false;
        private short idmodofacturacion = 1;
        private short idtipoprestataria = 0;

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

        public long IDRegistro
        {
            get { return idregistro; }
            set
            {
                if (idregistro != value)
                {
                    idregistro = value;
                }
            }
        }

        public DateTime FechaFactura
        {
            get { return fechafactura; }
            set
            {
                if (fechafactura != value)
                {
                    fechafactura = value;
                }
            }
        }

        public bool ComprobanteAnuladoReceptor
        {
            get { return companulareceptor; }
            set { companulareceptor = companulareceptor != value ? value : companulareceptor; }
        }

        public bool GeneracionAutomatica { get; set; } = true;

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (fecha != value)
                {
                    fecha = value;
                }
            }
        }

        public DateTime FechaVto
        {
            get { return fechavto; }
            set
            {
                if (fechavto != value)
                {
                    fechavto = value;
                }
            }
        }

        public string TipoComprobante
        {
            get { return tipocomprobante; }
            set
            {
                if (tipocomprobante != value.Trim())
                {
                    tipocomprobante = value.Trim();
                }
            }
        }

        public int TipoComprobanteNumero
        {
            get
            {
                int a = 0;

                switch (TipoComprobante + Letra)
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

        public string Letra
        {
            get
            {
                return letra;
            }
            set
            {
                if (letra != value.Trim())
                {
                    letra = value.Trim();
                }
            }
        }

        public int PuntoVenta
        {
            get { return puntoventa; }
            set
            {
                if (puntoventa != value)
                {
                    puntoventa = value;
                }
            }
        }

        //DATOS COMPROBANTE FCE
        public bool EmisorEmiteComprobanteFCE
        {
            get { return emitefce; }
            set { emitefce = emitefce != value ? value : emitefce; }
        }

        public string EmisorCbuComprobanteFCE
        {
            get { return cbu; }
            set { cbu = cbu != value.Trim() ? value.Trim() : cbu; }
        }

        public string EmisorAliasComprobanteFCE
        {
            get { return alias; }
            set { alias = alias != value.Trim() ? value.Trim() : alias; }
        }

        public string EmisorCircuitoComprobanteFCE
        {
            get { return tipocircuito; }
            set { tipocircuito = tipocircuito != value.Trim() ? value.Trim() : tipocircuito; }
        }

        public short IDModoFacturacion
        {
            get { return idmodofacturacion; }
            set { idmodofacturacion = idmodofacturacion != value ? value : idmodofacturacion; }
        }

        public long Numero
        {
            get { return numero; }
            set
            {
                if (numero != value)
                {
                    numero = value;
                }
            }
        }

        public string Periodo
        {
            get { return periodo; }
            set
            {
                if (periodo != value.Trim())
                {
                    periodo = value.Trim();
                }
            }
        }

        public int IDProfesional
        {
            get { return idprofesional; }
            set
            {
                if (idprofesional != value)
                {
                    idprofesional = value;
                }
            }

        }

        public int IDCuentaProf
        {
            get { return idcuentaprof; }
            set
            {
                if (idcuentaprof != value)
                {
                    idcuentaprof = value;
                }
            }

        }

        public string CodigoProf
        {
            get { return codigoprof; }
            set
            {
                if (codigoprof != value.Trim())
                {
                    codigoprof = value.Trim();
                }
            }
        }

        public string NombreProf
        {
            get { return nombreprof; }
            set
            {
                if (nombreprof != value.Trim())
                {
                    nombreprof = value.Trim();
                }
            }
        }

        public DateTime InicioActividad
        {
            get { return inicioactividad; }
            set
            {
                if (inicioactividad != value)
                {
                    inicioactividad = value;
                }
            }
        }

        public string IngresosBrutos
        {
            get { return ingresosbrutos; }
            set
            {
                if (ingresosbrutos != value.Trim())
                {
                    ingresosbrutos = value.Trim();
                }
            }
        }

        public long CuitProf
        {
            get { return cuitprof; }
            set
            {
                if (cuitprof != value)
                {
                    cuitprof = value;
                }
            }
        }

        public string IvaProfAbre
        {
            get { return ivaprofabre; }
            set
            {
                if (ivaprofabre != value.Trim())
                {
                    ivaprofabre = value.Trim();
                }
            }
        }

        public string IvaProfDesc
        {
            get { return ivaprofadesc; }
            set
            {
                if (ivaprofadesc != value.Trim())
                {
                    ivaprofadesc = value.Trim();
                }
            }
        }

        public short IvaProf
        {
            get { return ivaprof; }
            set
            {
                if (ivaprof != value)
                {
                    ivaprof = value;
                }
            }
        }

        public string DomFiscalProf
        {
            get { return domicilioprof; }
            set
            {
                if (domicilioprof != value.Trim())
                {
                    domicilioprof = value.Trim();
                }
            }

        }

        public int IDPrestDetalle
        {
            get { return idprestdetalle; }
            set
            {
                if (idprestdetalle != value)
                {
                    idprestdetalle = value;
                }
            }
        }

        public string CodigoPres
        {
            get { return codigoprest; }
            set
            {
                if (codigoprest != value.Trim())
                {
                    codigoprest = value.Trim();
                }
            }

        }

        public string NombrePres
        {
            get { return nombrepres; }
            set
            {
                if (nombrepres != value.Trim())
                {
                    nombrepres = value.Trim();
                }
            }
        }

        public string PrestatariaPlanNombre { get; set; } = string.Empty;


        public long CuitPres
        {
            get { return cuitpres; }
            set
            {
                if (cuitpres != value)
                {
                    cuitpres = value;
                }
            }
        }

        public short IvaPres
        {
            get { return ivapres; }
            set
            {
                if (ivapres != value)
                {
                    ivapres = value;
                }
            }
        }

        public string IvaPresAbre
        {
            get { return ivapresabre; }
            set
            {
                if (ivapresabre != value.Trim())
                {
                    ivapresabre = value.Trim();
                }
            }
        }

        public string IvaPresDesc
        {
            get { return ivapresdesc; }
            set
            {
                if (ivapresdesc != value.Trim())
                {
                    ivapresdesc = value.Trim();
                }
            }
        }

        public bool PresMiPyme
        {
            get { return prestmipyme; }
            set { prestmipyme = prestmipyme != value ? value : prestmipyme; }
        }

        public short IDTipoPrestataria
        {
            get { return idtipoprestataria; }
            set { idtipoprestataria = idtipoprestataria != value ? value : idtipoprestataria; }
        }

        public decimal PorcIvaPres
        {
            get { return porcivapres; }
            set
            {
                if (porcivapres != value)
                {
                    porcivapres = value;
                }
            }

        }

        public string DomFiscalPres
        {
            get { return domfiscalpres; }
            set
            {
                if (domfiscalpres != value.Trim())
                {
                    domfiscalpres = value.Trim();
                }
            }
        }

        public string PacienteNombre
        {
            get { return _pacientenombre; }
            set
            {
                _pacientenombre = _pacientenombre != value.Trim() ? value.Trim() : _pacientenombre;
            }
        }

        public long PacienteDocumento
        {
            get { return _pacientedocumento; }
            set
            {
                _pacientedocumento = _pacientedocumento != value ? value : _pacientedocumento;
            }
        }

        public string Paciente
        {
            get { return PacienteDocumento > 0 ? PacienteNombre + " " + PacienteDocumento : ""; }
        }

        public long InternacionPuntero
        {
            get { return _internacionpuntero; }
            set
            {
                _internacionpuntero = _internacionpuntero != value ? value : _internacionpuntero;
            }
        }

        public string InternacionNumero
        {
            get { return _internacionnumero; }
            set { _internacionnumero = _internacionnumero != value.Trim() ? value.Trim() : _internacionnumero; }
        }

        public int EntidadCuentaID
        {
            get { return entidadcuentaid; }
            set { entidadcuentaid = entidadcuentaid != value ? value : entidadcuentaid; }
        }

        public string EntidadCuentaCodigo
        {
            get { return entidadcuentacodigo; }
            set { entidadcuentacodigo = entidadcuentacodigo != value.Trim() ? value.Trim() : entidadcuentacodigo; }
        }

        public string EntidadNombre
        {
            get { return entidadnombre; }
            set { entidadnombre = entidadnombre != value.Trim() ? value.Trim() : entidadnombre; }
        }

        public decimal Neto
        {
            get { return neto; }
            set
            {
                if (neto != value)
                {
                    neto = value;
                }
            }
        }

        public decimal Neto0
        {
            get { return neto0; }
            set
            {
                neto0 = neto0 != value ? value : neto0;
            }
        }

        public decimal Neto21
        {
            get { return neto21; }
            set
            {
                if (neto21 != value)
                {
                    neto21 = value;
                }
            }
        }

        public decimal Neto105
        {
            get { return neto105; }
            set
            {
                if (neto105 != value)
                {
                    neto105 = value;
                }
            }
        }

        public decimal NoGravado
        {
            get { return nogravado; }
            set
            {
                if (nogravado != value)
                {
                    nogravado = value;
                }
            }
        }

        public decimal Iva
        {
            get { return iva; }
            set
            {
                if (iva != value)
                {
                    iva = value;
                }
            }
        }

        public decimal Iva21
        {
            get { return iva21; }
            set
            {
                if (iva21 != value)
                {
                    iva21 = value;
                }
            }
        }

        public decimal Iva105
        {
            get { return iva105; }
            set
            {
                if (iva105 != value)
                {
                    iva105 = value;
                }
            }
        }

        public decimal Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                }
            }
        }

        public DateTime FechaDesde
        {
            get { return fechadesde; }
            set
            {
                if (fechadesde != value)
                {
                    fechadesde = value;
                }
            }
        }

        public DateTime FechaHasta
        {
            get { return fechahasta; }
            set
            {
                if (fechahasta != value)
                {
                    fechahasta = value;
                }
            }
        }

        public string EstadoAf
        {
            get { return estadoaf; }
            set
            {
                if (estadoaf != value.Trim())
                {
                    estadoaf = value.Trim();
                }
            }

        }

        public string CaeNroAf
        {
            get { return canro; }
            set
            {
                if (canro != value.Trim())
                {
                    canro = value.Trim();
                }
            }

        }

        public string BarrasAf
        {
            get { return barrasaf; }
            set
            {
                if (barrasaf != value.Trim())
                {
                    barrasaf = value.Trim();
                }
            }

        }

        public DateTime VtoCaeAf
        {
            get { return vtocaeaf; }
            set
            {
                if (vtocaeaf != value)
                {
                    vtocaeaf = value;
                }
            }
        }

        public string ObservAf
        {
            get { return observaciones; }
            set
            {
                if (observaciones != value.Trim())
                {
                    observaciones = value.Trim();
                }
            }

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

        public bool Visible
        {
            get { return visible; }
            set
            {
                if (visible != value) { visible = value; }
            }
        }

        public string MailReceptorComprobante
        {
            get { return mailreceptor; }
            set { mailreceptor = mailreceptor != value.Trim() ? value.Trim() : mailreceptor; }
        }

        public string Comprobante
        {
            get { return $"{PuntoVenta.ToString("0000")}-{Numero.ToString("00000000")}"; }
        }

        public string ComprobanteCompleto
        {
            get { return $"{TipoComprobante} {Letra}{PuntoVenta.ToString("0000")}-{Numero.ToString("00000000")}"; }
        }

        public string CodigoComprobante
        {
            get
            {
                string c = "";

                if (TipoComprobante == "FC" && Letra == "A") { c = "Cod. 001"; }
                else if (TipoComprobante == "FC" && Letra == "B") { c = "Cod. 006"; }
                else if (TipoComprobante == "FC" && Letra == "C") { c = "Cod. 011"; }
                else if (TipoComprobante == "NC" && Letra == "A") { c = "Cod. 003"; }
                else if (TipoComprobante == "NC" && Letra == "B") { c = "Cod. 008"; }
                else if (TipoComprobante == "NC" && Letra == "C") { c = "Cod. 013"; }
                else if (TipoComprobante == "ND" && Letra == "A") { c = "Cod. 002"; }
                else if (TipoComprobante == "ND" && Letra == "B") { c = "Cod. 007"; }
                else if (TipoComprobante == "ND" && Letra == "C") { c = "Cod. 012"; }
                else { c = ""; }

                return c;
            }
        }

        public bool ComprobantesAsociados
        {
            get { return _comprobantesasociados; }
            set { _comprobantesasociados = _comprobantesasociados != value ? value : _comprobantesasociados; }
        }

        public bool Anulada
        {
            get { return _anulada; }
            set { _anulada = _anulada != value ? value : _anulada; }
        }

        public List<FacturaDet> Detalles { get; set; } = new List<FacturaDet>();

        public List<ComprobantesRel> ComprobantesRel { get; set; } = new List<ComprobantesRel>();

        public List<DetallesPrint> DetallesPrint { get; set; } = new List<DetallesPrint>();

        //REFERENTES BD
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public int ID_Profesional { get { return IDProfesional; } }
        public int ID_PrestDetalle { get { return IDPrestDetalle; } }
        public int ID_CuentaProf { get { return IDCuentaProf; } }

        public string CircuitoFCE  { get{return EmisorCircuitoComprobanteFCE;} }
        public string CbuFCE { get{return EmisorCbuComprobanteFCE;} }
        public string AliasFCE { get { return EmisorAliasComprobanteFCE;} }
        
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public string Guid { get { return IDLocal; } }


        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public FacturaEnc() { }

        public FacturaEnc(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public FacturaEnc Clone()
        {
            FacturaEnc d = (FacturaEnc)MemberwiseClone();
            FacturaDet det = new FacturaDet();
            ComprobantesRel r = new ComprobantesRel();

            d.Detalles = det.Clone(Detalles);
            d.ComprobantesRel = r.Clone(ComprobantesRel);

            return d;
        }

        //CLONE CON LISTAS
        public List<FacturaEnc> Clone(List<FacturaEnc> lst)
        {
            List<FacturaEnc> lista = new List<FacturaEnc>();

            foreach (FacturaEnc d in lst)
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

        public List<FacturaEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<FacturaEnc> lista = new List<FacturaEnc>();

                string c = $"SELECT FE.ID_Registro AS IDRegistro, FE.Fecha, FE.Fecha AS FechaFactura, FE.TipoComprobante, FE.Letra, FE.PuntoVenta, FE.Numero, FE.ID_CuentaProf AS IDCuentaProf, FE.ID_Profesional AS IDProfesional, FE.NombreProf, FE.CuitProf, FE.IvaProf, FE.DomFiscalProf," +
                           $" FE.ID_PrestDetalle AS IDPrestDetalle, FE.NombrePres, FE.CuitPres, FE.IvaPres, FE.PorcIvaPres, FE.DomFiscalPres, FE.Guid AS IDLocal, FE.Neto, FE.Neto21, FE.Neto105, FE.NoGravado, FE.Iva," +
                           $" FE.Iva21, FE.Iva105, FE.Total, FE.FechaDesde, FE.FechaHasta, FE.EstadoAf, FE.CaeNroAf, FE.BarrasAf, FE.VtoCaeAf, FE.ObservAf, FE.Visible, PC.Codigo as CodigoProf, PD.Codigo as CodigoPres," +
                           $" PCI.Abreviatura AS IvaProfAbre, PDCI.Abreviatura AS IvaPresAbre, PCI.Descripcion AS IvaProfDesc, PDCI.Descripcion AS IvaPresDesc," +
                           $" PR.InicioActividad, PR.IngrBrutos AS IngresosBrutos, FE.FechaVto, FE.InternacionNumero, FE.InternacionPuntero, FE.PacienteDocumento, FE.PacienteNombre," +
                           $" CAST(IIF( (SELECT COUNT(*) FROM FACTAMBUREL RE WHERE RE.ID_Factura = FE.ID_REGISTRO) > 0, 1, 0) AS BIT) AS ComprobantesAsociados," +
                           $" CAST(IIF((FE.Total - ISNULL((SELECT SUM(FR.Total)" +
                                                        $" FROM FACTAMBUREL NC" +
                                                        $" LEFT OUTER JOIN FACTAMBUENC FR ON(FR.ID_Registro = NC.ID_NotaCredito AND NC.ID_NotaCredito > 0)" +
                                                        $" WHERE NC.ID_Factura = FE.ID_Registro AND FR.EstadoAf = 'A'),0)" +
                                                        $" + ISNULL((SELECT SUM(FR1.Total)" +
                                                        $" FROM FACTAMBUREL ND" +
                                                        $" LEFT OUTER JOIN FACTAMBUENC FR1 ON(FR1.ID_Registro = ND.ID_NotaDebito AND ND.ID_NotaDebito > 0)" +
                                                        $" WHERE ND.ID_Factura = FE.ID_Registro AND FR1.EstadoAf = 'A'),0)) <= 0, 1, 0) as bit) AS Anulada," +
                           $" FE.EntidadCuentaID, PCE.Codigo as EntidadCuentaCodigo, PRE.Nombre as EntidadNombre," +
                           $" PR.Email AS MailReceptorComprobante, " +
                           $" FE.CircuitoFCE AS EmisorCircuitoComprobanteFCE, FE.CbuFCE AS EmisorCbuComprobanteFCE, FE.AliasFCE AS EmisorAliasComprobanteFCE," +
                           $" PRT.MiPyme AS PresMiPyme, PRE.IDModoFacturacion, PR.EmiteFCE AS EmisorEmiteComprobanteFCE, ISNULL(PD.Descripcion, '') AS PrestatariaPlanNombre" +
                           $" FROM {tablaname} FE" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON (PC.ID_Registro = FE.ID_CuentaProf)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PR ON (PR.ID_Registro = PC.ID_Profesional)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PCE ON (PCE.ID_Registro = FE.EntidadCuentaID)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PRE ON (PRE.ID_Registro = PCE.ID_Profesional)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA PCI ON (PCI.ID_Registro = FE.IvaProf)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON (PD.ID_Registro = FE.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PRT ON (PRT.ID_Registro = PD.ID_Prestataria)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA PDCI ON (PDCI.ID_Registro = FE.IvaPres)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<FacturaEnc>(rdr));
                }

                cnb.Desconectar();
                                               
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<FacturaEnc>();
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

        //METODOS GENERALES
        #region METODOS GENERALES

        public void SetLetra()
        {
            
            if (IvaProf == 1 && IvaPres == 1) { Letra = "A"; }            
            else if (IvaProf == 1 && IvaPres != 1) { Letra = "B"; }
            else if (IvaProf != 1) { Letra = "C"; }
            else { Letra = ""; }
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

            campos.Add("Fecha");
            campos.Add("TipoComprobante");
            campos.Add("Letra");
            campos.Add("PuntoVenta");
            campos.Add("Numero");
            campos.Add("InternacionNumero");
            campos.Add("InternacionPuntero");
            campos.Add("PacienteDocumento");
            campos.Add("PacienteNombre");
            campos.Add("EntidadCuentaID");
            campos.Add("ID_Profesional");
            campos.Add("ID_CuentaProf");
            campos.Add("NombreProf");
            campos.Add("CuitProf");
            campos.Add("IvaProf");
            campos.Add("DomFiscalProf");
            campos.Add("ID_PrestDetalle");            
            campos.Add("CircuitoFCE");
            campos.Add("CbuFCE");
            campos.Add("AliasFCE");
            campos.Add("NombrePres");
            campos.Add("CuitPres");
            campos.Add("IvaPres");
            campos.Add("PorcIvaPres");
            campos.Add("DomFiscalPres");
            campos.Add("Guid");
            campos.Add("Neto");
            campos.Add("Neto21");
            campos.Add("Neto105");
            campos.Add("NoGravado");
            campos.Add("Iva");
            campos.Add("Iva21");
            campos.Add("Iva105");
            campos.Add("Total");
            campos.Add("FechaDesde");
            campos.Add("FechaHasta");
            campos.Add("EstadoAf");
            campos.Add("CaeNroAf");
            campos.Add("BarrasAf");
            campos.Add("VtoCaeAf");
            campos.Add("ObservAf");
            campos.Add("Visible");
            campos.Add("GeneracionAutomatica");
            campos.Add("ID_UsuNew");
            campos.Add("ID_UsuModif");

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
                        FacturaDet detalle = new FacturaDet();
                        detalle.SqlConnection = SqlConnection;
                        var dic = detalle.Abm(Detalles);
                        func.PreparaRetorno(retorno, dic);
                    }
                    else
                    {
                        //ACTUALIZO DETALLES
                        foreach (FacturaDet d in Detalles)
                        {
                            //ASIGNO CONNEXION
                            d.SqlConnection = SqlConnection;
                            d.IDEncabezado = IDRegistro;
                            var dic = d.Abm();
                            func.PreparaRetorno(retorno, dic);
                        }
                    }
                    
                    if (TipoComprobante == "NC" || TipoComprobante == "ND" || TipoComprobante == "NCE" || TipoComprobante == "NDE" )
                    {
                        //AGREGO RELACION NC-D Y SOLO AQUELLAS RELACIONES NUEVAS
                        foreach (ComprobantesRel d in ComprobantesRel.Where(w => w.IDRegistro <= 0))
                        {
                            //ASIGNO CONNEXION
                            d.SqlConnection = SqlConnection;                            
                            d.IDNotaCredito = TipoComprobante == "NC" || TipoComprobante == "NCE" ? IDRegistro : 0;
                            d.IDNotaDebito = TipoComprobante == "ND" || TipoComprobante == "NDE" ? IDRegistro : 0;
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
