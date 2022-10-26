using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace AMDGOINT.Formularios.Aranceles
{
    class Discusionescls
    {
        //PUBLICAS
        public List<DiscusionEncabezado> encabezadoslst = new List<DiscusionEncabezado>();

        //PRIVADAS
        private List<DiscusionDetalle> detalleslst = new List<DiscusionDetalle>();
        private List<DiscusionExtra> extraslst = new List<DiscusionExtra>();
        private List<Prestadoras> prestadoraslst = new List<Prestadoras>();
        private List<DiscusionOtros> otroslst = new List<DiscusionOtros>();
        private List<DiscusionGrupoObs> gruposobs = new List<DiscusionGrupoObs>();
        private List<DiscusionRespuestasAM> respuestasam = new List<DiscusionRespuestasAM>();
        private List<DiscusionRespuestasOS> respuestasos = new List<DiscusionRespuestasOS>();

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();        

        //ENCABEZADOS
        public void ListarRegistros()
        {
            try
            {
                ConexionBD bd = new ConexionBD();
                SqlConnection con = bd.Conectar();

                encabezadoslst.Clear();

                string c = "SELECT DE.ID_Registro, DE.ID_AranValoriza, DE.ID_GrupoValor, DE.FechaInicio, DE.FechaCierre, DE.Estado," +
                           " GV.Codigo as CodigoGupo, GV.Descripcion as DescripcionGrupo, PT.Codigo," +
                           " DE.FechaImpacto, PT.Descripcion AS TipoNombre," +

                           " ISNULL(STUFF((SELECT ',' + PD.Codigo FROM DISCGRPVALHIST DH" +
                           " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           " WHERE DH.ID_Encabezado = DE.ID_Registro" +
                           " FOR XML PATH('')), 1, LEN(','), ''), '') AS CodigosConjuntos," +

                           " ISNULL(STUFF((SELECT DISTINCT '*' + CONCAT('(', PR.Nombre, ' ', PR.Cuit, ' | ', " +
                                                    " ISNULL(STUFF((SELECT ' ' + PD.Codigo + ' - ' " +                                                    
                                                    " FROM DISCGRPVALHIST DH1" +
                                                    " LEFT OUTER JOIN PRESTDETALLES PD ON (PD.ID_Registro = DH1.ID_PrestDetalle)" +
                                                    " WHERE DH1.ID_Encabezado = DE.ID_Registro" +
                                                    " FOR XML PATH('')), 1, LEN(','), ''), ''), ')')" +
                           " FROM DISCGRPVALHIST DH" +
                           " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           " WHERE DH.ID_Encabezado = DE.ID_Registro" +
                           " FOR XML PATH('')), 1, LEN(','), ''), '') AS PrestatariasConjunto," +

                           " AE.Fecha AS FechaAranBase, DE.Visible" +
                           " FROM DISCUSIONENC DE" +
                           " LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = DE.ID_AranValoriza)" +
                           " LEFT OUTER JOIN PRESTGRPVAL GV ON(GV.ID_Registro = DE.ID_GrupoValor)" +
                           " LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = GV.ID_PrestaTipo)" +
                           " WHERE DE.Visible = 1";

                foreach (DataRow r in func.getColecciondatos(c, con).Rows)
                {
                    encabezadoslst.Add(new DiscusionEncabezado
                    {
                        IDRegistro = Convert.ToInt32(r["ID_Registro"]),
                        FechaAranBase = r["FechaAranBase"] != DBNull.Value ? Convert.ToDateTime(r["FechaAranBase"]) : DateTime.MinValue,
                        FechaInicio = r["FechaInicio"] != DBNull.Value ? Convert.ToDateTime(r["FechaInicio"]) : DateTime.MinValue,
                        FechaCierre = r["FechaCierre"] != DBNull.Value ? Convert.ToDateTime(r["FechaCierre"]) : DateTime.MinValue,
                        FechaImpacto = r["FechaImpacto"] != DBNull.Value ? Convert.ToDateTime(r["FechaImpacto"]) : DateTime.MinValue,
                        IDAranvaloriza = Convert.ToInt32(r["ID_AranValoriza"]),
                        IDGrupoOs = Convert.ToInt32(r["ID_GrupoValor"]),
                        TipoValorizacion = r["Codigo"].ToString(),
                        TipoNombre = r["TipoNombre"].ToString(),
                        Estado = Convert.ToInt16(r["Estado"]),
                        //Prestataria = r["Prestataria"].ToString().Trim(),
                        //CuitPrestataria = Convert.ToInt64(r["Cuit"]),
                        PrestatariaConjunto = r["PrestatariasConjunto"].ToString().Trim(),
                        CodigoGupo = r["CodigoGupo"].ToString().Trim(),
                        CodigosConjuntos = r["CodigosConjuntos"].ToString().Trim(),
                        DescripcionGrupo = r["DescripcionGrupo"].ToString().Trim(),
                        AbraviaGrupo = r["Codigo"].ToString().Trim(),
                        Visible = Convert.ToBoolean(r["Visible"])
                    });
                }


                //DETALLES
                ListarDetalles(con);

                foreach (var r in encabezadoslst)
                {
                    r.Detalles = detalleslst.Where(s => s.IDEncabezado == r.IDRegistro).ToList();
                }

                //EXTRAS
                ListarExtras(con);

                foreach (var r in encabezadoslst)
                {
                    r.Extras = extraslst.Where(s => s.IDEncabezado == r.IDRegistro).ToList();
                }

                //GRUPOS OBS 
                ListarGruposobs(con);

                foreach (var r in encabezadoslst)
                {
                    r.GruposObs = gruposobs.Where(s => s.IDEncabezado == r.IDRegistro).ToList();
                }

                //RESPUESTAS
                ListarRespuestas(con);

                foreach (var r in encabezadoslst)
                {
                    r.Respuestas = respuestasam.Where(s => s.IDEncabezado == r.IDRegistro).ToList();
                }

                //OTROS
                ListarOtros(con);

                foreach (var r in encabezadoslst)
                {
                    r.Otros = otroslst.Where(s => s.IDEncabezado == r.IDRegistro).ToList();
                }

                //PRESTADORAS
                ListarPrestadoras(con);

                foreach (var r in encabezadoslst)
                {
                    r.Prestadoras = prestadoraslst.Where(s => s.IDDiscusion == r.IDRegistro).ToList();
                }

                con.Close();
                con.Dispose();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los encabezados\n. {e.Message}", 0);
                return;
            }
        }

        //LISTA PRESTADORAS ASOCIADAS
        private void ListarPrestadoras(SqlConnection conn)
        {
            try
            {
                prestadoraslst.Clear();

                string c = "SELECT DE.ID_Registro AS IDDiscusion, PR.Nombre AS NombreLegal, PR.Cuit, PD.Codigo AS PlanCodigo, PD.Descripcion AS PlanNombre," + 
                           " PG.Codigo AS AgrupadorCodigo, PG.Descripcion AS AgrupadorNombre," +
                           " ISNULL(STUFF((SELECT DISTINCT '*' + CONCAT(ISNULL(STUFF((SELECT ' ' + PD.Codigo + ' ' + PD.Abreviatura + ' - '" +
                           "     FROM DISCGRPVALHIST DH1" +
                           "     LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH1.ID_PrestDetalle)" +
                           "     WHERE DH1.ID_Encabezado = DE.ID_Registro" +
                           "     FOR XML PATH('')), 1, LEN(','), ''), ''),'')" +
                           "     FROM DISCGRPVALHIST DH" +
                           "     LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           "     LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           "     WHERE DH.ID_Encabezado = DE.ID_Registro" +
                           "     FOR XML PATH('')), 1, LEN(','), ''), '') AS CodigosDescripciones" +
                           " FROM DISCUSIONENC DE" +
                           " LEFT OUTER JOIN DISCGRPVALHIST DH ON(DH.ID_Encabezado = DE.ID_Registro)" +
                           " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           " LEFT OUTER JOIN PRESTGRPVAL PG ON(PG.ID_Registro = DE.ID_GrupoValor)";

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    prestadoraslst.Add(new Prestadoras
                    {
                        IDDiscusion = Convert.ToInt32(r["IDDiscusion"]),
                        NombreLegal = r["NombreLegal"].ToString().Trim(),
                        Cuit = Convert.ToInt64(r["Cuit"]),
                        AgrupadorCodigo = r["AgrupadorCodigo"].ToString().Trim(),
                        AgrupadorNombre = r["AgrupadorNombre"].ToString().Trim(),
                        PlanCodigo = r["PlanCodigo"].ToString().Trim(),
                        PlanNombre = r["PlanNombre"].ToString().Trim(),
                        CodigosDescripciones = r["CodigosDescripciones"].ToString().Trim()
                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las prestadoras\n. {e.Message}", 0);
                return;
            }
        }

        //DETALLES
        public void ListarDetalles(SqlConnection conn)
        {
            try
            {
                detalleslst.Clear();

                string c = "SELECT DD.ID_Registro, DD.ID_Encabezado, ISNULL(DD.FechaNeg, '') AS FechaNeg, DD.ID_Practica, DD.ID_Funcion, DD.Valor, DD.ValorCoseguro, DD.ValorCopago," +
                           " DD.Observacion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion, ISNULL(PM.Codigo, '') AS CodigoPractica," +
                           " ISNULL(PM.Descripcion, '') AS DescripcionPractica, ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion,'') As Grupo,  PG.Orden as GrupoOrden," +
                           " DD.CodigoOs, DD.Observacion, DD.EsAmdgo, DD.Guid, PG.ID_Registro as IDGrupo, PG.Observacion AS GrupoObs, DD.Aplicado," +
                           " PM.ID_Arancel, PM.ID_Gasto, DD.CodigoGasto" +
                           " FROM DISCUSIONDET DD" +
                           " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = DD.ID_Funcion)" +
                           " LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                           " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)";                                

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    detalleslst.Add(new DiscusionDetalle
                    {                        
                        IDRegistro = Convert.ToInt64(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDPractAm = Convert.ToInt32(r["ID_Practica"]),
                        FechaNeg = func.Trydatetimeconvert(r["FechaNeg"].ToString()),
                        Valor = Convert.ToDecimal(r["Valor"]),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoPractica = r["Grupo"].ToString(),
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        CodigoOs = r["CodigoOs"].ToString(),
                        CodigoGasto = r["CodigoGasto"].ToString(),
                        Obsdetalle = r["Observacion"].ToString(),
                        TipoValor = Convert.ToByte(r["EsAmdgo"]),
                        GrupoObservacion = r["GrupoObs"].ToString().Trim(),
                        Aplicado = (short)r["Aplicado"],
                        ValorCoseguro = Convert.ToDecimal(r["ValorCoseguro"]),
                        ValorCopago = Convert.ToDecimal(r["ValorCopago"])                        

                    });
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los detalles\n. {e.Message}", 0);
                return;
            }
        }

        //EXTRAS
        public void ListarExtras(SqlConnection conn)
        {
            try
            {
                extraslst.Clear();

                string c = "SELECT DD.ID_Registro, DD.ID_Encabezado, DD.Descripcion" +
                           " FROM DISCUSIONEXTRA DD";                           

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    extraslst.Add(new DiscusionExtra
                    {
                        IDRegistro = Convert.ToInt64(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        Descripcion = r["Descripcion"].ToString().Trim()

                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los extras\n. {e.Message}", 0);
                return;
            }
        }

        //GRUPOS OBSERVACIONES
        public void ListarGruposobs(SqlConnection conn)
        {
            try
            {
                gruposobs.Clear();

                string c = "SELECT DO.ID_Registro, DO.ID_Encabezado, DO.ID_GrupoPractica, PG.Descripcion AS Grupo, DO.Observacion" +
                           " FROM DISCUSIONGRPOBS DO" +
                           " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = DO.ID_GrupoPractica)";

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    gruposobs.Add(new DiscusionGrupoObs
                    {
                        IDRegistro = Convert.ToInt32(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        IDGrupoPractica = Convert.ToInt32(r["ID_GrupoPractica"]),
                        Grupo = r["Grupo"].ToString().Trim(),
                        Observacion = r["Observacion"].ToString().Trim()

                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las observaciones de grupo\n. {e.Message}", 0);
                return;
            }
        }

        //RESPUESTAS DE PRESTATARUAS
        public void ListarRespuestas(SqlConnection conn)
        {
            try
            {
                DiscusionRespuestasOS os = new DiscusionRespuestasOS();

                respuestasam.Clear();
                respuestasos.Clear();

                //RESPUESTAS AM
                string c = "SELECT ID_Registro, ID_Encabezado, Numero, Texto FROM DISCUSIONRPTAM";

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    respuestasam.Add(new DiscusionRespuestasAM
                    {
                        IDRegistro = Convert.ToInt32(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        Numero = Convert.ToInt16(r["Numero"]),
                        Texto = r["Texto"].ToString().Trim()
                    });
                }

                //RESPUESTAS OS
                c = "SELECT ID_Registro, ID_Respuesta, Observacion FROM DISCUSIONRPTPOS";

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    respuestasos.Add(new DiscusionRespuestasOS
                    {
                        IDRegistro = Convert.ToInt32(r["ID_Registro"]),
                        IDRespuesta = Convert.ToInt32(r["ID_Respuesta"]),
                        Observacion = r["Observacion"].ToString().Trim()
                    });
                }


                //ASOCIO LAS RESPUESTAS DE OS A CADA RESPUESTA AM
                foreach (DiscusionRespuestasAM a in respuestasam)
                {
                    a.RespuestaOs = new BindingList<DiscusionRespuestasOS>(os.Clone(respuestasos.Where(w => w.IDRespuesta == a.IDRegistro).ToList()));
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las respuestas\n.{e.Message}", 0);
                return;
            }
        }

        //DISCUSIONES OTROS
        public void ListarOtros(SqlConnection conn)
        {
            try
            {
                otroslst.Clear();

                string c = "SELECT ID_Registro, ID_Encabezado, CodigoOs, CodigoAm, Descripcion, Observacion, Valor FROM DISCUSIONOTROS";

                foreach (DataRow r in func.getColecciondatos(c, conn).Rows)
                {
                    otroslst.Add(new DiscusionOtros
                    {
                        IDRegistro = Convert.ToInt32(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        CodigoOs = r["CodigoOs"].ToString().Trim(),
                        CodigoAm = r["CodigoAm"].ToString().Trim(),
                        Descripcion = r["Descripcion"].ToString().Trim(),
                        Observacion = r["Observacion"].ToString().Trim(),
                        Valor = r["Valor"].ToString().Trim()

                    });
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los otros-varios\n. {e.Message}", 0);
                return;
            }
        }
        
        //NUEVOS DETALLES
        public List<DiscusionDetalle> Agregardetalles(string tipoobra, int idgrupovalores, int idaranvaloriza, byte tipovalor)
        {
            try
            {
                List<DiscusionDetalle> detail = new List<DiscusionDetalle>();

                if (tipoobra == "" || idgrupovalores <= 0 || idaranvaloriza <= 0) { return detail; }

                int cantidad = 0;

                //VALIDO SI HAY REGISTROS EN LA DISCUSION DETALLE DE ESE GRUPO 
                string ca = $"SELECT ISNULL(COUNT(AD.ID_Registro),0) AS ID_Registro" + 
                            $" FROM DISCUSIONDET AD" +
                            $" LEFT OUTER JOIN DISCUSIONENC AE ON(AE.ID_Registro = AD.ID_Encabezado)" +
                            $" WHERE AE.ID_GrupoValor = {idgrupovalores} AND AE.Estado >= 1 AND AD.Aplicado = 2 AND AE.FechaImpacto = " +
                            $"(SELECT MAX(DE.FechaImpacto) FROM DISCUSIONENC DE WHERE DE.ID_GrupoValor = {idgrupovalores} AND DE.Estado >= 1)";

                DataRow n = func.getColecciondatos(ca).Rows[0];
                cantidad = Convert.ToInt32(n["ID_Registro"]);

                string c = "";

                //SI NO SE CARGO UNA VALORIZACION ANTERIORMENTE
                if (cantidad <= 0)
                {
                    c = $"SELECT ISNULL(PM.ID_Registro,0) AS ID_PractAm, ISNULL(PM.ID_Funcion, 0) AS ID_Funcion, ISNULL(PM.Codigo, '') AS CodigoPractica, '' AS CodigoOs," +
                      $" ISNULL(PM.Descripcion, '') AS DescripcionPractica, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Letra,'') AS LetraFuncion," +
                      $" ISNULL(FU.Descripcion,'') AS DescripcionFuncion, ISNULL(PG.Descripcion,'') As Grupo, ISNULL(ARD.ValorPrepaga,0) AS ValorPrepaga," +
                      $" ISNULL(ARD.ValorOs, 0) AS ValorOs, ISNULL(ARD.ValorArt, 0) AS ValorArt, ISNULL(ARD.ValorCaja, 0) AS ValorCaja, ISNULL(ARD.ObsPrepaga, '') AS ObsPrepaga," +
                      $" ISNULL(ARD.ObsOs, '') AS ObsOs, ISNULL(ARD.ObsArt, '') AS ObsArt, ISNULL(ARD.ObsCaja, '') AS ObsCaja, PG.Orden as GrupoOrden," +
                      $" PG.ID_Registro as IDGrupo, '' AS Observacion, 0 AS ValorCoseguro, 0 AS ValorCopago, '' AS CodigoGasto, PM.ID_Arancel, PM.ID_Gasto, 0 AS ValorAN" +
                      $" FROM ARANVALORIZADET ARD" +
                      $" LEFT OUTER JOIN ARANVALORIZAENC ARE ON(ARE.ID_Registro = ARD.ID_Encabezado)" +
                      $" LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = ARD.ID_PractAm)" +
                      $" LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                      $" LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                      $" WHERE ARE.ID_Registro = {idaranvaloriza} AND PM.ID_Registro > 0";
                }
                else //SI YA EXISTE UNA VALORIZACION
                {
                    c = $"SELECT ISNULL(PM.ID_Registro,0) AS ID_PractAm, ISNULL(PM.ID_Funcion, 0) AS ID_Funcion, ISNULL(PM.Codigo, '') AS CodigoPractica, DD.CodigoOs," +                        
                        $" ISNULL(PM.Descripcion, '') AS DescripcionPractica, ISNULL(FU.Codigo, '') AS CodigoFuncion, ISNULL(FU.Letra, '') AS LetraFuncion," + 
                        $" ISNULL(FU.Descripcion, '') AS DescripcionFuncion, ISNULL(PG.Descripcion, '') As Grupo, ISNULL(ARD.ValorPrepaga, 0) AS ValorPrepaga,"  +
                        $" ISNULL(ARD.ValorOs, 0) AS ValorOs, ISNULL(ARD.ValorArt, 0) AS ValorArt, ISNULL(ARD.ValorCaja, 0) AS ValorCaja, ISNULL(ARD.ObsPrepaga, '') AS ObsPrepaga," +
                        $" ISNULL(ARD.ObsOs, '') AS ObsOs, ISNULL(ARD.ObsArt, '') AS ObsArt, ISNULL(ARD.ObsCaja, '') AS ObsCaja, PG.Orden as GrupoOrden," +
                        $" PG.ID_Registro as IDGrupo, DD.Observacion, DD.ValorCoseguro, DD.ValorCopago, DD.CodigoGasto, PM.ID_Arancel, PM.ID_Gasto, DD.Valor AS ValorAN" +
                        $" FROM DISCUSIONDET DD" +
                        $" LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DD.ID_Encabezado)" +
                        $" LEFT OUTER JOIN ARANVALORIZADET ARD ON(ARD.ID_PractAm = DD.ID_Practica AND ARD.ID_Encabezado = DE.ID_AranValoriza)" +
                        $" LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                        $" LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                        $" LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                        $" WHERE DE.ID_GrupoValor = {idgrupovalores} AND DE.Estado >= 1 AND DD.Aplicado = 2 AND DE.FechaInicio =" +                        
                        $" (SELECT MAX(DE1.FechaInicio) FROM DISCUSIONENC DE1 WHERE DE1.ID_GrupoValor = {idgrupovalores} AND DE1.Estado >= 1)" +
                        //CON ESTA LINEA, CONTEMPLO LOS CASOS EN LOS QUE SE CARGA MAS DE UNA EPOCA EL MISMO DIA, POR LO TANTO SIEMPRE TRAERÁ LA MÁXIMA CERRADA. (ID MAS ALTO)
                        //PODRIA HACERLO CON LA FECHA DE IMPACTO, PERO EN PROCESAMIENTO EL ID NUMERICO ES MAS RAPIDO
                        $" AND DE.ID_Registro = (SELECT MAX(DE2.ID_Registro) FROM DISCUSIONENC DE2 WHERE DE2.ID_GrupoValor = {idgrupovalores} AND DE2.Estado >= 1)";                        
                }                

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    detail.Add(new DiscusionDetalle
                    {
                        FechaNeg = DateTime.Now,
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_PractAm"]),
                        Valor = getValorcrp(tipoobra, Convert.ToDecimal(r["ValorPrepaga"]), Convert.ToDecimal(r["ValorOs"]), Convert.ToDecimal(r["ValorCaja"]),
                        Convert.ToDecimal(r["ValorArt"]), Convert.ToDecimal(r["ValorAN"])),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        CodigoOs = cantidad <= 0 ? r["CodigoPractica"].ToString().Trim() : r["CodigoOs"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        Obsdetalle = getObservacioncrp(tipoobra, r["ObsPrepaga"].ToString().Trim(), r["ObsOs"].ToString().Trim(),
                                                        r["ObsCaja"].ToString().Trim(), r["ObsArt"].ToString().Trim(), r["Observacion"].ToString().Trim()),
                        TipoValor = tipovalor,
                        ValorCoseguro = Convert.ToDecimal(r["ValorCoseguro"]),
                        ValorCopago = Convert.ToDecimal(r["ValorCopago"]),
                        CodigoGasto = r["CodigoGasto"].ToString().Trim()

                    });
                }

                return detail;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al agregar los detalles.\n {e.Message}", 0);
                return new List<DiscusionDetalle>();
            }
        }

        //NUEVAS OBSERVACIONES
        public List<DiscusionGrupoObs> Agregagruposobs(int idgrupovalor)
        {            
            try
            {
                List<DiscusionGrupoObs> lista = new List<DiscusionGrupoObs>();

                //VALIDO SI HAY REGISTROS EN EL ARANDETALLE 
                string ca = $"SELECT PG.ID_Registro, Descripcion AS Grupo, DO.Observacion" +
                            $" FROM PRACTGRUPOS PG" +
                            $" LEFT OUTER JOIN DISCUSIONGRPOBS DO ON(DO.ID_GrupoPractica = PG.ID_Registro)" +
                            $" LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DO.ID_Encabezado)" +
                            $" WHERE DE.ID_GrupoValor = {idgrupovalor} AND DE.FechaImpacto = (SELECT MAX(D1.FechaImpacto) " +
                            $"                         FROM DISCUSIONENC D1 " +
                            $"                         WHERE D1.ID_GrupoValor = {idgrupovalor} AND D1.Estado >= 1)";

                DataRowCollection filas = func.getColecciondatos(ca).Rows;

                if (filas.Count > 0)
                {
                    foreach (DataRow r in filas)
                    {
                        lista.Add(new DiscusionGrupoObs
                        {
                            IDGrupoPractica = Convert.ToInt32(r["ID_Registro"]),
                            Grupo = r["Grupo"].ToString().Trim(),
                            Observacion = r["Observacion"].ToString().Trim()
                        });
                    }
                }
                else
                {
                    string c = "SELECT ID_Registro, Descripcion AS Grupo, Observacion FROM PRACTGRUPOS";

                    foreach (DataRow r in func.getColecciondatos(c).Rows)
                    {
                        lista.Add(new DiscusionGrupoObs
                        {
                            IDGrupoPractica = Convert.ToInt32(r["ID_Registro"]),
                            Grupo = r["Grupo"].ToString().Trim(),
                            Observacion = r["Observacion"].ToString().Trim()
                        });
                    }
                }

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar la lista de grupos.\n {e.Message}", 0);
                return new List<DiscusionGrupoObs>(); 
            }
        }

        //NUEVOS EXTRAS
        public List<DiscusionExtra> Agregaextras(int idgrupovalor)
        {
            try
            {
                List<DiscusionExtra> lista = new List<DiscusionExtra>();

                //VALIDO SI HAY REGISTROS EN EL ARANDETALLE 
                string ca = $"SELECT DIE.ID_Registro, DIE.Descripcion" +
                            $" FROM DISCUSIONEXTRA DIE" +
                            $" LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DIE.ID_Encabezado)" +
                            $" WHERE DE.ID_GrupoValor = {idgrupovalor} AND DE.FechaImpacto = (SELECT MAX(D1.FechaImpacto)" +
                            $" FROM DISCUSIONENC D1"+
                            $" WHERE D1.ID_GrupoValor = {idgrupovalor} AND D1.Estado >= 1)";

                DataRowCollection filas = func.getColecciondatos(ca).Rows;

                if (filas.Count > 0)
                {
                    foreach (DataRow r in filas)
                    {
                        lista.Add(new DiscusionExtra
                        {
                            Descripcion = r["Descripcion"].ToString().Trim()                            
                        });
                    }
                }                

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar la lista de extras.\n {e.Message}", 0);
                return new List<DiscusionExtra>();
            }
        }

        //NUEVOS EXTRAS
        public List<DiscusionOtros> Agregaotros(int idgrupovalor)
        {
            try
            {
                List<DiscusionOtros> lista = new List<DiscusionOtros>();

                //VALIDO SI HAY REGISTROS EN EL ARANDETALLE 
                string ca = $"SELECT DIE.Descripcion, DIE.CodigoOs, DIE.CodigoAm, DIE.Observacion, DIE.Valor" +
                            $" FROM DISCUSIONOTROS DIE" +
                            $" LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DIE.ID_Encabezado)" +
                            $" WHERE DE.ID_GrupoValor = {idgrupovalor} AND DE.FechaImpacto = (SELECT MAX(D1.FechaImpacto)" +
                            $" FROM DISCUSIONENC D1" +
                            $" WHERE D1.ID_GrupoValor = {idgrupovalor} AND D1.Estado >= 1)";

                DataRowCollection filas = func.getColecciondatos(ca).Rows;

                if (filas.Count > 0)
                {
                    foreach (DataRow r in filas)
                    {
                        lista.Add(new DiscusionOtros
                        {
                            CodigoOs = r["CodigoOs"].ToString().Trim(),
                            CodigoAm = r["CodigoAm"].ToString().Trim(),
                            Descripcion = r["Descripcion"].ToString().Trim(),
                            Observacion = r["Observacion"].ToString().Trim(),
                            Valor = r["Valor"].ToString().Trim(),
                        });
                    }
                }

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar la lista de otros varios.\n {e.Message}", 0);
                return new List<DiscusionOtros>();
            }
        }


        //DETERMINO EL VALOR SEGUN TIPO DE PRESTATARIA
        private decimal getValorcrp(string tipo, decimal valPrepaga, decimal valOs, decimal valCaja, decimal valArt, decimal valoran)
        {
            if (valoran > 0) { return valoran; }
            else
            {
                switch (tipo)
                {
                    case "PP": return valPrepaga;
                    case "OS": return valOs;
                    case "ART": return valArt;
                    case "CJ": return valCaja;
                    default: return 0;
                }
            }
            
        }

        //OBTENGO LA OBSERVACION SEGUN TIPO DE PRESTATARIA
        private string getObservacioncrp(string tipo, string valPrepaga, string valOs, string valCaja, string valArt, string obspredef = "")
        {
            if (obspredef != "") { return obspredef.Trim(); }

            switch (tipo)
            {
                case "PP": return valPrepaga;
                case "OS": return valOs;
                case "ART": return valArt;
                case "CJ": return valCaja;
                default: return "";
            }
        }

        //GLOBAL DE DISCUSIONES PARA ANALISIS
        public List<DiscusionesGlobal> GetDiscucionglobal(int idarancelenc)
        {
            List<DiscusionesGlobal> lista = new List<DiscusionesGlobal>();

            try
            {
                string c = "SELECT DD.ID_Registro, DD.ID_Encabezado, ISNULL(DD.FechaNeg, '') AS FechaNeg, DD.Valor, AD.ValorPrepaga, AD.ValorOs, AD.ValorArt," +
                           " AD.ValorCaja, DD.ValorCoseguro, ISNULL(PT.Codigo, '') AS TipoPrestataria, DD.Observacion, ISNULL(FU.Codigo, '') AS CodigoFuncion," +
                           " ISNULL(FU.Descripcion, '') as DescripcionFuncion, ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                           " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, DD.CodigoOs, DD.Observacion," +
                           " DD.EsAmdgo, PG.Observacion AS GrupoObs, ISNULL(DD.ID_Practica, 0) AS ID_Practica, DE.FechaImpacto," +


                           " ISNULL(STUFF((SELECT DISTINCT ',' + CONCAT( '(', PD.Codigo, ' ', PR.Nombre, ' ', PR.Cuit, ')' )" +
                           " FROM DISCGRPVALHIST DH" +
                           " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           " WHERE DH.ID_Encabezado = DE.ID_Registro" +
                           " FOR XML PATH('')), 1, LEN(','), ''), '') AS Prestataria," +

                           " PRG.Codigo AS CodigoPrestataria," +
                          
                           " ISNULL((SELECT DT.Valor" +
                           " FROM DISCUSIONDET DT" +
                           " LEFT OUTER JOIN DISCUSIONENC DE1 ON(DE1.ID_Registro = DT.ID_Encabezado)" +
                           " WHERE DT.Aplicado = 2 AND DT.ID_Practica = DD.ID_Practica AND DE1.ID_GrupoValor = DE.ID_GrupoValor AND DE1.ID_AranValoriza <> DE.ID_AranValoriza" +
                           " AND DE1.FechaImpacto = (SELECT MAX(F.FechaImpacto) FROM DISCUSIONENC F WHERE F.FechaImpacto < DE.FechaImpacto AND" +
                                                                            " F.ID_GrupoValor = DE.ID_GrupoValor)),0) AS ValorAnterior," +
                           " PRG.Descripcion as DescripcionGrupo" +

                           " FROM DISCUSIONDET DD" +
                           " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = DD.ID_Funcion)" +
                           " LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                           " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                           " LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DD.ID_Encabezado)" +
                           " LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = DE.ID_AranValoriza)" +
                           " LEFT OUTER JOIN ARANVALORIZADET AD ON(AD.ID_Encabezado = AE.ID_Registro AND AD.ID_PractAm = DD.ID_Practica)" +
                           " LEFT OUTER JOIN PRESTGRPVAL PRG ON(PRG.ID_Registro = DE.ID_GrupoValor)" +                           
                           " LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = PRG.ID_PrestaTipo)" +
                           " WHERE DD.Aplicado = 2 AND DE.ID_AranValoriza = " + idarancelenc +
                           " AND DE.FechaImpacto = (SELECT MAX(FF.FechaImpacto) FROM DISCUSIONENC FF WHERE FF.ID_AranValoriza = DE.ID_AranValoriza" +
                                                   " AND FF.ID_GrupoValor = DE.ID_GrupoValor AND FF.Estado = 2)" +
                           " AND DD.ID_Funcion <> 10 AND DD.ID_Funcion <> 4";


                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    lista.Add(new DiscusionesGlobal
                    {
                        IDRegistro = Convert.ToInt64(r["ID_Registro"]),
                        IDEncabezado = Convert.ToInt32(r["ID_Encabezado"]),
                        IDPractAm = Convert.ToInt32(r["ID_Practica"]),
                        FechaNeg = func.Trydatetimeconvert(r["FechaNeg"].ToString()),
                        FechaImpacto = func.Trydatetimeconvert(r["FechaImpacto"].ToString()),
                        CodigoFuncion = r["CodigoFuncion"].ToString(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString(),
                        LetraFuncion = r["LetraFuncion"].ToString(),
                        CodigoPractica = r["CodigoPractica"].ToString(),
                        DescripcionPractica = r["DescripcionPractica"].ToString(),
                        GrupoPractica = r["Grupo"].ToString(),
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        Obsdetalle = r["Observacion"].ToString().Trim(),
                        TipoPrestataria = r["TipoPrestataria"].ToString(),
                        Valor = r["Valor"] != DBNull.Value ? Convert.ToDecimal(r["Valor"]) : 0,
                        ValorArt = r["ValorArt"] != DBNull.Value ? Convert.ToDecimal(r["ValorArt"]):0,
                        ValorCaja = r["ValorCaja"] != DBNull.Value ? Convert.ToDecimal(r["ValorCaja"]):0,
                        ValorOs = r["ValorOs"] != DBNull.Value ? Convert.ToDecimal(r["ValorOs"]):0,
                        ValorPrepaga = r["ValorPrepaga"] != DBNull.Value ? Convert.ToDecimal(r["ValorPrepaga"]):0,
                        TipoValor = Convert.ToByte(r["EsAmdgo"]),
                        CodigoPrestataria = r["CodigoPrestataria"].ToString().Trim(),
                        DescPrestataria = r["Prestataria"].ToString().Trim(),
                        DescripcionGrupo = r["DescripcionGrupo"].ToString().Trim(),
                        ValorAnterior = Convert.ToDecimal(r["ValorAnterior"])
                    });
                }

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los datos.\n{e.Message}", 0);
                lista.Clear();
                return lista;
            }
        }

        //OBTENGO EL CONJUTO DE PRESTATARIAS QUE ES REPRESTADAS POR EL AGRUPADOR DE VALOR OTROGADO
        public string GetConjuntoprestat(int idgrupovalor)
        {
            try
            {
                string retorno = "";

                string c = "SELECT DISTINCT " +
                            $" ISNULL(STUFF((SELECT DISTINCT ',' + CONCAT('(', PR.Nombre, ' ', PR.Cuit, ')')" +
                            $"            FROM PRESTDETALLES PD" +
                            $"            LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                            $"            WHERE PD.ID_Agrupador = GV.ID_Registro" +
                            $"            FOR XML PATH('')), 1, LEN(','), ''), '') AS PrestatariasConjunto" +
                            $" FROM PRESTGRPVAL GV" +                            
                            $" LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = GV.ID_PrestaTipo)" +
                            $" WHERE GV.ID_Registro = {idgrupovalor}";

                foreach (DataRow r in func.getColecciondatos(c).Rows) { retorno = r["PrestatariasConjunto"].ToString(); }

                return retorno;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los conjuntos de prestatarias.\n{e.Message}", 0);                
                return "";
            }
        }

        #region DATOS EN AMDGOSIS INS UPD GLOBAL
        
        //INSERTO REGISTROS EN TABLA AMDGOSIS [EPOCA CERO]
        public void InsertAmdgosis(DateTime fecha, string agrupador, int idencabezado, List<DiscusionDetalle> detalles)
        {
            try
            {
                if (fecha <= DateTime.MinValue || agrupador == "") { return; }

                //PRIMERO BORRO TODA EPOCA 9
                Borrarepocasnueve(agrupador);

                //INSERTO NUEVA EPOCA EN ASOCARAN (0)
                InsertAsocaran(idencabezado, agrupador, fecha);

                //INSERTO EL ASOCTGAL
                InsertAsoctgal(agrupador, detalles);

                //INSERTO EL ASOCTGAS
                InsertAsoctgas(agrupador, detalles);

                //INSERTO EN EL NONO
                InsertNono(agrupador, detalles);
                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los nuevos registros.\n {e.Message}", 0);
                return;
            }
        }

        //BORRO TODAS LAS EPOCAS 9 EN ARAN, TGAL, TGAS, NONO
        private void Borrarepocasnueve(string agrupador)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string delete = $"DELETE FROM [AmdgoSis].[dbo].[ASOCARAN] WHERE ARANEPOC = '9' AND ARANTIPO = '{agrupador}';";
                //BORRO LOS REGISTROS EN EPOCA CERO
                delete += $" DELETE FROM [AmdgoSis].[dbo].[ASOCTGAL] WHERE TGALEPOC = '9' AND TGALTIPO = '{agrupador}';";
                //BORRO LOS REGISTROS EN EPOCA CERO
                delete += $" DELETE FROM [AmdgoSis].[dbo].[ASOCTGAS] WHERE TGASEPOC = '9' AND TGASTIPO = '{agrupador}';";
                //BORRO LOS REGISTROS EN EPOCA CERO
                delete += $" DELETE FROM [AmdgoSis].[dbo].[NONO] WHERE EPOCA = '9' AND OS = '{agrupador}';";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (delete != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = delete;
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al borrar la 9na epoca.\n {e.Message}", 0);
                return;
            }
        }

        //VALIDO SI TIENE EPOCAS CARGADAS 
        public bool ContieneEpocasAsocaran(string agrupador)
        {
            try
            {
                //POR DEFECTO, NO CONTIENE
                bool retorno = false;

                string c = $"SELECT ISNULL(COUNT(ARANEPOC),0) AS Cantidad" +
                           $" FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $" WHERE ARANTIPO = '{agrupador}'";


                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    //SI LA CANTIDAD ES MAYOR A CERO, CONTIENE EPOCAS
                    if ((int)r["Cantidad"] > 0) { retorno = true; }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al validar insert en asocaran.\n {e.Message}", 0);
                return false;
            }
        }

        //VALIDO SI PUEDO EJECUTAR UN INSERT EN EPOCA CERO (valido que la fecha en epoca cero ya se encuentre asignada a una epoca numerada)
        public bool PuedoInsertAsocaran(string agrupador)
        {
            try
            {
                //POR DEFECTO, NO PERMITO BORRAR E INSERTAR NUEVA EPOCA CERO
                bool retorno = false;
                               
                string c = $"SELECT ISNULL(COUNT(ARANEPOC),0) AS Cantidad," +
                           $" (SELECT ISNULL(COUNT(ARANEPOC),0) FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $"  WHERE ARANTIPO = '{agrupador}' AND ARANEPOC = '0') AS Ecero" +
                           $" FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $" WHERE ARANTIPO = '{agrupador}' AND ARANEPOC <> '0' AND" +
                           $" ARANFEPOCA = (SELECT ARANFEPOCA FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $" WHERE ARANEPOC = '0' and ARANTIPO = '{agrupador}')";


                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    //SI NO HAY EPOCA CERO
                    if ((int)r["Ecero"] <= 0) { retorno = true; }
                    else
                    {
                        //SI LA CANTIDAD ES MAYOR A CERO, EPOCA IMPLEMENTADA, POR LO TANTO PUEDO BORRAR EPOCA CERO Y REEMPLAZAR POR UNA NUEVA
                        if ((int)r["Cantidad"] > 0) { retorno = true; }
                    }
                    
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al validar insert en asocaran.\n {e.Message}", 0);
                return false;
            }
        }

        //VALIDO SI LA FECHA A INSERTAR EXISTE EN EPOCA NO CERO
        public bool ExsisteFechaAsocaran(string agrupador, DateTime fecha)
        {
            try
            {
                //POR DEFECTO, NO EXISTE
                bool retorno = false;

                string c = $"SELECT ISNULL(COUNT(ARANEPOC),0) AS Cantidad" +
                           $" FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $" WHERE ARANTIPO = '{agrupador}' AND ARANEPOC <> '0' AND FORMAT(ARANFEPOCA, 'yyyy-MM-dd') = '{fecha.ToString("yyyy-MM-dd")}'";


                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    //SI LA CANTIDAD ES MAYOR A CERO, FECHA USADA
                    if ((int)r["Cantidad"] > 0) { retorno = true; }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al validar insert en asocaran.\n {e.Message}", 0);
                return false;
            }
        }
        
        //INSERTO REGISTROS EN EL ASOCARAN
        private void InsertAsocaran(int idencabezado, string agrupador, DateTime fecha)
        {
            try
            {                
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string delete = $"DELETE FROM [AmdgoSis].[dbo].[ASOCARAN] WHERE ARANEPOC = '0' AND ARANTIPO = '{agrupador}'";

                string insrt = "INSERT INTO [AmdgoSis].[dbo].[ASOCARAN] (ARANTIPO, ARANEPOC, ARANFEPOCA, IDAmdgoInt) VALUES" +
                       $" ('{agrupador}', '0', '{fecha}', {idencabezado});";


                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (delete != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = delete;
                            command.ExecuteNonQuery();                            
                        }
                    }

                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();                            
                        }
                    }

                    transaction.Commit();
                }                

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los nuevos registros [AsocAran].\n {e.Message}", 0);
                return;                
            }
        }

        //INSERTO REGISTROS EN EL ASOCTGAL
        private void InsertAsoctgal(string agrupador, List<DiscusionDetalle> detalles)
        {
            try
            {
                if (detalles.Where(w => w.IDArancel > 0).Count() <= 0) { return; }

                //string[] ginecologico = new string[9] { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9" };

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                //BORRO LOS REGISTROS EN EPOCA CERO
                string delete = $"DELETE FROM [AmdgoSis].[dbo].[ASOCTGAL] WHERE TGALEPOC = '0' AND TGALTIPO = '{agrupador}'";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {

                        if (delete != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = delete;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }

                string insrt = ""; 

                //foreach (DiscusionDetalle d in detalles.Where(w => w.IDArancel > 0 && !ginecologico.Contains(w.CodigoPractica)))
                //AHORA INSERTO LOS GINECOLOGICOS
                foreach (DiscusionDetalle d in detalles.Where(w => w.IDArancel > 0))
                {
                    insrt += "INSERT INTO [AmdgoSis].[dbo].[ASOCTGAL] (TGALTIPO, TGALEPOC, TGALGARA, TGALVALG, TGALVCAR, IDAmdgoInt) VALUES ";
                    insrt += $"('{agrupador}', '0', '{d.CodigoPractica}', {d.Valor.ToString(new CultureInfo("en-US"))}, 'N', {d.IDRegistro});";                                       
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los nuevos registros [AsocTgal].\n {e.Message}", 0);
                return;
            }
        }

        //INSERTO REGISTROS EN EL ASOCTGAS
        private void InsertAsoctgas(string agrupador, List<DiscusionDetalle> detalles)
        {
            try
            {

                if (detalles.Where(w => w.IDGasto > 0).Count() <= 0) { return; }

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                //BORRO LOS REGISTROS EN EPOCA CERO
                string delete = $"DELETE FROM [AmdgoSis].[dbo].[ASOCTGAS] WHERE TGASEPOC = '0' AND TGASTIPO = '{agrupador}'";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {

                        if (delete != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = delete;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }

                string insrt = "";

                foreach (DiscusionDetalle d in detalles.Where(w => w.IDGasto > 0))
                {
                    insrt += "INSERT INTO [AmdgoSis].[dbo].[ASOCTGAS] (TGASTIPO, TGASEPOC, TGASGGAS, TGASVGAS, IDAmdgoInt) VALUES ";
                    insrt += $"('{agrupador}', '0', '{d.CodigoPractica}', {d.Valor.ToString(new CultureInfo("en-US"))}, {d.IDRegistro});";
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los nuevos registros [AsocTgas].\n {e.Message}", 0);
                return;
            }
        }

        //INSERTO REGISTROS EN EL NONO
        private void InsertNono(string agrupador, List<DiscusionDetalle> detalles)
        {
            try
            {
                if (detalles.Where(w => w.IDFuncion > 0).Count() <= 0) { return; }

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();
               
                //BORRO LOS REGISTROS EN EPOCA CERO
                string delete = $"DELETE FROM [AmdgoSis].[dbo].[NONO] WHERE EPOCA = '0' AND OS = '{agrupador}'";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {

                        if (delete != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = delete;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }

                string insrt = "";

                //SOLO CON FUNCION VAN AL NONO, QUITAMOS LAS DE REFERENCIA, "CARGO AFILIADO"
                foreach (DiscusionDetalle d in detalles.Where(w => w.IDFuncion > 0 && w.IDFuncion != 10 && w.IDFuncion != 4))
                {
                    if (d.Valor <= 0 && d.CodigoPractica != "500106") { continue; }

                    string descr = d.DescripcionPractica.Length > 300 ? d.DescripcionPractica.Substring(1, 300).Trim() : d.DescripcionPractica;
                                        
                    insrt += "INSERT INTO [AmdgoSis].[dbo].[NONO] (OS, EPOCA, PRACTICA, DESCRIPCIO, FUNCION, IMPORTE, IDAmdgoInt) VALUES ";
                    insrt += $"('{agrupador}', '0', '{d.CodigoPractica}', '{descr}', '{d.CodigoFuncion}', {d.Valor.ToString(new CultureInfo("en-US"))}," +
                        $" {d.IDRegistro});";
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los nuevos registros [Nono].\n {e.Message}", 0);
                return;
            }
        }
               
        //APLICO LOS VALORES DE LA EPOCA CERO A LA EPOCA CORRESPONDIENTE
        public void UpdateAmdgosis(DateTime fecha, string agrupador, int idencabezado, List<DiscusionDetalle> detalles)
        {
            try
            {
                //DETERMINO LA EPOCA QUE CORRESPONDE A LA ACTUAL CERO
                int epoca = DeterminaNewepoca(fecha, agrupador);

                if (epoca <= 0) { return; }

                //ACTUALIZO EPOCA ASOCARAN
                UpdateAsocaran(agrupador, epoca);

                //ACTUALIZO EPOCA ASOCTGAL
                UpdateAsoctgal(agrupador, epoca);

                //ACTUALIZO EPOCA ASOCTGAS
                UpdateAsoctgas(agrupador, epoca);

                //ACTUALIZO EPOCA NONO
                UpdateNono(agrupador, epoca);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar.\n {e.Message}", 0);
                return;
            }
        }

        //DETERMINO LA EPOCA A INSERTAR
        private int DeterminaNewepoca(DateTime fecha, string agrupador)
        {
            try
            {
                int retorno = 1;

                string c = $"SELECT TOP 1 MAX(ARANFEPOCA) AS Fecha, RTRIM(LTRIM(ARANEPOC)) AS Epoca" +
                           $" FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $" WHERE ARANTIPO = '{agrupador}' AND FORMAT(ARANFEPOCA, 'yyyy-MM-dd') < '{fecha.ToString("yyyy-MM-dd")}'" +
                           $" GROUP BY ARANFEPOCA, ARANEPOC" +
                           $" ORDER BY ARANFEPOCA DESC";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    if (r["Epoca"] != DBNull.Value && r["Epoca"].ToString() != "" && Convert.ToInt32(r["Epoca"]) > 0)
                    { retorno = Convert.ToInt32(r["Epoca"]); }
                }
                
                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al determinar la nueva época.\n {e.Message}", 0);
                return 0;
            }
        }
                
        //ACTUALIZO LOS VALORES DE EPOCA EN ASOCARAN        
        private void UpdateAsocaran(string agrupador, int epoca)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string update = $"UPDATE [AmdgoSis].[dbo].[ASOCARAN] SET ARANEPOC = ISNULL(ARANEPOC, 0) + 1 WHERE ARANEPOC >= {epoca} AND ARANTIPO = '{agrupador}'";

                string insrt = "INSERT INTO [AmdgoSis].[dbo].[ASOCARAN] (ARANTIPO, ARANEPOC, ARANFEPOCA, IDAmdgoInt)" +
                       $" SELECT ARANTIPO, {epoca}, ARANFEPOCA, IDAmdgoInt FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                       $" WHERE ARANTIPO = '{agrupador}' AND ARANEPOC = '0'";


                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (update != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = update;
                            command.ExecuteNonQuery();
                        }
                    }

                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }



            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar los nuevos registros [AsocAran].\n {e.Message}", 0);
                return;
            }
        }

        //ACTUALIZO LOS VALORES EN ASOCTGAL
        private void UpdateAsoctgal(string agrupador, int epoca)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string update = $"UPDATE [AmdgoSis].[dbo].[ASOCTGAL] SET TGALEPOC = ISNULL(TGALEPOC, 0) + 1 WHERE TGALEPOC >= {epoca} AND TGALTIPO = '{agrupador}'";

                string insrt = $"INSERT INTO [AmdgoSis].[dbo].[ASOCTGAL] (TGALTIPO, TGALEPOC, TGALGARA, TGALVALG, TGALVCAR, IDAmdgoInt)" +
                               $" SELECT TGALTIPO, '{epoca}', TGALGARA, TGALVALG, TGALVCAR, IDAmdgoInt" +
                               $" FROM [AmdgoSis].[dbo].[ASOCTGAL]" +
                               $" WHERE TGALEPOC = '0' AND TGALTIPO = '{agrupador}'";
                        
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (update != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = update;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar los nuevos registros [AsocTgal].\n {e.Message}", 0);
                return;
            }
        }

        //ACTUALIZO REGISTROS EN EL ASOCTGAS
        private void UpdateAsoctgas(string agrupador, int epoca)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string update = $"UPDATE [AmdgoSis].[dbo].[ASOCTGAS] SET TGASEPOC = ISNULL(TGASEPOC, 0) + 1 WHERE TGASEPOC >= {epoca} AND TGASTIPO = '{agrupador}'";

                string insrt = $"INSERT INTO [AmdgoSis].[dbo].[ASOCTGAS] (TGASTIPO, TGASEPOC, TGASGGAS, TGASVGAS, IDAmdgoInt)" +
                               $" SELECT TGASTIPO, {epoca}, TGASGGAS, TGASVGAS, IDAmdgoInt" +
                               $" FROM [AmdgoSis].[dbo].[ASOCTGAS]" +
                               $" WHERE TGASEPOC = '0' AND TGASTIPO = '{agrupador}'";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {

                        if (update != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = update;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }
                            
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al update los nuevos registros [AsocTgas].\n {e.Message}", 0);
                return;
            }
        }

        //UPDATE REGISTROS EN EL NONO
        private void UpdateNono(string agrupador, int epoca)
        {
            try
            {                
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string update = $"UPDATE [AmdgoSis].[dbo].[NONO] SET EPOCA = ISNULL(EPOCA, 0) + 1 WHERE EPOCA >= {epoca} AND OS = '{agrupador}'";

                string insrt = $"INSERT INTO [AmdgoSis].[dbo].[NONO] (OS, EPOCA, PRACTICA, DESCRIPCIO, FUNCION, IMPORTE, IDAmdgoInt)" +
                               $" SELECT OS, {epoca}, PRACTICA, DESCRIPCIO, FUNCION, IMPORTE, IDAmdgoint" +
                               $" FROM [AmdgoSis].[dbo].[NONO]" +
                               $" WHERE OS = '{agrupador}' AND EPOCA = '0'";                               
                               

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {

                        if (update != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = update;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }
                              
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }

                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los nuevos registros [AsocTgas].\n {e.Message}", 0);
                return;
            }
        }                        

        #endregion

        #region DATOS AMDGOSIS INS UPD INDIVIDUAL

        public void InsertIdvAmdgosis(List<DiscusionDetalle> detalles, string agrupador, DateTime fecha)
        {
            try
            {

                if (agrupador == "" || fecha <= DateTime.MinValue) { return; }
                
                //DETERMINO LA EPOCA DE LOS REGISTROS
                int epoca = GetEpoca(fecha, agrupador);

                if (epoca < 0) { return; }

                //DETERMINO SI EL ORIGEN DE CARGA ES DEL SISTEMA, (SALIGO SI ES FALSO, LA CARGA Y MODIFICACION DEBE REALIZARSE A MANO)
                if (!GetOrigencargadatos(epoca, agrupador)) { return; }

                //INSERTO NUEVOS ASOCTGAL
                InsertAsoctgalind(detalles, agrupador, epoca);

                //INSERTO NUEVOS ASOCTGAS
                InsertAsoctgasind(detalles, agrupador, epoca);

                //INSERTO NUEVOS NONO
                InsertAsocnonoind(detalles, agrupador, epoca);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los registros individuales.\n{e.Message}", 1);
                return;
            }
        }

        //OBTENGO LA EPOCA EN LA QUE ESTAN LOS REGISTROS
        public int GetEpoca(DateTime fecha, string agrupador)
        {
            try
            {
                int retorno = -1;

                string c = $"SELECT ISNULL(LTRIM(RTRIM(MAX(ARANEPOC))),'-1') AS Epoca" +
                           $" FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                           $" WHERE ARANTIPO = '{agrupador}' AND FORMAT(ARANFEPOCA, 'yyyy-MM-dd') = '{fecha.ToString("yyyy-MM-dd")}'";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    retorno = Convert.ToInt32(r["Epoca"]);
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar la epoca en uso.\n {e.Message}", 0);
                return -1;
            }
        }

        //DETERMINO SI LA EPOCA FUE CARGADA DESDE MI SISTEMA O MANUALMENTE
        public bool GetOrigencargadatos(int epoca, string agrupador)
        {
            try
            {
                bool retorno = false;

                string c = $"SELECT ISNULL(IDAmdgoInt, 0) AS Origen" +
                    $" FROM [AmdgoSis].[dbo].[ASOCARAN]" +
                    $" WHERE ARANTIPO = '{agrupador}' AND ARANEPOC = '{epoca}'";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    if (Convert.ToInt32(r["Origen"]) > 0) { retorno = true; }                    
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar el origen de carga.\n {e.Message}", 0);
                return false;
            }
        }

        //INVD I- ASOCTGAL
        private void InsertAsoctgalind(List<DiscusionDetalle> detalles, string agrupador, int epoca)
        {
            try
            {
                if (agrupador == "" ||  detalles.Count <= 0) { return; }
                //string[] ginecologico = new string[9] { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9" };

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                //A PARTIR DE 18-10-21 SE TRATA GINECOLOGIA COMO NOMENCLADOR
                //foreach (DiscusionDetalle d in detalles.Where(w => w.IDArancel > 0 && w.IDRegistro <= 0 && !ginecologico.Contains(w.CodigoPractica)))
                foreach (DiscusionDetalle d in detalles.Where(w => w.IDArancel > 0 && w.IDRegistro <= 0))                
                {
                    //RECUPERO EL ID DE LOS RECIEN INSERTADOS Y LOS ASIGNO.
                    string c = $"SELECT ID_Registro FROM DISCUSIONDET WHERE Guid = '{d.IDLocal}'";

                    foreach (DataRow r in func.getColecciondatos(c).Rows)
                    {
                        d.IDRegistro = Convert.ToInt64(r["ID_Registro"]);
                    }

                    //SI POR ALGUNA RAZON NO ASIGNO EL ID, CONTINUA CON OTRO REGISTRO. 
                    if (d.IDRegistro <= 0) { continue; }

                    string insrt = $"INSERT INTO [AmdgoSis].[dbo].[ASOCTGAL] (TGALTIPO, TGALEPOC, TGALGARA, TGALVALG, TGALVCAR, IDAmdgoInt) VALUES" +
                                   $" ('{agrupador}', '{epoca}', '{d.CodigoPractica}', {d.Valor.ToString(new CultureInfo("en-US"))}, 'N', {d.IDRegistro});";

                    //INSERTO EL REGISTRO EN LA TABLA CORRESPONDIENTE
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (insrt != "")
                            {
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = insrt;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los registros Asoctgal Ind.\n{e.Message}", 1);
                return;
            }
        }
        //INVD I- ASOCTGAS
        private void InsertAsoctgasind(List<DiscusionDetalle> detalles, string agrupador, int epoca)
        {
            try
            {
                if (agrupador == "" || detalles.Count <= 0) { return; }


                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                foreach (DiscusionDetalle d in detalles.Where(w => w.IDGasto > 0 && w.IDRegistro <= 0 && w.Valor > 0))
                {
                    //RECUPERO EL ID DE LOS RECIEN INSERTADOS Y LOS ASIGNO.
                    string c = $"SELECT ID_Registro FROM DISCUSIONDET WHERE Guid = '{d.IDLocal}'";

                    foreach (DataRow r in func.getColecciondatos(c).Rows)
                    {
                        d.IDRegistro = Convert.ToInt64(r["ID_Registro"]);
                    }

                    //SI POR ALGUNA RAZON NO ASIGNO EL ID, CONTINUA CON OTRO REGISTRO. 
                    if (d.IDRegistro <= 0) { continue; }

                    string insrt = $"INSERT INTO [AmdgoSis].[dbo].[ASOCTGAS] (TGASTIPO, TGASEPOC, TGASGGAS, TGASVGAS, IDAmdgoInt) VALUES " +
                                   $"('{agrupador}', '{epoca}', '{d.CodigoPractica}', {d.Valor.ToString(new CultureInfo("en-US"))}, {d.IDRegistro});";
                    //INSERTO EL REGISTRO EN LA TABLA CORRESPONDIENTE
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (insrt != "")
                            {
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = insrt;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los registros Asoctgas Ind.\n{e.Message}", 1);
                return;
            }
        }
        //INVD I- NONO
        private void InsertAsocnonoind(List<DiscusionDetalle> detalles, string agrupador, int epoca)
        {
            try
            {
                if (agrupador == "" || detalles.Count <= 0) { return; }


                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                foreach (DiscusionDetalle d in detalles.Where(w => w.IDFuncion > 0 && w.IDFuncion != 10 && w.IDFuncion != 4 && w.IDRegistro <= 0))
                {
                    if (d.Valor <= 0 && d.CodigoPractica != "500106") { continue; }

                    //RECUPERO EL ID DE LOS RECIEN INSERTADOS Y LOS ASIGNO.
                    string c = $"SELECT ID_Registro FROM DISCUSIONDET WHERE Guid = '{d.IDLocal}'";

                    foreach (DataRow r in func.getColecciondatos(c).Rows)
                    {
                        d.IDRegistro = Convert.ToInt64(r["ID_Registro"]);
                    }

                    //SI POR ALGUNA RAZON NO ASIGNO EL ID, CONTINUA CON OTRO REGISTRO. 
                    if (d.IDRegistro <= 0) { continue; }

                    string descr = d.DescripcionPractica.Trim().Length > 300 ? d.DescripcionPractica.Substring(1, 300).Trim() : d.DescripcionPractica.Trim();
                    descr = descr.Replace("'", "");

                    string insrt = $"INSERT INTO [AmdgoSis].[dbo].[NONO] (OS, EPOCA, PRACTICA, DESCRIPCIO, FUNCION, IMPORTE, IDAmdgoInt) VALUES " +
                                   $"('{agrupador}', '{epoca}', '{d.CodigoPractica}', '{descr}', '{d.CodigoFuncion}', {d.Valor.ToString(new CultureInfo("en-US"))}," +
                                   $" {d.IDRegistro});";
                    
                    //INSERTO EL REGISTRO EN LA TABLA CORRESPONDIENTE
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (insrt != "")
                            {
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = insrt;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al insertar los registros Nono Ind.\n{e.Message}", 1);
                return;
            }
        }
        
        //INVD U- ASOCTGAL - TGAS - NONO
        public void UpdateIdvAmdgosis(List<DiscusionDetalle> detalles, string agrupador, int idencabezado)
        {
            try
            {
                if (detalles.Count <= 0 || idencabezado <= 0) { return; }

                //HAGO LA CONEXION A BD UNA VEZ PARA EL CONJUNTO DE INSTRUCCIONES
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                //ACTUALIZO EL ASOCTGAL INDIVIDUAL
                UpdateIdvAsoctgal(con, agrupador, idencabezado);

                //ACTUALIZO EL ASOCTGAS INDIVIDUAL
                UpdateIdvAsoctgas(con, agrupador, idencabezado);

                //ACTUALIZO EL NONO INDIVIDUAL
                UpdateIdvNono(con, agrupador, idencabezado);

                con.Close();
                cbd.Desconectar();
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar los registros individuales.\n{e.Message}", 1);
                return;
            }
        }

        //INVD UPDATE - ASOCTGAL
        private void UpdateIdvAsoctgal(SqlConnection con, string agrupador, int idencabezado)
        {
            try
            {                
                string instruccion = $"UPDATE [AmdgoSis].dbo.ASOCTGAL SET TGALVALG = DD.Valor" +
                                     $" FROM [AmdgoSis].dbo.ASOCTGAL XTG" +
                                     $" LEFT OUTER JOIN AmdgoInterno.dbo.DISCUSIONDET DD ON(DD.ID_Registro = XTG.IDAmdgoint)" +
                                     $" LEFT OUTER JOIN AmdgoInterno.dbo.PRACTAM PR ON(PR.ID_Registro = DD.ID_Practica)" +
                                     $" LEFT OUTER JOIN AmdgoInterno.dbo.ARANCELES AR ON(AR.ID_Registro = PR.ID_Arancel)" +
                                     $" WHERE XTG.TGALTIPO = '{agrupador}' AND XTG.IDAmdgoint > 0 AND DD.ID_Funcion = 0 AND DD.ID_Encabezado = {idencabezado}";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = con;
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;
                        command.CommandText = instruccion;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar los registros individuales tgal.\n{e.Message}", 1);
                return;
            }
        }

        //INVD UPDATE - ASOCTGAS
        private void UpdateIdvAsoctgas(SqlConnection con, string agrupador, int idencabezado)
        {
            try
            {                
                string instruccion = $"UPDATE [AmdgoSis].dbo.ASOCTGAS SET TGASVGAS = DD.Valor" +
                                     $" FROM [AmdgoSis].dbo.ASOCTGAS XTG" +
                                     $" LEFT OUTER JOIN AmdgoInterno.dbo.DISCUSIONDET DD ON(DD.ID_Registro = XTG.IDAmdgoint)" +
                                     $" LEFT OUTER JOIN AmdgoInterno.dbo.PRACTAM PR ON(PR.ID_Registro = DD.ID_Practica)" +
                                     $" LEFT OUTER JOIN AmdgoInterno.dbo.GASTOS AR ON(AR.ID_Registro = PR.ID_Gasto)" +
                                     $" WHERE XTG.TGASTIPO = '{agrupador}' AND XTG.IDAmdgoint > 0 AND DD.ID_Funcion = 0 AND DD.ID_Encabezado = {idencabezado}";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = con;
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;
                        command.CommandText = instruccion.ToString();
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar los registros individuales tgas.\n{e.Message}", 1);
                return;
            }
        }

        //INVD UPDATE - NONO
        private void UpdateIdvNono(SqlConnection con, string agrupador, int idencabezado)
        {
            try
            {              
               
                //ACTUALIZO DESDE FUNCION SQL
                string instruccion = $"UPDATE [AmdgoSis].dbo.NONO" +
                              $" SET PRACTICA = ISNULL(PR.Codigo,''), FUNCION = ISNULL(FU.Codigo, '')," +
                              $" DESCRIPCIO = ISNULL(IIF(LEN(PR.Descripcion) > 300, SUBSTRING(PR.Descripcion, 1, 300), PR.Descripcion), '')," +
                              $" IMPORTE = ISNULL(DD.Valor, 0)" +
                              $" FROM [AmdgoSis].dbo.NONO XNO" +
                              $" LEFT OUTER JOIN AmdgoInterno.dbo.DISCUSIONDET DD ON(DD.ID_Registro = XNO.IDAmdgoint)" +
                              $" LEFT OUTER JOIN AmdgoInterno.dbo.PRACTAM PR ON(PR.ID_Registro = DD.ID_Practica)" +
                              $" LEFT OUTER JOIN AmdgoInterno.dbo.FUNCIONES FU ON(FU.ID_Registro = PR.ID_Funcion)" +
                              $" WHERE XNO.OS = '{agrupador}' AND XNO.IDAmdgoint > 0 AND (DD.ID_Funcion > 0 AND DD.ID_Funcion <> 10 AND DD.ID_Funcion <> 4) AND DD.ID_Encabezado = {idencabezado}";

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = con;
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;
                        command.CommandText = instruccion;
                        command.ExecuteNonQuery();
                        transaction.Commit();                        

                    }
                }

              
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al actualizar los registros individuales tgas.\n{e.Message}", 1);
                return;
            }
        }

        //INVD DELETE - ASOCTGAL - TGAS - NONO
        public void DeleteIdvAmdgosis(List<long> iddel)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string ors = "";
                foreach (long d in iddel)
                {
                    if (string.IsNullOrEmpty(ors)) { ors = $"IDAmdgoint = {d.ToString()}"; }
                    else { ors += $" or IDAmdgoint = {d.ToString()}"; }
                }

                foreach (long d in iddel)
                {

                    //UPDATE DE ASOCTGAL
                    string instruccion = "";

                    instruccion = $"DELETE FROM [AmdgoSis].[dbo].[ASOCTGAL] WHERE {ors};" +
                                  $"DELETE FROM [AmdgoSis].[dbo].[ASOCTGAS] WHERE {ors};" +
                                  $"DELETE FROM [AmdgoSis].[dbo].[NONO] WHERE {ors};"; 


                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (instruccion != "")
                            {
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = instruccion;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al borrar los registros individuales.\n{e.Message}", 1);
                return;
            }
        }
        
        //HOMONIMOS
        public void AsocHomonimos(List<DiscusionDetalle> detalles, string agrupador)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                if (detalles.Where(w => w.CodigoOs != w.CodigoPractica && w.CodigoOs != "" && w.CodigoPractica != "").Count() > 0)
                {
                    string delete = $"DELETE FROM [AmdgoSis].[dbo].[NOM_HOMO] WHERE NHOMOS = '{agrupador}'";

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = delete;
                            command.ExecuteNonQuery();
                            transaction.Commit();                            
                        }
                    }
                }

                string insrt = "";
                foreach (DiscusionDetalle d in detalles.Where(w => w.CodigoOs != w.CodigoPractica && w.CodigoOs != "" && w.CodigoPractica != ""))
                {

                    insrt += "INSERT INTO [AmdgoSis].[dbo].[NOM_HOMO] (NHOMOS, NHOMCODNOME, NHOMHOMONIM) VALUES ";
                    insrt += $"('{agrupador}', '{d.CodigoPractica}', '{d.CodigoOs}');";
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (insrt != "")
                        {
                            command.Connection = con;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = insrt;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }

                    }
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al procesar los homónimos.\n{e.Message}", 0);
                return;
            }
        }
        
        #endregion
    }

    public class DiscusionEncabezado 
    {
        
        public string IDLocal { get; private set; } = Guid.NewGuid().ToString();
        public int IDRegistro { get; set; } = 0;
        public DateTime FechaAranBase { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaImpacto { get; set; }
        public int IDAranvaloriza { get; set; } = 0;
        public string TipoValorizacion { get; set; } = "";
        public int IDGrupoOs { get; set; } = 0;
        public short Estado { get; set; } = 0;
        public string Prestataria { get; set; } = "";
        public long CuitPrestataria { get; set; } = 0;
        public string CodigoGupo { get; set; } = "";
        public string CodigosConjuntos { get; set; } = "";
        public string DescripcionGrupo { get; set; } = "";
        public string TipoNombre { get; set; } = "";
        public string AbraviaGrupo { get; set; } = "";
        public string PrestatariaConjunto { get; set; } = "";
        public bool Visible { get; set; } = true;

        public List<DiscusionDetalle> Detalles { get; set; } = new List<DiscusionDetalle>();
        public List<DiscusionExtra> Extras { get; set; } = new List<DiscusionExtra>();
        public List<DiscusionGrupoObs> GruposObs { get; set; } = new List<DiscusionGrupoObs>();
        public List<DiscusionRespuestasAM> Respuestas { get; set; } = new List<DiscusionRespuestasAM>();
        public List<DiscusionOtros> Otros { get; set; } = new List<DiscusionOtros>();
        public List<Prestadoras> Prestadoras { get; set; } = new List<Prestadoras>();

        public List<Prestatariaarray> PrestatariaLista
        {
            get
            {
                List<Prestatariaarray> a = new List<Prestatariaarray>();

                if (PrestatariaConjunto != "")
                {
                    //DIVIDO EN PRESTATARIAS (VIENE SEPARADO POR COMMA)
                    foreach (string s in PrestatariaConjunto.Split('*'))
                    {
                        string pres = "";
                        string codigos = "";
                        

                        short c = 0;
                        foreach (string p in s.Split('|'))
                        {
                            if (c == 0) { pres = p.Replace("(", "").Trim(); }
                            else { codigos = p.Trim().Replace("/", " - ").Replace(")", ""); }
                            c++;
                        }
                                             
                        a.Add(new Prestatariaarray { Prestataria = pres, Codigos = codigos.Trim(), GrupoNombre = DescripcionGrupo });
                    }
                }

                return a;
            }

        }

        public DiscusionEncabezado() { }

        public DiscusionEncabezado Clone()
        {
            DiscusionEncabezado n = (DiscusionEncabezado)this.MemberwiseClone();
            DiscusionDetalle d = new DiscusionDetalle();
            DiscusionExtra e = new DiscusionExtra();
            DiscusionGrupoObs o = new DiscusionGrupoObs();
            DiscusionRespuestasAM r = new DiscusionRespuestasAM();
            DiscusionOtros ot = new DiscusionOtros();
            Prestadoras p = new Prestadoras();

            n.IDLocal = string.Copy(IDLocal);
            n.IDRegistro = this.IDRegistro;
            n.FechaAranBase = this.FechaAranBase;
            n.FechaInicio = this.FechaInicio;
            n.FechaCierre = this.FechaCierre;
            n.FechaImpacto = this.FechaImpacto;
            n.IDAranvaloriza = this.IDAranvaloriza;
            n.TipoValorizacion = this.TipoValorizacion;
            n.IDGrupoOs = this.IDGrupoOs;
            n.Estado = this.Estado;
            n.Prestataria = this.Prestataria;
            n.CuitPrestataria = this.CuitPrestataria;
            n.CodigoGupo = this.CodigoGupo;
            n.CodigosConjuntos = this.CodigosConjuntos;
            n.PrestatariaConjunto = this.PrestatariaConjunto;
            n.DescripcionGrupo = this.DescripcionGrupo;
            n.TipoNombre = this.TipoNombre;
            n.Visible = Visible;
            n.Detalles = d.Clone(this.Detalles);
            n.Extras = e.Clone(this.Extras);
            n.GruposObs = o.Clone(this.GruposObs);
            n.Respuestas = r.Clone(this.Respuestas);
            n.Otros = ot.Clone(this.Otros);
            n.Prestadoras = p.Clone(Prestadoras);
            return n;
        }
               
    }

    public class DiscusionDetalle : ArancelesValoriza
    {
        private Funciones f = new Funciones();

        public string IDLocal { get; set; } = Guid.NewGuid().ToString();
        public DateTime FechaNeg { get; set; } = DateTime.Now;
        public int IDArancel { get; set; } = 0;
        public int IDGasto { get; set; } = 0;
        public int IDFuncion { get; set; } = 0;
        public decimal Valor { get; set; } = 0;
        public decimal ValorDos { get; set; } = 0;
        public decimal ValorCoseguro { get; set; } = 0;
        public decimal ValorCopago { get; set; } = 0;
        public string CodigoOs { get; set; } = "";
        public string Obsdetalle { get; set; } = "";
        public string CodigoGasto { get; set; } = "";
        public int Anio
        {
            get { return FechaNeg.Year; }
        }
        public string Mes
        {
            get { return f.GetMes(FechaNeg.Month); }
        }
        public int Dia
        {
            get { return FechaNeg.Day; }
        }
        public string FechaCorta { get { return FechaNeg.Year + "-" + FechaNeg.Month.ToString("00") + "-" + FechaNeg.Day.ToString("00"); } }
        public string Hora
        {
            get { return $"{FechaNeg.Hour.ToString("00")}:{FechaNeg.Minute.ToString("00")}:{FechaNeg.Second.ToString("00")}"; }
        }
        public byte TipoValor { get; set; } = 0;
        public string TipoValordesc
        {
            get
            {
                if (TipoValor == 0) { return "OS"; } else { return "AM"; }
            }
        }
        public bool _BorrarRegistro { get; set; } = false;
        public bool _NuevoRegistro { get; set; } = false;
        public short _UsaObservacion { get; set; } = 0; //CERO NADA, 1 APLICA OBS PARA FECHAS > A PROCESADA, 2 APLICA OBS PARA FECHAS < A PROCESADA, 3 TODAS IGUALES
        public short Aplicado { get; set; } = 0;

        public decimal MaxValMinFec { get; set; } = 0;

        public decimal DiferenciaValor
        {
            get
            {

                decimal calc = 0;

                if (Valor > 0 && MaxValMinFec > 0)
                {
                    calc = Valor - MaxValMinFec;
                }                

                return calc;
            }
        }

        public decimal DiferenciaPorc
        {
            get
            {
                decimal calc = 0;

                if (MaxValMinFec > 0 && Valor > 0)
                {
                    calc = ((Valor / MaxValMinFec) * 100) - 100;
                }

                return calc;
            }
        }

        public decimal ValorPactado { get; set; } = 0;

        public decimal DiferenciaPorcpactado
        {
            get
            {
                decimal calc = 0;

                if (ValorPactado > 0 && Valor > 0)
                {
                    calc = ((Valor / ValorPactado) * 100) - 100;
                }

                return calc;
            }
        }

        public decimal DiferenciaValorPactado
        {
            get
            {

                decimal calc = 0;

                if (Valor > 0 && ValorPactado > 0)
                {
                    calc = Valor - ValorPactado;
                }

                return calc;
            }
        }

        public decimal ValorNomenclado { get; set; } = 0;

        public decimal DiferenciaValorNomenclado
        {
            get
            {

                decimal calc = 0;

                if (Valor > 0 && ValorNomenclado > 0)
                {
                    calc = Valor - ValorNomenclado;
                }

                return calc;
            }
        }

        public DiscusionDetalle() { }

        public List<DiscusionDetalle> Clone(List<DiscusionDetalle> p)
        {            
            List<DiscusionDetalle> n = new List<DiscusionDetalle>();

            foreach (DiscusionDetalle d in p)
            {
                n.Add(new DiscusionDetalle
                {
                    IDLocal = d.IDLocal,
                    IDRegistro = d.IDRegistro,
                    FechaNeg = d.FechaNeg,
                    IDArancel = d.IDArancel,
                    IDGasto = d.IDGasto,
                    IDFuncion = d.IDFuncion,
                    Valor = d.Valor,
                    ValorDos = d.ValorDos,
                    ValorCoseguro = d.ValorCoseguro,
                    ValorCopago = d.ValorCopago,
                    CodigoOs = d.CodigoOs,
                    Obsdetalle = d.Obsdetalle,
                    IDGrupo = d.IDGrupo,
                    GrupoPractica = d.GrupoPractica,
                    GrupoOrden = d.GrupoOrden,
                    IDEncabezado = d.IDEncabezado,
                    IDPractAm = d.IDPractAm,
                    CodigoPractica = d.CodigoPractica,
                    DescripcionPractica = d.DescripcionPractica,
                    CodigoFuncion = d.CodigoFuncion,
                    LetraFuncion = d.LetraFuncion,
                    DescripcionFuncion = d.DescripcionFuncion,
                    ValorPrepaga = d.ValorPrepaga,
                    ObsPrepaga = d.ObsPrepaga,
                    ValorOs = d.ValorOs,
                    ObsOs = d.ObsOs,
                    ValorArt = d.ValorArt,
                    ObsArt = d.ObsArt,
                    ValorCaja = d.ValorCaja,
                    ObsCaja = d.ObsCaja,
                    CodigoGasto = d.CodigoGasto,
                    TipoValor = d.TipoValor,
                    GrupoObservacion = d.GrupoObservacion,
                    Aplicado = d.Aplicado,
                    ValorNomenclado = d.ValorNomenclado,
                    ValorPactado = d.ValorPactado,
                    _BorrarRegistro = d._BorrarRegistro,
                    _NuevoRegistro = d._NuevoRegistro,
                    _UsaObservacion = d._UsaObservacion
                });
            }

            return n;
        }

        public DiscusionDetalle Clone()
        {
            DiscusionDetalle n = (DiscusionDetalle)this.MemberwiseClone();

            n.IDLocal = IDLocal;
            n.IDRegistro = IDRegistro;
            n.FechaNeg = FechaNeg;
            n.IDArancel = IDArancel;
            n.IDGasto = IDGasto;
            n.IDFuncion = IDFuncion;
            n.Valor = Valor;
            n.ValorDos = ValorDos;
            n.ValorCoseguro = ValorCoseguro;
            n.ValorCopago = ValorCopago;
            n.CodigoOs = CodigoOs;
            n.Obsdetalle = Obsdetalle;
            n.IDGrupo = IDGrupo;
            n.GrupoPractica = GrupoPractica;
            n.GrupoOrden = GrupoOrden;
            n.IDEncabezado = IDEncabezado;
            n.IDPractAm = IDPractAm;
            n.CodigoPractica = CodigoPractica;
            n.DescripcionPractica = DescripcionPractica;
            n.CodigoFuncion = CodigoFuncion;
            n.LetraFuncion = LetraFuncion;
            n.DescripcionFuncion = DescripcionFuncion;
            n.ValorPrepaga = ValorPrepaga;
            n.ObsPrepaga = ObsPrepaga;
            n.ValorOs = ValorOs;
            n.ObsOs = ObsOs;
            n.ValorArt = ValorArt;
            n.ObsArt = ObsArt;
            n.ValorCaja = ValorCaja;
            n.ObsCaja = ObsCaja;
            n.CodigoGasto = CodigoGasto;
            n.ValorNomenclado = ValorNomenclado;
            n.TipoValor = TipoValor;
            n.GrupoObservacion = GrupoObservacion;
            n.Aplicado = Aplicado;
            n.ValorPactado = ValorPactado;
            n._BorrarRegistro = _BorrarRegistro;
            n._NuevoRegistro = _NuevoRegistro;
            n._UsaObservacion = _UsaObservacion;
            return n;
        }
    }

    public class DiscusionExtra
    {
        public string IDLocal { get; set; } = Guid.NewGuid().ToString();
        public long IDRegistro { get; set; } = 0;
        public int IDEncabezado { get; set; } = 0;
        public string Descripcion { get; set; } = "";
        public bool _BorraRegistro { get; set; } = false;

        public List<DiscusionExtra> Clone(List<DiscusionExtra> p)
        {
            List<DiscusionExtra> n = new List<DiscusionExtra>();

            foreach (DiscusionExtra d in p)
            {
                n.Add(new DiscusionExtra
                {
                    IDLocal = d.IDLocal,
                    IDRegistro = d.IDRegistro,
                    IDEncabezado = d.IDEncabezado,
                    Descripcion = d.Descripcion,
                    _BorraRegistro = d._BorraRegistro
                });
            }

            return n;
        }

    }

    public class DiscusionOtros
    {
        public int IDRegistro { get; set; } = 0;
        public int IDEncabezado { get; set; } = 0;
        public string CodigoOs { get; set; } = "";
        public string CodigoAm { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Observacion { get; set; } = "";
        public string Valor { get; set; } = "0";
        public bool _BorraRegistro { get; set; } = false;

        public DiscusionOtros() { }

        public List<DiscusionOtros> Clone(List<DiscusionOtros> p)
        {
            List<DiscusionOtros> n = new List<DiscusionOtros>();

            foreach (DiscusionOtros d in p)
            {
                n.Add(new DiscusionOtros
                {                    
                    IDRegistro = d.IDRegistro,
                    IDEncabezado = d.IDEncabezado,
                    CodigoOs = d.CodigoOs,
                    CodigoAm = d.CodigoAm,
                    Descripcion = d.Descripcion,
                    Observacion = d.Observacion,
                    Valor = d.Valor,
                    _BorraRegistro = d._BorraRegistro
                });
            }

            return n;
        }
    }

    public class DiscusionGrupoObs
    {
        public string IDLocal { get; set; } = Guid.NewGuid().ToString();
        public int IDRegistro { get; set; } = 0;
        public int IDEncabezado { get; set; } = 0;
        public int IDGrupoPractica { get; set; } = 0;
        public string Grupo { get; set; } = "";
        public string Observacion { get; set; } = "";        

        public List<DiscusionGrupoObs> Clone(List<DiscusionGrupoObs> p)
        {
            List<DiscusionGrupoObs> n = new List<DiscusionGrupoObs>();

            foreach (DiscusionGrupoObs d in p)
            {
                n.Add(new DiscusionGrupoObs
                {
                    IDLocal = d.IDLocal,
                    IDRegistro = d.IDRegistro,
                    IDEncabezado = d.IDEncabezado,
                    IDGrupoPractica = d.IDGrupoPractica,
                    Grupo = d.Grupo,
                    Observacion = d.Observacion                    
                });
            }

            return n;
        }

    }

    public class DiscusionRespuestasAM
    {        
        public string IDLocal { get; set; } = Guid.NewGuid().ToString();
        public int IDRegistro { get; set; } = 0;
        public int IDEncabezado { get; set; } = 0;
        public short Numero { get; set; } = 1;
        public string Texto { get; set; } = "";        
        public virtual BindingList<DiscusionRespuestasOS> RespuestaOs { get; set; } = new BindingList<DiscusionRespuestasOS>();
        public bool _BorraRegistro { get; set; } = false;

        public DiscusionRespuestasAM() { }
        
        public List<DiscusionRespuestasAM> Clone(List<DiscusionRespuestasAM> p)
        {
            List<DiscusionRespuestasAM> n = new List<DiscusionRespuestasAM>();
            DiscusionRespuestasOS o = new DiscusionRespuestasOS();

            foreach (DiscusionRespuestasAM d in p)
            {
                n.Add(new DiscusionRespuestasAM
                {
                    IDLocal = d.IDLocal,
                    IDRegistro = d.IDRegistro,
                    IDEncabezado = d.IDEncabezado,
                    Numero = d.Numero,
                    Texto = d.Texto,
                    _BorraRegistro = d._BorraRegistro,
                    RespuestaOs = new BindingList<DiscusionRespuestasOS>(o.Clone(d.RespuestaOs.ToList()))
                });
            }

            return n;
        }
               
    }

    public class DiscusionRespuestasOS
    {
        public DiscusionRespuestasOS() { }

        public string IDLocal { get; set; } = Guid.NewGuid().ToString();
        public int IDRegistro { get; set; } = 0;
        public int IDRespuesta { get; set; } = 0;        
        public string Observacion { get; set; } = "";
        public bool _BorraRegistro { get; set; } = false;

        public List<DiscusionRespuestasOS> Clone(List<DiscusionRespuestasOS> p)
        {
            List<DiscusionRespuestasOS> n = new List<DiscusionRespuestasOS>();

            foreach (DiscusionRespuestasOS d in p)
            {
                n.Add(new DiscusionRespuestasOS
                {
                    IDLocal = d.IDLocal,
                    IDRegistro = d.IDRegistro,                    
                    IDRespuesta = d.IDRespuesta,
                    Observacion = d.Observacion,
                    _BorraRegistro = d._BorraRegistro
                });
            }

            return n;
        }
    }

    public class DiscusionesGlobal: DiscusionDetalle
    {
        public string TipoPrestataria { get; set; } = "";
        public decimal ValorOrigen
        {
            get
            {
                switch (TipoPrestataria)
                {
                    case "PP": return ValorPrepaga;
                    case "OS": return ValorOs;
                    case "ART": return ValorArt;
                    case "CJ": return ValorCaja;
                    default: return 0;
                }
            }
        }
        public decimal Porcentaje
        {
            get
            {
                decimal calc = 0;

                if (ValorOrigen > 0 && Valor > 0)
                {                    
                    calc = ((Valor / ValorOrigen) * 100) - 100;
                }

                return calc;
            }
        }
        public decimal ValorAnterior { get; set; } = 0;
        public decimal PorcentajeAnterior
        {
            get
            {
                decimal calc = 0;

                if (ValorAnterior > 0 && Valor > 0)
                {                    
                    calc = ((Valor / ValorAnterior) * 100) - 100;
                }

                return calc;
            }
        }
        public string CodigoPrestataria { get; set; } = "";
        public string DescPrestataria { get; set; } = "";
        public string Prestataria
        {
            get
            {
                /*if (CodigoPrestataria != "" && DescPrestataria != "") { return CodigoPrestataria + " " + DescPrestataria ; }
                else if (CodigoPrestataria != "" && DescPrestataria == "") { return CodigoPrestataria; }
                else if (CodigoPrestataria == "" && DescPrestataria != "") { return DescPrestataria; }
                else { return ""; }*/

                string ret = "";

                if (DescPrestataria != "")
                {
                    foreach (string s in DescPrestataria.Split(','))
                    {
                        ret += s + "\n";
                    }
                }

                return ret.Trim();
            }
        }
        public DateTime FechaImpacto { get; set; }
        public string FechaImpactopresent
        {
            get
            {
                string ret = "";

                if (FechaImpacto != DateTime.MinValue)
                {
                    ret = $"{FechaImpacto.Month.ToString("00")}-{FechaImpacto.Year.ToString("0000")}";
                }

                return ret;
            }
        }
        public string DescripcionGrupo { get; set; } = "";
        public string CodigoNombre
        {
            get { return DescripcionGrupo +" "+ CodigoPrestataria; }
        }
    }

    public class Prestatariaarray
    {
        public string Prestataria { get; set; } = "";        
        public string Codigos { get; set; } = "";
        public string GrupoNombre { get; set; } = "";

        public List<Prestatariaarray> Clone(List<Prestatariaarray> p)
        {
            List<Prestatariaarray> n = new List<Prestatariaarray>();

            foreach (Prestatariaarray d in p)
            {
                n.Add(new Prestatariaarray
                {
                    Prestataria = d.Prestataria,
                    Codigos = d.Codigos                    
                });
            }

            return n;
        }

    }

    public class PracticasNomencladas
    {
        private string _codigo = "";
        private string _descripcion = "";
        private int _idgaleno = 0;
        private decimal _unidadgaleno = 0;
        private int _idgasto = 0;
        private decimal _unidadgasto = 0;
        private short _cantayudante = 0;
        private decimal _unidadayudante = 0;


        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = _codigo != value.Trim() ? value.Trim() : _codigo; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion; }
        }

        public int IDGaleno
        {
            get { return _idgaleno; }
            set { _idgaleno = _idgaleno != value ? value : _idgaleno; }
        }

        public decimal UnidadGaleno
        {
            get { return _unidadgaleno; }
            set { _unidadgaleno = _unidadgaleno != value ? value : _unidadgaleno; }
        }

        public int IDGasto
        {
            get { return _idgasto; }
            set { _idgasto = _idgasto != value ? value : _idgasto; }
        }

        public decimal UnidadGasto
        {
            get { return _unidadgasto; }
            set { _unidadgasto = _unidadgasto != value ? value : _unidadgasto; }
        }

        public short CantidadAyudante
        {
            get { return _cantayudante; }
            set { _cantayudante = _cantayudante != value ? value : _cantayudante; }
        }

        public decimal UnidadAyudante
        {
            get { return _unidadayudante; }
            set { _unidadayudante = _unidadayudante != value ? value : _unidadayudante; }
        }
    }

    public class Prestadoras
    {
        private int _iddiscusion = 0;
        private string _nombrelegal = "";
        private long _cuit = 0;
        private string _agrupadorcodigo = "";
        private string _agrupadornombre = "";
        private string _plancodigo = "";
        private string _plannombre = "";
        private string _codigosdescripciones = "";

        public int IDDiscusion
        {
            get { return _iddiscusion; }
            set { _iddiscusion = _iddiscusion != value ? value : _iddiscusion; }
        }

        public string NombreLegal
        {
            get { return _nombrelegal; }
            set { _nombrelegal = _nombrelegal != value.Trim() ? value.Trim() : _nombrelegal; }
        }

        public long Cuit
        {
            get { return _cuit; }
            set { _cuit = _cuit != value ? value : _cuit; }
        }

        public string AgrupadorCodigo
        {
            get { return _agrupadorcodigo; }
            set { _agrupadorcodigo = _agrupadorcodigo != value.Trim() ? value.Trim() : _agrupadorcodigo; }
        }

        public string AgrupadorNombre
        {
            get { return _agrupadornombre; }
            set { _agrupadornombre = _agrupadornombre != value.Trim() ? value.Trim() : _agrupadornombre; }
        }

        public string AgrupadorCodigoNombre { get { return AgrupadorCodigo + " " + AgrupadorNombre; } }

        public string PlanCodigo
        {
            get { return _plancodigo; }
            set { _plancodigo = _plancodigo != value.Trim() ? value.Trim() : _plancodigo; }
        }

        public string PlanNombre
        {
            get { return _plannombre; }
            set { _plannombre = _plannombre != value.Trim() ? value.Trim() : _plannombre; }
        }

        public string PlanCodigoNombre { get { return PlanCodigo + " " + PlanNombre; } }

        

        public string CodigosDescripciones
        {
            get { return _codigosdescripciones; }
            set { _codigosdescripciones = _codigosdescripciones != value.Trim() ? value.Trim().Remove(value.Length -1) : _codigosdescripciones; }
        }

        //CLONE 
        public Prestadoras Clone()
        {
            Prestadoras d = (Prestadoras)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Prestadoras> Clone(List<Prestadoras> lst)
        {
            List<Prestadoras> lista = new List<Prestadoras>();

            lst.ForEach(f => lista.Add(f.Clone()));

            return lista;
        }

    }
}
