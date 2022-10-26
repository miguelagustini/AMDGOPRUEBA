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
    public class AsientosEnc: INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[ts_ASIENTOSCNTBLENC]";

        public long IDRegistro { get; set; } = 0;
        public int AsientoNumero { get; set; } = 0;        
        public DateTime AsientoFecha { get; set; } = DateTime.Now;
        public DateTime FechaCierreMensual { get; set; } = DateTime.MinValue;
        public DateTime FechaCierreAnual { get; set; } = DateTime.MinValue;        
        public string Observacion { get; set; } = string.Empty;
        public bool AsientoCierre { get; set; } = false;
        public long IDOrdenPago { get; set; } = 0;
        public List<AsientosDet> Detalles { get; set; } = new List<AsientosDet>();        
        public decimal ImporteDebe { get { return Detalles.Sum(s => s.ImporteDebe); } }
        public decimal ImporteHaber { get { return Detalles.Sum(s => s.ImporteHaber); } }

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
        public AsientosEnc() { }

        public AsientosEnc(SqlConnection conexion)
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
        public AsientosEnc Clone()
        {
            AsientosEnc e = (AsientosEnc)MemberwiseClone();
            AsientosDet d = new AsientosDet();

            e.Detalles = d.Clone(Detalles);

            return e;

        }

        //CLONE CON LISTAS
        public List<AsientosEnc> Clone(List<AsientosEnc> lst)
        {
            List<AsientosEnc> lista = new List<AsientosEnc>();

            foreach (AsientosEnc d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<AsientosEnc> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<AsientosEnc> lista = new List<AsientosEnc>();

                string c = $"SELECT IDRegistro, AsientoNumero, AsientoFecha, FechaCierreMensual, FechaCierreAnual, Observacion, AsientoCierre, IDOrdenPago" +
                           $" FROM {tablaname}" +
                           $" WHERE FechaCierreAnual IS NULL";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<AsientosEnc>(rdr));
                }
                
                //DETALLES
                #region DETALLES
                AsientosDet detcls = new AsientosDet(SqlConnection);
                List<AsientosDet> d = detcls.GetRegistros();

                foreach (AsientosEnc p in lista)
                {
                    p.Detalles = detcls.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<AsientosEnc>();
            }
        }

        public List<AsientosEnc> GetRegistrosbyfieldid(long idregistro, string campo)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<AsientosEnc> lista = new List<AsientosEnc>();

                string c = $"SELECT IDRegistro, AsientoNumero, AsientoFecha, FechaCierreMensual, FechaCierreAnual, Observacion, AsientoCierre, IDOrdenPago" +
                           $" FROM {tablaname}" +
                           $" WHERE FechaCierreAnual IS NULL {(idregistro > 0 && !string.IsNullOrEmpty(campo) ? "AND " + campo + " = " + idregistro : "")}";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<AsientosEnc>(rdr));
                }

                //DETALLES
                #region DETALLES
                AsientosDet detcls = new AsientosDet(SqlConnection);
                List<AsientosDet> d = detcls.GetRegistros(idregistro);

                foreach (AsientosEnc p in lista)
                {
                    p.Detalles = detcls.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<AsientosEnc>();
            }
        }

        private void SetNumeroAsiento()
        {
            try
            {
                string c = $"SELECT ISNULL(MAX(AsientoNumero)+1,1) AS ComprobanteNumero FROM {tablaname} WHERE FechaCierreAnual IS NULL";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    AsientoNumero = Convert.ToInt32(r["ComprobanteNumero"]);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el número de asiento.\n{e.Message}", 1);
                return;
            }
        }

        public bool AsientoEnPeriodoAnualCerrado()
        {
            try
            {
                bool retorno = false;

                string c = $"SELECT ISNULL(COUNT(*), 0) AS CantidadRegistros FROM {tablaname} " +
                           $" WHERE FechaCierreAnual IS NOT NULL AND FechaCierreAnual >= '{AsientoFecha}'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    if (Convert.ToInt32(r["CantidadRegistros"]) > 0) { retorno = true; }                    
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al validar la fecha del asiento.\n{e.Message}", 1);
                return true;
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

            campos.Add("AsientoNumero");
            campos.Add("AsientoFecha");
            campos.Add("FechaCierreMensual");
            campos.Add("FechaCierreAnual");
            campos.Add("Observacion");
            campos.Add("AsientoCierre");
            campos.Add("IDOrdenPago");
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

                //ASIGNO NUMERO ASIENTO
                SetNumeroAsiento();

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
                query.Append("OUTPUT INSERTED.IDRegistro VALUES (");

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
                IDRegistro = (long)cmd.ExecuteScalar();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (AsientosDet d in Detalles)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDEncabezado = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                }
                else
                {
                    Dictionary<short, string> r = new Dictionary<short, string>();
                    r.Add(0, "ID en insert no obtenido.");
                    func.PreparaRetorno(retorno, r);
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
        private Dictionary<short, string> Modificacion(bool procesadetalles)
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
                    foreach (AsientosDet d in Detalles)
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

        //MODIFICACION ESTADO POR ID ASOCIADO
        public Dictionary<short, string> ModificacionAsociados(string _campofiltro, long _idregistro, bool _estado)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                if (_idregistro <= 0)
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

                //INICIO DEL INSERT
                query.Append($"UPDATE {tablaname} SET Estado = '{_estado}' WHERE {_campofiltro} = {_idregistro}");

                //CONEXION
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Modificación Estado.\n{e.Message}");
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
                if (IDRegistro <= 0 && idregistro <= 0)
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

        //REINICIO DE NUMERACION DE ASIENTOS
        public Dictionary<short, string> AsignoFechaCierraAnual()
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

                //INICIO DEL INSERT
                query.Append($"UPDATE {tablaname} SET FechaCierreAnual = '{new DateTime(DateTime.Today.Year, 4, 30)}' WHERE AsientoFecha BETWEEN " +
                    $"'{new DateTime(DateTime.Today.Year - 1, 5, 1)}' AND '{new DateTime(DateTime.Today.Year, 4, 30)}'");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} AsignoFechaCierraAnual.\n{e.Message}");
                return retorno;
            }
        }
        
        //REINICIO DE NUMERACION DE ASIENTOS
        public Dictionary<short, string> ReinicioNumeracionAsientos()
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

                //INICIO DEL INSERT
                //INICIO DEL INSERT
                query.Append($"UPDATE {tablaname} SET AsientoNumero = 0 WHERE FechaCierreAnual IS NULL");

                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //EJECUTO LA ACTUALIZACION
                cmd.ExecuteNonQuery();

                cbd.Desconectar();
                cmd.Dispose();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} ReinicioNumeracionAsientos.\n{e.Message}");
                return retorno;
            }
        }

        //RENUMERACION DE ASIENTOS
        public Dictionary<short, string> RenumeracionAsientos()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {                
                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();
                                
                using (var command = new SqlCommand("AmdgoContable.dbo.sp_RenumeracionAsientos", SqlConnection){CommandType = CommandType.StoredProcedure})
                {                    
                    command.ExecuteNonQuery();
                }


                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Renumeración.\n{e.Message}");
                return retorno;
            }
        }
        
        #endregion
    }
}
