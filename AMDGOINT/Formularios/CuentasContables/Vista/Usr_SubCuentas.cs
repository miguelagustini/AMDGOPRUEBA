using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AMDGOINT.Clases;
using DevExpress.XtraGrid;

namespace AMDGOINT.Formularios.CuentasContables.Vista
{
    public partial class Usr_SubCuentas : UserControl
    {
        private Controles ctrls = new Controles();        
                                        
        public List<MC.SubCuentas> Detalles { get; set; } = new List<MC.SubCuentas>();
        private long _idcuenta = 0;
              
        public long IDCuenta
        {
            get { return _idcuenta; }
            set
            {
                _idcuenta = _idcuenta != value ? value : _idcuenta;
                SetBindings();
            }

        }

        public Usr_SubCuentas()
        {
            InitializeComponent();                        

        }
        
        //EJECUTO LA BUSQUEDA DE REGISTROS
        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = Detalles;
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                gridView.EndDataUpdate();
                ctrls.MensajeInfo("Ocurrió un error al ejecutar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.RowHandle != GridControl.NewItemRowHandle && (e.Column.FieldName == "UsoReciboPrestatariaDescripcion" || e.Column.FieldName == "UsoReciboPrestadorDescripcion"
                    || e.Column.FieldName == "UsoReciboEmpleadoDescripcion" || e.Column.FieldName == "UsoReciboTerceroDescripcion"
                    || e.Column.FieldName == "UsoOrdenPagoTerceroDescripcion" || e.Column.FieldName == "UsoOrdenPagoEmpleadoDescripcion" 
                    || e.Column.FieldName == "UsoOrdenPagoPrestadorDescripcion"))
                {
                    if (e.CellValue.ToString().ToUpper() == "SI")
                    { e.RepositoryItem = reposTextSi; }
                    else { e.RepositoryItem = reposTextNo; }
                }
                else if (e.RowHandle != GridControl.NewItemRowHandle && e.Column.FieldName == "EnviadoDosDescripcion")
                {
                    if (e.CellValue.ToString().ToUpper() == "ACTIVA")
                    { e.RepositoryItem = reposTextSi; }
                    else { e.RepositoryItem = reposTextNo; }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnExportaXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            ctrls.ExportaraExcelgrd(gridControl);
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount > 0) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }
        }
    }
}
