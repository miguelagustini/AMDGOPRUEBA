using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Globalization;
using AMDGOINT.Formularios.Auditoria.Anestesiologia.MC;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista
{
    public partial class Frm_Practicasanes : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private Practicaane Practicas = new Practicaane();


        public bool Es_Popup { get; set; } = true;
        
        public Frm_Practicasanes()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

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

                txtCodigo.DataBindings.Add("EditValue", Practicas, nameof(Practicas.Codigo));
                txtDescripcion.DataBindings.Add("EditValue", Practicas, nameof(Practicas.Descripcion));
                spnNivel.DataBindings.Add("EditValue", Practicas, nameof(Practicas.Nivel));                
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

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe ingresar un código.", 1);
                txtCodigo.Focus();
                return;
            }

            if (txtDescripcion.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar una descripción.", 1);
                txtDescripcion.Focus();
                return;
            }

            if (Practicas.ExisteCodigo())
            {
                ctrls.MensajeInfo("Este código ya existe.", 1);
                txtCodigo.Focus();
                return;
            }

            Practicas.Abm();

            Continuacion();
        }
     
    }
}