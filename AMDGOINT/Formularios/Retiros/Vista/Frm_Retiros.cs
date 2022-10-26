using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using AMDGOINT.Formularios.Informes;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;

namespace AMDGOINT.Formularios.Retiros.Vista
{
    public partial class Frm_Retiros : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private MC.Encabezado Encabezado = new MC.Encabezado();
        private List<MC.Encabezado> Encabezados = new List<MC.Encabezado>();
        private List<MC.Retiros> Retiros = new List<MC.Retiros>();
        private MC.Retiros _retiro = new MC.Retiros();
        private List<MC.Retiros> _retiros = new List<MC.Retiros>();
        private MC.Encabezado _encabezado = new MC.Encabezado();

        private int RowIndex { get; set; } = 0;

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private Point LocationSplash = new Point();
        private bool _ejecutachange { get; set; } = false;
        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Retiros()
        {
           
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
                        
            //DETERMINO LA POSICION DEL SPLASH
            screenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;

            //RESTAURO LAYOUT ANTERIOR DE GRID
            ctrls.PreferencesGrid(this, gridView, accion: "R");

            //VALOR POR DEFECTO DE REPOS FECHAS MINDATE 
            reposFechas.NullDate = DateTime.MinValue;
            reposFechas.NullText = string.Empty;
            
        }

        #region METODOS MANUALES

