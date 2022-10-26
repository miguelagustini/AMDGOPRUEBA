using AMDGOINT.Afip;
using AMDGOINT.Clases;
using AmdgoInterno.Afip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Facturas.Internacion.MC
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

        public List<Ambulatorio.MC.FacturaEnc> Encabezados { get; set; } = new List<Ambulatorio.MC.FacturaEnc>();
        public List<Ambulatorio.MC.FacturaDet> Detalles { get; set; } = new List<Ambulatorio.MC.FacturaDet>();
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

        //METODOS Y EVENTOS
        #region METODOS Y EVENTOS

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

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

        public bool ProcesaPendientes()
        {
            try
            {
                //Limpio datos facturacion (en caso de reemision)
                Encabezados.Clear();
                Detalles.Clear();
                                
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
                //CREO LA LISTA DE ENCABEZADOS
                var encabezado = lista.GroupBy(g => new { g.EmisorCuentaID, g.EmisorCuentaCodigo, g.EmisorNombre, g.EmisorCuit, g.EmisorIvaID, g.EmisorModoFacturacion,
                                                          g.EmisorIvaAbreviatura, g.EmisorDomicilioFiscal,
                                                          g.EmisorEmiteComprobanteFCE, g.EmisorCbuComprobanteFCE, g.EmisorAliasComprobanteFCE, g.EmisorCircuitoComprobanteFCE,
                                                          g.ReceptorCuentaID, g.ReceptorCuentaCodigo,
                                                          g.ReceptorDomicilioFiscal, g.EmisorPtovta, g.ReceptorNombre, g.ReceptorCuit,
                                                          g.ReceptorIvaID, g.ReceptorIvaAbreviatura, g.ReceptorPorcIva, g.ReceptorMiPyme, g.InternacionNumero,
                                                          g.InternacionPuntero, g.PacienteDocumento, g.PacienteNombre, g.EntidadCuentaCodigo, g.EntidadNombre, g.EntidadCuentaID
                                                        })
                                      .Select(s => new {
                                                        s.Key.EmisorCuentaID,
                                                        s.Key.EmisorCuentaCodigo,
                                                        s.Key.EmisorNombre,
                                                        s.Key.EmisorCuit,
                                                        s.Key.EmisorIvaID,
                                                        s.Key.EmisorIvaAbreviatura,
                                                        s.Key.EmisorModoFacturacion,
                                                        s.Key.EmisorPtovta,
                                                        s.Key.EmisorEmiteComprobanteFCE,
                                                        s.Key.EmisorCbuComprobanteFCE,
                                                        s.Key.EmisorAliasComprobanteFCE,
                                                        s.Key.EmisorCircuitoComprobanteFCE,
                                                        s.Key.EmisorDomicilioFiscal,
                                                        s.Key.ReceptorCuentaID,
                                                        s.Key.ReceptorCuentaCodigo,
                                                        s.Key.ReceptorPorcIva,
                                                        s.Key.ReceptorNombre,
                                                        s.Key.ReceptorCuit,
                                                        s.Key.ReceptorIvaID,
                                                        s.Key.ReceptorIvaAbreviatura,
                                                        s.Key.ReceptorDomicilioFiscal,
                                                        s.Key.ReceptorMiPyme,
                                                        s.Key.InternacionNumero,
                                                        s.Key.InternacionPuntero,
                                                        s.Key.PacienteDocumento,
                                                        s.Key.PacienteNombre,
                                                        s.Key.EntidadCuentaID,
                                                        s.Key.EntidadCuentaCodigo,
                                                        s.Key.EntidadNombre,
                                                        Neto = s.Sum(x => x.ImporteNeto),
                                                        Iva = s.Sum(x => x.ImporteIva),
                                                        Total = s.Sum(x => x.ImporteTotal)
                                        }).ToList();
                                
                foreach (var v in encabezado)
                {                                      

                    Encabezados.Add(new Ambulatorio.MC.FacturaEnc
                    {                                                          
                        IDCuentaProf = v.EmisorCuentaID,
                        NombreProf = v.EmisorNombre,
                        CuitProf = v.EmisorCuit,
                        IvaProf = v.EmisorIvaID,
                        CodigoProf = v.EmisorCuentaCodigo,
                        IvaProfAbre = v.EmisorIvaAbreviatura,
                        PuntoVenta = v.EmisorPtovta,
                        DomFiscalProf = v.EmisorDomicilioFiscal,

                        EmisorEmiteComprobanteFCE = v.EmisorEmiteComprobanteFCE,
                        EmisorCbuComprobanteFCE = v.EmisorCbuComprobanteFCE,
                        EmisorAliasComprobanteFCE = v.EmisorAliasComprobanteFCE,
                        EmisorCircuitoComprobanteFCE = v.EmisorCircuitoComprobanteFCE,

                        IDPrestDetalle = v.ReceptorCuentaID,
                        CodigoPres = v.ReceptorCuentaCodigo,
                        NombrePres = v.ReceptorNombre,
                        CuitPres = v.ReceptorCuit,
                        IvaPres = v.ReceptorIvaID,
                        IvaPresAbre = v.ReceptorIvaAbreviatura,
                        PorcIvaPres = v.ReceptorPorcIva,
                        DomFiscalPres = v.ReceptorDomicilioFiscal,
                        PresMiPyme = v.ReceptorMiPyme,
                        PacienteNombre = v.PacienteNombre,
                        PacienteDocumento = Convert.ToInt64(v.PacienteDocumento),
                        InternacionPuntero = v.InternacionPuntero,
                        InternacionNumero = v.InternacionNumero,
                        EntidadCuentaID = v.EntidadCuentaID,
                        EntidadCuentaCodigo = v.EntidadCuentaCodigo,
                        EntidadNombre = v.EntidadNombre,
                        Neto = v.Neto,
                        Iva = v.Iva,
                        Total = v.Total                        
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

        private bool ConformaDetalles(List<Pendientes> lista)
        {
            try
            {
                foreach (Pendientes p in lista)
                {
                    Detalles.Add(new Ambulatorio.MC.FacturaDet
                    {
                        FechaPract = p.PracticaFecha,
                        CodPract = p.PracticaCodigo,
                        DescrPract = p.PracticaDescripcion,
                        Funcion = p.PracticaFuncion,
                        DocuPaci = Convert.ToInt64(p.PacienteDocumento),
                        Puntero = p.InternacionPuntero,
                        InternacionNumero = p.InternacionNumero,
                        NombrePaci = p.PacienteNombre,
                        IvaPorc = p.ReceptorPorcIva,
                        Cantidad = p.Cantidad,
                        Neto = (p.ReceptorPorcIva > 0 && p.ImporteIva > 0) || p.EmisorIvaID != 1 ? p.ImporteNeto : 0,
                        Iva = p.ImporteIva,
                        NoGravado = p.ImporteIva <= 0 && p.EmisorIvaID == 1 ? p.ImporteNeto : 0,
                        Total = p.ImporteTotal,
                        Honorarios = p.ImporteHonorario,
                        Gastos = p.ImporteGasto,
                        Medicamentos = p.ImporteMedicamento,
                        IDPrestDetalle = p.ReceptorCuentaID,
                        IDCuentaProf = p.EmisorCuentaID,

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

                //ASIGNO LOS DETALLES A CADA ENCABEZADO CORRESPONDIENTE
                //FINALIZO LOS TOTALES DE NETOS E IVA SEGUN DETALLES
                Ambulatorio.MC.FacturaDet det = new Ambulatorio.MC.FacturaDet();
                foreach (Ambulatorio.MC.FacturaEnc f in Encabezados)
                {
                    f.TipoComprobante = f.EmisorEmiteComprobanteFCE && f.PresMiPyme && f.Total >= valmipyme ? "FCE" : "FC";
                    f.Detalles = det.Clone(Detalles.Where(w => w.IDCuentaProf == f.IDCuentaProf && w.IDPrestDetalle == f.IDPrestDetalle && w.InternacionNumero == f.InternacionNumero
                                                          && w.Puntero == f.InternacionPuntero).ToList());
                    f.Neto21 = decimal.Round(f.Detalles.Where(w => w.IvaPorc == 21).Sum(s => s.Neto), 2);
                    f.Neto105 = decimal.Round(f.Detalles.Where(w => w.IvaPorc == (decimal)10.5).Sum(s => s.Neto), 2);
                    f.Neto0 = decimal.Round(f.Detalles.Where(w => w.IvaPorc == 0).Sum(s => s.Neto), 2);
                    f.Iva21 = f.Neto21 > 0 && f.IvaProf == 1 ? Math.Round(f.Neto21 * (decimal)0.21, 2) : 0;
                    f.Iva105 = f.Neto105 > 0 && f.IvaProf == 1 ? Math.Round(f.Neto105 * (decimal)0.105, 2) : 0;
                    f.NoGravado = decimal.Round(f.Detalles.Where(w => w.NoGravado > 0).Sum(s => s.NoGravado), 2);
                    f.Neto = f.Neto21 + f.Neto105 + f.Neto0;
                    f.Iva = f.Iva21 + f.Iva105;
                    f.Total = f.Neto + f.Iva + f.NoGravado;
                    f.SetLetra();
                    f.FechaDesde = new DateTime(f.Fecha.Year, f.Fecha.Month, 1);
                    f.FechaHasta = f.FechaDesde.AddMonths(1).AddDays(-1);
                    f.FechaVto = f.Fecha.AddDays(10);
                }

                //QUITO TODOS LOS COMPROBANTES QUE ESTAN EN CERO
                Encabezados.RemoveAll(r => r.PuntoVenta == 0);

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
                foreach (Ambulatorio.MC.FacturaEnc f in Encabezados)
                {

                    f.NombreProf = string.IsNullOrWhiteSpace(Entidades.Where(w => w.Cuit == f.CuitProf.ToString()).Select(s => s.NombreApellido).DefaultIfEmpty("").FirstOrDefault().Replace(",", "")) ? f.NombreProf :
                                                             Entidades.Where(w => w.Cuit == f.CuitProf.ToString()).Select(s => s.NombreApellido).DefaultIfEmpty("").FirstOrDefault();

                    f.DomFiscalProf = string.IsNullOrWhiteSpace(Entidades.Where(w => w.Cuit == f.CuitProf.ToString()).Select(s => s.Domicilio).DefaultIfEmpty("").FirstOrDefault().Replace(",", "")) ? f.DomFiscalProf :
                                                                Entidades.Where(w => w.Cuit == f.CuitProf.ToString()).Select(s => s.Domicilio).DefaultIfEmpty("").FirstOrDefault();

                    f.NombrePres = string.IsNullOrWhiteSpace(Entidades.Where(w => w.Cuit == f.CuitPres.ToString()).Select(s => s.RazonSocial).DefaultIfEmpty("").FirstOrDefault().Replace(",", "")) ? f.NombrePres :
                                                             Entidades.Where(w => w.Cuit == f.CuitPres.ToString()).Select(s => s.RazonSocial).DefaultIfEmpty("").FirstOrDefault();

                    f.DomFiscalPres = string.IsNullOrWhiteSpace(Entidades.Where(w => w.Cuit == f.CuitPres.ToString()).Select(s => s.Domicilio).DefaultIfEmpty("").FirstOrDefault().Replace(",", "")) ? f.DomFiscalPres :
                                                                Entidades.Where(w => w.Cuit == f.CuitPres.ToString()).Select(s => s.Domicilio).DefaultIfEmpty("").FirstOrDefault();

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

                //CUIT EMISOR
                long[] lstemisor = Encabezados.GroupBy(g => g.CuitProf).Select(s => s.Key).ToArray();
                //CUIT RECEPTOR
                long[] lstreceptor = Encabezados.GroupBy(g => g.CuitPres).Select(s => s.Key).ToArray();

                //RECOLECTO CUIT PRESTADORES
                long[] arrcuits = lstemisor.Concat(lstreceptor).ToArray();

                //CONSULTO LOS DATOS ACTUALIZADOS DEL PADRON AFIP
                AfipPadron conspadron = new AfipPadron(SqlConnection);

                //RANGOS NO SUPERIOR A 250 CUITS
                for (int i = 0; i < arrcuits.Length; i += 250)
                {
                    long[] dest = arrcuits.Skip(i).Take(250).ToArray();

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

                //AGRUPO LOS ENCABEZADOS PARA NO GENERAR CONEXIONES UNA A UNA EN AFIP
                long[] cuits = Encabezados.GroupBy(g => g.CuitProf).Select(s => s.Key).ToArray();

                //RECORRO TODOS LOS CUITS
                foreach (long cuit in cuits)
                {
                   
                    AfipProdDatos afip = new AfipProdDatos();
                    afip.Sqlconnection = SqlConnection;
                   
                    //HAGO EL LOGIN 
                    if (!LoginAfip(1, cuit, afipprod: afip))
                    {
                        Dictionary<short, string> re = new Dictionary<short, string>();
                        re.Add(1, $"No se logró establecer la conexion a afip de {cuit.ToString()}");
                        func.PreparaRetorno(retorno, re);
                        afip.LiberaMemoria();

                        //return retorno;
                        continue;
                    }

                    //CHEQUEO DE CONEXION A INTERNET
                    if (!func.hayConexion())
                    {
                        retorno.Add(1, "La conexión a internet fue interrumpida.\nEl proceso debe ser retomado.");
                        afip.LiberaMemoria();
                        return retorno;
                    }

                    //RECORRO LOS ENCABEZADOS DE FACTURAS
                    foreach (Ambulatorio.MC.FacturaEnc f in Encabezados.Where(w => w.CuitProf == cuit))
                    {
                        //SET DATOS AFIP
                        afip.Nrofactura = 0;
                        afip.Observaciones = "";
                        afip.Caenumero = "";
                        afip.Fechavtocae = "";
                        afip.CodigoBarras = "";

                        //CONDICIONALES DE OMISION
                        //SIN CUIT PROFESIONAL, SIN PUNTO DE VENTE, SIN LETRA, SIN CUIT PRESTATARIA, TOTAL MENOR O IGUAL A CERO, SIN DETALLES
                        if (f.IDCuentaProf <= 0 || f.CuitProf <= 0 || f.PuntoVenta <= 0 || f.Letra == "" || f.CuitPres <= 0 || f.Total <= 0 || f.Detalles.Count <= 0 || f.IDPrestDetalle <= 0) { continue; }
                                                
                        //ENVÍO FACTURA A AFIP
                        retorno = EnvioFactuaAfip(f, afip);
                                                
                        //ABM INDEPENDIENTE SI FUE APROBADA O NO                        
                        f.SqlConnection = SqlConnection;
                        var dic = f.Abm();
                        func.PreparaRetorno(retorno, dic);

                        if (retorno.Count <= 0 && udpasoctran)
                        {
                            //ACTUALIZO ASOC SOLO SI NO HUBO ERRORES
                            ActualizaAsoc(f); 
                        }
                        // EN CASO DE QUE HAYA UN ERROR 
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
                                return retorno;
                            }
                        }
                        
                        Procesados = count++;
                    }

                    afip.LiberaMemoria();
                }

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"Hubo inconvenientes en la emisión de facturas.\n{e.Message}");
                return retorno;             
            }
        }

        //ENVIO FACTURA AFIP
        private Dictionary<short, string> EnvioFactuaAfip(Ambulatorio.MC.FacturaEnc enc, AfipProdDatos afip = null)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {                   
                //AGREGO LAS ALICUOTAS DE IVA                
                if (enc.Letra == "B" && enc.IvaPres == 1) { afip.setIva(3, enc.Total, 0); }
                else if(enc.Letra != "C") 
                {
                    if (enc.Iva105 > 0) { afip.setIva(4, enc.Neto105, Convert.ToDecimal(enc.Iva105.ToString("0.00"))); }
                    if (enc.Iva21> 0) { afip.setIva(5, enc.Neto21, Convert.ToDecimal(enc.Iva21.ToString("0.00"))); }
                }
                                
                if (enc.TipoComprobante == "FCE")
                {
                    afip.setOpcionales(enc.EmisorCbuComprobanteFCE, enc.EmisorAliasComprobanteFCE);
                    afip.setOpcionaltipotrans(enc.EmisorCircuitoComprobanteFCE);                              
                }                

                afip.agregaFactura(1, enc.Fecha.ToString("yyyyMMdd"), enc.PuntoVenta, "CUIT", Convert.ToInt64(enc.CuitPres), //ENCABEZADO
                2, enc.Neto, enc.Iva, enc.Total, enc.NoGravado, 0, 0, "pesos", 1, //IMPORTES
                enc.FechaDesde.ToString("yyyyMMdd"), enc.FechaHasta.ToString("yyyyMMdd"), enc.FechaVto.ToString("yyyyMMdd"), //FECHAS SRV
                enc.TipoComprobante, enc.Letra);

                if (afip.Estado) { enc.EstadoAf = "A"; } else { enc.EstadoAf = "R"; }
                                
                enc.Numero = afip.Nrofactura;
                enc.CaeNroAf = afip.Caenumero;
                enc.BarrasAf = afip.CodigoBarras;
                
                if (!string.IsNullOrEmpty(afip.Fechavtocae))
                {
                    enc.VtoCaeAf = new DateTime(Convert.ToInt32(afip.Fechavtocae.Substring(0, 4)), Convert.ToInt32(afip.Fechavtocae.Substring(4, 2)), Convert.ToInt32(afip.Fechavtocae.Substring(6, 2)));
                }

                enc.ObservAf = afip.Observaciones;

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Envío Factura Afip.\n{e.Message}");
                return retorno;
            }
        }

        //HAGO EL LOGIN CON AFIP AL MODULO CORRESPONDIENTE
        public bool LoginAfip(short produccion, long cuitemis, AfipHomoDatos afiphomo = null, AfipProdDatos afipprod = null)
        {
            try
            {
                bool retorno = false;
                string path = ExisteCertificado(produccion, cuitemis.ToString());

                //HOMOLOGACION 0
                if (produccion == 0 && afiphomo != null)
                {
                    if (path != "" && afiphomo.loginafip(path, "999", cuitemis)) { retorno = true; } else { retorno = false; }
                }
                //PRODUCCION 1
                else if (produccion == 1 && afipprod != null)
                {
                    if (path != "" && afipprod.loginafip(path, "248", cuitemis)) { retorno = true; } else { retorno = false; }
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
        private void ActualizaAsoc(Ambulatorio.MC.FacturaEnc f)
        {
            try
            {
                if (f.IDRegistro <= 0 || f.EstadoAf != "A") { return; }

                string query =  $"UPDATE AmdgoSis.dbo.ASOCSAN2 SET MOVOCOMP = CONCAT(Ltrim(Rtrim(IFE.TipoComprobante)), Ltrim(Rtrim(IFE.Letra)), FORMAT(IFE.PuntoVenta, '0000'), FORMAT(IFE.Numero, '00000000'))" +                                
                                $" FROM AmdgoSis.dbo.ASOCSAN2 MED" +
                                $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = MED.MOVOPFAC)" +
                                $" LEFT OUTER JOIN AmdgoInterno.dbo.FACTAMBUENC IFE ON(IFE.InternacionNumero = MED.MOVONINT AND IFE.InternacionPuntero = MED.MOVOPUNT AND IFE.ID_CuentaProf = PC.ID_Registro)" +
                                $" WHERE IFE.EstadoAf = 'A' AND MED.MOVOCOMP IS NULL AND IFE.ID_Registro = {f.IDRegistro} ";

                //**************** MODIFICAR PARA ACTUALIZAR ASOCSAN2 *******************************

                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                ctrl.MensajeInfo("Ocurrió un error al actualizar el id en asoc.\n" + x.Message, 0);
                return;
            }
        }

        #endregion

        #endregion

    }
}
