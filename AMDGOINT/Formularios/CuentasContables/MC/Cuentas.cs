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

namespace AMDGOINT.Formularios.CuentasContables.MC
{
    public class Cuentas : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[pc_PLANCUENTAS]";

        public int IDRegistro { get; set; } = 0;
        public int IDCuentaAgrupadora { get; set; } = 0;
        public string CodigoLargo { get; set; } = "";
        public string CodigoCorto { get; set; } = "";
        public string CodigoLargoAgrupador { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public byte CuentaOrigen
        {
            get
            {
                try
                {
                    byte _nro = 0;
                    byte.TryParse(CodigoLargo.Substring(0, 1), out _nro);
                    return _nro;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public bool UsoReciboPrestataria { get; set; } = false;
        public string UsoReciboPrestatariaDescripcion { get { return UsoReciboPrestataria ? "Si" : "No"; } }
        public bool UsoReciboPrestador { get; set; } = false;
        public string UsoReciboPrestadorDescripcion { get { return UsoReciboPrestador ? "Si" : "No"; } }
        public bool UsoReciboEmpleado { get; set; } = false;
        public string UsoReciboEmpleadoDescripcion { get { return UsoReciboEmpleado ? "Si" : "No"; } }
        public bool UsoReciboTercero { get; set; } = false;
        public string UsoReciboTerceroDescripcion { get { return UsoReciboTercero ? "Si" : "No"; } }

        //ORDEN PAGO
        public bool UsoOrdenPagoPrestador { get; set; } = false;
        public string UsoOrdenPagoPrestadorDescripcion { get { return UsoOrdenPagoPrestador ? "Si" : "No"; } }
        public bool UsoOrdenPagoEmpleado { get; set; } = false;
        public string UsoOrdenPagoEmpleadoDescripcion { get { return UsoOrdenPagoEmpleado ? "Si" : "No"; } }
        public bool UsoOrdenPagoTercero { get; set; } = false;
        public string UsoOrdenPagoTerceroDescripcion { get { return UsoOrdenPagoTercero ? "Si" : "No"; } }
                
        public bool Estado { get; set; } = true;
        public string EstadoDescripcion { get { return Estado ? "Activa" : "Inactiva"; } }
        public byte CuentaTipo { get; set; } = 1;
        public string CuentaTipoDescripcion { get { return CuentaTipo == 0 ? "Integración" : "Movimiento"; } }
        public bool Seleccionable { get; set; } = true;
        public string DescripcionExtendida { get { return CodigoCorto + " " + Descripcion; } }
        public List<SubCuentas> SubCuentas { get; set; } = new List<SubCuentas>();

        public decimal ImporteDebe { get; set; } = 0;
        public decimal ImporteHaber { get; set; } = 0;
        public decimal Saldo { get { return ImporteDebe - ImporteHaber; } }
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
        public Cuentas() { }

        public Cuentas(SqlConnection conexion)
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
        public Cuentas Clone()
        {
            Cuentas r = (Cuentas)MemberwiseClone();
            SubCuentas d = new SubCuentas();

            r.SubCuentas = d.Clone(SubCuentas);
            return r;

        }

        //CLONE CON LISTAS
        public List<Cuentas> Clone(List<Cuentas> lst)
        {
            List<Cuentas> lista = new List<Cuentas>();

            foreach (Cuentas d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Cuentas> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Cuentas> lista = new List<Cuentas>();

                string c = $"SELECT PC.IDRegistro, PC.CodigoLargo, PC.CodigoCorto, PC.Descripcion, PC.Estado, PC.UsoReciboPrestataria, PC.Seleccionable, PC.CuentaTipo, PC.IDCuentaAgrupadora," +
                           $" IIF(PC.IDCuentaAgrupadora > 0, PCE.CodigoLargo, PC.CodigoLargo) AS CodigoLargoAgrupador, PC.UsoReciboPrestador, PC.UsoReciboEmpleado, PC.UsoReciboTercero," +
                           $" PC.UsoOrdenPagoPrestador, PC.UsoOrdenPagoEmpleado, PC.UsoOrdenPagoTercero" +
                           $" FROM {tablaname} PC" +
                           $" LEFT OUTER JOIN {tablaname} PCE ON(PCE.IDRegistro  = PC.IDCuentaAgrupadora)";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Cuentas>(rdr));
                }

                //SUBCUENTAS
                #region SUBCUENTAS
                SubCuentas detcls = new SubCuentas(SqlConnection);
                List<SubCuentas> d = detcls.GetRegistros();

                foreach (Cuentas p in lista)
                {
                    p.SubCuentas = detcls.Clone(d.Where(w => w.IDEncabezado == p.IDRegistro).ToList());
                }

                #endregion

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Cuentas>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        public void SetIDbyCodigoLargo()
        {
            try
            {
                string c = $"SELECT IDRegistro FROM {tablaname} WHERE CodigoLargo = '{CodigoLargo}' AND IDRegistro <> {IDRegistro}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    IDRegistro = Convert.ToInt32(r["IDRegistro"]);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar el ID.\n{e.Message}", 1);
                return;
            }
        }

        //CONSULTO SI EXISTE EL REGISTRO (EVITA REPETIDOS)
        public bool ExisteByField(string _campo, string valor)
        {
            bool retorno = false;

            try
            {
                string c = $"SELECT ISNULL(COUNT(*), 0) AS Cantidad FROM {tablaname} WHERE {_campo} = '{valor}' AND IDRegistro <> {IDRegistro}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    retorno = Convert.ToInt32(r["Cantidad"]) > 0;
                }

                return retorno;
            }
            catch (Exception)
            {
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

            campos.Add("CodigoCorto");
            campos.Add("CodigoLargo");
            campos.Add("Descripcion");
            campos.Add("CuentaTipo");
            campos.Add("IDCuentaAgrupadora");
            campos.Add("UsoReciboPrestataria");
            campos.Add("UsoReciboPrestador");
            campos.Add("UsoReciboEmpleado");
            campos.Add("UsoReciboTercero");

            campos.Add("UsoOrdenPagoPrestador");
            campos.Add("UsoOrdenPagoEmpleado");
            campos.Add("UsoOrdenPagoTercero");


            campos.Add("Seleccionable");
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

                Seleccionable = CuentaTipo == 1;

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
                SetIDbyCodigoLargo();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO DETALLES
                    foreach (SubCuentas d in SubCuentas)
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

        private void Contadot()
        {
            try
            {
                int cont = 0;

                bool continuar = true;

                while (continuar)
                {
                    cont++;
                }


            }
            catch (Exception)
            {

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
                    foreach (SubCuentas d in SubCuentas)
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
