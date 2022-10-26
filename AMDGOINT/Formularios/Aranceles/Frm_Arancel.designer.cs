namespace AMDGOINT.Formularios.Aranceles
{
    partial class Frm_Arancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Arancel));
            this.pnlBase = new DevExpress.XtraEditors.PanelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.advGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGrupoPractica = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFecha = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCodPractica = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescripcionpractica = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodigofuncion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescripcionfuncion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGrupoOrden = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colValorprepaga = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposNumeric = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colValorOs = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colValorCaja = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colValorArt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colID_Registro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIDPractica = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colObsPrepaga = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposObs = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colObsOs = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colObsArt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colObsCaja = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grpDatos = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportxls = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnPorcentaje = new DevExpress.XtraBars.BarButtonItem();
            this.btnValoresDefecto = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuitapractica = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barHeaderItem2 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnAgregapractica = new DevExpress.XtraBars.BarButtonItem();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.datFecha = new DevExpress.XtraEditors.DateEdit();
            this.btnImportaxls = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.gridControlbk = new DevExpress.XtraGrid.GridControl();
            this.gridViewbk = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bkcolFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bkcolValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bkreposNumero = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bkreposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.ScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposObs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlbk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewbk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkreposNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkreposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.BorderColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.Options.UseBackColor = true;
            this.pnlBase.Appearance.Options.UseBorderColor = true;
            this.pnlBase.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBase.Controls.Add(this.pnlCenter);
            this.pnlBase.Controls.Add(this.pnlBottom);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(1);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(728, 426);
            this.pnlBase.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Appearance.Options.UseBackColor = true;
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.tableLayoutPanel1);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(728, 304);
            this.pnlCenter.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpDatos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 304);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 7);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 133);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.advGridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposFecha,
            this.reposNumeric,
            this.reposObs});
            this.gridControl.Size = new System.Drawing.Size(722, 168);
            this.gridControl.TabIndex = 26;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advGridView});
            // 
            // advGridView
            // 
            this.advGridView.Appearance.BandPanel.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.advGridView.Appearance.BandPanel.Options.UseFont = true;
            this.advGridView.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.advGridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.advGridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.advGridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.advGridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advGridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.advGridView.Appearance.FocusedCell.Options.UseFont = true;
            this.advGridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.advGridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.advGridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.advGridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.advGridView.Appearance.FocusedRow.Options.UseFont = true;
            this.advGridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.advGridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.advGridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.advGridView.Appearance.GroupRow.Font = new System.Drawing.Font("Myanmar Text", 9.75F);
            this.advGridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.SteelBlue;
            this.advGridView.Appearance.GroupRow.Options.UseFont = true;
            this.advGridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.advGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.advGridView.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
            this.advGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.advGridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.advGridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advGridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.advGridView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.advGridView.Appearance.Row.Options.UseFont = true;
            this.advGridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.advGridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.advGridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advGridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.advGridView.Appearance.SelectedRow.Options.UseFont = true;
            this.advGridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.advGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.advGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.advGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID_Registro,
            this.colFecha,
            this.colGrupoPractica,
            this.colGrupoOrden,
            this.colIDPractica,
            this.colCodPractica,
            this.colDescripcionpractica,
            this.colCodigofuncion,
            this.colDescripcionfuncion,
            this.colFuncion,
            this.colValorprepaga,
            this.colObsPrepaga,
            this.colValorOs,
            this.colObsOs,
            this.colValorArt,
            this.colObsArt,
            this.colValorCaja,
            this.colObsCaja});
            this.advGridView.GridControl = this.gridControl;
            this.advGridView.Name = "advGridView";
            this.advGridView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.advGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.advGridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.advGridView.OptionsMenu.EnableColumnMenu = false;
            this.advGridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.advGridView.OptionsSelection.MultiSelect = true;
            this.advGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.advGridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.advGridView.OptionsView.ColumnAutoWidth = true;
            this.advGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.advGridView.OptionsView.ShowIndicator = false;
            this.advGridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.advGridView_FocusedRowObjectChanged);
            this.advGridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.advGridView_FocusedColumnChanged);
            this.advGridView.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.advGridView_CustomColumnSort);
            this.advGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.advGridView_KeyDown);
            this.advGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.advGridView_MouseDown);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "General";
            this.gridBand1.Columns.Add(this.colGrupoPractica);
            this.gridBand1.Columns.Add(this.colFecha);
            this.gridBand1.Columns.Add(this.colCodPractica);
            this.gridBand1.Columns.Add(this.colDescripcionpractica);
            this.gridBand1.Columns.Add(this.colFuncion);
            this.gridBand1.Columns.Add(this.colCodigofuncion);
            this.gridBand1.Columns.Add(this.colDescripcionfuncion);
            this.gridBand1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand1.ImageOptions.Image")));
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.ShowInCustomizationForm = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 395;
            // 
            // colGrupoPractica
            // 
            this.colGrupoPractica.Caption = "Grupo de prácticas";
            this.colGrupoPractica.FieldName = "GrupoPractica";
            this.colGrupoPractica.Name = "colGrupoPractica";
            this.colGrupoPractica.OptionsColumn.AllowEdit = false;
            this.colGrupoPractica.OptionsColumn.ShowInCustomizationForm = false;
            this.colGrupoPractica.OptionsFilter.AllowFilter = false;
            this.colGrupoPractica.Width = 380;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.ColumnEdit = this.reposFecha;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.MinWidth = 40;
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.AllowSize = false;
            this.colFecha.OptionsColumn.ShowInCustomizationForm = false;
            this.colFecha.Width = 49;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposFecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // colCodPractica
            // 
            this.colCodPractica.Caption = "Práctica";
            this.colCodPractica.FieldName = "CodigoPractica";
            this.colCodPractica.MinWidth = 10;
            this.colCodPractica.Name = "colCodPractica";
            this.colCodPractica.OptionsColumn.AllowEdit = false;
            this.colCodPractica.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCodPractica.Visible = true;
            this.colCodPractica.Width = 84;
            // 
            // colDescripcionpractica
            // 
            this.colDescripcionpractica.Caption = "Descripción";
            this.colDescripcionpractica.FieldName = "DescripcionPractica";
            this.colDescripcionpractica.Name = "colDescripcionpractica";
            this.colDescripcionpractica.OptionsColumn.AllowEdit = false;
            this.colDescripcionpractica.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescripcionpractica.Visible = true;
            this.colDescripcionpractica.Width = 156;
            // 
            // colFuncion
            // 
            this.colFuncion.Caption = "Función";
            this.colFuncion.FieldName = "Funcion";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.OptionsColumn.AllowEdit = false;
            this.colFuncion.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFuncion.Visible = true;
            this.colFuncion.Width = 155;
            // 
            // colCodigofuncion
            // 
            this.colCodigofuncion.Caption = "Cod. Función";
            this.colCodigofuncion.FieldName = "CodigoFuncion";
            this.colCodigofuncion.Name = "colCodigofuncion";
            this.colCodigofuncion.OptionsColumn.AllowEdit = false;
            this.colCodigofuncion.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCodigofuncion.OptionsColumn.ShowInCustomizationForm = false;
            this.colCodigofuncion.Width = 61;
            // 
            // colDescripcionfuncion
            // 
            this.colDescripcionfuncion.Caption = "Descripción Función";
            this.colDescripcionfuncion.FieldName = "DescripcionFuncion";
            this.colDescripcionfuncion.Name = "colDescripcionfuncion";
            this.colDescripcionfuncion.OptionsColumn.AllowEdit = false;
            this.colDescripcionfuncion.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescripcionfuncion.OptionsColumn.ShowInCustomizationForm = false;
            this.colDescripcionfuncion.Width = 146;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Valores";
            this.gridBand2.Columns.Add(this.colGrupoOrden);
            this.gridBand2.Columns.Add(this.colValorprepaga);
            this.gridBand2.Columns.Add(this.colValorOs);
            this.gridBand2.Columns.Add(this.colValorCaja);
            this.gridBand2.Columns.Add(this.colValorArt);
            this.gridBand2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand2.ImageOptions.Image")));
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.ShowInCustomizationForm = false;
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 578;
            // 
            // colGrupoOrden
            // 
            this.colGrupoOrden.Caption = "GrupoOrden";
            this.colGrupoOrden.FieldName = "GrupoOrden";
            this.colGrupoOrden.Name = "colGrupoOrden";
            this.colGrupoOrden.OptionsColumn.AllowEdit = false;
            this.colGrupoOrden.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colValorprepaga
            // 
            this.colValorprepaga.AppearanceCell.Options.UseTextOptions = true;
            this.colValorprepaga.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorprepaga.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorprepaga.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorprepaga.Caption = "Prepaga";
            this.colValorprepaga.ColumnEdit = this.reposNumeric;
            this.colValorprepaga.FieldName = "ValorPrepaga";
            this.colValorprepaga.Name = "colValorprepaga";
            this.colValorprepaga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValorprepaga.Visible = true;
            this.colValorprepaga.Width = 139;
            // 
            // reposNumeric
            // 
            this.reposNumeric.AutoHeight = false;
            this.reposNumeric.Mask.EditMask = "n2";
            this.reposNumeric.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumeric.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumeric.Name = "reposNumeric";
            this.reposNumeric.NullText = "0,00";
            // 
            // colValorOs
            // 
            this.colValorOs.AppearanceCell.Options.UseTextOptions = true;
            this.colValorOs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorOs.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorOs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorOs.Caption = "Obra Social";
            this.colValorOs.ColumnEdit = this.reposNumeric;
            this.colValorOs.FieldName = "ValorOs";
            this.colValorOs.Name = "colValorOs";
            this.colValorOs.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValorOs.Visible = true;
            this.colValorOs.Width = 139;
            // 
            // colValorCaja
            // 
            this.colValorCaja.AppearanceCell.Options.UseTextOptions = true;
            this.colValorCaja.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorCaja.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorCaja.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorCaja.Caption = "Cajas";
            this.colValorCaja.ColumnEdit = this.reposNumeric;
            this.colValorCaja.FieldName = "ValorCaja";
            this.colValorCaja.Name = "colValorCaja";
            this.colValorCaja.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValorCaja.Visible = true;
            this.colValorCaja.Width = 144;
            // 
            // colValorArt
            // 
            this.colValorArt.AppearanceCell.Options.UseTextOptions = true;
            this.colValorArt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorArt.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorArt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorArt.Caption = "A.R.T";
            this.colValorArt.ColumnEdit = this.reposNumeric;
            this.colValorArt.FieldName = "ValorArt";
            this.colValorArt.Name = "colValorArt";
            this.colValorArt.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValorArt.Visible = true;
            this.colValorArt.Width = 156;
            // 
            // colID_Registro
            // 
            this.colID_Registro.Caption = "ID_Registro";
            this.colID_Registro.FieldName = "ID_Registro";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colIDPractica
            // 
            this.colIDPractica.Caption = "ID_Practica";
            this.colIDPractica.FieldName = "IDPractAm";
            this.colIDPractica.Name = "colIDPractica";
            this.colIDPractica.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colObsPrepaga
            // 
            this.colObsPrepaga.Caption = "Obs. Prepaga";
            this.colObsPrepaga.ColumnEdit = this.reposObs;
            this.colObsPrepaga.FieldName = "ObsPrepaga";
            this.colObsPrepaga.Name = "colObsPrepaga";
            this.colObsPrepaga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // reposObs
            // 
            this.reposObs.AutoHeight = false;
            this.reposObs.Mask.EditMask = "[^\']*";
            this.reposObs.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposObs.Mask.UseMaskAsDisplayFormat = true;
            this.reposObs.Name = "reposObs";
            // 
            // colObsOs
            // 
            this.colObsOs.Caption = "Obs. Obra Social";
            this.colObsOs.ColumnEdit = this.reposObs;
            this.colObsOs.FieldName = "ObsOs";
            this.colObsOs.Name = "colObsOs";
            this.colObsOs.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colObsArt
            // 
            this.colObsArt.Caption = "Obs. Art";
            this.colObsArt.ColumnEdit = this.reposObs;
            this.colObsArt.FieldName = "ObsArt";
            this.colObsArt.Name = "colObsArt";
            this.colObsArt.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colObsCaja
            // 
            this.colObsCaja.Caption = "Obs. Caja";
            this.colObsCaja.ColumnEdit = this.reposObs;
            this.colObsCaja.FieldName = "ObsCaja";
            this.colObsCaja.Name = "colObsCaja";
            this.colObsCaja.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // grpDatos
            // 
            this.grpDatos.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpDatos.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.grpDatos.Appearance.Options.UseBackColor = true;
            this.grpDatos.Appearance.Options.UseBorderColor = true;
            this.grpDatos.AppearanceCaption.BackColor = System.Drawing.Color.SteelBlue;
            this.grpDatos.AppearanceCaption.BackColor2 = System.Drawing.Color.SteelBlue;
            this.grpDatos.AppearanceCaption.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatos.AppearanceCaption.Options.UseBackColor = true;
            this.grpDatos.AppearanceCaption.Options.UseFont = true;
            this.grpDatos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tableLayoutPanel1.SetColumnSpan(this.grpDatos, 7);
            this.grpDatos.Controls.Add(this.tableLayoutPanel3);
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Location = new System.Drawing.Point(3, 3);
            this.grpDatos.LookAndFeel.SkinName = "The Bezier";
            this.grpDatos.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpDatos.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(722, 124);
            this.grpDatos.TabIndex = 25;
            this.grpDatos.Text = "Datos";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.42427F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.57573F));
            this.tableLayoutPanel3.Controls.Add(this.btnExportxls, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtObservaciones, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.datFecha, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnImportaxls, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(718, 99);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnExportxls
            // 
            this.btnExportxls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportxls.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnExportxls.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnExportxls.Appearance.Options.UseBackColor = true;
            this.btnExportxls.Appearance.Options.UseBorderColor = true;
            this.btnExportxls.AppearanceHovered.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportxls.AppearanceHovered.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnExportxls.AppearanceHovered.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportxls.AppearanceHovered.Options.UseBackColor = true;
            this.btnExportxls.AppearanceHovered.Options.UseBorderColor = true;
            this.btnExportxls.AppearanceHovered.Options.UseForeColor = true;
            this.btnExportxls.AppearancePressed.BackColor2 = System.Drawing.Color.SteelBlue;
            this.btnExportxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportxls.ImageOptions.Image")));
            this.btnExportxls.Location = new System.Drawing.Point(91, 71);
            this.btnExportxls.LookAndFeel.SkinName = "The Bezier";
            this.btnExportxls.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnExportxls.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExportxls.Name = "btnExportxls";
            this.btnExportxls.Size = new System.Drawing.Size(114, 23);
            this.btnExportxls.TabIndex = 3;
            this.btnExportxls.Text = "Exportar";
            this.btnExportxls.Click += new System.EventHandler(this.btnExportxls_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 15);
            this.labelControl1.Name = "labelControl1";
            this.tableLayoutPanel3.SetRowSpan(this.labelControl1, 2);
            this.labelControl1.Size = new System.Drawing.Size(82, 36);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha y Observaciones";
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtObservaciones
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtObservaciones, 2);
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Location = new System.Drawing.Point(211, 3);
            this.txtObservaciones.MenuManager = this.barManager1;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtObservaciones.Properties.MaxLength = 1500;
            this.tableLayoutPanel3.SetRowSpan(this.txtObservaciones, 2);
            this.txtObservaciones.Size = new System.Drawing.Size(504, 60);
            this.txtObservaciones.StyleController = this.styleText;
            this.txtObservaciones.TabIndex = 1;
            this.txtObservaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservaciones_KeyPress);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPorcentaje,
            this.btnValoresDefecto,
            this.btnQuitapractica,
            this.barHeaderItem1,
            this.barHeaderItem2,
            this.btnAgregapractica});
            this.barManager1.MaxItemId = 23;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(728, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 426);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(728, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 426);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(728, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 426);
            // 
            // btnPorcentaje
            // 
            this.btnPorcentaje.Caption = "Definir %";
            this.btnPorcentaje.Id = 0;
            this.btnPorcentaje.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPorcentaje.ImageOptions.Image")));
            this.btnPorcentaje.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPorcentaje.ImageOptions.LargeImage")));
            this.btnPorcentaje.Name = "btnPorcentaje";
            this.btnPorcentaje.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPorcentaje_ItemClick);
            // 
            // btnValoresDefecto
            // 
            this.btnValoresDefecto.Caption = "Por Defecto";
            this.btnValoresDefecto.Id = 2;
            this.btnValoresDefecto.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnValoresDefecto.ImageOptions.Image")));
            this.btnValoresDefecto.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnValoresDefecto.ImageOptions.LargeImage")));
            this.btnValoresDefecto.Name = "btnValoresDefecto";
            this.btnValoresDefecto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnValoresDefecto_ItemClick);
            // 
            // btnQuitapractica
            // 
            this.btnQuitapractica.Caption = "Quitar";
            this.btnQuitapractica.Id = 17;
            this.btnQuitapractica.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitapractica.ImageOptions.Image")));
            this.btnQuitapractica.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuitapractica.ImageOptions.LargeImage")));
            this.btnQuitapractica.Name = "btnQuitapractica";
            this.btnQuitapractica.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuitapractica_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Valores";
            this.barHeaderItem1.Id = 19;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barHeaderItem2
            // 
            this.barHeaderItem2.Caption = "Práctica";
            this.barHeaderItem2.Id = 20;
            this.barHeaderItem2.Name = "barHeaderItem2";
            // 
            // btnAgregapractica
            // 
            this.btnAgregapractica.Caption = "Agregar";
            this.btnAgregapractica.Id = 21;
            this.btnAgregapractica.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregapractica.ImageOptions.Image")));
            this.btnAgregapractica.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregapractica.ImageOptions.LargeImage")));
            this.btnAgregapractica.Name = "btnAgregapractica";
            this.btnAgregapractica.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregapractica_ItemClick);
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
            // datFecha
            // 
            this.datFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datFecha.EditValue = null;
            this.datFecha.Location = new System.Drawing.Point(91, 4);
            this.datFecha.MenuManager = this.barManager1;
            this.datFecha.Name = "datFecha";
            this.datFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.ClassicNew;
            this.datFecha.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.datFecha.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datFecha.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.datFecha.Size = new System.Drawing.Size(114, 24);
            this.datFecha.StyleController = this.styleText;
            this.datFecha.TabIndex = 0;
            // 
            // btnImportaxls
            // 
            this.btnImportaxls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportaxls.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnImportaxls.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnImportaxls.Appearance.Options.UseBackColor = true;
            this.btnImportaxls.Appearance.Options.UseBorderColor = true;
            this.btnImportaxls.AppearanceHovered.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImportaxls.AppearanceHovered.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnImportaxls.AppearanceHovered.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportaxls.AppearanceHovered.Options.UseBackColor = true;
            this.btnImportaxls.AppearanceHovered.Options.UseBorderColor = true;
            this.btnImportaxls.AppearanceHovered.Options.UseForeColor = true;
            this.btnImportaxls.AppearancePressed.BackColor2 = System.Drawing.Color.SteelBlue;
            this.btnImportaxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportaxls.ImageOptions.Image")));
            this.btnImportaxls.Location = new System.Drawing.Point(3, 71);
            this.btnImportaxls.LookAndFeel.SkinName = "The Bezier";
            this.btnImportaxls.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnImportaxls.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnImportaxls.Name = "btnImportaxls";
            this.btnImportaxls.Size = new System.Drawing.Size(82, 23);
            this.btnImportaxls.TabIndex = 2;
            this.btnImportaxls.Text = "Importar";
            this.btnImportaxls.Click += new System.EventHandler(this.btnImportaxls_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBottom.Controls.Add(this.tableLayoutPanel2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 304);
            this.pnlBottom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBottom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(728, 122);
            this.pnlBottom.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel2.Controls.Add(this.btnAplicar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.flyoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(728, 122);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Appearance.Options.UseFont = true;
            this.btnAplicar.AppearanceHovered.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAplicar.AppearanceHovered.Options.UseFont = true;
            this.btnAplicar.AppearancePressed.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.AppearancePressed.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearancePressed.Options.UseBackColor = true;
            this.btnAplicar.AppearancePressed.Options.UseFont = true;
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(579, 3);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAplicar.Size = new System.Drawing.Size(146, 116);
            this.btnAplicar.TabIndex = 5;
            this.btnAplicar.Text = "Aplicar cambios";
            this.btnAplicar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Appearance.BackColor = System.Drawing.Color.Red;
            this.flyoutPanel1.Appearance.Options.UseBackColor = true;
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(164, 3);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.OptionsBeakPanel.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Slide;
            this.flyoutPanel1.OptionsBeakPanel.BackColor = System.Drawing.Color.Red;
            this.flyoutPanel1.OwnerControl = this.gridControl;
            this.flyoutPanel1.Size = new System.Drawing.Size(324, 116);
            this.flyoutPanel1.TabIndex = 6;
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Controls.Add(this.gridControlbk);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(324, 116);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // gridControlbk
            // 
            this.gridControlbk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlbk.Location = new System.Drawing.Point(2, 2);
            this.gridControlbk.MainView = this.gridViewbk;
            this.gridControlbk.MenuManager = this.barManager1;
            this.gridControlbk.Name = "gridControlbk";
            this.gridControlbk.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bkreposFecha,
            this.bkreposNumero});
            this.gridControlbk.Size = new System.Drawing.Size(320, 112);
            this.gridControlbk.TabIndex = 0;
            this.gridControlbk.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewbk});
            // 
            // gridViewbk
            // 
            this.gridViewbk.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewbk.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewbk.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewbk.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewbk.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewbk.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewbk.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewbk.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewbk.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewbk.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewbk.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewbk.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewbk.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewbk.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewbk.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewbk.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewbk.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewbk.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewbk.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewbk.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewbk.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewbk.Appearance.Row.Options.UseFont = true;
            this.gridViewbk.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewbk.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewbk.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewbk.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewbk.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewbk.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewbk.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewbk.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bkcolFecha,
            this.bkcolValor});
            this.gridViewbk.GridControl = this.gridControlbk;
            this.gridViewbk.Name = "gridViewbk";
            this.gridViewbk.OptionsBehavior.Editable = false;
            this.gridViewbk.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewbk.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewbk.OptionsFind.AllowFindPanel = false;
            this.gridViewbk.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridViewbk.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridViewbk.OptionsView.ShowGroupPanel = false;
            // 
            // bkcolFecha
            // 
            this.bkcolFecha.Caption = "Fecha";
            this.bkcolFecha.FieldName = "AnioMes";
            this.bkcolFecha.MinWidth = 50;
            this.bkcolFecha.Name = "bkcolFecha";
            this.bkcolFecha.Visible = true;
            this.bkcolFecha.VisibleIndex = 0;
            this.bkcolFecha.Width = 286;
            // 
            // bkcolValor
            // 
            this.bkcolValor.Caption = "Valor";
            this.bkcolValor.ColumnEdit = this.bkreposNumero;
            this.bkcolValor.FieldName = "Valor";
            this.bkcolValor.Name = "bkcolValor";
            this.bkcolValor.Visible = true;
            this.bkcolValor.VisibleIndex = 1;
            this.bkcolValor.Width = 672;
            // 
            // bkreposNumero
            // 
            this.bkreposNumero.AutoHeight = false;
            this.bkreposNumero.Mask.EditMask = "c2";
            this.bkreposNumero.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.bkreposNumero.Mask.UseMaskAsDisplayFormat = true;
            this.bkreposNumero.Name = "bkreposNumero";
            // 
            // bkreposFecha
            // 
            this.bkreposFecha.AutoHeight = false;
            this.bkreposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.bkreposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.bkreposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.bkreposFecha.Name = "bkreposFecha";
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // ScreenManager
            // 
            this.ScreenManager.ClosingDelay = 500;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPorcentaje),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnValoresDefecto),
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnQuitapractica),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAgregapractica)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // Frm_Arancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 426);
            this.Controls.Add(this.pnlBase);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_Arancel";
            this.Text = "Arancel";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposObs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlbk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewbk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkreposNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bkreposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlBase;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.GroupControl grpDatos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraSplashScreen.SplashScreenManager ScreenManager;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnPorcentaje;
        private DevExpress.XtraBars.BarButtonItem btnValoresDefecto;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGrupoPractica;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposFecha;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodPractica;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescripcionpractica;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFuncion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodigofuncion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescripcionfuncion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colValorprepaga;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumeric;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colValorOs;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colValorCaja;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colValorArt;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID_Registro;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraBars.BarButtonItem btnQuitapractica;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDPractica;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem2;
        private DevExpress.XtraEditors.DateEdit datFecha;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.XtraGrid.GridControl gridControlbk;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewbk;
        private DevExpress.XtraGrid.Columns.GridColumn bkcolFecha;
        private DevExpress.XtraGrid.Columns.GridColumn bkcolValor;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit bkreposFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit bkreposNumero;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colObsPrepaga;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colObsOs;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colObsArt;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colObsCaja;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposObs;
        private DevExpress.XtraBars.BarButtonItem btnAgregapractica;
        private DevExpress.XtraEditors.SimpleButton btnImportaxls;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGrupoOrden;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraEditors.SimpleButton btnExportxls;
    }
}