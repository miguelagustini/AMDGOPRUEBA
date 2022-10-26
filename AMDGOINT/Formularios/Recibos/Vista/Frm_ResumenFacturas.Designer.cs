namespace AMDGOINT.Formularios.Recibos.Vista
{
    partial class Frm_ResumenFacturas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ResumenFacturas));
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tglModoExportacion = new DevExpress.XtraBars.BarEditItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.ViewResumenFacturas = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.colPrestatariaCuentaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaRecibo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReciboNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuitPrestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestatariarazon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tglModo = new DevExpress.XtraEditors.ToggleSwitch();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewResumenFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglModo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Agrupado";
            this.repositoryItemToggleSwitch1.OnText = "En Línea";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemToggleSwitch1});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1289, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 400);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1289, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 400);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1289, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 400);
            // 
            // tglModoExportacion
            // 
            this.tglModoExportacion.Edit = null;
            this.tglModoExportacion.Id = 8;
            this.tglModoExportacion.Name = "tglModoExportacion";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.464702F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.5353F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tglModo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExportar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1289, 400);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 39);
            this.gridControl.MainView = this.ViewResumenFacturas;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMoneda,
            this.reposDecimal,
            this.reposDate});
            this.gridControl.Size = new System.Drawing.Size(1283, 358);
            this.gridControl.TabIndex = 15;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewResumenFacturas});
            // 
            // ViewResumenFacturas
            // 
            this.ViewResumenFacturas.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.ViewResumenFacturas.Appearance.EvenRow.Options.UseBackColor = true;
            this.ViewResumenFacturas.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ViewResumenFacturas.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.ViewResumenFacturas.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ViewResumenFacturas.Appearance.FocusedCell.Options.UseBackColor = true;
            this.ViewResumenFacturas.Appearance.FocusedCell.Options.UseFont = true;
            this.ViewResumenFacturas.Appearance.FocusedCell.Options.UseForeColor = true;
            this.ViewResumenFacturas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ViewResumenFacturas.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.ViewResumenFacturas.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ViewResumenFacturas.Appearance.FocusedRow.Options.UseBackColor = true;
            this.ViewResumenFacturas.Appearance.FocusedRow.Options.UseFont = true;
            this.ViewResumenFacturas.Appearance.FocusedRow.Options.UseForeColor = true;
            this.ViewResumenFacturas.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.ViewResumenFacturas.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ViewResumenFacturas.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.ViewResumenFacturas.Appearance.GroupRow.Options.UseForeColor = true;
            this.ViewResumenFacturas.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.ViewResumenFacturas.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.ViewResumenFacturas.Appearance.HeaderPanel.Options.UseFont = true;
            this.ViewResumenFacturas.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.ViewResumenFacturas.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ViewResumenFacturas.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.ViewResumenFacturas.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.ViewResumenFacturas.Appearance.Row.Options.UseFont = true;
            this.ViewResumenFacturas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ViewResumenFacturas.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.ViewResumenFacturas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ViewResumenFacturas.Appearance.SelectedRow.Options.UseBackColor = true;
            this.ViewResumenFacturas.Appearance.SelectedRow.Options.UseFont = true;
            this.ViewResumenFacturas.Appearance.SelectedRow.Options.UseForeColor = true;
            this.ViewResumenFacturas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ViewResumenFacturas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaEmision,
            this.colComprobante,
            this.colPeriodo,
            this.colConcepto,
            this.colTipo,
            this.colDescripcion,
            this.colImportecomprobante,
            this.colImporte,
            this.colPrestatariaCuentaCodigo,
            this.colFechaRecibo,
            this.colReciboNumero,
            this.colCuitPrestataria,
            this.colPrestatariarazon});
            this.ViewResumenFacturas.GridControl = this.gridControl;
            this.ViewResumenFacturas.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteCancelado", this.colImporte, "{0:C2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ComprobanteAmdgoImporte", this.colImportecomprobante, "{0:C2}")});
            this.ViewResumenFacturas.Name = "ViewResumenFacturas";
            this.ViewResumenFacturas.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.ViewResumenFacturas.OptionsBehavior.Editable = false;
            this.ViewResumenFacturas.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.ViewResumenFacturas.OptionsView.RowAutoHeight = true;
            this.ViewResumenFacturas.OptionsView.ShowFooter = true;
            this.ViewResumenFacturas.OptionsView.ShowIndicator = false;
            // 
            // colFechaEmision
            // 
            this.colFechaEmision.Caption = "Factura Emitida";
            this.colFechaEmision.ColumnEdit = this.reposDate;
            this.colFechaEmision.FieldName = "ComprobanteFechaEmision";
            this.colFechaEmision.Name = "colFechaEmision";
            this.colFechaEmision.Visible = true;
            this.colFechaEmision.VisibleIndex = 5;
            this.colFechaEmision.Width = 83;
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
            this.colComprobante.Caption = "Factura Nro.";
            this.colComprobante.FieldName = "ComprobanteAmdgoNumero";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 6;
            this.colComprobante.Width = 106;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Periodo";
            this.colPeriodo.FieldName = "ComprobantePeriodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 7;
            this.colPeriodo.Width = 76;
            // 
            // colConcepto
            // 
            this.colConcepto.AppearanceHeader.Options.UseTextOptions = true;
            this.colConcepto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "ComprobanteConcepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 9;
            this.colConcepto.Width = 105;
            // 
            // colTipo
            // 
            this.colTipo.Caption = "Origen de prácticas";
            this.colTipo.FieldName = "ComprobanteTipoDescripcion";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 8;
            this.colTipo.Width = 120;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 10;
            this.colDescripcion.Width = 140;
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
            this.colImportecomprobante.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ComprobanteAmdgoImporte", "{0:C2}")});
            this.colImportecomprobante.Visible = true;
            this.colImportecomprobante.VisibleIndex = 11;
            this.colImportecomprobante.Width = 145;
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
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteCancelado", "{0:C2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 12;
            this.colImporte.Width = 120;
            // 
            // colPrestatariaCuentaCodigo
            // 
            this.colPrestatariaCuentaCodigo.Caption = "Prestataria Plan";
            this.colPrestatariaCuentaCodigo.FieldName = "PrestatariaCuentaCodigo";
            this.colPrestatariaCuentaCodigo.Name = "colPrestatariaCuentaCodigo";
            this.colPrestatariaCuentaCodigo.Visible = true;
            this.colPrestatariaCuentaCodigo.VisibleIndex = 4;
            this.colPrestatariaCuentaCodigo.Width = 95;
            // 
            // colFechaRecibo
            // 
            this.colFechaRecibo.Caption = "Recibo Emitido";
            this.colFechaRecibo.ColumnEdit = this.reposDate;
            this.colFechaRecibo.FieldName = "FechaEmision";
            this.colFechaRecibo.Name = "colFechaRecibo";
            this.colFechaRecibo.Visible = true;
            this.colFechaRecibo.VisibleIndex = 0;
            this.colFechaRecibo.Width = 110;
            // 
            // colReciboNumero
            // 
            this.colReciboNumero.Caption = "Recibo Nro.";
            this.colReciboNumero.FieldName = "Comprobante";
            this.colReciboNumero.Name = "colReciboNumero";
            this.colReciboNumero.Visible = true;
            this.colReciboNumero.VisibleIndex = 1;
            this.colReciboNumero.Width = 84;
            // 
            // colCuitPrestataria
            // 
            this.colCuitPrestataria.Caption = "Cuit";
            this.colCuitPrestataria.FieldName = "ReceptorCuit";
            this.colCuitPrestataria.Name = "colCuitPrestataria";
            this.colCuitPrestataria.Visible = true;
            this.colCuitPrestataria.VisibleIndex = 2;
            this.colCuitPrestataria.Width = 68;
            // 
            // colPrestatariarazon
            // 
            this.colPrestatariarazon.Caption = "Razón Social";
            this.colPrestatariarazon.FieldName = "ReceptorRazonSocial";
            this.colPrestatariarazon.Name = "colPrestatariarazon";
            this.colPrestatariarazon.Visible = true;
            this.colPrestatariarazon.VisibleIndex = 3;
            this.colPrestatariarazon.Width = 95;
            // 
            // reposDecimal
            // 
            this.reposDecimal.AutoHeight = false;
            this.reposDecimal.Mask.EditMask = "n2";
            this.reposDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimal.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimal.Name = "reposDecimal";
            // 
            // tglModo
            // 
            this.tglModo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tglModo.Location = new System.Drawing.Point(3, 9);
            this.tglModo.MenuManager = this.barManager1;
            this.tglModo.Name = "tglModo";
            this.tglModo.Properties.OffText = "Agrupado";
            this.tglModo.Properties.OnText = "Listado";
            this.tglModo.Size = new System.Drawing.Size(116, 18);
            this.tglModo.TabIndex = 13;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.Location = new System.Drawing.Point(125, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(113, 30);
            this.btnExportar.TabIndex = 14;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // Frm_ResumenFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_ResumenFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Exportacion_FormClosing);
            this.Load += new System.EventHandler(this.Usr_Detalles_Load);
            this.Shown += new System.EventHandler(this.Frm_ResumenFacturas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewResumenFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglModo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraBars.BarEditItem tglModoExportacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ToggleSwitch tglModo;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewResumenFacturas;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEmision;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colImportecomprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestatariaCuentaCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimal;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaRecibo;
        private DevExpress.XtraGrid.Columns.GridColumn colReciboNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colCuitPrestataria;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestatariarazon;
    }
}