        //PARAMETROS INICIO A
        private void IparametrosInicio()
        {
            if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
            if (!bgwInicio.IsBusy) { bgwInicio.RunWorkerAsync(); }
        }

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Encabezado.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;
            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());            
        }

        //PARAMETROS INICIO C
        private void FparametrosInicio()
        {
            //DEFINO LA CADENA DE NOTIFICACIONES
            notificacionesBD.ID_Consulta = 202;
            notificacionesBD.ListenerChange();

            //LANZO LA BUSQUEDA
            Ibusqregistros();
        }
        
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            try
            {
                if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                screenManager.SetWaitFormCaption("Por favor, espere");
                screenManager.SetWaitFormDescription("Obteniendo registros...");
                btnActualizar.Enabled = false;

                tmrescucha.Stop();

                gridView.BeginInit();
                gridView.BeginDataUpdate();

                if (!bgwRegistros.IsBusy) { bgwRegistros.RunWorkerAsync(); }
            }
            catch (Exception)
            {
                btnActualizar.Enabled = true;
                gridView.EndDataUpdate();
            }            
        }

        //PROCESA ENCABEZADOS
        private void ProcesaEncabezados()
        {
            try
            {
                Encabezados.Clear();
                Encabezados.AddRange(Encabezado.GetRegistros());

                Retiros.Clear();
                Retiros.AddRange(Encabezados.SelectMany(s => s.Detalles));
            }
            catch (Exception)
            {

            }
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            try
            {
                gridControl.DataSource = Retiros;
                gridView.EndDataUpdate();
                gridView.EndInit();

                if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                if (gridView.RowCount > 0) { gridView.FocusedRowHandle = RowIndex; }
                btnActualizar.Enabled = true;
                tmrescucha.Start();
            }
            catch (Exception)
            {
                btnActualizar.Enabled = true;
                gridView.EndDataUpdate();
                gridView.EndInit();
            }
            
        }

        //BINDING 
        private void SetBindings()
        {
            try
            {
                _ejecutachange = false; //EL UPDATE DEL BIND EN EL COMPONENTE SE EJECUTA IGUALEMENTE, POR LO TANTO EVITO EL PROCESO CON ESTA VARIABLE
                Accionretiro.DataBindings.Clear();
                if (_retiro != null) { Accionretiro.DataBindings.Add("EditValue", _retiro, nameof(_retiro.Estado)); }
                _ejecutachange = true; //PERMITO LA EJECUCION DEL CHANGE EN EL COMPONENTE BIND
            }
            catch (Exception)
            {

            }
        }

        //MUESTRO EL PANEL DE INFORMACION
        private void SetPanelInformacion(string Titulo = "", string Descripcion = "")
        {
            try
            {
                if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                screenManager.SetWaitFormCaption(Titulo);
                screenManager.SetWaitFormDescription(Descripcion);
                tmrInformacion.Start();                
            }
            catch (Exception)
            {

            }
        }

        //MUESTRO EL FORMULARIO
        private void MuestroFormulario(string acc)
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "RetiEdit" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    SetPanelInformacion("No Permitido", "Usuario sin privilegios");
                    return;
                }
                                
                if (acc != "N" && Encabezados.Where(w => w.IDRegistro == _retiro.IDEncabezado).FirstOrDefault().Detalles.Where(w => w.Estado == 0).Count() <= 0)
                {
                    SetPanelInformacion("No Permitido", "No hay detalles pendientes");
                    return;
                }
                                
                Frm_Retiro formulario = new Frm_Retiro();
                formulario.Es_Popup = false;
                                
                formulario.Encabezado = acc == "N" ? new MC.Encabezado() : Encabezados.Where(w => w.IDRegistro == _retiro.IDEncabezado).FirstOrDefault().Clone();
                
                ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);               
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al mostrar el formulario.\n" + e.Message, 0);
                return;
            }
        }

        //CAMBIO EL ESTADO DEL RETIRO
        private void SetEstadoRetiro(short estado)
        {
            try
            {
                

                if (!Permisos.Where(w => w.Clave == "RetiApr" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    SetPanelInformacion("No Permitido", "Usuario sin privilegios");
                    
                    return;
                }

                tmrescucha.Stop();

                //SI ESTOY TRABAJANDO CON UNA LISTA
                if (_retiros.Count > 0)
                {
                    if (_retiros.Where(w => w.EnviadoDos).Count() > 0)
                    {
                        SetPanelInformacion("No Permitido", "La lista contiene registros que fueron enviados a DOS.\nQuitelos y vuelva a intentar.");
                        tmrescucha.Start();
                        return;
                    }

                    //MODIFICO VISUALIZACION
                    gridView.BeginDataUpdate();

                    Retiros.Where(w => _retiros.Select(s => s.IDRegistro).Contains(w.IDRegistro)).ToList().ForEach(f => 
                    {
                        f.SqlConnection = SqlConnection;
                        f.Estado = estado;
                        f.Abm();
                    });

                    gridView.EndDataUpdate();
                }
                else
                {
                    if (_retiro.EnviadoDos)
                    {
                        SetPanelInformacion("No Permitido", "Retiro enviado a tesorería.");
                        tmrescucha.Start();
                        return;
                    }

                    //MODIFICO VISUALIZACION
                    gridView.BeginDataUpdate();
                    Retiros.Where(w => w.IDRegistro == _retiro.IDRegistro).ToList().ForEach(f => f.Estado = estado);                    
                    //GUARDO EN BD
                    MC.Retiros r = Retiros.Where(w => w.IDRegistro == _retiro.IDRegistro).FirstOrDefault();
                    if (r != null) { r.SqlConnection = SqlConnection; r.Abm(); }

                    gridView.EndDataUpdate();

                }

                tmrescucha.Start();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al actualizar el estado del retiro.{e.Message}", 0);
                gridView.EndDataUpdate();
                tmrescucha.Start();
                return;
            }
        }

        //MARCA REGISTROS COMO PAGADOS
        private void MarcaPagados()
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "RetiMarcaPago" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    SetPanelInformacion("No Permitido", "Usuario sin privilegios");
                    return;
                }

                tmrescucha.Stop();

                //SI ESTOY TRABAJANDO CON UNA LISTA
                if (_retiros.Count > 0)
                {
                    if (_retiros.Where(w => !w.EnviadoDos || w.Estado != 1).Count() > 0)
                    {
                        SetPanelInformacion("No Permitido", "La lista contiene registros que no fueron enviados a DOS o Autorizados.\nQuitelos y vuelva a intentar.");
                        tmrescucha.Start();
                        return;
                    }

                    //MODIFICO VISUALIZACION
                    gridView.BeginDataUpdate();

                    Retiros.Where(w => _retiros.Select(s => s.IDRegistro).Contains(w.IDRegistro)).ToList().ForEach(f =>
                    {
                        f.SqlConnection = SqlConnection;
                        f.Pagado = !f.Pagado;
                        f.Abm();
                    });

                    gridView.EndDataUpdate();
                }
                else
                {
                    if (!_retiro.EnviadoDos || _retiro.Estado != 1)
                    {
                        SetPanelInformacion("No Permitido", "Retiro no enviado a DOS o Autorizado.");
                        tmrescucha.Start();
                        return;
                    }

                    //MODIFICO VISUALIZACION
                    gridView.BeginDataUpdate();
                    Retiros.Where(w => w.IDRegistro == _retiro.IDRegistro).ToList().ForEach(f => f.Pagado = !f.Pagado);
                    
                    //GUARDO EN BD
                    MC.Retiros r = Retiros.Where(w => w.IDRegistro == _retiro.IDRegistro).FirstOrDefault();
                    if (r != null) { r.SqlConnection = SqlConnection; r.Abm(); }

                    gridView.EndDataUpdate();

                }

                tmrescucha.Start();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al actualizar el estado del retiro.{e.Message}", 0);
                gridView.EndDataUpdate();
                tmrescucha.Start();
                return;
            }
        }

        //MUESTRO EL COMPROBANTE
        private void MuestraComprobante()
        {
            try
            {
                if (_retiro == null) { return; }

                if (!_retiro.ExisteComprobante)
                {
                    if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                    screenManager.SetWaitFormCaption("Registro sin comprobante");
                    screenManager.SetWaitFormDescription("");

                    tmrInformacion.Start();
                    return;
                }
                else
                {                    
                    MC.Retiros _retitmp = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;

                    if (_retitmp != null)
                    {
                        if (_retitmp.TipoArchivo == ".pdf") { VisualizarComprobantepdf(_retitmp); }
                        else { VisualizarComprobantepdfImg(_retitmp); }
                    }
                }


            }
            catch (Exception)
            {

            }
        }

        //VISUALIZA COMPROBANTE RETIRO
        private void VisualizarComprobantepdfImg(MC.Retiros _retiro)
        {
            try
            {
                Usr_Visualizador visualiza = new Usr_Visualizador();
                visualiza.Imagen = _retiro.Comprobante;
                XtraDialogForm form = new XtraDialogForm();
                form.Shown += form_Shown;
                form.ShowMessageBoxDialog(new XtraDialogArgs(this, visualiza, "Comprobante de retiro", new DialogResult[] { DialogResult.OK }, 0));

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No se puede mostrar el comprobante.\n{e.Message}", 1);
                return;
            }
        }

        //VISUALIZAR COMPROBANTE PDF
        private void VisualizarComprobantepdf(MC.Retiros _retiro)
        {
            try
            {
                Frm_Pdfviewer pd = new Frm_Pdfviewer();
                MemoryStream str = new MemoryStream(_retiro.Comprobante);
                pd.CargaVista(str);
                pd.ShowDialog();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un inconveniente al mostrar el presupuesto.\n {e.Message}", 0);
                return;
            }
        }

        //PARA MOSTRAR EL CUADRO DE AGRANDAR EN EL FORM DIALOG
        void form_Shown(object sender, EventArgs e)
        {
            XtraDialogForm frm = sender as XtraDialogForm;
            frm.IconOptions.Image = this.IconOptions.Image;
            frm.MaximizeBox = true;
            List<SimpleButton> btns = frm.Controls.OfType<SimpleButton>().ToList();
            foreach (SimpleButton btn in btns)
                btn.Anchor = AnchorStyles.Bottom;
            Control content = frm.Controls.OfType<Control>().Last();
            content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
        }
        
        //INICIO EXPORTACION
        private void IExportacion()
        {
            try
            {
                if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                screenManager.SetWaitFormCaption("Por favor, espere");
                screenManager.SetWaitFormDescription("Enviando registros...");

                btNuevoBar.Enabled = false;
                btnEditarbar.Enabled = false;
                btnExportados.Enabled = false;

                gridView.BeginInit();
                gridView.BeginDataUpdate();

                if (!bgwExportacion.IsBusy) { bgwExportacion.RunWorkerAsync(); }
            }
            catch (Exception)
            {
                btNuevoBar.Enabled = true;
                btnEditarbar.Enabled = true;
                btnExportados.Enabled = true;
                return;
            }
        }

        //FIN EXPORTACION
        private void FExportacion()
        {            
            gridView.EndDataUpdate();
            gridView.EndInit();

            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
            if (gridView.RowCount > 0) { gridView.FocusedRowHandle = RowIndex; }

            btNuevoBar.Enabled = true;
            btnEditarbar.Enabled = true;
            btnExportados.Enabled = true;

            Ibusqregistros();

        }

        //PROCESA LA EXPORTACION DE LOS RETIROS
        private void ExportacionRetiros()
        {
            try
            {
                List<MC.Retiros> _retiroslst = new List<MC.Retiros>();
                Crealistaretiros(_retiroslst);
                                                
                //SOLO LOS APROBADOS POR GERENCIA Y NO ENVIADOS
                _retiroslst.RemoveAll(r => r.Estado != 1 || r.EnviadoDos);

                if (_retiroslst.Count == 0) { return; }

                //CAMBIO EL ESTADO DE LOS REGISTROS A ENVIADO
                MarcaRegistrosenviados(_retiroslst);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al enviar la lista de retiros.\n{e.Message}", 1);
                return;
            }
        }

        //LISTA DE RETIROS A EXPORTAR
        private void Crealistaretiros(List<MC.Retiros> _retiroslst)
        {
            try
            {               
                if (gridView.RowCount <= 0) { return; }
                                
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    MC.Retiros ret = gridView.GetRow(i) as MC.Retiros;
                    if (ret != null) { _retiroslst.Add(ret); }                    
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al crear la lista de retiros.\n{e.Message}", 1);
                return;
            }
        }

        //MARCA REGISTROS COMO ENVIADOS
        private void MarcaRegistrosenviados(List<MC.Retiros> _retiroslst)
        {
            try
            {
                Dictionary<short, string> retorno = new Dictionary<short, string>();

                foreach (MC.Retiros reti in _retiroslst)
                {
                    reti.SqlConnection = SqlConnection;
                    reti.EnviadoDos = true;
                    retorno = reti.Abm();

                    if (retorno.Count > 0)
                    {
                        string mensajes = "";

                        foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                        {
                            mensajes += $"{i.Trim()}\n";
                        }

                        if (!string.IsNullOrWhiteSpace(mensajes))
                        {
                            ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1);
                            break;
                        }
                    }
                }

            }
            catch (Exception )
            {                
                return;
            }
        }

        //EMISION DE RESUMEN
        private void ImpreimeResumen()
        {
            try
            {
                List<MC.Retiros> _retiroslst = new List<MC.Retiros>();

                //CREA LISTA REGISTROS 
                Crealistaretiros(_retiroslst);

                if (_retiroslst.Count <= 0) { return; }

                Xrpt_Retiros reporte = new Xrpt_Retiros();
                reporte.DataSource = _retiroslst.Where(w => w.Estado == 1);
                ReportPrintTool printTool = new ReportPrintTool(reporte);
                printTool.ShowPreviewDialog();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el resumen.\n{e.Message}", 1);
                return;
            }
        }

        //CREO LA COLECCION DE RETIROS EN CASO DE SELECCIONAR UN GRUPO
        private void SetRetirosLista(int filaprocesar)
        {
            try
            {
                _retiros.Clear();
                int groupRowHandle = filaprocesar;                
                AsignaItemsGrupos(groupRowHandle);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo inconvenientes al crear la lista de retiros.\n{e.Message}", 1);
                _retiros.Clear();
                return;
            }
        }

        private void AsignaItemsGrupos(int filagrupo)
        {
            try
            {
                //obtengo el numero de items en el grupo
                int cantidaditems = gridView.GetChildRowCount(filagrupo);

                for (int i = 0; i < cantidaditems; i++)
                {
                    //obtengo el handle del item segun su index
                    int childHandle = gridView.GetChildRowHandle(filagrupo, i);

                    //el la fila hijo tambien es un grupo, agrego sus items con el mismo metodos
                    if (gridView.IsGroupRow(childHandle))
                    {
                        AsignaItemsGrupos(childHandle);
                    }
                    else
                    {
                        //agrego el retiro siempre que no exista en la lista
                        MC.Retiros r = gridView.GetRow(childHandle) as MC.Retiros;
                        if (r != null && !_retiros.Contains(r)) { _retiros.Add(r); }
                    }
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
            IparametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, gridView, accion: "S");
        }


        //******************* EVENTOS SEGUNDO PLANO *************************      
        #region BACKGROUND WORKERS
        private void bgwInicio_DoWork(object sender, DoWorkEventArgs e)
        {
            Parametrosinicio();
        }

        private void bgwInicio_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FparametrosInicio();
        }

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcesaEncabezados();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgwExportacion_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportacionRetiros();
        }

        private void bgwExportacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FExportacion();
        }

        #endregion

        //************************** FIN SEGUNDO PLANO **********************************************

        #region EVENTOS DE GRILLA
        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount > 0 && !gridView.IsGroupRow(gridView.FocusedRowHandle))
            {
                popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
            }
        }
        
        private void gridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            try
            {
                if (popupMenu.Visible) { popupMenu.HidePopup(); }
                
                //SI NO ES UNA FILA AGRUPADA, OBTENGO EL REGISTRO UNICO (AGREGO AL BIND)
                if (!gridView.IsGroupRow(gridView.FocusedRowHandle))
                {
                    if (_retiros.Count > 0) { _retiros.Clear(); } //limpio la lista de retiros
                    _retiro = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
                    SetBindings();
                }
                //SI ES UNA FILA AGRUPADA, CREO UNA LISTA CON LOS DETALLES
                else { SetRetirosLista(gridView.FocusedRowHandle); }

                RowIndex = e.RowHandle;

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("error en FocusedRowObjectChanged.", 1);
                return;
            }            
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }

            //APROBACION
            if (e.KeyCode == Keys.Q)
            {
                SetEstadoRetiro(1);
            }
            //RECHAZO
            else if (e.KeyCode == Keys.W)
            {
                SetEstadoRetiro(2);
            }
            //PENDIENTE
            else if (e.KeyCode == Keys.E)
            {
                SetEstadoRetiro(0);
            }
            //VISUALIZA COMPROBANTE (SI EXISTE)
            else if (e.KeyCode == Keys.C)
            {
                MuestraComprobante();
            }
            //PAGADO
            else if (e.KeyCode == Keys.P)
            {
                MarcaPagados();
            }
        }

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridView.ActiveEditor is MemoEdit)
            {
                (gridView.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridView.ActiveEditor as MemoEdit).Paint += Form1_Paint;
            }
        }
        
        private void gridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            try
            {
                GridGroupRowInfo info = e.Info as GridGroupRowInfo;
                GridView view = sender as GridView;
                var rowValue = view.GetGroupRowValue(info.RowHandle, info.Column);
                info.GroupText = rowValue.ToString();
            }
            catch (Exception)
            {

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

        private void gridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Importe")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }
        }
        
        #endregion

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;                
            }
        }

        private void btNuevoBar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }
        
        private void Accionretiro_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_ejecutachange)
                {
                    BarEditItem t = sender as BarEditItem;
                    SetEstadoRetiro(Convert.ToInt16(t.EditValue));
                }
                
            }
            catch (Exception)
            {

            }
            
        }

        private void btnComprobante_ItemClick(object sender, ItemClickEventArgs e)
        {
            MuestraComprobante();
        }

        private void tmrInformacion_Tick(object sender, EventArgs e)
        {
            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
            tmrInformacion.Stop();
        }              
      
        private void btnExportados_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                ctrls.ExportaraExcelgrd(gridControl);
            }
            catch (Exception n)
            {
                ctrls.MensajeInfo($"Error al exportar.\n{n.Message}", 1);
                return;
            }
        }

        private void btnResumen_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            ImpreimeResumen();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {                
                Accionretiro.Visibility = Permisos.Where(w => w.Clave == "RetiApr" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First() ?
                    BarItemVisibility.Always : BarItemVisibility.Never;           
                btnPagado.Visibility = Permisos.Where(w => w.Clave == "RetiMarcaPago" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First() ?
                    BarItemVisibility.Always : BarItemVisibility.Never;
            }
            catch (Exception) 
            {

            }            

        }

        private void btnPagado_ItemClick(object sender, ItemClickEventArgs e)
        {
            MarcaPagados();
        }

        private void btnActualizar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Ibusqregistros();
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                var client = new RestSharp.RestClient("https://localhost:7037/api/Factambudets/");
                var request = new RestSharp.RestRequest(RestSharp.Method.GET);
                var response = client.Execute(request);
                List<Facturas.Ambulatorio.MC.FacturaDet> Empresas = new List<Facturas.Ambulatorio.MC.FacturaDet>();
                Empresas.AddRange(JsonConvert.DeserializeObject<List<Facturas.Ambulatorio.MC.FacturaDet>>(response.Content));                
                Empresas.Count();                                             

            }
            catch (Exception n)
            {
                ctrls.MensajeInfo(n.Message, 1);
                
            }
        }
    }
}