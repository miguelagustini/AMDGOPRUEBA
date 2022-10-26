using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;

namespace AMDGOINT.Formularios.Practicas
{
    public partial class Frm_PracticasMain : DevExpress.XtraEditors.XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();        
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Practicasclass clpracticas = new Practicasclass();

        private int IDRegistro { get; set; } = 0;
        private int indexrow = -1;
        
        public Frm_PracticasMain()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            ctrls.setSplitter(splitter);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            tableLayoutPanel1.RowStyles[1].Height = 0;
            ctrls.PreferencesGrid(this, bgridView, "R");

            notificacionesBD.ID_Consulta = 4;
            notificacionesBD.ListenerChange();

            
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            tmrescucha.Stop();
            bgridView.BeginDataUpdate();
            flyoutPanel.ShowPopup();
            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {            
            flyoutPanel.HidePopup();
            gridControl.DataSource = clpracticas.practicaslst;
            bgridView.EndDataUpdate();            
                        
            if (bgridView.RowCount >= indexrow) { bgridView.FocusedRowHandle = indexrow; }

            tmrescucha.Start();
        }

     
        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_Practicas formulario = new Frm_Practicas();
                formulario.Es_Popup = true;

                if (acc == "N") { formulario.IDRegistro = 0; } else { formulario.IDRegistro = IDRegistro; }

                if (formulario.ShowDialog(this) == DialogResult.OK)
                { indexrow = bgridView.FocusedRowHandle; Ibusqregistros(); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo(e.Message, 0);
                return;
            }
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            splitter.SplitterPosition = (splitter.Height / 2);
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridView, "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            clpracticas.GetPracticaslst();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }

        private void bgridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {

            var est = bgridView.GetFocusedRowCellValue(colEstado);

            if (est != null && Convert.ToBoolean(est)) { btnEstadopract.Caption = "Deshabilitar"; }
            else { btnEstadopract.Caption = "Habilitar"; }

        }

        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }
            IDRegistro = 0;

            if (bgridView.RowCount <= 0) { return; }

            var idreg = bgridView.GetFocusedRowCellValue(colID_Registro);

            if (idreg != null)
            {
                IDRegistro = Convert.ToInt32(idreg);                
            }
        }

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }

        private void btnNuevaprest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarprest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void btNuevoBar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void btnEstadopract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ctrls.MensajePregunta("¿Cambiar el estado de ésta práctica?") == DialogResult.Yes)
            {
                var v = bgridView.GetFocusedRowCellValue(colEstado);
                var i = bgridView.GetFocusedRowCellValue(colID_Registro);

                if (v != null && i != null) { clpracticas.Setestadoprac(!Convert.ToBoolean(v), Convert.ToInt32(i)); }
            }
        }
    }
}