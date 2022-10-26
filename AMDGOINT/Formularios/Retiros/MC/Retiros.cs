using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Retiros.MC
{
    public class Retiros : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[rt_RETIRODETALLES]";

        private DateTime _fecha = DateTime.Now;
        private long _idregistro = 0;
        private int _idencabezado = 0;
        private int _idcuentaasociado = 0;        
        private short _idconcepto = 0;
        private string _observacion = "";
        private byte[] _comprobanbte = null;
        private decimal _importe = 0;
        private byte _cobroforma = 0;
        private short _estado = 0;
        private byte _idpagoforma = 0;        
        private DateTime _vencimiento1 = DateTime.MinValue;
        private DateTime _vencimiento2 = DateTime.MinValue;
        private DateTime _vencimiento3 = DateTime.MinValue;
        private decimal _disponibilidad = 0;
        private short _idtipo = 1;
        private short _idempresa = 0;
        private bool _borraregistro = false;
        private string _nombreasociado = "";
        private string _conceptodesc = "";
        private string _retirotipo = "";
        private string _empresanombre = "";
        private long _empresacuit = 0;
        private string _tipoarchivo = "";
        private bool _enviadodos = false;
        private byte _categoria = 0;
        private byte _tipomovimiento = 1;
        private int _idfacturafsa = 0;
        private string _cuentadescripcion = "";
        private string _cuentacodigo = "";
        private string _pagoforma = "";
        private bool _pagado = false;


        public long IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public short IDTipo
        {
            get { return _idtipo; }
            set { _idtipo = _idtipo != value ? value : _idtipo; }
        }

        public string RetiroTipo
        {
            get { return _retirotipo; }
            set { _retirotipo = _retirotipo != value.Trim() ? value.Trim() : _retirotipo; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = _fecha != value ? value : _fecha; }
        }

        public int IDEncabezado
        {
            get { return _idencabezado; }
            set { _idencabezado = _idencabezado != value ? value : _idencabezado; }
        }

        public string NumeroPedido
        {
            get { return IDEncabezado.ToString("00000000"); }
        }

        public short IDEmpresa
        {
            get { return _idempresa; }
            set { _idempresa = _idempresa != value ? value : _idempresa; }
        }

        public string EmpresaNombre
        {
            get { return _empresanombre; }
            set { _empresanombre = _empresanombre != value.Trim() ? value.Trim() : _empresanombre; }
        }

        public long EmpresaCuit
        {
            get { return _empresacuit; }
            set { _empresacuit = _empresacuit != value ? value : _empresacuit; }
        }

        public string EmpresaCompleto
        {
            get { return EmpresaCuit > 0 ? EmpresaNombre + " " + EmpresaCuit : EmpresaNombre; }
        }

        public byte IDPagoForma
        {
            get { return _idpagoforma; }
            set { _idpagoforma = _idpagoforma != value ? value : _idpagoforma; }
        }

        public string PagoForma
        {
            get { return _pagoforma; }
            set { _pagoforma = _pagoforma != value.Trim() ? value.Trim() : _pagoforma; }
        }

        public int IDCuentaAsociado
        {
            get { return _idcuentaasociado; }
            set { _idcuentaasociado = _idcuentaasociado != value ? value : _idcuentaasociado; }
        }

        //PARA AGRUPACION RETIROS EN ORDENES PAGO Y CAJA
        public int IDCuentaAmdgo
        {
            get { return IDCuentaAsociado == 546 || IDCuentaAsociado == 547 ? IDCuentaAsociado : 0; }
        }

        public string AsociadoNombre
        {
            get { return _nombreasociado; }
            set { _nombreasociado = _nombreasociado != value.Trim() ? value.Trim() : _nombreasociado; }
        }

        public string CuentaDescripcion
        {
            get { return _cuentadescripcion; }
            set
            {
                _cuentadescripcion = _cuentadescripcion != value.Trim() ? value.Trim() : _cuentadescripcion;
            }
        }

        public string CuentaCodigo
        {
            get { return _cuentacodigo; }
            set
            {
                _cuentacodigo = _cuentacodigo != value.Trim() ? value.Trim() : _cuentacodigo;
            }
        }

        public int CuentaCodigoAgrupador
        {
            get
            {
                return CuentaCodigo == "9000" || CuentaCodigo == "9001" ? 1 : 0;
            }
        }

        public string AsociadoNombreOP
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(AsociadoNombre)) { return CuentaCodigo + " " + CuentaDescripcion; }
                //else { return CuentaCodigo + " " + AsociadoNombre; }
                                
                if (!string.IsNullOrEmpty(CuentaDescripcion)) { return CuentaCodigo + " " + CuentaDescripcion; }
                else { return CuentaCodigo + " " + AsociadoNombre; }
            }

        }

        public DateTime VencimientoUno
        {
            get { return _vencimiento1; }
            set { _vencimiento1 = _vencimiento1 != value ? value : _vencimiento1; }
        }

        public DateTime VencimientoDos
        {
            get { return _vencimiento2; }
            set { _vencimiento2 = _vencimiento2 != value ? value : _vencimiento2; }
        }

        public DateTime VencimientoTres
        {
            get { return _vencimiento3; }
            set { _vencimiento3 = _vencimiento3 != value ? value : _vencimiento3; }
        }

        public short IDConcepto
        {
            get { return _idconcepto; }
            set { _idconcepto = _idconcepto != value ? value : _idconcepto; }
        }

        public string ConceptoDescripcion
        {
            get { return _conceptodesc; }
            set { _conceptodesc = _conceptodesc != value.Trim() ? value.Trim() : _conceptodesc; }
        }

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public byte[] Comprobante
        {
            get { return _comprobanbte; }
            set { _comprobanbte = _comprobanbte != value ? value : _comprobanbte; }
        }

        public string TipoArchivo
        {
            get { return _tipoarchivo; }
            set { _tipoarchivo = _tipoarchivo != value.Trim() ? value.Trim() : _tipoarchivo; }
        }

        public decimal Importe
        {
            get { return _importe; }
            set { _importe = _importe != value ? value : _importe; }
        }

        public decimal Disponibilidad
        {
            get { return _disponibilidad; }
            set { _disponibilidad = _disponibilidad != value ? value : _disponibilidad; }
        }

        public short Estado
        {
            get { return _estado; }
            set { _estado = _estado != value ? value : _estado; }
        }

        public string EstadoDescripcion
        {
            get
            {
                switch (Estado)
                {
                    case 0: return "Pendiente";
                    case 1: return "Aprobado";
                    case 2: return "Rechazado";
                    default: return "Pendiente";
                }
            }
            
        }

        public bool BorraRegistro
        {
            get { return _borraregistro; }
            set { _borraregistro = _borraregistro != value ? value : _borraregistro; }
        }

        public bool ExisteComprobante
        {
            get { return Comprobante != null ? true : false; }
        }

        public bool EnviadoDos
        {
            get { return _enviadodos; }
            set { _enviadodos = _enviadodos != value ? value : _enviadodos; }
        }

        public bool Pagado
        {
            get { return _pagado; }
            set { _pagado = _pagado != value ? value : _pagado; }
        }

        public byte Categoria
        {
            get { return _categoria; }
            set { _categoria = _categoria != value ? value : _categoria; }
        }
               
        public string CategoriaDescripcion
        {
            get
            {
                string c = "";
                if (Categoria == 0) { c = "Normal"; }   
                else if (Categoria == 1) { c = "Rápido"; }   
                else if (Categoria == 2) { c = "Urgente"; }

                return c;
            }
        }

        public byte CobroForma
        {
            get { return _cobroforma; }
            set { _cobroforma = _cobroforma != value ? value : _cobroforma; }
        }

        public string CobroFormaDescripcion
        {

            get
            {
                string c = "";
                if (CobroForma == 0) { c = "Cuenta Corriente"; }
                else if (CobroForma == 1) { c = "Efectivo"; }
                else if (CobroForma == 2) { c = "Transferencia"; }

                return c;
            }

        }

        public byte TipoMovimiento
        {
            get { return _tipomovimiento; }
            set { _tipomovimiento = _tipomovimiento != value ? value : _tipomovimiento; }
        }

        public int IDFacturaFsa
        {
            get { return _idfacturafsa; }
            set { _idfacturafsa = _idfacturafsa != value ? value : _idfacturafsa; }
        }

        public byte EnviadoDosOP
        {
            get { if (EnviadoDos) { return 1; } else { return 0; } }
        }

        public string NombreUsuario
        {
            get { return glb.GetNomUsuariolog(); }
        }

        public bool Seleccionado { get; set; } = false;

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public int IDUsuNew { get => Convert.ToInt16(glb.GetIdUsuariolog()); }
        public int IDUsuModif { get => Convert.ToInt16(glb.GetIdUsuariolog()); }
        public DateTime TimeModif { get => DateTime.Now; }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Retiros() { }

        public Retiros(SqlConnection conexion)
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
        public Retiros Clone()
        {
            Retiros d = (Retiros)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Retiros> Clone(List<Retiros> lst)
        {
            List<Retiros> lista = new List<Retiros>();

            foreach (Retiros d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Retiros> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Retiros> lista = new List<Retiros>();

                string c = $"SELECT RD.IDRegistro, RD.Fecha, RD.IDEncabezado, RD.IDCuentaAsociado, RD.IDEmpresa, RD.IDConcepto, RD.Observacion, RD.Comprobante, RD.Importe, RD.Estado," +
                           $" RD.VencimientoUno, RD.VencimientoDos, RD.VencimientoTres, RD.IDPagoForma, RC.IDRetiroTipo AS IDTipo, PF.Nombre AS AsociadoNombre, RD.CobroForma," +
                           $" RC.Descripcion AS ConceptoDescripcion, RT.Descripcion AS RetiroTipo, EM.Nombre AS EmpresaNombre, EM.Cuit as EmpresaCuit, RD.TipoArchivo, RD.EnviadoDos, RD.Categoria," +
                           $" RD.IDFacturaFsa, PC.Descripcion as CuentaDescripcion, PC.Codigo as CuentaCodigo, PG.Descripcion as PagoForma, RD.TipoMovimiento, RD.Pagado" +
                           $" FROM {tablaname} RD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[rt_RETIROCONCEPTOS] RC ON(RC.IDRegistro = RD.IDConcepto)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].rt_RETIROTIPOS RT ON(RT.IDRegistro = RC.IDRetiroTipo)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].EMPRESAS EM ON(EM.IDRegistro = RD.IDEmpresa)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[PAGOFORMAS] PG ON(PG.IDRegistro = RD.IDPagoForma)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = RD.IDCuentaAsociado)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Retiros>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Retiros>();
            }
        }

        //OBTENGO EL SALDO IMPUTADO A LA CUENTA EN EL PERIODO CORRESPONDIENTE
        public List<Retiros> GetPagosImputados()
        {
            try
            {

                DateTime primerafecha; 
                DateTime segundafecha; 

                if (DateTime.Today.Day <= 20)
                {
                    primerafecha = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 21);
                    segundafecha = DateTime.Today;                    
                }
                else
                {
                    primerafecha = DateTime.Today;
                    segundafecha = new DateTime(DateTime.Today.AddMonths(1).Year, DateTime.Today.AddMonths(1).Month, 20);
                }
                                
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List <Retiros> lista = new List<Retiros>();

                string c = $"SELECT RD.IDRegistro, RD.Fecha, RD.IDEncabezado, RD.IDCuentaAsociado, RD.IDEmpresa, RD.IDConcepto, RD.Observacion, RD.Comprobante, RD.Importe, RD.Estado," +
                           $" RD.VencimientoUno, RD.VencimientoDos, RD.VencimientoTres, RD.IDPagoForma, RC.IDRetiroTipo AS IDTipo" +
                           $" FROM {tablaname} RD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[rt_RETIROCONCEPTOS] RC ON(RC.IDRegistro = RD.IDConcepto)" +
                           $" WHERE FORMAT(RD.Fecha,'yyyy-MM-dd') BETWEEN '{primerafecha.ToString("yyyy-MM-dd")}' AND '{segundafecha.ToString("yyyy-MM-dd")}'" +
                           $" AND RD.Estado <= 1"; //SOLO PENDIENTES Y APROBADOS

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Retiros>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los retiros imputados.\n{e.Message}", 0);
                return new List<Retiros>();
            }
        }

        public List<Retiros> GetRetirosPedientesPago(int idempresa, int idprofesional)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Retiros> lista = new List<Retiros>();

                string c = $"SELECT RD.IDRegistro, RD.Fecha, RD.IDEncabezado, RD.IDCuentaAsociado, RD.IDEmpresa, RD.IDConcepto, RD.Observacion, RD.Comprobante, RD.Importe, RD.Estado," +
                           $" RD.VencimientoUno, RD.VencimientoDos, RD.VencimientoTres, RD.IDPagoForma, RC.IDRetiroTipo AS IDTipo, PF.Nombre AS AsociadoNombre, RD.CobroForma," +
                           $" RC.Descripcion AS ConceptoDescripcion, RT.Descripcion AS RetiroTipo, EM.Nombre AS EmpresaNombre, EM.Cuit as EmpresaCuit, RD.TipoArchivo, RD.EnviadoDos, RD.Categoria," +
                           $" RD.IDFacturaFsa, PC.Descripcion as CuentaDescripcion, PC.Codigo as CuentaCodigo, PG.Descripcion as PagoForma, RD.TipoMovimiento, RD.Pagado" +
                           $" FROM {tablaname} RD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[rt_RETIROCONCEPTOS] RC ON(RC.IDRegistro = RD.IDConcepto)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].rt_RETIROTIPOS RT ON(RT.IDRegistro = RC.IDRetiroTipo)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].EMPRESAS EM ON(EM.IDRegistro = RD.IDEmpresa)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[PAGOFORMAS] PG ON(PG.IDRegistro = RD.IDPagoForma)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = RD.IDCuentaAsociado)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" WHERE RD.Pagado = 0 AND RD.Estado = 1" + (idempresa > 0 ? " AND RD.IDEmpresa = " + idempresa : idprofesional > 0 ? " AND RD.IDCuentaAsociado = " + idprofesional : "") +
                           //$" {idempresa > 0 ? + " " + } AND RD.IDEmpresa = {idempresa}" +
                           $" AND RD.IDEncabezado NOT IN (SELECT OD.RetiroID FROM [AmdgoContable].[dbo].[ts_ORDENESPAGODET] OD)" +
                           $" AND RD.IDEncabezado NOT IN (SELECT CA.RetiroEncabezadoID FROM [AmdgoContable].[dbo].[ts_CAJAMOVIMIENTOS] CA)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Retiros>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Retiros>();
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
            
            campos.Add("Fecha");
            campos.Add("IDEncabezado");
            campos.Add("IDCuentaAsociado");
            campos.Add("IDEmpresa");
            campos.Add("IDConcepto");
            campos.Add("IDPagoForma");
            campos.Add("VencimientoUno");
            campos.Add("VencimientoDos");
            campos.Add("VencimientoTres");
            campos.Add("Observacion");
            campos.Add("Comprobante"); 
            campos.Add("TipoArchivo"); 
            campos.Add("Importe");
            campos.Add("Estado");
            campos.Add("EnviadoDos");
            campos.Add("Categoria");
            campos.Add("TipoMovimiento");
            campos.Add("IDFacturaFsa");
            campos.Add("CobroForma");
            campos.Add("Pagado");
            campos.Add("IDUsuNew");            
            campos.Add("IDUsuModif");
            campos.Add("TimeModif");

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            if (BorraRegistro) { return retorno; }

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

                try
                {
                    //PARAMETROS
                    short paramnro = 0;
                    foreach (string c in campos)
                    {
                        if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                        }
                        else if (GetType().GetProperty(c).PropertyType == typeof(byte[]) && GetType().GetProperty(c).GetValue(this) == null)
                        {
                            cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", SqlBinary.Null);
                        }
                        else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null)); }

                        paramnro++;
                    }
                    
                    //EJECUTO LA INSTRUCCION
                    cmd.ExecuteNonQuery();

                    cbd.Desconectar();
                    cmd.Dispose();
                }
                catch (Exception e)
                {                    
                    cbd.Desconectar();
                    cmd.Dispose();

                    retorno.Add(-1, $"{GetType().Name} Alta.\n{e.Message}");
                    return retorno;
                }

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

                //SI ESTA MARCADO PARA ELIMINACION
                if (BorraRegistro)
                {
                    var e = Eliminacion();
                    func.PreparaRetorno(retorno, e);

                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
                campos.Remove("IDUsuNew");
                
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
                query.Append($" WHERE (IDRegistro = {IDRegistro})");

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
                    else if (GetType().GetProperty(c).PropertyType == typeof(byte[]) && GetType().GetProperty(c).GetValue(this) == null)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", SqlBinary.Null);
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

        private Dictionary<short, string> Eliminacion()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (IDRegistro <= 0)
                {
                    retorno.Add(0, "Sin id de registro para eliminacion.");
                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();

                //INICIO DEL INSERT
                query.Append($"DELETE FROM {tablaname} WHERE IDRegistro = {IDRegistro}");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, e.Message);
                return retorno;
            }

        }
        #endregion


        #endregion
    }
}
