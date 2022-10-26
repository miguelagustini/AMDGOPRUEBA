using AMDGOINT.Clases;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Configuracion.Usuarios
{
    public partial class Frm_Usuarios : Form
    {
        public bool Es_Popup { get; set; } = false;
        public int IDregistro { get; set; } = 0;
        public int Idgrupo { get; set; } = 0;

        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        public Frm_Usuarios()
        {
            InitializeComponent();
        }
        
        #region REDIMENSIONAMIENTO DEL FORMULARIO
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.pnlBase.Region = region;
            this.Invalidate();



        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        #region METODOS MANUALES

        //ABM 
        private void ABM(string accion)
        {
            try
            {
                ArrayList parametros = new ArrayList();
                ArrayList campos = new ArrayList();

                campos.Add("ID_Grupo");
                campos.Add("Usuario");
                campos.Add("Nick");
                campos.Add("Contrasena");
                campos.Add("Administrador");

                if (accion == "I")
                {
                    campos.Add("ID_UsuNew");
                    campos.Add("TimeNew");
                }

                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");

                parametros.Add(Idgrupo);
                parametros.Add(txtNombre.Text.ToString().Trim());
                parametros.Add(txtNick.Text.ToString().Trim());
                parametros.Add(txtPassword.Text.ToString().Trim());
                parametros.Add(chkAdministrador.EditValue);

                if (accion == "I") { parametros.Add(0); parametros.Add(func.Getfechorserver()); }
                parametros.Add(0); parametros.Add(func.Getfechorserver());

                //LLAMO AL METODO QUE SE ENCARGA DE GUARDAR / MODIFICAR LOS DATOS
                func.AccionBD(campos, parametros, accion, "USUARIOS", IDregistro, "ID_Registro");

                ProcesoContinuacion(accion);
                
            }
            catch (Exception e)
            {

                MessageBox.Show("Ocurrió un error al procesar el registro.\n"
                    + e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }              

        //CARGO LOS REGISTROS EN CASO DE INICIAR CON ID
        private void CargarRegistros()
        {
            try
            {
                string consulta = "SELECT Usuario, Nick, Contrasena, Administrador" +
                    " FROM USUARIOS WHERE ID_Registro = " + IDregistro;

                foreach(DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    txtNombre.Text = fila["Usuario"].ToString();
                    txtNick.Text = fila["Nick"].ToString();
                    txtPassword.Text = fila["Contrasena"].ToString();
                    chkAdministrador.EditValue = Convert.ToBoolean(fila["Administrador"]);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al cargar el registro.\n"
                    + e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }        

        //PROCESO LA CONTINUACION DESPUES DEL ABM
        private void ProcesoContinuacion(string accion)
        {
            try
            {
                //SOLO SI SE HIZO UN INSERT CONSULTO EL ID DEL NUEVO REGISTRO
                if (accion == "I") { Asignanuevoid(); }

                DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrió un error al procesar el registro.\n"
                    + e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //OBTENGO EL NUEVO ID GENERADO EN EL INSERT
        private void Asignanuevoid()
        {
            try
            {
                string consulta = "SELECT ID_Registro FROM USUARIOS WHERE Nick = '" + txtNombre.Text.Trim() + "'";

                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    IDregistro = Convert.ToInt32(fila["ID_Registro"]);
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
            if (Es_Popup)
            {                
                //UBICACION
                this.Width =  Properties.Settings.Default.UsuariosWidth;
                this.Height = Properties.Settings.Default.UsuariosHeight;
                this.Location = Properties.Settings.Default.UsuariosLocation;
            }

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            if (IDregistro > 0) { CargarRegistros(); }
        }

        //VALIDA SI EXISTE EL GRUPO
        private bool ExisteNick()
        {
            try
            {
                string consulta = "SELECT * FROM USUARIOS WHERE (Nick = '" + txtNombre.Text.Trim() + "')"
                    + " AND (ID_Registro <> " + IDregistro + ") AND (Estadoreg = 1)";

                if (func.getColecciondatos(consulta).Rows.Count > 0) { return true; } else { return false; }

            }
            catch (Exception e)
            {

                MessageBox.Show("Ocurrió un error al consultar la existencia del grupo.\n" + 
                    e.Message, "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        //********************************************************************
        //**********************   EVENTOS FORM   ****************************
        //********************************************************************
        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_Usuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GUARDO EL TAMAÑO USADO SI ES POPUP
            if (Es_Popup)
            {
                Properties.Settings.Default.UsuariosWidth = this.Width;
                Properties.Settings.Default.UsuariosHeight = this.Height;
                Properties.Settings.Default.UsuariosLocation = this.Location;
                Properties.Settings.Default.Save();
            }
        }

        private void Frm_Usuarios_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        //********************************************************************
        //**********************   EVENTOS CONTROLES   ****************************
        //********************************************************************
        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Es_Popup)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            IDregistro = 0;
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Idgrupo <= 0)
            {
                MessageBox.Show("No puede guardar un usuario sin un grupo.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtNombre.Text.ToString() == "")
            {
                MessageBox.Show("Debe ingresar un Nombre para continuar.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return;
            }

            if (txtNick.Text.ToString() == "")
            {
                MessageBox.Show("Debe ingresar un nick para continuar.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNick.Focus();
                return;
            }

            if (txtPassword.Text.ToString() == "")
            {
                MessageBox.Show("Debe ingresar una contraseña para continuar.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            if (ExisteNick())
            {
                MessageBox.Show("Éste Nick ya existe.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNick.Focus();
                return;
            }

            if (IDregistro > 0) { ABM("U"); } else { ABM("I"); }
        }

        private void tglVerpass_Toggled(object sender, EventArgs e)
        {
            txtPassword.Properties.PasswordChar = (txtPassword.Properties.PasswordChar == '*') ? '\0' : '*';
        }
    }
}
