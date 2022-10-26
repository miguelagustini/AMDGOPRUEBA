using AMDGOINT.Clases;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Profesionales.MC
{
    public class ExencionesPrint: INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE

        public string PrestadorNombre { get; set; } = "";
        public long PrestadorCuit { get; set; } = 0;
        public string PrestadorCuentaCodigo { get; set; } = "";
        public DateTime FechaDesde { get; set; } = DateTime.MinValue;
        public DateTime FechaHasta { get; set; } = DateTime.MinValue;
        public byte ExencionTipo { get; set; } = 0;
        public string ExencionTipoDescripcion
        {
            get
            {
                return ExencionTipo == 0 ? "Exencion Impuesto a las Ganancias" : ExencionTipo == 1 ? "Exencion Ingresos Brutos" : "";
            }
        }
        
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ExencionesPrint() { }

        public ExencionesPrint(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public ExencionesPrint Clone()
        {
            ExencionesPrint r = (ExencionesPrint)MemberwiseClone();            
            return r;

        }

        //CLONE CON LISTAS
        public List<ExencionesPrint> Clone(List<ExencionesPrint> lst)
        {
            List<ExencionesPrint> lista = new List<ExencionesPrint>();

            foreach (ExencionesPrint d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ExencionesPrint> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ExencionesPrint> lista = new List<ExencionesPrint>();

                string c = $"SELECT" +
                           $" PF.Nombre AS PrestadorNombre," +
                           $" PF.Cuit AS PrestadorCuit," +
                           $" PC.Codigo AS PrestadorCuentaCodigo," +
                           $" PG.FechaDesde AS FechaDesde," +
                           $" PG.FechaHasta AS FechaHasta," +
                           $" CAST(0 AS tinyint) AS ExencionTipo" +
                           $" FROM PROFEXRETGANANCIAS PG" +
                           $" LEFT OUTER JOIN PROFESIONALES PF ON(PF.ID_Registro = PG.IDProfesional)" +
                           $" LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                           $" WHERE SYSDATETIME() BETWEEN PG.FechaDesde AND PG.FechaHasta" +
                           $" UNION" +
                           $" SELECT" +
                           $" PF.Nombre AS PrestadorNombre," +
                           $" PF.Cuit AS PrestadorCuit," +
                           $" PC.Codigo AS PrestadorCuentaCodigo," +
                           $" PG.FechaDesde AS FechaDesde," +
                           $" PG.FechaHasta AS FechaHasta," +
                           $" CAST(1 AS tinyint) AS ExencionTipo" +
                           $" FROM PROFEXINSTITUTOBECARIO PG" +
                           $" LEFT OUTER JOIN PROFESIONALES PF ON(PF.ID_Registro = PG.IDProfesional)" +
                           $" LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                           $" WHERE SYSDATETIME() BETWEEN PG.FechaDesde AND PG.FechaHasta";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ExencionesPrint>(rdr));
                }
                
                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ExencionesPrint>();
            }
        }

        #endregion

        #region GENERA REPORTE

        public void GeneraReporte()
        {

            try
            {
                List<ExencionesPrint> Lista = new List<ExencionesPrint>();
                Lista.AddRange(GetRegistros());
                MuestraReporte(Lista);
            }
            catch (Exception e)
            {                
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los datos.\n{e.Message}", 1);
                return;
            }
        }

        private void MuestraReporte(List<ExencionesPrint> lst)
        {
            try
            {
                Vista.Xrpt_Exenciones rpt = new Vista.Xrpt_Exenciones();
                rpt.DataSource = lst;                
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.ShowPreviewDialog();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al moestrar el reporte.\n{e.Message}", 1);
                return;
            }
        }

        #endregion
    }
}
