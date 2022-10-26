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

namespace AMDGOINT.Formularios.Reclamos.MC
{
    public class ReclamosEnc : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private NumeroaLetras Numeroaletras = new NumeroaLetras();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoInterno].[dbo].[RECLAMOSENC]";
        private string _periodo = "";
        private string _observacion = "";

        public long IDRegistro { get; set; } = 0;
        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaCierre { get; set; } = DateTime.MinValue;
        public string Periodo { get { return _periodo.Replace("-", ""); } set { _periodo = _periodo != value ? value : _periodo; } } 
        public string ReclamoNumero { get { return IDRegistro.ToString("00000000"); } }
        public int PrestatariaID { get; set; } = 0;
        public string PrestatariaNombre { get; set; } = string.Empty;
        public long PrestatariaCuit { get; set; } = 0;
        public string PrestatariaAbreviatura { get; set; } = string.Empty;
        public string Observacion { get { return _observacion; } set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; } } 
        public byte Urgencia { get; set; } = 0;
        public string UrgenciaDescripcion { get { return Urgencia == 0 ? "Normal" : Urgencia == 1 ? "Rápido" : "Urgente"; } }
        public byte Estado { get; set; } = 0;
        public string EstadoDescripcion { get { return Estado == 0 ? "En Proceso" : Estado == 1 ? "Finalizado" : "Anulado"; } } 

        public List<ReclamosDet> Detalles { get; set; } = new List<ReclamosDet>();
        public List<ReclamosEventos> Eventos { get; set; } = new List<ReclamosEventos>();


        public decimal MontoFacturado { get { return Detalles.Sum(s => s.FacturadoImporteTotal); } }
        public decimal MontoDebitado { get { return Detalles.Sum(s => s.DebitadoImporteTotal); } }
        public decimal MontoReclamado { get { return Detalles.Sum(s => s.ReclamadoImporteTotal); } }
        public decimal MontoRecuperado { get { return Detalles.Sum(s => s.RecuperadoImporteTotal); } }


        public int IDUsuNew { get; set; } = 0;
        public string UsuarioCreadorNombre { get; set; } = string.Empty;
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
        public ReclamosEnc() { }

        public ReclamosEnc(SqlConnection conexion)
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
        public ReclamosEnc Clone()
        {
            ReclamosEnc r = (ReclamosEnc)MemberwiseClone();
            ReclamosDet d = new ReclamosDet();
            ReclamosEventos e = new ReclamosEventos();

            r.Detalles = d.Clone(Detalles);
            r.Eventos = e.Clone(Eventos);
            return r;

        }

        //CLONE CON LISTAS
        public List<ReclamosEnc> Clone(List<ReclamosEnc> lst)
        {
            List<ReclamosEnc> lista = new List<ReclamosEnc>();

            foreach (ReclamosEnc d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;
        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ReclamosEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ReclamosEnc> lista = new List<ReclamosEnc>();

                string c = $"SELECT RE.IDRegistro, RE.Guid AS IDLocal, RE.FechaInicio, RE.FechaCierre, RE.PrestatariaID, RE.Observacion, RE.Urgencia, RE.Estado," +
                           $" RE.IDUsuNew, RE.TimeNew, RE.IDUsuModif, RE.TimeModif, RE.Periodo," +
                           $" PR.Nombre AS PrestatariaNombre, PR.Cuit AS PrestatariaCuit, PR.Abreviatura AS PrestatariaAbreviatura, USUN.Usuario AS UsuarioCreadorNombre, USUM.Usuario AS UsuarioNombreModif," +
                           $" RE.IDUsuNew" +
                           $" FROM {tablaname} RE" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PR ON(PR.ID_Registro = RE.PrestatariaID)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.USUARIOS USUN ON(USUN.ID_Registro = RE.IDUsuNew)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.USUARIOS USUM ON(USUM.ID_Registro = RE.IDUsuModif)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ReclamosEnc>(rdr));
                }

                //DETALLES
                #region DETALLES
                ReclamosDet detcls = new ReclamosDet(SqlConnection);
                List<ReclamosDet> d = detcls.GetRegistros();

                foreach (ReclamosEnc p in lista)
                {
                    p.Detalles = detcls.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion


                //EVENTOS
                #region EVENTOS
                ReclamosEventos evecls = new ReclamosEventos(SqlConnection);
                List<ReclamosEventos> ev = evecls.GetRegistros();

                foreach (ReclamosEnc p in lista)
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
                return new List<ReclamosEnc>();
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

        public string ExisteReclamoIgual()
        {
            try
            {
                string retorno = "";
                ConexionBD cnb = new ConexionBD();
                string c = $"SELECT TOP 1" +
                           $" ISNULL(U.Usuario, '') AS Usuario" +
                           $" FROM RECLAMOSENC RE" +
                           $" LEFT OUTER JOIN USUARIOS U ON(U.ID_Registro = RE.IDUsuNew)" +
                           $" WHERE RE.PrestatariaID = {PrestatariaID} AND RE.Periodo = '{Periodo}' AND RE.IDRegistro <> {IDRegistro}" +
                           $" ORDER BY RE.FechaInicio DESC";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection).Rows)
                {
                    retorno = r["Usuario"].ToString();
                }

                cnb.Desconectar();
                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar el ID.\n{e.Message}", 1);
                return "";
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
            campos.Add("PrestatariaID");
            campos.Add("Observacion");
            campos.Add("Urgencia");
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
                    foreach (ReclamosDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO EVENTOS
                    foreach (ReclamosEventos d in Eventos)
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
                TimeModif = DateTime.Now;

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
                    foreach (ReclamosDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO EVENTOS
                    foreach (ReclamosEventos d in Eventos)
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
