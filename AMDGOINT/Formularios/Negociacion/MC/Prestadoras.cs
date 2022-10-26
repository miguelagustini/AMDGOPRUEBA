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

namespace AMDGOINT.Formularios.Negociacion.MC
{
    public class Prestadoras : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion
        private static string tablaname = "PRESTDETALLES";

        private string _codigo = "";
        private string _abreviatura = "";
        private string _nombrefiscal = "";
        private long _cuit = 0;
        private int _idencabezado = 0;
        private int _idagrupador = 0;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = _codigo != value.Trim() ? value.Trim() : _codigo; }
        }


        public string Abreviatura
        {
            get { return _abreviatura; }
            set { _abreviatura = _abreviatura != value.Trim() ? value.Trim() : _abreviatura; }
        }

        public string NombreFiscal
        {
            get { return _nombrefiscal; }
            set { _nombrefiscal = _nombrefiscal != value.Trim() ? value.Trim() : _nombrefiscal; }
        }

        public long Cuit
        {
            get { return _cuit; }
            set { _cuit = _cuit != value ? value : _cuit; }
        }

        public int IDEncabezado
        {
            get { return _idencabezado; }
            set { _idencabezado = _idencabezado != value ? value : _idencabezado; }
        }

        public int AgrupadorID
        {
            get { return _idagrupador; }
            set { _idagrupador = _idagrupador != value ? value : _idagrupador; }
        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Prestadoras() { }

        public Prestadoras(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE PROPERTY CHANGED
        #region PROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public Prestadoras Clone()
        {
            Prestadoras d = (Prestadoras)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Prestadoras> Clone(List<Prestadoras> lst)
        {
            List<Prestadoras> lista = new List<Prestadoras>();

            foreach (Prestadoras d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO DE LISTA BASE
        #region CONSULTA DE DATOS
        public List<Prestadoras> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Prestadoras> lista = new List<Prestadoras>();

                string c = $"SELECT PD.Codigo, PD.Descripcion AS Abreviatura, PR.Nombre AS NombreFiscal, PR.Cuit, PD.ID_Agrupador AS AgrupadorID" +
                           $" FROM {tablaname} PD" +                           
                           $" LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Prestadoras>(rdr));
                }

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Prestadoras>();
            }
        }

        //RETORNO DE PRESTADORAS HISTORICAS EN DISCUSIONES
        public List<Prestadoras> GetRegistroshisto()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Prestadoras> lista = new List<Prestadoras>();

                string c = $"SELECT PD.Codigo, PD.Descripcion AS Abreviatura, PR.Nombre AS NombreFiscal, PR.Cuit, DH.ID_Encabezado AS IDEncabezado," +
                           $" DH.ID_Agrupador AS AgrupadorID" +
                           $" FROM DISCGRPVALHIST DH" +
                           $" LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Prestadoras>(rdr));
                }

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Prestadoras>();
            }
        }

        #endregion

    }
}
