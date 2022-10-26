using AMDGOINT.Clases;
using AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista;
using AMDGOINT.Formularios.Aranceles;
using AMDGOINT.Formularios.Configuracion.Usuarios;
using AMDGOINT.Formularios.Facturas.Ambulatorio;
using AMDGOINT.Formularios.Facturas.Prestatarias;
using AMDGOINT.Formularios.Prestatarias;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraTab;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Formularios.Facturas.Ambulatorio.Vista;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using AMDGOINT.Formularios.Recibos.Vista;

namespace AMDGOINT.Formularios.Principal
{
    public partial class Frm_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {        
        private Controles ctrls = new Controles();
        private Globales globales = new Globales();
        private Funciones func = new Funciones();
        private EmailsAutomaticos autoemail = new EmailsAutomaticos();
        
        IDictionary<Process, string> ProcesosExternos = new Dictionary<Process, string>();
        private int Pindex { get; set; } = 0;
        //private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        //private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        public Frm_Main()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
        }

        #region METODOS MANUALES
       
        //PARAMETROS DE INICIO DEL MAIN
        private void ParametrosInicio()
        {
            ProcesosExternos.Clear();

            UserLookAndFeel.Default.SetSkinStyle("The Bezier", "Office White");
            
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;
                       
            TopMost = false;
            globales.SetMaintab(tabMain);
            globales.GetConexion();

            accMenu.OptionsMinimizing.State = AccordionControlState.Minimized;

           
        }

