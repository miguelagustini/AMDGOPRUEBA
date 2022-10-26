using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    public partial class Frm_NotaCredParam : XtraForm
    {
        private Propiedadesgral prop = new Propiedadesgral();
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();

        public long ID_Factura { get; set; } = 0;
        public decimal Total21 { get; set; } = 0;
        public decimal Total105 { get; set; } = 0;
        public decimal NoGravado { get; set; } = 0;

        public decimal retTotal21 { get; set; } = 0;
        public decimal retTotal105 { get; set; } = 0;
        public decimal retNoGravado { get; set; } = 0;
        public string Tipo { get; set; } = "";
        public Frm_NotaCredParam()
        {
            InitializeComponent();
            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);
            txtNograv.TextChanged += new EventHandler(TextEdit_TextChanged);
            txtTot21.TextChanged += new EventHandler(TextEdit_TextChanged);
            txtTot105.TextChanged += new EventHandler(TextEdit_TextChanged);
            txtNograv.Validated += new EventHandler(TextValidate);
            txtTot21.Validated += new EventHandler(TextValidate);
            txtTot105.Validated += new EventHandler(TextValidate);
        }

        #region METODOS MANUALES

        private void SumaImportes()
        {
            decimal total = 0;

            if (txtNograv.Text != "") { total += Convert.ToDecimal(txtNograv.Text); }
            if (txtTot21.Text != "") { total += Convert.ToDecimal(txtTot21.Text); }
            if (txtTot105.Text != "") { total += Convert.ToDecimal(txtTot105.Text); }

            lblTotal.Text = total.ToString("0.00");
        }

        private void ParametrosInicio()
        {
            if (Total21 > 0) { Total21 = Total21 - GetTotiva21acumnc() + GetTotiva21acumnd(); }
            if (Total105 > 0) { Total105 = Total105 - GetTotiva105acumnc() + GetTotiva105acumnd(); }
            if (NoGravado > 0) { NoGravado = NoGravado - GetTotnogravacumnc() + GetTotnogravacumnd(); }

            lblTot21.Text = Total21.ToString();
            lblTot105.Text = Total105.ToString();
            lblTotnog.Text = NoGravado.ToString();

            Deshabilitacomp();

            if (Tipo == "NC") { this.Text = "Parámetros Nota de Crédito"; }
            else { this.Text = "Parámetros Nota de Débito"; }
        }

        //OBTENGO EL TOTAL DE NOTAS DE CREDITO A ESA FACTURA 21
        private decimal GetTotiva21acumnc()
        {
            decimal retorno = 0;

            try
            {
                string consulta = "SELECT ISNULL(SUM(FE.Neto21 + FE.Iva21),0) AS Total" +
                    " FROM FACTAMBUREL FR" +
                    " LEFT OUTER JOIN FACTAMBUENC FE ON(FE.ID_Registro = FR.ID_NotaCredito)" +
                    " WHERE FR.ID_Factura = " + ID_Factura + " AND FE.EstadoAf = 'A'" +
                    " GROUP BY FR.ID_Factura";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { retorno += Convert.ToDecimal(f["Total"]); }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al obtener el total acumulado iva 21.\n" + e.Message, 0);
                return retorno;
            }
        }

        //OBTENGO EL TOTAL DE NOTAS DE DEBITO A ESA FACTURA 21
        private decimal GetTotiva21acumnd()
        {
            decimal retorno = 0;

            try
            {
                string consulta = "SELECT ISNULL(SUM(FE.Neto21 + FE.Iva21),0) AS Total" +
                    " FROM FACTAMBUREL FR" +
                    " LEFT OUTER JOIN FACTAMBUENC FE ON(FE.ID_Registro = FR.ID_NotaDebito)" +
                    " WHERE FR.ID_Factura = " + ID_Factura + " AND FE.EstadoAf = 'A'" +
                    " GROUP BY FR.ID_Factura";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { retorno += Convert.ToDecimal(f["Total"]); }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al obtener el total acumulado iva 21.\n" + e.Message, 0);
                return retorno;
            }
        }

        //OBTENGO EL TOTAL DE NOTAS DE CREDITO A ESA FACTURA 105
        private decimal GetTotiva105acumnc()
        {
            decimal retorno = 0;

            try
            {
                string consulta = "SELECT ISNULL(SUM(FE.Neto105 + FE.Iva105),0) AS Total" +
                    " FROM FACTAMBUREL FR" +
                    " LEFT OUTER JOIN FACTAMBUENC FE ON(FE.ID_Registro = FR.ID_NotaCredito)" +
                    " WHERE FR.ID_Factura = " + ID_Factura + " AND FE.EstadoAf = 'A'" +
                    " GROUP BY FR.ID_Factura";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { retorno += Convert.ToDecimal(f["Total"]); }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al obtener el total acumulado iva 21.\n" + e.Message, 0);
                return retorno;
            }
        }

        //OBTENGO EL TOTAL DE NOTAS DE DEBITO A ESA FACTURA 105
        private decimal GetTotiva105acumnd()
        {
            decimal retorno = 0;

            try
            {
                string consulta = "SELECT ISNULL(SUM(FE.Neto105 + FE.Iva105),0) AS Total" +
                    " FROM FACTAMBUREL FR" +
                    " LEFT OUTER JOIN FACTAMBUENC FE ON(FE.ID_Registro = FR.ID_NotaDebito)" +
                    " WHERE FR.ID_Factura = " + ID_Factura + " AND FE.EstadoAf = 'A'" +
                    " GROUP BY FR.ID_Factura";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { retorno += Convert.ToDecimal(f["Total"]); }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al obtener el total acumulado iva 21.\n" + e.Message, 0);
                return retorno;
            }
        }

        //OBTENGO EL TOTAL DE NOTAS DE CREDITO A ESA FACTURA NO GRAVADO
        private decimal GetTotnogravacumnc()
        {
            decimal retorno = 0;

            try
            {
                string consulta = "SELECT ISNULL(SUM(FE.NoGravado),0) AS Total" +
                    " FROM FACTAMBUREL FR" +
                    " LEFT OUTER JOIN FACTAMBUENC FE ON(FE.ID_Registro = FR.ID_NotaCredito)" +
                    " WHERE FR.ID_Factura = " + ID_Factura + " AND FE.EstadoAf = 'A'" +
                    " GROUP BY FR.ID_Factura";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { retorno += Convert.ToDecimal(f["Total"]); }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al obtener el total acumulado iva 21.\n" + e.Message, 0);
                return retorno;
            }
        }

        //OBTENGO EL TOTAL DE NOTAS DE DEBITO A ESA FACTURA NO GRAVADO
        private decimal GetTotnogravacumnd()
        {
            decimal retorno = 0;

            try
            {
                string consulta = "SELECT ISNULL(SUM(FE.NoGravado),0) AS Total" +
                    " FROM FACTAMBUREL FR" +
                    " LEFT OUTER JOIN FACTAMBUENC FE ON(FE.ID_Registro = FR.ID_NotaDebito)" +
                    " WHERE FR.ID_Factura = " + ID_Factura + " AND FE.EstadoAf = 'A'" +
                    " GROUP BY FR.ID_Factura";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows) { retorno += Convert.ToDecimal(f["Total"]); }

                return retorno;
            }
            catch (Exception e)
            {

                ctrl.MensajeInfo("Ocurrió un error al obtener el total acumulado iva 21.\n" + e.Message, 0);
                return retorno;
            }
        }

        private void Deshabilitacomp()
        {
            if (Total21 == 0) { txtTot21.Enabled = false; }
            if (Total105 == 0) { txtTot105.Enabled = false; }
            if (NoGravado == 0) { txtNograv.Enabled = false; }
        }

        #endregion

        private void tglUsatodo_Toggled(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(tglUsatodo.EditValue))
            {
                txtTot21.Text = lblTot21.Text;
                txtTot105.Text = lblTot105.Text;
                txtNograv.Text = lblTotnog.Text;
                txtTot21.Enabled = false;
                txtTot105.Enabled = false;
                txtNograv.Enabled = false;
            }
            else
            {
                txtTot21.Text = "0,00";
                txtTot105.Text = "0,00";
                txtNograv.Text = "0,00";
                txtTot21.Enabled = true;
                txtTot105.Enabled = true;
                txtNograv.Enabled = true;
                Deshabilitacomp();
            }
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            SumaImportes();
        }

        private void TextValidate(object sender, EventArgs e)
        {
            TextEdit txt = sender as TextEdit;
            if (txt.Text == "") { txt.Text = "0,00"; }
            switch (txt.Name)
            {
                case "txtTot21": if (Convert.ToDecimal(lblTot21.Text) < Convert.ToDecimal(txtTot21.Text)) { txtTot21.Focus(); } break;
                case "txtTot105": if (Convert.ToDecimal(lblTot105.Text) < Convert.ToDecimal(txtTot105.Text)) { txtTot105.Focus(); } break;
                case "txtNograv": if (Convert.ToDecimal(lblTotnog.Text) < Convert.ToDecimal(txtNograv.Text)) { txtNograv.Focus(); } break;
            }
            
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            prop.RecuperaUbicacion(4, this);
            ParametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            prop.GuardarUbicacion(4, this);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            retTotal21 = Convert.ToDecimal(txtTot21.Text);
            retTotal105 = Convert.ToDecimal(txtTot105.Text);
            retNoGravado = Convert.ToDecimal(txtNograv.Text);

            if (retTotal21 == 0 && retNoGravado == 0 && retTotal105 == 0)
            {
                ctrl.MensajeInfo("Debe ingresar un importe para generar la nota de crédito.", 1);
                return;
            }

            if (Convert.ToDecimal(lblTotal.Text) > (Total21 + NoGravado + Total105) && Tipo == "NC")
            {
                ctrl.MensajeInfo("El importe no puede ser mayor que el monto de la factura.", 1);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}