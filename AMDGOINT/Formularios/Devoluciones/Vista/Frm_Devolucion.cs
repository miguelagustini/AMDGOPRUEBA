using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace AMDGOINT.Formularios.Devoluciones.Vista
{
    public partial class Frm_Devolucion : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.DevolucionesEnc Devolucion { get; set; } = new MC.DevolucionesEnc();       
        
        private List<Binding> Binding = new List<Binding>();
        public List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        
        private Point LocationSplash = new Point();
        private bool ComprobanteGenerado = true;

        Usr_Detalles UsrDetalles = new Usr_Detalles(true);
        Usr_Eventos UsrEventos = new Usr_Eventos(true);

        public Form FormularioPadre { get; set; } = new Form();

        public Frm_Devolucion()
        {
            InitializeComponent();
                                 
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
                        
            datInicio.Properties.NullDate = DateTime.MinValue;
            datInicio.Properties.NullText = string.Empty;         
            
        }

        #region Metodos Manuales
        
        private void IniciaConexiones()
        {
            try
            {
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Devolucion.SqlConnection = SqlConnection;
                UsrDetalles.SqlConnection = SqlConnection;
                UsrEventos.SqlConnection = SqlConnection;
            }
            catch (Exception)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al inciar las conexiones.", 1);
                return;
            }
        }

        private void HabilitaSelectores()
        {
            cmbPrestador.Enabled = Devolucion.IDRegistro <= 0;
            txtPeriodo.Enabled = Devolucion.IDRegistro <= 0;
            pnlEncabezado.CustomHeaderButtons[0].Properties.Enabled = Devolucion.Estado <= 0;
            
        }

        private void CargaCombos(short cmb = 0)
        {
            try
            {
               
                if (cmb == 0 || cmb == 1) //PRESTADOR
                {
                   
                    string c = "SELECT PR.ID_Registro AS IDPrestador, PR.Nombre as Prestador" +
                               " FROM PROFESIONALES PR" +                               
                               " WHERE PR.Visible = 1 AND PR.ID_Referencia <= 0";

                    cmbPrestador.Properties.DataSource = func.getColecciondatos(c, SqlConnection);
                }                              
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void SetBindings()
        {
            try
            {                
                datInicio.DataBindings.Add("EditValue", Devolucion, nameof(Devolucion.FechaInicio));                
                cmbPrestador.DataBindings.Add("EditValue", Devolucion, nameof(Devolucion.PrestadorID));
                txtObservacion.DataBindings.Add("EditValue", Devolucion, nameof(Devolucion.Observacion));
                txtPeriodo.DataBindings.Add("EditValue", Devolucion, nameof(Devolucion.Periodo));
                lblEstado.Text = Devolucion.EstadoDescripcion;

                UsrDetalles.Detalles = Devolucion.Detalles;
                UsrDetalles.IDDevolucion = Devolucion.IDRegistro;

                UsrEventos.Eventos = Devolucion.Eventos;
                UsrEventos.IDDevolucion = Devolucion.IDRegistro;

                HabilitaSelectores();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }

        private void SetControles()
        {
            try
            {
                pnlDetalles.Controls.Add(UsrDetalles);
                UsrDetalles.Dock = DockStyle.Fill;

                pnlEventos.Controls.Add(UsrEventos);
                UsrEventos.Dock = DockStyle.Fill;
            }
            catch (Exception)
            {

            }
        }

        //INICIA GENERACION Devolucion
        private void IEmiteComprobante()
        {
            try
            {
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }                               
                

                if (bgwEmiteFactura.IsBusy) { return; }
                bgwEmiteFactura.RunWorkerAsync();
            }
            catch (Exception)
            {
               
                
            }
        }

        //GENERA Devolucion
        private void EmitirComprobante()
        {
            try
            {
                if (!ValidacionPreviaEmision())
                {
                    ComprobanteGenerado = false;
                    return;
                }
                else
                {
                    if (ctrl.MensajePregunta("¿Está seguro de generar éste comprobante?") != DialogResult.Yes) { return; }
                    GeneraComprobante();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir la factura.\n{e.Message}", 1);
                return;
            }
        }

        //FIN Devolucion
        private void FEmiteComprobante()
        {
            try
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                
                if (ComprobanteGenerado)
                {
                    //if ((bool)tglImpresion.EditValue) { ImpresionComprobante(); }
                    Close();
                }
                else
                {
                    ComprobanteGenerado = true;
                }
            }
            catch (Exception)
            {
                Close();
            }            
            
        }
             
        //VALIDO ANTES DE EMITIR EL COMPROBANTE
        private bool ValidacionPreviaEmision()
        {
            try
            {                
                if (Devolucion.FechaInicio > DateTime.Now)
                {
                    ctrl.MensajeInfo("No se puede generar un Devolucion con fecha mayor a la actual.", 1);
                    datInicio.Focus();
                    return false;
                }

                //PRESTADOR
                if (Devolucion.PrestadorID <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un Devolucion sin una prestataria.", 1);
                    cmbPrestador.Focus();
                    return false;
                }

                //PERIODO
                if (string.IsNullOrEmpty(Devolucion.Periodo))
                {
                    ctrl.MensajeInfo("No se puede generar un Devolucion sin un periodo.", 1);
                    txtPeriodo.Focus();
                    return false;
                }

                //SIN DETALLES
                if (Devolucion.Detalles.Count() <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un Devolucion sin detalles.", 1);                    
                    return false;
                }


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
               
        //GENERA COMPROBANTE
        private void GeneraComprobante()
        {
            try
            {
                Dictionary<short, string> retorno = new Dictionary<short, string>();

                retorno = Devolucion.Abm();

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); ComprobanteGenerado = false; }
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el Devolucion.\n{e.Message}", 1);
                ComprobanteGenerado = false;
                return;
            }
        }
   
     
        #endregion

        private void Frm_ComprobanteElectronico_Shown(object sender, EventArgs e)
        {
            SetControles();
            IniciaConexiones();
            CargaCombos();            
            SetBindings();            
        }

        private void Frm_ComprobanteElectronico_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnb.Desconectar();
        }

        private void Frm_ComprobanteElectronico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Parent is XtraTabPage)
            {
                XtraTabPage c = Parent as XtraTabPage;
                XtraTabControl x = c.Parent as XtraTabControl;
                x.TabPages.Remove(c);
            }
        }        
        
        private void reposTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }                                   
        
        private void bgwEmiteFactura_DoWork(object sender, DoWorkEventArgs e)
        {
            EmitirComprobante();
        }

        private void bgwEmiteFactura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FEmiteComprobante();
        }
                
        private void lblEstado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LabelControl l = sender as LabelControl;

                if (l.Text == "En Proceso") { l.Appearance.ForeColor = Color.Goldenrod; }
                else if (l.Text == "Finalizado") { l.Appearance.ForeColor = Color.OliveDrab; }
                else { l.Appearance.ForeColor = Color.Black; }
            }
            catch (Exception)
            {
                return;
            }
        }
                
        private void cmbPrestataria_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((int)e.OldValue != 0 && Devolucion.Detalles.Count() > 0) {

                if (ctrl.MensajePregunta("Los detalles estan cargados con los registros de otra obra social.\nSi continúa, estos se borrarán.\n¿Está seguro de Continuar?")
                    != DialogResult.Yes) { e.Cancel = true; }                
            }            

        }

        private void cmbPrestataria_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                UsrDetalles.IDPrestador = (int)cmbPrestador.EditValue;
            }
            catch (Exception)
            {
                return;
            }
        }
        
        private void pnlEncabezado_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            IEmiteComprobante();
        }

    }
}