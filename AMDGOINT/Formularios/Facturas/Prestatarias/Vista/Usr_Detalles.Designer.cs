namespace AMDGOINT.Formularios.Facturas.Prestataria.Vista
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usr_Detalles));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescripcionManual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechapractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCodpractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombrepaci = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroBusqueda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadorCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bgwDetalles = new System.ComponentModel.BackgroundWorker();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), typeof(System.Windows.Forms.UserControl));
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
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
            this.colPeriodo,
            this.coldescripcionManual,
            this.colComprobante,
            this.colFechapractica,
            this.colCodpractica,
            this.colPractica,
            this.colFuncion,
            this.colDocumento,
            this.colNombrepaci,
            this.colCantidad,
            this.colNeto,
            this.colIva,
            this.colTotal,
            this.colNroBusqueda,
            this.colPrestadorCodigo,
            this.colPrestador});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Período";
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 0;
            // 
            // coldescripcionManual
            // 
            this.coldescripcionManual.Caption = "Descripción";
            this.coldescripcionManual.FieldName = "DescripcionManual";
            this.coldescripcionManual.Name = "coldescripcionManual";
            this.coldescripcionManual.Visible = true;
            this.coldescripcionManual.VisibleIndex = 4;
            this.coldescripcionManual.Width = 175;
            // 
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "Descripcion";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 1;
            this.colComprobante.Width = 117;
            // 
            // colFechapractica
            // 
            this.colFechapractica.Caption = "Fecha práctica";
            this.colFechapractica.ColumnEdit = this.reposDate;
            this.colFechapractica.FieldName = "PracticaFecha";
            this.colFechapractica.Name = "colFechapractica";
            this.colFechapractica.Visible = true;
            this.colFechapractica.VisibleIndex = 6;
            this.colFechapractica.Width = 120;
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
            // colCodpractica
            // 
            this.colCodpractica.Caption = "Código";
            this.colCodpractica.FieldName = "PracticaCodigo";
            this.colCodpractica.Name = "colCodpractica";
            this.colCodpractica.Visible = true;
            this.colCodpractica.VisibleIndex = 7;
            this.colCodpractica.Width = 71;
            // 
            // colPractica
            // 
            this.colPractica.Caption = "Práctica";
            this.colPractica.FieldName = "PracticaDescripcion";
            this.colPractica.Name = "colPractica";
            this.colPractica.Visible = true;
            this.colPractica.VisibleIndex = 8;
            this.colPractica.Width = 121;
            // 
            // colFuncion
            // 
            this.colFuncion.Caption = "Funcion";
            this.colFuncion.FieldName = "Funcion";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.Visible = true;
            this.colFuncion.VisibleIndex = 9;
            this.colFuncion.Width = 80;
            // 
            // colDocumento
            // 
            this.colDocumento.Caption = "Documento Nro.";
            this.colDocumento.FieldName = "PacienteDocuemento";
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.Visible = true;
            this.colDocumento.VisibleIndex = 10;
            this.colDocumento.Width = 101;
            // 
            // colNombrepaci
            // 
            this.colNombrepaci.Caption = "Paciente";
            this.colNombrepaci.FieldName = "PacienteNombre";
            this.colNombrepaci.Name = "colNombrepaci";
            this.colNombrepaci.Visible = true;
            this.colNombrepaci.VisibleIndex = 11;
            this.colNombrepaci.Width = 141;
            // 
            // colCantidad
            // 
            this.colCantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.ColumnEdit = this.reposDecimal;
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 12;
            this.colCantidad.Width = 101;
            // 
            // reposDecimal
            // 
            this.reposDecimal.AutoHeight = false;
            this.reposDecimal.Mask.EditMask = "n2";
            this.reposDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimal.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimal.Name = "reposDecimal";
            // 
            // colNeto
            // 
            this.colNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.Caption = "Neto";
            this.colNeto.ColumnEdit = this.reposMoneda;
            this.colNeto.FieldName = "ImporteNeto";
            this.colNeto.Name = "colNeto";
            this.colNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteNeto", "{0:C2}")});
            this.colNeto.Visible = true;
            this.colNeto.VisibleIndex = 13;
            this.colNeto.Width = 97;
            // 
            // reposMoneda
            // 
            this.reposMoneda.AutoHeight = false;
            this.reposMoneda.Mask.EditMask = "c2";
            this.reposMoneda.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposMoneda.Mask.UseMaskAsDisplayFormat = true;
            this.reposMoneda.Name = "reposMoneda";
            // 
            // colIva
            // 
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "Iva";
            this.colIva.ColumnEdit = this.reposMoneda;
            this.colIva.FieldName = "ImporteIva";
            this.colIva.Name = "colIva";
            this.colIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "{0:C2}")});
            this.colIva.Visible = true;
            this.colIva.VisibleIndex = 14;
            this.colIva.Width = 81;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "Total";
            this.colTotal.ColumnEdit = this.reposMoneda;
            this.colTotal.FieldName = "ImporteTotal";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 15;
            this.colTotal.Width = 123;
            // 
            // colNroBusqueda
            // 
            this.colNroBusqueda.Caption = "Nro. Admisión";
            this.colNroBusqueda.FieldName = "PracticaNumeroAdmision";
            this.colNroBusqueda.Name = "colNroBusqueda";
            this.colNroBusqueda.Visible = true;
            this.colNroBusqueda.VisibleIndex = 5;
            this.colNroBusqueda.Width = 128;
            // 
            // colPrestadorCodigo
            // 
            this.colPrestadorCodigo.Caption = "Cuenta";
            this.colPrestadorCodigo.FieldName = "PrestadorCuentaCodigo";
            this.colPrestadorCodigo.Name = "colPrestadorCodigo";
            this.colPrestadorCodigo.Visible = true;
            this.colPrestadorCodigo.VisibleIndex = 2;
            // 
            // colPrestador
            // 
            this.colPrestador.Caption = "Prestador";
            this.colPrestador.FieldName = "PrestadorNombre";
            this.colPrestador.Name = "colPrestador";
            this.colPrestador.Visible = true;
            this.colPrestador.VisibleIndex = 3;
            this.colPrestador.Width = 136;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportar)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // btnExportar
            // 
            this.btnExportar.Caption = "Exportar lista";
            this.btnExportar.Id = 0;
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.LargeImage")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportar_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExportar});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 406);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 406);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 406);
            // 
            // bgwDetalles
            // 
            this.bgwDetalles.WorkerSupportsCancellation = true;
            this.bgwDetalles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDetalles_DoWork);
            this.bgwDetalles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDetalles_RunWorkerCompleted);
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
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Usr_Detalles";
            this.Size = new System.Drawing.Size(1008, 406);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colFechapractica;
        private DevExpress.XtraGrid.Columns.GridColumn colCodpractica;
        private DevExpress.XtraGrid.Columns.GridColumn colPractica;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncion;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colNombrepaci;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colNeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colNroBusqueda;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnExportar;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn coldescripcionManual;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private System.ComponentModel.BackgroundWorker bgwDetalles;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadorCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestador;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
    }
}
