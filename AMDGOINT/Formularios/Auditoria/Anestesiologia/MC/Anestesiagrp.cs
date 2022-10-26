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
    public class Anestesiagrp: INotifyPropertyChanged
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
        private int idencabezado = 0;
        private int numero = 0;
        private short idanestesista = 0;
        private string matricula = "";
        private string anestesista = "";
        private int documento = 0;
        private string paciente = "";
        private short identidad = 0;
        private string entidad = "";
        private DateTime fechapractica;       

        //DE CLASE
        private static string tablename = "AUDIANESTESIAGRP";

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

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

        public int IDEncabezado
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

        public int Numero
        {
            get { return numero; }
            set
            {
                if (numero != value)
                {
                    numero = value;
                }
            }
        }

        public short IDAnestesista
        {
            get { return idanestesista; }
            set
            {
                if (idanestesista != value)
                {
                    idanestesista = value;
                }
            }

        }

        public string Matricula
        {
            get { return matricula; }
            set
            {
                if (matricula != value.Trim())
                {
                    matricula = value.Trim();
                }
            }
        }

        public string Anestesista
        {
            get { return anestesista; }
            set
            {
                if (anestesista != value.Trim())
                {
                    anestesista = value.Trim();
                }
            }
        }

        public int Documento
        {
            get { return documento; }
            set
            {
                if (documento != value)
                {
                    documento = value;

                }
            }
        }

        public string Paciente
        {
            get { return paciente; }
                     
            set
            {
                if (paciente != value.Trim())
                {
                    paciente = value;
                }
            }
        }

        public short IDEntidad
        {
            get { return identidad; }
            set
            {
                if (identidad != value)
                {
                    identidad = value;
                }
            }
        }

        public string Entidad
        {
            get { return entidad; }
            set
            {
                if (entidad != value.Trim())
                {
                    entidad = value.Trim();
                }
            }
        }

        public DateTime FechaPractica
        {
            get { return fechapractica; }
            set
            {
                if (fechapractica != value) { fechapractica = value; }
            }
        }

        public BindingList<Anestesiadet> Detalles { get; set; } = new BindingList<Anestesiadet>();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public short ID_Anestesista { get { return IDAnestesista; } }
        public int ID_Encabezado { get { return IDEncabezado; } }        
        public short ID_Entidad { get { return IDEntidad; } }
        public string Guid { get { return IDLocal; } }
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

        public Anestesiagrp() { }

        public Anestesiagrp(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //CLONE 
        #region CLONACION
        public Anestesiagrp Clone()
        {
            Anestesiagrp d = (Anestesiagrp)MemberwiseClone();
            Anestesiadet det = new Anestesiadet();
            d.Detalles = det.Clone(d.Detalles);

            return d;

        }

        //CLONE CON LISTAS
        public List<Anestesiagrp> Clone(List<Anestesiagrp> lst)
        {
            List<Anestesiagrp> lista = new List<Anestesiagrp>();

            foreach (Anestesiagrp d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        public BindingList<Anestesiagrp> Clone(BindingList<Anestesiagrp> lst)
        {
            BindingList<Anestesiagrp> lista = new BindingList<Anestesiagrp>();

            foreach (Anestesiagrp d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS
        public List<Anestesiagrp> GetRegistros()
        {
            try
            {
                List<Anestesiagrp> lista = new List<Anestesiagrp>();

                string c = $"SELECT A.ID_Registro AS IDRegistro, A.ID_Encabezado AS IDEncabezado, A.Numero, A.ID_Anestesista AS IDAnestesista, A.Documento, A.Paciente, A.ID_Entidad AS IDEntidad," +
                           $" A.FechaPractica, AN.Matricula, AN.Nombre as Anestesista, A.Guid AS IDLocal, E.Nombre AS Entidad" +
                           $" FROM {tablename} AS A" +
                           $" LEFT OUTER JOIN AUDIANESENTI E ON(E.ID_Registro = A.ID_Entidad)" +
                           $" LEFT OUTER JOIN ANESTESISTAS AN ON(AN.ID_Registro = A.ID_Anestesista)";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Anestesiagrp a = new Anestesiagrp();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        GetType().GetProperty(co.ColumnName).SetValue(a, r[co]);
                    }

                    lista.Add(a);
                }

                //OBENGO LOS DETALLES 
                Anestesiadet detcls = new Anestesiadet(SqlConnection);
                List<Anestesiadet> lst = detcls.GetRegistros();

                //LOS ASIGNO SEGUN SU ENCABEZADO
                foreach (Anestesiagrp d in lista)
                {
                    d.Detalles = detcls.Clone(new BindingList<Anestesiadet>(lst.Where(w => w.IDEncabezado == d.IDRegistro).ToList()));
                }

                //dispongo de la memoria table
                tbl.Dispose();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los detalles.\n{e.Message}", 0);
                return new List<Anestesiagrp>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR DETALLES ASOCIADOS CREADOS DESDE CERO)
        private void GetIdregistro()
        {
            string c = $"SELECT ID_Registro FROM {tablename} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt64(r["ID_Registro"]);
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

            campos.Add("Guid");
            campos.Add("ID_Encabezado");
            campos.Add("Numero");
            campos.Add("ID_Anestesista");
            campos.Add("Documento");
            campos.Add("Paciente");
            campos.Add("ID_Entidad");
            campos.Add("FechaPractica");            
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

                //OBTENGO EL ID DE REGISTRO
                GetIdregistro();

                //ACTUALIZO LOS CONTACTOS
                if (IDRegistro > 0)
                {
                    foreach (Anestesiadet ct in Detalles)
                    {
                        //ASIGNO CONNEXION 
                        ct.SqlConnection = SqlConnection;
                        ct.IDEncabezado = IDRegistro;
                        ct.Abm();
                    }
                }


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
                campos.Remove("Guid");

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

                //ACTUALIZO LOS DETALLES
                foreach (Anestesiadet ct in Detalles)
                {
                    //ASIGNO CONNEXION 
                    ct.SqlConnection = SqlConnection;
                    //ASIGNO ID DE DIRECCION
                    ct.IDEncabezado = IDRegistro;
                    ct.Abm();

                }


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
