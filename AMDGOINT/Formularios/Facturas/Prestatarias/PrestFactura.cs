using AMDGOINT.Afip;
using AMDGOINT.Clases;
using AmdgoInterno.Afip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    class PrestFactura
    {
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private ConexionAmdgoSis conex = new ConexionAmdgoSis();
        private AfipProdDatos afip = new AfipProdDatos();
        private AfipPadron conspadron = new AfipPadron();
        private ConexionBD conn = new ConexionBD();

        public List<ComprobPE> ListadoPendienteEnc = new List<ComprobPE>();
        public List<ComprobPD> ListadoPendienteDet = new List<ComprobPD>();
        private List<Encabezadostruct> listaenc = new List<Encabezadostruct>();
        private List<Prestcomprobx> listaceptacmpx = new List<Prestcomprobx>();
        private List<Prestcomprobx> listcomprobxpaciente = new List<Prestcomprobx>();

        public string BusqPeriododesde { get; set; } = "";
        public string BusqPeriodohasta { get; set; } = "";
        public int Procesadas { get; set; } = 0;
        public long GlobalIDcomp { get; set; } = 0;


        public List<ComprobPE> GetEmitidos()
        {
            List<ComprobPE> lista = new List<ComprobPE>();

            try
            {
                string c = "SELECT FE.ID_Registro, FE.Fecha, FE.TipoComprobante, FE.Letra, FE.PuntoVenta, FE.Numero," +
                    " FE.Paciente, FE.NroDocumento, FE.ID_PrestDetalle, FE.NombrePres, PR.Descripcion AS NombreAsoc," +
                    " FE.CuitPres, CD.Descripcion AS IvaPres, FE.DomFiscalPres, FE.Cbu, FE.Alias, FE.Neto, FE.Gastos," +
                    " FE.Honorarios, FE.Iva, FE.Total, ISNULL(FE.FechaDesde, '') AS FechaDesde," +
                    " ISNULL(FE.FechaHasta, '') AS FechaHasta, FE.EstadoAf," +
                    " FE.CaeNroAf, FE.BarrasAf, ISNULL(FE.VtoCaeAf, '') AS VtoCaeAf, FE.ObservAf, PR.Codigo," +
                    " FE.IvaPres as IvaNro, CONCAT(FE.TipoComprobante, ' ', FE.Letra, '-', FORMAT(FE.PuntoVenta, '0000')," +
                    " ' ', FORMAT(FE.Numero, '00000000')) AS Comprobante, FE.Periodo, FE.Pagada," +
                    " IIF((ISNULL(FE.Total, 0) + ISNULL((SELECT SUM(FE1.Total)" + 
                                                     " FROM FACTPRESREL FR" +
                                                     " LEFT OUTER JOIN FACTPRESENC FE1 ON(FE1.ID_Registro = FR.ID_NotaDebito AND FR.ID_NotaDebito > 0)" +
                                                     " WHERE FR.ID_Factura = FE.ID_Registro),0)) - " +
                                              " ISNULL((SELECT SUM(FE1.Total)" +
                                                       " FROM FACTPRESREL FR" +
                                                       " LEFT OUTER JOIN FACTPRESENC FE1 ON(FE1.ID_Registro = FR.ID_NotaCredito AND FR.ID_NotaCredito > 0)" +
                                                       " WHERE FR.ID_Factura = FE.ID_Registro),0)" +
                                                       " <= 0, 1, 0) as Anulada," +
                    " FE.DiasVencidos, FE.InteresesVencimiento" +
                    " FROM FACTPRESENC FE" +
                    " LEFT OUTER JOIN PRESTDETALLES PR ON(PR.ID_Registro = FE.ID_PrestDetalle)" +
                    " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = FE.IvaPres)" +
                    " ORDER BY FE.Fecha DESC";

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {

                    lista.Add(new ComprobPE
                    {
                        ID_Factura = Convert.ToInt64(f["ID_Registro"]),
                        Fecha = Convert.ToDateTime(f["Fecha"]),
                        TipoComprobante = f["TipoComprobante"].ToString().Trim(),
                        Letra = f["Letra"].ToString().Trim(),
                        PuntoVta = Convert.ToInt32(f["PuntoVenta"]),
                        Numero = Convert.ToInt64(f["Numero"]),
                        Paciente = f["Paciente"].ToString().Trim(),
                        NroDocumento = Convert.ToInt64(f["NroDocumento"]),
                        ID_Prestataria = f["ID_PrestDetalle"].ToString(),
                        ReceptorCodigo = f["Codigo"].ToString().Trim(),
                        ReceptorNombre = f["NombrePres"].ToString().Trim(),
                        ReceptorNombreAsoc = f["NombreAsoc"].ToString().Trim(),
                        ReceptorCuit = f["CuitPres"].ToString().Trim(),
                        ReceptorIva = f["IvaPres"].ToString().Trim(),
                        ReceptorIvanro = f["IvaNro"].ToString(),
                        ReceptorDomFiscal = f["DomFiscalPres"].ToString().Trim(),
                        EmisorCbu = f["Cbu"].ToString().Trim(),
                        EmisorAlias = f["Alias"].ToString().Trim(),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Gastos = Convert.ToDecimal(f["Gastos"]),
                        Honorarios = Convert.ToDecimal(f["Honorarios"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        FechaDesde = f["FechaDesde"].ToString(),
                        FechaHasta = f["FechaHasta"].ToString(),
                        Estado = f["EstadoAf"].ToString().Trim(),
                        FechaVtoCae = f["VtoCaeAf"].ToString(),
                        CaeNro = f["CaeNroAf"].ToString().Trim(),
                        NumeroBarras = f["BarrasAf"].ToString().Trim(),
                        Observaciones = f["ObservAf"].ToString().Trim(),
                        Comprobante = f["Comprobante"].ToString().Trim(),
                        Periodo = f["Periodo"].ToString().Trim(),
                        Pagada = Convert.ToBoolean(f["Pagada"]),
                        Anulada = Convert.ToBoolean(f["Anulada"]),
                        DiasVencidos = Convert.ToInt16(f["DiasVencidos"]),
                        InteresesVencidos = Convert.ToDecimal(f["InteresesVencimiento"])
                    });
                }

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar los registros" + e.Message, 0);
                return lista;
            }
        }

        public void EmiteFacturas()
        {
            ABMFactuprestat();
        }

        private void PrepararEncabezados(string busde, string bushas)
        {
            try
            {
                listaenc.Clear();

                //CONSULTA SQL DE ENCABEZADOS
                string c = "SELECT movpcdob AS Obra, OB.OBRANOMB as Nombre, ISNULL(OB.OBRADART, '') AS ART," +
                                " ISNULL(OB.OBRANCUI, 0) AS Cuit, ISNULL(OB.OBRAPORC_IVA, 0) AS PorcIva," +
                                " ISNULL((case when((UPPER(OB.OBRADART) = 'S' OR RIGHT(movppefa, 1) = '6') AND movpcdob <> '284') then MAX(movppaci) end), '') as Paciente," +
                                " ISNULL((case when((UPPER(OB.OBRADART) = 'S' OR RIGHT(movppefa, 1) = '6') AND movpcdob <> '284') then movpdocp end), 0) as NroDocumento," +
                                " SUM(movpcant) as Cantidad, SUM(movpneto) as Neto, SUM(movpiiva) as Iva, SUM(movpgast) as Gastos," +
                                " SUM(movphono) as Honorarios, SUM(movptoim) as Total," +
                                " IIF(ISNULL(OB.OBRAPORC_IVA, 0) > 0 AND PF.PROFAFIP = '1' AND ISNULL(OB.OBRADART, '') <> 'S', 'X','C') AS Letra," +
                                " PF.PROFAFIP" +
                                " FROM ASOCTRAN" +
                                " LEFT OUTER JOIN ASOCOBRA OB ON(OB.OBRACODI = movpcdob)" +
                                " LEFT OUTER JOIN ASOCPROF PF ON(PF.PROFCODI = movpcopr)" +
                                " WHERE (movppefa = '" + busde + "' OR movppefa = '" + bushas + "')" +
                                //" WHERE (movppefa = '202111X')" +
                                " AND (movpcomAM IS NULL OR RTRIM(LTRIM(movpcomAM)) = '')" +
                                " AND (movpcdob <> '444' AND movpcdob <> '437' AND movpcdob <> '741' AND movpcdob <> '635' AND movpcdob <> '306' AND movpcdob <> '0344' AND movpcdob <> '343')" +
                                " GROUP BY movpcdob, OB.OBRANOMB, OB.OBRADART, OB.OBRANCUI, OB.OBRAPORC_IVA, PF.PROFAFIP," +
                                " CASE WHEN ((UPPER(OB.OBRADART) = 'S' OR RIGHT(movppefa, 1) = '6') AND movpcdob <> '284') THEN movpdocp END, movppefa" +                                
                                " ORDER BY OB.OBRANOMB ASC";

                List<Encabezadostruct> list = new List<Encabezadostruct>();

                //ADHIERO A LA LISTA
                foreach (DataRow f in func.getColecciondatosamsis(c).Rows)
                {
                    list.Add(new Encabezadostruct
                    {
                        Letra = GetLetraaprobada(f["Letra"].ToString(), f["Cuit"].ToString().Trim()),
                        Paciente = Getcomprobpacinom(f["ART"].ToString().Trim(), f["Cuit"].ToString().Trim(), f["Paciente"].ToString().Trim()),
                        NroDocumento = Getcomprobpacidoc(f["ART"].ToString().Trim(), f["Cuit"].ToString().Trim(), f["NroDocumento"].ToString().Trim()),
                        ReceptorCodigo = f["Obra"].ToString().Trim(),
                        ReceptorNombre = f["Nombre"].ToString().Trim(),
                        ReceptorNombreAsoc = f["Nombre"].ToString().Trim(),
                        ReceptorPorcIva = Convert.ToDecimal(f["PorcIva"]),
                        ReceptorArt = f["ART"].ToString().Trim(),
                        ReceptorCuit = f["Cuit"].ToString().Trim(),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Gastos = Convert.ToDecimal(f["Gastos"]),
                        Honorarios = Convert.ToDecimal(f["Honorarios"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"])

                    });
                }

                //NUEVO AGRUPAMIENTO
                listaenc = list.GroupBy(r => new { r.ReceptorCodigo, r.Letra, r.NroDocumento })
                            .Select(cl => new Encabezadostruct
                            {
                                Letra = cl.First().Letra,
                                Paciente = cl.First().Paciente,
                                NroDocumento = cl.First().NroDocumento,
                                ReceptorCodigo = cl.First().ReceptorCodigo,
                                ReceptorCuit = cl.First().ReceptorCuit,
                                ReceptorNombre = cl.First().ReceptorNombre,
                                ReceptorArt = cl.First().ReceptorArt,
                                ReceptorNombreAsoc = cl.First().ReceptorNombreAsoc,
                                ReceptorPorcIva = cl.First().ReceptorPorcIva,
                                Neto = cl.Sum(s => s.Neto),
                                Gastos = cl.Sum(s => s.Gastos),
                                Honorarios = cl.Sum(s => s.Honorarios),
                                Iva = cl.Sum(s => s.Iva),
                                Total = cl.Sum(s => s.Total)

                            }).ToList();
                
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar la lista de pendientes", 0);
                return;
            }
        }

        public void ListaPendientes()
        {
            try
            {
                ListadoPendienteEnc.Clear();
                ListadoPendienteDet.Clear();

                //CARGO EN LISTA LAS PRESTATARIAS QUE ACEPTAN COMPROBANTE X
                Cargaaceptax();

                //CARGO LA LISTA DE PRESTATARIAS QUE EMITEN COMPROBANTE POR PACIENTE
                Cargacomprobsxpaciente();

                string per = BusqPeriododesde.Remove(BusqPeriododesde.Length - 1);

                if (BusqPeriododesde == "" || BusqPeriodohasta == "") { return; }

                //PREPARO ENCABEZADOS
                PrepararEncabezados(BusqPeriododesde, BusqPeriodohasta);

                DateTime fec = func.Getfechorserver();


                foreach (var es in listaenc)
                {
                    ListadoPendienteEnc.Add(new ComprobPE
                    {
                        Fecha = fec,
                        Periodo = per,
                        Letra = es.Letra,
                        Paciente = es.Paciente,
                        NroDocumento = es.NroDocumento,
                        ReceptorCodigo = es.ReceptorCodigo,
                        ReceptorNombre = es.ReceptorNombre,
                        ReceptorNombreAsoc = es.ReceptorNombreAsoc,
                        ReceptorPorcIva = es.ReceptorPorcIva,
                        ReceptorArt = es.ReceptorArt,
                        ReceptorCuit = es.ReceptorCuit,
                        Neto = es.Neto,
                        Gastos = es.Gastos,
                        Honorarios = es.Honorarios,
                        Iva = es.Iva,
                        Total = es.Total

                    });
                }

                //DETALLES GLOBAL
                GetDetallesglob();

                //ACTUALIZO PRESTATARIA
                Actualizareceptor();

                //ASIGNO DETALLES
                foreach (ComprobPE ce in ListadoPendienteEnc)
                {
                    ce.Detalles = GetDetalles(ce.IDComprobante, ce.ReceptorCodigo, ce.NroDocumento.ToString(), ce.ReceptorArt, ce.Letra,
                        ce.ReceptorCuit);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener la lista de pendientes.\n" + e.Message, 0);
                return;
            }
        }

        //CREO UNA LISTA CON LAS QUE ACEPTAN FACTURA X
        private void Cargaaceptax()
        {
            try
            {
                listaceptacmpx.Clear();

                string c = "SELECT ID_Registro, Cuit, AceptaCompx FROM PRESTATARIAS WHERE AceptaCompx = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    listaceptacmpx.Add(new Prestcomprobx
                    {
                        IDPrestataria = Convert.ToInt32(r["ID_Registro"]),
                        Cuit = Convert.ToInt64(r["Cuit"]),
                        Aceptax = Convert.ToBoolean(r["AceptaCompx"])
                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar las prestatarias y comprobantes X.\n" + e.Message, 0);
                return;
            }
        }

        //OBTENGO LA LETRA PARA EL COMPROBANTE (SI APROBO X O C POR DEFECTO)
        private string GetLetraaprobada(string letra, string cuitprest)
        {
            string retorno = "C";

            try
            {
                if (letra == "X" && listaceptacmpx.Where(r => r.Cuit == Convert.ToInt64(cuitprest)).Count() > 0) { retorno = "X"; }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //CONSULTO LAS PRESTATARIAS QUE GENERAN COMPROBANTE POR PACIENTE
        private void Cargacomprobsxpaciente()
        {
            try
            {
                listcomprobxpaciente.Clear();

                string c = "SELECT ID_Registro, Cuit, CompPaciente FROM PRESTATARIAS WHERE CompPaciente = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    listcomprobxpaciente.Add(new Prestcomprobx
                    {
                        IDPrestataria = Convert.ToInt32(r["ID_Registro"]),
                        Cuit = Convert.ToInt64(r["Cuit"]),
                        Comprobxpaciente = Convert.ToBoolean(r["CompPaciente"])
                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar las prestatarias y comprobantes por paciente.\n" + e.Message, 0);
                return;
            }
        }

        //OBTENGO EL NOMBRE DE PACIENTE (SI QUIERE COMPROB POR PACIENTE)
        private string Getcomprobpacinom(string art, string cuitprest, string ret)
        {
            string retorno = ret;

            try
            {
                if (art == "S" && listcomprobxpaciente.Where(r => r.Cuit == Convert.ToInt64(cuitprest)).Count() <= 0) { retorno = ""; }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //OBTENGO EL DOCUMENTO DE PACIENTE(SI QUIERE COMPROB POR PACIENTE)
        private long Getcomprobpacidoc(string art, string cuitprest, string ret)
        {
            long retorno = Convert.ToInt64(ret);

            try
            {
                if (art == "S" && listcomprobxpaciente.Where(r => r.Cuit == Convert.ToInt64(cuitprest)).Count() <= 0) { retorno = 0; }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //DETERMINO SI OBTIENE DETALLES COMO ART
        private bool Getdetallesart(string cuitprest)
        {
            bool retorno = true;

            try
            {
                if (listcomprobxpaciente.Where(r => r.Cuit == Convert.ToInt64(cuitprest)).Count() <= 0) { retorno = false; }

                return retorno;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //ACTUALIZO DATOS PRESTATARIA
        private void Actualizareceptor()
        {
            try
            {
                if (!func.hayConexion()) { return; }

                string cbu = GetCbucreditos();
                string alias = GetAliascreditos();
                var list = ListadoPendienteEnc.GroupBy(t => t.ReceptorCuit).Select(grp => grp.First()).ToList();
                long[] arrcuits = new long[list.Count];
                int f = 0;

                foreach (ComprobPE r in list)
                {
                    if (r.ReceptorCuit != "")
                    {
                        arrcuits[f] = Convert.ToInt64(r.ReceptorCuit);
                        f++;
                    }
                }

                if (arrcuits.Length <= 0) { return; }

                ListaPersonas ent = conspadron.GetEntidad(arrcuits, Application.StartupPath + @"\Afip\PROD\PD-CR20078779250.pfx", "2048", 20078779250);

                decimal valmipyme = func.GetMinimoPyme();

                CultureInfo ci = new CultureInfo("es-Es");
                ci = new CultureInfo("es-Es");
                TextInfo textInfo = ci.TextInfo;

                //RECORRO LA LISTA OBTENIDA DE AFIP
                if (ent.personaListReturn != null)
                {
                    foreach (Persona p in ent.personaListReturn.persona)
                    {
                        string dom = "";
                        string razons = "";
                        string ivanro = "";
                        string error = "";

                        //SI DEVUELVE CON UN ERROR DE AFIP
                        if (p.errorConstancia != null)
                        {
                            error = p.errorConstancia.error.ToString();

                            var l = ListadoPendienteEnc.Where(s => s.ReceptorCuit == p.errorConstancia.idPersona).ToList();

                            //ACTUALIZO EL RESTO DE REGISTROS REPETIDOS
                            foreach (var r in l)
                            {
                                r.ReceptorRazonin = error;
                            }

                        }

                        if (p.datosGenerales != null)
                        {
                            if (p.datosGenerales.razonSocial != null)
                            {
                                razons = textInfo.ToTitleCase(p.datosGenerales.razonSocial.ToLower());

                                if (p.datosGenerales.estadoClave.ToUpper() != "ACTIVO")
                                {
                                    var l = ListadoPendienteEnc.Where(s => s.ReceptorCuit == p.errorConstancia.idPersona).ToList();

                                    //ACTUALIZO EL RESTO DE REGISTROS REPETIDOS
                                    foreach (var r in l)
                                    {
                                        r.ReceptorActivo = false;
                                    }

                                    continue;
                                }
                            }

                            if (p.datosGenerales.domicilioFiscal != null)
                            {
                                dom = "";
                                if (p.datosGenerales.domicilioFiscal.direccion != null)
                                { dom += textInfo.ToTitleCase(p.datosGenerales.domicilioFiscal.direccion.ToLower()); }
                                if (p.datosGenerales.domicilioFiscal.localidad != null)
                                { dom += ", " + textInfo.ToTitleCase(p.datosGenerales.domicilioFiscal.localidad.ToLower()); }
                                if (p.datosGenerales.domicilioFiscal.codPostal != null)
                                { dom += " " + textInfo.ToTitleCase(p.datosGenerales.domicilioFiscal.codPostal.ToLower()); }
                                if (p.datosGenerales.domicilioFiscal.descripcionProvincia != null)
                                { dom += ", " + textInfo.ToTitleCase(p.datosGenerales.domicilioFiscal.descripcionProvincia.ToLower()); }

                            }

                            if (p.datosRegimenGeneral != null && p.datosRegimenGeneral.impuesto != null)
                            {
                                for (int m = 0; m < p.datosRegimenGeneral.impuesto.Count; m++)
                                {
                                    switch (p.datosRegimenGeneral.impuesto[m].idImpuesto)
                                    {
                                        case "30": ivanro = "1"; break;
                                        case "32": ivanro = "4"; break;
                                    }
                                }
                            }

                            string idperso = p.datosGenerales.idPersona;
                            var lista = ListadoPendienteEnc.Where(s => s.ReceptorCuit == idperso).ToList();

                            //OBTENGO LOS DIAS DE VENCIMIENTO PARA PRESTATARIAS EN FACTURAS DE CREDITO 211
                            int diasvto = GetDiasvtoreceptor(idperso);
                            //DETERMINO SI ES MIPYME
                            bool inclfce = GetMipyme(idperso);

                            //ACTUALIZO EL RESTO DE REGISTROS REPETIDOS
                            foreach (var r in lista)
                            {
                                if (razons != "") { r.ReceptorNombre = razons; }
                                if (dom != "") { r.ReceptorDomFiscal = dom; }
                                if (ivanro != "") { r.ReceptorIvanro = ivanro; }
                                if (ivanro == "1") { r.ReceptorIva = "RESP. INSCRIPTO"; }
                                else if (ivanro == "4") { r.ReceptorIva = "EXENTO"; }
                                r.ReceptorActivo = true;

                                //VALIDACION MIPYIME
                                if (inclfce && r.Total >= valmipyme)
                                {
                                    r.TipoComprobante = "FCE";
                                    r.PuntoVta = 13;
                                    r.EmisorCbu = cbu;
                                    r.EmisorAlias = alias;
                                    r.ReceptorDiasVto = diasvto;
                                }
                                else
                                {
                                    r.TipoComprobante = "FC";
                                    r.PuntoVta = 10;
                                    r.EmisorCbu = "";
                                    r.EmisorAlias = "";
                                }
                            }

                        }

                    }
                }

                //RECORRO TODOS AQUELLOS QUE NO TIENEN NUMERO DE IVA, Y
                //TRATO DE COMPLETARLOS CON DATOS DESDE BD ASOC
                var k = ListadoPendienteEnc.Where(r => r.ReceptorIvanro == "" && r.ReceptorCuit != "").ToList();

                foreach (ComprobPE r in k)
                {
                    string dom = GetPrestatdom(Convert.ToInt64(r.ReceptorCuit.Trim()));
                    string ivanro = GetPrestacndi(Convert.ToInt64(r.ReceptorCuit.Trim()));
                    int diasvto = GetDiasvtoreceptor(r.ReceptorCuit);
                    bool inclfce = GetMipyme(r.ReceptorCuit);

                    r.ReceptorDomFiscal = dom;
                    r.ReceptorIvanro = ivanro;
                    if (ivanro == "1") { r.ReceptorIva = "RESP. INSCRIPTO"; }
                    else if (ivanro == "4") { r.ReceptorIva = "EXENTO"; }
                    r.ReceptorActivo = true;

                    //VALIDACION MIPYIME
                    if (inclfce && r.Total >= valmipyme)
                    {
                        r.TipoComprobante = "FCE";
                        r.PuntoVta = 13;
                        r.EmisorCbu = cbu;
                        r.EmisorAlias = alias;
                        r.ReceptorDiasVto = diasvto;
                    }
                    else
                    {
                        r.TipoComprobante = "FC";
                        r.PuntoVta = 10;
                        r.EmisorCbu = "";
                        r.EmisorAlias = "";
                    }

                }
            }
            catch (Exception e)
            {
                int r = e.HResult;
                ctrl.MensajeInfo("Ocurrió un error al actualizar los datos del receptor.\n" + e.Message, 0);
                return;
            }
        }

        //TRATO DE OBTENER LA DIRECCION DE LA PRESTATARIA
        private string GetPrestatdom(long cuit)
        {
            try
            {
                string retorno = "";

                if (cuit <= 0) { return retorno; }

                string c = "SELECT DomicilioFiscal" +
                           " FROM PRESTATARIAS" +
                           " WHERE Cuit = " + cuit;

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    retorno = f["DomicilioFiscal"].ToString();
                }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al consultar el domicilio legal de la prestataria.\n" + e.Message, 0);
                return "";
            }
        }

        //TRATO DE OBTENER LA CONDICION IVA DE LA PRESTATARIA
        private string GetPrestacndi(long cuit)
        {
            try
            {
                string retorno = "";

                if (cuit <= 0) { return retorno; }

                string c = "SELECT ID_Iva " +
                           " FROM PRESTATARIAS" +
                           " WHERE Cuit = " + cuit;

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    retorno = f["ID_Iva"].ToString();
                }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al consultar la condicion de la prestataria.\n" + e.Message, 0);
                return "";
            }
        }

        //OBTENGO LOS DIAS DE VENCIMIENTO PARA LA PRESTATARIA 
        public int GetDiasvtoreceptor(string cuit)
        {
            try
            {
                int retorno = 0;

                if (cuit == "") { return retorno; }

                string c = "SELECT DiasVencimiento FROM PRESTATARIAS WHERE Cuit = " + cuit;

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    retorno = Convert.ToInt32(f["DiasVencimiento"]);
                }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al consultar los dias de vencimiento.\n" + e.Message, 0);
                return 0;
            }
        }

        //CONSULTO SI INCLUYE FACTURAS FCE
        private bool GetMipyme(string cuit)
        {
            try
            {
                bool retorno = false;

                if (cuit == "") { return retorno; }

                string c = "SELECT MiPyme FROM PRESTATARIAS WHERE Cuit = " + cuit;

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    retorno = Convert.ToBoolean(f["MiPyme"]);
                }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al consultar los dias de vencimiento.\n" + e.Message, 0);
                return false;
            }
        }

        //OBTENGO LA LISTA DE DETALLES GLOBAL, PARA ACELERAR EL PROCESO
        private void GetDetallesglob()
        {

            try
            {
                if (BusqPeriododesde == "" || BusqPeriodohasta == "") { return; }

                string consulta = "SELECT movppefa as Periodo, movpcdob AS Obra, OB.OBRANOMB as Nombre," +
                                  " ISNULL(OB.OBRANCUI, 0) AS Cuit, ISNULL(movppaci,'') as Paciente," +
                                  " IIF(ISNULL(LEFT(movpdocp, PATINDEX('%[^0-9]%', movpdocp + 't') - 1),0) = 0, 0, LEFT(movpdocp, PATINDEX('%[^0-9]%', movpdocp + 't') - 1)) as NroDocumento," +
                                  " movpcant as Cantidad, movpneto as Neto, movpiiva as Iva, movpgast as Gastos," +
                                  " movphono as Honorarios, movptoim as Total, movpcoda AS Puntero, movpfunc as Funcion," +
                                  " movpcomp as Descripcion," +
                                  " IIF(ISNULL(OB.OBRAPORC_IVA, 0) > 0 AND PF.PROFAFIP = '1' AND ISNULL(OB.OBRADART, '') <> 'S', 'X','C') AS Letra," +
                                  " SUBSTRING(movppefa, LEN(movppefa), LEN(movppefa)) AS Origen," +
                                  " movpcopr as CodProfesional, PF.PROFAPNO AS Profesional, PF.PROFAFIP," +
                                  " ISNULL(movpprac,'') AS CodPractica, ISNULL(movpdesc,'') as DescPractica," +
                                  " ISNULL(FORMAT(movpfepr,'dd/MM/yyyy'), '') AS FechaPractica" +
                                  " FROM ASOCTRAN" +
                                  " LEFT OUTER JOIN ASOCOBRA OB ON(OB.OBRACODI = movpcdob)" +
                                  " LEFT OUTER JOIN ASOCPROF PF ON(PF.PROFCODI = movpcopr)" +
                                  " WHERE (movppefa = '" + BusqPeriododesde + "' OR movppefa = '" + BusqPeriodohasta + "')" +
                                  //" WHERE (movppefa = '202111X')" +
                                  " AND (movpcomAM IS NULL OR RTRIM(LTRIM(movpcomAM)) = '')" +
                                  " AND (movpcdob <> '444' AND movpcdob <> '437' AND movpcdob <> '741' AND movpcdob <> '635' AND movpcdob <> '306' AND movpcdob <> '0344' AND movpcdob <> '343')" +
                                  " ORDER BY movppefa ASC";

                foreach (DataRow f in func.getColecciondatosamsis(consulta).Rows)
                {
                    ListadoPendienteDet.Add(new ComprobPD
                    {
                        Periodo = f["Periodo"].ToString(),
                        Fecha = f["Periodo"].ToString(),
                        CodigoObra = f["Obra"].ToString().Trim(),
                        Descripcion = f["Descripcion"].ToString().Trim().Replace("'", ""),
                        DocumPaciente = f["NroDocumento"].ToString().Trim(),
                        NombrePaciente = f["Paciente"].ToString().Trim().Replace("'", ""),
                        Cantidad = Convert.ToDecimal(f["Cantidad"]),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Gastos = Convert.ToDecimal(f["Gastos"]),
                        Honorarios = Convert.ToDecimal(f["Honorarios"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        Puntero = Convert.ToInt64(f["Puntero"]),
                        Concepto = GetConcepto(f["Funcion"].ToString()),
                        LetraComprob = GetLetraaprobada(f["Letra"].ToString(), f["Cuit"].ToString()),
                        Origen = f["Origen"].ToString(),
                        CodProfesional = f["CodProfesional"].ToString(),
                        Profesional = f["Profesional"].ToString(),
                        ProfCond = f["PROFAFIP"].ToString(),
                        CodPractica = f["CodPractica"].ToString().Trim(),
                        DescPractica = f["DescPractica"].ToString().Trim(),
                        FechaPractica = f["FechaPractica"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al importar los detalles.\n" + e.Message, 0);
                return;
            }
        }

        private string GetConcepto(string func)
        {
            switch (func)
            {
                case "99": return "1";
                case "10": return "1";
                case "92": return "1";
                case "20": return "1";
                case "96": return "1";
                case "60": return "2";
                case "91": return "2";
                default: return "3";
            }
        }

        //OBTENGO LOS DETALLES DE UN ENCABEZADO Y RETORNO LA LISTA FILTRADA
        private List<ComprobPD> GetDetalles(string guid, string codobra, string docpaci, string art, string letra, string cuit)
        {

            try
            {

                if ((art == "S" && Getdetallesart(cuit)) || (docpaci != "0" && docpaci != ""))
                {
                    var list = ListadoPendienteDet.Where(s => s.CodigoObra == codobra && s.DocumPaciente == docpaci && s.LetraComprob == letra).ToList();

                    foreach (var r in list)
                    {
                        r.IDEncabezado = guid;
                    }

                    return list;
                }
                else
                {
                    var list = ListadoPendienteDet.Where(s => s.CodigoObra == codobra && s.LetraComprob == letra).ToList();

                    foreach (var r in list)
                    {
                        r.IDEncabezado = guid;
                    }

                    return list;
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener la lista detalles de pendientes.\n" + e.Message, 0);
                throw;
            }
        }

        //RETORNO EL ID DE LA PRESTATARIA (LO GUARDO SI NO EXISTE)
        private int GetIdPrestatria(ComprobPE e)
        {
            int retorno = 0;

            try
            {
                //VALIDO SI EXISTE LA PRESTATARIA
                int idprestataria = ExistePrestataria(Convert.ToInt64(e.ReceptorCuit), e);

                if (idprestataria <= 0)
                {
                    AltaPrestataria(e);
                    idprestataria = ExistePrestataria(Convert.ToInt64(e.ReceptorCuit), e);
                }

                if (idprestataria == 0) { return 0; }

                int iddetalle = ExisteCodDetalle(e, idprestataria);

                if (iddetalle <= 0)
                {
                    AltaPresDetalle(e, idprestataria);
                    iddetalle = ExisteCodDetalle(e, idprestataria);
                }

                //VALIDO SI EXISTE EL CODIGO EN EL DETALLE DE LA PRESTATARIA
                retorno = iddetalle;

                //RETORNO
                return retorno;
            }
            catch (Exception x)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el id de la prestataria.\n" + x.Message, 0);
                return retorno;
            }
        }

        //EXISTE PRESTATARIA
        private int ExistePrestataria(long cuit, ComprobPE e)
        {
            int retorno = 0;

            try
            {
                string consulta = "SELECT ID_Registro FROM PRESTATARIAS WHERE Cuit = " + cuit;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                { retorno = Convert.ToInt32(f["ID_Registro"]); }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //EXISTE EL CODIGO EN DETALLES
        private int ExisteCodDetalle(ComprobPE e, int idprestataria)
        {
            int retorno = 0;

            try
            {
                string consulta = "SELECT ID_Registro FROM PRESTDETALLES WHERE Codigo = '" + e.ReceptorCodigo + "'";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                { retorno = Convert.ToInt32(f["ID_Registro"]); }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //ALTA DE PRESTATARIA
        private void AltaPrestataria(ComprobPE e)
        {
            try
            {
                if (!e.ReceptorActivo || e.ReceptorIvanro == "") { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Nombre");
                campos.Add("Cuit");
                campos.Add("ID_Iva");
                campos.Add("DomicilioFiscal");
                campos.Add("Art");

                parametros.Add(e.ReceptorNombre);
                parametros.Add(e.ReceptorCuit);
                parametros.Add(Convert.ToInt16(e.ReceptorIvanro));
                parametros.Add(e.ReceptorDomFiscal);
                if (e.ReceptorArt == "S") { parametros.Add(1); } else { parametros.Add(0); }

                func.AccionBD(campos, parametros, "I", "PRESTATARIAS");

            }
            catch (Exception x)
            {

                ctrl.MensajeInfo("Ocurrió un error al insertar la prestataria.\n" + x.Message, 0);
                return;
            }
        }

        //ALTA DE DETALLE DE PRESTATARIA
        private void AltaPresDetalle(ComprobPE e, int idprestataria)
        {
            try
            {
                if (!e.ReceptorActivo || e.ReceptorIvanro == "") { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_Prestataria");
                campos.Add("Codigo");
                campos.Add("Descripcion");
                campos.Add("PorcIva");

                parametros.Add(idprestataria);
                parametros.Add(e.ReceptorCodigo);
                parametros.Add(e.ReceptorNombreAsoc);
                parametros.Add(e.ReceptorPorcIva);

                func.AccionBD(campos, parametros, "I", "PRESTDETALLES");

            }
            catch (Exception x)
            {

                ctrl.MensajeInfo("Ocurrió un error al insertar la prestataria.\n" + x.Message, 0);
                return;
            }
        }

        //ABM DE FACTURAS A PRESTATARIAS X Y E
        private void ABMFactuprestat()
        {
            try
            {
                if (ListadoPendienteEnc.Count <= 0) { return; }

                ArrayList campos = new ArrayList(Camposfactambu());

                ArrayList parametros = new ArrayList();
                DateTime fechahoy = func.Getfechorserver();
                SqlConnection con = conn.Conectar();

                //RECORRO LA LISTA DE ENCABEZADOS DE FACTURA
                foreach (ComprobPE e in ListadoPendienteEnc)
                {
                    Procesadas++;

                    EsperaConexion();

                    //SI LA PRESTATARIA NO ESTA DISPONIBLE EN AFIP
                    if (!e.ReceptorActivo || e.ReceptorIva == "") { e.Estado = "R"; continue; }

                    int idprestataria = GetIdPrestatria(e);
                    e.Fecha = fechahoy;

                    if (e.Letra == "C")
                    {
                        if (Procesoafip(e) < 0)
                        {
                            ctrl.MensajeInfo("Hay inconvenientes de conexión con AFIP,\n" +
                               "toda la operación se interrumpirá para evitar errores.\n" +
                               "Intente nuevamente más tarde.", 1);
                            break;
                        }
                    }
                    else
                    {
                        e.Numero = func.GetNumerox(e.TipoComprobante); e.Estado = "A";
                        e.FechaVtoPago = DateTime.Now;
                    }

                    parametros.Clear();

                    parametros.Add(e.Periodo);
                    parametros.Add(e.Fecha);
                    parametros.Add(e.FechaVtoPago);
                    parametros.Add(e.TipoComprobante);
                    parametros.Add(e.Letra);
                    parametros.Add(e.PuntoVta);
                    parametros.Add(e.Numero);
                    parametros.Add(e.Paciente);
                    parametros.Add(e.NroDocumento);
                    parametros.Add(idprestataria); //ID PRESTATARIA
                    parametros.Add(e.ReceptorNombre);
                    parametros.Add(e.ReceptorCuit);
                    parametros.Add(e.ReceptorIvanro);
                    parametros.Add(e.ReceptorDomFiscal);
                    parametros.Add(e.EmisorCbu);
                    parametros.Add(e.EmisorAlias);
                    parametros.Add(e.IDComprobante);
                    parametros.Add(e.Neto);
                    parametros.Add(e.Gastos);
                    parametros.Add(e.Honorarios);
                    parametros.Add(e.Iva);
                    parametros.Add(e.Total);
                    if (e.FechaDesde != null && e.FechaDesde != "") { parametros.Add(Convert.ToDateTime(e.FechaDesde)); } else { parametros.Add(DBNull.Value); }
                    if (e.FechaHasta != null && e.FechaHasta != "") { parametros.Add(Convert.ToDateTime(e.FechaHasta)); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Estado);
                    parametros.Add(e.CaeNro);
                    parametros.Add(e.NumeroBarras);
                    if (e.FechaVtoCae != null && e.FechaVtoCae != "") { parametros.Add(Convert.ToDateTime(e.FechaVtoCae)); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Observaciones);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);

                    EsperaConexion();

                    func.AccionBD2(camposlist: campos, parametros: parametros, accion: "I", tabla: "FACTPRESENC",
                        conn: con);

                    //DETALLES DE ENCABEZADO
                    Abmdetalles(e.Detalles, GetIdfactura(e.IDComprobante), con);

                    //ACTUALIZO NUMERO DE COMPROBANTE X
                    if (e.Letra == "X") { func.SetNumerox(e.Numero, e.TipoComprobante); }

                    //ACTUALIZO LA BD DE ASOC CON LOS GUID GENERADOS (Solo aquellos aprobados) SI NO SE PRODUJO UN
                    //BREAK
                    ActualizaAsoc(GetIdfactura(e.IDComprobante));
                }

                Procesadas = 0;

                conn.Desconectar();

                //LIMPIO LOS COMPONENTES
                Limpiar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el encabezado facturas.\n" + e.Message, 0);
                return;
            }
        }

        //VOID PARA ESPERA POR CONEXION
        private void EsperaConexion()
        {
            if (!func.hayConexion())
            {
                ctrl.MensajeInfo("La conexión a internet fue interrumpida.\nEl proceso quedará en pausa hasta que se" +
                    " logre retomar la conexión.", 1);

                while (!func.hayConexion())
                { }

            }
        }

        //OBTENGO EL ID DE LA FACTURA SEGUN SU GUID
        public long GetIdfactura(string guid)
        {
            try
            {
                string consulta = "SELECT ID_Registro FROM FACTPRESENC WHERE Guid = '" + guid + "'";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { return Convert.ToInt64(f["ID_Registro"]); }

                return 0;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el id de la factura.\n" + e.Message, 0);
                return 0;
            }
        }

        //CAMPOS DE LA TABLA FACTURA
        public ArrayList Camposfactambu()
        {

            ArrayList campos = new ArrayList();

            campos.Add("Periodo");
            campos.Add("Fecha");
            campos.Add("FechaVtoPago");
            campos.Add("TipoComprobante");
            campos.Add("Letra");
            campos.Add("PuntoVenta");
            campos.Add("Numero");
            campos.Add("Paciente");
            campos.Add("NroDocumento");
            campos.Add("ID_PrestDetalle");
            campos.Add("NombrePres");
            campos.Add("CuitPres");
            campos.Add("IvaPres");
            campos.Add("DomFiscalPres");
            campos.Add("Cbu");
            campos.Add("Alias");
            campos.Add("Guid");
            campos.Add("Neto");
            campos.Add("Gastos");
            campos.Add("Honorarios");
            campos.Add("Iva");
            campos.Add("Total");
            campos.Add("FechaDesde");
            campos.Add("FechaHasta");
            campos.Add("EstadoAf");
            campos.Add("CaeNroAf");
            campos.Add("BarrasAf");
            campos.Add("VtoCaeAf");
            campos.Add("ObservAf");
            campos.Add("ID_UsuNew");
            campos.Add("TimeNew");
            campos.Add("ID_UsuModif");
            campos.Add("TimeModif");

            return campos;
        }

        //LIMPIO LOS COMPONENTES UNA VEZ FINALIZADAS LAS OPERACIONES
        private void Limpiar()
        {
            try
            {
                ListadoPendienteEnc.Clear();
                ListadoPendienteEnc.Clear();
                Procesadas = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //ENVIO LA FACTURA A AFIP 
        private sbyte Procesoafip(ComprobPE enc)
        {
            try
            {
                sbyte retorno = 1;

                //HAGO EL LOGIN
                if (!func.LoginAfip(1, "30567506769", afipprod: afip))
                {
                    ctrl.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return -1;
                }

                //LETRA DE COMPROBANTE
                string letra = func.GetLetracomprob(4, Convert.ToInt16(enc.ReceptorIvanro), enc.Iva, false);

                short c1 = 0, c2 = 0, c3 = 0;

                //IVA Y CONCEPTO
                foreach (ComprobPD d in enc.Detalles)
                {
                    //CONCEPTO
                    if (d.Concepto == "1") { c1 += 1; }
                    else if (d.Concepto == "2") { c2 += 1; }
                    else if (d.Concepto == "3") { c3 += 1; }
                }

                //CONCEPTO P2
                int concep = 2;
                if (c2 == 0 && c3 == 0) { concep = 1; }
                else if (c1 == 0 && c2 == 0) { concep = 3; }

                //OPCIONALES
                if (enc.TipoComprobante == "FCE" || enc.TipoComprobante == "NCE" || enc.TipoComprobante == "NDE")
                {
                    afip.setOpcionales(enc.EmisorCbu, enc.EmisorAlias);

                    if (enc.TipoComprobante == "FCE")
                    {
                        afip.setOpcionaltipotrans("SCA");
                    }

                }

                DateTime fechavtofce = enc.Fecha;

                if (enc.TipoComprobante == "FCE")
                {
                    fechavtofce = enc.Fecha.AddDays(enc.ReceptorDiasVto);

                    if (enc.ReceptorCuit == "30654855168")
                    {
                        fechavtofce = func.Trydatetimeconvert(Fechasvtowissmg(enc.Fecha, fechavtofce));
                    }
                    else
                    {
                      /*  if (fechavtofce.Day > 10)
                        {
                            int dias = DateTime.DaysInMonth(fechavtofce.Year, fechavtofce.Month) - fechavtofce.Day;

                            fechavtofce = fechavtofce.AddDays(dias + 1);
                        }*/
                    }

                }
                else
                {
                    fechavtofce = enc.Fecha;
                }

                afip.agregaFactura(1, enc.Fecha.ToString("yyyyMMdd"), enc.PuntoVta, "CUIT", Convert.ToInt64(enc.ReceptorCuit), //ENCABEZADO
                concep, enc.Total, 0, enc.Total, 0, 0, 0, "pesos", 1, //IMPORTES
                enc.Fecha.ToString("yyyyMMdd"), enc.Fecha.AddDays(10).ToString("yyyyMMdd"), fechavtofce.ToString("yyyyMMdd"),//FECHAS SRV
                enc.TipoComprobante, letra);


                if (afip.Estado) { enc.Estado = "A"; } else { enc.Estado = "R"; }

                enc.Letra = letra;
                enc.Numero = afip.Nrofactura;
                enc.CaeNro = afip.Caenumero;
                enc.NumeroBarras = afip.CodigoBarras;
                enc.FechaDesde = enc.Fecha.ToString("dd-MM-yyyy");
                enc.FechaHasta = enc.Fecha.ToString("dd-MM-yyyy");
                enc.FechaVtoPago = fechavtofce;

                if (afip.Fechavtocae != null && afip.Fechavtocae != "" && enc.Estado != "R")
                {
                    string date = "";
                    date = afip.Fechavtocae.Substring(0, 4) + "-" + afip.Fechavtocae.Substring(4, 2) + "-" + afip.Fechavtocae.Substring(6, 2);
                    enc.FechaVtoCae = date;
                }

                enc.Observaciones = afip.Observaciones;

                return retorno;
            }
            catch (Exception)
            {
                //ctrl.MensajeInfo("Ocurrió un error al notificar la factura a AFIP.\n" + e.Message, 0);
                return -1;
            }
        }

        public string Fechasvtowissmg(DateTime fecemis, DateTime fechavto)
        {
            string retorno = "";
            try
            {
                if (fecemis.Year == 2021 && fecemis.Month == 1) { retorno = "2021-04-01"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 2) { retorno = "2021-05-03"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 3) { retorno = "2021-06-01"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 4) { retorno = "2021-07-01"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 5) { retorno = "2021-08-02"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 6) { retorno = "2021-09-01"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 7) { retorno = "2021-10-01"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 8) { retorno = "2021-11-01"; }
                else if (fecemis.Year == 2021 && fecemis.Month == 9) { retorno = "2021-12-01"; }
                else { retorno = fechavto.ToString("yyyy-MM-dd"); }

                return retorno;
            }
            catch (Exception)
            {

                return retorno;
            }
        }


        private sbyte ProcesoafipNc(ComprobPE enc, string tipo, bool nulaprevia)
        {
            try
            {
                sbyte retorno = 1;

                //HAGO EL LOGIN 
                if (!func.LoginAfip(1, "30567506769", afipprod: afip))
                {
                    ctrl.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return -1;
                }

                //LETRA DE COMPROBANTE
                string letra = func.GetLetracomprob(4, Convert.ToInt16(enc.ReceptorIvanro), enc.Iva, false);

                short c1 = 0, c2 = 0, c3 = 0;
                
                //IVA Y CONCEPTO
                foreach (ComprobPD d in enc.Detalles)
                {
                    //CONCEPTO
                    if (d.Concepto == "1") { c1 += 1; }
                    else if (d.Concepto == "2") { c2 += 1; }
                    else if (d.Concepto == "3") { c3 += 1; }
                }


                //CONCEPTO P2
                int concep = 2;
                if (c2 == 0 && c3 == 0) { concep = 1; }
                else if (c1 == 0 && c2 == 0) { concep = 3; }

                //OPCIONALES Y REFERENCIAS
                if (tipo == "NCE" || tipo == "NDE")
                {
                    /*if (tipo == "NCE" && Gettotalfactura(enc.ID_Factura) >= enc.Total)
                    { afip.setOpcionales("", "", "N"); }
                    else { afip.setOpcionales("", "", "N"); }*/

                    afip.setOpcionales("", "", nulaprevia ? "S" : "N");

                    //30567506769 
                    afip.setCompasociados(enc.TipoComprobante + enc.Letra, enc.PuntoVta, enc.Numero, "30567506769", enc.FechaFactura.ToString("yyyyMMdd"));
                }
                else { afip.setCompasociados(enc.TipoComprobante + enc.Letra, enc.PuntoVta, enc.Numero, fechafce: enc.FechaFactura.ToString("yyyyMMdd")); }


                afip.agregaFactura(1, func.Getfechorserver().ToString("yyyyMMdd"), enc.PuntoVta, "CUIT", Convert.ToInt64(enc.ReceptorCuit), //ENCABEZADO
                concep, enc.Total, 0, enc.Total, 0, 0, 0, "pesos", 1, //IMPORTES
                enc.Fecha.ToString("yyyyMMdd"), enc.Fecha.AddDays(10).ToString("yyyyMMdd"), enc.Fecha.AddDays(enc.ReceptorDiasVto).ToString("yyyyMMdd"),//FECHAS SRV
                tipo, letra);

                if (afip.Estado) { enc.Estado = "A"; } else { enc.Estado = "R"; }

                enc.Letra = letra;
                enc.Numero = afip.Nrofactura;
                enc.CaeNro = afip.Caenumero;
                enc.NumeroBarras = afip.CodigoBarras;
                enc.FechaDesde = enc.Fecha.ToString("dd-MM-yyyy");
                enc.FechaHasta = enc.Fecha.ToString("dd-MM-yyyy");

                if (afip.Fechavtocae != null && afip.Fechavtocae != "" && enc.Estado != "R")
                {
                    string date = "";
                    date = afip.Fechavtocae.Substring(0, 4) + "-" + afip.Fechavtocae.Substring(4, 2) + "-" + afip.Fechavtocae.Substring(6, 2);
                    enc.FechaVtoCae = date;
                }

                enc.Observaciones = afip.Observaciones;

                return retorno;
            }
            catch (Exception e)
            {
                int r = e.HResult;                
                return -1;
            }
        }

        // OBTENGO EL CBU DE PARA FACTURAS DE CREDITO
        public string GetCbucreditos()
        {
            try
            {
                string retorno = "";

                string c = "SELECT Cbu FROM PARAMSCBU WHERE Codigo = 'fccpres'";

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    retorno = f["Cbu"].ToString();
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar el Cbu.\n" + e.Message, 0);
                return "";
            }
        }

        // OBTENGO EL ALIAS DE PARA FACTURAS DE CREDITO
        public string GetAliascreditos()
        {
            try
            {
                string retorno = "";

                string c = "SELECT Alias FROM PARAMSCBU WHERE Codigo = 'fccpres'";

                foreach (DataRow f in func.getColecciondatos(c).Rows)
                {
                    retorno = f["Alias"].ToString();
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar el Alias.\n" + e.Message, 0);
                return "";
            }
        }

        //ACTUALIZO GUID EN BD ASOC
        private void ActualizaAsoc(long idfactura)
        {
            try
            {
                if (idfactura <= 0) { return; }
            
                EsperaConexion();

                ConexionAmdgoSis con = new ConexionAmdgoSis();
                SqlConnection cn = con.Conectar();
                DateTime fec = func.Getfechorserver();

                string query = "UPDATE [AmdgoSis].[dbo].[ASOCTRAN] set movpcomAM = ISNULL(CONCAT(Ltrim(Rtrim(SIT1.Letra)), '', " +
                        " FORMAT(SIT1.PuntoVenta, '0000'), '-', FORMAT(SIT1.Numero,'00000000')), '')" +
                        " FROM [AmdgoSis].[dbo].[ASOCTRAN] AS AMT" +
                        " LEFT OUTER JOIN[AmdgoInterno].[dbo].[FACTPRESDET] SIT ON(AMT.movpcoda = SIT.Puntero)" +
                        " LEFT OUTER JOIN[AmdgoInterno].[dbo].[FACTPRESENC] SIT1 ON(SIT1.ID_Registro = SIT.ID_Encabezado)" +                        
                        " WHERE SIT1.EstadoAf = 'A' AND SIT1.ID_Registro = " + idfactura;

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
              
                con.Desconectar();
            }
            catch (Exception x)
            {

                ctrl.MensajeInfo("Ocurrió un error al actualizar el id en asoc.\n" + x.Message, 0);
                return;
            }
        }

        //DETALLES DE LA FACTURA
        private void Abmdetalles(List<ComprobPD> d, long idencabezado, SqlConnection con)
        {            
            try
            {
                EsperaConexion();

               if (idencabezado <= 0) { return; }                
                  
                string qry = "";
                int contador = 0;
                int acumulado = 0;
                        

                try
                {
                    foreach (ComprobPD de in d)
                    {
                                
                        qry += "INSERT INTO FACTPRESDET (ID_Encabezado, Periodo, Descripcion, NroDocumento, Paciente, " +
                            "Cantidad, Neto, Gastos, Honorarios, Iva, Total, Guid, Puntero, Origen," +
                            " CodProfesional, Profesional, ProfCndIva, FechaPractica, CodPractica, DescPractica) VALUES ";


                        qry += "(" + idencabezado + ", '" + de.Periodo + "', '" + de.Descripcion + "', " + de.DocumPaciente + ", '"
                            + de.NombrePaciente + "', " + de.Cantidad.ToString().Replace(",", ".") + ", " +
                            de.Neto.ToString().Replace(",", ".") + ", " + de.Gastos.ToString().Replace(",", ".") +
                            ", " + de.Honorarios.ToString().Replace(",", ".") + ", " + de.Iva.ToString().Replace(",", ".") +
                            ", " + de.Total.ToString().Replace(",", ".") + ", '" + de.IDEncabezado +
                            "', " + de.Puntero + ", '" + de.Origen + "', " + "'" + de.CodProfesional.Trim() + "', '" +
                                de.Profesional.Trim() + "', '" + de.ProfCond + "', '" + de.FechaPractica + "', '" +
                                de.CodPractica + "', '" + de.DescPractica + "')";

                        if (contador == 1000 || ((d.Count - 1) == acumulado))
                        {
                            using (SqlTransaction transaction = con.BeginTransaction())
                            {
                                using (var command = new SqlCommand())
                                {
                                    if(qry != "")
                                    {
                                        command.Connection = con;
                                        command.Transaction = transaction;
                                        command.CommandType = CommandType.Text;
                                        command.CommandText = qry;
                                        command.ExecuteNonQuery();
                                        transaction.Commit();
                                    }
                                    
                                }
                            }      
                                        
                            qry = "";
                            contador = 0;
                        }

                        acumulado++;
                        contador++;

                    }
                                       
                }
                catch (Exception)
                {
                    //transaction.Rollback();

                    throw;
                }
                   
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el detalle de la factura.\n" + e.Message, 0);
                return;

            }
        }
        
        //GENERO NOTA DE CREDITO A COMPROBANTE FC
        public void GeneraNCD(List<ComprobPE> Listafacturas, long idfactura, decimal importe, string tipo, bool nulaprevia)
        {
            try
            {
                List<ComprobPE> comprobantes = new List<ComprobPE>();

                foreach (ComprobPE f in Listafacturas)
                {
                    comprobantes.Add(new ComprobPE
                    {
                        TipoComprobante = f.TipoComprobante,
                        Fecha = func.Getfechorserver(),
                        FechaFactura = f.Fecha,
                        Letra = f.Letra.Trim(),
                        PuntoVta = f.PuntoVta,
                        Numero = f.Numero,
                        ID_Prestataria = f.ID_Prestataria,
                        ReceptorCodigo = f.ReceptorCodigo,
                        ReceptorDomFiscal = f.ReceptorDomFiscal,
                        ReceptorNombre = f.ReceptorNombre,
                        ReceptorCuit = f.ReceptorCuit,
                        ReceptorIva = f.ReceptorIva,
                        ReceptorIvanro = f.ReceptorIvanro,
                        EmisorCbu = f.EmisorCbu,
                        EmisorAlias = f.EmisorAlias,
                        Honorarios = 0,
                        Gastos = 0,
                        Neto = importe,
                        Total = importe,
                        ID_Factura = idfactura, 
                        Comprobante = f.TipoComprobante + " " + f.Letra + " " + f.PuntoVta.ToString("0000") + "-" + f.Numero.ToString("00000000")
                    });
                }

                ABMFactuambuNCD(comprobantes, importe, tipo, nulaprevia);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al procesar el comprobante.\n" + e.Message,0 );
                return;
            }
        }
        
        //ALTA DE FACTURAS NOTAS DE CREDITO DEBITO
        private void ABMFactuambuNCD(List<ComprobPE> Listafacturas,  decimal importe, string tipo, bool nulaprevia)
        {
            try
            {
                
                if (Listafacturas.Count <= 0) { return; }

                ArrayList campos = new ArrayList(Camposfactambu());

                ArrayList parametros = new ArrayList();
                DateTime fechahoy = func.Getfechorserver();
                
                //RECORRO LA LISTA DE ENCABEZADOS DE FACTURA
                foreach (ComprobPE e in Listafacturas)
                {
                    GlobalIDcomp = 0;
                    Procesadas++;

                    if (!func.hayConexion()) { ctrl.MensajeInfo("La conexión a internet fue interrumpida.\nEl proceso debe ser retomado.", 1); return; }

                    //SI LA PRESTATARIA NO ESTA DISPONIBLE EN AFIP
                    if (!e.ReceptorActivo || e.ReceptorIva == "") { e.Estado = "R"; continue; }


                    //SI SE PRETENDE HACER FACTURAS DE CREDITO SIN CBU O ALIAS
                    if ((tipo == "NCE" || tipo == "NDE") && e.EmisorCbu == "")
                    {
                        continue;
                    }

                    e.Fecha = fechahoy;

                    if (ProcesoafipNc(e, tipo, nulaprevia) < 0)
                    {
                        ctrl.MensajeInfo("Hay inconvenientes de conexión con AFIP,\n" +
                                "toda la operación se interrumpirá para evitar errores.\n" +
                                "Intente nuevamente más tarde.", 1);
                        break;
                    }
                    
                    parametros.Clear();

                    parametros.Add(e.Periodo);
                    parametros.Add(e.Fecha);
                    parametros.Add(e.Fecha);
                    parametros.Add(tipo);
                    parametros.Add(e.Letra);
                    parametros.Add(e.PuntoVta);
                    parametros.Add(e.Numero);
                    parametros.Add(e.Paciente);
                    parametros.Add(e.NroDocumento);
                    parametros.Add(e.ID_Prestataria);
                    parametros.Add(e.ReceptorNombre);
                    parametros.Add(e.ReceptorCuit);
                    parametros.Add(e.ReceptorIvanro);
                    parametros.Add(e.ReceptorDomFiscal);
                    parametros.Add(e.EmisorCbu);
                    parametros.Add(e.EmisorAlias);
                    parametros.Add(e.IDComprobante);
                    parametros.Add(e.Neto);
                    parametros.Add(e.Gastos);
                    parametros.Add(e.Honorarios);
                    parametros.Add(e.Iva);
                    parametros.Add(e.Total);
                    if (e.FechaDesde != null && e.FechaDesde != "") { parametros.Add(Convert.ToDateTime(e.FechaDesde)); } else { parametros.Add(DBNull.Value); }
                    if (e.FechaHasta != null && e.FechaHasta != "") { parametros.Add(Convert.ToDateTime(e.FechaHasta)); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Estado);
                    parametros.Add(e.CaeNro);
                    parametros.Add(e.NumeroBarras);
                    if (e.FechaVtoCae != null && e.FechaVtoCae != "") { parametros.Add(Convert.ToDateTime(e.FechaVtoCae)); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Observaciones);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);

                    func.AccionBD(campos, parametros, "I", "FACTPRESENC");
                    
                    //COMPROBANTES ASOCIADOS
                    GuardorelacionNC(e.ID_Factura, e.IDComprobante, tipo);

                    GlobalIDcomp = GetIdfactura(e.IDComprobante);
                    
                    //ASOCIO EN ASOC SIS BD
                    GeneraRelasoctran(GlobalIDcomp, e.Comprobante, e.TipoComprobante, e.Letra, e.PuntoVta, e.Numero, e.Total);
                }

                Procesadas = 0;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el comprobante" + ".\n" + e.Message, 0);
                return;
                
            }
        }

        private decimal Gettotalfactura(long idreg)
        {
            try
            {
                decimal retorno = 0;

                string c = "SELECT Total FROM FACTPRESENC WHERE ID_Registro = " + idreg;

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    if (r["Total"] != null) { retorno = Convert.ToDecimal(r["Total"]); }
                }

                return retorno;

            }
            catch (Exception)
            {
                return 0;                
            }
        }

        //GUARDO LOS REGISTROS EN LA TABLA DE RELACION
        private void GuardorelacionNC(long idfactura, string guid, string tipo)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_NotaCredito");
                campos.Add("ID_NotaDebito");
                campos.Add("ID_Factura");

                parametros.Clear();
                if (tipo == "NC" || tipo == "NCE")
                {
                    parametros.Add(GetIdfactura(guid));
                    parametros.Add(0);
                }
                else
                {
                    parametros.Add(0);
                    parametros.Add(GetIdfactura(guid));                    
                }
                
                parametros.Add(idfactura);

                func.AccionBD(campos, parametros, "I", "FACTPRESREL");

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al guardar la relacion de comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO RELACION ENTRE ASOCTRAN Y NCD
        private void GeneraRelasoctran(long idcomprobante, string factura, string tipo, string letra, int pventa, long numero, decimal total)
        {
            try
            {
                ConexionAmdgoSis con = new ConexionAmdgoSis();
                SqlConnection cn = con.Conectar();
                string compr = letra + " " + pventa.ToString("0000") + "-" + numero.ToString("00000000");
                string query = "";
                                                          
                if (tipo == "NC" || tipo == "NCE")
                {
                    query = "INSERT INTO ASOCTRANREL (FACTURA, IDBDIN, NDEBITO, NCREDITO, TOTAL)" +
                               " VALUES ('" + factura + "', " + idcomprobante + ", '', '" + compr + "', " + total.ToString().Replace(",", ".") + ")";
                }
                else
                {
                    query = "INSERT INTO ASOCTRANREL (FACTURA, IDBDIN, NDEBITO, NCREDITO, TOTAL)" +
                               " VALUES ('" + factura + "', " + idcomprobante + ", '" + compr + "', ''," + total.ToString().Replace(",", ".") + ")";
                }
                               
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();

                con.Desconectar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el registro de relación de comprobantes.\n" + e.Message, 1);
                return;
            }
        }
    }
        
    //CLASE DE COMPROBANTES PENDIENTES DE AUTORIZACION CONTRA AFIP
    public class ComprobPE
    {
        public string IDComprobante { get; private set; } = Guid.NewGuid().ToString();
        public string TipoComprobante { get; set; } = "FC";
        public bool Pagada { get; set; } = false;
        public bool Anulada { get; set; } = false;
        public DateTime Fecha { get; set; }
        public DateTime FechaVtoPago { get; set; }
        public string Periodo { get; set; } = "";
        public string ID_Prestataria { get; set; } = "";
        public string EmisorCbu { get; set; } = "";
        public string EmisorAlias { get; set; } = "";
        public bool ReceptorActivo { get; set; } = true;
        public string ReceptorRazonin { get; set; } = "";
        public string ReceptorArt { get; set; } = "";
        public string ReceptorCodigo { get; set; } = "";
        public string ReceptorNombre { get; set; } = "";
        public string ReceptorCuit { get; set; } = "";
        public string ReceptorIva { get; set; } = "";
        public string ReceptorIvanro { get; set; } = "";
        public string ReceptorNombreAsoc { get; set; } = "";
        public decimal ReceptorPorcIva { get; set; } = 0;
        public string ReceptorDomFiscal { get; set; } = "";
        public int ReceptorDiasVto { get; set; } = 0;
        public bool ReceptorFCE { get; set; } = false;
        public string Paciente { get; set; } = "";
        public long NroDocumento { get; set; } = 0;
        public decimal Neto { get; set; } = 0;        
        public decimal Gastos { get; set; } = 0;
        public decimal Honorarios { get; set; } = 0;
        public decimal Iva { get; set; } = 0;        
        public decimal Total { get; set; } = 0;
        public List<ComprobPD> Detalles { get; set; } = new List<ComprobPD>();

        //DATOS A LLENAR DESDE AFIP

        public string Letra { get; set; } = "";
        public int PuntoVta { get; set; } = 10;
        public long Numero { get; set; } = 0;
        public string Estado { get; set; } = "";
        public string CaeNro { get; set; } = "";
        public string NumeroBarras { get; set; } = "";
        public string FechaVtoCae { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string Observaciones { get; set; } = "";
        public short DiasVencidos { get; set; } = 0;
        public decimal InteresesVencidos { get; set; } = 0;
        //PARA RELACION DE COMPROBANTES (FC A NC/ND/NCE/NDE)
        public long ID_Factura { get; set; } = 0;
        public DateTime FechaFactura { get; set; }
        public string Comprobante { get; set; } = "";
        public string ProfCondIva { get; set; } = "";

        public string TextoQr { get; set; }
        public byte[] ByteQr { get; set; }
    }

    //DETALLES DE COMPROBANTES
    public class ComprobPD
    {
        public string IDComprobante { get; private set; } = Guid.NewGuid().ToString();
        public long IDDetalle { get; set; } = 0;
        public long IDFactura { get; set; } = 0;
        public string IDEncabezado { get; set; }
        public string Fecha { get; set; } = "";
        public string Periodo { get; set; } = "";
        public string CodigoObra { get; set; } = "";
        public string DocumPaciente { get; set; } = "";
        public string NombrePaciente { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Concepto { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal Gastos { get; set; } = 0;
        public decimal Honorarios { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public long Puntero { get; set; } = 0;
        public string LetraComprob { get; set; } = "";
        public string Origen { get; set; } = "";
        public string CodProfesional { get; set; } = "";
        public string Profesional { get; set; } = "";
        public string ProfCond { get; set; } = "";
        public string CodPractica { get; set; } = "";
        public string DescPractica { get; set; } = "";
        public string FechaPractica { get; set; } = "";
    }

    public class Encabezadostruct
    {
        public string Letra { get; set; } = "";
        public string Paciente { get; set; } = "";
        public long NroDocumento { get; set; } = 0;
        public string ReceptorCodigo  { get; set; } = "";
        public string ReceptorNombre  { get; set; } = "";
        public string ReceptorNombreAsoc { get; set; } = "";
        public decimal ReceptorPorcIva { get; set; } = 0;
        public string ReceptorArt { get; set; } = "";
        public string ReceptorCuit { get; set; } = "";
        public decimal Neto  { get; set; } = 0;
        public decimal Gastos { get; set; } = 0;
        public decimal Honorarios { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Total { get; set; } = 0;        
    }

    public class Prestcomprobx
    {
        public int IDPrestataria { get; set; } = 0;
        public long Cuit { get; set; } = 0;
        public bool Aceptax { get; set; }= false;
        public bool Comprobxpaciente { get; set; } = false;
    }
    
    #region COMPROBANTES X
    //CLASE PARA EMISION DE COMPROBANTES X COMO C
    /*public class EmisionXC
    {
        Funciones func = new Funciones();
        Globales glob = new Globales();
        Controles ctrl = new Controles();
        AfipProdDatos afip = new AfipProdDatos();        
        private PrestFactura prestclas = new PrestFactura();
        List<ComprobPE> encabezadoslst = new List<ComprobPE>();
        

        private void ListarcomprobX()
        {
            try
            {
                string c = "SELECT ID_Registro, Periodo, Fecha, Paciente," +
                    " NroDocumento, ID_PrestDetalle, NombrePres, CuitPres, IvaPres, DomFiscalPres, Neto, Gastos," +
                    " Honorarios, Iva, Total, FechaDesde, FechaHasta" +
                    " FROM FACTPRESENC" +
                    " WHERE Letra = 'X' AND TipoComprobante = 'FC' AND ID_Registro NOT IN (SELECT ID_ComprobanteX FROM FACTPRESRX)";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    encabezadoslst.Add(new ComprobPE
                    {
                        Periodo = r["Periodo"].ToString(),
                        Fecha = DateTime.Today,
                        TipoComprobante = "FC",
                        Letra = "C",
                        PuntoVta = 10,
                        Paciente = r["Paciente"].ToString().Trim(),
                        NroDocumento = Convert.ToInt64(r["NroDocumento"]),
                        ID_Prestataria = r["ID_PrestDetalle"].ToString(),
                        ReceptorNombre = r["NombrePres"].ToString(),
                        ReceptorCuit = r["CuitPres"].ToString(),
                        ReceptorIvanro = r["IvaPres"].ToString(),
                        ReceptorDomFiscal = r["DomFiscalPres"].ToString(),
                        Neto = Convert.ToDecimal(r["Neto"]),
                        Gastos = Convert.ToDecimal(r["Gastos"]),
                        Honorarios = Convert.ToDecimal(r["Honorarios"]),
                        Iva = Convert.ToDecimal(r["Iva"]),
                        Total = Convert.ToDecimal(r["Total"]),
                        FechaDesde = r["FechaDesde"].ToString(),
                        FechaHasta = r["FechaHasta"].ToString(),
                        ID_Factura = Convert.ToInt64(r["ID_Registro"])
                    });
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar los registros X.\n" + e.Message, 0);
                return;
            }
            
        }

        public void GenerarFacturasXC()
        {
            ListarcomprobX();

            GeneraFacturas();
        }

        private void GeneraFacturas()
        {
            try
            {

                ArrayList campos = new ArrayList(prestclas.Camposfactambu());

                ArrayList parametros = new ArrayList();
                DateTime fechahoy = func.Getfechorserver();

                //RECORRO LA LISTA DE ENCABEZADOS DE FACTURA
                foreach (ComprobPE e in encabezadoslst)
                {
                   if (Procesoafip(e) < 0)
                   {
                        ctrl.MensajeInfo("Hay inconvenientes de conexión con AFIP,\n" +
                            "toda la operación se interrumpirá para evitar errores.\n" +
                            "Intente nuevamente más tarde.", 1);                            
                        break;
                   }
                 
                    parametros.Clear();

                    parametros.Add(e.Periodo);
                    parametros.Add(e.Fecha);
                    parametros.Add(e.TipoComprobante);
                    parametros.Add(e.Letra);
                    parametros.Add(e.PuntoVta);
                    parametros.Add(e.Numero);
                    parametros.Add(e.Paciente);
                    parametros.Add(e.NroDocumento);
                    parametros.Add(Convert.ToInt64(e.ID_Prestataria)); //ID PRESTATARIA
                    parametros.Add(e.ReceptorNombre);
                    parametros.Add(e.ReceptorCuit);
                    parametros.Add(e.ReceptorIvanro);
                    parametros.Add(e.ReceptorDomFiscal);
                    parametros.Add(e.EmisorCbu);
                    parametros.Add(e.EmisorAlias);
                    parametros.Add(e.IDComprobante);
                    parametros.Add(e.Neto);
                    parametros.Add(e.Gastos);
                    parametros.Add(e.Honorarios);
                    parametros.Add(e.Iva);
                    parametros.Add(e.Total);
                    if (e.FechaDesde != null && e.FechaDesde != "") { parametros.Add(Convert.ToDateTime(e.FechaDesde)); } else { parametros.Add(DBNull.Value); }
                    if (e.FechaHasta != null && e.FechaHasta != "") { parametros.Add(Convert.ToDateTime(e.FechaHasta)); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Estado);
                    parametros.Add(e.CaeNro);
                    parametros.Add(e.NumeroBarras);
                    if (e.FechaVtoCae != null && e.FechaVtoCae != "") { parametros.Add(Convert.ToDateTime(e.FechaVtoCae)); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Observaciones);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);

                    func.AccionBD(campos, parametros, "I", "FACTPRESENC");

                    RelacionXC(e.IDComprobante, e.ID_Factura);

                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el comprobante.\n" + e.Message, 0);
                return;
            }
            
        }

        private sbyte Procesoafip(ComprobPE enc)
        {
            try
            {
                sbyte retorno = 1;

                //HAGO EL LOGIN
                if (!func.LoginAfip(1, "30567506769", afipprod: afip))                
                {
                    ctrl.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return -1;
                }

                //LETRA DE COMPROBANTE
                string letra = func.GetLetracomprob(4, Convert.ToInt16(enc.ReceptorIvanro), enc.Iva, false);

                short c1 = 0, c2 = 0, c3 = 0;

                //IVA Y CONCEPTO
                foreach (ComprobPD d in enc.Detalles)
                {
                    //CONCEPTO
                    if (d.Concepto == "1") { c1 += 1; }
                    else if (d.Concepto == "2") { c2 += 1; }
                    else if (d.Concepto == "3") { c3 += 1; }
                }


                //CONCEPTO P2
                int concep = 2;
                if (c2 == 0 && c3 == 0) { concep = 1; }
                else if (c1 == 0 && c2 == 0) { concep = 3; }

                //OPCIONALES
                //if (enc.TipoComprobante == "FCE" || enc.TipoComprobante == "NCE" || enc.TipoComprobante == "NDE")
                //{
                //    afip.setOpcionales(enc.EmisorCbu, enc.EmisorAlias);
                //}                

                if (enc.TipoComprobante != "FCE")
                {
                    afip.agregaFactura(1, func.Getfechorserver().ToString("yyyyMMdd"), enc.PuntoVta, "CUIT", Convert.ToInt64(enc.ReceptorCuit), //ENCABEZADO
                    concep, enc.Total, 0, enc.Total, 0, 0, 0, "pesos", 1, //IMPORTES
                    enc.Fecha.ToString("yyyyMMdd"), enc.Fecha.ToString("yyyyMMdd"), enc.Fecha.ToString("yyyyMMdd"),//FECHAS SRV
                    enc.TipoComprobante, letra);                    
                }


                if (afip.Estado) { enc.Estado = "A"; } else { enc.Estado = "R"; }

                enc.Letra = letra;
                enc.Numero = afip.Nrofactura;
                enc.CaeNro = afip.Caenumero;
                enc.NumeroBarras = afip.CodigoBarras;
                enc.FechaDesde = enc.Fecha.ToString("dd-MM-yyyy");
                enc.FechaHasta = enc.Fecha.ToString("dd-MM-yyyy");

                if (afip.Fechavtocae != null && afip.Fechavtocae != "" && enc.Estado != "R")
                {
                    string date = "";
                    date = afip.Fechavtocae.Substring(0, 4) + "-" + afip.Fechavtocae.Substring(4, 2) + "-" + afip.Fechavtocae.Substring(6, 2);
                    enc.FechaVtoCae = date;
                }

                enc.Observaciones = afip.Observaciones;

                return retorno;
            }
            catch (Exception)
            {
                //ctrl.MensajeInfo("Ocurrió un error al notificar la factura a AFIP.\n" + e.Message, 0);
                return -1;
            }
        }

        private void RelacionXC(string guid, long idfact)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_Factura");
                campos.Add("ID_ComprobanteX");                
                
                parametros.Clear();
                
                parametros.Add(prestclas.GetIdfactura(guid));
                parametros.Add(idfact);
                
                func.AccionBD(campos, parametros, "I", "FACTPRESRX");

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al guardar la relacion de comprobantes.\n" + e.Message, 0);
                return;
            }
        }
    }*/
    #endregion
}
