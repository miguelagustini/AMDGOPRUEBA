using AMDGOINT.Afip;
using AMDGOINT.Clases;
using AmdgoInterno.Afip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class Facturacion : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Pendientes pendientes = new Pendientes();                
        #endregion

        //PROPIEDADES
        #region PROPIEDADES
        private int procesados = 0;
        private string periodo = "";

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public List<ComprobanteEnc> Encabezados { get; set; } = new List<ComprobanteEnc>();
        public List<ComprobanteDet> Detalles { get; set; } = new List<ComprobanteDet>();
        private List<Afip.Entidad> Entidades { get; set; } = new List<Afip.Entidad>();


        public int Procesados
        {
            get { return procesados; }
            set
            {
                if (procesados != value)
                {
                    procesados = value;
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

        #endregion

        //PROPERTYCHANGED
        #region PROPERTYCHANGED

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Facturacion() { }

        public Facturacion(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //PROCESAMIENTO DE PENDIENTES
        #region PROCESAMIENTO DE PENDIENTES

        public bool ProcesaPendientes(string periodo, List<string> tiposcomprobante)
        {
            try
            {
                //Limpio datos facturacion (en caso de reemision)
                Encabezados.Clear();
                Detalles.Clear();
                                
                pendientes.ParamPeriodo = periodo;                
                pendientes.ParamTipoComrpobante.AddRange(tiposcomprobante);

                pendientes.SqlConnection = SqlConnection;
                List<Pendientes> pendienteslst = pendientes.Clone(pendientes.GetRegistros());

                //SI NO HAY PENDIENTES, SALGO
                if (pendienteslst.Count <= 0) { return false; }

                //Encabezados
                if (!ConformaEncabezados(pendienteslst)) { return false; }

                //Detalles
                if (!ConformaDetalles(pendienteslst)) { return false; }

                //Asigno Detalles, Ajusto totales y letra de encabezado
                if (!AsignaDetalles()) { return false; }

                //ACTUALIZO LOS DATOS DE EMISOR Y RECEPTOR
                if (!ActualizaRazonesSociales()) { return false; }

                return true;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes en la obtención de pendientes.\n{e.Message}", 0);
                return false;
            }
        }

        private bool ConformaEncabezados(List<Pendientes> lista)
        {
            try
            {

                //PRIMERO REASIGNO LA LETRA CORRESPONDIENTE
                ReasignaLetrasRegistro(lista);

                //CREO LA LISTA DE ENCABEZADOS
                var encabezado = lista.GroupBy(g => new
                                    {
                                        g.ParamPeriodo,
                                        g.ComprobanteLetra,
                                        g.PrestadoraCuentaID,
                                        g.PrestadoraCuentaCodigo,
                                        g.PrestadoraRazonSocial,
                                        g.PrestadoraDomicilioFiscal,
                                        g.PrestadoraCuit,
                                        g.PrestadoraMiPyme,
                                        g.PrestadoraDiasVencimiento,
                                        g.PrestadoraCuentaIvaID,
                                        g.PrestadoraCuentaIvaPorcentaje,
                                        g.PrestadoraIvaAbreviatura,
                                        g.PacienteDocumentoProcesado
                                      })
                                      .Select(s => new {                                          
                                          s.Key.ComprobanteLetra,
                                          s.Key.PrestadoraCuentaID,
                                          s.Key.PrestadoraCuentaCodigo,
                                          s.Key.PrestadoraRazonSocial,
                                          s.Key.PrestadoraDomicilioFiscal,
                                          s.Key.PrestadoraCuit,
                                          s.Key.PrestadoraMiPyme,
                                          s.Key.PrestadoraDiasVencimiento,
                                          s.Key.PrestadoraCuentaIvaID,
                                          s.Key.PrestadoraCuentaIvaPorcentaje,
                                          s.Key.PrestadoraIvaAbreviatura,
                                          s.First().PacienteNombreProcesado,
                                          s.First().PacienteDocumentoProcesado,
                                          ImporteNeto = s.Sum(x => x.ImporteNeto),
                                          ImporteIva = s.Sum(x => x.ImporteIva),
                                          ImporteGastos = s.Sum(x => x.ImporteGastos),
                                          ImporteHonorarios = s.Sum(x => x.ImporteHonorarios),
                                          ImporteTotal = s.Sum(x => x.ImporteTotal)
                                      }).ToList();

                foreach (var v in encabezado)
                {                   
                    Encabezados.Add(new ComprobanteEnc
                    {

                        Periodo = pendientes.ParamPeriodo,
                        ComprobanteLetra = v.ComprobanteLetra,
                        PacienteNombre = v.PacienteNombreProcesado,
                        PacienteDocumento = v.PacienteDocumentoProcesado,

                        PrestadoraCuentaID = v.PrestadoraCuentaID,
                        PrestadoraCuentaCodigo = v.PrestadoraCuentaCodigo,
                        PrestadoraRazonSocial = v.PrestadoraRazonSocial,
                        PrestadoraCuit = v.PrestadoraCuit,
                        PrestadoraIvaID = v.PrestadoraCuentaIvaID,
                        PrestadoraCuentaIvaPorcentaje = v.PrestadoraCuentaIvaPorcentaje,
                        PrestadoraIvaAbreviatura = v.PrestadoraIvaAbreviatura,                        
                        PrestadoraDomicilioFiscal = v.PrestadoraDomicilioFiscal,
                        PrestadoraDiasVencimiento = v.PrestadoraDiasVencimiento,
                        PrestadoraMiPyme = v.PrestadoraMiPyme,                        
                        ImporteNeto = v.ImporteNeto,
                        ImporteGastos = v.ImporteGastos,
                        ImporteHonorarios = v.ImporteHonorarios,
                        ImporteIva = v.ImporteIva,
                        ImporteTotal = v.ImporteTotal
                    });
                }
                
                
                return true;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo(e.Message, 1);
                return false;

            }
        }

        private void ReasignaLetrasRegistro(List<Pendientes> lista)
        {
            try
            {
                string c = "";
                                                                
                foreach (Pendientes p in lista)
                {
                  
                    if (p.PrestadoraCuentaIvaPorcentaje > 0 && p.PrestadorIvaID == 1 && p.PrestadoraArt.ToUpper() != "S" && p.PrestadoraAceptaComprobanteX)
                    { c = "X"; }
                    //{ c = "C"; }
                    else { c = "C"; }

                    //SI ES PRESTADORA SOLO X
                    //ESTO NO SIRVE MAS, DEJAR VALIDACION "SI ES MO, EX O RI                    

                    /*if (p.PrestadorIvaID == 1 && p.PrestadoraCuentaCodigo != "119" && p.PrestadoraCuentaCodigo != "284" && p.PrestadoraCuentaCodigo != "101"
                        && p.PrestadoraCuentaCodigo != "1041" && p.PrestadoraCuentaCodigo != "1090" && p.PrestadoraCuentaCodigo != "1000" && p.PrestadoraCuentaCodigo != "1100" && p.PrestadoraCuentaCodigo != "1200")
                    { c = "X"; }
                    else { c = "C"; }*/
                    
                    p.ComprobanteLetra = c;
                }

            }
            catch (Exception)
            {

            }
        }

        private bool ConformaDetalles(List<Pendientes> lista)
        {
            try
            {
                foreach (Pendientes p in lista)
                {
                    Detalles.Add(new ComprobanteDet
                    {
                        Periodo = p.PracticaPeriodo,
                        PacienteDocumento = p.PacienteDocumento,
                        PacienteNombre = p.PacienteNombre,

                        Cantidad = p.Cantidad,
                        ImporteNeto = p.ImporteNeto,
                        ImporteGastos = p.ImporteGastos,
                        ImporteHonorarios = p.ImporteHonorarios,
                        ImporteIva = p.ImporteIva,
                        ImporteTotal = p.ImporteTotal,

                        ComprobanteLetra = p.ComprobanteLetra,
                        PrestadoraCuentaID = p.PrestadoraCuentaID,

                        PrestadorCuentaCodigo = p.PrestadorCuentaCodigo,
                        PrestadorCuentaID = p.PrestadorCuentaID,
                        PrestadorIvaID = p.PrestadorIvaID,
                        PrestadorIvaAbreviatura = p.PrestadorIvaAbreviatura,
                        PrestadorNombre = p.PrestadorNombre,

                        PracticaPunteroAsocTran = p.Puntero,
                        PracticaFecha = p.PracticaFecha,
                        PracticaCodigo = p.PracticaCodigo,
                        PracticaDescripcion = p.PracticaDescripcion,
                        PracticaFuncionCodigo = p.FuncionCodigo,
                        Descripcion = p.ComprobanteCargado
                    });
                }

                return true;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo(e.Message, 0);
                return false;
            }
        }

        private bool AsignaDetalles()
        {
            try
            {
                decimal valmipyme = func.GetMinimoPyme(SqlConnection);
                string cbuemisor = func.GetCbucreditos(SqlConnection);
                string aliasemisor = func.GetAliascreditos(SqlConnection);

                //ASIGNO LOS DETALLES A CADA ENCABEZADO CORRESPONDIENTE
                //FINALIZO LOS TOTALES DE NETOS E IVA SEGUN DETALLES
                ComprobanteDet det = new ComprobanteDet();
                foreach (ComprobanteEnc f in Encabezados)
                {
                    f.Detalles = f.PacienteDocumento > 0 ? det.Clone(Detalles.Where(w => w.PrestadoraCuentaID == f.PrestadoraCuentaID && 
                                                                                    w.ComprobanteLetra == f.ComprobanteLetra && w.PacienteDocumento == f.PacienteDocumento).ToList()) :
                                                           det.Clone(Detalles.Where(w => w.PrestadoraCuentaID == f.PrestadoraCuentaID &&
                                                                                    w.ComprobanteLetra == f.ComprobanteLetra).ToList());
                    f.ImporteNeto = f.Detalles.Sum(s => s.ImporteNeto);
                    f.ImporteGastos = f.Detalles.Sum(s => s.ImporteGastos);
                    f.ImporteHonorarios = f.Detalles.Sum(s => s.ImporteHonorarios);
                    f.ImporteIva = f.Detalles.Sum(s => s.ImporteIva);
                    f.ImporteTotal = f.Detalles.Sum(s => s.ImporteTotal);
                    f.ComprobanteTipo = f.PrestadoraMiPyme && f.ImporteTotal > valmipyme && f.Letra != "X" ? "FCE" : "FC";
                    f.ComprobantePuntoVenta = f.ComprobanteTipo == "FCE" ? 13 : 10;
                    f.EmisorCbu = f.ComprobanteTipo == "FCE" ? cbuemisor : "";
                    f.EmisorAlias = f.ComprobanteTipo == "FCE" ? aliasemisor : "";
                    f.FechaDesde = new DateTime(f.ComprobanteFecha.Year, f.ComprobanteFecha.Month, 1);
                    f.FechaHasta = f.FechaDesde.AddMonths(1).AddDays(-1);

                    //VENCIMIENTO SWISS MEDICAL
                    if ((f.PrestadoraCuentaCodigo == "0237" || f.PrestadoraCuentaCodigo == "2891" || f.PrestadoraCuentaCodigo == "198" || f.PrestadoraCuentaCodigo == "0227") &&
                        f.ComprobanteTipo == "FCE" && f.ComprobanteLetra == "C" && f.FacturaFecha.Year == 2022)
                    {
                        switch (f.FacturaFecha.Month)
                        {
                            case 6: f.ComprobanteFechaVtoPago = new DateTime(2022, 9, 1);  break;
                            case 7: f.ComprobanteFechaVtoPago = new DateTime(2022, 10, 3); break;
                            case 8: f.ComprobanteFechaVtoPago = new DateTime(2022, 11, 1); break;
                            case 9: f.ComprobanteFechaVtoPago = new DateTime(2022, 12, 1); break;
                            case 10: f.ComprobanteFechaVtoPago = new DateTime(2023, 1, 2); break;
                            case 11: f.ComprobanteFechaVtoPago = new DateTime(2023, 2, 1); break;
                            case 12: f.ComprobanteFechaVtoPago = new DateTime(2023, 3, 1); break;
                            default: f.ComprobanteFechaVtoPago = f.PrestadoraDiasVencimiento > 0 ? f.ComprobanteFecha.AddDays(f.PrestadoraDiasVencimiento) : f.ComprobanteFecha.AddMonths(1).AddDays(-1); break;
                        }
                    }
                    else
                    {
                        f.ComprobanteFechaVtoPago = f.PrestadoraDiasVencimiento > 0 ? f.ComprobanteFecha.AddDays(f.PrestadoraDiasVencimiento) : f.ComprobanteFecha.AddMonths(1).AddDays(-1);
                    }

                    f.EstadoAfip = f.Letra == "X" ? "A" : "";

                    //DETERMINO EL CONCEPTO
                    f.IDConcepto = f.Detalles.Count(c => c.PracticaOrigen == "1") > 0 || f.Detalles.Count(c => c.PracticaOrigen == "3") > 0 ? (short)1 : //FACTURACION MENSUAL
                                    f.Detalles.Count(c => c.PracticaOrigen == "7") > 0 || f.Detalles.Count(c => c.PracticaOrigen == "8") > 0 ? (short)2 : //REFACTURACION
                                    f.Detalles.Count(c => c.PracticaOrigen == "6") > 0 ? (short)3 : //COVID
                                    f.Detalles.Count(c => c.PracticaOrigen == "2") > 0 || f.Detalles.Count(c => c.PracticaOrigen == "4") > 0 ? (short)4  //FUERA DE TERMINO
                                    : (short)1;


                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ActualizaRazonesSociales()
        {
            try
            {
                //OBTENGO LA INFORMACION DE TODOS LOS CUITS DESDE AFIP
                ProcesaInformacionEntidades();

                //ACTUALIZO LOS DATOS DE LOS ENCABEZADOS
                foreach (ComprobanteEnc f in Encabezados)
                {                    

                    f.PrestadoraRazonSocial = string.IsNullOrWhiteSpace(Entidades.Where(w => w.Cuit == f.PrestadoraCuit.ToString()).Select(s => s.RazonSocial).DefaultIfEmpty("").FirstOrDefault().Replace(",", "")) ? f.PrestadoraRazonSocial :
                                                             Entidades.Where(w => w.Cuit == f.PrestadoraCuit.ToString()).Select(s => s.RazonSocial).DefaultIfEmpty("").FirstOrDefault();

                    f.PrestadoraDomicilioFiscal = string.IsNullOrWhiteSpace(Entidades.Where(w => w.Cuit == f.PrestadoraCuit.ToString()).Select(s => s.Domicilio).DefaultIfEmpty("").FirstOrDefault().Replace(",", "")) ? f.PrestadoraDomicilioFiscal :
                                                                Entidades.Where(w => w.Cuit == f.PrestadoraCuit.ToString()).Select(s => s.Domicilio).DefaultIfEmpty("").FirstOrDefault();

                }

                return true;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al obtener la información de AFIP.\n{e.Message}", 1);
                return false;
            }
        }

        private void ProcesaInformacionEntidades()
        {
            try
            {
                Entidades.Clear();
                                
                //CUIT RECEPTOR
                long[] lstreceptor = Encabezados.GroupBy(g => g.PrestadoraCuit).Select(s => s.Key).ToArray();

                //CONSULTO LOS DATOS ACTUALIZADOS DEL PADRON AFIP
                AfipPadron conspadron = new AfipPadron(SqlConnection);

                //RANGOS NO SUPERIOR A 250 CUITS
                for (int i = 0; i < lstreceptor.Length; i += 250)
                {
                    long[] dest = lstreceptor.Skip(i).Take(250).ToArray();

                    ListaPersonas personas = conspadron.GetEntidad(dest, Application.StartupPath + @"\Afip\PROD\PD-CR20078779250.pfx", "2048", 20078779250);
                    

                    foreach (var s in personas?.personaListReturn?.persona.Where(w => w.datosGenerales != null))
                    {

                        if (string.IsNullOrEmpty(s.datosGenerales.idPersona)) { continue; }

                        Entidades.Add(new Afip.Entidad
                        {
                            Cuit = s.datosGenerales.idPersona,
                            Domicilio = s.datosGenerales?.domicilioFiscal?.direccion + ", " +
                                        s.datosGenerales?.domicilioFiscal?.localidad + " " +
                                        s.datosGenerales?.domicilioFiscal?.codPostal + ", " +
                                        s.datosGenerales?.domicilioFiscal?.descripcionProvincia,
                            NombreApellido = s.datosGenerales?.apellido + ", " + s.datosGenerales?.nombre,
                            RazonSocial = string.IsNullOrEmpty(s.datosGenerales?.razonSocial) ? "" : s.datosGenerales?.razonSocial
                        });
                    }
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al obtener los datos de AFIP.\n{e.Message}", 1);
                return;
            }
        }

        #endregion

        //PROCESAMIENTO DE FACTURA
        #region PROCESAMIENTO DE FACTURA

        //GENERACION DE FACTURA
        public Dictionary<short, string> GenerarFacturas(bool udpasoctran = true)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (Encabezados.Count <= 0) { retorno.Add(1, "No se encontraron comprobantes a emitir."); return retorno; }

                int count = 0;

                AfipProdDatos afip = new AfipProdDatos();
                afip.Sqlconnection = SqlConnection;

                //HAGO EL LOGIN 
                if (!LoginAfip(1, "30567506769", afipprod: afip))
                {
                    Dictionary<short, string> re = new Dictionary<short, string>();
                    re.Add(1, $"No se logró establecer la conexion a afip");
                    func.PreparaRetorno(retorno, re);
                    afip.LiberaMemoria();

                    return retorno;
                }

                //CHEQUEO DE CONEXION A INTERNET
                if (!func.hayConexion())
                {
                    retorno.Add(1, "La conexión a internet fue interrumpida.\nEl proceso debe ser retomado.");
                    afip.LiberaMemoria();
                    return retorno;
                }

                //RECORRO LOS ENCABEZADOS DE FACTURAS
                foreach (ComprobanteEnc f in Encabezados)
                {
                    //SET DATOS AFIP
                    afip.Nrofactura = 0;
                    afip.Observaciones = "";
                    afip.Caenumero = "";
                    afip.Fechavtocae = "";
                    afip.CodigoBarras = "";
                    
                    //CONDICIONALES DE OMISION
                    //SIN CUIT PROFESIONAL, SIN PUNTO DE VENTE, SIN LETRA, SIN CUIT PRESTATARIA, TOTAL MENOR O IGUAL A CERO, SIN DETALLES
                    if (string.IsNullOrEmpty(f.ReceptorCuentaCodigo) || f.ReceptorCuit <= 0 || f.ComprobantePuntoVenta <= 0 || 
                                            f.ComprobanteLetra == "" || f.ImporteTotal <= 0 || f.Detalles.Count <= 0) { continue; }

                    //ENVÍO FACTURA A AFIP
                    if (f.Letra == "C") { retorno = EnvioFactuaAfip(f, afip); }
                    else //SI ES X, ASIGNO EL NUMERO DE COMPROBANTE
                    { SetNumeracionX(f); }

                    if (retorno.Count <= 0)
                    {
                        
                        f.SqlConnection = SqlConnection;                        
                        var dic = f.Abm();
                        func.PreparaRetorno(retorno, dic);

                        //EN CASO DE QUE HAYA UN ERROR EN EL GUARDADO
                        if (retorno.Count > 0)
                        {
                            string mensajes = "";

                            foreach (string i in retorno.Select(s => s.Value))
                            {
                                mensajes += $"{i.Trim()}\n";
                            }

                            if (!string.IsNullOrWhiteSpace(mensajes))
                            {
                                ctrl.MensajeInfo($"Hubo inconvenientes en el guardado, la operación será abortada.\n{mensajes}", 1);
                                afip.LiberaMemoria();
                                break;
                            }
                        }

                        //ACTUALIZO ASOC
                        if (udpasoctran) { ActualizaAsoc(f); }

                    }
                    // EN CASO DE QUE HAYA UN ERROR EN LA APROBACION CON AFIP
                    else
                    {
                        string mensajes = "";

                        foreach (string i in retorno.Select(s => s.Value))
                        {
                            mensajes += $"{i.Trim()}\n";
                        }

                        if (!string.IsNullOrWhiteSpace(mensajes))
                        {
                            Dictionary<short, string> re = new Dictionary<short, string>();
                            re.Add(1, $"Hubo inconvenientes en la notificación de la factura a AFIP, la operación será abortada.\n{mensajes}");
                            func.PreparaRetorno(retorno, re);
                            afip.LiberaMemoria();
                            break;
                        }
                    }

                    Procesados = count++;
                }

                afip.LiberaMemoria();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"Hubo inconvenientes en la emisión de facturas.\n{e.Message}");
                return retorno;
            }
        }

        //ENVIO FACTURA AFIP
        private Dictionary<short, string> EnvioFactuaAfip(ComprobanteEnc enc, AfipProdDatos afip = null)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //CONCEPTO P2
                int concep = 2;

                //OPCIONALES
                if (enc.ComprobanteTipo == "FCE")
                {
                    afip.setOpcionales(enc.EmisorCbu, enc.EmisorAlias);
                    afip.setOpcionaltipotrans("SCA");                    
                }
                else if (enc.ComprobanteTipo == "NCE" || enc.ComprobanteTipo == "NDE")
                {
                    afip.setOpcionales("", "", enc.ComprobanteAnuladoReceptor ? "S" : "N"); 

                    afip.setCompasociados("FCE" + enc.ComprobanteLetra, enc.ComprobantePuntoVenta, enc.ComprobanteNumero, "30567506769",
                                            enc.FacturaFecha.ToString("yyyyMMdd"));
                }
                else if (enc.ComprobanteTipo == "NC" || enc.ComprobanteTipo == "ND")
                {                                                            
                    afip.setCompasociados("FC" + enc.ComprobanteLetra, enc.ComprobantePuntoVenta, enc.ComprobanteNumero);
                }
                    
                afip.agregaFactura(1, enc.ComprobanteFecha.ToString("yyyyMMdd"), enc.ComprobantePuntoVenta, "CUIT", Convert.ToInt64(enc.ReceptorCuit), //ENCABEZADO
                concep, enc.ImporteTotal, 0, enc.ImporteTotal, 0, 0, 0, "pesos", 1, //IMPORTES
                enc.FechaDesde.ToString("yyyyMMdd"), enc.FechaHasta.ToString("yyyyMMdd"), enc.ComprobanteFechaVtoPago.ToString("yyyyMMdd"), //FECHAS SRV
                enc.ComprobanteTipo, enc.ComprobanteLetra);

                if (afip.Estado) { enc.EstadoAfip = "A"; } else { enc.EstadoAfip = "R"; }

                enc.ComprobanteNumero = afip.Nrofactura;
                enc.CaeNumeroAfip = afip.Caenumero;
                enc.CodigoBarrasAfip = afip.CodigoBarras;
                enc.ObservacionesAfip = afip.Observaciones;

                if (!string.IsNullOrEmpty(afip.Fechavtocae))
                {
                    enc.VencimientoCaeAfip = new DateTime(Convert.ToInt32(afip.Fechavtocae.Substring(0, 4)), Convert.ToInt32(afip.Fechavtocae.Substring(4, 2)),
                        Convert.ToInt32(afip.Fechavtocae.Substring(6, 2)));
                }

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Envío Factura Afip.\n{e.Message}");
                return retorno;
            }
        }

        //HAGO EL LOGIN CON AFIP AL MODULO CORRESPONDIENTE
        public bool LoginAfip(short produccion, string cuitemis, AfipHomoDatos afiphomo = null, AfipProdDatos afipprod = null)
        {
            try
            {
                bool retorno = false;
                string path = ExisteCertificado(produccion, cuitemis);

                //HOMOLOGACION 0
                if (produccion == 0 && afiphomo != null)
                {
                    if (path != "" && afiphomo.loginafip(path, "999", Convert.ToInt64(cuitemis))) { retorno = true; } else { retorno = false; }
                }
                //PRODUCCION 1
                else if (produccion == 1 && afipprod != null)
                {
                    if (path != "" && afipprod.loginafip(path, "248", Convert.ToInt64(cuitemis))) { retorno = true; } else { retorno = false; }
                }


                return retorno;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //PROCESO SI EXISTE EL CERTIFICADO PARA GENERAR LA FACTURA
        private string ExisteCertificado(short produccion, string cuitemis)
        {
            try
            {
                string retorno = "";

                //HOMOLOGACION
                if (produccion == 0)
                {
                    if (File.Exists(Application.StartupPath + @"\Afip\HOMO\H-CR" + cuitemis + ".pfx"))
                    {
                        retorno = Application.StartupPath + @"\Afip\HOMO\H-CR" + cuitemis + ".pfx";
                    }

                }//PRODUCCION 1
                else
                {
                    if (File.Exists(Application.StartupPath + @"\Afip\PROD\P-CR" + cuitemis + ".pfx"))
                    {
                        retorno = Application.StartupPath + @"\Afip\PROD\P-CR" + cuitemis + ".pfx";
                    }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al buscar las credenciales.\n" + e.Message, 0);
                return "";
            }
        }

        //ACTUALIZO GUID EN BD ASOC
        private void ActualizaAsoc(ComprobanteEnc f)
        {
            try
            {
                if (f.IDRegistro <= 0 || f.EstadoAfip != "A") { return; }

                string query = "UPDATE [AmdgoSis].[dbo].[ASOCTRAN] set movpcomAM = ISNULL(CONCAT(Ltrim(Rtrim(SIT1.Letra)), '', " +
                               " FORMAT(SIT1.PuntoVenta, '0000'), '-', FORMAT(SIT1.Numero,'00000000')), '')" +
                               " FROM [AmdgoSis].[dbo].[ASOCTRAN] AS AMT" +
                               " LEFT OUTER JOIN[AmdgoInterno].[dbo].[FACTPRESDET] SIT ON(AMT.movpcoda = SIT.Puntero)" +
                               " LEFT OUTER JOIN[AmdgoInterno].[dbo].[FACTPRESENC] SIT1 ON(SIT1.ID_Registro = SIT.ID_Encabezado)" +                               
                               " WHERE SIT1.EstadoAf = 'A' AND SIT1.ID_Registro = " + f.IDRegistro;

                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                ctrl.MensajeInfo("Ocurrió un error al actualizar el id en asoc.\n" + x.Message, 0);
                return;
            }
        }

        //OBTENGO EL NUMERO DE FACTURA X SEGUN TIPO
        private void SetNumeracionX(ComprobanteEnc f)
        {
            try
            {                
                string c = "SELECT ISNULL(MAX(Numero),0) AS Numero FROM FACTPRESENC WHERE TipoComprobante = '" + f.ComprobanteTipo + "' AND PuntoVenta = " + f.ComprobantePuntoVenta + " AND Letra = 'X'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows) { f.ComprobanteNumero = Convert.ToInt64(r["Numero"]) + 1; }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al consultar la numeracion X.\n{e.Message}", 1);
                return;
            }
        }

        #endregion
    }
}
