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

namespace AMDGOINT.Formularios.Caja.MC
{
    public class CajaSaldoArrastre : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion


        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[ts_CAJASALDOSARRASTRE]";
        private string _usunewname = "";
        public int IDRegistro { get; set; } = 0;
        public DateTime FechaCierre { get; set; } = DateTime.Now;
        public List<CajaMovimientos> Movimientos { get; set; } = new List<CajaMovimientos>();

        public decimal SaldoArrastre { get; set; } = 0;        
        public bool SumaImporte { get { return Movimientos.Where(w => w.Estado && w.OrdenPagoDetalleID == 0).Sum(s => s.ImporteDebe) <= Movimientos.Where(w => w.Estado && w.OrdenPagoDetalleID == 0).Sum(s => s.ImporteHaber); } }
        public decimal SaldoDia
        {
            get
            {
                decimal retorno = 0;

                retorno = Math.Round(Movimientos.Where(w => w.Estado && w.OrdenPagoDetalleID == 0).Sum(s => s.ImporteDebe - s.ImporteHaber), 2);

                return (SumaImporte && retorno < 0) || (!SumaImporte && retorno > 0) ? retorno * -1 : retorno;
            }
        }
        
        public decimal SaldoActual { get { return SaldoArrastre + SaldoDia; } }
        public decimal Saldo{ get { return SaldoActual; } }

        //public decimal SaldoEfectivo { get { return Math.Round(Movimientos.Where(w => w.Estado && w.ModoPago == 0).Sum(s => s.ImporteDebe) - Movimientos.Where(w => w.Estado && w.ModoPago == 0).Sum(s => s.ImporteHaber), 2); } }
        public decimal SaldoEfectivo
        {
            get
            {
                return ImporteArrastreEfectivo + 
                    Math.Round(
                        Movimientos.Where(w => w.Estado && w.ModoPago == 0 && w.PlanCuentaID == 3).Sum(s => s.ImporteDebe) -
                        Movimientos.Where(w => w.Estado && w.ModoPago == 0 && w.PlanCuentaCodigoCorto.StartsWith("5")).Sum(s => s.ImporteDebe)
                    , 2);
            }
        }
        public decimal SaldoTransferencias { get { return ImporteArrastreTransferencia + Math.Round(Movimientos.Where(w => w.Estado && (w.PlanCuentaID >= 6 && w.PlanCuentaID <= 8) && w.ModoPago == 1).Sum(s => s.ImporteDebe - s.ImporteHaber), 2); } }
        public decimal SaldoCheques { get { return ImporteArrastreCheque + Math.Round(Movimientos.Where(w => w.Estado && w.ModoPago == 2 && (w.PlanCuentaID >= 6 && w.PlanCuentaID <= 8)).Sum(s => s.ImporteDebe - s.ImporteHaber), 2); } }

        //IGUALACION BD
        public decimal ImporteEfectivo { get { return SaldoEfectivo; } }
        public decimal ImporteTransferencia { get { return SaldoTransferencias; } }
        public decimal ImporteCheque { get { return SaldoCheques; } }

        public decimal ImporteArrastreEfectivo { get; set; }
        public decimal ImporteArrastreTransferencia { get; set; }
        public decimal ImporteArrastreCheque { get; set; }


        public string UsuarioNewNombre { get { return string.IsNullOrWhiteSpace(_usunewname) ? glb.GetNomUsuariolog() : _usunewname; } set { _usunewname = _usunewname != value ? value : _usunewname; } } 
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
        public CajaSaldoArrastre() { }

        public CajaSaldoArrastre(SqlConnection conexion)
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
        public CajaSaldoArrastre Clone()
        {
            CajaSaldoArrastre d = (CajaSaldoArrastre)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<CajaSaldoArrastre> Clone(List<CajaSaldoArrastre> lst)
        {
            List<CajaSaldoArrastre> lista = new List<CajaSaldoArrastre>();

            foreach (CajaSaldoArrastre d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<CajaSaldoArrastre> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<CajaSaldoArrastre> lista = new List<CajaSaldoArrastre>();
                
                string c = $"SELECT CA.IDRegistro, CA.FechaCierre, CA.Saldo as SaldoArrastre, CA.ImporteEfectivo as ImporteArrastreEfectivo, CA.ImporteTransferencia as ImporteArrastreTransferencia," +
                    $" CA.ImporteCheque as ImporteArrastreCheque, USU.Usuario AS UsuarioNewNombre " +
                    $" FROM {tablaname} CA" +
                    $" LEFT OUTER JOIN [AmdgoInterno].[dbo].[USUARIOS] USU ON(USU.ID_Registro = CA.IDUsuNew)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<CajaSaldoArrastre>(rdr));
                }

                //DETALLES
                #region DETALLES
                CajaMovimientos detcls = new CajaMovimientos(SqlConnection);
                List<CajaMovimientos> d = detcls.GetRegistros();

                foreach (CajaSaldoArrastre p in lista)
                {
                    p.Movimientos = detcls.Clone(d.Where(w => w.IDSaldoArrastre == p.IDRegistro).ToList());
                }

                #endregion


                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<CajaSaldoArrastre>();
            }
        }

        public void setSaldoArrastre()
        {
            try
            {                                
                string c = $"SELECT TOP 1 ISNULL(CA.Saldo, 0) AS SaldoArrastre,  ISNULL(CA.ImporteEfectivo, 0) as ImporteEfectivo, ISNULL(CA.ImporteTransferencia, 0) AS ImporteTransferencia," +
                    $" ISNULL(CA.ImporteCheque, 0) as ImporteCheque" +
                    $" FROM {tablaname} CA ORDER BY CA.FechaCierre DESC";

                ConexionBD cnb = new ConexionBD();

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection).Rows)
                {
                    SaldoArrastre = (decimal)r["SaldoArrastre"];
                    ImporteArrastreEfectivo = (decimal)r["ImporteEfectivo"];
                    ImporteArrastreTransferencia = (decimal)r["ImporteTransferencia"];
                    ImporteArrastreCheque = (decimal)r["ImporteCheque"];
                }

                cnb.Desconectar();
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al setear el saldo.\n{e.Message}", 0);
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

            campos.Add("FechaCierre");
            campos.Add("ImporteEfectivo");
            campos.Add("ImporteTransferencia");
            campos.Add("ImporteCheque");
            campos.Add("Saldo");            
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
                IDRegistro = (int)cmd.ExecuteScalar();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (CajaMovimientos d in Movimientos)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.IDSaldoArrastre = IDRegistro;
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
        public Dictionary<short, string> Eliminacion(long idregistro, string campouso = "IDRegistro")
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
