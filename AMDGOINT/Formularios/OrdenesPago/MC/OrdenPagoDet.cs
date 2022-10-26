using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.OrdenesPago.MC
{
    public class OrdenPagoDet : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[ts_ORDENESPAGODET]";

        public long IDRegistro { get; set; } = 0;
        public long IDEncabezado { get; set; } = 0;
        public long RetiroID { get; set; } = 0;
        public int PlanCuentaID { get; set; } = 0;
        public string PlanCuentaCodigoCorto { get; set; } = "";
        public string PlanCuentaNombre { get; set; } = "";
        public string PlanCuentaCompleto { get { return PlanCuentaCodigoCorto + " " + PlanCuentaNombre; } }
        public int PlanSubCuentaID { get; set; } = 0;
        public string PlanSubCuentaCodigoCorto { get; set; } = "";
        public string PlanSubCuentaNombre { get; set; } = "";
        public string PlanSubCuentaCompleto { get { return PlanSubCuentaCodigoCorto + " " + PlanSubCuentaNombre; } }
        public short BancoID { get; set; } = 0;
        public string BancoNombre { get; set; } = "";
        public string BancoCodigo { get; set; } = "";
        public string BancoCompleto { get { return BancoCodigo + " " + BancoNombre; } }
        public string Descripcion { get; set; } = "";
        public byte ModoPago { get; set; } = 1;
        public string ModoPagoDescripcion { get { return ModoPago == 0 ? "Efectivo" : ModoPago == 1 ? "Transferencia" : "Cheque"; } }
        public bool _BorraRegistro { get; set; } = false;
        public decimal Importe { get; set; } = 0;
        public decimal ImportesSingo { get { return Math.Abs(Importe); } }
        public List<Caja.MC.CajaMovimientos> MovimientosCaja { get; set; } = new List<Caja.MC.CajaMovimientos>();
        public List<AsientosContables.MC.AsientosDet> AsientosContables { get; set; } = new List<AsientosContables.MC.AsientosDet>();
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
        public OrdenPagoDet() { }

        public OrdenPagoDet(SqlConnection conexion)
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
        public OrdenPagoDet Clone()
        {
            OrdenPagoDet d = (OrdenPagoDet)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<OrdenPagoDet> Clone(List<OrdenPagoDet> lst)
        {
            List<OrdenPagoDet> lista = new List<OrdenPagoDet>();                       
            lst.ForEach(f => lista.Add(f.Clone()));

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<OrdenPagoDet> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<OrdenPagoDet> lista = new List<OrdenPagoDet>();

                string c = $"SELECT OD.IDRegistro, OD.IDEncabezado, OD.RetiroID, OD.PlanCuentaID, OD.PlanSubCuentaID, OD.Descripcion, OD.ModoPago, OD.Importe, OD.BancoID," +
                           $" PC.CodigoCorto AS PlanCuentaCodigoCorto, PC.Descripcion AS PlanCuentaNombre, PSC.Codigo AS PlanSubCuentaCodigoCorto, PSC.Descripcion AS PlanSubCuentaNombre," +
                           $" BA.Codigo AS BancoCodigo, BA.Descripcion AS BancoNombre" +
                           $" FROM {tablaname} OD" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANCUENTAS] PC ON(PC.IDRegistro = OD.PlanCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[pc_PLANSUBCUENTAS] PSC ON(PSC.IDRegistro = OD.PlanSubCuentaID)" +
                           $" LEFT OUTER JOIN [AmdgoContable].[dbo].[BANCOS] BA ON(BA.IDRegistro = OD.BancoID)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<OrdenPagoDet>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<OrdenPagoDet>();
            }
        }

        //CREACION DE ASIENTOS CONTABLES
        public void GeneraAsientos()
        {
            try
            {
                //PLANES CONTABLES
                CuentasContables.MC.Cuentas ctas = new CuentasContables.MC.Cuentas(SqlConnection);
                List<CuentasContables.MC.Cuentas> lst = ctas.GetRegistros().Where(w => w.Estado && w.Seleccionable).ToList();
                byte _cuentaorigen = lst.Where(w => w.IDRegistro == PlanCuentaID).Select(s => s.CuentaOrigen).First();

                MovimientosCaja.Clear();
                                
                if (_BorraRegistro || Importe == 0) { return; }

                AsientosContables.Add(new AsientosContables.MC.AsientosDet
                {
                    PlanCuentaID = PlanCuentaID,
                    PlanSubCuentaID = PlanSubCuentaID,
                    Descripcion = Descripcion,                    
                    ImporteDebe = Importe,
                });

                
                //MOVIMIENTO AUTOMATICO (CUENTA DE SALIDA) BANCO, CAJA, ETC.
                if (ModoPago == 0) //EFECTIVO
                {
                    AsientosContables.Add(new AsientosContables.MC.AsientosDet
                    {                        
                        PlanCuentaID = 3,
                        PlanSubCuentaID = 0,
                        Descripcion = Descripcion,                        
                        ImporteHaber = Importe
                    });
                }
                else if (ModoPago == 1 || ModoPago == 2) //TRANSFERENCIAS / CHEQUES
                {
                    AsientosContables.Add(new AsientosContables.MC.AsientosDet
                    {                        
                        PlanCuentaID = BancoID == 1 ? 8 : BancoID == 2 ? 6 : BancoID == 102 ? 7 : 0,
                        PlanSubCuentaID = 0,
                        Descripcion = Descripcion,                        
                        ImporteHaber = Importe
                    });
                }                
          
                return;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el asiento contable.\n{e.Message}", 1);
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
            campos.Add("RetiroID");
            campos.Add("PlanCuentaID");
            campos.Add("PlanSubCuentaID");
            campos.Add("Descripcion");
            campos.Add("ModoPago");
            campos.Add("BancoID");
            campos.Add("Importe");            
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
                //cmd.ExecuteNonQuery();
                IDRegistro = (long)cmd.ExecuteScalar();
                
                /*if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (Caja.MC.CajaMovimientos d in MovimientosCaja)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.OrdenPagoDetalleID = IDRegistro;
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                }*/

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
                
               /* if (IDRegistro > 0)
                {
                    //PRIMERO BORRO LOS DETALLES GENERADOS EN LA CAJA PARA ESE ASIENTO.
                    Caja.MC.CajaMovimientos _caja = new Caja.MC.CajaMovimientos(SqlConnection);
                    var di = _caja.Eliminacion(IDRegistro, "OrdenPagoDetalleID");
                    func.PreparaRetorno(retorno, di);

                    //LUEGO INSERTO LOS NUEVOS
                    foreach (Caja.MC.CajaMovimientos d in MovimientosCaja)
                    {
                        //ASIGNO CONNEXION
                        d.SqlConnection = SqlConnection;
                        d.OrdenPagoDetalleID = IDRegistro;                        
                        var dic = d.Abm();
                        func.PreparaRetorno(retorno, dic);
                    }

                }*/


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

                //BORRO LOS POSIBLES ASIENTOS AUTOMATICOS DEL DETALLES
                /*if (IDRegistro > 0)
                {
                    //PRIMERO BORRO LOS DETALLES GENERADOS EN LA CAJA PARA ESE ASIENTO.
                    Caja.MC.CajaMovimientos _caja = new Caja.MC.CajaMovimientos(SqlConnection);
                    var di = _caja.Eliminacion(IDRegistro, "OrdenPagoDetalleID");
                    func.PreparaRetorno(retorno, di);                    
                }*/

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
