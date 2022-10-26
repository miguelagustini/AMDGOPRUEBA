using AMDGOINT.AFIP.PROD.WSFE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AmdgoInterno.Afip
{
    public class AfipProdDatos
    {
        //ESTA CLASE ES LA CLASE "CONTROLADOR" DESDE ACA VOY A PARAMENTRIZAR TODO,
        //A QUE SERVER ME QUIERO CONECTAR, CON QUE CREDENCIALES (LAS VOY A OBTENER DE CADA RESPONSABLE)
        //TODO LO QUE LLEVE UN DIRECTORIO (EL CERTIFICADO OBTENIDO POR AFIP, POR EJEMPLO, DEBE SER PARAMETRIZADO DESDE LA PESTAÑA DE PARAMETROS       
        public SqlConnection Sqlconnection = new SqlConnection();


        public FEAuthRequest authRequest { get; set; }

        public Service servicio { get; set; }

        public AfipProdLog login { get; set; }

        public string Caenumero { get; set; } = "";

        public string CodigoBarras { get; set; } = "";

        public string Fechavtocae { get; set; } 

        public long Nrofactura { get; set; }

        public bool Estado { get; set; }

        public string Observaciones { get; set; } = "";

        private int Puntoventa { get; set; }
        private int Idcomprobantetipo { get; set; }
        private long Cuitresponsable { get; set; }

        private FECAERequest request { get; set; }

        private FECAECabRequest cabecera { get; set; }

        private FECAEDetRequest detalle { get; set; }

        private CbteAsoc[] CompAsociado;
        private AlicIva[] Aliciva;
        private Opcional[] Opcional;

        private List<CbteAsoc> cbteAsocs = new List<CbteAsoc>();
        private List<AlicIva> alicivas = new List<AlicIva>();
        private List<Opcional> opcionales = new List<Opcional>();

        private long Cuitempresa { get; set; } = 0; 
        private string Letra { get; set; } = "";
        private string TipoComprobante { get; set; } = "";

        public bool loginafip(string certificadodir, string clavecert, long cuit)
        {
            try
            {
                Cuitempresa = cuit;
                AfipProdLog log = new AfipProdLog(certificadodir, clavecert);
                log.urlWSDL = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL";
                log.server = "wsfe";
                log.Sqlconnection = Sqlconnection;
                log.HacerLogin(Cuitempresa);
                login = log;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        private void Inicioparametrosconexion(long micuit)
        {
            authRequest = new FEAuthRequest();
            authRequest.Cuit = micuit;
            authRequest.Sign = login.Sign;
            authRequest.Token = login.Token;

            servicio = new Service();
            servicio.Url = login.urlwsdl;
            servicio.ClientCertificates.Add(login.certificado);

        }

        //AGREGA ENCABEZADOS
        public void agregaFactura(int cantreg, string fechacbte, int pventa, string tipodoccmop, long cuitcomp, int concepto,
            decimal impneto, decimal impiva, decimal imptotal, decimal impnograv, decimal impexentos, decimal imptributarios, string moneda, double monedacotiz, string fecsrvdesde,
            string fecsrvhasta, string fecvtopago, string tipocomprob, string letra)
        {
            TipoComprobante = tipocomprob;
            Letra = letra;

            //INICIALIZO EL AUTHREQUES Y SERVICIO PARA TRABAJAR CON ESTOS DURANTE ESTA GENERACION
            Inicioparametrosconexion(Cuitempresa);

            request = new FECAERequest();
            cabecera = new FECAECabRequest();
            detalle = new FECAEDetRequest();

            //ENCABEZADO DE FACTURA
            Cuitresponsable = Cuitempresa;
            Puntoventa = pventa;
            Idcomprobantetipo = getIdtipocomprob(TipoComprobante + Letra);

            cabecera.CantReg = cantreg;            
            cabecera.PtoVta = pventa;            
            cabecera.CbteTipo = Idcomprobantetipo;            
            request.FeCabReq = cabecera;

            //DETALLE DE FACTURA            
            detalle.Concepto = concepto;
            detalle.DocTipo = getIddocumentocmp(tipodoccmop);
            detalle.DocNro = cuitcomp;                      
            
            Nrofactura = getUltimonumerocbte(pventa, getIdtipocomprob(TipoComprobante + Letra));
            detalle.CbteDesde = Nrofactura;
            detalle.CbteHasta = Nrofactura;
            detalle.CbteFch = fechacbte;

            detalle.ImpTotal = Convert.ToDouble(imptotal);
            detalle.ImpTotConc = Convert.ToDouble(impnograv);
            detalle.ImpNeto = Convert.ToDouble(impneto);

            detalle.ImpOpEx = Convert.ToDouble(impexentos);
            detalle.ImpTrib = Convert.ToDouble(imptributarios);
            detalle.ImpIVA = Convert.ToDouble(impiva);

            //FECHAS PARA SERVICIOS (CONCEPTOS DOS Y TRES)
            if (concepto == 2 || concepto == 3)
            {
                detalle.FchServDesde = fecsrvdesde;
                detalle.FchServHasta = fecsrvhasta;

                //FECHAS PARA FCC
                if (TipoComprobante != "NCE" && TipoComprobante != "NDE") { detalle.FchVtoPago = fecvtopago; }                                
            }            

            detalle.MonId = getIdmoneda(moneda);
            detalle.MonCotiz = Convert.ToDouble(monedacotiz);

            //ALICUOTAS DE IVA            
            if ((alicivas != null) && (alicivas.Count > 0))
            {
                Aliciva = new AlicIva[alicivas.Count];
                alicivas.CopyTo(Aliciva);
                detalle.Iva = Aliciva;                    
            }
            
            alicivas.Clear();

            //OPCIONALES
            if ((opcionales != null) && (opcionales.Count > 0))
            {
                Opcional = new Opcional[opcionales.Count];
                opcionales.CopyTo(Opcional);
                detalle.Opcionales = Opcional;
            }

            opcionales.Clear();

            //COMPROBANTES ASOCIADOS
            if (TipoComprobante == "NC" || TipoComprobante == "ND" ||
                TipoComprobante == "NCE" || TipoComprobante == "NDE")
            {
                if ((cbteAsocs != null) && (cbteAsocs.Count > 0))
                {
                    CompAsociado = new CbteAsoc[cbteAsocs.Count];
                    cbteAsocs.CopyTo(CompAsociado);
                    detalle.CbtesAsoc = CompAsociado;

                    cbteAsocs.Clear();
                }                
            }

            if (imptotal > 0) { solicitaAprobacion(); }
            else { Observaciones = "Servidor AFIP ah retornado el total menor a cero."; Estado = false; }
            
        }

        //APLICA FACTURA
        public string solicitaAprobacion()
        {
            string retorno = "";

            try
            {

                request.FeDetReq = new[] { detalle };
                FECAEResponse respuesta = servicio.FECAESolicitar(authRequest, request);
                
                string m = "";

                if (respuesta.FeCabResp != null)
                {
                    m += "Estado: " + respuesta.FeCabResp.Resultado + "\n";
                    m += "Estado Esp: " + respuesta.FeDetResp[0].Resultado.ToString();
                    m += "\n";
                    m += "CAE: " + respuesta.FeDetResp[0].CAE.ToString();
                    m += "\n";
                    m += "Vto: " + respuesta.FeDetResp[0].CAEFchVto.ToString();
                    m += "\n";
                    m += "Desde-Hasta: " + respuesta.FeDetResp[0].CbteDesde.ToString() + "-" + respuesta.FeDetResp[0].CbteHasta.ToString();
                    m += "\n";
                    
                }

                if (respuesta.FeDetResp != null)
                {
                    
                    Caenumero = respuesta.FeDetResp[0].CAE;
                    Fechavtocae = respuesta.FeDetResp[0].CAEFchVto;

                    if (respuesta.FeCabResp.Resultado != null)
                    {
                        //EN CASO DE FACTURACION EN LOTES, CONTEMPLAR LA LETRA "P" DONDE ALGUNAS DE LAS ENVIADAS PODRIAN HABER SIDO RECHAZADAS
                        if (respuesta.FeCabResp.Resultado.ToString().ToUpper() == "A") { Estado = true; genCodigoBarras(); } else { Estado = false; }
                    }
                    else { Estado = false; }

                    Observaciones = "";
                    if (respuesta.FeDetResp[0].Observaciones != null)
                    {
                        foreach (Obs o in respuesta.FeDetResp[0].Observaciones)
                        {
                            m += String.Format("Obs: {0} - {1}", o.Code, o.Msg) + "\n";
                            Observaciones = String.Format("Obs: {0} - {1}", o.Code, o.Msg) + "\n";
                        }
                    }
                }

                Observaciones += "\n";

                if (respuesta.Errors != null)
                {
                    foreach (Err Errors in respuesta.Errors)
                    {
                        Observaciones += String.Format("Err: {0} - {1}", Errors.Code, Errors.Msg);
                    }
                }

                Observaciones += "\n";

                if (respuesta.Events != null)
                {
                    foreach (Evt ev in respuesta.Events)
                    {
                        Observaciones += String.Format("Evt: {0} - {1}", ev.Code, ev.Msg);
                    }
                }

                retorno = m;

                return retorno;
            }
            catch (Exception e)
            {
                Estado = false;
                return e.Message;
            }

        }

        //CIERRO Y DISOPISE
        public void LiberaMemoria()
        {
            try
            {
                if (servicio != null) { servicio.Dispose(); }
            }
            catch (Exception)
            {

            }

        }

        public void PuntosVenta()
        {
            Inicioparametrosconexion(Cuitempresa);
            FEPtoVentaResponse puntosventa = new FEPtoVentaResponse();

            puntosventa = servicio.FEParamGetPtosVenta(authRequest);

            foreach (var r in puntosventa.ResultGet)
            {
                string valor = r.Nro.ToString();
            }
        }

        //RETORNO LOS COMPROBANTES ASOCIADOS
        public void setCompasociados(string comprobante, int puntoventa, long numero, string cuitfce = "", string fechafce = "")
        {
            try
            {
                if (fechafce != "")
                {
                    cbteAsocs.Add(new CbteAsoc
                    {
                        Tipo = getIdtipocomprob(comprobante),
                        PtoVta = puntoventa,
                        Nro = numero,
                        Cuit = cuitfce,
                        CbteFch = fechafce
                    });
                }
                else
                {
                    cbteAsocs.Add(new CbteAsoc
                    {
                        Tipo = getIdtipocomprob(comprobante),
                        PtoVta = puntoventa,
                        Nro = numero,
                        Cuit = cuitfce

                    });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void setIva(int idalicuota, decimal importebase, decimal importeiva)
        {
            try
            {
                alicivas.Add(new AlicIva
                {
                    Id = idalicuota,
                    BaseImp = Convert.ToDouble(importebase),
                    Importe = Convert.ToDouble(importeiva)

                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        //OPCIONALES CBU
        public void setOpcionales(string cbu, string alias, string anula = "")
        {
            try
            {
                if (cbu != "")
                {
                    opcionales.Add(new Opcional
                    {
                        Id = "2101",
                        Valor = cbu
                    });
                }

                if (alias != "")
                {
                    opcionales.Add(new Opcional
                    {
                        Id = "2102",
                        Valor = alias
                    });

                }

                if (anula != "")
                {
                    opcionales.Add(new Opcional
                    {
                        Id = "22",
                        Valor = anula
                    });

                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        //OPCIONLAES TIPO DE TRANSFERENCIA
        public void setOpcionaltipotrans(string tipocircuito)
        {
            opcionales.Add(new Opcional
            {
                Id = "27",
                Valor = tipocircuito
            });
        }

        //DEVUELVO EL ULTIMO NUMERO DE COMPROBANTE GENERADO
        private long getUltimonumerocbte(int pventa, int idtipocomprob)
        {
            try
            {
                FERecuperaLastCbteResponse lastRes = servicio.FECompUltimoAutorizado(authRequest, pventa, idtipocomprob);
                long last = lastRes.CbteNro + 1;

                return last;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DEVUELVO ID TIPO DE COMPROBANTE
        public int getIdtipocomprob(string tipocomprob)
        {
            int comprobante = 0;

            //TIPO DE COMPROBANTE - AFIP TG-B
            switch (tipocomprob)
            {
                case "FCA":
                    comprobante = 1;
                    break;
                case "NDA":
                    comprobante = 2;
                    break;
                case "NCA":
                    comprobante = 3;
                    break;
                case "RCA":
                    comprobante = 4;
                    break;
                case "FCB":
                    comprobante = 6;
                    break;                
                case "NDB":
                    comprobante = 7;
                    break;
                case "NCB":
                    comprobante = 8;
                    break;
                case "RCB":
                    comprobante = 9;
                    break;
                case "FCC":
                    comprobante = 11;
                    break;
                case "NDC":
                    comprobante = 12;
                    break;
                case "NCC":
                    comprobante = 13;
                    break;
                case "RCC":
                    comprobante = 15;
                    break;

                case "FCEA":
                    comprobante = 201;
                    break;
                case "NCEA":
                    comprobante = 203;
                    break;
                case "NDEA":
                    comprobante = 202;
                    break;
                case "FCEB":
                    comprobante = 206;
                    break;
                case "NCEB":
                    comprobante = 208;
                    break;
                case "NDEB":
                    comprobante = 207;
                    break;
                case "FCEC":
                    comprobante = 211;
                    break;
                case "NCEC":
                    comprobante = 213;
                    break;
                case "NDEC":
                    comprobante = 212;
                    break;                
                default:
                    comprobante = 0;
                    break;
            }

            return comprobante;
        }

        //DEVUELVO EL ID DEL TIPO DE DOCUMENTO DEL COMPRADOR
        public int getIddocumentocmp(string documento)
        {
            int tipodoccomprador = 0;

            // TIPO DE DOCUMENTO COMPRADOR
            switch (documento)
            {
                case "CUIT":
                    tipodoccomprador = 80;
                    break;
                case "CUIL":
                    tipodoccomprador = 86;
                    break;
                case "DNI":
                    tipodoccomprador = 96;
                    break;
                case "PPTE":
                    tipodoccomprador = 94;
                    break;
                case "CI":
                    tipodoccomprador = 0;    //CED IDENT POLIC FEDERAL
                    break;
                default:
                    tipodoccomprador = 99;  //SIN IDENTIFICAR VENTA GLOBAL DIARIA
                    break;
            }

            return tipodoccomprador;
        }

        //DEVUELVO EL ID DE LA MONEDA 
        //LOS STRING DEBEN MANEJARSE SIN ACENTOS
        public string getIdmoneda(string moneda)
        {
            string idmoneda = "PES";

            switch (moneda.ToUpper())
            {
                case "PESOS":
                    idmoneda = "PES";
                    break;
                case "DÓLAR ESTADOUNIDENSE":
                    idmoneda = "DOL";
                    break;
                case "REAL":
                    idmoneda = "012";
                    break;
                case "DOLAR ESTADOUNIDENSE":
                    idmoneda = "DOL";
                    break;
                case "PESO BOLIVIANO":
                    idmoneda = "031";
                    break;
                case "PESO COLOMBIANO":
                    idmoneda = "032";
                    break;
                case "PESO CHILENO":
                    idmoneda = "033";
                    break;
                case "EURO":
                    idmoneda = "060";
                    break;
                default:
                    idmoneda = "PES";
                    break;
            }

            return idmoneda;
            
            /*000 OTRAS MONEDAS
            PES PESOS
            DOL Dólar ESTADOUNIDENSE
            ´002    Dólar EEUU LIBRE
            003 FRANCOS FRANCESES
            004 LIRAS ITALIANAS
            005 PESETAS
            006 MARCOS ALEMANES
            007 FLORINES HOLANDESES
            008 FRANCOS BELGAS
            009 FRANCOS SUIZOS
            010 PESOS MEJICANOS
            011 PESOS URUGUAYOS
            012 REAL
            013 ESCUDOS PORTUGUESES
            014 CORONAS DANESAS
            015 CORONAS NORUEGAS
            016 CORONAS SUECAS
            017 CHELINES AUTRIACOS
            018 Dólar CANADIENSE
            019 YENS
            021 LIBRA ESTERLINA
            022 MARCOS FINLANDESES
            023 BOLIVAR(VENEZOLANO)
            024 CORONA CHECA
            025 DINAR(YUGOSLAVO)
            026 Dólar AUSTRALIANO
            027 DRACMA(GRIEGO)
            028 FLORIN(ANTILLAS HOLA
            029 GUARANI
            030 SHEKEL(ISRAEL)
            031 PESO BOLIVIANO
            032 PESO COLOMBIANO
            033 PESO CHILENO
            034 RAND(SUDAFRICANO)
            035 NUEVO SOL PERUANO
            036 SUCRE(ECUATORIANO)
            040 LEI RUMANOS
            041 DERECHOS ESPECIALES DE GIRO
            042 PESOS DOMINICANOS
            043 BALBOAS PANAMEÑAS
            044 CORDOBAS NICARAGÛENSES
            045 DIRHAM MARROQUÍES
            046 LIBRAS EGIPCIAS
            047 RIYALS SAUDITAS
            048 BRANCOS BELGAS FINANCIERAS
            049 GRAMOS DE ORO FINO
            050 LIBRAS IRLANDESAS
            051 Dólar DE HONG KONG
            052 Dólar DE SINGAPUR
            053 Dólar DE JAMAICA
            054 Dólar DE TAIWAN
            055 QUETZAL(GUATEMALTECOS)
            056 FORINT(HUNGRIA)
            057 BAHT(TAILANDIA)
            058 ECU
            059 DINAR KUWAITI
            060 EURO
            061 ZLTYS POLACOS
            062 RUPIAS HINDÚES
            063 LEMPIRAS HONDUREÑAS
            064 YUAN(Rep.Pop.China)*/

        }

        //GENERO EL CODIGO DE BARRAS PARA LA FACTURA (SI FUE APROBADA)
        private void genCodigoBarras()
        {
            try
            {

                CodigoBarras = "";
                if (!Estado) { return; }

                int iSum = 0, iDigit = 0;
                string FIN2 = "", cadena = "";

                //CODIGO DE BARRAS
                //PASA TODOS LOS DATOS NECESARIOS PARA EL CODIGO DE BARRAS A LA VARIABLE cadena
                cadena = Cuitresponsable.ToString() + Idcomprobantetipo.ToString("000") + 
                         Puntoventa.ToString("00000") + Caenumero.ToString() + Fechavtocae.ToString();

                //RECORRO LA CADENA
                for (int i = cadena.Length; i == 1; i--)
                {
                    iDigit = cadena.Substring(i, 1).Length;

                    if (((cadena.Length - i + 1) / 2) != 0) { iSum = iSum + iDigit * 3; }
                    else { iSum = iSum + iDigit; }
                }

                int iCheckSum = 0;
                iCheckSum = (10 - (iSum / 10)) / 10;     //calcula el verificador resto de la division((10 - resto(iSum/10) / 10) 
                FIN2 = iCheckSum.ToString();
                CodigoBarras = cadena + FIN2;                   //agrego digito verificador.-
                
            }
            catch (Exception)
            {
                CodigoBarras = "";
                throw;
            }
            
        }
    }
}
