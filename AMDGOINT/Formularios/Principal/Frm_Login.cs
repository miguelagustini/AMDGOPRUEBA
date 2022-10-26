using System;
using System.Data;
using System.Windows.Forms;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Principal
{
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        private Globales globales = new Globales();
        private Funciones func = new Funciones();
        private Controles ctrls = new Controles();

        private bool cierreautomat = false;

        public Frm_Login()
        {
            InitializeComponent();
            pnlTransparent.Parent = pictureBox1;            
        }

        #region METODOS MANUALES

        //VALIDO EL USUARIO
        private void ValidaUsuarios()
        {
            try
            {
                short contador = 0;

                string consulta = "SELECT ID_Registro, Usuario, Estadoreg, Supervisor" +
                    " FROM USUARIOS" +
                    " WHERE Nick = '" + txtUsuario.Text.ToString().Trim() + "' AND" +
                    " Contrasena = '" + txtPassword.Text.ToString().Trim() + "'";

                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    if (Convert.ToInt32(fila["ID_Registro"]) > 0)
                    {
                        if (Convert.ToBoolean(fila["Estadoreg"]))
                        {
                            globales.SetIdUsuariolog(Convert.ToInt32(fila["ID_Registro"]));
                            globales.SetNomUsuariolog(fila["Usuario"].ToString());
                            globales.SetUsuariosuper(Convert.ToBoolean(fila["Supervisor"]));
                            contador++;
                        }
                        else { contador--; }
                        
                    }
                    
                }

                if (contador <= 0)
                {
                    if (contador < 0) { ctrls.MensajeInfo("Éste usuario fue dado de baja.", 1); }
                    else { ctrls.MensajeInfo("Usuario o Contraseña Incorrectos.\n" + "Intente de nuevo.", 1); }
                        
                    txtUsuario.Focus();
                    globales.SetIdUsuariolog(0);
                    globales.SetNomUsuariolog("");
                    globales.SetUsuariosuper(false);
                    return;
                }
                else
                {
                    cierreautomat = true;
                    DialogResult = DialogResult.OK;
                }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al validar el usuario.\n" + e.Message, 0);                
                return;
            }
        }

        #endregion

        private void Frm_Login_Shown(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cierreautomat && globales.GetIdUsuariolog() <= 0 &&
                ctrls.MensajePregunta("¿Desea salir de la aplicación?") == DialogResult.No)
            {
                txtUsuario.Focus();                
                e.Cancel = true;                
            }            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                ctrls.MensajeInfo("Ingrese un Usuario.", 1);                
                txtUsuario.Focus();
                return;
            }

            if (txtPassword.Text == "")
            {
                ctrls.MensajeInfo("Ingrese una Contraseña.", 1);                
                txtPassword.Focus();
                return;
            }

            ValidaUsuarios();
        }
    }
}