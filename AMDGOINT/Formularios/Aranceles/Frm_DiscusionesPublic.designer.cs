namespace AMDGOINT.Formularios.Aranceles
{
    partial class Frm_DiscusionesPublic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DiscusionesPublic));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colEstado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnVer = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitter = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridview = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTipogrp = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescripciongrupo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPrestataria = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colFechaImpacto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colID_Registro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposNumero = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.reposdFecha = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.tabdetalles = new DevExpress.XtraTab.XtraTabControl();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.tmrescucha = new System.Windows.Forms.Timer(this.components);
            this.screenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposdFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposdFecha.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ShowInCustomizationForm = false;
            this.colEstado.Visible = true;
            this.colEstado.Width = 53;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(883, 52);
            this.pblTop.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnVer);
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
            this.NavPanel.Size = new System.Drawing.Size(883, 52);
            this.NavPanel.TabIndex = 0;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btnVer
            // 
            this.btnVer.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnVer.Caption = "Visualizar";
            this.btnVer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.ImageOptions.Image")));
            this.btnVer.Name = "btnVer";
            this.btnVer.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnVer_ElementClick);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 372);
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
            this.splitter.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.splitter.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.splitter.Size = new System.Drawing.Size(877, 366);
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
            this.pnlCenter.Size = new System.Drawing.Size(877, 366);
            this.pnlCenter.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.bgridview;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposFecha,
            this.reposNumero,
            this.reposMemo,
            this.reposdFecha});
            this.gridControl.Size = new System.Drawing.Size(877, 366);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgridview});
            // 
            // bgridview
            // 
            this.bgridview.Appearance.BandPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridview.Appearance.BandPanel.Options.UseFont = true;
            this.bgridview.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.bgridview.Appearance.EvenRow.Options.UseBackColor = true;
            this.bgridview.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridview.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridview.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridview.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bgridview.Appearance.FocusedCell.Options.UseFont = true;
            this.bgridview.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bgridview.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridview.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridview.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bgridview.Appearance.FocusedRow.Options.UseFont = true;
            this.bgridview.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bgridview.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.bgridview.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bgridview.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridview.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridview.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgridview.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.bgridview.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridview.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bgridview.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridview.Appearance.Row.Options.UseFont = true;
            this.bgridview.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridview.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridview.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridview.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bgridview.Appearance.SelectedRow.Options.UseFont = true;
            this.bgridview.Appearance.SelectedRow.Options.UseForeColor = true;
            this.bgridview.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand4});
            this.bgridview.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridview.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID_Registro,
            this.colPrestataria,
            this.colTipogrp,
            this.colCodigo,
            this.colDescripciongrupo,
            this.colFechaImpacto,
            this.colEstado});
            gridFormatRule1.Column = this.colEstado;
            gridFormatRule1.ColumnApplyTo = this.colEstado;
            gridFormatRule1.Name = "EstadoIconos";
            formatConditionRuleIconSet1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionIconSet1.CategoryName = "Formas";
            formatConditionIconSetIcon1.PredefinedName = "TrafficLights23_1.png";
            formatConditionIconSetIcon1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "TrafficLights23_2.png";
            formatConditionIconSetIcon2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "RedToBlack4_4.png";
            formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "TrafficLights3Unrimmed";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule1.Rule = formatConditionRuleIconSet1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colEstado;
            gridFormatRule2.ColumnApplyTo = this.colEstado;
            gridFormatRule2.Name = "ValorizaCerrada";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[Estado] = 1";
            gridFormatRule2.Rule = formatConditionRuleValue1;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colEstado;
            gridFormatRule3.Name = "ValorizacionAplicada";
            formatConditionRuleValue2.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(110)))), ((int)(((byte)(73)))));
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[Estado] = 2";
            gridFormatRule3.Rule = formatConditionRuleValue2;
            this.bgridview.FormatRules.Add(gridFormatRule1);
            this.bgridview.FormatRules.Add(gridFormatRule2);
            this.bgridview.FormatRules.Add(gridFormatRule3);
            this.bgridview.GridControl = this.gridControl;
            this.bgridview.Name = "bgridview";
            this.bgridview.OptionsBehavior.Editable = false;
            this.bgridview.OptionsCustomization.AllowBandMoving = false;
            this.bgridview.OptionsDetail.EnableMasterViewMode = false;
            this.bgridview.OptionsFind.AlwaysVisible = true;
            this.bgridview.OptionsFind.FindDelay = 500;
            this.bgridview.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.bgridview.OptionsFind.ShowCloseButton = false;
            this.bgridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bgridview.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.bgridview.OptionsView.EnableAppearanceEvenRow = true;
            this.bgridview.OptionsView.EnableAppearanceOddRow = true;
            this.bgridview.OptionsView.RowAutoHeight = true;
            this.bgridview.OptionsView.ShowFooter = true;
            this.bgridview.OptionsView.ShowGroupPanel = false;
            this.bgridview.OptionsView.ShowIndicator = false;
            this.bgridview.ShownEditor += new System.EventHandler(this.bgridView_ShownEditor);
            this.bgridview.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.bgridView_FocusedRowObjectChanged);
            this.bgridview.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.bgridView_CustomColumnDisplayText);
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridBand4.Caption = "Aranceles en discusión";
            this.gridBand4.Columns.Add(this.colEstado);
            this.gridBand4.Columns.Add(this.colTipogrp);
            this.gridBand4.Columns.Add(this.colCodigo);
            this.gridBand4.Columns.Add(this.colDescripciongrupo);
            this.gridBand4.Columns.Add(this.colPrestataria);
            this.gridBand4.Columns.Add(this.colFechaImpacto);
            this.gridBand4.Columns.Add(this.colID_Registro);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.AllowMove = false;
            this.gridBand4.VisibleIndex = 0;
            this.gridBand4.Width = 631;
            // 
            // colTipogrp
            // 
            this.colTipogrp.Caption = "Tipo Prestataria";
            this.colTipogrp.FieldName = "TipoNombre";
            this.colTipogrp.Name = "colTipogrp";
            this.colTipogrp.Visible = true;
            this.colTipogrp.Width = 128;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "CodigoGupo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            // 
            // colDescripciongrupo
            // 
            this.colDescripciongrupo.Caption = "Grupo";
            this.colDescripciongrupo.FieldName = "DescripcionGrupo";
            this.colDescripciongrupo.Name = "colDescripciongrupo";
            this.colDescripciongrupo.Visible = true;
            this.colDescripciongrupo.Width = 92;
            // 
            // colPrestataria
            // 
            this.colPrestataria.Caption = "Prestatarias";
            this.colPrestataria.ColumnEdit = this.reposMemo;
            this.colPrestataria.FieldName = "PrestatariaConjunto";
            this.colPrestataria.Name = "colPrestataria";
            this.colPrestataria.Visible = true;
            this.colPrestataria.Width = 158;
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // colFechaImpacto
            // 
            this.colFechaImpacto.AppearanceCell.Options.UseTextOptions = true;
            this.colFechaImpacto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFechaImpacto.AppearanceHeader.Options.UseTextOptions = true;
            this.colFechaImpacto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFechaImpacto.Caption = "Vigencia";
            this.colFechaImpacto.FieldName = "FechaImpacto";
            this.colFechaImpacto.Name = "colFechaImpacto";
            this.colFechaImpacto.Visible = true;
            this.colFechaImpacto.Width = 125;
            // 
            // colID_Registro
            // 
            this.colID_Registro.FieldName = "IDRegistro";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            this.colID_Registro.Width = 87;
            // 
            // reposNumero
            // 
            this.reposNumero.AutoHeight = false;
            this.reposNumero.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposNumero.Mask.EditMask = "d";
            this.reposNumero.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumero.Name = "reposNumero";
            // 
            // reposdFecha
            // 
            this.reposdFecha.AutoHeight = false;
            this.reposdFecha.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposdFecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposdFecha.Mask.EditMask = "dd-MM-yyyy";
            this.reposdFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposdFecha.Name = "reposdFecha";
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
            // tmrescucha
            // 
            this.tmrescucha.Interval = 200;
            this.tmrescucha.Tick += new System.EventHandler(this.tmrescucha_Tick);
            // 
            // screenManager
            // 
            this.screenManager.ClosingDelay = 500;
            // 
            // Frm_DiscusionesPublic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 424);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_DiscusionesPublic";
            this.Text = "Negociaciones";
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposdFecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposdFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Timer tmrescucha;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraSplashScreen.SplashScreenManager screenManager;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit reposNumero;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgridview;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescripciongrupo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPrestataria;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFechaImpacto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEstado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID_Registro;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposdFecha;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTipogrp;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodigo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraBars.Navigation.NavButton btnVer;
    }
}