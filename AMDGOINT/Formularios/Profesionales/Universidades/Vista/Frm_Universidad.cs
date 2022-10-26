using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Profesionales.Universidades.Vista
{
    public partial class Frm_Universidad : XtraForm
    {
        private Controles ctrls = new Controles();
        private MC.Universidad Universidad = new MC.Universidad();
        
        private ConexionBD bc = new ConexionBD();
        private SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Universidad()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : bc.Conectar();
            Universidad.SqlConnection = SqlConnection;

            this.FormBorderStyle = ctrls.EstiloBordesform(true);

            SetBindings();
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtDescripcion.DataBindings.Add("EditValue", Universidad, nameof(Universidad.Descripcion));                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            this.DialogResult = DialogResult.OK;
        }

      
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            bc.Desconectar();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Universidad.Descripcion))
            {
                ctrls.MensajeInfo("Debe Ingresar una descripción para continuar.", 1);
                txtDescripcion.Focus();
                return;
            }

            if (Universidad.Existeregbydesc() > 0)
            {
                ctrls.MensajeInfo("Ésta universidad ya existe.", 1);
                txtDescripcion.Focus();
                return;
            }

            Universidad.Abm();
            Continuacion();
        }
    }
}