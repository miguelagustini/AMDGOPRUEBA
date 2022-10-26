using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Profesionales.MC
{
    public class Direcciones : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES      
        private static string tablaname = "PROFDIRECCIONES";

        private int idregistro = 0;
        private int idprofesional = 0;
        private string domicilio = "";
        private string calle = "";
        private string numero = "";
        private string piso = "";
        private string departamento = "";
        private int idlocalidad = 0;
        private string localidad = "";
        private string tipo = "";
        private bool _estado = true;
        private bool _datopersonal = false;

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

        public int IDRegistro
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

        public int IDProfesional
        {
            get { return idprofesional; }
            set
            {
                if (idprofesional != value)
                {
                    idprofesional = value;

                }
            }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set
            {
                if (domicilio != value.Trim())
                {
                    domicilio = value.Trim();
                }
            }

        }

        public string Calle
        {
            get { return calle; }
            set
            {
                if (calle != value.Trim())
                {
                    calle = value.Trim();

                }
            }
        }

        public string Numero
        {
            get { return numero; }
            set
            {
                if (numero != value.Trim())
                {
                    numero = value.Trim();
                }
            }

        }

        public string Piso
        {
            get { return piso; }
            set
            {
                if (piso != value.Trim())
                {
                    piso = value.Trim();
                }
            }

        }

        public string Departamento
        {
            get { return departamento; }
            set
            {
                if (departamento != value.Trim())
                {
                    departamento = value.Trim();
                }
            }

        }

        public int IDLocalidad
        {
            get { return idlocalidad; }
            set
            {
                if (idlocalidad != value)
                {
                    idlocalidad = value;
                }
            }
        }

        public string Localidad
        {
            get { return localidad; }
            set
            {
                if (localidad != value.Trim())
                {
                    localidad = value.Trim();
                }
            }

        }

        public string Tipo
        {
            get { return tipo; }
            set
            {
                 if (tipo != value.Trim())
                 {
                     if (value.Length > 1) { tipo = value.Substring(0, 1); }
                     else { tipo = value.Trim(); }

                 }
                //tipo = tipo != value.Trim() ? value.Trim() : tipo;
            }
        }

        public string TipoDescripcion
        {
            get { if (tipo == "L") { return "Laboral"; } else { return "Personal"; } }            
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = _estado != value ? value : _estado; }
        }

        public bool MostrarDatoPersonal
        {
            get { return _datopersonal; }
            set { _datopersonal = _datopersonal != value ? value : _datopersonal; }
        }

        public virtual BindingList<Contactos> Contactos { get; set; } = new BindingList<Contactos>();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public int ID_Profesional { get { return IDProfesional; } }
        public int ID_Localidad { get { return IDLocalidad; } }
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public string Guid { get { return IDLocal; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Direcciones() { }

        public Direcciones(SqlConnection conexion) { SqlConnection = conexion; }

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
        public Direcciones Clone()
        {
            Direcciones d = (Direcciones)MemberwiseClone();
            Contactos c = new Contactos();
            d.Contactos = c.Clone(Contactos);

            return d;

        }
        
        //CLONE CON LISTAS
        public List<Direcciones> Clone(List<Direcciones> lst)
        {
            List<Direcciones> lista = new List<Direcciones>();

            foreach (Direcciones d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        
        #endregion

        //CONSULTA DE DATOS
        #region CONSULTA DE DATOS
        
        //RETORNO LISTA DE DIRECCIONES
        public List<Direcciones> GetDirecciones()
        {
            try
            {
                List<Direcciones> lista = new List<Direcciones>();

                string c = $"SELECT PD.ID_Registro AS IDRegistro, PD.ID_Profesional AS IDProfesional, PD.Domicilio, PD.Calle, PD.Numero, PD.Piso," +
                           $" PD.Departamento, PD.ID_Localidad AS IDLocalidad, PD.Tipo, PD.Guid AS IDLocal," +
                           $" ISNULL(LO.Descripcion, '') AS Localidad, PD.Estado" +
                           $" FROM {tablaname} PD" +
                           $" LEFT OUTER JOIN LOCALIDADES LO ON(LO.ID_Registro = PD.ID_Localidad)";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Direcciones>(rdr));
                }

                cnb.Desconectar();

                Contactos ctnclas = new Contactos(SqlConnection);
                List<Contactos> contalst = ctnclas.GetContactos();

                foreach (Direcciones d in lista)
                {
                    d.Contactos =  ctnclas.Clone(new BindingList<Contactos>(contalst.Where(w => w.IDDireccion == d.IDRegistro).ToList()));
                }

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las direcciones.\n{e.Message}", 0);
                return new List<Direcciones>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void GetIdregistro()
        {
            string c = $"SELECT ID_Registro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt32(r["ID_Registro"]);
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();            
            if (IDRegistro <= 0 && IDLocal.Length > 0)
            {
                return Alta();
            }
            else if (IDRegistro > 0 && IDLocal.Length > 0)
            {
                return Modificacion();
            }            
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();
                        
            campos.Add("ID_Profesional");
            campos.Add("Domicilio");
            campos.Add("Calle");
            campos.Add("Numero");
            campos.Add("Piso");
            campos.Add("Departamento");
            campos.Add("ID_Localidad");
            campos.Add("Tipo");
            campos.Add("Guid");            
            campos.Add("Estado");
            campos.Add("ID_UsuNew");
            campos.Add("ID_UsuModif");

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //DEFINO CONNEXION EN CASO DE NO HABER UNA
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

                //CONEXION                
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                short paramnro = 0;
                foreach (string c in campos)
                {
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null));
                    paramnro++;
                }

                //EJECUTO LA INSTRUCCION
                cmd.ExecuteNonQuery();

                //****************************************************************************************
                //************************ EVALUACION PARA CONTACTOS *************************************
                //****************************************************************************************       
                
                //OBTENGO EL ID DE REGISTRO
                GetIdregistro();

                //ACTUALIZO LOS CONTACTOS
                if (IDRegistro > 0)
                {
                    foreach (Contactos ct in Contactos)
                    {
                        //ASIGNO CONNEXION 
                        ct.SqlConnection = SqlConnection;
                        ct.IDDireccion = IDRegistro;
                        var dic = ct.Abm();

                        PreparaRetorno(retorno, dic);
                    }
                }
                                
                cbd.Desconectar();
                cmd.Dispose();
                
                return retorno;
            }
            catch (Exception e)
            {                
                retorno.Add(-1, $"Direccion Alta.\n{e.Message}");
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
                campos.Remove("ID_UsuNew");
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
                query.Append($" WHERE (ID_Registro = {IDRegistro})");

                //CONEXION                
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                paramnro = 0;
                foreach (string c in campos)
                {
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this));
                    paramnro++;
                }

                //ACTUALIZO DIRECCION
                cmd.ExecuteNonQuery();

                //****************************************************************************************
                //************************ EVALUACION PARA CONTACTOS *************************************
                //****************************************************************************************       
                
                //ACTUALIZO LOS CONTACTOS
                foreach (Contactos ct in Contactos)
                {
                    //ASIGNO CONNEXION 
                    ct.SqlConnection = SqlConnection;                                        
                    //ASIGNO ID DE DIRECCION
                    ct.IDDireccion = IDRegistro;
                    var dic = ct.Abm();

                    PreparaRetorno(retorno, dic);
                }                                

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {                
                retorno.Add(-1,$"Direccion Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        private void PreparaRetorno(Dictionary<short, string> retorno, Dictionary<short, string> proc)
        {
            foreach (var y in proc)
            {
                if (retorno.Where(w => w.Key == y.Key).Count() <= 0)
                {
                    retorno.Add(y.Key, y.Value);
                }
            }
        }

        #endregion


        #endregion
    }
}
