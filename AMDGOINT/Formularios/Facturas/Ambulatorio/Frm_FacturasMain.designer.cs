namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    partial class Frm_FacturasMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FacturasMain));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colEmisorPuntovta = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnPendientes = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnGenerafact = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnPruebacuit = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmisorNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmisorCodigo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmisorCuit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmisorIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colReceptorNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colID_Registro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colReceptorCodigo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colReceptorCuit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colReceptorIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colNeto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSeleccionado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.flyoutPanel = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl = new DevExpress.Utils.FlyoutPanelControl();
            this.ppGenerando = new DevExpress.XtraWaitForm.ProgressPanel();
            this.DSDatos = new AMDGOINT.Datos.DSDatos();
            this.bgwPendientes = new System.ComponentModel.BackgroundWorker();
            this.bgwFacturas = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnPventa = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel)).BeginInit();
            this.flyoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl)).BeginInit();
            this.flyoutPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colEmisorPuntovta
            // 
            this.colEmisorPuntovta.AppearanceCell.Options.UseTextOptions = true;
            this.colEmisorPuntovta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmisorPuntovta.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmisorPuntovta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmisorPuntovta.Caption = "Punto Vta.";
            this.colEmisorPuntovta.FieldName = "EmisorPuntoVta";
            this.colEmisorPuntovta.Name = "colEmisorPuntovta";
            this.colEmisorPuntovta.RowIndex = 1;
            this.colEmisorPuntovta.Visible = true;
            this.colEmisorPuntovta.Width = 96;
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(783, 52);
            this.pblTop.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnPendientes);
            this.NavPanel.Buttons.Add(this.btnGenerafact);
            this.NavPanel.Buttons.Add(this.btnPruebacuit);
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
            this.NavPanel.Size = new System.Drawing.Size(783, 52);
            this.NavPanel.TabIndex = 0;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btnPendientes
            // 
            this.btnPendientes.Caption = "Obtener Pendientes";
            this.btnPendientes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPendientes.ImageOptions.Image")));
            this.btnPendientes.Name = "btnPendientes";
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipItem1.Text = "Obtener registros pendientes de facturar.";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnPendientes.SuperTip = superToolTip1;
            this.btnPendientes.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnPendientes_ElementClick);
            // 
            // btnGenerafact
            // 
            this.btnGenerafact.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnGenerafact.Caption = "Generar Facturas";
            this.btnGenerafact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerafact.ImageOptions.Image")));
            this.btnGenerafact.Name = "btnGenerafact";
            toolTipItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipItem2.Text = "Generar facturas disponibles.";
            superToolTip2.Items.Add(toolTipItem2);
            this.btnGenerafact.SuperTip = superToolTip2;
            this.btnGenerafact.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnGenerafact_ElementClick);
            // 
            // btnPruebacuit
            // 
            this.btnPruebacuit.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnPruebacuit.Caption = "Probar Cred Afip";
            this.btnPruebacuit.Name = "btnPruebacuit";
            this.btnPruebacuit.Visible = false;
            this.btnPruebacuit.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButton2_ElementClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flyoutPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.7482F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.2518F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 370);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.bgridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes,
            this.reposFecha});
            this.gridControl.Size = new System.Drawing.Size(777, 233);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgridView});
            // 
            // bgridView
            // 
            this.bgridView.Appearance.BandPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.gridBand3,
            this.gridBand1,
            this.gridBand4});
            this.bgridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID_Registro,
            this.colSeleccionado,
            this.colEmisorCodigo,
            this.colEmisorNombre,
            this.colEmisorCuit,
            this.colEmisorIva,
            this.colEmisorPuntovta,
            this.colReceptorCodigo,
            this.colReceptorNombre,
            this.colReceptorCuit,
            this.colReceptorIva,
            this.colNeto,
            this.colIva,
            this.colTotal});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colEmisorPuntovta;
            gridFormatRule1.Name = "SinPuntovta";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Indigo;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.LessOrEqual;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.bgridView.FormatRules.Add(gridFormatRule1);
            this.bgridView.GridControl = this.gridControl;
            this.bgridView.Name = "bgridView";
            this.bgridView.OptionsBehavior.Editable = false;
            this.bgridView.OptionsCustomization.AllowBandMoving = false;
            this.bgridView.OptionsDetail.EnableMasterViewMode = false;
            this.bgridView.OptionsDetail.ShowDetailTabs = false;
            this.bgridView.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
            this.bgridView.OptionsDetail.SmartDetailExpand = false;
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
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Datos de Profesionales";
            this.gridBand3.Columns.Add(this.colEmisorNombre);
            this.gridBand3.Columns.Add(this.colEmisorCodigo);
            this.gridBand3.Columns.Add(this.colEmisorCuit);
            this.gridBand3.Columns.Add(this.colEmisorIva);
            this.gridBand3.Columns.Add(this.colEmisorPuntovta);
            this.gridBand3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand3.ImageOptions.Image")));
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.OptionsBand.AllowMove = false;
            this.gridBand3.VisibleIndex = 0;
            this.gridBand3.Width = 393;
            // 
            // colEmisorNombre
            // 
            this.colEmisorNombre.Caption = "Profesional";
            this.colEmisorNombre.FieldName = "EmisorNombre";
            this.colEmisorNombre.Name = "colEmisorNombre";
            this.colEmisorNombre.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmisorNombre", "{0} Registros")});
            this.colEmisorNombre.Visible = true;
            this.colEmisorNombre.Width = 393;
            // 
            // colEmisorCodigo
            // 
            this.colEmisorCodigo.Caption = "Código";
            this.colEmisorCodigo.FieldName = "EmisorCodigo";
            this.colEmisorCodigo.Name = "colEmisorCodigo";
            this.colEmisorCodigo.RowIndex = 1;
            this.colEmisorCodigo.Visible = true;
            this.colEmisorCodigo.Width = 104;
            // 
            // colEmisorCuit
            // 
            this.colEmisorCuit.Caption = "Cuit";
            this.colEmisorCuit.FieldName = "EmisorCuit";
            this.colEmisorCuit.Name = "colEmisorCuit";
            this.colEmisorCuit.RowIndex = 1;
            this.colEmisorCuit.Visible = true;
            this.colEmisorCuit.Width = 140;
            // 
            // colEmisorIva
            // 
            this.colEmisorIva.Caption = "IVA";
            this.colEmisorIva.FieldName = "EmisorIva";
            this.colEmisorIva.Name = "colEmisorIva";
            this.colEmisorIva.RowIndex = 1;
            this.colEmisorIva.Visible = true;
            this.colEmisorIva.Width = 53;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Datos de Prestatarias";
            this.gridBand1.Columns.Add(this.colReceptorNombre);
            this.gridBand1.Columns.Add(this.colID_Registro);
            this.gridBand1.Columns.Add(this.colReceptorCodigo);
            this.gridBand1.Columns.Add(this.colReceptorCuit);
            this.gridBand1.Columns.Add(this.colReceptorIva);
            this.gridBand1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand1.ImageOptions.Image")));
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 521;
            // 
            // colReceptorNombre
            // 
            this.colReceptorNombre.Caption = "Prestataria";
            this.colReceptorNombre.FieldName = "ReceptorNombre";
            this.colReceptorNombre.Name = "colReceptorNombre";
            this.colReceptorNombre.Visible = true;
            this.colReceptorNombre.Width = 521;
            // 
            // colID_Registro
            // 
            this.colID_Registro.FieldName = "IDComprobante";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            this.colID_Registro.RowIndex = 1;
            // 
            // colReceptorCodigo
            // 
            this.colReceptorCodigo.Caption = "Código";
            this.colReceptorCodigo.FieldName = "ReceptorCodigo";
            this.colReceptorCodigo.Name = "colReceptorCodigo";
            this.colReceptorCodigo.RowIndex = 1;
            this.colReceptorCodigo.Visible = true;
            this.colReceptorCodigo.Width = 168;
            // 
            // colReceptorCuit
            // 
            this.colReceptorCuit.Caption = "Cuit";
            this.colReceptorCuit.FieldName = "ReceptorCuit";
            this.colReceptorCuit.Name = "colReceptorCuit";
            this.colReceptorCuit.RowIndex = 1;
            this.colReceptorCuit.Visible = true;
            this.colReceptorCuit.Width = 190;
            // 
            // colReceptorIva
            // 
            this.colReceptorIva.Caption = "IVA";
            this.colReceptorIva.FieldName = "ReceptorIva";
            this.colReceptorIva.Name = "colReceptorIva";
            this.colReceptorIva.RowIndex = 1;
            this.colReceptorIva.Visible = true;
            this.colReceptorIva.Width = 163;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridBand4.Caption = "Importes";
            this.gridBand4.Columns.Add(this.colTotal);
            this.gridBand4.Columns.Add(this.colNeto);
            this.gridBand4.Columns.Add(this.colIva);
            this.gridBand4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand4.ImageOptions.Image")));
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.AllowMove = false;
            this.gridBand4.VisibleIndex = 2;
            this.gridBand4.Width = 149;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "$ Total";
            this.colTotal.ColumnEdit = this.reposImportes;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.Width = 149;
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "n";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // colNeto
            // 
            this.colNeto.AppearanceCell.Options.UseTextOptions = true;
            this.colNeto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.Caption = "$ Neto";
            this.colNeto.ColumnEdit = this.reposImportes;
            this.colNeto.FieldName = "Neto";
            this.colNeto.Name = "colNeto";
            this.colNeto.RowIndex = 1;
            this.colNeto.Visible = true;
            this.colNeto.Width = 74;
            // 
            // colIva
            // 
            this.colIva.AppearanceCell.Options.UseTextOptions = true;
            this.colIva.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "$ Iva";
            this.colIva.ColumnEdit = this.reposImportes;
            this.colIva.FieldName = "Iva";
            this.colIva.Name = "colIva";
            this.colIva.RowIndex = 1;
            this.colIva.Visible = true;
            // 
            // colSeleccionado
            // 
            this.colSeleccionado.Caption = "...";
            this.colSeleccionado.FieldName = "Seleccionado";
            this.colSeleccionado.Name = "colSeleccionado";
            this.colSeleccionado.OptionsColumn.ShowCaption = false;
            this.colSeleccionado.OptionsColumn.ShowInCustomizationForm = false;
            this.colSeleccionado.Visible = true;
            this.colSeleccionado.Width = 22;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // flyoutPanel
            // 
            this.flyoutPanel.Controls.Add(this.flyoutPanelControl);
            this.flyoutPanel.Location = new System.Drawing.Point(3, 242);
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
            this.ppGenerando.Caption = "Generando Facturas";
            this.ppGenerando.Description = "Espere...";
            this.ppGenerando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppGenerando.Location = new System.Drawing.Point(2, 2);
            this.ppGenerando.Name = "ppGenerando";
            this.ppGenerando.Size = new System.Drawing.Size(219, 89);
            this.ppGenerando.TabIndex = 0;
            this.ppGenerando.Text = "progressPanel1";
            // 
            // DSDatos
            // 
            this.DSDatos.DataSetName = "DSDatos";
            this.DSDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bgwPendientes
            // 
            this.bgwPendientes.WorkerSupportsCancellation = true;
            this.bgwPendientes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPendientes_DoWork);
            this.bgwPendientes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPendientes_RunWorkerCompleted);
            // 
            // bgwFacturas
            // 
            this.bgwFacturas.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFacturas_DoWork);
            this.bgwFacturas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFacturas_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPventa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Opciones";
            this.barHeaderItem1.Id = 1;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // btnPventa
            // 
            this.btnPventa.Caption = "Asignar Punto de Venta";
            this.btnPventa.Id = 0;
            this.btnPventa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPventa.ImageOptions.Image")));
            this.btnPventa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPventa.ImageOptions.LargeImage")));
            this.btnPventa.Name = "btnPventa";
            this.btnPventa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPventa_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPventa,
            this.barHeaderItem1,
            this.btnExport});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(783, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 422);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(783, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 422);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(783, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 422);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Exportar  a excel";
            this.btnExport.Id = 2;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.LargeImage")));
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // Frm_FacturasMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 422);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_FacturasMain";
            this.Text = "Pendientes / Generación";
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel)).EndInit();
            this.flyoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl)).EndInit();
            this.flyoutPanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DSDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pblTop;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraBars.Navigation.NavButton btnPendientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.Utils.FlyoutPanel flyoutPanel;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl;
        private DevExpress.XtraWaitForm.ProgressPanel ppGenerando;
        private System.ComponentModel.BackgroundWorker bgwPendientes;
        private Datos.DSDatos DSDatos;
        private DevExpress.XtraBars.Navigation.NavButton btnGenerafact;
        private System.ComponentModel.BackgroundWorker bgwFacturas;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bgridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSeleccionado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmisorNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmisorCodigo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmisorCuit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmisorIva;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colReceptorNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID_Registro;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colReceptorCodigo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colReceptorCuit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colReceptorIva;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNeto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIva;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmisorPuntovta;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnPventa;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.Navigation.NavButton btnPruebacuit;
        private DevExpress.XtraBars.BarButtonItem btnExport;
    }
}