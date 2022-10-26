using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_Profesional : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();        
        private Propiedadesgral prop = new Propiedadesgral();
        private Globales glb = new Globales();
        
        private Frm_DirecCont frmcontact = new Frm_DirecCont();
        private Frm_Especialidades frmespe = new Frm_Especialidades();
        private Frm_Prestatarias frmprestataria = new Frm_Prestatarias();
        private Frm_Cuentas frmcuentas = new Frm_Cuentas();
        private Frm_Diferencial frmdiferencial = new Frm_Diferencial();

        private Frm_ExIngresosBrutos frmingresosbrutos = new Frm_ExIngresosBrutos();
        private Frm_ExImpuestoGanancias frmimpuestoganancias = new Frm_ExImpuestoGanancias();
        private Frm_ExInstitutoBecario frminstitutobecario = new Frm_ExInstitutoBecario();
        private Frm_CondicionFiscalIVa frmcondicionfiscaliva = new Frm_CondicionFiscalIVa();

        private List<Binding> Bindctrls = new List<Binding>();
        public MC.Profesionales Profesional { get; set; } = new MC.Profesionales();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        public bool Es_Popup { get; set; } = false;

        private bool PermisoEdicion = false;

        private ConexionBD bc = new ConexionBD();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Profesional()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            datVencimiento.Properties.NullDate = DateTime.MinValue;
            datVencimiento.Properties.NullText = string.Empty;
            datVtoHabilitacion.Properties.NullDate = DateTime.MinValue;
            datVtoHabilitacion.Properties.NullText = string.Empty;
            datInicioa.Properties.NullDate = DateTime.MinValue;
            datInicioa.Properties.NullText = string.Empty;
            datGraduacion.Properties.NullDate = DateTime.MinValue;
            datGraduacion.Properties.NullText = string.Empty;
            datNacimiento.Properties.NullDate = DateTime.MinValue;
            datNacimiento.Properties.NullText = string.Empty;
            datIngrasoam.Properties.NullDate = DateTime.MinValue;
            datIngrasoam.Properties.NullText = string.Empty;
        }

        #region METODOS MANUALES
               
        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                if (Es_Popup) { DialogResult = DialogResult.OK; }
                else
                {
                    Close();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : bc.Conectar();
            Profesional.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;

            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            //CARGA PERMISOS
            Permisos.Clear();            
            Permisos.AddRange(Permiso.GetPermisoUsuario());
            PermisoEdicion = Permisos.Where(w => w.Clave == "ProfEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First();

            frmcontact.Editable = PermisoEdicion;
            frmcontact.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmcontact, Tabdetalles);

            frmespe.Editable = PermisoEdicion;
            frmespe.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmespe, Tabdetalles);

            frmprestataria.Editable = PermisoEdicion;
            frmprestataria.SqlConnection = SqlConnection;
            ctrls.AgregaFormulario(frmprestataria, Tabdetalles);

            frmcuentas.Editable = PermisoEdicion;
            frmcuentas.SqlConnection = SqlConnection;           
            ctrls.AgregaFormulario(frmcuentas, Tabdetalles);

            frmdiferencial.Editable = PermisoEdicion;            
            ctrls.AgregaFormulario(frmdiferencial, Tabdetalles);
            frmingresosbrutos.Editable = PermisoEdicion;
            ctrls.AgregaFormulario(frmingresosbrutos, Tabdetalles);
            frmimpuestoganancias.Editable = PermisoEdicion;
            ctrls.AgregaFormulario(frmimpuestoganancias, Tabdetalles);
            frminstitutobecario.Editable = PermisoEdicion;
            ctrls.AgregaFormulario(frminstitutobecario, Tabdetalles);
            frmcondicionfiscaliva.SqlConnection = SqlConnection;
            frmcondicionfiscaliva.Editable = PermisoEdicion;
            ctrls.AgregaFormulario(frmcondicionfiscaliva, Tabdetalles);

            //ICONOS            
            Tabdetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BOContact2_16x16;
            Tabdetalles.TabPages[1].ImageOptions.Image = Properties.Resources.ContentArrangeInRows_16x16;
            Tabdetalles.TabPages[2].ImageOptions.Image = Properties.Resources.BlankRowsPivotTable_16x16;
            Tabdetalles.TabPages[3].ImageOptions.Image = Properties.Resources.Driving_16x16;
            Tabdetalles.TabPages[4].ImageOptions.Image = Properties.Resources.Currency_16x16;
            Tabdetalles.TabPages[5].ImageOptions.Image = Properties.Resources.BO_Opportunity;
            Tabdetalles.TabPages[6].ImageOptions.Image = Properties.Resources.BO_Organization;
            Tabdetalles.TabPages[7].ImageOptions.Image = Properties.Resources.BO_Sale;
            Tabdetalles.TabPages[8].ImageOptions.Image = Properties.Resources.BO_Note;


            Tabdetalles.SelectedTabPageIndex = 0;

            SetBindings();
            ControlesSinModificacion(this, !PermisoEdicion);
            
        }


        private void ControlesSinModificacion(Control parent, bool puedeeditar)
        {
            try
            {
                foreach (Control c in parent.Controls)
                {
                    if (c.GetType() == typeof(TextEdit))
                    {
                        TextEdit t = c as TextEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(ComboBoxEdit))
                    {
                        ComboBoxEdit t = c as ComboBoxEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(ButtonEdit))
                    {
                        ButtonEdit t = c as ButtonEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(GridLookUpEdit))
                    {
                        GridLookUpEdit t = c as GridLookUpEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(DateEdit))
                    {
                        DateEdit t = c as DateEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(SpinEdit))
                    {
                        SpinEdit t = c as SpinEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(ToggleSwitch))
                    {
                        ToggleSwitch t = c as ToggleSwitch;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(MemoEdit))
                    {
                        MemoEdit t = c as MemoEdit;
                        t.ReadOnly = puedeeditar;
                    }
                    else if (c.GetType() == typeof(SimpleButton))
                    {
                        SimpleButton t = c as SimpleButton;
                        t.Enabled = !puedeeditar;
                    }
                 
                    if (c.HasChildren) { ControlesSinModificacion(c, puedeeditar); }
                    
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al ajustar los controles.\n{e.Message}", 1);
                return;
            }
        }

        //CARGA DE COMBOS
        private void CargaCombos(short cmb)
        {
            try
            {
                
                string c = "";
                
                //CONDICIONES DE IVA 
                if (cmb == 0 || cmb == 2)
                {
                    c = $"SELECT ID_Registro, Descripcion, Abreviatura" +
                        $" FROM CONDSIVA" +
                        $" WHERE Abreviatura <> 'CF'" +
                        $" ORDER BY Descripcion ASC";

                    cmbCondIva.Properties.DataSource = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                }

                //TITULOS
                if (cmb == 0 || cmb == 3)
                {
                    Titulos.MC.Titulo datamodel = new Titulos.MC.Titulo(SqlConnection);
                    List<Titulos.MC.Titulo> lst = datamodel.Clone(datamodel.GetRegistros());
                    cmbTitulo.Properties.DataSource = lst;

                }

                //CATEGORIA
                if (cmb == 0 || cmb == 4)
                {
                    c = $"SELECT ID_Registro, Descripcion" +
                        $" FROM PROFCATEGORIA" +                        
                        $" ORDER BY Descripcion ASC";

                    cmbCategoria.Properties.DataSource = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                    
                }

                //UNIVERSIDAD
                if (cmb == 0 || cmb == 5)
                {
                    Universidades.MC.Universidad datamodel = new Universidades.MC.Universidad();
                    List<Universidades.MC.Universidad> lst = datamodel.Clone(datamodel.GetRegistros());
                    cmbUniversidad.Properties.DataSource = lst;
                }

                //REFERENCIAS
                if (cmb == 0 || cmb == 6)
                {
                    c = $"SELECT ID_Registro, Descripcion" +
                        $" FROM PROFEREFERENCIAS" +
                        $" WHERE Visible = 1" +
                        $" ORDER BY Descripcion ASC";

                    cmbReferencia.Properties.DataSource = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                }
               
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message + " " + cmb, 0);                
                return;
            }
        }
               
        //OBTENGO DATOS DE AFIP
        private void GetDatosAfip()
        {
            try
            {   
                CultureInfo ci = new CultureInfo("es-Es");
                ci = new CultureInfo("es-Es");
                TextInfo textInfo = ci.TextInfo;

                Enabled = false;

                DatosAfip d = func.GetInfoAfipunico(Convert.ToInt64(txtCuit.Text));

                if (d != null)
                {
                    Profesional.Nombre = string.IsNullOrWhiteSpace(d.RazonSocial) ? textInfo.ToTitleCase(d.Nombre.Trim().ToLower()) :
                                                                                    textInfo.ToTitleCase(d.RazonSocial.Trim().ToLower());
                    Profesional.DomicilioFiscal = textInfo.ToTitleCase(d.DomicilioFiscal.Trim().ToLower());
                    Profesional.IDIva = Convert.ToInt16(d.IDIva);
                    Profesional.InicioActividad = string.IsNullOrWhiteSpace(d.FechaInicio) ? DateTime.MinValue : Convert.ToDateTime(d.FechaInicio);
                }

                ctrls.RefrescarValorcontrols(Bindctrls);

                Enabled = true;
            }
            catch (Exception)
            {
                Enabled = true;
                return;
            }
        }
               
        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {                
                Bindctrls.Clear();

                Bindctrls.Add(txtNombre.DataBindings.Add("EditValue", Profesional, nameof(Profesional.Nombre)));                
                Bindctrls.Add(cmbCondIva.DataBindings.Add("EditValue", Profesional, nameof(Profesional.IDIva)));
                Bindctrls.Add(txtDomfiscal.DataBindings.Add("EditValue", Profesional, nameof(Profesional.DomicilioFiscal)));
                Bindctrls.Add(datInicioa.DataBindings.Add("EditValue", Profesional, nameof(Profesional.InicioActividad)));
                Bindctrls.Add(txtCuit.DataBindings.Add("EditValue", Profesional, nameof(Profesional.Cuit)));               
                
                txtIngresos.DataBindings.Add("EditValue", Profesional, nameof(Profesional.IngresosBrutos));
                spnPuntovta.DataBindings.Add("EditValue", Profesional, nameof(Profesional.PuntoVenta));
                tglProfesional.DataBindings.Add("EditValue", Profesional, nameof(Profesional.EsProfesional));
                tglLiquidacion.DataBindings.Add("EditValue", Profesional, nameof(Profesional.VisLiquidacion));
                tglAsociado.DataBindings.Add("EditValue", Profesional, nameof(Profesional.AsociadoAm));
                tglAceptadoIapos.DataBindings.Add("EditValue", Profesional, nameof(Profesional.TrabajaConIapos));

                txtEmail.DataBindings.Add("EditValue", Profesional, nameof(Profesional.EmailFacturas));
                txtMatriculaprv.DataBindings.Add("EditValue", Profesional, nameof(Profesional.MatriculaProv));
                txtLibro.DataBindings.Add("EditValue", Profesional, nameof(Profesional.Libro));
                txtFolio.DataBindings.Add("EditValue", Profesional, nameof(Profesional.Folio));

                cmbTitulo.DataBindings.Add("EditValue", Profesional, nameof(Profesional.IDTitulo));
                cmbCategoria.DataBindings.Add("EditValue", Profesional, nameof(Profesional.IDCategoria));
                cmbReferencia.DataBindings.Add("EditValue", Profesional, nameof(Profesional.IDReferencia));
                cmbUniversidad.DataBindings.Add("EditValue", Profesional, nameof(Profesional.IDUniversidad));

                txtMatriculanac.DataBindings.Add("EditValue", Profesional, nameof(Profesional.MatriculaNacional));
                                
                datNacimiento.DataBindings.Add("EditValue", Profesional, nameof(Profesional.FechaNacimiento));
                datIngrasoam.DataBindings.Add("EditValue", Profesional, nameof(Profesional.FechaIngreso));
                datGraduacion.DataBindings.Add("EditValue", Profesional, nameof(Profesional.FechaGraduacion));
                datVencimiento.DataBindings.Add("EditValue", Profesional, nameof(Profesional.VtoRegNacional));
                datVtoHabilitacion.DataBindings.Add("EditValue", Profesional, nameof(Profesional.VtoHabilitacion));

                txtCac.DataBindings.Add("EditValue", Profesional, nameof(Profesional.CodigoArteCurar));
                txtActa.DataBindings.Add("EditValue", Profesional, nameof(Profesional.NumeroActa));
                txtRegnacional.DataBindings.Add("EditValue", Profesional, nameof(Profesional.RegistroNacional));
                TxtObs.DataBindings.Add("EditValue", Profesional, nameof(Profesional.Observaciones));


                frmcontact.Direccioneslst.Clear();
                frmcontact.Direccioneslst = Profesional.Direcciones;
                frmcontact.IDProfesional = Profesional.IDRegistro;

                frmespe.Especialidadeslst.Clear();
                frmespe.Especialidadeslst = Profesional.Especialidades;
                frmespe.IDProfesional = Profesional.IDRegistro;

                frmprestataria.Prestatariaslst.Clear();
                frmprestataria.Prestatariaslst = Profesional.Prestatarias;
                frmprestataria.IDProfesional = Profesional.IDRegistro;

                frmcuentas.Cuentaslst.Clear();
                frmcuentas.Cuentaslst = Profesional.Cuentas;
                frmcuentas.IDProfesional = Profesional.IDRegistro;

                frmdiferencial.Diferenciallst.Clear();
                frmdiferencial.Diferenciallst = Profesional.Diferencial;
                frmdiferencial.IDProfesional = Profesional.IDRegistro;

                frmingresosbrutos.IngresosBrutos.Clear();
                frmingresosbrutos.IngresosBrutos = Profesional.RetencionIngresosBrutos;
                frmingresosbrutos.IDProfesional = Profesional.IDRegistro;

                frmimpuestoganancias.ImpuestoGanancias.Clear();
                frmimpuestoganancias.ImpuestoGanancias = Profesional.RetencionGanancias;
                frmimpuestoganancias.IDProfesional = Profesional.IDRegistro;

                frminstitutobecario.InstitutoBecario.Clear();
                frminstitutobecario.InstitutoBecario = Profesional.RetencionInstitutoBecario;
                frminstitutobecario.IDProfesional = Profesional.IDRegistro;

                frmcondicionfiscaliva.CondicionFiscalIva.Clear();
                frmcondicionfiscaliva.CondicionFiscalIva = Profesional.CategoriaCondicionesIva;
                frmcondicionfiscaliva.IDProfesional = Profesional.IDRegistro;

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
            
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
            CargaCombos(0);            
            txtCuit.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (Es_Popup) { prop.GuardarUbicacion(5, this); }            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //DEBE CONTENER NOMBRE
            if (string.IsNullOrWhiteSpace(Profesional.Nombre))
            {
                ctrls.MensajeInfo("Debe Ingresar un nombre.", 1);
                txtNombre.Focus();
                return;
            }

            //DEBE CONTENER CUIT
            if (Profesional.Cuit <= 0)
            {
                ctrls.MensajeInfo("Debe ingresar un número de documento.", 1);
                txtCuit.Focus();
                return;
            }

            //DEBE CONTENER UNA CONDICION DE IVA
            if (Profesional.IDIva <= 0)
            {
                ctrls.MensajeInfo("Debe seleccionar una condición de Iva.", 1);
                cmbCondIva.Focus();
                return;
            }

            //SI ES NUEVO, NO PUEDE TENER EL MISMO CUIT QUE OTROS REGISTROS 
            //TODO
            //QUITAR ESTA VALIDACION AL REMOVR LOS CUITS REPETIDOS
            if (Profesional.IDRegistro <= 0 && Profesional.ExisteregbyCuit() > 0)
            {
                ctrls.MensajeInfo("Éste cuit ya está registrado.", 1);
                txtCuit.Focus();
                return;
            }

            //SOCIO DIFERENCIAL
            if (Profesional.AsociadoDiferencial && Profesional.AsociadoAm)
            {
                ctrls.MensajeInfo("Un asociado Diferencial, no puede ser configurado como Socio Am hasta superar su fecha de finalización.", 1);
                return;
            }

            //VALIDO CONDICION IVA
            short idiva = Profesional.CategoriaCondicionesIva.OrderByDescending(o => o.FechaDesde).Select(s => s.IDCondicionIva).FirstOrDefault();

            if (idiva > 0 && Profesional.IDIva != idiva)
            {
                ctrls.MensajeInfo("La condicion de iva declarada no coincide con la establecida a la fecha.\n" +
                    "Se utilizará la condición asignada a la fecha.", 1);
                Profesional.IDIva = idiva;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Profesional.Abm();

            if (retorno.Count > 0)
            {
                string mensajes = "";

                foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                {
                    mensajes += $"{i.Trim()}\n";
                }

                if (!string.IsNullOrWhiteSpace(mensajes))
                { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }                
            }
            
            Continuacion();
        }

        private void txtCuit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                if (txtCuit.Text.ToString().Trim() == "") { return; }
                GetDatosAfip();
            }
        }

        private void cmbTitulo_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                Titulos.Vista.Frm_Titulo form = new Titulos.Vista.Frm_Titulo();

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CargaCombos(3);
                }
            }
        }

        private void cmbUniversidad_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {

                Universidades.Vista.Frm_Universidad form = new Universidades.Vista.Frm_Universidad();

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CargaCombos(5);
                }
            }
        }
                
        private void Frm_Profesional_FormClosed(object sender, FormClosedEventArgs e)
        {          
            if (!Es_Popup)
            {
                if (Parent is XtraTabPage)
                {
                    XtraTabPage c = Parent as XtraTabPage;
                    XtraTabControl x = c.Parent as XtraTabControl;
                    
                    x.TabPages.Remove(c);
                }
            }

            bc.Desconectar();
            SqlConnection.Dispose();
        }

        private void cmbKeydown(object sender, KeyEventArgs e)
        {
            LookUpEdit combo = sender as LookUpEdit;

            if (e.KeyCode == Keys.Delete)
            { combo.EditValue = 0; }
        }

        private void TxtObs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                
            }
        }
    }
}