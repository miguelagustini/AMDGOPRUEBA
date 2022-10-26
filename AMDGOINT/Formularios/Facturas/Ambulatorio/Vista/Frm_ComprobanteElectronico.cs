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

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Frm_ComprobanteElectronico : XtraForm
    {

        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public MC.FacturaEnc ComprobanteOriginal { get; set; } = new MC.FacturaEnc();        
        private MC.FacturaEnc ComprobanteEmitir { get; set; } = new MC.FacturaEnc();
        private MC.Facturacion Facturacion { get; set; } = new MC.Facturacion();

        private List<Binding> Binding = new List<Binding>();
        private decimal sumaPiecol { get; set; } = 0;
        private Point LocationSplash = new Point();
        private bool ComprobanteGenerado = true;

        public Form FormularioPadre { get; set; } = new Form();

        public Frm_ComprobanteElectronico()
        {
            InitializeComponent();

            coldtotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            coldNeto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            coldIva.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            coldNoGravado.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
        }

        #region Metodos Manuales

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
                    string c = "SELECT PC.ID_Registro AS IDCuenta, PC.Codigo AS CodigoCuenta, PF.Nombre as Profesional, PF.Cuit as Cuit, CD.Descripcion as Iva," +
                               " CONCAT(PC.Codigo, ' ', PF.Nombre) AS ProfesionalCompleto, PF.ID_Iva AS IDIva, PF.DomFiscal, PF.EmiteFCE, PF.CbuFCE, PF.AliasFCE, PF.CircuitoFCE," +
                               " IIF(PF.IDModoFacturacion = 1, PF.PuntoVenta, IIF(PF.IDModoFacturacion = 2, PC.PuntoVenta,0)) as PuntoVenta, PF.IDModoFacturacion, PF.ID_Registro AS IDProfesional" +
                               " FROM PROFESIONALES PF" +
                               " LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PF.ID_Iva)" +
                               " WHERE PF.Estado = 1 AND PC.Codigo IS NOT NULL AND PF.ID_Iva = 1 AND PF.Visible = 1" +
                               " ORDER BY PF.Nombre ASC";

                    cmbProfesional.Properties.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                if (cmb == 0 || cmb == 2) //PRESTATARIA
                {
                    string c = "SELECT PD.ID_Registro AS IDPrestatariaCuenta, PD.Codigo AS CodigoPlan, PD.Abreviatura, PR.Nombre as Prestataria, PR.Cuit, CD.Descripcion AS Iva," +
                               " CONCAT(PD.Codigo, ' ', PR.Nombre) AS PrestadoraCompleta, PR.DomicilioFiscal, PR.ID_Iva AS IDIva, PD.PorcIva, PR.MiPyme, PD.IDTipoPrestataria" +
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

                if (cmb == 0 || cmb == 4) //CONDICIONES DE IVA
                {
                    string c = "SELECT ID_Registro as IDRegistro, Descripcion, Abreviatura FROM CONDSIVA";
                    cmbIvaPrestador.Properties.DataSource = func.getColecciondatos(c, SqlConnection);
                    cmbIvaPrestataria.Properties.DataSource = func.getColecciondatos(c, SqlConnection);

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
                ComprobanteEmitir.ComprobantesRel.Clear();

                cmbProfesional.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.IDCuentaProf));
                cmbPrestadora.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.IDPrestDetalle));
                cmbComprobante.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.TipoComprobante));

                Binding.Add(txtCuitPrestador.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.CuitProf)));
                Binding.Add(txtPventa.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.PuntoVenta)));
                Binding.Add(txtCuitPrestadora.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.CuitPres)));
                Binding.Add(cmbIvaPrestador.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.IvaProf)));
                Binding.Add(cmbIvaPrestataria.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.IvaPres)));
                Binding.Add(txtIvaporc.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.PorcIvaPres)));
                Binding.Add(chkCompAnuladoPrest.DataBindings.Add("EditValue", ComprobanteEmitir, nameof(ComprobanteEmitir.ComprobanteAnuladoReceptor)));
                
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.FacturaDet>(ComprobanteEmitir.Detalles); ;
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
                        ComprobanteEmitir.IDCuentaProf = _id;
                        ComprobanteEmitir.CuitProf = Convert.ToInt64(r["Cuit"]);
                        ComprobanteEmitir.IvaProf = Convert.ToInt16(r["IDIva"]);
                        ComprobanteEmitir.PuntoVenta = Convert.ToInt32(r["PuntoVenta"]);
                        ComprobanteEmitir.DomFiscalProf = r["DomFiscal"].ToString().Trim();
                        ComprobanteEmitir.NombreProf = r["Profesional"].ToString().Trim();
                        ComprobanteEmitir.EmisorEmiteComprobanteFCE = Convert.ToBoolean(r["EmiteFCE"]);
                        ComprobanteEmitir.EmisorCbuComprobanteFCE = r["CbuFCE"].ToString();
                        ComprobanteEmitir.EmisorAliasComprobanteFCE = r["AliasFCE"].ToString();
                        ComprobanteEmitir.EmisorCircuitoComprobanteFCE = r["CircuitoFCE"].ToString();                        
                        ComprobanteEmitir.IDModoFacturacion = Convert.ToInt16(r["IDModoFacturacion"]);
                        ComprobanteEmitir.IDProfesional = Convert.ToInt16(r["IDProfesional"]);
                    }
                }
                else { cmbProfesional.EditValue = ComprobanteOriginal.IDCuentaProf; }

                AsignaPuntoVenta();
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
                        ComprobanteEmitir.IDPrestDetalle = _id;
                        ComprobanteEmitir.CuitPres = Convert.ToInt64(r["Cuit"]);
                        ComprobanteEmitir.IvaPres = Convert.ToInt16(r["IDIva"]);
                        ComprobanteEmitir.DomFiscalPres = r["DomicilioFiscal"].ToString().Trim();
                        ComprobanteEmitir.PorcIvaPres = Convert.ToDecimal(r["PorcIva"]);
                        ComprobanteEmitir.NombrePres = r["Prestataria"].ToString().Trim();
                        ComprobanteEmitir.IDTipoPrestataria = Convert.ToInt16(r["IDTipoPrestataria"]);
                    }

                }
                else { cmbPrestadora.EditValue = ComprobanteOriginal.IDPrestDetalle; }

                AsignaPuntoVenta();
                ctrl.RefrescarValorcontrols(Binding);
                
            }
            catch (Exception)
            {

            }
        }
                
        //ASIGNA PUNTO DE VENTA (MODO 3)
        private void AsignaPuntoVenta()
        {
            try
            {
                if (ComprobanteEmitir.IDProfesional <= 0 || ComprobanteEmitir.IDCuentaProf <= 0 || ComprobanteEmitir.IDPrestDetalle <= 0 || ComprobanteEmitir.IDModoFacturacion < 3) { return; }

                string c = $"SELECT ISNULL(PVT.PuntoVenta, 0) AS PuntoVenta" +
                           $" FROM PROFESIONALES PF" +
                           $" LEFT OUTER JOIN PROFPVTATIPOPRES PVT ON(PVT.IDProfesional = {ComprobanteEmitir.IDProfesional} AND PVT.TipoPrestataria = {ComprobanteEmitir.IDTipoPrestataria})" +
                           $" WHERE PF.ID_Registro = {ComprobanteEmitir.IDProfesional}";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    if (r["PuntoVenta"] != DBNull.Value) { ComprobanteEmitir.PuntoVenta = Convert.ToInt32(r["PuntoVenta"]); }
                }
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al asignar el punto de venta.{e.Message}", 1);
                return;
            }
        }

        //CALCULA LOS TOTALES
        private void CalculaTotalesItem()
        {
            try
            {
                MC.FacturaDet d = gridView.GetRow(gridView.FocusedRowHandle) as MC.FacturaDet;

                if (d == null) { return; }

                d.NoGravado = d.IvaPorc == 0 ? d.PrecioUnitario * d.Cantidad : 0;
                d.Neto = d.IvaPorc > 0 ? d.PrecioUnitario * d.Cantidad : 0;
                d.Iva = Math.Round(d.PrecioUnitario * (d.IvaPorc / 100) * d.Cantidad, 2);
                d.Total = d.Neto + d.Iva + d.NoGravado;
                                
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
                    MC.FacturaDet d = gridView.GetRow(i) as MC.FacturaDet;
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
                ComprobanteEmitir.NoGravado = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.NoGravado);
                ComprobanteEmitir.Neto105 = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado && w.IvaPorc == (decimal)10.5).Sum(s => s.Neto);
                ComprobanteEmitir.Neto21 = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado && w.IvaPorc == 21).Sum(s => s.Neto); ;
                ComprobanteEmitir.Neto = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.Neto);
                ComprobanteEmitir.Iva105 = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado && w.IvaPorc == (decimal)10.5).Sum(s => s.Iva);
                ComprobanteEmitir.Iva21 = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado && w.IvaPorc == 21).Sum(s => s.Iva);
                ComprobanteEmitir.Iva = ComprobanteEmitir.Detalles.Where(w => w.Seleccionado).Sum(s => s.Iva);

                ComprobanteEmitir.Total = ComprobanteEmitir.NoGravado + ComprobanteEmitir.Neto + ComprobanteEmitir.Iva;

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
                bool habilitaCambio = cmbComprobante.SelectedItem.ToString() == "FC" ? true : false;

                //SI SON NC O ND
                if (!habilitaCambio)
                {
                    ComprobanteEmitir.IDCuentaProf = ComprobanteOriginal.IDCuentaProf;
                    cmbProfesional.EditValue = ComprobanteOriginal.IDCuentaProf;

                    ComprobanteEmitir.IDPrestDetalle = ComprobanteOriginal.IDPrestDetalle;
                    cmbPrestadora.EditValue = ComprobanteOriginal.IDPrestDetalle;
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
                    ImpresionComprobante();

                    if (FormularioPadre != null && FormularioPadre is Frm_Facturas)
                    {
                        Frm_Facturas f = FormularioPadre as Frm_Facturas;
                        f.LanzaActualizacion = !f.LanzaActualizacion;
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

                decimal importeA = (ComprobanteOriginal.Total - ComprobanteOriginal.ComprobantesRel.Sum(s => s.TotalNC) + ComprobanteOriginal.ComprobantesRel.Sum(s => s.TotalND));
                decimal importeB = 0;

                if (ComprobanteEmitir.TipoComprobante == "NC" || ComprobanteEmitir.TipoComprobante == "NCE") { importeB = importeA - ComprobanteEmitir.Total; }
                else if(ComprobanteEmitir.TipoComprobante == "ND" || ComprobanteEmitir.TipoComprobante == "NDE") { importeB = importeA + ComprobanteEmitir.Total; }

                if (importeB >= (decimal)-0.50) { retorno = true; }

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
                if (ComprobanteEmitir.IDCuentaProf <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin un profesional.", 1);
                    return false;
                }

                if (ComprobanteEmitir.IDPrestDetalle <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin una prestadora.", 1);
                    return false;
                }

                if (ComprobanteEmitir.PuntoVenta <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un comprobante sin un punto de venta.", 1);
                    return false;
                }

                //NO PERMITO HACER NOTAS CREDITO SOBRE NOTAS CREDITO
                if (ComprobanteEmitir.TipoComprobante != "FC" && ComprobanteOriginal.TipoComprobante != "FC" 
                    && ComprobanteEmitir.TipoComprobante != "FCE" && ComprobanteOriginal.TipoComprobante != "FCE")
                {
                    ctrl.MensajeInfo($"No se puede generar un comprobante {ComprobanteEmitir.TipoComprobante}\n" +
                        $"en base a un comprobante {ComprobanteOriginal.TipoComprobante}.", 1);
                    return false;
                }

                if (!ComprobanteEmitir.EmisorEmiteComprobanteFCE && (ComprobanteEmitir.TipoComprobante == "FCE" || ComprobanteEmitir.TipoComprobante == "NCD" || ComprobanteEmitir.TipoComprobante == "NCE"))
                {
                    ctrl.MensajeInfo("Este prestador no emite facturas tipo MiPyme.", 1);
                    return false;
                }


                if (ComprobanteEmitir.EmisorEmiteComprobanteFCE &&  
                    (ComprobanteEmitir.TipoComprobante == "FCE" || ComprobanteEmitir.TipoComprobante == "NDE" || ComprobanteEmitir.TipoComprobante == "NCE") &&
                    (ComprobanteEmitir.EmisorCbuComprobanteFCE == "" || ComprobanteEmitir.EmisorCircuitoComprobanteFCE == ""))
                {
                    ctrl.MensajeInfo("Los datos CBU o Circuito no estan completos para la emisión\n de facturas tipo MiPyme.", 1);
                    return false;
                }

                //NOTAS DE CREDITO DEBITO
                if (ComprobanteEmitir.TipoComprobante != "FC" && ComprobanteEmitir.TipoComprobante != "FCE")
                {

                    if (ComprobanteEmitir.Detalles.Where(w => w.IDReclamoDetalle > 0).Count() > 0)
                    {
                        ctrl.MensajeInfo($"No se pueden generar reclamos para comprobantes {ComprobanteEmitir.TipoComprobante}", 1);
                        return false;
                    }

                    if (ComprobanteOriginal.EstadoAf != "A")
                    {
                        ctrl.MensajeInfo("No se pueden asociar comprobantes de tipo débito / crédito a facturas rechazadas.", 1);
                        return false;
                    }

                    if ((ComprobanteEmitir.IDPrestDetalle != ComprobanteOriginal.IDPrestDetalle || ComprobanteEmitir.IDCuentaProf != ComprobanteOriginal.IDCuentaProf))
                    {
                        ctrl.MensajeInfo("Para generar un comprobante tipo Debtio o Crédito, los encabezados deben ser iguales a la factura sobre la que se realiza.", 1);
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

                    if (!PuedoAgregarComprobantes())
                    {
                        ctrl.MensajeInfo("No se pueden anexar más comprobantes a la factura original.", 1);
                        return false;
                    }

                }

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

                //VALIDACIONES MIPYME
                decimal valmipyme = func.GetMinimoPyme(SqlConnection);

                if (ComprobanteEmitir.PresMiPyme && ComprobanteEmitir.Total >= valmipyme && (ComprobanteEmitir.TipoComprobante == "FC" || ComprobanteEmitir.TipoComprobante == "NDE"))
                {
                    ctrl.MensajeInfo($"El monto total supera el valor minimo establecido para comprobantes tipo {ComprobanteEmitir.TipoComprobante}", 1);
                    return false;
                }

                if (ComprobanteEmitir.PresMiPyme && ComprobanteEmitir.Total <= valmipyme && (ComprobanteEmitir.TipoComprobante == "FCE" || ComprobanteEmitir.TipoComprobante == "NDE"))
                {
                    ctrl.MensajeInfo($"El monto total supera el valor minimo establecido para comprobantes tipo {ComprobanteEmitir.TipoComprobante}", 1);
                    return false;
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
                if (ComprobanteEmitir.TipoComprobante != "FC")
                {
                    MC.ComprobantesRel r = new MC.ComprobantesRel();
                    r.IDFactura = ComprobanteOriginal.IDRegistro;

                    ComprobanteEmitir.ComprobantesRel.Add(r);
                }

                //GENERACION NO AUTOMATICA MENSUAL
                ComprobanteEmitir.GeneracionAutomatica = false;

                //DETERMINO LA LETRA DEL COMPROBANTE
                ComprobanteEmitir.SetLetra();                

                //QUITO REGISTRO DE ENCABEZADO
                ComprobanteEmitir.IDRegistro = 0;

                //QUITO LOS DETALLES NO SELECCIONADOS
                ComprobanteEmitir.Detalles.RemoveAll(r => !r.Seleccionado);

                //QUITO LOS ID DE LOS REGISTROS A EMITIR
                ComprobanteEmitir.Detalles.ForEach(f => f.IDRegistro = 0);

                //FECHA DEL COMPROBANTE
                ComprobanteEmitir.Fecha = DateTime.Today;
                ComprobanteEmitir.FechaDesde = DateTime.Today;
                ComprobanteEmitir.FechaHasta = DateTime.Today.AddDays(10);
                ComprobanteEmitir.FechaVto = DateTime.Today.AddDays(10);

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
                List<MC.FacturaEnc> ListaPrint = new List<MC.FacturaEnc>();

                ListaPrint.Add(ComprobanteEmitir);
                
                Usr_PrintParams parametros = new Usr_PrintParams();

                if (XtraDialog.Show(parametros, "Parámetros de impresión", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }

                if (parametros.Cantidad <= 0 || parametros.Cantidad > 4) { return; }
                                
                Impresion.Facturas = ListaPrint;
                Impresion.Imprimir(parametros.Cantidad, parametros.IncluirPacientes, parametros.IncluirFactura); 
                
                parametros.Dispose();

            }
            catch (Exception)
            {


            }
        }

        //SELECTOR DE RECLAMOS
        private void SelectorReclamos()
        {
            try
            {
                if (ComprobanteEmitir.IDCuentaProf <= 0 || ComprobanteEmitir.IDPrestDetalle <= 0)
                {
                    string p = ComprobanteEmitir.IDCuentaProf <= 0 ? "un prestador" : "una prestataria";
                    ctrl.MensajeInfo($"Debe seleccionar {p} para acceder a los reclamos.", 1);
                    return;
                }

                if (ComprobanteEmitir.TipoComprobante != "FC" && ComprobanteEmitir.TipoComprobante != "FCE")
                {
                    ctrl.MensajeInfo($"No se puede acceder a los reclamos con comprobantes que no sean FC o FCE.", 1);
                    return;
                }


                Frm_Reclamos frm = new Frm_Reclamos();
                frm.SqlConnection = SqlConnection;
                frm.PrestadorCuentaID = ComprobanteEmitir.IDCuentaProf;
                frm.PrestatariaCuentaID = ComprobanteEmitir.IDPrestDetalle;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridView.BeginDataUpdate();

                    long docu = 0;
                    foreach (Reclamos.MC.ReclamosDet r in frm.Detalles.Where(w => w.Seleccionado))
                    {
                        MC.FacturaDet d = new MC.FacturaDet();
                        docu = 0;
                        d.IDReclamoDetalle = r.IDRegistro;
                        long.TryParse(r.PacienteDocumento.Trim(), out docu);
                        d.FechaPract = r.PracticaFecha;
                        d.CodPract = r.PracticaCodigo;
                        d.DescrPract = r.PracticaNombre;
                        d.Funcion = r.PracticaFuncion;
                        d.DocuPaci = docu;
                        d.NombrePaci = r.PacienteNombre;
                        d.Puntero = r.IDAsocTran;
                        d.IvaPorc = r.RecuperadoIvaPorcentaje;
                        d.Cantidad = r.RecuperadoCantidad;
                        d.PrecioUnitario = r.RecuperadoCantidad > 0 ? Math.Round(r.RecuperadoImporteNeto / r.RecuperadoCantidad, 2) : r.RecuperadoImporteNeto;
                        d.Honorarios = r.RecuperadoHonorarios;
                        d.Gastos = r.RecuperadoGastos;
                        d.Medicamentos = r.RecuperadoMedicamentos;
                        d.Neto = d.IvaPorc > 0 ? r.RecuperadoImporteNeto : 0;
                        d.NoGravado = d.IvaPorc <= 0 ? r.RecuperadoImporteNeto : 0;
                        d.Iva = r.RecuperadoImporteIva;
                        d.Total = r.RecuperadoImporteTotal;

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
            CalculaTotalesItem();
        }

        private void gridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

            if ((e.IsTotalSummary) &&
                    (((e.Item as GridSummaryItem).FieldName == coldNeto.FieldName)) ||
                    ((e.Item as GridSummaryItem).FieldName == coldtotal.FieldName) ||
                    ((e.Item as GridSummaryItem).FieldName == coldIva.FieldName) ||
                    ((e.Item as GridSummaryItem).FieldName == coldNoGravado.FieldName)
                    )
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

        private void gridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column == coldtotal || e.Column == coldIva || e.Column == coldNeto || e.Column == coldNoGravado)
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

        private void cmbComprobante_SelectedValueChanged(object sender, EventArgs e)
        {
            ValidaTipoComprobante();
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

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Tag?.ToString() == "RECLAMOS") { SelectorReclamos(); }
        }
    }
}