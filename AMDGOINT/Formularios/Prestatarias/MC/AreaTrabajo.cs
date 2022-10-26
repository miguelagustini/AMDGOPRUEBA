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

namespace AMDGOINT.Formularios.Prestatarias.MC
{
    public class AreaTrabajo : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "AmdgoInterno.dbo.PRESTAREASTRABAJO";

        private short _idregistro = 0;
        private short _idareatrabajo = 0;        
        private int _idprestataria = 0;
        private string _observaciones = "";        
        private string _areatrabajop = "";

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

        public short IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public short IDAreaTrabajo
        {
            get { return _idareatrabajo; }
            set { _idareatrabajo = _idareatrabajo != value ? value : _idareatrabajo; }
        }

        public int IDPrestataria
        {
            get { return _idprestataria; }
            set { _idprestataria = _idprestataria != value ? value : _idprestataria; }
        }

        public string AreaTrabajoDescripcion
        {
            get { return _areatrabajop; }
            set { _areatrabajop = _areatrabajop != value.Trim() ? value.Trim() : _areatrabajop; }
        }

        public string Observacion
        {
            get { return _observaciones; }
            set { _observaciones = _observaciones != value.Trim() ? value.Trim() : _observaciones; }
        }

        public virtual BindingList<Contactos> Contactos { get; set; } = new BindingList<Contactos>();

        public string Guid { get { return IDLocal; } }

        public int IDUsuNew { get { return glb.GetIdUsuariolog(); } }
        public int IDUsuModif { get { return glb.GetIdUsuariolog(); } }
        public DateTime TimeModif { get { return DateTime.Now; } }
        
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
                
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public AreaTrabajo() { }

        public AreaTrabajo(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //NOTIFY
        #region NOTIFY

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
        public AreaTrabajo Clone()
        {            
            AreaTrabajo d = (AreaTrabajo)MemberwiseClone();
            Contactos c = new Contactos();

            d.Contactos = c.Clone(Contactos);
            return d;

        }

        //CLONE CON LISTAS
        public List<AreaTrabajo> Clone(List<AreaTrabajo> lst)
        {
            List<AreaTrabajo> lista = new List<AreaTrabajo>();

            foreach (AreaTrabajo d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<AreaTrabajo> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<AreaTrabajo> lista = new List<AreaTrabajo>();

                string c = $"SELECT PT.IDRegistro, PT.IDPrestataria, PT.IDAreaTrabajo, PT.Observacion, PA.Descripcion AS AreaTrabajoDescripcion, PT.Guid AS IDLocal" +                           
                           $" FROM {tablaname} PT" +
                           $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[AREASTRABAJO] PA ON(PA.IDRegistro = PT.IDAreaTrabajo)";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<AreaTrabajo>(rdr));
                }

                //CONTACTOS
                #region CONTACTOS
                Contactos plclass = new Contactos(SqlConnection);
                List<Contactos> d = plclass.GetRegistros();
                lista.ForEach(p => p.Contactos = plclass.Clone(new BindingList<Contactos>(d.Where(w => w.IDAreaPrestataria == p.IDRegistro).ToList())));

                #endregion


                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<AreaTrabajo>();
            }
        }

       
        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void SetIdregistro()
        {
            string c = $"SELECT IDRegistro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt16(r["IDRegistro"]);
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0)
            {
                return Alta();
            }
            else if (IDRegistro > 0)
            {
                return Modificacion();
            }
            else
            {
                retorno.Add(0, $"{GetType().Name}. No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("Guid");
            campos.Add("IDAreaTrabajo");
            campos.Add("IDPrestataria");
            campos.Add("Observacion");            
            campos.Add("IDUsuNew");
            campos.Add("IDUsuModif");
            campos.Add("TimeModif");

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //CONEXION
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();

                //INICIO DEL INSERT
                query.Append($"INSERT INTO {tablaname} (");

                //AGREGO LOS CAMPOS
                foreach (string c in campos)
                {
                    query.Append($"{c},");
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                query.Replace(",", ")", query.Length - 1, 1);

                //AGREGO VALORES AL BULDIER
                query.Append(" VALUES (");

                //CREO TANTO PARAMETROS COMO CAMPOS HAY
                for (int i = 0; i < campos.Count; i++)
                {
                    query.Append($"@p{i.ToString()},");
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                query.Replace(",", ")", query.Length - 1, 1);
                
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                short paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null)); }

                    paramnro++;
                }

                //EJECUTO LA INSTRUCCION
                cmd.ExecuteNonQuery();

                //IDREGISTRO
                SetIdregistro();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO LOS CONTACTOS
                    foreach (Contactos dir in Contactos)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.IDAreaPrestataria = IDRegistro;
                        var dic = dir.Abm();

                        func.PreparaRetorno(retorno, dic);
                    }
                }
                
                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Alta.\n{e.Message}");
                return retorno;
            }

        }

        //MODIFICACION DE REGISTROS DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Modificacion()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (IDRegistro <= 0)
                {
                    retorno.Add(0, "Sin id de registro para modificación.");
                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
                campos.Remove("IDUsuNew");
                campos.Remove("Guid");


                //INICIO DEL INSERT
                query.Append($"UPDATE {tablaname} SET ");

                //AGREGO LOS CAMPOS A ACTUALZIAR 
                short paramnro = 0;
                foreach (string c in campos)
                {
                    query.Append($"{c} = @p{paramnro.ToString()},");
                    paramnro++;
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                query.Replace(",", "", query.Length - 1, 1);

                //AGREGO AGREGO CLAUSULA WHERE
                query.Append($" WHERE (IDRegistro = {IDRegistro})");

                //CONEXION

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                paramnro = 0;
                foreach (string c in campos)
                {
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this)); }

                    paramnro++;
                }

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();


                //ACTUALIZO LOS CONTACTOS
                foreach (Contactos dir in Contactos)
                {
                    //ASIGNO CONNEXION
                    dir.SqlConnection = SqlConnection;
                    dir.IDAreaPrestataria = IDRegistro;
                    var dic = dir.Abm();

                    func.PreparaRetorno(retorno, dic);
                }

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Modificación.\n{e.Message}");
                return retorno;
            }

        }




        #endregion
    }
}
