namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    partial class Frm_Prestatarias
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Prestatarias));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCondicionIVa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMipyme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tglStrings = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.colComprobanteX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.panelContainer2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.panelCtasCtes = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer3 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelPlanes = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContactos = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnNuevo = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditar = new DevExpress.XtraBars.Navigation.NavButton();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.tmrEscucha = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglStrings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelContainer2.SuspendLayout();
            this.panelCtasCtes.SuspendLayout();
            this.panelPlanes.SuspendLayout();
            this.panelContactos.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
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
            this.tglStrings});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1082, 135);
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
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            this.colRazonSocial,
            this.colCuit,
            this.colAbreviatura,
            this.colCondicionIVa,
            this.colDomicilio,
            this.colMipyme,
            this.colComprobanteX,
            this.colVencimiento});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "ComprobanteRechazado";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[EstadoAf] <> \'A\'";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "ComprobantesAsociados";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[ComprobantesAsociados]";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "ComprobanteAnulado";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            formatConditionRuleValue3.Appearance.Options.HighPriority = true;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue3.Expression = "[Anulada]";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.FormatRules.Add(gridFormatRule3);
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
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.Caption = "Razón Social";
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 0;
            this.colRazonSocial.Width = 427;
            // 
            // colCuit
            // 
            this.colCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCuit.Caption = "Cuit";
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.VisibleIndex = 1;
            this.colCuit.Width = 119;
            // 
            // colAbreviatura
            // 
            this.colAbreviatura.Caption = "Abreviatura";
            this.colAbreviatura.FieldName = "Abreviatura";
            this.colAbreviatura.Name = "colAbreviatura";
            this.colAbreviatura.Visible = true;
            this.colAbreviatura.VisibleIndex = 3;
            this.colAbreviatura.Width = 154;
            // 
            // colCondicionIVa
            // 
            this.colCondicionIVa.AppearanceCell.Options.UseTextOptions = true;
            this.colCondicionIVa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCondicionIVa.AppearanceHeader.Options.UseTextOptions = true;
            this.colCondicionIVa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCondicionIVa.Caption = "Iva";
            this.colCondicionIVa.FieldName = "IvaAbreviatura";
            this.colCondicionIVa.Name = "colCondicionIVa";
            this.colCondicionIVa.Visible = true;
            this.colCondicionIVa.VisibleIndex = 4;
            this.colCondicionIVa.Width = 74;
            // 
            // colDomicilio
            // 
            this.colDomicilio.Caption = "Domicilio Legal";
            this.colDomicilio.FieldName = "DomicilioFiscal";
            this.colDomicilio.Name = "colDomicilio";
            this.colDomicilio.Visible = true;
            this.colDomicilio.VisibleIndex = 2;
            this.colDomicilio.Width = 310;
            // 
            // colMipyme
            // 
            this.colMipyme.Caption = "MiPyme";
            this.colMipyme.ColumnEdit = this.tglStrings;
            this.colMipyme.FieldName = "MiPymeDescripcion";
            this.colMipyme.Name = "colMipyme";
            this.colMipyme.Visible = true;
            this.colMipyme.VisibleIndex = 5;
            this.colMipyme.Width = 99;
            // 
            // tglStrings
            // 
            this.tglStrings.AutoHeight = false;
            this.tglStrings.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tglStrings.Name = "tglStrings";
            this.tglStrings.OffText = "No";
            this.tglStrings.OnText = "Si";
            this.tglStrings.ValueOff = "No";
            this.tglStrings.ValueOn = "Si";
            // 
            // colComprobanteX
            // 
            this.colComprobanteX.Caption = "Proforma X";
            this.colComprobanteX.ColumnEdit = this.tglStrings;
            this.colComprobanteX.FieldName = "AceptaComprobanteXDescripcion";
            this.colComprobanteX.Name = "colComprobanteX";
            this.colComprobanteX.Visible = true;
            this.colComprobanteX.VisibleIndex = 6;
            this.colComprobanteX.Width = 99;
            // 
            // colVencimiento
            // 
            this.colVencimiento.AppearanceCell.Options.UseTextOptions = true;
            this.colVencimiento.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVencimiento.AppearanceHeader.Options.UseTextOptions = true;
            this.colVencimiento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVencimiento.Caption = "Dias Vto.";
            this.colVencimiento.FieldName = "DiasVencimiento";
            this.colVencimiento.Name = "colVencimiento";
            this.colVencimiento.Visible = true;
            this.colVencimiento.VisibleIndex = 7;
            this.colVencimiento.Width = 65;
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
            this.barManager1.MaxItemId = 4;
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
            this.panelContainer2,
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
            // panelContainer2
            // 
            this.panelContainer2.ActiveChild = this.panelPlanes;
            this.panelContainer2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelContainer2.Appearance.Options.UseBorderColor = true;
            this.panelContainer2.Controls.Add(this.panelPlanes);
            this.panelContainer2.Controls.Add(this.panelContactos);
            this.panelContainer2.Controls.Add(this.panelCtasCtes);
            this.panelContainer2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelContainer2.ID = new System.Guid("20852f1b-93d7-41a8-bc3f-0aed73934394");
            this.panelContainer2.Location = new System.Drawing.Point(0, 210);
            this.panelContainer2.Name = "panelContainer2";
            this.panelContainer2.OriginalSize = new System.Drawing.Size(200, 240);
            this.panelContainer2.Size = new System.Drawing.Size(1082, 240);
            this.panelContainer2.Tabbed = true;
            this.panelContainer2.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelContainer2.TabStop = false;
            this.panelContainer2.Text = "panelContainer2";
            // 
            // panelCtasCtes
            // 
            this.panelCtasCtes.Controls.Add(this.controlContainer3);
            this.panelCtasCtes.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelCtasCtes.ID = new System.Guid("7654e1fb-e884-4daa-906e-634b9aea336e");
            this.panelCtasCtes.Location = new System.Drawing.Point(0, 50);
            this.panelCtasCtes.Name = "panelCtasCtes";
            this.panelCtasCtes.OriginalSize = new System.Drawing.Size(1082, 92);
            this.panelCtasCtes.Size = new System.Drawing.Size(1082, 190);
            this.panelCtasCtes.Text = "Movimientos de Comprobantes";
            // 
            // controlContainer3
            // 
            this.controlContainer3.Location = new System.Drawing.Point(0, 0);
            this.controlContainer3.Name = "controlContainer3";
            this.controlContainer3.Size = new System.Drawing.Size(1082, 190);
            this.controlContainer3.TabIndex = 0;
            // 
            // panelPlanes
            // 
            this.panelPlanes.Controls.Add(this.controlContainer2);
            this.panelPlanes.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelPlanes.ID = new System.Guid("98741eb0-6c9d-444a-9223-8c78b13d2808");
            this.panelPlanes.Location = new System.Drawing.Point(0, 50);
            this.panelPlanes.Name = "panelPlanes";
            this.panelPlanes.OriginalSize = new System.Drawing.Size(1082, 92);
            this.panelPlanes.Size = new System.Drawing.Size(1082, 190);
            this.panelPlanes.Text = "Planes";
            // 
            // controlContainer2
            // 
            this.controlContainer2.Location = new System.Drawing.Point(0, 0);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(1082, 190);
            this.controlContainer2.TabIndex = 0;
            // 
            // panelContactos
            // 
            this.panelContactos.Controls.Add(this.controlContainer1);
            this.panelContactos.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContactos.ID = new System.Guid("91ca2923-523c-4f15-aa88-2ed7d4f4829b");
            this.panelContactos.Location = new System.Drawing.Point(0, 50);
            this.panelContactos.Name = "panelContactos";
            this.panelContactos.OriginalSize = new System.Drawing.Size(1082, 92);
            this.panelContactos.Size = new System.Drawing.Size(1082, 190);
            this.panelContactos.Text = "Contactos";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(1082, 190);
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
            this.panelEncabezado.Size = new System.Drawing.Size(1082, 158);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Datos Generales";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1082, 135);
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
            // 
            // btnNuevo
            // 
            this.btnNuevo.Caption = "Nueva";
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnNuevo_ElementClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditar_ElementClick);
            // 
            // panelContainer1
            // 
            this.panelContainer1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelContainer1.Appearance.Options.UseBorderColor = true;
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("2797c4d1-fa07-4222-a93f-3933974d4016");
            this.panelContainer1.Location = new System.Drawing.Point(0, 275);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 175);
            this.panelContainer1.Size = new System.Drawing.Size(1082, 175);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // tmrEscucha
            // 
            this.tmrEscucha.Interval = 1000;
            this.tmrEscucha.Tick += new System.EventHandler(this.tmrEscucha_Tick);
            // 
            // Frm_Prestatarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 450);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.panelContainer2);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.NavPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_Prestatarias";
            this.Text = "Prestatarias";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglStrings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelContainer2.ResumeLayout(false);
            this.panelCtasCtes.ResumeLayout(false);
            this.panelPlanes.ResumeLayout(false);
            this.panelContactos.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
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
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel panelPlanes;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colAbreviatura;
        private DevExpress.XtraGrid.Columns.GridColumn colCondicionIVa;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colMipyme;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteX;
        private DevExpress.XtraGrid.Columns.GridColumn colVencimiento;
        private DevExpress.XtraBars.Navigation.NavButton btnNuevo;
        private DevExpress.XtraBars.Navigation.NavButton btnEditar;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch tglStrings;
        private DevExpress.XtraBars.Docking.DockPanel panelContactos;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer2;
        private System.Windows.Forms.Timer tmrEscucha;
        private DevExpress.XtraBars.Docking.DockPanel panelCtasCtes;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer3;
    }
}