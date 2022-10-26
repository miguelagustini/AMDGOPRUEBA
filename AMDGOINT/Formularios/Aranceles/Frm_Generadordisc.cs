using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Linq;
using DevExpress.Utils;
using System.Collections;
using System.Text;
using System.Globalization;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_Generadordisc : XtraForm
    {

        private ConexionBD cbd = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private OverlayPanel OverlayPanel = new OverlayPanel();
        private SqlConnection SqlConnection = new SqlConnection();

        private List<DiscusionDetalle> Detalleslst = new List<DiscusionDetalle>();
        private List<DiscusionDetalle> PractOF = new List<DiscusionDetalle>();
        public List<DiscusionEncabezado> Discusiones = new List<DiscusionEncabezado>();

        private Point LocationSplash = new Point();

        private string[] ArrayOftalm = new string[20] { "300201", "300112", "300119", "300120", "180109", "305001", "301011", "300202", "300204", "301014", "301015",
                                                        "300109", "300127", "020901", "020309", "020501", "020701", "029001", "020902",
                                                        "500106"};


        public Frm_Generadordisc()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
          
        }
                
        private void ParametrosInicio()
        {
            SqlConnection = cbd.Conectar();
            CargaCombos();
                       
            gridView.Columns["GrupoPractica"].GroupIndex = 0;
            gridView.OptionsView.ShowGroupPanel = false;
        }

        #region METODOS MANUALES
        
        //CARGA DE COMBOS
        private void CargaCombos(short cmb = 0)
        {
            try
            {
                string consulta = "";
                               
                //VALORIZACION
                if (cmb == 0 || cmb == 1)
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

        //inicia carga listado
        private void Ilistar()
        {           
            
            gridView.BeginDataUpdate();

            if (bgwCargar.IsBusy) { bgwCargar.CancelAsync(); }
            while (bgwCargar.CancellationPending)
            { if (!bgwCargar.CancellationPending) { break; } }

            bgwCargar.RunWorkerAsync();
        }
        
        //CARGO LA LISTA DE PRACTICAS QUE APARECIERON EN LA ULTIUMA NEGOCIACION ESTABLECIDA
        private void ListarPracticas()
        {
            try
            {
                Detalleslst.Clear();


                string c = "SELECT DISTINCT DD.ID_Practica, PM.ID_Arancel, PM.ID_Gasto, DD.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                            " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                            " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                            " FROM DISCUSIONDET DD" +
                            " LEFT OUTER JOIN DISCUSIONENC DE ON(DE.ID_Registro = DD.ID_Encabezado)" +
                            " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = DD.ID_Funcion)" +
                            " LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica)" +
                            " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                            " WHERE DE.Estado >= 1 AND DD.Aplicado = 2 AND" +
                            " DE.FechaImpacto = (SELECT MAX(DE1.FechaImpacto)" +
                            " FROM DISCUSIONENC DE1 WHERE DE1.ID_GrupoValor = DE.ID_GrupoValor AND DE1.Estado >= 1)" +
                            //SIN FUNCION PRESUPUESTO NI CARGO AFILIADO
	                        " AND DD.ID_Funcion <> 4 AND DD.ID_Funcion <> 10";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    Detalleslst.Add(new DiscusionDetalle
                    {

                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Practica"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0,
                        ValorDos = 0
                        
                    });
                }

                PracticasOF();

                foreach (DiscusionDetalle d in PractOF)
                {
                    if (Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Count() <= 0)
                    {
                        Detalleslst.Add(d);
                    }
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al consultar la lista de prácticas.\n{e.Message}", 0);
                return;
            }
        }

        //fin de carga
        private void Flistar()
        {
            gridControl.DataSource = Detalleslst;
            gridView.EndDataUpdate();
        }

        //ASIGNA VALORES GRID
        private void AsignaValores(byte tipovalor, decimal valor, List<string> aplicaen)
        {
            try
            {
                gridView.BeginDataUpdate();
                                
                //GRUPO
                if (aplicaen.Count > 0)
                {
                    foreach (DiscusionDetalle i in Detalleslst.Where(w => aplicaen.Contains(w.GrupoPractica)))
                    {
                        i.TipoValor = tipovalor;
                        i.Valor = valor;
                    }
                }

                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al actualizar los valores.\n{e.Message}", 1);
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
                int idvalorizacion = 0;
                //VALIDO SI DEBO GENERAR UNA NUEVA VALORIZACION
                if ((bool)tglNuevaValoriza.EditValue)
                {
                    idvalorizacion = NuevaValorizacion();
                }
                else { idvalorizacion = (int)cmbValorizacion.EditValue; }

                //GUARDO CADA DISCUSION, ENCABEZADO Y DETALLES
                if (idvalorizacion > 0)
                {
                    NuevDiscusion(idvalorizacion);
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar las negociaciones.\n{e.Message}", 1);
                return;
            }
        }

        //PROCEDIMIENTOS RELACIONADOS CON VALORIZACION BASE
        #region ALTA DE NUEVA VALORIZACION

        //CONSULTO QUE LA VALORIZACION DE ALTA NO EXISTA
        private bool ExisteArancelalta()
        {
            try
            {
                bool retorno = false;

                string c = $"SELECT ID_Registro FROM ARANVALORIZAENC WHERE Fecha = '{Convert.ToDateTime(datNegociacion.Text)}'";

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

        //GENERO NUEVA VALORIZACION BASE
        private int NuevaValorizacion()
        {
            try
            {
                int retorno = 0;

                //CREO LOS DETALLES ANTES DE INSERTAR LA NUEVA VALORIZACION, DE LO CONTRARIO NO TRAERA NADA.
                Arancelesclass aranceles = new Arancelesclass();
                //CREO LOS NUEVOS DETALLES
                aranceles.Agregardetalles();
                List<ArancelesValoriza> lista = aranceles.arancelesdetallelst;

                //GUARDO EL ENCABEZADO
                retorno = GuardoEncabezadoaran();

                //DETALLES
                if (retorno > 0) { GuardoDetallesaran(retorno, lista); }


                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar la nueva valorización.\n{e.Message}", 1);
                return 0;
            }
        }

        private int GuardoEncabezadoaran()
        {
            try
            {

                int retorno = 0;

                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                string g = Guid.NewGuid().ToString();

                campos.Add("Guid");
                campos.Add("Fecha"); 
                campos.Add("Observaciones");
                campos.Add("Estado");
                campos.Add("ID_UsuNew");
                campos.Add("ID_UsuModif");

                DateTime dat = Convert.ToDateTime(datNegociacion.Text);

                parametros.Add(g);
                parametros.Add(dat);
                parametros.Add($"Aranceles pretendidos {dat.ToString("MMMM")} {dat.Year}");
                parametros.Add(1);
                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(glob.GetIdUsuariolog());

                //GUARDO EL ENCABEZADO
                func.AccionBD(campos, parametros, "I", "ARANVALORIZAENC");
                //RECUPERO EL ID AGREGADO EN CASO DE SER UN REGISTRO NUEVO
                retorno = GetIDarancelbase(g);

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar la nueva valorización.\n{e.Message}", 1);
                return 0;
            }
        }

        //GET ID ARANCEL POR GUID
        private int GetIDarancelbase(string g)
        {
            int retorno = 0;

            try
            {
                string c = "SELECT ID_Registro FROM ARANVALORIZAENC WHERE Guid = '" + g + "'";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                { retorno = Convert.ToInt32(r["ID_Registro"]); }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al obtener el arancel.\n {e.Message}", 0);
                return retorno;
            }
        }

        //GUARDO LOS DETALLES DE LA VALORIZACION
        private void GuardoDetallesaran(int idencabezado, List<ArancelesValoriza> detalles)
        {
            try
            {                
                byte tipoval = 0;
                decimal valor = 0;

                //RECALCULO LOS VALORES
                foreach (ArancelesValoriza d in detalles)
                {
                    //SI NO ENCUENTRO LA PRACTICA, CONTINÚO
                    if (Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Count() <= 0) { continue; }

                    tipoval = Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.TipoValor).First();
                    valor = Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.Valor).First();

                    if (valor > 0)
                    {
                        d.ValorArt = tipoval == 0 ? decimal.Round(d.ValorArt + (d.ValorArt * (valor / 100)), MidpointRounding.AwayFromZero) : valor;
                        d.ValorCaja = tipoval == 0 ? decimal.Round(d.ValorCaja + (d.ValorCaja * (valor / 100)), MidpointRounding.AwayFromZero) : valor;
                        d.ValorOs = tipoval == 0 ? decimal.Round(d.ValorOs + (d.ValorOs * (valor / 100)), MidpointRounding.AwayFromZero) : valor;
                        d.ValorPrepaga = tipoval == 0 ? decimal.Round(d.ValorPrepaga + (d.ValorPrepaga * (valor / 100)), MidpointRounding.AwayFromZero) : valor;
                    }
                }

                //GUARDADO
                StringBuilder qry = new StringBuilder();
                int contador = 0;
                int acumulado = 0;

                foreach (ArancelesValoriza av in detalles)
                {

                    qry.AppendLine("INSERT INTO ARANVALORIZADET (ID_Encabezado, ID_PractAm, ValorPrepaga, ValorOs, ValorArt, ValorCaja," +
                           " ObsPrepaga, ObsOs, ObsArt, ObsCaja, ID_UsuNew) VALUES ");


                    qry.AppendLine($"({idencabezado}, {av.IDPractAm}, {av.ValorPrepaga.ToString(new CultureInfo("en-US"))}," +
                        $" {av.ValorOs.ToString(new CultureInfo("en-US"))}, {av.ValorArt.ToString(new CultureInfo("en-US"))}," +
                        $" {av.ValorCaja.ToString(new CultureInfo("en-US"))}, '{av.ObsPrepaga.Trim()}', '{av.ObsOs.Trim()}'," +
                        $" '{av.ObsArt.Trim()}', '{av.ObsCaja.Trim()}', {glob.GetIdUsuariolog()});");

                    if (contador == 1000 || ((detalles.Count - 1) == acumulado))
                    {
                        using (SqlTransaction transaction = SqlConnection.BeginTransaction())
                        {
                            using (var command = new SqlCommand())
                            {
                                if (qry.ToString() != "")
                                {
                                    command.Connection = SqlConnection;
                                    command.Transaction = transaction;
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = qry.ToString();
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }

                            }
                        }

                        qry.Clear();
                        contador = 0;
                    }

                    acumulado++;
                    contador++;
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar los detalles de la nueva valorización.\n{e.Message}", 1);
                return;
            }
        }

        #endregion

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

        private void PracticasOF()
        {            
            try
            {
                PractOF.Clear();

                string c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                            " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                            " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                            " FROM PRACTAM PM" +
                            " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                            " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                            " WHERE (PM.Codigo = '300201' OR PM.Codigo = '300112' OR PM.Codigo = '300119' OR PM.Codigo = '300120' OR PM.Codigo = '180109' OR" +
                            " PM.Codigo = '305001' OR PM.Codigo = '301011' OR PM.Codigo = '300202' OR PM.Codigo = '300204' OR PM.Codigo = '301014' OR" +
                            " PM.Codigo = '301015' OR PM.Codigo = '300109' OR PM.Codigo = '300127' OR PM.Codigo = '020901' OR PM.Codigo = '020309' OR" +
                            " PM.Codigo = '020501' OR PM.Codigo = '020701' OR PM.Codigo = '029001' OR PM.Codigo = '020902' OR PM.Codigo = '300137'" +
                            " OR PM.Codigo = '500106') AND ID_Funcion = 5";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                           " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                           " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                           " FROM PRACTAM PM" +
                           " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                           " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                           " WHERE(PM.Codigo = 'G1' OR PM.Codigo = 'G2' OR PM.Codigo = 'G3' OR PM.Codigo = 'G4' OR PM.Codigo = 'G5' OR" +
                           " PM.Codigo = 'G6' OR PM.Codigo = 'G7' OR PM.Codigo = 'G8')";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                    " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                    " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                    " FROM PRACTAM PM" +
                    " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                    " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                    " WHERE(PM.Codigo = 'GVL606') AND ID_Funcion = 3";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                   " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                   " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                   " FROM PRACTAM PM" +
                   " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                   " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                   " WHERE(PM.Codigo = 'GVL606') AND ID_Funcion = 3";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                  " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                  " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                  " FROM PRACTAM PM" +
                  " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                  " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                  " WHERE (PM.Codigo = '285008' OR PM.Codigo = '285009' OR PM.Codigo = '285010' OR PM.Codigo = '285011') AND ID_Funcion = 5";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                 " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                 " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                 " FROM PRACTAM PM" +
                 " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                 " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                 " WHERE (PM.Codigo = '360112' OR PM.Codigo = '365001' OR PM.Codigo = '360108' OR PM.Codigo = '365002' OR PM.Codigo = '369001' OR PM.Codigo = '100210'" +
                 " OR PM.Codigo = '100404' OR PM.Codigo = '105004' OR PM.Codigo = '100175' OR PM.Codigo = '365010' OR PM.Codigo = '100220' OR PM.Codigo = '100221'" +
                 " OR PM.Codigo = '100504' OR PM.Codigo = '100501' OR PM.Codigo = '105002') and (ID_Funcion = 5 or ID_Funcion = 3)";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }


                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                " FROM PRACTAM PM" +
                " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                " WHERE (PM.Codigo = '360112' OR PM.Codigo = '365001' OR PM.Codigo = '360108' OR PM.Codigo = '365002' OR PM.Codigo = '369001' OR PM.Codigo = '100210'" +
                " OR PM.Codigo = '100404' OR PM.Codigo = '105004' OR PM.Codigo = '100175' OR PM.Codigo = '365010' OR PM.Codigo = '100220' OR PM.Codigo = '100221'" +
                " OR PM.Codigo = '100504' OR PM.Codigo = '100501' OR PM.Codigo = '105002') and (ID_Funcion = 5 or ID_Funcion = 3)";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                      " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                      " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                      " FROM PRACTAM PM" +
                      " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                      " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                      " WHERE (PM.Codigo = 'GOB401' OR PM.Codigo = 'GOB403' OR PM.Codigo = '110403')";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                      " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                      " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                      " FROM PRACTAM PM" +
                      " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                      " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                      " WHERE (PM.Codigo = '425090' OR PM.Codigo = '425091' OR PM.Codigo = '425092' OR PM.Codigo = '425093' OR PM.Codigo = '425094' OR PM.Codigo = '425095')";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                      " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                      " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                      " FROM PRACTAM PM" +
                      " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                      " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                      " WHERE (PM.Codigo = '500107' OR PM.Codigo = '500108') and ID_Funcion = 5";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                     " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                     " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                     " FROM PRACTAM PM" +
                     " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                     " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                     " WHERE (PM.Codigo = '290113' OR PM.Codigo = '290143') and ID_Funcion = 5";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }

                c = "SELECT PM.ID_Registro, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, ISNULL(FU.Codigo,'') AS CodigoFuncion, ISNULL(FU.Descripcion, '') as DescripcionFuncion," +
                    " ISNULL(PM.Codigo, '') AS CodigoPractica, ISNULL(PM.Descripcion, '') AS DescripcionPractica," +
                    " ISNULL(FU.Letra, '') as LetraFuncion, ISNULL(PG.Descripcion, '') As Grupo, PG.Orden as GrupoOrden, PG.ID_Registro as IDGrupo" +
                    " FROM PRACTAM PM" +
                    " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                    " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                    " WHERE PM.Codigo = '171010'  and ID_Funcion = 3";

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows)
                {
                    PractOF.Add(new DiscusionDetalle
                    {
                        IDFuncion = Convert.ToInt32(r["ID_Funcion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoFuncion = r["CodigoFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescripcionFuncion"].ToString().Trim(),
                        CodigoPractica = r["CodigoPractica"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        DescripcionPractica = r["DescripcionPractica"].ToString().Trim(),
                        IDGrupo = (int)r["IDGrupo"],
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        GrupoPractica = r["Grupo"].ToString(),
                        TipoValor = 0,
                        Valor = 0

                    });
                }


            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al obtener las prácticas oftalmológicas.\n{e.Message}", 1);
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

                foreach (DataRow r in func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null).Rows) { retorno = Convert.ToInt32(r["ID_Registro"]); }

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
                byte tipoval = 0;
                decimal valor = 0;
                decimal valordef = 0;
                

                //PRIMERO ME ASEGURO DE QUE TENGA TODAS LAS PRACTICAS OFTALMOLOGICAS (SACAR LUEGO)
                foreach (DiscusionDetalle d in PractOF)
                {
                    if (det.Where(w => w.IDPractAm == d.IDPractAm).Count() <= 0)
                    {
                        DiscusionDetalle discd = new DiscusionDetalle();
                        discd = d.Clone();
                        discd.Valor = 0;
                        det.Add(discd);
                    }
                }
                
                //RECORRO LA LISTA DE DETALLES DE LA DISCUSION, ACTUALIZO NUEVA VALORIZACION
                foreach (DiscusionDetalle d in det)
                {
                    tipoval = Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.TipoValor).FirstOrDefault();
                    valor = Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.Valor).FirstOrDefault();
                    valordef = Detalleslst.Where(w => w.IDPractAm == d.IDPractAm).Select(s => s.ValorDos).FirstOrDefault();

                    //SI LA PRACTICA VIENE CON VALOR
                    if (d.Valor > 0)
                    {
                        if (valor > 0)
                        {
                            /*if ((d.CodigoPractica == "300119") || coun == 1932)
                            {
                                string c = "";
                            }*/
                            d.Valor = tipoval == 0 ? decimal.Round(d.Valor + (d.Valor * (valor / 100)), MidpointRounding.AwayFromZero) : valor;
                        }
                    }                    
                    else
                    {
                        d.Valor = valordef;
                    }

                    if (d.CodigoPractica == "500106") { d.Valor = 0; }
                    
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
                              
                foreach (DiscusionDetalle av in detalles)
                {
                    sb.Append(a + $"({idencabezado}, '{av.IDLocal}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {av.IDPractAm}," +
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
            ParametrosInicio();
        }

        private void Frm_Generadordisc_Shown(object sender, EventArgs e)
        {
            Ilistar();
        }

        private void Frm_Generadordisc_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbd.Desconectar();
            SqlConnection.Dispose();
        }

        private void tglNuevaValoriza_Toggled(object sender, EventArgs e)
        {
            cmbValorizacion.EditValue = (bool)tglNuevaValoriza.EditValue ? 0 : cmbValorizacion.EditValue = cmbValorizacion.OldEditValue;
            cmbValorizacion.Enabled = !(bool)tglNuevaValoriza.EditValue;            
        }

        private void bgwCargar_DoWork(object sender, DoWorkEventArgs e)
        {
            ListarPracticas();
        }

        private void bgwCargar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Flistar();
        }
        
        private void gridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            GridView view = sender as GridView;
            if (info.Column == colGrupo)
            {
                var rowValue = view.GetGroupRowValue(info.RowHandle, info.Column);
                info.GroupText = rowValue.ToString();
            }
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).Width = (int)Math.Round((double)this.Width / 2, 0);
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;            
        }

        private void Frm_Generadordisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                Usr_Paramgeneracion prm = new Usr_Paramgeneracion();
                prm.Grupos = Detalleslst.GroupBy(g => new { g.GrupoPractica }).Select(s => s.First().GrupoPractica).ToList();

                if (XtraDialog.Show(prm, "Parámetros de edición", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AsignaValores(prm.Tipovalor, prm.Valor, prm.Gruposel);                   
                    
                }

                prm.Dispose();
            }
        }

        private void toolTip_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            try
            {
                if (e.Info == null && e.SelectedControl == gridControl)
                {
                    GridView view = gridControl.FocusedView as GridView;
                    GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);

                    if (info != null && info.Column == colFuncion && view != null)
                    {
                        DiscusionDetalle d = new DiscusionDetalle();
                        d = view.GetRow(info.RowHandle) as DiscusionDetalle;
                        string text = d.DescripcionFuncion;
                        string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                        e.Info = new ToolTipControlInfo(cellKey, text);
                    }
                }                
            }
            catch (Exception )
            {
                return;
            }
            
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
            if (!(bool)tglNuevaValoriza.EditValue && (int)cmbValorizacion.EditValue <= 0)
            {
                ctrls.MensajeInfo("Si va a utilizar una valorización existente, debe seleccionarla", 1);
                cmbValorizacion.Focus();
                return;
            }

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

            if ((bool)tglNuevaValoriza.EditValue && ExisteArancelalta())
            {
                ctrls.MensajeInfo("Ya existe una valorización base con esta fecha, cambie los parámetros de generación.", 1);                
                return;
            }

            if (ctrls.MensajePregunta($"¿Está seguro de generar una nueva negociación con fecha {datNegociacion.Text}?") == DialogResult.Yes)
            {
                IGeneracion();
            }

            
        }
    }
}