        //VALIDA USUARIO
        private void ValidaLogin()
        {
            try
            {

                Enabled = false;
                                
                if (globales.GetIdUsuariolog() <= 0)
                {
                    Frm_Login log = new Frm_Login();
                    DialogResult result = log.ShowDialog(this);
                    if (result == DialogResult.Cancel) { Application.Exit(); }
                    else
                    {
                        Usuarioinfo.Caption = "Sin Información";
                        ValidaLogin();
                    }

                }
                else
                {
                    Enabled = true;
                    Usuarioinfo.Caption = globales.GetNomUsuariolog();
                    ConcedeAcceso();
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar el usuario.\n" + e.Message, 0);
                return;
            }
        }

        //CONTROLA EL ACCESO A LOS MENUES SEGUN SU PERMISO
        private void ConcedeAcceso()
        {
            try
            {
                //CARGA PERMISOS
                //Permisos.Clear();
                //Permisos.AddRange(Permiso.GetPermisoUsuario());

                List<Configuracion.Permisos.MC.Permiso> pm = new List<Configuracion.Permisos.MC.Permiso>();
                pm.AddRange(globales.GetPermisos(true));

                //Personas
                btnProfesionaleslst.Visible = pm.Where(w => w.Clave == "ProfAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First(); 

                //Prestatarias
                btnPrestatariasmain.Visible = pm.Where(w => w.Clave == "PrestAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnAgrupadores.Visible = pm.Where(w => w.Clave == "PrestAgrAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnFactpresemis.Visible = pm.Where(w => w.Clave == "PrestcpAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnFactpresEmit.Visible = pm.Where(w => w.Clave == "PrestcpeAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnParamsFcc.Visible = pm.Where(w => w.Clave == "PrestConf" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnAutoemailprest.Visible = pm.Where(w => w.Clave == "AutoEmail" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnTasaInteres.Visible = pm.Where(w => w.Clave == "PrestConf" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnLiquidacion.Visible = pm.Where(w => w.Clave == "GenLiqui" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnResumenfacturacion.Visible = pm.Where(w => w.Clave == "RmnPraFact" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                                                                
                //PROFESIONALES
                btnProfesionaleslst.Visible = pm.Where(w => w.Clave == "ProfAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnFacturaslst.Visible = pm.Where(w => w.Clave == "AmfactAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnFacturaslstinternacion.Visible = pm.Where(w => w.Clave == "IntFactPend" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnFactemitidas.Visible = pm.Where(w => w.Clave == "AmfactemAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnAutoemailprof.Visible = false;

                //AUDITORIA
                btnAnestesiaaudit.Visible = pm.Where(w => w.Clave == "AnesAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnMedicamentos.Visible = pm.Where(w => w.Clave == "MedAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                //ARANCELES
                btnPracticasamdgo.Visible = pm.Where(w => w.Clave == "PracAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnAranceles.Visible = pm.Where(w => w.Clave == "AranAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnDiscusion.Visible = pm.Where(w => w.Clave == "NegAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnDiscusionanalisis.Visible = pm.Where(w => w.Clave == "DiscAnls" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnDiscusionescerradas.Visible = pm.Where(w => w.Clave == "AranPublic" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnCalculadoraValores.Visible = pm.Where(w => w.Clave == "CalcValores" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                //RECLAMOS
                btnReclamos.Visible = pm.Where(w => w.Clave == "ReclAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnImportacionDebitosCreditos.Visible = pm.Where(w => w.Clave == "ImpoDebiCredi" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                //TESORERIA                
                bntRetirosgral.Visible = pm.Where(w => w.Clave == "RetiAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnEmpresas.Visible = pm.Where(w => w.Clave == "EmprAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnOrdenesPago.Visible = pm.Where(w => w.Clave == "OrdAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnCajaMovimientos.Visible = pm.Where(w => w.Clave == "CajaAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnContabilidad.Visible = pm.Where(w => w.Clave == "CntAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnConfiguracionAsientos.Visible = pm.Where(w => w.Clave == "CntConf" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                //recibos
                btnRecibos.Visible = pm.Where(w => w.Clave == "RecAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                //contabilidad
                btnPlanCuentas.Visible = pm.Where(w => w.Clave == "PlCtaAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                //saldos negativos
                btnSaldosNegativos.Visible = pm.Where(w => w.Clave == "AccSlds" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                //cuentas conjuntas
                btnCuentasConjuntas.Visible = pm.Where(w => w.Clave == "CtasCjtAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                
                //EMPLEADOS
                btnEmpleados.Visible = pm.Where(w => w.Clave == "EmplAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                //MESA DE ENTRADA
                btnDocumentalgest.Visible = pm.Where(w => w.Clave == "DocuAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();
                btnDevoluciones.Visible = pm.Where(w => w.Clave == "DevoAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                //CONFIGURACION
                btnUsupermisos.Visible = pm.Where(w => w.Clave == "ConfAcc" && w.UsuarioID == globales.GetIdUsuariolog()).Select(s => s.Acceso).First();

                Setgruposvisible();
                                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al asignar la lista de permisos.\n{e.Message}", 1);
                return;
            }                   
        }

        private void Setgruposvisible()
        {
            foreach (AccordionControlElement ctrl in accMenu.GetElements().Where(s => s.Style == ElementStyle.Group))
            {
                bool visible = false;

                if (ctrl.Elements.Where(r => r.Style == ElementStyle.Item &&
                        r.OwnerElement == ctrl && r.Visible == true).Count() > 0)
                { visible = true; }

                ctrl.Visible = visible;
            }
        }

        //VALIDACIONES ANTES DE CIERRE
        private bool ValidaCierre(object formulario = null, Type tipo = null)
        {
            try
            {
                Form formufound;
                bool retorno = true;

                if (formulario != null) { retorno = ValidaCierreForms(formulario as Form); }
                else
                {
                    //RECORRO TODAS LAS PESTAÑAS EN BUSCA DEL FORMULARIO
                    foreach (XtraTabPage hoja in tabMain.TabPages)
                    {
                        //GUARDO LO ENCONTRADO
                        formufound = hoja.Controls.OfType<Form>().FirstOrDefault();

                        //COMPRUEBO QUE NO SEA NULLO Y SI COINCIDE CON EL QUE TRATO DE ABRIR
                        if (formufound != null) { retorno = ValidaCierreForms(formufound); }
                    }
                }
                
                return retorno;
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Ocurrio un error al validar el cierre del formulario.", 0);
                return true;
            }
        }

        private bool ValidaCierreForms(Form formufound)
        {

            if (formufound is Frm_PFacturasMain)
            {
                Frm_PFacturasMain f = formufound as Frm_PFacturasMain;
                return f.CanClose;
            }
            else if (formufound is Frm_FacturasMain)
            {
                Frm_FacturasMain f = formufound as Frm_FacturasMain;
                return f.CanClose;
            }
            else if (formufound is Frm_Pendientes)
            {
                Frm_Pendientes f = formufound as Frm_Pendientes;
                return f.CanClose;
            }

            return true;
        }

        //TERMINO TODOS LOS PROCESOS EJECUTADOS EXTERNOS
        private void FinalizaProcesos(string tabname)
        {
            try
            {
                if (string.IsNullOrEmpty(tabname))
                {
                    ProcesosExternos.Select(s => s.Key).ToList().ForEach(f => f.Kill());
                }
                else { ProcesosExternos.Where(w => w.Value == tabname).Select(s => s.Key).ToList().ForEach(f => f.Kill()); }
                
            }
            catch (Exception)
            {

            }
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            ValidaLogin();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ValidaCierre())
            {
                //ctrls.MensajeInfo("Aguarde a que todas las tareas finalicen.", 1);
                e.Cancel = true;
                return;
            }

            FinalizaProcesos("");
        }

        #endregion

        private void tabMain_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                Form formulario = new Form();
                Int32 index = tabMain.SelectedTabPageIndex;

                //ME POSICIONO EN LA PESTAÑA SELECCIONADA
                XtraTabPage page = tabMain.SelectedTabPage;

                //DETERMINO QUE FORMULARIO ESTOY USANDO
                formulario = page.Controls.OfType<Form>().FirstOrDefault();

                //SI OBTENGO UN FORMULARIO,LO CIERRO PARA QUE LAS OPERACIONES DEL EVENTO (CLOSE) SE EJECUTEN CORRECTAMENTE
                if (formulario != null)
                {

                    if (!ValidaCierre(formulario))
                    {
                        //ctrls.MensajeInfo("Aguarde a que se finalicen todas las tareas.", 1);
                        tabMain.SelectedTabPageIndex = index;
                        return;
                    }

                    formulario.Close();
                }

                FinalizaProcesos(page.Name);

                //DESTRUYO LA PESTAÑA CONTENEDORA
                tabMain.SelectedTabPageIndex = Pindex;
                tabMain.TabPages.Remove(page);
            }
            catch (Exception n)
            {
                ctrls.MensajeInfo($"Hubo inconvenientes al cerrar los procesos.\n{n.Message}", 1);
                return;
            }            
        }

        private void tabMain_Deselecting(object sender, TabPageCancelEventArgs e)
        {
            try
            {
                Pindex = e.PageIndex;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void tabMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            tabMain.SelectedTabPageIndex = Pindex;
        }

        private void Usuarioinfo_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Login log = new Frm_Login();            
            if (log.ShowDialog() == DialogResult.Cancel && globales.GetIdUsuariolog() <= 0)
            {
                Application.Exit();
            }
            else
            {
                Usuarioinfo.Caption = "Sin Información";
                ValidaLogin();
            }
        }

        /// ****************************************************************************************************
        /// *************************************** USUARIOS ************************************************ 
        /// ****************************************************************************************************
        #region USUARIOS
        private void btnUsupermisos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Frm_UsuariosMain(), tabMain);
        }

        #endregion

        /// ****************************************************************************************************
        /// *************************************** PRESTADORES ************************************************ 
        /// ****************************************************************************************************
        #region PRESTADORES

        private void btnProfesionaleslst_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Profesionales.Vista.Frm_ProfesionalesMain(), tabMain);
        }

        private void btnFacturaslst_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Frm_Pendientes(), tabMain);
        }

        private void btnFacturaslstinternacion_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Facturas.Internacion.Vista.Frm_Pendientes(), tabMain);
        }

        private void btnFactemitidas_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();            
            ctrls.AgregaFormulario(new Frm_Facturas(), tabMain);
        }

        #endregion

        /// ****************************************************************************************************
        /// *************************************** PRESTATARIAS *********************************************** 
        /// ****************************************************************************************************
        #region PRESTATARIAS
        private void btnPrestatariasmain_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            //ctrls.AgregaFormulario(new Frm_PrestatariasMain(), tabMain);            
            ctrls.AgregaFormulario(new Prestatarias.Vista.Frm_Prestatarias(), tabMain);
        }

        private void btnFactpresemis_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Facturas.Prestatarias.Vista.Frm_Pendientes(), tabMain);
        }

        private void btnFactpresEmit_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Facturas.Prestatarias.Vista.Frm_Comprobantes(), tabMain);
        }

        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            Frm_GeneradorLiquidacion frm = new Frm_GeneradorLiquidacion();
            frm.ShowDialog(this);
        }

        private void btnResumenfacturacion_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Facturas.ResumenInformesGral.Vista.Frm_Facturado(), tabMain);
        }

        private void btnParamsFcc_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            Frm_ParamPresFact frm = new Frm_ParamPresFact();
            frm.Es_Popup = true;
            frm.ShowDialog(this);
        }

        private void btnTasaInteres_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            Facturas.Prestatarias.Vista.Frm_TasaInteres frm = new Facturas.Prestatarias.Vista.Frm_TasaInteres();
            frm.ShowDialog(this);
        }

        #endregion

        /// ****************************************************************************************************
        /// ******************************   TESORERIA  ********************************************************
        /// ****************************************************************************************************
        #region TESORERIA
        private void btnCajaMovimientos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Caja.Vista.Frm_CajaMovimientos(), tabMain);
        }

        private void btnRecibos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Frm_Recibos(), tabMain);
        }

