using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using System.Drawing;
using DevExpress.XtraSplashScreen;

namespace AMDGOINT.Formularios.Aranceles.Vista
{
    public partial class Frm_Arancel : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();

        private List<ArancelesHistorico> aranhisto = new List<ArancelesHistorico>();
        private List<EstructuraExcel> excelimport = new List<EstructuraExcel>();

        private Usr_Encabezado Usrencabezado = new Usr_Encabezado();
        private Usr_Detalles Usrdetalles = new Usr_Detalles();

        public MC.Arancel Arancel { get; set; } = new MC.Arancel();

        private Point LocationSplash = new Point();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private bool _canedit = false;

        public Frm_Arancel()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosed += new FormClosedEventHandler(Formulario_Closed);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
        }

        #region METODOS MANUALES

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {              
                Close();              
            }
            catch (Exception)
            {
            }
        }
                
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Usrdetalles.SqlConnection = SqlConnection;
            Arancel.SqlConnection = SqlConnection;
            
            ScreenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScreenManager.SplashFormLocation = LocationSplash;

            Setcontroles();
            SetBindigs();

            ctrls.PreferencesGrid(this, dockManager, "R");
            _canedit = func.DevuelvePermiso("AraEdit");
        }

        private void Setcontroles()
        {
            try
            {
                Dockdatosgral.Controls.Add(Usrencabezado);
                Usrencabezado.Dock = DockStyle.Fill;
                dockPracticas.Controls.Add(Usrdetalles);
                Usrdetalles.Dock = DockStyle.Fill;
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al asignar los controles.\n{e.Message}", 1);
                return;
            }
        }

        private void SetBindigs()
        {
            try
            {
                Usrencabezado.Arancel = Arancel;
                Usrdetalles.Detalles = Arancel.Detalles;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }

        //INICIO GUARDADO REGISTROS
        private void IGuardaRegistros()
        {
            if (Arancel.Detalles.Count <= 0)
            {
                ctrls.MensajeInfo("No hay detalles para guardar.", 1);
                return;
            }

            if (Arancel.Detalles.Where(w => w.Valor == 0).Count() == Arancel.Detalles.Count)
            {
                ctrls.MensajeInfo("No se puede guardar con solo valores cero.", 1);
                return;
            }


            if (Arancel.Fecha == DateTime.MinValue)
            {
                ctrls.MensajeInfo("Debe seleccionar una fecha para continuar", 1);
                return;
            }

            if (Arancel.Estado)
            {
                ctrls.MensajeInfo("No se puede modificar una valorizacion arancelaria cerrada", 1);
                return;
            }

            if (!ScreenManager.IsSplashFormVisible) { ScreenManager.ShowWaitForm(); }
            if (!bgwGuardado.IsBusy) { bgwGuardado.RunWorkerAsync(); }
        }

        //FIN BUSQUEDA REGISTROS
        private void FGuardaRegistros()
        {           

            if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
            Continuacion();
        }

        private void GuardaDatos()
        {
            try
            {
                                
                Dictionary<short, string> retorno = new Dictionary<short, string>();

                retorno = Arancel.Abm();

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
                }                                
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
                                 
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Formulario_Closed(object sender, FormClosedEventArgs e)
        {
            cnb.Desconectar();
            SqlConnection.Dispose();

            if (Parent is XtraTabPage)
            {
                XtraTabPage c = this.Parent as XtraTabPage;
                XtraTabControl x = c.Parent as XtraTabControl;
                x.TabPages.Remove(c);
            }            
        }

        private void Frm_Arancel_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrls.PreferencesGrid(this, dockManager, "S");
        }
 
        private void Dockdatosgral_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if ((short)e.Button.Properties.Tag == 0)
            {
                if (!_canedit)
                {
                    ctrls.MensajeInfo("No tiene permisos de edición", 1);
                    return;
                }

                IGuardaRegistros();
            }
        }

        private void bgwGuardado_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            GuardaDatos();
        }

        private void bgwGuardado_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FGuardaRegistros();
        }
    }
        
}