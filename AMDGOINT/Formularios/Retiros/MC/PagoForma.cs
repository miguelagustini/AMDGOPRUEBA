using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Retiros.MC
{
    public class PagoForma
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();        

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[PAGOFORMAS]";

        private byte _idregistro = 0;        
        private string _codigo = "";
        private string _descripcion = "";        

        public byte IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = _codigo != value.Trim() ? value.Trim() : _codigo; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion; }
        }
             
        public string CodigoDescripcion
        {
            get { return Codigo + " - " + Descripcion; }
        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public PagoForma() { }

        public PagoForma(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region EVENTOS DE LA CLASE

        //CLONACION
        #region CLONE

        //CLONE 
        public PagoForma Clone()
        {
            PagoForma d = (PagoForma)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<PagoForma> Clone(List<PagoForma> lst)
        {
            List<PagoForma> lista = new List<PagoForma>();

            foreach (PagoForma d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<PagoForma> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<PagoForma> lista = new List<PagoForma>();

                string c = $"SELECT PG.IDRegistro, PG.Codigo, PG.Descripcion FROM {tablaname} PG";                           

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    PagoForma a = new PagoForma();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<PagoForma>();
            }
        }

        #endregion
                
        #endregion
    }
}
