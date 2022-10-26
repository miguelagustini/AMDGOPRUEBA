using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Empleados.Vista
{
    public partial class Frm_Empleado : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();        
        private Propiedadesgral prop = new Propiedadesgral();

        public MC.Empleado Empleado = new MC.Empleado();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public bool Es_Popup { get; set; } = true;        
        
        public Frm_Empleado()
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
            Empleado.SqlConnection = SqlConnection;

            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
            CargaCombos();
            SetBindings();
        }


        private void CargaCombos()
        {
            try
            {   
                //planesSeleccionables
                CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                List<CuentasContables.MC.Cuentas> lst = ctas.GetRegistros().Where(w => w.Estado && w.Seleccionable).ToList();

                //PLANES HABILITADOS RECIBOS PARA PRESTATARIAS
                cmbSubcuenta.Properties.DataSource = lst.Where(w => w.IDRegistro == 16).SelectMany(s => s.SubCuentas).ToList(); 
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al cargar los planes contables.\n{e.Message}", 1);
                return;
            }
        }


        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtNombre.DataBindings.Add("EditValue", Empleado, nameof(Empleado.Nombre));
                txtCuit.DataBindings.Add("EditValue", Empleado, nameof(Empleado.DocumentoNumero));                              
                cmbSubcuenta.DataBindings.Add("EditValue", Empleado, nameof(Empleado.IDPlanSubCuenta));                                              
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

            if (string.IsNullOrWhiteSpace(Empleado.Nombre))
            {
                ctrls.MensajeInfo("Debe ingresar un nombre para continuar.", 1);
                txtNombre.Focus();
                return;
            }

            if (Empleado.DocumentoNumero <= 0)
            {
                ctrls.MensajeInfo("Debe Ingresar un Documento para continuar.", 1);
                txtCuit.Focus();
                return;
            }

            if (Empleado.GetbyDocumento() > 0)
            {
                ctrls.MensajeInfo("Éste documento ya está registrado.", 1);
                txtCuit.Focus();
                return;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Empleado.Abm();

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

