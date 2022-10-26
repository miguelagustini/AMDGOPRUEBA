using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using AMDGOINT.Formularios.Informes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Text;
using System.IO;
using System.Globalization;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_DiscusionesMain : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();        
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Discusionescls discusiones = new Discusionescls();

        private int IDRegistro { get; set; } = 0;
        private int indexrow = -1;
        private bool _canedit = false;
        private bool Cambiarow = false;
        private Point LocationSplash = new Point();

        public Frm_DiscusionesMain()
        {
           
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            ctrls.setSplitter(splitter);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250,
                                      workingArea.Top + 73);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {            
            ctrls.PreferencesGrid(this, bgridview, accion: "R");
            
            notificacionesBD.ID_Consulta = 7;
            notificacionesBD.ListenerChange();
            
            tmrDetalles.Start();
            
            reposdFecha.NullDate = DateTime.MinValue;
            reposdFecha.NullText = string.Empty;

            if (globales.GetIdUsuariolog() != 1) { }
            _canedit = func.DevuelvePermiso("NegEmis");
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            screenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;
            if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
            

            tmrescucha.Stop();
            bgridview.BeginDataUpdate();
            
            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {            
            bgridview.EndDataUpdate();
            gridControl.DataSource = discusiones.encabezadoslst;
            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }                

            if (bgridview.RowCount >= indexrow) { bgridview.FocusedRowHandle = indexrow; }

            tmrescucha.Start();
        }               

        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Discusion formulario = new Frm_Discusion();

                formulario.discusionenc = acc == "N" ? new DiscusionEncabezado() : discusiones.encabezadoslst.Where(r => r.IDRegistro == IDRegistro).
                        DefaultIfEmpty(new DiscusionEncabezado()).First().Clone();
                                                
                ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al mostrar el formulario.\n" + e.Message, 0);
                return;
            }
        }

        //ACTUALIZO EL ENCABEZADO CON LOS DATOS DEL CIERRE
        private void EjecutaCierre(byte tipovalor, DateTime fechadiscusion, DateTime fechaimp, short estado, string agrupador)
        {
            try
            {                
                //PRIMERO ACTUALIZO LOS DATOS ENCABEZADO
                if (IDRegistro <= 0 || agrupador == "") { return; }

                if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                

                //VALIDO SI LA EPOCA CERO ACTUAL YA ESTÁ APLICADA DE LO CONTRARIO NO PUEDE CONTINUAR
                if (discusiones.ContieneEpocasAsocaran(agrupador) && !discusiones.PuedoInsertAsocaran(agrupador))
                {
                    ctrls.MensajeInfo($"Hay una valorización sin aplicar para {agrupador}.\n" +
                        $"Al aplicar esos valores podrá cerrar la negociación actual.",1);

                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                        

                    return;
                }
                
                //CARGO MI VARIABLE DE DETALLES                
                List<DiscusionDetalle> detalles = new List<DiscusionDetalle>();
                DiscusionDetalle disc = new DiscusionDetalle();
                detalles = disc.Clone(discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Detalles.Where
                                        (w => w.TipoValor == tipovalor && w.FechaNeg == fechadiscusion)).ToList());


                if (detalles.Count <= 0)
                {
                    ctrls.MensajeInfo($"Los parámetros ingresados no contienen prácticas.", 1);

                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                    return;
                }

                if (detalles.Where(w => w.IDRegistro <= 0).Count() > 0)
                {
                    ctrls.MensajeInfo($"Los detalles no terminaron de cargarse completamente, intente nuevamente en unos momentos.", 1);

                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                    return;
                }

                //CONTROLO QUE NO HAYA PRACTICAS DUPLICADAS
                StringBuilder duplicadas = new StringBuilder();

                foreach(var v in detalles.GroupBy(g => new { g.CodigoPractica, g.DescripcionPractica, g.IDFuncion }).Select(gs => new
                {
                    id = gs.Key.CodigoPractica,
                    descripcion = gs.Key.DescripcionPractica,
                    cantidad = gs.Count()
                }).Where(w => w.cantidad > 1).Select(s => new { s.id, s.cantidad, s.descripcion }))
                {
                    if (v.cantidad > 1)
                    {
                        if (string.IsNullOrEmpty(duplicadas.ToString()))
                        { duplicadas.Append(v.ToString()); }
                        else { duplicadas.AppendLine(v.ToString()); }
                        continue;
                    }
                 
                }

                if (!string.IsNullOrEmpty(duplicadas.ToString()))
                {
                    ctrls.MensajeInfo($"Se encontraron prácticas duplicadas para los parametros de cierre.\n" +
                        $"Haga una revisión y quite los duplicados antes de continuar.\n" + duplicadas, 1);
                    
                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }

                    return;
                }


                StringBuilder porpresupuesto = new StringBuilder();
                //CONTROLO QUE NO HAYA PRESUPUESTOS CON VALOR
                detalles.Where(w => w.IDFuncion == 4 && w.Valor > 0).ToList().ForEach(f => porpresupuesto.Append(f.CodigoPractica + " " + f.DescripcionPractica));
                if (!string.IsNullOrWhiteSpace(porpresupuesto.ToString()))
                {
                    ctrls.MensajeInfo($"No se puede cerrar una valorizacion con practicas por presupuesto con valor asignado.\n" + porpresupuesto, 1);

                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }

                    return;
                }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("FechaCierre");
                campos.Add("FechaImpacto");
                campos.Add("Estado");

                parametros.Add(fechadiscusion);
                parametros.Add(fechaimp);
                parametros.Add(estado);
                
                func.AccionBD(campos, parametros, "U", "DISCUSIONENC", IDRegistro);


                //LUEGO ACTUALIZO LOS DATOS DE LOS DETALLES
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();
                                               
                string qry = $"UPDATE DISCUSIONDET SET Aplicado = {estado} WHERE ID_Encabezado = {IDRegistro} AND FechaNeg = '{fechadiscusion}'" +
                    $" AND EsAmdgo = {tipovalor}";
                   
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = con;
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;
                        command.CommandText = qry;
                        command.ExecuteNonQuery();
                        transaction.Commit();                        
                    }
                }

                if (!discusiones.ExsisteFechaAsocaran(agrupador, fechaimp))
                {
                    //AHORA INSERT ASOC                
                    discusiones.InsertAmdgosis(fechaimp, agrupador, IDRegistro, detalles);
                }

                if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al ejecutar el cierre.\n {e.Message}", 0);
                if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                return;
            }
        }

        //APLICO LA EPOCA DETERMINADA
        private void EjecutaAplicacion()
        {
            try
            {
                screenManager.ShowWaitForm();

                //PRIMERO ACTUALIZO LOS DATOS ENCABEZADO
                if (IDRegistro <= 0) { screenManager.CloseWaitForm(); return; }

                //RECUPERO DE DATOS PREVIOS
                DateTime fechac = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).Select(s => s.FechaImpacto).DefaultIfEmpty(DateTime.MinValue).First();
                string agrupador = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).Select(s => s.CodigoGupo).DefaultIfEmpty(string.Empty).First();

                if (fechac == DateTime.MinValue)
                {
                    ctrls.MensajeInfo($"No hay Fecha de impacto disponible", 1);
                    screenManager.CloseWaitForm();
                    return;
                }

                if (agrupador == string.Empty)
                {
                    ctrls.MensajeInfo($"No hay información de agrupador disponible.", 1);
                    screenManager.CloseWaitForm();
                    return;
                }

                //CARGO MI VARIABLE DE DETALLES                
                List<DiscusionDetalle> detalles = new List<DiscusionDetalle>();

                foreach (DiscusionDetalle d in discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Detalles))
                {
                    if (d.Aplicado == 1) { detalles.Add(d); }
                }

                if (detalles.Count() <= 0)
                {
                    ctrls.MensajeInfo($"No se encontraron detalles a procesar.", 1);
                    screenManager.CloseWaitForm();
                    return;
                }

                if (detalles.Where(w => w.IDRegistro <= 0).Count() > 0)
                {
                    ctrls.MensajeInfo($"Los detalles no terminaron de cargarse completamente, intente nuevamente en unos momentos.", 1);

                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                    return;
                }

                StringBuilder porpresupuesto = new StringBuilder();
                //CONTROLO QUE NO HAYA PRESUPUESTOS CON VALOR
                detalles.Where(w => w.IDFuncion == 4 && w.Valor > 0).ToList().ForEach(f => porpresupuesto.Append(f.CodigoPractica + " " + f.DescripcionPractica));
                if (!string.IsNullOrWhiteSpace(porpresupuesto.ToString()))
                {
                    ctrls.MensajeInfo($"No se puede cerrar una valorizacion con practicas por presupuesto con valor asignado.\n" + porpresupuesto, 1);

                    if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }

                    return;
                }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();
                                
                campos.Add("Estado");                                
                parametros.Add(2);

                func.AccionBD(campos, parametros, "U", "DISCUSIONENC", IDRegistro);
                
                //LUEGO ACTUALIZO LOS DATOS DE LOS DETALLES
                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                string qry = $"UPDATE DISCUSIONDET SET Aplicado = 2 WHERE ID_Encabezado = {IDRegistro} AND Aplicado = 1";                    

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (qry != "")
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

                //AHORA ACTUALIZO ASOC (GLOBAL) SIEMPRE QUE LA FECHA NO ESTÉ EN USO
                if (!discusiones.ExsisteFechaAsocaran(agrupador, fechac))
                {
                    discusiones.UpdateAmdgosis(fechac, agrupador, IDRegistro, detalles);
                }

                screenManager.CloseWaitForm();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al ejecutar el cierre.\n {e.Message}", 0);
                screenManager.CloseWaitForm();
                return;
            }
        }

        //CIERRO EL ESTADO DE LA VALORIZACION
        private void SetEstadovaloriza(short estado)
        {
            try
            {
                List<DateTime> fechas = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).Select(s => s.Detalles)
                    .DefaultIfEmpty(new List<DiscusionDetalle>()).First().GroupBy(g => new { g.FechaNeg}).Select(s => s.First().FechaNeg).ToList();

                string agrupador = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).Select(s => s.CodigoGupo).DefaultIfEmpty("").First();
                DateTime fechaimp = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).Select(s => s.FechaImpacto).DefaultIfEmpty(DateTime.MinValue).First();

                if (agrupador == "" || fechaimp == DateTime.MinValue) { return; }

                //INICIO PARAMETROS
                Usr_PrametrosCierre parametros = new Usr_PrametrosCierre(fechas);

                if (XtraDialog.Show(parametros, "Parámetros de cierre", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                //SI HAY FECHA
                if (parametros.FechaDiscusion == "") { ctrls.MensajeInfo("No se puede realizar la operación sin fecha.", 1); return; }

                DateTime fechacierre = Convert.ToDateTime(parametros.FechaDiscusion);
               
                string palabra = parametros.Tipovalor == 0 ? "Obra Social" : "Amdgo";
                                
                //ANTES DE TODO, VALIDO QUE NO HAYA PRACTICAS DUPLICADAS PARA EL PERIODO


                if (ctrls.MensajePregunta($"Se cerrará ésta discusión con el valor de carga el día {fechacierre.ToString("dd-MM-yyyy H:mm:ss")}" +
                    $" establecido por {palabra}, con impacto en {fechaimp.ToString("MM-yyyy")}.\nAdemás, todos aquellos valores en cero" +
                    $" cuya función no sea PP serán ignorados.\n¿Continuar?") == DialogResult.Yes)
                {
                    EjecutaCierre(parametros.Tipovalor, fechacierre, fechaimp, estado, agrupador);
                }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al finalizar el estado.\n {e.Message}", 0);
                return;
            }
        }
                
        //EXPORTACION
        private void GeneraReporte()
        {
            try
            {
                if (IDRegistro <= 0) { return; }
                                
                //INICIO PARAMETROS
                Usr_Exportacion parametros = new Usr_Exportacion();
                if (XtraDialog.Show(parametros, "Parámetros de exportación", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                Xrpt_Memo report = new Xrpt_Memo();                
                                                
                List<DiscusionEncabezado> li = new List<DiscusionEncabezado>();
                DiscusionEncabezado enc = new DiscusionEncabezado();
                enc = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).DefaultIfEmpty(new DiscusionEncabezado()).First().Clone();
                li.Add(enc);

                //ACTUALIZO LA OBSERVACION DE LOS GRUPOS SEGUN LO CARGADO EN DETALLES OBS
                foreach (DiscusionDetalle d in enc.Detalles.Where(w => w.Aplicado >= 1))
                {
                    d.GrupoObservacion = enc.GruposObs.Where(w => w.IDGrupoPractica == d.IDGrupo).Select(s => s.Observacion).DefaultIfEmpty(string.Empty).First();
                }

                //OBTENGO LISTA GENERAL
                li = li.Select(s => new DiscusionEncabezado
                {                        
                    PrestatariaConjunto = s.PrestatariaConjunto,
                    CuitPrestataria = s.CuitPrestataria,
                    CodigoGupo = s.CodigoGupo,
                    DescripcionGrupo = s.DescripcionGrupo,
                    CodigosConjuntos = s.CodigosConjuntos,
                    FechaImpacto = s.FechaImpacto,
                    Extras = s.Extras,
                    Otros = s.Otros,
                    Detalles = s.Detalles.Where(w => w.Aplicado >= 1).ToList(),
                    Prestadoras = s.Prestadoras
                        
                }).ToList();


                report.DataSource = li.FirstOrDefault().Prestadoras;                                
                report.RequestParameters = false;
                foreach (var p in report.Parameters) { p.Visible = false; }
                report.Parameters["FechaNeg"].Value = enc.FechaImpacto;
                report.Parameters["GrupoSeleccion"].Value = parametros.ImpresionAgrupadorCodigo;
                report.Parameters["HideCoseguro"].Value = parametros.VerCoseguro;
                report.Parameters["HideCopago"].Value = parametros.VerCopago;

                XRSubreport subReportControl = report.FindControl("subReportDiscusion", true) as XRSubreport;
                XtraReport subReport = subReportControl.ReportSource as XtraReport;
                subReport.DataSource = li;



                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
                parametros.Dispose();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al generar el reporte.\n {e.Message}", 0);
                return;
            }
        }

        //GENERACION TEMPORAL
        private void Reportestemporal()
        {
            try
            {
                List<DiscusionEncabezado> lista = new List<DiscusionEncabezado>();

                //CREO LA LISTA COMPLETA (SOLO ESTADO 2)
                for (int i = 0; i < bgridview.RowCount; i++)
                {
                    DiscusionEncabezado p = bgridview.GetRow(i) as DiscusionEncabezado;
                    lista.Add(p.Clone());
                }

                string path = @"C:\Users\Usuario\Desktop\Nueva carpeta";
                //Xrpt_Aranceles report = new Xrpt_Aranceles();
                Xrpt_Memo report = new Xrpt_Memo();
                List<DiscusionEncabezado> li = new List<DiscusionEncabezado>();

                foreach (DiscusionEncabezado en in lista)
                {

                    //ACTUALIZO LA OBSERVACION DE LOS DETALLES SEGUN LO CARGADO EN DETALLES OBS
                    foreach (DiscusionDetalle d in en.Detalles)
                    {
                        d.GrupoObservacion = en.GruposObs.Where(w => w.IDGrupoPractica == d.IDGrupo).Select(s => s.Observacion).DefaultIfEmpty(string.Empty).First();
                    }

                    li.Clear();
                    li.Add(en);

                    //OBTENGO LISTA GENERAL
                    li = li.Select(s => new DiscusionEncabezado
                    {
                        PrestatariaConjunto = s.PrestatariaConjunto,
                        CuitPrestataria = s.CuitPrestataria,
                        CodigoGupo = s.CodigoGupo,
                        DescripcionGrupo = s.DescripcionGrupo,
                        CodigosConjuntos = s.CodigosConjuntos,
                        FechaImpacto = s.FechaImpacto,
                        Extras = s.Extras,
                        Otros = s.Otros,
                        Detalles = s.Detalles.Where(w => w.Aplicado >= 1).ToList(),
                        Prestadoras = s.Prestadoras

                    }).ToList();

                    report.DataSource = li.FirstOrDefault().Prestadoras;

                    report.Parameters["FechaNeg"].Value = en.FechaImpacto;
                    report.Parameters["GrupoSeleccion"].Value = false;
                    report.Parameters["HideCoseguro"].Value = false;
                    report.Parameters["HideCopago"].Value = false;

                    XRSubreport subReportControl = report.FindControl("subReportDiscusion", true) as XRSubreport;
                    XtraReport subReport = subReportControl.ReportSource as XtraReport;
                    subReport.DataSource = li;

                    report.CreateDocument();

                    DevExpress.XtraPrinting.XlsxExportOptions op = new DevExpress.XtraPrinting.XlsxExportOptions();
                    op.ShowGridLines = true;
                    op.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    op.SheetName = en.AbraviaGrupo + " " + en.CodigoGupo;

                    report.ExportToXlsx(path + @"\" + en.DescripcionGrupo + " " + en.CodigoGupo + ".xlsx", op);
                    //FileInfo fi = new FileInfo(path + @"\" + en.DescripcionGrupo + " " + en.CodigoGupo + ".xlsx");                    
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo(e.Message, 1);
                throw;
            }
        }

        //GENERACION DE ARANCELES POR LOTE
        private void GeneracionDiscusiones()
        {
            try
            {
                tmrescucha.Stop();
                List<DiscusionEncabezado> lista = new List<DiscusionEncabezado>();

                //CREO LA LISTA COMPLETA (SOLO ESTADO 2)
                for (int i = 0; i < bgridview.RowCount; i++)
                {
                    DiscusionEncabezado p = bgridview.GetRow(i) as DiscusionEncabezado;

                    p.Detalles = p.Detalles.Where(w => w.Aplicado == 2).ToList();
                    if (p.Estado == 2) { lista.Add(p.Clone()); }                    
                }                  
                
                Frm_GeneradorNegociacion frm = new Frm_GeneradorNegociacion();
                frm.Discusiones = lista.GroupBy(y => y.IDGrupoOs).Select(o => o.OrderByDescending(t => t.FechaImpacto).First()).ToList(); 

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Ibusqregistros();
                }
                else{ tmrescucha.Start(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"ocurrió un error al procesar las discusiones.\n{e.Message}", 1);
                return;
            }
        }

        /*SOLO USO PROGRAMADOR*/
        private void InsertPracticasglob()
        {
            try
            {
                List<DiscusionEncabezado> lista = new List<DiscusionEncabezado>();
                //CREO LA LISTA COMPLETA (SOLO ESTADO 0)
                for (int i = 0; i < bgridview.RowCount; i++)
                {
                    DiscusionEncabezado p = bgridview.GetRow(i) as DiscusionEncabezado;

                    p.Detalles = p.Detalles.Where(w => w.Aplicado == 0).ToList();
                    if (p.Estado == 0) { lista.Add(p.Clone()); }
                    
                }

                List<DiscusionEncabezado> newlist = lista.GroupBy(y => y.IDGrupoOs).Select(o => o.OrderByDescending(t => t.FechaImpacto).First()).ToList();
                                
                List<DiscusionDetalle> listdetalle = new List<DiscusionDetalle>();
                foreach (DiscusionEncabezado en in newlist)
                {

                    DiscusionDetalle detalle = new DiscusionDetalle();
                    detalle.IDEncabezado = en.IDRegistro;
                    detalle.FechaNeg = en.Detalles.GroupBy(g => g.FechaNeg).Select(s => s.First().FechaNeg).First();
                    detalle.IDPractAm = 7249;
                    detalle.IDFuncion = 3;
                    detalle.TipoValor = 1;
                    detalle.Valor = 4000;
                    detalle.CodigoOs = "070615";

                    listdetalle.Add(detalle);
                }

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                StringBuilder sb = new StringBuilder();

                string a = "INSERT INTO DISCUSIONDET (ID_Encabezado, Guid, FechaNeg, ID_Practica, CodigoOs, ID_Funcion, Valor, ValorCoseguro, ValorCopago, Observacion," +
                           " CodigoGasto, EsAmdgo, Aplicado, ID_UsuNew) VALUES ";

                foreach (DiscusionDetalle av in listdetalle)
                {                                       
                    sb.Append(a + $"({av.IDEncabezado}, '{av.IDLocal}', '{av.FechaNeg.ToString("yyyy-MM-dd HH:mm:ss")}', {av.IDPractAm}, '{av.CodigoOs}', {av.IDFuncion}," +
                                  $" {av.Valor.ToString(new CultureInfo("en-US"))}, 0, 0, '', '', 1, 0, 0);");

                    
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (sb.ToString() != "")
                            {
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = sb.ToString();
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }

                        }
                    }

                    sb.Clear();                   

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            splitter.SplitterPosition = (splitter.Height / 2);
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridview, accion: "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            discusiones.ListarRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }
        
        private void bgridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            IDRegistro = 0;

            if (bgridview.RowCount <= 0) { return; }

            var idreg = bgridview.GetFocusedRowCellValue(colID_Registro);

            if (idreg != null)
            {
                IDRegistro = Convert.ToInt32(idreg);
                Cambiarow = true;
            }
        }

        private void bgridView_ShownEditor(object sender, EventArgs e)
        {
            if (bgridview.ActiveEditor is MemoEdit)
            {

                (bgridview.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (bgridview.ActiveEditor as MemoEdit).Paint += Form1_Paint;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawFocusRectangle(e.Graphics, e.ClipRectangle);
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            if (sender is MemoEdit)
            {
                MemoEditViewInfo vi = (sender as MemoEdit).GetViewInfo() as MemoEditViewInfo;
                var cache = new GraphicsCache((sender as MemoEdit).CreateGraphics());
                int h = (vi as IHeightAdaptable).CalcHeight(cache, vi.MaskBoxRect.Width);
                var args = new ObjectInfoArgs();
                args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, h);
                var rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
                cache.Dispose();
                (sender as MemoEdit).Height = rect.Height;
            }
        }

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;                
            }
        }

        private void btnNuevaprest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarprest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void btNuevoBar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void tmrDetalles_Tick(object sender, EventArgs e)
        {
            if (Cambiarow)
            {                
                Cambiarow = false;
            }
        }

        private void btnCerrarValoriza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canedit) { ctrls.MensajeInfo("No posee los privilegios para realizar ésta acción.", 1); }
            SetEstadovaloriza(1);            
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            var v = bgridview.GetFocusedRowCellValue(colEstado);

            if (v != null && (short)v < 1)
            {
                btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnAplicarValorización.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnExportar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (v != null && (short)v == 1)
            {
                btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnAplicarValorización.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnExportar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (v != null && (short)v >= 2)
            {
                btnCerrarValoriza.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnAplicarValorización.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnExportar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
             
        private void bgridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
                       
            if ((e.Column == colEstado) && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                e.DisplayText = "";                
            }

        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GeneraReporte();
        }

        private void btnAplicarValorización_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_canedit) { ctrls.MensajeInfo("No posee los privilegios para realizar ésta acción.", 1); }
            if (ctrls.MensajePregunta($"Se aplicarán los valores de la discusión cerrada.\n¿Continuar?") == DialogResult.Yes)
            {
                EjecutaAplicacion();
            }
        }

        private void btnGeneracion_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {

            //if (!_canedit) { ctrls.MensajeInfo("No posee los privilegios para realizar ésta acción.", 1); }
            //GeneracionDiscusiones();
            Reportestemporal();
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            /*INSERTA PRACTICAS GLOBAL SOLO USO PROGRAMADOR*/

            InsertPracticasglob();
        }

        private void btnGeneradorGlobal_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (!_canedit) { ctrls.MensajeInfo("No posee los privilegios para realizar ésta acción.", 1); return; }
            GeneracionDiscusiones();
        }
    }
}