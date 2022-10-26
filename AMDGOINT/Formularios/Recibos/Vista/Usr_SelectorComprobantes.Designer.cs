namespace AMDGOINT.Formularios.Recibos.Vista
{
    partial class Usr_SelectorComprobantes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFechas = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colPeriodoFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobanteConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobanteOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimales = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colImportecancelado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentacodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposDecimales,
            this.reposFechas});
            this.gridControl.Size = new System.Drawing.Size(922, 365);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
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
            this.gridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
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
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccion,
            this.colFechaFactura,
            this.colPeriodoFactura,
            this.colComprobanteConcepto,
            this.colComprobanteOrigen,
            this.colImporteTotal,
            this.colImportecancelado,
            this.colComprobante,
            this.colCuentacodigo});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView_CustomSummaryCalculate);
            this.gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_SelectionChanged);
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "...";
            this.colSeleccion.FieldName = "Seleccionado";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsColumn.ShowInCustomizationForm = false;
            this.colSeleccion.OptionsColumn.ShowInExpressionEditor = false;
            this.colSeleccion.Width = 21;
            // 
            // colFechaFactura
            // 
            this.colFechaFactura.Caption = "Fecha Emisión";
            this.colFechaFactura.ColumnEdit = this.reposFechas;
            this.colFechaFactura.FieldName = "ComprobanteFechaEmision";
            this.colFechaFactura.Name = "colFechaFactura";
            this.colFechaFactura.OptionsColumn.AllowEdit = false;
            this.colFechaFactura.Visible = true;
            this.colFechaFactura.VisibleIndex = 2;
            this.colFechaFactura.Width = 97;
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
            // colPeriodoFactura
            // 
            this.colPeriodoFactura.Caption = "Período Asignado";
            this.colPeriodoFactura.FieldName = "ComprobantePeriodo";
            this.colPeriodoFactura.Name = "colPeriodoFactura";
            this.colPeriodoFactura.OptionsColumn.AllowEdit = false;
            this.colPeriodoFactura.Visible = true;
            this.colPeriodoFactura.VisibleIndex = 3;
            this.colPeriodoFactura.Width = 130;
            // 
            // colComprobanteConcepto
            // 
            this.colComprobanteConcepto.Caption = "Concepto";
            this.colComprobanteConcepto.FieldName = "ComprobanteConcepto";
            this.colComprobanteConcepto.Name = "colComprobanteConcepto";
            this.colComprobanteConcepto.OptionsColumn.AllowEdit = false;
            this.colComprobanteConcepto.Visible = true;
            this.colComprobanteConcepto.VisibleIndex = 5;
            this.colComprobanteConcepto.Width = 161;
            // 
            // colComprobanteOrigen
            // 
            this.colComprobanteOrigen.Caption = "Origen";
            this.colComprobanteOrigen.FieldName = "ComprobanteTipoDescripcion";
            this.colComprobanteOrigen.Name = "colComprobanteOrigen";
            this.colComprobanteOrigen.OptionsColumn.AllowEdit = false;
            this.colComprobanteOrigen.Visible = true;
            this.colComprobanteOrigen.VisibleIndex = 6;
            this.colComprobanteOrigen.Width = 161;
            // 
            // colImporteTotal
            // 
            this.colImporteTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporteTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporteTotal.Caption = "$ Total Comprobante";
            this.colImporteTotal.ColumnEdit = this.reposDecimales;
            this.colImporteTotal.FieldName = "ComprobanteAmdgoImporte";
            this.colImporteTotal.Name = "colImporteTotal";
            this.colImporteTotal.OptionsColumn.AllowEdit = false;
            this.colImporteTotal.Visible = true;
            this.colImporteTotal.VisibleIndex = 7;
            this.colImporteTotal.Width = 161;
            // 
            // reposDecimales
            // 
            this.reposDecimales.AutoHeight = false;
            this.reposDecimales.Mask.EditMask = "n2";
            this.reposDecimales.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimales.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimales.Name = "reposDecimales";
            // 
            // colImportecancelado
            // 
            this.colImportecancelado.AppearanceHeader.Options.UseTextOptions = true;
            this.colImportecancelado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImportecancelado.Caption = "$ Saldado";
            this.colImportecancelado.ColumnEdit = this.reposDecimales;
            this.colImportecancelado.FieldName = "ImporteSaldado";
            this.colImportecancelado.Name = "colImportecancelado";
            this.colImportecancelado.Visible = true;
            this.colImportecancelado.VisibleIndex = 8;
            this.colImportecancelado.Width = 207;
            // 
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "ComprobanteAmdgoNumero";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 4;
            this.colComprobante.Width = 174;
            // 
            // colCuentacodigo
            // 
            this.colCuentacodigo.Caption = "Cuenta";
            this.colCuentacodigo.FieldName = "PrestatariaCuentaCodigo";
            this.colCuentacodigo.Name = "colCuentacodigo";
            this.colCuentacodigo.Visible = true;
            this.colCuentacodigo.VisibleIndex = 1;
            // 
            // Usr_SelectorComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "Usr_SelectorComprobantes";
            this.Size = new System.Drawing.Size(922, 365);
            this.Load += new System.EventHandler(this.Usr_SelectorComprobantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodoFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimales;
        private DevExpress.XtraGrid.Columns.GridColumn colImportecancelado;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposFechas;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentacodigo;
    }
}
