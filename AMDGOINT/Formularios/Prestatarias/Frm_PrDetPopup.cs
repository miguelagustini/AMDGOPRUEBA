using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Prestatarias
{
    public partial class Frm_PrDetPopup : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private PrestatariasControlador prestatariasctrl = new PrestatariasControlador();

        public bool Es_Popup { get; set; } = false;
        public int IDRegistro { get; set; } = 0;
        public int IDPrestataria { get; set; } = 0;

        public Frm_PrDetPopup()
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

                campos.Add("ID_Prestataria");
                campos.Add("Codigo");
                campos.Add("Descripcion");                                
                campos.Add("PorcIva");
                campos.Add("ID_Agrupador");

                if (IDRegistro <= 0)
                {
                    campos.Add("ID_UsuNew");
                    campos.Add("TimeNew");
                }

                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");

                parametros.Add(IDPrestataria);
                parametros.Add(txtCodigo.Text.ToString().Trim());
                parametros.Add(txtNombre.Text.ToString().Trim());                                
                parametros.Add(Convert.ToDecimal(cmbPorcentaje.EditValue));
                parametros.Add(Convert.ToInt32(cmbAgrupador.EditValue));

                if (IDRegistro <= 0)
                {
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(func.Getfechorserver());
                }

                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(func.Getfechorserver());

                string accion = "";
                if (IDRegistro <= 0) accion = "I"; else accion = "U";

                func.AccionBD(campos, parametros, accion, "PRESTDETALLES", IDRegistro);

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
                prop.RecuperaUbicacion(7, this);
            }
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            CargaCombos(0);

            if (IDRegistro > 0) { CargarRegistro();}
                        
        }

        private void CargaCombos(short cmb)
        {
            try
            {
                string consulta = "";

                //CONDICIONES DE IVA 
                if (cmb == 0 || cmb == 1)
                {
                    consulta = "SELECT ID_Registro, Codigo, Descripcion" +
                        " FROM PRESTGRPVAL" +                        
                        " ORDER BY Descripcion ASC";

                    cmbAgrupador.Properties.DataSource = func.getColecciondatos(consulta);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }

        //CARGA DE DATOS
        private void CargarRegistro()
        {
            try
            {                
                string consulta = "SELECT Codigo, Descripcion, PorcIva, ID_Agrupador" +
                    " FROM PRESTDETALLES" +
                    " WHERE ID_Registro = " + IDRegistro;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    txtCodigo.Text = f["Codigo"].ToString();
                    txtNombre.Text = f["Descripcion"].ToString();                    
                    cmbPorcentaje.EditValue = f["PorcIva"].ToString();
                    cmbAgrupador.EditValue = Convert.ToInt32(f["ID_Agrupador"]);
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar el registro.\n" + e.Message, 0);
                return;

            }
        }
        
        //VALIDO EXISTENCIA DE CODIGO DE OBRA
        private bool ExisteCodigo(string cod)
        {
            try
            {
                bool retorno = false;

                string consulta = "SELECT * FROM PRESTDETALLES WHERE Codigo = '" + cod.Trim() + "' AND ID_Registro <> " + IDRegistro;

                if (func.getColecciondatos(consulta).Rows.Count > 0) { retorno = true; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar el registro.\n" + e.Message, 0);
                return true;
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
            txtCodigo.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            prop.GuardarUbicacion(7, this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {           

            if (txtCodigo.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar un código.", 1);
                txtCodigo.Focus();
                return;
            }

            if (ExisteCodigo(txtCodigo.Text))
            {
                ctrls.MensajeInfo("Éste código, ya está registrado.", 1);
                txtCodigo.Focus();
                return;
            }

            if (txtNombre.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar un nombre.", 1);
                txtNombre.Focus();
                return;
            }

            if (cmbPorcentaje.Text.ToString() == "")
            {
                ctrls.MensajeInfo("Debe seleccionar un porcentaje de Iva.", 1);
                cmbPorcentaje.Focus();
                return;
            }


            Abm();
        }
    }
}