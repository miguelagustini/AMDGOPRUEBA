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

namespace AMDGOINT.Formularios.Devoluciones.MC
{
    public class DevolucionesEnc : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        
        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoInterno].[dbo].[DEVOLUCIONESENC]";
        private string _periodo = "";
        private string _observacion = "";

        public long IDRegistro { get; set; } = 0;
        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaCierre { get; set; } = DateTime.MinValue;
        public string Periodo { get { return _periodo.Replace("-", ""); } set { _periodo = _periodo != value ? value : _periodo; } } 
        public string DevolucionNumero { get { return IDRegistro.ToString("00000000"); } }
        public int PrestadorID { get; set; } = 0;
        public string PrestadorNombre { get; set; } = "";
        public long PrestadorCuit { get; set; } = 0;        
        public string Observacion { get { return _observacion; } set { _observacion = value?.Trim(); } }         
        public byte Estado { get; set; } = 0;
        public string EstadoDescripcion { get { return Estado == 0 ? "En Proceso" : Estado == 1 ? "Finalizado" : "Anulado"; } } 

        public List<DevolucionesDet> Detalles { get; set; } = new List<DevolucionesDet>();
        public List<DevolucionesEventos> Eventos { get; set; } = new List<DevolucionesEventos>();
        
        public decimal MontoFacturado { get { return Detalles.Sum(s => s.FacturadoImporteTotal); } }
        public decimal MontoDebitado { get { return Detalles.Sum(s => s.DebitadoImporteTotal); } }
        

        public int IDUsuNew { get; set; } = 0;
        public string UsuarioNew { get; set; } = "";
        public int IDUsuModif { get; set; } = 0;
        public string UsuarioModif { get; set; } = "";
        public DateTime TimeModif { get; set; } = DateTime.Now;
        public DateTime TimeNew { get; set; } = DateTime.Now;
        public string Guid { get { return IDLocal; } }
        
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public DevolucionesEnc() { }

        public DevolucionesEnc(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

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
        public DevolucionesEnc Clone()
        {
            DevolucionesEnc r = (DevolucionesEnc)MemberwiseClone();
            DevolucionesDet d = new DevolucionesDet();
            DevolucionesEventos e = new DevolucionesEventos();

            r.Detalles = d.Clone(Detalles);
            r.Eventos = e.Clone(Eventos);
            return r;

        }

        //CLONE CON LISTAS
        public List<DevolucionesEnc> Clone(List<DevolucionesEnc> lst)
        {
            List<DevolucionesEnc> lista = new List<DevolucionesEnc>();

            foreach (DevolucionesEnc d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;
        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<DevolucionesEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<DevolucionesEnc> lista = new List<DevolucionesEnc>();

                string c = $"SELECT RE.IDRegistro, RE.Guid AS IDLocal, RE.FechaInicio, RE.FechaCierre, RE.PrestadorID, RE.Observacion, RE.Estado," +
                           $" RE.IDUsuNew, RE.TimeNew, RE.IDUsuModif, RE.TimeModif, RE.Periodo," +
                           $" PR.Nombre AS PrestadorNombre, PR.Cuit AS PrestadorCuit," +
                           $" USUN.Usuario AS UsuarioNombreNew, USUM.Usuario AS UsuarioNombreModif" +
                           $" FROM {tablaname} RE" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PR ON(PR.ID_Registro = RE.PrestadorID)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.USUARIOS USUN ON(USUN.ID_Registro = RE.IDUsuNew)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.USUARIOS USUM ON(USUM.ID_Registro = RE.IDUsuModif)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DevolucionesEnc>(rdr));
                }

                //DETALLES
                #region DETALLES
                DevolucionesDet detcls = new DevolucionesDet(SqlConnection);
                List<DevolucionesDet> d = detcls.GetRegistros();

                foreach (DevolucionesEnc p in lista)
                {
                    p.Detalles = detcls.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion


                //EVENTOS
                #region EVENTOS
                DevolucionesEventos evecls = new DevolucionesEventos(SqlConnection);
                List<DevolucionesEventos> ev = evecls.GetRegistros();

                foreach (DevolucionesEnc p in lista)
                {
                    p.Eventos = evecls.Clone(ev.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<DevolucionesEnc>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        public void SetIDbyGuid()
        {
            try
            {
                ConexionBD cnb = new ConexionBD();
                string c = $"SELECT IDRegistro FROM {tablaname} WHERE Guid = '{IDLocal}' AND IDRegistro <> {IDRegistro}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection).Rows)
                {
                    IDRegistro = Convert.ToInt64(r["IDRegistro"]);
                }

                cnb.Desconectar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar el ID.\n{e.Message}", 1);
                return;
            }
        }
             
        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm(bool procesadetalles = true)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0)
            {
                return Alta();
            }
            else if (IDRegistro > 0)
            {
                return Modificacion(procesadetalles);
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
            campos.Add("FechaInicio");
            campos.Add("FechaCierre");
            campos.Add("Periodo");
            campos.Add("PrestadorID");
            campos.Add("Observacion");            
            campos.Add("Estado");
            campos.Add("IDUsuNew");
            campos.Add("TimeNew");
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

                IDUsuNew = glb.GetIdUsuariolog();
                IDUsuModif = glb.GetIdUsuariolog();

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

                //ASIGNO EL ID DE REGISTRO POR GUID
                SetIDbyGuid();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (DevolucionesDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO EVENTOS
                    foreach (DevolucionesEventos d in Eventos)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
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
        private Dictionary<short, string> Modificacion(bool procesadetalles = true)
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
                                
                IDUsuModif = glb.GetIdUsuariolog();

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

                if (procesadetalles)
                {
                    //ACTUALIZO DETALLES
                    foreach (DevolucionesDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO EVENTOS
                    foreach (DevolucionesEventos d in Eventos)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }
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
