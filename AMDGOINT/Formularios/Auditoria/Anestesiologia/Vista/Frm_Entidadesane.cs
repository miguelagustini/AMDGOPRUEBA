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
    public partial class Frm_Entidadesane : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();        
        private Propiedadesgral prop = new Propiedadesgral();
        private Entidadane Entidad = new Entidadane();
        
        public bool Es_Popup { get; set; } = true;
        
        public Frm_Entidadesane()
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
                txtDescripcion.DataBindings.Add("EditValue", Entidad, nameof(Entidad.Nombre));                
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
            txtDescripcion.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {                      
            if (txtDescripcion.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar una descripción.", 1);
                txtDescripcion.Focus();
                return;
            }

            if (Entidad.ExisteNombre())
            {
                ctrls.MensajeInfo("Esta entidad ya existe.", 1);
                txtDescripcion.Focus();
                return;
            }

            Entidad.Abm();

            Continuacion();
        }
     
    }
}