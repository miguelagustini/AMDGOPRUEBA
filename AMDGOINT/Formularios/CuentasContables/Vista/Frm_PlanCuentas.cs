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
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.CuentasContables.Vista
{
    public partial class Frm_PlanCuentas : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();
        private BindingSource BindSrcTree = new BindingSource();

        private MC.Cuentas PlanCuenta = new MC.Cuentas();
        private List<MC.Cuentas> PlanCuentas = new List<MC.Cuentas>();
        
        private Usr_SubCuentas UsrSubCuentas = new Usr_SubCuentas();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private Notificacionesbd notificacionesbd = new Notificacionesbd();
                
        
        private Point LocationSplash = new Point();
        private SqlConnection SqlConnection = new SqlConnection();

        private MC.Cuentas _encabezado;
                
        private string Pathexport { get; set; } = "";
        
        public Frm_PlanCuentas()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            SetControles();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            PlanCuenta.SqlConnection = SqlConnection;            
            Permiso.SqlConnection = SqlConnection;
            
            notificacionesbd.ID_Consulta = 205;            
            notificacionesbd.ListenerChange();
                        
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
                panelDetalles.Controls.Add(UsrSubCuentas);
                UsrSubCuentas.Dock = DockStyle.Fill;                
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
                //btnImpresion.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnActualizar.Enabled = false;
                

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
               // btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnActualizar.Enabled = true;
                btnEditar.Enabled = true;
                timerEscucha.Start();
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                PlanCuentas.Clear(); 
                PlanCuentas.AddRange(PlanCuenta.GetRegistros());
                BindSrcTree.DataSource = PlanCuentas;
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
                treeView.DataSource = BindSrcTree;
                treeView.RootValue = 0;
                treeView.KeyFieldName = "IDRegistro";
                treeView.ParentFieldName = "IDCuentaAgrupadora";
                treeView.ExpandAll();
                
               // btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnActualizar.Enabled = true;

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                timerEscucha.Start();
            }
            catch (Exception)
            {                
               // btnImpresion.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnActualizar.Enabled = true;
                timerEscucha.Start();
            }
            
        }

        //PREPARO IMPRESION
        public void PreparaImpresion(short mode = 0,  bool unicoreg = false, long findbyid = 0)
        {
            try
            {                
                
                if (!Permisos.Where(w => w.Clave == "PlCtaImpr" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de comprobantes", 1);
                    return;
                }


                Xtra_PlanCtas rpt = new Xtra_PlanCtas();
                rpt.DataSource = PlanCuentas;
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.ShowPreviewDialog();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la impresión.\n{e.Message}", 1);
                return;                
            }
        }

        //EXPORTA EXCEL (parametro de grid para acceso public0)
        public void ExportaExcel()
        {
            if (!Permisos.Where(w => w.Clave == "PlCtaExl" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene acceso a la exportacion de comprobantes en lista.", 1);
                return;
            }
            
            ctrls.ExportaraExceltree(treeView);
            
        }

        //EDICION DE REGISTROS
        private void AmbRegistros(string acc = "N")
        {
            try
            {

                //PERMISOS GENERAL
                if (!Permisos.Where(w => w.Clave == "PlCtaEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar PlanCuentas.", 1);
                    return;
                }

                //CUENTA DE INTEGRACION
                if (_encabezado.CuentaTipo == 0 && _encabezado.IDRegistro > 0 && acc != "N")
                {
                    ctrls.MensajeInfo("No se puede editar una cuenta de Integración.", 1);
                    return;
                }

                Frm_PlanContable frm = new Frm_PlanContable();                
                frm.SqlConnection = SqlConnection;
                frm.Cuentas = PlanCuentas;
                frm.Cuenta = acc == "E" ? _encabezado.Clone() : new MC.Cuentas();                
                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
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
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnPrevisualizacion": PreparaImpresion(0) ; break;                    
                    case "btnExcel": ExportaExcel(); break;                    
                }

            }
        }              

        private void btnNuevo_ElementClick(object sender, NavElementEventArgs e)
        {
            AmbRegistros();
        }

        private void btnEditar_ElementClick(object sender, NavElementEventArgs e)
        {
            AmbRegistros("E");
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

        private void TreeView_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "UsoReciboPrestatariaDescripcion" || e.Column.FieldName == "UsoReciboPrestadorDescripcion" || e.Column.FieldName == "UsoReciboEmpleadoDescripcion"
                     || e.Column.FieldName == "UsoReciboTerceroDescripcion"
                     || e.Column.FieldName == "UsoOrdenPagoTerceroDescripcion" || e.Column.FieldName == "UsoOrdenPagoEmpleadoDescripcion" || e.Column.FieldName == "UsoOrdenPagoPrestadorDescripcion")
                {
                    if (e.Node.GetValue(treeView.Columns[e.Column.FieldName]).ToString().ToUpper() == "SI")
                    { e.RepositoryItem = reposTextSi; }
                    else { e.RepositoryItem = reposTextNo; }
                }
                else if (e.Column.FieldName == "EstadoDescripcion")
                {
                    if (e.Node.GetValue(treeView.Columns["EstadoDescripcion"]).ToString().ToUpper() == "ACTIVA")
                    { e.RepositoryItem = reposTextSi; }
                    else { e.RepositoryItem = reposTextNo; }
                }


            }
            catch (Exception)
            {
                return;
            }
        }

        private void TreeView_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {                
                _encabezado = treeView.GetRow(e.Node.Id) as MC.Cuentas;
                if (_encabezado != null)
                {                    
                    UsrSubCuentas.Detalles = _encabezado.SubCuentas;
                    UsrSubCuentas.IDCuenta = _encabezado.IDRegistro;
                }


            }
            catch (Exception)
            {
                return;                
            }
        }
    }

}