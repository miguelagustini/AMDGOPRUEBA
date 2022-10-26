using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Devoluciones.MC
{
    public class DevolucionesDet : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoInterno].[dbo].[DEVOLUCIONESDET]";
        private string _pacientedocumento = "";
        private string _pacientenombre = "";
        private string _practicacodigo = "";
        private string _practicanombre = "";
        private string _practicafuncion = "";
        private string _admisioncodigo = "";
        private string _prestatariaexpediente = "";
        private string _prestatarialote = "";
        private string _debitomotivo = "";
        private string _periododebitado = "";
        private string _periodofacturado = "";        
        private string _observacion = "";
        private string _lote = "";


        public long IDRegistro { get; set; } = 0;
        public long IDEncabezado { get; set; } = 0;
        public long IDAsocTranImp { get; set; } = 0;
        public long IDAsocMedDos { get; set; } = 0;
        public long IDAsocSan { get; set; } = 0;
        public string IdentificadorInternacionLocal { get { return IDAsocSan.ToString() + AdmisionCodigo; } }
        public string TipoDevolucion { get { return IDAsocTranImp > 0 ? "Débitos" : IDAsocMedDos > 0 ? "Órdenes Ambulatorias" : IDAsocSan > 0 ? "Órdenes Internación" : "Sin Definir"; } }
        public int ProfesionalCuentaID { get; set; } = 0;
        public string ProfesionalCuentaCodigo { get; set; } = "";
        public string ProfesionalCuentaNombre { get; set; } = "";
        public int PrestatariaCuentaID { get; set; } = 0;
        public string PrestatariaCuentaCodigo { get; set; } = "";
        public string PrestatariaCuentaNombre { get; set; } = "";
        public string PacienteDocumento { get { return _pacientedocumento; } set { _pacientedocumento = value?.Trim(); } }
        public string PacienteNombre { get { return _pacientenombre; } set { _pacientenombre = value?.Trim(); } }

        public string PracticaCodigo { get { return _practicacodigo; } set { _practicacodigo = value?.Trim(); } }
        public string PracticaNombre { get { return _practicanombre; } set { _practicanombre = value?.Trim(); } }
        public string PracticaFuncion { get { return _practicafuncion; } set { _practicafuncion = value?.Trim(); } }
        public string PracticaLote { get { return _lote; } set { _lote = value?.Trim(); } }
        public DateTime PracticaFecha { get; set; } = DateTime.MinValue;

        public string AdmisionCodigo { get { return _admisioncodigo; } set { _admisioncodigo = value?.Trim(); } }  //NUMERO DE BUSQUEDA O INTERNACION        
        public string PrestatariaExpediente { get { return _prestatariaexpediente; } set { _prestatariaexpediente = value?.Trim(); } }
        public string PrestatariaLote { get { return _prestatarialote; } set { _prestatarialote = value?.Trim(); } }
        public string DebitoMotivo { get { return _debitomotivo; } set { _debitomotivo = value?.Trim(); } }

        public string PeriodoFacturado { get { return _periodofacturado; } set { _periodofacturado = value?.Trim(); } }
        public string PeriodoDebitado { get { return _periododebitado; } set { _periododebitado = value?.Trim(); } }

        /// <summary>
        /// TOTALES FACTURADOS
        /// </summary>
        public decimal FacturadoCantidad { get; set; } = 0;
        public decimal FacturadoHonorarios { get; set; } = 0;
        public decimal FacturadoGastos { get; set; } = 0;
        public decimal FacturadoMedicamentos { get; set; } = 0;
        public decimal FacturadoIvaPorcentaje { get; set; } = 0;

        public decimal FacturadoImporteNeto { get { return (FacturadoHonorarios + FacturadoGastos + FacturadoMedicamentos); } }
        public decimal FacturadoImporteIva { get { return Math.Round(FacturadoImporteNeto * (FacturadoIvaPorcentaje > 0 ? (FacturadoIvaPorcentaje / 100) : 0), 2); } }
        public decimal FacturadoImporteTotal { get { return FacturadoImporteNeto + FacturadoImporteIva; } }


        /// <summary>
        /// TOTALES DEBITADOS
        /// </summary>
        public decimal DebitadoCantidad { get; set; } = 0;
        public decimal DebitadoHonorarios { get; set; } = 0;
        public decimal DebitadoGastos { get; set; } = 0;
        public decimal DebitadoMedicamentos { get; set; } = 0;
        public decimal DebitadoIvaPorcentaje { get; set; } = 0;

        public decimal DebitadoImporteNeto { get { return DebitadoHonorarios + DebitadoGastos + DebitadoMedicamentos; } }
        public decimal DebitadoImporteIva { get { return Math.Round(DebitadoImporteNeto * (DebitadoIvaPorcentaje > 0 ? (DebitadoIvaPorcentaje / 100) : 0), 2); } }
        public decimal DebitadoImporteTotal { get { return DebitadoImporteNeto + DebitadoImporteIva; } }
                
        public string Observacion { get { return _observacion; } set { _observacion = value?.Trim(); } }
        public byte Estado { get; set; } = 0;
                
        public bool Seleccionado { get; set; } = false;
        public bool _BorrarRegistro { get; set; } = false;
        public int IDUsuNew { get; set; } = 0;
        public int IDUsuModif { get; set; } = 0;
        public DateTime TimeModif { get; set; } = DateTime.Now;
        public DateTime TimeNew { get; set; } = DateTime.Now;
       
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public DevolucionesDet() { }

        public DevolucionesDet(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

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
        public DevolucionesDet Clone()
        {
            DevolucionesDet r = (DevolucionesDet)MemberwiseClone();            
            return r;
        }

        //CLONE CON LISTAS
        public List<DevolucionesDet> Clone(List<DevolucionesDet> lst)
        {
            List<DevolucionesDet> lista = new List<DevolucionesDet>();

            foreach (DevolucionesDet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;
        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<DevolucionesDet> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<DevolucionesDet> lista = new List<DevolucionesDet>();

                string c = $"SELECT" + 
                           $" RD.IDRegistro," +
                           $" RD.IDEncabezado," +
                           $" RD.IDAsocTranImp," +
                           $" RD.IDAsocMedDos," +
                           $" RD.IDAsocSan," +
                           $" RD.ProfesionalCuentaID," +
                           $" PC.Codigo AS ProfesionalCuentaCodigo," +
                           $" PC.Descripcion AS ProfesionalCuentaNombre," +
                           $" RD.PrestatariaCuentaID," +
                           $" PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" PD.Descripcion AS PrestatariaCuentaNombre," +
                           $" RD.PacienteDocumento, RD.PacienteNombre," +
                           $" RD.PracticaCodigo," +
                           $" RD.PracticaNombre," +
                           $" RD.PracticaFuncion," +                            
                           $" RD.PracticaFecha," +
                           $" RD.AdmisionCodigo," +                           
                           $" RD.DebitoMotivo," +
                           $" RD.FacturadoCantidad, RD.FacturadoGastos, RD.FacturadoHonorarios, RD.FacturadoMedicamentos, RD.FacturadoIvaPorcentaje," +
                           $" RD.DebitadoCantidad, RD.DebitadoGastos, RD.DebitadoHonorarios, RD.DebitadoMedicamentos, RD.DebitadoIvaPorcentaje," +                           
                           $" RD.Estado, RD.PeriodoFacturado, RD.PeriodoDebitado, RD.PracticaLote" +
                           //AGREGAR EL FACTURADO PROF Y FACTURADO AMDGO COMO BOOL CON RELACION
                           $" FROM {tablaname} RD" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = RD.ProfesionalCuentaID)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = RD.PrestatariaCuentaID)";
                            

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DevolucionesDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<DevolucionesDet>();
            }
        }

        public List<DevolucionesDet> GetDebitos(int prestadorid, string periodo)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<DevolucionesDet> lista = new List<DevolucionesDet>();

                string c = $"SELECT" +
                           $" ISNULL(ATI.movpcoda, 0) AS IDAsocTranImp," +
                           $" ISNULL(PC.ID_Registro, 0) AS ProfesionalCuentaID," +
                           $" RTRIM(LTRIM(ISNULL(PC.Codigo, 0))) AS ProfesionalCuentaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(PC.Descripcion, 0))) AS ProfesionalCuentaNombre," +
                           $" ISNULL(PD.ID_Registro, 0) as PrestatariaCuentaID," +
                           $" RTRIM(LTRIM(ISNULL(PD.Codigo, 0))) as PrestatariaCuentaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpadmi, ''))) AS AdmisionCodigo," +
                           $" RTRIM(LTRIM(ISNULL(PD.Descripcion, 0))) as PrestatariaCuentaNombre," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpdocp, ''))) AS PacienteDocumento," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movppaci, ''))) AS PacienteNombre," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpprac, ''))) AS PracticaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpdesc, ''))) AS PracticaNombre," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpfunc, ''))) AS PracticaFuncion," +
                           $" ATR.movpfepr AS PracticaFecha," +
                           $" RTRIM(LTRIM(ISNULL(ATI.movpmotivo, ''))) AS DebitoMotivo," +
                           $" ISNULL(ATR.movpcant, 0) AS FacturadoCantidad," +
                           $" ISNULL(ATR.movphono, 0) AS FacturadoHonorarios," +
                           $" ISNULL(ATR.movpgast, 0) AS FacturadoGastos," +
                           $" ISNULL(ATR.movpmedi, 0) AS FacturadoMedicamentos," +
                           $" ISNULL(PD.PorcIva, 0) AS FacturadoIvaPorcentaje," +
                           $" IIF(ATR.movpfunc = '64', ATI.movpdebito, 0) AS DebitadoMedicamentos," +
                           $" IIF(ATR.movpfunc = '60' OR ATR.movpfunc = '91', ATI.movpdebito, 0) AS DebitadoGastos," +
                           $" IIF(ATR.movpfunc <> '60' AND ATR.movpfunc <> '91' AND ATR.movpfunc <> '64', ATI.movpdebito, 0) AS DebitadoHonorarios," +                           
                           $" RTRIM(LTRIM(ISNULL(ATR.movppefa, ''))) AS PeriodoFacturado," +
                           $" RTRIM(LTRIM(ISNULL(ATI.movpperpago, ''))) AS PeriodoDebitado" +
                           $" FROM AmdgoSis.dbo.ASOCTRANImp ATI" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCTRAN ATR ON(ATR.movpcoda = ATI.movpcoda)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = ATR.movpcopr)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = ATR.movpcdob)" +
                           $" WHERE PC.ID_Profesional = {prestadorid} AND ATI.movpperpago > '202112'";
                           //$" WHERE ATI.movpperpago LIKE '{periodo}%' AND PC.ID_Profesional = {prestadorid}";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DevolucionesDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<DevolucionesDet>();
            }
        }

        public List<DevolucionesDet> GetOrdenesAmbulatorias(int prestadorid, string periodo)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<DevolucionesDet> lista = new List<DevolucionesDet>();

                string c = $"SELECT" +
                           $" ISNULL(MD.MED2PUNT, 0) AS IDAsocMedDos," +
                           $" ISNULL(PC.ID_Registro, 0) AS ProfesionalCuentaID," +
                           $" RTRIM(LTRIM(ISNULL(PC.Codigo, 0))) AS ProfesionalCuentaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(PC.Descripcion, 0))) AS ProfesionalCuentaNombre," +
                           $" ISNULL(PD.ID_Registro, 0) as PrestatariaCuentaID," +
                           $" RTRIM(LTRIM(ISNULL(PD.Codigo, 0))) as PrestatariaCuentaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2NBUS, ''))) AS AdmisionCodigo," +
                           $" RTRIM(LTRIM(ISNULL(PD.Descripcion, 0))) as PrestatariaCuentaNombre," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2DOCU, ''))) AS PacienteDocumento," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2PACI, ''))) AS PacienteNombre," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2PRAC, ''))) AS PracticaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(MD.med2pnom, ''))) AS PracticaNombre," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2FUNC, ''))) AS PracticaFuncion," +
                           $" CONVERT(datetime, MD.MED2FEPR, 105) AS PracticaFecha," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2AUDI, ''))) AS DebitoMotivo," +
                           $" ISNULL(MD.MED2CANT, 0) AS FacturadoCantidad," +
                           $" ISNULL(MD.MED2HONO, 0) AS FacturadoHonorarios," +
                           $" ISNULL(MD.MED2GAST, 0) AS FacturadoGastos," +
                           $" ISNULL(MD.MED2MEDI, 0) AS FacturadoMedicamentos," +
                           $" ISNULL(PD.PorcIva, 0) AS FacturadoIvaPorcentaje," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2MESA, ''))) AS PeriodoFacturado," +
                           $" RTRIM(LTRIM(ISNULL(MD.MED2LOTE, ''))) AS PracticaLote" +
                           $" FROM AmdgoSis.dbo.ASOCMED2 MD" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = MD.MED2CPRO)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = MD.MED2COOB)" +
                           $" WHERE PC.ID_Profesional = {prestadorid} AND (MD.MED2MESA IS NULL OR MD.MED2MESA > '202112') AND (MD.MED2MESA LIKE '%1') ";
                           //$" WHERE MD.MED2FACT = '5' AND PC.ID_Profesional = {prestadorid} AND(MD.MED2MESA IS NULL OR MD.MED2MESA like '{periodo}%')";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DevolucionesDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<DevolucionesDet>();
            }
        }

        public List<DevolucionesDet> GetOrdenesInternacion(int prestadorid, string periodo)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<DevolucionesDet> lista = new List<DevolucionesDet>();

                string c = $"SELECT" +
                           $" CAST(ISNULL(SA.MOVOPUNT, 0) AS BIGINT) AS IDAsocSan," +
                           $" ISNULL(RTRIM(LTRIM(SA.MOVONINT)), '') AS AdmisionCodigo," + 
                           $" ISNULL(PC.ID_Registro, 0) AS ProfesionalCuentaID," +
                           $" RTRIM(LTRIM(ISNULL(PC.Codigo, 0))) AS ProfesionalCuentaCodigo," +
                           $" RTRIM(LTRIM(ISNULL(PC.Descripcion, 0))) AS ProfesionalCuentaNombre," +
                           $" ISNULL(PD.ID_Registro, 0) as PrestatariaCuentaID," +
                           $" RTRIM(LTRIM(ISNULL(PD.Codigo, 0))) as PrestatariaCuentaCodigo, " +
                           $" RTRIM(LTRIM(ISNULL(PD.Descripcion, 0))) as PrestatariaCuentaNombre," +
                           $" RTRIM(LTRIM(ISNULL(SA.MOVODOCU, ''))) AS PacienteDocumento," +
                           $" RTRIM(LTRIM(ISNULL(SA.MOVOPACI, ''))) AS PacienteNombre," +
                           $" RTRIM(LTRIM(ISNULL(SA.MOVODIAG, ''))) AS DebitoMotivo," +
                           $" RTRIM(LTRIM(ISNULL(SA.MOVOAMQU, ''))) AS PeriodoFacturado" +
                           $" FROM AmdgoSis.dbo.ASOCSAN1 SA" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = RTRIM(LTRIM(SA.MOVOCSAN)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = LTRIM(RTRIM(SA.MOVOCOOB)))" +
                           $" WHERE PC.ID_Profesional = {prestadorid} AND (SA.MOVOAMQU IS NULL OR SA.MOVOAMQU > '202112') AND (SA.MOVOAMQU LIKE '%3' OR SA.MOVOAMQU LIKE '%6')";
                           //$" WHERE PC.ID_Profesional = {prestadorid} AND(SA.MOVOAMQU IS NULL OR SA.MOVOAMQU like '{periodo}%')";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DevolucionesDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<DevolucionesDet>();
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

            campos.Add("IDEncabezado"); 
            campos.Add("IDAsocMedDos");
            campos.Add("IDAsocTranImp");
            campos.Add("IDAsocSan");
            campos.Add("ProfesionalCuentaID");
            campos.Add("PrestatariaCuentaID");
            campos.Add("PacienteDocumento");
            campos.Add("PacienteNombre");
            campos.Add("PracticaCodigo");
            campos.Add("PracticaNombre");
            campos.Add("PracticaFuncion");
            campos.Add("PracticaFecha");
            campos.Add("PracticaLote");
            campos.Add("AdmisionCodigo");            
            campos.Add("DebitoMotivo");
            campos.Add("FacturadoCantidad");
            campos.Add("FacturadoGastos");
            campos.Add("FacturadoHonorarios");
            campos.Add("FacturadoMedicamentos");
            campos.Add("FacturadoIvaPorcentaje");
            campos.Add("DebitadoCantidad");
            campos.Add("DebitadoGastos");
            campos.Add("DebitadoHonorarios");
            campos.Add("DebitadoMedicamentos");
            campos.Add("DebitadoIvaPorcentaje");            
            campos.Add("Observacion");
            campos.Add("Estado");            
            campos.Add("PeriodoDebitado");
            campos.Add("PeriodoFacturado");
            campos.Add("IDUsuNew");
            campos.Add("TimeNew");
            campos.Add("IDUsuModif");
            campos.Add("TimeModif");

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            if (_BorrarRegistro) { return retorno; }

            try
            {
                //CONEXION
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                IDUsuNew = glb.GetIdUsuariolog();
                IDUsuModif = glb.GetIdUsuariolog();

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

                //SI ESTA MARCADO PARA ELIMINACION
                if (_BorrarRegistro)
                {
                    var e = Eliminacion();
                    func.PreparaRetorno(retorno, e);

                    return retorno;
                }

                IDUsuModif = glb.GetIdUsuariolog();

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
                campos.Remove("IDUsuNew");
                campos.Remove("Guid");

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

        //ELIMINACION
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
                retorno.Add(-1, $"{GetType().Name} Eliminación.\n{e.Message}");
                return retorno;
            }

        }


        #endregion
    }
}
