namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    partial class Frm_Pendientes
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Pendientes));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.gridViewdet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.coldCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldPractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldNombrepaci = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimales = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colHonorarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colGastos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadorcuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadornom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadoriva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTipocomprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPventa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobanteletra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoprestadora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCondicioniva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadoraIvaPorc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExesoIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnPendientes = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnGenerafact = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnExportar = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bgwPendientes = new System.ComponentModel.BackgroundWorker();
            this.bgwFacturas = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewdet
            // 
            this.gridViewdet.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewdet.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewdet.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewdet.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewdet.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewdet.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewdet.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewdet.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewdet.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewdet.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewdet.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewdet.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewdet.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewdet.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewdet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewdet.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewdet.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewdet.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewdet.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewdet.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewdet.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewdet.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewdet.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewdet.Appearance.Row.Options.UseFont = true;
            this.gridViewdet.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewdet.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewdet.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewdet.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewdet.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewdet.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewdet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewdet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldFecha,
            this.coldCodigo,
            this.coldPractica,
            this.colFuncion,
            this.coldDocumento,
            this.coldNombrepaci,
            this.colComprobante,
            this.coldCantidad,
            this.colHonorarios,
            this.colGastos,
            this.coldNeto,
            this.coldIva,
            this.coldTotal,
            this.colPrestadorcuenta,
            this.colPrestadornom,
            this.colPrestadoriva});
            this.gridViewdet.GridControl = this.gridControl;
            this.gridViewdet.Name = "gridViewdet";
            this.gridViewdet.OptionsBehavior.Editable = false;
            this.gridViewdet.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewdet.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridViewdet.OptionsView.ShowFooter = true;
            this.gridViewdet.OptionsView.ShowIndicator = false;
            // 
            // coldFecha
            // 
            this.coldFecha.Caption = "Fecha";
            this.coldFecha.ColumnEdit = this.reposFecha;
            this.coldFecha.FieldName = "PracticaFecha";
            this.coldFecha.Name = "coldFecha";
            this.coldFecha.Visible = true;
            this.coldFecha.VisibleIndex = 0;
            this.coldFecha.Width = 67;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // coldCodigo
            // 
            this.coldCodigo.Caption = "Código";
            this.coldCodigo.FieldName = "PracticaCodigo";
            this.coldCodigo.Name = "coldCodigo";
            this.coldCodigo.Visible = true;
            this.coldCodigo.VisibleIndex = 4;
            this.coldCodigo.Width = 85;
            // 
            // coldPractica
            // 
            this.coldPractica.Caption = "Práctica";
            this.coldPractica.FieldName = "PracticaDescripcion";
            this.coldPractica.Name = "coldPractica";
            this.coldPractica.Visible = true;
            this.coldPractica.VisibleIndex = 5;
            this.coldPractica.Width = 85;
            // 
            // colFuncion
            // 
            this.colFuncion.Caption = "Función";
            this.colFuncion.FieldName = "PracticaFuncionCodigo";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.Visible = true;
            this.colFuncion.VisibleIndex = 6;
            this.colFuncion.Width = 85;
            // 
            // coldDocumento
            // 
            this.coldDocumento.AppearanceCell.Options.UseTextOptions = true;
            this.coldDocumento.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.coldDocumento.Caption = "Doc. Paciente";
            this.coldDocumento.FieldName = "PacienteDocumento";
            this.coldDocumento.Name = "coldDocumento";
            this.coldDocumento.Visible = true;
            this.coldDocumento.VisibleIndex = 7;
            this.coldDocumento.Width = 85;
            // 
            // coldNombrepaci
            // 
            this.coldNombrepaci.Caption = "Paciente";
            this.coldNombrepaci.FieldName = "PacienteNombre";
            this.coldNombrepaci.Name = "coldNombrepaci";
            this.coldNombrepaci.Visible = true;
            this.coldNombrepaci.VisibleIndex = 8;
            this.coldNombrepaci.Width = 85;
            // 
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "Descripcion";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 9;
            // 
            // coldCantidad
            // 
            this.coldCantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.coldCantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldCantidad.Caption = "Cantidad";
            this.coldCantidad.ColumnEdit = this.reposDecimales;
            this.coldCantidad.FieldName = "Cantidad";
            this.coldCantidad.Name = "coldCantidad";
            this.coldCantidad.Visible = true;
            this.coldCantidad.VisibleIndex = 10;
            this.coldCantidad.Width = 85;
            // 
            // reposDecimales
            // 
            this.reposDecimales.AutoHeight = false;
            this.reposDecimales.Mask.EditMask = "n2";
            this.reposDecimales.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimales.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimales.Name = "reposDecimales";
            // 
            // colHonorarios
            // 
            this.colHonorarios.AppearanceHeader.Options.UseTextOptions = true;
            this.colHonorarios.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHonorarios.Caption = "$ Honorarios";
            this.colHonorarios.ColumnEdit = this.reposImportes;
            this.colHonorarios.FieldName = "ImporteHonorarios";
            this.colHonorarios.Name = "colHonorarios";
            this.colHonorarios.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteHonorarios", "{0:C2}")});
            this.colHonorarios.Visible = true;
            this.colHonorarios.VisibleIndex = 11;
            this.colHonorarios.Width = 71;
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "c2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // colGastos
            // 
            this.colGastos.AppearanceHeader.Options.UseTextOptions = true;
            this.colGastos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colGastos.Caption = "$ Gastos";
            this.colGastos.ColumnEdit = this.reposImportes;
            this.colGastos.FieldName = "ImporteGastos";
            this.colGastos.Name = "colGastos";
            this.colGastos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteGastos", "{0:C2}")});
            this.colGastos.Visible = true;
            this.colGastos.VisibleIndex = 12;
            this.colGastos.Width = 71;
            // 
            // coldNeto
            // 
            this.coldNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.coldNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldNeto.Caption = "$ Neto";
            this.coldNeto.ColumnEdit = this.reposImportes;
            this.coldNeto.FieldName = "ImporteNeto";
            this.coldNeto.Name = "coldNeto";
            this.coldNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteNeto", "{0:C2}")});
            this.coldNeto.Visible = true;
            this.coldNeto.VisibleIndex = 13;
            this.coldNeto.Width = 85;
            // 
            // coldIva
            // 
            this.coldIva.AppearanceHeader.Options.UseTextOptions = true;
            this.coldIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldIva.Caption = "$ Iva";
            this.coldIva.ColumnEdit = this.reposImportes;
            this.coldIva.FieldName = "ImporteIva";
            this.coldIva.Name = "coldIva";
            this.coldIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:C2}")});
            this.coldIva.Visible = true;
            this.coldIva.VisibleIndex = 14;
            this.coldIva.Width = 76;
            // 
            // coldTotal
            // 
            this.coldTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.coldTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldTotal.Caption = "$ Total";
            this.coldTotal.ColumnEdit = this.reposImportes;
            this.coldTotal.FieldName = "ImporteTotal";
            this.coldTotal.Name = "coldTotal";
            this.coldTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:C2}")});
            this.coldTotal.Visible = true;
            this.coldTotal.VisibleIndex = 15;
            this.coldTotal.Width = 91;
            // 
            // colPrestadorcuenta
            // 
            this.colPrestadorcuenta.Caption = "Cuenta";
            this.colPrestadorcuenta.FieldName = "PrestadorCuentaCodigo";
            this.colPrestadorcuenta.Name = "colPrestadorcuenta";
            this.colPrestadorcuenta.Visible = true;
            this.colPrestadorcuenta.VisibleIndex = 1;
            this.colPrestadorcuenta.Width = 71;
            // 
            // colPrestadornom
            // 
            this.colPrestadornom.Caption = "Prestador";
            this.colPrestadornom.FieldName = "PrestadorNombre";
            this.colPrestadornom.Name = "colPrestadornom";
            this.colPrestadornom.Visible = true;
            this.colPrestadornom.VisibleIndex = 2;
            this.colPrestadornom.Width = 71;
            // 
            // colPrestadoriva
            // 
            this.colPrestadoriva.Caption = "Cnd. Iva";
            this.colPrestadoriva.FieldName = "PrestadorIvaAbreviatura";
            this.colPrestadoriva.Name = "colPrestadoriva";
            this.colPrestadoriva.Visible = true;
            this.colPrestadoriva.VisibleIndex = 3;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewdet;
            gridLevelNode1.RelationName = "Detalles";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes,
            this.reposFecha,
            this.reposDecimales});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(918, 404);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridViewdet});
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
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.gridView.ChildGridLevelName = "gridViewdet";
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTipocomprobante,
            this.colPventa,
            this.colComprobanteletra,
            this.colCodigoprestadora,
            this.colRazonSocial,
            this.colCuit,
            this.colCondicioniva,
            this.colPrestadoraIvaPorc,
            this.colNeto,
            this.colIva,
            this.colTotal,
            this.colExesoIva});
            gridFormatRule1.Column = this.colExesoIva;
            gridFormatRule1.ColumnApplyTo = this.colExesoIva;
            gridFormatRule1.Name = "ExesoIva";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.IndianRed;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue1.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView.FormatRules.Add(gridFormatRule1);
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
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // colTipocomprobante
            // 
            this.colTipocomprobante.Caption = "Comprobante";
            this.colTipocomprobante.FieldName = "ComprobanteTipo";
            this.colTipocomprobante.Name = "colTipocomprobante";
            this.colTipocomprobante.Visible = true;
            this.colTipocomprobante.VisibleIndex = 0;
            this.colTipocomprobante.Width = 78;
            // 
            // colPventa
            // 
            this.colPventa.AppearanceCell.Options.UseTextOptions = true;
            this.colPventa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPventa.Caption = "Punto Venta";
            this.colPventa.FieldName = "ComprobantePuntoVenta";
            this.colPventa.Name = "colPventa";
            this.colPventa.Visible = true;
            this.colPventa.VisibleIndex = 1;
            this.colPventa.Width = 45;
            // 
            // colComprobanteletra
            // 
            this.colComprobanteletra.Caption = "Letra";
            this.colComprobanteletra.FieldName = "ComprobanteLetra";
            this.colComprobanteletra.Name = "colComprobanteletra";
            this.colComprobanteletra.Visible = true;
            this.colComprobanteletra.VisibleIndex = 2;
            this.colComprobanteletra.Width = 48;
            // 
            // colCodigoprestadora
            // 
            this.colCodigoprestadora.Caption = "Cuenta";
            this.colCodigoprestadora.FieldName = "PrestadoraCuentaCodigo";
            this.colCodigoprestadora.Name = "colCodigoprestadora";
            this.colCodigoprestadora.Visible = true;
            this.colCodigoprestadora.VisibleIndex = 3;
            this.colCodigoprestadora.Width = 54;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.Caption = "Razón Social";
            this.colRazonSocial.FieldName = "PrestadoraRazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 4;
            this.colRazonSocial.Width = 289;
            // 
            // colCuit
            // 
            this.colCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCuit.Caption = "Cuit";
            this.colCuit.FieldName = "PrestadoraCuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.VisibleIndex = 5;
            this.colCuit.Width = 61;
            // 
            // colCondicioniva
            // 
            this.colCondicioniva.Caption = "IVA";
            this.colCondicioniva.FieldName = "PrestadoraIvaAbreviatura";
            this.colCondicioniva.Name = "colCondicioniva";
            this.colCondicioniva.Visible = true;
            this.colCondicioniva.VisibleIndex = 6;
            this.colCondicioniva.Width = 38;
            // 
            // colPrestadoraIvaPorc
            // 
            this.colPrestadoraIvaPorc.AppearanceCell.Options.UseTextOptions = true;
            this.colPrestadoraIvaPorc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrestadoraIvaPorc.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrestadoraIvaPorc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrestadoraIvaPorc.Caption = "% Iva";
            this.colPrestadoraIvaPorc.FieldName = "PrestadoraCuentaIvaPorcentaje";
            this.colPrestadoraIvaPorc.Name = "colPrestadoraIvaPorc";
            this.colPrestadoraIvaPorc.Visible = true;
            this.colPrestadoraIvaPorc.VisibleIndex = 7;
            this.colPrestadoraIvaPorc.Width = 38;
            // 
            // colNeto
            // 
            this.colNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.Caption = "Neto";
            this.colNeto.ColumnEdit = this.reposImportes;
            this.colNeto.FieldName = "ImporteNeto";
            this.colNeto.Name = "colNeto";
            this.colNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteNeto", "{0:C2}")});
            this.colNeto.Visible = true;
            this.colNeto.VisibleIndex = 8;
            this.colNeto.Width = 86;
            // 
            // colIva
            // 
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "Iva";
            this.colIva.ColumnEdit = this.reposImportes;
            this.colIva.FieldName = "ImporteIva";
            this.colIva.Name = "colIva";
            this.colIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:C2}")});
            this.colIva.Visible = true;
            this.colIva.VisibleIndex = 9;
            this.colIva.Width = 70;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "Total";
            this.colTotal.ColumnEdit = this.reposImportes;
            this.colTotal.FieldName = "ImporteTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 10;
            this.colTotal.Width = 111;
            // 
            // colExesoIva
            // 
            this.colExesoIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colExesoIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colExesoIva.Caption = "Iva Exedido";
            this.colExesoIva.ColumnEdit = this.reposImportes;
            this.colExesoIva.FieldName = "ImporteIvaExedido";
            this.colExesoIva.Name = "colExesoIva";
            this.colExesoIva.Visible = true;
            this.colExesoIva.VisibleIndex = 11;
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(924, 52);
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
            this.NavPanel.Buttons.Add(this.btnExportar);
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
            this.NavPanel.Size = new System.Drawing.Size(924, 52);
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
            // btnExportar
            // 
            this.btnExportar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnExportar.Caption = "Exportar";
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnExportar_ElementClick);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 278F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(924, 410);
            this.tableLayoutPanel1.TabIndex = 3;
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
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // Frm_Pendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_Pendientes";
            this.Text = "Facturación Pendiente";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pblTop;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraBars.Navigation.NavButton btnPendientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker bgwPendientes;
        private DevExpress.XtraBars.Navigation.NavButton btnGenerafact;
        private System.ComponentModel.BackgroundWorker bgwFacturas;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewdet;
        private DevExpress.XtraGrid.Columns.GridColumn coldFecha;
        private DevExpress.XtraGrid.Columns.GridColumn coldCodigo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn coldPractica;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncion;
        private DevExpress.XtraGrid.Columns.GridColumn coldDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn coldNombrepaci;
        private DevExpress.XtraGrid.Columns.GridColumn coldCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn coldNeto;
        private DevExpress.XtraGrid.Columns.GridColumn coldIva;
        private DevExpress.XtraGrid.Columns.GridColumn coldTotal;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private DevExpress.XtraBars.Navigation.NavButton btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn colTipocomprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteletra;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoprestadora;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colCondicioniva;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadoraIvaPorc;
        private DevExpress.XtraGrid.Columns.GridColumn colNeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colPventa;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimales;
        private DevExpress.XtraGrid.Columns.GridColumn colHonorarios;
        private DevExpress.XtraGrid.Columns.GridColumn colGastos;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadorcuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadornom;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadoriva;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colExesoIva;
    }
}