namespace AMDGOINT.Formularios.Profesionales.CuentasConjuntas
{
    partial class Frm_CuentasConjuntas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CuentasConjuntas));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnBuscar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnExportaExcel = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitter = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentaConjunta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbCuentaConjunta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryTextSI = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryTextNO = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tabdetalles = new DevExpress.XtraTab.XtraTabControl();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, true);
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCuentaConjunta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(1110, 52);
            this.pblTop.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnBuscar);
            this.NavPanel.Buttons.Add(this.btnExportaExcel);
            // 
            // tileNavCategory1
            // 
            this.NavPanel.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.NavPanel.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.NavPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(1110, 52);
            this.NavPanel.TabIndex = 0;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Caption = "Buscar";
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnBuscar_ElementClick);
            // 
            // btnExportaExcel
            // 
            this.btnExportaExcel.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnExportaExcel.Caption = "Exportar Excel";
            this.btnExportaExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportaExcel.ImageOptions.Image")));
            this.btnExportaExcel.Name = "btnExportaExcel";
            this.btnExportaExcel.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnExportaExcel_ElementClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitter, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.7482F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 478);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // splitter
            // 
            this.splitter.Appearance.BackColor = System.Drawing.Color.White;
            this.splitter.Appearance.Options.UseBackColor = true;
            this.splitter.Collapsed = true;
            this.splitter.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Horizontal = false;
            this.splitter.Location = new System.Drawing.Point(3, 3);
            this.splitter.Name = "splitter";
            this.splitter.Panel1.Controls.Add(this.pnlCenter);
            this.splitter.Panel1.Text = "Panel1";
            this.splitter.Panel2.Controls.Add(this.tabdetalles);
            this.splitter.Panel2.Text = "Panel2";
            this.splitter.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.splitter.Size = new System.Drawing.Size(1104, 472);
            this.splitter.SplitterPosition = 122;
            this.splitter.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.gridControl);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1104, 462);
            this.pnlCenter.TabIndex = 2;
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
            this.cmbCuentaConjunta,
            this.repositoryTextSI,
            this.repositoryTextNO});
            this.gridControl.Size = new System.Drawing.Size(1104, 462);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colDescripcion,
            this.colEmpresa,
            this.colCuentaConjunta});
            gridFormatRule1.Name = "SaldoExedido";
            formatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Bold);
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[SaldoNegativo] * -1 >= [SaldoDisponibleCuenta]";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindDelay = 500;
            this.gridView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.gridView.OptionsFind.ShowCloseButton = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.EditFormShowing += new DevExpress.XtraGrid.Views.Grid.EditFormShowingEventHandler(this.gridView_EditFormShowing);
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            this.gridView.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gridView_InvalidValueException);
            // 
            // colCodigo
            // 
            this.colCodigo.AppearanceCell.Options.UseTextOptions = true;
            this.colCodigo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCodigo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCodigo.Caption = "Cuenta";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            this.colCodigo.Width = 166;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AppearanceCell.Options.UseTextOptions = true;
            this.colDescripcion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescripcion.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescripcion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescripcion.Caption = "Profesional";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 492;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Profesional / Entidad";
            this.colEmpresa.FieldName = "EsProfesionalDescripcion";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 3;
            this.colEmpresa.Width = 228;
            // 
            // colCuentaConjunta
            // 
            this.colCuentaConjunta.Caption = "Cuenta Conjunta";
            this.colCuentaConjunta.ColumnEdit = this.cmbCuentaConjunta;
            this.colCuentaConjunta.FieldName = "IDCuentaConjuntoContable";
            this.colCuentaConjunta.Name = "colCuentaConjunta";
            this.colCuentaConjunta.Visible = true;
            this.colCuentaConjunta.VisibleIndex = 2;
            this.colCuentaConjunta.Width = 461;
            // 
            // cmbCuentaConjunta
            // 
            this.cmbCuentaConjunta.AutoHeight = false;
            this.cmbCuentaConjunta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCuentaConjunta.DisplayMember = "ProfesionalNombreOP";
            this.cmbCuentaConjunta.Name = "cmbCuentaConjunta";
            this.cmbCuentaConjunta.NullText = "";
            this.cmbCuentaConjunta.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.cmbCuentaConjunta.ValueMember = "IDRegistro";
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.EvenRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cuenta";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción";
            this.gridColumn2.FieldName = "Descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryTextSI
            // 
            this.repositoryTextSI.AutoHeight = false;
            this.repositoryTextSI.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("repositoryTextSI.ContextImageOptions.Image")));
            this.repositoryTextSI.Name = "repositoryTextSI";
            // 
            // repositoryTextNO
            // 
            this.repositoryTextNO.AutoHeight = false;
            this.repositoryTextNO.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("repositoryTextNO.ContextImageOptions.Image")));
            this.repositoryTextNO.Name = "repositoryTextNO";
            // 
            // tabdetalles
            // 
            this.tabdetalles.AppearancePage.Header.BackColor = System.Drawing.Color.White;
            this.tabdetalles.AppearancePage.Header.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabdetalles.AppearancePage.Header.Options.UseBackColor = true;
            this.tabdetalles.AppearancePage.Header.Options.UseFont = true;
            this.tabdetalles.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
            this.tabdetalles.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Gainsboro;
            this.tabdetalles.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabdetalles.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabdetalles.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.tabdetalles.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabdetalles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tabdetalles.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tabdetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabdetalles.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.tabdetalles.Location = new System.Drawing.Point(0, 0);
            this.tabdetalles.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.tabdetalles.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabdetalles.Name = "tabdetalles";
            this.tabdetalles.Size = new System.Drawing.Size(0, 0);
            this.tabdetalles.TabIndex = 0;
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 9;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1110, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 530);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1110, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 530);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1110, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 530);
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // Frm_CuentasConjuntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_CuentasConjuntas";
            this.Text = "Cuentas Conjuntas";
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCuentaConjunta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pblTop;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitter;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraTab.XtraTabControl tabdetalles;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraBars.Navigation.NavButton btnBuscar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraBars.Navigation.NavButton btnExportaExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaConjunta;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbCuentaConjunta;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryTextSI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryTextNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}