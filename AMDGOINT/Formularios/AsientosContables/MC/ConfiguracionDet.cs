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

namespace AMDGOINT.Formularios.AsientosContables.MC
{
    public class ConfiguracionDet : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        public static string tablaname = "[AmdgoContable].[dbo].[pc_CONFIGASIENTOS]";

        public int IDRegistro { get; set; } = 0;
        
        public int IDEncabezado { get; set; } = 0;
        public int PrestatariaID { get; set; } = 0;
        public int PrestatariaCuentaID { get; set; } = 0;
        public string PrestatariaCuentaCodigo { get; set; } = string.Empty;
        public string PrestatariaCuentaDescripcion { get; set; } = string.Empty;
        public string PrestatariaCompleta { get { return (PrestatariaCuentaCodigo + " " + PrestatariaCuentaDescripcion).Trim(); } }
        public int PrestadorCuentaID { get; set; } = 0;
        public string PrestatdorCuentaCodigo { get; set; } = string.Empty;
        public string PrestadorCuentaDescripcion { get; set; } = string.Empty;
        public string PrestadorCompleto { get { return (PrestatdorCuentaCodigo + " " + PrestadorCuentaDescripcion).Trim(); } }
        public int TerceroID { get; set; } = 0;
        public long TerceroCuit { get; set; } = 0;
        public string TerceroNombre { get; set; } = string.Empty;
        public string TerceroCompleto { get { return (TerceroCuit + " " + TerceroNombre).Trim(); } }
        public int PersonalID { get; set; } = 0;
        public long PersonalDocumento { get; set; } = 0;
        public string PersonalNombre { get; set; } = string.Empty;
        public string PersonalCompleto { get { return (PersonalDocumento + " " + PersonalNombre).Trim(); } }
        public int DebePlanCuentaID { get; set; } = 0;
        public CuentasContables.MC.Cuentas DebeCuentaContable { get; set; } = new CuentasContables.MC.Cuentas();        
        public int DebePlanSubCuentaID { get; set; } = 0;
        public CuentasContables.MC.SubCuentas DebeSubCuentaContable { get; set; } = new CuentasContables.MC.SubCuentas();
        public int HaberPlanCuentaID { get; set; } = 0;
        public CuentasContables.MC.Cuentas HaberCuentaContable { get; set; } = new CuentasContables.MC.Cuentas();
        public int HaberPlanSubCuentaID { get; set; } = 0;
        public CuentasContables.MC.SubCuentas HaberSubCuentaContable { get; set; } = new CuentasContables.MC.SubCuentas();        

        public string ComprobanteTipo { get; set; } = "RC";
        public string ComprobanteTipoDescripcion { get { return ComprobanteTipo == "RC" ? "Recibos" : ComprobanteTipo == "OP" ? "Ordenes de pago" : ""; } }
        
        
        public byte Area { get; set; } = 2;
        public string AreaDescripcion
        {
            get { return Area == 1 ? "Pago prestatarias" : Area == 2 ? "Tesorería" : ""; }
        }         
        public byte ImporteTipo { get; set; } = 1;
        public string ImporteTipoDescripcion { get { return ImporteTipo == 1 ? "Positivo" : "Negativo"; } }
        public string DestinoDescripcion
        {
            get { return PrestatariaCuentaID > 0 ? "Prestatarias" : PrestadorCuentaID > 0 ? "Prestadores" : TerceroID > 0 ? "Empresas / Terceros" : PersonalID > 0 ? "Empleados" : ""; }
        }
        public string DestinoNombre
        {
            get { return PrestatariaCuentaID > 0 ? PrestatariaCompleta : PrestadorCuentaID > 0 ? PrestadorCompleto : TerceroID > 0 ? TerceroCompleto : PersonalID > 0 ? PersonalCompleto : ""; }
        }
        public bool _BorraRegistro { get; set; } = false;
        public int IDUsuNew { get; set; } = 0;
        public int IDUsuModif { get; set; } = 0;
        public DateTime TimeModif { get; set; } = DateTime.Now;
        public DateTime TimeNew { get; set; } = DateTime.Now;

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public ConfiguracionDet() { }

