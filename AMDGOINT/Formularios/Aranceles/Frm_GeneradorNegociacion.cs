using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Linq;
using System.Collections;
using System.Text;
using System.Globalization;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_GeneradorNegociacion : XtraForm
    {

        private ConexionBD cbd = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private OverlayPanel OverlayPanel = new OverlayPanel();
        private SqlConnection SqlConnection = new SqlConnection();

        private MC.Arancel Arancel { get; set; } = new MC.Arancel();
        private List<MC.Arancel> Aranceles { get; set; } = new List<MC.Arancel>();
        private List<MC.Detalles> ArancelDetalles { get; set; } = new List<MC.Detalles>();


        private List<DiscusionDetalle> Detalleslst = new List<DiscusionDetalle>();
        private List<DiscusionDetalle> PractOF = new List<DiscusionDetalle>();
        public List<DiscusionEncabezado> Discusiones = new List<DiscusionEncabezado>();
        private Point LocationSplash = new Point();

        private string[] Galenosygastosex = new string[46] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
                                                             "GI", "GB", "GN", "GQ", "GR", "GT", "GU", "OG",
                                                             "T1","T2","T3","T4","T5","T6","T7","T8","T9","TA",
                                                             "N1","N2","N3","N4","N5","N6","N7","N8",
                                                             "G1","G2","G3","G4","G5","G6","G7","G8","G9"};

        public Frm_GeneradorNegociacion()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
          
        }
                
        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cbd.Conectar() : SqlConnection;
            Arancel.SqlConnection = SqlConnection;

            Ilistar();
        }

        #region METODOS MANUALES

        //inicia carga listado
        private void Ilistar()
        {
            if (bgwCargar.IsBusy) { bgwCargar.CancelAsync(); }
            while (bgwCargar.CancellationPending)
            { if (!bgwCargar.CancellationPending) { break; } }

            bgwCargar.RunWorkerAsync();
        }
             
        //fin de carga
        private void Flistar()
        {
            CargaCombos();
        }

        //CARGA LISTA ARANCELES
        private void ListarAranceles()
        {
            try
            {
                Aranceles.Clear();
                Aranceles.AddRange(Arancel.GetRegistros().Where(w => w.Fecha.Year >= DateTime.Today.Year && w.Estado));

            }
            catch (Exception)
            {
                return;
            }
        }

        //CARGA DE COMBOS
        private void CargaCombos(short cmb = 0)
        {
            try
            {                  
                //VALORIZACION
                if (cmb == 0 || cmb == 1)
                {                   
                    cmbValorizacion.Properties.DataSource = Aranceles;
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }
        
        //COMIENZO GENERACION DE NEGOCIACIONES
        private void IGeneracion()
        {
            if (bgwGeneracion.IsBusy) { return; }
            OverlayPanel.Mostrar(this);
            bgwGeneracion.RunWorkerAsync();
        }

        //EJECUTO LA GENERACION
        private void Ejecutageneracion()
        {
            try
            {
                int idvalorizacion = (int)cmbValorizacion.EditValue;

                //GUARDO CADA DISCUSION, ENCABEZADO Y DETALLES
                if (idvalorizacion <= 0)
                {
                    ctrls.MensajeInfo("No hay arancel base seleccionado.", 1);
                    return;
                }

                ArancelDetalles.Clear();
                ArancelDetalles.AddRange(Aranceles.Where(w => w.IDRegistro == idvalorizacion).SelectMany(s => s.Detalles));

                if (ArancelDetalles.Count <= 0)
                {
                    ctrls.MensajeInfo("No hay detalles de valorizacion arancelaria para procesar.", 1);
                    return;
                }

                NuevDiscusion(idvalorizacion);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar las negociaciones.\n{e.Message}", 1);
                return;
            }
        }
               
        //PROCEDIMIENTOS RELACIONADOS A DISCUCION CON PRESTATARIA
        #region DISCUSION PRESTATARIAS

        private void NuevDiscusion(int idarancelbase)
        {
            try
            {
                int idencbaezado = 0;
                                
                //GENERO NUEVA DISCUSION
                foreach (DiscusionEncabezado ec in Discusiones)
                {
                    if (ExisteDiscusionalta(idarancelbase, ec.IDGrupoOs)) { continue; }

                    //PROCESO EL ENCABEZADO
                    idencbaezado = Guardaencabezadodisc(idarancelbase, ec.IDGrupoOs);
                    
                    //PROCESO TODOS LOS DETALLES
                    if (idencbaezado > 0)
                    {
                        //GUARDO EL DETALLE
                        Guardodetallesdisc(idencbaezado, ec.Detalles);
                        
                        //GUARDO EXTRAS
                        GuardaExtras(idencbaezado, ec.Extras);
                        
                        //GUARDO OBSERVACIONES
                        GuardaGruposObs(idencbaezado, ec.GruposObs);
                        
                        //GUARDA OTROSVARIOS
                        GuardaOtrosvarios(idencbaezado, ec.Otros);
                        
                        //HISTORICO DE GRUPO VALOR
                        GuardaHistoGrpval(idencbaezado, ec.IDGrupoOs);
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al generar las discusiones.\n{e.Message}", 1);
                return;
            }
        }

        //CONSULTO QUE LA DISCUSION A DAR DE ALTA NO EXISTE
        private bool ExisteDiscusionalta(int idarancel, int idgruoos)
        {
            try
            {
                bool retorno = false;

                string c = $"SELECT ID_Registro FROM DISCUSIONENC WHERE FechaImpacto = '{Convert.ToDateTime(datNegociacion.Text)}'" +
                           $" AND ID_AranValoriza = {idarancel} AND ID_GrupoValor = {idgruoos}";

                if (func.getColecciondatos(c, SqlConnection).Rows.Count > 0)
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

        //ALTA DE ENCABEZADO DE LA DISCUSION
        private int Guardaencabezadodisc(int idarancel, int idagrupador)
        {
            try
            {
                int retorno = 0;

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                string g = Guid.NewGuid().ToString();

                campos.Add("ID_AranValoriza");
                campos.Add("ID_GrupoValor");
                campos.Add("Guid");
                campos.Add("FechaInicio");
                campos.Add("FechaImpacto");
                campos.Add("ID_UsuNew"); 
                campos.Add("ID_UsuModif");

                parametros.Add(idarancel);
                parametros.Add(idagrupador);
                parametros.Add(g);
                parametros.Add(DateTime.Now);
                parametros.Add(Convert.ToDateTime(datNegociacion.Text));
                parametros.Add(glob.GetIdUsuariolog()); 
                parametros.Add(glob.GetIdUsuariolog());

                //GUARDO EL ENCABEZADO                
                func.AccionBD(campos, parametros, "I", "DISCUSIONENC");

                //RECUPERO EL ID AGREGADO EN CASO DE SER UN REGISTRO NUEVO
                retorno = GetIDaranguid(g);      
                

                return retorno;
                     
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al dar de alta una discusion.\n{e.Message}", 1);
                return 0;
            }
        }

        //GET ID ARANCEL POR GUID
        private int GetIDaranguid(string g)
        {
            int retorno = 0;

            try
            {
                string c = "SELECT ID_Registro FROM DISCUSIONENC WHERE Guid = '" + g + "'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows) { retorno = Convert.ToInt32(r["ID_Registro"]); }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al obtener el id de discusión.\n {e.Message}", 0);
                return retorno;
            }
        }

        //INSERTO DETALLES DISCUSION
        private void Guardodetallesdisc(int idencabezado, List<DiscusionDetalle> det)
        {
            try
            {
                bool tipoval = false;
                decimal valor = 0;

                //QUITO TODAS LAS PRACTICAS MARCADAS COMO EXCLUIDAS
                det.RemoveAll(r => ArancelDetalles.Where(w => !w.PracticaIncluir).Select(s => s.IDPractica).Contains(r.IDPractAm));
                
                //QUITO TODAS LAS PRACTICAS POR PRESUPUESTO Y CARGO AFILIADO
                det.RemoveAll(r => r.LetraFuncion == "PP" || r.LetraFuncion == "AF");

                //RECORRO LA LISTA DE DETALLES DE LA DISCUSION, ACTUALIZO NUEVA VALORIZACION O QUITO LAS RECHAZADAS
                foreach (DiscusionDetalle d in det)
                {
                    //SI LA PRACTICA EXISTE Y ESTA INCLUIDA EN LA VALORIZACION BASE
                    if (ArancelDetalles.Where(w => w.IDPractica == d.IDPractAm).Count() > 0)
                    {
                        tipoval = ArancelDetalles.Where(w => w.IDPractica == d.IDPractAm).Select(s => s.TipoValor).FirstOrDefault();
                        valor = ArancelDetalles.Where(w => w.IDPractica == d.IDPractAm).Select(s => s.Valor).FirstOrDefault();
                        
                        //SI LA PRACTICA NO TIENE UN VALOR ASIGNADO (PORCENTUAL O FIJO) QUEDA EL VALOR QUE TIENE
                        if (valor > 0)
                        {
                            d.Valor = !tipoval ? decimal.Round(d.Valor + (d.Valor * (valor / 100)), MidpointRounding.AwayFromZero) : valor;
                        }

                        if (d.Valor == 0) { d.Valor = ArancelDetalles.Where(w => w.IDPractica == d.IDPractAm).Select(s => s.ValorDefecto).FirstOrDefault(); }
                    }
                }
                
                //RECORRO LA LISTA DE ARANCELES CON VALOR POR DEFECTO Y SI NO EXISTEN EN EL DETALLE LAS AGREGO
                foreach (MC.Detalles d in ArancelDetalles.Where(w => w.ValorDefecto > 0 && !det.Select(s => s.IDPractAm).Contains(w.IDPractica)))
                {
                    DiscusionDetalle nd = new DiscusionDetalle();
                    nd.IDEncabezado = idencabezado;
                    
                    nd.IDPractAm = d.IDPractica;
                    nd.CodigoOs = d.PracticaCodigo;
                    nd.IDFuncion = d.FuncionID;
                    nd.Valor = d.ValorDefecto;

                    det.Add(nd);
                }

                //VALIDO QUE NO SE REPITAN PRACTICAS (CODIGO FUNCION)
                foreach (var v in det.GroupBy(g => new { g.CodigoPractica }).Select(gs => new
                {
                    id = gs.Key.CodigoPractica,                    
                    cantidad = gs.Count()
                }).Where(w => w.cantidad > 1 && !Galenosygastosex.Contains(w.id)).Select(s => new { s.id }))
                {
                    //SI TIENE P BORRO EL RESTO
                    if(det.Where(w => w.CodigoPractica == v.id && w.LetraFuncion == "P").Count() > 0)
                    {
                        det.RemoveAll(r => r.CodigoPractica == v.id && r.LetraFuncion != "P");
                    }
                }

                GuardaDetalles(idencabezado, det);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al generar los detalles de discusión.\n{e.Message}", 1);
                return;
            }
        }

        //GUARDO LOS DETALLES 
        private void GuardaDetalles(int idencabezado, List<DiscusionDetalle> detalles)
        {
            try
            {
                int contador = 0;
                int acumulado = 0;

                StringBuilder sb = new StringBuilder();

                string a = "INSERT INTO DISCUSIONDET (ID_Encabezado, Guid, FechaNeg, ID_Practica, CodigoOs, ID_Funcion, Valor, ValorCoseguro, ValorCopago, Observacion," +
                           " CodigoGasto, EsAmdgo, Aplicado, ID_UsuNew) VALUES ";

                DateTime fechanegdetalle = DateTime.Now;
                //fechanegdetalle.ToString("yyyy-MM-dd HH:mm:ss")
                foreach (DiscusionDetalle av in detalles)
                {
                    sb.Append(a + $"({idencabezado}, '{av.IDLocal}', '{fechanegdetalle}', {av.IDPractAm}," +
                                  $" '{(av.CodigoOs.Trim().Length > 12 ? av.CodigoOs.Substring(0, 12).Trim() : av.CodigoOs)}', {av.IDFuncion}," +
                                  $" {av.Valor.ToString(new CultureInfo("en-US"))}, {av.ValorCoseguro.ToString(new CultureInfo("en-US"))}," +
                                  $" {av.ValorCopago.ToString(new CultureInfo("en-US"))}," +
                                  $" '{(av.Obsdetalle.Trim().Length > 1000 ? av.Obsdetalle.Substring(0, 1000).Trim() : av.Obsdetalle)}'," +
                                  $" '{(av.CodigoGasto.Trim().Length > 10 ? av.CodigoGasto.Substring(0, 10).Trim() : av.CodigoGasto)}', {1}," +
                                  $" {0}, {glob.GetIdUsuariolog()});");

                    if (contador == 1000 || ((detalles.Count - 1) == acumulado))
                    {
                        using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                        {
                            using (var command = new SqlCommand())
                            {
                                if (sb.ToString() != "")
                                {
                                    command.Connection = SqlConnection;
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
             
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar los detalles.\n {e.Message}", 0);
                return;
            }
        }

        //GUARDO LOS EXTRAS 
        private void GuardaExtras(int idencabezado, List<DiscusionExtra> extras)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                string a = "INSERT INTO DISCUSIONEXTRA (ID_Encabezado, Descripcion, ID_UsuNew, ID_UsuModif) VALUES ";

                foreach (DiscusionExtra av in extras)
                {
                    sb.Append(a + $"({idencabezado}, '{av.Descripcion}', {glob.GetIdUsuariolog()}, {glob.GetIdUsuariolog()})");                                                                                    
                }

                using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (sb.ToString() != "")
                        {
                            command.Connection = SqlConnection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = sb.ToString();
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
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
        private void GuardaGruposObs(int idencabezado, List<DiscusionGrupoObs> observaciones)
        {
            try
            {                
                StringBuilder sb = new StringBuilder();
                                
                string a = "INSERT INTO DISCUSIONGRPOBS (ID_Encabezado, ID_GrupoPractica, Observacion, ID_UsuNew, ID_UsuModif) VALUES ";

                foreach (DiscusionGrupoObs av in observaciones)
                {
                    sb.Append(a + $"({idencabezado}, {av.IDGrupoPractica} ,'{av.Observacion}', {glob.GetIdUsuariolog()}, {glob.GetIdUsuariolog()})");
                }

                using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (sb.ToString() != "")
                        {
                            command.Connection = SqlConnection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = sb.ToString();
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
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
        private void GuardaOtrosvarios(int idencabezado, List<DiscusionOtros> otros)
        {
            try
            {                
                StringBuilder sb = new StringBuilder();

                string a = "INSERT INTO DISCUSIONOTROS (ID_Encabezado, CodigoOs, CodigoAm, Descripcion, Observacion, Valor, ID_UsuNew, ID_UsuModif) VALUES ";

                foreach (DiscusionOtros av in otros)
                {
                    sb.Append(a + $"({idencabezado}, '{av.CodigoOs}' , '{av.CodigoAm}', '{av.Descripcion}', '{av.Observacion}', '{av.Valor}', {glob.GetIdUsuariolog()}, {glob.GetIdUsuariolog()})");
                }

                using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (sb.ToString() != "")
                        {
                            command.Connection = SqlConnection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = sb.ToString();
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar los extras.\n {e.Message}", 0);
                return;
            }
        }

        //GUARDO HISTORICO DE PLANES POR GRUPO A ESTE MOMENTO
        public void GuardaHistoGrpval(int idencabezado, int idgrupo)
        {
            try
            {
                //SELECCIONO TODOS LOS CODIGOS ASOCIADOS ACTUALMENTE A ÉSTE GRUPO
                string c = "SELECT ID_Registro, ID_Agrupador FROM PRESTDETALLES WHERE ID_Agrupador = " + idgrupo;

                StringBuilder sb = new StringBuilder();
                string a = "INSERT INTO DISCGRPVALHIST (ID_Encabezado, ID_PrestDetalle, ID_Agrupador) VALUES ";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    sb.Append(a + $"({idencabezado}, {Convert.ToInt32(r["ID_Registro"])} , {Convert.ToInt32(r["ID_Agrupador"])})");
                }

                using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        if (sb.ToString() != "")
                        {
                            command.Connection = SqlConnection;
                            command.Transaction = transaction;
                            command.CommandType = CommandType.Text;
                            command.CommandText = sb.ToString();
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar el histórico de grupos.\n {e.Message}", 0);
                return;
            }            
        }

        #endregion
        
        //FIN GENERACION
        private void FGeneracion()
        {            
            OverlayPanel.Ocultar();
            DialogResult = DialogResult.OK;
        }

        #endregion

        private void Frm_Generadordisc_Load(object sender, EventArgs e)
        {
            
        }

        private void Frm_Generadordisc_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
            
        }

        private void Frm_Generadordisc_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbd.Desconectar();
            SqlConnection.Dispose();
        }
        
        private void bgwCargar_DoWork(object sender, DoWorkEventArgs e)
        {
            ListarAranceles();
        }

        private void bgwCargar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Flistar();
        }
        
        private void bgwGeneracion_DoWork(object sender, DoWorkEventArgs e)
        {
            Ejecutageneracion();
        }

        private void bgwGeneracion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FGeneracion();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {            
            if (datNegociacion.Text == "" || (DateTime)datNegociacion.EditValue == DateTime.MinValue)
            {
                ctrls.MensajeInfo("Debe ingresar una fecha de negociación válida para continuar.", 1);
                datNegociacion.Focus();
                return;
            }

            if (Discusiones.Where(w => w.Estado ==  2).Count() <= 0)
            {
                ctrls.MensajeInfo("No hay discusiones base finalizadas para procesar.", 1);                
                return;
            }
                        
            if (ctrls.MensajePregunta($"¿Está seguro de generar una nueva negociación con fecha {datNegociacion.Text}?") == DialogResult.Yes)
            {
                IGeneracion();
            }

            
        }
    }
}