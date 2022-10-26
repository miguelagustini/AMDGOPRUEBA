using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    public partial class Frm_PFacturasDet : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();
        private List<Detalles> factdetalles = new List<Detalles>();
        private ConexionBD cb = new ConexionBD();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public long IDEncabezado { get; set; } = 0;
        public bool EsPopup { get; set; } = false;

        public Frm_PFacturasDet()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();

            InitializeComponent();
        }

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;

            if (EsPopup)
            {
                prop.RecuperaUbicacion(2, this);
                bgridView.OptionsSelection.MultiSelect = true;
                bgridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                FormBorderStyle = FormBorderStyle.Sizable;
                Ibusquedareg();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                tableLayoutPanel1.RowStyles[1].Height = 0;
            }

            ctrls.PreferencesGrid(this, bgridView, "R");
        }

        //INICIO LA BUSQUEDA DE REGISTROS
        public void Ibusquedareg()
        {
            try
            {
                try
                {
                    bgridView.BeginDataUpdate();
                    if (bgwDetalles.IsBusy) { bgwDetalles.CancelAsync(); }
                    bgwDetalles.RunWorkerAsync();
                }
                catch (Exception)
                {
                    bgridView.EndDataUpdate();
                    return;
                }
                
                /*while (bgwDetalles.CancellationPending)
                { if (!bgwDetalles.CancellationPending) { break; } }*/
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al iniciar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        //EJECUTO LA BUSQUEDA DE REGISTROS
        private void Ebusquedareg()
        {
            try
            {
                factdetalles.Clear();

                if (IDEncabezado <= 0) return;

                string consulta = "SELECT ID_Registro, ID_Encabezado, Periodo, Descripcion, NroDocumento, Paciente, Cantidad," +
                                  " Neto, Gastos, Honorarios, Iva, Total, Puntero, Origen, CodProfesional, Profesional," +
                                  " CASE WHEN ProfCndIva = '1' THEN 'RI'" +
                                  " WHEN ProfCndIva = '4' THEN 'EX'" +
                                  " WHEN ProfCndIva = '6' THEN 'MO'" +
                                  " ELSE '' END AS ProfCndIva" +
                                  " FROM FACTPRESDET" +
                                  " WHERE ID_ENCABEZADO = " + IDEncabezado;

                foreach (DataRow f in func.getColecciondatos(consulta, SqlConnection).Rows)
                {
                    if (bgwDetalles.CancellationPending) { return; }

                    factdetalles.Add(new Detalles
                    {
                        IDRegistro = Convert.ToInt64(f["ID_Registro"]),
                        IDEncabezado = Convert.ToInt64(f["ID_Encabezado"]),
                        Periodo = f["Periodo"].ToString(),
                        Descripcion = f["Descripcion"].ToString(),
                        NroDocumento = Convert.ToInt64(f["NroDocumento"]),
                        Paciente = f["Paciente"].ToString().Trim(),
                        Cantidad = Convert.ToDecimal(f["Cantidad"]),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Gastos = Convert.ToDecimal(f["Gastos"]),
                        Honorarios = Convert.ToDecimal(f["Honorarios"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        Puntero = Convert.ToInt64(f["Puntero"]),
                        Origen = f["Origen"].ToString(),
                        CodProfesional = f["CodProfesional"].ToString(),
                        Profesional = f["Profesional"].ToString(),
                        CondIva = f["ProfCndIva"].ToString()
                        
                    });
                }
            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al ejecutar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        //FINALIZO LA BUSQUEDA DE REGISTROS
        private void Fbusquedareg()
        {
            try
            {
                gridControl.DataSource = factdetalles;
                bgridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al finalizar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        private void bgwDetalles_DoWork(object sender, DoWorkEventArgs e)
        {
            Ebusquedareg();
        }

        private void bgwDetalles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusquedareg();
        }

        private void Frm_PFacturasDet_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrls.PreferencesGrid(this, bgridView, "S");
        }

        private void Frm_PFacturasDet_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (bgridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void btnExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);
        }
                
    }

    class Detalles
    {
        public long IDRegistro { get; set; } = 0;
        public long IDEncabezado { get; set; } = 0;
        public string Periodo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public long NroDocumento { get; set; } = 0;
        public string Paciente { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal Neto { get; set; } = 0;
        public decimal Gastos { get; set; } = 0;
        public decimal Honorarios { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public long Puntero { get; set; } = 0;
        public string Origen { get; set; } = "";
        public string CodProfesional { get; set; } = "";
        public string Profesional { get; set; } = "";
        public string CondIva { get; set; } = "";

    }
}