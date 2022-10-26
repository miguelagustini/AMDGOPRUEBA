using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using AMDGOINT.Formularios.Informes;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils;
using DevExpress.XtraTab;

namespace AMDGOINT.Formularios.Retiros.Vista
{
    public partial class Frm_Retiro : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();

        public MC.Encabezado Encabezado { get; set; } = new MC.Encabezado();

        private MC.Retiros Retiro = new MC.Retiros();
        private List<Profesionales.MC.Cuentas> SaldosDisponibles { get; set; } = new List<Profesionales.MC.Cuentas>();
        private Profesionales.MC.Cuentas Cuentas = new Profesionales.MC.Cuentas();
        private List<Profesionales.MC.Cuentas> Cuentaslst = new List<Profesionales.MC.Cuentas>();
        private List<MC.Retiros> PagosImputados { get; set; } = new List<MC.Retiros>();
        private List<MC.RegistrosImportacion> RegistrosImportacion { get; set; } = new List<MC.RegistrosImportacion>();
        private List<MC.Concepto> Conceptos { get; set; } = new List<MC.Concepto>();
        private List<MC.Retiros> Retirostemporal { get; set; } = new List<MC.Retiros>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public bool Es_Popup { get; set; } = true;
        private Point LocationSplash = new Point();

        public Frm_Retiro()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            //DETERMINO LA POSICION DEL SPLASH
            screenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;
                        
        }

        #region METODOS MANUALES

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Cuentas.SqlConnection = SqlConnection;
            Encabezado.SqlConnection = SqlConnection;
            Retiro.SqlConnection = SqlConnection;

            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            SetBindings();
            CargaCombos();

            reposFecha.NullDate = DateTime.MinValue;
            reposFecha.NullText = string.Empty;

        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Retiros>(Encabezado.Detalles);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;
            }
        }

        //CARGA DE COMBOS
        private void CargaCombos(short cmb = 0, object search = null)
        {
            try
            {
                //CUENTAS DE PROFESIONAL
                if (cmb == 0 || cmb == 1)
                {
                    Cuentaslst.Clear();
                    Cuentaslst = Cuentas.GetCuentasactivas();
                    cmbCuentas.DataSource = Cuentaslst;
                }

                //PAGOS FORMA
                if (cmb == 0 || cmb == 2)
                {
                    MC.PagoForma pagoforma = new MC.PagoForma(SqlConnection);
                    cmbPagoForma.DataSource = pagoforma.GetRegistros();

                }

                //CONCEPTOS
                if (cmb == 0 || cmb == 3)
                {
                    Conceptos.Clear();
                    MC.Concepto concepto = new MC.Concepto(SqlConnection);
                    Conceptos = concepto.GetRegistros();
                    cmbConceptosretiro.DataSource = Conceptos;

                    if (search != null)
                    {
                        SearchLookUpEdit se = search as SearchLookUpEdit;
                        se.Properties.DataSource = Conceptos;
                    }

                }

                //LISTA DE EMPRESAS
                if (cmb == 0 || cmb == 4)
                {
                    Empresas.MC.Empresa empresa = new Empresas.MC.Empresa(SqlConnection);
                    List<Empresas.MC.Empresa> empresalst = empresa.GetRegistros();

                    cmbEmpresas.DataSource = empresalst;

                    if (search != null)
                    {
                        SearchLookUpEdit se = search as SearchLookUpEdit;
                        se.Properties.DataSource = empresalst;
                    }

                }

                //SALDOS DISPONIBLES
                if (cmb == 0 || cmb == 5)
                {
                    SaldosDisponibles.Clear();

                    Profesionales.MC.Cuentas cu = new Profesionales.MC.Cuentas(SqlConnection);
                    SaldosDisponibles.AddRange(cu.GetSaldodisponible());
                }

                //PAGOS IMPUTADOS
                if (cmb == 0 || cmb == 6)
                {
                    PagosImputados.Clear();
                    PagosImputados.AddRange(Retiro.GetPagosImputados());
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
                return;
            }
        }

        private void MuestraComprobante()
        {
            try
            {
                MC.Retiros _retitmp = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;

                if (_retitmp != null)
                {
                    if (_retitmp.TipoArchivo == ".pdf") { VisualizarComprobantepdf(_retitmp); }
                    else { VisualizarComprobantepdfImg(_retitmp); }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No se puede mostrar el comprobanbte.\n{e.Message}", 1);
                return;
            }
        }

        //VISUALIZA COMPROBANTE RETIRO
        private void VisualizarComprobantepdfImg(MC.Retiros _retiro)
        {
            try
            {
                Usr_Visualizador visualiza = new Usr_Visualizador();
                visualiza.Imagen = _retiro.Comprobante;
                XtraDialogForm form = new XtraDialogForm();
                form.Shown += form_Shown;
                form.ShowMessageBoxDialog(new XtraDialogArgs(this, visualiza, "Comprobante de retiro", new DialogResult[] { DialogResult.OK }, 0));

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No se puede mostrar el comprobanbte.\n{e.Message}", 1);
                return;
            }
        }

        //VISUALIZAR COMPROBANTE PDF
        private void VisualizarComprobantepdf(MC.Retiros _retiro)
        {
            try
            {
                Frm_Pdfviewer pd = new Frm_Pdfviewer();
                MemoryStream str = new MemoryStream(_retiro.Comprobante);
                pd.CargaVista(str);
                pd.ShowDialog();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un inconveniente al mostrar el presupuesto.\n {e.Message}", 0);
                return;
            }
        }

        //PARA MOSTRAR EL CUADRO DE AGRANDAR EN EL FORM DIALOG
        void form_Shown(object sender, EventArgs e)
        {
            XtraDialogForm frm = sender as XtraDialogForm;
            frm.IconOptions.Image = this.IconOptions.Image;
            frm.MaximizeBox = true;
            List<SimpleButton> btns = frm.Controls.OfType<SimpleButton>().ToList();
            foreach (SimpleButton btn in btns)
                btn.Anchor = AnchorStyles.Bottom;
            Control content = frm.Controls.OfType<Control>().Last();
            content.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
        }
               
        private void RetornaListaencarga2()
        {

            try
            {

                if (Retirostemporal.Count == gridView.RowCount) { return; }
                Retirostemporal.Clear();                
                if (gridView.RowCount <= 0) { return; }

                int index = gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle);

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetDataSourceRowIndex(i) != index && gridView.GetDataSourceRowIndex(i) >= 0) { Retirostemporal.Add(gridView.GetRow(i) as MC.Retiros); }
                }


                return;

            }
            catch (Exception)
            {
                return;
            }

        }

        //RETORNO EL SALDO DISPONIBLE DE LA CUENTA A CARGAR
        private decimal ImporteDisponible(int idctaasociado)
        {
            try
            {
                RetornaListaencarga2();
                decimal retorno = 0;

                //DE LISTA LOCAL
                decimal debitosimputados = Convert.ToDecimal(Retirostemporal?.Where(w => Cuentaslst.Where(w2 => w2.IDCuentaPrincipal == Cuentaslst.Where(w1 => w1.IDRegistro == idctaasociado).Select(s => s.IDCuentaPrincipal).First()
                                                                                                && w.TipoMovimiento == 1)
                                                                        .Select(s1 => s1.IDRegistro).ToList().Contains(w.IDCuentaAsociado)).Sum(s1 => s1.Importe));
                decimal creditosimputados = Convert.ToDecimal(Retirostemporal?.Where(w => Cuentaslst.Where(w2 => w2.IDCuentaPrincipal == Cuentaslst.Where(w1 => w1.IDRegistro == idctaasociado).Select(s => s.IDCuentaPrincipal).First()
                                                                                                && w.TipoMovimiento == 2)
                                                                        .Select(s1 => s1.IDRegistro).ToList().Contains(w.IDCuentaAsociado)).Sum(s1 => s1.Importe));

                //RESTO AL SALDO DISPONIBLE TODA LA LISTA DE IMPORTES REALIZADOS A LA CUENTA PRINCIPAL                
                retorno = SaldosDisponibles.Where(w => w.IDRegistro == idctaasociado).Select(s => s.SaldoDisponibleGeneral).FirstOrDefault() - //SALDO DISPONIBLE
                          PagosImputados.Where(w => w.IDCuentaAsociado == idctaasociado).Sum(s => s.Importe) - //PAGOS IMPUTADOS
                          debitosimputados + creditosimputados; //TOTAL DE LISTA LOCAL

                return retorno;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private decimal CalculaDisponibilidad(int idcuentasociado, decimal importe, byte tipomov)
        {
            try
            {
                decimal retorno = 0;

                //CREDITO A LA CUENTA
                if (tipomov == 2) { retorno = ImporteDisponible(idcuentasociado) + importe; }
                //DEBITO A LA CUENTA
                else { retorno = ImporteDisponible(idcuentasociado) - importe; }

                return retorno;
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("HUbo un inconveniente al calcular la disponibilidad.", 1);
                return 0;
            }
        }

        //MARCO REGISTRO PARA BORRAR
        private void MarcoRegistroborrado()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Eliminar éste movimiento?") != DialogResult.Yes) { return; }

                MC.Retiros _reti = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
                if (_reti == null) { return; }
                if (_reti.EnviadoDos)
                {   
                    ctrls.MensajeInfo("Éste retiro fue enviado a tesorería, no puede ser borrado.", 1);
                    return;
                }
                if (_reti.Estado > 0)
                {
                    ctrls.MensajeInfo("Éste retiro fue revisado por gerencia, no puede ser borrado.", 1);
                    return;
                }
                gridView.BeginDataUpdate();
                _reti.BorraRegistro = !_reti.BorraRegistro;
                gridView.EndDataUpdate();
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un inconveniente al procesar el borrado.", 1);
                return;
            }
        }

        //IMPORTAR PDF O IMAGEN
        private void ImportarArchivo()
        {
            try
            {
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Archivos Imagenes, PDF|*.JPEG;*.JPG;*.PNG;*.PDF";

                    //"Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF| All files (*.*)|*.*";

                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        FileInfo fi = new FileInfo(filePath);

                        gridView.BeginDataUpdate();
                        MC.Retiros _reti = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
                        if (_reti != null)
                        {
                            if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                            screenManager.SetWaitFormCaption("Agregando Comprobante");
                            screenManager.SetWaitFormDescription("");
                            byte[] contpdf = File.ReadAllBytes(filePath);
                            _reti.Comprobante = contpdf;
                            _reti.TipoArchivo = fi.Extension;
                            tmrInformacion.Start();
                        }
                        gridView.EndDataUpdate();


                    }
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente en la importación del archivo.\n{e.Message}" + e.Message, 0);
                return;
            }
        }

        //ELIMINO COMPROBANTE
        private void EliminarComprobante()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Quitar éste comprobante?") == DialogResult.Yes)
                { 
                    gridView.BeginDataUpdate();
                    MC.Retiros _reti = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
                    if (_reti != null)
                    {
                        if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
                        screenManager.SetWaitFormCaption("Comprobante removido");
                        screenManager.SetWaitFormDescription("");
                        _reti.Comprobante = null;
                        _reti.TipoArchivo = "";
                        tmrInformacion.Start();
                    }
                    gridView.EndDataUpdate();
                }

            }
            catch (Exception)
            {

            }
        }

        //DETERMINO ARCHIVO A IMPORTAR
        private void ImportaDetallesCuentas(short tagimport)
        {
            try
            {
                RegistrosImportacion.Clear();

                gridView.BeginDataUpdate();

                if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }

                switch (tagimport)
                {
                    case 1: Importacion(13); break; //IMPORTACION DE CUOTAS MEDICOS FESALUD
                    case 2: Importacion(136); break; //IMPORTACION DE CREDITOS MEDICOS 
                    case 3: ImportaCotasFsa(); break; //CUOTAS FONDO SOLIDARIO AUTOMOTOR
                    case 4: Importacion(0); break; //IMPORTACION DE BECARIO, INGRESOS BRUTOS E IMPUESTO GANANCIAS            
                    case 5: Importacion(146); break; //IMPORTACION CUOTAS JUBILACION CPAC
                }

                gridView.EndDataUpdate();

                if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al importar el archivo.\n{e.Message}", 1);
                return;
            }
        }

        //EJECUTA LA IMPORTACION DEL ARCHIVO SEELCCIOADO
        private void Importacion(short idconcepto)
        {
            try
            {
                Frm_Importacion frmimport = new Frm_Importacion();
                frmimport.SqlConnection = SqlConnection;
                if (frmimport.ShowDialog() == DialogResult.OK)
                { RegistrosImportacion.AddRange(frmimport.Registros); }
                else { frmimport.Dispose(); return; }

                foreach (MC.RegistrosImportacion registro in RegistrosImportacion)
                {
                    Encabezado.Detalles.Add(new MC.Retiros
                    {
                        IDEncabezado = Encabezado.IDRegistro,
                        IDConcepto = registro.IDConcepto, //idconcepto == 0 ? Conceptos.Where(w => w.Codigo == registro.RetiroCodigo).Select(s => s.IDRegistro).FirstOrDefault() : idconcepto,
                        IDCuentaAsociado = Cuentaslst.Where(w => w.Codigo == registro.CodigoCuenta).Select(s => s.IDRegistro).DefaultIfEmpty(0).FirstOrDefault(),
                        Importe = registro.Importe,
                        TipoMovimiento = registro.TipoMovimiento,
                        Observacion = registro.Observacion,
                        VencimientoUno = registro.Vencimiento,
                        IDPagoForma = registro.IDPagoForma,
                        IDEmpresa = registro.IDEmpresa
                    });
                }

                //BORRO LOS IMPORTADOS QUE NO TIENEN ASIGNADO UN ID DE ASOCIADO
                Encabezado.Detalles.RemoveAll(r => r.IDCuentaAsociado == 0);
              
                frmimport.Dispose();
            }
            catch (Exception)
            {
                return;
            }
        }

        //IMPORTO LAS CUOTAS DEL FONDO SOLIDARIO AUTOMOTOR
        private void ImportaCotasFsa()
        {
            try
            {

                string c = $"SELECT LTRIM(RTRIM(PE.CodFact)) AS CuentaCodigo, ISNULL(SUM(FA.Total),0) AS Total, FA.ID_Registro AS IDFactura" +
                            $" FROM AmdgoMutual.dbo.FACTURASENC FA" +
                            $" LEFT OUTER JOIN AmdgoMutual.dbo.PERSONAS PE ON(PE.ID_Registro = FA.ID_Persona)" +
                            $" WHERE PE.CodFact <> '' and FORMAT(FA.FechaEmision, 'yyyy-MM') = '{DateTime.Today.ToString("yyyy-MM")}'" +
                            $" AND FA.ID_Registro NOT IN(SELECT RD.IDFacturaFsa FROM AmdgoContable.dbo.rt_RETIRODETALLES RD)" +
                            $" AND FA.ID_Registro NOT IN (SELECT FR.ID_Factura FROM AmdgoMutual.dbo.FACTURASREL FR)" +
                            $" AND FA.Tipo <> 'NC' AND PE.ID_Grupo = 2" +
                            $" GROUP BY PE.CodFact, FA.ID_Registro";

                foreach (DataRow registro in func.getColecciondatos(c, SqlConnection).Rows)
                {
                    Encabezado.Detalles.Add(new MC.Retiros
                    {
                        IDEncabezado = Encabezado.IDRegistro,
                        IDConcepto = 170,
                        IDCuentaAsociado = Cuentaslst.Where(w => w.Codigo == registro["CuentaCodigo"].ToString()).Select(s => s.IDRegistro).DefaultIfEmpty(0).FirstOrDefault(),
                        Importe = Convert.ToDecimal(registro["Total"]),
                        TipoMovimiento = 1,
                        IDFacturaFsa = Convert.ToInt32(registro["IDFactura"])
                    });
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un error al obtener las cuotas del FSA.\n{e.Message}", 1);                
                return;
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
            
        }

        private void Frm_Retiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                gridView.AddNewRow();                
            }
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            cnb.Desconectar();
            SqlConnection.Dispose();
        }

        private void Frm_Retiro_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Parent is XtraTabPage)
            {
                XtraTabPage c = Parent as XtraTabPage;
                XtraTabControl x = c.Parent as XtraTabControl;
                x.TabPages.Remove(c);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (Encabezado.Detalles.Where(w => w.IDConcepto <= 0).Count() > 0)
            {
                ctrls.MensajeInfo("No puede guardar retiros sin concepto.", 1);
                return;
            }

            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Encabezado.Abm();

            if (retorno.Count > 0)
            {

                string mensajes = "";

                foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                {
                    mensajes += $"{i.Trim()}\n";
                }

                if (!string.IsNullOrWhiteSpace(mensajes))
                { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
                else { Continuacion(); }
            }
            else
            {
                Continuacion();
            }
        }

        #region GRILLAS
        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                MuestraComprobante();
            }
            else if (e.KeyCode == Keys.Delete && gridView.RowCount > 0)
            {                
                MarcoRegistroborrado();                                    
            }

        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridView.ActiveEditor is MemoEdit)
            {
                (gridView.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridView.ActiveEditor as MemoEdit).Paint += Form1_Paint;
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                MC.Retiros _reti = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
                if (_reti == null) { return; }

                if (e.Column == colIDRetiroconcepto)
                {
                    List<MC.Concepto> conceptolst = cmbConceptosretiro.DataSource as List<MC.Concepto>;
                    _reti.IDTipo = conceptolst.Where(w => w.IDRegistro == _reti.IDConcepto).Select(s => s.IDRetiroTipo).FirstOrDefault();
                }
                else if (e.Column == colIDCuentaprofesional)
                {
                    _reti.Disponibilidad = CalculaDisponibilidad(_reti.IDCuentaAsociado, _reti.Importe, _reti.TipoMovimiento);                    
                }
                else if (e.Column == colImporte || e.Column == colTipoMovimiento)
                {
                    _reti.Disponibilidad = CalculaDisponibilidad(_reti.IDCuentaAsociado, _reti.Importe, _reti.TipoMovimiento);
                }                
            }
            catch (Exception)
            {

            }            
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView v = gridView;
            GridColumn c = new GridColumn();

            MC.Retiros _reti = v.GetRow(v.FocusedRowHandle) as MC.Retiros;

            if (_reti != null)
            {
                string errorstring = "Debe completar el campo para continuar.";

                //ASOCIADO
                if (_reti.IDCuentaAsociado <= 0)
                { e.Valid = false; c = colIDCuentaprofesional; }

                //CONCEPTO
                if (_reti.IDConcepto <= 0)
                { e.Valid = false; c = colIDRetiroconcepto; }

                //IMPORTE
                if (_reti.Importe <= 0)
                { e.Valid = false; c = colImporte; }

                //IMPORTE DISPONIBLE              
                if (_reti.Disponibilidad < 0 && _reti.IDCuentaAsociado != 546 && _reti.IDCuentaAsociado != 547 && _reti.CobroForma == 0)
                { e.Valid = false; c = colImporte; errorstring = "El importe no puede ser superior al saldo disponible."; }

                if (!e.Valid) { v.SetColumnError(c, errorstring); }
            }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;            
        }

        private void gridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Importe")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }
        }

        private void gridView_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            MC.Retiros _reti = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
            if (_reti == null) { return; }
            if (_reti.EnviadoDos)
            {
                e.Allow = false;
                ctrls.MensajeInfo("Éste retiro fue enviado a tesorería, no puede ser modificado.", 1);
                return;
            }
            if (_reti.Estado > 0)
            {
                e.Allow = false;
                ctrls.MensajeInfo("Éste retiro fue revisado por gerencia, no puede ser modificado.", 1);
                return;
            }
            _reti.Disponibilidad = CalculaDisponibilidad(_reti.IDCuentaAsociado, _reti.Importe, _reti.TipoMovimiento);
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount > 0) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawFocusRectangle(e.Graphics, e.ClipRectangle);
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            if (sender is MemoEdit)
            {
                MemoEditViewInfo vi = (sender as MemoEdit).GetViewInfo() as MemoEditViewInfo;
                var cache = new GraphicsCache((sender as MemoEdit).CreateGraphics());
                int h = (vi as IHeightAdaptable).CalcHeight(cache, vi.MaskBoxRect.Width);
                var args = new ObjectInfoArgs();
                args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, h);
                var rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
                cache.Dispose();
                (sender as MemoEdit).Height = rect.Height;
            }
        }
        
        #endregion

        private void cmbButtons_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {

            if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Tag.ToString() == "Empresa")
            {
                Empresas.Vista.Frm_Empresa empresa = new Empresas.Vista.Frm_Empresa();
                empresa.SqlConnection = SqlConnection;

                if (empresa.ShowDialog(this) == DialogResult.OK)
                {
                    SearchLookUpEdit c = sender as SearchLookUpEdit;
                    CargaCombos(4, c);
                }
            }
            else if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Tag.ToString() == "Concepto")
            {
                Frm_Conceptos concepto = new Frm_Conceptos();
                concepto.SqlConnection = SqlConnection;

                if (concepto.ShowDialog(this) == DialogResult.OK)
                {
                    SearchLookUpEdit c = sender as SearchLookUpEdit;
                    CargaCombos(3, c);
                }
            }
        }
                
        private void combosRepository_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyData == Keys.Delete)
            {
                SearchLookUpEdit c = sender as SearchLookUpEdit;
                c.EditValue = 0;
                e.Handled = true;                
            }
        }
                
        private void btnAdjuntararchivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImportarArchivo();
        }

        private void tmrInformacion_Tick(object sender, EventArgs e)
        {
            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }
            tmrInformacion.Stop();
        }

        private void btnQuitararchivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EliminarComprobante();
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            MC.Retiros _reti = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;

            if (_reti != null)
            {
                btnQuitararchivo.Visibility = _reti.ExisteComprobante ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnVerComprobante.Visibility = _reti.ExisteComprobante ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btnVerComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestraComprobante();
        }
               
        private void NavBar_ElementClick(object sender, NavElementEventArgs e)
        {
            if (e.Element.Tag == null) { return; }
            
            ImportaDetallesCuentas(Convert.ToInt16(e.Element.Tag));

        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void reposDisponibilidad_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit t = sender as TextEdit;

                if (t.EditValue != null)
                {
                    if ((decimal)t.EditValue <= 0)
                    {
                        t.BackColor = Color.FromArgb(230, 57, 70);
                        t.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        t.BackColor = Color.Transparent;
                        t.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception)
            {
            }
            

          

        }
                        
    }
}

