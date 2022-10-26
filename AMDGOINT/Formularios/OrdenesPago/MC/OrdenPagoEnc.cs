using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.OrdenesPago.MC
{
    public class OrdenPagoEnc : INotifyPropertyChanged
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
        private static string tablaname = "[AmdgoContable].[dbo].[ts_ORDENESPAGOENC]";

        public long IDRegistro { get; set; } = 0;
        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();
       // public string OrdenNumero { get { return IDRegistro.ToString("00000"); } }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public string ComprobanteTipo { get; set; } = "OP";
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
        public short IDEmpleado { get; set; } = 0;
        public int IDPrestadorCuenta { get; set; } = 0;
        public short IDEmpresa { get; set; } = 0;
        public string ReceptorRazonSocial { get; set; } = "";
        public long ReceptorCuit { get; set; } = 0;
        public string ReceptorCuentaBancaria { get; set; } = "";
        public decimal ImporteTotal { get; set; } = 0;
        public string ImporteTotalLetras
        {
            get
            {
                return Numeroaletras.enletras(ImporteTotal.ToString()).ToUpperInvariant();
            }
        }
        public string Observacion { get; set; } = "";
        public bool Estado { get; set; } = true;
        public string EstadoDescripcion { get { return Estado ? "Incluída" : "Excluída"; } }
        public List<OrdenPagoDet> Detalles { get; set; } = new List<OrdenPagoDet>();
        public List<AsientosContables.MC.AsientosDet> AsientosContables { get; set; } = new List<AsientosContables.MC.AsientosDet>();
        public int IDUsuNew { get; set; } = 0;
        public int IDUsuModif { get; set; } = 0;
        public DateTime TimeModif { get; set; } = DateTime.Now;
        public DateTime TimeNew { get; set; } = DateTime.Now;
        public string Guid { get { return IDLocal; } }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
              
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public OrdenPagoEnc() { }

        public OrdenPagoEnc(SqlConnection conexion)
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
        public OrdenPagoEnc Clone()
        {
            OrdenPagoEnc r = (OrdenPagoEnc)MemberwiseClone();
            OrdenPagoDet d = new OrdenPagoDet();

            r.Detalles = d.Clone(Detalles);
            return r;
        }

        //CLONE CON LISTAS
        public List<OrdenPagoEnc> Clone(List<OrdenPagoEnc> lst)
        {
            List<OrdenPagoEnc> lista = new List<OrdenPagoEnc>();
            lst.ForEach(f => lista.Add(f.Clone()));            
            return lista;
        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<OrdenPagoEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<OrdenPagoEnc> lista = new List<OrdenPagoEnc>();

                string c = $"SELECT OE.IDRegistro, OE.Guid AS IDLocal, OE.FechaEmision, OE.IDEmpleado, OE.IDPrestadorCuenta, OE.IDEmpresa, OE.ReceptorRazonSocial, OE.ReceptorCuit," +
                           $" OE.ReceptorCuentaBancaria, OE.ImporteTotal, OE.Observacion, OE.ComprobanteTipo, OE.ComprobanteLetra, OE.ComprobantePuntoVenta, OE.ComprobanteNumero," +
                           $" OE.Estado" +
                           $" FROM {tablaname} OE";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<OrdenPagoEnc>(rdr));
                }

                //DETALLES
                #region DETALLES
                OrdenPagoDet detcls = new OrdenPagoDet(SqlConnection);
                List<OrdenPagoDet> d = detcls.GetRegistros();

                foreach (OrdenPagoEnc p in lista)
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
                return new List<OrdenPagoEnc>();
            }
        }
             
        public bool PuedoModificar()
        {
            try
            {
                ConexionBD cnb = new ConexionBD();
                bool retorno = false;

                if (Detalles.Count <= 0) { return true; }

                string _where = "";
                Detalles.ForEach(f => _where += _where.Length > 0 ? $" OR CA.IDOrdenPago = {f.IDRegistro}" : $" CA.IDOrdenPago = {f.IDRegistro}");

                string c = $"SELECT ISNULL(COUNT(*), 0) AS Cantidad" +
                    $" FROM [AmdgoContable].[dbo].[ts_ASIENTOSCNTBLENC] CA " +
                    $" WHERE ({_where})" +
                    $" AND CA.FechaCierreAnual IS NULL AND CA.FechaCierreMensual IS NULL";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection).Rows)
                {
                    if ((int)r["Cantidad"] <= 0) { retorno = true; }
                }

                cnb.Desconectar();
                return retorno;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar el estado.\n{e.Message}", 1);
                return false;
            }
        }

        private void SetNumeroComprobante()
        {
            try
            {
                string c = $"SELECT ISNULL(MAX(ComprobanteNumero)+1,1) AS ComprobanteNumero FROM {tablaname}";

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

        public void GeneraAsientos()
        {
            try
            {                
                AsientosContables.Clear();

                //AGRUPO LOS DETALLES POR CUENTA
                var pases = Detalles.Where(w => !w._BorraRegistro).GroupBy(g => new { g.PlanCuentaID, g.PlanSubCuentaID, g.ModoPago, g.BancoID })
                    .Select(s => new
                    {
                        s.Key.BancoID,
                        s.Key.ModoPago,
                        s.Key.PlanCuentaID,
                        s.Key.PlanSubCuentaID,
                        Importe = s.Sum(n => n.ImportesSingo),
                        ImporteCs = s.Sum(n => n.Importe)
                    });


                //RECORRO CADA UNO DE LOS MOVIMIENTOS
                foreach (var v in pases)
                {
                    if (v.Importe == 0) { continue; }

                    //MOVIMIENTO ESTANDAR (CUENTA SELECCIONADA)
                    AsientosContables.Add(new AsientosContables.MC.AsientosDet
                    {
                        PlanCuentaID = v.PlanCuentaID,
                        PlanSubCuentaID = v.PlanSubCuentaID,
                        ImporteDebe = v.ImporteCs > 0 ? v.Importe : 0,
                        ImporteHaber = v.ImporteCs < 0 ? v.Importe : 0,
                    });

                    if (v.ImporteCs < 0) { continue; } //NO GENERO ASIENTO AUTOMATICO EN NEGATIVOS

                    //TOTALIZO IMPORTES NEGATIVOS PARA RESTAR
                    decimal _negativo = Math.Abs(Detalles.Where(w => !w._BorraRegistro 
                                                          && w.PlanCuentaID != v.PlanCuentaID && w.PlanSubCuentaID != v.PlanSubCuentaID 
                                                          && w.ModoPago == v.ModoPago && w.BancoID == v.BancoID
                                                          && w.Importe < 0).Sum(s => s.Importe));

                    //MOVIMIENTO AUTOMATICO (CUENTA DE SALIDA) BANCO, CAJA, ETC.
                    if (v.ModoPago == 0) //EFECTIVO
                    {
                        AsientosContables.Add(new AsientosContables.MC.AsientosDet
                        {
                            PlanCuentaID = 3,
                            PlanSubCuentaID = 0,
                            ImporteHaber = v.Importe - _negativo
                        });
                    }
                    else if (v.ModoPago == 1 || v.ModoPago == 2) //TRANSFERENCIAS / CHEQUES
                    {
                        AsientosContables.Add(new AsientosContables.MC.AsientosDet
                        {                            
                            PlanCuentaID = v.BancoID == 1 ? 8 : v.BancoID == 2 ? 6 : v.BancoID == 102 ? 7 : 0,
                            PlanSubCuentaID = 0,
                            ImporteHaber = v.Importe - _negativo
                        });
                    }
                    
                }

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

            campos.Add("Guid");
            campos.Add("ComprobanteTipo");
            campos.Add("ComprobanteLetra");
            campos.Add("ComprobantePuntoVenta");
            campos.Add("ComprobanteNumero");            
            campos.Add("FechaEmision");
            campos.Add("IDEmpleado");
            campos.Add("IDPrestadorCuenta");
            campos.Add("IDEmpresa");
            campos.Add("ReceptorRazonSocial");
            campos.Add("ReceptorCuit");
            campos.Add("ReceptorCuentaBancaria");
            campos.Add("ImporteTotal");
            campos.Add("Observacion");
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

                //ASIGNO NUMERO COMPROBANTE
                SetNumeroComprobante();

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
                IDRegistro = (long)cmd.ExecuteScalar();
                                
                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (OrdenPagoDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                }

                //AGREGO EL ASIENTO CONTABLE (ENCABEZADO // DETALLES)
                ProcesoAsientoContable("I");

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

                if (procesadetalles)
                {
                    //ACTUALIZO DETALLES
                    foreach (OrdenPagoDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
                }

                ProcesoAsientoContable("U");

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
        
        private Dictionary<short, string> ProcesoAsientoContable(string accion)
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

                AsientosContables.MC.AsientosEnc Asiento = new AsientosContables.MC.AsientosEnc(SqlConnection);

                //NUEVOS ASIENTOS
                if (accion == "I")
                {
                    //detalles
                    AsientosContables.ForEach(f => f.OrdenPagoID = IDRegistro);
                    Asiento.Detalles.AddRange(AsientosContables);

                    //encabezado
                    Asiento.IDOrdenPago = IDRegistro;
                    Asiento.Observacion = ComprobanteTipo + " " + ComprobanteLetra + ComprobantePuntoVenta.ToString("0000") + "-" + ComprobanteNumero.ToString("00000000");
                    var dic = Asiento.Abm();
                    func.PreparaRetorno(retorno, dic);
                                                                            
                }
                else if (accion == "U")
                {
                    //RECUPERO EL ENCABEZADO
                    AsientosContables.MC.AsientosEnc _encabezado = Asiento.GetRegistrosbyfieldid(IDRegistro, "IDOrdenPago").FirstOrDefault();
                                        
                    //SIEMPRE SE BORRA LOS DETALLES
                    //BORRO DETALLES
                    AsientosContables.MC.AsientosDet _detalle = new AsientosContables.MC.AsientosDet(SqlConnection);
                    _detalle.Eliminacion(IDRegistro, "OrdenPagoID");

                    if (!Estado) //SI SE DA DE BAJA LA ORDEN, TAMBIEN SE BORRA EL ENCABEZADO
                    {
                        //BORRO ENCABEZADO
                        if (_encabezado != null) { _encabezado.Eliminacion(IDRegistro, "IDOrdenPago"); }
                    }
                    else //SI ES MODIFICACION
                    {
                        if (AsientosContables.Count == 0) { GeneraAsientos(); }

                        AsientosContables.ForEach(f => f.OrdenPagoID = IDRegistro);

                        if (_encabezado != null) //SI HAY ENCABEZADO SOLO GUARDO LOS NUEVOS ASIENTOS
                        {
                            _encabezado.Detalles.Clear();
                            _encabezado.Detalles.AddRange(AsientosContables);
                        }
                        else //SI ES NULL, DEBO AGREGAR EL ENCABEZADO
                        {
                            _encabezado = new AsientosContables.MC.AsientosEnc();
                            _encabezado.IDOrdenPago = IDRegistro;
                            _encabezado.Observacion = ComprobanteTipo + " " + ComprobanteLetra + ComprobantePuntoVenta.ToString("0000") + "-" + ComprobanteNumero.ToString("00000000");
                            _encabezado.Detalles.AddRange(AsientosContables);
                        }

                        var dic = _encabezado.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
                }

                cbd.Desconectar();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Modificación.\n{e.Message}");
                return retorno;
            }

        }


        #endregion

    }
}
