using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Frm_Comprobante : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.ComprobanteEnc ComprobanteOriginal { get; set; } = new MC.ComprobanteEnc();
        public bool FromZero { get; set; } = false;

        private MC.ComprobanteEnc ComprobanteEmitir { get; set; } = new MC.ComprobanteEnc();
        private MC.Facturacion Facturacion { get; set; } = new MC.Facturacion();

        private List<Binding> Binding = new List<Binding>();
        private decimal sumaPiecol { get; set; } = 0;
        private Point LocationSplash = new Point();
        private bool ComprobanteGenerado = true;

        
        public Form FormularioPadre { get; set; } = new Form();

        public Frm_Comprobante()
        {
            InitializeComponent();

            coldtotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            coldNeto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            coldIva.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            reposFechas.NullDate = DateTime.MinValue;
            reposFechas.NullText = string.Empty;
            datFechaVto.Properties.NullDate = DateTime.MinValue;
            datFechaVto.Properties.NullText = string.Empty;
                        
        }

        #region Metodos Manuales

        private void HabilitaSelectores()
        {
            if (FromZero)
            {
                cmbPrestadora.Enabled = ComprobanteEmitir.PrestadoraCuentaID > 0 || ComprobanteEmitir.AsociadoCuentaID <= 0 ? true : false;
                cmbProfesional.Enabled = ComprobanteEmitir.AsociadoCuentaID > 0 || ComprobanteEmitir.PrestadoraCuentaID <= 0 ? true : false;
            }
            else
            {
                cmbPrestadora.Enabled = ComprobanteOriginal.PrestadoraCuentaID > 0 ? true : false;
                cmbProfesional.Enabled = ComprobanteOriginal.AsociadoCuentaID > 0 ? true : false;
            }
        }

        private void IniciaConexiones()
        {
            try
            {
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                ComprobanteOriginal.SqlConnection = SqlConnection;
                Facturacion.SqlConnection = SqlConnection;
            }
            catch (Exception)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al inciar las conexiones.", 1);
                return;
            }
        }

        private void CargaCombos(short cmb = 0)
        {
            try
            {
                if (cmb == 0 || cmb == 1) //PROFESIONAL
                {
                    string c = "SELECT PC.ID_Registro AS IDCuenta, PC.Codigo AS CodigoCuenta, PC.Descripcion as Profesional, PF.Cuit as Cuit, CD.Descripcion as Iva, PF.PuntoVenta," +
                               " CONCAT(PC.Codigo, ' ', PC.Descripcion) AS ProfesionalCompleto, PF.ID_Iva AS IDIva, PF.DomFiscal, CD.Abreviatura AS IvaAbreviado" +
                               " FROM PROFESIONALES PF" +
                               " LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PF.ID_Iva)" +
                               " WHERE PF.Estado = 1 and PC.Codigo is not null AND PF.Visible = 1" + //AND PF.PuntoVenta > 0
                               " ORDER BY PF.Nombre ASC";

                    DataTable dt = func.getColecciondatos(c, SqlConnection);

                    cmbProfesional.Properties.DataSource = dt;

                    cmbReposCuentasprof.BeginUpdate();
                    cmbReposCuentasprof.DataSource = dt;
                    cmbReposCuentasprof.EndUpdate();
                }

                if (cmb == 0 || cmb == 2) //PRESTATARIA
                {
                    string c = "SELECT PD.ID_Registro AS IDPrestatariaCuenta, PD.Codigo AS CodigoPlan, PD.Abreviatura, PR.Nombre as Prestataria, PR.Cuit, CD.Descripcion AS Iva," +
                               " CONCAT(PD.Codigo, ' ', PR.Nombre) AS PrestadoraCompleta, PR.DomicilioFiscal, PR.ID_Iva AS IDIva, PD.PorcIva, PR.MiPyme" +
                               " FROM PRESTATARIAS PR" +
                               " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Prestataria = PR.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                               " WHERE PD.ID_Registro IS NOT NULL AND PD.Visible = 1";

                    cmbPrestadora.Properties.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                if (cmb == 0 || cmb == 3) // TIPO DE COMPROBANTE
                {
                    cmbComprobante.Properties.Items.Clear();
                    cmbComprobante.Properties.Items.Add("FC");
                    cmbComprobante.Properties.Items.Add("NC");
                    cmbComprobante.Properties.Items.Add("ND");
                    cmbComprobante.Properties.Items.Add("FCE");
                    cmbComprobante.Properties.Items.Add("NCE");
                    cmbComprobante.Properties.Items.Add("NDE");
                }

                if (cmb == 0 || cmb == 4) //CONCEPTO
                {
                    string c = "SELECT IDRegistro, Concepto FROM CONCEPTOSCOMPROBANTES";

                    cmbConcepto.Properties.DataSource = func.getColecciondatos(c, SqlConnection);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void SetBindings()
        {
            try
            {
                ComprobanteEmitir = ComprobanteOriginal.Clone();
                ComprobanteEmitir.IDLocal = Guid.NewGuid().ToString();
                ComprobanteEmitir.ComprobantesRelacion.Clear();
                ComprobanteEmitir.ComprobanteLetra = ComprobanteOriginal.ComprobanteLetra != "" ? ComprobanteOriginal.ComprobanteLetra : "C";

                cmbProfesional.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.AsociadoCuentaID));
                cmbPrestadora.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.PrestadoraCuentaID));
                cmbComprobante.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.ComprobanteTipo));
                cmbConcepto.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.IDConcepto));
                txtPeriodo.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.Periodo));
                datFechaVto.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.ComprobanteFechaVtoPago));
                chkCompAnuladoPrest.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.ComprobanteAnuladoReceptor));
                tglLetraComprobante.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.ComprobanteLetra));

                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.ComprobanteDet>(ComprobanteEmitir.Detalles); ;
                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }

        //CAMBIO LOS DATOS DEL PROFESIONAL SEGUN SELECCION
        private void SetProfesionaldata()
        {
            try
            {
                int _id = 0;

                if (cmbProfesional.EditValue != null && int.TryParse(cmbProfesional.EditValue.ToString(), out _id))
                {                    
                    DataTable dt = cmbProfesional.Properties.DataSource as DataTable;

                    DataRow r = dt.Select("IDCuenta = " + _id).FirstOrDefault();
                    if (r != null)
                    {
                        ComprobanteEmitir.AsociadoCuentaCodigo = r["CodigoCuenta"].ToString().Trim();
                        ComprobanteEmitir.AsociadoCuit = Convert.ToInt64(r["Cuit"]);
                        ComprobanteEmitir.AsociadoIvaId = Convert.ToInt16(r["IDIva"]);                        
                        ComprobanteEmitir.AsociadoDomicilioFiscal = r["DomFiscal"].ToString().Trim();
                        ComprobanteEmitir.AsociadoRazonSocial = r["Profesional"].ToString().Trim();
                    }
                }
                else
                {
                    cmbProfesional.EditValue = ComprobanteOriginal.AsociadoCuentaID;
                }

                ctrl.RefrescarValorcontrols(Binding);                

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el profesional.\n{e.Message}", 1);
                return;
            }
        }

        //CAMBIO LOS DATOS DE PRESTADORA SEGUN SELECCION
        private void SetPrestadoradata()
        {
            try
            {
                int _id = 0;  

                if (cmbPrestadora.EditValue != null && int.TryParse(cmbPrestadora.EditValue.ToString(), out _id))
                {
                    DataTable dt = cmbPrestadora.Properties.DataSource as DataTable;
                    DataRow r = dt.Select("IDPrestatariaCuenta = " + _id).FirstOrDefault();
                    if (r != null)
                    {
                        ComprobanteEmitir.PrestadoraCuentaCodigo = r["CodigoPlan"].ToString().Trim();
                        ComprobanteEmitir.PrestadoraCuit = Convert.ToInt64(r["Cuit"]);
                        ComprobanteEmitir.PrestadoraIvaID = Convert.ToInt16(r["IDIva"]);
                        ComprobanteEmitir.PrestadoraDomicilioFiscal = r["DomicilioFiscal"].ToString().Trim();
                        ComprobanteEmitir.PrestadoraCuentaIvaPorcentaje = Convert.ToDecimal(r["PorcIva"]);
                        ComprobanteEmitir.PrestadoraRazonSocial = r["Prestataria"].ToString().Trim();
                        ComprobanteEmitir.PrestadoraMiPyme = Convert.ToBoolean(r["MiPyme"]);
                    }                    
                }
                else
                {
                    cmbPrestadora.EditValue = ComprobanteOriginal.PrestadoraCuentaID;
                }

                ctrl.RefrescarValorcontrols(Binding);                

            }
            catch (Exception)
            {

            }
        }
                
        //CALCULA LOS TOTALES
        private void CalculaTotalesItem()
        {
            try
            {
                MC.ComprobanteDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.ComprobanteDet;

                if (d == null) { return; }

                d.ImporteTotal = d.ImporteNeto + d.ImporteIva;
                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"No se pudo finalizar el calculo de totales.\n{e.Message}", 1);
                return;
            }
        }

        //MARCA SELECCION DE FILAS EN ORIGEN DATOS
        private void MarcaSeleccionado()
        {
            try
            {
                gridView.BeginDataUpdate();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    MC.ComprobanteDet d = gridView.GetRow(i) as MC.ComprobanteDet;
                    if (d != null) { d.Seleccionado = gridView.IsRowSelected(i); }                    
                }

                gridView.EndDataUpdate();

                CalculaTotalesEncabezado();
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        //TOTALIZO LOS DETALLES SELECCIONADOS EN EL ENCABEZADO
        private void CalculaTotalesEncabezado()
        {
            try
            {

                ComprobanteEmitir.ImporteHonorarios = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.ImporteHonorarios);
                ComprobanteEmitir.ImporteGastos = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.ImporteGastos);
                ComprobanteEmitir.ImporteNeto = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.ImporteNeto);
                ComprobanteEmitir.ImporteIva = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.ImporteIva);
                ComprobanteEmitir.ImporteTotal = ComprobanteEmitir.ImporteNeto + ComprobanteEmitir.ImporteIva;                                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"No se pudo calcular el total de la factura.\n{e.Message}", 1);
                return;
            }
        }

        //VALIDO EL CAMBIO DE TIPO COMPROIBANTE, SI ES NC  / ND, NO PUEDO CAMBIAR LOS DATOS DE FACTURACION
        private void ValidaTipoComprobante()
        {
            try
            {
                bool habilitaCambio = (cmbComprobante.SelectedItem.ToString() == "FC" || cmbComprobante.SelectedItem.ToString() == "FCE") || ComprobanteOriginal.IDRegistro <= 0 ? true : false;

                //SI SON NC O ND
                if (!habilitaCambio)
                {
                    ComprobanteEmitir.AsociadoCuentaID = ComprobanteOriginal.AsociadoCuentaID;
                    cmbProfesional.EditValue = ComprobanteOriginal.AsociadoCuentaID;
                    ComprobanteEmitir.AsociadoCuit = ComprobanteOriginal.AsociadoCuit;
                    ComprobanteEmitir.AsociadoDomicilioFiscal = ComprobanteOriginal.AsociadoDomicilioFiscal;
                    
                    ComprobanteEmitir.PrestadoraCuentaID = ComprobanteOriginal.PrestadoraCuentaID;
                    cmbPrestadora.EditValue = ComprobanteOriginal.PrestadoraCuentaID;
                    ComprobanteEmitir.PrestadoraCuit = ComprobanteOriginal.PrestadoraCuit;
                    ComprobanteEmitir.PrestadoraRazonSocial = ComprobanteOriginal.PrestadoraRazonSocial;
                    ComprobanteEmitir.PrestadoraDomicilioFiscal = ComprobanteOriginal.PrestadoraDomicilioFiscal;
                }

                cmbProfesional.Enabled = habilitaCambio;
                cmbPrestadora.Enabled = habilitaCambio;

                if (cmbComprobante.SelectedItem.ToString() == "NCE" || cmbComprobante.SelectedItem.ToString() == "NDE") { chkCompAnuladoPrest.Enabled = true; }
                else { chkCompAnuladoPrest.Enabled = false; }
                

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al validar el tipo de comprobante.\n{e.Message}", 1);
                return;
            }
        }

        //VALIDA PUNTO VENTA
        private void ValidaPuntoVenta()
        {
            try
            {
                if (cmbComprobante.Text == "FC" || cmbComprobante.Text == "NC" || cmbComprobante.Text == "ND")
                { ComprobanteEmitir.ComprobantePuntoVenta = 10; }
                else { ComprobanteEmitir.ComprobantePuntoVenta = 13; }

            }
            catch (Exception)
            {

            }
        }

        //INICIA EMISION FACTURA
        private void IEmiteFactura()
        {
            try
            {
                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                btnGenerar.Enabled = false;
                gridControl.Enabled = false;

                if (bgwEmiteFactura.IsBusy) { return; }
                bgwEmiteFactura.RunWorkerAsync();
            }
            catch (Exception)
            {
                gridControl.Enabled = true;
                btnGenerar.Enabled = true;
            }
        }

        //EMITE FACTURA
        private void EmitirFactura()
        {
            try
            {
                if (!ValidacionPreviaEmision())
                {
                    ComprobanteGenerado = false;
                    return;
                }

                PreparaComprobante();
                                
                GeneraComprobante();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir la factura.\n{e.Message}", 1);
                return;
            }
        }

        //FIN EMISION FACTURA
        private void FEmiteFactura()
        {
            try
            {
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }

                btnGenerar.Enabled = true;
                gridControl.Enabled = true;

                if (ComprobanteGenerado)
                {
                    if (ComprobanteEmitir.EstadoAf != "A")
                    {
                        ctrl.MensajeInfo("La factura no fue autorizada por AFIP, intente nuevamente", 1);
                    }
                    else
                    {
                        ImpresionComprobante();

                        if (FormularioPadre != null && FormularioPadre is Frm_Comprobantes)
                        {
                            Frm_Comprobantes f = FormularioPadre as Frm_Comprobantes;
                            f.LanzaActualizacion = !f.LanzaActualizacion;
                        }
                    }                    

                    Close();
                }
                else
                {
                    ComprobanteGenerado = true;
                }
            }
            catch (Exception)
            {
                Close();
            }            
            
        }

        //VALIDO SI LOS COMPROBANTES DE RELACION NO SUPERARON LA FACTURA ORIGINAL
        private bool PuedoAgregarComprobantes()
        {
            try
            {
                bool retorno = false;

                if ((ComprobanteOriginal.Total - ComprobanteOriginal.ComprobantesRelacion.Sum(s => s.TotalNC) + ComprobanteOriginal.ComprobantesRelacion.Sum(s => s.TotalND)) > 0) { retorno = true; }
                else { if (ComprobanteEmitir.ComprobanteTipo != "NC" && ComprobanteEmitir.ComprobanteTipo != "NCE") { retorno = true; } }

                return retorno;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al calcular el agregado de comprobantes.\n{e.Message}", 1);
                return false;
            }
        }

        //VALIDO ANTES DE EMITIR EL COMPROBANTE
        private bool ValidacionPreviaEmision()
        {
            try
            {                
                if (ComprobanteEmitir.AsociadoCuentaID <= 0 && ComprobanteEmitir.PrestadoraCuentaID <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin completar el receptor.", 1);
                    return false;
                }

                if (ComprobanteEmitir.IDConcepto <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin completar el concepto.", 1);
                    return false;
                }


                if (string.IsNullOrEmpty(ComprobanteEmitir.Periodo))
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin completar el periodo.", 1);
                    return false;
                }

                if (ComprobanteEmitir.ComprobanteFechaVtoPago <= DateTime.MinValue)
                {
                    ctrl.MensajeInfo($"No se puede emitir un comprobante sin vencimiento.", 1);
                    return false;
                }

                if (ComprobanteEmitir.ComprobanteFechaVtoPago <= DateTime.Today)
                {
                    ctrl.MensajeInfo($"No se puede emitir un comprobante con vencimiento a la misma fecha de emisión.", 1);
                    return false;
                }

                //TOTALES
                if (ComprobanteEmitir.Total <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante con importe total igual a cero (0).", 1);
                    return false;
                }

                if (ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Count() <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin detalles seleccionados.", 1);
                    return false;
                }

                if (ComprobanteEmitir.Detalles.Where(w => w.Seleccionado && w.Total <= 0).Count() > 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante con importe total de detalle en cero ($0).", 1);
                    return false;
                }


                if (ComprobanteEmitir.ComprobanteLetra == "X")
                {
                    if (ctrl.MensajePregunta("Está a punto de generar un comprobante X.\n¿Continuar?") != DialogResult.Yes) { return false; }
                }

                //NO PERMITO HACER NOTAS CREDITO SOBRE NOTAS CREDITO
                if (ComprobanteEmitir.TipoComprobante != "FC" && ComprobanteEmitir.TipoComprobante != "FCE" 
                    && ComprobanteOriginal.TipoComprobante != "FC" && ComprobanteOriginal.TipoComprobante != "FCE")
                {
                    ctrl.MensajeInfo($"No se puede generar un comprobante {ComprobanteEmitir.TipoComprobante}\n" +
                        $"en base a un comprobante {ComprobanteOriginal.TipoComprobante}.", 1);
                    return false;
                }

                //NO PERMITO SELECCIONAR PROFESIONAL Y PRESTADORA AL MISMO TIEMPO
                if (ComprobanteEmitir.AsociadoCuentaID > 0 && ComprobanteEmitir.PrestadoraCuentaID > 0)
                {
                    ctrl.MensajeInfo("Solo se pueden generar comprobantes a prestador o prestadora, no ambos al mismo tiempo.", 1);
                    return false;
                }                               

                //NOTAS DE CREDITO DEBITO
                if (ComprobanteEmitir.TipoComprobante != "FC" && ComprobanteEmitir.TipoComprobante != "FCE" )
                {

                    //ESTADO DEL COMPROBANTE ORIGINAL
                    if (ComprobanteOriginal.EstadoAf != "A")
                    {
                        ctrl.MensajeInfo("No se pueden asociar comprobantes de tipo débito / crédito a facturas rechazadas.", 1);
                        return false;
                    }

                    //LETRA DEL COMPROBANTE
                    if (ComprobanteOriginal.ComprobanteLetra == "X")
                    {
                        ctrl.MensajeInfo("No se pueden asociar comprobantes de tipo débito / crédito a facturas x.", 1);
                        return false;
                    }

                    if (ComprobanteOriginal.TipoComprobante == "FC" && ComprobanteEmitir.TipoComprobante != "NC" && ComprobanteEmitir.TipoComprobante != "ND")
                    {
                        ctrl.MensajeInfo($"Para comprobantes tipo FC, el comprobante a emitir no puede ser {ComprobanteEmitir.TipoComprobante}", 1);
                        return false;
                    }

                    if (ComprobanteOriginal.TipoComprobante == "FCE" && ComprobanteEmitir.TipoComprobante != "NCE" && ComprobanteEmitir.TipoComprobante != "NDE")
                    {
                        ctrl.MensajeInfo($"Para comprobantes tipo FCE, el comprobante a emitir no puede ser {ComprobanteEmitir.TipoComprobante}", 1);
                        return false;
                    }

                    if ((ComprobanteEmitir.PrestadoraCuentaID != ComprobanteOriginal.PrestadoraCuentaID || ComprobanteEmitir.AsociadoCuentaID != ComprobanteOriginal.AsociadoCuentaID))
                    {
                        ctrl.MensajeInfo("Para generar un comprobante tipo Debtio o Crédito, los encabezados deben ser iguales a la factura sobre la que se realiza.", 1);
                        return false;
                    }

                    if (!PuedoAgregarComprobantes())
                    {
                        ctrl.MensajeInfo("No se pueden anexar más comprobantes a la factura original.", 1);
                        return false;
                    }

                }

                decimal valmipyme = func.GetMinimoPyme(SqlConnection);

                //VALIDACIONES MI PYME
                if (ComprobanteEmitir.PrestadoraMiPyme && ComprobanteEmitir.ImporteTotal >= valmipyme && (ComprobanteEmitir.ComprobanteTipo == "FC" || ComprobanteEmitir.ComprobanteTipo == "ND"))
                {
                    ctrl.MensajeInfo($"El monto total supera el valor minimo establecido para comprobantes tipo {ComprobanteEmitir.ComprobanteTipo}", 1);
                    return false;
                }

                if (ComprobanteEmitir.PrestadoraMiPyme && ComprobanteEmitir.ImporteTotal <= valmipyme && (ComprobanteEmitir.ComprobanteTipo == "FCE" || ComprobanteEmitir.ComprobanteTipo == "NDE"))
                {
                    ctrl.MensajeInfo($"El monto total supera el valor minimo establecido para comprobantes tipo {ComprobanteEmitir.ComprobanteTipo}", 1);
                    return false;
                }

                if (ComprobanteOriginal.ComprobanteLetra == "X" && ComprobanteEmitir.ComprobanteLetra == "C")
                {
                    if (ctrl.MensajePregunta("Generará un comprobante FISCAL en base a un comprobante X.¿Está seguro de continuar?") != DialogResult.Yes)
                    {
                        return false;
                    }
                }
                                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //QUITA DATOS INECESARIOS COMPROBANTE A GENERAR
        private void PreparaComprobante()
        {
            try
            {
                
                //SI ES NC O ND
                if (ComprobanteEmitir.ComprobanteTipo != "FC" && ComprobanteEmitir.ComprobanteTipo != "FCE")
                {
                    MC.ComprobantesRel r = new MC.ComprobantesRel();
                    r.IDFactura = ComprobanteOriginal.IDRegistro;

                    ComprobanteEmitir.ComprobantesRelacion.Add(r);
                }

                //ASIGNO PUNTO DE VENTA CORRECTO
                ValidaPuntoVenta();

                ComprobanteEmitir.EstadoAfip = ComprobanteEmitir.ComprobanteLetra == "X" ? "A" : "";              
                

                //QUITO REGISTRO DE ENCABEZADO
                ComprobanteEmitir.IDRegistro = 0;

                //QUITO LOS DETALLES NO SELECCIONADOS
                ComprobanteEmitir.Detalles.RemoveAll(r => !r.Seleccionado);

                //QUITO LOS ID DE LOS REGISTROS A EMITIR
                ComprobanteEmitir.Detalles.ForEach(f => f.IDRegistro = 0);

                //SI TIPO COMPROBANTE NCE, FCE, NDE
                if (ComprobanteEmitir.ComprobanteTipo == "NDE" || ComprobanteEmitir.ComprobanteTipo == "NCE" || ComprobanteEmitir.ComprobanteTipo == "FCE")
                {
                    ComprobanteEmitir.EmisorAlias = func.GetAliascreditos(SqlConnection);
                    ComprobanteEmitir.EmisorCbu = func.GetCbucreditos(SqlConnection);
                }
                
                //FECHA DEL COMPROBANTE
                ComprobanteEmitir.ComprobanteFecha = DateTime.Today;
                ComprobanteEmitir.FechaDesde = DateTime.Today;
                ComprobanteEmitir.FechaHasta = DateTime.Today.AddDays(10);
                //ComprobanteEmitir.ComprobanteFechaVtoPago = ComprobanteEmitir.PrestadoraDiasVencimiento > 0 ? ComprobanteEmitir.ComprobanteFecha.AddDays(ComprobanteEmitir.PrestadoraDiasVencimiento) : ComprobanteEmitir.ComprobanteFecha.AddDays(10);                

                //RECALCULO TOTALES
                CalculaTotalesEncabezado();
            }
            catch (Exception)
            {
                ComprobanteGenerado = false;
                return;
            }
        }

        //GENERA COMPROBANTE
        private void GeneraComprobante()
        {
            try
            {
                Facturacion.Encabezados.Clear();
                Facturacion.Encabezados.Add(ComprobanteEmitir);

                Dictionary<short, string> retorno = new Dictionary<short, string>();

                retorno = Facturacion.GenerarFacturas(false);

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); ComprobanteGenerado = false; }
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al emitir la factura.\n{e.Message}", 1);
                ComprobanteGenerado = false;
                return;
            }
        }

        //PREPARO COMPROBANTE FACTURA
        private void ImpresionComprobante()
        {
            try
            {

                MC.Impresion Impresion = new MC.Impresion();
                List<MC.ComprobanteEnc> ListaPrint = new List<MC.ComprobanteEnc>();

                ListaPrint.Add(ComprobanteEmitir);
                
                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }                                                               
                                
                Impresion.Facturas = ListaPrint;

                Impresion.Imprimir(parametros.Cantidad, parametros.IncluirPacientes, parametros.IncluirDetalles, parametros.IncluirPrestador, parametros.IncluirLeyendaOriginal); 
                
                parametros.Dispose();

            }
            catch (Exception)
            {


            }
        }

        //CAMBIO DATOS SEGUN PROFESIONAL DETALLES
        private void SetProfesionaldatadetail()
        {
            try
            {               

                MC.ComprobanteDet det = gridView.GetRow(gridView.FocusedRowHandle) as MC.ComprobanteDet;

                if (det == null || det.PrestadorCuentaCodigo == "") { return; }

                if (det != null)
                {
                    DataTable dt = cmbReposCuentasprof.DataSource as DataTable;
                    if (dt.Rows.Count <= 0) { return; }

                    DataRow r = dt.Select("CodigoCuenta = " + det.PrestadorCuentaCodigo).FirstOrDefault();

                    if (r != null)
                    {
                        det.PrestadorIvaAbreviatura = r["IvaAbreviado"].ToString().Trim();
                        det.PrestadorNombre = r["Profesional"].ToString().Trim();
                    }
                }                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el profesional en detalles.\n{e.Message}", 1);
                return;
            }
        }

        //SELECTOR DE RECLAMOS
        private void SelectorReclamos()
        {
            try
            {
                if (ComprobanteOriginal.IDRegistro > 0)
                {
                    ctrl.MensajeInfo($"No se pueden anexar reclamos a un comprobante relacionado.", 1);
                    return;
                }

                if (ComprobanteEmitir.PrestadoraCuentaID <= 0)
                {                    
                    ctrl.MensajeInfo($"Debe seleccionar una prestataria para acceder a los reclamos.", 1);
                    return;
                }

                if (ComprobanteEmitir.TipoComprobante != "FC" && ComprobanteEmitir.TipoComprobante != "FCE")
                {
                    ctrl.MensajeInfo($"No se puede acceder a los reclamos con comprobantes que no sean FC o FCE.", 1);
                    return;
                }


                Frm_Reclamos frm = new Frm_Reclamos();
                frm.SqlConnection = SqlConnection;                
                frm.PrestatariaCuentaID = ComprobanteEmitir.PrestadoraCuentaID;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridView.BeginDataUpdate();

                    long docu = 0;

                    foreach (Reclamos.MC.ReclamosDet r in frm.Detalles.Where(w => w.Seleccionado))
                    {
                        MC.ComprobanteDet d = new MC.ComprobanteDet();
                        docu = 0;
                        long.TryParse(r.PacienteDocumento.Trim(), out docu);
                        d.Periodo = r.PeriodoFacturado;
                        d.Descripcion = r.FacturaProfesionalNew;
                        d.PacienteDocumento = docu;
                        d.PacienteNombre = r.PacienteNombre;
                        d.Cantidad = r.RecuperadoCantidad;
                        d.ImporteNeto = r.RecuperadoImporteNeto;
                        d.ImporteGastos = r.RecuperadoGastos;
                        d.ImporteHonorarios = r.RecuperadoHonorarios;
                        d.ImporteIva = r.RecuperadoImporteIva;
                        d.ImporteTotal = r.RecuperadoImporteTotal;
                        d.PracticaPunteroAsocTran = r.IDAsocTran;
                        d.PracticaOrigen = r.PeriodoFacturado.Length > 0 ? r.PeriodoFacturado.Substring(r.PeriodoFacturado.Length - 1) : "0";
                        d.PrestadorCuentaCodigo = r.ProfesionalCuentaCodigo;
                        d.PrestadorNombre = r.ProfesionalCuentaNombre;
                        d.DescripcionManual = r.PrestatariaExpediente != "" && r.PrestatariaLote != "" ? "Expediente: " + r.PrestatariaExpediente + " Lote: " + r.PrestatariaLote :
                            r.PrestatariaExpediente != "" && r.PrestatariaLote == "" ? "Expediente: " + r.PrestatariaExpediente :
                            r.PrestatariaExpediente == "" && r.PrestatariaLote != "" ? "Lote: " + r.PrestatariaLote : "";
                        //d.PrestadorIvaID = 0;
                        d.PracticaFecha = r.PracticaFecha;
                        d.PracticaCodigo = r.PracticaCodigo;
                        d.PracticaDescripcion = r.PracticaNombre;
                        d.IDReclamoDetalle = r.IDRegistro;

                        ComprobanteEmitir.Detalles.Add(d);
                    }

                    gridView.EndDataUpdate();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al seleccionar los reclamos pendientes.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        #endregion

        private void Frm_ComprobanteElectronico_Shown(object sender, EventArgs e)
        {
            IniciaConexiones();
            CargaCombos();
            SetBindings();
            HabilitaSelectores();
        }

        private void Frm_ComprobanteElectronico_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnb.Desconectar();            
        }

        private void Frm_ComprobanteElectronico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Parent is XtraTabPage)
            {
                XtraTabPage c = Parent as XtraTabPage;
                XtraTabControl x = c.Parent as XtraTabControl;
                x.TabPages.Remove(c);
            }
        }

        private void cmbProfesional_EditValueChanged(object sender, EventArgs e)
        {
            SetProfesionaldata();
        }

        private void cmbPrestadora_EditValueChanged(object sender, EventArgs e)
        {
            SetPrestadoradata();
        }

        #region GRILLA DETALLES

        private void gridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView v = gridView;
                GridColumn c = new GridColumn();

                MC.ComprobanteDet det = v.GetRow(v.FocusedRowHandle) as MC.ComprobanteDet;

                if (det != null)
                {
                    string errorstring = "Debe completar el campo para continuar.";

                    //CANTIDAD
                    if (det.Cantidad <= 0)
                    { e.Valid = false; c = coldCantidad; }
                    else if (det.ImporteNeto <= 0)//NETO
                    { e.Valid = false; c = coldNeto; }
                                        
                    if (!e.Valid) { v.SetColumnError(c, errorstring); }
                }

                SetProfesionaldatadetail();
                CalculaTotalesItem();
            }
            catch (Exception)
            {

            }
        }

        private void gridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

            if ((e.IsTotalSummary) &&
                    (((e.Item as GridSummaryItem).FieldName == coldNeto.FieldName)) ||
                    ((e.Item as GridSummaryItem).FieldName == coldtotal.FieldName) ||
                    ((e.Item as GridSummaryItem).FieldName == coldIva.FieldName))
            {
                GridSummaryItem item = e.Item as GridSummaryItem;

                switch (e.SummaryProcess)
                {
                    case DevExpress.Data.CustomSummaryProcess.Start:
                        sumaPiecol = 0;
                        break;

                    case DevExpress.Data.CustomSummaryProcess.Calculate:
                        if (Convert.ToBoolean(gridView.GetRowCellValue(e.RowHandle, colSeleccion)))
                        {
                            sumaPiecol += Convert.ToDecimal(e.FieldValue);
                        }
                        break;

                    case DevExpress.Data.CustomSummaryProcess.Finalize:
                        e.TotalValue = sumaPiecol;
                        break;
                }
            }
        }

        private void gridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column == coldtotal || e.Column == coldIva || e.Column == coldNeto )
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                decimal summaryvalue = Convert.ToDecimal(summary.SummaryValue);
                string summarytext = string.Format("{2:C2}", "", "", summaryvalue);
                e.Info.DisplayText = summarytext;
            }
        }

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            MarcaSeleccionado();
            gridView.UpdateTotalSummary();
        }

        private void reposTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ctrl.MensajePregunta("¿Está seguro de generar éste comprobante?") != DialogResult.Yes) { return; }

            IEmiteFactura();            
        }

        private void bgwEmiteFactura_DoWork(object sender, DoWorkEventArgs e)
        {
            EmitirFactura();
        }

        private void bgwEmiteFactura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FEmiteFactura();
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2) { gridView.AddNewRow(); }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (Convert.ToInt16(e.Button.Properties.Tag) == 0)
            {
                gridView.OptionsView.ColumnAutoWidth = !gridView.OptionsView.ColumnAutoWidth;
            }
            else if (Convert.ToInt16(e.Button.Properties.Tag) == 1) { SelectorReclamos(); }
        }

        private void cmbPrestadora_Validated(object sender, EventArgs e)
        {
            HabilitaSelectores();
        }

        private void cmbProfesional_Validated(object sender, EventArgs e)
        {
            HabilitaSelectores();
        }

        private void cmbComprobante_TextChanged(object sender, EventArgs e)
        {
            ValidaTipoComprobante();
        }

        private void cmbConcepto_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                Conceptos.Vista.Frm_Concepto frm = new Conceptos.Vista.Frm_Concepto();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargaCombos(4);
                }
            }
        }

        private void tglLetraComprobante_Toggled(object sender, EventArgs e)
        {
            //ComprobanteEmitir.ComprobanteLetra = tglLetraComprobante.EditValue.ToString();
        }

    }
}