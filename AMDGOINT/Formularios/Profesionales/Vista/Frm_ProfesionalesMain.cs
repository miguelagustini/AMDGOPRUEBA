using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_ProfesionalesMain : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();        

        private Frm_DirecCont frmcontact = new Frm_DirecCont();        
        private Frm_Especialidades frmespecialidad = new Frm_Especialidades();
        private Frm_Prestatarias frmprestatarias = new Frm_Prestatarias();
        private Frm_Cuentas frmcuentas = new Frm_Cuentas();
        private Frm_Diferencial frmdiferencial = new Frm_Diferencial();

        private Frm_ExIngresosBrutos frmingresosbrutos = new Frm_ExIngresosBrutos();
        private Frm_ExImpuestoGanancias frmimpuestoganancias = new Frm_ExImpuestoGanancias();
        private Frm_ExInstitutoBecario frminstitutobecario = new Frm_ExInstitutoBecario();
        private Frm_CondicionFiscalIVa frmcondicionfiscaliva = new Frm_CondicionFiscalIVa();

        private MC.Profesionales profesionalcls = new MC.Profesionales();
        private List<MC.Profesionales> profesionaleslst = new List<MC.Profesionales>();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private ConexionBD cnbd = new ConexionBD();

        private SqlConnection SqlConnection { get; set; } = new SqlConnection();
                
        private int IDRegistro { get; set; } = 0;

        private int indexrow = -1;
        private Point LocationSplash = new Point();

        public Frm_ProfesionalesMain()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            ctrls.setSplitter(splitter);

            reposFechas.NullDate = DateTime.MinValue;
            reposFechas.NullText = string.Empty;
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State == System.Data.ConnectionState.Open ? SqlConnection : cnbd.Conectar();
            profesionalcls.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, bgridView, accion: "R");

            notificacionesBD.ID_Consulta = 2;
            notificacionesBD.SqlConnection = SqlConnection;
            notificacionesBD.ListenerChange();

            ControlAcceso();

            frmcontact.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmcontact, Tabdetalles);
            frmespecialidad.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmespecialidad, Tabdetalles);
            frmprestatarias.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmprestatarias, Tabdetalles);
            frmcuentas.SqlConnection = SqlConnection;
            frmcuentas.VisualizaCtaCte = Permisos.Where(w => w.Clave == "PrfVerCta" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault();
            ctrls.AgregaFormulario(frmcuentas, Tabdetalles);
                        
            ctrls.AgregaFormulario(frmdiferencial, Tabdetalles); 
            ctrls.AgregaFormulario(frmingresosbrutos, Tabdetalles);
            ctrls.AgregaFormulario(frmimpuestoganancias, Tabdetalles);
            ctrls.AgregaFormulario(frminstitutobecario, Tabdetalles);
            ctrls.AgregaFormulario(frmcondicionfiscaliva, Tabdetalles);

            //ICONOS            
            Tabdetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BOContact2_16x16;
            Tabdetalles.TabPages[1].ImageOptions.Image = Properties.Resources.ContentArrangeInRows_16x16;
            Tabdetalles.TabPages[2].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;
            Tabdetalles.TabPages[3].ImageOptions.Image = Properties.Resources.Driving_16x16;
            Tabdetalles.TabPages[4].ImageOptions.Image = Properties.Resources.Currency_16x16;
            Tabdetalles.TabPages[5].ImageOptions.Image = Properties.Resources.BO_Opportunity;
            Tabdetalles.TabPages[6].ImageOptions.Image = Properties.Resources.BO_Organization;
            Tabdetalles.TabPages[7].ImageOptions.Image = Properties.Resources.BO_Sale;
            Tabdetalles.TabPages[8].ImageOptions.Image = Properties.Resources.BO_Note;
            Tabdetalles.SelectedTabPageIndex = 0;
                        
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
        }

        //Control de acceso usuario
        private void ControlAcceso()
        {
            try
            {

                //CARGA PERMISOS
                Permisos.Clear();
                Permisos.AddRange(Permiso.GetPermisoUsuario());

                btnNuevobar.Enabled = Permisos.Where(w => w.Clave == "ProfAlta" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault(); 
                btnFemesfe.Enabled = Permisos.Where(w => w.Clave == "ProfFemesfe" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault();
                btnPadron.Enabled = Permisos.Where(w => w.Clave == "ProfPadron" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault();
                btnPadronAmdgo.Enabled = Permisos.Where(w => w.Clave == "ProfPadron" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault(); 
                btnExenciones.Enabled = Permisos.Where(w => w.Clave == "ProfExenc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault();
            }
            catch (Exception)
            {
                btnEditarbar.Enabled = false;
                btnNuevobar.Enabled = false;
                return;       
            }
        }

        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            tmrescucha.Stop();
            indexrow = Convert.ToInt32(bgridView.GetFocusedRowCellValue("IDRegistro")); //bgridView.FocusedRowHandle;
            bgridView.BeginDataUpdate();
            profesionaleslst.Clear();

            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            try
            {
                gridControl.DataSource = profesionaleslst;
                bgridView.EndDataUpdate();

                //if (bgridView.RowCount >= indexrow) { bgridView.FocusedRowHandle = indexrow; }
                bgridView.FocusedRowHandle = bgridView.LocateByValue("IDRegistro", indexrow);
                tmrescucha.Start();

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un error al finalizar la carga.\n{e.Message}", 1);
                bgridView.EndDataUpdate();
                return;
            }
            
        }

        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Profesional formulario = new Frm_Profesional();               
                formulario.Es_Popup = false;
                
                formulario.Profesional = acc == "N" ? new MC.Profesionales() :
                                                      profesionaleslst.Where(w => w.IDRegistro == IDRegistro).
                                                      DefaultIfEmpty(new MC.Profesionales()).FirstOrDefault().Clone();
                

                ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al iniciar.\n {e.Message}", 0);
                return;
            }
        }
                
        //BAJA DEL PROFESIONAL
        private void BajaProfesional()
        {
            try
            {
                if (IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Estado");
                campos.Add("ID_UsuModif");
                parametros.Add(0);
                parametros.Add(globales.GetIdUsuariolog());

                func.AccionBD(campos, parametros, "U", "PROFESIONALES", IDRegistro);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al dar de baja el profesional.\n" + e.Message, 0);
                return;
            }
        }

        //PADRON
        public void PadronProfesionales(string tipo = "T")
        {
            try
            {
                List<MC.Profesionales> profesionales = new List<MC.Profesionales>();
                MC.Direcciones drcclass = new MC.Direcciones();


                List<MC.Profesionales> lista = new List<MC.Profesionales>();
                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    MC.Profesionales p = bgridView.GetRow(i) as MC.Profesionales;
                    lista.Add(p);
                }
                

                if (tipo == "T")
                {
                    profesionales = lista.Where(w => w.IDTitulo > 0 && (w.IDReferencia == 0) && w.Estado)
                    .Select(s => new MC.Profesionales()
                    {
                        IDRegistro = s.IDRegistro,
                        Nombre = s.Nombre,
                        Cuit = s.Cuit,
                        Categoria = s.Categoria,
                        FechaNacimiento = s.FechaNacimiento,
                        FechaGraduacion = s.FechaGraduacion,
                        Universidad = s.Universidad,
                        Titulo = s.Titulo,
                        Libro = s.Libro,
                        Folio = s.Folio,
                        MatriculaProv = s.MatriculaProv,
                        MatriculaNacional = s.MatriculaNacional,
                        CodigoArteCurar = s.CodigoArteCurar,
                        RegistroNacional = s.RegistroNacional,
                        VtoRegNacional = s.VtoRegNacional,
                        IDGrupo = s.IDGrupo,
                        DescripcionGrupo = s.DescripcionGrupo,
                        Observaciones = s.Observaciones,
                        Direcciones = drcclass.Clone(s.Direcciones.Where(w => w.Tipo == "L" && w.Estado).ToList()),
                        Especialidades = s.Especialidades,
                        Cuentas = s.Cuentas

                    }
                    ).ToList();
                }
                else if (tipo == "I")
                {
                    profesionales = lista.Where(w => w.Estado).Select(s => new MC.Profesionales()
                    {
                        IDRegistro = s.IDRegistro,
                        Nombre = s.Nombre,
                        Categoria = s.Categoria,
                        Cuit = s.Cuit,
                        FechaNacimiento = s.FechaNacimiento,
                        FechaGraduacion = s.FechaGraduacion,
                        Universidad = s.Universidad,
                        Titulo = s.Titulo,
                        Libro = s.Libro,
                        Folio = s.Folio,
                        MatriculaProv = s.MatriculaProv,
                        MatriculaNacional = s.MatriculaNacional,
                        CodigoArteCurar = s.CodigoArteCurar,
                        RegistroNacional = s.RegistroNacional,
                        VtoRegNacional = s.VtoRegNacional,
                        IDGrupo = s.IDGrupo,
                        DescripcionGrupo = s.DescripcionGrupo,
                        Observaciones = s.Observaciones,
                        Direcciones = s.Direcciones,
                        Especialidades = s.Especialidades,
                        Cuentas = s.Cuentas

                    }
                    ).ToList();
                }
                      
                Xrpt_Padron report = new Xrpt_Padron();
                report.DataSource = profesionales;

                XRSubreport subReportControl = report.FindControl("SrtEspecialidades", true) as XRSubreport;
                XtraReport subReport = subReportControl.ReportSource as XtraReport;
                subReport.DataSource = profesionales.SelectMany(s => s.Especialidades).ToList();

                XRSubreport subReportControl1 = report.FindControl("SrtDomicilios", true) as XRSubreport;
                XtraReport subReport1 = subReportControl1.ReportSource as XtraReport;                
                subReport1.DataSource = profesionales.SelectMany(s => s.Direcciones).ToList();

                XRSubreport subReportControl2 = report.FindControl("SrtCuentas", true) as XRSubreport;
                XtraReport subReport2 = subReportControl2.ReportSource as XtraReport;
                subReport2.DataSource = profesionales.SelectMany(s => s.Cuentas).ToList();

                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No podemos mostrar el padrón es éste momento.\n{e.Message}", 0);
                return;
            }
          
        }

        public void MuestraListaExenciones()
        {
            try
            {
                MC.ExencionesPrint exprt = new MC.ExencionesPrint(SqlConnection);
                exprt.GeneraReporte();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar la lista.\n{e.Message}", 1);
                return;
            }
        }


        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
           
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            splitter.SplitterPosition = (splitter.Height / 2);
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridView, "S");
            SqlConnection.Dispose();
            cnbd.Desconectar();

        }
        
        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {            
            profesionaleslst = profesionalcls.Clone(profesionalcls.GetProfesionales().Where(w => w.Visible).ToList());
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }
        
        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            if (bgridView.RowCount > 0)
            {

                //ESTADO
                var es = bgridView.GetFocusedRowCellValue(colEstado);
                if (es.ToString().Equals("Activo")) { btnBaja.Visibility = DevExpress.XtraBars.BarItemVisibility.Always; }
                else { btnBaja.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; }
            }
            else
            {               
                btnBaja.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            
        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }            
            IDRegistro = 0;

            if (bgridView.RowCount <= 0) { return; }

            var idreg = bgridView.GetFocusedRowCellValue(colID_Registro);

            if (idreg != null)
            {
                IDRegistro = Convert.ToInt32(idreg);

                frmcontact.Direccioneslst.Clear();                
                frmcontact.Direccioneslst = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Direcciones).ToList();
                frmcontact.IDProfesional = IDRegistro;

                frmespecialidad.Especialidadeslst.Clear();
                frmespecialidad.Especialidadeslst = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Especialidades).ToList();
                frmespecialidad.IDProfesional = IDRegistro;

                frmprestatarias.Prestatariaslst.Clear();
                frmprestatarias.Prestatariaslst = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Prestatarias).ToList();
                frmprestatarias.IDProfesional = IDRegistro;

                frmcuentas.Cuentaslst.Clear();
                frmcuentas.Cuentaslst = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Cuentas).ToList();
                frmcuentas.IDProfesional = IDRegistro;

                frmdiferencial.Diferenciallst.Clear();
                frmdiferencial.Diferenciallst = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Diferencial).ToList();
                frmdiferencial.IDProfesional = IDRegistro;

                frmingresosbrutos.IngresosBrutos.Clear();
                frmingresosbrutos.IngresosBrutos = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.RetencionIngresosBrutos).ToList();
                frmingresosbrutos.IDProfesional = IDRegistro;

                frmimpuestoganancias.ImpuestoGanancias.Clear();
                frmimpuestoganancias.ImpuestoGanancias = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.RetencionGanancias).ToList();
                frmimpuestoganancias.IDProfesional = IDRegistro;

                frminstitutobecario.InstitutoBecario.Clear();
                frminstitutobecario.InstitutoBecario = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.RetencionInstitutoBecario).ToList();
                frminstitutobecario.IDProfesional = IDRegistro;

                frmcondicionfiscaliva.CondicionFiscalIva.Clear();
                frmcondicionfiscaliva.CondicionFiscalIva = profesionaleslst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.CategoriaCondicionesIva).ToList();
                frmcondicionfiscaliva.IDProfesional = IDRegistro;

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
     
        private void btnNuevobar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }
        
        private void btnBaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Permisos.Where(w => w.Clave == "ProfBaja" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).FirstOrDefault())
            {
                ctrls.MensajeInfo("No tiene autorización para realizar ésta acción.", 1);
                return;
            }

            if (ctrls.MensajePregunta("¿Dar de baja éste prestador?") == DialogResult.No) { return; }

            BajaProfesional();

        }

        private void btnExcelexport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);
        }

        private void btnFemesfe_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {

            Frm_Femesfepreview formulario = new Frm_Femesfepreview();
            formulario.Es_Popup = false;

            ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);
        }

        private void btnPadron_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {                        
            PadronProfesionales();
        }

        private void btnPadronAmdgo_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            PadronProfesionales("I");
        }

        private void bgridView_DoubleClick(object sender, EventArgs e)
        {
            if (bgridView.RowCount > 0) { MuestroFormulario("E"); }            
        }

        private void btnExenciones_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestraListaExenciones();
        }

        private void bgridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.RowHandle != GridControl.NewItemRowHandle && e.Column.FieldName == "EsProfesionalDescripcion")
                {
                    if (e.CellValue.ToString() == "Profesional")
                    { e.RepositoryItem = reposTextProfesional; }
                    else { e.RepositoryItem = reposTextEntidad; }
                }
                else if (e.RowHandle != GridControl.NewItemRowHandle && (e.Column.FieldName == "TrabajaConIaposDescripcion" || e.Column.FieldName == "AsociadoAmDescripcion" || 
                                                                         e.Column.FieldName == "EstadoDescripcion" || e.Column.FieldName == "AsociadoDiferencialDescripcion"))
                {
                    if (e.CellValue.ToString() == "Activo" || e.CellValue.ToString() == "Asociado" || e.CellValue.ToString() == "Socio Diferencial" || e.CellValue.ToString() == "Si")
                    { e.RepositoryItem = reposTextSi; }                    
                    else { e.RepositoryItem = reposTextNo; }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}