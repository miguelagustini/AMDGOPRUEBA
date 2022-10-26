using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraGrid;
using AMDGOINT.Formularios.Reclamos.MC;

namespace AMDGOINT.Formularios.Reclamos.Vista
{
    public partial class Frm_Reclamos : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();

        private ReclamosEnc Reclamo = new ReclamosEnc();
        private List<ReclamosEnc> Reclamos = new List<ReclamosEnc>();
        
        private Usr_Detalles UsrDetalles = new Usr_Detalles(false);
        private Usr_Eventos UsrEventos = new Usr_Eventos(false);

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private Notificacionesbd notificacionesbd = new Notificacionesbd();

        
        
        
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();

        private MC.ReclamosEnc _encabezado;
                
        private string Pathexport { get; set; } = "";
        
        public Frm_Reclamos()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

            SetControles();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Reclamo.SqlConnection = SqlConnection;            
            Permiso.SqlConnection = SqlConnection;


            notificacionesbd.ID_Consulta = 11;
            notificacionesbd.SqlConnection = SqlConnection;
            notificacionesbd.ListenerChange();

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());            
        }

        private void SetControles()
        {
            try
            {
                panelDetalles.Controls.Add(UsrDetalles);
                UsrDetalles.Dock = DockStyle.Fill;

                panelEventos.Controls.Add(UsrEventos);
                UsrEventos.Dock = DockStyle.Fill;
            }
            catch (Exception)
            {

            }
        }

        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {
                timerEscucha.Stop();
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                SetControlesState(false);
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { return; }
                
                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                SetControlesState(true);
                gridView.EndDataUpdate();
                timerEscucha.Start();
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Reclamos.Clear();               
                Reclamos.AddRange(Reclamo.GetRegistros());                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al obtener los registros.\n{e.Message}", 1);
                return;
            }
        }

        //FIN DE CONSULTA REGISTROS
        private void FBusqRegistros()
        {
            try
            {
                gridControl.DataSource = Reclamos;
                gridView.EndDataUpdate();

                SetControlesState(true);

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                SetControlesState(true);
                timerEscucha.Start();
            }
            
        }

        public void SetControlesState(bool estado)
        {
            btnImpresion.Enabled = estado;
            btnNuevo.Enabled = estado;
            btnEditar.Enabled = estado;
            btnActualizar.Enabled = estado;
        }

        //PREPARO IMPRESION
        public void PreparaImpresion(short mode = 0,  bool unicoreg = false, long findbyid = 0)
        {
            /*try
            {                
                ListaPrint.Clear();

                if (!Permisos.Where(w => w.Clave == "RecPrint" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de comprobantes", 1);
                    return;
                }
                    

                if (unicoreg)
                {
                    //SI DEBO ENCONTRAR POR ID (USADO PARA IMPRIMIR DESDE FUERA DEL FORM)
                    if (findbyid > 0)
                    {
                        ReclamosEnc p = Reclamo.Where(w => w.IDRegistro == findbyid).FirstOrDefault();

                        if (p != null){ ListaPrint.Add(p); }
                        else
                        {
                            ctrls.MensajeInfo("No se encontró el comprobante a visualizar.", 1);
                            return;
                        }
                    }
                    else
                    {
                        ReclamosEnc p = gridView.GetRow(gridView.FocusedRowHandle) as ReclamosEnc;
                        if (p != null)
                        {                            
                            ListaPrint.Add(p);
                        }
                    }
                    
                }
                else
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        ReclamosEnc p = gridView.GetRow(i) as ReclamosEnc;                        
                        if (p != null) { ListaPrint.Add(p); }
                        
                    }
                }

                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                CantCopias = parametros.Cantidad;
                IncluirCuentas = parametros.IncluirCuentas;

                Impresion.Reclamo = ListaPrint;

                if (mode == 0) { Impresion.Imprimir(CantCopias, IncluirCuentas); }
                if (mode == 1) { Iexpotarpdf(); }

                parametros.Dispose();
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la impresión.\n{e.Message}", 1);
                return;                
            }*/
        }

        //EXPORTA PDF
        private void Iexpotarpdf()
        {
            /*try
            {
                if (CantCopias <= 0) { return; }
                btnImpresion.Enabled = false;

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                        Pathexport = fbd.SelectedPath;                                                                        

                        if (bgwExportpdf.IsBusy) { bgwExportpdf.CancelAsync(); }
                        while (bgwExportpdf.CancellationPending)
                        { if (!bgwExportpdf.CancellationPending) { break; } }

                        bgwExportpdf.RunWorkerAsync();
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                btnImpresion.Enabled = true;
                return;
            }*/
        }

        private void ExportarPdf()
        {
           /* try
            {
                if (Pathexport == "") { return; }
                Impresion.GeneraDatosPdf(ListaPrint, CantCopias, Pathexport);

            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }*/
        }

        private void Fexportapdf()
        {

            btnImpresion.Enabled = true;
            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            Pathexport = "";
        }

        //EXPORTA EXCEL (parametro de grid para acceso public0)
        public void ExportaExcel(GridControl grid = null)
        {
            if (!Permisos.Where(w => w.Clave == "ReclExl" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene acceso a la exportacion de comprobantes en lista.", 1);
                return;
            }

            ctrls.ExportaraExcelgrd(grid != null ? grid : gridControl);
        }

        //GENERACION DE COMPROBANTE
        private void GeneraComprobante(string acc = "N")
        {
            try
            {

                //PERMISOS GENERAL
                if (!Permisos.Where(w => w.Clave == "ReclNew" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar Reclamos.", 1);
                    return;
                }

                if (acc != "N" && _encabezado.IDUsuNew != glb.GetIdUsuariolog() && glb.GetIdUsuariolog() != 1)
                {
                    ctrls.MensajeInfo("No puede alterar el reclamo iniciado por otra persona.", 1);
                    return;
                }

                Frm_Reclamo frm = new Frm_Reclamo();
                frm.FormularioPadre = this;
                frm.SqlConnection = SqlConnection;

                frm.Permisos.Clear();
                frm.Permisos.AddRange(Permisos);

                if (_encabezado != null && acc == "E")
                {
                    if (_encabezado.Estado > 0)
                    {
                        ctrls.MensajeInfo("Éste relcamo ya fue finalizado y <b>NO</b> puede ser modificado.", 1);
                        frm.Dispose();
                        return;
                    }                    
                    
                    frm.Reclamo = _encabezado.Clone();
                    
                }
                else
                {
                    frm.Reclamo = new ReclamosEnc();
                }                

                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //CREACIÓN DE EVENTO
        private bool RegistrarEvento()
        {
            try
            {
                if (_encabezado is null || _encabezado.IDRegistro <= 0)
                {
                    ctrls.MensajeInfo("No se puede generar un evento sin un identificador de reclamo.", 1);
                    return false;
                }

                //VALIDAR NO  AGREGAR SI ESTA TERMINADO
                if (_encabezado.Estado > 0)
                {
                    ctrls.MensajeInfo("No se puede generar un evento para un reclamo finalzado", 1);
                    return false;
                }

                if (_encabezado.IDUsuNew != glb.GetIdUsuariolog() && glb.GetIdUsuariolog() != 1)
                {
                    ctrls.MensajeInfo("No puede alterar el reclamo de otra persona.", 1);
                    return false;
                }

                Frm_EventoPopup frm = new Frm_EventoPopup();
                frm.SqlConnection = SqlConnection;
                frm.Evento.IDEncabezado = _encabezado.IDRegistro;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridView.BeginDataUpdate();
                    _encabezado.Eventos.Add(frm.Evento);
                    gridView.EndDataUpdate();
                    return true;
                }
                else { return false; }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al registrar el evento.\n{e.Message}", 1);
                return false;
            }
        }

        //CIERRE / ANULACION  DE RECLAMO
        private void EstadoReclamo(byte estado)
        {
            try
            {
                if (_encabezado is null || _encabezado.Estado > 0) { return; }
                
                if (_encabezado.IDUsuNew != glb.GetIdUsuariolog() && glb.GetIdUsuariolog() != 1)
                {
                    ctrls.MensajeInfo("No puede alterar el reclamo de otra persona.", 1);
                    return;
                }                            

                string palabra = estado == 1 ? "cerrar" : "anular";                
                
                if (ctrls.MensajePregunta($"¿Está seguro de {palabra} el reclamo?\nDe ser si, se solicitará registrar un evento.\nLuego las urgencias del mismo\nserán marcadas como <b>Normal</b>.") != DialogResult.Yes) { return; }

                if (_encabezado.MontoRecuperado <= 0 && ctrls.MensajePregunta($"El monto total recuperado es 0.\n¿{palabra} de todos modos?") != DialogResult.Yes) { return; }

                if (!RegistrarEvento())
                {
                    ctrls.MensajeInfo("No se puede cambiar el estado del reclamo sin un evento.", 1);
                    return;
                }

                gridView.BeginDataUpdate();
                _encabezado.Estado = estado;
                _encabezado.Urgencia = 0;
                _encabezado.FechaCierre = DateTime.Now;
                _encabezado.Abm(false);
                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {                
                ctrls.MensajeInfo($"Hubo un inconveniente al cerrar el reclamo.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        //EXPORTAR RECLAMO
        private void ExportarReclamo()
        {
            try
            {
                List<ReclamosDet> _detalles = new List<ReclamosDet>();

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    ReclamosEnc p = gridView.GetRow(i) as ReclamosEnc;
                    if (p != null) { _detalles.AddRange(p.Detalles); }
                }

                Frm_Exportacion parametros = new Frm_Exportacion();
                parametros.Detalles.AddRange(_detalles);

                parametros.Show();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar la exportación\n{e.Message}", 1);
                return;
            }
            
        }
        
        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            IBusqRegistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {            
            ConexionBD.Desconectar();
            SqlConnection.Dispose();
            ctrls.PreferencesGrid(this, gridView, "S");
            ctrls.PreferencesGrid(this, dockManager, "S");
        }
        
        //******************* EVENTOS BACKGROUND *************************
     
        private void bgwObtienereg_DoWork(object sender, DoWorkEventArgs e)
        {
            GetRegistros();            
        }

        private void bgwObtienereg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FBusqRegistros();
        }

        private void NavPanel_ElementClick(object sender, NavElementEventArgs e)
        {
            if (e.IsTile)
            {
                if (gridView.RowCount <= 0) { return; }
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnPrevisualizacion": PreparaImpresion(0); break;
                    case "btnPdf": PreparaImpresion(1); break;
                    case "btnExcel": ExportaExcel(); break;
                    case "btnExportacionweb": PreparaImpresion(1); break;                     
                }

            }
        }

        private void bgwExportpdf_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportarPdf();
        }

        private void bgwExportpdf_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fexportapdf();
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            if (popupMenu.Visible) { popupMenu.HidePopup(); }

            try
            {
                _encabezado = gridView.GetRow(gridView.FocusedRowHandle) as ReclamosEnc;
                if (_encabezado != null)
                {
                    UsrDetalles.IDPrestataria = _encabezado.PrestatariaID;
                    UsrDetalles.Detalles = _encabezado.Detalles;
                    UsrDetalles.IDReclamo = _encabezado.IDRegistro;
                    UsrDetalles.EstadoReclamo = _encabezado.Estado;
                    UsrDetalles.NombreCreditosExport = _encabezado.PrestatariaAbreviatura + " " + _encabezado.Periodo;
                    UsrEventos.Eventos = _encabezado.Eventos;
                    UsrEventos.IDReclamo = _encabezado.IDRegistro;
                }
                
                
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar los detalles de la factura.", 1);
            }

        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PreparaImpresion(0, true);
        }

        private void btnNuevo_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraComprobante();
        }

        private void btnEditar_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraComprobante("E");
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {                
                if (e.RowHandle != GridControl.NewItemRowHandle && e.Column.FieldName == "ReclamoNumero")
                {                    
                    var v = gridView.GetRowCellValue(e.RowHandle, "EstadoDescripcion");
                    if (v?.ToString() == "Finalizado"){ e.RepositoryItem = reposFinalizado; }
                    else if (v?.ToString() == "Anulado") { e.RepositoryItem = reposAnulado; }
                    else { e.RepositoryItem = reposProceso; }
                }
            }
            catch (Exception)
            {
                return;                
            }
        }

        private void timerEscucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesbd.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                IBusqRegistros();

                notificacionesbd.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }

        private void btnActualizar_ElementClick(object sender, NavElementEventArgs e)
        {
            IBusqRegistros();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {
                btnCerrar.Visibility = _encabezado != null && _encabezado.Estado <= 0 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnEvento.Visibility = _encabezado != null && _encabezado.Estado <= 0 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnAnular.Visibility = _encabezado != null && _encabezado.Estado <= 0 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void btnCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EstadoReclamo(1);
        }

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EstadoReclamo(2);
        }

        private void btnEvento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RegistrarEvento();
        }

        private void btnExport_ElementClick(object sender, NavElementEventArgs e)
        {
            ExportarReclamo();            
        }

    }
    
}