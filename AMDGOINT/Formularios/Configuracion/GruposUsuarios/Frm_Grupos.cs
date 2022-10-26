using AMDGOINT.Clases;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Configuracion.GruposUsuarios
{
    public partial class Frm_Grupos : Form
    {
        public bool Es_Popup { get; set; } = false;
        public int IDregistro { get; set; } = 0;

        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();

        public Frm_Grupos()
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


                campos.Add("Descripcion");

                if (accion == "I")
                {
                    campos.Add("ID_UsuNew");
                    campos.Add("TimeNew");
                }

                campos.Add("ID_UsuModif");
                campos.Add("TimeModif");

                parametros.Add(txtDescripcion.Text.ToString().Trim());

                if (accion == "I") { parametros.Add(0); parametros.Add(func.Getfechorserver()); }
                parametros.Add(0); parametros.Add(func.Getfechorserver());

                //LLAMO AL METODO QUE SE ENCARGA DE GUARDAR / MODIFICAR LOS DATOS
                func.AccionBD(campos, parametros, accion, "USUGRUPOS", IDregistro, "ID_Registro");

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
                string consulta = "SELECT Descripcion FROM USUGRUPOS WHERE ID_Registro = " + IDregistro;

                foreach(DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    txtDescripcion.Text = fila["Descripcion"].ToString();
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
                string consulta = "SELECT ID_Registro FROM USUGRUPOS WHERE Descripcion = '" + txtDescripcion.Text.Trim() + "'";

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
                prop.RecuperaUbicacion(2, this);
            }

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            if (IDregistro > 0) { CargarRegistros(); }
        }

        //VALIDA SI EXISTE EL GRUPO
        private bool ExisteGrupo()
        {
            try
            {
                string consulta = "SELECT * FROM USUGRUPOS WHERE (Descripcion = '" + txtDescripcion.Text.Trim() + "')"
                    + " AND (ID_Registro <> " + IDregistro + ")";

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
        private void Frm_Grupos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_Grupos_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GUARDO EL TAMAÑO USADO SI ES POPUP
            if (Es_Popup)
            {
                prop.GuardarUbicacion(2, this);
            }
        }

        private void Frm_Grupos_Shown(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
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
            if (txtDescripcion.Text.ToString() == "")
            {
                MessageBox.Show("Debe ingresar una descripción para continuar.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return;
            }

            if (ExisteGrupo())
            {
                MessageBox.Show("Éste grupo ya existe.", "Amdgo Mutual", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return;
            }

            if (IDregistro > 0) { ABM("U"); } else { ABM("I"); }
        }
    }
}
