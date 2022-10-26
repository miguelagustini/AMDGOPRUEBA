using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class Pendientes
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private DateTime fechapractica = DateTime.MinValue;
        private string periodo = "";
        private string codpractica = "";
        private string descpractica = "";
        private string funcion = "";
        private string pacientenom = "";
        private string pacientedocu = "";
        private decimal cantidad = 0;
        private decimal neto = 0;
        private decimal iva = 0;
        private decimal total = 0;
        private long puntero = 0;
        private int emisoridcuenta = 0;
        private string emisorcodigo = "";
        private string emisorivaab = "";
        private string emisornombre = "";
        private long emisorcuit = 0;
        private short emisoriva = 0;
        private int emisorpvta = 0;
        private string emisordomfiscal = "";
        private int idprestdetalle = 0;
        private string receptorcodigo = "";
        private string receptorivaab = "";
        private string receptornombre = "";
        private string receptordomfiscal = "";
        private long receptorcuit = 0;
        private short receptoriva = 0;
        private decimal receptorivaporc = 0;

        public string Periodo { get { return periodo; } set { periodo = periodo != value.Trim() ? value.Trim() : periodo; } }

        public DateTime FechaPractica
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

        public string CodPractica
        {
            get { return codpractica; }
            set
            {
                if (codpractica != value.Trim())
                {
                    codpractica = value.Trim();
                }
            }
        }

        public string DescPractica
        {
            get { return descpractica; }
            set
            {
                if (descpractica != value.Trim())
                {
                    descpractica = value.Trim();
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

        public string PacienteNom
        {
            get { return pacientenom; }
            set
            {
                if (pacientenom != value.Trim())
                {
                    pacientenom = value.Trim();
                }
            }
        }

        public string PacienteDocu
        {
            get { return pacientedocu; }
            set
            {
                if (pacientedocu != value.Trim())
                {                    
                    pacientedocu = Regex.Replace(value.Trim().Trim(), "[^0-9]+", "0");
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

        public int EmisorIDCuenta
        {
            get { return emisoridcuenta; }
            set
            {
                if (emisoridcuenta != value)
                {
                    emisoridcuenta = value;
                }
            }
        }

        public string EmisorCodigo
        {
            get { return emisorcodigo; }
            set
            {
                if (emisorcodigo != value.Trim())
                {
                    emisorcodigo = value.Trim();
                }
            }
        }

        public string EmisorNombre
        {
            get { return emisornombre; }
            set
            {
                if (emisornombre != value.Trim())
                {
                    emisornombre = value.Trim();
                }
            }
        }

        public long EmisorCuit
        {
            get { return emisorcuit; }
            set
            {
                if (emisorcuit != value)
                {
                    emisorcuit = value;
                }
            }
        }

        public string EmisorIvaAb
        {
            get { return emisorivaab; }
            set
            {
                if (emisorivaab != value.Trim())
                {
                    emisorivaab = value.Trim();
                }
            }
        }

        public short EmisorIva
        {
            get { return emisoriva; }
            set
            {
                if (emisoriva != value)
                {
                    emisoriva = value;
                }
            }
        }

        public int EmisorPtovta
        {
            get { return emisorpvta; }
            set
            {
                if (emisorpvta != value)
                {
                    emisorpvta = value;
                }
            }
        }

        public string EmisorDomFiscal
        {
            get { return emisordomfiscal; }
            set
            {
                if (emisordomfiscal != value.Trim())
                {
                    emisordomfiscal = value.Trim();
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

        public string ReceptorCodigo
        {
            get { return receptorcodigo; }
            set
            {
                if (receptorcodigo != value.Trim())
                {
                    receptorcodigo = value.Trim();
                }
            }
        }

        public string ReceptorNombre
        {
            get { return receptornombre; }
            set
            {
                if (receptornombre != value.Trim())
                {
                    receptornombre = value.Trim();
                }
            }
        }

        public long ReceptorCuit
        {
            get { return receptorcuit; }
            set
            {
                if (receptorcuit != value)
                {
                    receptorcuit = value;
                }
            }
        }

        public short ReceptorIva
        {
            get { return receptoriva; }
            set
            {
                if (receptoriva != value)
                {
                    receptoriva = value;
                }
            }
        }

        public string ReceptorIvaAb
        {
            get { return receptorivaab; }
            set
            {
                if (receptorivaab != value.Trim())
                {
                    receptorivaab = value.Trim();
                }
            }
        }

        public decimal ReceptorPorcIva
        {
            get { return receptorivaporc; }
            set
            {
                if (receptorivaporc != value)
                {
                    receptorivaporc = value;
                }
            }
        }

        public string ReceptorDomFiscal
        {
            get { return receptordomfiscal; }
            set
            {
                if (receptordomfiscal != value.Trim())
                {
                    receptordomfiscal = value.Trim();
                }
            }
        }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Pendientes() { }

        public Pendientes(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONE
        #region CLONACION

        //CLONE 
        public Pendientes Clone()
        {
            Pendientes d = (Pendientes)MemberwiseClone();            
            return d;
        }

        //CLONE CON LISTAS
        public List<Pendientes> Clone(List<Pendientes> lst)
        {
            List<Pendientes> lista = new List<Pendientes>();

            foreach (Pendientes d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO DE LISTA REGISTROS
        #region CONSULTA DE DATOS
        public List<Pendientes> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Pendientes> lista = new List<Pendientes>();

                string c = " SELECT CONVERT(datetime, MED.MED2FEPR, 105) AS FechaPractica, MED.MED2PRAC AS CodPractica, MED.MED2PNOM AS DescPractica, ISNULL(MED.MED2FUNC, 0) AS Funcion, MED.MED2PACI AS PacienteNom," +
                           " MED.MED2DOCU AS PacienteDocu, ISNULL(MED.MED2CANT, 0) AS Cantidad, ISNULL(MED.MED2NETO, 0) AS Neto, ISNULL(MED.MED21IVA, 0) AS Iva," +
                           " ISNULL(MED.MED2TOTA, 0) AS Total, ISNULL(MED.MED2PUNT, 0) AS Puntero, PF.PROFCODI AS EmisorCodigo, PR.Nombre AS EmisorNombre, CAST(PF.PROFNCUI AS BIGINT) AS EmisorCuit," +
                           " CDE.Abreviatura AS EmisorIvaAb, CAST(PF.PROFAFIP AS TINYINT) AS EmisorIva, AC.OBRACODI AS ReceptorCodigo, PRE.Nombre AS ReceptorNombre, CDR.Abreviatura AS ReceptorIvaAb," +
                           " CAST(AC.OBRANCUI AS BIGINT) AS ReceptorCuit, CDR.ID_Registro AS ReceptorIva, CAST(ISNULL(AC.OBRAPORC_IVA, 0) AS NUMERIC(5,2)) AS ReceptorPorcIva, PC.ID_Registro AS EmisorIDCuenta," +
                           " PR.DomFiscal AS EmisorDomFiscal, PD.ID_Registro AS IDPrestDetalle," +
                           //" CAST(PR.PuntoVenta AS int) AS EmisorPtovta," +
                           $" IIF(PR.IDModoFacturacion = 1, PR.PuntoVenta, IIF(PR.IDModoFacturacion = 2, PC.PuntoVenta, IIF(PR.IDModoFacturacion = 3, PVT.PuntoVenta, 0))) AS EmisorPtovta" +
                           " FROM AmdgoSis.dbo.ASOCMED2 MED" +
                           " LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF PF ON(PF.PROFCODI = MED.MED2PCOB)" +
                           " LEFT OUTER JOIN AmdgoSis.dbo.ASOCOBRA AC ON(AC.OBRACODI = MED.MED2COOB)" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(PF.PROFCODI)))" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PR ON(PR.ID_Registro = PC.ID_Profesional)" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CDE ON(CDE.ID_Registro = PR.ID_Iva)" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = LTRIM(RTRIM(AC.OBRACODI)))" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.PROFPVTATIPOPRES PVT ON(PVT.IDProfesional = PR.ID_Registro AND PVT.TipoPrestataria = PD.IDTipoPrestataria)" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PRE ON(PRE.ID_Registro = PD.ID_Prestataria)" +
                           " LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CDR ON(CDR.ID_Registro = PRE.ID_Iva)" +
                           " WHERE" +
                           " MED.MED2MESA IS NULL" +
                           " AND PR.ID_Iva = 1" +
                           " AND PD.ID_Registro > 0" +
                           " AND (MED.MED2FACT = '3' OR MED.MED2FACT = '8') " +
                           " AND (MED.MED2CSEG = 'B' OR MED.MED2CSEG = 'A')" +
                           " AND (MED.MED2COOB LIKE '0%' OR MED.MED2COOB = '13')" +
                           //" AND (MED.MED2COOB <> '1041' AND MED.MED2COOB <> '1000' AND MED.MED2COOB <> '101' AND MED.MED2COOB <> '284' AND MED.MED2COOB <> '119' AND MED.MED2COOB <> '1100' AND MED.MED2COOB <> '1200' AND MED.MED2COOB <> '1090')" +
                           " AND (MED.MED2COMP IS NULL OR LTRIM(RTRIM(MED.MED2COMP)) = '')" +
                           " AND LEN(MED.MED2LOTE) = 16" +
                           " AND (MED.export_guid is null OR LTRIM(RTRIM(MED.export_guid)) = '')"; 
                           //" AND (MED.MED2DOCU <> '6544820' AND MED.MED2DOCU <> '13248151' AND MED.MED2DOCU <> '7702101' AND MED.MED2DOCU <> '4879045' AND MED.MED2DOCU <> '6349252')";

                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Pendientes>(rdr));
                }

                cnb.Desconectar();
                
                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Pendientes>();
            }
        }               
        
        #endregion
    }
}
