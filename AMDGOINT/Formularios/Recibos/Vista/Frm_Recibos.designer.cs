namespace AMDGOINT.Formularios.Recibos.Vista
{
    partial class Frm_Recibos
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Recibos));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            this.colEnviadoDos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorRz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagoRecibido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryTextSI = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryTextNO = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.bgwExportpdf = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelDetalles = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnNuevo = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnImpresion = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.btnPrevisualizacion = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnPdf = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnExcel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.timerEscucha = new System.Windows.Forms.Timer(this.components);
            this.btnFacturasCanceladas = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelDetalles.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // colEnviadoDos
            // 
            this.colEnviadoDos.Caption = "Enviado Tesorería";
            this.colEnviadoDos.FieldName = "EnviadoDosDescripcion";
            this.colEnviadoDos.Name = "colEnviadoDos";
            this.colEnviadoDos.Visible = true;
            this.colEnviadoDos.VisibleIndex = 6;
            this.colEnviadoDos.Width = 69;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
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
            this.reposFecha,
            this.reposMemo,
            this.repositoryTextSI,
            this.repositoryTextNO,
            this.reposDate});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1082, 200);
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
            this.colFechaCaja,
            this.colFecha,
            this.colFechaPago,
            this.colPeriodo,
            this.colComprobante,
            this.colReceptorCuit,
            this.colReceptorRz,
            this.colObservacion,
            this.colImporte,
            this.colPagoRecibido,
            this.colEnviadoDos,
            this.colArea,
            this.colEstado,
            this.colDebitos});
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colEnviadoDos;
            gridFormatRule3.Name = "EnviadoDos";
            formatConditionRuleValue3.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(182)))), ((int)(((byte)(154)))));
            formatConditionRuleValue3.Appearance.Options.HighPriority = true;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = "SI";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.colEstado;
            gridFormatRule4.Name = "Estado";
            formatConditionRuleValue4.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue4.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue4.Appearance.Options.HighPriority = true;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.Value1 = false;
            gridFormatRule4.Rule = formatConditionRuleValue4;
            this.gridView.FormatRules.Add(gridFormatRule3);
            this.gridView.FormatRules.Add(gridFormatRule4);
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
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            // 
            // colFechaCaja
            // 
            this.colFechaCaja.Caption = "Fecha de Caja";
            this.colFechaCaja.ColumnEdit = this.reposDate;
            this.colFechaCaja.FieldName = "FechaCaja";
            this.colFechaCaja.Name = "colFechaCaja";
            this.colFechaCaja.Visible = true;
            this.colFechaCaja.VisibleIndex = 0;
            this.colFechaCaja.Width = 96;
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
            // colFecha
            // 
            this.colFecha.Caption = "Emitido";
            this.colFecha.ColumnEdit = this.reposFecha;
            this.colFecha.FieldName = "FechaEmision";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 64;
            // 
            // colFechaPago
            // 
            this.colFechaPago.Caption = "Pagado";
            this.colFechaPago.ColumnEdit = this.reposFecha;
            this.colFechaPago.FieldName = "FechaPago";
            this.colFechaPago.Name = "colFechaPago";
            this.colFechaPago.Visible = true;
            this.colFechaPago.VisibleIndex = 3;
            this.colFechaPago.Width = 57;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Periodo";
            this.colPeriodo.FieldName = "PeriodoPago";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 4;
            this.colPeriodo.Width = 61;
            // 
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 7;
            this.colComprobante.Width = 85;
            // 
            // colReceptorCuit
            // 
            this.colReceptorCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colReceptorCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReceptorCuit.Caption = "Cuit";
            this.colReceptorCuit.FieldName = "ReceptorCuit";
            this.colReceptorCuit.Name = "colReceptorCuit";
            this.colReceptorCuit.Visible = true;
            this.colReceptorCuit.VisibleIndex = 8;
            this.colReceptorCuit.Width = 78;
            // 
            // colReceptorRz
            // 
            this.colReceptorRz.Caption = "Razón Social";
            this.colReceptorRz.FieldName = "ReceptorRazonSocial";
            this.colReceptorRz.Name = "colReceptorRz";
            this.colReceptorRz.Visible = true;
            this.colReceptorRz.VisibleIndex = 9;
            this.colReceptorRz.Width = 267;
            // 
            // colObservacion
            // 
            this.colObservacion.Caption = "Observación";
            this.colObservacion.ColumnEdit = this.reposMemo;
            this.colObservacion.FieldName = "Observacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Visible = true;
            this.colObservacion.VisibleIndex = 10;
            this.colObservacion.Width = 190;
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // colImporte
            // 
            this.colImporte.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporte.Caption = "Importe";
            this.colImporte.ColumnEdit = this.reposImportes;
            this.colImporte.FieldName = "ImporteTotal";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:C2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 11;
            this.colImporte.Width = 117;
            // 
            // colPagoRecibido
            // 
            this.colPagoRecibido.Caption = "Pago Recibido";
            this.colPagoRecibido.FieldName = "PagoRecibidoDescripcion";
            this.colPagoRecibido.Name = "colPagoRecibido";
            this.colPagoRecibido.Visible = true;
            this.colPagoRecibido.VisibleIndex = 5;
            this.colPagoRecibido.Width = 94;
            // 
            // colArea
            // 
            this.colArea.Caption = "Área";
            this.colArea.FieldName = "AreaDescripcion";
            this.colArea.Name = "colArea";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 2;
            this.colArea.Width = 69;
            // 
            // colDebitos
            // 
            this.colDebitos.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebitos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebitos.Caption = "Debitado";
            this.colDebitos.ColumnEdit = this.reposImportes;
            this.colDebitos.FieldName = "ImporteDebitado";
            this.colDebitos.Name = "colDebitos";
            this.colDebitos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteDebitado", "{0:C2}")});
            this.colDebitos.Visible = true;
            this.colDebitos.VisibleIndex = 12;
            this.colDebitos.Width = 100;
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
            // bgwExportpdf
            // 
            this.bgwExportpdf.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExportpdf_DoWork);
            this.bgwExportpdf.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwExportpdf_RunWorkerCompleted);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVisualizar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Caption = "Visualizar";
            this.btnVisualizar.Id = 0;
            this.btnVisualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.ImageOptions.Image")));
            this.btnVisualizar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.ImageOptions.LargeImage")));
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisualizar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular Recibo";
            this.btnAnular.Id = 4;
            this.btnAnular.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.ImageOptions.Image")));
            this.btnAnular.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.ImageOptions.LargeImage")));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
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
            this.btnVisualizar,
            this.btnAnular});
            this.barManager1.MaxItemId = 5;
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
            this.panelDetalles.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelDetalles.Appearance.Options.UseBorderColor = true;
            this.panelDetalles.Controls.Add(this.dockPanel2_Container);
            this.panelDetalles.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelDetalles.FloatVertical = true;
            this.panelDetalles.ID = new System.Guid("e05846cb-dbbd-4d12-ae8d-6ea554aeb5aa");
            this.panelDetalles.Location = new System.Drawing.Point(0, 275);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.OriginalSize = new System.Drawing.Size(200, 175);
            this.panelDetalles.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelDetalles.SavedIndex = 0;
            this.panelDetalles.Size = new System.Drawing.Size(1082, 175);
            this.panelDetalles.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelDetalles.Text = "Detalle";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 24);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1082, 151);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.dockPanel1_Container);
            this.panelEncabezado.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelEncabezado.ID = new System.Guid("32d67652-40b1-48b7-afe8-19c2d531847f");
            this.panelEncabezado.Location = new System.Drawing.Point(0, 52);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.OriginalSize = new System.Drawing.Size(1082, 200);
            this.panelEncabezado.Size = new System.Drawing.Size(1082, 223);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Comprobantes";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1082, 200);
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
            this.NavPanel.Buttons.Add(this.btnImpresion);
            this.NavPanel.Buttons.Add(this.btnFacturasCanceladas);
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
            this.btnEditar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnEditar.Caption = "Editar";
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.Name = "btnEditar";
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
            // btnImpresion
            // 
            this.btnImpresion.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnImpresion.Caption = "Impresión";
            this.btnImpresion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImpresion.ImageOptions.Image")));
            this.btnImpresion.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.btnPrevisualizacion,
            this.btnPdf,
            this.btnExcel});
            this.btnImpresion.Name = "btnImpresion";
            toolTipItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipItem2.Text = "Opciones de Impresión";
            superToolTip2.Items.Add(toolTipItem2);
            this.btnImpresion.SuperTip = superToolTip2;
            // 
            // 
            // 
            this.btnImpresion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            tileItemElement8.Text = "Opciones de Impresión";
            this.btnImpresion.Tile.Elements.Add(tileItemElement8);
            // 
            // btnPrevisualizacion
            // 
            this.btnPrevisualizacion.Caption = "Previsualización";
            this.btnPrevisualizacion.Name = "btnPrevisualizacion";
            // 
            // 
            // 
            this.btnPrevisualizacion.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevisualizacion.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnPrevisualizacion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement5.ImageOptions.ImageToTextIndent = 10;
            tileItemElement5.Text = "Previsualización";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnPrevisualizacion.Tile.Elements.Add(tileItemElement5);
            this.btnPrevisualizacion.Tile.Name = "btnPrevisualizacion";
            // 
            // btnPdf
            // 
            this.btnPdf.Caption = "Exportación Dividida";
            this.btnPdf.Name = "btnPdf";
            // 
            // 
            // 
            this.btnPdf.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPdf.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnPdf.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement6.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement6.ImageOptions.ImageToTextIndent = 10;
            tileItemElement6.Text = "Exportación Dividida";
            this.btnPdf.Tile.Elements.Add(tileItemElement6);
            this.btnPdf.Tile.Name = "btnExportaPdf";
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Lista Excel";
            this.btnExcel.Name = "btnExcel";
            // 
            // 
            // 
            this.btnExcel.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnExcel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            tileItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement7.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement7.ImageOptions.ImageToTextIndent = 10;
            tileItemElement7.Text = "Lista Excel";
            this.btnExcel.Tile.Elements.Add(tileItemElement7);
            this.btnExcel.Tile.Name = "btnListaExcel";
            // 
            // timerEscucha
            // 
            this.timerEscucha.Interval = 1000;
            this.timerEscucha.Tick += new System.EventHandler(this.timerEscucha_Tick);
            // 
            // btnFacturasCanceladas
            // 
            this.btnFacturasCanceladas.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnFacturasCanceladas.Caption = "Facturas Canceladas";
            this.btnFacturasCanceladas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturasCanceladas.ImageOptions.Image")));
            this.btnFacturasCanceladas.Name = "btnFacturasCanceladas";
            this.btnFacturasCanceladas.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnFacturasCanceladas_ElementClick);
            // 
            // Frm_Recibos
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
            this.Name = "Frm_Recibos";
            this.Text = "Lista de Recibos";
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTextNO)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private System.ComponentModel.BackgroundWorker bgwObtienereg;
        private System.ComponentModel.BackgroundWorker bgwExportpdf;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnVisualizar;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel panelEncabezado;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelDetalles;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraBars.Navigation.TileNavCategory btnImpresion;
        private DevExpress.XtraBars.Navigation.TileNavItem btnPrevisualizacion;
        private DevExpress.XtraBars.Navigation.TileNavItem btnPdf;
        private DevExpress.XtraBars.Navigation.TileNavItem btnExcel;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraBars.Navigation.NavButton btnNuevo;
        private DevExpress.XtraBars.Navigation.NavButton btnEditar;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorRz;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colPagoRecibido;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryTextSI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryTextNO;
        private System.Windows.Forms.Timer timerEscucha;
        private DevExpress.XtraGrid.Columns.GridColumn colEnviadoDos;
        private DevExpress.XtraBars.Navigation.NavButton btnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCaja;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitos;
        private DevExpress.XtraBars.Navigation.NavButton btnFacturasCanceladas;
    }
}