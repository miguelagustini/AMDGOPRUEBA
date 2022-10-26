using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AMDGOINT.Clases
{
    class ConexionBD
    {
        //CADENA DE CONEXION                
        
        //private static string Cadena { get; } = "Persist Security Info=False;User ID = sa; Password=Am2016; Initial Catalog = AmdgoInterno; Server=181.10.27.235,2526; MultipleActiveResultSets=True";
        private static string Cadena { get; } = @"Persist Security Info=False;User ID = sa; Password=Am2016; Initial Catalog = AmdgoInterno; Data Source=192.168.1.241,1433; MultipleActiveResultSets=True";
        private static string CadenaDos { get; } = @"Persist Security Info=False;User ID = sa; Password=Am2016; Initial Catalog = AmdgoContable; Data Source=192.168.1.241,1433; MultipleActiveResultSets=True";

        public string Getcadena { get; } = Cadena;
        public string GetcadenaDos { get; } = CadenaDos;

        //INICIALIZADOR DE CONEXION
        private SqlConnection cn = new SqlConnection(Cadena);
        private SqlConnection cncontabilidad = new SqlConnection(CadenaDos);

        //METODO DE CONEXION DE LA BASE DE DATOS
        public SqlConnection Conectar()
        {
            try
            {
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                }

                return cn;

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                return cn;
            }
        }

        //METODO DE DESCONEXION DE LA BASE DE DATOS
        public void Desconectar()
        {
            try
            {
                if (cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }

            }
            catch (Exception)
            {
                
            }
        }


        //METODO DE CONEXION DE LA BASE DE DATOS
        public SqlConnection ConectarContabilidad()
        {
            try
            {
                if (cncontabilidad.State != System.Data.ConnectionState.Open)
                {
                    cncontabilidad.Open();
                }

                return cncontabilidad;

            }
            catch (Exception)
            {
                return cncontabilidad;
            }
        }

        //METODO DE DESCONEXION DE LA BASE DE DATOS
        public void DesconectarContabilidad()
        {
            try
            {
                if (cncontabilidad.State != System.Data.ConnectionState.Closed)
                {
                    cncontabilidad.Close();
                }

            }
            catch (Exception)
            {

            }
        }
    }


    public class ConexionAmdgoSis
    {
        //CADENA DE CONEXION        
        private static string Cadena { get; } = "Persist Security Info=False;User ID = sa; Password=Am2016; Initial Catalog = AmdgoSis; Data Source=192.168.1.241,1433; MultipleActiveResultSets=True";

        public string Getcadena { get; } = Cadena;

        //INICIALIZADOR DE CONEXION
        private SqlConnection cn = new SqlConnection(Cadena);

        //METODO DE CONEXION DE LA BASE DE DATOS
        public SqlConnection Conectar()
        {
            try
            {
                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                }

                return cn;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        //METODO DE DESCONEXION DE LA BASE DE DATOS
        public void Desconectar()
        {
            try
            {
                if (cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }
    }
}
