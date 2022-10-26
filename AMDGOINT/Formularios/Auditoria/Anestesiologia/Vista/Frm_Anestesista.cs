using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using AMDGOINT.Formularios.Auditoria.Anestesiologia.MC;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista
{
    public partial class Frm_Anestesista : XtraForm
    {
        private Controles ctrls = new Controles();        
        private Anestesista Anestesista = new Anestesista();
        
        public bool Es_Popup { get; set; } = true;
        
        public Frm_Anestesista()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);            

        }

        #region METODOS MANUALES
            
        private void Continuacion()
        {            
            if (Es_Popup) { this.DialogResult = DialogResult.OK; }
        }
        
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {            
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
            SetBindings();
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtCodigo.DataBindings.Add("EditValue", Anestesista, nameof(Anestesista.Matricula));
                txtNombre.DataBindings.Add("EditValue", Anestesista, nameof(Anestesista.Nombre));                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
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
            txtCodigo.Focus();
        }
               
        private void btnGuardar_Click(object sender, EventArgs e)
        {                      
            if (txtCodigo.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar una matricula.", 1);
                txtCodigo.Focus();
                return;
            }

            if (txtNombre.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar un nombre.", 1);
                txtNombre.Focus();
                return;
            }

            if (Anestesista.ExisteMatricual())
            {
                ctrls.MensajeInfo("Esta matricula ya existe.", 1);
                txtCodigo.Focus();
                return;
            }

            Anestesista.Abm();

            Continuacion();
        }
     
    }
}