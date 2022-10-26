using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Recibos.MC
{
    public class ReciboDet : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoInterno].[dbo].[RECIBOSDET]";
        
        public long IDRegistro { get; set; } = 0;        
        public long IDEncabezado { get; set; } = 0;
        public long ComprobanteAmdgoID { get; set; } = 0;        
        public string ComprobanteAmdgoNumero { get; set; } = "";
        public DateTime ComprobanteFechaEmision { get; set; } = DateTime.MinValue;
        public string ComprobanteConcepto { get; set; } = "";
        public string ComprobantePeriodo { get; set; } = "";
        public int PrestatariaCuentaID { get; set; } = 0;
        public int PrestatariaID { get; set; } = 0;
        public string PrestatariaCuentaCodigo { get; set; } = "";
        public byte ModoPago { get; set; } = 1;
        public string ModoPagoDescripcion { get { return ModoPago == 0 ? "Efectivo" : ModoPago == 1 ? "Transferencia" : ModoPago == 2 ? "Cheque" : ""; } }
        public short BancoID { get; set; } = 0;
        public string BancoNombre { get; set; } = "";
        public string BancoCodigo { get; set; } = "";
        public string BancoCompleto { get { return BancoCodigo + " " + BancoNombre; } }
        public int PlanCuentaID { get; set; } = 0;
        public string PlanCuentaCodigoCorto { get; set; } = "";
        public string PlanCuentaNombre { get; set; } = "";
        public string PlanCuentaCompleto { get { return PlanCuentaCodigoCorto + " " + PlanCuentaNombre; } }
        public int PlanSubCuentaID { get; set; } = 0;
        /// <summary>
        /// Usado para obtener el numero de subcuenta por defecto del plan de la prestadora al importar facturas
        /// </summary>
        public int IDSubCuentaContablePlan { get; set; } = 0;
        public string PlanSubCuentaCodigoCorto { get; set; } = "";
        public string PlanSubCuentaNombre { get; set; } = "";
        public string PlanSubCuentaCompleto { get { return PlanSubCuentaCodigoCorto + " " + PlanSubCuentaNombre; } }
        public string Descripcion { get; set; } = "";
        public byte ComprobanteOrigen { get; set; } = 0;
        public string ComprobanteTipoDescripcion
        {
            get
            {
                string c = "";

                switch (ComprobanteOrigen)
                {
                    case 1:c = "Facturación Ambulatorio"; break;
                    case 2:c = "Fuera de término Ambulatorio"; break;
                    case 3:c = "Facturación Internación"; break;
                    case 4:c = "Fuera de término internación"; break;
                    case 5:c = ""; break;
                    case 6:c = "Facturación Covid-19"; break;
                    case 7:c = "Refacturación Ambulatorio"; break;
                    case 8:c = "Refacturación Internación"; break;
                    default: c = ""; break;
                }

                return c;
            }            
        }
        public decimal ComprobanteAmdgoImporte { get; set; } = 0;
        public decimal ImporteSaldado { get; set; } = 0;
        public decimal ImporteCancelado { get; set; } = 0;
        public List<Caja.MC.CajaMovimientos> MovimientosCaja { get; set; } = new List<Caja.MC.CajaMovimientos>();
        public bool Seleccionado { get; set; } = false;
        public bool _BorrarRegistro { get; set; } = false;

        public string DetallePrint
        {
            get { return ComprobanteAmdgoID > 0 ? $"{ComprobanteAmdgoNumero}   {ComprobantePeriodo}   {PrestatariaCuentaCodigo}" + (Descripcion.Length > 0 ? $" - {Descripcion}" : "") : Descripcion; }
        }

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
        public ReciboDet() { }

        public ReciboDet(SqlConnection conexion)
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
        public ReciboDet Clone()
        {
            ReciboDet d = (ReciboDet)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<ReciboDet> Clone(List<ReciboDet> lst)
        {
            List<ReciboDet> lista = new List<ReciboDet>();

            foreach (ReciboDet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ReciboDet> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReciboDet> lista = new List<ReciboDet>();

                string c = $"SELECT RD.IDRegistro, RD.IDEncabezado, RD.ComprobanteAmdgoID, RD.ComprobanteAmdgoNumero, RD.ComprobanteAmdgoImporte, RD.ComprobanteOrigen, RD.ImporteCancelado," +
                           $" RD.Descripcion, FE.Fecha AS ComprobanteFechaEmision, FE.Periodo AS ComprobantePeriodo, CO.Concepto AS ComprobanteConcepto, RD.PlanCuentaID, RD.PlanSubCuentaID," +
                           $" PLC.CodigoCorto AS PlanCuentaCodigoCorto, PLC.Descripcion AS PlanCuentaNombre, PSC.Codigo AS PlanSubCuentaCodigoCorto, PSC.Descripcion AS PlanSubCuentaNombre," +
                           $" ISNULL(PD.ID_Registro, 0) AS PrestatariaCuentaID, ISNULL(PD.Codigo, '') AS PrestatariaCuentaCodigo, RD.ModoPago," +
                           $" RD.BancoID, BA.Descripcion as BancoNombre, BA.Codigo as BancoCodigo, PD.ID_Prestataria AS PrestatariaID" +
                           $" FROM {tablaname} RD" +
                           $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[FACTPRESENC] FE ON(FE.ID_Registro = RD.ComprobanteAmdgoID)" +
                           $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[PRESTDETALLES] PD ON(PD.ID_Registro = FE.ID_PrestDetalle)" + 
                           $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[CONCEPTOSCOMPROBANTES] CO ON(CO.IDRegistro = FE.IDConcepto)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANCUENTAS] PLC ON(PLC.IDRegistro = RD.PlanCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANSUBCUENTAS] PSC ON(PSC.IDRegistro = RD.PlanSubCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[BANCOS] BA ON(BA.IDRegistro = RD.BancoID)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReciboDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReciboDet>();
            }
        }

        public List<ReciboDet> GetFacturasPendientes(int prestatariaid)
        {
            try
            {
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReciboDet> lista = new List<ReciboDet>();
                string peri = prestatariaid == 18 || prestatariaid == 28 || prestatariaid == 31 ? "2020-12" : "2021-05";
                string c = $"SELECT TT.ComprobanteAmdgoID, TT.ComprobanteFechaEmision, TT.PrestatariaCuentaID, TT.PrestatariaCuentaCodigo, CONCAT(TT.TipoComprobante, ' ', TT.Letra, '',  RIGHT(CONCAT('0000', TT.PuntoVenta),4),'-', RIGHT(CONCAT('00000000', TT.Numero),8)) AS ComprobanteAmdgoNumero," +
                           $" TT.ComprobantePeriodo, TT.ComprobanteOrigen, TT.ComprobanteAmdgoImporte, ISNULL(SUM(RD.ImporteCancelado), 0) AS ImporteSaldado, ISNULL(TT.ComprobanteConcepto, '') AS ComprobanteConcepto," +
                           $" TT.IDSubCuentaContablePlan" +
                           $" FROM" +
                           $" (SELECT FE.ID_Registro AS ComprobanteAmdgoID, FE.Fecha AS ComprobanteFechaEmision, PD.ID_Registro AS PrestatariaCuentaID, PD.Codigo AS PrestatariaCuentaCodigo, FE.TipoComprobante, " +
                           $" FE.Letra, FE.PuntoVenta, FE.Numero, FD.Periodo AS ComprobantePeriodo, CAST(FD.Origen AS tinyint) as ComprobanteOrigen, CO.Concepto AS ComprobanteConcepto," +
                           $" SUM(FD.Total) AS ComprobanteAmdgoImporte, PD.IDPlanSubCuenta AS IDSubCuentaContablePlan" +                           
                           $" FROM FACTPRESDET FD" +
                           $" LEFT OUTER JOIN FACTPRESENC FE ON(FE.ID_Registro = FD.ID_Encabezado)" +
                           $" LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = FE.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN CONCEPTOSCOMPROBANTES CO ON(CO.IDRegistro = FE.IDConcepto)" +
                           $" WHERE(FE.TipoComprobante = 'FC' OR FE.TipoComprobante = 'FCE' OR FE.TipoComprobante = 'ND' OR FE.TipoComprobante = 'NDE') AND FE.Pagada = 0" +
                           $" AND FORMAT(FE.Fecha, 'yyyy-MM') > '{peri}' AND PD.ID_Prestataria = {prestatariaid}" +
                           $" GROUP BY FE.ID_Registro, FE.Fecha,PD.ID_Registro, PD.Codigo, FE.TipoComprobante, FE.Letra, FE.PuntoVenta, FE.Numero, FD.Periodo, FD.Origen, CO.Concepto, PD.IDPlanSubCuenta) AS TT" +
                           $" LEFT OUTER JOIN RECIBOSDET RD ON(RD.ComprobanteAmdgoID = TT.ComprobanteAmdgoID AND RD.ComprobanteOrigen = TT.ComprobanteOrigen)" +
                           $" LEFT OUTER JOIN RECIBOSENC RE ON(RE.IDRegistro = RD.IDEncabezado)" +
                           $" GROUP BY TT.ComprobanteAmdgoID, TT.ComprobanteFechaEmision, TT.PrestatariaCuentaID, TT.PrestatariaCuentaCodigo, TT.TipoComprobante, TT.Letra, TT.PuntoVenta, TT.Numero," +
                           $" TT.ComprobantePeriodo, TT.ComprobanteOrigen, TT.ComprobanteAmdgoImporte, TT.ComprobanteConcepto, TT.IDSubCuentaContablePlan, RE.Estado" +
                           $" HAVING IIF(RE.Estado = 1, IIF(ISNULL(SUM(RD.ImporteCancelado),0) < TT.ComprobanteAmdgoImporte, 1, 0), 1) = 1";


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReciboDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al obtener los comprobantes pendientes.\n{e.Message}", 1);
                return new List<ReciboDet>();
            }
        }

        //CREACION DE ASIENTOS CONTABLES
        public void GeneraAsientos(byte area)
        {
            try
            {
                //AREA 1 SIN GENERACION DE ASIENTOS BANCO / EFECTIVO

                //PLANES CONTABLES
                //CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                //List<CuentasContables.MC.Cuentas> lst = ctas.GetRegistros().Where(w => w.Estado && w.Seleccionable).ToList();
                //byte _cuentaorigen = lst.Where(w => w.IDRegistro == PlanCuentaID).Select(s => s.CuentaOrigen).First();

                MovimientosCaja.Clear();

                if (_BorrarRegistro) { return; }

                //MOVIMIENTO ESTANDAR (CUENTA SELECCIONADA)
                MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                {
                    FechaMovimiento = DateTime.Now,
                    ModoPago = ModoPago,
                    BancoID = BancoID,
                    PlanCuentaID = PlanCuentaID,
                    PlanSubCuentaID = PlanSubCuentaID,
                    Descripcion = Descripcion,
                    //ImporteDebe = _cuentaorigen < 2 && ImporteCancelado > 0 ? ImporteCancelado : 0,
                    //ImporteHaber = _cuentaorigen > 1 || ImporteCancelado < 0 ? ImporteCancelado : 0
                    ImporteHaber = ImporteCancelado

                });

                if (ImporteCancelado <= 0) { return; }

                //SI ES AREA 1
                if (area == 1)
                {
                    if (PlanCuentaID == 46)
                    {
                        MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                        {
                            FechaMovimiento = DateTime.Now,
                            ModoPago = ModoPago,
                            BancoID = BancoID,
                            PlanCuentaID = 15,
                            PlanSubCuentaID = 0,
                            Descripcion = Descripcion,
                            //ImporteDebe = _cuentaorigen >= 2  ? ImporteCancelado : 0,
                            //ImporteHaber = _cuentaorigen < 2 ? ImporteCancelado : 0
                            ImporteDebe = ImporteCancelado
                        });
                    }
                }
                else
                {
                    //MOVIMIENTO AUTOMATICO (CUENTA DE SALIDA) BANCO, CAJA, ETC.
                    if (ModoPago == 0) //EFECTIVO
                    {
                        MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                        {
                            FechaMovimiento = DateTime.Now,
                            ModoPago = ModoPago,
                            BancoID = BancoID,
                            PlanCuentaID = 3,
                            PlanSubCuentaID = 0,
                            Descripcion = Descripcion,
                            //ImporteDebe = _cuentaorigen >= 2  ? ImporteCancelado : 0,
                            //ImporteHaber = _cuentaorigen < 2 ? ImporteCancelado : 0
                            ImporteDebe = ImporteCancelado
                        });
                    }
                    else if (ModoPago == 1 || ModoPago == 2) //TRANSFERENCIAS / CHEQUES
                    {
                        MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                        {
                            FechaMovimiento = DateTime.Now,
                            ModoPago = ModoPago,
                            BancoID = BancoID,
                            PlanCuentaID = BancoID == 1 ? 8 : BancoID == 2 ? 6 : BancoID == 102 ? 7 : 0,
                            PlanSubCuentaID = 0,
                            Descripcion = Descripcion,
                            //ImporteDebe = _cuentaorigen >= 2 ? ImporteCancelado : 0,
                            //ImporteHaber = _cuentaorigen < 2 ? ImporteCancelado : 0
                            ImporteDebe = ImporteCancelado
                        });
                    }
                }
                

                return;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento contable.\n{e.Message}", 1);
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
            campos.Add("ComprobanteAmdgoID");
            campos.Add("ComprobanteAmdgoNumero");
            campos.Add("ComprobanteAmdgoImporte");
            campos.Add("ComprobanteOrigen");
            campos.Add("Descripcion");
            campos.Add("ImporteCancelado");
            campos.Add("PlanCuentaID");
            campos.Add("PlanSubCuentaID");
            campos.Add("ModoPago");
            campos.Add("BancoID");
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

            //ReciboEnc RE = new ReciboEnc();
            //ReciboDet rd = Extensiones.RecibosExtensions.reciboDto(RE);
            

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
                query.Append("OUTPUT INSERTED.IDRegistro VALUES (");

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
                //cmd.ExecuteNonQuery();
                IDRegistro = (long)cmd.ExecuteScalar();

                if (IDRegistro > 0)
                {
                    //GUARDO LOS ASIENTOS AUTOMATICOS
                    /*foreach (Caja.MC.CajaMovimientos d in MovimientosCaja)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.ReciboDetalleID = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }*/

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

                //BORRO LOS POSIBLES ASIENTOS AUTOMATICOS DEL  MOVIMIENTO
                /*if (IDRegistro > 0)
                {
                    //PRIMERO BORRO LOS DETALLES GENERADOS EN LA CAJA PARA ESE ASIENTO.
                    Caja.MC.CajaMovimientos _caja = new Caja.MC.CajaMovimientos(SqlConnection);
                    var di = _caja.Eliminacion(IDRegistro, "ReciboDetalleID");
                    func.PreparaRetorno(retorno, di);
                }*/


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
