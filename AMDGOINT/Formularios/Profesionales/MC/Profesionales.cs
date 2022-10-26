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
    public class Profesionales : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
        private static string tablaname = "PROFESIONALES";

        private int idregistro = 0;
        private string nombre = "";
        private short idtipodoc = 0;
        private long cuit = 0;
        private short idiva = 0;
        private string iva = "";
        private string ingresosbrutos = "";
        private DateTime inicioactividad = DateTime.MinValue;
        private string domiciliofiscal = "";
        private int puntovta = 0;
        private bool esprofesional = true;
        private bool visliquidacion = true;
        private string emailfacturas = "";
        private string matricualprov = "";
        private string libro = "";
        private string folio = "";
        private int idtitulo = 0;
        private string titulo = "";
        private int idcategoria = 0;
        private string categoria = "";
        private string matriculanacional = "";
        private DateTime fecnacimiento = DateTime.MinValue;
        private DateTime fecingreso = DateTime.MinValue;
        private int iduniversidad = 0;
        private DateTime fecgraduacion = DateTime.MinValue;
        private string codigoartecurar = "";
        private int nroacta = 0;
        private string regnacionalprest = "";
        private DateTime vtoregnacionalprest = DateTime.MinValue;
        private string sexo = "";
        private bool asociadoam = false;
        private string observaciones = "";
        private int idreferencia = 0;
        private bool estado = true;
        private string referencia = "";
        private short idgrupotitulo = 0;
        private string descripciongrupo = "";
        private string universidad = "";
        private string titulogrupo = "";
        private bool visible = false;
        private DateTime vtohabilitacion = DateTime.MinValue;
        private bool trabajaconiapos = false;

        //DATOS PARA FACTURA DE CREDITO ELECTRONICA
        private bool emitefce = false;
        private string cbu = "";
        private string alias = "";
        private string tipocircuito = "";  //ADC O SCA

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

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value.Trim())
                {
                    nombre = value.Trim();
                }
            }
        }

        public short IDTipodoc
        {
            get { return idtipodoc; }
            set
            {
                if (idtipodoc != value)
                {
                    idtipodoc = value;
                }
            }
        }

        public long Cuit
        {
            get { return cuit; }
            set
            {
                if (cuit != value)
                {
                    cuit = value;
                }
            }
        }

        public short IDIva
        {
            get { return idiva; }
            set
            {
                if (idiva != value)
                {
                    idiva = value;
                }
            }
        }

        public string Iva
        {
            get { return iva; }
            set
            {
                if (iva != value.Trim())
                {
                    iva = value.Trim();
                }
            }
        }

        public string IngresosBrutos
        {
            get { return ingresosbrutos; }
            set
            {
                if (ingresosbrutos != value.Trim())
                {
                    ingresosbrutos = value.Trim();
                }
            }
        }

        public DateTime InicioActividad
        {
            get { return inicioactividad; }
            set
            {
                if (inicioactividad != value)
                {
                    inicioactividad = value;

                }
            }
        }

        public string DomicilioFiscal
        {
            get { return domiciliofiscal; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && domiciliofiscal != value)
                {
                    domiciliofiscal = value.Trim();
                }
            }

        }

        public int PuntoVenta
        {
            get { return puntovta; }
            set
            {
                if (puntovta != value)
                {
                    puntovta = value;
                }
            }
        }

        public bool EsProfesional
        {
            get { return esprofesional; }
            set
            {
                if (esprofesional != value)
                {
                    esprofesional = value;
                }
            }
        }

        public string EsProfesionalDescripcion { get { return EsProfesional ? "Profesional" : "Entidad"; } }

        public bool VisLiquidacion
        {
            get { return visliquidacion; }
            set
            {
                if (visliquidacion != value)
                {
                    visliquidacion = value;
                }
            }
        }
        public string VisLiquidacionDescripcion { get { return VisLiquidacion ? "Si" : "No"; } }

        public string EmailFacturas
        {
            get { return emailfacturas; }
            set
            {
                if (emailfacturas != value.Trim())
                {
                    emailfacturas = value.Trim();
                }
            }

        }

        public string MatriculaProv
        {
            get { return matricualprov; }
            set
            {
                if (matricualprov != value.Trim())
                {
                    matricualprov = value;
                }
            }
        }

        public string Libro
        {
            get { return libro; }
            set
            {
                if (libro != value.Trim())
                {
                    libro = value.Trim();
                }
            }
        }

        public string Folio
        {
            get { return folio; }
            set
            {
                if (folio != value.Trim())
                {
                    folio = value.Trim();
                }
            }
        }

        public int IDTitulo
        {
            get { return idtitulo; }
            set
            {
                if (idtitulo != value)
                {
                    idtitulo = value;
                }
            }
        }

        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (titulo != value.Trim())
                {
                    titulo = value.Trim();
                }
            }
        }

        public string TituloGrupo
        {
            get { return titulogrupo; }
            set
            {
                if (titulogrupo != value.Trim())
                {
                    titulogrupo = value.Trim();
                }
            }
        }

        public short IDGrupo
        {
            get { return idgrupotitulo; }
            set
            {
                if (idgrupotitulo != value)
                {
                    idgrupotitulo = value;
                }
            }
        }

        public string DescripcionGrupo
        {
            get { return descripciongrupo.Trim(); }
            set
            {
                if (descripciongrupo != value.Trim())
                {
                    descripciongrupo = value.Trim();
                }
            }
        }

        public int IDCategoria
        {
            get { return idcategoria; }
            set
            {
                if (idcategoria != value)
                {
                    idcategoria = value;
                }
            }
        }

        public string Categoria
        {
            get { return categoria; }
            set
            {
                if (categoria != value.Trim())
                {
                    categoria = value.Trim();
                }
            }
        }

        public string MatriculaNacional
        {
            get { return matriculanacional; }
            set
            {
                if (matriculanacional != value.Trim())
                {
                    matriculanacional = value;
                }
            }
        }

        public bool TrabajaConIapos
        {
            get { return trabajaconiapos; }
            set { trabajaconiapos = trabajaconiapos != value ? value : trabajaconiapos; }
        }

        public string TrabajaConIaposDescripcion { get { return TrabajaConIapos ? "Si" : "No"; } }

        public DateTime FechaNacimiento
        {
            get { return fecnacimiento; }
            set
            {
                if (fecnacimiento != value)
                {
                    fecnacimiento = value;
                }
            }
        }

        public DateTime FechaIngreso
        {
            get { return fecingreso; }
            set
            {
                if (fecingreso != value)
                {
                    fecingreso = value;
                }
            }

        }

        public int IDUniversidad
        {
            get { return iduniversidad; }
            set
            {
                if (iduniversidad != value)
                {
                    iduniversidad = value;
                }
            }

        }

        public DateTime FechaGraduacion
        {
            get { return fecgraduacion; }
            set
            {
                if (fecgraduacion != value)
                {
                    fecgraduacion = value;
                }
            }
        }

        public string CodigoArteCurar
        {
            get { return codigoartecurar; }
            set
            {
                if (codigoartecurar != value.Trim())
                {
                    codigoartecurar = value.Trim();
                }
            }
        }

        public int NumeroActa
        {
            get { return nroacta; }
            set
            {
                if (nroacta != value)
                {
                    nroacta = value;
                }
            }
        }

        public string Universidad
        {
            get { return universidad; }
            set
            {
                if (universidad != value.Trim())
                {
                    universidad = value.Trim();
                }
            }
        }

        public string RegistroNacional
        {
            get { return regnacionalprest; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && regnacionalprest != value)
                {
                    regnacionalprest = value.Trim();
                }
            }
        }

        public DateTime VtoRegNacional
        {
            get { return vtoregnacionalprest; }
            set
            {
                if (vtoregnacionalprest != value)
                {
                    vtoregnacionalprest = value;
                }
            }

        }

        public DateTime VtoHabilitacion
        {
            get { return vtohabilitacion; }
            set
            {
                if (vtohabilitacion != value)
                {
                    vtohabilitacion = value;
                }
            }

        }

        public string Sexo
        {
            get { return sexo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && sexo != value)
                {
                    sexo = value;
                }
            }
        }

        public bool AsociadoAm
        {
            get { return asociadoam; }
            set
            {
                if (asociadoam != value)
                {
                    asociadoam = value;
                }
            }

        }

        public string AsociadoAmDescripcion { get { return AsociadoAm ? "Asociado" : "No Asociado"; } }

        public string Observaciones
        {
            get { return observaciones; }
            set
            {
                if (observaciones != value.Trim())
                {
                    observaciones = value.Trim();
                }
            }
        }

        public int IDReferencia
        {
            get { return idreferencia; }
            set
            {
                if (idreferencia != value)
                {
                    idreferencia = value;
                }
            }

        }

        public string Referencia
        {
            get { return referencia; }
            set
            {
                if (referencia != value.Trim())
                {
                    referencia = value.Trim();
                }
            }
        }

        public bool Estado
        {
            get { return estado; }
            set
            {
                if (estado != value)
                {
                    estado = value;
                }
            }

        }

        public string EstadoDescripcion { get { return Estado ? "Activo" : "Inactivo"; } }

        public bool AsociadoDiferencial
        {
            get
            {
                bool b = false;
                
                if (Diferencial.Count > 0)
                {
                    var v = Diferencial?.Max(m => m.FechaFin);
                    b = v != null && (Convert.ToDateTime(v) > DateTime.Today || Convert.ToDateTime(v).Year == 1) ? true : false;
                }

                return b;
            }
        }

        public string AsociadoDiferencialDescripcion { get { return AsociadoDiferencial ? "Socio Diferencial" : "Socio Común"; } }

        public bool EmiteComprobanteFCE
        {
            get { return emitefce; }
            set { emitefce = emitefce != value ? value : emitefce; }
        }

        public string CbuComprobanteFCE
        {
            get { return cbu; }
            set { cbu = cbu != value.Trim() ? value.Trim() : cbu; }
        }

        public string AliasComprobanteFCE
        {
            get { return alias; }
            set { alias = alias != value.Trim() ? value.Trim() : alias; }
        }

        public string CircuitoComprobanteFCE
        {
            get { return tipocircuito; }
            set { tipocircuito = tipocircuito != value.Trim() ? value.Trim() : tipocircuito; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = visible != value ? value : visible; }
        }

        public List<Direcciones> Direcciones { get; set; } = new List<Direcciones>();

        public List<Especialidades> Especialidades { get; set; } = new List<Especialidades>();

        public List<Prestatarias> Prestatarias { get; set; } = new List<Prestatarias>();

        public List<Cuentas> Cuentas { get; set; } = new List<Cuentas>();

        public List<Diferencial> Diferencial { get; set; } = new List<Diferencial>();

        public List<RetencionGanancias> RetencionGanancias { get; set; } = new List<RetencionGanancias>();
        public List<RetencionIngresosBrutos> RetencionIngresosBrutos { get; set; } = new List<RetencionIngresosBrutos>();
        public List<RetencionInstitutoBecario> RetencionInstitutoBecario { get; set; } = new List<RetencionInstitutoBecario>();
        public List<CategoriaCondicionesIva> CategoriaCondicionesIva { get; set; } = new List<CategoriaCondicionesIva>();
        

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        //DE IGUALACION CON CAMPOS DE BD
        public short ID_TipoDoc { get { return IDTipodoc; } }
        public short ID_Iva { get { return IDIva; } }
        public int ID_Titulo { get { return IDTitulo; } }
        public int ID_Categoria { get { return IDCategoria; } }
        public int ID_Universidad { get { return IDUniversidad; } }
        public int ID_Referencia { get { return IDReferencia; } }
        public int ID_UsuNew { get { return glb.GetIdUsuariolog(); } }
        public int ID_UsuModif { get { return glb.GetIdUsuariolog(); } }
        public string Guid { get { return IDLocal; } }
        public string IngrBrutos { get { return IngresosBrutos; } }
        public string DomFiscal { get { return DomicilioFiscal; } }
        public string Email { get { return EmailFacturas; } }
        public string MatriculaNac { get { return MatriculaNacional; } }
        public int NroActa { get { return NumeroActa; } }
        public string RegNacPrestador { get { return RegistroNacional; } }
        public DateTime VtoRegNacPrestador { get { return VtoRegNacional; } }
        public DateTime TimeModif { get { return DateTime.Now; } }
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Profesionales() { }

        public Profesionales(SqlConnection conexion)
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
        public Profesionales Clone()
        {
            Profesionales d = (Profesionales)MemberwiseClone();

            Direcciones dir = new Direcciones();
            Especialidades esp = new Especialidades();
            Cuentas cuen = new Cuentas();
            Prestatarias pr = new Prestatarias();
            Diferencial df = new Diferencial();
            RetencionGanancias rg = new RetencionGanancias();
            RetencionIngresosBrutos rig = new RetencionIngresosBrutos();
            RetencionInstitutoBecario rib = new RetencionInstitutoBecario();
            CategoriaCondicionesIva cci = new CategoriaCondicionesIva();
            

            d.Direcciones = dir.Clone(Direcciones);
            d.Especialidades = esp.Clone(Especialidades);
            d.Cuentas = cuen.Clone(Cuentas);
            d.Prestatarias = pr.Clone(Prestatarias);
            d.Diferencial = df.Clone(Diferencial);
            d.RetencionGanancias = rg.Clone(RetencionGanancias);
            d.RetencionIngresosBrutos = rig.Clone(RetencionIngresosBrutos);
            d.RetencionInstitutoBecario = rib.Clone(RetencionInstitutoBecario);
            d.CategoriaCondicionesIva = cci.Clone(CategoriaCondicionesIva);
            

            return d;

        }
                
        //CLONE CON LISTAS
        public List<Profesionales> Clone(List<Profesionales> lst)
        {
            List<Profesionales> lista = new List<Profesionales>();

            foreach (Profesionales d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO DE LISTA PROFESIONALES
        #region CONSULTA DE DATOS
        public List<Profesionales> GetProfesionales()
        {            
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Profesionales> lista = new List<Profesionales>();

                string c = $"SELECT PR.ID_Registro AS IDRegistro, PR.Nombre, PR.ID_TipoDoc AS IDTipodoc, PR.Cuit, PR.ID_Iva AS IDIva, PR.IngrBrutos AS IngresosBrutos, PR.InicioActividad," +
                    $" PR.DomFiscal AS DomicilioFiscal, PR.PuntoVenta, PR.EsProfesional, PR.VisLiquidacion, PR.Email AS EmailFacturas, PR.MatriculaProv, PR.Libro, PR.Folio, PR.ID_Titulo AS IDTitulo," +
                    $" PR.ID_Categoria AS IDCategoria, PR.MatriculaNac AS MatriculaNacional, PR.FechaNacimiento, PR.FechaIngreso, PR.ID_Universidad AS IDUniversidad, PR.FechaGraduacion, PR.CodigoArteCurar," +
                    $" PR.NroActa AS NumeroActa, PR.RegNacPrestador AS RegistroNacional, PR.VtoRegNacPrestador AS VtoRegNacional, PR.Sexo, PR.AsociadoAm," +
                    $" PR.Observaciones, PR.ID_Referencia AS IDReferencia, PR.Estado, ISNULL(PT.Descripcion, '') AS Titulo, ISNULL(CD.Abreviatura,'') AS Iva, ISNULL(PC.Descripcion, '') AS Categoria," +
                    $" ISNULL(RE.Descripcion, '') AS Referencia, TG.ID_Registro AS IDGrupo, TG.Descripcion AS DescripcionGrupo, ISNULL(PU.Descripcion, '') AS Universidad," +
                    $" ISNULL(PTG.Descripcion, '') AS TituloGrupo, PR.Guid AS IDLocal, PR.Visible, PR.VtoHabilitacion, PR.TrabajaConIapos" +
                    $" FROM {tablaname} PR" +
                    $" LEFT OUTER JOIN PROFTITULOS PT ON(PT.ID_Registro = PR.ID_Titulo)" +
                    $" LEFT OUTER JOIN PROFUNIVERSIDADES PU ON(PU.ID_Registro = PR.ID_Universidad)" +
                    $" LEFT OUTER JOIN PROFTITULOSGRUPO PTG ON(PTG.ID_Registro = PT.ID_Grupo)" +
                    $" LEFT OUTER JOIN PROFTITULOSGRUPO TG ON(TG.ID_Registro = PT.ID_Grupo)" +
                    $" LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                    $" LEFT OUTER JOIN PROFCATEGORIA PC ON(PC.ID_Registro = PR.ID_Categoria)" +
                    $" LEFT OUTER JOIN PROFEREFERENCIAS RE ON(RE.ID_Registro = PR.ID_Referencia)";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<Profesionales>(rdr));
                }

                cnb.Desconectar();

                //DIRECCIONES Y CONTACTOS
                #region DIRECCIONES
                Direcciones dirclass = new Direcciones(SqlConnection);                                
                List<Direcciones> d = dirclass.GetDirecciones();

                foreach (Profesionales p in lista)
                {
                    p.Direcciones = dirclass.Clone(d.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }

                #endregion

                //PRESTATARIAS
                #region PRESTATARIAS
                Prestatarias prest = new Prestatarias(SqlConnection);
                List<Prestatarias> pr = prest.GetRegistros();

                foreach (Profesionales p in lista)
                {
                    p.Prestatarias = prest.Clone(pr.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }

                #endregion

                //ESPECIALIDADES
                #region ESPECIALIDADES
                Especialidades especls = new Especialidades(SqlConnection);
                List<Especialidades> espe = especls.GetEspecialidad();

                foreach (Profesionales p in lista)
                {                    
                    p.Especialidades = especls.Clone(espe.Where(w => w.IDProfesional == p.IDRegistro).ToList());                                     
                }
                #endregion

                //CUENTAS
                #region CUENTAS
                Cuentas cuentacls = new Cuentas(SqlConnection);
                List<Cuentas> cu = cuentacls.GetRegistros(true);

                foreach (Profesionales p in lista)
                {
                    p.Cuentas = cuentacls.Clone(cu.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }
                #endregion

                //DIFERENCFIAL
                #region DIFERENCIAL
                Diferencial diferencialclas = new Diferencial(SqlConnection);
                List<Diferencial> df = diferencialclas.GetRegistros();

                foreach (Profesionales p in lista)
                {
                    p.Diferencial = diferencialclas.Clone(df.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }
                #endregion

                //RETENCION GANANCIAS
                #region GANANCIAS
                RetencionGanancias retgan = new RetencionGanancias(SqlConnection);
                List<RetencionGanancias> rtg = retgan.GetRegistros();

                foreach (Profesionales p in lista)
                {
                    p.RetencionGanancias = retgan.Clone(rtg.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }
                #endregion

                //RETENCION INGRESOS BRUTOS
                #region INGRESOS BRUTOS
                RetencionIngresosBrutos retigb = new RetencionIngresosBrutos(SqlConnection);
                List<RetencionIngresosBrutos> reigb = retigb.GetRegistros();

                foreach (Profesionales p in lista)
                {
                    p.RetencionIngresosBrutos = retigb.Clone(reigb.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }
                #endregion

                //RETENCION INSTITUTO BECARIO
                #region INSTITUTO BECARIO
                RetencionInstitutoBecario retib = new RetencionInstitutoBecario(SqlConnection);
                List<RetencionInstitutoBecario> rib = retib.GetRegistros();

                foreach (Profesionales p in lista)
                {
                    p.RetencionInstitutoBecario = retib.Clone(rib.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }
                #endregion

                //CONDICIONES DE IVA            
                #region CONDICIONES DE IVA
                CategoriaCondicionesIva cdiva = new CategoriaCondicionesIva(SqlConnection);
                List<CategoriaCondicionesIva> cci = cdiva.GetRegistros();

                foreach (Profesionales p in lista)
                {
                    p.CategoriaCondicionesIva = cdiva.Clone(cci.Where(w => w.IDProfesional == p.IDRegistro).ToList());
                }
                #endregion

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Profesionales>();
            }
        }
                
        //ASIGNO AL ID DE REGISTRO SEGUN GUID (ME PERMITE GUARDAR CONTACTOS ASOCIADOS CREADOS DESDE CERO)
        private void SetIdbyguid()
        {
            string c = $"SELECT ID_Registro FROM {tablaname} WHERE Guid = '{IDLocal}'";

            foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
            {
                IDRegistro = Convert.ToInt32(r["ID_Registro"]);
            }
        }

        //CONSULTO SI EXISTE EL REGISTRO POR CUIT (EVITA REPETIDOS)
        public int ExisteregbyCuit()
        {
            int retorno = 0;

            try
            {
                string c = $"SELECT ID_Registro FROM {tablaname} WHERE Cuit = {Cuit} AND ID_Registro <> {IDRegistro}";

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
                retorno.Add(0, "No se cumplieron los requisitos de ID para guardar los registros.");
                return retorno;
            }
        }

        private List<string> RetornaCampos()
        {
            List<string> campos = new List<string>();
                        
            campos.Add("Guid");
            campos.Add("Nombre");
            campos.Add("ID_TipoDoc");
            campos.Add("Cuit");
            campos.Add("ID_Iva");
            campos.Add("IngrBrutos");
            campos.Add("InicioActividad");
            campos.Add("DomFiscal");
            campos.Add("PuntoVenta");
            campos.Add("EsProfesional");
            campos.Add("VisLiquidacion");
            campos.Add("Email");
            campos.Add("MatriculaProv");
            campos.Add("Libro");
            campos.Add("Folio");
            campos.Add("ID_Titulo");
            campos.Add("ID_Categoria");            
            campos.Add("MatriculaNac");
            campos.Add("FechaNacimiento");
            campos.Add("FechaIngreso");
            campos.Add("ID_Universidad");
            campos.Add("FechaGraduacion");
            campos.Add("CodigoArteCurar");
            campos.Add("NroActa");
            campos.Add("RegNacPrestador");
            campos.Add("VtoRegNacPrestador");
            campos.Add("VtoHabilitacion");
            campos.Add("Sexo");
            campos.Add("AsociadoAm");
            campos.Add("Observaciones");
            campos.Add("ID_Referencia");
            campos.Add("Estado");
            campos.Add("TrabajaConIapos");
            campos.Add("ID_UsuNew");
            campos.Add("ID_UsuModif");
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
                foreach(string c in campos)
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
                    //ACTUALIZO LAS DIRECCIONES 
                    foreach (Direcciones dir in Direcciones)
                    {
                        //ASIGNO CONNEXION
                        dir.SqlConnection = SqlConnection;
                        dir.IDProfesional = IDRegistro;
                        var dic = dir.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO LAS ESPECIALIDADES
                    foreach (Especialidades e in Especialidades)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO LAS PRESTATARIAS
                    foreach (Prestatarias e in Prestatarias)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO LAS CUENTAS
                    foreach (Cuentas e in Cuentas)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO LOS DIFERENCIAL
                    foreach (Diferencial e in Diferencial)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO RETENCION INGRESOS BRUTOS
                    foreach (RetencionIngresosBrutos e in RetencionIngresosBrutos)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO RETENCION GANANCIAS
                    foreach (RetencionGanancias e in RetencionGanancias)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO RETENCION BECARIO
                    foreach (RetencionInstitutoBecario e in RetencionInstitutoBecario)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                    //ACTUALIZO CONDICIONES IVA
                    foreach (CategoriaCondicionesIva e in CategoriaCondicionesIva)
                    {
                        e.SqlConnection = SqlConnection;
                        e.IDProfesional = IDRegistro;
                        var dic = e.Abm();

                        PreparaRetorno(retorno, dic);
                    }

                }                

                cbd.Desconectar();
                cmd.Dispose();
                
                return retorno;
            }
            catch (Exception e)
            {                
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
                    if (GetType().GetProperty(c).PropertyType == typeof(DateTime) && Convert.ToDateTime(GetType().GetProperty(c).GetValue(this)) == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", DBNull.Value);
                    }
                    else { cmd.Parameters.AddWithValue($"p{paramnro.ToString()}", GetType().GetProperty(c).GetValue(this)); }
                    
                    paramnro++;
                }

                try
                {                   
                    //EJECUTO LA ACTUALIZACION
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    cbd.Desconectar();
                    cmd.Dispose();
                    retorno.Add(-1, $"Profesional Modificación.\n{e.Message}");
                    return retorno;                    
                }
                

                //ACTUALIZO LAS DIRECCIONES 
                foreach (Direcciones dir in Direcciones)
                {
                    //ASIGNO CONNEXION
                    dir.SqlConnection = SqlConnection;                    
                    dir.IDProfesional = IDRegistro;
                    var dic = dir.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO LAS ESPECIALIDADES
                foreach (Especialidades e in Especialidades)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO LAS PRESTATARIAS
                foreach (Prestatarias e in Prestatarias)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO LAS CUENTAS
                foreach (Cuentas e in Cuentas)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO LOS DIFERENCIAL
                foreach (Diferencial e in Diferencial)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO RETENCION INGRESOS BRUTOS
                foreach (RetencionIngresosBrutos e in RetencionIngresosBrutos)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO RETENCION GANANCIAS
                foreach (RetencionGanancias e in RetencionGanancias)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO RETENCION BECARIO
                foreach (RetencionInstitutoBecario e in RetencionInstitutoBecario)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                //ACTUALIZO CONDICIONES IVA
                foreach (CategoriaCondicionesIva e in CategoriaCondicionesIva)
                {
                    e.SqlConnection = SqlConnection;
                    e.IDProfesional = IDRegistro;
                    var dic = e.Abm();

                    PreparaRetorno(retorno, dic);
                }

                cbd.Desconectar();
                cmd.Dispose();
                
                return retorno;
            }
            catch (Exception e)
            {                
                retorno.Add(-1, $"Profesional Modificación.\n{e.Message}");
                return retorno;
            }

        }

        private void PreparaRetorno(Dictionary<short, string> retorno, Dictionary<short, string> proc)
        {
            foreach (var y in proc)
            {
                if (retorno.Where(w => w.Key == y.Key).Count() <= 0)
                {
                    retorno.Add(y.Key, y.Value);
                }
                else
                {
                    retorno.Add((short)(retorno.Max(m => m.Key) +1), y.Value);
                }
            }
        }

        #endregion


        #endregion
    }
}
