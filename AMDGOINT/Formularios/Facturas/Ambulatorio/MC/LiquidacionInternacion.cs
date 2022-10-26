using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class LiquidacionInternacion : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion


        #region PROPIEDADES

        public string Periodo { get; set; } = "";
        public string PeriodoIdentificacion { get { return Periodo.EndsWith("6") ? "Covid-19" : Periodo.EndsWith("4") ? "Fuera De Término" : Periodo.EndsWith("8") ? "Refacturación" : "Mensual"; } }
        public string EntidadCuentaCodigo { get; set; } = "";
        public string EntidadCuentaNombre { get; set; } = "";
        public string EntidadCompleta { get { return EntidadCuentaCodigo + " " + EntidadCuentaNombre; } }
        public string PacienteDocumento { get; set; } = "";
        public string PacienteNombre { get; set; } = "";
        public string PacienteCompleto { get { return PacienteDocumento + " " + PacienteNombre; } }
        public string InternacionNumero { get; set; } = "";
        public DateTime InternacionFecha { get; set; } = DateTime.MinValue;
        public DateTime InternacionFechaAlta { get; set; } = DateTime.MinValue;
        public string PrestadorSolicitanteCodigo { get; set; } = "";
        public string PrestadorSolicitanteNombre { get; set; } = "";
        public string PrestadorSolicitanteCompleto { get { return PrestadorSolicitanteCodigo + " " + PrestadorSolicitanteNombre; } }
        public string InternacionDiagnostico { get; set; } = "";
        public int InternacionDias { get { return (InternacionFechaAlta - InternacionFecha).Days; } }
        public int InternacionDiasEstadia { get { return InternacionDias == 0 ? 1 : InternacionDias; } }
        public string InternacionTipoAbreviatura { get; set; } = "";
        public string InternacionTipoDescripcion
        {
            get { return InternacionTipoAbreviatura == "Q" ? "Quirúrgica" : InternacionTipoAbreviatura == "C" ? "Clínica" : InternacionTipoAbreviatura == "O" ? "Obstétrica" : ""; }
        }
        public string InternacionAltaTipo { get; set; } = "";
        public string InternacionAltaDescripcion { get { return InternacionAltaTipo == "1" ? "Alta" : InternacionAltaTipo == "2" ? "Fallecimiento" : "Sin Definicion"; } }
        public string PracticaCodigo { get; set; } = "";
        public string PracticaDescripcion { get; set; } = "";
        public string PracticaCompleta { get { return PracticaCodigo + " " + PracticaDescripcion; } }
        public string PracticaFuncion { get; set; } = "";
        public string PrestadorCuentaCodigo { get; set; } = "";
        public string PrestadorCuentaNombre { get; set; } = "";
        public string PrestdorFacturadorCompleto { get { return PrestadorCuentaCodigo + " " + PrestadorCuentaNombre; } }
        public string Comprobante { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal ImporteHonorarios { get; set; } = 0;
        public decimal ImporteGastos { get; set; } = 0;
        public decimal ImporteMedicamentos { get; set; } = 0;
        public decimal ImporteNeto { get; set; } = 0;
        public decimal ImporteIva { get; set; } = 0;
        public decimal ImporteTotal { get; set; } = 0;

        public string PrestadoraCodigo { get; set; } = "";
        public string PrestadoraNombre { get; set; } = "";
        public string PrestadoraCompleta { get { return PrestadoraCodigo + " " + PrestadoraNombre; } }
        public long PrestadoraCuit { get; set; } = 0;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public LiquidacionInternacion() { }

        public LiquidacionInternacion(SqlConnection conexion)
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
        public LiquidacionInternacion Clone()
        {
            LiquidacionInternacion d = (LiquidacionInternacion)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<LiquidacionInternacion> Clone(List<LiquidacionInternacion> lst)
        {
            List<LiquidacionInternacion> lista = new List<LiquidacionInternacion>();

            foreach (LiquidacionInternacion d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<LiquidacionInternacion> GetRegistrosInternacionPrestataria(string prestcodigo, List<string> periodos)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<LiquidacionInternacion> lista = new List<LiquidacionInternacion>();

                //DEFINO EL PARAMETRO DE BUSQUEDA DE PERIODO (TIPO FACTURACION, ORIGEN DE PRACTICA Y FECHA)
                string orcondicionaltbl1 = "", orcondicionaltbl2 = "";
                //CONDICIONAL ASOCSAN1
                periodos.ForEach(f => orcondicionaltbl1 += orcondicionaltbl1.Length > 0 ? (f.EndsWith("8") ? $" OR SE.MOVOAMQU = '{f.Substring(0, 6)}3'" : $" OR SE.MOVOAMQU = '{f}'") 
                                                                                 : (f.EndsWith("8") ? $" SE.MOVOAMQU = '{f.Substring(0, 6)}3'" : $" SE.MOVOAMQU = '{f}'"));
                


                
                
                //CONDICIONAL ASOCSAN2
                periodos.ForEach(f => orcondicionaltbl2 += orcondicionaltbl2.Length > 0 ? " OR SD.MOVOPERI = '" + f + "'" : " SD.MOVOPERI = '" + f + "'");

                string c = $"SELECT" +
                           $" ISNULL(RTRIM(LTRIM(SD.MOVOPERI)),'') AS Periodo," +
                           $" ISNULL(RTRIM(LTRIM(SE.MOVOCOOB)),'') AS PrestadoraCodigo," +
                           $" PR.Nombre AS PrestadoraNombre," +
                           $" PR.Cuit AS PrestadoraCuit," +
                           //ENCABEZADO
                           $" RTRIM(LTRIM(SE.MOVOCSAN)) AS EntidadCuentaCodigo," +
                           $" RTRIM(LTRIM(EN.PROFAPNO)) AS EntidadCuentaNombre," +
                           $" RTRIM(LTRIM(SE.MOVODOCU)) AS PacienteDocumento," +
                           $" RTRIM(LTRIM(SE.MOVOPACI)) AS PacienteNombre," +
                           $" SE.MOVOFINT AS InternacionFecha," +
                           $" SE.MOVOFALT AS InternacionFechaAlta," +
                           $" RTRIM(LTRIM(SE.MOVOSOLI)) AS PrestadorSolicitanteCodigo," +
                           $" ISNULL(RTRIM(LTRIM(SO.PROFAPNO)), '') AS PrestadorSolicitanteNombre," +
                           $" RTRIM(LTRIM(SE.MOVODIAG)) AS InternacionDiagnostico," +
                           $" RTRIM(LTRIM(SE.MOVONINT)) AS InternacionNumero," +
                           $" ISNULL(SE.MOVOALTA, 0) AS InternacionAltaTipo," +
                           //$" SUM(ISNULL(SE.MOVODICL, 0) + ISNULL(SE.MOVODUTI, 0)) AS InternacionDias," +
                           $" ISNULL(SE.MOVOTIPO, '') AS InternacionTipoAbreviatura," +
                           //--DETALLE
                           $" SD.MOVOPRAC AS PracticaCodigo," +
                           $" SD.MOVODESC AS PracticaDescripcion," +
                           $" SD.MOVOFUNC AS PracticaFuncion," +
                           $" SD.MOVOPFAC AS PrestadorCuentaCodigo," +
                           $" AP.PROFAPNO AS PrestadorCuentaNombre, " +
                           $" ISNULL(SD.MOVOCOMP, '') AS Comprobante," +
                           $" SUM(ISNULL(SD.MOVOCPRA, 0)) AS Cantidad," +
                           $" SUM(ISNULL(SD.MOVOHONO, 0)) AS ImporteHonorarios," +
                           $" SUM(ISNULL(SD.MOVOGAST, 0)) AS ImporteGastos," +
                           $" SUM(ISNULL(SD.MOVOMEDI, 0)) AS ImporteMedicamentos," +
                           $" SUM(ISNULL(SD.MOVONETO, 0)) AS ImporteNeto," +
                           $" SUM(ISNULL(SD.MOVOIIVA, 0)) AS ImporteIva," +
                           $" SUM(ISNULL(SD.MOVOTOTA, 0)) AS ImporteTotal" +
                           $" FROM AmdgoSis.dbo.ASOCSAN1 SE" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCSAN2 SD ON(SD.MOVOPUNT = SE.MOVOPUNT AND SD.MOVONINT = SE.MOVONINT)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF AP ON(AP.PROFCODI = SD.MOVOPFAC)" +//--PROFESIONAL QUE COBRA
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF EN ON(EN.PROFCODI = SE.MOVOCSAN)" +//--ENTIDAD
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF SO ON(SO.PROFCODI = SE.MOVOSOLI)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = RTRIM(LTRIM(SE.MOVOCOOB)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +//PLAN PRESTATARIA
                           $" WHERE ({orcondicionaltbl1}) AND ({orcondicionaltbl2})" + (!string.IsNullOrEmpty(prestcodigo) ? $" AND SE.MOVOCOOB = '{prestcodigo}'" : "") +
                           $" AND SE.MOVOAUTO = '2' AND (SD.MOVOFACT = '3' OR SD.MOVOFACT = '8') AND SE.MOVOFACT = '3'" +                           
                           $" GROUP BY " +
                           $" SD.MOVOPERI, SE.MOVOCOOB, PR.Nombre, PR.Cuit," +
                           $" SE.MOVOCSAN, EN.PROFAPNO, SE.MOVODOCU, SE.MOVOPACI, SE.MOVOFINT, SE.MOVOFALT, SE.MOVOSOLI, SO.PROFAPNO, SE.MOVODIAG, SE.MOVONINT, SE.MOVOALTA, " +
                           $" SE.MOVODICL, SE.MOVOTIPO, SD.MOVOPRAC, SD.MOVODESC, SD.MOVOFUNC, SD.MOVOPFAC, AP.PROFAPNO, SD.MOVOCOMP";
                

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<LiquidacionInternacion>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<LiquidacionInternacion>();
            }
        }

        #endregion
    }
}
