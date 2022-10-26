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

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.MC
{
    public class Anestesiadet : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES    
        private long idregistro = 0;
        private long idencabezado = 0;        
        private short idpractica = 0;
        private short nivel = 0;
        private decimal porcentaje = 0;
        private decimal importe = 0;
        private decimal importeam = 0;
        private string codigo = "";
        private string practica = "";
        
            //DE CLASE
        private static string tablename = "AUDIANESTESIAGRPDET";

        public long IDRegistro
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

        public long IDEncabezado
        {
            get { return idencabezado; }
            set
            {
                if (idencabezado != value)
                {
                    idencabezado = value;

                }
            }
        }
        
        public short IDPractica
        {
            get { return idpractica; }
            set
            {
                if (idpractica != value)
                {
                    idpractica = value;
                }
            }
        }

        public short Nivel
        {
            get { return nivel; }
            set
            {
                if (nivel != value)
                {
                    nivel = value;
                }
            }
        }

        public decimal Porcentaje
        {
            get { return porcentaje; }
            set
            {
                if (porcentaje != value)
                {
                    porcentaje = value;
                }
            }            
        }

        public decimal Importe
        {
            get { return importe; }
            set
            {
                if (importe != value)
                {
                    importe = value;
                }
            }
        }

        public decimal ImporteAm
        {
            get { return importeam; }
            set
            {
                if (importeam != value)
                {
                    importeam = value;
                }
            }
        }

        public decimal ValorPorcNivelAm
        {
            get
            {
                decimal v = 0;
                if (Porcentaje != 0)
                {
                    v = ImporteAm * (Porcentaje / 100);
                }

                return v;
            }
        }

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (codigo != value.Trim())
                {
                    codigo = value.Trim();
                }
            }
        }

        public string Practica
        {
            get { return practica; }
            set
            {
                if (practica != value.Trim())
                {
                    practica = value.Trim();
                }

            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD        
        public long ID_Encabezado { get { return IDEncabezado; } }
        public short ID_Practica { get { return IDPractica; } }
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }

        #endregion

        //NOTIFY PROPERTY
        #region NOTYFIPROPERTY

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Anestesiadet() { }

        public Anestesiadet(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //CLONE 
        #region CLONACION
        public Anestesiadet Clone()
        {
            Anestesiadet d = (Anestesiadet)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Anestesiadet> Clone(List<Anestesiadet> lst)
        {
            List<Anestesiadet> lista = new List<Anestesiadet>();

            foreach (Anestesiadet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        public BindingList<Anestesiadet> Clone(BindingList<Anestesiadet> lst)
        {
            BindingList<Anestesiadet> lista = new BindingList<Anestesiadet>();

            foreach (Anestesiadet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS

        public List<Anestesiadet> GetRegistros()
        {
            try
            {
                List<Anestesiadet> lista = new List<Anestesiadet>();

                string c = $"SELECT A.ID_Registro AS IDRegistro, A.ID_Encabezado AS IDEncabezado, A.ID_Practica AS IDPractica, A.Porcentaje, A.Importe," +
                           $" P.Nivel, A.ImporteAm, P.Codigo, P.Descripcion AS Practica" +
                           $" FROM {tablename} AS A" +
                           $" LEFT OUTER JOIN PRACTANES P ON(P.ID_Registro = A.ID_Practica)";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Anestesiadet a = new Anestesiadet();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        GetType().GetProperty(co.ColumnName).SetValue(a, r[co]);
                    }

                    lista.Add(a);
                }

                //dispongo de la memoria table
                tbl.Dispose();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los detalles.\n{e.Message}", 0);
                return new List<Anestesiadet>();
            }
        }
        
        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        //METODO ABM DE ACCESO PUBLICO
        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0) { return Alta(); }
            else if (IDRegistro > 0) { return Modificacion(); }
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        //LISTA DE CAMPOS
        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("ID_Encabezado");
            campos.Add("ID_Practica");
            campos.Add("Porcentaje");
            campos.Add("Importe");            
            campos.Add("ImporteAm");
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
                query.Append($"INSERT INTO {tablename} (");

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

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();

                retorno.Add(1, "OK");

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, e.Message);
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
                List<string> campos = new List<string>(RetornaCampos());
                campos.Remove("ID_UsuNew");

                //INICIO DEL INSERT
                query.Append($"UPDATE {tablename} SET ");

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

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();

                retorno.Add(1, "OK");

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, e.Message);
                return retorno;
            }

        }

        #endregion
    }
}
