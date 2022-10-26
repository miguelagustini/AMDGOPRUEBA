using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Collections;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Frm_TasaInteres : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();

        private short IDRegistro = 0;


        public Frm_TasaInteres()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {   
            FormBorderStyle = ctrls.EstiloBordesform(true);

            CargarRegistro();
        }

        //CARGA DE DATOS
        private void CargarRegistro()
        {
            try
            {
                string consulta = "SELECT IDRegistro, TazaInteres FROM TAZASINTERES";                    

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    IDRegistro = Convert.ToInt16(f["IDRegistro"]);
                    txtCbu.EditValue = f["TazaInteres"];
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

                campos.Add("TazaInteres");                
                
                parametros.Add(Convert.ToDecimal(txtCbu.Text));

                if (IDRegistro > 0) { func.AccionBD(campos, parametros, "U", "TAZASINTERES", IDRegistro, "IDRegistro"); }
                else { func.AccionBD(campos, parametros, "I", "TAZASINTERES", IDRegistro, "IDRegistro"); }
                

                DialogResult = DialogResult.OK;
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
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Abm();
        }
    }
}