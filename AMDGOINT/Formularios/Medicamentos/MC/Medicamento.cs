using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AMDGOINT.Formularios.Medicamentos.MC

{
    class Medicamento
    {

        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private ConexionBD cbd = new ConexionBD();

        #endregion

        #region ATRIBUTOS DE LA CLASE

        private static string tablaname = "[AmdgoInterno].[dbo].[MEDICAMENTOS]";
        public long IDRegistro { get; set; } = 0;
        public long Troquel { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Presentacion { get; set; } = string.Empty;
        public decimal Ioma1 { get; set; } = 0;
        public string Ioma2 { get; set; } = string.Empty;
        public string Ioma3 { get; set; } = string.Empty;
        public string Laboratorio { get; set; } = string.Empty;
        public decimal Precio { get; set; } = 0;
        public decimal PrecioCompleto { get; set; } = 0;
        public DateTime Fecha { get; set; } = DateTime.MinValue;
        public string MarcaProdContr { get; set; } = string.Empty;
        public bool Importado { get; set; } = true;
        public string TipoDeVenta { get; set; } = string.Empty;
        public string Iva { get; set; } = string.Empty;
        public string CodPami { get; set; } = string.Empty;
        public int CodLab { get; set; } = 0;
        public int NroRegistro { get; set; } = 0;
        public bool Baja { get; set; } = true;
        public string CodBarra { get; set; } = "";
        public int Unidades { get; set; } = 0;
        public string Tamanio { get; set; } = string.Empty;
        public string Gravamen { get; set; } = string.Empty;
        public string Monodroga { get; set; } = string.Empty;
        public int Homonimo { get; set; } = 0;
        public Boolean EstadoAsoc { get; set; } = true;

        public int IDUsuNew { get; set; } = 0;
        public int IDUsuModif { get; set; } = 0;
        #endregion

        #region PROPIEDADES CALCULADAS
        public string EstadoAsocDescripcion { get { return EstadoAsoc ? "Activo" : "Inactivo"; } }
        public string MarcaProdContrDesc { get {
                switch (MarcaProdContr)
                {
                    case "0": return "No Controlado";
                    case "2": return "Psicotrópico II";
                    case "3": return "Psicotrópico III";
                    case "4": return "Psicotrópico IV";
                    case "6": return "Estupefaciente I";
                    case "7": return "Estupefaciente II";
                    case "8": return "Estupefaciente II";
                    case "9": return "Succinilcolina";
                    case "A": return "Venta Vigilada";
                    default: return "";
                }
            } }
        public string ImportadoDesc {get { return Importado ? "Importado" : "Nacional"; }} 

        public string TipoDeVentaDesc { get {
                switch (TipoDeVenta)
                {
                    case "1": return "Vta. Libre";
                    case "2": return "Vta. Libre bajo receta";
                    case "3": return "Vta. Libre bajo receta archivada";
                    case "4": return "Vta. Libre bajo receta oficial";
                    case "5": return "Pendiente";
                    case "6": return "Bajo control médico recomendado";
                    case "7": return "No clasificado";
                    default: return "";
                }
            } }

        public string CodPamiDesc { get{
                switch (CodPami)
                {
                    case "0": return "Sin descuento";
                    case "1": return "70%";
                    case "2": return "50%";
                    case "3": return "45%";
                    case "4": return "100% Empadronamiento previo";
                    case "5": return "30%";
                    case "6": return "80%";
                    case "7": return "40%";
                    case "8": return "60%";
                    case "9": return "65%";
                    case "A": return "Uso autorizado";
                    case "B": return "55%";
                    case "C": return "75%";
                    case "D": return "35%";
                    case "E": return "100% Con autorización previa";
                    default: return "";
                }
            } }

        public string TamanioDesc { get
            {
                switch (Tamanio)
                {
                    case "1": return "Menor";
                    case "2": return "Siguiente";
                    case "3": return "Grande (de dos presentaciones)";
                    case "4": return "Gigante";
                    case "5": return "Grande (mas de dos presentaciones)";
                    case "6": return "Antibiótico monodosis";
                    case "7": return "Antibiótico multidosis";
                    case "8": return "Soluciones parenterales";
                    case "9": return "Hospitalario";
                    case "A": return "No clasificado";
                    default: return "";
                }
            } }

        public string BajaDesc { get { return Baja ? "Prestación dada de baja" : "Prestación activa"; } }


        #endregion
        
        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Medicamento() { }

        public Medicamento(SqlConnection conexion)
        {
        }

        #endregion


        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();
            campos.Add("Troquel");
            campos.Add("Nombre");
            campos.Add("Presentacion");
            campos.Add("Ioma1");
            campos.Add("Ioma2");
            campos.Add("Ioma3");
            campos.Add("Laboratorio");
            campos.Add("Precio");
            campos.Add("PrecioCompleto");
            campos.Add("Fecha");
            campos.Add("MarcaProdContr");
            campos.Add("Importado");
            campos.Add("TipoDeVenta");
            campos.Add("Iva");
            campos.Add("CodPami");
            campos.Add("CodLab");
            campos.Add("NroRegistro");
            campos.Add("Baja");
            campos.Add("CodBarra");
            campos.Add("Unidades");
            campos.Add("Tamanio");
            campos.Add("Gravamen");
            campos.Add("Monodroga");

            return campos;
        }

        public Dictionary<short, string> Abm(bool t)
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();


            if (IDRegistro <= 0)
            {
                return Alta();
            }
            else if (IDRegistro > 0)
            {
                return Modificacion(t);
            }
            else
            {
                retorno.Add(0, $"{GetType().Name}. No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }


        #region GET REGISTROS
        public List<Medicamento> GetRegistros()

        {
            try
            {
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Medicamento> lista = new List<Medicamento>();

                string c = $"SELECT * FROM {tablaname}";


                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, glb.GetConexion().State != ConnectionState.Open ? cbd.Conectar() : glb.GetConexion()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Medicamento>(rdr));
                }

                cbd.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Medicamento>();
            }
        }



        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> AltaLista(List<Medicamento> listaAlta)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();
                                
                //INICIO DEL INSERT
                string a = $"INSERT INTO {tablaname} (";

                //AGREGO LOS CAMPOS
                foreach (string c in campos)
                {
                    a+= $"{c},";
                }

                //REMUEVO LA ULTIMA COMA Y REEPLAZO POR PARENTESIS DE CIERRE
                a= a.Substring(0, a.Length-1) + ") VALUES";

                for (int i = 0; i < listaAlta.Count; i += 500)
                {
                    List<Medicamento> insertlist = listaAlta.Skip(i).Take(500).ToList();

                    foreach (Medicamento av in insertlist)
                    {
                        query.Append( a+ $"({av.Troquel}, '{av.Nombre}', '{av.Presentacion}', {av.Ioma1.ToString(new CultureInfo("en-US"))}, '{av.Ioma2}', '{av.Ioma3}'," +
                                         $"'{av.Laboratorio}', {av.Precio.ToString(new CultureInfo("en-US"))}, {av.PrecioCompleto.ToString(new CultureInfo("en-US"))}," +
                                         $" '{av.Fecha}', '{av.MarcaProdContr}', {Convert.ToInt16(av.Importado)}, '{av.TipoDeVenta}'," +
                                         $" '{av.Iva}', '{av.CodPami}', {av.CodLab}, {av.NroRegistro},{Convert.ToInt16(av.Baja)}, '{av.CodBarra}', {av.Unidades},'{av.Tamanio}'," +
                                         $" '{av.Gravamen}', {av.Homonimo}, '{av.Monodroga}', {Convert.ToInt16(av.EstadoAsoc)});");
                    }

                    using (SqlTransaction transaction = glb.GetConexion().BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (query.ToString() != "")
                            {
                                command.Connection = glb.GetConexion();
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
                ctrl.MensajeInfo(e.Message, 1);
                return retorno;
            }

        }


        public Dictionary<short, string> ModificacionLista(List<Medicamento> listaModificacion)
        {

            Asocdrog xasocdrog = new Asocdrog();

            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();

                //INICIO DEL UPDATE
                string a = $"UPDATE {tablaname} ";
           

                for (int i = 0; i < listaModificacion.Count; i += 100)
                {
                    List<Medicamento> updatelist = listaModificacion.Skip(i).Take(100).ToList();

                    foreach (Medicamento av in updatelist)
                    {
                        query.Append(a + $"SET NOMBRE ='{av.Nombre}', PRESENTACION ='{av.Presentacion}', IOMA1={av.Ioma1.ToString(new CultureInfo("en-US"))}, " +
                                         $"IOMA2 = '{av.Ioma2}', IOMA3='{av.Ioma3}', LABORATORIO ='{av.Laboratorio}', PRECIO= { av.Precio.ToString(new CultureInfo("en-US"))}," +
                                         $"PRECIOCOMPLETO={av.PrecioCompleto.ToString(new CultureInfo("en-US"))}, FECHA='{av.Fecha}', MARCAPRODCONTR='{av.MarcaProdContr}'," +
                                         $" IMPORTADO ={Convert.ToInt16(av.Importado)}, TIPODEVENTA='{av.TipoDeVenta}',IVA = '{av.Iva}',CODPAMI='{av.CodPami}'," +
                                         $"CODLAB= {av.CodLab}, BAJA={Convert.ToInt16(av.Baja)}, CODBARRA='{av.CodBarra}', " +
                                         $"UNIDADES={av.Unidades},TAMANIO='{av.Tamanio}', GRAVAMEN='{av.Gravamen}', MONODROGA= '{av.Monodroga}'" +
                                         $"WHERE NROREGISTRO = {av.NroRegistro};");
                    }

                    using (SqlTransaction transaction = glb.GetConexion().BeginTransaction())
                    {
                        using (var command = new SqlCommand())
                        {
                            if (query.ToString() != "")
                            {
                                command.Connection = glb.GetConexion();
                                command.Transaction = transaction;
                                command.CommandType = CommandType.Text;
                                command.CommandText = query.ToString();
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }

                        }
                    }

                    query.Clear();

                    //UNA VEZ QUE SE CARGAN TODOS LOS REGISTROS, ACTUALIZAMOS LOS PRECIOS EN LA TABLA XASOCDROG
                    xasocdrog.ActualizarPrecios();

                }

                cbd.Desconectar();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} Modificación Lista.\n{e.Message}");
                ctrl.MensajeInfo(e.Message, 1);
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

                SqlCommand cmd = new SqlCommand(query.ToString(), glb.GetConexion());


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


        //MODIFICACION DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Modificacion(bool t)
        {
           
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {

                IDUsuModif = glb.GetIdUsuariolog();

                //INICIO EL STRING BULDIER
                StringBuilder query = new StringBuilder();
                //RETORNO DE CAMPOS
                List<string> campos = RetornaCampos();

                //AGREGO LOS CAMPOS DE ASOCIACIÓN
                campos.Add("Homonimo");
                campos.Add("EstadoAsoc");


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
                SqlCommand cmd = new SqlCommand(query.ToString(), glb.GetConexion());

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

                nuevoXasocDrog();
                
                if (t)
                {
                    ModificacionAntiguos(IDRegistro, Homonimo);
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


        private Dictionary<short, string> nuevoXasocDrog()
        {

            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                Asocdrog xasocdrog = new Asocdrog();

                xasocdrog.DROGCODI = Homonimo.ToString();
                xasocdrog.DROGDENO = Nombre;
                xasocdrog.DROGPREC= Precio;
                xasocdrog.DROGFACT = DateTime.Now;
                xasocdrog.DROGREST = EstadoAsoc ? "S" : "N";
                xasocdrog.DROGTROQUEL = Convert.ToInt32(Troquel);
                xasocdrog.NROREGISTROALF = NroRegistro;

                xasocdrog.Abm();

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{GetType().Name} NuevoXasocDrog.\n{e.Message}");
                return retorno;
            }
        }

        private Dictionary<short, string> ModificacionAntiguos(long idNuevo, int Homonimo)
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            try
            {
                IDUsuModif = glb.GetIdUsuariolog();


                string actualizarViejo = $"UPDATE {tablaname} SET HOMONIMO = 0 WHERE IDRegistro <> {idNuevo} AND HOMONIMO = {Homonimo}";


                //CONEXION
                SqlCommand cmd = new SqlCommand(actualizarViejo, glb.GetConexion());


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

        #endregion
    }

}