using System.Collections;
using System.Windows.Forms;

namespace AMDGOINT.Clases
{
    class Propiedadesgral
    {

        public void GuardarUbicacion(short idconf, Form formulario)
        {
            switch (idconf)
            {
                //PRESTATARIAS
                case 1:
                    Properties.Settings.Default.PrestatariaWidth = formulario.Width;
                    Properties.Settings.Default.PrestatariaHeight = formulario.Height;
                    Properties.Settings.Default.PrestatariaLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //REPORTE
                case 2:
                    Properties.Settings.Default.ReporteWidth = formulario.Width;
                    Properties.Settings.Default.ReporteHeight = formulario.Height;
                    Properties.Settings.Default.ReporteLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //FACTURAS DET
                case 3:
                    Properties.Settings.Default.FacturaDetWidth = formulario.Width;
                    Properties.Settings.Default.FacturaDetHeight = formulario.Height;
                    Properties.Settings.Default.FacturaDetLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //NC PARAMETROS
                case 4:
                    Properties.Settings.Default.NcParamsWidth = formulario.Width;
                    Properties.Settings.Default.NcParamsHeight = formulario.Height;
                    Properties.Settings.Default.NcParamsLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //PROFESIONALES
                case 5:
                    Properties.Settings.Default.ProfesWidth = formulario.Width;
                    Properties.Settings.Default.ProfesHeight = formulario.Height;
                    Properties.Settings.Default.ProfesLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //PARAMETROS FACTURA DE CREDITO
                case 6:
                    Properties.Settings.Default.ParamsPFCWidth = formulario.Width;
                    Properties.Settings.Default.ParamsPFCHeight = formulario.Height;
                    Properties.Settings.Default.ParamsPFCLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //DETALLE DE PRESTATARIAS
                case 7:
                    Properties.Settings.Default.PresDetallesWidth = formulario.Width;
                    Properties.Settings.Default.PresDetallesHeight = formulario.Height;
                    Properties.Settings.Default.PresDetallesLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //Informacion General
                case 8:
                    Properties.Settings.Default.InfoGeneralWidth = formulario.Width;
                    Properties.Settings.Default.InfoGeneralHeight = formulario.Height;
                    Properties.Settings.Default.InfoGeneralLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //Factura Unica
                case 9:
                    Properties.Settings.Default.FacturaUnicWidth = formulario.Width;
                    Properties.Settings.Default.FacturaUnicHeight = formulario.Height;
                    Properties.Settings.Default.FacturaUnicLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;

                //Factura Unica Porfesional
                case 10:
                    Properties.Settings.Default.FactUnicProfWidth = formulario.Width;
                    Properties.Settings.Default.FactUnicProfHeight = formulario.Height;
                    Properties.Settings.Default.FactUnicProfLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //ESPECIALIDAD
                case 11:
                    Properties.Settings.Default.EspecialidadWidth = formulario.Width;
                    Properties.Settings.Default.EspecialidadHeight = formulario.Height;
                    Properties.Settings.Default.EspecialidadLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //PROFESIONALES PRESTATARIAS POPUP
                case 12:
                    Properties.Settings.Default.PrestPopupWidth = formulario.Width;
                    Properties.Settings.Default.PrestPopupHeight = formulario.Height;
                    Properties.Settings.Default.PrestPopupLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //PRACTICAS
                case 13:
                    Properties.Settings.Default.PracticasWidth = formulario.Width;
                    Properties.Settings.Default.PracticasHeight = formulario.Height;
                    Properties.Settings.Default.PracticasLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
                //EMPRESA
                case 14:
                    Properties.Settings.Default.EmpresaWidth = formulario.Width;
                    Properties.Settings.Default.EmpresaHeight = formulario.Height;
                    Properties.Settings.Default.EmpresaLocation = formulario.Location;
                    Properties.Settings.Default.Save();
                    break;
            }
        }

