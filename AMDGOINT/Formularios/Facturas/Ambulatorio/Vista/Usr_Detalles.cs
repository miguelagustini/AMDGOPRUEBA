using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Usr_Detalles : UserControl
    {
        private Controles ctrls = new Controles();        
        private List<MC.FacturaDet> detalles = new List<MC.FacturaDet>();        
        private long _idfactura = 0;

        public List<MC.FacturaDet> Detalles
        {
            get { return detalles; }
            set
            {
                detalles = detalles != value ? value : detalles;
                SetBindings();
            }
        }

        public long IDFactura
        {
            get { return _idfactura; }
            set
            {
                _idfactura = _idfactura != value ? value : _idfactura;
                SetBindings();
            }

        }
             
        public Usr_Detalles()
        {
            InitializeComponent();
        }

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = Detalles.Where(w => w.IDEncabezado == IDFactura && w.IDRegistro > 0).ToList();
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            MC.FacturaDet rel = gridView.GetRow(gridView.FocusedRowHandle) as MC.FacturaDet;
            if (rel is null) { return; }

            if (ParentForm is Frm_Facturas)
            {
                Frm_Facturas f = ParentForm as Frm_Facturas;
                if (f != null) { f.ExportaExcel(gridControl); }
            }
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }
    }
}
