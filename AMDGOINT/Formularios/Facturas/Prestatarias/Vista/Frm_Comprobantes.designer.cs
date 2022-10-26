namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    partial class Frm_Comprobantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Comprobantes));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue5 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule6 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue6 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule7 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue7 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.colEstadoAfip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobantesasociados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCheckedbool = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAnuladas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiasVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPuntoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorDom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceptorIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportehonorarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteGastos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntereses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.bgwExportpdf = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPagado = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnExportaweb = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.titleComprobanteAfip = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.btnComprobanterel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnComprobantecero = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnCalcintereses = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwDetallesbak = new System.ComponentModel.BackgroundWorker();
            this.colAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colEstadoAfip.FieldName = "EstadoAfip";
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
            // colPagada
            // 
            this.colPagada.Caption = "Pagada";
            this.colPagada.ColumnEdit = this.reposCheckedbool;
            this.colPagada.FieldName = "Pagada";
            this.colPagada.Name = "colPagada";
            // 
            // colDiasVencimiento
            // 
            this.colDiasVencimiento.Caption = "Dias Vto.";
            this.colDiasVencimiento.FieldName = "VencidoDias";
            this.colDiasVencimiento.Name = "colDiasVencimiento";
            this.colDiasVencimiento.Visible = true;
            this.colDiasVencimiento.VisibleIndex = 17;
            this.colDiasVencimiento.Width = 69;
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
            this.colFecha,
            this.colTipo,
            this.colLetra,
            this.colPuntoVenta,
            this.colNumero,
            this.colReceptorCodigo,
            this.colReceptorNombre,
            this.colReceptorDom,
            this.colReceptorCuit,
            this.colReceptorIva,
            this.colNeto,
            this.colIva,
            this.colTotal,
            this.colImportehonorarios,
            this.colImporteGastos,
            this.colComprobantesasociados,
            this.colAnuladas,
            this.colEstadoAfip,
            this.colObservaciones,
            this.colPagada,
            this.colPeriodo,
            this.colDiasVencimiento,
            this.colIntereses,
            this.colConcepto,
            this.colAbreviatura});
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
            gridFormatRule3.StopIfTrue = true;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.colPagada;
            gridFormatRule4.Name = "Pagado";
            formatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(106)))), ((int)(((byte)(79)))));
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            formatConditionRuleValue4.Appearance.Options.HighPriority = true;
            formatConditionRuleValue4.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue4.Expression = "[Pagada]";
            gridFormatRule4.Rule = formatConditionRuleValue4;
            gridFormatRule4.StopIfTrue = true;
            gridFormatRule5.Column = this.colDiasVencimiento;
            gridFormatRule5.ColumnApplyTo = this.colDiasVencimiento;
            gridFormatRule5.Name = "MoraBaja";
            formatConditionRuleValue5.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue5.Appearance.BackColor = System.Drawing.Color.OliveDrab;
            formatConditionRuleValue5.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.LessOrEqual;
            formatConditionRuleValue5.Value1 = ((short)(7));
            gridFormatRule5.Rule = formatConditionRuleValue5;
            gridFormatRule6.Column = this.colDiasVencimiento;
            gridFormatRule6.ColumnApplyTo = this.colDiasVencimiento;
            gridFormatRule6.Name = "MoraMedia";
            formatConditionRuleValue6.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue6.Appearance.BackColor = System.Drawing.Color.Gold;
            formatConditionRuleValue6.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual;
            formatConditionRuleValue6.Value1 = ((short)(8));
            gridFormatRule6.Rule = formatConditionRuleValue6;
            gridFormatRule7.Column = this.colDiasVencimiento;
            gridFormatRule7.ColumnApplyTo = this.colDiasVencimiento;
            gridFormatRule7.Name = "MoraAlta";
            formatConditionRuleValue7.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue7.Appearance.BackColor = System.Drawing.Color.Firebrick;
            formatConditionRuleValue7.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue7.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual;
            formatConditionRuleValue7.Value1 = ((short)(16));
            gridFormatRule7.Rule = formatConditionRuleValue7;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.FormatRules.Add(gridFormatRule3);
            this.gridView.FormatRules.Add(gridFormatRule4);
            this.gridView.FormatRules.Add(gridFormatRule5);
            this.gridView.FormatRules.Add(gridFormatRule6);
            this.gridView.FormatRules.Add(gridFormatRule7);
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
            this.gridView.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView_CustomDrawGroupRow);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.ColumnEdit = this.reposFecha;
            this.colFecha.FieldName = "ComprobanteFecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 62;
            // 
            // colTipo
            // 
            this.colTipo.Caption = "Tipo";
            this.colTipo.FieldName = "ComprobanteTipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 2;
            this.colTipo.Width = 30;
            // 
            // colLetra
            // 
            this.colLetra.Caption = "Letra";
            this.colLetra.FieldName = "Letra";
            this.colLetra.Name = "colLetra";
            this.colLetra.Visible = true;
            this.colLetra.VisibleIndex = 4;
            this.colLetra.Width = 40;
            // 
            // colPuntoVenta
            // 
            this.colPuntoVenta.AppearanceCell.Options.UseTextOptions = true;
            this.colPuntoVenta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPuntoVenta.Caption = "Punto Venta";
            this.colPuntoVenta.FieldName = "ComprobantePuntoVenta";
            this.colPuntoVenta.Name = "colPuntoVenta";
            this.colPuntoVenta.Visible = true;
            this.colPuntoVenta.VisibleIndex = 3;
            this.colPuntoVenta.Width = 69;
            // 
            // colNumero
            // 
            this.colNumero.AppearanceCell.Options.UseTextOptions = true;
            this.colNumero.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNumero.Caption = "Número";
            this.colNumero.FieldName = "ComprobanteNumero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 5;
            this.colNumero.Width = 47;
            // 
            // colReceptorCodigo
            // 
            this.colReceptorCodigo.Caption = "Código";
            this.colReceptorCodigo.FieldName = "ReceptorCuentaCodigo";
            this.colReceptorCodigo.Name = "colReceptorCodigo";
            this.colReceptorCodigo.Visible = true;
            this.colReceptorCodigo.VisibleIndex = 6;
            this.colReceptorCodigo.Width = 53;
            // 
            // colReceptorNombre
            // 
            this.colReceptorNombre.Caption = "Receptor";
            this.colReceptorNombre.FieldName = "ReceptorRazonSocial";
            this.colReceptorNombre.Name = "colReceptorNombre";
            this.colReceptorNombre.Visible = true;
            this.colReceptorNombre.VisibleIndex = 7;
            this.colReceptorNombre.Width = 117;
            // 
            // colReceptorDom
            // 
            this.colReceptorDom.Caption = "Domicilio";
            this.colReceptorDom.FieldName = "ReceptorDomicilioFiscal";
            this.colReceptorDom.Name = "colReceptorDom";
            this.colReceptorDom.Visible = true;
            this.colReceptorDom.VisibleIndex = 9;
            this.colReceptorDom.Width = 65;
            // 
            // colReceptorCuit
            // 
            this.colReceptorCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colReceptorCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReceptorCuit.Caption = "Cuit";
            this.colReceptorCuit.FieldName = "ReceptorCuit";
            this.colReceptorCuit.Name = "colReceptorCuit";
            this.colReceptorCuit.Visible = true;
            this.colReceptorCuit.VisibleIndex = 10;
            this.colReceptorCuit.Width = 51;
            // 
            // colReceptorIva
            // 
            this.colReceptorIva.Caption = "IVA";
            this.colReceptorIva.FieldName = "ReceptorIvaAbreviatura";
            this.colReceptorIva.Name = "colReceptorIva";
            this.colReceptorIva.Visible = true;
            this.colReceptorIva.VisibleIndex = 11;
            this.colReceptorIva.Width = 41;
            // 
            // colNeto
            // 
            this.colNeto.AppearanceCell.Options.UseTextOptions = true;
            this.colNeto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.Caption = "$ Neto";
            this.colNeto.ColumnEdit = this.reposImportes;
            this.colNeto.FieldName = "ImporteNeto";
            this.colNeto.Name = "colNeto";
            this.colNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteNeto", "{0:C2}")});
            this.colNeto.Visible = true;
            this.colNeto.VisibleIndex = 14;
            this.colNeto.Width = 60;
            // 
            // colIva
            // 
            this.colIva.AppearanceCell.Options.UseTextOptions = true;
            this.colIva.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "$ Iva";
            this.colIva.ColumnEdit = this.reposImportes;
            this.colIva.FieldName = "ImporteIva";
            this.colIva.Name = "colIva";
            this.colIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:C2}")});
            this.colIva.Visible = true;
            this.colIva.VisibleIndex = 15;
            this.colIva.Width = 62;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "$ Total";
            this.colTotal.ColumnEdit = this.reposImportes;
            this.colTotal.FieldName = "ImporteTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 16;
            this.colTotal.Width = 70;
            // 
            // colImportehonorarios
            // 
            this.colImportehonorarios.Caption = "$ Honorarios";
            this.colImportehonorarios.ColumnEdit = this.reposImportes;
            this.colImportehonorarios.FieldName = "ImporteHonorarios";
            this.colImportehonorarios.Name = "colImportehonorarios";
            this.colImportehonorarios.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteHonorarios", "{0:C2}")});
            this.colImportehonorarios.Visible = true;
            this.colImportehonorarios.VisibleIndex = 12;
            // 
            // colImporteGastos
            // 
            this.colImporteGastos.Caption = "$ Gastos";
            this.colImporteGastos.ColumnEdit = this.reposImportes;
            this.colImporteGastos.FieldName = "ImporteGastos";
            this.colImporteGastos.Name = "colImporteGastos";
            this.colImporteGastos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteGastos", "{0:C2}")});
            this.colImporteGastos.Visible = true;
            this.colImporteGastos.VisibleIndex = 13;
            this.colImporteGastos.Width = 68;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones Afip";
            this.colObservaciones.ColumnEdit = this.reposMemo;
            this.colObservaciones.FieldName = "ObservacionesAfip";
            this.colObservaciones.Name = "colObservaciones";
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Periodo";
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 1;
            this.colPeriodo.Width = 62;
            // 
            // colIntereses
            // 
            this.colIntereses.Caption = "$ Intereses";
            this.colIntereses.FieldName = "ImporteIntereses";
            this.colIntereses.Name = "colIntereses";
            this.colIntereses.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIntereses", "{0:C2}")});
            this.colIntereses.Visible = true;
            this.colIntereses.VisibleIndex = 18;
            this.colIntereses.Width = 72;
            // 
            // colConcepto
            // 
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "ConceptoDescripcion";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 19;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPagado)});
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
            // btnPagado
            // 
            this.btnPagado.Caption = "Comprobante Pagado";
            this.btnPagado.Id = 2;
            this.btnPagado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPagado.ImageOptions.Image")));
            this.btnPagado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPagado.ImageOptions.LargeImage")));
            this.btnPagado.Name = "btnPagado";
            this.btnPagado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPagado_ItemClick);
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
            this.btnPagado});
            this.barManager1.MaxItemId = 3;
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
            this.NavPanel.Buttons.Add(this.titleComprobanteAfip);
            this.NavPanel.Buttons.Add(this.btnActualizar);
            this.NavPanel.Buttons.Add(this.btnCalcintereses);
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
            this.btnExportaweb});
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
            // btnExportaweb
            // 
            this.btnExportaweb.Caption = "Exportación Web";
            this.btnExportaweb.Name = "btnExportaweb";
            // 
            // 
            // 
            this.btnExportaweb.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            tileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement4.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement4.Text = "Exportación Web";
            this.btnExportaweb.Tile.Elements.Add(tileItemElement4);
            this.btnExportaweb.Tile.Name = "tileBarItem1";
            // 
            // titleComprobanteAfip
            // 
            this.titleComprobanteAfip.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.titleComprobanteAfip.Caption = "Comprobante Afip";
            this.titleComprobanteAfip.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("titleComprobanteAfip.ImageOptions.Image")));
            this.titleComprobanteAfip.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.btnComprobanterel,
            this.btnComprobantecero});
            this.titleComprobanteAfip.Name = "titleComprobanteAfip";
            // 
            // 
            // 
            this.titleComprobanteAfip.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            // 
            // btnComprobanterel
            // 
            this.btnComprobanterel.Caption = "Relacionado";
            this.btnComprobanterel.Name = "btnComprobanterel";
            this.btnComprobanterel.Tag = ((short)(1));
            // 
            // 
            // 
            this.btnComprobanterel.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobanterel.Tile.AppearanceItem.Normal.ForeColor = System.Drawing.Color.White;
            this.btnComprobanterel.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnComprobanterel.Tile.AppearanceItem.Normal.Options.UseForeColor = true;
            this.btnComprobanterel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            tileItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement6.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement6.Text = "Relacionado";
            this.btnComprobanterel.Tile.Elements.Add(tileItemElement6);
            this.btnComprobanterel.Tile.Name = "tileBarItem1";
            // 
            // btnComprobantecero
            // 
            this.btnComprobantecero.Caption = "tileNavItem2";
            this.btnComprobantecero.Name = "btnComprobantecero";
            this.btnComprobantecero.Tag = ((short)(2));
            // 
            // 
            // 
            this.btnComprobantecero.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobantecero.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnComprobantecero.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image7")));
            tileItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement7.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement7.Text = "Desde Cero";
            this.btnComprobantecero.Tile.Elements.Add(tileItemElement7);
            this.btnComprobantecero.Tile.Name = "tileBarItem2";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnActualizar_ElementClick);
            // 
            // btnCalcintereses
            // 
            this.btnCalcintereses.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnCalcintereses.Caption = "Calcular Intereses";
            this.btnCalcintereses.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcintereses.ImageOptions.Image")));
            this.btnCalcintereses.Name = "btnCalcintereses";
            toolTipItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image8")));
            toolTipItem2.Text = "Recalcula los intereses.";
            superToolTip2.Items.Add(toolTipItem2);
            this.btnCalcintereses.SuperTip = superToolTip2;
            this.btnCalcintereses.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnCalcintereses_ElementClick);
            // 
            // bgwDetallesbak
            // 
            this.bgwDetallesbak.WorkerSupportsCancellation = true;
            this.bgwDetallesbak.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDetallesbak_DoWork);
            this.bgwDetallesbak.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDetallesbak_RunWorkerCompleted);
            // 
            // colAbreviatura
            // 
            this.colAbreviatura.Caption = "Desc. Fantasía";
            this.colAbreviatura.FieldName = "PrestadoraAbreviatura";
            this.colAbreviatura.Name = "colAbreviatura";
            this.colAbreviatura.Visible = true;
            this.colAbreviatura.VisibleIndex = 8;
            // 
            // Frm_Comprobantes
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
            this.Name = "Frm_Comprobantes";
            this.Text = "Comprobantes Electrónicos Prestatarias";
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
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorIva;
        private DevExpress.XtraGrid.Columns.GridColumn colNeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colReceptorDom;
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
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colPagada;
        private DevExpress.XtraGrid.Columns.GridColumn colImportehonorarios;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteGastos;
        private DevExpress.XtraBars.Navigation.NavButton btnActualizar;
        private DevExpress.XtraBars.Navigation.TileNavCategory titleComprobanteAfip;
        private DevExpress.XtraBars.Navigation.TileNavItem btnComprobanterel;
        private DevExpress.XtraBars.Navigation.TileNavItem btnComprobantecero;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private System.ComponentModel.BackgroundWorker bgwDetallesbak;
        private DevExpress.XtraBars.Navigation.TileNavItem btnExportaweb;
        private DevExpress.XtraGrid.Columns.GridColumn colDiasVencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colIntereses;
        private DevExpress.XtraBars.Navigation.NavButton btnCalcintereses;
        private DevExpress.XtraBars.BarButtonItem btnPagado;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colAbreviatura;
    }
}