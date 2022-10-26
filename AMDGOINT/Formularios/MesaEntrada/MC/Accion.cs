using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.MesaEntrada.MC
{
    public class Accion
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();        

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "DOCUMENTALACC";

        private byte _idregistro = 0;                
        private string _descripcion = "";        

        public byte IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion; }
        }
             
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Accion() { }

        public Accion(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region EVENTOS DE LA CLASE

        //CLONACION
        #region CLONE

        //CLONE 
        public Accion Clone()
        {
            Accion d = (Accion)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Accion> Clone(List<Accion> lst)
        {
            List<Accion> lista = new List<Accion>();

            foreach (Accion d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Accion> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Accion> lista = new List<Accion>();

                string c = $"SELECT IDRegistro, Descripcion FROM {tablaname}";                           

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Accion a = new Accion();

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
                return new List<Accion>();
            }
        }

        #endregion
                
        #endregion
    }
}
