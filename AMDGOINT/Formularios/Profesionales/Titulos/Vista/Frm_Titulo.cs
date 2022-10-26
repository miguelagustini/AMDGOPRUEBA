using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AMDGOINT.Formularios.Profesionales.Titulos.Vista
{
    public partial class Frm_Titulo : XtraForm
    {
        private Controles ctrls = new Controles();
        private MC.Titulo Titulo = new Titulos.MC.Titulo();


        private ConexionBD bc = new ConexionBD();
        private SqlConnection SqlConnection { get; set; } = new SqlConnection();
              
        public Frm_Titulo()
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
            Titulo.SqlConnection = SqlConnection;

            this.FormBorderStyle = ctrls.EstiloBordesform(true);
            CargaCombos();
            SetBindings();
        }

        //CARGA COMBOS
        private void CargaCombos(object c = null)
        {
            try
            {
                Titulos.MC.Grupo ent = new Titulos.MC.Grupo(SqlConnection);

                List<Titulos.MC.Grupo> lst = ent.Clone(ent.GetRegistros());

                if (c != null)
                {
                    SearchLookUpEdit se = c as SearchLookUpEdit;
                    cmbGrupos.Properties.DataSource = lst;
                    se.Properties.DataSource = lst;
                }
                else { cmbGrupos.Properties.DataSource = lst; }

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("No se pudo cargar los grupos.", 0);
                return;
            }
        }

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            this.DialogResult = DialogResult.OK;
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtDescripcion.DataBindings.Add("EditValue", Titulo, nameof(Titulo.Descripcion));
                cmbGrupos.DataBindings.Add("EditValue", Titulo, nameof(Titulo.IDGrupo));
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
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
            if (string.IsNullOrWhiteSpace(Titulo.Descripcion))
            {
                ctrls.MensajeInfo("Debe Ingresar una descripción para continuar.", 1);
                txtDescripcion.Focus();
                return;
            }

            if (Titulo.IDGrupo <= 0)
            {
                ctrls.MensajeInfo("Debe seleccionar un grupo para continuar.", 1);
                cmbGrupos.Focus();
                return;
            }

            if (Titulo.Existeregbydesc() > 0)
            {
                ctrls.MensajeInfo("Éste título ya existe.", 1);
                txtDescripcion.Focus();
                return;
            }

            Titulo.Abm();
            Continuacion();
        }
    }
}