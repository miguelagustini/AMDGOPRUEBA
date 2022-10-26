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
using AMDGOINT.Formularios.Recibos.MC;

namespace AMDGOINT.Formularios.Recibos.Vista
{
    public partial class Frm_Recibos : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();

        private ReciboEnc Recibo = new ReciboEnc();
        private List<ReciboEnc> Recibos = new List<ReciboEnc>();
        private List<ReciboEnc> ListaPrint = new List<ReciboEnc>();
        private Usr_Detalles UsrDetalles = new Usr_Detalles();
                
        private Notificacionesbd notificacionesbd = new Notificacionesbd();
        private Impresion Impresion = new Impresion();
        private short CantCopias = 1;
        private bool IncluirCuentas = false;
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();

        private ReciboEnc _encabezado;
                
        private string Pathexport { get; set; } = "";

        public Frm_Recibos()
        {

            InitializeComponent();

            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            SetControles();

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Recibo.SqlConnection = SqlConnection;            
            
            notificacionesbd.ID_Consulta = 10;
            notificacionesbd.SqlConnection = SqlConnection;
            notificacionesbd.ListenerChange();

            ctrls.PreferencesGrid(this, gridView, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
                        
        }

        private void SetControles()
        {
            try
            {
                panelDetalles.Controls.Add(UsrDetalles);
                UsrDetalles.Dock = DockStyle.Fill;                
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
                HabilitaBotones(false);
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                HabilitaBotones(true);
                gridView.EndDataUpdate();
                timerEscucha.Start();
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Recibos.Clear();               
                Recibos.AddRange(Recibo.GetRegistros());                
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
                gridControl.DataSource = Recibos;
                gridView.EndDataUpdate();
                HabilitaBotones(true);

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                HabilitaBotones(true);
                timerEscucha.Start();
            }
            
        }

        private void HabilitaBotones(bool estado)
        {
            btnImpresion.Enabled = estado;
            btnNuevo.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnEditar.Enabled = estado;
            btnFacturasCanceladas.Enabled = estado;
        }

        //PREPARO IMPRESION
        public void PreparaImpresion(short mode = 0,  bool unicoreg = false, long findbyid = 0)
        {
            try
            {                
                ListaPrint.Clear();

                if (!glb.GetPermisos().Where(w => w.Clave == "RecPrint" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de comprobantes", 1);
                    return;
                }
                    

                if (unicoreg)
                {
                    //SI DEBO ENCONTRAR POR ID (USADO PARA IMPRIMIR DESDE FUERA DEL FORM)
                    if (findbyid > 0)
                    {
                        ReciboEnc p = Recibos.Where(w => w.IDRegistro == findbyid).FirstOrDefault();

                        if (p != null){ ListaPrint.Add(p); }
                        else
                        {
                            ctrls.MensajeInfo("No se encontró el comprobante a visualizar.", 1);
                            return;
                        }
                    }
                    else
                    {
                        ReciboEnc p = gridView.GetRow(gridView.FocusedRowHandle) as ReciboEnc;
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
                        ReciboEnc p = gridView.GetRow(i) as ReciboEnc;   
                        
                        if (p != null) { ListaPrint.Add(p); }
                        
                    }
                }

                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                CantCopias = parametros.Cantidad;
                IncluirCuentas = parametros.IncluirCuentas;

                Impresion.Recibos = ListaPrint;

                if (mode == 0) { Impresion.Imprimir(CantCopias, IncluirCuentas); }
                if (mode == 1) { Iexpotarpdf(); }

                parametros.Dispose();
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la impresión.\n{e.Message}", 1);
                return;                
            }
        }

        //EXPORTA PDF
        private void Iexpotarpdf()
        {
            try
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
            }
        }

        private void ExportarPdf()
        {
            try
            {
                if (Pathexport == "") { return; }
                Impresion.GeneraDatosPdf(ListaPrint, CantCopias, Pathexport);

            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }
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
            if (!glb.GetPermisos().Where(w => w.Clave == "RecExl" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
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
                if (!glb.GetPermisos().Where(w => w.Clave == "RecNew" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar Recibos.", 1);
                    return;
                }                              

                Frm_Recibo frm = new Frm_Recibo();
                frm.FormularioPadre = this;
                frm.SqlConnection = SqlConnection;
               
                if (_encabezado != null && acc == "E")
                {
                    if (_encabezado.EnviadoDos)
                    {
                        ctrls.MensajeInfo("Éste recibo ya fue enviado y <b>NO</b> puede ser modificado.\nDe ser necesario, realizar un recibo de ajuste.", 1);
                        frm.Dispose();
                        return;
                    }
                    else
                    {
                        //PERMISOS PARA PRESTATARIAS
                        if (_encabezado.IDPrestataria > 0 && !glb.GetPermisos().Where(w => w.Clave == "RecPrest" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                        {
                            ctrls.MensajeInfo("No tiene permisos para editar recibos a prestatarias.", 1);
                            return;
                        }
                        //PERMISOS PARA PROFESIONALES
                        if (_encabezado.IDPrestadorCuenta > 0 && !glb.GetPermisos().Where(w => w.Clave == "RecProf" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                        {
                            ctrls.MensajeInfo("No tiene permisos para editar recibos a profesionales.", 1);
                            return;
                        }
                        //PERMISOS PARA TERCEROS
                        if (_encabezado.IDEmpresa > 0 && !glb.GetPermisos().Where(w => w.Clave == "RecTerc" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                        {
                            ctrls.MensajeInfo("No tiene permisos para editar recibos a empresas / terceros.", 1);
                            return;
                        }


                        frm.Recibo = _encabezado.Clone();
                    }                    
                }
                else
                {
                    frm.Recibo = new ReciboEnc();
                }                

                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //ANULACION DEL REGISTRO
        private void AnularRecibo()
        {
            try
            {

                if (!glb.GetPermisos().Where(w => w.Clave == "RecAnula" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar Anulaciones.", 1);
                    return;
                }

                ReciboEnc d = gridView.GetRow(gridView.FocusedRowHandle) as ReciboEnc;

                if (d != null)
                {

                    if (d.EnviadoDos)
                    {
                        ctrls.MensajeInfo("No se puede anular un recibo enviado a tesorería.", 1);
                        return;
                    }

                    gridView.BeginDataUpdate();
                    string palabra = !d.Estado ? "Incluir" : "Excluir";
                    if (ctrls.MensajePregunta($"¿{palabra} el recibo seleccionado?") == DialogResult.Yes)
                    { d.Estado = !d.Estado; }

                    d.SqlConnection = SqlConnection;
                    d.Abm(false);
                    gridView.EndDataUpdate();
                }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
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
                    case "btnPrevisualizacion": PreparaImpresion(0) ; break;
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
                _encabezado = gridView.GetRow(gridView.FocusedRowHandle) as ReciboEnc;
                if (_encabezado != null)
                {                    
                    UsrDetalles.Detalles = _encabezado.Detalles;
                    UsrDetalles.IDRecibo = _encabezado.IDRegistro;
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
                if (e.RowHandle != GridControl.NewItemRowHandle && (e.Column.FieldName == "PagoRecibidoDescripcion" || e.Column.FieldName == "EnviadoDosDescripcion"))
                {
                    if (e.CellValue.ToString() == "SI")
                    { e.RepositoryItem = repositoryTextSI; }
                    else { e.RepositoryItem = repositoryTextNO; }
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

        private void btnAnular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnularRecibo();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            try
            {
                ReciboEnc d = gridView.GetRow(gridView.FocusedRowHandle) as ReciboEnc;
                if (d != null)
                {
                    string palabra = !d.Estado ? "Incluir Recibo" : "Excluir Recibo";
                    btnAnular.Caption = palabra;
                }
            }
            catch (Exception)
            {
                return;
            }            
        }

        private void btnFacturasCanceladas_ElementClick(object sender, NavElementEventArgs e)
        {
            Frm_ResumenFacturas frm = new Frm_ResumenFacturas();
            frm.Recibos.AddRange(Recibo.GetDetalleExtenso(Recibos.Where(w => w.Estado && w.Area == 1).ToList()));
            frm.ShowDialog(this);
        }
    }
    
}