using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    public partial class Usr_ComprobantesRel : XtraUserControl
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();

        public SqlConnection SqlConnection = new SqlConnection();
        private MC.ComprobantesRel Comprobantescls = new MC.ComprobantesRel();
        public List<MC.ComprobantesRel> Comprobanteslst { get; set; } = new List<MC.ComprobantesRel>();
        private long _idfactura = 0;

        public long IDFactura
        {
            get { return _idfactura; }
            set
            {
                if (_idfactura != value)
                {
                    _idfactura = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Usr_ComprobantesRel()
        {
            InitializeComponent();

            Parametrosinicio();
        }

        #region NOTIFY      
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (propertyname == "IDFactura") { Ibusquedareg(); }
        }

        #endregion

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;
            Comprobantescls.SqlConnection = SqlConnection;            
        }
      
        //INICIO LA BUSQUEDA DE REGISTROS
        private void Ibusquedareg()
        {
            try
            {
                try
                {
                    gridView.BeginDataUpdate();
                    if (bgwComprobantes.IsBusy) { bgwComprobantes.CancelAsync(); }
                    bgwComprobantes.RunWorkerAsync();
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
                Comprobantescls.SqlConnection = SqlConnection;
                Comprobanteslst.Clear();
                Comprobanteslst.AddRange(Comprobantescls.GetRegistrosPorComprobante(IDFactura));
             
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
                gridControl.DataSource = Comprobanteslst;
                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al finalizar la busqueda de detalles.\n" + e.Message, 0);
                gridView.EndDataUpdate();
                return;
            }
        }


        private void MuestraComprobante()
        {
            try
            {
                MC.ComprobantesRel rel = gridView.GetRow(gridView.FocusedRowHandle) as MC.ComprobantesRel;
                if (rel is null) { return; }

                if (ParentForm is Frm_Comprobantes)
                {
                    Frm_Comprobantes f = ParentForm as Frm_Comprobantes;
                    if (f != null) { f.PreparaImpresion(0, true, rel.IDComprobante); }                    
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al mostrar el comprobante.\n{e.Message}", 1);
                return;
            }
        }

        private void btnImprimirComprobante_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestraComprobante();
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void bgwComprobantes_DoWork(object sender, DoWorkEventArgs e)
        {
            Ebusquedareg();
        }

        private void bgwComprobantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusquedareg();
        }
    }
}
