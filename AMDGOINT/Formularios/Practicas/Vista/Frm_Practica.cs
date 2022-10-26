using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace AMDGOINT.Formularios.Practicas.Vista
{
    public partial class Frm_Practica : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();        
        private Propiedadesgral prop = new Propiedadesgral();
        private List<Binding> Binding = new List<Binding>();

        public MC.Practica Practica { get; set; } = new MC.Practica();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public bool Es_Popup { get; set; } = false;        
        
        public Frm_Practica()
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
                if (Es_Popup) { this.DialogResult = DialogResult.OK; }
                
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
            Practica.SqlConnection = SqlConnection;

            if (Es_Popup)
            {
                prop.RecuperaUbicacion(13, this);
            }
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
                        
            SetBindings();
            CargaCombos();

        }
        
        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                txtCodigo.DataBindings.Add("EditValue", Practica, nameof(Practica.Codigo));
                memoDescrip.DataBindings.Add("EditValue", Practica, nameof(Practica.Descripcion));

                //LOS AGREGO A UN BINDING PARA FORZAR LA LECTURA A LOS CONTROLES.                
                Binding.Add(cmbArancel.DataBindings.Add("EditValue", Practica, nameof(Practica.IDGaleno)));
                Binding.Add(cmbGasto.DataBindings.Add("EditValue", Practica, nameof(Practica.IDGasto)));
                Binding.Add(cmbFuncion.DataBindings.Add("EditValue", Practica, nameof(Practica.IDFuncion)));                

                cmbGrupo.DataBindings.Add("EditValue", Practica, nameof(Practica.IDGrupo));
                trackTipo.DataBindings.Add("EditValue", Practica, nameof(Practica.TipoPractica));
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;
            }
        }

        //CARGA DE COMBOS
        private void CargaCombos(short cmb = 0)
        {
            try
            {   
                //FUNCIONES
                if (cmb == 0 || cmb == 1)
                {
                    MC.Funcion Funciones = new MC.Funcion(SqlConnection);
                    cmbFuncion.Properties.DataSource = Funciones.GetRegistros().Where(w => w.Codigo != "64").ToList();
                }

                //UNIDADES DE GALENO
                if (cmb == 0 || cmb == 2)
                {
                    MC.Galeno Galenos = new MC.Galeno(SqlConnection);
                    cmbArancel.Properties.DataSource = Galenos.GetRegistros();
                }

                //UNIDADES DE GASTOS
                if (cmb == 0 || cmb == 3)
                {                    
                    MC.Gasto Gasto = new MC.Gasto(SqlConnection);
                    cmbGasto.Properties.DataSource = Gasto.GetRegistros();
                }

                //GRUPOS
                if (cmb == 0 || cmb == 4)
                {                    
                    MC.Grupo Grupos = new MC.Grupo(SqlConnection);
                    cmbGrupo.Properties.DataSource = Grupos.GetRegistros();
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }
       
        //PARA LOS CONTROLES QUE NO REFLEJAN EL CAMBIO DE LA FUENTE DE DATOS
        private void LeerValor()
        {
            foreach (Binding b in Binding)
            {
                if (b != null) { b.ReadValue(); }
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
            CargaCombos();
            txtCodigo.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            cnb.Desconectar();            
            prop.GuardarUbicacion(13, this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Practica.Codigo))
            {
                ctrls.MensajeInfo("Debe ingresar un código para continuar.", 1);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(Practica.Descripcion))
            {
                ctrls.MensajeInfo("Debe Ingresar una descripción.", 1);
                memoDescrip.Focus();
                return;
            }

            if (Practica.TipoPractica == 0 && Practica.IDFuncion == 0)
            {
                ctrls.MensajeInfo("Debe Seleccionar una función.", 1);
                cmbFuncion.Focus();
                return;
            }

            if (Practica.TipoPractica == 1 && Practica.IDGaleno == 0)
            {
                ctrls.MensajeInfo("Debe Seleccionar una unidad de galeno.", 1);
                cmbArancel.Focus();
                return;
            }

            if (Practica.TipoPractica == 2 && Practica.IDGasto == 0)
            {
                ctrls.MensajeInfo("Debe Seleccionar una unidad de gasto.", 1);
                cmbGasto.Focus();
                return;
            }

            if (Practica.IDGrupo == 0)
            {
                ctrls.MensajeInfo("Debe seleccionar un grupo.", 1);
                cmbGrupo.Focus();
                return;
            }

            if (Practica.ExisteRegistro() > 0)
            {
                ctrls.MensajeInfo("Ya existe una práctica registrada con éstos parámetros.", 1);
                txtCodigo.Focus();
                return;
            }

            if (Practica.IDRegistro > 0 && !Practica.PermitoModificarrel())
            {
                ctrls.MensajeInfo("No se puede modificar una práctica asociada a una valorización cerrada.", 1);
                return;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Practica.Abm();

            if (retorno.Count > 0)
            {
                string mensajes = "";

                retorno.Where(w => w.Key != 1).Select(s => s.Value).ToList().ForEach(f => mensajes += $"{f.Trim()}\n");
                
                if (!string.IsNullOrWhiteSpace(mensajes))
                { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
            }

            Continuacion();
        }

        private void Combos_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyData == Keys.Delete)
            {
                GridLookUpEdit edit = sender as GridLookUpEdit;
                edit.EditValue = 0;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void trackTipo_ValueChanged(object sender, EventArgs e)
        {
            if ((short)trackTipo.Value == 0)
            {
                cmbFuncion.Enabled = true;
                Practica.IDGaleno = 0;
                cmbArancel.Enabled = false;
                Practica.IDGasto = 0;
                cmbGasto.Enabled = false;
                
            }
            else if ((short)trackTipo.Value == 1)
            {
                cmbArancel.Enabled = true;                
                cmbFuncion.Enabled = false;
                Practica.IDFuncion = 0; 
                cmbGasto.Enabled = false;
                Practica.IDGasto = 0; 
            }
            else if ((short)trackTipo.Value == 2)
            {
                cmbGasto.Enabled = true;                
                cmbFuncion.Enabled = false;
                Practica.IDFuncion = 0; 
                cmbArancel.Enabled = false;
                Practica.IDGaleno = 0; 
            }

            //FUERZO LECTURA DE LOS CONTROLES.
            LeerValor();
        }

        private void memoDescrip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}

