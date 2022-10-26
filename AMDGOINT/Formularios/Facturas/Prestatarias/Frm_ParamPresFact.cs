using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Collections;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Frm_ParamPresFact : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();

        public bool Es_Popup { get; set; } = false;
        private int ID_PARAMSCBU = 0;

        public Frm_ParamPresFact()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                prop.RecuperaUbicacion(6, this);
            }
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);

            CargarRegistro();
        }

        //CARGA DE DATOS
        private void CargarRegistro()
        {
            try
            {
                string consulta = "SELECT ID_Registro, Cbu, Alias, MinPyme" +
                    " FROM PARAMSCBU";
                    

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    txtCbu.Text = f["Cbu"].ToString();
                    txtAlias.Text = f["Alias"].ToString();
                    txtImpomipyme.Text = f["MinPyme"].ToString();
                    ID_PARAMSCBU = Convert.ToInt32(f["ID_Registro"]);
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar el registro.\n" + e.Message, 0);
                return;

            }
        }

        //ABM
        private void Abm()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Cbu");
                campos.Add("Alias");
                campos.Add("MinPyme");

                if (ID_PARAMSCBU <= 0)
                {
                    campos.Add("ID_UsuNew");
                    campos.Add("TimeNew");
                }

                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");


                parametros.Add(txtCbu.Text.ToString().Trim());
                parametros.Add(txtAlias.Text.ToString().Trim());
                parametros.Add(Convert.ToDecimal(txtImpomipyme.Text));

                if (ID_PARAMSCBU <= 0)
                {
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(func.Getfechorserver());
                }

                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(func.Getfechorserver());

                string accion = "";
                if (ID_PARAMSCBU <= 0) accion = "I"; else accion = "U";

                func.AccionBD(campos, parametros, accion, "PARAMSCBU", ID_PARAMSCBU);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el registro.\n" + e.Message, 0);
                return;
            }
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            txtCbu.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            prop.GuardarUbicacion(6, this);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Abm();
        }
    }
}