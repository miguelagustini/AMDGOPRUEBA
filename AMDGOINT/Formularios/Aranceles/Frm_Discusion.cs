using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using AMDGOINT.Formularios.Practicas;
using System.Globalization;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using AMDGOINT.Formularios.Informes;
using System.IO;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_Discusion : XtraForm
    {
        private ConexionBD cbd = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Practicasclass practcls = new Practicasclass();
        private Propiedadesgral prop = new Propiedadesgral();
        private Discusionescls discusioncls = new Discusionescls();

        public bool Es_Popup { get; set; } = false;
        public DiscusionEncabezado discusionenc { get; set; } = new DiscusionEncabezado();
        private DiscusionDetalle discusiondetalle = new DiscusionDetalle();
        private DiscusionExtra discusionExtra = new DiscusionExtra();
        private DiscusionGrupoObs discusionGrupo = new DiscusionGrupoObs();
        private DiscusionRespuestasAM discusionrespuesta = new DiscusionRespuestasAM();
        private DiscusionOtros discusionotros = new DiscusionOtros();
        private List<EstructuraExcel> excelimport = new List<EstructuraExcel>();
        private List<DiscusionDetalle> ValoresOldlst = new List<DiscusionDetalle>();
        private List<PracticasNomencladas> PracticasNomencladas = new List<PracticasNomencladas>();

        private DateTime FechaImpacto { get; set; } = DateTime.Today;
        private byte TipoValordetalle { get; set; } = 0;
        private short OrdenSegundoplano { get; set; } = 0;
        private bool Recarga { get; set; } = false;
        private Point LocationSplash = new Point();

        private bool _pedidodifporc = false;
        private bool _pedidodifpeso = false;
        private bool _pactadodifporc = false;
        private bool _pactadodifpeso = false;
        private bool _valnomenc = false;
        private bool _coseguro = false;
        private bool _copago = false;
        private bool _canedit = false;

        private SqlConnection SqlConnection = new SqlConnection();
        private string[] Galenosygastosex = new string[55] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
                                                             "GI", "GB", "GN", "GQ", "GR", "GT", "GU", "OG",
                                                             "T1","T2","T3","T4","T5","T6","T7","T8","T9","TA",
                                                             "N1","N2","N3","N4","N5","N6","N7","N8",
                                                             "G1","G2","G3","G4","G5","G6","G7","G8","G9",
                                                             "P1","P2","P3","P4","P5","P6","P7","P8","P9"};
        public Frm_Discusion()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosed += new FormClosedEventHandler(Formulario_Closed);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            pvControl.EditValueChanged += PivotControl_EditValueChanged;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            SqlConnection = cbd.Conectar();

        }

        #region METODOS MANUALES

        #region ABM DE REGISTROS

        //ABM DE REGISTROS
        private void Abm()
        {
            try
            {
                if (!ScreenManager.IsSplashFormVisible) { ScreenManager.ShowWaitForm(); }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_AranValoriza");
                campos.Add("ID_GrupoValor");
                campos.Add("Guid");
                campos.Add("FechaInicio");
                campos.Add("FechaImpacto");
                if (discusionenc.IDRegistro <= 0) { campos.Add("ID_UsuNew"); }
                campos.Add("ID_UsuModif");

                parametros.Add(discusionenc.IDAranvaloriza);
                parametros.Add(discusionenc.IDGrupoOs);
                parametros.Add(discusionenc.IDLocal);
                parametros.Add(Convert.ToDateTime(datFecha.Text));
                parametros.Add(Convert.ToDateTime(datImpacto.Text));

                if (discusionenc.IDRegistro <= 0) { parametros.Add(glob.GetIdUsuariolog()); }

                parametros.Add(glob.GetIdUsuariolog());

                //GUARDO EL ENCABEZADO
                string acc = discusionenc.IDRegistro <= 0 ? "I" : "U";                
                func.AccionBD(campos, parametros, acc, "DISCUSIONENC", discusionenc.IDRegistro);

                //RECUPERO EL ID AGREGADO EN CASO DE SER UN REGISTRO NUEVO
                if (discusionenc.IDRegistro <= 0) { discusionenc.IDRegistro = GetIDaranguid(discusionenc.IDLocal); }

                //GUARDO PLANES ASOCIADOS AL AGRUPADOR EN ÉSTE MOMENTO                
                if (acc == "I") { GuardaHistoGrpval(); }

                //GUARDAR DETALLES
                GuardaDetalles();

                //GUARDO EXTRAS
                GuardaExtras();

                //GUARDO OTROS - VARIOS
                GuardaOtrosvarios();

                //GUARDO OBSERVACIONES DE GRUPO
                GuardaGruposObs();

                //GUARDO LAS RESPUESTAS (AM / OS)
                GuardaRespuestas();

                Continuacion();

                if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al guardar los registros.\n {e.Message}", 0);
                if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
                return;
            }
        }

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Desea Continuar editando?") == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    Recarga = true;
                    Ibusqregistros();
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al preparar la continuacion.\n{e.Message}", 1);
            }
        }

        //GET ID ARANCEL POR GUID
        private int GetIDaranguid(string g)
        {
            int retorno = 0;

            try
            {
                string c = "SELECT ID_Registro FROM DISCUSIONENC WHERE Guid = '" + g + "'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows) { retorno = Convert.ToInt32(r["ID_Registro"]); }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al obtener el id de discusión.\n {e.Message}", 0);
                return retorno;
            }
        }

        //GUARDO HISTORICO DE PLANES POR GRUPO A ESTE MOMENTO
        public void GuardaHistoGrpval()
        {
            try
            {
                if (discusionenc.IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_Encabezado");
                campos.Add("ID_PrestDetalle");
                campos.Add("ID_Agrupador");

                //SELECCIONO TODOS LOS CODIGOS ASOCIADOS ACTUALMENTE A ÉSTE GRUPO
                string c = "SELECT ID_Registro, ID_Agrupador FROM PRESTDETALLES WHERE ID_Agrupador = " + discusionenc.IDGrupoOs;

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    parametros.Clear();
                    parametros.Add(discusionenc.IDRegistro);
                    parametros.Add(Convert.ToInt32(r["ID_Registro"]));
                    parametros.Add(Convert.ToInt32(r["ID_Agrupador"]));

                    func.AccionBD(campos, parametros, "I", "DISCGRPVALHIST");
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al guardar los agrupadores historicos.\n{e.Message}", 1);
                return;
            }
        }

        //GUARDO LOS DETALLES 
        private void GuardaDetalles()
        {
            try
            {
                
                if (discusionenc.IDRegistro <= 0) {  return; }
                                
                int contador = 0;
                int acumulado = 0;

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = SqlConnection.State != ConnectionState.Open ? cbd.Conectar() : SqlConnection; //cbd.Conectar();

                //PRIMERO BORRO LOS DETALLES MARCADOS (EN CASO DE QUE LOS HAYA)
                Borrardetalles();

                //INSERTO NUEVAS PRACTICAS
                Insertarnewpracticas();

                //VALORES A INSERTAR
                List<DiscusionDetalle> detinserted = discusiondetalle.Clone(discusionenc.Detalles.Where(d => d.IDRegistro == 0).ToList());

                StringBuilder sb = new StringBuilder();

                string a = "INSERT INTO DISCUSIONDET (ID_Encabezado, Guid, FechaNeg, ID_Practica, CodigoOs, ID_Funcion, Valor, ValorCoseguro, ValorCopago, Observacion," +
                           " CodigoGasto, EsAmdgo, Aplicado, ID_UsuNew) VALUES ";

                foreach (DiscusionDetalle av in detinserted)
                {

                    //DEFINO SI LA NUEVA PRACTICA ESTA EN VALORIZACION APLICADA O NO                    
                    if (discusionenc.FechaCierre == av.FechaNeg) { av.Aplicado = discusionenc.Estado; }                                       
                  
                    sb.Append(a + $"({discusionenc.IDRegistro}, '{av.IDLocal}', '{av.FechaNeg}', {av.IDPractAm}," +
                                  $" '{(av.CodigoOs.Trim().Length > 12 ? av.CodigoOs.Substring(0, 12).Trim() : av.CodigoOs)}', {av.IDFuncion}," +
                                  $" {av.Valor.ToString(new CultureInfo("en-US"))}, {av.ValorCoseguro.ToString(new CultureInfo("en-US"))}," +
                                  $" {av.ValorCopago.ToString(new CultureInfo("en-US"))}," +
                                  $" '{(av.Obsdetalle.Trim().Length > 1000 ? av.Obsdetalle.Substring(0, 1000).Trim() : av.Obsdetalle)}'," +
                                  $" '{(av.CodigoGasto.Trim().Length > 10 ? av.CodigoGasto.Substring(0, 10).Trim() : av.CodigoGasto)}', {av.TipoValor}," +
                                  $" {av.Aplicado}, {glob.GetIdUsuariolog()});");
                    
                    if (contador == 1000 || ((detinserted.Count - 1) == acumulado))
                    {
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            using (var command = new SqlCommand())
                            {                                
                                if (sb.ToString() != "")
                                {
                                    command.Connection = con;
                                    command.Transaction = transaction;
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = sb.ToString();
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }

                            }
                        }
                        sb.Clear();
                        contador = 0;
                    }

                    acumulado++;
                    contador++;

                }

                /**** PROCEDIMIENTO AMDGOSIS ****/
                //SOLO SI HAY FECHA DE IMPACTO ASIGNADA Y SE INSERTA NUEVAS PRACTICAS y EL ESTADO ES MAYOR A CERO
                if (discusionenc.FechaImpacto > DateTime.MinValue && detinserted.Where(w => w.Aplicado > 0).Count() > 0 && discusionenc.Estado > 0)
                {
                    discusioncls.InsertIdvAmdgosis(discusiondetalle.Clone(detinserted.Where(w => w.Aplicado > 0).ToList()), 
                        discusionenc.CodigoGupo, discusionenc.FechaImpacto);
                }
                
                //VALORES A ACTUALIZAR
                List<DiscusionDetalle> detupdated = discusiondetalle.Clone(discusionenc.Detalles.Where(d => d.IDRegistro > 0).ToList());

                contador = 0;
                acumulado = 0;
                sb.Clear();

                foreach (DiscusionDetalle av in detupdated)
                {                    
                    sb.Append($"UPDATE DISCUSIONDET SET" +
                           $" CodigoOs = '{(av.CodigoOs.Trim().Length > 12 ? av.CodigoOs.Substring(0, 12).Trim() : av.CodigoOs)}'," +
                           $" CodigoGasto = '{(av.CodigoGasto.Trim().Length > 10 ? av.CodigoGasto.Substring(0, 10).Trim() : av.CodigoGasto)}'," +
                           $" ID_Funcion = {av.IDFuncion}," +
                           $" Valor = {av.Valor.ToString(new CultureInfo("en-US"))}," +
                           $" ValorCoseguro = {av.ValorCoseguro.ToString(new CultureInfo("en-US"))}," +
                           $" ValorCopago = {av.ValorCopago.ToString(new CultureInfo("en-US"))}," +
                           $" Observacion = '{(av.Obsdetalle.Trim().Length > 1000 ? av.Obsdetalle.Substring(0, 1000).Trim() : av.Obsdetalle)}'," +
                           $" ID_UsuModif = {glob.GetIdUsuariolog()}," +
                           $" EsAmdgo = {av.TipoValor}" +
                           $" WHERE ID_Registro = {av.IDRegistro};");

                    if (contador == 1000 || ((detupdated.Count - 1) == acumulado))
                    {
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            using (var command = new SqlCommand())
                            {                                
                                if (sb.ToString() != "")
                                    {
                                    command.Connection = con;
                                    command.Transaction = transaction;
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = sb.ToString();
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }

                            }
                        }

                        sb.Clear();
                        contador = 0;
                    }

                    acumulado++;
                    contador++;

                }

                //SOLO PASO POR EL UPDATE SI HAY FECHA DE IMPACTO ASIGANDA Y EL ESTADO ES MAYOR A CERO
                if (discusionenc.FechaImpacto > DateTime.MinValue && discusionenc.Estado > 0)
                {

                    //SI HAY EPOCA APLICADA CORRECTAMENTE
                    int epoca = discusioncls.GetEpoca(discusionenc.FechaImpacto, discusionenc.CodigoGupo);
                    if (epoca < 0) { return; }

                    //SI LA CARGA FUE ORIGINADA EN ESTE SISTEMA
                    if (!discusioncls.GetOrigencargadatos(epoca, discusionenc.CodigoGupo)) { return; }

                    //ACTUALIZO LOS VALORES POR ID (PRACTICAS)
                    discusioncls.UpdateIdvAmdgosis(discusiondetalle.Clone(detupdated), discusionenc.CodigoGupo, discusionenc.IDRegistro);

                    //BORRO Y ASIGNO LOS HOMONIMOS NUEVAMENTE
                    if (detinserted.Count > 0 || detupdated.Count > 0)
                    {
                        discusioncls.AsocHomonimos(discusionenc.Detalles, discusionenc.CodigoGupo);
                    }
                }
                              
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar los detalles.\n {e.Message}", 0);              
                return;
            }
        }

        //GUARDO LOS EXTRAS 
        private void GuardaExtras()
        {
            try
            {
                if (discusionenc.IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();
              
                ArrayList parametros = new ArrayList();
                
                foreach (DiscusionExtra ex in discusionenc.Extras)
                {
                    //BORRAR
                    if (ex._BorraRegistro && ex.IDRegistro > 0)
                    {
                        func.AccionBD(campos, parametros, "D", "DISCUSIONEXTRA", ex.IDRegistro);
                        continue;
                    }

                    //INSERTAR
                    if (ex.IDRegistro <= 0)
                    {
                        campos.Clear();
                        campos.Add("ID_Encabezado");
                        campos.Add("Descripcion");
                        campos.Add("ID_UsuNew");
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();
                        parametros.Add(discusionenc.IDRegistro);
                        parametros.Add(ex.Descripcion);
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "I", "DISCUSIONEXTRA");
                        
                    }//MODIFICAR
                    else
                    {
                        campos.Clear();                        
                        campos.Add("Descripcion");                        
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();                        
                        parametros.Add(ex.Descripcion);                        
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "U", "DISCUSIONEXTRA", ex.IDRegistro);
                        continue;
                    }

                }
                              
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar los extras.\n {e.Message}", 0);
                return;
            }
        }

        //GUARDO LAS OBSERVACIONES DE GRUPO
        private void GuardaGruposObs()
        {
            try
            {
                if (discusionenc.IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();                
                ArrayList parametros = new ArrayList();

                foreach (DiscusionGrupoObs ex in discusionenc.GruposObs)
                {
                  
                    //INSERTAR
                    if (ex.IDRegistro <= 0)
                    {
                        campos.Clear();
                        campos.Add("ID_Encabezado");
                        campos.Add("ID_GrupoPractica");
                        campos.Add("Observacion");
                        campos.Add("ID_UsuNew");
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();
                        parametros.Add(discusionenc.IDRegistro);
                        parametros.Add(ex.IDGrupoPractica);
                        parametros.Add(ex.Observacion.Trim());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "I", "DISCUSIONGRPOBS");
                        
                    }
                    else //MODIFICAR                    
                    {
                        campos.Clear();                        
                        campos.Add("ID_GrupoPractica");
                        campos.Add("Observacion");                        
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();
                        parametros.Add(ex.IDGrupoPractica);
                        parametros.Add(ex.Observacion.Trim());                        
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "U", "DISCUSIONGRPOBS", ex.IDRegistro);
                        
                    }

                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar las observaciones de grupo.\n {e.Message}", 0);
                return;
            }
        }

        //GUARDO OTROS - VARIOS 
        private void GuardaOtrosvarios()
        {
            try
            {
                if (discusionenc.IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();                

                foreach (DiscusionOtros ex in discusionenc.Otros)
                {
                    //BORRAR
                    if (ex._BorraRegistro && ex.IDRegistro > 0)
                    {
                        func.AccionBD(campos, parametros, "D", "DISCUSIONOTROS", ex.IDRegistro);
                        continue;
                    }

                    //INSERTAR
                    if (ex.IDRegistro <= 0)
                    {
                        campos.Clear();
                        campos.Add("ID_Encabezado");
                        campos.Add("CodigoOs");
                        campos.Add("CodigoAm");
                        campos.Add("Descripcion");
                        campos.Add("Observacion");
                        campos.Add("Valor");
                        campos.Add("ID_UsuNew");
                        campos.Add("ID_UsuModif");                        

                        parametros.Clear();
                        parametros.Add(discusionenc.IDRegistro);
                        parametros.Add(ex.CodigoOs.Trim());
                        parametros.Add(ex.CodigoAm.Trim());
                        parametros.Add(ex.Descripcion.Trim());
                        parametros.Add(ex.Observacion.Trim());
                        parametros.Add(ex.Valor.Trim());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(glob.GetIdUsuariolog());                        

                        func.AccionBD(campos, parametros, "I", "DISCUSIONOTROS");
                        
                    } //MODIFICAR
                    else
                    {
                        campos.Clear();                        
                        campos.Add("CodigoOs");
                        campos.Add("CodigoAm");
                        campos.Add("Descripcion");
                        campos.Add("Observacion");
                        campos.Add("Valor");                        
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();                        
                        parametros.Add(ex.CodigoOs.Trim());
                        parametros.Add(ex.CodigoAm.Trim());
                        parametros.Add(ex.Descripcion.Trim());
                        parametros.Add(ex.Observacion.Trim());
                        parametros.Add(ex.Valor.Trim());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "U", "DISCUSIONOTROS", ex.IDRegistro);
                        
                    }

                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar los extras.\n {e.Message}", 0);
                return;
            }
        }

        //GUARDO LAS RESPUESTAS 
        private void GuardaRespuestas()
        {
            try
            {
                if (discusionenc.IDRegistro <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                //PRIMERO BORRO
                BorraRespuestas();

                //RECORRO LAS RESPUESTAS AM
                foreach (DiscusionRespuestasAM ex in discusionenc.Respuestas.Where(w => !w._BorraRegistro))
                {

                    //INSERTAR
                    if (ex.IDRegistro <= 0)
                    {
                        campos.Clear();
                        campos.Add("ID_Encabezado");
                        campos.Add("ID_Local");
                        campos.Add("Numero");
                        campos.Add("Texto");
                        campos.Add("ID_UsuNew");
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();
                        parametros.Add(discusionenc.IDRegistro);
                        parametros.Add(ex.IDLocal);
                        parametros.Add(ex.Numero);
                        parametros.Add(ex.Texto);
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "I", "DISCUSIONRPTAM");
                    }
                    else //MODIFICAR                    
                    {
                        campos.Clear();                        
                        campos.Add("Numero");
                        campos.Add("Texto");                        
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();                        
                        parametros.Add(ex.Numero);
                        parametros.Add(ex.Texto);
                        parametros.Add(glob.GetIdUsuariolog());                        
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "U", "DISCUSIONRPTAM", ex.IDRegistro);                        
                    }


                    //AGREGO LAS RESPUES DE OS EN CASO DE TENERLAS
                    if (ex.IDRegistro <= 0)
                    {
                        GuardaRespuestasos(ex.RespuestaOs.ToList(), Getidrespuesta(ex.IDLocal));
                    }
                    else
                    {
                        GuardaRespuestasos(ex.RespuestaOs.ToList(), ex.IDRegistro);
                    }

                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar las respuestas am.\n {e.Message}", 0);
                return;
            }
        }

        //OBENGO EL ID DE LA NUEVA RESPUESTA POR ID LOCAL
        private int Getidrespuesta(string idlocal)
        {
            try
            {
                int retorno = 0;

                string c = $"SELECT ID_Registro FROM DISCUSIONRPTAM WHERE ID_Local = '{idlocal}'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows) { retorno = (int)r["ID_Registro"]; }

                return retorno;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //GUARDO LAS RESPUESTAS OS
        private void GuardaRespuestasos(List<DiscusionRespuestasOS> oslst, int idrespuesta)
        {
            try
            {
                if (idrespuesta <= 0) { return; }

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                foreach (DiscusionRespuestasOS ex in oslst.Where(w => !w._BorraRegistro))
                {

                    //INSERTAR
                    if (ex.IDRegistro <= 0)
                    {
                        campos.Clear();
                        campos.Add("ID_Respuesta");
                        campos.Add("Observacion");                        
                        campos.Add("ID_UsuNew");
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();
                        parametros.Add(idrespuesta);
                        parametros.Add(ex.Observacion);                        
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "I", "DISCUSIONRPTPOS");
                    }
                    else //MODIFICAR                    
                    {
                        campos.Clear();                        
                        campos.Add("Observacion");                        
                        campos.Add("ID_UsuModif");
                        campos.Add("TimeModif");

                        parametros.Clear();                        
                        parametros.Add(ex.Observacion);                        
                        parametros.Add(glob.GetIdUsuariolog());
                        parametros.Add(DateTime.Now);

                        func.AccionBD(campos, parametros, "U", "DISCUSIONRPTPOS", ex.IDRegistro);
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar las respuestas os.\n {e.Message}", 0);
                return;
            }
        }

        //BORRO TODOS LOS REGISTROS MARCADOS DE RESPUESTA
        private void BorraRespuestas()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                //RECORRO LAS RESPUESTAS 
                foreach (DiscusionRespuestasAM a in discusionenc.Respuestas)
                {
                    //BORRO LAS RESPUES MARCADAS DE OS O TODAS SI ESTA MARCADO SU ENCABEZADO
                    foreach (DiscusionRespuestasOS o in a.RespuestaOs)
                    {
                        if ((o._BorraRegistro || a._BorraRegistro) && o.IDRegistro > 0)
                        {
                            func.AccionBD(campos, parametros, "D", "DISCUSIONRPTPOS", o.IDRegistro);
                        }
                    }

                    //BORRO LAS RESPUESTAS AM (PADRE)
                    if (a._BorraRegistro && a.IDRegistro > 0) { func.AccionBD(campos, parametros, "D", "DISCUSIONRPTAM", a.IDRegistro); }

                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al borrar las respuestas.\n{e.Message}", 0);
                return;
            }
        }

        //VALIDO PRACTICAS (QUE LA FUNCION Y EL ID COINCIDAN CON EL ID DE PRACITCA GUARDADA)
        private void ValidaPractica(List<Practicas.Practicas> practicas)
        {
            try
            {
                //POR CADA PRACTICA EN EL DETALLE
                foreach (DiscusionDetalle dd in discusionenc.Detalles)
                {
                    //RECORRO TODOS LOS DETALLES Y DETERMINO CUAL NO COINCIDE ID DE PRACTICA CON ID FUNCION (EXCLUYENDO UNIDADES DE GALENO)
                    if (practicas.Where(w => w.ID_Registro == dd.IDPractAm && w.ID_Funcion != dd.IDFuncion
                                              && !Galenosygastosex.Contains(dd.CodigoPractica)).Count() > 0)
                    {
                        //ASIGNO EL ID QUE CORRESPONDE SEGUN CÓDIGO DE PRÁCTICA Y ID FUNCION
                        dd.IDPractAm = practicas.Where(w => w.Codigo == dd.CodigoPractica && w.ID_Funcion == dd.IDFuncion).Select(s => s.ID_Registro).FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al actualizar el ID de la práctica.", 1);
                return;
            }
        }

        //INSERTO TODAS LAS PRACTICAS CUYA COMBINACION NO EXISTA
        private void Insertarnewpracticas()
        {
            try
            {
                Practicasclass p = new Practicasclass();                
                p.GetPracticaslst();                               

                //OBTENGO LISTA DE PRACTICAS ACTUALES
                List<Practicas.Practicas> pract = p.practicaslst;

                //VALIDA PRACTICAS (CODIGOS Y FUNCIONES CORRECTAS)
                ValidaPractica(pract);

                ArrayList campos = new ArrayList();
                campos.Add("Codigo");
                campos.Add("Descripcion");
                campos.Add("ID_Funcion");
                campos.Add("ID_Grupo");

                //RECORRO LOS DETALLES CUYOS ID DE PRACTICA ESTAN EN CERO
                foreach (var det in discusionenc.Detalles.Where(w => w.IDPractAm <= 0))
                {

                    //COINCIDE CODIGO Y FUNCION?
                    int idpractica = p.practicaslst.Where(w => w.Codigo == det.CodigoPractica &&
                                                            w.ID_Funcion == det.IDFuncion).Select(s => s.ID_Registro).DefaultIfEmpty(0).First();

                    if (idpractica <= 0)
                    {
                        if (det.IDGrupo > 0 && (det.IDArancel > 0 || det.IDFuncion > 0 || det.IDGasto > 0))
                        {
                            ArrayList parametros = new ArrayList();

                            parametros.Add(det.CodigoPractica.Trim());
                            parametros.Add(det.DescripcionPractica.Trim());
                            parametros.Add(det.IDFuncion);
                            parametros.Add(det.IDGrupo);

                            func.AccionBD(campos, parametros, "I", "PRACTAM");

                            det.IDPractAm = Getidpractica(det.IDFuncion, det.CodigoPractica, det.IDGrupo);
                        }

                    }
                    else { det.IDPractAm = idpractica; }

                }

                //RECORRO LOS DETALLES CUYOS ID DE PRACTICA NO ESTAN EN CERO, Y VALIDO SI LA FUNCION ES CORRECTA
                foreach (var det in discusionenc.Detalles.Where(w => w.IDPractAm > 0))
                {

                    //COINCIDE CODIGO Y FUNCION?
                    int idpractica = p.practicaslst.Where(w => w.Codigo == det.CodigoPractica &&
                                                            w.ID_Funcion == det.IDFuncion).Select(s => s.ID_Registro).DefaultIfEmpty(0).First();

                    if (idpractica <= 0)
                    {
                        if (det.IDGrupo > 0 && (det.IDArancel > 0 || det.IDFuncion > 0 || det.IDGasto > 0))
                        {
                            ArrayList parametros = new ArrayList();

                            parametros.Add(det.CodigoPractica.Trim());
                            parametros.Add(det.DescripcionPractica.Trim());
                            parametros.Add(det.IDFuncion);
                            parametros.Add(det.IDGrupo);

                            func.AccionBD(campos, parametros, "I", "PRACTAM");

                            det.IDPractAm = Getidpractica(det.IDFuncion, det.CodigoPractica, det.IDGrupo);
                        }

                    }
                  

                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al insertar las nuevas practicas detectadas.\n {e.Message}", 0);
                return;
            }
        }

        //RECUPERO EL ID DE PRACTICA POR COMBINACION
        private int Getidpractica(int idfuncion, string codigo, int idgrupo)
        {

            try
            {
                int retorno = 0;

                string c = $"SELECT ID_Registro FROM PRACTAM WHERE ID_Funcion = {idfuncion} AND ID_Grupo = {idgrupo} AND Codigo = '{codigo}'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows) { retorno = (int)r["ID_Registro"]; }
                return retorno;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //BORRO LOS REGISTROS DE LOS DETALLES
        private void Borrardetalles()
        {
            try
            {
                //SELECCIOO TODOS LOS DETALLES ACTUALES EN BD Y ARMO UNA LISTA CON ELLOS
                string c = "SELECT ID_Registro FROM DISCUSIONDET WHERE ID_Encabezado = " + discusionenc.IDRegistro;

                List<long> list = new List<long>();

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    list.Add((long)r["ID_Registro"]);
                }

                //CREO UNA LISTA CON TODOS LOS ITEMS DE BD QUE NO ESTAN EN LA LISTA PROCESADA ACTUALMENTE (PERO QUE HAYAN SIDO GUARDADOS PREVIAMENTE
                var eliminar = list.Where(w => !discusionenc.Detalles.Any(f => f.IDRegistro > 0 && f.IDRegistro == Convert.ToInt64(w))).ToList();

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                //SI HAY REGISTROS A ELIMINAR
                if (eliminar.Count > 0)
                {
                    foreach (long d in eliminar)
                    {
                        func.AccionBD(campos, parametros, "D", "DISCUSIONDET", d);
                    }

                    discusioncls.DeleteIdvAmdgosis(eliminar);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al borrar las practicas marcadas.\n {e.Message}",0);
                return;
            }
        }
        
        #endregion

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {            
            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
            pnlBottom.Height = 72;
            colGrupoPractica.SortMode = PivotSortMode.Custom;
            colDescripcionPractica.SortMode = PivotSortMode.Custom;


            pvControl.OptionsView.ShowDataHeaders = false;
            pvControl.OptionsView.ShowFilterHeaders = false;
            
            ScreenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScreenManager.SplashFormLocation = LocationSplash;
           
            CargaCombos(0);
            pvControl.Visible = false;
            _canedit = func.DevuelvePermiso("NegEdit");
        }

        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            OrdenSegundoplano = 0;
            pvControl.BeginUpdate();
            btnAplicar.Enabled = false;
            if (!ScreenManager.IsSplashFormVisible)
            {
                ScreenManager.ShowWaitForm();                
            }

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //CARGAR REGISTROS
        private void CargarRegistros()
        {
            try
            {
                //EN CASO DE QUE SEA UN RELOAD (CONTINUACION DE EDICION)
                if (Recarga)
                {                    
                    int id = discusionenc.IDRegistro;

                    if (id > 0)
                    {
                        discusioncls.ListarRegistros();
                        discusionenc = discusioncls.encabezadoslst.Where(r => r.IDRegistro == id).DefaultIfEmpty(new DiscusionEncabezado()).First().Clone();                        
                    }

                    Recarga = false;
                }

                if (discusionenc.IDRegistro > 0)
                {                    
                    CalculaDiferencias();
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al cargar los registros.\n {e.Message}", 0);
                return;
            }
        }
        
        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            pvControl.DataSource = discusionenc.Detalles;
            pvControl.EndUpdate();
                        
            if (discusionenc.IDRegistro > 0)
            {
                datFecha.EditValue = discusionenc.FechaInicio;
                datImpacto.EditValue = discusionenc.FechaImpacto;
                cmbPrestataria.EditValue = discusionenc.IDGrupoOs;
                cmbValorizacion.EditValue = discusionenc.IDAranvaloriza;
                memoPresta.Text = discusionenc.PrestatariaConjunto;

                datFecha.Enabled = false;
                if (discusionenc.Estado > 0) { datImpacto.Enabled = false; }                
                cmbPrestataria.Enabled = false;
                cmbValorizacion.Enabled = false;
            }

            btnAplicar.Enabled = true;
            btnAplicar.Refresh();
            pvControl.RefreshData();            
            pvControl.Visible = true;

            if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
            Visibilidadcolumnas();
        }

        //CARGA DE COMBOS
        private void CargaCombos(short cmb)
        {
            try
            {
                string consulta = "";

                //AGRUPADORES DE OBRAS
                if (cmb == 0 || cmb == 1)
                {
                    consulta = "SELECT PG.ID_Registro, PG.Codigo, PT.Codigo AS Grupo, CONCAT(PG.Codigo, ' - ', PT.Codigo) AS Display," +
                               " PT.Descripcion," +
                               " ISNULL(STUFF((SELECT DISTINCT ',' + CONCAT('(', PR.Nombre, ' ', PR.Cuit, ' | '," +
                               " ISNULL(STUFF((SELECT ' ' + PD.Codigo FROM PRESTDETALLES PD WHERE PD.ID_Prestataria = PR.ID_Registro" +
                                                            " FOR XML PATH('')), 1, LEN(','), ''), ''), ')')" +
                                                            " FROM PRESTDETALLES PD" +
                                                            " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                                                            " WHERE PD.ID_Agrupador = PG.ID_Registro" +
                                                            " FOR XML PATH('')), 1, LEN(','), ''), '') AS PrestatariasConjunto" +
                               " FROM PRESTGRPVAL PG" +                               
                               " LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = PG.ID_PrestaTipo)" +
                               " ORDER BY PG.Codigo ASC";

                    cmbPrestataria.Properties.DataSource = func.getColecciondatos(consulta, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                }

                //VALORIZACIO
                if (cmb == 0 || cmb == 2)
                {
                    consulta = "SELECT ID_Registro, FORMAT(Fecha, 'yyyy-MM-dd') AS Fecha, Observaciones" +
                               " FROM ARANVALORIZAENC" +
                               " WHERE Estado = 1" +
                               " ORDER BY Fecha DESC";

                    cmbValorizacion.Properties.DataSource = func.getColecciondatos(consulta, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }              
      
        //DEFINICION DE ACCIONES A PARTIR DE OPCIONES
        private void ParametrizaCambios()
        {
            try
            {

                DateTime date = DateTime.Now;
                
                //INICIO PARAMETROS
                Usr_Parametros parametros = new Usr_Parametros(discusionenc.Detalles.GroupBy(g => g.FechaNeg.ToString("dd/MM/yyyy H:mm:ss")).Select(s => s.First().FechaNeg).ToList(),
                    discusionenc.Detalles.GroupBy(g => new { g.GrupoPractica }).Select(s => s.First().GrupoPractica).ToList());

                discusionenc.Detalles.GroupBy(g => g.FechaNeg.ToString("dd/MM/yyyy H:mm:ss")).Select(s => 
                new { date = DateTime.ParseExact(s.Key, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None) }).ToList();

                if (XtraDialog.Show(parametros, "Parámetros de edición", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                //SI HAY FECHA
                if (parametros.FechaOperacion == "") { ctrls.MensajeInfo("No se puede realizar la operación sin fecha.", 1); return; }

                if (parametros.FechaOperacion != "Nueva Fecha") { date = Convert.ToDateTime(parametros.FechaOperacion); }

                string palabra = parametros.Tipovalor == 0 ? "Obra Social" : "Amdgo";

                //SI ES UNA GENERACIN DE DATOS
                if (parametros.Generacion)
                {

                    //SI LA FECHA DE NEGOCIACION ES DISTINTA NUEV
                    if (parametros.FechaOperacion != "Nueva Fecha")
                    {
                        if (discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss")).Count() > 0)
                        //&& w.TipoValor == parametros.Tipovalor).Count() > 0)
                        {
                            ctrls.MensajeInfo($"Ya existe una valorizacion en {date.ToString("dd/MM/yyyy H:mm:ss")}.", 1);
                            return;
                        }

                        if (ctrls.MensajePregunta($"¿Generar una nueva valorización para {palabra}\n en {date.ToString("dd/MM/yyyy H:mm:ss")}" +
                            $" con un porcentaje de {parametros.Porcentaje}?") == DialogResult.Yes)
                        {
                            pvControl.BeginUpdate();

                            CreaNuevalista(date, parametros.Tipovalor, parametros.Porcentaje,
                                discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss")
                                                            && w.TipoValor == parametros.Tipovalor).ToList());

                            pvControl.EndUpdate();
                            pvControl.RefreshData();
                        }
                        else { return; }
                    }
                    else
                    {
                        if (discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss")
                        && w.TipoValor == parametros.Tipovalor).Count() > 0)
                        {
                            ctrls.MensajeInfo($"Ya existe una valorizacion para {palabra} en {date.ToString("dd-MMMM-yyyy")}.", 1);
                            return;
                        }

                        if (ctrls.MensajePregunta($"¿Generar una nueva valorización para {palabra}\n en {date.ToString("dd/MM/yyyy H:mm:ss")}" +
                            $" con un porcentaje de {parametros.Porcentaje}?") == DialogResult.Yes)
                        {
                            pvControl.BeginUpdate();

                            CreaNuevalista(date, parametros.Tipovalor, porcentaje: parametros.Porcentaje, frmlastvaloriza: true);

                            pvControl.EndUpdate();
                            pvControl.RefreshData();
                        }
                        else { return; }
                    }
                }

                //COPIAR
                if (parametros.Copiar)
                {
                    string palabra2 = parametros.CopiaNewTipo == 0 ? "Obra Social" : "Amdgo";                    
                    DateTime locdate =  DateTime.Now;
                    if (parametros.FechaOperacion != "Nueva Fecha")
                    {

                        if (discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == locdate.ToString("dd/MM/yyyy H:mm:ss")).Count() > 0)
                                                        //&& w.TipoValor == parametros.CopiaNewTipo).Count() > 0)
                        {
                            ctrls.MensajeInfo($"Ya existe una valorizacion en {locdate.ToString("dd/MM/yyyy H:mm:ss")}.", 1);
                            return;
                        }

                        if (ctrls.MensajePregunta($"¿Copiar la valorización para {palabra2} con un porcentaje de {parametros.Porcentaje}?") == DialogResult.Yes)
                        {
                            pvControl.BeginUpdate();



                            CreaNuevalista(locdate, parametros.CopiaNewTipo, (decimal)parametros.Porcentaje,
                                discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss")
                                                            && w.TipoValor == parametros.Tipovalor).ToList());

                            pvControl.EndUpdate();
                            pvControl.RefreshData();
                        }
                        else { return; }
                    }
                }

                //SI ES UNA IMPORTACION DE DATOS
                if (parametros.Importacion)
                {
                    Frm_AranImportxls fr = new Frm_AranImportxls();
                    fr.OrigenValoriza = false;
                    FechaImpacto = date;
                    TipoValordetalle = parametros.Tipovalor;

                    if (fr.ShowDialog() == DialogResult.OK)
                    {
                        excelimport = fr.excelimport;

                        if (discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss")
                        && w.TipoValor == parametros.Tipovalor).Count() > 0)
                        {
                            if (ctrls.MensajePregunta($"Ya existe una valorizacion para {palabra} en {date.ToString("dd-MMMM-yyyy")}.\n" +
                                $"¿Importar de todas formas?") == DialogResult.Yes)
                            {
                                IImport(fr.Archivo);

                            }
                            else { return; }
                                                        
                        }
                        else
                        {
                            if (ctrls.MensajePregunta($"¿Aplicar los valores para {palabra} en {date.ToString("dd/MM/yyyy")}?") == DialogResult.Yes)
                            {
                                IImport(fr.Archivo);
                            }
                            else { return; }

                        }

                    }
                }

                //SI ES UNA MODIFICACION
                if (parametros.Modificacion)
                {
                    Frm_DiscusionDetpopup det = new Frm_DiscusionDetpopup();
                    det.Es_Popup = true;


                    //LISTA POR FECHA, GRUPO y TIPO
                    var detallesfiltrados = discusiondetalle.Clone(discusionenc.Detalles.Where(s => 
                                                                        s.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss") 
                                                                        && s.TipoValor == parametros.Tipovalor
                                                                        && parametros.Grupossel.Contains(s.GrupoPractica)).ToList());
                    
                    if (detallesfiltrados.Count <= 0) { return; }
                    
                    det.discusiondet = detallesfiltrados;
                    det.practtotales = discusiondetalle.Clone(discusionenc.Detalles.Where(s => s.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == date.ToString("dd/MM/yyyy H:mm:ss")
                                                                                            && s.TipoValor == parametros.Tipovalor).ToList());

                    if (det.ShowDialog(this) == DialogResult.OK)
                    {
                        if (ctrls.MensajePregunta("¿Está seguro de aplicar las modificaciones?") == DialogResult.Yes)
                        {
                            EjecutaModificaion(det.discusiondet, date, parametros.Tipovalor, parametros.Grupossel);
                        }
                        else { det.Dispose();  return; }
                    }

                    det.Dispose();
                    
                }
                               
                //VALORIZACION
                if (parametros.Valorizacion)
                {
                    if (parametros.Porcentaje != 0)
                    {
                        EjecutaValorizacion(date, parametros.Tipovalor, parametros.Porcentaje, parametros.Grupossel);
                    }

                }

                if (parametros.Generacion || parametros.Copiar || parametros.Valorizacion || parametros.Modificacion)
                {
                    CalculaDiferencias();
                }

                //EXPORTACION
                if (parametros.Exportacion)
                {
                    if (parametros.FechaOperacion == "Nueva Fecha" || 
                        discusionenc.Detalles.Count == discusionenc.Detalles.Where(w => w.IDRegistro <= 0).Count()
                        || discusionenc.FechaImpacto == DateTime.MinValue)
                    {
                        return;
                    }

                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK)
                        {                            
                            EjecutaExportacion(parametros.Tipovalor, date, fbd.SelectedPath);
                        }
                    }

                }

                //NORMALIZACION
                //SI ES UNA MODIFICACION
                if (parametros.Normalizacion)
                {
                    //LISTA POR FECHA, GRUPO y TIPO
                    var detallesfiltrados = discusiondetalle.Clone(discusionenc.Detalles.
                                                                    Where(s => parametros.Grupossel.Contains(s.GrupoPractica)).ToList());

                    if (detallesfiltrados.Count <= 0) { return; }

                    if (ctrls.MensajePregunta("¿Está seguro de aplicar las modificaciones?") == DialogResult.Yes)
                    {
                        EjecutaNormalizacion(detallesfiltrados, parametros.Grupossel);
                    }
                    
                    return;
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al modificar los valores.\n {e.Message}", 0);
                return;
            }
        }
        
        private void IImport(string archivo)
        {
            OrdenSegundoplano = 1;
            pvControl.BeginUpdate();

            if (!ScreenManager.IsSplashFormVisible) { ScreenManager.ShowWaitForm(); }
            

            //Ubicacion                
            string path = Application.StartupPath + @"\ImpoAran";
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            string archpath = Application.StartupPath + @"\ImpoAran\" + FechaImpacto.ToString("dd-MM-yyyy H-mm-ss") + " " + Path.GetFileName(archivo);

            if (File.Exists(archpath))
            {
                File.Copy(archivo, Application.StartupPath + @"\ImpoAran\" + 
                                   FechaImpacto.ToString("dd-MM-yyyy H-mm-ss") + " @ " + DateTime.Now.ToString("dd-MM-yyyy H-mm-ss") + " " +
                                   Path.GetFileName(archivo));
            }
            else
            {
                File.Copy(archivo, archpath);
            }
            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }
                        
            bgwRegistros.RunWorkerAsync();
        }

        private void FImport()
        {
            pvControl.EndUpdate();
            pvControl.RefreshData();
            if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
            
        }

        //ACTUALIZO LOS VALORES DESDE UNA IMPORTACION
        private void Actualizavalimportado()
        {
            try
            {
                                                
                //SI LA FECHA DE IMPORTACION EXISTE ACTUALIZO, DE LO CONTRARIO AGREGO NUEVO
                //MODIFICACION
                if (discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == FechaImpacto.ToString("dd/MM/yyyy H:mm:ss") && w.TipoValor == TipoValordetalle).Count() <= 0)
                {
                    //CREO UNA NUEVA LISTA DE DETALLES
                    //SI HAY REGISTROS, USO EL MAYOR
                    CreaNuevalista(FechaImpacto, TipoValordetalle);
                }
                
                EjecutaImportacion();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actulizar los valores importados. \n {e.Message}", 0);
                return;
            }
        }

        //HAGO LA ACTUALIZACION POR IMPORTACION
        private void EjecutaImportacion()
        {
            try
            {
                //DETERMINO CUALES PRACTICAS YA LAS TENEMOS CONTEPLADAS
                var listaexistente = (from a in excelimport
                                      join b in discusionenc.Detalles on new { cod = (string)a.CodigoAM, fun = (int)a.IDFuncion } 
                                                                      equals new { cod = (string)b.CodigoPractica, fun = (int)b.IDFuncion }
                                      where b.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == FechaImpacto.ToString("dd/MM/yyyy H:mm:ss") && b.TipoValor == TipoValordetalle
                                      select new { a.CodigoAM, a.NewObservacion, a.Valor, a.IDFuncion, a.Descripcion, a.CodigoGasto, a.CodigoOs }).ToList();

                foreach (DiscusionDetalle v in discusionenc.Detalles.Where(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == FechaImpacto.ToString("dd/MM/yyyy H:mm:ss")
                                                                            && w.TipoValor == TipoValordetalle))
                {
                    //SI SE ENCUENTRA EL CODIGO                        
                    string c = listaexistente.Where(w => w.CodigoAM == v.CodigoPractica && w.IDFuncion == v.IDFuncion).Select(s => s.CodigoOs).DefaultIfEmpty("").First().Trim();
                    if (c != "")
                    {
                        v.CodigoOs = c;
                    }
                    else { v.CodigoOs = v.CodigoPractica; }

                    v.Obsdetalle = listaexistente.Where(w => w.CodigoAM == v.CodigoPractica && w.IDFuncion == v.IDFuncion).Select(s => s.NewObservacion).DefaultIfEmpty("").First();
                    v.Valor = listaexistente.Where(w => w.CodigoAM == v.CodigoPractica && w.IDFuncion == v.IDFuncion).Select(s => s.Valor).DefaultIfEmpty(0).First();                        

                    v.CodigoGasto = listaexistente.Where(w => w.CodigoAM == v.CodigoPractica && w.IDFuncion == v.IDFuncion).Select(s => s.CodigoGasto).DefaultIfEmpty("").First();
                    if (v.DescripcionPractica.Trim() == "")
                    { v.DescripcionPractica = listaexistente.Where(w => w.CodigoAM == v.CodigoPractica && w.IDFuncion == v.IDFuncion).Select(s => s.Descripcion).DefaultIfEmpty("").First(); }
                    

                }

                //DETERMINO CUALES PRACTICAS NO ESTAN CARGADAS
                var listanoexiste = excelimport.Where(w => !discusionenc.Detalles.Any(b => b.CodigoPractica == w.CodigoAM && b.IDFuncion == w.IDFuncion)).ToList();

                //VALIDO TODAS LAS PRACTICAS QUE NO EXISTEN, LAS AGREGO EN LA TABLA DE PRACTICAS (SI NO EXISTEN) LUEGO A LA VLORIZACION
                if (listanoexiste.Count > 0)
                {
                    Insertnewdetalles(listanoexiste, TipoValordetalle);
                }

                //QUITO TODAS LAS VALOR CERO QUE NO SON PP PERO DEJO LOS GASTOS Y GALENOS                                
                discusionenc.Detalles.RemoveAll(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == FechaImpacto.ToString("dd/MM/yyyy H:mm:ss")
                                                                            && w.TipoValor == TipoValordetalle && w.Valor == 0 && w.IDFuncion != 4
                                                                            && !Galenosygastosex.Contains(w.CodigoPractica));

                CalculaDiferencias();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al ejecutar la importación.\n {e.Message}", 0);
                return;
            }
        }

        //INSERTO NUEVAS PRACTICAS A LA DISCUSION
        private void Insertnewdetalles(List<EstructuraExcel> estructuraExcel, byte tipovalor)
        {
            try
            {
                //OBTENGO LAS PRACTICAS
                Practicasclass practicas = new Practicasclass();
                practicas.GetPracticaslst();
                practicas.GetFuncioneslst();

                //FILTRO POR ACTIVAS
                List<Practicas.Practicas> practicaslst = practicas.practicaslst.Where(w => w.Estado == true).ToList();
                List<FuncionesAran> funcioneslst = practicas.funcioneslst.Where(w => w.Letra != "").ToList();
                
                //SALGO SI NO SE OBTIENE NINGUNA
                if (practicaslst.Count <= 0) { return; }
                
                foreach (var e in estructuraExcel)
                {

                    if (e.CodigoAM == "") { continue; }
                    discusionenc.Detalles.Add(new DiscusionDetalle
                    {
                        FechaNeg = FechaImpacto,
                        CodigoOs = e.CodigoOs,
                        CodigoPractica = e.CodigoAM,
                        DescripcionPractica = e.Descripcion,
                        IDFuncion = e.IDFuncion,
                        CodigoFuncion = funcioneslst.Where(w=> w.ID_Registro == e.IDFuncion).Select(s => s.Codigo).DefaultIfEmpty("").First(),
                        DescripcionFuncion = funcioneslst.Where(w => w.ID_Registro == e.IDFuncion).Select(s => s.Descripcion).DefaultIfEmpty("").First(),
                        LetraFuncion = funcioneslst.Where(w => w.ID_Registro == e.IDFuncion).Select(s => s.Letra).DefaultIfEmpty("").First(),
                        Valor = e.Valor,
                        TipoValor = tipovalor,
                        Obsdetalle = e.NewObservacion,
                        IDGrupo = e.IDGrupo,
                        GrupoOrden = e.GrupoOrden,
                        GrupoObservacion = e.GrupoObservacion,
                        GrupoPractica = e.GrupoPractica,
                        CodigoGasto = e.CodigoGasto

                    });

                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al insertar las nuevas practicas.\n {e.Message}", 0);
                return;
            }
        }

        //CREO NUEVA LISTA DE DETALLES
        private void CreaNuevalista(object fechanew = null, byte tipovalor = 0, object porcentaje = null, List<DiscusionDetalle> dorg = null, bool frmlastvaloriza = false)
        {
            try
            {

                List<DiscusionDetalle> d = new List<DiscusionDetalle>();

                if (dorg != null && dorg.Count > 0)
                {
                    DiscusionDetalle disc = new DiscusionDetalle();
                    d = disc.Clone(dorg);

                    foreach (DiscusionDetalle f in d)
                    {
                        f.TipoValor = tipovalor;
                        f.FechaNeg = Convert.ToDateTime(fechanew);

                        f.Valor = porcentaje != null ? f.Valor + (f.Valor * ((decimal)porcentaje / 100)) : 0;

                        //REDONDEO O NO
                        f.Valor = Galenosygastosex.Contains(f.CodigoPractica) ? decimal.Round(f.Valor, 2) : decimal.Round(f.Valor, MidpointRounding.AwayFromZero);                        
                        f.Aplicado = 0;
                    }

                    discusionenc.Detalles.AddRange(d);

                    //QUITO TODAS LAS VALOR CERO QUE NO SON PP
                    discusionenc.Detalles.RemoveAll(w => w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == Convert.ToDateTime(fechanew).ToString("dd/MM/yyyy H:mm:ss")
                                                                                && w.TipoValor == tipovalor && w.Valor == 0 && w.IDFuncion != 4);

                    return;
                }

                if (discusionenc.TipoValorizacion == "" || discusionenc.IDAranvaloriza <= 0 || discusionenc.IDGrupoOs <= 0) { return; }

                if (discusionenc.Detalles.Count > 0 && !frmlastvaloriza)
                {
                    DiscusionDetalle disc = new DiscusionDetalle();                    
                    d = disc.Clone(discusionenc.Detalles.Where(w => w.FechaNeg == discusionenc.Detalles.Max(m => m.FechaNeg)).ToList());                    

                }
                else
                {
                    d = discusioncls.Agregardetalles(discusionenc.TipoValorizacion, discusionenc.IDGrupoOs, discusionenc.IDAranvaloriza, tipovalor);
                }

                

                if (fechanew != null)
                {
                    foreach (DiscusionDetalle det in d)
                    {
                        det.IDRegistro = 0;
                        det.TipoValor = tipovalor;
                        det.Aplicado = 0;
                        det.FechaNeg = Convert.ToDateTime(fechanew);
                        det.Valor = porcentaje != null ? det.Valor + (det.Valor * ((decimal)porcentaje / 100)) : det.Valor;
                        //REDONDEO O NO
                        det.Valor = Galenosygastosex.Contains(det.CodigoPractica) ? decimal.Round(det.Valor, 2) : decimal.Round(det.Valor, MidpointRounding.AwayFromZero);
                    }
                }

                discusionenc.Detalles.AddRange(d);
                
            }
            catch (Exception e)
            {

                ctrls.MensajeInfo($"Ocurrió un error al crear la nueva lista de detalles. \n {e.Message}", 0);
                return;
            }
        }
            
        //VALORIZACION
        private void EjecutaValorizacion(DateTime fecha, byte tipo, decimal porcentaje, List<string> grupos)
        {
            try
            {
                pvControl.BeginUpdate();

                foreach (var r in discusionenc.Detalles.Where(s => s.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == fecha.ToString("dd/MM/yyyy H:mm:ss") && s.TipoValor == tipo && grupos.Contains(s.GrupoPractica)))
                {
                    r.Valor = r.Valor * (porcentaje / 100) + r.Valor;
                    r.Valor = Galenosygastosex.Contains(r.CodigoPractica) ? decimal.Round(r.Valor, 2) : decimal.Round(r.Valor, MidpointRounding.AwayFromZero);
                }
            
                pvControl.EndUpdate();
                pvControl.RefreshData();


            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al modificar los valores.\n {e.Message}", 0);
                return;
            }
        }

        //MODIFICACION
        private void EjecutaModificaion(List<DiscusionDetalle> d, DateTime fecha, byte tipo, List<string> grupos)
        {
            try
            {
                pvControl.BeginUpdate();

                //RECORRO LAS NUEVAS PRACTICAS (VALIDACIONES CORRESPONDIENTES)
                foreach (DiscusionDetalle det in d.Where(w => w._NuevoRegistro))
                {
                    //SI NO EXISTE EN LOS DETALLES, LA AGREGO
                    if (discusionenc.Detalles.Where(w => w.IDPractAm == det.IDPractAm && w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss")
                              == fecha.ToString("dd/MM/yyyy H:mm:ss") && w.TipoValor == tipo).Count() <= 0)
                    {
                        if (det.CodigoOs == "") { det.CodigoOs = det.CodigoPractica; }
                        if (det.Obsdetalle == "") { det.Obsdetalle = discusionenc.Detalles.Where(w => w.IDPractAm == det.IDPractAm).
                                Select(s => s.Obsdetalle).DefaultIfEmpty("").First(); }
                        discusionenc.Detalles.Add(det);
                    }
                }

                //LUEGO RECORRO EL RESTO Y MODIFICO
                foreach (var r in discusionenc.Detalles.Where(s => s.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == fecha.ToString("dd/MM/yyyy H:mm:ss") && s.TipoValor == tipo && grupos.Contains(s.GrupoPractica)))
                {                                        
                    //CODIGO OS O AMDGO (POR DEFECTO)
                    string codos = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.CodigoOs).DefaultIfEmpty("").First();
                    if (codos.Trim() == "") { r.CodigoOs = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.CodigoPractica).DefaultIfEmpty("").First(); }
                    else { r.CodigoOs = codos; }

                    //ID FUNCION
                    r.IDFuncion = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.IDFuncion).DefaultIfEmpty(0).First();
                    //DETALLES
                    r.Obsdetalle = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.Obsdetalle).DefaultIfEmpty("").First();
                    //VALOR
                    r.Valor = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.Valor).DefaultIfEmpty(0).First();
                    //COSEGURO
                    r.ValorCoseguro = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.ValorCoseguro).DefaultIfEmpty(0).First();
                    //COPAGO
                    r.ValorCopago = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.ValorCopago).DefaultIfEmpty(0).First();
                    //CODIGO FUNCION
                    r.CodigoFuncion = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.CodigoFuncion).DefaultIfEmpty("").First();
                    //DESCRIPCION FUNCION
                    r.DescripcionFuncion = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.DescripcionFuncion).DefaultIfEmpty("").First();
                    //LETRA
                    r.LetraFuncion = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.LetraFuncion).DefaultIfEmpty("").First();
                    //CODIGO GASTO
                    r.CodigoGasto = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.CodigoGasto).DefaultIfEmpty("").First();
                    //GRUPO ID
                    r.IDGrupo = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.IDGrupo).DefaultIfEmpty(0).First();
                    r.GrupoPractica = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.GrupoPractica).DefaultIfEmpty("").First();
                    r.GrupoOrden = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s.GrupoOrden).DefaultIfEmpty(0).First();
                    //BORRADO DE REGISTRO
                    r._BorrarRegistro = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s._BorrarRegistro).DefaultIfEmpty(false).First();

                    //APLICACION DE OBS
                    short usa = d.Where(s => s.IDLocal == r.IDLocal).Select(s => s._UsaObservacion).First();
                    
                    if (usa == 1)
                    {
                        foreach (var i in discusionenc.Detalles.Where(s => s.FechaNeg < fecha && s.CodigoPractica == r.CodigoPractica))
                        {
                            i.Obsdetalle = r.Obsdetalle;
                        }
                    }
                    else if (usa == 2)
                    {
                        foreach (var i in discusionenc.Detalles.Where(s => s.FechaNeg > fecha && s.CodigoPractica == r.CodigoPractica))
                        {
                            i.Obsdetalle = r.Obsdetalle;
                        }
                    }
                    else if (usa == 3)
                    {
                        foreach (var i in discusionenc.Detalles.Where(s => s.CodigoPractica == r.CodigoPractica))
                        {
                            i.Obsdetalle = r.Obsdetalle;
                        }
                    }
                    else if (usa == 4)
                    {
                        foreach (var i in discusionenc.Detalles.Where(s => s.FechaNeg < fecha && s.CodigoPractica == r.CodigoPractica))
                        {
                            i.Obsdetalle = r.Obsdetalle;
                        }
                    }
                    else if (usa == 5)
                    {
                        foreach (var i in discusionenc.Detalles.Where(s => s.FechaNeg > fecha && s.CodigoPractica == r.CodigoPractica))
                        {
                            i.Obsdetalle = r.Obsdetalle;
                        }
                    }
                    else if (usa == 6)
                    {
                        foreach (var i in discusionenc.Detalles.Where(s => s.CodigoPractica == r.CodigoPractica))
                        {
                            i.Obsdetalle = r.Obsdetalle;
                        }
                    }
                }
                             
                //BORRO TODAS LAS MARCADAS PARA ELLO.
                discusionenc.Detalles.RemoveAll(r => r.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == fecha.ToString("dd/MM/yyyy H:mm:ss")
                                               && r.TipoValor == tipo && grupos.Contains(r.GrupoPractica)
                                               && r._BorrarRegistro);     

                pvControl.EndUpdate();
                pvControl.RefreshData();
              

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al modificar los valores.\n {e.Message}", 0);
                return;
            }
        }

        //NORMALIZACION
        private void EjecutaNormalizacion(List<DiscusionDetalle> d, List<string> grupos)
        {
            try
            {
                pvControl.BeginUpdate();

                //LUEGO RECORRO Y MODIFICO
                foreach (var r in discusionenc.Detalles.Where(s => grupos.Contains(s.GrupoPractica)))
                {
                    foreach (var i in discusionenc.Detalles.Where(s => s.CodigoPractica == r.CodigoPractica))
                    {
                        i.Obsdetalle = r.Obsdetalle;
                    }
                    
                }

                pvControl.EndUpdate();
                pvControl.RefreshData();


            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al normalizar las Observaciones.\n {e.Message}", 0);
                return;
            }
        }

        //EXPORTACION
        private void EjecutaExportacion(byte tipovalor, DateTime fechaex, string path)
        {
            try
            {
                //INICIO PARAMETROS
                Usr_Exportacion parametros = new Usr_Exportacion();
                if (XtraDialog.Show(parametros, "Parámetros de exportación", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                Xrpt_Memo report = new Xrpt_Memo();
                List<DiscusionEncabezado> li = new List<DiscusionEncabezado>();
               
                //ENCABEZADO A LISTA
                li.Add(discusionenc);

                //ACTUALIZO LA OBSERVACION DE LOS DETALLES SEGUN LO CARGADO EN DETALLES OBS
                foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.TipoValor == tipovalor && w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss")
                                                                             == fechaex.ToString("dd/MM/yyyy H:mm:ss")))
                {
                    d.GrupoObservacion = discusionenc.GruposObs.Where(w => w.IDGrupoPractica == d.IDGrupo).Select(s => s.Observacion).DefaultIfEmpty(string.Empty).First();
                }

                //ASIGNO A LA LISTA LOS VALORES EXACTOS A EXPORTAR
                li = li.Select(s => new DiscusionEncabezado
                    {
                        Prestataria = s.Prestataria,
                        CuitPrestataria = s.CuitPrestataria,
                        CodigoGupo = s.CodigoGupo,
                        DescripcionGrupo = s.DescripcionGrupo,
                        CodigosConjuntos = s.CodigosConjuntos,
                        FechaImpacto = discusionenc.FechaImpacto,
                        Extras = s.Extras,
                        Otros = s.Otros,
                        GruposObs = s.GruposObs,
                        PrestatariaConjunto = s.PrestatariaConjunto,
                        Detalles = s.Detalles.Where(w => w.TipoValor == tipovalor && w.FechaNeg.ToString("dd/MM/yyyy H:mm:ss") == fechaex.ToString("dd/MM/yyyy H:mm:ss")).ToList(),
                        Prestadoras = s.Prestadoras

                    }).ToList();


                report.DataSource = li.FirstOrDefault().Prestadoras;
                report.RequestParameters = false;
                foreach (var p in report.Parameters) { p.Visible = false; }
                report.Parameters["FechaNeg"].Value = discusionenc.FechaImpacto;
                report.Parameters["GrupoSeleccion"].Value = parametros.ImpresionAgrupadorCodigo;
                report.Parameters["HideCoseguro"].Value = parametros.VerCoseguro;
                report.Parameters["HideCopago"].Value = parametros.VerCopago;

                XRSubreport subReportControl = report.FindControl("subReportDiscusion", true) as XRSubreport;
                XtraReport subReport = subReportControl.ReportSource as XtraReport;
                subReport.DataSource = li;

               // report.DataSource = li;

                report.CreateDocument();

                DevExpress.XtraPrinting.XlsxExportOptions op = new DevExpress.XtraPrinting.XlsxExportOptions();
                op.ShowGridLines = true;
                op.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                op.SheetName = discusionenc.AbraviaGrupo + " " + discusionenc.CodigoGupo;

                report.ExportToXlsx(path + @"\" + discusionenc.AbraviaGrupo +" " + discusionenc.CodigoGupo + ".xlsx", op);
                FileInfo fi = new FileInfo(path + @"\" + discusionenc.AbraviaGrupo + " " + discusionenc.CodigoGupo + ".xlsx");

                if (fi.Exists)
                {
                    System.Diagnostics.Process.Start(path + @"\" + discusionenc.AbraviaGrupo + " " + discusionenc.CodigoGupo + ".xlsx");
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al exportar el archivo.\n {e.Message}", 0);
                return;
            }
        }

        //CALCULA PROCENTAJES E IMPORTES DE DIFERENCIA
        private void CalculaDiferencias()
        {
            try
            {
                pvControl.BeginUpdate();

                //DETERMINO LA MENOR FECHA, UNA VEZ
                DateTime mindate = discusionenc.Detalles.OrderBy(o => o.FechaNeg).Select(s => s.FechaNeg).DefaultIfEmpty(DateTime.MinValue).FirstOrDefault();

                //OBTENGO LOS MENORES VALORES DE LA MENOR FECHA                
                GetOldValues();
                
                //OBTENGO LAS UNIDADES DE LAS PRÁCTICAS
                Getpractnomencladas();
                
                //CALCULOS DE VALORES FECHA MENOR
                foreach (DiscusionDetalle d in discusionenc.Detalles)
                {                    
                    //ORDENANDO DE FORMA DESCENDIENTE, OBTENGO LA MAYOR FECHA, MENOR A LA PROCESADA ACTUALMENTE
                    DateTime fecha = discusionenc.Detalles.Where(w => w.FechaNeg < d.FechaNeg).OrderByDescending(o => o.FechaNeg)
                        .Select(s => s.FechaNeg).DefaultIfEmpty(DateTime.MinValue).FirstOrDefault();

                    d.ValorPactado = ValoresOldlst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault();

                    if (fecha > DateTime.MinValue)
                    {
                        d.MaxValMinFec = discusionenc.Detalles.Where(w => w.IDPractAm == d.IDPractAm && w.FechaNeg == fecha)
                                                              .Select(s => s.Valor).DefaultIfEmpty(0).First();
                    }

                    if (mindate > DateTime.MinValue && d.FechaNeg == mindate)
                    {
                        d.MaxValMinFec = ValoresOldlst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault();
                    }
                }

                //CALCULOS VALORES POR UNIDADES DE PRÁCTICA
                foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => PracticasNomencladas.Select(s => s.Codigo).Contains(w.CodigoPractica)))
                {

                    //OBTENGO LA PRACTICA NOMENCLADA
                    var practinom = PracticasNomencladas.Where(w => w.Codigo == d.CodigoPractica).First();

                    //SI HAY REGISTRO
                    if (practinom != null)
                    {

                        decimal costogaleno = 0;                        
                        decimal costogasto = 0;
                        decimal costoayudante = 0;
                        decimal total = 0;

                        //SI LA PRACTICA ES FUNCION HONORARIOS
                        if (d.LetraFuncion == "H" || d.LetraFuncion == "P")
                        {
                            costogaleno = discusionenc.Detalles.Where(w => w.FechaNeg == d.FechaNeg && w.IDArancel == practinom.IDGaleno
                                                                      && w.IDFuncion == 0 && w.IDGasto == 0)
                                                  .Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault() * practinom.UnidadGaleno;
                        }

                        if (d.LetraFuncion == "HA" || d.LetraFuncion == "P")
                        {
                            costoayudante = (discusionenc.Detalles.Where(w => w.FechaNeg == d.FechaNeg && w.IDArancel == practinom.IDGaleno && w.IDFuncion == 0)
                                                .Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault() * (practinom.CantidadAyudante * practinom.UnidadAyudante));
                        }

                        if (d.LetraFuncion == "G" || d.LetraFuncion == "P")
                        {                            
                            costogasto = discusionenc.Detalles.Where(w => w.FechaNeg == d.FechaNeg && w.IDGasto == practinom.IDGasto && w.IDFuncion == 0 && w.IDArancel == 0)
                                                  .Select(s => s.Valor).DefaultIfEmpty(0).FirstOrDefault() * practinom.UnidadGasto;
                        }

                        total = costogaleno + costogasto + costoayudante;

                        d.ValorNomenclado = decimal.Round(total, MidpointRounding.AwayFromZero);
                    }
                }

                pvControl.EndUpdate();
                pvControl.RefreshData();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al calcular las diferencias.\n {e.Message}", 0);
                return;
            }
        }

        //OBTENGO LOS VALORES ANTERIORES
        private void GetOldValues()
        {
            try
            {

                ValoresOldlst.Clear();

              
                string c = $"SELECT DD.ID_Practica, DD.Valor, DD.ID_Encabezado" +
                           $" FROM DISCUSIONDET DD" +
                           $" LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DD.ID_Encabezado)" +
                           $" WHERE DD.Aplicado = 2 AND DE.ID_GrupoValor = {discusionenc.IDGrupoOs} AND DE.FechaImpacto = (SELECT MAX(F.FechaImpacto)" +
                           $" FROM DISCUSIONENC F WHERE F.FechaImpacto < '{discusionenc.FechaImpacto.ToString("yyyy-MM-dd")}'" +
                           $" AND F.ID_GrupoValor = {discusionenc.IDGrupoOs})";                           

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    ValoresOldlst.Add(new DiscusionDetalle
                    {
                        IDPractAm = Convert.ToInt32(r["ID_Practica"]),
                        Valor = Convert.ToDecimal(r["Valor"])

                    });
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al consultar los valores anteriores.\n {e.Message}", 0);
                ValoresOldlst.Clear();
                return;
            }
        }

        private void Getpractnomencladas()
        {
            try
            {
                PracticasNomencladas.Clear();

                string c = $"SELECT Codigo, Descripcion, ID_Galeno, UnidadGaleno, ID_Gasto, UnidadGasto, AyudanteCantidad, AyudanteUnidad" +
                           $" FROM PRACTNOMECLADAS";                           
                
                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PracticasNomencladas.Add(new PracticasNomencladas
                    {
                        Codigo = r["Codigo"].ToString(),
                        Descripcion = r["Descripcion"].ToString(),
                        IDGaleno = Convert.ToInt32(r["ID_Galeno"]),
                        UnidadGaleno = Convert.ToDecimal(r["UnidadGaleno"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        UnidadGasto = Convert.ToDecimal(r["UnidadGasto"]),
                        CantidadAyudante = Convert.ToInt16(r["AyudanteCantidad"]),
                        UnidadAyudante = Convert.ToDecimal(r["AyudanteUnidad"]),
                    });
                }


            }
            catch (Exception )
            {
                PracticasNomencladas.Clear();
                return;
            }
        }


        //ORDEN CUSTOMIZADO DEL PIVOT
        private void pivotControl_CustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
        {
            if (e.Field.FieldName == "GrupoPractica")
            {
                if (e.SortLocation == PivotSortLocation.Pivot)
                {
                    object orderValue1 = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "GrupoOrden"),
                        orderValue2 = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "GrupoOrden");
                    e.Result = Comparer.Default.Compare(orderValue1, orderValue2);
                }
                else
                {
                    e.Result = Comparer.Default.Compare(e.Value1.ToString().Split(' ')[1], e.Value2.ToString().Split(' ')[1]);
                }
                e.Handled = true;
            }
            else if (e.Field.FieldName == "DescripcionPractica")
            {
                if (e.SortLocation == PivotSortLocation.Pivot)
                {
                    object orderValue1 = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "DescripcionPractica"),
                        orderValue2 = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "DescripcionPractica");
                    e.Result = Comparer.Default.Compare(orderValue1, orderValue2);
                }
                else
                {
                    e.Result = Comparer.Default.Compare(e.Value1.ToString().Split(' ')[1], e.Value2.ToString().Split(' ')[1]);
                }
                e.Handled = true;
            }
        }

        //PERMITIR MODIFICACION DE VALOR DEL PIVOT
        private void pivotControl_ChangeCellValue(EditValueChangedEventArgs e, object oldValue, object newValue, PivotGridField column)
        {
            PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

            if (e.DataField == colValor)
            {
                for (int i = 0; i < ds.RowCount; i++)
                {
                    if (newValue != null) { ds.SetValue(i, e.DataField, Convert.ToDecimal(newValue)); }
                    
                }
            }
            
           
        }

        //PERMITIR MODIFICACION DE VALOR DEL PIVOT
        private void PivotControl_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {           
            pivotControl_ChangeCellValue(e, e.Value, e.Editor.EditValue, e.DataField);
        }

        //CONSULTO QUE LA DISCUSION A DAR DE ALTA NO EXISTE
        private bool ExisteDiscusionalta()
        {
            try
            {
                bool retorno = false;

                string c = $"SELECT ID_Registro FROM DISCUSIONENC WHERE FechaImpacto = '{Convert.ToDateTime(datImpacto.Text)}'" +
                           $" AND ID_AranValoriza = {discusionenc.IDAranvaloriza} AND ID_GrupoValor = {discusionenc.IDGrupoOs}" +
                           $" AND ID_Registro <> {discusionenc.IDRegistro}";

                if (func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows.Count > 0)
                {
                    retorno = true;
                }

                return retorno;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al consultar las valorizaciones existentes.\n{e.Message}", 1);
                return true;
            }
        }

        //OBTENGO 
        private List<DiscusionDetalle> Getdetallesedit()
        {            

            try
            {

                /***************************************************************************
                 ***************    OBTENGO LA LISTA DE CELDAS SELECCIONADAS ***************
                 *************************************************************************** 
                 ***************************************************************************/
                List<DiscusionDetalle> detalleslst = new List<DiscusionDetalle>();

                PivotGridCells cells = pvControl.Cells;
                // Get the coordinates of the selected cells.
                Rectangle cellSelection = cells.Selection;                
                // Get the index of the bottommost selected row.
                int maxRow = cellSelection.Y + cellSelection.Height;
                // Get the index of the rightmost selected column.
                int maxColumn = cellSelection.X + cellSelection.Width;
                // Iterate through the selected cells.
                for (int rowIndex = cellSelection.Y; rowIndex <= maxRow; rowIndex++)
                {
                    for (int colIndex = cellSelection.X; colIndex <= maxColumn; colIndex++)
                    {
                        
                        if (cells.GetCellInfo(colIndex, rowIndex) != null && cells.GetCellInfo(colIndex, rowIndex).Selected)
                        {
                            PivotDrillDownDataSource ds = cells.GetCellInfo(colIndex, rowIndex).CreateDrillDownDataSource();

                            if (ds[0] != null)
                            {
                                detalleslst.Add((pvControl.DataSource as List<DiscusionDetalle>)[ds[0].ListSourceRowIndex]);
                            }                            
                            
                        }                        
                    }                    
                }

                return detalleslst.GroupBy(g => g.IDPractAm).Select(s => s.First()).ToList();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al procesar las observaciones.\n{e.Message}", 0);
                return new List<DiscusionDetalle>();
            }
        }

        //PROCESO OBSERVACIONES
        private void ProcesaObs(short acc = 0)
        {

            /*
             * 0 =  Registro Unico hacia atras
             * 1 =  Registro Unico hacia adelante
             * 2 =  Registro Unico hacia todos
             * 3 =  Todos los Registros hacia atras
             * 4 =  Todos los Registros hacia adelante
             * 5 =  Todos los Registros              
             *              
             */

            try
            {
                pvControl.BeginUpdate();

                List<DiscusionDetalle> detalleslst = Getdetallesedit();
                if (detalleslst.Count <= 0) { pvControl.EndUpdate(); return; }

                DiscusionDetalle v = detalleslst.GroupBy(g => g.FechaNeg).Select(s => s.First()).First();
                if (acc == 0)
                {

                    foreach (DiscusionDetalle n in detalleslst)
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg < n.FechaNeg))
                        {
                            d.Obsdetalle = n.Obsdetalle;
                        }
                    }                 
                    
                }
                else if (acc == 1)
                {


                    foreach (DiscusionDetalle n in detalleslst)
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg > n.FechaNeg))
                        {
                            d.Obsdetalle = n.Obsdetalle;
                        }
                    }
                                      
                }
                else if (acc == 2)
                {
                    foreach (DiscusionDetalle n in detalleslst)
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg != n.FechaNeg))
                        {
                            d.Obsdetalle = n.Obsdetalle;
                        }
                    }
                }
                else if (acc == 3)
                {
                    foreach (DiscusionDetalle n in discusionenc.Detalles.Where(w => w.FechaNeg == v.FechaNeg))
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg < n.FechaNeg))
                        {
                            d.Obsdetalle = n.Obsdetalle;
                        }
                    }
                    
                }
                else if (acc == 4)
                {
                    foreach (DiscusionDetalle n in discusionenc.Detalles.Where(w => w.FechaNeg == v.FechaNeg))
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg > n.FechaNeg))
                        {
                            d.Obsdetalle =n.Obsdetalle;
                        }
                    }
                }
                else if (acc == 5)
                {
                    foreach (DiscusionDetalle n in discusionenc.Detalles.Where(w => w.FechaNeg == v.FechaNeg))
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg != n.FechaNeg))
                        {
                            d.Obsdetalle = n.Obsdetalle;
                        }
                    }
                }

                pvControl.EndUpdate();
                pvControl.RefreshData();
                pvControl.Cells.Selection = Rectangle.Empty;
                CalculaDiferencias();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurró un error al actualizar las observaciones de las obras sociales.\n{e.Message}", 1);
                return;
            }


        }

        private void ProcesaCodigosos(short acc = 0)
        {
            try
            {
                pvControl.BeginUpdate();

                List<DiscusionDetalle> detalleslst = Getdetallesedit();

                if (detalleslst.Count <= 0) { pvControl.EndUpdate(); return; }

                DiscusionDetalle v = detalleslst.GroupBy(g => g.FechaNeg).Select(s => s.First()).First();

                //HACIA ATRAS UNICO
                if (acc == 0)
                {
                    foreach (DiscusionDetalle n in detalleslst)
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.FechaNeg < v.FechaNeg && w.IDPractAm == n.IDPractAm))
                        {
                            d.CodigoOs = n.CodigoOs;
                        }
                    }


                }//HACIA ADELANTE UNICO
                else if (acc == 1)
                {
                    foreach (DiscusionDetalle n in detalleslst)
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.FechaNeg > v.FechaNeg && w.IDPractAm == n.IDPractAm))
                        {
                            d.CodigoOs = n.CodigoOs;
                        }
                    }

                }//PARA TODOS UNICO
                else if (acc == 2)
                {
                    foreach (DiscusionDetalle n in detalleslst)
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.FechaNeg != v.FechaNeg && w.IDPractAm == n.IDPractAm))
                        {
                            d.CodigoOs = n.CodigoOs;
                        }
                    }
                }
                //TODAS LAS PRACTICAS HACIA ATRAS
                else if (acc == 3)
                {
                    foreach (DiscusionDetalle n in discusionenc.Detalles.Where(w => w.FechaNeg == v.FechaNeg))
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg < n.FechaNeg))
                        {
                            d.CodigoOs = n.CodigoOs;
                        }
                    }

                }
                //TODAS LAS PRACTICAS HACIA ADELANTE
                else if (acc == 4)
                {
                    foreach (DiscusionDetalle n in discusionenc.Detalles.Where(w => w.FechaNeg == v.FechaNeg))
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg > n.FechaNeg))
                        {
                            d.CodigoOs = n.CodigoOs;
                        }
                    }
                }
                //TODAS LAS PRACTICAS 
                else if (acc == 5)
                {
                    foreach (DiscusionDetalle n in discusionenc.Detalles.Where(w => w.FechaNeg == v.FechaNeg))
                    {
                        foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => w.IDPractAm == n.IDPractAm && w.FechaNeg != n.FechaNeg))
                        {
                            d.CodigoOs = n.CodigoOs;
                        }
                    }
                }
                //EDITAR REGISTROS SELECCIONADOS
                else if (acc == 50)
                {
                    EditarRegselecction(detalleslst);
                }
                //EDITAR TODA LA LISTA
                else if (acc == 51)
                {
                    EditarRegselecction(discusionenc.Detalles.Where(w => w.FechaNeg == detalleslst.GroupBy(g => g.FechaNeg).Select(s => s.First().FechaNeg).First()
                                                                    && w.TipoValor == detalleslst.GroupBy(g => g.TipoValor).Select(s => s.First().TipoValor).First()).ToList());
                }

                pvControl.EndUpdate();
                pvControl.RefreshData();
                pvControl.Cells.Selection = Rectangle.Empty;
                CalculaDiferencias();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurró un error al actualizar los codigos de las obras sociales.\n{e.Message}", 1);
                return;
            }
        }

        //PARAMETROS EDICION
        private void EditarRegselecction(List<DiscusionDetalle> detalleslst)
        {
            try
            {
                if (detalleslst.Count() <= 0) { return; }

                Frm_DiscusionDetpopup det = new Frm_DiscusionDetpopup();
                det.Es_Popup = true;

                DateTime fechan = detalleslst.GroupBy(g => g.FechaNeg).Select(s => s.First().FechaNeg).First();
                byte tipov = detalleslst.GroupBy(g => g.TipoValor).Select(s => s.First().TipoValor).First();
                List<string> grupos = detalleslst.GroupBy(g => g.GrupoPractica).Select(s => s.First().GrupoPractica).ToList();

                det.discusiondet = discusiondetalle.Clone(discusionenc.Detalles.Where(s => s.FechaNeg == fechan && s.TipoValor == tipov 
                                                                                      && grupos.Contains(s.GrupoPractica)).ToList()); ;

                det.practtotales = discusiondetalle.Clone(discusionenc.Detalles.Where(s => s.FechaNeg == fechan && s.TipoValor == tipov).ToList());
                
                if (det.ShowDialog(this) == DialogResult.OK)
                {
                    if (ctrls.MensajePregunta("¿Está seguro de aplicar las modificaciones?") == DialogResult.Yes)
                    {
                        EjecutaModificaion(det.discusiondet, fechan, tipov, grupos);
                    }
                    else { det.Dispose(); return; }
                }

                det.Dispose();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al relizar las modificaciones.\n{e.Message}", 0);
                return;
            }
        }

        //VISIBILIDAD DE COLUMNAS
        private void Visibilidadcolumnas()
        {
            try
            {
                _pedidodifporc = false;
                _pedidodifpeso = false;
                _pactadodifporc = false;
                _pactadodifpeso = false;
                _valnomenc = false;
                _coseguro = false;
                _copago = false;

                foreach (var n in cmbCheckoptn.Properties.Items.GetCheckedValues())
                {
                    if ((short)n == 0) { _pedidodifporc = true; }
                    else if ((short) n == 1 ) { _pedidodifpeso = true; }
                    else if ((short)n == 2) { _pactadodifporc = true; }
                    else if ((short)n == 3) { _pactadodifpeso = true; }
                    else if ((short)n == 4) { _coseguro = true; }
                    else if ((short)n == 5) { _copago = true; }
                    else if ((short)n == 6) { _valnomenc = true; }
                }

                pvControl.BeginInit();

                colDiferenciaporc.Visible = _pedidodifporc;
                colDiferenciaVal.Visible = _pedidodifpeso;
                colDiferenciapactporc.Visible = _pactadodifporc;
                coldiferenciapactval.Visible = _pactadodifpeso;
                colValornomenclado.Visible = _valnomenc;
                colValorCoseguro.Visible = _coseguro;
                colValorCopago.Visible = _copago;

                pvControl.EndInit();
                pvControl.RefreshData();
                pvControl.Refresh();
            }
            catch (Exception)
            {
                pvControl.EndInit();
                pvControl.Refresh();
            }
        }

        //VALIDA QUE NO SE REPITAN LOS CODIGOS POR FECHA (NO PUEDE HABER DOS CODIGOS CON FUNCION DISTINTA, SOLO ES UNA)
        private bool ValidaRepeticioncodigos()
        {
            try
            {

                string repes = "";

                discusionenc.Detalles.GroupBy(g => new { g.FechaNeg, g.CodigoPractica, g.CodigoFuncion }).Select(s => new
                {
                    s.Key.FechaNeg,
                    s.Key.CodigoPractica,
                    s.Key.CodigoFuncion,
                    Repeticiones = s.Count()
                }).Where(w => w.Repeticiones > 1).ToList()
                .ForEach(f => repes += $"Fecha Negociación: {f.FechaNeg} | Práctica: {f.CodigoPractica} | Función: {f.CodigoFuncion}\n");



                if (!string.IsNullOrEmpty(repes))
                {
                    ctrls.MensajeInfo($"Debe corregir las siguientes repeticiones antes de continuar.\n{repes}", 1);
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al validar los códigos.\n{e.Message}", 1);
                return true;
            }
        }

        //RETORNO DE UNIDADES SEGUN PRACTICA
        private decimal Getunidadgaleno(DiscusionDetalle d)
        {
            try
            {
                return PracticasNomencladas.Where(w => w.Codigo == d.CodigoPractica).Select(s => s.UnidadGaleno).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private decimal Getunidadgasto(DiscusionDetalle d)
        {
            try
            {
                return PracticasNomencladas.Where(w => w.Codigo == d.CodigoPractica).Select(s => s.UnidadGasto).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private short Getcantidadayudantes(DiscusionDetalle d)
        {
            try
            {
                return PracticasNomencladas.Where(w => w.Codigo == d.CodigoPractica).Select(s => s.CantidadAyudante).FirstOrDefault();                
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private decimal Getunidadayudantes(DiscusionDetalle d)
        {
            try
            {   
                return PracticasNomencladas.Where(w => w.Codigo == d.CodigoPractica).Select(s => s.UnidadAyudante).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Ibusqregistros();
        }

        private void Formulario_Closed(object sender, FormClosedEventArgs e)
        {
            if (!Es_Popup)
            {
                if (this.Parent is XtraTabPage)
                {
                    XtraTabPage c = this.Parent as XtraTabPage;
                    XtraTabControl x = c.Parent as XtraTabControl;
                    x.TabPages.Remove(c);
                }
            }

            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            ctrls.PreferencesPivot(this, pvControl, "S");
            SqlConnection.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!_canedit) { ctrls.MensajeInfo("No tiene privilegios para realizar ésta acción.", 1); return; }

            if (datFecha.Text == "")
            {
                ctrls.MensajeInfo("Debe ingresar una fecha de inicio para guardar ésta valorización.", 1);
                datFecha.Focus();
                return;
            }

            if (datImpacto.Text == "")
            {
                ctrls.MensajeInfo("Debe ingresar una fecha de negociación para guardar ésta valorización.", 1);
                datImpacto.Focus();
                return;
            }

            if (cmbPrestataria.EditValue == null || cmbPrestataria.EditValue.ToString() == "")
            {
                ctrls.MensajeInfo("Debe ingresar una prestataria para guardar la discusión.", 1);
                cmbPrestataria.Focus();
                return;
            }

            if (cmbValorizacion.EditValue == null || cmbValorizacion.EditValue.ToString() == "")
            {
                ctrls.MensajeInfo("Debe ingresar una valorización para guardar la discusión.", 1);
                cmbValorizacion.Focus();
                return;
            }

            if (discusionenc.Detalles.Count <= 0)
            {
                ctrls.MensajeInfo("No se puede guardar una discusión sin detalles.", 1);                
                return;
            }


            StringBuilder porpresupuesto = new StringBuilder();
            //CONTROLO QUE NO HAYA PRESUPUESTOS CON VALOR
            discusionenc.Detalles.Where(w => w.IDFuncion == 4 && w.Valor > 0).ToList().ForEach(f => porpresupuesto.Append(f.CodigoPractica + " " + f.DescripcionPractica));
            if (!string.IsNullOrWhiteSpace(porpresupuesto.ToString()))
            {
                ctrls.MensajeInfo($"No se puede cerrar una valorizacion con practicas por presupuesto con valor asignado.\n" + porpresupuesto, 1);
                return;
            }

            //SIN PRACTICAS CON CARACTERES > 6
            string[] pracp = new string[6]{ "420101-1", "420101-2", "420101-3", "420110-1", "420110-2", "420110-3" };

            if (discusionenc.Detalles.Where(w => !pracp.Contains(w.CodigoPractica) && !w.CodigoPractica.StartsWith("G") && w.CodigoPractica.Length > 6).Count() > 0)
            {
                ctrls.MensajeInfo("No se puede guardar una discusión con practicas cuyo código AM\nson mayores a 6 dígitos.", 1);
                return;
            }

            //NO DEBE FALTAR NINGUN GALENO NI GASTO
            if (discusionenc.Detalles.Where(w => Galenosygastosex.Contains(w.CodigoPractica)).Count() < Galenosygastosex.Count())
            {
                ctrls.MensajeInfo("Para guardar ésta discusión, todas las unidades de gastos, galenos, nomenclador Neurocirugía\n" +
                                    " traumatología y ginecología deben estar presentes, aunque lleven como valor cero ($0).", 1);
                               
                return;
            }

            //500106
            if (discusionenc.Detalles.Where(w => w.CodigoPractica == "500106" && (w.DescripcionPractica.Length > 0 || w.LetraFuncion != "P")).Count() > 0)
            {
                ctrls.MensajeInfo("No se puede guardar una discusión con descripciones en 500106 o funciones distintas de P.", 1);
                return;

            }
                                    
            //SIN ID PRACTICA Y SIN FUNCION
            if (discusionenc.Detalles.Where(w => !Galenosygastosex.Contains(w.CodigoPractica) && w.LetraFuncion.Trim().Length <= 0).Count() > 0)
            {
                string s = "";
                foreach (DiscusionDetalle d in discusionenc.Detalles.Where(w => !Galenosygastosex.Contains(w.CodigoPractica) && w.LetraFuncion.Trim().Length <= 0))
                {
                    s += $"{d.CodigoPractica} - {d.DescripcionPractica}\n";
                }

                ctrls.MensajeInfo($"Debe definir una función para las siguientes prácticas antes de continuar.\n{s}", 1);
                return;
            }

            if (discusionenc.Detalles.Where(w => w.IDGrupo <= 0).Count() > 0)
            {
                ctrls.MensajeInfo("No se puede guardar una discusión con practicas sin identificación de grupo.", 1);
                return;
            }

            if (ExisteDiscusionalta())
            {
                ctrls.MensajeInfo("Ya existe una discusión con éstos parámetros, no podrá guardar ésta.", 1);
                return;
            }

            if (!ValidaRepeticioncodigos()) { return; }


            
            Abm();
        }

        private void bgwRegistros_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (OrdenSegundoplano == 0) { CargarRegistros(); }
            else if (OrdenSegundoplano == 1)
            {
                Actualizavalimportado();
                //EjecutaImportacion();
            }
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (OrdenSegundoplano == 0) { Fbusqregistros(); }
            else if (OrdenSegundoplano == 1) { FImport(); }
        }
        
        private void cmbPrestataria_EditValueChanged(object sender, EventArgs e)
        {
            string tipoold = discusionenc.TipoValorizacion;
            int idold = discusionenc.IDGrupoOs;

            GridView view = cmbPrestataria.Properties.View;
            if (view == null) { return; }

            var val = view.GetRowCellValue(view.FocusedRowHandle, cmGrupo);
            if (val == null) { return; }

            if (cmbPrestataria.EditValue != null && (int)cmbPrestataria.EditValue > 0)
            {
                if (discusionenc.IDGrupoOs > 0 && (int)cmbPrestataria.EditValue != discusionenc.IDGrupoOs
                    && discusionenc.Detalles.Where(w => w.IDRegistro <= 0).Count() > 0)
                {
                    if (ctrls.MensajePregunta("Hay valores generados que serán quitados por seguridad si cambia la prestatarira.\n" +
                        "¿Continuar?") == DialogResult.Yes)
                    {
                        discusionenc.TipoValorizacion = val.ToString();
                        discusionenc.IDGrupoOs = Convert.ToInt32(cmbPrestataria.EditValue);
                        memoPresta.Text = discusioncls.GetConjuntoprestat(discusionenc.IDGrupoOs);
                        discusionenc.Detalles.RemoveAll(r => r.IDRegistro <= 0);
                        pvControl.RefreshData();
                    }
                    else
                    {
                        cmbPrestataria.EditValue = idold;
                    }
                }
                else
                {
                    discusionenc.TipoValorizacion = val.ToString();
                    discusionenc.IDGrupoOs = Convert.ToInt32(cmbPrestataria.EditValue);
                    memoPresta.Text = discusioncls.GetConjuntoprestat(discusionenc.IDGrupoOs);
                }
            }
        }

        private void cmbValorizacion_EditValueChanged(object sender, EventArgs e)
        {

            if (cmbValorizacion.EditValue != null && (int)cmbValorizacion.EditValue > 0)
            {
                int idold = discusionenc.IDAranvaloriza;

                if (discusionenc.IDAranvaloriza > 0 && discusionenc.IDAranvaloriza != (int)cmbValorizacion.EditValue
                    && discusionenc.Detalles.Where(w => w.IDRegistro <= 0).Count() > 0)
                {
                    if (ctrls.MensajePregunta("Hay valores generados que serán quitados por seguridad si cambia el origen de valores.\n" +
                        "¿Continuar?") == DialogResult.Yes)
                    {
                        discusionenc.IDAranvaloriza = Convert.ToInt32(cmbValorizacion.EditValue);
                        discusionenc.Detalles.RemoveAll(r => r.IDRegistro <= 0);
                        pvControl.RefreshData();
                    }
                    else
                    {
                        cmbValorizacion.EditValue = discusionenc.IDAranvaloriza;
                    }
                }
                else
                {
                    discusionenc.IDAranvaloriza = Convert.ToInt32(cmbValorizacion.EditValue);
                }
            }                
            
        }
        
        private void btnExtras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (discusionenc.IDGrupoOs <= 0) { ctrls.MensajeInfo("Seleccione una prestataria para acceder a éste menú.", 1); return; }

            //AGREGO LA LISTA DE GRUPOS OS 
            if (discusionenc.Extras.Count <= 0 && discusionenc.IDRegistro <= 0)
            {
                discusionenc.Extras = discusionExtra.Clone(discusioncls.Agregaextras(discusionenc.IDGrupoOs));
            }

            Frm_Extras frm = new Frm_Extras();
            frm.Es_Popup = true;
            frm.extralist = discusionExtra.Clone(discusionenc.Extras);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                discusionenc.Extras.Clear();
                discusionenc.Extras = discusionExtra.Clone(frm.extralist);
            }
            frm.Dispose();
        }

        private void btnObservaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (discusionenc.IDGrupoOs <= 0) { ctrls.MensajeInfo("Seleccione una prestataria para acceder a éste menú.", 1); return; }

            //AGREGO LA LISTA DE GRUPOS OS POR DEFECTO, EN CASO DE QUE AUN NO TENGA NINGUNO
            if (discusionenc.GruposObs.Count <= 0)
            {
                discusionenc.GruposObs = discusionGrupo.Clone(discusioncls.Agregagruposobs(discusionenc.IDGrupoOs));
            }

            Frm_GruposObs frm = new Frm_GruposObs();
            frm.Es_Popup = true;
            frm.gruposlst = discusionGrupo.Clone(discusionenc.GruposObs);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                discusionenc.GruposObs.Clear();
                discusionenc.GruposObs = discusionGrupo.Clone(frm.gruposlst);

            }

            frm.Dispose();
        }

        private void btnRespuestas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AGREGO LA LISTA DE GRUPOS OS 
           
            Frm_Respuestasos frm = new Frm_Respuestasos();            
            frm.respuestaslst = discusionrespuesta.Clone(discusionenc.Respuestas);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                discusionenc.Respuestas.Clear();
                discusionenc.Respuestas = discusionrespuesta.Clone(frm.respuestaslst);

            }

            frm.Dispose();

        }

        private void btnParametrizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ParametrizaCambios();
        }

        private void btnOtrasopc_Click(object sender, EventArgs e)
        {
            popupMenu.ShowPopup(MousePosition);
        }

        private void btnOtrosvarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AGREGO LA LISTA 
            if (discusionenc.IDGrupoOs <= 0) { ctrls.MensajeInfo("Seleccione una prestataria para acceder a éste menú.", 1); return; }

            //AGREGO LA LISTA DE GRUPOS OS 
            if (discusionenc.Otros.Count <= 0 && discusionenc.IDRegistro <= 0)
            {
                discusionenc.Otros = discusionotros.Clone(discusioncls.Agregaotros(discusionenc.IDGrupoOs));
            }
            Frm_Otros frm = new Frm_Otros();
            frm.otroslst = discusionotros.Clone(discusionenc.Otros);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                discusionenc.Otros.Clear();
                discusionenc.Otros = discusionotros.Clone(frm.otroslst);

            }

            frm.Dispose();
        }

        private void datImpacto_Validated(object sender, EventArgs e)
        {
            if (discusionenc.Estado == 0 && !string.IsNullOrWhiteSpace(datImpacto.Text))
            {
                discusionenc.FechaImpacto = Convert.ToDateTime(datImpacto.Text);
                CalculaDiferencias();
            }
        }

        private void pvControl_CustomAppearance(object sender, PivotCustomAppearanceEventArgs e)
        {
            try
            {
                if ((e.DataField == colValor || e.DataField == colValorCoseguro || e.DataField == colValorCopago ||
                    e.DataField == colDiferenciaporc || e.DataField == colDiferenciaVal || e.DataField == coldiferenciapactval ||
                    e.DataField == colDiferenciapactporc || e.DataField == colValornomenclado)
                    && e.ColumnValueType == PivotGridValueType.Value && e.RowValueType == PivotGridValueType.Value)
                {
                    if (e.Focused)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#354f52");
                        e.Appearance.ForeColor = ColorTranslator.FromHtml("#edf6f9");
                    }
                    
                    //VALORES APLICADOS
                    PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                    if (ds[0] == null) { e.Appearance.BackColor = ColorTranslator.FromHtml("#fec89a"); return; }
                    DiscusionDetalle detailed = (pvControl.DataSource as List<DiscusionDetalle>)[ds[0].ListSourceRowIndex];
                    
                    //APLICACION
                    if (detailed.Aplicado == 2)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#5e6472");
                        e.Appearance.ForeColor = ColorTranslator.FromHtml("#edf6f9");
                    }
                    else
                    {
                        //PORCENTAJE NEGATIVO EN NEGOCIACION
                        if (detailed.DiferenciaPorc < 0)
                        {
                            if (e.DataField == colValor || e.DataField == colDiferenciaporc || e.DataField == colDiferenciaVal)
                            { e.Appearance.BackColor = ColorTranslator.FromHtml("#d62828"); }
                        }

                        //DIFERENCIA NEGATIVA EN NEGOCIACION PACTADA
                        if (detailed.DiferenciaPorcpactado < 0)
                        {
                            if (e.DataField == colValor || e.DataField == coldiferenciapactval || e.DataField == colDiferenciapactporc)
                            { e.Appearance.BackColor = ColorTranslator.FromHtml("#d62828"); }
                        }

                        //DIFERENCIA NEGATIVA EN CALCULO POR NOMENCLADOR
                        if (detailed.DiferenciaValorNomenclado < 0)
                        {
                            if (e.DataField == colValor || e.DataField == colValornomenclado)
                            {
                                e.Appearance.BackColor = ColorTranslator.FromHtml("#6a4c93");
                            }
                        }
                    }                   
                }
            }
            catch (Exception)
            {
            }
        }

        private void pvControl_PopupMenuShowing(object sender, DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs e)
        {
            popupPivot.ShowPopup(pvControl.PointToScreen(e.Point));
        }

        private void pvControl_FocusedCellChanged(object sender, EventArgs e)
        {
            PivotGridControl pivot = (PivotGridControl)sender;
            if (pivot.Cells.Selection == Rectangle.Empty)
                pivot.Cells.MultiSelection.SetSelection(new Point[] { pivot.Cells.FocusedCell });
        }

        private void Popupmenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //OBSERVACIONES
            if (e.Item.Name == "btnObsregAtras") { ProcesaObs(0); }
            else if (e.Item.Name == "btnObsregAdelante") { ProcesaObs(1); }
            else if (e.Item.Name == "btnObsregtodos") { ProcesaObs(2); }
            else if (e.Item.Name == "btnObsallatras") { ProcesaObs(3); }
            else if (e.Item.Name == "btnObsallAdelante") { ProcesaObs(4); }
            else if (e.Item.Name == "btnObsalltodos") { ProcesaObs(5); }

            //CODIGOS DE GASTOS
            else if (e.Item.Name == "btnCodosuatras") { ProcesaCodigosos(0); }
            else if (e.Item.Name == "btnCodosuadelante") { ProcesaCodigosos(1); }
            else if (e.Item.Name == "btnCodosutodos") { ProcesaCodigosos(2); }

            else if (e.Item.Name == "btnCodosallatras") { ProcesaCodigosos(3); }
            else if (e.Item.Name == "btnCodosalladelante") { ProcesaCodigosos(4); }
            else if (e.Item.Name == "btnCodosalltodos") { ProcesaCodigosos(5); }

            //EDITAR TODO
            else if (e.Item.Name == "btnEditarseleccion") { ProcesaCodigosos(50); }
            else if (e.Item.Name == "btnEditartodo") { ProcesaCodigosos(51); }

        }               
                            
        private void cmbCheckoptn_TextChanged(object sender, EventArgs e)
        {
            Visibilidadcolumnas();
        }

        private void toolTipCtrl_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            PivotGridControl pivotctrl = e.SelectedControl as PivotGridControl;
            if (pivotctrl == null) { return; }

            PivotGridHitInfo hitinfo = pivotctrl.CalcHitInfo(e.ControlMousePosition);

            if (hitinfo.HitTest == PivotGridHitTest.Cell)
            {
                string cellKey = string.Format("Cell|{0}|{1}", hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex);

                ToolTipControlInfo cellInfo = new ToolTipControlInfo(cellKey, "");               
                cellInfo.SuperTip = new SuperToolTip();
                cellInfo.SuperTip.AllowHtmlText = DefaultBoolean.True;

                string colorsubt = "#1d3557";
                string cneg = "#e63946"; //COLOR PARA VALORES NEGATIVOS
                string cpos = "#0b090a"; //COLOR PARA VALORES POSITIVOS
                string val = "";
                PivotGridCells cells = pivotctrl.Cells;
                if (cells.GetCellInfo(hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex) != null)
                {
                    if (cells.GetCellInfo(hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex).DataField.FieldName == "Valor")
                    {
                        PivotDrillDownDataSource ds = cells.GetCellInfo(hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex).CreateDrillDownDataSource();

                        if (ds[0] != null)
                        {
                            DiscusionDetalle det = (pivotctrl.DataSource as List<DiscusionDetalle>)[ds[0].ListSourceRowIndex];

                            if (!_pedidodifpeso || !_pedidodifporc)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Diferencia sobre Pedido</b></color>");

                                val = det.DiferenciaPorc < 0 ? cneg : cpos;

                                if (!_pedidodifporc) { cellInfo.SuperTip.Items.Add($"<color={val}>{Math.Round(det.DiferenciaPorc, 2).ToString(new CultureInfo("en-US"))} %</color>"); }
                                if (!_pedidodifpeso) { cellInfo.SuperTip.Items.Add($"<color={val}>{det.DiferenciaValor.ToString(new CultureInfo("en-US"))} $</color>"); }
                                
                            }

                            if (!_pactadodifporc || !_pactadodifpeso)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Diferencia sobre Pactado</b></color>");

                                val = det.DiferenciaPorcpactado < 0 ? cneg : cpos;

                                if (!_pactadodifporc) { cellInfo.SuperTip.Items.Add($"<color={val}>{Math.Round(det.DiferenciaPorcpactado, 2).ToString(new CultureInfo("en-US"))} %</color>"); }
                                if (!_pactadodifpeso) { cellInfo.SuperTip.Items.Add($"<color={val}>{det.DiferenciaValorPactado.ToString(new CultureInfo("en-US"))} $</color>"); }
                                
                            }

                            if (!_coseguro || !_copago)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Coseguros y Copagos</b></color>");

                                if (!_coseguro) { cellInfo.SuperTip.Items.Add($"Coseguro - {det.ValorCoseguro.ToString(new CultureInfo("en-US"))} $</color>"); }
                                if (!_copago) { cellInfo.SuperTip.Items.Add($"Copagos - {det.ValorCopago.ToString(new CultureInfo("en-US"))} $</color>"); }                                
                            }

                            if (!_valnomenc)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Diferencia sobre Nomenclador</b></color>");
                                val = det.ValorNomenclado > det.Valor ? cneg : cpos;
                                cellInfo.SuperTip.Items.Add($"<color={val}>{det.DiferenciaValorNomenclado.ToString("N2")} $" +
                                     //$" ({det.ValorNomenclado.ToString(new CultureInfo("en-US"))})</color>");
                                     $" ({det.ValorNomenclado.ToString("N2")})</color>");

                                if (det.LetraFuncion == "H" && Getunidadgaleno(det) > 0)
                                { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Galeno: {Getunidadgaleno(det)}</i></color>"); }
                                else if (det.LetraFuncion == "G" && Getunidadgasto(det) > 0)
                                { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Gastos: {Getunidadgasto(det)}</i></color>"); }
                                else if (det.LetraFuncion == "HA" && Getcantidadayudantes(det) > 0)
                                {
                                    cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>Cant. Ayudante: {Getcantidadayudantes(det)}</i></color>");
                                    cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Ayudante: {Getunidadayudantes(det)}</i></color>");
                                }                                    
                                else if (det.LetraFuncion == "P")
                                {
                                    if (Getunidadgaleno(det) > 0) { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Galeno: {Getunidadgaleno(det)}</i></color>"); }
                                    if (Getunidadgasto(det) > 0) { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Gastos: {Getunidadgasto(det)}</i></color>"); }
                                    if (Getcantidadayudantes(det) > 0)
                                    {
                                        cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>Cant. Ayudante: {Getcantidadayudantes(det)}</i></color>");
                                        cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Ayudante: {Getunidadayudantes(det)}</i></color>");
                                    }                                        
                                }                                
                            }

                            e.Info = cellInfo;
                        }
                    }
                }

            }
        }
    }
}
 