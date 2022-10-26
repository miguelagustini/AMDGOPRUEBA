using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AMDGOINTSTART.Clases;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace AMDGOINTSTART.Formularios.Inicio
{
    public partial class Frm_Landing : SplashScreen
    {
        
        public Frm_Landing()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2020-" + DateTime.Now.Year.ToString();
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


        private void Frm_Landing_Shown(object sender, EventArgs e)
        {            
            labelStatus.Text = "Comprobando Actualizaciones...";
            bgWorker.RunWorkerAsync();
            
        }
             
        private void Frm_Landing_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Updater udp = new Updater();
            if (udp.ValidaVersion()) { udp.Actualiza(); }
            
            if (!File.Exists(Application.StartupPath + @"\AMDGOINT.exe"))
            {
                MessageBox.Show("No logramos establecer conexión con el servidor,\n" +
                  " la aplicación no se iniciará a menos que se actualice");
            }
            else
            {
                if(Environment.GetCommandLineArgs().Length > 1)
                {
                    Process.Start(Application.StartupPath + @"\AMDGOINT.exe", Environment.GetCommandLineArgs()[1].ToString());
                    //Process.Start(Application.StartupPath + @"\AMDGOINT.exe", "36579048");
                                        
                }
                else
                {
                    Process.Start(Application.StartupPath + @"\AMDGOINT.exe");
                }
                
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Application.Exit();
        }
    }
}