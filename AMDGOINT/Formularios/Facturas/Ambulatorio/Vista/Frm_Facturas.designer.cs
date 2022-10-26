namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    partial class Frm_Facturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Facturas));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            this.colEstadoAfip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobantesasociados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCheckedbool = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAnuladas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDLocal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmisorCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmisorNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmisorCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmisorIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorDOm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNogravado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPaciente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternacionNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternacionpuntero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.bgwExportpdf = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotificarpormail = new DevExpress.XtraBars.BarButtonItem();
            this.btnNotificarLista = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.panelDetalles = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelComprobrel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnImpresion = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.btnPrevisualizacion = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnPdf = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnExcel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnExportacionweb = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnComprobantes = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.btnComprobanterel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnComprobantecero = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnTxtSA = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnTxtSN = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnTxtFesalud = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwEnviaMails = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.reposCheckedbool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.panelDetalles.SuspendLayout();
            this.panelComprobrel.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // colEstadoAfip
            // 
            this.colEstadoAfip.Caption = "Aceptado";
            this.colEstadoAfip.FieldName = "EstadoAf";
            this.colEstadoAfip.Name = "colEstadoAfip";
            // 
            // colComprobantesasociados
            // 
            this.colComprobantesasociados.Caption = "Asociaciones";
            this.colComprobantesasociados.ColumnEdit = this.reposCheckedbool;
            this.colComprobantesasociados.FieldName = "ComprobantesAsociados";
            this.colComprobantesasociados.Name = "colComprobantesasociados";
            this.colComprobantesasociados.OptionsColumn.AllowEdit = false;
            // 
            // reposCheckedbool
            // 
            this.reposCheckedbool.AutoHeight = false;
            this.reposCheckedbool.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.reposCheckedbool.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("reposCheckedbool.ImageOptions.ImageChecked")));
            this.reposCheckedbool.Name = "reposCheckedbool";
            // 
            // colAnuladas
            // 
            this.colAnuladas.Caption = "Anulado";
            this.colAnuladas.ColumnEdit = this.reposCheckedbool;
            this.colAnuladas.FieldName = "Anulada";
            this.colAnuladas.Name = "colAnuladas";
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
            this.reposImportes.Mask.EditMask = "n2";
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
            this.reposCheckedbool,
            this.reposMemo});
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
            this.colIDLocal,
            this.colEmisorCodigo,
            this.colEmisorNombre,
            this.colEmisorCuit,
            this.colEmisorIva,
            this.colLetra,
            this.colReceptorCodigo,
            this.colReceptorDOm,
            this.colReceptorNombre,
            this.colReceptorCuit,
            this.colReceptorIva,
            this.colNeto,
            this.colIva,
            this.colNogravado,
            this.colTotal,
            this.colFecha,
            this.colTipo,
            this.colNumero,
            this.colComprobantesasociados,
            this.colAnuladas,
            this.colEstadoAfip,
            this.colObservaciones,
            this.colPaciente,
            this.colInternacionNro,
            this.colInternacionpuntero,
            this.colPlanNombre});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colEstadoAfip;
            gridFormatRule1.Name = "ComprobanteRechazado";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[EstadoAf] <> \'A\'";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colComprobantesasociados;
            gridFormatRule2.Name = "ComprobantesAsociados";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[ComprobantesAsociados]";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colAnuladas;
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
            // colIDLocal
            // 
            this.colIDLocal.FieldName = "IDLocal";
            this.colIDLocal.Name = "colIDLocal";
            this.colIDLocal.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colEmisorCodigo
            // 
            this.colEmisorCodigo.Caption = "Código";
            this.colEmisorCodigo.FieldName = "CodigoProf";
            this.colEmisorCodigo.Name = "colEmisorCodigo";
            this.colEmisorCodigo.Visible = true;
            this.colEmisorCodigo.VisibleIndex = 4;
            this.colEmisorCodigo.Width = 56;
            // 
            // colEmisorNombre
            // 
            this.colEmisorNombre.Caption = "Profesional";
            this.colEmisorNombre.FieldName = "NombreProf";
            this.colEmisorNombre.Name = "colEmisorNombre";
            this.colEmisorNombre.Visible = true;
            this.colEmisorNombre.VisibleIndex = 5;
            this.colEmisorNombre.Width = 92;
            // 
            // colEmisorCuit
            // 
            this.colEmisorCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colEmisorCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colEmisorCuit.Caption = "Cuit";
            this.colEmisorCuit.FieldName = "CuitProf";
            this.colEmisorCuit.Name = "colEmisorCuit";
            this.colEmisorCuit.Visible = true;
            this.colEmisorCuit.VisibleIndex = 6;
            this.colEmisorCuit.Width = 49;
            // 
            // colEmisorIva
            // 
            this.colEmisorIva.Caption = "IVA";
            this.colEmisorIva.FieldName = "IvaProfAbre";
            this.colEmisorIva.Name = "colEmisorIva";
            this.colEmisorIva.Visible = true;
            this.colEmisorIva.VisibleIndex = 7;
            this.colEmisorIva.Width = 37;
            // 
            // colLetra
            // 
            this.colLetra.Caption = "Letra";
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            this.colLetra.Visible = true;
            this.colLetra.VisibleIndex = 2;
            this.colLetra.Width = 58;
            // 
            // colReceptorCodigo
            // 
            this.colReceptorCodigo.Caption = "Código";
            this.colReceptorCodigo.FieldName = "CodigoPres";
            this.colReceptorCodigo.Name = "colReceptorCodigo";
            this.colReceptorCodigo.Visible = true;
            this.colReceptorCodigo.VisibleIndex = 8;
            this.colReceptorCodigo.Width = 48;
            // 
            // colReceptorDOm
            // 
            this.colReceptorDOm.Caption = "Domicilio";
            this.colReceptorDOm.FieldName = "DomFiscalPres";
            this.colReceptorDOm.Name = "colReceptorDOm";
            this.colReceptorDOm.Visible = true;
            this.colReceptorDOm.VisibleIndex = 10;
            this.colReceptorDOm.Width = 63;
            // 
            // colReceptorNombre
            // 
            this.colReceptorNombre.Caption = "Prestataria";
            this.colReceptorNombre.FieldName = "NombrePres";
            this.colReceptorNombre.Name = "colReceptorNombre";
            this.colReceptorNombre.Visible = true;
            this.colReceptorNombre.VisibleIndex = 9;
            this.colReceptorNombre.Width = 77;
            // 
            // colReceptorCuit
            // 
            this.colReceptorCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colReceptorCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReceptorCuit.Caption = "Cuit";
            this.colReceptorCuit.FieldName = "CuitPres";
            this.colReceptorCuit.Name = "colReceptorCuit";
            this.colReceptorCuit.Visible = true;
            this.colReceptorCuit.VisibleIndex = 11;
            this.colReceptorCuit.Width = 51;
            // 
            // colReceptorIva
            // 
            this.colReceptorIva.Caption = "IVA";
            this.colReceptorIva.FieldName = "IvaPresAbre";
            this.colReceptorIva.Name = "colReceptorIva";
            this.colReceptorIva.Visible = true;
            this.colReceptorIva.VisibleIndex = 12;
            this.colReceptorIva.Width = 40;
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
            this.colNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Neto", "{0:C2}")});
            this.colNeto.Visible = true;
            this.colNeto.VisibleIndex = 13;
            this.colNeto.Width = 69;
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
            this.colIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Iva", "{0:C2}")});
            this.colIva.Visible = true;
            this.colIva.VisibleIndex = 15;
            this.colIva.Width = 51;
            // 
            // colNogravado
            // 
            this.colNogravado.AppearanceCell.Options.UseTextOptions = true;
            this.colNogravado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNogravado.AppearanceHeader.Options.UseTextOptions = true;
            this.colNogravado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNogravado.Caption = "$ No Gravado";
            this.colNogravado.ColumnEdit = this.reposImportes;
            this.colNogravado.FieldName = "NoGravado";
            this.colNogravado.Name = "colNogravado";
            this.colNogravado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NoGravado", "{0:C2}")});
            this.colNogravado.Visible = true;
            this.colNogravado.VisibleIndex = 14;
            this.colNogravado.Width = 97;
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
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 16;
            this.colTotal.Width = 67;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.ColumnEdit = this.reposFecha;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", "{0}")});
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 61;
            // 
            // colTipo
            // 
            this.colTipo.Caption = "Tipo";
            this.colTipo.FieldName = "TipoComprobante";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 1;
            this.colTipo.Width = 60;
            // 
            // colNumero
            // 
            this.colNumero.Caption = "Número";
            this.colNumero.FieldName = "Comprobante";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 3;
            this.colNumero.Width = 66;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones Afip";
            this.colObservaciones.ColumnEdit = this.reposMemo;
            this.colObservaciones.FieldName = "ObservAf";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // colPaciente
            // 
            this.colPaciente.Caption = "Paciente";
            this.colPaciente.FieldName = "Paciente";
            this.colPaciente.Name = "colPaciente";
            // 
            // colInternacionNro
            // 
            this.colInternacionNro.Caption = "Internación Nro.";
            this.colInternacionNro.FieldName = "InternacionNumero";
            this.colInternacionNro.Name = "colInternacionNro";
            // 
            // colInternacionpuntero
            // 
            this.colInternacionpuntero.Caption = "Internación Puntero";
            this.colInternacionpuntero.FieldName = "InternacionPuntero";
            this.colInternacionpuntero.Name = "colInternacionpuntero";
            // 
            // colPlanNombre
            // 
            this.colPlanNombre.Caption = "Nombre Fantasía";
            this.colPlanNombre.FieldName = "PrestatariaPlanNombre";
            this.colPlanNombre.Name = "colPlanNombre";
            this.colPlanNombre.Visible = true;
            this.colPlanNombre.VisibleIndex = 17;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNotificarpormail),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNotificarLista)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
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
            // btnNotificarpormail
            // 
            this.btnNotificarpormail.Caption = "Notificar vía email";
            this.btnNotificarpormail.Id = 2;
            this.btnNotificarpormail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNotificarpormail.ImageOptions.Image")));
            this.btnNotificarpormail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNotificarpormail.ImageOptions.LargeImage")));
            this.btnNotificarpormail.Name = "btnNotificarpormail";
            this.btnNotificarpormail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotificarpormail_ItemClick);
            // 
            // btnNotificarLista
            // 
            this.btnNotificarLista.Caption = "Notificar Lista via email";
            this.btnNotificarLista.Id = 3;
            this.btnNotificarLista.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNotificarLista.ImageOptions.Image")));
            this.btnNotificarLista.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNotificarLista.ImageOptions.LargeImage")));
            this.btnNotificarLista.Name = "btnNotificarLista";
            this.btnNotificarLista.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNotificarLista_ItemClick);
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
            this.btnNotificarpormail,
            this.btnNotificarLista});
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
            this.panelContainer1,
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
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.panelDetalles;
            this.panelContainer1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelContainer1.Appearance.Options.UseBorderColor = true;
            this.panelContainer1.Controls.Add(this.panelDetalles);
            this.panelContainer1.Controls.Add(this.panelComprobrel);
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
            // panelDetalles
            // 
            this.panelDetalles.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelDetalles.Appearance.Options.UseBorderColor = true;
            this.panelDetalles.Controls.Add(this.dockPanel2_Container);
            this.panelDetalles.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelDetalles.FloatVertical = true;
            this.panelDetalles.ID = new System.Guid("e05846cb-dbbd-4d12-ae8d-6ea554aeb5aa");
            this.panelDetalles.Location = new System.Drawing.Point(0, 50);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.OriginalSize = new System.Drawing.Size(1082, 82);
            this.panelDetalles.Size = new System.Drawing.Size(1082, 125);
            this.panelDetalles.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelDetalles.Text = "Detalle";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1082, 125);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // panelComprobrel
            // 
            this.panelComprobrel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelComprobrel.Appearance.Options.UseBorderColor = true;
            this.panelComprobrel.Controls.Add(this.controlContainer1);
            this.panelComprobrel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelComprobrel.DockVertical = DevExpress.Utils.DefaultBoolean.True;
            this.panelComprobrel.ID = new System.Guid("148db19e-77a5-42e7-ad06-d8286b9e87d8");
            this.panelComprobrel.Location = new System.Drawing.Point(0, 50);
            this.panelComprobrel.Name = "panelComprobrel";
            this.panelComprobrel.Options.ShowCloseButton = false;
            this.panelComprobrel.OriginalSize = new System.Drawing.Size(1082, 82);
            this.panelComprobrel.Size = new System.Drawing.Size(1082, 125);
            this.panelComprobrel.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelComprobrel.Text = "Comprobantes relacionados";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(1082, 125);
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
            this.panelEncabezado.Size = new System.Drawing.Size(1082, 223);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Comprobantes Electrónicos";
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
            this.NavPanel.Buttons.Add(this.btnImpresion);
            this.NavPanel.Buttons.Add(this.btnComprobantes);
            this.NavPanel.Buttons.Add(this.btnTxtSA);
            this.NavPanel.Buttons.Add(this.btnTxtSN);
            this.NavPanel.Buttons.Add(this.btnTxtFesalud);
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
            // btnImpresion
            // 
            this.btnImpresion.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnImpresion.Caption = "Impresión";
            this.btnImpresion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImpresion.ImageOptions.Image")));
            this.btnImpresion.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.btnPrevisualizacion,
            this.btnPdf,
            this.btnExcel,
            this.btnExportacionweb});
            this.btnImpresion.Name = "btnImpresion";
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipItem1.Text = "Opciones de Impresión";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnImpresion.SuperTip = superToolTip1;
            // 
            // 
            // 
            this.btnImpresion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            tileItemElement5.Text = "Opciones de Impresión";
            this.btnImpresion.Tile.Elements.Add(tileItemElement5);
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
            tileItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement1.ImageOptions.ImageToTextIndent = 10;
            tileItemElement1.Text = "Previsualización";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnPrevisualizacion.Tile.Elements.Add(tileItemElement1);
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
            tileItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement2.ImageOptions.ImageToTextIndent = 10;
            tileItemElement2.Text = "Exportación Dividida";
            this.btnPdf.Tile.Elements.Add(tileItemElement2);
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
            tileItemElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement3.ImageOptions.ImageToTextIndent = 10;
            tileItemElement3.Text = "Lista Excel";
            this.btnExcel.Tile.Elements.Add(tileItemElement3);
            this.btnExcel.Tile.Name = "btnListaExcel";
            // 
            // btnExportacionweb
            // 
            this.btnExportacionweb.Caption = "Exportación Web";
            this.btnExportacionweb.Name = "btnExportacionweb";
            // 
            // 
            // 
            this.btnExportacionweb.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            tileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement4.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement4.ImageOptions.ImageToTextIndent = 10;
            tileItemElement4.Text = "Exportación Web";
            this.btnExportacionweb.Tile.Elements.Add(tileItemElement4);
            this.btnExportacionweb.Tile.Name = "tileBarItem1";
            // 
            // btnComprobantes
            // 
            this.btnComprobantes.Caption = "Comprobante Afip";
            this.btnComprobantes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnComprobantes.ImageOptions.Image")));
            this.btnComprobantes.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.btnComprobanterel,
            this.btnComprobantecero});
            this.btnComprobantes.Name = "btnComprobantes";
            // 
            // 
            // 
            this.btnComprobantes.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            // 
            // btnComprobanterel
            // 
            this.btnComprobanterel.Caption = "Relacionado";
            this.btnComprobanterel.Name = "btnComprobanterel";
            // 
            // 
            // 
            this.btnComprobanterel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            tileItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement6.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement6.Text = "Relacionado";
            this.btnComprobanterel.Tile.Elements.Add(tileItemElement6);
            this.btnComprobanterel.Tile.Name = "btnComprobanterel";
            // 
            // btnComprobantecero
            // 
            this.btnComprobantecero.Caption = "Desde Cero";
            this.btnComprobantecero.Name = "btnComprobantecero";
            // 
            // 
            // 
            this.btnComprobantecero.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image7")));
            tileItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement7.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement7.Text = "Desde Cero";
            this.btnComprobantecero.Tile.Elements.Add(tileItemElement7);
            this.btnComprobantecero.Tile.Name = "tileBarItem2";
            // 
            // btnTxtSA
            // 
            this.btnTxtSA.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnTxtSA.Caption = "Generar Txt";
            this.btnTxtSA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTxtSA.ImageOptions.Image")));
            this.btnTxtSA.Name = "btnTxtSA";
            this.btnTxtSA.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnTxt_ElementClick);
            // 
            // btnTxtSN
            // 
            this.btnTxtSN.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnTxtSN.Caption = "Txt SN";
            this.btnTxtSN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTxtSN.ImageOptions.Image")));
            this.btnTxtSN.Name = "btnTxtSN";
            this.btnTxtSN.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnTxtSN_ElementClick);
            // 
            // btnTxtFesalud
            // 
            this.btnTxtFesalud.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnTxtFesalud.Caption = "Txt Fesalud";
            this.btnTxtFesalud.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTxtFesalud.ImageOptions.Image")));
            this.btnTxtFesalud.Name = "btnTxtFesalud";
            this.btnTxtFesalud.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnTxtFesalud_ElementClick);
            // 
            // bgwEnviaMails
            // 
            this.bgwEnviaMails.WorkerSupportsCancellation = true;
            this.bgwEnviaMails.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEnviaMails_DoWork);
            this.bgwEnviaMails.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwEnviaMails_RunWorkerCompleted);
            // 
            // Frm_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 450);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.NavPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_Facturas";
            this.Text = "Comprobantes Electrónicos Prestadores";
            ((System.ComponentModel.ISupportInitialize)(this.reposCheckedbool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.panelDetalles.ResumeLayout(false);
            this.panelComprobrel.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn colIDLocal;
        private DevExpress.XtraGrid.Columns.GridColumn colEmisorCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colEmisorNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colEmisorCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colEmisorIva;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorIva;
        private DevExpress.XtraGrid.Columns.GridColumn colNeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colNogravado;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorDOm;
        private DevExpress.XtraGrid.Columns.GridColumn colLetra;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private System.ComponentModel.BackgroundWorker bgwObtienereg;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
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
        private DevExpress.XtraBars.Docking.DockPanel panelComprobrel;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobantesasociados;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheckedbool;
        private DevExpress.XtraGrid.Columns.GridColumn colAnuladas;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoAfip;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colPaciente;
        private DevExpress.XtraGrid.Columns.GridColumn colInternacionNro;
        private DevExpress.XtraGrid.Columns.GridColumn colInternacionpuntero;
        private DevExpress.XtraBars.Navigation.TileNavItem btnExportacionweb;
        private DevExpress.XtraBars.Navigation.NavButton btnTxtSA;
        private System.ComponentModel.BackgroundWorker bgwEnviaMails;
        private DevExpress.XtraBars.BarButtonItem btnNotificarpormail;
        private DevExpress.XtraBars.BarButtonItem btnNotificarLista;
        private DevExpress.XtraBars.Navigation.TileNavCategory btnComprobantes;
        private DevExpress.XtraBars.Navigation.TileNavItem btnComprobanterel;
        private DevExpress.XtraBars.Navigation.TileNavItem btnComprobantecero;
        private DevExpress.XtraBars.Navigation.NavButton btnTxtSN;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanNombre;
        private DevExpress.XtraBars.Navigation.NavButton btnTxtFesalud;
    }
}