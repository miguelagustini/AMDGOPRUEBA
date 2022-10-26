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

namespace AMDGOINT.Formularios.Practicas.MC
{
    public class Convenidas
    {

        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        

        private int _practicaid = 0;
        private DateTime _fechanegociacion = DateTime.MinValue;
        private string _prestadoracodigo = "";
        private string _prestadoranombre = "";
        private decimal _valor = 0;
        public int PracticaID
        {
            get { return _practicaid; }
            set { _practicaid = _practicaid != value ? value : _practicaid; }
        }

        public DateTime FechaNegociacion
        {
            get { return _fechanegociacion; }
            set
            {
                _fechanegociacion = _fechanegociacion != value ? value : _fechanegociacion;
            }
        }

        public string PrestadoraCodigo
        {
            get { return _prestadoracodigo; }
            set
            {
                _prestadoracodigo = _prestadoracodigo != value.Trim() ? value.Trim() : _prestadoracodigo;
            }
        }

        public string PrestadoraNombre
        {
            get { return _prestadoranombre; }
            set
            {
                _prestadoranombre = _prestadoranombre != value.Trim() ? value.Trim() : _prestadoranombre;
            }
        }

        public string Prestadora
        {
            get { return PrestadoraCodigo + " " + PrestadoraNombre; }
        }

        public decimal ValorPactado
        {
            get { return _valor; }
            set
            {
                _valor = _valor != value ? value : _valor;
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Convenidas() { }

        public Convenidas(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //EVENTOS
        #region EVENTOS Y  METODOS

        //PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        //CLONE 
        #region CLONACION
        public Convenidas Clone()
        {
            Convenidas d = (Convenidas)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Convenidas> Clone(List<Convenidas> lst)
        {
            List<Convenidas> lista = new List<Convenidas>();

            foreach (Convenidas d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS

        public List<Convenidas> GetRegistros()
        {
            try
            {
                List<Convenidas> lista = new List<Convenidas>();

                string c = $"SELECT DD.ID_Practica AS PracticaID, DE.FechaImpacto as FechaNegociacion, PG.Codigo as PrestadoraCodigo, PG.Descripcion as PrestadoraNombre, DD.Valor as ValorPactado" +
                           $" from DISCUSIONENC DE" +
                           $" LEFT OUTER JOIN PRESTGRPVAL PG ON(PG.ID_Registro = DE.ID_GrupoValor)" +
                           $" LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Agrupador = PG.ID_Registro)" +
                           $" LEFT OUTER JOIN DISCUSIONDET DD ON(DD.ID_Encabezado = DE.ID_Registro)" +
                           $" WHERE DD.Aplicado = 2 AND DE.Estado = 2" +
                           $" GROUP BY DD.ID_Practica, DE.FechaImpacto, PG.Codigo, PG.Descripcion, DD.Valor" +
                           $" ORDER BY DE.FechaImpacto DESC";

                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Convenidas>(rdr));
                }

                cnn.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los convenios.\n{e.Message}", 0);
                return new List<Convenidas>();
            }
        }

        #endregion

     
        #endregion

    }
}
