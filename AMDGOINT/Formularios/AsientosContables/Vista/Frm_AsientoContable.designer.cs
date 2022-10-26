namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    partial class Frm_AsientoContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AsientoContable));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.txtMemo = new DevExpress.XtraEditors.MemoEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnBorrarRegistro = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposText150 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCuentaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCmbCuenta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colpCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpCodigol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCuentaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCmbSubcuenta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.lblFechaAsiento = new DevExpress.XtraEditors.LabelControl();
            this.datFechaAsiento = new DevExpress.XtraEditors.DateEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.bgwEmiteFactura = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposText150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbSubcuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaAsiento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaAsiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // colDebe
            // 
            this.colDebe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebe.Caption = "$ Debe";
            this.colDebe.ColumnEdit = this.reposMoneda;
            this.colDebe.FieldName = "ImporteDebe";
            this.colDebe.Name = "colDebe";
            this.colDebe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteDebe", "{0:C2}")});
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 3;
            this.colDebe.Width = 153;
            // 
            // reposMoneda
            // 
            this.reposMoneda.AutoHeight = false;
            this.reposMoneda.Mask.EditMask = "C2";
            this.reposMoneda.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposMoneda.Mask.UseMaskAsDisplayFormat = true;
            this.reposMoneda.Name = "reposMoneda";
            // 
            // colHaber
            // 
            this.colHaber.AppearanceHeader.Options.UseTextOptions = true;
            this.colHaber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHaber.Caption = "$ Haber";
            this.colHaber.ColumnEdit = this.reposMoneda;
            this.colHaber.FieldName = "ImporteHaber";
            this.colHaber.Name = "colHaber";
            this.colHaber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteHaber", "{0:C2}")});
            this.colHaber.Visible = true;
            this.colHaber.VisibleIndex = 4;
            this.colHaber.Width = 148;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaAsiento, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.datFechaAsiento, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1005, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 657F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableLayoutPanel3.Controls.Add(this.btnGenerar, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtMemo, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 291);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(999, 55);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Appearance.Options.UseFont = true;
            this.btnGenerar.AppearanceHovered.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerar.AppearanceHovered.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.AppearanceHovered.Options.UseBackColor = true;
            this.btnGenerar.AppearanceHovered.Options.UseFont = true;
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.ImageOptions.Image")));
            this.btnGenerar.Location = new System.Drawing.Point(789, 3);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGenerar.Size = new System.Drawing.Size(207, 49);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Generar Asientos";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 36);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Descripción del Asiento";
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtMemo
            // 
            this.txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemo.Location = new System.Drawing.Point(89, 3);
            this.txtMemo.MenuManager = this.barManager1;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMemo.Properties.MaxLength = 500;
            this.txtMemo.Size = new System.Drawing.Size(651, 49);
            this.txtMemo.TabIndex = 10;
            this.txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMemo_KeyDown);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnBorrarRegistro});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1005, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 349);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1005, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 349);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1005, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 349);
            // 
            // btnBorrarRegistro
            // 
            this.btnBorrarRegistro.Caption = "Borrar Registro";
            this.btnBorrarRegistro.Id = 1;
            this.btnBorrarRegistro.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarRegistro.ImageOptions.Image")));
            this.btnBorrarRegistro.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBorrarRegistro.ImageOptions.LargeImage")));
            this.btnBorrarRegistro.Name = "btnBorrarRegistro";
            this.btnBorrarRegistro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBorrarRegistro_ItemClick);
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 3);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 33);
            this.gridControl.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMoneda,
            this.reposText150,
            this.reposCmbCuenta,
            this.reposCmbSubcuenta});
            this.gridControl.Size = new System.Drawing.Size(999, 252);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion,
            this.colCuentaID,
            this.colSubCuentaID,
            this.colDebe,
            this.colHaber});
            gridFormatRule1.Column = this.colDebe;
            gridFormatRule1.Name = "ImporteNegativoDebe";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.colHaber;
            gridFormatRule2.Name = "ImporteNegativoHaber";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue2.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.ColumnEdit = this.reposText150;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            this.colDescripcion.Width = 197;
            // 
            // reposText150
            // 
            this.reposText150.AutoHeight = false;
            this.reposText150.MaxLength = 150;
            this.reposText150.Name = "reposText150";
            this.reposText150.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reposTexto_KeyDown);
            // 
            // colCuentaID
            // 
            this.colCuentaID.Caption = "Cuenta  Cnt.";
            this.colCuentaID.ColumnEdit = this.reposCmbCuenta;
            this.colCuentaID.FieldName = "PlanCuentaID";
            this.colCuentaID.Name = "colCuentaID";
            this.colCuentaID.Visible = true;
            this.colCuentaID.VisibleIndex = 1;
            this.colCuentaID.Width = 241;
            // 
            // reposCmbCuenta
            // 
            this.reposCmbCuenta.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.reposCmbCuenta.AutoHeight = false;
            this.reposCmbCuenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposCmbCuenta.DisplayMember = "DescripcionExtendida";
            this.reposCmbCuenta.Name = "reposCmbCuenta";
            this.reposCmbCuenta.NullText = "";
            this.reposCmbCuenta.PopupView = this.gridView1;
            this.reposCmbCuenta.ValueMember = "IDRegistro";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colpCodigo,
            this.colpCodigol,
            this.colpDescripcion});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colpCodigo
            // 
            this.colpCodigo.Caption = "Código Corto";
            this.colpCodigo.FieldName = "CodigoCorto";
            this.colpCodigo.Name = "colpCodigo";
            this.colpCodigo.Visible = true;
            this.colpCodigo.VisibleIndex = 0;
            // 
            // colpCodigol
            // 
            this.colpCodigol.Caption = "Código Largo";
            this.colpCodigol.FieldName = "CodigoLargo";
            this.colpCodigol.Name = "colpCodigol";
            this.colpCodigol.Visible = true;
            this.colpCodigol.VisibleIndex = 2;
            // 
            // colpDescripcion
            // 
            this.colpDescripcion.Caption = "Descripción";
            this.colpDescripcion.FieldName = "Descripcion";
            this.colpDescripcion.Name = "colpDescripcion";
            this.colpDescripcion.Visible = true;
            this.colpDescripcion.VisibleIndex = 1;
            // 
            // colSubCuentaID
            // 
            this.colSubCuentaID.Caption = "SubCuenta Cnt.";
            this.colSubCuentaID.ColumnEdit = this.reposCmbSubcuenta;
            this.colSubCuentaID.FieldName = "PlanSubCuentaID";
            this.colSubCuentaID.Name = "colSubCuentaID";
            this.colSubCuentaID.Visible = true;
            this.colSubCuentaID.VisibleIndex = 2;
            this.colSubCuentaID.Width = 236;
            // 
            // reposCmbSubcuenta
            // 
            this.reposCmbSubcuenta.AutoHeight = false;
            this.reposCmbSubcuenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposCmbSubcuenta.DisplayMember = "DescripcionExtendida";
            this.reposCmbSubcuenta.Name = "reposCmbSubcuenta";
            this.reposCmbSubcuenta.NullText = "";
            this.reposCmbSubcuenta.PopupView = this.gridView3;
            this.reposCmbSubcuenta.ValueMember = "IDRegistro";
            this.reposCmbSubcuenta.BeforePopup += new System.EventHandler(this.reposCmbSubcuenta_BeforePopup);
            // 
            // gridView3
            // 
            this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView3.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsCodigo,
            this.colsDescripcion});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colsCodigo
            // 
            this.colsCodigo.Caption = "Código";
            this.colsCodigo.FieldName = "Codigo";
            this.colsCodigo.Name = "colsCodigo";
            this.colsCodigo.Visible = true;
            this.colsCodigo.VisibleIndex = 0;
            // 
            // colsDescripcion
            // 
            this.colsDescripcion.Caption = "Descripción";
            this.colsDescripcion.FieldName = "Descripcion";
            this.colsDescripcion.Name = "colsDescripcion";
            this.colsDescripcion.Visible = true;
            this.colsDescripcion.VisibleIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.ImageOptions.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.LookAndFeel.SkinName = "The Bezier";
            this.btnAgregar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblFechaAsiento
            // 
            this.lblFechaAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaAsiento.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblFechaAsiento.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblFechaAsiento.Location = new System.Drawing.Point(737, 6);
            this.lblFechaAsiento.Name = "lblFechaAsiento";
            this.lblFechaAsiento.Size = new System.Drawing.Size(116, 18);
            this.lblFechaAsiento.StyleController = this.styleLabels;
            this.lblFechaAsiento.TabIndex = 5;
            this.lblFechaAsiento.Text = "Fecha del Asiento";
            // 
            // datFechaAsiento
            // 
            this.datFechaAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datFechaAsiento.EditValue = null;
            this.datFechaAsiento.Location = new System.Drawing.Point(859, 3);
            this.datFechaAsiento.MenuManager = this.barManager1;
            this.datFechaAsiento.Name = "datFechaAsiento";
            this.datFechaAsiento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFechaAsiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFechaAsiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFechaAsiento.Size = new System.Drawing.Size(143, 24);
            this.datFechaAsiento.StyleController = this.styleText;
            this.datFechaAsiento.TabIndex = 6;
            // 
            // styleText
            // 
            this.styleText.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.styleText.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.Appearance.Options.UseBorderColor = true;
            this.styleText.Appearance.Options.UseFont = true;
            this.styleText.AppearanceFocused.BorderColor = System.Drawing.Color.Goldenrod;
            this.styleText.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.AppearanceFocused.Options.UseBorderColor = true;
            this.styleText.AppearanceFocused.Options.UseFont = true;
            this.styleText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // bgwEmiteFactura
            // 
            this.bgwEmiteFactura.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEmiteFactura_DoWork);
            this.bgwEmiteFactura.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwEmiteFactura_RunWorkerCompleted);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBorrarRegistro)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // Frm_AsientoContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 349);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_AsientoContable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asiento Contable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_ComprobanteElectronico_FormClosed);
            this.Shown += new System.EventHandler(this.Frm_ComprobanteElectronico_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposText150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbSubcuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaAsiento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaAsiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.SimpleButton btnGenerar;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposAlicsiva;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheck;
        private System.ComponentModel.BackgroundWorker bgwEmiteFactura;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnBorrarRegistro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposText150;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposCmbCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colpCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colpCodigol;
        private DevExpress.XtraGrid.Columns.GridColumn colpDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCuentaID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposCmbSubcuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colsCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colsDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colHaber;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtMemo;
        private DevExpress.XtraEditors.LabelControl lblFechaAsiento;
        private DevExpress.XtraEditors.DateEdit datFechaAsiento;
    }
}