using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Collections;
using AmdgoInterno.Afip;
using System.Collections.Generic;
using System.Data;
using AMDGOINT.Datos;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    public partial class Frm_FacturaUnica : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        //private AfipDatosHomo afiphomo = new AfipDatosHomo();
        private AfipProdDatos afipPROD = new AfipProdDatos();
        private List<Prestata> prestataria = new List<Prestata>();
        private List<Prestador> prestador = new List<Prestador>();
        private Impresionglob impresionglo = new Impresionglob();
        private Reportes dsreportes = new Reportes();
        private FacturasClass factambu = new FacturasClass();

        public bool Es_Popup { get; set; } = true;
        private long IDRegistro { get; set; } = 0;
        private decimal Iva105 { get; set; } = 0;
        private decimal Iva21 { get; set; } = 0;


        public Frm_FacturaUnica()
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
                
                cmbTipo.Properties.Items.Add("NC");
                cmbTipo.Properties.Items.Add("ND");

                cmbTipo.Text = "NC";
            }

            if (i == 0 || i == 2)
            {
                cmbPrestataria.Properties.DataSource = "";

                string c = "SELECT PD.ID_Registro, PD.ID_Prestataria, PD.Codigo, PD.Descripcion as Prestataria," +
                           " PR.DomicilioFiscal AS Domicilio, CD.Abreviatura as Iva, PR.Cuit, CD.ID_Registro as idiva," +
                           " PD.PorcIva" +
                           " FROM PRESTDETALLES PD" +
                           " LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                           " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                           " ORDER BY PD.Descripcion ASC";

                cmbPrestataria.Properties.DataSource = func.getColecciondatos(c);
            }

            if (i == 0 || i == 3)
            {
                cmbPrestador.Properties.DataSource = "";

                string c = "SELECT PD.ID_Registro, PD.Codigo, PD.Nombre as Prestador," +
                           " PD.DomFiscal, CD.Abreviatura as Iva, PD.Cuit, CD.ID_Registro as idiva," +
                           " PD.PuntoVenta" +
                           " FROM PROFESIONALES PD" +                           
                           " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PD.ID_Iva)" +
                           " WHERE PD.PuntoVenta > 0" +
                           " ORDER BY PD.Nombre ASC";

                cmbPrestador.Properties.DataSource = func.getColecciondatos(c);
            }

        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                prop.RecuperaUbicacion(10, this);
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
            campos.Add("ID_Profesional");
            campos.Add("NombreProf");
            campos.Add("CuitProf");
            campos.Add("IvaProf");
            campos.Add("DomFiscalProf");
            campos.Add("ID_PrestDetalle");
            campos.Add("NombrePres");
            campos.Add("CuitPres");
            campos.Add("IvaPres");
            campos.Add("PorcIvaPres");
            campos.Add("DomFiscalPres");
            campos.Add("Guid");
            campos.Add("Neto");
            campos.Add("Neto21");
            campos.Add("Neto105");
            campos.Add("NoGravado");
            campos.Add("Iva");
            campos.Add("Iva21");
            campos.Add("Iva105");
            campos.Add("Total");
            campos.Add("FechaDesde");
            campos.Add("FechaHasta");
            campos.Add("EstadoAf");
            campos.Add("CaeNroAf");
            campos.Add("BarrasAf");
            campos.Add("VtoCaeAf");
            campos.Add("ObservAf");            
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

                if (prestataria == null || prestataria.Count <= 0) { return; }
                if (prestador == null || prestador.Count <= 0) { return; }

                string g = Guid.NewGuid().ToString();
                ArrayList campos = new ArrayList(Camposfactambu());
                ArrayList parametros = new ArrayList();

                string let = func.GetLetracomprob(prestador[0].Iva, prestataria[0].Iva, 0, false);
                DateTime fechahoy = func.Getfechorserver();
                
                if (Procesoafip(let) < 0)
                {
                    ctrls.MensajeInfo("Hay inconvenientes de conexión con AFIP,\n" +
                               "toda la operación se interrumpirá para evitar errores.\n" +
                               "Intente nuevamente más tarde.", 1);
                    btnGenerar.Enabled = true;
                    return;
                }

                if (!afipPROD.Estado)
                {
                    ctrls.MensajeInfo("El comprobante fue rechazado por AFIP.\n" +
                        afipPROD.Observaciones, 1);
                    btnGenerar.Enabled = true;
                    return;
                }
                
                parametros.Add(Convert.ToDateTime(datFecha.Text));
                parametros.Add(cmbTipo.Text);
                parametros.Add(let);
                parametros.Add(Convert.ToInt32(txtPventa.Text));
                parametros.Add(afipPROD.Nrofactura);
                parametros.Add(prestador[0].IDRegistro);
                parametros.Add(prestador[0].Nombre);
                parametros.Add(prestador[0].Cuit);
                parametros.Add(prestador[0].Iva);
                parametros.Add(prestador[0].Domicilio);
                parametros.Add(prestataria[0].IDRegistro);
                parametros.Add(prestataria[0].Nombre);
                parametros.Add(prestataria[0].Cuit);
                parametros.Add(prestataria[0].Iva);
                parametros.Add(prestataria[0].PorcIva);
                parametros.Add(prestataria[0].Domicilio);
                parametros.Add(g);

                decimal neto105 = (Convert.ToDecimal(txtNeto105.Text));
                decimal neto21 = (Convert.ToDecimal(txtNeto21.Text));
                decimal neto = neto21 + neto105 + Convert.ToDecimal(txtNogravado.Text);
                decimal ivas = Iva21 + Iva105;

                parametros.Add(Convert.ToDecimal(neto.ToString("0.00"))); //NETO TOT (21 + 105 + NG)
                parametros.Add(Convert.ToDecimal(neto21.ToString("0.00"))); //NETO21
                parametros.Add(Convert.ToDecimal(neto105.ToString("0.00"))); //NETO105
                parametros.Add(Convert.ToDecimal(txtNogravado.Text)); //NO GRAVADO
                parametros.Add(Convert.ToDecimal(ivas.ToString("0.00"))); //IVA TOT (21 +105)
                parametros.Add(Iva21); //IVA21
                parametros.Add(Iva105); //IVA105
                parametros.Add(Convert.ToDecimal(lblTotal.Text)); //TOTAL (IVA + NETO)
                parametros.Add(Convert.ToDateTime(datFecha.Text));
                parametros.Add(Convert.ToDateTime(datFecha.Text));

                parametros.Add("A");
                parametros.Add(afipPROD.Caenumero);
                parametros.Add(afipPROD.CodigoBarras);

                if (afipPROD.Fechavtocae != null && afipPROD.Fechavtocae != "" && afipPROD.Estado)
                {
                    string date = "";
                    date = afipPROD.Fechavtocae.Substring(0, 4) + "-" +
                        afipPROD.Fechavtocae.Substring(4, 2) + "-" +
                        afipPROD.Fechavtocae.Substring(6, 2);
                    parametros.Add(Convert.ToDateTime(date));
                }
                else { parametros.Add(DBNull.Value); }
                
                parametros.Add(afipPROD.Observaciones);
                
                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(fechahoy);
                parametros.Add(glob.GetIdUsuariolog());
                parametros.Add(fechahoy);

                func.AccionBD(campos, parametros, "I", "FACTAMBUENC");

                IDRegistro = factambu.GetIdfactura(g);

                GuardorelacionNC();

                Continuacion();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar la factura." + e.Message, 0);
                btnGenerar.Enabled = true;
                return;
            }

        }

        private void GuardorelacionNC()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("ID_NotaCredito");
                campos.Add("ID_NotaDebito");
                campos.Add("Comprobante");

                if (cmbTipo.Text.ToString().ToUpper() == "NC")
                {
                    parametros.Add(IDRegistro);
                    parametros.Add(0);
                }
                else if (cmbTipo.Text.ToString().ToUpper() == "ND")
                {
                    parametros.Add(0);
                    parametros.Add(IDRegistro);                    
                }
                parametros.Add("FC " + txtLetra.Text + " " + Convert.ToInt32(txtPventa.Text).ToString("0000") + "-" +
                    Convert.ToInt64(txtNroasoc.Text).ToString("00000000"));

                func.AccionBD(campos, parametros, "I", "FACTAMBUREL");

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar la relacion de comprobantes.\n" + e.Message, 0);
                return;
            }
        }

        //CONTINUACION
        private void Continuacion()
        {
            if (afipPROD.Estado)
            {
                impresionglo.IDRegistro = IDRegistro;
                impresionglo.datosrep = dsreportes;
                impresionglo.CargaDatosfcambu();
                impresionglo.MuestraReporte();
            }            

            prestataria.Clear();
            prestador.Clear();

            btnGenerar.Enabled = true;
            DSDatos.FacturaDetalle.Clear();
            cmbPrestataria.EditValue = 0;
            cmbPrestador.EditValue = 0;
            txtLetra.Text = "";
            txtPventa.Text = "";
            txtNroasoc.Text = "";
            txtNeto105.Text = "0,00";
            txtNeto21.Text = "0,00";
            txtNogravado.Text = "0,00";
            IDRegistro = 0;
        }
               
        private sbyte Procesoafip(string letra)
        {
            try
            {
                sbyte retorno = 1;

                //HAGO EL LOGIN HOMOLOG
                if (!func.LoginAfip(1, prestador[0].Cuit.ToString(), afipprod: afipPROD))
                {
                    ctrls.MensajeInfo("No logramos acceder al servidor de AFIP.", 1);
                    return -1;
                }
                                
                //CONCEPTO P2
                int concep = 2;
                string tipo = cmbTipo.Text;

                decimal neto21 = (Convert.ToDecimal(txtNeto21.Text));
                decimal neto105 = (Convert.ToDecimal(txtNeto105.Text));
                decimal neto = neto105 + neto21;
                decimal iva = Convert.ToDecimal(Iva21.ToString("0.00")) + Convert.ToDecimal(Iva105.ToString("0.00"));
                decimal nogra = Convert.ToDecimal(txtNogravado.Text);
                decimal total = Convert.ToDecimal(lblTotal.Text);

                afipPROD.setCompasociados("FC" + txtLetra.Text, Convert.ToInt32(txtPvtaasoc.Text), Convert.ToInt64(txtNroasoc.Text));

                if (Iva105 > 0) { afipPROD.setIva(4, Convert.ToDecimal(neto105.ToString("0.00")), Convert.ToDecimal(Iva105.ToString("0.00"))); }
                if (Iva21 > 0) { afipPROD.setIva(5, Convert.ToDecimal(neto21.ToString("0.00")), Convert.ToDecimal(Iva21.ToString("0.00"))); }

                DateTime fecha = Convert.ToDateTime(datFecha.Text);

                afipPROD.agregaFactura(1, func.Getfechorserver().ToString("yyyyMMdd"), prestador[0].PuntoVenta,
                    "CUIT", prestataria[0].Cuit, //ENCABEZADO
                concep, neto, iva, total, nogra, 0, 0, "pesos", 1, //IMPORTES
                fecha.ToString("yyyyMMdd"), fecha.ToString("yyyyMMdd"), fecha.AddDays(0).ToString("yyyyMMdd"),
                tipo, letra);

                return retorno;
            }
            catch (Exception e)
            {
                int r = e.HResult;
                return -1;
            }
        }

        //CALCULA IMPORTES
        private void CalculaImportes()
        {
            try
            {
                decimal neto105 = 0;
                decimal neto21 = 0;
                decimal netonog = 0;

                if (txtNeto105.Text != "" && txtNeto105.Text != "0,00")
                {
                    neto105 = Convert.ToDecimal(txtNeto105.Text);
                    Iva105 = neto105 * (Convert.ToDecimal(10.5) / 100);
                    decimal calc = Iva105;                    
                    txtSubt105.Text = calc.ToString("0.00");
                }
                else
                {
                    txtSubt105.Text = "0,00";
                }

                if (txtNeto21.Text != "" && txtNeto21.Text != "0,00")
                {
                    neto21 = Convert.ToDecimal(txtNeto21.Text);
                    Iva21 = neto21 * (Convert.ToDecimal(21) / 100);
                    decimal calc = Iva21;                    
                    txtSubt21.Text = calc.ToString("0.00");
                }
                else
                {
                    txtSubt21.Text = "0,00";
                }

                if (txtNogravado.Text != "" && txtNogravado.Text != "0,00")
                {
                    netonog = Convert.ToDecimal(txtNogravado.Text);                    
                }

                decimal tot = neto105 + neto21 + Iva105 + Iva21 + netonog;                

                lblTotal.Text = tot.ToString("0.00");

            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Ocurrió un error al calcular importes", 0);
                return;
            }
        }

        //ASIGNA LETRA DE COMPROBANTE
        private void CambiaLetras()
        {
            try
            {
                if (prestador != null && prestador.Count > 0 && prestataria != null &&
                    prestataria.Count > 0)
                {
                    txtLetra.Text = func.GetLetracomprob(prestador[0].Iva, prestataria[0].Iva, 0, false);
                }
                else { txtLetra.Text = ""; }
                 
            }
            catch (Exception)
            {
                txtLetra.Text = "";                
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
            prop.GuardarUbicacion(10, this);
        }
        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            btnGenerar.Enabled = false;

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

            if (cmbPrestataria.EditValue == null || prestataria.Count == 0)
            {
                ctrls.MensajeInfo("Debe seleccionar una prestataria para continuar.", 1);
                cmbPrestataria.Focus();
                return;
            }

            if (cmbPrestador.EditValue == null || prestador.Count == 0)
            {
                ctrls.MensajeInfo("Debe seleccionar un prestador para continuar.", 1);
                cmbPrestador.Focus();
                return;
            }

            if (txtLetra.Text.Trim() == "")
            {
                ctrls.MensajeInfo("Debe ingresar una letra para continuar.", 1);                
                return;
            }

            if (txtPventa.Text.Trim() == "" || txtPventa.Text.Trim() == "0")
            {
                ctrls.MensajeInfo("Debe ingresar un punto de venta asociado para continuar.", 1);
                txtPventa.Focus();
                return;
            }

            if (txtNroasoc.Text.Trim() == "" || txtNroasoc.Text.Trim() == "0")
            {
                ctrls.MensajeInfo("Debe ingresar un número de comprobante asociado para continuar.", 1);
                txtNroasoc.Focus();
                return;
            }

            if (lblTotal.Text == "" || lblTotal.Text == "0,00")
            {
                ctrls.MensajeInfo("Debe ingresar un importe para continuar.", 1);                
                return;
            }

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
                        Iva = Convert.ToInt16(r["idiva"].ToString()),
                        PorcIva = Convert.ToDecimal(r["PorcIva"].ToString())
                    });
                }

            }

            CambiaLetras();
        }

        private void cmbPrestador_TextChanged(object sender, EventArgs e)
        {
            prestador.Clear();
            txtPventa.Text = "0";
            if (cmbPrestador.EditValue != null && cmbPrestador.Properties.View != null)
            {
                DataTable dt = cmbPrestador.Properties.DataSource as DataTable;

                foreach (DataRow r in dt.Select("ID_Registro = " + Convert.ToInt32(cmbPrestador.EditValue)))
                {
                    prestador.Add(new Prestador
                    {
                        IDRegistro = Convert.ToInt32(cmbPrestador.EditValue),
                        Nombre = r["Prestador"].ToString().Trim(),
                        Domicilio = r["DomFiscal"].ToString().Trim(),
                        Cuit = Convert.ToInt64(r["Cuit"].ToString().Trim()),
                        Iva = Convert.ToInt16(r["idiva"].ToString().Trim()),
                        PuntoVenta = Convert.ToInt32(r["PuntoVenta"].ToString().Trim())
                    });

                    txtPventa.Text = r["PuntoVenta"].ToString().Trim();
                }
            }
            else
            {
                txtPventa.Text = "0";
            }

            CambiaLetras();
        }

        private void txtNeto105_TextChanged(object sender, EventArgs e)
        {
            CalculaImportes();
        }

        private void txtNeto21_TextChanged(object sender, EventArgs e)
        {
            CalculaImportes();
        }

        private void txtNogravado_TextChanged(object sender, EventArgs e)
        {
            CalculaImportes();
        }
    }

    internal class Prestata
    {
        public long IDRegistro { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Domicilio { get; set; } = "";
        public long Cuit { get; set; } = 0;
        public short Iva { get; set; } = 0;
        public decimal PorcIva { get; set; } = 0;

    }

    internal class Prestador
    {
        public long IDRegistro { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string Domicilio { get; set; } = "";
        public long Cuit { get; set; } = 0;
        public short Iva { get; set; } = 0;
        public int PuntoVenta { get; set; } = 0;
    }
}