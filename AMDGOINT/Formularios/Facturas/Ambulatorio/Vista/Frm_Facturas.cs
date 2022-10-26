using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using AMDGOINT.Formularios.Facturas.Ambulatorio.MC;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraGrid;
using System.IO;
using System.Net;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Frm_Facturas : XtraForm
    {
        private ConexionBD ConexionBD = new ConexionBD();        
        private Controles ctrls = new Controles();
        private Globales glb = new Globales();
        private Funciones func = new Funciones();

        private Facturacion Facturacion = new Facturacion();
        private List<FacturaEnc> FacturasEncabezados = new List<FacturaEnc>();
        private List<FacturaDet> FacturasDetalles = new List<FacturaDet>();
        private List<ComprobantesRel> ComprobantesRelacionados = new List<ComprobantesRel>();
        private List<Mailing> ComprobantesMails = new List<Mailing>();

        private List<Configuracion.Permisos.MC.Permiso> Permisos { get; set; } = new List<Configuracion.Permisos.MC.Permiso>();
        private Configuracion.Permisos.MC.Permiso Permiso = new Configuracion.Permisos.MC.Permiso();

        private FacturaEnc Facturascls = new FacturaEnc();
        private FacturaDet Detallescls = new FacturaDet();
        private ComprobantesRel Comprobantesrelcls = new ComprobantesRel();

        private Impresion Impresion = new Impresion();

        private Point LocationSplash = new Point();

        private SqlConnection SqlConnection = new SqlConnection();

        private Usr_Detalles UsrDetallesindividual = new Usr_Detalles();
        private Usr_ComprobantesRel UsrComprobantesrel = new Usr_ComprobantesRel();

        private FacturaEnc _encabezado;

        private List<FacturaEnc> ListaPrint { get; set; } = new List<FacturaEnc>();
        private short CantCopias { get; set; } = 0;
        private bool ExportaWeb { get; set; } = false;
        private bool Incluyepaci { get; set; } = false;
        private bool Incluyefactura { get; set; } = false;
        private bool MailUnico { get; set; } = true;
        private string Pathexport { get; set; } = "";
        private bool _lanzaactualizacion = false;

        public bool LanzaActualizacion
        {
            get { return _lanzaactualizacion; }
            set
            {
                if (_lanzaactualizacion != value)
                {
                    IBusqRegistros();
                }
            }
        }

        public Frm_Facturas()
        {

            InitializeComponent();
                        
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            SetControles();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = ConexionBD.Conectar();
            Facturacion.SqlConnection = SqlConnection;
            Facturascls.SqlConnection = SqlConnection;
            Detallescls.SqlConnection = SqlConnection;
            Comprobantesrelcls.SqlConnection = SqlConnection;
            Permiso.SqlConnection = SqlConnection;

            ctrls.PreferencesGrid(this, gridView, "R");

            ctrls.PreferencesGrid(this, dockManager, "R");
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            //CARGA PERMISOS
            Permisos.Clear();
            Permisos.AddRange(Permiso.GetPermisoUsuario());

            btnTxtSA.Visible = glb.GetIdUsuariolog() == 1 ? true : false;
            btnTxtSN.Visible = glb.GetIdUsuariolog() == 1 ? true : false;
            btnTxtFesalud.Visible = glb.GetIdUsuariolog() == 1 ? true : false;
        }

        private void SetControles()
        {
            try
            {
                panelDetalles.Controls.Add(UsrDetallesindividual);
                UsrDetallesindividual.Dock = DockStyle.Fill;
                panelComprobrel.Controls.Add(UsrComprobantesrel);
                UsrComprobantesrel.Dock = DockStyle.Fill;                
            }
            catch (Exception)
            {

            }
        }

        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
                btnImpresion.Enabled = false;
                btnComprobantes.Enabled = false;                
                gridView.BeginDataUpdate();

                if (bgwObtienereg.IsBusy) { bgwObtienereg.CancelAsync(); }
                while (bgwObtienereg.CancellationPending)
                { if (!bgwObtienereg.CancellationPending) { break; } }

                bgwObtienereg.RunWorkerAsync();
            }
            catch (Exception)
            {
                btnImpresion.Enabled = true;
                btnComprobantes.Enabled = true;                
            }            
            
        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                FacturasEncabezados.Clear();
                FacturasDetalles.Clear();
                ComprobantesRelacionados.Clear();

                FacturasEncabezados.AddRange(Facturascls.GetRegistros());
                FacturasDetalles.AddRange(Detallescls.GetRegistros());
                ComprobantesRelacionados.AddRange(Comprobantesrelcls.GetRegistros());
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al obtener los registros.\n{e.Message}", 1);
                return;
            }
        }

        //FIN DE CONSULTA REGISTROS
        private void FBusqRegistros()
        {

            try
            {
                gridControl.DataSource = FacturasEncabezados;
                gridView.EndDataUpdate();

                UsrDetallesindividual.Detalles.Clear();
                UsrDetallesindividual.Detalles.AddRange(FacturasDetalles);
                UsrComprobantesrel.Comprobanteslst.Clear();
                UsrComprobantesrel.Comprobanteslst.AddRange(ComprobantesRelacionados);

                btnImpresion.Enabled = true;
                btnComprobantes.Enabled = true;                

                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
                btnImpresion.Enabled = true;
                btnComprobantes.Enabled = true;                
            }
            
        }
              
        //PREPARO IMPRESION
        public void PreparaImpresion(short mode = 0,  bool unicoreg = false, long findbyid = 0)
        {
            try
            {
                Impresion.Facturas.Clear();
                ListaPrint.Clear();

                if (!Permisos.Where(w => w.Clave == "AmfactImpresion" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso a la impresión de comprobantes", 1);
                    return;
                }
                    

                if (unicoreg)
                {
                    //SI DEBO ENCONTRAR POR ID (USADO PARA IMPRIMIR DESDE FUERA DEL FORM)
                    if (findbyid > 0)
                    {
                        FacturaEnc p = FacturasEncabezados.Where(w => w.IDRegistro == findbyid && w.EstadoAf == "A").FirstOrDefault();

                        if (p != null)
                        {
                            p.Detalles.Clear();
                            p.Detalles.AddRange(FacturasDetalles.Where(w => w.IDEncabezado == p.IDRegistro));
                            ListaPrint.Add(p);
                        }
                        else
                        {
                            ctrls.MensajeInfo("No se encontró el comprobante a visualizar.", 1);
                            return;
                        }

                    }
                    else
                    {
                        FacturaEnc p = gridView.GetRow(gridView.FocusedRowHandle) as FacturaEnc;
                        if (p != null && p.EstadoAf == "A")
                        {
                            p.Detalles.Clear();
                            p.Detalles.AddRange(FacturasDetalles.Where(w => w.IDEncabezado == p.IDRegistro));
                            ListaPrint.Add(p);
                        }
                        
                    }
                    
                }
                else
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        FacturaEnc p = gridView.GetRow(i) as FacturaEnc;
                        p.Detalles.Clear();
                        p.Detalles.AddRange(FacturasDetalles.Where(w => w.IDEncabezado == p.IDRegistro));
                        if (p != null && p.EstadoAf == "A") { ListaPrint.Add(p); }
                        
                    }
                }

                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                CantCopias = parametros.Cantidad;
                Incluyepaci = parametros.IncluirPacientes;      
                Incluyefactura = parametros.IncluirFactura;
                
                Impresion.Facturas = ListaPrint;

                if (mode == 0) { Impresion.Imprimir(CantCopias, Incluyepaci, Incluyefactura); }
                if (mode == 1) { Iexpotarpdf(); }

                parametros.Dispose();
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la impresión.\n{e.Message}", 1);
                return;                
            }
        }

        //EXPORTA PDF
        private void Iexpotarpdf()
        {
            try
            {
                if (CantCopias <= 0) { return; }
                btnImpresion.Enabled = false;

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                        Pathexport = fbd.SelectedPath;                                                                        

                        if (bgwExportpdf.IsBusy) { bgwExportpdf.CancelAsync(); }
                        while (bgwExportpdf.CancellationPending)
                        { if (!bgwExportpdf.CancellationPending) { break; } }

                        bgwExportpdf.RunWorkerAsync();
                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                btnImpresion.Enabled = true;
                return;
            }
        }

        private void ExportarPdf()
        {
            try
            {
                if (Pathexport == "") { return; }
                Impresion.GeneraDatosPdf(ListaPrint, CantCopias, Incluyepaci, Pathexport, Incluyefactura, ExportaWeb);

            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al exportar los comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        private void Fexportapdf()
        {

            btnImpresion.Enabled = true;
            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            Pathexport = "";
        }

        //EXPORTA EXCEL (parametro de grid para acceso public0)
        public void ExportaExcel(GridControl grid = null)
        {
            if (!Permisos.Where(w => w.Clave == "Amfactexportaxls" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrls.MensajeInfo("No tiene acceso a la exportacion de comprobantes en lista.", 1);
                return;
            }

            ctrls.ExportaraExcelgrd(grid != null ? grid : gridControl);
        }

        //GENERACION DE COMPROBANTE
        private void GeneraComprobante(bool Relacionado = true)
        {
            try
            {

                if (!Permisos.Where(w => w.Clave == "Amfactman" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene permisos para realizar comprobantes electrónicos.", 1);
                    return;
                }

                Frm_ComprobanteElectronico frm = new Frm_ComprobanteElectronico();
                frm.FormularioPadre = this;
                frm.SqlConnection = SqlConnection;

                if (Relacionado)
                {
                    if (_encabezado != null)
                    {
                        _encabezado.Detalles.Clear();
                        _encabezado.Detalles.AddRange(FacturasDetalles.Where(w => w.IDEncabezado == _encabezado.IDRegistro));
                        _encabezado.ComprobantesRel.Clear();
                        _encabezado.ComprobantesRel.AddRange(ComprobantesRelacionados.Where(w => w.IDFactura == _encabezado.IDRegistro));

                        frm.ComprobanteOriginal = _encabezado.Clone();
                    }
                    else
                    {
                        frm.ComprobanteOriginal = new FacturaEnc();
                    }
                }
                else
                {
                    frm.ComprobanteOriginal = new FacturaEnc();
                }

                ctrls.AgregaFormulario(frm, glb.GetMaintab(), true);
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el formulario de comprobantes.\n{e.Message}", 1);
                return;
            }
        }

        //EXPORTACION A TXT DE FACTURACION
        private void GeneraTextoFactura()
        {
            try
            {
                TextWriter tw = new StreamWriter(@"C:\Users\Usuario\Desktop\Facturacion.txt");

                string linea = "";
                
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    FacturaEnc s = gridView.GetRow(i) as FacturaEnc;
                    
                    if (s != null && s.EstadoAf == "A")
                    {
                        string prestnombre = s.NombrePres.Length > 80 ? s.NombrePres.Substring(0, 80) : s.NombrePres.Trim();
                        string pacinomb = s.PacienteNombre.Length > 80 ? s.PacienteNombre.Substring(0, 80) : s.PacienteNombre.Trim();
                        /********************  PARA SANATORIO AVELLANEDA   *********************************/
                        linea = 
                        $"{s.CodigoProf.Replace(" ", ""),-4}" +                        
                        $"{s.Fecha.ToString("ddMMyyyy"),-8}" +
                        $"{s.TipoComprobante,-2}" +
                        $"{s.Letra,-1}" +
                        $"{s.PuntoVenta.ToString("0000"),-4}" +
                        $"{s.Numero.ToString("00000000"), -8}" +
                        $"{s.CodigoPres.PadLeft(6, '0'),-6}" +
                        $"{prestnombre, -80}" +
                        $"{s.CuitPres.ToString("00000000000"),-11}" +
                        $"{s.IvaPresAbre,-2}" +
                        $"{s.InternacionNumero.PadLeft(6, '0'),-6}" +
                        $"{s.PacienteDocumento.ToString("00000000"),-8}" +
                        $"{pacinomb, -80}" +
                        //$"{s.PorcIvaPres.ToString().Replace(",", ""),-4}" +
                        $"{decimal.ToInt64(s.Neto).ToString("00000000"),8}{((s.Neto - decimal.ToInt64(s.Neto)) * 100).ToString("00"),2}" +
                        $"{decimal.ToInt64(s.NoGravado).ToString("00000000"),8}{((s.NoGravado - decimal.ToInt64(s.NoGravado)) * 100).ToString("00"),2}" +
                        $"{decimal.ToInt64(s.Iva).ToString("00000000"),8}{((s.Iva - decimal.ToInt64(s.Iva)) * 100).ToString("00"),2}" +
                        $"{decimal.ToInt64(s.Total).ToString("00000000"),8}{((s.Total - decimal.ToInt64(s.Total)) * 100).ToString("00"),2}" +
                        $"{s.CaeNroAf, -14}" +
                        $"{s.VtoCaeAf.ToString("ddMMyyyy"), -8}";

                        tw.WriteLine(linea);

                        linea = "";                       

                    }
                }
                                               
                tw.Close();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar el archivo de texto.\n{e.Message}", 1);
                return;
            }
        }
                
        private void GeneraTxtSanatorioNorte()
        {
            try
            {
                ExportacionSN exp = new ExportacionSN(SqlConnection);
                exp.GeneraTxt();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar el txt.\n{e.Message}", 1);
                return;
            }
        }

        private void GeneraTxtFesalud()
        {
            try
            {
                TextWriter tw = new StreamWriter(@"C:\Users\Usuario\Desktop\FacturacionFesalud.txt");

                string linea = "";

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    FacturaEnc s = gridView.GetRow(i) as FacturaEnc;

                    if (s != null && s.EstadoAf == "A")
                    {
                        string prestnombre = s.NombrePres.Length > 80 ? s.NombrePres.Substring(0, 80) : s.NombrePres.Trim();
                        string pacinomb = s.PacienteNombre.Length > 80 ? s.PacienteNombre.Substring(0, 80) : s.PacienteNombre.Trim();
                        /********************  PARA SANATORIO AVELLANEDA   *********************************/
                        linea =
                        $"{s.CodigoProf,-4}" +
                        $"{s.Fecha.ToString("ddMMyyyy"),-8}" +
                        $"{s.PuntoVenta.ToString("0000"),-4}" +
                        $"{s.Numero.ToString("00000000"),-8}" +
                        $"{s.CuitProf.ToString("00000000000"),-11}" +
                        $"{decimal.ToInt64(s.Total).ToString("00000000"),8}{((s.Total - decimal.ToInt64(s.Total)) * 100).ToString("00"),2}";
                        
                        tw.WriteLine(linea);

                        linea = "";

                        //detalles 
                        GeneraTxtFesaludDetalles(s);
                    }

                }

                tw.Close();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar el txt.\n{e.Message}", 1);
                return;
            }
        }

        private void GeneraTxtFesaludDetalles(FacturaEnc s)
        {
            try
            {
                string path = @"C:\Users\Usuario\Desktop\DetallesFesalud";
                string name = s.NombreProf.Replace(",", "").Replace(" ", "") + "_" + s.Fecha.ToString("yyyyMM") + "_" + s.Comprobante.Replace("-", "");
                

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                TextWriter tw = new StreamWriter($@"{path}\{name}.txt");

                string linea = "";

                foreach(FacturaDet fd in FacturasDetalles.Where(w => w.IDEncabezado == s.IDRegistro))
                {                       
                    linea =
                        $"{s.CodigoProf};" +
                        $"{fd.DocuPaci};" +
                        $"{fd.FechaPract.ToString("yyyyMMdd")};" +
                        $"{(fd.BonoNumero == 0 ? "0" : fd.BonoNumero.ToString("0040000000000"))};" +
                        $"{fd.CodPract};" +
                        $"{(fd.Honorarios > 0 ? 1 : fd.Gastos > 0 ? 4 : 100)};" +
                        $"{decimal.ToInt64(fd.Cantidad).ToString("0000"),4}{((fd.Cantidad - decimal.ToInt64(fd.Cantidad)) * 100).ToString("00"),2};" +
                        $"{s.CodigoProf};" +
                        $"{decimal.ToInt64(fd.Total).ToString("0000"),4}{((fd.Total - decimal.ToInt64(fd.Total)) * 100).ToString("00"),2};" +
                        $"{decimal.ToInt64(fd.Total).ToString("0000"),4}{((fd.Total - decimal.ToInt64(fd.Total)) * 100).ToString("00"),2};" +
                        $"{(fd.CodPract.Contains("420101") ? fd.BonoNumero > 0 ? 1 : 102 : fd.BonoNumero > 0 ? 5 : 101)};" +
                        $"{(fd.Medicamentos > 0 ? 50 : 2).ToString()};" +
                        $"{(!s.InternacionNumero.Equals("") ? s.InternacionNumero : "0")};";
                    
                    tw.WriteLine(linea);
                    linea = "";
                }

                tw.Close();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al generar el txt.\n{e.Message}", 1);
                return;
            }
        }


        //ENVIO DE MAILS
        private void IEnviarMail()
        {
            try
            {
                if (!Permisos.Where(w => w.Clave == "AmfactMail" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrls.MensajeInfo("No tiene acceso al envío de comprobantes por mail", 1);
                    return;
                }

                string mensaje = "";
                if (MailUnico) { mensaje = "éste comprobante"; }
                else { mensaje = "la lista completa de comprobantes"; }

                if (ctrls.MensajePregunta($"¿Está seguro de notificar {mensaje}?") != DialogResult.Yes) { return; }

                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                CantCopias = parametros.Cantidad;
                Incluyepaci = parametros.IncluirPacientes;
                Incluyefactura = parametros.IncluirFactura;

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                if (bgwEnviaMails.IsBusy) { bgwEnviaMails.CancelAsync(); }
                while (bgwEnviaMails.CancellationPending)
                { if (!bgwEnviaMails.CancellationPending) { break; } }

                bgwEnviaMails.RunWorkerAsync();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Error al enviar el mail.\n{e.Message}", 1);
                return;
            }
        }

        private void EnviarMail()
        {
            try
            {
                
                ComprobantesMails.Clear();

                if (MailUnico)
                {
                    Impresion.Facturas.Clear();
                    FacturaEnc p = gridView.GetRow(gridView.FocusedRowHandle) as FacturaEnc;
                    if (p != null && p.EstadoAf == "A")
                    {
                        p.Detalles.Clear();
                        p.Detalles.AddRange(FacturasDetalles.Where(w => w.IDEncabezado == p.IDRegistro));
                        
                        ComprobantesMails.Add(new Mailing
                        {
                            Adjunto = Impresion.GetComprobantesMS(p, CantCopias, Incluyepaci, Incluyefactura),
                            Comprobante = $"{p.ComprobanteCompleto} {p.Fecha.ToString("yyyy-MM-dd")}",
                            EmailReceptor = p.MailReceptorComprobante
                        });

                        func.EnviarEmail(ComprobantesMails);
                    }
                }
                else
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        Impresion.Facturas.Clear();
                        FacturaEnc p = gridView.GetRow(i) as FacturaEnc;
                        p.Detalles.Clear();
                        p.Detalles.AddRange(FacturasDetalles.Where(w => w.IDEncabezado == p.IDRegistro));
                        if (p != null && p.EstadoAf == "A")
                        {
                            ComprobantesMails.Add(new Mailing
                            {
                                Adjunto = Impresion.GetComprobantesMS(p, CantCopias, Incluyepaci, Incluyefactura),
                                Comprobante = $"{p.ComprobanteCompleto} {p.Fecha.ToString("yyyy-MM-dd")}",
                                EmailReceptor = p.MailReceptorComprobante
                            });
                        }                        
                    }

                    func.EnviarEmail(ComprobantesMails);
                }
                                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Hubo inconvenientes al generar el mail.", 1);
                return;
            }
        }

        private void FEnviarMail()
        {
            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            IBusqRegistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {            
            ConexionBD.Desconectar();
            SqlConnection.Dispose();
            ctrls.PreferencesGrid(this, gridView, "S");
            ctrls.PreferencesGrid(this, dockManager, "S");
        }


        //******************* EVENTOS BACKGROUND *************************
     
        private void bgwObtienereg_DoWork(object sender, DoWorkEventArgs e)
        {
            GetRegistros();            
        }

        private void bgwObtienereg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FBusqRegistros();
        }

        private void NavPanel_ElementClick(object sender, NavElementEventArgs e)
        {
            if (e.IsTile)
            {
                if (gridView.RowCount <= 0) { return; }
                NavPanel.HideDropDownWindow();
                switch (e.Element.Name)
                {
                    case "btnPrevisualizacion": PreparaImpresion(0) ; break;
                    case "btnPdf": ExportaWeb = false; PreparaImpresion(1); break;
                    case "btnExcel": ExportaExcel(); break;
                    case "btnExportacionweb": ExportaWeb = true; PreparaImpresion(1); break;
                    case "btnComprobanterel": GeneraComprobante(); break;
                }

                if (e.Element.Name == "btnComprobantecero") { GeneraComprobante(false); }
            }
        }

        private void bgwExportpdf_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportarPdf();
        }

        private void bgwExportpdf_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fexportapdf();
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            if (popupMenu.Visible) { popupMenu.HidePopup(); }

            try
            {
                _encabezado = gridView.GetRow(gridView.FocusedRowHandle) as FacturaEnc;
                UsrDetallesindividual.IDFactura = _encabezado != null ? _encabezado.IDRegistro : 0;
                UsrComprobantesrel.IDFactura = _encabezado != null ? _encabezado.IDRegistro : 0;
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al asignar los detalles de la factura.", 1);
            }

        }

        private void btnVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PreparaImpresion(0, true);
        }
        
        private void btnTxt_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraTextoFactura();
        }

        private void bgwEnviaMails_DoWork(object sender, DoWorkEventArgs e)
        {
            EnviarMail();
        }

        private void bgwEnviaMails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FEnviarMail();
        }

        private void btnNotificarpormail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MailUnico = true;
            IEnviarMail();
        }

        private void btnNotificarLista_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MailUnico = false;
            IEnviarMail();
        }

        private void btnTxtSN_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraTxtSanatorioNorte();
        }

        private void btnTxtFesalud_ElementClick(object sender, NavElementEventArgs e)
        {
            GeneraTxtFesalud();
        }
    }
    
}