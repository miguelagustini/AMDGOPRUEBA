using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Retiros.MC
{
    public class Encabezado : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "[AmdgoContable].[dbo].[rt_RETIROENCABEZADOS]";

        private int _idregistro = 0;        
        private DateTime _fecha = DateTime.Now;                
        private string _observacion = "";                
        private short _finalizado = 0;        

        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = _fecha != value ? value : _fecha; }
        }

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public short Finalizado
        {
            get { return _finalizado; }
            set { _finalizado = _finalizado != value ? value : _finalizado; }
        }

        public decimal ImporteTotal
        {
            get { return Detalles.Where(w => w.IDEncabezado == IDRegistro).Sum(s => s.Importe); }            
        }

        public decimal ImporteAprobado
        {
            get { return Detalles.Where(w => w.IDEncabezado == IDRegistro && w.Estado == 1).Sum(s => s.Importe); }            
        }

        public List<Retiros> Detalles { get; set; } = new List<Retiros>();

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
                
        public string Guid { get => IDLocal; }

        public short IDUsuNew { get => Convert.ToInt16(glb.GetIdUsuariolog()); }
        public short IDUsuModif { get => Convert.ToInt16(glb.GetIdUsuariolog()); }
        public DateTime TimeModif { get => DateTime.Now; }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Encabezado() { }

        public Encabezado(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region EVENTOS DE LA CLASE

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        //CLONACION
        #region CLONE

        //CLONE 
        public Encabezado Clone()
        {
            Encabezado d = (Encabezado)MemberwiseClone();

            Retiros deta = new Retiros();
            d.Detalles = deta.Clone(Detalles);

            return d;
        }

        //CLONE CON LISTAS
        public List<Encabezado> Clone(List<Encabezado> lst)
        {
            List<Encabezado> lista = new List<Encabezado>();

            foreach (Encabezado d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Encabezado> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Encabezado> lista = new List<Encabezado>();

                string c = $"SELECT RE.IDRegistro, RE.Guid AS IDLocal, RE.Fecha, RE.Finalizado FROM {tablaname} RE";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Encabezado>(rdr));
                }

                cnb.Desconectar();

                //DETALLES DE RETIROS
                #region RETIROS
                Retiros de = new Retiros(SqlConnection);
                List<Retiros> t1 = de.GetRegistros();

                lista.ForEach(f => f.Detalles = de.Clone(t1.Where(w => w.IDEncabezado == f.IDRegistro).ToList()));
                
                #endregion

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Encabezado>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void SetIdbyguid()
        {
            string c = $"SELECT IDRegistro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt32(r["IDRegistro"]);
            }
        }

        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0 && IDLocal.Length > 0)
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

            campos.Add("Guid");
            campos.Add("Fecha");                                    
            campos.Add("Finalizado");
            campos.Add("IDUsuNew");
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
                SetIdbyguid();

                if (IDRegistro > 0)
                {
                    //ACTUALIZO RETIROS 
                    foreach (Retiros dir in Detalles)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.IDEncabezado = IDRegistro;
                        var dic = dir.Abm();
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

                //ACTUALIZO RETIROS                
                foreach (Retiros dir in Detalles)
                {
                    //ASIGNO CONNEXION
                    dir.SqlConnection = SqlConnection;
                    dir.IDEncabezado = dir.IDEncabezado <= 0 ? IDRegistro : dir.IDEncabezado;
                    var dic = dir.Abm();
                    func.PreparaRetorno(retorno, dic);
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


        #endregion
    }
}
