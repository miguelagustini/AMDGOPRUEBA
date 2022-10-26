using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;
using AMDGOINT.Formularios.Facturas.Prestatarias.Vista;

namespace AMDGOINT.Formularios.Facturas.Prestataria.Vista
{
    public partial class Usr_Detalles : UserControl
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Point LocationSplash = new Point();

        public SqlConnection SqlConnection = new SqlConnection();

        private Prestatarias.MC.ComprobanteDet Detallescls = new Prestatarias.MC.ComprobanteDet();
        public List<Prestatarias.MC.ComprobanteDet> Detalles { get; set; } = new List<Prestatarias.MC.ComprobanteDet>();        
        private long _idfactura = 0;
              
        public long IDFactura
        {
            get { return _idfactura; }
            set
            {
                _idfactura = _idfactura != value ? value : _idfactura;
                Ibusquedareg();
            }

        }

        public Usr_Detalles()
        {
            InitializeComponent();
            Detallescls.SqlConnection = SqlConnection;
            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            splashScreen.SplashFormLocation = LocationSplash;
        }

        //INICIO LA BUSQUEDA DE REGISTROS
        private void Ibusquedareg()
        {
            try
            {
                try
                {
                    if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                    gridView.BeginDataUpdate();
                    if (bgwDetalles.IsBusy) { bgwDetalles.CancelAsync(); }
                    bgwDetalles.RunWorkerAsync();
                }
                catch (Exception)
                {
                    gridView.EndDataUpdate();                    
                    return;
                }

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
                Detallescls.SqlConnection = SqlConnection;
                if (Detalles.Where(w => w.IDEncabezado == IDFactura).Count() <= 0) { Detalles.AddRange(Detallescls.GetRegistrosPorComprobante(IDFactura)); }                               
                
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
                gridControl.DataSource = Detalles.Where(w => w.IDEncabezado == IDFactura && !w.DescripcionFacturaOriginal).ToList();
                gridView.EndDataUpdate();
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al finalizar la busqueda de detalles.\n" + e.Message, 0);
                gridView.EndDataUpdate();
                if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
                return;
            }
        }
        
        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Prestatarias.MC.ComprobanteDet rel = gridView.GetRow(gridView.FocusedRowHandle) as Prestatarias.MC.ComprobanteDet;
            if (rel is null) { return; }

            if (ParentForm is Frm_Comprobantes)
            {
                Frm_Comprobantes f = ParentForm as Frm_Comprobantes;
                if (f != null) { f.ExportaExcel(gridControl); }
            }
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void bgwDetalles_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Ebusquedareg();
        }

        private void bgwDetalles_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Fbusquedareg();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }
    }
}