        public void RecuperaUbicacion(short idconf, Form formulario)
        { 
            switch (idconf)
            {
                //PRESTATARIAS
                case 1:
                    //UBICACION
                    formulario.Width = Properties.Settings.Default.PrestatariaWidth;
                    formulario.Height = Properties.Settings.Default.PrestatariaHeight;
                    formulario.Location = Properties.Settings.Default.PrestatariaLocation;
                    break;
                //REPORTE
                case 2:
                    //UBICACION
                    formulario.Width = Properties.Settings.Default.ReporteWidth;
                    formulario.Height = Properties.Settings.Default.ReporteHeight;
                    formulario.Location = Properties.Settings.Default.ReporteLocation;
                    break;
                //FACTURAS DET
                case 3:
                    //UBICACION
                    formulario.Width = Properties.Settings.Default.FacturaDetWidth;
                    formulario.Height = Properties.Settings.Default.FacturaDetHeight;
                    formulario.Location = Properties.Settings.Default.FacturaDetLocation;
                    break;
                //NC PARAMETROS
                case 4:
                    //UBICACION
                    formulario.Width = Properties.Settings.Default.NcParamsWidth;
                    formulario.Height = Properties.Settings.Default.NcParamsHeight;
                    formulario.Location = Properties.Settings.Default.NcParamsLocation;
                    break;
                //PROFESIONALES
                case 5:
                    //UBICACION
                    formulario.Width = Properties.Settings.Default.ProfesWidth;
                    formulario.Height = Properties.Settings.Default.ProfesHeight;
                    formulario.Location = Properties.Settings.Default.ProfesLocation;
                    break;
                //PARAMETROS FACTURA DE CREDITO
                case 6:                    
                    formulario.Width = Properties.Settings.Default.ParamsPFCWidth;
                    formulario.Height = Properties.Settings.Default.ParamsPFCHeight;
                    formulario.Location = Properties.Settings.Default.ParamsPFCLocation;
                    break;
                //DETALLE DE PRESTATARIAS
                case 7:
                    formulario.Width = Properties.Settings.Default.PresDetallesWidth;
                    formulario.Height = Properties.Settings.Default.PresDetallesHeight;
                    formulario.Location = Properties.Settings.Default.PresDetallesLocation;
                    break;
                //INFORMACION GENERAL
                case 8:
                    formulario.Width = Properties.Settings.Default.InfoGeneralWidth;
                    formulario.Height = Properties.Settings.Default.InfoGeneralHeight;
                    formulario.Location = Properties.Settings.Default.InfoGeneralLocation;
                    break;
                //Factura Unica Prestataria
                case 9:
                    formulario.Width = Properties.Settings.Default.FacturaUnicWidth;
                    formulario.Height = Properties.Settings.Default.FacturaUnicHeight;
                    formulario.Location = Properties.Settings.Default.FacturaUnicLocation;
                    break;

                //Factura Unica Prestador
                case 10:
                    formulario.Width = Properties.Settings.Default.FactUnicProfWidth;
                    formulario.Height = Properties.Settings.Default.FactUnicProfHeight;
                    formulario.Location = Properties.Settings.Default.FactUnicProfLocation;
                    break;
                //ESPECIALIDADES
                case 11:
                    formulario.Width = Properties.Settings.Default.EspecialidadWidth;
                    formulario.Height = Properties.Settings.Default.EspecialidadHeight;
                    formulario.Location = Properties.Settings.Default.EspecialidadLocation;
                    break;
                //PRESTATARIAS PROFESIONA POPUP
                case 12:
                    formulario.Width = Properties.Settings.Default.PrestPopupWidth;
                    formulario.Height = Properties.Settings.Default.PrestPopupHeight;
                    formulario.Location = Properties.Settings.Default.PrestPopupLocation;
                    break;
                //PRACTICAS
                case 13:
                    formulario.Width = Properties.Settings.Default.PracticasWidth;
                    formulario.Height = Properties.Settings.Default.PracticasHeight;
                    formulario.Location = Properties.Settings.Default.PracticasLocation;
                    break;
                //EMPRESA
                case 14:
                    formulario.Width = Properties.Settings.Default.EmpresaWidth;
                    formulario.Height = Properties.Settings.Default.EmpresaHeight;
                    formulario.Location = Properties.Settings.Default.EmpresaLocation;
                    break;
            }
        }
        
    }
}
