using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Facturas.ResumenInformesGral.MC
{
    public class FacturacionResumen : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        public string _filterperiodo { get; set; } = "";
        public string _filterctaprestataria { get; set; } = "";
        public string Periodo { get; set; } = "";
        public string ProfesionalCuentaCodigo { get; set; } = "";
        public string ProfesionalCuentaNombre { get; set; } = "";
        public string PracticaCodigo { get; set; } = "";
        public string PracticaDescripcion { get; set; } = "";
        public string PracticaFuncion { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal ImporteHonorarios { get; set; } = 0;
        public decimal ImporteGastos { get; set; } = 0;
        public decimal ImporteMedicamentos { get; set; } = 0;
        public decimal ImporteNeto { get; set; } = 0;
        public decimal ImporteIva { get; set; } = 0;
        public decimal ImporteTotal { get; set; } = 0;
        
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public FacturacionResumen() { }

        public FacturacionResumen(SqlConnection conexion)
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
        public FacturacionResumen Clone()
        {
            FacturacionResumen r = (FacturacionResumen)MemberwiseClone();
            return r;

        }

        //CLONE CON LISTAS
        public List<FacturacionResumen> Clone(List<FacturacionResumen> lst)
        {
            List<FacturacionResumen> lista = new List<FacturacionResumen>();

            foreach (FacturacionResumen d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<FacturacionResumen> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<FacturacionResumen> lista = new List<FacturacionResumen>();

                string c = $"SELECT" +
                           $" ISNULL(TR.movppefa, '') as Periodo," +
                           $" ISNULL(TR.movpcopr, '') AS ProfesionalCuentaCodigo," +
                           $" ISNULL(AP.PROFAPNO, '') AS ProfesionalCuentaNombre," +
                           $" ISNULL(TR.movpprac, '') as PracticaCodigo," +
                           $" ISNULL(TR.movpdesc, '') as PracticaDescripcion," +
                           $" ISNULL(TR.MOVPFUNC, '') AS PracticaFuncion," +
                           $" SUM(TR.movpcant) AS Cantidad," +
                           $" SUM(TR.movphono) as ImporteHonorarios," +
                           $" SUM(TR.movpgast) AS ImporteGastos," +
                           $" SUM(TR.movpmedi) AS ImporteMedicamentos," +
                           $" SUM(TR.movpneto) AS ImporteNeto," +
                           $" SUM(TR.movpiiva) AS ImporteIva," +
                           $" SUM(TR.movptoim) AS ImporteTotal" +
                           $" FROM AmdgoSis.dbo.ASOCTRAN TR" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF AP ON(AP.PROFCODI = TR.movpcopr)" +
                           $" WHERE TR.movppefa like '{_filterperiodo}%' AND TR.movpcdob = '{_filterctaprestataria}'" +
                           $" GROUP BY TR.movppefa, TR.movpcopr, AP.PROFAPNO, TR.movpprac, TR.movpdesc, TR.MOVPFUNC"; 

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<FacturacionResumen>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<FacturacionResumen>();
            }
        }
              
        #endregion

    }
}
