namespace AMDGOINT.Formularios.Practicas
{
    partial class Frm_PracticasMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PracticasMain));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colEstado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btNuevoBar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditarbar = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitter = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCodigo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colArancel = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGasto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGrupo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colID_Registro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabdetalles = new DevExpress.XtraTab.XtraTabControl();
            this.flyoutPanel = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl = new DevExpress.Utils.FlyoutPanelControl();
            this.ppGenerando = new DevExpress.XtraWaitForm.ProgressPanel();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnNuevapract = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditarpract = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tmrescucha = new System.Windows.Forms.Timer(this.components);
            this.btnEstadopract = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel)).BeginInit();
            this.flyoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl)).BeginInit();
            this.flyoutPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(704, 52);
            this.pblTop.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btNuevoBar);
            this.NavPanel.Buttons.Add(this.btnEditarbar);
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
            this.NavPanel.Size = new System.Drawing.Size(704, 52);
            this.NavPanel.TabIndex = 0;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btNuevoBar
            // 
            this.btNuevoBar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btNuevoBar.Caption = "Nuevo";
            this.btNuevoBar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btNuevoBar.ImageOptions.Image")));
            this.btNuevoBar.Name = "btNuevoBar";
            this.btNuevoBar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btNuevoBar_ElementClick);
            // 
            // btnEditarbar
            // 
            this.btnEditarbar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnEditarbar.Caption = "Editar";
            this.btnEditarbar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarbar.ImageOptions.Image")));
            this.btnEditarbar.Name = "btnEditarbar";
            this.btnEditarbar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditarbar_ElementClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flyoutPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.7482F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.2518F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 278);
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
            this.splitter.Size = new System.Drawing.Size(698, 173);
            this.splitter.SplitterPosition = 65;
            this.splitter.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.gridControl);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(698, 163);
            this.pnlCenter.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.bgridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposCheck});
            this.gridControl.Size = new System.Drawing.Size(698, 163);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgridView});
            // 
            // bgridView
            // 
            this.bgridView.Appearance.BandPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridView.Appearance.BandPanel.Options.UseFont = true;
            this.bgridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.bgridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedCell.Options.UseFont = true;
            this.bgridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bgridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedRow.Options.UseFont = true;
            this.bgridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bgridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.bgridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bgridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.bgridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bgridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.Row.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.SelectedRow.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.bgridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.bgridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID_Registro,
            this.colCodigo,
            this.colDescripcion,
            this.colFuncion,
            this.colGasto,
            this.colArancel,
            this.colGrupo,
            this.colEstado});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colEstado;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Brown;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[Estado] = False";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule2.StopIfTrue = true;
            this.bgridView.FormatRules.Add(gridFormatRule2);
            this.bgridView.GridControl = this.gridControl;
            this.bgridView.Name = "bgridView";
            this.bgridView.OptionsBehavior.Editable = false;
            this.bgridView.OptionsCustomization.AllowBandMoving = false;
            this.bgridView.OptionsFind.AlwaysVisible = true;
            this.bgridView.OptionsFind.FindDelay = 500;
            this.bgridView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.bgridView.OptionsFind.ShowCloseButton = false;
            this.bgridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bgridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.bgridView.OptionsView.ColumnAutoWidth = true;
            this.bgridView.OptionsView.EnableAppearanceEvenRow = true;
            this.bgridView.OptionsView.EnableAppearanceOddRow = true;
            this.bgridView.OptionsView.ShowFooter = true;
            this.bgridView.OptionsView.ShowGroupPanel = false;
            this.bgridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.bgridView_PopupMenuShowing);
            this.bgridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.bgridView_FocusedRowObjectChanged);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "...";
            this.gridBand2.MinWidth = 22;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.AllowMove = false;
            this.gridBand2.OptionsBand.AllowSize = false;
            this.gridBand2.OptionsBand.ShowInCustomizationForm = false;
            this.gridBand2.Visible = false;
            this.gridBand2.VisibleIndex = -1;
            this.gridBand2.Width = 22;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Prácticas Amdgo";
            this.gridBand1.Columns.Add(this.colCodigo);
            this.gridBand1.Columns.Add(this.colDescripcion);
            this.gridBand1.Columns.Add(this.colFuncion);
            this.gridBand1.Columns.Add(this.colArancel);
            this.gridBand1.Columns.Add(this.colGasto);
            this.gridBand1.Columns.Add(this.colGrupo);
            this.gridBand1.Columns.Add(this.colID_Registro);
            this.gridBand1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand1.ImageOptions.Image")));
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.OptionsBand.ShowInCustomizationForm = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 898;
            // 
            // colCodigo
            // 
            this.colCodigo.AppearanceCell.Options.UseTextOptions = true;
            this.colCodigo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCodigo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.Width = 125;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AppearanceCell.Options.UseTextOptions = true;
            this.colDescripcion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescripcion.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescripcion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.Width = 267;
            // 
            // colFuncion
            // 
            this.colFuncion.AppearanceCell.Options.UseTextOptions = true;
            this.colFuncion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFuncion.AppearanceHeader.Options.UseTextOptions = true;
            this.colFuncion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFuncion.Caption = "Funcion";
            this.colFuncion.FieldName = "Funcion";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.Visible = true;
            this.colFuncion.Width = 114;
            // 
            // colArancel
            // 
            this.colArancel.AppearanceCell.Options.UseTextOptions = true;
            this.colArancel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colArancel.AppearanceHeader.Options.UseTextOptions = true;
            this.colArancel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colArancel.Caption = "Arancel";
            this.colArancel.FieldName = "Arancel";
            this.colArancel.Name = "colArancel";
            this.colArancel.Visible = true;
            this.colArancel.Width = 175;
            // 
            // colGasto
            // 
            this.colGasto.AppearanceCell.Options.UseTextOptions = true;
            this.colGasto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGasto.AppearanceHeader.Options.UseTextOptions = true;
            this.colGasto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGasto.Caption = "Gasto";
            this.colGasto.FieldName = "Gasto";
            this.colGasto.Name = "colGasto";
            this.colGasto.Visible = true;
            this.colGasto.Width = 121;
            // 
            // colGrupo
            // 
            this.colGrupo.Caption = "Grupo";
            this.colGrupo.FieldName = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.Visible = true;
            this.colGrupo.Width = 96;
            // 
            // colID_Registro
            // 
            this.colID_Registro.FieldName = "ID_Registro";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            this.colID_Registro.RowIndex = 2;
            // 
            // reposCheck
            // 
            this.reposCheck.AutoHeight = false;
            this.reposCheck.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.reposCheck.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("reposCheck.ImageOptions.ImageChecked")));
            this.reposCheck.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("reposCheck.ImageOptions.ImageUnchecked")));
            this.reposCheck.Name = "reposCheck";
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
            // flyoutPanel
            // 
            this.flyoutPanel.Controls.Add(this.flyoutPanelControl);
            this.flyoutPanel.Location = new System.Drawing.Point(3, 182);
            this.flyoutPanel.Name = "flyoutPanel";
            this.flyoutPanel.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right;
            this.flyoutPanel.Options.CloseOnHidingOwner = false;
            this.flyoutPanel.OwnerControl = this.NavPanel;
            this.flyoutPanel.ParentForm = this;
            this.flyoutPanel.Size = new System.Drawing.Size(223, 93);
            this.flyoutPanel.TabIndex = 4;
            // 
            // flyoutPanelControl
            // 
            this.flyoutPanelControl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.flyoutPanelControl.Appearance.Options.UseBackColor = true;
            this.flyoutPanelControl.Controls.Add(this.ppGenerando);
            this.flyoutPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl.FlyoutPanel = this.flyoutPanel;
            this.flyoutPanelControl.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl.Name = "flyoutPanelControl";
            this.flyoutPanelControl.Size = new System.Drawing.Size(223, 93);
            this.flyoutPanelControl.TabIndex = 0;
            // 
            // ppGenerando
            // 
            this.ppGenerando.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppGenerando.Appearance.Options.UseBackColor = true;
            this.ppGenerando.AppearanceCaption.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppGenerando.AppearanceCaption.Options.UseFont = true;
            this.ppGenerando.AppearanceDescription.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppGenerando.AppearanceDescription.Options.UseFont = true;
            this.ppGenerando.Caption = "Recuperando Datos";
            this.ppGenerando.Description = "Espere...";
            this.ppGenerando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppGenerando.Location = new System.Drawing.Point(2, 2);
            this.ppGenerando.Name = "ppGenerando";
            this.ppGenerando.Size = new System.Drawing.Size(219, 89);
            this.ppGenerando.TabIndex = 0;
            this.ppGenerando.Text = "progressPanel1";
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevapract),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditarpract),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEstadopract)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Opciones";
            this.barHeaderItem1.Id = 2;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // btnNuevapract
            // 
            this.btnNuevapract.Caption = "Agregar práctica";
            this.btnNuevapract.Id = 4;
            this.btnNuevapract.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevapract.ImageOptions.Image")));
            this.btnNuevapract.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNuevapract.ImageOptions.LargeImage")));
            this.btnNuevapract.Name = "btnNuevapract";
            this.btnNuevapract.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevaprest_ItemClick);
            // 
            // btnEditarpract
            // 
            this.btnEditarpract.Caption = "Editar práctica";
            this.btnEditarpract.Id = 5;
            this.btnEditarpract.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarpract.ImageOptions.Image")));
            this.btnEditarpract.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEditarpract.ImageOptions.LargeImage")));
            this.btnEditarpract.Name = "btnEditarpract";
            this.btnEditarpract.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditarprest_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barHeaderItem1,
            this.btnNuevapract,
            this.btnEditarpract,
            this.btnEstadopract});
            this.barManager1.MaxItemId = 8;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(704, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 330);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(704, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 330);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(704, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 330);
            // 
            // tmrescucha
            // 
            this.tmrescucha.Interval = 200;
            this.tmrescucha.Tick += new System.EventHandler(this.tmrescucha_Tick);
            // 
            // btnEstadopract
            // 
            this.btnEstadopract.Caption = "Deshabilitar";
            this.btnEstadopract.Id = 6;
            this.btnEstadopract.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnEstadopract.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btnEstadopract.Name = "btnEstadopract";
            this.btnEstadopract.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEstadopract_ItemClick);
            // 
            // Frm_PracticasMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 330);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PracticasMain";
            this.Text = "Practicas Amdgo";
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel)).EndInit();
            this.flyoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl)).EndInit();
            this.flyoutPanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
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
        private DevExpress.Utils.FlyoutPanel flyoutPanel;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl;
        private DevExpress.XtraWaitForm.ProgressPanel ppGenerando;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bgridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID_Registro;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodigo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheck;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private System.Windows.Forms.Timer tmrescucha;
        private DevExpress.XtraBars.BarButtonItem btnNuevapract;
        private DevExpress.XtraBars.BarButtonItem btnEditarpract;
        private DevExpress.XtraBars.Navigation.NavButton btNuevoBar;
        private DevExpress.XtraBars.Navigation.NavButton btnEditarbar;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFuncion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colArancel;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGasto;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGrupo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEstado;
        private DevExpress.XtraBars.BarButtonItem btnEstadopract;
    }
}