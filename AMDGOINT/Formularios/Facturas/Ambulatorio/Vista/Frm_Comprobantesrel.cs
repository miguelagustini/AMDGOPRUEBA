using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Linq;
using AMDGOINT.Datos;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    public partial class Frm_Comprobantesrel : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();
        public  List<MC.ComprobantesRel> Comprobanteslst = new List<MC.ComprobantesRel>();

        private ConexionBD cb = new ConexionBD();
        private Impresionglob impresion = new Impresionglob();
        private Reportes dsreportes = new Reportes();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

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

        public Frm_Comprobantesrel()
        {            
            InitializeComponent();
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
            SqlConnection = SqlConnection.State != ConnectionState.Open ? cb.Conectar() : SqlConnection;
                       
            FormBorderStyle = FormBorderStyle.None;
            tableLayoutPanel1.RowStyles[1].Height = 0;

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

            AsignaDatos();
        }
              
        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = Comprobanteslst.Where(w => w.IDFactura ==  IDFactura).ToList();
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }
                       
        //IMPRESION
        private void Imprimir()
        {
            MC.ComprobantesRel r = gridView.GetRow(gridView.FocusedRowHandle) as MC.ComprobantesRel;
            if (r == null) { return; }

            impresion.datosrep = dsreportes;
            impresion.Imprimirdetallado = true;
            impresion.IDRegistro = r.IDComprobante;
            impresion.CargaDatosfcambu();
            impresion.MuestraReporte();

        }
                
        private void Frm_PFacturasDet_FormClosing(object sender, FormClosingEventArgs e)
        {            
        }

        private void Frm_PFacturasDet_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }
                
        private void btnExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ctrls.MensajePregunta("¿Imprimir éste comprobante?") == DialogResult.Yes) { Imprimir(); }            
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount > 0) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Point)); }
        }
    }
}