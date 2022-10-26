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

namespace AMDGOINT.Formularios.Reclamos.Vista.DebitosCreditosImportacion
{
    public partial class Frm_ImportaDebitosCreditos : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();        
        private Funciones func = new Funciones();
        
        private SqlConnection SqlConnection = new SqlConnection();

        private MC.ImportaDebitosCreditos Importacion = new MC.ImportaDebitosCreditos();

        private List<MC.ImportacionDebitosEstructura> Registros = new List<MC.ImportacionDebitosEstructura>();
        private string PathImportacion = "";
                        
        private Point LocationSplash = new Point();
        
        
        public Frm_ImportaDebitosCreditos()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
                        
        }

        #region METODOS MANUALES
                
        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Importacion.SqlConnection = SqlConnection;            
                        
            ctrls.PreferencesGrid(this, gridViewimpo, "R");
            ctrls.PreferencesGrid(this, dockManager, "R");

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
                        
        }
        
        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {
                PathImportacion = "";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    PathImportacion = folderDialog.SelectedPath.ToString();
                }
                else { return; }

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                HabilitaControles(false);
                gridViewimpo.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { gridViewimpo.EndDataUpdate(); return; }
                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                HabilitaControles(true);
                gridViewimpo.EndDataUpdate();                
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Registros.Clear();
                var d =  Importacion.ImportaExcels(PathImportacion);

                if (d.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in d.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrls.MensajeInfo($"Hubo inconvenientes en el insert.\n{mensajes}", 1); }
                }



                Registros.AddRange(Importacion.ItemsImportados);                
                
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
                gridControl.DataSource = Registros;
                gridViewimpo.EndDataUpdate();
                HabilitaControles(true);
                                
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                
            }
            catch (Exception)
            {
                gridViewimpo.EndDataUpdate();
                HabilitaControles(true);                
            }
            
        }

        //INICIO INSERT REGISTROS
        public void IInsertRegistros()
        {
            try
            {                
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                HabilitaControles(false);
                gridViewimpo.BeginDataUpdate();

                if (bgwInsertaRegistros.IsBusy) { gridViewimpo.EndDataUpdate(); return; }
                bgwInsertaRegistros.RunWorkerAsync();
            }
            catch (Exception)
            {
                HabilitaControles(true);
                gridViewimpo.EndDataUpdate();
            }

        }

        //INSERTO REGISTROS
        private void InsertRegistros()
        {
            try
            {                                
                var d = Importacion.Abm(Registros);


                if (d.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in d.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrls.MensajeInfo($"Hubo inconvenientes en el insert.\n{mensajes}", 1);  }
                }


                Registros.Clear();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al obtener los registros.\n{e.Message}", 1);
                return;
            }
        }

        //FIN INSERT REGISTROS
        private void FInsertRegistros()
        {

            try
            {
                gridControl.DataSource = Registros;
                gridViewimpo.EndDataUpdate();
                HabilitaControles(true);

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }

            }
            catch (Exception)
            {
                gridViewimpo.EndDataUpdate();
                HabilitaControles(true);
            }

        }

        //ESTADO DE CONTROLES
        private void HabilitaControles(bool _estado)
        {
            btnImportar.Enabled = _estado;
            btnInsertarRegistros.Enabled = _estado;
        }
        
        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {            
            ConexionBD.Desconectar();
            SqlConnection.Dispose();
            ctrls.PreferencesGrid(this, gridViewimpo, "S");
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

        private void btnImportar_ElementClick(object sender, NavElementEventArgs e)
        {
            IBusqRegistros();
        }

        private void btnInsertarRegistros_ElementClick(object sender, NavElementEventArgs e)
        {
            IInsertRegistros();
        }

        private void bgwInsertaRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            InsertRegistros();
        }

        private void bgwInsertaRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FInsertRegistros();
        }
    }
    
}