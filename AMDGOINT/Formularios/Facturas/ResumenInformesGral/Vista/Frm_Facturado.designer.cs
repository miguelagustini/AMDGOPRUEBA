namespace AMDGOINT.Formularios.Facturas.ResumenInformesGral.Vista
{
    partial class Frm_Facturado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Facturado));
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentacodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentanombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpraccodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPracticanombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colHonorario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGastos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmedicamentos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnBuscar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnExportExcel = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "C2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes,
            this.reposDecimal});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1176, 375);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.ChildGridLevelName = "gridViewdet";
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPeriodo,
            this.colCuentacodigo,
            this.colCuentanombre,
            this.colpraccodigo,
            this.colPracticanombre,
            this.colCantidad,
            this.colHonorario,
            this.colGastos,
            this.colmedicamentos,
            this.colNeto,
            this.colIva,
            this.colTotal,
            this.colFuncion});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindDelay = 500;
            this.gridView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.gridView.OptionsFind.ShowCloseButton = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Período";
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 0;
            this.colPeriodo.Width = 82;
            // 
            // colCuentacodigo
            // 
            this.colCuentacodigo.Caption = "Cuenta";
            this.colCuentacodigo.FieldName = "ProfesionalCuentaCodigo";
            this.colCuentacodigo.Name = "colCuentacodigo";
            this.colCuentacodigo.Visible = true;
            this.colCuentacodigo.VisibleIndex = 1;
            this.colCuentacodigo.Width = 99;
            // 
            // colCuentanombre
            // 
            this.colCuentanombre.Caption = "Nombre";
            this.colCuentanombre.FieldName = "ProfesionalCuentaNombre";
            this.colCuentanombre.Name = "colCuentanombre";
            this.colCuentanombre.Visible = true;
            this.colCuentanombre.VisibleIndex = 2;
            this.colCuentanombre.Width = 99;
            // 
            // colpraccodigo
            // 
            this.colpraccodigo.Caption = "Práctica Código";
            this.colpraccodigo.FieldName = "PracticaCodigo";
            this.colpraccodigo.Name = "colpraccodigo";
            this.colpraccodigo.Visible = true;
            this.colpraccodigo.VisibleIndex = 3;
            this.colpraccodigo.Width = 80;
            // 
            // colPracticanombre
            // 
            this.colPracticanombre.Caption = "Práctica";
            this.colPracticanombre.FieldName = "PracticaDescripcion";
            this.colPracticanombre.Name = "colPracticanombre";
            this.colPracticanombre.Visible = true;
            this.colPracticanombre.VisibleIndex = 4;
            this.colPracticanombre.Width = 131;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.ColumnEdit = this.reposDecimal;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N2}")});
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 6;
            this.colCantidad.Width = 96;
            // 
            // reposDecimal
            // 
            this.reposDecimal.AutoHeight = false;
            this.reposDecimal.Mask.EditMask = "N2";
            this.reposDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimal.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimal.Name = "reposDecimal";
            // 
            // colHonorario
            // 
            this.colHonorario.AppearanceHeader.Options.UseTextOptions = true;
            this.colHonorario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHonorario.Caption = "$ Honorarios";
            this.colHonorario.ColumnEdit = this.reposImportes;
            this.colHonorario.FieldName = "ImporteHonorarios";
            this.colHonorario.Name = "colHonorario";
            this.colHonorario.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteHonorarios", "{0:C2}")});
            this.colHonorario.Visible = true;
            this.colHonorario.VisibleIndex = 7;
            this.colHonorario.Width = 96;
            // 
            // colGastos
            // 
            this.colGastos.AppearanceHeader.Options.UseTextOptions = true;
            this.colGastos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colGastos.Caption = "$ Gastos";
            this.colGastos.ColumnEdit = this.reposImportes;
            this.colGastos.FieldName = "ImporteGastos";
            this.colGastos.Name = "colGastos";
            this.colGastos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteGastos", "{0:C2}")});
            this.colGastos.Visible = true;
            this.colGastos.VisibleIndex = 8;
            this.colGastos.Width = 96;
            // 
            // colmedicamentos
            // 
            this.colmedicamentos.AppearanceHeader.Options.UseTextOptions = true;
            this.colmedicamentos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colmedicamentos.Caption = "$ Medicamentos";
            this.colmedicamentos.ColumnEdit = this.reposImportes;
            this.colmedicamentos.FieldName = "ImporteMedicamentos";
            this.colmedicamentos.Name = "colmedicamentos";
            this.colmedicamentos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteMedicamentos", "{0:C2}")});
            this.colmedicamentos.Visible = true;
            this.colmedicamentos.VisibleIndex = 9;
            this.colmedicamentos.Width = 116;
            // 
            // colNeto
            // 
            this.colNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.Caption = "$ Neto";
            this.colNeto.ColumnEdit = this.reposImportes;
            this.colNeto.FieldName = "ImporteNeto";
            this.colNeto.Name = "colNeto";
            this.colNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteNeto", "{0:C2}")});
            this.colNeto.Visible = true;
            this.colNeto.VisibleIndex = 10;
            this.colNeto.Width = 90;
            // 
            // colIva
            // 
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "$ Iva";
            this.colIva.ColumnEdit = this.reposImportes;
            this.colIva.FieldName = "ImporteIva";
            this.colIva.Name = "colIva";
            this.colIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:C2}")});
            this.colIva.Visible = true;
            this.colIva.VisibleIndex = 11;
            this.colIva.Width = 90;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "$ Total";
            this.colTotal.ColumnEdit = this.reposImportes;
            this.colTotal.FieldName = "ImporteTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 12;
            this.colTotal.Width = 101;
            // 
            // colFuncion
            // 
            this.colFuncion.Caption = "Función";
            this.colFuncion.FieldName = "PracticaFuncion";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.Visible = true;
            this.colFuncion.VisibleIndex = 5;
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // navButton1
            // 
            this.navButton1.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton1.Caption = "navButton2";
            this.navButton1.Name = "navButton1";
            // 
            // bgwObtienereg
            // 
            this.bgwObtienereg.WorkerSupportsCancellation = true;
            this.bgwObtienereg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwObtienereg_DoWork);
            this.bgwObtienereg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwObtienereg_RunWorkerCompleted);
            // 
            // dockManager
            // 
            this.dockManager.DockingOptions.ShowCloseButton = false;
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelEncabezado});
            this.dockManager.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.dockPanel1_Container);
            this.panelEncabezado.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelEncabezado.ID = new System.Guid("32d67652-40b1-48b7-afe8-19c2d531847f");
            this.panelEncabezado.Location = new System.Drawing.Point(0, 52);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.OriginalSize = new System.Drawing.Size(1082, 200);
            this.panelEncabezado.Size = new System.Drawing.Size(1176, 398);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Prácticas";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1176, 375);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnBuscar);
            this.NavPanel.Buttons.Add(this.btnExportExcel);
            // 
            // tileNavCategory1
            // 
            this.NavPanel.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.NavPanel.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.NavPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(1176, 52);
            this.NavPanel.TabIndex = 8;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Caption = "Buscar";
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnBuscar_ElementClick);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnExportExcel.Caption = "Exportar Xls";
            this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnExportExcel_ElementClick);
            // 
            // Frm_Facturado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 450);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.NavPanel);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_Facturado";
            this.Text = "Resúmen de Facturación";
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private System.ComponentModel.BackgroundWorker bgwObtienereg;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel panelEncabezado;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentacodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentanombre;
        private DevExpress.XtraGrid.Columns.GridColumn colpraccodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPracticanombre;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colHonorario;
        private DevExpress.XtraGrid.Columns.GridColumn colGastos;
        private DevExpress.XtraGrid.Columns.GridColumn colmedicamentos;
        private DevExpress.XtraGrid.Columns.GridColumn colNeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimal;
        private DevExpress.XtraBars.Navigation.NavButton btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncion;
        private DevExpress.XtraBars.Navigation.NavButton btnExportExcel;
    }
}