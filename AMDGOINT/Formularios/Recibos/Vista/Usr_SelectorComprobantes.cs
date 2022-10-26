using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace AMDGOINT.Formularios.Recibos.Vista
{
    public partial class Usr_SelectorComprobantes : UserControl
    {
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private OverlayPanel OverlayPanel = new OverlayPanel();
        public List<MC.ReciboDet> Detalles { get; set; } = new List<MC.ReciboDet>();
        private MC.ReciboDet Detalle = new MC.ReciboDet();
        private decimal sumaPiecol { get; set; } = 0;

        public int PrestatariaCuentaID { get; set; }
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        public Usr_SelectorComprobantes()
        {
            InitializeComponent();
            colImporteTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colImportecancelado.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
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
                return;
            }
        }

        private void BusqDetalles()
        {
            try
            {
                Detalle.SqlConnection = SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection;
                Detalles.Clear();
                Detalles.AddRange(Detalle.GetFacturasPendientes(PrestatariaCuentaID));
                gridControl.DataSource = Detalles.OrderByDescending(o => o.ComprobanteFechaEmision);
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
                    MC.ReciboDet d = gridView.GetRow(i) as MC.ReciboDet;
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

        private void Usr_SelectorComprobantes_Load(object sender, EventArgs e)
        {
            IbusqDetalles();
        }

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            MarcaSeleccionado();
            gridView.UpdateTotalSummary();
        }

        private void gridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if ((e.IsTotalSummary) &&
                   (((e.Item as GridSummaryItem).FieldName == colImporteTotal.FieldName)) ||
                   ((e.Item as GridSummaryItem).FieldName == colImportecancelado.FieldName))
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
            if (e.Column == colImporteTotal || e.Column == colImportecancelado)
            {
                GridSummaryItem summary = e.Info.SummaryItem;
                decimal summaryvalue = Convert.ToDecimal(summary.SummaryValue);
                string summarytext = string.Format("{2:C2}", "", "", summaryvalue);
                e.Info.DisplayText = summarytext;
            }
        }
    }
}
