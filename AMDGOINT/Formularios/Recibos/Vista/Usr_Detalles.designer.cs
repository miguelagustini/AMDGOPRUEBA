namespace AMDGOINT.Formularios.Recibos.Vista
{
    partial class Usr_Detalles
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaEmision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportecomprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestatariaCuentaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), typeof(System.Windows.Forms.UserControl));
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMoneda,
            this.reposDecimal,
            this.reposDate});
            this.gridControl.Size = new System.Drawing.Size(1008, 406);
            this.gridControl.TabIndex = 0;
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
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
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
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaEmision,
            this.colComprobante,
            this.colPeriodo,
            this.colConcepto,
            this.colTipo,
            this.colDescripcion,
            this.colImportecomprobante,
            this.colImporte,
            this.colCuenta,
            this.colSubCuenta,
            this.colPrestatariaCuentaCodigo,
            this.colModoPago,
            this.colBanco});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // colFechaEmision
            // 
            this.colFechaEmision.Caption = "Fecha Emisión";
            this.colFechaEmision.ColumnEdit = this.reposDate;
            this.colFechaEmision.FieldName = "ComprobanteFechaEmision";
            this.colFechaEmision.Name = "colFechaEmision";
            this.colFechaEmision.Visible = true;
            this.colFechaEmision.VisibleIndex = 0;
            this.colFechaEmision.Width = 94;
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
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "ComprobanteAmdgoNumero";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 2;
            this.colComprobante.Width = 121;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Periodo";
            this.colPeriodo.FieldName = "ComprobantePeriodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 3;
            this.colPeriodo.Width = 86;
            // 
            // colConcepto
            // 
            this.colConcepto.AppearanceHeader.Options.UseTextOptions = true;
            this.colConcepto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "ComprobanteConcepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 5;
            this.colConcepto.Width = 120;
            // 
            // colTipo
            // 
            this.colTipo.Caption = "Origen de prácticas";
            this.colTipo.FieldName = "ComprobanteTipoDescripcion";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 4;
            this.colTipo.Width = 136;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 6;
            this.colDescripcion.Width = 157;
            // 
            // colImportecomprobante
            // 
            this.colImportecomprobante.AppearanceCell.Options.UseTextOptions = true;
            this.colImportecomprobante.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImportecomprobante.AppearanceHeader.Options.UseTextOptions = true;
            this.colImportecomprobante.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImportecomprobante.Caption = "Importe Comprobante";
            this.colImportecomprobante.ColumnEdit = this.reposMoneda;
            this.colImportecomprobante.FieldName = "ComprobanteAmdgoImporte";
            this.colImportecomprobante.Name = "colImportecomprobante";
            this.colImportecomprobante.Visible = true;
            this.colImportecomprobante.VisibleIndex = 11;
            this.colImportecomprobante.Width = 119;
            // 
            // reposMoneda
            // 
            this.reposMoneda.AutoHeight = false;
            this.reposMoneda.Mask.EditMask = "c2";
            this.reposMoneda.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposMoneda.Mask.UseMaskAsDisplayFormat = true;
            this.reposMoneda.Name = "reposMoneda";
            // 
            // colImporte
            // 
            this.colImporte.AppearanceCell.Options.UseTextOptions = true;
            this.colImporte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporte.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporte.Caption = "Importe Cancelado";
            this.colImporte.ColumnEdit = this.reposMoneda;
            this.colImporte.FieldName = "ImporteCancelado";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 12;
            this.colImporte.Width = 149;
            // 
            // colCuenta
            // 
            this.colCuenta.Caption = "Cuenta";
            this.colCuenta.FieldName = "PlanCuentaCompleto";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.Visible = true;
            this.colCuenta.VisibleIndex = 9;
            this.colCuenta.Width = 125;
            // 
            // colSubCuenta
            // 
            this.colSubCuenta.Caption = "Sub Cuenta";
            this.colSubCuenta.FieldName = "PlanSubCuentaCompleto";
            this.colSubCuenta.Name = "colSubCuenta";
            this.colSubCuenta.Visible = true;
            this.colSubCuenta.VisibleIndex = 10;
            this.colSubCuenta.Width = 133;
            // 
            // colPrestatariaCuentaCodigo
            // 
            this.colPrestatariaCuentaCodigo.Caption = "Prestataria Plan";
            this.colPrestatariaCuentaCodigo.FieldName = "PrestatariaCuentaCodigo";
            this.colPrestatariaCuentaCodigo.Name = "colPrestatariaCuentaCodigo";
            this.colPrestatariaCuentaCodigo.Visible = true;
            this.colPrestatariaCuentaCodigo.VisibleIndex = 1;
            this.colPrestatariaCuentaCodigo.Width = 107;
            // 
            // colModoPago
            // 
            this.colModoPago.Caption = "Modo Pago";
            this.colModoPago.FieldName = "ModoPagoDescripcion";
            this.colModoPago.Name = "colModoPago";
            this.colModoPago.Visible = true;
            this.colModoPago.VisibleIndex = 7;
            // 
            // colBanco
            // 
            this.colBanco.Caption = "Banco";
            this.colBanco.FieldName = "BancoCompleto";
            this.colBanco.Name = "colBanco";
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 8;
            // 
            // reposDecimal
            // 
            this.reposDecimal.AutoHeight = false;
            this.reposDecimal.Mask.EditMask = "n2";
            this.reposDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimal.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimal.Name = "reposDecimal";
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // Usr_Detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "Usr_Detalles";
            this.Size = new System.Drawing.Size(1008, 406);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEmision;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colImportecomprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestatariaCuentaCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colModoPago;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
    }
}
