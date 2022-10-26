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
using DevExpress.Utils;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Frm_Configuraciones : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private MC.ConfiguracionDet Detalle { get; set; } = new MC.ConfiguracionDet();
        private List<MC.ConfiguracionDet> Detalles { get; set; } = new List<MC.ConfiguracionDet>();
        private List<MC.ConfiguracionDet> _detalles { get; set; } = new List<MC.ConfiguracionDet>();

        private int RowIndex { get; set; } = 0;

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private Point LocationSplash = new Point();
                
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Configuraciones()
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
            ctrls.PreferencesGrid(this, bgGridView, accion: "R");
            
        }

        #region METODOS MANUALES
        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection;
            Detalle.SqlConnection = SqlConnection;

            Permiso.SqlConnection = SqlConnection;


            notificacionesBD.ID_Consulta = 209;
            notificacionesBD.ListenerChange();

            ctrls.PreferencesGrid(this, bgGridView, "R");
                        
        }

        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            try
            {                
                if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }

                HabilitaComponentes(false);
                
                if (!bgwRegistros.IsBusy) { bgwRegistros.RunWorkerAsync(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);                
                HabilitaComponentes(true);
                return;
            }            
        }

        //EJECUTA LA BUSQUEDA
        private void BusqRegistros()
        {
            try
            {
                Detalles.Clear();
                Detalles.AddRange(Detalle.GetRegistros());

                //CARGA PERMISOS
                Permisos.Clear();
                Permisos.AddRange(Permiso.GetPermisoUsuario());
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);                
                HabilitaComponentes(true);
                return;
            }
        }
             
        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            try
            {
                gridControl.DataSource = Detalles;
                HabilitaComponentes(true);

                if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
                if (bgGridView.RowCount > 0) { bgGridView.FocusedRowHandle = RowIndex; }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);                
                HabilitaComponentes(true);
                return;
            }
            
        }

        private void HabilitaComponentes(bool estado)
        {
            btnActualizar.Enabled = estado;
            btnEditarbar.Enabled = estado;
            btNuevoBar.Enabled = estado;

            if (estado)
            {
                tmrescucha.Start();
                bgGridView.EndDataUpdate();                
            }
            else
            {
                tmrescucha.Stop();
                bgGridView.BeginDataUpdate();
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
     
        //CREO LA COLECCION DE RETIROS EN CASO DE SELECCIONAR UN GRUPO
        private async void SetConfiguracionLista(int filaprocesar)
        {
            try
            {
                _detalles.Clear();
                int groupRowHandle = filaprocesar;                
                await AsignaItemsGrupos(groupRowHandle);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo inconvenientes al crear la lista de configuraciones.\n{e.Message}", 1);
                _detalles.Clear();
                return;
            }
        }

        private async Task AsignaItemsGrupos(int filagrupo)
        {
            try
            {
                //obtengo el numero de items en el grupo
                int cantidaditems = bgGridView.GetChildRowCount(filagrupo);

                for (int i = 0; i < cantidaditems; i++)
                {
                    //obtengo el handle del item segun su index
                    int childHandle = bgGridView.GetChildRowHandle(filagrupo, i);

                    //el la fila hijo tambien es un grupo, agrego sus items con el mismo metodos
                    if (bgGridView.IsGroupRow(childHandle))
                    {
                        await AsignaItemsGrupos(childHandle);
                    }
                    else
                    {
                        //agrego el retiro siempre que no exista en la lista
                        MC.ConfiguracionDet r = bgGridView.GetRow(childHandle) as MC.ConfiguracionDet;
                        if (r != null && !_detalles.Contains(r)) { _detalles.Add(r); }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //MUESTRO EL FORMULARIO
        private void MuestroFormulario(string acc)
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "CntConfEdit" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene los privilegios para realiza ésta acción.", 1);
                    return;
                }

                Frm_Configuracion formulario = new Frm_Configuracion();
                formulario.SqlConnection = SqlConnection;

                formulario.Configuraciones = acc == "N" ? new List<MC.ConfiguracionDet>()
                    : _detalles.Count() == 0 ? new List<MC.ConfiguracionDet>() : new List<MC.ConfiguracionDet>(_detalles);

                formulario.ShowDialog();                                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al mostrar el formulario.\n" + e.Message, 0);
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
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgGridView, accion: "S");
        }


        //******************* EVENTOS SEGUNDO PLANO *************************      
        #region BACKGROUND WORKERS
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            BusqRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        #endregion

        //************************** FIN SEGUNDO PLANO **********************************************

        #region EVENTOS DE GRILLA
        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (bgGridView.RowCount > 0 && !bgGridView.IsGroupRow(bgGridView.FocusedRowHandle))
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
                if (!bgGridView.IsGroupRow(bgGridView.FocusedRowHandle))
                {
                    if (_detalles.Count > 0) { _detalles.Clear(); } //limpio la lista de configuraciones
                    _detalles.Add(bgGridView.GetRow(bgGridView.FocusedRowHandle) as MC.ConfiguracionDet);
                    
                }
                //SI ES UNA FILA AGRUPADA, CREO UNA LISTA CON LOS DETALLES
                else { SetConfiguracionLista(bgGridView.FocusedRowHandle); }

                RowIndex = e.RowHandle;
                
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("error en FocusedRowObjectChanged.", 1);
                return;
            }            
        }
        
        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (bgGridView.ActiveEditor is MemoEdit)
            {
                (bgGridView.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (bgGridView.ActiveEditor as MemoEdit).Paint += Form1_Paint;
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
      
        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {                
                /*Accionretiro.Visibility = Permisos.Where(w => w.Clave == "RetiApr" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First() ?
                    BarItemVisibility.Always : BarItemVisibility.Never;           
                btnPagado.Visibility = Permisos.Where(w => w.Clave == "RetiMarcaPago" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First() ?
                    BarItemVisibility.Always : BarItemVisibility.Never;*/
            }
            catch (Exception) 
            {

            }            

        }

        private void btnActualizar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Ibusqregistros();
        }

        private void btnImpresion_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (gridControl.IsPrintingAvailable) { gridControl.ShowRibbonPrintPreview(); }
        }
    }
}