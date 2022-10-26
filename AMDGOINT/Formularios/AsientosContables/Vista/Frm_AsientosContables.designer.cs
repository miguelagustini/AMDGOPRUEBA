namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    partial class Frm_AsientosContables
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AsientosContables));
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colhaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAsientoNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposNumero = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelDetalles = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnNuevo = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnConciliacionBancaria = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnCierreAnual = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnImpresion = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.btnLibroDiario = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnMayorCuenta = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnBalanceintegracion = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.timerEscucha = new System.Windows.Forms.Timer(this.components);
            this.bgwImpresion = new System.ComponentModel.BackgroundWorker();
            this.btnImprimirAsiento = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelDetalles.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // colDebe
            // 
            this.colDebe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebe.Caption = "$ Debe";
            this.colDebe.ColumnEdit = this.reposImportes;
            this.colDebe.FieldName = "ImporteDebe";
            this.colDebe.Name = "colDebe";
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 3;
            this.colDebe.Width = 176;
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "C2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // colhaber
            // 
            this.colhaber.AppearanceHeader.Options.UseTextOptions = true;
            this.colhaber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colhaber.Caption = "$ Haber";
            this.colhaber.ColumnEdit = this.reposImportes;
            this.colhaber.FieldName = "ImporteHaber";
            this.colhaber.Name = "colhaber";
            this.colhaber.Visible = true;
            this.colhaber.VisibleIndex = 4;
            this.colhaber.Width = 188;
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
            this.reposDate,
            this.reposNumero});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1082, 239);
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
            this.colFechaMovimiento,
            this.colAsientoNro,
            this.colDescripcion,
            this.colDebe,
            this.colhaber});
            gridFormatRule1.Column = this.colDebe;
            gridFormatRule1.Name = "ImportesNegativosDebe";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = 0D;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.colhaber;
            gridFormatRule2.Name = "ImporteNegativoHaber";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue2.Value1 = 0D;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
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
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView_CustomSummaryCalculate);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            // 
            // colFechaMovimiento
            // 
            this.colFechaMovimiento.Caption = "Fecha";
            this.colFechaMovimiento.ColumnEdit = this.reposDate;
            this.colFechaMovimiento.FieldName = "AsientoFecha";
            this.colFechaMovimiento.Name = "colFechaMovimiento";
            this.colFechaMovimiento.Visible = true;
            this.colFechaMovimiento.VisibleIndex = 0;
            this.colFechaMovimiento.Width = 111;
            // 
            // reposDate
            // 
            this.reposDate.AutoHeight = false;
            this.reposDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.Mask.EditMask = "dd-MM-yyyy";
            this.reposDate.Mask.UseMaskAsDisplayFormat = true;
            this.reposDate.Name = "reposDate";
            // 
            // colAsientoNro
            // 
            this.colAsientoNro.AppearanceHeader.Options.UseTextOptions = true;
            this.colAsientoNro.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAsientoNro.Caption = "Asiento Nro.";
            this.colAsientoNro.ColumnEdit = this.reposNumero;
            this.colAsientoNro.FieldName = "AsientoNumero";
            this.colAsientoNro.Name = "colAsientoNro";
            this.colAsientoNro.Visible = true;
            this.colAsientoNro.VisibleIndex = 1;
            this.colAsientoNro.Width = 110;
            // 
            // reposNumero
            // 
            this.reposNumero.Appearance.Options.UseTextOptions = true;
            this.reposNumero.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.reposNumero.AutoHeight = false;
            this.reposNumero.Mask.EditMask = "N0";
            this.reposNumero.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumero.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumero.Name = "reposNumero";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Observacion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 2;
            this.colDescripcion.Width = 762;
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
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimirAsiento)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnImprimirAsiento});
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1082, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1082, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 450);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1082, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 450);
            // 
            // dockManager
            // 
            this.dockManager.DockingOptions.ShowCloseButton = false;
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager1;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelDetalles,
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
            // panelDetalles
            // 
            this.panelDetalles.Controls.Add(this.controlContainer1);
            this.panelDetalles.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelDetalles.ID = new System.Guid("a00c15a3-910d-4b80-a2aa-892fbf6105dc");
            this.panelDetalles.Location = new System.Drawing.Point(0, 314);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.OriginalSize = new System.Drawing.Size(200, 136);
            this.panelDetalles.Size = new System.Drawing.Size(1082, 136);
            this.panelDetalles.Text = "Detalles";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(0, 24);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(1082, 112);
            this.controlContainer1.TabIndex = 0;
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.dockPanel1_Container);
            this.panelEncabezado.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelEncabezado.ID = new System.Guid("32d67652-40b1-48b7-afe8-19c2d531847f");
            this.panelEncabezado.Location = new System.Drawing.Point(0, 52);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.OriginalSize = new System.Drawing.Size(1082, 200);
            this.panelEncabezado.Size = new System.Drawing.Size(1082, 262);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Asientos";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1082, 239);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnNuevo);
            this.NavPanel.Buttons.Add(this.btnEditar);
            this.NavPanel.Buttons.Add(this.btnActualizar);
            this.NavPanel.Buttons.Add(this.btnConciliacionBancaria);
            this.NavPanel.Buttons.Add(this.btnCierreAnual);
            this.NavPanel.Buttons.Add(this.btnImpresion);
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
            this.NavPanel.Size = new System.Drawing.Size(1082, 52);
            this.NavPanel.TabIndex = 8;
            this.NavPanel.Text = "tileNavPane1";
            this.NavPanel.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.NavPanel_ElementClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnNuevo.Caption = "Nuevo";
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnNuevo_ElementClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Visible = false;
            this.btnEditar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditar_ElementClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnActualizar_ElementClick);
            // 
            // btnConciliacionBancaria
            // 
            this.btnConciliacionBancaria.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnConciliacionBancaria.Caption = "Conciliación Bancaria";
            this.btnConciliacionBancaria.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConciliacionBancaria.ImageOptions.Image")));
            this.btnConciliacionBancaria.Name = "btnConciliacionBancaria";
            this.btnConciliacionBancaria.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnConciliacionBancaria_ElementClick);
            // 
            // btnCierreAnual
            // 
            this.btnCierreAnual.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnCierreAnual.Caption = "Cierre del Ejercicio";
            this.btnCierreAnual.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCierreAnual.ImageOptions.Image")));
            this.btnCierreAnual.Name = "btnCierreAnual";
            this.btnCierreAnual.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnCierreAnual_ElementClick);
            // 
            // btnImpresion
            // 
            this.btnImpresion.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnImpresion.Caption = "Impresión";
            this.btnImpresion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImpresion.ImageOptions.Image")));
            this.btnImpresion.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.btnLibroDiario,
            this.btnMayorCuenta,
            this.btnBalanceintegracion});
            this.btnImpresion.Name = "btnImpresion";
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipItem1.Text = "Opciones de Impresión";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnImpresion.SuperTip = superToolTip1;
            // 
            // 
            // 
            this.btnImpresion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            tileItemElement4.Text = "Opciones de Impresión";
            this.btnImpresion.Tile.Elements.Add(tileItemElement4);
            // 
            // btnLibroDiario
            // 
            this.btnLibroDiario.Caption = "Libro Diario";
            this.btnLibroDiario.Name = "btnLibroDiario";
            // 
            // 
            // 
            this.btnLibroDiario.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement1.ImageOptions.ImageToTextIndent = 10;
            tileItemElement1.Text = "Libro Diario";
            this.btnLibroDiario.Tile.Elements.Add(tileItemElement1);
            this.btnLibroDiario.Tile.Name = "tileBarItem1";
            // 
            // btnMayorCuenta
            // 
            this.btnMayorCuenta.Caption = "Mayor de Cuenta";
            this.btnMayorCuenta.Name = "btnMayorCuenta";
            // 
            // 
            // 
            this.btnMayorCuenta.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement2.ImageOptions.ImageToTextIndent = 10;
            tileItemElement2.Text = "Mayor de Cuenta";
            this.btnMayorCuenta.Tile.Elements.Add(tileItemElement2);
            this.btnMayorCuenta.Tile.Name = "tileBarItem2";
            // 
            // btnBalanceintegracion
            // 
            this.btnBalanceintegracion.Caption = "tileNavItem1";
            this.btnBalanceintegracion.Name = "btnBalanceintegracion";
            // 
            // 
            // 
            this.btnBalanceintegracion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement3.ImageOptions.ImageToTextIndent = 10;
            tileItemElement3.Text = "Balance Integración";
            this.btnBalanceintegracion.Tile.Elements.Add(tileItemElement3);
            this.btnBalanceintegracion.Tile.Name = "tileBarItem1";
            // 
            // timerEscucha
            // 
            this.timerEscucha.Enabled = true;
            this.timerEscucha.Interval = 500;
            this.timerEscucha.Tick += new System.EventHandler(this.timerEscucha_Tick);
            // 
            // bgwImpresion
            // 
            this.bgwImpresion.WorkerSupportsCancellation = true;
            this.bgwImpresion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwImpresion_DoWork);
            this.bgwImpresion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwImpresion_RunWorkerCompleted);
            // 
            // btnImprimirAsiento
            // 
            this.btnImprimirAsiento.Caption = "Visualizar Asiento";
            this.btnImprimirAsiento.Id = 6;
            this.btnImprimirAsiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirAsiento.ImageOptions.Image")));
            this.btnImprimirAsiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirAsiento.ImageOptions.LargeImage")));
            this.btnImprimirAsiento.Name = "btnImprimirAsiento";
            this.btnImprimirAsiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimirAsiento_ItemClick);
            // 
            // Frm_AsientosContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 450);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.NavPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_AsientosContables";
            this.Text = "Asientos Contables";
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelDetalles.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private System.ComponentModel.BackgroundWorker bgwObtienereg;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel panelEncabezado;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraBars.Navigation.TileNavCategory btnImpresion;
        private DevExpress.XtraBars.Navigation.NavButton btnNuevo;
        private System.Windows.Forms.Timer timerEscucha;
        private DevExpress.XtraBars.Navigation.NavButton btnActualizar;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colAsientoNro;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraGrid.Columns.GridColumn colhaber;
        private DevExpress.XtraBars.Docking.DockPanel panelDetalles;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Navigation.NavButton btnEditar;
        private DevExpress.XtraBars.Navigation.NavButton btnCierreAnual;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumero;
        private DevExpress.XtraBars.Navigation.TileNavItem btnLibroDiario;
        private DevExpress.XtraBars.Navigation.TileNavItem btnMayorCuenta;
        private System.ComponentModel.BackgroundWorker bgwImpresion;
        private DevExpress.XtraBars.Navigation.TileNavItem btnBalanceintegracion;
        private DevExpress.XtraBars.Navigation.NavButton btnConciliacionBancaria;
        private DevExpress.XtraBars.BarButtonItem btnImprimirAsiento;
    }
}