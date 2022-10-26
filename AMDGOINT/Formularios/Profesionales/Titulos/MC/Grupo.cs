using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Profesionales.Titulos.MC
{
    public class Grupo: INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();        
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "PROFTITULOSGRUPO";

        private short idregistro = 0;
        private string descripcion = "";
        
        public short IDRegistro
        {
            get { return idregistro; }
            set
            {
                if (idregistro != value)
                {
                    idregistro = value;
                }
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (descripcion != value.Trim())
                {
                    descripcion = value.Trim();

                }
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
      
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Grupo() { }

        public Grupo(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //EVENTOS
        #region EVENTOS Y  METODOS

        //PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #region CLONACION
        
        //CLONE 
        public Grupo Clone()
        {
            Grupo d = (Grupo)MemberwiseClone();

            return d;

        }

        //CLONE CON LISTAS
        public List<Grupo> Clone(List<Grupo> lst)
        {
            List<Grupo> lista = new List<Grupo>();

            foreach (Grupo d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        #region CONSULTA DE DATOS

        //RETORNO LISTA 
        public List<Grupo> GetRegistros()
        {
            try
            {
                List<Grupo> lista = new List<Grupo>();

                string c = $"SELECT ID_Registro AS IDRegistro, Descripcion FROM {tablaname}";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Grupo a = new Grupo();

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
                ctrl.MensajeInfo($"Ocurrió un error al consultar los grupos.\n{e.Message}", 0);
                return new List<Grupo>();
            }
        }

        #endregion

        #endregion

    }
}
