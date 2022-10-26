using System;
using System.IO;
using System.Windows.Forms;

namespace AMDGOINTSTART.Clases
{
    class Updater
    {
        private static string UpdateExe = @"\\192.168.1.247\DATOS\General\SISTEMAS\sisupdater\AmdgoInterno\AMDGOINT.exe";
        private static string CurrentExe = Application.StartupPath + @"\AMDGOINT.exe";
        

        public bool ValidaVersion()
        {
            try
            {
                bool retorno = false;
                if (CurrentExe == "" || UpdateExe == "") { return retorno ; }

                if (File.Exists(UpdateExe))
                {                    

                    if(File.GetLastWriteTime(UpdateExe) > File.GetLastWriteTime(CurrentExe))
                    {
                        retorno = true;
                    }

                }

                return retorno;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Actualiza()
        {
            try
            {
                //SI NO EXISTE LA CARPETA BACKUP, CREO UNA
                if (!Directory.Exists(Application.StartupPath + @"\BackUp"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\BackUp");
                }

                //COPIO EL ARCHIVO A LA CARPETA BACK
                if (File.Exists(CurrentExe))
                { File.Copy(CurrentExe, Application.StartupPath + @"\BackUp\AMDGOINT " + DateTime.Today.ToString("dd-MM-yyyy") + ".exe", true); }
                                        

                //SOBREESCRIBO EL NUEVO
                File.Copy(UpdateExe, Application.StartupPath + @"\AMDGOINT.exe", true);
            }
            catch (Exception)
            {

                return;
            }
            
        }
    }
}
