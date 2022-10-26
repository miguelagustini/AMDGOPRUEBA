using AMDGOINT.Clases;
using DevExpress.Export.Xl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Reclamos.MC
{
    public class ReclamosDet : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoInterno].[dbo].[RECLAMOSDET]";
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
        private string _facturaamdgo = "";
        private string _facturaprofesional = "";
        private string _observacion = "";
        private string _facturaamdgonew = "";
        private string _facturaprofesionalnew = "";

        public long IDRegistro { get; set; } = 0;
        public long IDEncabezado { get; set; } = 0;
        public string ReclamoNumero { get { return IDEncabezado.ToString("000000"); } }
        public long IDAsocTran { get; set; } = 0;
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
        public DateTime PracticaFecha { get; set; } = DateTime.MinValue;

        public string AdmisionCodigo { get { return _admisioncodigo; } set { _admisioncodigo = value?.Trim(); } }  //NUMERO DE BUSQUEDA O INTERNACION        
        public string PrestatariaExpediente { get { return _prestatariaexpediente; } set { _prestatariaexpediente = value?.Trim(); } }
        public string PrestatariaLote { get { return _prestatarialote; } set { _prestatarialote = value?.Trim(); } }
        public string DebitoMotivo { get { return _debitomotivo; } set { _debitomotivo = value?.Trim(); } }

        public string PeriodoFacturado { get { return _periodofacturado; } set { _periodofacturado = value?.Trim(); } }
        public string PeriodoFacturadoTipo
        {
            get
            {
                try
                {
                    string c = PeriodoFacturado.Substring(PeriodoFacturado.Length - 1, 1);

                    return c.Equals("1") || c.Equals("7") || c.Equals("2") ? "AMBULATORIO" :
                           c.Equals("3") || c.Equals("8") || c.Equals("4") || c.Equals("6") ? "INTERNACIÓN" : "";
                }
                catch (Exception)
                {
                    return string.Empty;
                }
                
            }
        }
        public string PeriodoDebitado { get { return _periododebitado; } set { _periododebitado = value?.Trim(); } }
        public bool RegistroProcesado { get; set; } = false;

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
        public decimal DebitadoCantidad { get; set; } = 1;
        public decimal DebitadoHonorarios { get; set; } = 0;
        public decimal DebitadoGastos { get; set; } = 0;
        public decimal DebitadoMedicamentos { get; set; } = 0;
        public decimal DebitadoIvaPorcentaje { get; set; } = 0;

        public decimal DebitadoImporteNeto { get { return DebitadoHonorarios + DebitadoGastos + DebitadoMedicamentos; } }
        public decimal DebitadoImporteIva { get { return Math.Round(DebitadoImporteNeto * (DebitadoIvaPorcentaje > 0 ? (DebitadoIvaPorcentaje / 100) : 0), 2); } }
        public decimal DebitadoImporteTotal { get { return DebitadoImporteNeto + DebitadoImporteIva; } }

        /// <summary>
        /// TOTALES RECLAMADOS
        /// </summary>
        /// 
        public decimal ReclamadoCantidad { get; set; } = 1;
        public decimal ReclamadoHonorarios { get; set; } = 0;
        public decimal ReclamadoGastos { get; set; } = 0;
        public decimal ReclamadoMedicamentos { get; set; } = 0;
        public decimal ReclamadoIvaPorcentaje { get; set; } = 0;

        public decimal ReclamadoImporteNeto { get { return ReclamadoHonorarios + ReclamadoGastos + ReclamadoMedicamentos; } }
        public decimal ReclamadoImporteIva { get { return Math.Round(ReclamadoImporteNeto * (ReclamadoIvaPorcentaje > 0 ? (ReclamadoIvaPorcentaje / 100) : 0), 2); } }
        public decimal ReclamadoImporteTotal { get { return ReclamadoImporteNeto + ReclamadoImporteIva; } }

        /// <summary>
        /// TOTALES RECUPERADOS
        /// </summary>
        public decimal RecuperadoCantidad { get; set; } = 0;
        public decimal RecuperadoHonorarios { get; set; } = 0;
        public decimal RecuperadoGastos { get; set; } = 0;
        public decimal RecuperadoMedicamentos { get; set; } = 0;
        public decimal RecuperadoIvaPorcentaje { get; set; } = 0;

        public decimal RecuperadoImporteNeto { get { return RecuperadoHonorarios + RecuperadoGastos + RecuperadoMedicamentos; } }
        public decimal RecuperadoImporteIva { get { return Math.Round(RecuperadoImporteNeto * (RecuperadoIvaPorcentaje > 0 ? (RecuperadoIvaPorcentaje / 100) : 0), 2); } }
        public decimal RecuperadoImporteTotal { get { return RecuperadoImporteNeto + RecuperadoImporteIva; } }


        public string FacturaProfesional { get { return _facturaprofesional; } set { _facturaprofesional = value?.Trim(); } }
        public string FacturaAmdgo { get { return _facturaamdgo; } set { _facturaamdgo = value?.Trim(); } }
        public string Observacion { get { return _observacion; } set { _observacion = value?.Trim(); } }
        public byte Estado { get; set; } = 0;

        public bool Facturado { get; set; } = false;
        public bool RequiereFacturaProfesional { get; set; } = false;
        public bool RequiereFacturaAmdgo { get; set; } = true;

        public string FacturaProfesionalNew { get { return _facturaprofesionalnew; } set { _facturaprofesionalnew = value?.Trim(); } }
        public string FacturaAmdgoNew { get { return _facturaamdgonew; } set { _facturaamdgonew = value?.Trim(); } }


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
        public ReclamosDet() { }

        public ReclamosDet(SqlConnection conexion)
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
        public ReclamosDet Clone()
        {
            ReclamosDet r = (ReclamosDet)MemberwiseClone();            
            return r;
        }

        //CLONE CON LISTAS
        public List<ReclamosDet> Clone(List<ReclamosDet> lst)
        {
            List<ReclamosDet> lista = new List<ReclamosDet>();

            foreach (ReclamosDet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;
        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        //REGISTROS DE BD
        public List<ReclamosDet> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReclamosDet> lista = new List<ReclamosDet>();

                string c = $" SELECT" + 
                            $" RD.IDRegistro," +
                            $" RD.IDEncabezado," +
                            $" RD.IDAsocTran," +
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
                            $" RD.PrestatariaExpediente," +
                            $" RD.PrestatariaLote, " +
                            $" RD.DebitoMotivo," +
                            $" RD.FacturadoCantidad, RD.FacturadoGastos, RD.FacturadoHonorarios, RD.FacturadoMedicamentos, RD.FacturadoIvaPorcentaje," +
                            $" RD.DebitadoCantidad, RD.DebitadoGastos, RD.DebitadoHonorarios, RD.DebitadoMedicamentos, RD.DebitadoIvaPorcentaje," +
                            $" RD.ReclamadoCantidad, RD.ReclamadoGastos, RD.ReclamadoHonorarios, RD.ReclamadoMedicamentos, RD.ReclamadoIvaPorcentaje," +
                            $" RD.RecuperadoCantidad, RD.RecuperadoGastos, RD.RecuperadoHonorarios, RD.RecuperadoMedicamentos, RD.RecuperadoIvaPorcentaje," +
                            $" RD.FacturaProfesional, RD.FacturaAmdgo, RD.RequiereFacturaProfesional, RD.Observacion, RD.Estado, RD.RequiereFacturaAmdgo," +
                            $" RD.PeriodoFacturado, RD.PeriodoDebitado" +
                            //AGREGAR EL FACTURADO PROF Y FACTURADO AMDGO COMO BOOL CON RELACION
                            $" FROM {tablaname} RD" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = RD.ProfesionalCuentaID)" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = RD.PrestatariaCuentaID)";
                            

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReclamosDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReclamosDet>();
            }
        }

        //DEBITOS 
        public List<ReclamosDet> GetDebitos(int prestatariaid, string periodo)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReclamosDet> lista = new List<ReclamosDet>();

                string c = $"SELECT" +
                           $" ISNULL(ATR.movpcoda, 0) AS IDAsocTran," +
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
                           $" IIF(ATR.movpfunc = '64', ISNULL(ATI.movpdebito, 0), 0) AS DebitadoMedicamentos," +
                           $" IIF(ATR.movpfunc = '60' OR ATR.movpfunc = '91', ISNULL(ATI.movpdebito, 0), 0) AS DebitadoGastos," +
                           $" IIF(ATR.movpfunc <> '60' AND ATR.movpfunc <> '91' AND ATR.movpfunc <> '64', ISNULL(ATI.movpdebito, 0), 0) AS DebitadoHonorarios," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpcomAM, ''))) AS FacturaAmdgo," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movpcomp, ''))) AS FacturaProfesional," +
                           $" RTRIM(LTRIM(ISNULL(ATR.movppefa, ''))) AS PeriodoFacturado," +
                           $" RTRIM(LTRIM(ISNULL(ATI.movpperpago, ''))) AS PeriodoDebitado," +
                           $" CAST(IIF(ATR.movpcoda IN (SELECT RD.IDAsocTran FROM AmdgoInterno.dbo.RECLAMOSDET RD), 1, 0) AS BIT) AS RegistroProcesado" +
                           $" FROM AmdgoSis.dbo.ASOCTRAN ATR" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCTRANImp ATI ON(ATI.movpcoda = ATR.movpcoda)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = ATR.movpcopr)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = ATR.movpcdob)" +                           
                           $" WHERE ATR.movppefa LIKE '{periodo}%' AND PD.ID_Prestataria = {prestatariaid}";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReclamosDet>(rdr));
                }

                cnb.Desconectar();

                //POR DEFECTO ASIGNO EL IMPORTE DEBITADO AL RECLAMADO
                foreach (ReclamosDet f in lista)
                {
                    f.ReclamadoCantidad = f.DebitadoCantidad;
                    f.ReclamadoGastos = f.DebitadoGastos;
                    f.ReclamadoHonorarios = f.DebitadoHonorarios;                    
                    f.ReclamadoMedicamentos = f.DebitadoMedicamentos;
                    f.ReclamadoIvaPorcentaje = f.DebitadoIvaPorcentaje;
                }


                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReclamosDet>();
            }
        }

        //PENDIENTES DE FACTURAR PROFESIONAL
        public List<ReclamosDet> GetRegistrosFacturaProfesional(int prestatariaid, int prestadorid)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReclamosDet> lista = new List<ReclamosDet>();

                string c = $" SELECT" +                            
                            $" RD.IDRegistro," +
                            $" RD.IDEncabezado," +
                            $" RD.IDAsocTran," +
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
                            $" RD.PrestatariaExpediente," +
                            $" RD.PrestatariaLote, " +
                            $" RD.DebitoMotivo," +
                            $" RD.FacturadoCantidad, RD.FacturadoGastos, RD.FacturadoHonorarios, RD.FacturadoMedicamentos, RD.FacturadoIvaPorcentaje," +
                            $" RD.DebitadoCantidad, RD.DebitadoGastos, RD.DebitadoHonorarios, RD.DebitadoMedicamentos, RD.DebitadoIvaPorcentaje," +
                            $" RD.ReclamadoCantidad, RD.ReclamadoGastos, RD.ReclamadoHonorarios, RD.ReclamadoMedicamentos, RD.ReclamadoIvaPorcentaje," +
                            $" RD.RecuperadoCantidad, RD.RecuperadoGastos, RD.RecuperadoHonorarios, RD.RecuperadoMedicamentos, RD.RecuperadoIvaPorcentaje," +
                            $" RD.FacturaProfesional, RD.FacturaAmdgo, RD.RequiereFacturaProfesional, RD.Observacion, RD.Estado, RD.RequiereFacturaAmdgo," +
                            $" RD.PeriodoFacturado, RD.PeriodoDebitado" +
                            $" FROM [AmdgoInterno].[dbo].[RECLAMOSENC] RE" +
                            $" LEFT OUTER JOIN {tablaname} RD ON(RD.IDEncabezado = RE.IDRegistro)" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = RD.ProfesionalCuentaID)" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = RD.PrestatariaCuentaID)" +
                            $" WHERE RD.ProfesionalCuentaID = {prestadorid} AND RD.PrestatariaCuentaID = {prestatariaid}" +
                            $" AND RE.Estado = 1 AND RD.RequiereFacturaProfesional = 1 AND (RD.RecuperadoGastos + RD.RecuperadoHonorarios + RD.RecuperadoMedicamentos) > 0" +                            
                            $" AND RD.IDRegistro NOT IN(SELECT FD.IDReclamoDetalle FROM AmdgoInterno.dbo.FACTAMBUDET FD WHERE FD.IDReclamoDetalle > 0)" +
                            $" AND (RD.RecuperadoGastos + RD.RecuperadoHonorarios + RD.RecuperadoMedicamentos) > 0";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReclamosDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReclamosDet>();
            }
        }

        //PENDIENTES DE FACTURAR PRESTADORA
        public List<ReclamosDet> GetRegistrosFacturaPrestadora(int prestatariaid)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReclamosDet> lista = new List<ReclamosDet>();

                string c = $"SELECT" +
                            $" RD.IDRegistro," +
                            $" RD.IDEncabezado," +
                            $" RD.IDAsocTran," +
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
                            $" RD.PrestatariaExpediente," +
                            $" RD.PrestatariaLote, " +
                            $" RD.DebitoMotivo," +
                            $" RD.PeriodoFacturado," +
                            $" RD.FacturadoCantidad, RD.FacturadoGastos, RD.FacturadoHonorarios, RD.FacturadoMedicamentos, RD.FacturadoIvaPorcentaje," +
                            $" RD.DebitadoCantidad, RD.DebitadoGastos, RD.DebitadoHonorarios, RD.DebitadoMedicamentos, RD.DebitadoIvaPorcentaje," +
                            $" RD.ReclamadoCantidad, RD.ReclamadoGastos, RD.ReclamadoHonorarios, RD.ReclamadoMedicamentos, RD.ReclamadoIvaPorcentaje," +
                            $" RD.RecuperadoCantidad, RD.RecuperadoGastos, RD.RecuperadoHonorarios, RD.RecuperadoMedicamentos, RD.RecuperadoIvaPorcentaje," +
                            $" RD.FacturaProfesional, RD.FacturaAmdgo, RD.RequiereFacturaProfesional, RD.Observacion, RD.Estado, RD.RequiereFacturaAmdgo," +
                            $" LTRIM(RTRIM(CONCAT(FE.TipoComprobante, ' ', FE.Letra,  IIF(FE.PuntoVenta > 0,RIGHT(CONCAT('0000', FE.PuntoVenta),4), ''), IIF(FE.Numero > 0, RIGHT(CONCAT('00000000', FE.Numero),8), '') ))) AS FacturaProfesionalNew" +
                            $" FROM [AmdgoInterno].[dbo].[RECLAMOSENC] RE" +
                            $" LEFT OUTER JOIN {tablaname} RD ON(RD.IDEncabezado = RE.IDRegistro)" +
                            $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[FACTAMBUDET] FD ON(FD.IDReclamoDetalle = RD.IDRegistro)" +
                            $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[FACTAMBUENC] FE ON(FE.ID_Registro = FD.ID_Encabezado)" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = RD.ProfesionalCuentaID)" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = RD.PrestatariaCuentaID)" +
                            $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTPRESDET PRD ON(RD.IDRegistro = PRD.IDReclamoDetalle)" +
                            $" WHERE RD.PrestatariaCuentaID = {prestatariaid}" +
                            $" AND RE.Estado = 1 AND RD.RequiereFacturaAmdgo = 1 AND (RD.RecuperadoGastos + RD.RecuperadoHonorarios + RD.RecuperadoMedicamentos) > 0" +
                            $" AND PRD.ID_Registro IS NULL";
                            //$" AND RD.IDRegistro NOT IN(SELECT FD.IDReclamoDetalle FROM AmdgoInterno.dbo.FACTPRESDET FD WHERE FD.IDReclamoDetalle > 0)";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReclamosDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReclamosDet>();
            }
        }

        #endregion

        #region GENERA XLS CREDITOS

        public void GeneraExcelCreditos(List<ReclamosDet> listaexport, string archivonombre)
        {
            try
            {
                string _pathexprt = "";

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        _pathexprt = fbd.SelectedPath;
                    }
                    else { return; }
                }

                // Create an exporter instance. 
                IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xls);

                // Create the FileStream object with the specified file path. 
                using (FileStream stream = new FileStream(_pathexprt+$@"\{archivonombre} Creditos.xls", FileMode.Create, FileAccess.ReadWrite))
                {
                    // Create a new document and begin to write it to the specified stream. 
                    using (IXlDocument document = exporter.CreateDocument(stream))
                    {
                        // Add a new worksheet to the document. 
                        using (IXlSheet sheet = document.CreateSheet())
                        {
                            // Specify the worksheet name.
                            sheet.Name = "hoja1";

                            //CREO LAS COLUMNAS
                            for (short i = 0; i < 10; i++)
                            {                                
                                using (IXlColumn column = sheet.CreateColumn())
                                {
                                    column.WidthInPixels = 100;

                                    if (i >= 4 && i <= 6)
                                    {
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""-""??_);_(@_)";                                        
                                    }
                                }
                            }

                            //CREO LA FILA ENCABEZADO                            
                            using (IXlRow row = sheet.CreateRow())
                            {
                                for (short i = 0; i < 10; i++)
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        switch (i)
                                        {
                                            case 0: cell.Value = "ID"; break;
                                            case 1: cell.Value = "Codigo"; break;
                                            case 2: cell.Value = "prestataria"; break;
                                            case 3: cell.Value = "autorizacion"; break;
                                            case 4: cell.Value = "Total"; break;
                                            case 5: cell.Value = "debito"; break;
                                            case 6: cell.Value = "creditos"; break;
                                            case 7: cell.Value = "Motivo"; break;
                                            case 8: cell.Value = "comprobante"; break;
                                            case 9: cell.Value = "periodo"; break;
                                        }
                                    }
                                    
                                }
                            }

                            //RECORRO LOS DATOS
                            foreach (ReclamosDet r in listaexport)
                            {
                                //CREO FILLA
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    //POR CADA COLUMNA DE DATOS
                                    for (short i = 0; i < 10; i++)
                                    {
                                        //CREO COLUMNA EN EXCEL
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            switch (i)
                                            {
                                                case 0: cell.Value = r.IDAsocTran; break;
                                                case 1: cell.Value = r.ProfesionalCuentaCodigo; break;
                                                case 2: cell.Value = r.PrestatariaCuentaCodigo; break;
                                                case 3: cell.Value = r.AdmisionCodigo; break;
                                                case 4: cell.Value = XlVariantValue.FromObject((decimal)0); break;
                                                case 5: cell.Value = XlVariantValue.FromObject((decimal)0); break;
                                                case 6: cell.Value = XlVariantValue.FromObject(r.RecuperadoImporteTotal); break;
                                                case 7: cell.Value = "DEBITO RECUPERADO"; break;
                                                case 8: cell.Value = string.Empty; break;
                                                case 9: cell.Value = r.PeriodoFacturado; break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Open the XLSX document using the default application.
                    //System.Diagnostics.Process.Start("Document.xlsx");
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el archivo.\n{e.Message}", 1);
                return;
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
            campos.Add("IDAsocTran");
            campos.Add("ProfesionalCuentaID");
            campos.Add("PrestatariaCuentaID");
            campos.Add("PacienteDocumento");
            campos.Add("PacienteNombre");
            campos.Add("PracticaCodigo");
            campos.Add("PracticaNombre");
            campos.Add("PracticaFuncion");
            campos.Add("PracticaFecha");
            campos.Add("AdmisionCodigo");
            campos.Add("PrestatariaExpediente");
            campos.Add("PrestatariaLote");
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
            campos.Add("ReclamadoCantidad");
            campos.Add("ReclamadoGastos");
            campos.Add("ReclamadoHonorarios");
            campos.Add("ReclamadoMedicamentos");
            campos.Add("ReclamadoIvaPorcentaje");
            campos.Add("RecuperadoCantidad");
            campos.Add("RecuperadoGastos");
            campos.Add("RecuperadoHonorarios");
            campos.Add("RecuperadoMedicamentos");
            campos.Add("RecuperadoIvaPorcentaje");            
            campos.Add("FacturaProfesional");
            campos.Add("FacturaAmdgo");
            campos.Add("Observacion");
            campos.Add("Estado");
            campos.Add("RequiereFacturaProfesional");
            campos.Add("RequiereFacturaAmdgo");
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
