using System;
using DevExpress.XtraSplashScreen;
using System.Windows.Forms;
using AMDGOINT.Clases;
using System.Threading;

namespace AMDGOINT.Formularios.Principal
{
    public partial class Frm_Landing : SplashScreen
    {
        private Funciones func = new Funciones();

        public Frm_Landing()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Amdgo - Copyright © 2020-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion
        
        public enum SplashScreenCommand
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool res = true;
            
            //VALIDO LA CONEXION CON LA BASE DE DATOS
            /*if (!func.hayConexion())
            {
                //res = false;
            }*/
          
            if (res) { this.DialogResult = DialogResult.OK; }
            else {  this.DialogResult = DialogResult.Abort; }

            timer.Stop();
        }

        private void Frm_Landing_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}