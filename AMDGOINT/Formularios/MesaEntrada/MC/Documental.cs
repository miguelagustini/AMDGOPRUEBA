using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace AMDGOINT.Formularios.MesaEntrada.MC
{
    public class Documental
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "DOCUMENTALADMIN";

        private int _idregistro = 0;
        private DateTime _fechapresentacion = DateTime.MinValue;
        private int _idprofesionalcuenta = 0;
        private string _nrointernacion = "";
        private string _nrobusqueda = "";
        private string _nrolote = "";
        private DateTime _fechaauditoria = DateTime.MinValue;
        private string _devolucionmotivo = "";
        private string _personaauditoria = "";
        private bool _notificado = false;
        private DateTime _fechanotificacion = DateTime.MinValue;
        private string _personaretiro = "";
        private DateTime _fecharetiro = DateTime.MinValue;
        private string _codigocuentaprof = "";
        private string _observacionretiro = "";
        private string _cuentadescripcion = "";
        private string _codigopractica = "";
        private string _descrpractica = "";
        private string _pacientenom = "";
        private string _pacientedoc = "";
        private string _prestadoracodigo = "";
        private string _prestadoradescripcion = "";

        public int IDRegistro
        {
            get { return _idregistro; }
            set { _idregistro = _idregistro != value ? value : _idregistro; }
        }

        public DateTime FechaPresentacion
        {
            get { return _fechapresentacion; }
            set { _fechapresentacion = _fechapresentacion != value ? value : _fechapresentacion; }
        }

        public int IDProfesionalCuenta
        {
            get { return _idprofesionalcuenta; }
            set { _idprofesionalcuenta = _idprofesionalcuenta != value ? value : _idprofesionalcuenta; }
        }

        public string CodigoProfesionalCuenta
        {
            get { return _codigocuentaprof; }
            set { _codigocuentaprof = _codigocuentaprof != value.Trim() ? value.Trim() : _codigocuentaprof; }
        }

        public string CuentaDescripcion
        {
            get { return _cuentadescripcion; }
            set { _cuentadescripcion = _cuentadescripcion != value.Trim() ? value.Trim() : _cuentadescripcion; }
        }

        public string CuentaInformacion
        {
            get { return CodigoProfesionalCuenta + " " + CuentaDescripcion; }
        }

        public string NroInternacion
        {
            get { return _nrointernacion; }
            set { _nrointernacion = _nrointernacion != value.Trim() ? value.Trim() : _nrointernacion; }
        }

        public string NroBusqueda
        {
            get { return _nrobusqueda; }
            set { _nrobusqueda = _nrobusqueda != value.Trim() ? value.Trim() : _nrobusqueda; }
        }

        public string NroLote
        {
            get { return _nrolote; }
            set { _nrolote = _nrolote != value.Trim() ? value.Trim() : _nrolote; }
        }

        public DateTime AuditoriaFecha
        {
            get { return _fechaauditoria; }
            set { _fechaauditoria = _fechaauditoria != value ? value : _fechaauditoria; }
        }

        public string AuditoriaPersona
        {
            get { return _personaauditoria; }
            set { _personaauditoria = _personaauditoria != value.Trim() ? value.Trim() : _personaauditoria; }
        }

        public string PracticaCodigo
        {
            get { return _codigopractica; }
            set { _codigopractica = _codigopractica != value.Trim() ? value.Trim() : _codigopractica; }
        }

        public string PracticaDescripcion
        {
            get { return _descrpractica; }
            set { _descrpractica = _descrpractica != value.Trim() ? value.Trim() : _descrpractica; }
        }

        public string PracticaCompleta
        {
            get { return PracticaCodigo + " " + PracticaDescripcion; }
        }

        public string PacienteDocumento
        {
            get { return _pacientedoc; }
            set { _pacientedoc = _pacientedoc != value.Trim() ? value.Trim() : _pacientedoc; }
        }

        public string PacienteNombre
        {
            get { return _pacientenom; }
            set { _pacientenom = _pacientenom != value.Trim() ? value.Trim() : _pacientenom; }
        }

        public string PacienteCompleto
        {
            get { return PacienteDocumento + " " + PacienteNombre; }
        }
        
        public string MotivoDevolucion
        {
            get { return _devolucionmotivo; }
            set { _devolucionmotivo = _devolucionmotivo != value.Trim() ? value.Trim() : _devolucionmotivo; }
        }

        public bool Notificado
        {
            get { return _notificado; }
            set { _notificado = _notificado != value ? value : _notificado; }
        }

        public DateTime FechaNotificacion
        {
            get { return _fechanotificacion; }
            set { _fechanotificacion = _fechanotificacion != value ? value : _fechanotificacion; }
        }

        public string PersonaRetiro
        {
            get { return _personaretiro; }
            set { _personaretiro = _personaretiro != value.Trim() ? value.Trim() : _personaretiro; }
        }

        public DateTime FechaRetiro
        {
            get { return _fecharetiro; }
            set { _fecharetiro = _fecharetiro != value ? value : _fecharetiro; }
        }

        public string ObservacionRetiro
        {
            get { return _observacionretiro; }
            set { _observacionretiro = _observacionretiro != value.Trim() ? value.Trim() : _observacionretiro; }
        }

        public string PrestadoraCodigo
        {
            get { return _prestadoracodigo; }
            set { _prestadoracodigo = _prestadoracodigo != value.Trim() ? value.Trim() : _prestadoracodigo; }
        }

        public string PrestadoraDescripcion
        {
            get { return _prestadoradescripcion; }
            set { _prestadoradescripcion = _prestadoradescripcion != value.Trim() ? value.Trim() : _prestadoradescripcion; }
        }

        public string Prestadora
        {
            get { return PrestadoraCodigo + " " + PrestadoraDescripcion; }
        }

        public List<Auditor> Auditores { get; set; } = new List<Auditor>();
        public List<Gestion> Gestion { get; set; } = new List<Gestion>();

        public int IDUsuModif { get => Convert.ToInt16(glb.GetIdUsuariolog()); }
        public DateTime TimeModif { get => DateTime.Now; }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Documental() { }

        public Documental(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public Documental Clone()
        {
            Documental d = (Documental)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<Documental> Clone(List<Documental> lst)
        {
            List<Documental> lista = new List<Documental>();

            foreach (Documental d in lst)
            {
                lista.Add(d.Clone());
            }
            return lista;
        }

        #endregion
        
        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Documental> GetDocumental()
        {
            try
            {
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Documental> lista = new List<Documental>();

                string c = $"SELECT CONVERT(datetime, MD.MED2FEPR, 105) AS FechaPresentacion, PC.ID_Registro AS IDProfesionalCuenta, MD.MED2CPRO as CodigoProfesionalCuenta," +
                           $" ISNULL(IIF(PF.Nombre IS NOT NULL, PF.Nombre, PC.Descripcion), '') AS CuentaDescripcion, MD.MED2NBUS AS NroBusqueda, MD.MED2LOTE AS NroLote," +
                           $" '' AS NroInternacion, ISNULL(AB.OBRACODI,'') AS PrestadoraCodigo, ISNULL(AB.OBRAABRE,'') AS PrestadoraDescripcion," +                           
                           $" MD.MED2PRAC AS PracticaCodigo, MD.med2pnom AS PracticaDescripcion, MD.MED2PACI as PacienteNombre, MD.MED2DOCU AS PacienteDocumento" +
                           $" FROM AmdgoSis.dbo.ASOCMED2 MD" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = MD.MED2CPRO)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCOBRA AB ON(AB.OBRACODI = MD.MED2COOB)" +                           
                           $" WHERE FORMAT(CONVERT(datetime, MD.MED2FEPR, 105), 'yyyy-MM') > '2021-09' AND (MD.MED2MESA LIKE '%1' OR MD.MED2MESA IS NULL)" +                           
                           $" AND MD.MED2NBUS IN (SELECT AU1.AUDINBUS FROM AmdgoSis.dbo.ASOCAUDCONT AU1 WHERE AU1.AUDIESTD = '5')" +                           
                           $" GROUP BY MD.MED2FEPR, PC.ID_Registro, MD.MED2CPRO , MD.MED2NBUS, MD.MED2LOTE, MD.MED2PRAC, MD.med2pnom," +                           
                           $" PF.Nombre, PC.Descripcion, MD.MED2PACI, MD.MED2DOCU,AB.OBRACODI, AB.OBRAABRE" +
                           $" UNION" +
                           $" SELECT CONVERT(datetime, AI.MOVOFEEN, 105) AS FechaPresentacion, PC.ID_Registro AS IDProfesionalCuenta, AI.MOVOCSAN as CodigoProfesionalCuenta, " +
                           $" ISNULL(IIF(PF.Nombre IS NOT NULL, PF.Nombre, PC.Descripcion), '') AS CuentaDescripcion, '' AS NroBusqueda, '' AS NroLote," +
                           $" ISNULL(AI.MOVONINT, '') AS NroInternacion, ISNULL(AB.OBRACODI,'') AS PrestadoraCodigo, ISNULL(AB.OBRAABRE,'') AS PrestadoraDescripcion," +
                           $" '' AS PracticaCodigo, '' AS PracticaDescripcion, AI.MOVOPACI as PacienteNombre, AI.MOVODOCU AS PacienteDocumento" +
                           $" FROM AmdgoSis.dbo.ASOCSAN1 AI" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = AI.MOVOCSAN)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCOBRA AB ON(AB.OBRACODI = AI.MOVOCOOB)" +                           
                           $" WHERE FORMAT(CONVERT(datetime, AI.MOVOFEEN, 105), 'yyyy-MM') > '2021-09'" +                           
                           $" AND (AI.MOVOAMQU LIKE '%3' OR AI.MOVOAMQU LIKE '%6' OR AI.MOVOAMQU IS NULL) AND" +
                           $" AI.MOVONINT IN (SELECT AU1.AUDININT FROM AmdgoSis.dbo.ASOCAUDCONT AU1 WHERE AU1.AUDIESTD = '5')" +                           
                           $" GROUP BY AI.MOVOFEEN, PC.ID_Registro, AI.MOVOCSAN, AI.MOVONINT, PF.Nombre, PC.Descripcion," +
                           $" AI.MOVOPACI, AI.MOVODOCU, AB.OBRACODI, AB.OBRAABRE";

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Documental a = new Documental();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                //DOCUMENTAL AUDITORES
                #region AUDITORES                
                Auditor _auditor = new Auditor(SqlConnection);
                List<Auditor> auditores = _auditor.GetRegistros();

                foreach (Documental d in lista)
                {
                    d.Auditores = _auditor.Clone(auditores.Where(w => w.NroBusqueda == d.NroBusqueda && w.NroInternacion == d.NroInternacion).ToList());                    
                }

                #endregion

                //DEVOLUCION / GESTION DE DOCUMENTAL
                #region GESTION
                Gestion _gestion = new Gestion(SqlConnection);
                List<Gestion> _gestiones = _gestion.GetRegistros();

                foreach (Documental d in lista)
                {
                    d.Gestion = _gestion.Clone(_gestiones.Where(w => w.NroBusqueda == d.NroBusqueda && w.NroInternacion == d.NroInternacion).ToList());
                }

                #endregion

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Documental>();
            }
        }

        #endregion                
    }
}
