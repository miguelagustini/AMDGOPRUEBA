using AMDGOINT.Clases;
using AMDGOINT.Formularios.Principal;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AMDGOINT
{
    static class Program
    {        
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
                
        static void Main()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            Frm_Landing cargasplash = new Frm_Landing();
            Funciones func = new Funciones();
            Globales glb = new Globales();

            if (Environment.GetCommandLineArgs().Length > 1)
            {
                func.SetIdusuariolog(Environment.GetCommandLineArgs()[1].ToString());

                if (glb.GetIdUsuariolog() <= 0)
                {
                    MessageBox.Show("No hay información de Usuario.", "Amdgo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    Application.Run(new Frm_Main());
                }
            }
            else
            {
                if (cargasplash.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Frm_Main());
                }
                else
                {
                    MessageBox.Show("No se pudo acceder a la base de datos.", "Amdgo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            
        }
    }
}
