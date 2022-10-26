using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.AsientosContables.MC
{
    public class AsientosDet: INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        public static string tablaname = "[AmdgoContable].[dbo].[ts_ASIENTOSCNTBLDET]";

        public long IDRegistro { get; set; } = 0;
        public long IDEncabezado { get; set; } = 0;
        public int PaseNumero { get; set; } = 0;
        public int AsientoNumero { get; set; } = 0;
        public DateTime AsientoFecha { get; set; } = DateTime.MinValue;
        public DateTime FechaConciliacion { get; set; } = DateTime.MinValue;
        public long MovimientoCajaID { get; set; } = 0;
        public long OrdenPagoDetalleID { get; set; } = 0;
        public long OrdenPagoID { get; set; } = 0;
        public int PlanCuentaID { get; set; } = 0;
        public string PlanCuentaCodigoCorto { get; set; } = string.Empty;
        public string PlanCuentaCodigoLargo { get; set; } = string.Empty;
        public string PlanCuentaNombre { get; set; } = string.Empty;
        public string PlanCuentaCompleto { get { return PlanCuentaCodigoCorto + " " + PlanCuentaNombre; } }
        public string PlanCuentaCompletoExtenso { get { return PlanCuentaCodigoLargo + " " + PlanCuentaNombre; } }
        public int PlanSubCuentaID { get; set; } = 0;
        public string PlanSubCuentaCodigoCorto { get; set; } = string.Empty;        
        public string PlanSubCuentaNombre { get; set; } = string.Empty;
        public string PlanSubCuentaCompleto { get { return PlanSubCuentaCodigoCorto + " " + PlanSubCuentaNombre; } }        
        public string Descripcion { get; set; } = string.Empty;
        public decimal ImporteDebe { get; set; } = 0;
        public decimal ImporteHaber { get; set; } = 0;
        public bool _BorraRegistro { get; set; } = false;
        public bool Conciliado { get; set; } = false;
        public bool _AjusteManualOrigenAutomaticos { get; set; } = false;
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
        public AsientosDet() { }

        public AsientosDet(SqlConnection conexion)
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
        public AsientosDet Clone()
        {
            AsientosDet d = (AsientosDet)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<AsientosDet> Clone(List<AsientosDet> lst)
        {
            List<AsientosDet> lista = new List<AsientosDet>();
            lst.ForEach(f => lista.Add(f.Clone()));

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<AsientosDet> GetRegistros(long idencabezado = 0)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<AsientosDet> lista = new List<AsientosDet>();

                string c = $"SELECT MD.IDRegistro, MD.IDEncabezado, MD.MovimientoCajaID, MD.PlanCuentaID, MD.PlanSubCuentaID, MD.Descripcion, MD.FechaConciliacion, MD.ImporteDebe," +
                           $" MD.ImporteHaber, ISNULL(PC.CodigoCorto, '') AS PlanCuentaCodigoCorto, ISNULL(PC.CodigoLargo, '') AS PlanCuentaCodigoLargo,  ISNULL(PC.Descripcion, '') AS PlanCuentaNombre," +
                           $" ISNULL(PSC.Codigo, '') AS PlanSubCuentaCodigoCorto, ISNULL(PSC.Descripcion, '') AS PlanSubCuentaNombre, MD.PaseNumero, MD.OrdenPagoID" +                           
                           $" FROM {tablaname} MD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANCUENTAS] PC ON(PC.IDRegistro = MD.PlanCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANSUBCUENTAS] PSC ON(PSC.IDRegistro = MD.PlanSubCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[ts_ASIENTOSCNTBLENC] ME ON(ME.IDRegistro = MD.IDEncabezado)" +
                           $" WHERE ME.FechaCierreAnual IS NULL {(idencabezado > 0 ? "AND MD.IDEncabezado = " + idencabezado  : "")}";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<AsientosDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<AsientosDet>();
            }
        }

        public List<AsientosDet> GetRegistros(DateTime _desde, DateTime _hasta, int _idplancuenta)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<AsientosDet> lista = new List<AsientosDet>();

                string c = $"SELECT MD.IDRegistro, MD.IDEncabezado, MD.MovimientoCajaID, MD.PlanCuentaID, MD.PlanSubCuentaID, MD.Descripcion, MD.FechaConciliacion, MD.ImporteDebe," +
                           $" MD.ImporteHaber, ISNULL(PC.CodigoCorto, '') AS PlanCuentaCodigoCorto, ISNULL(PC.CodigoLargo, '') AS PlanCuentaCodigoLargo,  ISNULL(PC.Descripcion, '') AS PlanCuentaNombre," +
                           $" ISNULL(PSC.Codigo, '') AS PlanSubCuentaCodigoCorto, ISNULL(PSC.Descripcion, '') AS PlanSubCuentaNombre, MD.PaseNumero, ME.AsientoFecha, ME.AsientoNumero," +
                           $" CAST(IIF(MD.FechaConciliacion IS NOT NULL, 1, 0) AS BIT) AS Conciliado" +
                           $" FROM {tablaname} MD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANCUENTAS] PC ON(PC.IDRegistro = MD.PlanCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANSUBCUENTAS] PSC ON(PSC.IDRegistro = MD.PlanSubCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[ts_ASIENTOSCNTBLENC] ME ON(ME.IDRegistro = MD.IDEncabezado)" +
                           $" WHERE ME.AsientoFecha BETWEEN '{_desde}' AND '{_hasta}' AND MD.PlanCuentaID = {_idplancuenta}";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<AsientosDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<AsientosDet>();
            }
        }


        private void SetNumeroPase()
        {
            try
            {
                string c = $"SELECT MAX(PaseNumero) AS ComprobanteNumero FROM {tablaname} WHERE IDEncabezado = {IDEncabezado}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    PaseNumero = Convert.ToInt32(r["ComprobanteNumero"] != DBNull.Value ? r["ComprobanteNumero"] : 0)+1;
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el número de asiento.\n{e.Message}", 1);
                return;
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

            campos.Add("IDEncabezado");
            campos.Add("PaseNumero");
            campos.Add("MovimientoCajaID");
            campos.Add("OrdenPagoID");
            campos.Add("PlanCuentaID");
            campos.Add("PlanSubCuentaID");
            campos.Add("Descripcion");
            campos.Add("FechaConciliacion");
            campos.Add("ImporteDebe");
            campos.Add("ImporteHaber");
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

                //SET PASE NUMERO
                SetNumeroPase();

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

                //SET PASE NUMERO
                if (PaseNumero <= 0) { SetNumeroPase(); }

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