        public ConfiguracionDet(SqlConnection conexion)
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
        public ConfiguracionDet Clone()
        {
            ConfiguracionDet d = (ConfiguracionDet)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<ConfiguracionDet> Clone(List<ConfiguracionDet> lst)
        {
            List<ConfiguracionDet> lista = new List<ConfiguracionDet>();
            lst.ForEach(f => lista.Add(f.Clone()));

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<ConfiguracionDet> GetRegistros(long idencabezado = 0)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<ConfiguracionDet> lista = new List<ConfiguracionDet>();

                string c = $"SELECT CN.IDRegistro, CN.PrestatariaCuentaID, CN.PrestadorCuentaID, CN.TerceroID, CN.PersonalID, CN.DebePlanCuentaID," +
                           $" CN.DebePlanSubCuentaID, CN.ComprobanteTipo, CN.Area, CN.ImporteTipo," +                                                      
                           $" ISNULL(PD.Codigo, '') AS PrestatariaCuentaCodigo, ISNULL(PD.Abreviatura, '') AS PrestatariaCuentaDescripcion," +
                           $" ISNULL(PFC.Codigo, '') AS PrestatdorCuentaCodigo, ISNULL(PFC.Descripcion, '') AS PrestadorCuentaDescripcion," +
                           $" ISNULL(EMP.DocumentoNumero, 0) AS PersonalDocumento, ISNULL(EMP.Nombre, '') AS PersonalNombre," +
                           $" ISNULL(TRC.Cuit, '') AS TerceroCuit, ISNULL(TRC.Nombre, '') AS TerceroNombre, CN.HaberPlanCuentaID, CN.HaberPlanSubCuentaID, " +
                           $" PD.ID_Prestataria AS PrestatariaID" +
                           $" FROM AmdgoContable.dbo.pc_CONFIGASIENTOS CN" +                           
                           $" LEFT OUTER JOIN AmdgoContable.dbo.EMPLEADOS EMP ON(EMP.IDRegistro = CN.PersonalID)" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.EMPRESAS TRC ON(TRC.IDRegistro = CN.TerceroID)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.ID_Registro = CN.PrestatariaCuentaID)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PFC ON(PFC.ID_Registro = CN.PrestadorCuentaID)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<ConfiguracionDet>(rdr));
                }

                #region DATOS DE CUENTAS Y SUBCUENTAS

                CuentasContables.MC.Cuentas _cnt = new CuentasContables.MC.Cuentas(SqlConnection);
                List<CuentasContables.MC.Cuentas> _lst = _cnt.GetRegistros();

                foreach (ConfiguracionDet d in lista)
                {
                    //origen
                    d.DebeCuentaContable = _lst.Where(w => w.IDRegistro == d.DebePlanCuentaID).FirstOrDefault();
                    d.DebeSubCuentaContable = _lst.Where(w => w.IDRegistro == d.DebePlanCuentaID).Select(s => s.SubCuentas.Where(W => W.IDRegistro == d.DebePlanSubCuentaID).FirstOrDefault()).FirstOrDefault();

                    //destino
                    d.HaberCuentaContable = _lst.Where(w => w.IDRegistro == d.HaberPlanCuentaID).FirstOrDefault();
                    d.HaberSubCuentaContable = _lst.Where(w => w.IDRegistro == d.HaberPlanCuentaID).Select(s => s.SubCuentas.Where(W => W.IDRegistro == d.HaberPlanSubCuentaID).FirstOrDefault()).FirstOrDefault();
                }

                #endregion


                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<ConfiguracionDet>();
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

            campos.Add("PrestatariaCuentaID");
            campos.Add("PrestadorCuentaID");
            campos.Add("TerceroID");
            campos.Add("PersonalID");            
            campos.Add("DebePlanCuentaID");
            campos.Add("DebePlanSubCuentaID");
            campos.Add("HaberPlanCuentaID");
            campos.Add("HaberPlanSubCuentaID");
            campos.Add("ComprobanteTipo");
            campos.Add("Area");            
            campos.Add("ImporteTipo");
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

            if (_BorraRegistro) { return retorno; }

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


                //SI ESTA MARCADO PARA ELIMINACION
                if (_BorraRegistro)
                {
                    var e = Eliminacion();
                    func.PreparaRetorno(retorno, e);
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

        //ELIMINACION
        private Dictionary<short, string> Eliminacion()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (IDRegistro <= 0)
                {
                    retorno.Add(0, "Sin id de registro para eliminacion.");
                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();

                //INICIO DEL INSERT
                query.Append($"DELETE FROM {tablaname} WHERE IDRegistro = {IDRegistro}");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Eliminación.\n{e.Message}");
                return retorno;
            }

        }

        //ELIMINACION
        public Dictionary<short, string> Eliminacion(long idregistro, string campouso)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (idregistro <= 0)
                {
                    retorno.Add(0, "Sin id de registro para eliminacion.");
                    return retorno;
                }

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();

                //INICIO DEL INSERT
                query.Append($"DELETE FROM {tablaname} WHERE {campouso} = {idregistro}");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Eliminación.\n{e.Message}");
                return retorno;
            }

        }

        #endregion
    }
}