        private void btnCuentasConjuntas_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Profesionales.CuentasConjuntas.Frm_CuentasConjuntas(), tabMain);
        }

        private void btnOrdenesPago_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new OrdenesPago.Vista.Frm_OrdenesPago(), tabMain);
        }

        private void btnPlanCuentas_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new CuentasContables.Vista.Frm_PlanCuentas(), tabMain);
        }

        private void bntRetirosgral_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Retiros.Vista.Frm_Retiros(), tabMain);
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Empresas.Vista.Frm_Empresas(), tabMain);
        }

        private void btnSaldosNegativos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Profesionales.SaldosNegativos.Frm_SaldosNegativos(), tabMain);
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new AsientosContables.Vista.Frm_AsientosContables(), tabMain);
        }

        private void btnConfiguracionAsientos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new AsientosContables.Vista.Frm_Configuraciones(), tabMain);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Empleados.Vista.Frm_Empleados(), tabMain);
        }

        #endregion

        /// ****************************************************************************************************
        /// ******************************** ARANCELES *********************************************************
        /// ****************************************************************************************************
        #region ARANCELES

        private void btnPracticasamdgo_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Practicas.Vista.Frm_PracticasMain(), tabMain);

        }

        private void btnAranceles_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            //ctrls.AgregaFormulario(new Frm_ArancelesMain(), tabMain);
            ctrls.AgregaFormulario(new Aranceles.Vista.Frm_ArancelesMain(), tabMain);
        }
              
        private void btnDiscusion_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Frm_DiscusionesMain(), tabMain);
            //ctrls.AgregaFormulario(new Negociacion.Vista.Frm_Negociaciones(), tabMain);
        }

        private void btnDiscusionanalisis_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Negociacion.Vista.Frm_Analisis(), tabMain);
        }

        private void btnAgrupadores_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            Frm_PrAgrupador frm = new Frm_PrAgrupador();
            frm.Es_Popup = true;
            frm.ShowDialog(this);
        }

        private void btnDiscusionescerradas_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Frm_DiscusionesPublic(), tabMain);
        }

        private void btnCalculadoraValores_Click(object sender, EventArgs e)
        {
            Negociacion.Vista.Frm_Valorizador frm = new Negociacion.Vista.Frm_Valorizador();
            frm.Show(this);
        }

        #endregion

        /// ****************************************************************************************************
        /// ******************************** RECLAMOS **********************************************************
        /// ****************************************************************************************************
        #region RECLAMOS
        private void btnReclamos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Reclamos.Vista.Frm_Reclamos(), tabMain);
        }

        private void btnImportacionDebitosCreditos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Reclamos.Vista.DebitosCreditosImportacion.Frm_ImportaDebitosCreditos(), tabMain);
        }
        #endregion


        /// ****************************************************************************************************
        /// ******************************** MESA DE ENTRADA ***************************************************
        /// ****************************************************************************************************
        #region MESA DE ENTRADA
        private void btnDocumentalgest_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new MesaEntrada.Vista.Frm_DocumentalAdmin(), tabMain);
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Devoluciones.Vista.Frm_Devoluciones(), tabMain);
        }

        #endregion

        /// ****************************************************************************************************
        /// ******************************** AUDITORIA *********************************************************
        /// ****************************************************************************************************
        #region AUDITORIAS
        private void btnAnestesiaaudit_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Frm_AnestesiaAuditMain(), tabMain);
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            accMenu.ClosePopupForm();
            ctrls.AgregaFormulario(new Medicamentos.Vista.Frm_Medicamentos(), tabMain);
        }
        #endregion

        /// ****************************************************************************************************
        /// ******************************** EMAILS AUTOMATICOS ************************************************
        /// ****************************************************************************************************
        #region EMAILS AUTOMATICOS

        //EMAIL AUTOMATICO PROFESIONALES
        private void btnAutoemailprof_Click(object sender, EventArgs e)
        {
            autoemail.Sendemails(1);
        }

        //EMAIL AUTOMATICO PRESTATARIAS
        private void btnAutoemailprest_Click(object sender, EventArgs e)
        {
            if (ctrls.MensajePregunta("A continuación se notificará a todas las prestatarias en lista y al personal de Amdgo\n" +
                    "la disponibilidad de la facturación en la web.\n" +
                    "¿Continuar?") == DialogResult.Yes)
            {
                btnAutoemailprest.Enabled = false;
                ScreenManager.ShowWaitForm();
                bgwEmails.RunWorkerAsync();
            }
        }

        private void bgwEmails_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            autoemail.Sendemails(0);
        }

        private void bgwEmails_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnAutoemailprest.Enabled = true;
            ScreenManager.CloseWaitForm();
        }

        #endregion

        private void btnCreditos_Click(object sender, EventArgs e)
        {

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(Application.StartupPath + @"\SIST_AMG-PAGO\AMBULATORIO.exe", "31151182");               
                Process p = Process.Start(psi);                
                p.WaitForInputIdle(); // Allow the process to open it's window

                //CREO UNA NUEVA PESTÑA PARA EL FORMULARIO
                XtraTabPage myTabPage = new XtraTabPage();
                myTabPage.Padding = new Padding(0, 0, 0, 0);
                myTabPage.Margin = new Padding(0, 0, 0, 0);
                //TITULO DE LA PESTAÑA
                myTabPage.Text = "Creditos";
                myTabPage.Name = ProcesosExternos.Count().ToString();

                ProcesosExternos.Add(p, myTabPage.Name);

                //AGREGO LA PESTAÑA AL CONTROL PRINCIPAL
                tabMain.TabPages.Add(myTabPage);                
                SetParent(p.MainWindowHandle, myTabPage.Handle);

                int left = 0;
                int top = 0;
                int width = myTabPage.Width;
                int height = myTabPage.Height;
                                                
                SetWindowPos(p.MainWindowHandle, HWND_TOP, left, top, width, height, 0);

                //int GWL_STYLE = -16;
                //int GWL_EXSTYLE = -20;
                                
               // uint styles = GetWindowLong(p.MainWindowHandle, GWL_STYLE);
                //System.Windows.WindowStyle exStyles = GetWindowLong(p.MainWindowHandle, GWL_EXSTYLE);

                //System.Windows.WindowStyle newStyles = System.Windows.WindowStyle.None;

                //SetWindowLong(p.MainWindowHandle, GWL_STYLE, (uint)newStyles);

               
            }
            catch (Exception n)
            {
                ctrls.MensajeInfo($"No se pudo ejecutar el módulo.\n{n.Message}", 1);
                return;
            }
        }
              
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        // Inside the class

        // HWND Constants
        public long WindowStyles = 0;
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);                
        private const int GWL_STYLE = -16;              //hex constant for style changing
        private const int GWL_EXSTYLE = -20;              //hex constant for style changing
        private const int WS_BORDER = 0x00800000;       //window with border
        private const int WS_CAPTION = 0x00C00000;      //window with a title bar
        private const int WS_SYSMENU = 0x00080000;      //window with no borders etc.
        private const int WS_MINIMIZEBOX = 0x00020000;  //window with minimizebox

        // P/Invoke
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
           int Y, int cx, int cy, uint uFlags);        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

    }
}
