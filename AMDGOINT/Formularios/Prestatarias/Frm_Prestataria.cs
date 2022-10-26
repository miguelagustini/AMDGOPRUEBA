using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Globalization;

namespace AMDGOINT.Formularios.Prestatarias
{
    public partial class Frm_Prestataria : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private PrestatariasControlador prestatariasctrl = new PrestatariasControlador();
        
        private Frm_PrDetalles frmplanes = new Frm_PrDetalles();        

        public bool Es_Popup { get; set; } = false;
        public int IDRegistro { get; set; } = 0;
        
        public Frm_Prestataria()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES

        //ABM DE PERSONAS
        private void Abm()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();
                                
                campos.Add("Nombre");
                campos.Add("Cuit");
                campos.Add("ID_Iva");
                campos.Add("DomicilioFiscal");
                campos.Add("DiasVencimiento");
                campos.Add("MiPyme");
                campos.Add("AceptaCompx");
                campos.Add("CompPaciente");
                campos.Add("Abreviatura");

                if (IDRegistro <= 0)
                {
                    campos.Add("ID_UsuNew");
                    campos.Add("TimeNew");
                }

                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");
                                                
                parametros.Add(txtNombre.Text.ToString().Trim());
                parametros.Add(Convert.ToInt64(txtCuit.Text));
                parametros.Add(Convert.ToInt16(cmbCondIva.EditValue));
                parametros.Add(txtDomiciliof.Text.Trim());
                parametros.Add(Convert.ToInt32(spnVencimientos.EditValue));
                parametros.Add(Convert.ToBoolean(tglmipyme.EditValue));
                parametros.Add(Convert.ToBoolean(tglComprobX.EditValue));
                parametros.Add(Convert.ToBoolean(tglComprobpaci.EditValue));
                parametros.Add(txtAbrevia.Text.Trim());

                if (IDRegistro <= 0)
                {
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(func.Getfechorserver());
                }

                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(func.Getfechorserver());

                string accion = "";
                if (IDRegistro <= 0) accion = "I"; else accion = "U";

                func.AccionBD(campos, parametros, accion, "PRESTATARIAS", IDRegistro);

                Continuacion();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el registro.\n" + e.Message, 0);
                return;
            }
        }

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                prop.RecuperaUbicacion(1, this);
            }
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            ctrls.AgregaFormulario(frmplanes, tabDetalles);
            
            //ICONOS            
            tabDetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;
            
            CargaCombos(0);

            tabDetalles.SelectedTabPageIndex = 0;
            if (IDRegistro > 0) { CargarRegistro(); tabDetalles.Enabled = true; }
            else { tabDetalles.Enabled = false; }
                        
        }
                
        //CARGA DE DATOS
        private void CargarRegistro()
        {
            try
            {                
                string consulta = "SELECT Nombre, Cuit, ID_Iva, MiPyme, DiasVencimiento, DomicilioFiscal, AceptaCompx, CompPaciente, Abreviatura" +
                    " FROM PRESTATARIAS" +
                    " WHERE ID_Registro = " + IDRegistro;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {                    
                    txtNombre.Text = f["Nombre"].ToString();
                    txtCuit.Text = f["Cuit"].ToString();
                    cmbCondIva.EditValue = Convert.ToInt16(f["ID_Iva"]);  
                    txtDomiciliof.Text = f["DomicilioFiscal"].ToString();
                    spnVencimientos.EditValue = Convert.ToInt32(f["DiasVencimiento"]);
                    tglmipyme.EditValue = Convert.ToBoolean(f["MiPyme"]);
                    tglComprobX.EditValue = Convert.ToBoolean(f["AceptaCompx"]);
                    tglComprobpaci.EditValue = Convert.ToBoolean(f["CompPaciente"]);
                    txtAbrevia.Text = f["Abreviatura"].ToString();
                }

                frmplanes.IDPrestataria = IDRegistro;
                frmplanes.CargarRegistro();                

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar el registro.\n" + e.Message, 0);
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

                string consulta = "SELECT * FROM PRESTATARIAS WHERE Cuit = " + cod.Trim() + " AND ID_Registro <> " + IDRegistro;

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
            prop.GuardarUbicacion(1, this);
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
                        
            Abm();
        }


        private void txtCuit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                if (txtCuit.Text.ToString().Trim() == "") { return; }
                GetDatosAfip();
            }
        }
    }
}