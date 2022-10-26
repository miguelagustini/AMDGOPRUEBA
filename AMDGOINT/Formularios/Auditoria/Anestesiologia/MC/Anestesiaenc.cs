using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.MC
{
    public class Anestesiaenc : INotifyPropertyChanged
    {
        //DEFINICION DE REFERENCIAS UTILIZADAS
        #region DEFINICION DE REFERENCIAS
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();
        private Globales glb = new Globales();

        #endregion

        //DEFINICION DE PROPIEDADES
        #region PROPIEDADES
        private int idregistro = 0;
        private DateTime fechacarga = DateTime.Today;
        private string periodo = "";
        private DateTime fechafactura = DateTime.MinValue;
        private long nrofactura = 0;
        private string entidad = "Asociación de Anestesia, Anlagesia y Reanimación de Santa Fe";
        private int idprestdetalle = 0;
        private string prestataria = "";


        //SOLO DE CLASE
        private static string tablaname = "AUDIANESTESIAENC";

        //ENCAPSULAMIENTO PUBLICO
        public string IDLocal { get; set; } = System.Guid.NewGuid().ToString();

        public int IDRegistro
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

        public DateTime FechaCarga
        {
            get { return fechacarga; }
            set
            {
                if (fechacarga != value)
                {
                    fechacarga = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Periodo
        {
            get { return periodo; }
            set
            {
                if (periodo != value.Trim())
                {
                    periodo = value.Trim();
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime FechaFactura
        {
            get { return fechafactura; }
            set
            {
                if (fechafactura != value)
                {
                    fechafactura = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public long NroFacturacion
        {
            get { return nrofactura; }
            set
            {
                if (nrofactura != value)
                {
                    nrofactura = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Entidad
        {
            get { return entidad; }
            set
            {
                if (entidad != value.Trim())
                {
                    entidad = value.Trim();
                    NotifyPropertyChanged();
                }
            }
        }

        public int IDPrestdetalle
        {
            get { return idprestdetalle; }
            set
            {
                if (idprestdetalle != value)
                {
                    idprestdetalle = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Prestataria
        {
            get { return prestataria; }
            set
            {
                if (prestataria != value.Trim())
                {
                    prestataria = value.Trim();
                }
            }
        }
        
        public BindingList<Anestesiagrp> Grupos { get; set; } = new BindingList<Anestesiagrp>();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        //DE IGUALACION CON CAMPOS DE BD
        public int ID_PrestDetalle { get { return IDPrestdetalle; } }        
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public string Guid { get { return IDLocal; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES
        public Anestesiaenc() { }

        public Anestesiaenc(SqlConnection conexion) { SqlConnection = conexion; }
        #endregion

        //METODOS 
        #region METODOS
        
        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }


        //CLONACION
        #region CLONACION
        public Anestesiaenc Clone()
        {
            Anestesiaenc d = (Anestesiaenc)MemberwiseClone();
            Anestesiagrp c = new Anestesiagrp();
            d.Grupos = c.Clone(Grupos);
            
            return d;
        }
               
        //CLONE CON LISTAS
        public List<Anestesiaenc> Clone(List<Anestesiaenc> lst)
        {
            List<Anestesiaenc> lista = new List<Anestesiaenc>();

            foreach (Anestesiaenc d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //CONSULTA DE DATOS
        #region CONSULTA DE DATOS

        //RETORNO LISTA DE REGISTROS
        public List<Anestesiaenc> GetRegistros()
        {
            try
            {
                List<Anestesiaenc> lista = new List<Anestesiaenc>();

                //OBTENGO LA LISTA DE CAMPOS, CAMBIO SUS NOMBRES A LOS DE LAS PROPIEDADES PARA PODER ENCONTRAR Y SETEAR SU VALOR CORRECTAMENTE
                string c = $"SELECT AE.ID_Registro AS IDRegistro, AE.Guid as IDLocal, AE.FechaCarga, AE.Periodo, AE.FechaFactura, AE.NroFacturacion, AE.Entidad," +
                           $" AE.ID_PrestDetalle as IDPrestdetalle, PR.Nombre AS Prestataria" +
                           $" FROM {tablaname} AS AE" +
                           $" LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = AE.ID_PrestDetalle)" +
                           $" LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                
                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Anestesiaenc a = new Anestesiaenc();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        GetType().GetProperty(co.ColumnName).SetValue(a, r[co]);
                    }

                    lista.Add(a);
                }

                //dispongo de la memoria table
                tbl.Dispose();

                //OBENGO LOS DETALLES 
                Anestesiagrp ctnclas = new Anestesiagrp(SqlConnection);
                List<Anestesiagrp> contalst = ctnclas.GetRegistros();

                //LOS ASIGNO SEGUN SU ENCABEZADO
                foreach (Anestesiaenc d in lista)
                {
                    d.Grupos = ctnclas.Clone(new BindingList<Anestesiagrp>(contalst.Where(w => w.IDEncabezado == d.IDRegistro).ToList()));
                }
                
                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los encabezados.\n{e.Message}", 0);
                return new List<Anestesiaenc>();
            }
        }

        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR DETALLES ASOCIADOS CREADOS DESDE CERO)
        private void GetIdregistro()
        {
            string c = $"SELECT ID_Registro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt32(r["ID_Registro"]);
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
            else if (IDRegistro > 0 && IDLocal.Length > 0)
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

            campos.Add("Guid");
            campos.Add("FechaCarga");
            campos.Add("Periodo");
            campos.Add("FechaFactura");
            campos.Add("NroFacturacion");
            campos.Add("Entidad");
            campos.Add("ID_PrestDetalle");            
            campos.Add("ID_UsuNew");
            campos.Add("ID_UsuModif");

            return campos;
        }

        //ALTA DE REGISTROS (RETORNO UN DICCIONARIO CON VALOR + INFO DEL ERROR, ME PERMITE EN CASO DE SER PADRE, SALIR DEL ABM EN CASO DE <> 1
        private Dictionary<short, string> Alta()
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

                //CONEXION                
                SqlCommand cmd = new SqlCommand(query.ToString(), SqlConnection);

                //PARAMETROS
                short paramnro = 0;
                foreach (string c in campos)
                {
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this, null));
                    paramnro++;
                }

                //EJECUTO LA INSTRUCCION
                cmd.ExecuteNonQuery();

                //****************************************************************************************
                //************************ EVALUACION PARA DETALLES *************************************
                //****************************************************************************************       

                //OBTENGO EL ID DE REGISTRO
                GetIdregistro();

                //ACTUALIZO LOS CONTACTOS
                if (IDRegistro > 0)
                {
                    foreach (Anestesiagrp ct in Grupos)
                    {
                        //ASIGNO CONNEXION 
                        ct.SqlConnection = SqlConnection;
                        ct.IDEncabezado = IDRegistro;
                        ct.Abm();
                    }
                }

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
                campos.Remove("ID_UsuNew");
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
                    cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this));
                    paramnro++;
                }

                //ACTUALIZO DIRECCION
                cmd.ExecuteNonQuery();

                //****************************************************************************************
                //************************ EVALUACION PARA GRUPOS / DETALLES *************************************
                //****************************************************************************************       

                //ACTUALIZO LOS GRUPOS
                foreach (Anestesiagrp ct in Grupos)
                {
                    //ASIGNO CONNEXION 
                    ct.SqlConnection = SqlConnection;
                    //ASIGNO ID DE DIRECCION
                    ct.IDEncabezado = IDRegistro;
                    ct.Abm();

                }


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

        #endregion

    }
}
