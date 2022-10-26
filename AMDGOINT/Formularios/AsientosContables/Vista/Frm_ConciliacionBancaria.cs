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

namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    public partial class Frm_ConciliacionBancaria : DevExpress.XtraEditors.XtraForm
    {

        private ConexionBD ConexionBD = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private OverlayPanel OverlayPanel = new OverlayPanel();

        private DateTime FechaDesde { get; set; } = DateTime.MinValue;
        private DateTime FechaHasta { get; set; } = DateTime.MinValue;
        private int PlanCuentaID { get; set; } = 0;
        public DateTime FechaExtracto { get; set; } = DateTime.Today;

        private MC.AsientosDet Pase = new MC.AsientosDet();
        private List<MC.AsientosDet> Pases = new List<MC.AsientosDet>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_ConciliacionBancaria()
        {
            InitializeComponent();
            datFechaExtracto.DataBindings.Add("EditValue", this, nameof(this.FechaExtracto));
        }

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            SqlConnection = SqlConnection.State != ConnectionState.Open ? ConexionBD.Conectar() : SqlConnection;
            Pase.SqlConnection = SqlConnection;
        }
               


        //BUSQUEDA DE REGISTROS
        public void IBusqRegistros()
        {
            try
            {

                Usr_PrintParams pr = new Usr_PrintParams();

                if (XtraDialog.Show(pr, "Parámetros de búsqueda", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }
                
                if (pr.FechaDesde > pr.FechaHasta)
                {
                    ctrls.MensajeInfo("La fecha DESDE no puede ser MAYOR a la fecha HASTA.", 1);
                    pr.Dispose();
                    return;
                }

                FechaDesde = pr.FechaDesde;
                FechaHasta = pr.FechaHasta;
                PlanCuentaID = pr.IDPlanCuenta;

                OverlayPanel.Mostrar(this);                                
                gridView.BeginDataUpdate();

                if (bgwBusqregistros.IsBusy)
                {                   
                    return;
                }
                
                bgwBusqregistros.RunWorkerAsync();
            }
            catch (Exception)
            {
                OverlayPanel.Ocultar();
                gridView.EndDataUpdate();
                
            }

        }

        //OBTENGO LOS REGISTROS
        private void GetRegistros()
        {
            try
            {
                Pases.Clear();
                Pases.AddRange(Pase.GetRegistros(FechaDesde, FechaHasta, PlanCuentaID));

            }
            catch (Exception e)
            {
                OverlayPanel.Ocultar();
                ctrls.MensajeInfo($"Hubo un inconveniente al obtener los registros.\n{e.Message}", 1);
                return;
            }
        }

        //FIN DE CONSULTA REGISTROS
        private void FBusqRegistros()
        {

            try
            {
                gridControl.DataSource = Pases;
                gridView.EndDataUpdate();
                OverlayPanel.Ocultar();
            }
            catch (Exception)
            {
                OverlayPanel.Ocultar();                
                gridView.EndDataUpdate();               
                
            }

        }

        //CONCILIAR 
        private void ConciliarRegistro()
        {
            try
            {
                if (gridView.RowCount <= 0) { return; }

                if (FechaExtracto == DateTime.MinValue)
                {
                    ctrls.MensajeInfo("No se Asigno una fecha de extracto bancario.", 1);
                    return;
                }

                MC.AsientosDet _deta = gridView.GetRow(gridView.FocusedRowHandle) as MC.AsientosDet;
                if (_deta == null)  { return; }

                gridView.BeginDataUpdate();

                _deta.FechaConciliacion = !_deta.Conciliado ? FechaExtracto : DateTime.MinValue;
                _deta.Conciliado = !_deta.Conciliado;

                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al conciliar el registro.\n{e.Message}",1);
                gridView.EndDataUpdate();
                return;
            }
        }

        //GUARDO LAS CONCILIACIONES REALIZADAS
        public void IGuardarRegistros()
        {
            try
            {                
                OverlayPanel.Mostrar(this);
                gridView.BeginDataUpdate();

                if (bgwGuardar.IsBusy)
                {                    
                    return;
                }

                bgwGuardar.RunWorkerAsync();
            }
            catch (Exception)
            {
                OverlayPanel.Ocultar();
                gridView.EndDataUpdate();

            }

        }

        //GUARDO LAS CONCILIACIONES
        private void GuardarConciliaciones()
        {
            try
            {                
                foreach (MC.AsientosDet p in Pases)
                {
                    p.SqlConnection = SqlConnection;
                    p.Abm();
                }                                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return;
            }
        }

        //FIN DEL GUARDADO
        private void FGuardarRegistros()
        {

            try
            {
                gridView.EndDataUpdate();
                OverlayPanel.Ocultar();
            }
            catch (Exception)
            {
                OverlayPanel.Ocultar();
                gridView.EndDataUpdate();

            }

        }

        private void Frm_ConciliacionBancaria_Shown(object sender, EventArgs e)
        {
            Parametrosinicio();
            IBusqRegistros();
        }

        private void bgwBusqregistros_DoWork(object sender, DoWorkEventArgs e)
        {
            GetRegistros();
        }

        private void bgwBusqregistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FBusqRegistros();
        }

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column == colConciliado) { ConciliarRegistro(); }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.C) { ConciliarRegistro(); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            IGuardarRegistros();
        }

        private void bgwGuardar_DoWork(object sender, DoWorkEventArgs e)
        {
            GuardarConciliaciones();
        }

        private void bgwGuardar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FGuardarRegistros();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IBusqRegistros();
        }
    }
}