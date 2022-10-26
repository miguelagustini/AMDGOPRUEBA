using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class FacturaDet : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES
        private static string tablaname = "AmdgoInterno.dbo.FACTAMBUDET";
        private static string tablasubname = "AmdgoInterno.dbo.FACTAMBUENC";

        private long idregistro = 0;
        private long idencabezado = 0;
        private DateTime fechapractica = DateTime.Today;        
        private string codpract = "";
        private string descpract = "";
        private string funcion = "";
        private long docupaci = 0;
        private string nombrepaci = "";
        private decimal ivaporc = 0;
        private decimal cantidad = 0;
        private decimal preciounitario = 0;
        private decimal neto = 0;
        private decimal nogravado = 0;
        private decimal iva = 0;
        private decimal total = 0;
        private decimal medicamentos = 0;
        private decimal honorarios = 0;
        private decimal gastos = 0;
        private long puntero = 0;
        private int idcuentaprof = 0;
        private int idprestdetalle = 0;
        private string funciondesc = "";
        private string descripcionrel = "";
        private string nrobusqueda = "";
        private bool _seleccionado = false;
        private string _descripcionmanual = "";        
        private string numeroint = "";


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

        public long IDEncabezado 
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

        public DateTime FechaPract
        {
            get { return fechapractica; }
            set
            {
                if (fechapractica != value)
                {
                    fechapractica = value;
                }
            }
        }

        public string CodPract
        {
            get { return codpract; }
            set
            {
                if (codpract != value.Trim())
                {
                    codpract = value.Trim();
                }
            }
        }

        public string DescrPract
        {
            get { return descpract; }
            set
            {
                if (descpract != value.Trim())
                {
                    descpract = value.Trim();
                }
            }
        }

        public string Funcion
        {
            get { return funcion; }
            set
            {
                if (funcion != value.Trim())
                {
                    funcion = value.Trim();
                }
            }
        }

        public string FuncionDesc
        {
            get { return funciondesc; }
            set
            {
                if (funciondesc != value.Trim())
                {
                    funciondesc = value.Trim();
                }
            }
        }

        public long DocuPaci
        {
            get { return docupaci; }
            set
            {
                if (docupaci != value)
                {
                    docupaci = value;
                }
            }
        }
        
        public string NombrePaci
        {
            get { return nombrepaci; }
            set
            {
                if (nombrepaci != value.Trim())
                {
                    nombrepaci = value.Trim();
                }
            }
        }
               
        public decimal IvaPorc
        {
            get { return ivaporc; }
            set
            {
                if (ivaporc != value)
                {
                    ivaporc = value;
                }
            }
        }

        public decimal Cantidad
        {
            get { return cantidad; }
            set
            {
                if (cantidad != value)
                {
                    cantidad = value;
                }
            }
        }

        public decimal PrecioUnitario
        {
            get { return preciounitario; }
            set
            {
                if (preciounitario != value)
                {
                    preciounitario = value;
                }

            }
        }

        public decimal Medicamentos
        {
            get { return medicamentos; }
            set { medicamentos = medicamentos != value ? value : medicamentos; }
        }

        public decimal Honorarios
        {
            get { return honorarios; }
            set { honorarios = honorarios != value ? value : honorarios; }
        }

        public decimal Gastos
        {
            get { return gastos; }
            set { gastos = gastos != value ? value : gastos; }
        }
        
        public decimal Neto
        {
            get { return neto; }
            set
            {
                if (neto != value)
                {
                    neto = value;
                }
            }
        }
               
        public decimal NoGravado
        {
            get { return nogravado; }
            set
            {
                if (nogravado != value)
                {
                    nogravado = value;
                }
            }
        }

        public decimal Iva
        {
            get { return iva; }
            set
            {
                if (iva != value)
                {
                    iva = value;
                }
            }
        }
              
        public decimal Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                }
            }
        }

        public int BonoNumero { get; set; } = 0;

        public long Puntero
        {
            get { return puntero; }
            set
            {
                if (puntero != value)
                {
                    puntero = value;
                }
            }
        }

        public string Descripcionrel
        {
            get { return descripcionrel; }
            set
            {
                if (descripcionrel != value.Trim())
                {
                    descripcionrel = value.Trim();
                }
            }
        }

        public int IDCuentaProf
        {
            get { return idcuentaprof; }
            set
            {
                if (idcuentaprof != value)
                {
                    idcuentaprof = value;
                }
            }

        }

        public int IDPrestDetalle
        {
            get { return idprestdetalle; }
            set
            {
                if (idprestdetalle != value)
                {
                    idprestdetalle = value;
                }
            }
        }

        public string NumeroBusqueda
        {
            get { return nrobusqueda.Trim(); }
            set { nrobusqueda = nrobusqueda.Trim() != value.Trim() ? value.Trim() : nrobusqueda; }
        }

        public string DescripcionManual
        {
            get { return _descripcionmanual.Trim(); }
            set { _descripcionmanual = _descripcionmanual != value.Trim() ? value.Trim() : _descripcionmanual; }
        }
                
        public string InternacionNumero
        {
            get { return numeroint; }
            set { numeroint = numeroint != value.Trim() ? value.Trim() : numeroint; }
        }
        
        public bool Seleccionado
        {
            get { return _seleccionado; }
            set { _seleccionado = _seleccionado != value ? value : _seleccionado; }
        }

        public long IDReclamoDetalle { get; set; } = 0;

        public List<FacturaDet> Detalles = new List<FacturaDet>();

        //REFERENTES BD
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public long ID_Encabezado { get { return IDEncabezado; } }                
        public string Guid { get { return IDLocal; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public FacturaDet() { }

        public FacturaDet(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion
        
        //CLONACION
        #region CLONE

        //CLONE 
        public FacturaDet Clone()
        {
            FacturaDet d = (FacturaDet)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<FacturaDet> Clone(List<FacturaDet> lst)
        {
            List<FacturaDet> lista = new List<FacturaDet>();

            foreach (FacturaDet d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion
        
        //EVENTOS DE PROPERTY CHANGED
        #region  PROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion


        //RETORNO DE LISTA REGISTROS
        #region CONSULTA DE DATOS
        public List<FacturaDet> GetRegistros()
        {
            try
            {
                #region DETALLES VINCULADOS
                //CONSULTO LA LISTA GENERAL DE REGISTROS
                List<FacturaDet> lista = new List<FacturaDet>();

                string c = $"SELECT FD.ID_Registro AS IDRegistro, FD.ID_Encabezado as IDEncabezado, FD.FechaPract, FD.CodPract, FD.DescrPract, FD.Funcion, " +
                           $" FD.DocuPaci, FD.NombrePaci, FD.IvaPorc, FD.Cantidad, FD.PrecioUnitario, FD.Neto, FD.NoGravado, FD.Iva, FD.Total, FD.Guid AS IDLocal," +
                           $" FD.Puntero, FN.Descripcion AS FuncionDesc, FD.DescripcionManual, FD.Honorarios, FD.Medicamentos, FD.Gastos" +
                           $" ,ISNULL(MD.MED2NBUS,'') AS NumeroBusqueda, FD.IDReclamoDetalle, FD.IDReclamoDetalle," +
                           $" ISNULL(MD.MED2BONO, 0) AS BonoNumero" +
                           $" FROM {tablasubname} FE" +
                           $" LEFT OUTER JOIN {tablaname} FD ON(FD.ID_Encabezado = FE.ID_Registro)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.FUNCIONES FN ON(FN.Codigo = FD.Funcion)" + 
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCMED2 MD ON (MD.MED2PUNT = FD.Puntero AND FE.InternacionNumero = '')";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<FacturaDet>(rdr));
                }

                #endregion

                #region DETALLES NO VINCULADOS

                c = $"SELECT FE.ID_Registro AS IDEncabezado, FE.Total," +
                    $" IIF(FC.Numero > 0, CONCAT('Según factura Nº ', FC.Letra, ' ', FORMAT(FC.PuntoVenta, '0000'), ' - ', FORMAT(FC.Numero, '00000000'))," +
                    $" CONCAT('Según factura Nº ', FR.Comprobante)) AS Descripcionrel" +
                    $" FROM {tablasubname} FE" +
                    $" LEFT OUTER JOIN FACTAMBUREL FR ON(" +
                    $" (CASE WHEN FR.ID_NotaCredito > 0 THEN FR.ID_NotaCredito WHEN FR.ID_NotaDebito > 0" +
                    $" THEN FR.ID_NotaDebito else FR.ID_NotaCredito end) = FE.ID_Registro)" +
                    $" LEFT OUTER JOIN {tablasubname} FC ON(FC.ID_Registro = FR.ID_Factura)" +
                    $" WHERE FC.Numero > 0 OR FR.Comprobante <> ''";
                                

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<FacturaDet>(rdr));
                }

                cnb.Desconectar();

                #endregion
                              
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<FacturaDet>();
            }
        }

        //LISTA DE RECLAMOS PENDIENTES DE FACTURACION


        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm(List<FacturaDet> abmlista = null)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0)
            {
                //ABM POR LISTA
                if (abmlista != null)
                {
                    return AltaLista(abmlista);
                }
                //ABM POR REGISTRO
                else { return Alta(); }
            }
            else if (IDRegistro > 0)
            {
                return Modificacion();
            }
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("ID_Encabezado");
            campos.Add("FechaPract");
            campos.Add("CodPract");
            campos.Add("DescrPract"); 
            campos.Add("DescripcionManual");
            campos.Add("Funcion");
            campos.Add("DocuPaci");
            campos.Add("NombrePaci");
            campos.Add("IvaPorc");
            campos.Add("Cantidad");
            campos.Add("Neto");
            campos.Add("NoGravado");
            campos.Add("Iva");
            campos.Add("Medicamentos");
            campos.Add("Honorarios");
            campos.Add("Gastos");
            campos.Add("Total");
            campos.Add("Guid");
            campos.Add("Puntero");
            campos.Add("IDReclamoDetalle");
            
            return campos;
        }

        private Dictionary<short, string> AltaLista(List<FacturaDet> abmlista)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //CONEXION
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();

                string a = $"INSERT INTO {tablaname} (ID_Encabezado, FechaPract, CodPract, DescrPract, DescripcionManual, Funcion, DocuPaci, NombrePaci," +
                           $" IvaPorc, Cantidad, Neto, NoGravado, Iva, Total, Medicamentos, Honorarios, Gastos, Guid, Puntero, IDReclamoDetalle) VALUES";

                for (int i = 0; i < abmlista.Count; i += 1000)
                {
                    List<FacturaDet> insertlist = abmlista.Skip(i).Take(1000).ToList();

                    foreach (FacturaDet av in insertlist)
                    {
                        query.Append(a + $"({av.IDEncabezado}, '{av.FechaPract}', '{av.CodPract}', '{av.DescrPract}', '{av.DescripcionManual}', '{av.Funcion}', {av.DocuPaci}," +
                                         $"'{av.NombrePaci}', {av.IvaPorc.ToString(new CultureInfo("en-US"))}, {av.Cantidad.ToString(new CultureInfo("en-US"))}," +
                                         $" {av.Neto.ToString(new CultureInfo("en-US"))}, {av.NoGravado.ToString(new CultureInfo("en-US"))}, {av.Iva.ToString(new CultureInfo("en-US"))}," +
                                         $" {av.Total.ToString(new CultureInfo("en-US"))}, {av.Medicamentos.ToString(new CultureInfo("en-US"))}, {av.Honorarios.ToString(new CultureInfo("en-US"))}," +
                                         $" {av.Gastos.ToString(new CultureInfo("en-US"))}, '{av.Guid}', {av.Puntero}, {av.IDReclamoDetalle});");                               
                    }

                    using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (query.ToString() != "")
                            {
                                command.Connection = SqlConnection;
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = query.ToString();
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }

                        }
                    }

                    query.Clear();

                }

                cbd.Desconectar();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Alta Lista.\n{e.Message}");
                return retorno;
            }

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

                //DEFINO CONNEXION EN CASO DE NO HABER UNA
                ConexionBD cbd = new ConexionBD();
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cbd.Conectar();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
                campos.Remove("ID_Encabezado");
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
                query.Append($" WHERE (ID_Registro = {IDRegistro})");

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

    public class DetallesPrint
    {
        //PROPIEDADES
        #region PROPIEDADES
        
        private string codpract = "";
        private long docupaci = 0;
        private string nombrepaci = "";
        private decimal ivaporc = 0;
        private decimal cantidad = 0;
        private decimal preciounitario = 0;
        private decimal neto = 0;
        private decimal nogravado = 0;
        private decimal iva = 0;
        private decimal total = 0;        
        private string funciondesc = "";
        private string descripcionrel = "";
        private string descripcionman = "";

        public string CodPract
        {
            get { return codpract; }
            set
            {
                if (codpract != value.Trim())
                {
                    codpract = value.Trim();
                }
            }
        }

        public string FuncionDesc
        {
            get { return funciondesc; }
            set
            {
                if (funciondesc != value.Trim())
                {
                    funciondesc = value.Trim();
                }
            }
        }

        public long DocuPaci
        {
            get { return docupaci; }
            set
            {
                if (docupaci != value)
                {
                    docupaci = value;
                }
            }
        }

        public string NombrePaci
        {
            get { return nombrepaci; }
            set
            {
                if (nombrepaci != value.Trim())
                {
                    nombrepaci = value.Trim();
                }
            }
        }

        public string Descripcionrel
        {
            get { return descripcionrel; }
            set
            {
                if (descripcionrel != value.Trim())
                {
                    descripcionrel = value.Trim();
                }
            }
        }
        
        public string DescripcionManual
        {
            get { return descripcionman; }
            set { descripcionman = descripcionman != value.Trim() ? value.Trim() : descripcionman; }
        }

        public string Descripcion
        {
            get
            {
                string c = "";

                if (!string.IsNullOrEmpty(DescripcionManual))
                {
                    c = DescripcionManual;
                }
                else if (!string.IsNullOrWhiteSpace(Descripcionrel))
                {
                    c = Descripcionrel;
                }
                else
                {
                    if (docupaci > 0)
                    {
                        c = $"{FuncionDesc} - {DocuPaci} {NombrePaci}";
                    }
                    else
                    {
                        c = FuncionDesc;
                    }
                }

                return c;
            }
        }


        public decimal IvaPorc
        {
            get { return ivaporc; }
            set
            {
                if (ivaporc != value)
                {
                    ivaporc = value;
                }
            }
        }

        public decimal Cantidad
        {
            get { return cantidad; }
            set
            {
                if (cantidad != value)
                {
                    cantidad = value;
                }
            }
        }

        public decimal PrecioUnitario
        {
            get { return preciounitario; }
            set
            {
                if (preciounitario != value)
                {
                    preciounitario = value;
                }

            }
        }

        public decimal Neto
        {
            get { return neto; }
            set
            {
                if (neto != value)
                {
                    neto = value;
                }
            }
        }

        public decimal NoGravado
        {
            get { return nogravado; }
            set
            {
                if (nogravado != value)
                {
                    nogravado = value;
                }
            }
        }

        public decimal Iva
        {
            get { return iva; }
            set
            {
                if (iva != value)
                {
                    iva = value;
                }
            }
        }

        public decimal Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                }
            }
        }

        #endregion

    }
}
