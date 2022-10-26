using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Collections;
using AmdgoInterno.Afip;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using AMDGOINT.Datos;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Frm_PFacturaUnica : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private AfipProdDatos afip = new AfipProdDatos();
        private List<Prestata> prestataria = new List<Prestata>();
        private PrestFactura prestfactura = new PrestFactura();
        private Impresionglob impresionglo = new Impresionglob();
        private Reportes dsreportes = new Reportes();

        public bool Es_Popup { get; set; } = true;
        private long IDRegistro { get; set; } = 0;

        public Frm_PFacturaUnica()
        {
            InitializeComponent();
            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        #region METODOS MANUALES
        
        //COMBOS
        private void CargaCombos(short i = 0)
        {
            if (i == 0 || i == 1)
            {
                cmbTipo.Properties.Items.Clear();

                cmbTipo.Properties.Items.Add("FC");
                cmbTipo.Properties.Items.Add("NC");
                cmbTipo.Properties.Items.Add("ND");
                cmbTipo.Properties.Items.Add("FCE");
                cmbTipo.Properties.Items.Add("NCE");
                cmbTipo.Properties.Items.Add("NDE");

            }

            if (i == 0 || i == 2)
            {
                cmbPrestataria.Properties.DataSource = "";

                string c = "SELECT PD.ID_Registro, PD.ID_Prestataria, PD.Codigo, PD.Descripcion as Prestataria," +
                           " PR.DomicilioFiscal AS Domicilio, CD.Abreviatura as Iva, PR.Cuit, CD.ID_Registro as idiva" +
                           " FROM PRESTDETALLES PD" +
                           " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                           " WHERE PR.Estado = 1" +
                           " ORDER BY PD.Descripcion ASC";
                           

                cmbPrestataria.Properties.DataSource = func.getColecciondatos(c);
            }

        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                prop.RecuperaUbicacion(9, this);
            }

            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);

            datFecha.Text = func.Getfechorserver().ToString("dd/MM/yyyy");

            CargaCombos();

        }

        //CAMPOS DE LA TABLA FACTURA
        private ArrayList Camposfactambu()
        {

            ArrayList campos = new ArrayList();

            campos.Add("Fecha");
            campos.Add("TipoComprobante");
            campos.Add("Letra");
            campos.Add("PuntoVenta");
            campos.Add("Numero");
            campos.Add("ID_PrestDetalle");
            campos.Add("NombrePres");
            campos.Add("CuitPres");
            campos.Add("IvaPres");
            campos.Add("DomFiscalPres");
            campos.Add("Cbu");
            campos.Add("Alias");
            campos.Add("Neto");
            campos.Add("Total");
            campos.Add("FechaDesde");
            campos.Add("FechaHasta");
            campos.Add("FechaVtoPago");
            campos.Add("EstadoAf");
            campos.Add("CaeNroAf");
            campos.Add("BarrasAf");
            campos.Add("VtoCaeAf");
            campos.Add("ObservAf");
            campos.Add("Guid");
            campos.Add("ID_UsuNew");
            campos.Add("TimeNew");
            campos.Add("ID_UsuModif");
            campos.Add("TimeModif");

            return campos;
        }

        //ABM
        private void ABM()
        {
            try
            {
                if (!func.hayConexion())
                {
                    ctrls.MensajeInfo("La conexión a internet fue interrumpida.\nEl proceso debe ser retomado.", 1);
                    return;
                }

                string g = Guid.NewGuid().ToString();
                ArrayList campos = new ArrayList(Camposfactambu());
                ArrayList parametros = new ArrayList();

                DateTime fechahoy = func.Getfechorserver();
                DateTime fechavto = fechahoy;
                                
                long cuitr = 0;
                decimal total = Convert.ToDecimal(gridView.Columns.ColumnByName("colImporte").SummaryItem.SummaryValue);

                foreach (Prestata p in prestataria)
                {
                    cuitr = p.Cuit;
                }

                if (cmbTipo.Text == "FCE")
                {
                    fechavto = fechavto.AddDays(prestfactura.GetDiasvtoreceptor(cuitr.ToString()));

                    /*if (fechavto.Day < 1 || fechavto.Day > 10)
                    {
                        int dias = DateTime.DaysInMonth(fechavto.Year, fechavto.Month) - fechavto.Day;

                        fechavto = fechavto.AddDays(dias + 1);
                    }*/

                    if (cuitr == 30654855168)
                    {
                        fechavto = func.Trydatetimeconvert(prestfactura.Fechasvtowissmg(fechahoy, fechavto));
                    }
                }
                

                if (Procesoafip(cmbTipo.Text, cuitr, total, fechavto) < 0)
                {
                    ctrls.MensajeInfo("Hay inconvenientes de conexión con AFIP,\n" +
                               "toda la operación se interrumpirá para evitar errores.\n" +
                               "Intente nuevamente más tarde.", 1);
                    btnGenerar.Enabled = true;
                    return;
                }

                if (!afip.Estado)
                {
                    ctrls.MensajeInfo("El comprobante no puede ser emitido:\n" + afip.Observaciones, 1);
                    btnGenerar.Enabled = true;
                    return;
                }

                parametros.Add(Convert.ToDateTime(datFecha.Text));
                parametros.Add(cmbTipo.Text);
                parametros.Add("C");
                parametros.Add(Convert.ToInt32(cmbPventa.Text));
                parametros.Add(afip.Nrofactura);

                foreach (Prestata p in prestataria)
                {
                    parametros.Add(p.IDRegistro); //ID PRESTATARIA
                    parametros.Add(p.Nombre);
                    parametros.Add(p.Cuit);
                    parametros.Add(p.Iva);
                    parametros.Add(p.Domicilio);
                }

                if (cmbTipo.Text == "FCE" || cmbTipo.Text == "NCE" || cmbTipo.Text == "NDE")
                {
                    parametros.Add(prestfactura.GetCbucreditos());
                    parametros.Add(prestfactura.GetAliascreditos());
                    //fechavto = fechahoy.AddDays(prestfactura.GetDiasvtoreceptor(cuitr.ToString()));
                }
                else
                {
                    parametros.Add("");
                    parametros.Add("");
                }

                parametros.Add(total);
                parametros.Add(total);

                if (cmbTipo.Text == "FCE" || cmbTipo.Text == "NCE" || cmbTipo.Text == "NDE")
                {
                    parametros.Add(Convert.ToDateTime(datFecha.Text));
                    parametros.Add(Convert.ToDateTime(datFecha.Text));
                    parametros.Add(fechavto);
                }
                else
                {
                    parametros.Add(Convert.ToDateTime(datFecha.Text));
                    parametros.Add(Convert.ToDateTime(datFecha.Text));
                    parametros.Add(Convert.ToDateTime(datFecha.Text));
                }
                
                if (afip.Estado) { parametros.Add("A"); } else { parametros.Add("R"); }

                parametros.Add(afip.Caenumero);
                parametros.Add(afip.CodigoBarras);
                if (afip.Fechavtocae != null && afip.Fechavtocae != "" && afip.Estado)
                {
                    string date = "";
                    date = afip.Fechavtocae.Substring(0, 4) + "-" + afip.Fechavtocae.Substring(4, 2) + "-" + afip.Fechavtocae.Substring(6, 2);
                    parametros.Add(Convert.ToDateTime(date));
                }
                else { parametros.Add(DBNull.Value); }
                parametros.Add(afip.Observaciones);
                parametros.Add(g);
                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(fechahoy);
                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(fechahoy);

                func.AccionBD(campos, parametros, "I", "FACTPRESENC");

                IDRegistro = prestfactura.GetIdfactura(g);

                Altadetalles(g);

                if (cmbTipo.Text != "FC" && cmbTipo.Text != "FCE" && cmbTipo.Text != "")
                {
                    Altarelacionmanual();
                }

                Continuacion();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar la factura." + e.Message, 0);
                btnGenerar.Enabled = true;
                return;
            }

        }

        //CONTINUACION
        private void Continuacion()
        {
            if (afip.Estado)
            {
                impresionglo.Imprimirdetallado = true;
                impresionglo.IDRegistro = IDRegistro;
                impresionglo.datosrep = dsreportes;
                impresionglo.CargaDatosfcprestat();
                impresionglo.MuestraReporteFcprest();
            }            

            prestataria.Clear();
            txtNroComprob.Text = "";
            datFechafact.Text = "";
            btnGenerar.Enabled = true;
            DSDatos.FacturaDetalle.Clear();
            cmbPrestataria.EditValue = 0;
            cmbPrestataria.Focus();
            IDRegistro = 0;
        }

        //DETALLES DE FACTURA
        private void Altadetalles(string g)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();
                

                campos.Add("ID_Encabezado");
                campos.Add("Periodo");
                campos.Add("Descripcion");
                campos.Add("Cantidad");
                campos.Add("Neto");
                campos.Add("Total");
                campos.Add("Origen");
                campos.Add("Guid");

                foreach (DataRow r in DSDatos.FacturaDetalle.Rows)
                {
                    parametros.Clear();
                    parametros.Add(IDRegistro);
                    parametros.Add(r["Periodo"].ToString().Replace("/", ""));
                    parametros.Add(r["Descripcion"].ToString());
                    parametros.Add(1);
                    parametros.Add(Convert.ToDecimal(r["Importe"]));
                    parametros.Add(Convert.ToDecimal(r["Importe"]));
                    parametros.Add(r["Periodo"].ToString().Replace("/", "").Substring(6,1));
                    parametros.Add(g);

                    func.AccionBD(campos, parametros, "I", "FACTPRESDET");
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar los detalles." + e.Message, 0);
                return;
            }
        }

        //RELACION DE CREDITOS DEBITOS MANUALES
        private void Altarelacionmanual()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();
                string tipo = "FC";
                            
                campos.Add("ID_NotaCredito");
                campos.Add("ID_NotaDebito");
                campos.Add("ID_Factura");
                campos.Add("Comprobante");                
                
                parametros.Clear();

                if (cmbTipo.Text == "NCE" || cmbTipo.Text == "NC")
                {
                    parametros.Add(IDRegistro);
                    parametros.Add(0);
                }
                else
                {
                    parametros.Add(0);
                    parametros.Add(IDRegistro);                    
                }

                parametros.Add(0);

                if (cmbTipo.Text.ToString() == "NCE" || cmbTipo.Text.ToString() == "NDE")
                { tipo = "FCE"; }

                parametros.Add(tipo + " C " + Convert.ToInt32(cmbPventa.Text).ToString("0000") + "-" 
                    + Convert.ToInt64(txtNroComprob.Text).ToString("00000000"));

                func.AccionBD(campos, parametros, "I", "FACTPRESREL");

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar la relacion de comprobantes." + e.Message, 0);
                return;
            }
        }

        private sbyte Procesoafip(string tipo, long cuitrecep, decimal total, DateTime fechavto)
        {
            try
            {
                sbyte retorno = 1;                
                DateTime fecha = Convert.ToDateTime(datFecha.Text);

                //HAGO EL LOGIN 
                if (!func.LoginAfip(1, "30567506769", afipprod : afip))
                {
                    ctrls.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return -1;
                }
                                
                //CONCEPTO P2
                int concep = 2;                

                //OPCIONALES Y REFERENCIAS
                if (tipo == "NCE" || tipo == "NDE")
                {
                                        
                    afip.setOpcionales("","", "N");
                    
                    afip.setCompasociados("FCEC", Convert.ToInt32(cmbPventa.Text), Convert.ToInt64(txtNroComprob.Text),
                        "30567506769", Convert.ToDateTime(datFechafact.Text).ToString("yyyyMMdd"));
                }
                else if(tipo == "NC" || tipo == "ND")
                {
                    afip.setCompasociados("FCC", Convert.ToInt32(cmbPventa.Text), Convert.ToInt64(txtNroComprob.Text));
                }
                
                if (tipo == "FCE")
                {   
                    afip.setOpcionales(prestfactura.GetCbucreditos(), prestfactura.GetAliascreditos());
                    afip.setOpcionaltipotrans("SCA");
                }
                              
                afip.agregaFactura(1, func.Getfechorserver().ToString("yyyyMMdd"), Convert.ToInt32(cmbPventa.Text),
                "CUIT", cuitrecep, //ENCABEZADO
                concep, total, 0, total, 0, 0, 0, "pesos", 1, //IMPORTES
                fecha.ToString("yyyyMMdd"), fecha.AddDays(10).ToString("yyyyMMdd"), fechavto.ToString("yyyyMMdd"),
                tipo, "C");
                
                return retorno;
            }
            catch (Exception e)
            {
                int r = e.HResult;
                return -1;
            }
        }
               
        #endregion

        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            cmbTipo.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            prop.GuardarUbicacion(9, this);
        }

        private void cmbTipo_TextChanged(object sender, EventArgs e)
        {
            cmbPventa.Properties.Items.Clear();

            if (cmbTipo.Text == "FCE" || cmbTipo.Text == "NCE" || cmbTipo.Text == "NDE")
            {
                cmbPventa.Properties.Items.Add("13");
                cmbPventa.Text = "13";                                
            }
            else
            {
                cmbPventa.Properties.Items.Add("10");
                cmbPventa.Text = "10";
                
            }

            if (cmbTipo.Text == "NCE" || cmbTipo.Text == "NDE" || cmbTipo.Text == "NC" || cmbTipo.Text == "ND")
            {
                txtNroComprob.Enabled = true;
                txtNroComprob.Text = "0";
                datFechafact.Enabled = true;
                datFechafact.Text = "";
            }
            else
            {
                txtNroComprob.Enabled = false;
                txtNroComprob.Text = "";
                datFechafact.Enabled = false;
                datFechafact.Text = "";
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                gridView.AddNewRow();
            }
            else if (e.KeyData == Keys.F3)
            {
                if (gridView.RowCount <= 0) { return; }

                gridView.DeleteRow(gridView.FocusedRowHandle);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
                      
            if (datFecha.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar una fecha de comprobante para continuar.", 1);                
                return;
            }

            if (cmbTipo.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar un tipo de comprobante para continuar.", 1);
                cmbTipo.Focus();
                return;
            }

            if (cmbPventa.Text == "")
            {
                ctrls.MensajeInfo("Debe seleccionar un punto de venta para continuar.", 1);
                cmbPventa.Focus();
                return;
            }

            if ((cmbTipo.Text == "NCE" || cmbTipo.Text == "NDE" || cmbTipo.Text == "NC" || cmbTipo.Text == "ND")
                && (txtNroComprob.Text == "" || txtNroComprob.Text == "0"))
            {
                ctrls.MensajeInfo("Debe ingresar un número de comprobante de relación para continuar.", 1);
                txtNroComprob.Focus();
                return;
            }

            if ((cmbTipo.Text == "NCE" || cmbTipo.Text == "NDE" || cmbTipo.Text == "NC" || cmbTipo.Text == "ND")
                && datFechafact.Text == "")
            {
                ctrls.MensajeInfo("Debe ingresar una fecha de factura para continuar.", 1);
                datFechafact.Focus();
                return;
            }

            if (cmbPrestataria.EditValue == null || prestataria.Count <= 0)
            {
                ctrls.MensajeInfo("Debe seleccionar una prestataria para continuar.", 1);
                cmbPrestataria.Focus();
                return;
            }

            if (gridView.RowCount <= 0)
            {
                ctrls.MensajeInfo("Debe agregar al menos un detalle para continuar.", 1);
                return;
            }

            btnGenerar.Enabled = false;
            ABM();
        }

        private void cmbPrestataria_TextChanged(object sender, EventArgs e)
        {
            prestataria.Clear();

            if (cmbPrestataria.EditValue != null && cmbPrestataria.Properties.View != null)
            {
                DataTable dt = cmbPrestataria.Properties.DataSource as DataTable;

                foreach (DataRow r in dt.Select("ID_Registro = " + Convert.ToInt32(cmbPrestataria.EditValue)))
                {
                    prestataria.Add(new Prestata
                    {
                        IDRegistro = Convert.ToInt32(cmbPrestataria.EditValue),
                        Nombre = r["Prestataria"].ToString(),
                        Domicilio = r["Domicilio"].ToString(),
                        Cuit = Convert.ToInt64(r["Cuit"].ToString()),
                        Iva = Convert.ToInt16(r["idiva"].ToString())
                    });
                }
                
            }
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView v = sender as GridView;
            bool r = false;

            //PERIODO
            if (v.GetRowCellValue(e.RowHandle, colPeriodo) != null &&
                Convert.ToString(v.GetRowCellValue(e.RowHandle, colPeriodo)) != "") { r = true; }
            else { r = false; }

            //DESCRIPCION
            if (v.GetRowCellValue(e.RowHandle, colDescripcion) != null &&
                Convert.ToString(v.GetRowCellValue(e.RowHandle, colDescripcion)).Trim() != "") { r = true; }
            else { r = false; }

            //IMPORTE
            if (v.GetRowCellValue(e.RowHandle, colImporte) != null &&
                Convert.ToDecimal(v.GetRowCellValue(e.RowHandle, colImporte)) > 0) { r = true; }
            else { r = false; }

            if (!r)
            {                
                e.ErrorText = "Debe completar todos los campos para dar de alta el detalle.";
            }

            e.Valid = r;
        }
    }

    internal class Prestata
    {
        public long IDRegistro { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Domicilio { get; set; } = "";
        public long Cuit { get; set; } = 0;
        public short Iva { get; set; } = 0;

    }
}