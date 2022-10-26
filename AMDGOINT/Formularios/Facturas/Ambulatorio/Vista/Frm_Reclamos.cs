using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Frm_Reclamos : XtraForm
    {
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private OverlayPanel OverlayPanel = new OverlayPanel();

        public List<Reclamos.MC.ReclamosDet> Detalles { get; set; } = new List<Reclamos.MC.ReclamosDet>();
        private Reclamos.MC.ReclamosDet Detalle = new Reclamos.MC.ReclamosDet();

        public int PrestatariaCuentaID { get; set; }
        public int PrestadorCuentaID { get; set; }
        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Reclamos()
        {
            InitializeComponent();
        }

        private void ParametrosInicio()
        {
            try
            {
                ctrl.PreferencesGrid(this, gridView, "R");
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Detalle.SqlConnection = SqlConnection;
                IbusqDetalles();

            }
            catch (Exception)
            {

            }
        }

        private void IbusqDetalles()
        {
            try
            {
                if (bgwRegistros.IsBusy) { return; }
                OverlayPanel.Mostrar(this);
                gridView.BeginDataUpdate();
                bgwRegistros.RunWorkerAsync();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        private void BusqDetalles()
        {
            try
            {
                Detalle.SqlConnection = SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection;
                Detalles.Clear();
                Detalles.AddRange(Detalle.GetRegistrosFacturaProfesional(PrestatariaCuentaID, PrestadorCuentaID));
                gridControl.DataSource = Detalles;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        private void FbusqDetalles()
        {
            try
            {
                gridView.EndDataUpdate();
                OverlayPanel.Ocultar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
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
                    Reclamos.MC.ReclamosDet d = gridView.GetRow(i) as Reclamos.MC.ReclamosDet;
                    if (d == null) { return; }
                    d.Seleccionado = gridView.IsRowSelected(i);
                }

                gridView.EndDataUpdate();
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            BusqDetalles();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FbusqDetalles();
        }


        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            MarcaSeleccionado();
            gridView.UpdateTotalSummary();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Frm_DebitosSelector_Load(object sender, EventArgs e)
        {

        }

        private void Frm_DebitosSelector_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_DebitosSelector_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //ctrl.PreferencesGrid(this, gridView, "S");
        }
    }
}
