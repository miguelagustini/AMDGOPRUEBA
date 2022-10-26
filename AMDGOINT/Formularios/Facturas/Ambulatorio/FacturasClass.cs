using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using AMDGOINT.Datos;
using System.Collections;
using AmdgoInterno.Afip;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using AMDGOINT.Afip;
using System.Text.RegularExpressions;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    class FacturasClass
    {
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();        
        private AfipPadron conspadron = new AfipPadron();

        public List<ComprobPE> Comprobplst = new List<ComprobPE>();
        public List<ComprobPD> Comprobdetlst = new List<ComprobPD>();        

        public int Procesadas { get; private set; } = 0;
        public DSDatos datacoll { get; set; }
        public string Periodo { get; set; } = "";

        public List<Faltantes> ChequearFaltantes()
        {
            List<Faltantes> Faltanteslst = new List<Faltantes>();

            try
            {               
                                
                string c = "SELECT ISNULL(COUNT(MED2CSEG), 0) AS Seguimiento, ISNULL(COUNT(MED2FACT), 0) as Audita," +
                           " ISNULL(MED2PCOB, '') AS Codigo, ISNULL(PROFAPNO, '') as Profesional" +
                           " FROM ASOCMED2" +
                           " LEFT OUTER JOIN ASOCPROF AP ON(AP.PROFCODI = MED2PCOB)" +
                           " WHERE MED2CSEG = '2' AND MED2FACT = '1' AND" +
                           " (MED2COMP is null OR LTRIM(RTRIM(MED2COMP)) = '') " +
                           " AND MED2MESA = NULL AND LEN(MED2LOTE) = 16" +
                           " GROUP BY MED2PCOB, PROFAPNO";

                foreach (DataRow r in func.getColecciondatosamsis(c).Rows)
                {
                    Faltanteslst.Add(new Faltantes
                    {
                        Seguimiento = Convert.ToInt16(r["Seguimiento"]),
                        Audita = Convert.ToInt16(r["Audita"]),
                        ProfCodigo = r["Codigo"].ToString(),
                        ProfNombre = r["Profesional"].ToString()

                    });                                        
                }

                return Faltanteslst;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar los faltantes.\n" + e.Message, 0);
                return Faltanteslst;
            }
        }

        public void ProcesarAmbulatorio(DSDatos dat)
        {
            datacoll = dat;
            Comprobplst.Clear();
            Comprobdetlst.Clear();

            //CREO LA LISTA DIVIDIDA EN CLASES ORDENANDO LOS DATOS
            ListaPendientes();

        }

        public void FacturaAmbulatorio()
        {
            try
            {
                ABMFactuambu();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar las facturas.\n" + e.Message ,0);
                return;
            }
        }

        private void ListaPendientes()
        {
            try
            {                                
                string consulta = "SELECT PF.PROFCODI AS EmisorCodigo, PF.PROFAPNO AS EmisorNombre, PF.PROFNCUI AS EmisorCuit," +
                    " PF.PROFAFIP AS EmisorIva, AC.OBRACODI AS ReceptorCodigo, AC.OBRANOMB AS ReceptorNombre," +
                    " AC.OBRANCUI AS ReceptorCuit, AC.OBRATIVA AS ReceptorIva, SUM(MED.MED2NETO) AS Neto," +
                    " SUM(MED.MED21IVA) AS Iva, SUM(MED.MED2TOTA) AS Total, IIF(AC.OBRATIVA LIKE '%mono%', 6," +
                    " IIF((AC.OBRATIVA LIKE '%insc%' or AC.OBRATIVA LIKE '%inc%' OR AC.OBRATIVA LIKE '%ins%'), 1, IIF(AC.OBRATIVA LIKE '%exe%',4,4)))  AS ReceptorNroiva," +
                    " ISNULL(AC.OBRAPORC_IVA, 0) AS ReceptorPi" +
                    " FROM ASOCMED2 MED" +
                    " LEFT OUTER JOIN ASOCPROF PF ON(PF.PROFCODI = MED.MED2PCOB)" +
                    " LEFT OUTER JOIN ASOCOBRA AC ON(AC.OBRACODI = MED.MED2COOB)" +
                    " WHERE PF.PROFAFIP = '1' AND (MED.MED2FACT = '3' OR MED.MED2FACT = '8')" +
                    " AND (MED.MED2COMP IS NULL OR LTRIM(RTRIM(MED.MED2COMP)) = '') AND LEN(MED.MED2LOTE) = 16" +                    
                    " AND MED.MED2MESA IS NULL" +
                    " AND (MED.MED2PCOB <> '5500' AND MED.MED2PCOB <> '8684' AND MED.MED2PCOB <> '8561' AND MED.MED2PCOB <> '5293' AND MED.MED2PCOB <> '5715'" +
                    " AND MED.MED2PCOB <> '6381' AND MED.MED2PCOB <> '8677' AND MED.MED2PCOB <> '5058' AND MED.MED2PCOB <> '5059' AND MED.MED2PCOB <> '5227' AND MED.MED2PCOB <> '7483'" +
                    " AND MED.MED2PCOB <> '6411' AND MED.MED2PCOB <> '6950' AND MED.MED2PCOB <> '8875' AND MED.MED2PCOB <> '8837' AND MED.MED2PCOB <> '7391' AND MED.MED2PCOB <> '6862'" +
                    " AND MED.MED2PCOB <> '6855' AND MED.MED2PCOB <> '6879' AND MED.MED2PCOB <> '6619')" + //PARA FACTURAR DESDE EL NUEVO MODULO
                    //" WHERE PF.PROFAFIP = '1' AND MED.MED2MESA = '2021067' AND MED.MED2FACT = 'X'" +
                    //" AND MED.MED2COMP = '0-0' AND LEN(MED.MED2LOTE) = 16 " +

                    " AND (MED.export_guid is null OR LTRIM(RTRIM(MED.export_guid)) = '') AND (MED.MED2CSEG = 'A' OR MED.MED2CSEG = 'B')" +
                    " GROUP BY PF.PROFCODI, PF.PROFAPNO, PF.PROFNCUI, PF.PROFAFIP, AC.OBRACODI," +
                    " AC.OBRANOMB, AC.OBRANCUI, AC.OBRATIVA, AC.OBRAPORC_IVA";

                DateTime fec = func.Getfechorserver();
                foreach (DataRow f in func.getColecciondatosamsis(consulta).Rows)
                {
                    Comprobplst.Add(new ComprobPE
                    {
                        Fecha = fec,
                        EmisorCodigo = f["EmisorCodigo"].ToString().Trim(),
                        EmisorNombre = f["EmisorNombre"].ToString().Trim(),
                        EmisorCuit = f["EmisorCuit"].ToString().Trim(),
                        EmisorIva = f["EmisorIva"].ToString().Trim(),
                        ReceptorCodigo = f["ReceptorCodigo"].ToString().Trim(),
                        ReceptorNombre = f["ReceptorNombre"].ToString().Trim(),
                        ReceptorNombreAsoc = f["ReceptorNombre"].ToString().Trim(),
                        ReceptorCuit = f["ReceptorCuit"].ToString().Trim(),
                        ReceptorIva = f["ReceptorIva"].ToString().Trim(),
                        ReceptorIvanro = f["ReceptorNroiva"].ToString().Trim(),
                        ReceptorPorciva = Convert.ToDecimal(f["ReceptorPi"]),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"])                        
                    });
                }

                //ACTUALIZO PRESTADORES
                Actualizaemisor();
                
                //ACTUALIZO PRESTATARIA
                Actualizareceptor();

                //DETALLES GLOBAL
                GetDetallesglob();

                //ASIGNO DETALLES
                foreach (ComprobPE cenc in Comprobplst)
                {
                    cenc.Detalles = GetDetalles(cenc.IDComprobante, cenc.EmisorCodigo, cenc.ReceptorCodigo);
                    cenc.Neto21 = GetNeto21(cenc.IDComprobante);
                    cenc.Neto105 = GetNeto105(cenc.IDComprobante);
                    cenc.Iva21 = GetIva21(cenc.IDComprobante);
                    cenc.Iva105 = GetIva105(cenc.IDComprobante);
                    cenc.NoGravado = GetNoGravado(cenc.IDComprobante);
                }
               
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener la lista de pendientes.\n" + e.Message, 0);
                return;
            }
        }

        //OBTENOG EL PUNTO DE VENTA DEL PRESTADOR
        private int GetPuntovta(string cuit)
        {
            try
            {
                int retorno = 0;

                string consulta = "SELECT TOP 1 PuntoVenta FROM PROFESIONALES WHERE CUIT = " + cuit;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    retorno = Convert.ToInt32(f["PuntoVenta"]);
                }

                return retorno;
            }
            catch (Exception)
            {
                return 0;                
            }
        }
        
        //ACTUALIZO DATOS EMISOR
        private void Actualizaemisor()
        {
            try
            {
                if (!func.hayConexion()) { return; }

                var list = Comprobplst.GroupBy(t => t.EmisorCuit).Select(grp => grp.First()).ToList();
                long[] arrcuits = new long[list.Count];
                int f = 0;

                foreach (ComprobPE r in list)
                {
                    if (r.EmisorCuit != "")
                    {
                        arrcuits[f] = Convert.ToInt64(r.EmisorCuit);
                        f++;
                    }

                }

                ListaPersonas ent = conspadron.GetEntidad(arrcuits, Application.StartupPath + @"\Afip\PROD\PD-CR20078779250.pfx", "2048", 20078779250);

                foreach (ComprobPE e in Comprobplst)
                {
                    string dom = "";
                    string fecha = "";
                    string nombre = "";
                    int pventa = GetPuntovta(e.EmisorCuit);

                    //VALIDO SI ESTA COMPLETO EL DOMICILIO FISCAL Y FECHA DE INICIO
                    if (e.EmisorDomFiscal == "")
                    {
                        //RECORRO BUSCANDO EL ID DE LA PERSONA EN EL RESULTADO DE AFIP
                        foreach (Persona p in ent.personaListReturn.persona)
                        {
                            if (p.datosGenerales == null) { continue; }
                            
                            if (p.datosGenerales.idPersona == e.EmisorCuit)
                            {
                                //NOMBRE
                                if (p.datosGenerales != null && p.datosGenerales.nombre != null
                                   && p.datosGenerales.apellido != null)
                                {
                                    nombre = p.datosGenerales.apellido + ", " + p.datosGenerales.nombre;

                                    e.EmisorNombre = nombre;
                                }

                                //DOMICILIO
                                if (p.datosGenerales != null && p.datosGenerales.domicilioFiscal != null)
                                {
                                    dom = p.datosGenerales.domicilioFiscal.direccion + ", " +
                                        p.datosGenerales.domicilioFiscal.localidad + " " +
                                        p.datosGenerales.domicilioFiscal.codPostal + ", " +
                                        p.datosGenerales.domicilioFiscal.descripcionProvincia;

                                    e.EmisorDomFiscal = dom;
                                }

                                if (p.datosRegimenGeneral != null && p.datosRegimenGeneral.impuesto != null)
                                {
                                    for (int m = 0; m < p.datosRegimenGeneral.actividad.Count; m++)
                                    {
                                        switch (p.datosRegimenGeneral.actividad[m].orden)
                                        {
                                            case "1":
                                                string dat = p.datosRegimenGeneral.actividad[m].periodo;
                                                if (dat != "")
                                                {
                                                    fecha = dat.Substring(0, 4) + "-" + dat.Substring(4, 2) + "-01";
                                                    e.EmisorFinicioact = fecha;
                                                }
                                                break;

                                        }
                                    }
                                }

                            }

                        }

                        e.EmisorPuntoVta = pventa;

                        var resultados = Comprobplst.Where(s => s.EmisorCuit == e.EmisorCuit).ToList();

                        foreach (var r in resultados)
                        {
                            if (nombre != "") { r.EmisorNombre = nombre; }
                            if (dom != "") { r.EmisorDomFiscal = dom; }
                            if (fecha != "-01" && fecha != "") { r.EmisorFinicioact = fecha; }
                            r.EmisorPuntoVta = pventa;
                        }
                    }
                                  
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error alactualizar los datos del emisor.\n" + e.Message, 0);
                return;
            }
        }

        //ACTUALIZO DATOS PRESTATARIA
        private void Actualizareceptor()
        {
            try
            {
                if (!func.hayConexion()) { return; }

                var list = Comprobplst.GroupBy(t => t.ReceptorCuit).Select(grp => grp.First()).ToList();
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

                ListaPersonas ent = conspadron.GetEntidad(arrcuits, Application.StartupPath + @"\Afip\PROD\PD-CR20078779250.pfx", "2048", 20078779250);
                
                foreach (ComprobPE e in Comprobplst)
                {
                    string dom = "";
                    string razons = "";
                    string ivanro = "";
                    
                    //VALIDO SI ESTA COMPLETO EL DOMICILIO FISCAL Y FECHA DE INICIO
                    if (e.ReceptorDomFiscal == "" && ent != null && ent.personaListReturn != null && ent.personaListReturn.persona.Count > 0)
                    {
                        foreach (Persona p in ent.personaListReturn.persona)
                        {
                            if (p.datosGenerales != null && p.datosGenerales.idPersona == e.ReceptorCuit)
                            {
                                if (p.datosGenerales != null && p.datosGenerales.razonSocial != null)
                                {
                                    razons = p.datosGenerales.razonSocial;

                                    e.ReceptorNombre = razons;
                                }

                                if (p.datosGenerales != null && p.datosGenerales.domicilioFiscal != null)
                                {
                                    dom = p.datosGenerales.domicilioFiscal.direccion + ", " +
                                        p.datosGenerales.domicilioFiscal.localidad + " " +
                                        p.datosGenerales.domicilioFiscal.codPostal + ", " +
                                        p.datosGenerales.domicilioFiscal.descripcionProvincia;

                                    e.ReceptorDomFiscal = dom;
                                }

                                if (p.datosRegimenGeneral != null && p.datosRegimenGeneral.impuesto != null)
                                {
                                    for (int m = 0; m < p.datosRegimenGeneral.impuesto.Count; m++)
                                    {
                                        switch (p.datosRegimenGeneral.impuesto[m].idImpuesto)
                                        {
                                            case "30": ivanro = "1"; e.ReceptorIvanro = ivanro; e.ReceptorIva = "RESP. INSCRIPTO"; break;
                                            case "32": ivanro = "4"; e.ReceptorIvanro = ivanro; e.ReceptorIva = "EXENTO"; break;
                                        }
                                    }
                                }

                                var resultados = Comprobplst.Where(s => s.ReceptorCuit == e.ReceptorCuit).ToList();

                                foreach (var r in resultados)
                                {
                                    if (razons != "") { r.ReceptorNombre = razons; }
                                    if (dom != "") { r.ReceptorDomFiscal = dom; }
                                    if (ivanro != "") { r.ReceptorIvanro = ivanro; }
                                    if (ivanro == "1") { e.ReceptorIva = "RESP. INSCRIPTO"; } else if (ivanro == "4") { e.ReceptorIva = "EXENTO"; }
                                    r.ReceptorIva = e.ReceptorIva;
                                }
                            }
                            
                        }   
                        
                    }
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error alactualizar los datos del emisor.\n" + e.Message, 0);
                return;
            }
        }

        //OBTENGO TOTAL NETO21
        private decimal GetNeto21(string codigoenc)
        {
            try
            {
                decimal resultados = Comprobdetlst.Where(s => s.IDEncabezado == codigoenc && s.IvaPorc == 21).Sum(r => r.Neto);

                return resultados;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el total neto21.\n" + e.Message, 0);
                return 0;
            }
        }

        //OBTENGO TOTAL NETO105
        private decimal GetNeto105(string codigoenc)
        {
            try
            {
                decimal resultados = Comprobdetlst.Where(s => s.IDEncabezado == codigoenc && s.IvaPorc == Convert.ToDecimal(10.5)).Sum(r => r.Neto);

                return resultados;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el total neto105" +
                    ".\n" + e.Message, 0);
                return 0;
            }
        }

        //OBTENGO TOTAL NO GRAVADO
        private decimal GetNoGravado(string codigoenc)
        {
            try
            {
                decimal resultados = Comprobdetlst.Where(s => s.IDEncabezado == codigoenc && s.IvaPorc == 0).Sum(r => r.Neto);

                return resultados;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el total neto105.\n" + e.Message, 0);
                return 0;
            }
        }

        //OBTENGO TOTAL IVA21
        private decimal GetIva21(string codigoenc)
        {
            try
            {
                decimal resultados = Comprobdetlst.Where(s => s.IDEncabezado == codigoenc && s.IvaPorc == 21).Sum(r => r.Iva);

                return resultados;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el total iva21.\n" + e.Message, 0);
                return 0;
            }
        }

        //OBTENGO TOTAL NO GRAVADO
        private decimal GetIva105(string codigoenc)
        {
            try
            {
                decimal resultados = Comprobdetlst.Where(s => s.IDEncabezado == codigoenc && s.IvaPorc == Convert.ToDecimal(10.5)).Sum(r => r.Iva);

                return resultados;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el total Iva105.\n" + e.Message, 0);
                return 0;
            }
        }

        //OBTENGO LA LISTA DE DETALLES GLOBAL, PARA ACELERAR EL PROCESO
        private void GetDetallesglob()
        {
            try
            {
                string consulta = "SELECT MED.MED2PRAC AS Practica, MED.MED2FEPR AS FechaPractica, MED.MED2PACI AS PacienteNom," +
                    " MED.MED2DOCU AS PacienteDocu, ISNULL(MED.MED2CANT,0) AS Cantidad, ISNULL(MED.MED2NETO,0) AS Neto, ISNULL(MED.MED21IVA,0) AS Iva," +                    
                    " ISNULL(MED.MED2TOTA ,0) AS Total, ISNULL(MED.MED2PUNT,0) AS Puntero, MED.MED2PNOM AS PracticaDesc," +                                        
                    " IIF(MED21IVA > 0, isnull( OBRAPORC_IVA,0), 0) AS IvaPorc," +
                    " ISNULL(MED.MED2FUNC,0) AS Funcion, MED.MED2PCOB AS CodProf, MED.MED2COOB AS CodObra" +
                    " FROM ASOCMED2 MED" +
                    " LEFT OUTER JOIN ASOCPROF PF ON(PF.PROFCODI = MED.MED2PCOB)" +
                    " LEFT OUTER JOIN ASOCOBRA AC ON(AC.OBRACODI = MED.MED2COOB)" +
                    " WHERE PF.PROFAFIP = '1' AND (MED.MED2FACT = '3' OR MED.MED2FACT = '8')" +
                    " AND (MED.MED2COMP IS NULL OR LTRIM(RTRIM(MED.MED2COMP)) = '') AND LEN(MED.MED2LOTE) = 16" +
                    " AND MED.MED2MESA IS NULL" +

                    " AND (MED.MED2PCOB <> '5500' AND MED.MED2PCOB <> '8684' AND MED.MED2PCOB <> '8561' AND MED.MED2PCOB <> '5293' AND MED.MED2PCOB <> '5715'" +
                    " AND MED.MED2PCOB <> '6381' AND MED.MED2PCOB <> '8677' AND MED.MED2PCOB <> '5058' AND MED.MED2PCOB <> '5059' AND MED.MED2PCOB <> '5227' AND MED.MED2PCOB <> '7483'" +
                    " AND MED.MED2PCOB <> '6411' AND MED.MED2PCOB <> '6950' AND MED.MED2PCOB <> '8875' AND MED.MED2PCOB <> '8837' AND MED.MED2PCOB <> '7391' AND MED.MED2PCOB <> '6862'" +
                    " AND MED.MED2PCOB <> '6855' AND MED.MED2PCOB <> '6879' AND MED.MED2PCOB <> '6619')" +
                    // EXCLUYO PARA FACTURAR EN NUEVO MODULO


                    //" WHERE PF.PROFAFIP = '1' AND MED.MED2MESA = '2021067' AND MED.MED2FACT = 'X'" +
                    //" AND MED.MED2COMP =  '0-0' AND LEN(MED.MED2LOTE) = 16" +
                    " AND (MED.export_guid is null OR LTRIM(RTRIM(MED.export_guid)) = '') AND (MED.MED2CSEG = 'A' OR MED.MED2CSEG = 'B')";
                    

                foreach (DataRow f in func.getColecciondatosamsis(consulta).Rows)
                {

                    DateTime fecha = new DateTime();

                    if (f["FechaPractica"] != DBNull.Value) { fecha = Convert.ToDateTime(f["FechaPractica"]); }

                    Comprobdetlst.Add(new ComprobPD {

                        Practica = f["Practica"].ToString().Trim(),
                        PracticaNom = f["PracticaDesc"].ToString().Trim(),
                        Fecha = fecha,
                        PaciDocu = Regex.Replace(f["PacienteDocu"].ToString().Trim(), "[^0-9]+", ""),
                        PaciNombre = f["PacienteNom"].ToString().Trim(),
                        Cantidad = Convert.ToDecimal(f["Cantidad"]),
                        Neto = GetNetodetalle(Convert.ToDecimal(f["IvaPorc"]), Convert.ToDecimal(f["Neto"])),
                        NoGravado = GetNogravadodetalle(Convert.ToDecimal(f["IvaPorc"]), Convert.ToDecimal(f["Neto"])),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        IvaPorc = Convert.ToDecimal(f["IvaPorc"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        Puntero = Convert.ToInt64(f["Puntero"]),
                        Funcion = f["Funcion"].ToString(),
                        Concepto = GetConcepto(f["Funcion"].ToString()),
                        Profesional= f["CodProf"].ToString().Trim(),
                        Prestataria = f["CodObra"].ToString().Trim()
                    });                    
                }                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al importar los detalles.\n" + e.Message, 0);
                return;
            }
        }

        //RETORNO EL NETO DETALLE SEGUN CORRESPONDA
        private decimal GetNetodetalle(decimal ivaporc, decimal neto)
        {
            if (ivaporc > 0) { return neto; } else { return 0; }
        }

        //RETORNO EL NO GRAVADO DETALLE SEGUN CORRESPONDA
        private decimal GetNogravadodetalle(decimal ivaporc, decimal neto)
        {
            if (ivaporc == 0) { return neto; } else { return 0; }
        }

        //OBTENGO LOS DETALLES DE UN ENCABEZADO Y RETORNO LA LISTA FILTRADA
        private List<ComprobPD> GetDetalles(string guid, string profcodi, string obracodi)
        {
            List<ComprobPD> list = new List<ComprobPD>();

            try
            {               
                var resultados = Comprobdetlst.Where(s => s.Profesional == profcodi && s.Prestataria == obracodi).ToList();

                foreach (var r in resultados)
                {
                    r.IDEncabezado = guid;
                    list.Add(r);                    
                }
                
                return list;
              
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener la lista detalles de pendientes.\n" + e.Message, 0);
                return list;
            }
        }

        //RETORNO EL CONCEPTO SEGUN FUNCION
        private string GetConcepto(string func)
        {
            switch (func)
            {
                case "199": return "2";
                case "110": return "1";
                case "192": return "1";
                case "120": return "1";
                case "196": return "1";
                case "160": return "2";
                case "191": return "2";
                default: return "2";
            }
        }
              
        //ABM DE FACTURAS AMBULATORIO
        private void ABMFactuambu()
        {
            try
            {
                if(Comprobplst.Count <= 0) { return; }

                ArrayList campos = new ArrayList(Camposfactambu());
                ArrayList parametros = new ArrayList();
                DateTime fechahoy = DateTime.Now;
                ConexionBD cnb = new ConexionBD();
                SqlConnection sqlconn = cnb.Conectar();

                //RECORRO LA LISTA DE ENCABEZADOS DE FACTURA
                foreach (ComprobPE e in Comprobplst)
                {
                    AfipProdDatos afip = new AfipProdDatos();
                    afip.Sqlconnection = sqlconn;

                    Procesadas++;

                    if (!func.hayConexion()) { ctrl.MensajeInfo("La conexión a internet fue interrumpida.\nEl proceso debe ser retomado.", 1);  return; }
                                        
                    //NO HAY INFORMACION DE PUNTO DE VENTA DISPONIBLE
                    if (e.EmisorPuntoVta == 0 || e.EmisorCuit.Trim() == "") { continue; }

                    int idprofesional = GetIdProfesional(e, sqlconn);
                    int idprestataria = GetIdPrestatria(e, sqlconn);

                    if (e.Detalles.Count <= 0 || e.Total <= 0) { continue; }
                    if (!Procesoafipambu(e, afip)) { continue; }

                    parametros.Clear();

                    parametros.Add(fechahoy);
                    parametros.Add("FC");
                    parametros.Add(e.Letra);
                    parametros.Add(e.EmisorPuntoVta);
                    parametros.Add(e.Numero);
                    parametros.Add(idprofesional); //ID DEL PROFESIONAL
                    parametros.Add(e.EmisorNombre);
                    parametros.Add(e.EmisorCuit);
                    parametros.Add(e.EmisorIva);
                    parametros.Add(e.EmisorDomFiscal);
                    parametros.Add(idprestataria); //ID PRESTATARIA
                    parametros.Add(e.ReceptorNombre);
                    parametros.Add(e.ReceptorCuit);
                    parametros.Add(e.ReceptorIvanro);
                    parametros.Add(e.ReceptorPorciva);
                    parametros.Add(e.ReceptorDomFiscal);
                    parametros.Add(e.IDComprobante);                    
                    parametros.Add(e.Neto);
                    parametros.Add(e.Neto21);
                    parametros.Add(e.Neto105);
                    parametros.Add(e.NoGravado);
                    parametros.Add(e.Iva);
                    parametros.Add(e.Iva21);
                    parametros.Add(e.Iva105);
                    parametros.Add(e.Total);
                    if (e.FechaDesde >= DateTime.Today) { parametros.Add(e.FechaDesde); } else { parametros.Add(DBNull.Value); }
                    if (e.FechaHasta >= DateTime.Today) { parametros.Add(e.FechaHasta); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Estado);
                    parametros.Add(e.CaeNro);
                    parametros.Add(e.NumeroBarras);
                    if (e.FechaVtoCae >= DateTime.Today) { parametros.Add(e.FechaVtoCae); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Observaciones);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);

                    func.AccionBD(campos, parametros, "I", "FACTAMBUENC");

                    //DETALLES DE ENCABEZADO
                    Abmdetalles(e.Detalles, GetIdfactura(e.IDComprobante, sqlconn), e.ReceptorIvanro);

                    if (e.Estado == "A")
                    {
                        //ACTUALIZO LA BD DE ASOC CON LOS GUID GENERADOS (Solo aquellos aprobados)
                        ActualizaAsoc(GetIdfactura(e.IDComprobante, sqlconn), sqlconn);
                    }
                    
                }

                Procesadas = 0;
                cnb.Desconectar();
                sqlconn.Dispose();     

                //LIMPIO LOS COMPONENTES
                Limpiar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el encabezado facturas.\n" + e.Message, 0);
                return;
            }
        }

        //LIMPIO LOS COMPONENTES UNA VEZ FINALIZADAS LAS OPERACIONES
        private void Limpiar()
        {
            try
            {
                Comprobdetlst.Clear();
                Comprobplst.Clear();                
                Procesadas = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
              
        //ENVIO LA FACTURA A AFIP 
        private bool Procesoafipambu(ComprobPE enc, AfipProdDatos afip = null)
        {
            try
            {

                if (enc.ReceptorCuit == "" || enc.ReceptorCuit == "0" || afip == null
                    || enc.EmisorCuit == "") { return false; }

                //HAGO EL LOGIN 
                if (!func.LoginAfip(1, enc.EmisorCuit, afipprod: afip))                
                {
                    //ctrl.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return false;
                }
                              
                //LETRA DE COMPROBANTE
                string letra = func.GetLetracomprob(Convert.ToInt16(enc.EmisorIva), Convert.ToInt16(enc.ReceptorIvanro), enc.Iva, false);

                decimal nograv = 0, iva105 = 0, iva21 = 0, neto21 = 0, neto105 = 0;
                short c1 = 0, c2 = 0, c3 = 0;
                
                //IVA Y CONCEPTO
                foreach (ComprobPD d in enc.Detalles)
                {

                    if (d.Iva > 0 && d.IvaPorc > 0)
                    {
                        decimal calciva = d.Neto * (d.IvaPorc / 100);
                        d.Iva = calciva;

                        if (d.IvaPorc == Convert.ToDecimal("10,50")) { iva105 += d.Iva; neto105 += d.Neto; }
                        else if (d.IvaPorc == 21) { iva21 += d.Iva; neto21 += d.Neto; }
                    }
                    else if (d.Iva <= 0)
                    {
                        nograv += d.NoGravado;
                    }
                                        
                    //CONCEPTO
                    if (d.Concepto == "1") { c1 += 1; }
                    else if (d.Concepto == "2") { c2 += 1; }
                    else if (d.Concepto == "3") { c3 += 1; }
                }
                
                
                //CONCEPTO P2
                int concep = 2;
                if (c2 == 0 && c3 == 0) { concep = 1; }
                else if (c1 == 0 && c2 == 0) { concep = 3; }

                //AGREGO LAS ALICUOTAS DE IVA                
                if (letra == "B" && enc.ReceptorIvanro != "4") { afip.setIva(3, enc.Total, 0); }
                else
                {
                    if (iva105 > 0) { afip.setIva(4, neto105, Convert.ToDecimal(iva105.ToString("0.00"))); }
                    if (iva21 > 0) { afip.setIva(5, neto21, Convert.ToDecimal(iva21.ToString("0.00"))); }
                }
                
                decimal neto = neto105 + neto21;
                decimal iva = iva105 + iva21;
                decimal total = neto + iva + nograv;
                        
                enc.Total = Convert.ToDecimal(total.ToString("0.00"));
                enc.Neto = Convert.ToDecimal(neto.ToString("0.00"));
                enc.Iva = Convert.ToDecimal(iva.ToString("0.00"));
                enc.NoGravado = Convert.ToDecimal(nograv.ToString("0.00"));

                afip.agregaFactura(1, enc.Fecha.ToString("yyyyMMdd"), enc.EmisorPuntoVta, "CUIT", Convert.ToInt64(enc.ReceptorCuit), //ENCABEZADO
                concep, enc.Neto, enc.Iva, enc.Total, enc.NoGravado, 0, 0, "pesos", 1, //IMPORTES
                enc.Fecha.ToString("yyyyMMdd"), enc.Fecha.ToString("yyyyMMdd"), enc.Fecha.ToString("yyyyMMdd"), //FECHAS SRV
                "FC", letra);
                
                if (afip.Estado) { enc.Estado = "A"; } else { enc.Estado = "R"; }

                enc.Letra = letra;                
                enc.Numero = afip.Nrofactura;
                enc.CaeNro = afip.Caenumero;
                enc.NumeroBarras = afip.CodigoBarras;
                enc.FechaDesde = enc.Fecha;
                enc.FechaHasta = enc.Fecha;
                
                if (afip.Fechavtocae != null && afip.Fechavtocae != "")
                {
                    string date = "";
                    date = afip.Fechavtocae.Substring(0, 4) + "-" + afip.Fechavtocae.Substring(4, 2) + "-" + afip.Fechavtocae.Substring(6, 2);
                    enc.FechaVtoCae = Convert.ToDateTime(date);
                }
                
                enc.Observaciones = afip.Observaciones;
                return true;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al notificar la factura a AFIP.\n" + e.Message, 0);
                return false;
            }
        }                

        //OBTENGO EL ID DE LA FACTURA SEGUN SU GUID
        public long GetIdfactura(string guid, SqlConnection sql = null)
        {
            try
            {
                string consulta = "SELECT ID_Registro FROM FACTAMBUENC WHERE Guid = '" + guid + "'";

                foreach (DataRow f in func.getColecciondatos(consulta, sql != null ? sql : null).Rows) { return Convert.ToInt64(f["ID_Registro"]); }

                return 0;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el id de la factura.\n" + e.Message, 0);
                return 0;
            }
        }

        //DETALLES DE LA FACTURA
        private void Abmdetalles(List<ComprobPD> d, long idencabezado, string ivacomp)
        {
            try
            {
                if (idencabezado <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_Encabezado");
                campos.Add("FechaPract");
                campos.Add("CodPract");
                campos.Add("DescrPract");
                campos.Add("Funcion");
                campos.Add("DocuPaci");
                campos.Add("NombrePaci");
                campos.Add("IvaPorc");
                campos.Add("Cantidad");
                campos.Add("Neto");
                campos.Add("NoGravado");
                campos.Add("Iva");
                campos.Add("Total");
                campos.Add("Guid");
                campos.Add("Puntero");

                foreach (ComprobPD deta in d)
                {
                    parametros.Clear();
                    
                    parametros.Add(idencabezado);
                    parametros.Add(deta.Fecha);
                    parametros.Add(deta.Practica);
                    parametros.Add(deta.PracticaNom);
                    parametros.Add(deta.Funcion);
                    parametros.Add(deta.PaciDocu);
                    parametros.Add(deta.PaciNombre);
                    parametros.Add(deta.IvaPorc);
                    parametros.Add(deta.Cantidad);                    
                    parametros.Add(deta.Neto);
                    parametros.Add(deta.NoGravado);
                    parametros.Add(deta.Iva);
                    parametros.Add(deta.Total);
                    parametros.Add(deta.IDEncabezado);
                    parametros.Add(deta.Puntero);

                    func.AccionBD(campos, parametros, "I", "FACTAMBUDET");
                }               
            
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el detalle de la factura.\n" + e.Message, 0);
                return;

            }
        }

        //CAMPOS DE LA TABLA FACTURA
        private ArrayList Camposfactambu()
        {

            ArrayList campos = new ArrayList();            

            campos.Add("Fecha");
            campos.Add("TipoComprobante");
            campos.Add("Letra");
            campos.Add("PuntoVenta");
            campos.Add("Numero");
            campos.Add("ID_Profesional");
            campos.Add("NombreProf");
            campos.Add("CuitProf");
            campos.Add("IvaProf");
            campos.Add("DomFiscalProf");
            campos.Add("ID_PrestDetalle");
            campos.Add("NombrePres");
            campos.Add("CuitPres");
            campos.Add("IvaPres");
            campos.Add("PorcIvaPres");
            campos.Add("DomFiscalPres");
            campos.Add("Guid");
            campos.Add("Neto");
            campos.Add("Neto21");
            campos.Add("Neto105");
            campos.Add("NoGravado");
            campos.Add("Iva");
            campos.Add("Iva21");
            campos.Add("Iva105");
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

        //RETORNO EL ID DEL PROFESIONAL (LO GUARDO SI NO EXISTE)
        private int GetIdProfesional(ComprobPE e, SqlConnection sq = null)
        {
            int retorno = 0;

            try
            {
                retorno = func.Getidprofesional(e.EmisorCodigo, sq);

                if (retorno <= 0)
                {
                    AltaProfesional(e);
                    retorno = func.Getidprofesional(e.EmisorCodigo, sq);
                }

                return retorno;
            }
            catch (Exception x)
            {
                ctrl.MensajeInfo("Ocurrió un error al obtener el id del profesional.\n" + x.Message, 0);
                return retorno;
            }
        }

        //ALTA DE PROFESIONAL
        private void AltaProfesional(ComprobPE e)
        {
            try
            {
                DateTime fecha;
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Codigo");
                campos.Add("Nombre");
                campos.Add("Cuit");
                campos.Add("ID_Iva");
                campos.Add("InicioActividad");
                campos.Add("DomFiscal");
                campos.Add("PuntoVenta");

                parametros.Add(e.EmisorCodigo);
                parametros.Add(e.EmisorNombre);
                parametros.Add(e.EmisorCuit);
                parametros.Add(Convert.ToInt16(e.EmisorIva));
                if (DateTime.TryParse(e.EmisorFinicioact, out fecha)) { parametros.Add(fecha); } else { parametros.Add(DBNull.Value);  }
                parametros.Add(e.EmisorDomFiscal);
                parametros.Add(e.EmisorPuntoVta);

                func.AccionBD(campos, parametros, "I", "PROFESIONALES");

            }
            catch (Exception x)
            {

                ctrl.MensajeInfo("Ocurrió un error al insertar el profesional.\n" + x.Message, 0);
                return;
            }
        }

        //RETORNO EL ID DE LA PRESTATARIA (LO GUARDO SI NO EXISTE)
        private int GetIdPrestatria(ComprobPE e, SqlConnection sq = null)
        {
            int retorno = 0;

            try
            {
                //VALIDO SI EXISTE LA PRESTATARIA
                int idprestataria = ExistePrestataria(Convert.ToInt64(e.ReceptorCuit), e, sq);

                if (idprestataria <= 0)
                {
                    AltaPrestataria(e);
                    idprestataria = ExistePrestataria(Convert.ToInt64(e.ReceptorCuit), e, sq);
                }

                if (idprestataria == 0) { return 0; }

                int iddetalle = ExisteCodDetalle(e, idprestataria, sq);

                if (iddetalle <= 0)
                {
                    AltaPresDetalle(e, idprestataria);
                    iddetalle = ExisteCodDetalle(e, idprestataria, sq);
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
        private int ExistePrestataria(long cuit, ComprobPE e, SqlConnection sq)
        {
            int retorno = 0;

            try
            {
                string consulta = "SELECT ID_Registro FROM PRESTATARIAS WHERE Cuit = " + cuit;

                foreach (DataRow f in func.getColecciondatos(consulta, sq).Rows)
                { retorno = Convert.ToInt32(f["ID_Registro"]); }

                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        //EXISTE EL CODIGO EN DETALLES
        private int ExisteCodDetalle(ComprobPE e, int idprestataria, SqlConnection sq)
        {
            int retorno = 0;

            try
            {
                string consulta = "SELECT ID_Registro FROM PRESTDETALLES WHERE Codigo = '" + e.ReceptorCodigo + "'";

                foreach (DataRow f in func.getColecciondatos(consulta, sq).Rows) { retorno = Convert.ToInt32(f["ID_Registro"]); }

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
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Nombre");
                campos.Add("Cuit");
                campos.Add("ID_Iva");
                campos.Add("DomicilioFiscal");
                

                parametros.Add(e.ReceptorNombre);
                parametros.Add(e.ReceptorCuit);
                parametros.Add(Convert.ToInt16(e.ReceptorIvanro));
                parametros.Add(e.ReceptorDomFiscal);
                

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
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_Prestataria");
                campos.Add("Codigo");
                campos.Add("Descripcion");
                campos.Add("PorcIva");

                parametros.Add(idprestataria);
                parametros.Add(e.ReceptorCodigo);
                parametros.Add(e.ReceptorNombreAsoc);
                parametros.Add(e.ReceptorPorciva);

                func.AccionBD(campos, parametros, "I", "PRESTDETALLES");

            }
            catch (Exception x)
            {

                ctrl.MensajeInfo("Ocurrió un error al insertar la prestataria.\n" + x.Message, 0);
                return;
            }
        }

        //ACTUALIZO GUID EN BD ASOC
        private void ActualizaAsoc(long idfactura, SqlConnection sq)
        {
            try
            {
                if (!func.hayConexion() || idfactura <= 0) { return; }

                //Procesadas = 0;
                string query = "";
                ConexionBD cb = new ConexionBD();
                sq = sq.State == ConnectionState.Open ? sq : cb.Conectar();
                
                query = "UPDATE AmdgoSis.dbo.ASOCMED2 SET" +
                                " export_guid = IFD.Guid, MED2COMP = CONCAT(Ltrim(Rtrim(IFE.Letra)), FORMAT(IFE.PuntoVenta, '0000')," +
                                " FORMAT(IFE.Numero, '00000000'))" +
                                " ,MED2MESA = '" + Periodo.Substring(0,6) + "1'" +                                
                                " FROM AmdgoSis.dbo.ASOCMED2 MED" +
                                " LEFT OUTER JOIN AmdgoInterno.dbo.FACTAMBUDET IFD ON(MED.MED2PUNT = IFD.Puntero)" +
                                " LEFT OUTER JOIN AmdgoInterno.dbo.FACTAMBUENC IFE ON(IFE.ID_Registro = IFD.ID_Encabezado)" +                                
                                " WHERE IFE.EstadoAf = 'A' AND IFE.ID_Registro = " + idfactura;

                SqlCommand cmd = new SqlCommand(query, sq);
                cmd.ExecuteNonQuery();

                cb.Desconectar();

            }
            catch (Exception x)
            {
                ctrl.MensajeInfo("Ocurrió un error al actualizar el id en asoc.\n" + x.Message, 0);
                return;
            }
        }

        //GENERO NOTA DE CREDITO A COMPROBANTE FC
        public void GeneraNotaCreditoDebito(long idfactura, decimal Total21, decimal Total105, decimal Nogravado, string tipo)
        {
            try
            {
                List<ComprobPE> comprobantes = new List<ComprobPE>();

                string consulta = "SELECT EN.ID_Registro, EN.TipoComprobante, EN.Fecha, EN.Letra, EN.PuntoVenta, EN.Numero, EN.ID_Profesional," +
                    " PR.Codigo AS CodigoProf, EN.NombreProf, EN.CuitProf, EN.IvaProf, EN.ID_PrestDetalle, PT.Codigo as CodigoPres," +
                    " EN.NombrePres, EN.CuitPres, EN.IvaPres, EN.PorcIvaPres, EN.Guid, EN.Neto, EN.Iva, EN.NoGravado, EN.Total" +                    
                    " FROM FACTAMBUENC EN" +
                    " LEFT OUTER JOIN PROFESIONALES PR ON(PR.ID_Registro = EN.ID_Profesional)" +
                    " LEFT OUTER JOIN PRESTDETALLES PT ON(PT.ID_Registro = EN.ID_PrestDetalle)" +
                    " WHERE EN.ID_Registro = " + idfactura;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    comprobantes.Add(new ComprobPE {
                        Fecha = func.Getfechorserver(),
                        Letra = f["Letra"].ToString().Trim(),
                        PuntoVta = Convert.ToInt32(f["PuntoVenta"]),
                        EmisorPuntoVta = Convert.ToInt32(f["PuntoVenta"]),
                        Numero = Convert.ToInt64(f["Numero"]),
                        EmisorCodigo = f["CodigoProf"].ToString().Trim(),
                        EmisorNombre = f["NombreProf"].ToString().Trim(),
                        EmisorCuit = f["CuitProf"].ToString().Trim(),
                        EmisorIva = f["IvaProf"].ToString().Trim(),
                        ReceptorCodigo = f["CodigoPres"].ToString().Trim(),
                        ReceptorNombre = f["NombrePres"].ToString().Trim(),
                        ReceptorCuit = f["CuitPres"].ToString().Trim(),
                        ReceptorIva = f["IvaPres"].ToString().Trim(),
                        ReceptorIvanro = f["IvaPres"].ToString().Trim(),
                        ReceptorPorciva = Convert.ToDecimal(f["PorcIvaPres"]),
                        Neto = 0,
                        Iva =0,
                        NoGravado = 0,
                        Total = 0,
                        ID_Factura = idfactura
                    });
                }

                ABMFactuambuNC(comprobantes, Total21, Total105, Nogravado, tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //ABM DE FACTURAS AMBULATORIO
        private void ABMFactuambuNC(List<ComprobPE> Listafacturas, decimal Total21, decimal Total105, decimal Nogravado, string tipo)
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
                    if (e.EmisorCuit.Trim() == "") { continue; }
                    AfipProdDatos afip = new AfipProdDatos();

                    Procesadas++;

                    if (!func.hayConexion()) { ctrl.MensajeInfo("La conexión a internet fue interrumpida.\nEl proceso debe ser retomado.", 1); return; }
                    
                    //NO HAY INFORMACION DE PUNTO DE VENTA DISPONIBLE
                    if (e.EmisorPuntoVta == 0) { continue; }

                    int idprofesional = GetIdProfesional(e);
                    int idprestataria = GetIdPrestatria(e);
                    
                    ProcesoafipambuNC(e, Total21, Total105, Nogravado, tipo, afip);

                    parametros.Clear();

                    parametros.Add(fechahoy);
                    parametros.Add(tipo);
                    parametros.Add(e.Letra);
                    parametros.Add(e.PuntoVta);
                    parametros.Add(e.Numero);
                    parametros.Add(idprofesional); //ID DEL PROFESIONAL
                    parametros.Add(e.EmisorNombre);
                    parametros.Add(e.EmisorCuit);
                    parametros.Add(e.EmisorIva);
                    parametros.Add(e.EmisorDomFiscal);
                    parametros.Add(idprestataria); //ID PRESTATARIA
                    parametros.Add(e.ReceptorNombre);
                    parametros.Add(e.ReceptorCuit);
                    parametros.Add(e.ReceptorIvanro);
                    parametros.Add(e.ReceptorPorciva);
                    parametros.Add(e.ReceptorDomFiscal);
                    parametros.Add(e.IDComprobante);
                    parametros.Add(e.Neto);
                    parametros.Add(e.Neto21);
                    parametros.Add(e.Neto105);
                    parametros.Add(e.NoGravado);
                    parametros.Add(e.Iva);
                    parametros.Add(e.Iva21);
                    parametros.Add(e.Iva105);

                    parametros.Add(e.Total);
                    if (e.FechaDesde >= DateTime.Today) { parametros.Add(e.FechaDesde); } else { parametros.Add(DBNull.Value); }
                    if (e.FechaHasta >= DateTime.Today) { parametros.Add(e.FechaHasta); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Estado);
                    parametros.Add(e.CaeNro);
                    parametros.Add(e.NumeroBarras);
                    if (e.FechaVtoCae >= DateTime.Today) { parametros.Add(e.FechaVtoCae); } else { parametros.Add(DBNull.Value); }
                    parametros.Add(e.Observaciones);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(fechahoy);

                    func.AccionBD(campos, parametros, "I", "FACTAMBUENC");

                    //COMPROBANTES ASOCIADOS
                    GuardorelacionNC(e.ID_Factura, e.IDComprobante, tipo);
                }

                Procesadas = 0;
                
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al generar el encabezado facturas.\n" + e.Message, 0);
                return;
            }
        }

        //ENVIO LA NOTA DE CREDITO A AFIP 
        private void ProcesoafipambuNC(ComprobPE enc, decimal Total21, decimal Total105, decimal Nogravado, string tipo,
            AfipProdDatos afip = null)
        {
            try
            {

                if (enc.ReceptorCuit == "" || enc.ReceptorCuit == "0" || afip == null) { return; }

                //HAGO EL LOGIN 
                if (!func.LoginAfip(1, enc.EmisorCuit, afipprod: afip))
                {
                    ctrl.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return;
                }
                
                //LETRA DE COMPROBANTE
                string letra = func.GetLetracomprob(Convert.ToInt16(enc.EmisorIva), Convert.ToInt16(enc.ReceptorIvanro), enc.Iva, false);
                
                decimal neto21 = 0, neto105 = 0, iva21 = 0, iva105 = 0, total = 0, neto = 0, iva = 0;

                if (Total21 > 0)
                {
                    iva21 = Total21 * Convert.ToDecimal("0,21");
                    neto21 = Total21;// + iva21;

                    enc.Neto21 = Convert.ToDecimal(neto21.ToString("0.00"));
                    enc.Iva21 = Convert.ToDecimal(iva21.ToString("0.00"));
                }

                if (Total105 > 0)
                {
                    iva105 = Total105 * Convert.ToDecimal("0,105");
                    neto105 = Total105;// + iva105;

                    enc.Neto105 = Convert.ToDecimal(neto105.ToString("0.00"));
                    enc.Iva105= Convert.ToDecimal(iva105.ToString("0.00"));
                }

                if (Nogravado > 0)
                {
                    enc.NoGravado = Nogravado;
                }

                neto = neto21 + neto105;
                iva = iva21 + iva105;
                total = neto + iva + Nogravado;
                                
                enc.Neto = Convert.ToDecimal(neto.ToString("0.00"));                
                enc.Iva = Convert.ToDecimal(iva.ToString("0.00"));                
                enc.Total = Convert.ToDecimal(total.ToString("0.00"));

                //AGREGO LAS ALICUOTAS DE IVA                
                //if (Nogravado > 0) { afip.setIva(3, enc.Neto, 0); }
                if (neto105 > 0) { afip.setIva(4, enc.Neto105, enc.Iva105); }
                if (neto21 > 0) { afip.setIva(5, enc.Neto21, enc.Iva21); }

                afip.setCompasociados("FC" + enc.Letra, enc.PuntoVta, enc.Numero);

                afip.agregaFactura(1, func.Getfechorserver().ToString("yyyyMMdd"), enc.EmisorPuntoVta, "CUIT", Convert.ToInt64(enc.ReceptorCuit), //ENCABEZADO
                1, enc.Neto, enc.Iva, enc.Total, enc.NoGravado, 0, 0, "pesos", 1, //IMPORTES
                "", "", "", //FECHAS SRV
                tipo, letra);

                if (afip.Estado) { enc.Estado = "A"; } else { enc.Estado = "R"; }

                enc.Letra = letra;                
                enc.Numero = afip.Nrofactura;
                enc.CaeNro = afip.Caenumero;
                enc.NumeroBarras = afip.CodigoBarras;
                enc.FechaDesde = enc.Fecha;
                enc.FechaHasta = enc.Fecha;

                if (afip.Fechavtocae != "")
                {
                    string date = "";
                    date = afip.Fechavtocae.Substring(0, 4) + "-" + afip.Fechavtocae.Substring(4, 2) + "-" + afip.Fechavtocae.Substring(6, 2);
                    enc.FechaVtoCae = Convert.ToDateTime(date);
                }

                enc.Observaciones = afip.Observaciones;

            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al notificar la factura a AFIP.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO LOS REGISTROS EN LA TABLA DE RELACION
        private void GuardorelacionNC(long idfactura, string guid, string tipo)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                if (tipo == "NC") { campos.Add("ID_NotaCredito"); }
                else { campos.Add("ID_NotaDebito"); }
                campos.Add("ID_Factura");
                
                parametros.Clear();
                parametros.Add(GetIdfactura(guid));
                parametros.Add(idfactura);
                
                func.AccionBD(campos, parametros, "I", "FACTAMBUREL");                
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al guardar la relacion de comprobantes.\n" + e.Message, 0);
                return;
            }
        }
        
    }
    
    //CLASE DE COMPROBANTES PENDIENTES DE AUTORIZACION CONTRA AFIP
    public class ComprobPE
    {
        public string IDComprobante { get; private set; } = Guid.NewGuid().ToString();
        public string TipoComprobante { get; set; } = "FC";
        public DateTime Fecha { get; set; } 
        public string EmisorCodigo { get; set; } = "";
        public string EmisorNombre { get; set; } = "";
        public string EmisorCuit { get; set; } = "";
        public string EmisorIva { get; set; } = "";
        public string EmisorDomFiscal { get; set; } = "";
        public string EmisorFinicioact { get; set; }
        public int EmisorPuntoVta { get; set; } = 0;
        public string ReceptorCodigo { get; set; } = "";
        public string ReceptorNombre { get; set; } = "";
        public string ReceptorCuit { get; set; } = "";
        public string ReceptorIva { get; set; } = "";
        public string ReceptorIvanro { get; set; } = "";
        public string ReceptorNombreAsoc { get; set; } = "";
        public decimal ReceptorPorciva { get; set; } = 0;
        public bool ReceptorIvaOculto { get; set; }= false;
        public string ReceptorDomFiscal { get; set; } = "";
        public decimal Neto { get; set; } = 0;
        public decimal Neto21 { get; set; } = 0;
        public decimal Neto105 { get; set; } = 0;
        public decimal NoGravado { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Iva21 { get; set; } = 0;
        public decimal Iva105 { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public List<ComprobPD> Detalles { get; set; } = new List<ComprobPD>();

        //DATOS A LLENAR DESDE AFIP

        public string Letra { get; set; } = "";
        public int PuntoVta { get; set; } = 0;
        public long Numero { get; set; } = 0;
        public string Estado { get; set; } = "";
        public string CaeNro { get; set; } = "";
        public string NumeroBarras { get; set; } = "";
        public DateTime FechaVtoCae { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Observaciones { get; set; } = "";
        
        //PARA RELACION DE COMPROBANTES (FC A NC O ND)
        public long ID_Factura { get; set; } = 0;
        
    }

    //DETALLES DE COMPROBANTES
    public class ComprobPD
    {
        public string IDComprobante { get; private set; } = Guid.NewGuid().ToString();
        public string IDEncabezado { get; set; }
        public DateTime Fecha { get; set; } = new DateTime();
        public string Practica { get; set; } = "";
        public string PracticaNom { get; set; } = "";
        public string PaciDocu { get; set; } = "";
        public string PaciNombre { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal NoGravado { get; set; } = 0;
        public decimal IvaPorc { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public long Puntero { get; set; } = 0;
        public string Funcion { get; set; } = "";
        public string Concepto { get; set; } = "";
        public string Profesional { get; set; } = "";
        public string Prestataria { get; set; } = "";
    }
    
    //CLASE DE COMPROBANTES FALTANTES DE AUDITAR
    public class Faltantes
    {
        public short Seguimiento { get; set; } =0;
        public short Audita { get; set; } = 0;
        public string ProfCodigo { get; set; } = "";
        public string ProfNombre { get; set; } = "";
    }

}
