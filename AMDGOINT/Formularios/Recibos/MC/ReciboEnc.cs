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

namespace AMDGOINT.Formularios.Recibos.MC
{
    public class ReciboEnc : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private NumeroaLetras Numeroaletras = new NumeroaLetras();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoInterno].[dbo].[RECIBOSENC]";
        
        public long IDRegistro { get; set; } = 0;
        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();
        
        public int IDPrestataria { get; set; } = 0;
        public int IDPrestadorCuenta { get; set; } = 0;
        public int IDEmpresa { get; set; } = 0;
        public short IDEmpleado { get; set; } = 0;
        public bool PagoRecibido { get; set; } = true;
        public string PagoRecibidoDescripcion { get { return PagoRecibido ? "SI" : "NO"; } }
        public string ComprobanteTipo { get; set; } = "RC";
        public string ComprobanteLetra { get; set; } = "X";
        public int ComprobantePuntoVenta { get; set; } = 10;
        public long ComprobanteNumero { get; set; } = 0;
        public string Comprobante
        {
            get
            {
                return ComprobanteNumero.ToString("00000000");
            }
        }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public DateTime FechaCaja { get; set; } = DateTime.MinValue;
        public DateTime FechaPago { get; set; } = DateTime.MinValue;
        public string PeriodoPago { get; set; } = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
        public bool AsientoAutomatico { get; set; } = true;
        public long ReceptorCuit { get; set; } = 0;
        public string ReceptorRazonSocial { get; set; } = "";
        public string ReceptorCuentaCodigo { get; set; } = "";
        public decimal ImporteTotal { get; set; } = 0;
        public string Observacion { get; set; } = "";
        public bool Estado { get; set; } = true;
        public byte Area { get; set; }
        public string AreaDescripcion { get { return Area == 1 ? "Pago Prestatarias" : "Tesorería"; } }
        public string ImporteCanceladoLetras
        {
            get
            {
                return Numeroaletras.enletras(ImporteTotal.ToString()).ToUpperInvariant();
            }
        }
        public bool EnviadoDos { get; set; } = false;        
        public string EnviadoDosDescripcion { get { return EnviadoDos ? "SI" : "NO"; } }
        public byte GeneracionAsientosTipo { get; set; } = 1;
        public List<ReciboDet> Detalles { get; set; } = new List<ReciboDet>();
        public List<Caja.MC.CajaMovimientos> MovimientosCaja { get; set; } = new List<Caja.MC.CajaMovimientos>();
        public decimal ImporteAcreditado { get { return Detalles.Where(w => w.ImporteCancelado > 0).Sum(s => s.ImporteCancelado); } } //MODIFICAR CUANDO SE IMPLEMENTE RECIBO PARCIAL, YA QUE NO SERA EL IMPORTE ACREDITADO REAL
        public decimal ImporteDebitado { get { return  Detalles.Where(w => w.ImporteCancelado < 0).Sum(s => s.ImporteCancelado); }  }
        public int IDUsuNew { get; set; } = 0;
        public int IDUsuModif { get; set; } = 0;
        public DateTime TimeModif { get; set; } = DateTime.Now;
        public DateTime TimeNew { get; set; } = DateTime.Now;


        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public string Guid { get { return IDLocal; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ReciboEnc() { }

        public ReciboEnc(SqlConnection conexion)
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
        public ReciboEnc Clone()
        {
            ReciboEnc r = (ReciboEnc)MemberwiseClone();
            ReciboDet d = new ReciboDet();

            r.Detalles = d.Clone(Detalles);
            return r;

        }

        //CLONE CON LISTAS
        public List<ReciboEnc> Clone(List<ReciboEnc> lst)
        {
            List<ReciboEnc> lista = new List<ReciboEnc>();

            foreach (ReciboEnc d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ReciboEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReciboEnc> lista = new List<ReciboEnc>();

                string c = $"SELECT RE.IDRegistro, RE.Guid AS IDLocal, RE.IDPrestataria, RE.IDPrestadorCuenta, RE.IDEmpresa, RE.IDEmpleado, RE.ComprobanteTipo, RE.ComprobanteLetra," +
                           $" RE.ComprobantePuntoVenta, RE.ComprobanteNumero, RE.FechaEmision, RE.FechaPago, RE.PeriodoPago, RE.Observacion, RE.ImporteTotal," +
                           $" RE.ReceptorRazonSocial, RE.ReceptorCuit, RE.PagoRecibido, RE.EnviadoDos, RE.Area, RE.Estado, RE.FechaCaja, RE.AsientoAutomatico" +
                           //$"ISNULL(PD.Codigo, '') AS ReceptorCuentaCodigo, " +                           
                           $" FROM {tablaname} RE"; 
                           //$" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = RE.IDPrestatariaCuenta)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReciboEnc>(rdr));
                }

                //DETALLES
                #region DETALLES
                ReciboDet detcls = new ReciboDet(SqlConnection);
                List<ReciboDet> d = detcls.GetRegistros();
                
                foreach (ReciboEnc p in lista)
                {
                    p.Detalles = detcls.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }
                #endregion

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReciboEnc>();
            }
        }
             
        private void SetNumeroRecibo()
        {
            try
            {
                string c = $"SELECT ISNULL(MAX(ComprobanteNumero)+1,1) AS ComprobanteNumero FROM {tablaname} WHERE Area = {Area} AND Estado = 1";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    ComprobanteNumero = Convert.ToInt64(r["ComprobanteNumero"]);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar el ID.\n{e.Message}", 1);
                return;
            }
        }

        public List<DetalleExtendido> GetDetalleExtenso(List<ReciboEnc> recibos)
        {
            List<DetalleExtendido> retorno = new List<DetalleExtendido>();
            try
            {

                foreach (ReciboEnc r in recibos)
                {
                    foreach (ReciboDet d in r.Detalles)
                    {

                        retorno.Add(new DetalleExtendido
                        {
                            ComprobanteAmdgoNumero = d.ComprobanteAmdgoNumero,
                            ComprobanteFechaEmision = d.ComprobanteFechaEmision,
                            ComprobanteConcepto = d.ComprobanteConcepto,
                            ComprobantePeriodo = d.ComprobantePeriodo,
                            ComprobanteOrigen = d.ComprobanteOrigen,
                            ComprobanteAmdgoImporte = d.ComprobanteAmdgoImporte,
                            PrestatariaCuentaCodigo = d.PrestatariaCuentaCodigo,
                            Descripcion = d.Descripcion,
                            ImporteSaldado = d.ImporteSaldado,
                            ImporteCancelado = d.ImporteCancelado,
                            ComprobanteRcLetra = r.ComprobanteLetra,
                            ComprobanteRcTipo = r.ComprobanteTipo,
                            ComprobanteRcPuntoVenta = r.ComprobantePuntoVenta,
                            ComprobanteRcNumero = r.ComprobanteNumero,
                            FechaEmision = r.FechaEmision,
                            ReceptorCuit = r.ReceptorCuit,
                            ReceptorRazonSocial = r.ReceptorRazonSocial,
                            ImporteAcreditado = r.ImporteAcreditado,                            
                            

                        });
                                           
                    }
                    
                }                                

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return retorno;
            }
        }

        public void GeneraAsiento()
        {
            try
            {
                MovimientosCaja.Clear();                

                //AGRUPO LOS DETALLES POR CUENTA Y SUMO HABER
                var pases = Detalles.Where(w => !w._BorrarRegistro).GroupBy(g => new { g.PlanCuentaID, g.PlanSubCuentaID, g.ModoPago, g.BancoID, g.IDSubCuentaContablePlan })
                    .Select(s => new
                    {
                        s.Key.BancoID,
                        s.Key.ModoPago,
                        s.Key.PlanCuentaID,
                        s.Key.PlanSubCuentaID,
                        s.Key.IDSubCuentaContablePlan,
                        Importe = s.Sum(n => n.ImporteCancelado)
                    }).ToList();

                //RECORRO CADA UNO DE LOS MOVIMIENTOS
                foreach (var v in pases)
                {
                    //MOVIMIENTO ESTANDAR (CUENTA SELECCIONADA)
                    MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                    {
                        FechaMovimiento = DateTime.Now,
                        ModoPago = v.ModoPago,
                        BancoID = v.BancoID,
                        PlanCuentaID = v.PlanCuentaID,
                        PlanSubCuentaID = v.PlanSubCuentaID,
                        ImporteHaber = v.Importe
                    });
                }

                //asiento automatico
                if (GeneracionAsientosTipo.Equals(1))
                {
                    GeneraAsientoAutomatico(pases);
                }
                //asiento de plantilla
                else if (GeneracionAsientosTipo.Equals(2))
                {
                    GeneraAsientosPlantilla(pases);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void GeneraAsientoAutomatico(IEnumerable<dynamic> pases)
        {
            try
            {                                                    
                //RECORRO CADA UNO DE LOS MOVIMIENTOS
                foreach (var v in pases)
                {                  
                    //SI ES CAJA Y TESORERIA, NO GENERO MOVIMIENTOS AUTOMATICOS
                    if (IDPrestataria == 39 && Area == 2) { continue; }

                    if (v.Importe < 0) { continue; } //NO GENERO ASIENTO AUTOMATICO EN NEGATIVOS

                    //ASIENTO AUTOMATICO SEGUN AREA
                    //pago a prestatarias
                    if (Area == 1)
                    {
                        MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                        {
                            FechaMovimiento = DateTime.Now,
                            ModoPago = (byte)v.ModoPago,
                            BancoID = (short)v.BancoID,
                            PlanCuentaID = IDPrestataria == 4 ? 288 : 15, //si es fesalud uso 2602, sino 1202
                            PlanSubCuentaID = IDPrestataria == 4 ? 325 : (int)v.IDSubCuentaContablePlan,//si es fesalud uso 13009, sino 0
                            ImporteDebe = v.Importe - Convert.ToDecimal(Math.Abs(pases.Where(w => w.Importe < 0).Sum(s => s.Importe)))
                        });
                        
                    }
                    else //recibos tesoreria
                    {
                        //MOVIMIENTO AUTOMATICO (CUENTA DE SALIDA) BANCO, CAJA, ETC.
                        if ((byte)v.ModoPago == 0) //EFECTIVO
                        {
                            MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                            {
                                FechaMovimiento = DateTime.Now,
                                ModoPago = (byte)v.ModoPago,
                                BancoID = (short)v.BancoID,
                                PlanCuentaID = 3,
                                PlanSubCuentaID = 0,                                                                
                                ImporteDebe = v.Importe - Convert.ToDecimal(Math.Abs(pases.Where(w => w.Importe < 0).Sum(s => s.Importe)))
                            });
                        }
                        else if ((byte)v.ModoPago == 1 || (byte)v.ModoPago == 2) //TRANSFERENCIAS / CHEQUES
                        {
                            MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                            {
                                FechaMovimiento = DateTime.Now,
                                ModoPago = (byte)v.ModoPago,
                                BancoID = (short)v.BancoID,
                                PlanCuentaID = (short)v.BancoID == 1 ? 8 : (short)v.BancoID == 2 ? 6 : (short)v.BancoID == 102 ? 7 : 0,
                                PlanSubCuentaID = 0,                                
                                ImporteDebe = v.Importe - Convert.ToDecimal(Math.Abs(pases.Where(w => w.Importe < 0).Sum(s => s.Importe)))
                            });
                        }
                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento contable automático.\n{e.Message}", 1);
                return;
            }
        }

        private void GeneraAsientosPlantilla(IEnumerable<dynamic> pases)
        {
            try
            {

                AsientosContables.MC.ConfiguracionDet conf = new AsientosContables.MC.ConfiguracionDet(SqlConnection);
                List<AsientosContables.MC.ConfiguracionDet> configuraciones = conf.GetRegistros();
                              
                //RECORRO CADA UNO DE LOS MOVIMIENTOS
                foreach (var v in pases)
                {
                    //BUSCAR LA PLANTILLA DE ASIENTOS
                    List<AsientosContables.MC.ConfiguracionDet> _useconfig =  configuraciones.Where(w => w.ComprobanteTipo == "RC"
                                               && 
                                               (
                                                    //( > 0 ? w.PrestatariaCuentaID == IDPrestataria ) ||                                                    
                                                    w.PrestatariaID == IDPrestataria &&                                                   
                                                    w.PrestadorCuentaID == IDPrestadorCuenta &&
                                                    w.TerceroID == IDEmpresa &&
                                                    w.PersonalID == IDEmpleado
                                               )
                                               && w.Area == Area
                                               && w.ImporteTipo == (v.Importe < 0 ? 2 : 1)
                                               && w.DebePlanCuentaID > 0
                                               && w.HaberPlanCuentaID == (int)v.PlanCuentaID
                                               ).ToList();


                    if (_useconfig != null && _useconfig.Count > 0)
                    {
                        //SI SE REALIZA UN ASIENTO DE BANCO
                        if (_useconfig.Exists(e => e.DebePlanCuentaID == 8 || e.DebePlanCuentaID == 6 || e.DebePlanCuentaID == 7))
                        {
                            MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                            {
                                FechaMovimiento = DateTime.Now,
                                ModoPago = (byte)v.ModoPago,
                                BancoID = (short)v.BancoID,
                                PlanCuentaID = _useconfig.Where(w => w.DebePlanCuentaID == (v.BancoID == 1 ? 8 : v.BancoID == 2 ? 6 : v.BancoID == 102 ? 7 : 0)).Select(s => s.DebePlanCuentaID).FirstOrDefault(),
                                //PlanSubCuentaID = _useconfig.Where(w => w.DebePlanCuentaID == (v.BancoID == 1 ? 8 : v.BancoID == 2 ? 6 : v.BancoID == 102 ? 7 : 0)).Select(s => s.DebePlanCuentaID).FirstOrDefault(),
                                ImporteDebe = v.Importe - Convert.ToDecimal(Math.Abs(pases.Where(w => w.Importe < 0).Sum(s => s.Importe)))
                            });
                        }
                        else
                        {
                            MovimientosCaja.Add(new Caja.MC.CajaMovimientos
                            {
                                FechaMovimiento = DateTime.Now,
                                ModoPago = (byte)v.ModoPago,
                                BancoID = (short)v.BancoID,
                                PlanCuentaID = _useconfig.Select(s => s.DebePlanCuentaID).FirstOrDefault(),
                                PlanSubCuentaID = _useconfig.Select(s => s.DebePlanSubCuentaID).FirstOrDefault(),
                                ImporteDebe = v.Importe - Convert.ToDecimal(Math.Abs(pases.Where(w => w.Importe < 0).Sum(s => s.Importe)))
                            });
                        }
                    }

                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento contable por plantilla.\n{e.Message}", 1);
                return;
            }
        }
               
        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm(bool procesadetalles = true)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0)
            {
                return Alta();
            }
            else if (IDRegistro > 0)
            {
                return Modificacion(procesadetalles);
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
            
            //campos.Add("Guid");
            campos.Add("Area");
            campos.Add("IDPrestataria");
            campos.Add("IDPrestadorCuenta");
            campos.Add("IDEmpresa");
            campos.Add("IDEmpleado");
            campos.Add("FechaEmision");
            campos.Add("FechaPago");
            campos.Add("PagoRecibido");
            campos.Add("ComprobanteTipo");
            campos.Add("ComprobanteLetra");
            campos.Add("ComprobantePuntoVenta");
            campos.Add("ComprobanteNumero");
            campos.Add("PeriodoPago");
            campos.Add("ReceptorCuit");
            campos.Add("ReceptorRazonSocial");
            campos.Add("ImporteTotal");
            campos.Add("Observacion");            
            campos.Add("EnviadoDos");
            campos.Add("AsientoAutomatico");
            campos.Add("Estado");
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

            try
            {
                //CONEXION
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                IDUsuNew = glb.GetIdUsuariolog();
                IDUsuModif = glb.GetIdUsuariolog();

                //ASIGNO EL NUMERO DE RECIBO
                SetNumeroRecibo();

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
                query.Append(" OUTPUT INSERTED.IDRegistro VALUES (");

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
                IDRegistro = (long)cmd.ExecuteScalar();
                                
                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (ReciboDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
                                        
                    var trn = SetAsientosCaja("I");
                    func.PreparaRetorno(retorno, trn);
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
        private Dictionary<short, string> Modificacion(bool procesadetalles = true)
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

                IDUsuModif = glb.GetIdUsuariolog();
                
                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
                campos.Remove("IDUsuNew");                
                campos.Remove("ComprobanteNumero");

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

                if (procesadetalles)
                {
                    //ACTUALIZO DETALLES
                    foreach (ReciboDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }                                        
                }

                //FUERA DEL PROCESO DE DETALLES, PORQUE DEBE BORRAR LOS REGISTROS IGUALMENTE                
                var trn = SetAsientosCaja("U");
                func.PreparaRetorno(retorno, trn);

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

        public Dictionary<short, string> SetAsientosCaja(string acc)
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

                //SOLO SI ES UPDATE
                if (acc == "U")
                {
                    //BORRO LOS DETALLES GENERADOS EN LA CAJA PARA ESE ASIENTO.
                    Caja.MC.CajaMovimientos _caja = new Caja.MC.CajaMovimientos(SqlConnection);
                    var di = _caja.Eliminacion(IDRegistro, "ReciboID");
                    func.PreparaRetorno(retorno, di);
                }

                //LUEGO INSERTO LOS NUEVOS (SOLO SI EL RECIBO ES NO ANULADO)
                if (Estado)
                {
                    foreach (Caja.MC.CajaMovimientos d in MovimientosCaja)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.ReciboID = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
                }
                
                               
                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}");                
                return retorno;
            }

        }

        #endregion

    }
}
