using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Caja.MC
{
    public class CajaMovimientos : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[ts_CAJAMOVIMIENTOS]";

        public long IDRegistro { get; set; } = 0;        
        public int IDSaldoArrastre { get; set; } = 0;
        public DateTime FechaMovimiento { get; set; } = DateTime.Now;                
        public byte ModoPago { get; set; } = 1;
        public string ModoPagoDescripcion { get { return ModoPago == 0 ? "Efectivo" : ModoPago == 1 ? "Transferencia" : ModoPago == 2 ? "Cheque" : ""; } }
        public short BancoID { get; set; } = 1;
        public string BancoNombre { get; set; } = "";
        public string BancoCodigo { get; set; } = "";
        public string BancoCompleto { get { return BancoCodigo + " " + BancoNombre; } }
        public int PlanCuentaID { get; set; } = 0;
        public string PlanCuentaCodigoCorto { get; set; } = "";
        public string PlanCuentaNombre { get; set; } = "";
        public string PlanCuentaCompleto { get { return PlanCuentaCodigoCorto + " " + PlanCuentaNombre; } }
        public int PlanSubCuentaID { get; set; } = 0;
        public string PlanSubCuentaCodigoCorto { get; set; } = "";
        public string PlanSubCuentaNombre { get; set; } = "";
        public string PlanSubCuentaCompleto { get { return PlanSubCuentaCodigoCorto + " " + PlanSubCuentaNombre; } }
        public long ReciboDetalleID { get; set; } = 0;
        public long ReciboID { get; set; } = 0;
        public long OrdenPagoDetalleID { get; set; } = 0;
        public int RetiroEncabezadoID { get; set; } = 0;
        public bool MovimientoManual { get { return ReciboID > 0 || OrdenPagoDetalleID > 0; } } 
        public string Descripcion { get; set; } = "";
        
        //COMPROBANTE ORDEN PAGO
        public string ComprobanteTipoOP { get; set; } = "";
        public string ComprobanteLetraOP { get; set; } = "";
        public int ComprobantePuntoVentaOP { get; set; } = 0;
        public long ComprobanteNumeroOP { get; set; } = 0;
        
        //COMPROBANTE RECIBO
        public string ComprobanteTipoRE { get; set; } = "";
        public string ComprobanteLetraRE { get; set; } = "";
        public int ComprobantePuntoVentaRE { get; set; } = 0;
        public long ComprobanteNumeroRE { get; set; } = 0;

        //COMPROBANTE CALCULADO DESCRIPCION
        public string Comprobante
        {
            get
            {
                return OrdenPagoDetalleID > 0 ? string.Concat(ComprobanteTipoOP, " ", ComprobanteLetraOP, "-", ComprobantePuntoVentaOP.ToString("0000"), ComprobanteNumeroOP.ToString("00000000")) :
                    ReciboID > 0 ? string.Concat(ComprobanteTipoRE, " ", ComprobanteLetraRE, "-", ComprobantePuntoVentaRE.ToString("0000"), ComprobanteNumeroRE.ToString("00000000")) : "";
            }
        }

        //DESCRIPCION EXTENSA
        public string DescripcionExtensa
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Comprobante) && !string.IsNullOrWhiteSpace(Descripcion) ? Comprobante + " - " + Descripcion :
                       !string.IsNullOrWhiteSpace(Comprobante) && string.IsNullOrWhiteSpace(Descripcion) ? Comprobante : Descripcion;


            }
        }

        public decimal ImporteDebe { get; set; } = 0;
        public decimal ImporteHaber { get; set; } = 0;
        public bool Estado { get; set; } = true; //DETERMINA SI EL REGISTRO PUEDE PASAR COMO ASIENTO CONTABLE AL CERRAR LA CAJA O NO               
        public string EstadoDescripcion { get { return Estado ? "Computable" : "Anulado"; } }
        public bool Seleccionado { get; set; } = false;
        public bool _BorrarRegistro { get; set; } = false;
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
        public CajaMovimientos() { }

        public CajaMovimientos(SqlConnection conexion)
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
        public CajaMovimientos Clone()
        {
            CajaMovimientos d = (CajaMovimientos)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<CajaMovimientos> Clone(List<CajaMovimientos> lst)
        {
            List<CajaMovimientos> lista = new List<CajaMovimientos>();

            foreach (CajaMovimientos d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<CajaMovimientos> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<CajaMovimientos> lista = new List<CajaMovimientos>();

                string c = $"SELECT CA.IDRegistro, CA.IDSaldoArrastre, CA.FechaMovimiento, CA.ModoPago, CA.RetiroEncabezadoID," +
                           $" CA.BancoID, CA.PlanCuentaID, CA.PlanSubCuentaID, CA.ReciboID, CA.OrdenPagoDetalleID," +
                           $" CA.Descripcion, CA.ImporteDebe, CA.ImporteHaber, CA.Estado," +
                           $" PC.CodigoCorto AS PlanCuentaCodigoCorto, PC.Descripcion AS PlanCuentaNombre, ISNULL(PSC.Codigo, '') AS PlanSubCuentaCodigoCorto," +
                           $" ISNULL(PSC.Descripcion, '') AS PlanSubCuentaNombre," +
                           $" ISNUll(OE.ComprobanteTipo, '') AS ComprobanteTipoOP, ISNUll(OE.ComprobanteLetra, '') AS ComprobanteLetraOP, ISNUll(OE.ComprobantePuntoVenta, 0) as ComprobantePuntoVentaOP," +
                           $" ISNUll(OE.ComprobanteNumero, 0) as ComprobanteNumeroOP," +
                           $" ISNUll(RE.ComprobanteTipo, '') AS ComprobanteTipoRE, ISNUll(RE.ComprobanteLetra, '') AS ComprobanteLetraRE, ISNUll(RE.ComprobantePuntoVenta, 0) as ComprobantePuntoVentaRE," +
                           $" ISNUll(RE.ComprobanteNumero, 0) as ComprobanteNumeroRE, ISNULL(BA.Codigo, '') AS BancoCodigo, ISNULL(BA.Descripcion, '') as BancoNombre" +
                           $" FROM {tablaname} CA" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.pc_PLANCUENTAS PC ON(PC.IDRegistro = CA.PlanCuentaID)" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.pc_PLANSUBCUENTAS PSC ON(PSC.IDRegistro = CA.PlanSubCuentaID)" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.ts_ORDENESPAGODET OD ON(OD.IDRegistro = CA.OrdenPagoDetalleID)" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.ts_ORDENESPAGOENC OE ON(OE.IDRegistro = OD.IDEncabezado)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.RECIBOSENC RE ON(RE.IDRegistro = CA.ReciboID)" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.BANCOS BA ON (BA.IDRegistro = CA.BancoID)" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.ts_ASIENTOSCNTBLDET MTD ON(MTD.MovimientoCajaID = CA.IDRegistro)" +
                           $" WHERE MTD.IDRegistro IS NULL AND CA.IDSaldoArrastre = 0"; 
                           //+$" AND (CA.ReciboID <= 991 or CA.IDRegistro = 1604)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<CajaMovimientos>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<CajaMovimientos>();
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

            campos.Add("IDSaldoArrastre");
            campos.Add("FechaMovimiento");
            campos.Add("ModoPago");
            campos.Add("BancoID");
            campos.Add("PlanCuentaID");
            campos.Add("PlanSubCuentaID");
            campos.Add("ReciboID");            
            campos.Add("OrdenPagoDetalleID");
            campos.Add("RetiroEncabezadoID");            
            campos.Add("Descripcion");
            campos.Add("ImporteDebe");
            campos.Add("ImporteHaber");
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

            if (_BorrarRegistro) { return retorno; }

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
                if (_BorrarRegistro)
                {
                    var e = Eliminacion(IDRegistro);
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
                query.Append($"UPDATE {tablaname} SET Estado = '{_estado}', TimeModif = '{TimeModif}', IDUsuModif = {IDUsuModif} WHERE {_campofiltro} = {_idregistro}");

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
