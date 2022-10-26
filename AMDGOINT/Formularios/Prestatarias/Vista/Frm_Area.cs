using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    public partial class Frm_Area : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();        
        private Propiedadesgral prop = new Propiedadesgral();

        MC.Area Area = new MC.Area();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public bool Es_Popup { get; set; } = true;        
        
        public Frm_Area()
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
                DialogResult = DialogResult.OK; 
                
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
            Area.SqlConnection = SqlConnection;

            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
                        
            SetBindings();

        }
        
        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtNombre.DataBindings.Add("EditValue", Area, nameof(Area.Descripcion));                
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

            if (string.IsNullOrWhiteSpace(Area.Descripcion))
            {
                ctrls.MensajeInfo("Debe ingresar una descripcion para continuar.", 1);
                txtNombre.Focus();
                return;
            }

            if (Area.GetbyDescripcion() > 0)
            {
                ctrls.MensajeInfo("Ésta descripción ya esta registrada.", 1);
                txtNombre.Focus();
                return;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Area.Abm();

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

