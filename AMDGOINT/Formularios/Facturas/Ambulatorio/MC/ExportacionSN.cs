using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class ExportacionSN : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        #region PROPIEDADES

        public DateTime ComprobanteFecha { get; set; } = DateTime.MinValue;
        public byte FacturaManual { get; set; } = 0; // 0 = GENERALES DEL MES / 1 = EMITIDAS MANUALES
        public string ComprobanteTipo { get; set; } = "";
        public string ComprobanteLetra { get; set; } = "";
        public string ComprobanteTipoNumero {
            get
            {
                switch (ComprobanteTipo + ComprobanteLetra)
                {
                    case "FCA": return "001";
                    case "FCB": return "006";
                    case "FCC": return "011";
                    case "NCA": return "003";
                    case "NCB": return "008";
                    case "NCC": return "013";
                    case "NDA": return "002";
                    case "NDB": return "007";
                    case "NDC": return "012";
                    case "FCEA": return "201";
                    case "NCEA": return "203";
                    case "NDEA": return "202";
                    case "FCEB": return "206";
                    case "NCEB": return "208";
                    case "NDEB": return "207";
                    case "FCEC": return "211";
                    case "NCEC": return "213";
                    case "NDEC": return "212";
                    default: return "";
                }
            }
        }
        public int ComprobantePuntoVenta { get; set; } = 0;
        public long ComprobanteNumero { get; set; } = 0;
        public string PrestatariaCuentaCodigo { get; set; } = "";
        public string PrestadorCuentaCodigo { get; set; } = "";
        public decimal ImporteTotal { get; set; } = 0;
        public decimal HonorariosNeto21 { get; set; } = 0;        
        public decimal HonorariosNeto105 { get; set; } = 0;        
        public decimal HonorariosNeto0 { get; set; } = 0;
        public decimal HonorariosIva { get; set; } = 0;        
        public decimal HonorariosBruto { get { return HonorariosNeto0 + HonorariosNeto105 + HonorariosNeto21 + HonorariosIva; } }

        //IVA EXACTO DE FACTURA SEGUN CALCULO SISTEMA
        /*public decimal HonorariosIva21 { get { return Math.Round(HonorariosNeto21 * (decimal)0.21, 2); } }
        public decimal HonorariosIva105 { get { return Math.Round(HonorariosNeto105 * (decimal)0.105, 2); } }
        public decimal HonorariosIvaNuevo { get { return HonorariosIva105 + HonorariosIva21; } }
        public decimal HonorariosBrutoNuevo { get { return HonorariosNeto0 + HonorariosNeto105 + HonorariosNeto21 + HonorariosIvaNuevo; } }*/


        public decimal GastosNeto21 { get; set; } = 0;
        public decimal GastosNeto105 { get; set; } = 0;
        public decimal GastosNeto0 { get; set; } = 0;
        public decimal GastosIva { get; set; } = 0;
        public decimal GastosBruto { get { return GastosNeto0 + GastosNeto105 + GastosNeto21 + GastosIva; } }

        //IVA EXACTO DE FACTURA SEGUN CALCULO SISTEMA
        /*public decimal GastosIva21 { get { return Math.Round(GastosNeto21 * (decimal)0.21, 2); } }
        public decimal GastosIva105 { get { return Math.Round(GastosNeto105 * (decimal)0.105, 2); } }
        public decimal GastosIvaNuevo { get { return GastosIva21 + GastosIva105; } }
        public decimal GastosBrutoNuevo { get { return GastosNeto0 + GastosNeto105 + GastosNeto21 + GastosIvaNuevo; } }*/


        public decimal MedicamentosNeto21 { get; set; } = 0;
        public decimal MedicamentosNeto105 { get; set; } = 0;
        public decimal MedicamentosNeto0 { get; set; } = 0;
        public decimal MedicamentosIva { get; set; } = 0;
        public decimal MedicamentosBruto { get { return MedicamentosNeto0 + MedicamentosNeto105 + MedicamentosNeto21 + MedicamentosIva; } }

        //IVA EXACTO DE FACTURA SEGUN CALCULO SISTEMA
        /*public decimal MedicamentosIva21 { get { return Math.Round(MedicamentosNeto21 * (decimal)0.21, 2); } }
        public decimal MedicamentosIva105 { get { return Math.Round(MedicamentosNeto105 * (decimal)0.105, 2); } }
        public decimal MedicamentosIvaNuevo { get { return MedicamentosIva21 + MedicamentosIva105; } }
        public decimal MedicamentosBrutoNuevo { get { return MedicamentosNeto0 + MedicamentosNeto105 + MedicamentosNeto21 + MedicamentosIvaNuevo; } }*/
        
        public decimal EcografiasNeto21 { get; set; } = 0;
        public decimal EcografiasNeto105 { get; set; } = 0;
        public decimal EcografiasNeto0 { get; set; } = 0;
        public decimal EcografiasIva { get; set; } = 0;
        public decimal EcografiasBruto { get { return EcografiasNeto0 + EcografiasNeto105 + EcografiasNeto21 + EcografiasIva; } }


        /// <summary>
        /// PARA FACTURAS MANUALES
        /// </summary>
        /// 

        public decimal Neto21 { get; set; } = 0;
        public decimal Neto105 { get; set; } = 0;
        public decimal Neto0 { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        

        public SqlConnection SqlConnection = new SqlConnection();

        #endregion


        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ExportacionSN() { }

        public ExportacionSN(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public ExportacionSN Clone()
        {
            ExportacionSN d = (ExportacionSN)MemberwiseClone();           

            return d;
        }

        //CLONE CON LISTAS
        public List<ExportacionSN> Clone(List<ExportacionSN> lst)
        {
            List<ExportacionSN> lista = new List<ExportacionSN>();

            foreach (ExportacionSN d in lst)
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

        public List<ExportacionSN> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ExportacionSN> lista = new List<ExportacionSN>();
                string periodo = "202209";
                string c = $"SELECT" +
                           $" RTRIM(LTRIM(MED.MED2PCOB)) AS PrestadorCuentaCodigo," +
                           $" FA.Fecha AS ComprobanteFecha, FA.TipoComprobante AS ComprobanteTipo, FA.Letra AS ComprobanteLetra, FA.PuntoVenta AS ComprobantePuntoVenta, FA.Numero AS ComprobanteNumero, PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" SUM(CASE WHEN DE.IvaPorc = 21 THEN med.MED2HONO ELSE 0 END) as HonorariosNeto21, SUM(CASE WHEN DE.IvaPorc = 10.5 THEN med.MED2HONO ELSE 0 END) as HonorariosNeto105, SUM(CASE WHEN DE.IvaPorc = 0 THEN med.MED2HONO ELSE 0 END) as HonorariosNeto0, SUM(CASE WHEN med.MED2HONO > 0 THEN med.MED21IVA ELSE 0 END) AS HonorariosIva," +
                           $" SUM(CASE WHEN DE.IvaPorc = 21 THEN med.MED2GAST ELSE 0 END) as GastosNeto21, SUM(CASE WHEN DE.IvaPorc = 10.5 THEN med.MED2GAST ELSE 0 END) as GastosNeto105, SUM(CASE WHEN DE.IvaPorc = 0 THEN med.MED2GAST ELSE 0 END) as GastosNeto0,  SUM(CASE WHEN med.MED2GAST > 0 THEN med.MED21IVA ELSE 0 END) AS GastosIva," +
                           $" SUM(CASE WHEN DE.IvaPorc = 21 THEN med.MED2MEDI ELSE 0 END) as MedicamentosNeto21, SUM(CASE WHEN DE.IvaPorc = 10.5 THEN med.MED2MEDI ELSE 0 END) as MedicamentosNeto105, SUM(CASE WHEN DE.IvaPorc = 0 THEN med.MED2MEDI ELSE 0 END) as MedicamentosNeto0, SUM(CASE WHEN med.MED2MEDI > 0 THEN med.MED21IVA ELSE 0 END) AS MedicamentosIva," +
                           $" 0 as EcografiasNeto21, 0 as EcografiasNeto105, 0 as EcografiasNeto0, 0 AS EcografiasIva, FA.Total AS ImporteTotal" +
                           $" FROM AmdgoInterno.dbo.FACTAMBUENC FA" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = FA.ID_CuentaProf)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = FA.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTAMBUDET DE ON(DE.ID_Encabezado = FA.ID_Registro)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCMED2 MED ON(MED.MED2PUNT = de.Puntero)" +
                           $" WHERE FA.EstadoAf = 'A' AND PC.ID_Profesional = 722 AND FA.InternacionNumero = '' AND MED.MED2MESA = '{periodo+"1"}' AND MED.MED2PCOB <> '9106'" +
                           $" GROUP BY MED.MED2PCOB, FA.Fecha, FA.TipoComprobante, FA.Letra, FA.PuntoVenta, FA.Numero, PD.Codigo, FA.Total, de.IvaPorc" +
                           $" UNION" +
                           //INTERNACION
                           $" SELECT" +
                           $" MED.MOVOPFAC AS PrestadorCuentaCodigo, " +
                           $" FA.Fecha AS ComprobanteFecha, FA.TipoComprobante AS ComprobanteTipo, FA.Letra AS ComprobanteLetra, FA.PuntoVenta AS ComprobantePuntoVenta, FA.Numero AS ComprobanteNumero, PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" SUM(CASE WHEN PD.PorcIva = 21 THEN med.MOVOHONO ELSE 0 END) as HonorariosNeto21, SUM(CASE WHEN PD.PorcIva = 10.5 THEN med.MOVOHONO ELSE 0 END) as HonorariosNeto105, SUM(CASE WHEN PD.PorcIva = 0 THEN med.MOVOHONO ELSE 0 END) as HonorariosNeto0, SUM(CASE WHEN med.MOVOHONO > 0 THEN med.MOVOIIVA ELSE 0 END)  AS HonorariosIva," +
                           $" SUM(CASE WHEN PD.PorcIva = 21 THEN med.MOVOGAST ELSE 0 END) as GastosNeto21, SUM(CASE WHEN PD.PorcIva = 10.5 THEN med.MOVOGAST ELSE 0 END) as GastosNeto105, SUM(CASE WHEN PD.PorcIva = 0 THEN med.MOVOGAST ELSE 0 END) as GastosNeto0, SUM(CASE WHEN med.MOVOGAST > 0 THEN med.MOVOIIVA ELSE 0 END)  AS GastosIva," +
                           $" SUM(CASE WHEN PD.PorcIva = 21 THEN med.MOVOMEDI ELSE 0 END) as MedicamentosNeto21, SUM(CASE WHEN PD.PorcIva = 10.5 THEN med.MOVOMEDI ELSE 0 END) as MedicamentosNeto105, SUM(CASE WHEN PD.PorcIva = 0 THEN med.MOVOMEDI ELSE 0 END) as MedicamentosNeto0, SUM(CASE WHEN med.MOVOMEDI > 0 THEN med.MOVOIIVA ELSE 0 END)  AS MedicamentosIva," +
                           $" 0 as EcografiasNeto21, 0 as EcografiasNeto105, 0 as EcografiasNeto0, 0 AS EcografiasIva, FA.Total AS ImporteTotal" +
                           $" FROM AmdgoInterno.dbo.FACTAMBUENC FA" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = FA.ID_CuentaProf)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = FA.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCSAN2 MED ON(MED.MOVONINT = FA.InternacionNumero AND MED.MOVOPUNT = FA.InternacionPuntero AND MED.MOVOPFAC = PC.Codigo)" +
                           $" WHERE FA.EstadoAf = 'A' AND PC.ID_Profesional = 722 AND FA.InternacionNumero <> '' AND (MED.MOVOPERI = '{periodo + "3"}' OR MED.MOVOPERI = '{periodo + "6"}') AND MED.MOVOPFAC <> '9106'" +
                           $" GROUP BY MED.MOVOPFAC, FA.Fecha, FA.TipoComprobante, FA.Letra, FA.PuntoVenta, FA.Numero, PD.Codigo, FA.Total, PD.PorcIva" +
                           $" UNION" +
                           //ECOGRAFIAS AMBULATORIO
                           $" SELECT" +
                           $" MED.MED2PCOB AS PrestadorCuentaCodigo," +
                           $" FA.Fecha AS ComprobanteFecha, FA.TipoComprobante AS ComprobanteTipo, FA.Letra AS ComprobanteLetra, FA.PuntoVenta AS ComprobantePuntoVenta, FA.Numero AS ComprobanteNumero, PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" 0 as HonorariosNeto21, 0 as HonorariosNeto105, 0 as HonorariosNeto0, 0 AS HonorariosIva," +
                           $" 0 as GastosNeto21, 0 as GastosNeto105, 0 as GastosNeto0,  0 AS GastosIva," +
                           $" 0 MedicamentosNeto21, 0 as MedicamentosNeto105, 0 as MedicamentosNeto0, 0 AS MedicamentosIva," +
                           $" SUM(CASE WHEN DE.IvaPorc = 21 THEN med.MED2NETO ELSE 0 END) as EcografiasNeto21, SUM(CASE WHEN DE.IvaPorc = 10.5 THEN med.MED2NETO ELSE 0 END) as EcografiasNeto105, SUM(CASE WHEN DE.IvaPorc = 0 THEN med.MED2NETO ELSE 0 END) as EcografiasNeto0, SUM(med.MED21IVA) AS EcografiasIva," +
                           $" FA.Total AS ImporteTotal" +
                           $" FROM AmdgoInterno.dbo.FACTAMBUENC FA" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = FA.ID_CuentaProf)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = FA.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTAMBUDET DE ON(DE.ID_Encabezado = FA.ID_Registro)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCMED2 MED ON(MED.MED2PUNT = de.Puntero)" +
                           $" WHERE FA.EstadoAf = 'A' AND PC.ID_Profesional = 722 AND FA.InternacionNumero = '' AND MED.MED2MESA = '{periodo + "1"}' AND MED.MED2PCOB = '9106'" +
                           $" GROUP BY  MED.MED2PCOB, FA.Fecha, FA.TipoComprobante, FA.Letra, FA.PuntoVenta, FA.Numero, PD.Codigo, FA.Total, de.IvaPorc" +
                           $" UNION" +
                           //ECOGRAFIAS INTERNACION
                           $" SELECT" +
                           $" MED.MOVOPFAC AS PrestadorCuentaCodigo," +
                           $" FA.Fecha AS ComprobanteFecha, FA.TipoComprobante AS ComprobanteTipo, FA.Letra AS ComprobanteLetra, FA.PuntoVenta AS ComprobantePuntoVenta, FA.Numero AS ComprobanteNumero, PD.Codigo AS PrestatariaCuentaCodigo," +
                           $" 0 as HonorariosNeto21, 0 as HonorariosNeto105, 0 as HonorariosNeto0, 0  AS HonorariosIva," +
                           $" 0 as GastosNeto21, 0 as GastosNeto105, 0 as GastosNeto0, 0 AS GastosIva," +
                           $" 0 as MedicamentosNeto21, 0 as MedicamentosNeto105, 0 as MedicamentosNeto0, 0  AS MedicamentosIva," +
                           $" SUM(CASE WHEN PD.PorcIva = 21 THEN med.MOVONETO ELSE 0 END) as EcografiasNeto21, SUM(CASE WHEN PD.PorcIva = 10.5 THEN med.MOVONETO ELSE 0 END) as EcografiasNeto105, SUM(CASE WHEN PD.PorcIva = 0 THEN med.MOVONETO ELSE 0 END) as EcografiasNeto0, SUM(med.MOVOIIVA) AS EcografiasIva," +
                           $" FA.Total AS ImporteTotal" +
                           $" FROM AmdgoInterno.dbo.FACTAMBUENC FA" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = FA.ID_CuentaProf)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = FA.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCSAN2 MED ON(MED.MOVONINT = FA.InternacionNumero AND MED.MOVOPUNT = FA.InternacionPuntero AND MED.MOVOPFAC = PC.Codigo)" +
                           $" WHERE FA.EstadoAf = 'A' AND PC.ID_Profesional = 722 AND FA.InternacionNumero <> '' AND (MED.MOVOPERI = '{periodo + "3"}' OR MED.MOVOPERI = '{periodo + "6"}') AND MED.MOVOPFAC = '9106'" +
                           $" GROUP BY MED.MOVOPFAC, FA.Fecha, FA.TipoComprobante, FA.Letra, FA.PuntoVenta, FA.Numero, PD.Codigo, FA.Total, PD.PorcIva";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ExportacionSN>(rdr));
                }

                DateTime fechainicio = new DateTime(2022, 9, 1);
                DateTime fechafin = new DateTime(2022, 10, 4);

                c = $"SELECT" +
                    $" CAST(1 AS TINYINT) AS FacturaManual," +
                    $" PC.Codigo AS PrestadorCuentaCodigo," +
                    $" FA.Fecha AS ComprobanteFecha," +
                    $" FA.TipoComprobante AS ComprobanteTipo," +
                    $" FA.Letra AS ComprobanteLetra," +
                    $" FA.PuntoVenta AS ComprobantePuntoVenta," +
                    $" FA.Numero AS ComprobanteNumero," +
                    $" PD.Codigo AS PrestatariaCuentaCodigo," +
                    $" SUM(CASE WHEN DE.IvaPorc = 21 THEN DE.Neto ELSE 0 END) as Neto21," +
                    $" SUM(CASE WHEN DE.IvaPorc = 10.5 THEN DE.Neto ELSE 0 END) as Neto105," +
                    $" SUM(CASE WHEN DE.IvaPorc = 0 THEN DE.NoGravado ELSE 0 END) as Neto0," +
                    $" SUM(DE.Iva) AS Iva," +
                    $" SUM(DE.Total) AS ImporteTotal" +
                    $" FROM FACTAMBUENC FA" +
                    $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.ID_Registro = FA.ID_CuentaProf)" +
                    $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = FA.ID_PrestDetalle)" +
                    $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTAMBUDET DE ON(DE.ID_Encabezado = FA.ID_Registro)" +
                    $" WHERE PC.ID_Profesional = 722 AND FA.ID_UsuNew > 1 AND(FORMAT(FA.Fecha, 'yyyy-MM-dd') BETWEEN '{fechainicio.ToString("yyyy-MM-dd")}' AND '{fechafin.ToString("yyyy-MM-dd")}')" +
                    $" GROUP BY PC.Codigo, FA.Fecha, FA.TipoComprobante, FA.Letra, FA.PuntoVenta, FA.Numero, PD.Codigo";

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ExportacionSN>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ExportacionSN>();
            }
        }

        public void GeneraTxt()
        {
            try
            {
                List<ExportacionSN> lista = GetRegistros();

                //FACTURAS AUTOMATICAS
                TextWriter tw = new StreamWriter(@"C:\Users\Usuario\Desktop\FacturacionSanatorioNorte.txt");
                string linea = "";
                
                foreach (ExportacionSN s in lista.Where(w => w.FacturaManual == 0).OrderBy(o => o.ComprobanteNumero))
                {
                    linea = $"{s.PrestadorCuentaCodigo.Replace(" ", ""),-4}" +
                            $"{s.ComprobanteFecha.ToString("yyyyMMdd"),-8}" +
                            $"{s.ComprobanteTipoNumero,-3}" +
                            $"{s.ComprobanteLetra,-1}" +
                            $"{s.ComprobantePuntoVenta.ToString("0000"),-4}" +
                            $"{s.ComprobanteNumero.ToString("00000000"),-8}" +
                            $"{s.PrestatariaCuentaCodigo.PadLeft(6, '0'),-6}" +
                            //TOTAL FACTURA
                            $"{decimal.ToInt64(s.ImporteTotal).ToString("00000000"),8}{((s.ImporteTotal - decimal.ToInt64(s.ImporteTotal)) * 100).ToString("00"),2}" +
                            //HONORARIOS
                            $"{decimal.ToInt64(s.HonorariosBruto).ToString("00000000"),8}{((s.HonorariosBruto - decimal.ToInt64(s.HonorariosBruto)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.HonorariosNeto21).ToString("00000000"),8}{((s.HonorariosNeto21 - decimal.ToInt64(s.HonorariosNeto21)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.HonorariosNeto105).ToString("00000000"),8}{((s.HonorariosNeto105 - decimal.ToInt64(s.HonorariosNeto105)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.HonorariosNeto0).ToString("00000000"),8}{((s.HonorariosNeto0 - decimal.ToInt64(s.HonorariosNeto0)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.HonorariosIva).ToString("00000000"),8}{((s.HonorariosIva - decimal.ToInt64(s.HonorariosIva)) * 100).ToString("00"),2}" +
                            //GASTOS
                            $"{decimal.ToInt64(s.GastosBruto).ToString("00000000"),8}{((s.GastosBruto - decimal.ToInt64(s.GastosBruto)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.GastosNeto21).ToString("00000000"),8}{((s.GastosNeto21 - decimal.ToInt64(s.GastosNeto21)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.GastosNeto105).ToString("00000000"),8}{((s.GastosNeto105 - decimal.ToInt64(s.GastosNeto105)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.GastosNeto0).ToString("00000000"),8}{((s.GastosNeto0 - decimal.ToInt64(s.GastosNeto0)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.GastosIva).ToString("00000000"),8}{((s.GastosIva - decimal.ToInt64(s.GastosIva)) * 100).ToString("00"),2}" +
                            //MEDICAMENTOS
                            $"{decimal.ToInt64(s.MedicamentosBruto).ToString("00000000"),8}{((s.MedicamentosBruto - decimal.ToInt64(s.MedicamentosBruto)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.MedicamentosNeto21).ToString("00000000"),8}{((s.MedicamentosNeto21 - decimal.ToInt64(s.MedicamentosNeto21)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.MedicamentosNeto105).ToString("00000000"),8}{((s.MedicamentosNeto105 - decimal.ToInt64(s.MedicamentosNeto105)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.MedicamentosNeto0).ToString("00000000"),8}{((s.MedicamentosNeto0 - decimal.ToInt64(s.MedicamentosNeto0)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.MedicamentosIva).ToString("00000000"),8}{((s.MedicamentosIva - decimal.ToInt64(s.MedicamentosIva)) * 100).ToString("00"),2}" +
                            //ECOGRAFIAS
                            $"{decimal.ToInt64(s.EcografiasBruto).ToString("00000000"),8}{((s.EcografiasBruto - decimal.ToInt64(s.EcografiasBruto)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.EcografiasNeto21).ToString("00000000"),8}{((s.EcografiasNeto21 - decimal.ToInt64(s.EcografiasNeto21)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.EcografiasNeto105).ToString("00000000"),8}{((s.EcografiasNeto105 - decimal.ToInt64(s.EcografiasNeto105)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.EcografiasNeto0).ToString("00000000"),8}{((s.EcografiasNeto0 - decimal.ToInt64(s.EcografiasNeto0)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.EcografiasIva).ToString("00000000"),8}{((s.EcografiasIva - decimal.ToInt64(s.EcografiasIva)) * 100).ToString("00"),2}";
                    
                    tw.WriteLine(linea);

                    linea = "";
                }

                tw.Close();

                //FACTURAS MANUALES
                tw = new StreamWriter(@"C:\Users\Usuario\Desktop\FacturacionSanatorioNorteManuales.txt");
                linea = "";

                foreach (ExportacionSN s in lista.Where(w => w.FacturaManual == 1).OrderBy(o => o.ComprobanteNumero))
                {
                    linea = $"{s.PrestadorCuentaCodigo,-4}" +
                            $"{s.ComprobanteFecha.ToString("yyyyMMdd"),-8}" +
                            $"{s.ComprobanteTipoNumero,-3}" +
                            $"{s.ComprobanteLetra,-1}" +
                            $"{s.ComprobantePuntoVenta.ToString("0000"),-4}" +
                            $"{s.ComprobanteNumero.ToString("00000000"),-8}" +
                            $"{s.PrestatariaCuentaCodigo.PadLeft(6, '0'),-6}" +
                            //TOTAL FACTURA
                            $"{decimal.ToInt64(s.ImporteTotal).ToString("00000000"),8}{((s.ImporteTotal - decimal.ToInt64(s.ImporteTotal)) * 100).ToString("00"),2}" +
                            //NETOS
                            $"{decimal.ToInt64(s.Neto21).ToString("00000000"),8}{((s.Neto21 - decimal.ToInt64(s.Neto21)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.Neto105).ToString("00000000"),8}{((s.Neto105 - decimal.ToInt64(s.Neto105)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.Neto0).ToString("00000000"),8}{((s.Neto0 - decimal.ToInt64(s.Neto0)) * 100).ToString("00"),2}" +
                            $"{decimal.ToInt64(s.Iva).ToString("00000000"),8}{((s.Iva - decimal.ToInt64(s.Iva)) * 100).ToString("00"),2}";

                    tw.WriteLine(linea);

                    linea = "";
                }

                tw.Close();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el txt.\n{e.Message}", 1);
                return;
            }
        }

        #endregion
    }
}
