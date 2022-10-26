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

namespace AMDGOINT.Formularios.Configuracion.Permisos.MC
{
    public class Permiso : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "PERMISOS";

        private int _idregistro = 0;
        private string _formulario = "";
        private string _clave = "";
        private string _descripcion = "";
        private bool _acceso = false;
        private int _idusuario = 0;
        
        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro;  }
        }

        public string Formulario
        {
            get { return _formulario; }
            set { _formulario = _formulario != value.Trim() ? value.Trim() : _formulario; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = _clave != value.Trim() ? value.Trim() : _clave; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = _descripcion != value.Trim() ? value.Trim() : _descripcion; }
        }

        public bool Acceso
        {
            get { return _acceso; }
            set { _acceso = _acceso != value ? value : _acceso; }
        }

        public int UsuarioID
        {
            get { return _idusuario; }
            set { _idusuario = _idusuario != value ? value : _idusuario; }
        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Permiso() { }

        public Permiso(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region EVENTOS DE LA CLASE

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
        public Permiso Clone()
        {
            Permiso d = (Permiso)MemberwiseClone();
            return d;
        }

        #endregion
                
        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS
        public List<Permiso> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Permiso> lista = new List<Permiso>();

                string c = $"SELECT ID_Registro AS IDRegistro, Formulario, Clave, Descripcion FROM {tablaname}";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Permiso a = new Permiso();

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
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Permiso>();
            }
        }

        public List<Permiso> GetPermisoUsuario()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Permiso> lista = new List<Permiso>();
                                
                string c = $"SELECT PE.ID_Registro AS IDRegistro, PE.Formulario, PE.Clave, PE.Descripcion, RO.Acceso, US.ID_Registro AS UsuarioID" +
                                  $" FROM USUARIOS US" +
                                  $" LEFT OUTER JOIN ROLESGRUPO RO ON(RO.ID_Grupo = US.ID_Grupo)" +
                                  $" LEFT OUTER JOIN PERMISOS PE ON(PE.ID_Registro = RO.ID_Permiso)" +
                                  $" WHERE Estadoreg = 1";

                //OBTENGO LA TABLA
                //DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                DataTable tbl = func.getColecciondatos(c, glb.GetConexion());

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Permiso a = new Permiso();

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
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Permiso>();
            }
        }

        #endregion
    }
}
