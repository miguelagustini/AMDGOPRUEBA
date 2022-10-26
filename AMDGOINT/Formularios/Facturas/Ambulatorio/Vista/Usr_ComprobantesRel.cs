using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Usr_ComprobantesRel : DevExpress.XtraEditors.XtraUserControl
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();

        public List<MC.ComprobantesRel> Comprobanteslst = new List<MC.ComprobantesRel>();

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
            if (propertyname == "IDFactura") { AsignaDatos(); }
        }

        #endregion

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

            AsignaDatos();
        }

        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = Comprobanteslst.Where(w => w.IDFactura == IDFactura).ToList();
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }

        private void MuestraComprobante()
        {
            try
            {
                MC.ComprobantesRel rel = gridView.GetRow(gridView.FocusedRowHandle) as MC.ComprobantesRel;
                if (rel is null) { return; }

                if (ParentForm is Frm_Facturas)
                {
                    Frm_Facturas f = ParentForm as Frm_Facturas;
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
    }
}
