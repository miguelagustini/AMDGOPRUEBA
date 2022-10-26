using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Globalization;

namespace AMDGOINT.Formularios.Practicas
{
    public partial class Frm_Practicas : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        
        public bool Es_Popup { get; set; } = false;
        public int IDRegistro { get; set; } = 0;
        
        public Frm_Practicas()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES

        //ABM DE PERSONAS
        private void Abm()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();
                                
                campos.Add("Codigo");
                campos.Add("Descripcion");
                campos.Add("ID_Funcion");
                campos.Add("ID_Arancel");
                campos.Add("ID_Gasto");                
                campos.Add("ID_Grupo");                

                if (IDRegistro <= 0)
                {
                    campos.Add("ID_UsuNew");
                    campos.Add("TimeNew");
                }

                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");
                                                
                parametros.Add(txtCodigo.Text.ToString().Trim());
                parametros.Add(txtDescripcion.Text.ToString().Trim());
                parametros.Add(Convert.ToInt32(cmbFuncion.EditValue));
                parametros.Add(Convert.ToInt32(cmbArancel.EditValue));
                parametros.Add(Convert.ToInt32(cmbGasto.EditValue));
                parametros.Add(Convert.ToInt32(cmbGrupo.EditValue));

                if (IDRegistro <= 0)
                {
                    parametros.Add(glob.GetIdUsuariolog());
                    parametros.Add(func.Getfechorserver());
                }

                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(func.Getfechorserver());

                string accion = "";
                if (IDRegistro <= 0) accion = "I"; else accion = "U";

                func.AccionBD(campos, parametros, accion, "PRACTAM", IDRegistro);

                Continuacion();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al procesar el registro.\n" + e.Message, 0);
                return;
            }
        }

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                if (Es_Popup) { this.DialogResult = DialogResult.OK; }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                prop.RecuperaUbicacion(13, this);
            }
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
                        
            CargaCombos(0);

            if (IDRegistro > 0) { CargarRegistro(); }
            
                        
        }
                
        //CARGA DE DATOS
        private void CargarRegistro()
        {
            try
            {                
                string consulta = "SELECT ID_Registro, Codigo, Descripcion, ID_Arancel, ID_Gasto, ID_Funcion, ID_Grupo" +
                    " FROM PRACTAM" +
                    " WHERE ID_Registro = " + IDRegistro;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    txtCodigo.Text = f["Codigo"].ToString();
                    txtDescripcion.Text = f["Descripcion"].ToString();                    
                    cmbFuncion.EditValue = Convert.ToInt32(f["ID_Funcion"]);
                    cmbArancel.EditValue = Convert.ToInt32(f["ID_Arancel"]);
                    cmbGasto.EditValue = Convert.ToInt32(f["ID_Gasto"]);
                    cmbGrupo.EditValue = Convert.ToInt32(f["ID_Grupo"]);
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar el registro.\n" + e.Message, 0);
                return;
            }
        }
               
        //CARGA DE COMBOS
        private void CargaCombos(short cmb)
        {
            try
            {
                string consulta = "";
                
                //FUNCIONES
                if (cmb == 0 || cmb == 1)
                {
                    consulta = "SELECT ID_Registro, Codigo, Descripcion" +
                        " FROM FUNCIONES" +                        
                        " ORDER BY Descripcion ASC";

                    cmbFuncion.Properties.DataSource = func.getColecciondatos(consulta);
                }

                //ARANCELES
                if (cmb == 0 || cmb == 2)
                {
                    consulta = "SELECT ID_Registro, Codigo, Descripcion" +
                        " FROM ARANCELES" +
                        " ORDER BY Descripcion ASC";

                    cmbArancel.Properties.DataSource = func.getColecciondatos(consulta);
                }

                //GASTOS
                if (cmb == 0 || cmb == 3)
                {
                    consulta = "SELECT ID_Registro, Codigo, Descripcion" +
                        " FROM GASTOS" +
                        " ORDER BY Descripcion ASC";

                    cmbGasto.Properties.DataSource = func.getColecciondatos(consulta);
                }

                //GRUPOS
                if (cmb == 0 || cmb == 4)
                {
                    consulta = "SELECT ID_Registro, Descripcion" +
                        " FROM PRACTGRUPOS" +
                        " ORDER BY Descripcion ASC";

                    cmbGrupo.Properties.DataSource = func.getColecciondatos(consulta);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }

        //EXISTE REGISTRO
        private bool ExisteRegistro()
        {
            bool retorno = false;

            try
            {
                string c = "SELECT * FROM PRACTAM WHERE Codigo = '" + txtCodigo.Text.Trim() + "'" +
                    " AND ID_Funcion = " + Convert.ToInt32(cmbFuncion.EditValue) +
                    " AND ID_Arancel = " + Convert.ToInt32(cmbArancel.EditValue) +
                    " AND ID_Gasto = " + Convert.ToInt32(cmbGasto.EditValue) + 
                    " AND ID_Registro <> " + IDRegistro;

                if (func.getColecciondatos(c).Rows.Count > 0) { retorno = true; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al consultar la existencia.\n {e.Message}", 0);
                return retorno;
            }
        }

        //VALIDO SI LA PRACTICA ESTA ASOCIADA A UNA VALORIZACION FINALIZADA
        private bool PermitoModificarrel()
        {
            bool retorno = false;

            try
            {
                string c = "SELECT * FROM ARANVALORIZADET AD" +
                        " LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = AD.ID_Encabezado)" +
                        " WHERE AD.ID_PractAm = " + IDRegistro + " AND AE.Estado = 1";

                if (func.getColecciondatos(c).Rows.Count <= 0) { retorno = true; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al consultar la disponibilidad de modificación.\n {e.Message}", 0);
                return retorno;
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
            prop.GuardarUbicacion(13, this);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe ingresar un código de documento.", 1);
                txtCodigo.Focus();
                return;
            }

            if (txtDescripcion.Text.ToString().Trim() == "")
            {
                ctrls.MensajeInfo("Debe Ingresar una descripción.", 1);
                txtDescripcion.Focus();
                return;
            }
                        
            int c = 0;
            c = cmbFuncion.Text.ToString() != "" ? c+1 : c;
            c = cmbArancel.Text.ToString() != "" ? c+1 : c;
            c = cmbGasto.Text.ToString() != "" ? c+1 : c;

            if (c == 0)
            {
                ctrls.MensajeInfo("Debe seleccionar una característica.", 1);
                cmbFuncion.Focus();
                return;
            }
            else if (c > 1)
            {
                ctrls.MensajeInfo("Una práctica no debe contener más de una característica..", 1);
                cmbFuncion.Focus();
                return;
            }

            if (cmbGrupo.Text.ToString() == "")
            {
                ctrls.MensajeInfo("Debe seleccionar un grupo.", 1);
                cmbFuncion.Focus();
                return;
            }

            if (ExisteRegistro())
            {
                ctrls.MensajeInfo("Ya existe una práctica registrada con éstos parámetros.", 1);
                txtCodigo.Focus();
                return;
            }

            if (IDRegistro > 0 && !PermitoModificarrel())
            {
                ctrls.MensajeInfo("No se puede modificar una práctica asociada a una valorización cerrada.", 1);
                return;
            }

            Abm();
        }

        private void cmbFuncion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                cmbFuncion.EditValue = 0;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void cmbArancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                cmbArancel.EditValue = 0;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void cmbGasto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                cmbGasto.EditValue = 0;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}