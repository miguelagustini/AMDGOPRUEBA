namespace AMDGOINT.Formularios.Profesionales.Vista
{
    partial class Frm_CuentaCorrienteInfo
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.gridViewCreditos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcFechaPAgo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colcPeriodoFacturado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcPeriodoQuincena = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcPrestatariaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcPrestatariaabrv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcPorcentaje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colcIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcintereses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewDebitos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldeFechaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldePeriodoFacturado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldeQuincena = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldePeriodorecu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldePrestatriaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldePrestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldeMotivoDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldeMotivoObse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.coldeMovimientot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldeImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovimientoNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewDescuentos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldRetiroc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldRetirodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteDebitos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetoParcial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescuentos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCreditos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDebitos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDescuentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewCreditos
            // 
            this.gridViewCreditos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridViewCreditos.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewCreditos.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewCreditos.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewCreditos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewCreditos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewCreditos.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewCreditos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewCreditos.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewCreditos.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewCreditos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewCreditos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewCreditos.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewCreditos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewCreditos.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewCreditos.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewCreditos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewCreditos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewCreditos.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCreditos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewCreditos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewCreditos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewCreditos.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewCreditos.Appearance.Row.Options.UseFont = true;
            this.gridViewCreditos.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewCreditos.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewCreditos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewCreditos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewCreditos.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewCreditos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewCreditos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewCreditos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcFechaPAgo,
            this.colcPeriodoFacturado,
            this.colcPeriodoQuincena,
            this.colcPrestatariaCodigo,
            this.colcPrestatariaabrv,
            this.colcMovimiento,
            this.colcPorcentaje,
            this.colcNeto,
            this.colcIva,
            this.colcintereses,
            this.colcTotal});
            this.gridViewCreditos.GridControl = this.gridControl;
            this.gridViewCreditos.Name = "gridViewCreditos";
            this.gridViewCreditos.OptionsBehavior.Editable = false;
            this.gridViewCreditos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewCreditos.OptionsView.ShowGroupPanel = false;
            this.gridViewCreditos.OptionsView.ShowIndicator = false;
            // 
            // colcFechaPAgo
            // 
            this.colcFechaPAgo.Caption = "Fecha Pago";
            this.colcFechaPAgo.ColumnEdit = this.reposDate;
            this.colcFechaPAgo.FieldName = "FechaPago";
            this.colcFechaPAgo.Name = "colcFechaPAgo";
            this.colcFechaPAgo.Visible = true;
            this.colcFechaPAgo.VisibleIndex = 0;
            this.colcFechaPAgo.Width = 101;
            // 
            // reposDate
            // 
            this.reposDate.AutoHeight = false;
            this.reposDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.Mask.EditMask = "yyyy-MM-dd";
            this.reposDate.Mask.UseMaskAsDisplayFormat = true;
            this.reposDate.Name = "reposDate";
            // 
            // colcPeriodoFacturado
            // 
            this.colcPeriodoFacturado.Caption = "Período Facturado";
            this.colcPeriodoFacturado.FieldName = "PeriodoFacturacion";
            this.colcPeriodoFacturado.Name = "colcPeriodoFacturado";
            this.colcPeriodoFacturado.Visible = true;
            this.colcPeriodoFacturado.VisibleIndex = 1;
            this.colcPeriodoFacturado.Width = 101;
            // 
            // colcPeriodoQuincena
            // 
            this.colcPeriodoQuincena.Caption = "Quincena";
            this.colcPeriodoQuincena.FieldName = "PeriodoPagoQuincena";
            this.colcPeriodoQuincena.Name = "colcPeriodoQuincena";
            this.colcPeriodoQuincena.Visible = true;
            this.colcPeriodoQuincena.VisibleIndex = 2;
            this.colcPeriodoQuincena.Width = 101;
            // 
            // colcPrestatariaCodigo
            // 
            this.colcPrestatariaCodigo.Caption = "Prestataria Cod.";
            this.colcPrestatariaCodigo.FieldName = "PrestatariaCuentaCodigo";
            this.colcPrestatariaCodigo.Name = "colcPrestatariaCodigo";
            this.colcPrestatariaCodigo.Visible = true;
            this.colcPrestatariaCodigo.VisibleIndex = 3;
            this.colcPrestatariaCodigo.Width = 90;
            // 
            // colcPrestatariaabrv
            // 
            this.colcPrestatariaabrv.Caption = "Prestataria";
            this.colcPrestatariaabrv.FieldName = "PrestatariaCuentaAbreviatura";
            this.colcPrestatariaabrv.Name = "colcPrestatariaabrv";
            this.colcPrestatariaabrv.Visible = true;
            this.colcPrestatariaabrv.VisibleIndex = 4;
            this.colcPrestatariaabrv.Width = 102;
            // 
            // colcMovimiento
            // 
            this.colcMovimiento.Caption = "Movimiento";
            this.colcMovimiento.FieldName = "MovimientoDescripcion";
            this.colcMovimiento.Name = "colcMovimiento";
            this.colcMovimiento.Visible = true;
            this.colcMovimiento.VisibleIndex = 5;
            this.colcMovimiento.Width = 102;
            // 
            // colcPorcentaje
            // 
            this.colcPorcentaje.AppearanceHeader.Options.UseTextOptions = true;
            this.colcPorcentaje.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colcPorcentaje.Caption = "% Pago";
            this.colcPorcentaje.FieldName = "PagoPorcentaje";
            this.colcPorcentaje.Name = "colcPorcentaje";
            this.colcPorcentaje.Visible = true;
            this.colcPorcentaje.VisibleIndex = 7;
            this.colcPorcentaje.Width = 102;
            // 
            // colcNeto
            // 
            this.colcNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colcNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colcNeto.Caption = "$ Neto";
            this.colcNeto.ColumnEdit = this.reposImportes;
            this.colcNeto.FieldName = "PagoImporteNeto";
            this.colcNeto.Name = "colcNeto";
            this.colcNeto.Visible = true;
            this.colcNeto.VisibleIndex = 8;
            this.colcNeto.Width = 102;
            // 
            // reposImportes
            // 
            this.reposImportes.Mask.EditMask = "c2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // colcIva
            // 
            this.colcIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colcIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colcIva.Caption = "$ Iva";
            this.colcIva.ColumnEdit = this.reposImportes;
            this.colcIva.FieldName = "PagoImporteIva";
            this.colcIva.Name = "colcIva";
            this.colcIva.Visible = true;
            this.colcIva.VisibleIndex = 9;
            this.colcIva.Width = 102;
            // 
            // colcintereses
            // 
            this.colcintereses.AppearanceHeader.Options.UseTextOptions = true;
            this.colcintereses.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colcintereses.Caption = "$ Intereses";
            this.colcintereses.ColumnEdit = this.reposImportes;
            this.colcintereses.FieldName = "PagoImporteIntereses";
            this.colcintereses.Name = "colcintereses";
            this.colcintereses.Visible = true;
            this.colcintereses.VisibleIndex = 6;
            this.colcintereses.Width = 102;
            // 
            // colcTotal
            // 
            this.colcTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colcTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colcTotal.Caption = "$ Total";
            this.colcTotal.ColumnEdit = this.reposImportes;
            this.colcTotal.FieldName = "PagoImporteTotal";
            this.colcTotal.Name = "colcTotal";
            this.colcTotal.Visible = true;
            this.colcTotal.VisibleIndex = 10;
            this.colcTotal.Width = 108;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewCreditos;
            gridLevelNode1.RelationName = "CreditosPrestatarias";
            gridLevelNode2.LevelTemplate = this.gridViewDebitos;
            gridLevelNode2.RelationName = "DebitosPrestatarias";
            gridLevelNode3.LevelTemplate = this.gridViewDescuentos;
            gridLevelNode3.RelationName = "DescuentosAmMgm";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes,
            this.reposDate,
            this.reposMemo});
            this.gridControl.Size = new System.Drawing.Size(1094, 485);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDebitos,
            this.gridViewDescuentos,
            this.gridView,
            this.gridViewCreditos});
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // gridViewDebitos
            // 
            this.gridViewDebitos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridViewDebitos.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewDebitos.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDebitos.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDebitos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDebitos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewDebitos.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewDebitos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewDebitos.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDebitos.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDebitos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDebitos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewDebitos.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewDebitos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewDebitos.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewDebitos.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewDebitos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewDebitos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDebitos.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDebitos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewDebitos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDebitos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewDebitos.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDebitos.Appearance.Row.Options.UseFont = true;
            this.gridViewDebitos.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDebitos.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDebitos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDebitos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewDebitos.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewDebitos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewDebitos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldeFechaPago,
            this.coldePeriodoFacturado,
            this.coldeQuincena,
            this.coldePeriodorecu,
            this.coldePrestatriaCodigo,
            this.coldePrestataria,
            this.coldeMotivoDebito,
            this.coldeMotivoObse,
            this.coldeMovimientot,
            this.coldeImporte,
            this.colMovimientoNro});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colMovimientoNro;
            gridFormatRule1.Name = "Recuperos";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = ((byte)(2));
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridViewDebitos.FormatRules.Add(gridFormatRule1);
            this.gridViewDebitos.GridControl = this.gridControl;
            this.gridViewDebitos.Name = "gridViewDebitos";
            this.gridViewDebitos.OptionsBehavior.Editable = false;
            this.gridViewDebitos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDebitos.OptionsView.RowAutoHeight = true;
            this.gridViewDebitos.OptionsView.ShowGroupPanel = false;
            this.gridViewDebitos.OptionsView.ShowIndicator = false;
            // 
            // coldeFechaPago
            // 
            this.coldeFechaPago.Caption = "Fecha";
            this.coldeFechaPago.ColumnEdit = this.reposDate;
            this.coldeFechaPago.FieldName = "FechaPago";
            this.coldeFechaPago.Name = "coldeFechaPago";
            this.coldeFechaPago.Visible = true;
            this.coldeFechaPago.VisibleIndex = 0;
            this.coldeFechaPago.Width = 95;
            // 
            // coldePeriodoFacturado
            // 
            this.coldePeriodoFacturado.Caption = "Facturado";
            this.coldePeriodoFacturado.FieldName = "PeriodoFacturacion";
            this.coldePeriodoFacturado.Name = "coldePeriodoFacturado";
            this.coldePeriodoFacturado.Visible = true;
            this.coldePeriodoFacturado.VisibleIndex = 1;
            this.coldePeriodoFacturado.Width = 143;
            // 
            // coldeQuincena
            // 
            this.coldeQuincena.Caption = "Pago Quincena";
            this.coldeQuincena.FieldName = "PeriodoPagoQuincena";
            this.coldeQuincena.Name = "coldeQuincena";
            this.coldeQuincena.Visible = true;
            this.coldeQuincena.VisibleIndex = 2;
            this.coldeQuincena.Width = 103;
            // 
            // coldePeriodorecu
            // 
            this.coldePeriodorecu.Caption = "Recuperado";
            this.coldePeriodorecu.FieldName = "PeriodoRecupero";
            this.coldePeriodorecu.Name = "coldePeriodorecu";
            this.coldePeriodorecu.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // coldePrestatriaCodigo
            // 
            this.coldePrestatriaCodigo.Caption = "Prestataria Código";
            this.coldePrestatriaCodigo.FieldName = "PrestatariaCuentaCodigo";
            this.coldePrestatriaCodigo.Name = "coldePrestatriaCodigo";
            this.coldePrestatriaCodigo.Visible = true;
            this.coldePrestatriaCodigo.VisibleIndex = 3;
            this.coldePrestatriaCodigo.Width = 151;
            // 
            // coldePrestataria
            // 
            this.coldePrestataria.Caption = "Prestataria";
            this.coldePrestataria.FieldName = "PrestatariaCuentaAbreviatura";
            this.coldePrestataria.Name = "coldePrestataria";
            this.coldePrestataria.Visible = true;
            this.coldePrestataria.VisibleIndex = 4;
            this.coldePrestataria.Width = 151;
            // 
            // coldeMotivoDebito
            // 
            this.coldeMotivoDebito.Caption = "Motivo Débito";
            this.coldeMotivoDebito.FieldName = "MotivoDebitoDescripcion";
            this.coldeMotivoDebito.Name = "coldeMotivoDebito";
            this.coldeMotivoDebito.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // coldeMotivoObse
            // 
            this.coldeMotivoObse.Caption = "Observación";
            this.coldeMotivoObse.ColumnEdit = this.reposMemo;
            this.coldeMotivoObse.FieldName = "MotivoDebitoObservacion";
            this.coldeMotivoObse.Name = "coldeMotivoObse";
            this.coldeMotivoObse.Visible = true;
            this.coldeMotivoObse.VisibleIndex = 5;
            this.coldeMotivoObse.Width = 202;
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // coldeMovimientot
            // 
            this.coldeMovimientot.Caption = "Movimiento";
            this.coldeMovimientot.FieldName = "MovimientoDescripcion";
            this.coldeMovimientot.Name = "coldeMovimientot";
            this.coldeMovimientot.Visible = true;
            this.coldeMovimientot.VisibleIndex = 6;
            this.coldeMovimientot.Width = 111;
            // 
            // coldeImporte
            // 
            this.coldeImporte.AppearanceHeader.Options.UseTextOptions = true;
            this.coldeImporte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldeImporte.Caption = "$ Total";
            this.coldeImporte.ColumnEdit = this.reposImportes;
            this.coldeImporte.FieldName = "ImporteTotal";
            this.coldeImporte.Name = "coldeImporte";
            this.coldeImporte.Visible = true;
            this.coldeImporte.VisibleIndex = 7;
            this.coldeImporte.Width = 155;
            // 
            // colMovimientoNro
            // 
            this.colMovimientoNro.Caption = "MovimientoNro";
            this.colMovimientoNro.FieldName = "MovimientoTipo";
            this.colMovimientoNro.Name = "colMovimientoNro";
            this.colMovimientoNro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridViewDescuentos
            // 
            this.gridViewDescuentos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridViewDescuentos.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewDescuentos.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDescuentos.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDescuentos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDescuentos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewDescuentos.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewDescuentos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewDescuentos.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDescuentos.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDescuentos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDescuentos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewDescuentos.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewDescuentos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewDescuentos.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewDescuentos.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewDescuentos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewDescuentos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDescuentos.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDescuentos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewDescuentos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDescuentos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewDescuentos.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDescuentos.Appearance.Row.Options.UseFont = true;
            this.gridViewDescuentos.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDescuentos.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewDescuentos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDescuentos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewDescuentos.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewDescuentos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewDescuentos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldFecha,
            this.coldRetiroc,
            this.coldRetirodes,
            this.coldMovimiento,
            this.coldObservacion,
            this.coldTotal});
            this.gridViewDescuentos.GridControl = this.gridControl;
            this.gridViewDescuentos.Name = "gridViewDescuentos";
            this.gridViewDescuentos.OptionsBehavior.Editable = false;
            this.gridViewDescuentos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDescuentos.OptionsView.ShowGroupPanel = false;
            this.gridViewDescuentos.OptionsView.ShowIndicator = false;
            // 
            // coldFecha
            // 
            this.coldFecha.Caption = "Fecha";
            this.coldFecha.ColumnEdit = this.reposDate;
            this.coldFecha.FieldName = "Fecha";
            this.coldFecha.Name = "coldFecha";
            this.coldFecha.Visible = true;
            this.coldFecha.VisibleIndex = 0;
            // 
            // coldRetiroc
            // 
            this.coldRetiroc.Caption = "Concepto Código";
            this.coldRetiroc.FieldName = "RetiroCodigo";
            this.coldRetiroc.Name = "coldRetiroc";
            this.coldRetiroc.Visible = true;
            this.coldRetiroc.VisibleIndex = 1;
            // 
            // coldRetirodes
            // 
            this.coldRetirodes.Caption = "Concepto";
            this.coldRetirodes.FieldName = "RetiroDescripcion";
            this.coldRetirodes.Name = "coldRetirodes";
            this.coldRetirodes.Visible = true;
            this.coldRetirodes.VisibleIndex = 2;
            // 
            // coldMovimiento
            // 
            this.coldMovimiento.Caption = "Movimiento";
            this.coldMovimiento.FieldName = "MovimientoTipoDescripcion";
            this.coldMovimiento.Name = "coldMovimiento";
            this.coldMovimiento.Visible = true;
            this.coldMovimiento.VisibleIndex = 3;
            // 
            // coldObservacion
            // 
            this.coldObservacion.Caption = "Observación";
            this.coldObservacion.FieldName = "Observacion";
            this.coldObservacion.Name = "coldObservacion";
            this.coldObservacion.Visible = true;
            this.coldObservacion.VisibleIndex = 4;
            // 
            // coldTotal
            // 
            this.coldTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.coldTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldTotal.Caption = "$ Total";
            this.coldTotal.ColumnEdit = this.reposImportes;
            this.coldTotal.FieldName = "ImporteTotal";
            this.coldTotal.Name = "coldTotal";
            this.coldTotal.Visible = true;
            this.coldTotal.VisibleIndex = 5;
            // 
            // gridView
            // 
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
            this.colPeriodo,
            this.colCreditos,
            this.colImporteDebitos,
            this.colNetoParcial,
            this.colDescuentos,
            this.colTotal});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colTotal;
            gridFormatRule2.Name = "ImporteNegativo";
            formatConditionRuleValue2.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue2.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue2.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Periodo de Pago";
            this.colPeriodo.FieldName = "PagoPeriodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 0;
            // 
            // colCreditos
            // 
            this.colCreditos.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreditos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCreditos.Caption = "$ Créditos";
            this.colCreditos.ColumnEdit = this.reposImportes;
            this.colCreditos.FieldName = "ImporteCreditos";
            this.colCreditos.Name = "colCreditos";
            this.colCreditos.Visible = true;
            this.colCreditos.VisibleIndex = 1;
            // 
            // colImporteDebitos
            // 
            this.colImporteDebitos.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporteDebitos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporteDebitos.Caption = "$ Débitos";
            this.colImporteDebitos.ColumnEdit = this.reposImportes;
            this.colImporteDebitos.FieldName = "ImporteDebitos";
            this.colImporteDebitos.Name = "colImporteDebitos";
            this.colImporteDebitos.Visible = true;
            this.colImporteDebitos.VisibleIndex = 2;
            // 
            // colNetoParcial
            // 
            this.colNetoParcial.AppearanceHeader.Options.UseTextOptions = true;
            this.colNetoParcial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNetoParcial.Caption = "$ Neto Parcial";
            this.colNetoParcial.ColumnEdit = this.reposImportes;
            this.colNetoParcial.FieldName = "ImporteNetoParcial";
            this.colNetoParcial.Name = "colNetoParcial";
            this.colNetoParcial.Visible = true;
            this.colNetoParcial.VisibleIndex = 3;
            // 
            // colDescuentos
            // 
            this.colDescuentos.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescuentos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDescuentos.Caption = "$ Descuentos";
            this.colDescuentos.ColumnEdit = this.reposImportes;
            this.colDescuentos.FieldName = "ImporteDescuentos";
            this.colDescuentos.Name = "colDescuentos";
            this.colDescuentos.Visible = true;
            this.colDescuentos.VisibleIndex = 4;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "$ Total";
            this.colTotal.ColumnEdit = this.reposImportes;
            this.colTotal.FieldName = "ImporteTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 5;
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // Frm_CuentaCorrienteInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 485);
            this.Controls.Add(this.gridControl);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_CuentaCorrienteInfo";
            this.Text = "Cuentas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DirecCont_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Contactos_Load);
            this.Shown += new System.EventHandler(this.Frm_CuentaCorrienteInfo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCreditos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDebitos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDescuentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCreditos;
        private DevExpress.XtraGrid.Columns.GridColumn colcPeriodoFacturado;
        private DevExpress.XtraGrid.Columns.GridColumn colcPeriodoQuincena;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDebitos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDescuentos;
        private DevExpress.XtraGrid.Columns.GridColumn colcFechaPAgo;
        private DevExpress.XtraGrid.Columns.GridColumn colcPrestatariaCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colcMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colcPorcentaje;
        private DevExpress.XtraGrid.Columns.GridColumn colcNeto;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraGrid.Columns.GridColumn colcIva;
        private DevExpress.XtraGrid.Columns.GridColumn colcintereses;
        private DevExpress.XtraGrid.Columns.GridColumn colcTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Columns.GridColumn colcPrestatariaabrv;
        private DevExpress.XtraGrid.Columns.GridColumn coldFecha;
        private DevExpress.XtraGrid.Columns.GridColumn coldRetiroc;
        private DevExpress.XtraGrid.Columns.GridColumn coldRetirodes;
        private DevExpress.XtraGrid.Columns.GridColumn coldMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn coldObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn coldTotal;
        private DevExpress.XtraGrid.Columns.GridColumn coldeFechaPago;
        private DevExpress.XtraGrid.Columns.GridColumn coldePeriodoFacturado;
        private DevExpress.XtraGrid.Columns.GridColumn coldeQuincena;
        private DevExpress.XtraGrid.Columns.GridColumn coldePeriodorecu;
        private DevExpress.XtraGrid.Columns.GridColumn coldePrestatriaCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn coldePrestataria;
        private DevExpress.XtraGrid.Columns.GridColumn coldeMotivoDebito;
        private DevExpress.XtraGrid.Columns.GridColumn coldeMotivoObse;
        private DevExpress.XtraGrid.Columns.GridColumn coldeMovimientot;
        private DevExpress.XtraGrid.Columns.GridColumn coldeImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimientoNro;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditos;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteDebitos;
        private DevExpress.XtraGrid.Columns.GridColumn colNetoParcial;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuentos;
    }
}