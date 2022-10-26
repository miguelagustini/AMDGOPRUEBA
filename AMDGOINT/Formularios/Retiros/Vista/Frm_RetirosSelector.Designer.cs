namespace AMDGOINT.Formularios.Retiros.Vista
{
    partial class Frm_RetirosSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RetirosSelector));
            this.colCategorianro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFechas = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAsociado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTiporetiro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVencimientouno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVencimientodos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVencimientotres = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colFormapago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstadoDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCobroForma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.reposTogle = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTogle)).BeginInit();
            this.SuspendLayout();
            // 
            // colCategorianro
            // 
            this.colCategorianro.Caption = "Numerocat";
            this.colCategorianro.FieldName = "Categoria";
            this.colCategorianro.Name = "colCategorianro";
            this.colCategorianro.OptionsColumn.ShowInCustomizationForm = false;
            this.colCategorianro.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colcategoria
            // 
            this.colcategoria.Caption = "Categoría";
            this.colcategoria.FieldName = "CategoriaDescripcion";
            this.colcategoria.Name = "colcategoria";
            this.colcategoria.Visible = true;
            this.colcategoria.VisibleIndex = 10;
            this.colcategoria.Width = 93;
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.02831F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.9717F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1285, 337);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMemo,
            this.reposFechas,
            this.reposImportes,
            this.reposTogle,
            this.reposCheck});
            this.gridControl.Size = new System.Drawing.Size(1266, 269);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tw Cen MT", 11.25F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccion,
            this.colFecha,
            this.colAsociado,
            this.colTiporetiro,
            this.colConcepto,
            this.colEmpresa,
            this.colVencimientouno,
            this.colVencimientodos,
            this.colVencimientotres,
            this.colImporte,
            this.colObservacion,
            this.colcategoria,
            this.colCategorianro,
            this.colFormapago,
            this.colNroPedido,
            this.colEstadoDescripcion,
            this.colCobroForma,
            this.colPagado});
            gridFormatRule1.Column = this.colCategorianro;
            gridFormatRule1.ColumnApplyTo = this.colcategoria;
            gridFormatRule1.Name = "IconoCategoria";
            formatConditionRuleIconSet1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionIconSet1.CategoryName = "Formas";
            formatConditionIconSetIcon1.PredefinedName = "TrafficLights23_1.png";
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "TrafficLights23_2.png";
            formatConditionIconSetIcon2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "TrafficLights23_3.png";
            formatConditionIconSetIcon3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "TrafficLights3Unrimmed";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule1.Rule = formatConditionRuleIconSet1;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 2;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", this.colImporte, "{0:c2}")});
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindDelay = 500;
            this.gridView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.gridView.OptionsFind.ShowCloseButton = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEmpresa, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNroPedido, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_SelectionChanged);
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "...";
            this.colSeleccion.FieldName = "Seleccionado";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsColumn.ShowInCustomizationForm = false;
            this.colSeleccion.Width = 20;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.ColumnEdit = this.reposFechas;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 3;
            this.colFecha.Width = 91;
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
            // colAsociado
            // 
            this.colAsociado.Caption = "Asociado";
            this.colAsociado.FieldName = "AsociadoNombreOP";
            this.colAsociado.Name = "colAsociado";
            this.colAsociado.Visible = true;
            this.colAsociado.VisibleIndex = 4;
            this.colAsociado.Width = 108;
            // 
            // colTiporetiro
            // 
            this.colTiporetiro.Caption = "Tipo";
            this.colTiporetiro.FieldName = "RetiroTipo";
            this.colTiporetiro.Name = "colTiporetiro";
            this.colTiporetiro.Visible = true;
            this.colTiporetiro.VisibleIndex = 5;
            this.colTiporetiro.Width = 111;
            // 
            // colConcepto
            // 
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "ConceptoDescripcion";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 6;
            this.colConcepto.Width = 107;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "EmpresaCompleto";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 1;
            this.colEmpresa.Width = 126;
            // 
            // colVencimientouno
            // 
            this.colVencimientouno.Caption = "Vto. Uno";
            this.colVencimientouno.ColumnEdit = this.reposFechas;
            this.colVencimientouno.FieldName = "VencimientoUno";
            this.colVencimientouno.Name = "colVencimientouno";
            this.colVencimientouno.Visible = true;
            this.colVencimientouno.VisibleIndex = 7;
            this.colVencimientouno.Width = 91;
            // 
            // colVencimientodos
            // 
            this.colVencimientodos.Caption = "Vto. Dos";
            this.colVencimientodos.ColumnEdit = this.reposFechas;
            this.colVencimientodos.FieldName = "VencimientoDos";
            this.colVencimientodos.Name = "colVencimientodos";
            this.colVencimientodos.Visible = true;
            this.colVencimientodos.VisibleIndex = 8;
            this.colVencimientodos.Width = 91;
            // 
            // colVencimientotres
            // 
            this.colVencimientotres.Caption = "Vto. Tres";
            this.colVencimientotres.ColumnEdit = this.reposFechas;
            this.colVencimientotres.FieldName = "VencimientoTres";
            this.colVencimientotres.Name = "colVencimientotres";
            this.colVencimientotres.Visible = true;
            this.colVencimientotres.VisibleIndex = 9;
            this.colVencimientotres.Width = 97;
            // 
            // colImporte
            // 
            this.colImporte.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporte.Caption = "$ Importe";
            this.colImporte.ColumnEdit = this.reposImportes;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:C2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 11;
            this.colImporte.Width = 99;
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "c2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // colObservacion
            // 
            this.colObservacion.Caption = "Observación";
            this.colObservacion.ColumnEdit = this.reposMemo;
            this.colObservacion.FieldName = "Observacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Visible = true;
            this.colObservacion.VisibleIndex = 12;
            this.colObservacion.Width = 108;
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // colFormapago
            // 
            this.colFormapago.Caption = "Forma Pago";
            this.colFormapago.FieldName = "PagoForma";
            this.colFormapago.Name = "colFormapago";
            // 
            // colNroPedido
            // 
            this.colNroPedido.AppearanceCell.Options.UseTextOptions = true;
            this.colNroPedido.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNroPedido.Caption = "Nro. Pedido";
            this.colNroPedido.FieldName = "IDEncabezado";
            this.colNroPedido.Name = "colNroPedido";
            this.colNroPedido.Visible = true;
            this.colNroPedido.VisibleIndex = 2;
            this.colNroPedido.Width = 121;
            // 
            // colEstadoDescripcion
            // 
            this.colEstadoDescripcion.Caption = "Estado";
            this.colEstadoDescripcion.FieldName = "EstadoDescripcion";
            this.colEstadoDescripcion.Name = "colEstadoDescripcion";
            this.colEstadoDescripcion.Visible = true;
            this.colEstadoDescripcion.VisibleIndex = 13;
            this.colEstadoDescripcion.Width = 104;
            // 
            // colCobroForma
            // 
            this.colCobroForma.Caption = "Forma de cobro";
            this.colCobroForma.FieldName = "CobroFormaDescripcion";
            this.colCobroForma.Name = "colCobroForma";
            // 
            // colPagado
            // 
            this.colPagado.Caption = "Pagado";
            this.colPagado.ColumnEdit = this.reposCheck;
            this.colPagado.FieldName = "Pagado";
            this.colPagado.Name = "colPagado";
            // 
            // reposCheck
            // 
            this.reposCheck.AutoHeight = false;
            this.reposCheck.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.reposCheck.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("reposCheck.ImageOptions.ImageChecked")));
            this.reposCheck.Name = "reposCheck";
            // 
            // reposTogle
            // 
            this.reposTogle.AutoHeight = false;
            this.reposTogle.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.reposTogle.Name = "reposTogle";
            this.reposTogle.OffText = "No";
            this.reposTogle.OnText = "Si";
            this.reposTogle.ValueOff = ((byte)(0));
            this.reposTogle.ValueOn = ((byte)(1));
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(1157, 278);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 56);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Continuar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Frm_RetirosSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 337);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.IconOptions.ShowIcon = false;
            this.MinimizeBox = false;
            this.Name = "Frm_RetirosSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de retiros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_RetirosSelector_FormClosing);
            this.Load += new System.EventHandler(this.Frm_RetirosSelector_Load);
            this.Shown += new System.EventHandler(this.Frm_RetirosSelector_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTogle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposFechas;
        private DevExpress.XtraGrid.Columns.GridColumn colAsociado;
        private DevExpress.XtraGrid.Columns.GridColumn colTiporetiro;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colVencimientouno;
        private DevExpress.XtraGrid.Columns.GridColumn colVencimientodos;
        private DevExpress.XtraGrid.Columns.GridColumn colVencimientotres;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colcategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colCategorianro;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch reposTogle;
        private DevExpress.XtraGrid.Columns.GridColumn colFormapago;
        private DevExpress.XtraGrid.Columns.GridColumn colNroPedido;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCobroForma;
        private DevExpress.XtraGrid.Columns.GridColumn colPagado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
    }
}
