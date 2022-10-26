using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Frm_Valorizador : XtraForm
    {
        private Funciones func = new Funciones();
        private Controles ctrls = new Controles();
        private ConexionBD cnb = new ConexionBD();

        private Practicas.MC.Practica PracticaNomenclada = new Practicas.MC.Practica();
        private List<Practicas.MC.Practica> Practicas { get; set; } = new List<Practicas.MC.Practica>();
        private MC.DetalleGlobal DetalleGlobal = new MC.DetalleGlobal();
        private List<MC.DetalleGlobal> DetallesGlobales { get; set; } = new List<MC.DetalleGlobal>();

        public SqlConnection SqlConnection = new SqlConnection();
        private List<Binding> Bindctrls = new List<Binding>();

        public decimal UnidadGastos { get; set; } = 0;
        public decimal UnidadGaleno { get; set; } = 0;
        public decimal UnidadAyudante { get; set; } = 0;
        public decimal CantidadAyudante { get; set; } = 0;
        public decimal ValorGaleno { get; set; } = 0;
        public decimal ValorGasto { get; set; } = 0;
        public decimal ValorAyudante { get; set; } 
        public string CodigoGasto { get; set; } = "";
        public string CodigoGaleno { get; set; } = "";
        public decimal ValorPactado { get; set; } = 0;

        public decimal TotalGaleno
        {
            get { return  UnidadGaleno * ValorGaleno; }
        }

        public decimal TotalGasto
        {
            get { return UnidadGastos * ValorGasto; }
        }

        public decimal TotalAyudante
        {
            get { return UnidadAyudante > 0 ? (CantidadAyudante * UnidadAyudante) * ValorAyudante : 0; }
        }

        public decimal Total
        {
            get { return TotalAyudante + TotalGaleno + TotalGasto; }
        }

        public Frm_Valorizador()
        {
            InitializeComponent();
        }

        #region Metodos Manuales

        private void ParametrosInicio()
        {
            try
            {
                SqlConnection = SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection;
                PracticaNomenclada.SqlConnection = SqlConnection;
                DetalleGlobal.SqlConnection = SqlConnection;

                SetBindings();                                
                CargaCombos(0);
            }
            catch (Exception)
            {

            }
        }
        
        
        private void CargaCombos(short c)
        {
            try
            {
                if (c == 0 || c == 1)
                {
                    string co = $"SELECT SOC.OBRACODI AS CuentaCodigo, SOC.OBRANOMB as CuentaNombre, SOC.OBRAABRE as CuentaAbreviatura, SOC.OBRAAGOB as CuentaAgrupador" +
                                $" FROM AmdgoSis.dbo.ASOCOBRA SOC" +
                                $" WHERE SOC.Visible = 1";

                    cmbPrestadora.Properties.DataSource = func.getColecciondatos(co, SqlConnection);
                }

                if (c == 0 || c == 2)
                {
                    var v = cmbPrestadora.EditValue;
                    string agrupador = v != null ? v.ToString() : "";
                    string co = "SELECT AR.ARANTIPO AS CuentaAgrupador, AR.ARANEPOC AS Epoca, AR.ARANFEPOCA AS Fecha" +
                                " FROM AmdgoSis.dbo.ASOCARAN AR" +
                                $" WHERE AR.ARANTIPO = '{agrupador.Trim()}' AND AR.ARANEPOC <> '0'" +
                                $" ORDER BY AR.ARANEPOC ASC";

                    cmbNegociacion.Properties.DataSource = func.getColecciondatos(co, SqlConnection);
                }

                if (c == 0 || c == 3)
                {
                    Practicas.Clear();
                    Practicas.AddRange(PracticaNomenclada.GetNomencladas());
                    cmbPracticas.Properties.DataSource = Practicas;
                }
            }
            catch (Exception)
            {

            }
        }

        //GET VALORES ASOCTGAL
        private void SetValoresUnidades()
        {
            try
            {
                string epoca = "";
                string agrupador = "";                
                string practica = "";
                
                if (cmbNegociacion.EditValue != null && !string.IsNullOrWhiteSpace(cmbNegociacion.EditValue.ToString())) { epoca = cmbNegociacion.EditValue.ToString().Trim(); } else { epoca = ""; }
                if (cmbPrestadora.EditValue != null && !string.IsNullOrWhiteSpace(cmbPrestadora.EditValue.ToString())) { agrupador = cmbPrestadora.EditValue.ToString().Trim(); } else { agrupador = ""; }
                if (cmbPracticas.EditValue != null && !string.IsNullOrWhiteSpace(cmbPracticas.EditValue.ToString())) { practica = cmbPracticas.EditValue.ToString().Trim(); } else { practica = ""; }

                if (string.IsNullOrEmpty(epoca) || string.IsNullOrEmpty(agrupador) || string.IsNullOrEmpty(practica)) { return; }

                string c = $"SELECT TG.TGALVALG from AmdgoSis.dbo.ASOCTGAL TG where TG.TGALTIPO = '{agrupador}' and TG.TGALEPOC  = '{epoca}' and TG.TGALGARA = '{CodigoGaleno.Trim()}'";

                decimal _out = 0;
                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows) { decimal.TryParse(r["TGALVALG"].ToString(), out _out); ValorGaleno = _out; ValorAyudante = _out; }

                c = $"select TG.TGASVGAS from AmdgoSis.dbo.ASOCTGAS TG where TG.TGASTIPO = '{agrupador}' and TG.TGASEPOC  = '{epoca}' and TG.TGASGGAS = '{CodigoGasto.Trim()}'";

                _out = 0;
                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows) { decimal.TryParse(r["TGASVGAS"].ToString(), out _out); ValorGasto = _out; }

                c = $"SELECT SUM(IMPORTE) AS Importe FROM AmdgoSis.dbo.NONO TB WHERE TB.OS = '{agrupador}' AND TB.PRACTICA = '{practica}' AND TB.EPOCA = '{epoca}'";
                foreach (DataRow r in func.getColecciondatos(c, SqlConnection).Rows) { decimal.TryParse(r["Importe"].ToString(), out _out); ValorPactado = _out; }

                if (ValorPactado > 0)
                {
                    lblPracticapactada.Text = $"Práctica pactada por el valor total de $ {ValorPactado.ToString("0.00")}";
                }
                else { lblPracticapactada.Text = $"Práctica NO pactada"; }

                ctrls.RefrescarValorcontrols(Bindctrls);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"No se pudo procesar la información.\n{e.Message}", 1);
                return;
            }
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                                
                Bindctrls.Clear();
                Bindctrls.Add(txtUgaleno.DataBindings.Add("EditValue", this, nameof(UnidadGaleno)));                
                Bindctrls.Add(txtUgasto.DataBindings.Add("EditValue", this, nameof(UnidadGastos)));
                Bindctrls.Add(txtUayudantes.DataBindings.Add("EditValue", this, nameof(UnidadAyudante)));
                Bindctrls.Add(txtCayudante.DataBindings.Add("EditValue", this, nameof(CantidadAyudante)));
                Bindctrls.Add(txtVgaleno.DataBindings.Add("EditValue", this, nameof(ValorGaleno)));
                Bindctrls.Add(txtVgasto.DataBindings.Add("EditValue", this, nameof(ValorGasto)));
                Bindctrls.Add(txtVayudantes.DataBindings.Add("EditValue", this, nameof(ValorAyudante)));

                Bindctrls.Add(txtTotalgaleno.DataBindings.Add("EditValue", this, nameof(TotalGaleno)));
                Bindctrls.Add(txtTotalgasto.DataBindings.Add("EditValue", this, nameof(TotalGasto)));
                Bindctrls.Add(txtTotalAyudantes.DataBindings.Add("EditValue", this, nameof(TotalAyudante)));

                Bindctrls.Add(txtTotal.DataBindings.Add("EditValue", this, nameof(Total)));


            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }

        //CAMBIO LOS DATOS DEL PROFESIONAL SEGUN SELECCION
        private void SetPacticadata()
        {
            try
            {                
                if (cmbPracticas.EditValue != null && !string.IsNullOrWhiteSpace(cmbPracticas.EditValue.ToString()))
                {

                    UnidadGaleno = Practicas.Where(w => w.Codigo == cmbPracticas.EditValue.ToString()).Select(s => s.UnidadGaleno).First();
                    UnidadGastos = Practicas.Where(w => w.Codigo == cmbPracticas.EditValue.ToString()).Select(s => s.UnidadGasto).First();
                    UnidadAyudante = Practicas.Where(w => w.Codigo == cmbPracticas.EditValue.ToString()).Select(s => s.AyudanteUnidad).First();
                    CantidadAyudante = Practicas.Where(w => w.Codigo == cmbPracticas.EditValue.ToString()).Select(s => s.AyudanteCantidad).First();           
                    CodigoGasto = Practicas.Where(w => w.Codigo == cmbPracticas.EditValue.ToString()).Select(s => s.GastoCodigo).First();
                    CodigoGaleno = Practicas.Where(w => w.Codigo == cmbPracticas.EditValue.ToString()).Select(s => s.GalenoCodigo).First(); 
                }
                else
                {
                    UnidadGaleno = 0;
                    UnidadGastos = 0;
                    UnidadAyudante = 0;
                    CantidadAyudante = 0;
                    CodigoGasto = "";
                    CodigoGaleno = "";
                    ValorPactado = 0;
                }

                SetValoresUnidades();               

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al asignar el profesional.\n{e.Message}", 1);
                return;
            }
        }


        #endregion

        private void Frm_Valorizador_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }
        

        private void cmbPrestadora_EditValueChanged(object sender, EventArgs e)
        {
            CargaCombos(2);
            SetValoresUnidades();
        }

        private void cmbPracticas_EditValueChanged(object sender, EventArgs e)
        {
            SetPacticadata();
        }

        private void cmbNegociacion_EditValueChanged(object sender, EventArgs e)
        {
            SetValoresUnidades();
        }
    }
}