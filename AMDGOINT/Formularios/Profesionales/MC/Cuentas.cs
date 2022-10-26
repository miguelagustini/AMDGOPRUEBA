using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AMDGOINT.Formularios.Profesionales.MC
{
    public class Cuentas : INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        // PROPIEDADES 
        #region PROPIEDADES        
        private static string tablaname = "PROFCUENTAS";

        private int idregistro = 0;
        private int idprincipal = 0;
        private int idprofesional = 0;        
        private string codigo = "";
        private string descripcion = "";
        private string _nombreprof = "";
        private decimal _saldodisponiblecta = 0;
        private decimal _saldodisponibleagrupado = 0;
        private decimal _saldodisponiblegral = 0;


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

        public int IDProfesional
        {
            get { return idprofesional; }
            set
            {
                if (idprofesional != value)
                {
                    idprofesional = value;

                }
            }
        }
              
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (codigo != value.Trim())
                {
                    codigo = value.Trim();
                }
            }

        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (descripcion != value.Trim())
                {
                    descripcion = value.Trim();

                }
            }
        }

        public string ProfesionalNombre
        {
            get { return _nombreprof; }
            set
            {
                _nombreprof = _nombreprof != value.Trim() ? value.Trim() : _nombreprof;                
            }
        }

        public string Profesional //PROFESIONAL MAS CODIGO, USO PARA DISPLAYS
        {
            get
            {
                if (!string.IsNullOrEmpty(Descripcion)) { return Codigo + " " + Descripcion; }
                else { return Codigo + " " + ProfesionalNombre; }
            }
        }

        public string ProfesionalNombreOP
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ProfesionalNombre)) { return Codigo + " " + Descripcion; }
                else { return Profesional; }
            }
        }

        public int IDCuentaPrincipal
        {
            get { return idprincipal; }
            set
            {
                idprincipal = idprincipal != value ? value : idprincipal;               
            }
        }

        public decimal SaldoDisponibleCuenta
        {
            get { return _saldodisponiblecta; }
            set { _saldodisponiblecta = _saldodisponiblecta != value ? value : _saldodisponiblecta; }
        }

        public int IDCuentaConjuntoContable { get; set; } = 0;

        public decimal SaldoDisponibleAgrupado
        {
            get { return _saldodisponibleagrupado; }
            set { _saldodisponibleagrupado = _saldodisponibleagrupado != value ? value : _saldodisponibleagrupado; }
        }

        public decimal SaldoDisponibleGeneral
        {
            get
            {
                //ACA CONVERTIA LOS SALDOS NEGATIVOS EN POSITIVOS
                //_saldodisponiblegral = SaldoDisponibleAgrupado < 0 ? -(SaldoDisponibleAgrupado * 2) : SaldoDisponibleAgrupado * 2;
                
                //ACA DIRECTAMENTE DEJO COMO ESTAN, SI SON NEGATIVOS NO SE PROCESA RETIROS
                _saldodisponiblegral = SaldoDisponibleAgrupado * 2;
                return _saldodisponiblegral;
            }
        }

        public decimal SaldoNegativo { get; set; } = 0;
        public bool EsProfesional { get; set; } = true;
        public string EsProfesionalDescripcion { get { return EsProfesional ? "Profesional" : "Entidad"; } } 
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
               
        public virtual List<CuentaCorriente.CuentaCorriente> CuentaCorriente { get; set; } = new List<CuentaCorriente.CuentaCorriente>();

        public int ID_Profesional { get { return IDProfesional; } }
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public Cuentas() { }

        public Cuentas(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        //EVENTOS
        #region EVENTOS Y  METODOS

        //PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        //CLONE 
        #region CLONACION
        public Cuentas Clone()
        {
            Cuentas d = (Cuentas)MemberwiseClone();            
            return d;

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

        //RETORNO LISTA 
        #region CONSULTA DE DATOS
        public List<Cuentas> GetRegistros(bool cargactacte = false)
        {
            try
            {
                List<Cuentas> lista = new List<Cuentas>();

                string c = $"SELECT ID_Registro AS IDRegistro, ID_Profesional AS IDProfesional, Codigo, Descripcion, IDCuentaPrincipal, IDCuentaConjuntoContable" +
                           $" FROM PROFCUENTAS";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Cuentas>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<Cuentas>();
            }
        }

        //RETORNO DE LISTA CON NOMBRE DE PROFESIONAL (FACILITA CARGA COMBOS) SOLO ACTIVOS Y SOCIOS AM
        public List<Cuentas> GetCuentasactivas()
        {
            try
            {
                List<Cuentas> lista = new List<Cuentas>();

                string c = $"SELECT PC.ID_Profesional AS IDProfesional, PC.ID_Registro AS IDRegistro, PC.Codigo, PC.Descripcion, PF.Nombre as ProfesionalNombre, PC.IDCuentaPrincipal" +
                           $" FROM PROFCUENTAS PC" +
                           $" LEFT OUTER JOIN PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" WHERE PC.BeneficiosActivos = 1";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Cuentas>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<Cuentas>();
            }
        }

        //RETORNO DE LISTA CON LA DISPONIBILIDAD DE LA CUENTA (IMPORTE PROMEDIO ULTIMOS 6 MESES) POR CUENTA PRINCIPAL DE FACTURACION = 0 O CONTABLE = 1
        public List<Cuentas> GetSaldodisponible(DateTime? _fechadefinida = null, short cuentagrupo = 0)
        {
            try
            {
                List<Cuentas> lista = new List<Cuentas>();

                DateTime fechaestimada;

                if (_fechadefinida != null)
                {
                    if (Convert.ToDateTime(_fechadefinida).Day > 25)
                    { fechaestimada = new DateTime(Convert.ToDateTime(_fechadefinida).AddMonths(1).Year, Convert.ToDateTime(_fechadefinida).AddMonths(1).Month, 21); }
                    else { fechaestimada = Convert.ToDateTime(_fechadefinida); }                                        
                }
                else
                {
                    if (DateTime.Today.Day > 25)
                    { fechaestimada = new DateTime(DateTime.Today.AddMonths(1).Year, DateTime.Today.AddMonths(1).Month, 21); }
                    else { fechaestimada = DateTime.Today; }
                }

                string minperiodo = fechaestimada.AddMonths(-7).ToString("yyyyMM");

                string c = "";

                //POR CUENTA PRINCIPAL DE FACTURACION
                if (cuentagrupo == 0)
                {
                    c = $"SELECT PC.IDCuentaPrincipal, AVG(T.TOTAL) AS SaldoDisponibleCuenta, PC.ID_Registro AS IDRegistro, PC.Codigo, PC.Descripcion, PC.ID_Profesional AS IDProfesional, PF.Nombre AS ProfesionalNombre" +
                        $" FROM" +
                        $" (SELECT IMPULABO AS Codigo, IMPUPAGO AS Periodo," +
                        $" (sum(ISNULL(IMPUNETB, 0)) - (sum(ISNULL(IMPUMUTU, 0) + ISNULL(IMPUCENT, 0) + ISNULL(IMPUGAAD, 0) + ISNULL(IMPUFOSS, 0) + ISNULL(IMPUCSAM, 0) + ISNULL(IMPUFESA, 0) + ISNULL(IMPUGRME, 0) + ISNULL(IMPCASOC, 0)" +
                        $" + ISNULL(IMPUENAS, 0)) + isnull((SELECT sum(ISNULL(retiimpo, 0))" +
                                $" FROM AmdgoSis.dbo.SISTRETI SI" +
                                $" WHERE SI.reticome = IMPULABO and SI.retipago = IMPUPAGO AND(SI.reticore = '118' OR SI.reticore = '135' OR SI.reticore = '143' OR SI.reticore = '152'" +
                                $" OR SI.reticore = '153' OR SI.reticore = '164' OR SI.reticore = '165' OR SI.reticore = '166' OR SI.reticore = '29')), 0))) AS TOTAL" +
                        $" ,PC.IDCuentaPrincipal AS CuentaPrincipal" +
                        $" FROM AmdgoSis.dbo.ASOCIMPU" +
                        $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF AP ON(AP.PROFCODI = IMPULABO)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(IMPULABO)))" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                        $" WHERE (IMPUPAGO > '{minperiodo}' AND IMPUPAGO <= '{fechaestimada.ToString("yyyyMM")}') AND PC.BeneficiosActivos = 1" +
                        $" GROUP BY  IMPULABO, IMPUPAGO, PC.IDCuentaPrincipal" +
                        $" HAVING (SUM(ISNULL(IMPUNETB, 0)) - (sum(ISNULL(IMPUMUTU, 0) + ISNULL(IMPUCENT, 0) + ISNULL(IMPUGAAD, 0) + ISNULL(IMPUFOSS, 0) + ISNULL(IMPUCSAM, 0) + ISNULL(IMPUFESA, 0) + ISNULL(IMPUGRME, 0) + ISNULL(IMPCASOC, 0)" +
                        $" + ISNULL(IMPUENAS, 0)) + isnull((SELECT sum(ISNULL(retiimpo, 0))" +
                        $" FROM AmdgoSis.dbo.SISTRETI SI" +
                        $" WHERE SI.reticome = IMPULABO and SI.retipago = IMPUPAGO AND(SI.reticore = '118' OR SI.reticore = '135' OR SI.reticore = '143' OR SI.reticore = '152'" +
                        $" OR SI.reticore = '153' OR SI.reticore = '164' OR SI.reticore = '165' OR SI.reticore = '166' OR SI.reticore = '29')), 0))) <> 0)" +
                        $" AS T" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = T.Codigo)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                        $" GROUP BY PC.IDCuentaPrincipal, PC.Codigo, PC.Descripcion, PC.ID_Profesional, PF.Nombre, PC.ID_Registro";
                }
                else // POR CUENTA PRINCIPAL CONTABLE
                {
                    c = $"SELECT PC.IDCuentaConjuntoContable AS IDCuentaPrincipal, AVG(T.TOTAL) AS SaldoDisponibleCuenta, PC.ID_Registro AS IDRegistro, PC.Codigo, PC.Descripcion, PC.ID_Profesional AS IDProfesional, PF.Nombre AS ProfesionalNombre" +
                        $" FROM" +
                        $" (SELECT IMPULABO AS Codigo, IMPUPAGO AS Periodo," +
                        $" (sum(ISNULL(IMPUNETB, 0)) - (sum(ISNULL(IMPUMUTU, 0) + ISNULL(IMPUCENT, 0) + ISNULL(IMPUGAAD, 0) + ISNULL(IMPUFOSS, 0) + ISNULL(IMPUCSAM, 0) + ISNULL(IMPUFESA, 0) + ISNULL(IMPUGRME, 0) + ISNULL(IMPCASOC, 0)" +
                        $" + ISNULL(IMPUENAS, 0)) + isnull((SELECT sum(ISNULL(retiimpo, 0))" +
                                $" FROM AmdgoSis.dbo.SISTRETI SI" +
                                $" WHERE SI.reticome = IMPULABO and SI.retipago = IMPUPAGO AND(SI.reticore = '118' OR SI.reticore = '135' OR SI.reticore = '143' OR SI.reticore = '152'" +
                                $" OR SI.reticore = '153' OR SI.reticore = '164' OR SI.reticore = '165' OR SI.reticore = '166' OR SI.reticore = '29')), 0))) AS TOTAL" +
                        $" ,PC.IDCuentaConjuntoContable AS CuentaPrincipal" +
                        $" FROM AmdgoSis.dbo.ASOCIMPU" +
                        $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF AP ON(AP.PROFCODI = IMPULABO)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(IMPULABO)))" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                        $" WHERE (IMPUPAGO > '{minperiodo}' AND IMPUPAGO <= '{fechaestimada.ToString("yyyyMM")}') AND PC.BeneficiosActivos = 1" +
                        //$" WHERE IMPUPAGO > '{minperiodo}' AND PC.BeneficiosActivos = 1" +
                        $" GROUP BY  IMPULABO, IMPUPAGO, PC.IDCuentaConjuntoContable" +
                        $" HAVING (SUM(ISNULL(IMPUNETB, 0)) - (sum(ISNULL(IMPUMUTU, 0) + ISNULL(IMPUCENT, 0) + ISNULL(IMPUGAAD, 0) + ISNULL(IMPUFOSS, 0) + ISNULL(IMPUCSAM, 0) + ISNULL(IMPUFESA, 0) + ISNULL(IMPUGRME, 0) + ISNULL(IMPCASOC, 0)" +
                        $" + ISNULL(IMPUENAS, 0)) + isnull((SELECT sum(ISNULL(retiimpo, 0))" +
                        $" FROM AmdgoSis.dbo.SISTRETI SI" +
                        $" WHERE SI.reticome = IMPULABO and SI.retipago = IMPUPAGO AND(SI.reticore = '118' OR SI.reticore = '135' OR SI.reticore = '143' OR SI.reticore = '152'" +
                        $" OR SI.reticore = '153' OR SI.reticore = '164' OR SI.reticore = '165' OR SI.reticore = '166' OR SI.reticore = '29')), 0))) <> 0)" +
                        $" AS T" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = T.Codigo)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                        $" GROUP BY PC.IDCuentaConjuntoContable, PC.Codigo, PC.Descripcion, PC.ID_Profesional, PF.Nombre, PC.ID_Registro";
                }

                

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Cuentas>(rdr));
                }

                cnb.Desconectar();

                ProcesoSaldosAgrupadors(lista);

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<Cuentas>();
            }
        }

        private void ProcesoSaldosAgrupadors(List<Cuentas> lista)
        {
            try
            {

                lista.ForEach(f => f.SaldoDisponibleAgrupado = lista.Where(w => w.IDCuentaPrincipal == f.IDCuentaPrincipal).Sum(s => s.SaldoDisponibleCuenta));

            }
            catch (Exception)
            {
                return;
            }
        }
        
        private List<Cuentas> _getSaldosNegativos(DateTime _fecha)
        {
            try
            {

                string periodo = "";

                if (_fecha.Day > 25)
                { periodo = _fecha.ToString("yyyyMM"); }
                else { periodo = _fecha.AddMonths(-1).ToString("yyyyMM"); }                
                
                if (string.IsNullOrEmpty(periodo)) { return new List<Cuentas>(); }

                List<Cuentas> lista = new List<Cuentas>();

                string c = $"SELECT" +
                           $" TT.Codigo," +
                           $" ISNULL(RTRIM(LTRIM(PR.PROFAPNO)), '') AS ProfesionalNombre," +
                           //$" TT.IDCuentaConjuntoContable," +
                           $" ISNULL(PC.IDCuentaConjuntoContable, 0) AS IDCuentaPrincipal," +
                           $" TT.EsProfesional," +
                           $" SUM(SaldoNegativo) AS SaldoNegativo" +
                           $" FROM" +
                           $" (SELECT IIF(PCC.Codigo IS NULL, ISNULL(AI.IMPULABO, ''), PCC.Codigo) AS Codigo, ISNULL(AI.IMPULABO, '') AS CodigoCuenta," +
                           $" ISNULL(PC.IDCuentaConjuntoContable, 0) AS IDCuentaConjuntoContable, ISNULL(PF.EsProfesional, 1) AS EsProfesional," +
                           $" SUM(ISNULL(AI.IMPUCHEQ, 0)) AS SaldoNegativo" +
                           $" FROM AmdgoSis.dbo.ASOCPROF AP" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCIMPU AI ON(AI.IMPULABO = AP.PROFCODI)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(AI.IMPULABO)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PCC ON(PCC.ID_Registro = PC.IDCuentaConjuntoContable)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" WHERE AI.IMPUPAGO = '{periodo}'" +
                           $" GROUP BY PCC.Codigo, AI.IMPULABO, PC.IDCuentaConjuntoContable, PF.EsProfesional)" +
                           $" AS TT" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPROF PR ON(PR.PROFCODI = TT.Codigo)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = LTRIM(RTRIM(PR.PROFCODI)))" +
                           $" GROUP BY TT.Codigo, PR.PROFAPNO, TT.IDCuentaConjuntoContable,PC.IDCuentaConjuntoContable, TT.EsProfesional" +
                           $" HAVING SUM(SaldoNegativo) < 0" +
                           $" ORDER BY TT.Codigo ASC";
                           

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Cuentas>(rdr));
                }

                cnb.Desconectar();

                ProcesoSaldosAgrupadors(lista);

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los saldos negativas.\n{e.Message}", 0);
                return new List<Cuentas>();
            }
        }

        public List<Cuentas> GetSaldosNegativos(DateTime fecha)
        {
            try
            {                
                List<Cuentas> _saldosnegativos = _getSaldosNegativos(fecha);
                List<Cuentas> _saldospromediados = GetSaldodisponible(fecha, 1);

                _saldosnegativos.ForEach(f => f.SaldoDisponibleCuenta = _saldospromediados.Where(w => w.IDCuentaPrincipal == f.IDCuentaPrincipal).Select(s => s.SaldoDisponibleAgrupado).FirstOrDefault());

                return _saldosnegativos;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al procesar la lista de saldos negativos.\n{e.Message}", 1);
                return new List<Cuentas>();
            }
        }

        //CONSULTO SI EXISTE EL REGISTRO POR CODIGO (EVITA REPETIDOS)
        public int ExisteRegbycodigo(string _codigo)
        {
            int retorno = 0;

            try
            {
                string c = $"SELECT ID_Registro FROM {tablaname} WHERE Codigo = '{_codigo}' AND ID_Registro <> {IDRegistro}";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    retorno = Convert.ToInt32(r["ID_Registro"]);
                }

                return retorno;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        
        #endregion

        //ABM DE REGISTROS
        #region ALTA, BAJA Y MODIFICACION DE REGISTROS

        public Dictionary<short, string> Abm()
        {
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            if (IDRegistro <= 0) { return Alta(); }
            else if (IDRegistro > 0) { return Modificacion(); }
            else
            {
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();

            campos.Add("ID_Profesional");
            campos.Add("IDCuentaPrincipal");
            campos.Add("Codigo");
            campos.Add("Descripcion"); 
            campos.Add("IDCuentaConjuntoContable"); 
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
                if (IDProfesional <= 0)
                {
                    retorno.Add(0, "Sin id de profesionaL para registro de alta.");
                    return retorno;
                }

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

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();
                
                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, $"Cuentas Alta.\n{e.Message}");
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
                List<string> campos = new List<string>(RetornaCampos());
                campos.Remove("ID_UsuNew");

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

                cmd.ExecuteNonQuery();
                cbd.Desconectar();
                cmd.Dispose();


                return retorno;
            }
            catch (Exception e)
            {
                retorno.Clear();
                retorno.Add(-1, $"Cuentas Modificacion.\n{e.Message}");
                return retorno;
            }

        }

        #endregion
        #endregion
    }
}
