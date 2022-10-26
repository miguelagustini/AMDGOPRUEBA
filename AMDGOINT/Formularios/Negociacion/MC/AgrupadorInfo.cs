using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Negociacion.MC
{
    public class AgrupadorInfo : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion
        private static string tablaname = "PRESTGRPVAL";

        private int _idregistro = 0;
        private string _codigo = "";
        private string _descripcion = "";
        private short _idpresttipo = 0;
        private string _prestcodigo = "";
        private string _prestdescr = "";

        public int IDRegistro
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

        public string Descripcionplus
        {
            get
            {
                return Codigo + " " + Descripcion;
            }
        }

        public short PrestadoraTipoID
        {
            get { return _idpresttipo; }
            set { _idpresttipo = _idpresttipo != value ? value : _idpresttipo; }
        }

        public string PrestadoraTipoCodigo
        {
            get { return _prestcodigo; }
            set { _prestcodigo = _prestcodigo != value.Trim() ? value.Trim() : _prestcodigo; }
        }

        public string PrestadoraTipoDescripcion
        {
            get { return _prestdescr; }
            set { _prestdescr = _prestdescr != value.Trim() ? value.Trim() : _prestdescr; }
        }

        public List<Prestadoras> PrestatariasHisto { get; set; } = new List<Prestadoras>();
        public List<Prestadoras> Prestatarias { get; set; } = new List<Prestadoras>();

        //IGUALACION
        public short ID_PrestaTipo { get => PrestadoraTipoID; }
                
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public AgrupadorInfo() { }

        public AgrupadorInfo(SqlConnection conexion)
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
        public AgrupadorInfo Clone()
        {
            AgrupadorInfo d = (AgrupadorInfo)MemberwiseClone();
            Prestadoras p = new Prestadoras();
            d.Prestatarias = p.Clone(Prestatarias);

            return d;
        }

        //CLONE CON LISTAS
        public List<AgrupadorInfo> Clone(List<AgrupadorInfo> lst)
        {
            List<AgrupadorInfo> lista = new List<AgrupadorInfo>();

            foreach (AgrupadorInfo d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS
        public List<AgrupadorInfo> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<AgrupadorInfo> lista = new List<AgrupadorInfo>();

                string c = $"SELECT GV.ID_Registro as IDRegistro, GV.Codigo, GV.Descripcion, GV.ID_PrestaTipo AS PrestadoraTipoID,  PT.Codigo AS PrestadoraTipoCodigo," +
                           $" PT.Descripcion AS PrestadoraTipoDescripcion" +
                           $" FROM {tablaname} GV" +
                           $" LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = GV.ID_PrestaTipo)";


                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<AgrupadorInfo>(rdr));
                }

                //LISTA DE PRESTATARIAS ASOCIADAS AL AGRUPADOR
                #region PRESTATARIAS
                Prestadoras p = new Prestadoras();
                List<Prestadoras> lst = p.GetRegistros();

                lista.ForEach(f => f.Prestatarias = p.Clone(lst.Where(w => w.AgrupadorID == f.IDRegistro).ToList()));

                #endregion

                //LISTA DE PRESTATARIAS ASOCIADAS AL AGRUPADOR DE LA VALORIZACION
                #region PRESTATARIAS HISTORICO
                Prestadoras ph = new Prestadoras();
                List<Prestadoras> lsth = ph.GetRegistroshisto();

                lista.ForEach(f => f.PrestatariasHisto = ph.Clone(lsth.Where(w => w.AgrupadorID == f.IDRegistro).ToList()));

                #endregion

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<AgrupadorInfo>();
            }
        }

        #endregion

    }
}
