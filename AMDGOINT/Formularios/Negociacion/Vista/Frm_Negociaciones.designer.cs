namespace AMDGOINT.Formularios.Negociacion.Vista
{
    partial class Frm_Negociaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Negociaciones));
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
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btNuevoBar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditarbar = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnCerrarValoriza = new DevExpress.XtraBars.BarButtonItem();
            this.btnAplicarValorización = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tmrescucha = new System.Windows.Forms.Timer(this.components);
            this.screenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.reposFechas = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipogrp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupadorCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgrupadorDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaFin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaImpacto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(763, 52);
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
            this.NavPanel.Size = new System.Drawing.Size(763, 52);
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCerrarValoriza),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAplicarValorización),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportar)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Negociación";
            this.barHeaderItem1.Id = 2;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // btnCerrarValoriza
            // 
            this.btnCerrarValoriza.Caption = "Cerrar";
            this.btnCerrarValoriza.Id = 6;
            this.btnCerrarValoriza.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarValoriza.ImageOptions.Image")));
            this.btnCerrarValoriza.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarValoriza.ImageOptions.LargeImage")));
            this.btnCerrarValoriza.Name = "btnCerrarValoriza";
            this.btnCerrarValoriza.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCerrarValoriza_ItemClick);
            // 
            // btnAplicarValorización
            // 
            this.btnAplicarValorización.Caption = "Aplicar Valorización";
            this.btnAplicarValorización.Id = 8;
            this.btnAplicarValorización.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicarValorización.ImageOptions.Image")));
            this.btnAplicarValorización.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAplicarValorización.ImageOptions.LargeImage")));
            this.btnAplicarValorización.Name = "btnAplicarValorización";
            this.btnAplicarValorización.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAplicarValorización_ItemClick);
            // 
            // btnExportar
            // 
            this.btnExportar.Caption = "Exportar";
            this.btnExportar.Id = 7;
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.LargeImage")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportar_ItemClick);
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
            this.btnCerrarValoriza,
            this.btnExportar,
            this.btnAplicarValorización});
            this.barManager1.MaxItemId = 9;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(763, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 330);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(763, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(763, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 330);
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
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMemo,
            this.reposFechas});
            this.gridControl.Size = new System.Drawing.Size(757, 272);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // reposFechas
            // 
            this.reposFechas.AutoHeight = false;
            this.reposFechas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposFechas.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposFechas.Mask.EditMask = "yyyy-MM-dd";
            this.reposFechas.Mask.UseMaskAsDisplayFormat = true;
            this.reposFechas.Name = "reposFechas";
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
            this.colFecha,
            this.colPrestataria,
            this.colTipogrp,
            this.colAgrupadorCodigo,
            this.colAgrupadorDescripcion,
            this.colFechaFin,
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
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.FormatRules.Add(gridFormatRule3);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
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
            this.gridView.ShownEditor += new System.EventHandler(this.gridView_ShownEditor);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
            // 
            // colFecha
            // 
            this.colFecha.AppearanceCell.Options.UseTextOptions = true;
            this.colFecha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFecha.Caption = "Inicio";
            this.colFecha.ColumnEdit = this.reposFechas;
            this.colFecha.FieldName = "FechaInicio";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 102;
            // 
            // colPrestataria
            // 
            this.colPrestataria.Caption = "Prestatarias";
            this.colPrestataria.ColumnEdit = this.reposMemo;
            this.colPrestataria.FieldName = "PrestatriasAsociadas";
            this.colPrestataria.Name = "colPrestataria";
            this.colPrestataria.Visible = true;
            this.colPrestataria.VisibleIndex = 5;
            this.colPrestataria.Width = 304;
            // 
            // colTipogrp
            // 
            this.colTipogrp.Caption = "Tipo Prestataria";
            this.colTipogrp.FieldName = "PrestadoraTipoDescripcion";
            this.colTipogrp.Name = "colTipogrp";
            this.colTipogrp.Visible = true;
            this.colTipogrp.VisibleIndex = 2;
            this.colTipogrp.Width = 174;
            // 
            // colAgrupadorCodigo
            // 
            this.colAgrupadorCodigo.Caption = "Código";
            this.colAgrupadorCodigo.FieldName = "AgrupadorCodigo";
            this.colAgrupadorCodigo.Name = "colAgrupadorCodigo";
            this.colAgrupadorCodigo.Visible = true;
            this.colAgrupadorCodigo.VisibleIndex = 3;
            this.colAgrupadorCodigo.Width = 102;
            // 
            // colAgrupadorDescripcion
            // 
            this.colAgrupadorDescripcion.Caption = "Descripción";
            this.colAgrupadorDescripcion.FieldName = "AgrupadorDescripcion";
            this.colAgrupadorDescripcion.Name = "colAgrupadorDescripcion";
            this.colAgrupadorDescripcion.Visible = true;
            this.colAgrupadorDescripcion.VisibleIndex = 4;
            this.colAgrupadorDescripcion.Width = 125;
            // 
            // colFechaFin
            // 
            this.colFechaFin.Caption = "Finalizado";
            this.colFechaFin.ColumnEdit = this.reposFechas;
            this.colFechaFin.FieldName = "FechaCierre";
            this.colFechaFin.Name = "colFechaFin";
            this.colFechaFin.Visible = true;
            this.colFechaFin.VisibleIndex = 6;
            this.colFechaFin.Width = 131;
            // 
            // colFechaImpacto
            // 
            this.colFechaImpacto.AppearanceCell.Options.UseTextOptions = true;
            this.colFechaImpacto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFechaImpacto.AppearanceHeader.Options.UseTextOptions = true;
            this.colFechaImpacto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFechaImpacto.Caption = "Negociación";
            this.colFechaImpacto.ColumnEdit = this.reposFechas;
            this.colFechaImpacto.FieldName = "FechaImpacto";
            this.colFechaImpacto.Name = "colFechaImpacto";
            this.colFechaImpacto.Visible = true;
            this.colFechaImpacto.VisibleIndex = 7;
            this.colFechaImpacto.Width = 103;
            // 
            // colEstado
            // 
            this.colEstado.AppearanceCell.Options.UseTextOptions = true;
            this.colEstado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ShowInCustomizationForm = false;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 0;
            this.colEstado.Width = 72;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.7482F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 278);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Frm_Negociaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 330);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Negociaciones";
            this.Text = "Negociaciones";
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pblTop;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private System.Windows.Forms.Timer tmrescucha;
        private DevExpress.XtraBars.Navigation.NavButton btNuevoBar;
        private DevExpress.XtraBars.Navigation.NavButton btnEditarbar;
        private DevExpress.XtraBars.BarButtonItem btnCerrarValoriza;
        private DevExpress.XtraSplashScreen.SplashScreenManager screenManager;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarButtonItem btnAplicarValorización;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposFechas;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestataria;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colTipogrp;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupadorCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colAgrupadorDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaFin;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaImpacto;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}