using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraTab;

namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    public partial class Frm_Prestataria : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();
                
        private Usr_Planes UsrPlanes = new Usr_Planes();
        private Usr_Contactos UsrContactos = new Usr_Contactos();        
        public SqlConnection SqlConnection = new SqlConnection();

        public MC.Prestataria Prestataria { get; set; } = new MC.Prestataria();
                

        public Frm_Prestataria()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES
             
        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Prestataria.SqlConnection = SqlConnection;
            UsrContactos.SqlConnection = SqlConnection;
            UsrPlanes.SqlConnection = SqlConnection;
            
            //TABS
            UsrPlanes.Editable = true;
            
            UsrContactos.Editable = true;

            tabDetalles.TabPages[0].Controls.Add(UsrPlanes);
            tabDetalles.TabPages[1].Controls.Add(UsrContactos);

            UsrPlanes.Dock = DockStyle.Fill;
            UsrContactos.Dock = DockStyle.Fill;            

            tabDetalles.SelectedTabPageIndex = 0;

            CargaCombos(0);
            SetBindings();
            
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtCuit.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.Cuit));
                txtNombre.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.RazonSocial));
                txtDomiciliof.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.DomicilioFiscal));
                txtAbrevia.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.Abreviatura));
                tglComprobpaci.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.ComprobantePaciente));
                tglComprobX.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.AceptaComprobanteX));
                tglmipyme.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.MiPyme));
                spnVencimientos.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.DiasVencimiento));
                cmbCondIva.DataBindings.Add("EditValue", Prestataria, nameof(Prestataria.IvaID));

                
                UsrPlanes.Planes = Prestataria.Planes;
                UsrContactos.AreasTrabajo = Prestataria.AreaTrabajo;                

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;
            }
        }
                      
        //CARGA DE COMBOS
        private void CargaCombos(short cmb)
        {
            try
            {
                string consulta = "";
                
                //CONDICIONES DE IVA 
                if (cmb == 0 || cmb == 2)
                {
                    consulta = "SELECT ID_Registro, Descripcion, Abreviatura" +
                        " FROM CONDSIVA" +
                        " WHERE Abreviatura <> 'CF'" +
                        " ORDER BY Descripcion ASC";

                    cmbCondIva.Properties.DataSource = func.getColecciondatos(consulta);
                }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }

        //VALIDO EXISTENCIA DE CODIGO DE OBRA
        private bool ExisteCuit(string cod)
        {
            try
            {
                bool retorno = false;

                string consulta = "SELECT * FROM PRESTATARIAS WHERE Cuit = " + cod.Trim() + " AND ID_Registro <> " + Prestataria.IDRegistro;

                if (func.getColecciondatos(consulta).Rows.Count > 0) { retorno = true; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar el registro.\n" + e.Message, 0);
                return true;
            }
        }

        //OBTENGO DATOS DE AFIP
        private void GetDatosAfip()
        {
            try
            {
                string cuit = txtCuit.Text.Trim();
                CultureInfo ci = new CultureInfo("es-ES");
                ci = new CultureInfo("es-ES");
                TextInfo textInfo = ci.TextInfo;                

                if (cuit != "")
                {
                    this.Enabled = false;

                    DatosAfip d = func.GetInfoAfipunico(Convert.ToInt64(cuit));

                    if (d != null)
                    {                        
                        txtNombre.Text = textInfo.ToTitleCase(d.RazonSocial.Trim().ToLower());
                        txtDomiciliof.Text = textInfo.ToTitleCase(d.DomicilioFiscal.Trim().ToLower());
                        cmbCondIva.EditValue = Convert.ToInt16(d.IDIva);
                    }
                }

                this.Enabled = true;
            }
            catch (Exception)
            {
                this.Enabled = true;
                return;                
            }
        }
               
        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            txtCuit.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            //prop.GuardarUbicacion(1, this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {              
                        
            if (txtNombre.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar un nombre.", 1);
                txtNombre.Focus();
                return;
            }

            if (txtCuit.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe ingresar un número de documento.", 1);
                txtCuit.Focus();
                return;
            }

            if (ExisteCuit(txtCuit.Text))
            {
                ctrls.MensajeInfo("Éste Cuit, ya está registrado.", 1);
                txtCuit.Focus();
                return;
            }

            if (cmbCondIva.Text.ToString() == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una condición de Iva.", 1);
                cmbCondIva.Focus();
                return;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Prestataria.Abm();

            if (retorno.Count > 0)
            {
                string mensajes = "";

                retorno.Where(w => w.Key != 1).Select(s => s.Value).ToList().ForEach(f => mensajes += $"{f.Trim()}\n");

                if (!string.IsNullOrWhiteSpace(mensajes))
                { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); return; }
            }

            Continuacion();

        }


        private void txtCuit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                if (txtCuit.Text.ToString().Trim() == "") { return; }
                GetDatosAfip();
            }
        }

        private void Frm_Prestataria_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Parent is XtraTabPage)
                {
                    XtraTabPage c = Parent as XtraTabPage;
                    XtraTabControl x = c.Parent as XtraTabControl;

                    x.TabPages.Remove(c);
                }
            }
            catch (Exception a)
            {
                ctrls.MensajeInfo($"Inconvenientes en el cierre del formulario.\n{a.Message}", 1);
                return;
            }
            
        }
    }
}