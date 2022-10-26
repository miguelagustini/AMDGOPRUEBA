using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AMDGOINT.Formularios.Facturas.Internacion.MC
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
        private string codpractica = "";
        private string descpractica = "";
        private string funcion = "";
        private string pacientenom = "";
        private string pacientedocu = "";
        private decimal cantidad = 0;
        private decimal honorarios = 0;
        private decimal medicamentos = 0;
        private decimal gastos = 0;
        private decimal neto = 0;
        private decimal iva = 0;
        private decimal total = 0;
        private decimal punitario = 0;
        private long puntero = 0;
        private string numeroint = "";
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
        private decimal receptorporciva = 0;
        private string codigocuentaentidad = "";
        private int idcodigoentidad = 0;
        private string nombreentidad = "";
        private short idmodofacturacion = 1;
        private short idtipoplan = 0;
        
        //DATOS FACTURA FCE
        private bool emitefce = false; 
        private string cbu = "";
        private string alias = "";
        private string tipocircuito = "";
        private bool receptormipyme = false;

        public DateTime PracticaFecha
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

        public string PracticaCodigo
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

        public string PracticaDescripcion
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

        public string PracticaFuncion
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

        public string PacienteNombre
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

        public string PacienteDocumento
        {
            get { return pacientedocu; }
            set
            {
                pacientedocu = pacientedocu != value.Trim() ? Regex.Replace(value.Trim(), "[^0-9]+", "0") : pacientedocu;
                //if (pacientedocu != value.Trim()) {   pacientedocu = Regex.Replace(value.Trim(), "[^0-9]+", "0"); }
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

        public decimal ImporteUnitario
        {
            get { return punitario; }
            set { punitario = punitario != value ? value : punitario; }
        }

        public decimal ImporteHonorario
        {
            get { return honorarios; }
            set { honorarios = honorarios != value ? value : honorarios; }
        }

        public decimal ImporteGasto
        {
            get { return gastos; }
            set { gastos = gastos != value ? value : gastos; }
        }

        public decimal ImporteMedicamento
        {
            get { return medicamentos; }
            set { medicamentos = medicamentos != value ? value : medicamentos; }
        }

        public decimal ImporteNeto
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

        public decimal ImporteIva
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

        public decimal ImporteTotal
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

        public long InternacionPuntero
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

        public string InternacionNumero
        {
            get { return numeroint; }
            set { numeroint = numeroint != value.Trim() ? value.Trim() : numeroint; }
        }

        public int EmisorCuentaID
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

        public string EmisorCuentaCodigo
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
            get { return emisornombre.ToUpper(); }
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

        public string EmisorIvaAbreviatura
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

        public short EmisorIvaID
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
        

        public bool EmisorEmiteComprobanteFCE
        {
            get { return emitefce; }
            set { emitefce = emitefce != value ? value : emitefce; }
        }

        public string EmisorCbuComprobanteFCE
        {
            get { return cbu; }
            set { cbu = cbu != value.Trim() ? value.Trim() : cbu; }
        }

        public string EmisorAliasComprobanteFCE
        {
            get { return alias; }
            set { alias = alias != value.Trim() ? value.Trim() : alias; }
        }

        public string EmisorCircuitoComprobanteFCE
        {
            get { return tipocircuito; }
            set { tipocircuito = tipocircuito != value.Trim() ? value.Trim() : tipocircuito; }
        }




        public short EmisorModoFacturacion
        {
            get { return idmodofacturacion; }
            set
            {
                if (idmodofacturacion != value)
                {
                    idmodofacturacion = value;
                }
            }
        }

        public string EmisorDomicilioFiscal
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

        public int ReceptorCuentaID
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

        public string ReceptorCuentaCodigo
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
            get { return receptornombre.ToUpper(); }
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

        public short ReceptorIvaID
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

        public string ReceptorIvaAbreviatura
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
        
        public string ReceptorDomicilioFiscal
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

        public bool ReceptorMiPyme
        {
            get { return receptormipyme; }
            set { receptormipyme = receptormipyme != value ? value : receptormipyme; }
        }

        public decimal ReceptorPorcIva
        {
            get { return receptorporciva; }
            set { receptorporciva = receptorporciva != value ? value : receptorporciva; }
        }
        
        public short ReceptorIDPlanTipo
        {
            get { return idtipoplan; }
            set { idtipoplan = idtipoplan != value ? value : idtipoplan; }
        }

        public string EntidadCuentaCodigo
        {
            get { return codigocuentaentidad; }
            set { codigocuentaentidad = codigocuentaentidad != value.Trim() ? value.Trim() : codigocuentaentidad; }
        }

        public int EntidadCuentaID
        {
            get { return idcodigoentidad; }
            set { idcodigoentidad = idcodigoentidad != value ? value : idcodigoentidad; }
        }

        public string EntidadNombre
        {
            get { return nombreentidad.ToUpper(); }
            set { nombreentidad = nombreentidad != value.Trim() ? value.Trim() : nombreentidad; }
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

                string c = $"SELECT" +
                           $" A2.MOVOFEPA AS PracticaFecha," +
                           $" A2.MOVOPRAC as PracticaCodigo," +
                           $" A2.MOVODESC as PracticaDescripcion," +
                           $" A2.MOVOFUNC as PracticaFuncion," +
                           $" A2.MOVOCPRA as Cantidad," +
                           $" A2.MOVOAUST as ImporteUnitario," +
                           $" A2.MOVOHONO as ImporteHonorario," +
                           $" A2.MOVOGAST as ImporteGasto," +
                           $" A2.MOVOMEDI as ImporteMedicamento," +
                           $" A2.MOVONETO as ImporteNeto," +
                           $" A2.MOVOIIVA as ImporteIva," +
                           $" A2.MOVOTOTA as ImporteTotal," +
                           $" A1.MOVOPACI AS PacienteNombre," +
                           $" A1.MOVODOCU AS PacienteDocumento," +
                           $" A1.MOVONINT AS InternacionNumero," +
                           $" CAST(ISNULL(A1.MOVOPUNT, 0) AS BIGINT) AS InternacionPuntero," +
                           //SOLICITANTE (ENTIDAD)
                           $" PCS.ID_Registro AS EntidadCuentaID," +
                           $" A1.MOVOCSAN AS EntidadCuentaCodigo," +
                           $" PRS.Nombre AS EntidadNombre, " +
                           //PROFESIONAL
                           $" PC.ID_Registro AS EmisorCuentaID," +
                           $" AP.PROFCODI AS EmisorCuentaCodigo," +
                           $" CAST(AP.PROFAFIP AS TINYINT) AS EmisorIvaID," +
                           $" CDE.Abreviatura AS EmisorIvaAbreviatura, " +
                           $" PR.Nombre AS EmisorNombre, " +
                           $" PR.Cuit AS EmisorCuit," +
                           $" PR.DomFiscal AS EmisorDomicilioFiscal," +

                           $" PR.EmiteFCE AS EmisorEmiteComprobanteFCE," +
                           $" PR.CbuFCE AS EmisorCbuComprobanteFCE," +
                           $" PR.AliasFCE AS EmisorAliasComprobanteFCE," +
                           $" PR.CircuitoFCE AS EmisorCircuitoComprobanteFCE," +

                           //$" PR.PuntoVenta AS EmisorPtovta," +
                           $" IIF(PR.IDModoFacturacion = 1, PR.PuntoVenta, IIF(PR.IDModoFacturacion = 2, PC.PuntoVenta, IIF(PR.IDModoFacturacion = 3, PVT.PuntoVenta, 0))) AS EmisorPtovta," +
                           //PRESTADORA
                           $" PD.ID_Registro AS ReceptorCuentaID," +
                           $" AC.OBRACODI AS ReceptorCuentaCodigo," +
                           $" PRE.Nombre AS ReceptorNombre," +
                           $" PRE.DomicilioFiscal AS ReceptorDomicilioFiscal," +
                           $" PRE.MiPyme AS ReceptorMiPyme," +
                           $" CDR.Abreviatura AS ReceptorIvaAbreviatura," +
                           $" CAST(AC.OBRANCUI AS BIGINT) AS ReceptorCuit," +
                           $" CDR.ID_Registro AS ReceptorIvaID," +
                           $" CAST(ISNULL(AC.OBRAPORC_IVA, 0) AS NUMERIC(5,2)) AS ReceptorPorcIva," +
                           $" PD.IDTipoPrestataria as ReceptorIDPlanTipo" +
                           //FROM Y RELACIONES
                           $" FROM AmdgoSis.dbo.ASOCSAN1 A1" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCSAN2 A2 ON(A2.MOVONINT = A1.MOVONINT AND A2.MOVOPUNT = A1.MOVOPUNT)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF AP ON(AP.PROFCODI = A2.MOVOPFAC)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCOBRA AC ON(AC.OBRACODI = A2.MOVOOBRA)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(AP.PROFCODI)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PR ON(PR.ID_Registro = PC.ID_Profesional)" +
                           //SOLICITANTE
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PCS ON(PCS.Codigo = LTRIM(RTRIM(A1.MOVOCSAN)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PRS ON(PRS.ID_Registro = PCS.ID_Profesional)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CDE ON(CDE.ID_Registro = PR.ID_Iva)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = LTRIM(RTRIM(A2.MOVOOBRA)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PRE ON(PRE.ID_Registro = PD.ID_Prestataria)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.CONDSIVA CDR ON(CDR.ID_Registro = PRE.ID_Iva)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFPVTATIPOPRES PVT ON(PVT.IDProfesional = PR.ID_Registro AND PVT.TipoPrestataria = PD.IDTipoPrestataria)" +
                           //WHERE
                           $" WHERE" +
                           $" (A1.MOVOFACT = '3' OR A1.MOVOFACT = '8')" +
                           $" AND (A2.MOVOFACT = '3' OR A2.MOVOFACT = '8')" +
                           $" AND A1.MOVOAUTO = '1'" +
                           $" AND LEN(AP.PROFCODI) < 5" +
                           $" AND PR.ID_Iva = 1" +                           
                           $" AND (A2.MOVOCOMP IS NULL OR LTRIM(RTRIM(A2.MOVOCOMP)) = '')" +
                           $" AND (A1.MOVOCOOB LIKE '0%' OR A1.MOVOCOOB = '13')" +
                           //$" AND (A1.MOVOCOOB <> '1041' AND A1.MOVOCOOB <> '1000' AND A1.MOVOCOOB <> '101' AND A1.MOVOCOOB <> '284' AND A1.MOVOCOOB <> '119' AND A1.MOVOCOOB <> '1100' AND A1.MOVOCOOB <> '1200')" +
                           $" AND (A1.MOVOCSAN = '6916' OR A1.MOVOCSAN = '7186' OR A1.MOVOCSAN = '6855')";
                           
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
