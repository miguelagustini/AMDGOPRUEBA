using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraTab;
using DevExpress.XtraPivotGrid;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.XtraCharts;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Frm_Analisis : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private MC.DetalleGlobal DetallesGlob { get; set; } = new MC.DetalleGlobal();
        private List<MC.DetalleGlobal> DetallesGlblst { get; set; } = new List<MC.DetalleGlobal>();
        public bool Es_Popup { get; set; } = false;
        private int IDArancelenc { get; set; } = 0;
        private Point LocationSplash = new Point();

        private SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Analisis()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosed += new FormClosedEventHandler(Formulario_Closed);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250,
                                      workingArea.Top + 73);
        }

        #region METODOS MANUALES
                
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {

            SqlConnection = SqlConnection.State != System.Data.ConnectionState.Open ? cnb.Conectar() : SqlConnection;
            DetallesGlob.SqlConnection = SqlConnection;
            
            ctrls.PreferencesPivot(this, pvControl, "R");
            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);

            pvControl.OptionsView.ShowDataHeaders = false;
            pvControl.OptionsView.ShowFilterHeaders = false;            
            pvControl.OptionsView.ShowFilterSeparatorBar = false;
                        
            //colGrupoPractica.SortMode = PivotSortMode.Custom;

            ScreenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScreenManager.SplashFormLocation = LocationSplash;
            SetOptionsdefault();

        }

        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            pvControl.BeginUpdate();
            ScreenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScreenManager.SplashFormLocation = new Point(Width - 198, 61);
            if (!ScreenManager.IsSplashFormVisible) { ScreenManager.ShowWaitForm(); }


            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();

            
        }
        
        private void BusqRegistros()
        {
            try
            {
               
                DetallesGlblst.Clear();                
                DetallesGlblst.AddRange(DetallesGlob.GetRegistrosAnalisis());                
            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Hubo un error al asignar los datos.", 1);
                return;
            }
            
        }

        private void Fbusqregistros()
        {
            try
            {
                pvControl.DataSource = DetallesGlblst;
                pvControl.EndUpdate();
                pvControl.RefreshData();                
                ListarPrestadoras();
                
                if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al finalizar la búsqueda.\n{e.Message}", 1);
                if (ScreenManager.IsSplashFormVisible) { ScreenManager.CloseWaitForm(); }
                return;
            }
        }

        private void SetOptionsdefault(bool mode = true)//TRUE INICIO / FALSE CIERRE
        {
            chkValorpactadoanterior.EditValue = Properties.Settings.Default.Anl_colvalorpactant;
            chkDiferenciapactadoporc.EditValue = Properties.Settings.Default.Anl_coldifpactporc;

            Visibilidadcolumnas();

            

        }

        private void ListarPrestadoras()
        {
            try
            {
                foreach (string g in DetallesGlblst.GroupBy(s => s.Prestataria).Select(s => s.Key).ToList().OrderBy(o => o))
                {
                    cmbPrestadoras.Properties.Items.Add(g);
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al cargar la lista de grupos.\n {e.Message}", 0);
                return;
            }

        }
        
        //ORDEN CUSTOMIZADO DEL PIVOT
        private void pivotControl_CustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
        {
            /*if (e.Field.FieldName == "GrupoDescripcion")
            {
                if (e.SortLocation == PivotSortLocation.Pivot)
                {
                    object orderValue1 = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "GrupoOrden"),
                        orderValue2 = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "GrupoOrden");
                    e.Result = Comparer.Default.Compare(orderValue1, orderValue2);
                }
                else
                {
                    e.Result = Comparer.Default.Compare(e.Value1.ToString().Split(' ')[1], e.Value2.ToString().Split(' ')[1]);
                }
                e.Handled = true;
            }*/
        }

        private void ChkColumnas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit ch = sender as CheckEdit;

                if (ch == null) { return; }

                bool valor = (bool)ch.EditValue;

                switch (Convert.ToInt16(ch.Tag))
                {
                    case 0: Properties.Settings.Default.Anl_colvalorpactant = valor; break;
                    case 1: Properties.Settings.Default.Anl_coldifpactporc = valor; break;                    
                }

                Properties.Settings.Default.Save();

                Visibilidadcolumnas();
            }
            catch (Exception)
            {
            }
        }

        //VISIBILIDAD DE COLUMNAS
        private void Visibilidadcolumnas()
        {
            try
            {
                pvControl.BeginInit();

                colValorPactadoAnterior.Visible = Properties.Settings.Default.Anl_colvalorpactant;
                colDiferenciaPactadoAnterior.Visible = Properties.Settings.Default.Anl_coldifpactporc;
                
                pvControl.EndInit();
                pvControl.RefreshData();
            }
            catch (Exception)
            {
                pvControl.EndInit();
                pvControl.Refresh();
                return;
            }
        }

        //AGREGA FILTOS PRESTADORA
        private void FiltrarPrestadora()
        {
            try
            {                                                
                pvControl.Prefilter.Clear();

                foreach (string s in cmbPrestadoras.Properties.Items.GetCheckedValues().Select(s => s.ToString()))
                {   
                    if (string.IsNullOrEmpty(pvControl.Prefilter.CriteriaString))
                    {                        
                        pvControl.Prefilter.CriteriaString = $"[{colDesPrestataria.PrefilterColumnName}] = '{s}'";                    
                    }
                    else
                    {                        
                        if (!pvControl.Prefilter.CriteriaString.Contains(s))
                        {
                            pvControl.Prefilter.CriteriaString = pvControl.Prefilter.CriteriaString + $" OR [{colDesPrestataria.PrefilterColumnName}] = '{s}'";
                        }                       
                    } 
                }
                
            }
            catch (Exception)
            {                
                return;
            }
        }
               
        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            Ibusqregistros();
        }

        private void Formulario_Closed(object sender, FormClosedEventArgs e)
        {
            if (!Es_Popup)
            {
                if (Parent is XtraTabPage)
                {
                    XtraTabPage c = this.Parent as XtraTabPage;
                    XtraTabControl x = c.Parent as XtraTabControl;
                    x.TabPages.Remove(c);
                }
            }

            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            ctrls.PreferencesPivot(this, pvControl, "S");
        }
        
        private void bgwRegistros_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
              BusqRegistros();             
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Fbusqregistros();             
        }
      
        private void pvControl_CustomAppearance(object sender, PivotCustomAppearanceEventArgs e)
        {
            try
            {
                if ((e.DataField == colDiferenciaPactadoAnterior) && e.ColumnValueType == PivotGridValueType.Value                
                    && e.RowValueType == PivotGridValueType.Value)
                {
                    if (e.Value != null)
                    {                        
                        //POSITIVOS
                        if ((decimal)e.Value >= 75)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#272F7F");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                            
                        }
                        else if ((decimal)e.Value >= 50)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#1A4301");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                            
                        }
                        else if ((decimal)e.Value >= 25)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#538D22");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#030800");
                            
                        }
                        else if ((decimal)e.Value > 0)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#AAD576");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#030800");
                            
                        }
                        //CERO
                        else if ((decimal)e.Value == 0)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#EEF5E6");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#030800");
                            
                        }
                        //NEGATIVOS
                        else if ((decimal)e.Value >= -25)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#FFBA08");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#030800");
                            
                        }
                        else if ((decimal)e.Value >= -50)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#E85D04");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                            
                        }
                        else if ((decimal)e.Value < -50)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#9D0208");
                            e.Appearance.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                            
                        }
                        
                    }
                }
            }
            catch (Exception)
            {                
                
            }
            
        }

        private void btnExportarxls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrls.ExportaraExcelpvgr(pvControl);
        }

        private void pvControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(pvControl.PointToScreen(e.Point));
        }

        private void cmbPrestadoras_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        
        private void dockGraficos_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            try
            {
                if (Convert.ToByte(e.Button.Properties.Tag) == 0) { chart.SeriesTemplate.ChangeView(ViewType.Bar); }
                else if (Convert.ToByte(e.Button.Properties.Tag) == 1) { chart.SeriesTemplate.ChangeView(ViewType.StackedBar); }
                else if (Convert.ToByte(e.Button.Properties.Tag) == 2) { chart.SeriesTemplate.ChangeView(ViewType.NestedDoughnut); }


            }
            catch (Exception)
            {
                ctrls.MensajeInfo("Gráfico no compatible", 1);
            }
        }

        private void cmbPrestadoras_Popup(object sender, EventArgs e)
        {
            var edit = sender as CheckedComboBoxEdit;
            var form = edit.GetPopupEditForm();
            form.OkButton.Click -= okBtn_Click;
            form.OkButton.Click += okBtn_Click;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            FiltrarPrestadora();
        }

        //SeriesPoint m_HotTrackedPoint;

        private void chart_ObjectHotTracked(object sender, HotTrackEventArgs e)
        {
          /*  SeriesPoint point = e.AdditionalObject as SeriesPoint;
            if (!Object.ReferenceEquals(point, m_HotTrackedPoint))
            {
                m_HotTrackedPoint = point;
                chart.Refresh();
            }*/

        }

        private void chart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            /*if (!Object.Equals(e.SeriesPoint, m_HotTrackedPoint))
            {
                e.LabelText = "";
            }*/
        }
    }
}