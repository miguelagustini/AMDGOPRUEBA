using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.AsientosContables.MC
{
    public class ReporteDet : AsientosDet, INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();


        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        public int IDCalculado { get; set; } = 0; //UTILIZADO PARA ORDEN CORRECTO DE CALCULOS SALDO
        public int IDCuentaAgrupadora { get; set; } = 0;        
        public string Observacion { get; set; } = string.Empty;
        public decimal Saldo { get; set; } = 0;
        public bool AsientoCierre { get; set; } = false;
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ReporteDet()
        {

        }

        public ReporteDet(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

        //EVENTOS DE PROPERTY CHANGED
        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public new ReporteDet Clone()
        {
            ReporteDet d = (ReporteDet)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<ReporteDet> Clone(List<ReporteDet> lst)
        {
            List<ReporteDet> lista = new List<ReporteDet>();
            lst.ForEach(f => lista.Add(f.Clone()));

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ReporteDet> GetRegistros(DateTime fdesde, DateTime fhasta, int _plancuentaid = 0, int _plansubcuentaid = 0, bool _usarangofechas = true, string _histoactual = "A")
        {
            try
            {               
                                
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReporteDet> lista = new List<ReporteDet>();

                string c = $"SELECT ME.AsientoNumero, ME.AsientoFecha, MD.IDRegistro, MD.IDEncabezado, MD.MovimientoCajaID, MD.PlanCuentaID, MD.PlanSubCuentaID, MD.Descripcion, MD.FechaConciliacion," +
                           $" MD.ImporteDebe, MD.ImporteHaber, ISNULL(PC.CodigoCorto, '') AS PlanCuentaCodigoCorto, ISNULL(PC.CodigoLargo, '') AS PlanCuentaCodigoLargo," +
                           $" ISNULL(PC.Descripcion, '') AS PlanCuentaNombre, ISNULL(PSC.Codigo, '') AS PlanSubCuentaCodigoCorto, ISNULL(PSC.Descripcion, '') AS PlanSubCuentaNombre, MD.PaseNumero," +
                           $" ME.Observacion, PC.IDCuentaAgrupadora, ME.AsientoCierre" +
                           $" FROM {tablaname} MD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANCUENTAS] PC ON(PC.IDRegistro = MD.PlanCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANSUBCUENTAS] PSC ON(PSC.IDRegistro = MD.PlanSubCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[ts_ASIENTOSCNTBLENC] ME ON(ME.IDRegistro = MD.IDEncabezado)" +
                           $" WHERE " +
                           $" {(_histoactual == "A" ? "ME.FechaCierreAnual IS NULL" : "FORMAT(ME.FechaCierreAnual, 'yyyy') = " + (fdesde.Year+1))}" + //EJERCICIO EN CURSO U OTROS, 
                           $" {(_usarangofechas ? " AND (ME.AsientoFecha BETWEEN '" + fdesde + "' AND '" + fhasta + "')" : "")} " + // DESDE HASTA                           
                           $" {(_plancuentaid > 0 ? "AND MD.PlanCuentaID = " + _plancuentaid : "")}" +
                           $" {(_plansubcuentaid > 0 ? "AND MD.PlanSubCuentaID = " + _plansubcuentaid : "")};";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReporteDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ReporteDet>();
            }
        }

        #endregion

    }
}
