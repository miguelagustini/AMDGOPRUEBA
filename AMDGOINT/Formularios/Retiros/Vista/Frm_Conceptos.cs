using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Retiros.Vista
{
    public partial class Frm_Conceptos : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();
        private Propiedadesgral prop = new Propiedadesgral();

        MC.Concepto Concepto = new MC.Concepto();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public bool Es_Popup { get; set; } = true;        
        
        public Frm_Conceptos()
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
                if (Es_Popup) { DialogResult = DialogResult.OK; }
                
            }
            catch (Exception)
            {
                return;
            }
        }
        
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Concepto.SqlConnection = SqlConnection;

            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);    
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            CargaCombo();
            SetBindings();

        }

        private void CargaCombo()
        {
            try
            {
                MC.RetirosTipo reti = new MC.RetirosTipo();
                cmbTiporetiro.Properties.DataSource = reti.GetRegistros();
            }
            catch (Exception)
            {

            }
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtNombre.DataBindings.Add("EditValue", Concepto, nameof(Concepto.Descripcion));
                txtCodigo.DataBindings.Add("EditValue", Concepto, nameof(Concepto.Codigo));
                cmbTiporetiro.DataBindings.Add("EditValue", Concepto, nameof(Concepto.IDRetiroTipo));
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
            txtNombre.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            cnb.Desconectar();
            SqlConnection.Dispose();           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Concepto.Descripcion))
            {
                ctrls.MensajeInfo("Debe ingresar un nombre para continuar.", 1);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(Concepto.Codigo))
            {
                ctrls.MensajeInfo("Debe Ingresar un código para continuar.", 1);
                txtCodigo.Focus();
                return;
            }

            if (Concepto.IDRetiroTipo <= 0)
            {
                ctrls.MensajeInfo("Debe Ingresar un tipo de retiro para continuar.", 1);
                cmbTiporetiro.Focus();
                return;
            }

            if (Concepto.GetIdbycodigo() > 0)
            {
                ctrls.MensajeInfo("Éste código ya esta registrado.", 1);
                txtCodigo.Focus();
                return;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Concepto.Abm();

            if (retorno.Count > 0)
            {
                string mensajes = "";

                retorno.Where(w => w.Key != 1).Select(s => s.Value).ToList().ForEach(f => mensajes += $"{f.Trim()}\n");
                
                if (!string.IsNullOrWhiteSpace(mensajes))
                { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
            }

            Continuacion();
        }               
    }
}

