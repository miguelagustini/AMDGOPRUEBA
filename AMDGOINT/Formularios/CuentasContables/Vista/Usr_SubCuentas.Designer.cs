namespace AMDGOINT.Formularios.CuentasContables.Vista
{
    partial class Usr_SubCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usr_SubCuentas));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsorcprestatria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsorcprestador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsorcempleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsorctercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsoopprestador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsoopempleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusooptercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposTextSi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposTextNo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), typeof(System.Windows.Forms.UserControl));
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnExportaXls = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextNo)).BeginInit();
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
            this.reposTextSi,
            this.reposTextNo});
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
            this.colCodigo,
            this.colDescripcion,
            this.colUsorcprestatria,
            this.colEstado,
            this.colUsorcprestador,
            this.colUsorcempleado,
            this.colUsorctercero,
            this.colUsoopprestador,
            this.colUsoopempleado,
            this.colusooptercero});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.True;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colUsorcprestatria
            // 
            this.colUsorcprestatria.Caption = "Uso Recibo Prestataria";
            this.colUsorcprestatria.FieldName = "UsoReciboPrestatariaDescripcion";
            this.colUsorcprestatria.Name = "colUsorcprestatria";
            this.colUsorcprestatria.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colUsorcprestatria.Visible = true;
            this.colUsorcprestatria.VisibleIndex = 2;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "EstadoDescripcion";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 9;
            // 
            // colUsorcprestador
            // 
            this.colUsorcprestador.Caption = "Uso Recibo Prestador";
            this.colUsorcprestador.FieldName = "UsoReciboPrestadorDescripcion";
            this.colUsorcprestador.Name = "colUsorcprestador";
            this.colUsorcprestador.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colUsorcprestador.Visible = true;
            this.colUsorcprestador.VisibleIndex = 3;
            // 
            // colUsorcempleado
            // 
            this.colUsorcempleado.Caption = "Uso Recibo Empleado";
            this.colUsorcempleado.FieldName = "UsoReciboEmpleadoDescripcion";
            this.colUsorcempleado.Name = "colUsorcempleado";
            this.colUsorcempleado.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colUsorcempleado.Visible = true;
            this.colUsorcempleado.VisibleIndex = 4;
            // 
            // colUsorctercero
            // 
            this.colUsorctercero.Caption = "Uso Recibo Tercero";
            this.colUsorctercero.FieldName = "UsoReciboTerceroDescripcion";
            this.colUsorctercero.Name = "colUsorctercero";
            this.colUsorctercero.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colUsorctercero.Visible = true;
            this.colUsorctercero.VisibleIndex = 5;
            // 
            // colUsoopprestador
            // 
            this.colUsoopprestador.Caption = "Uso O.P Prestador";
            this.colUsoopprestador.FieldName = "UsoOrdenPagoPrestadorDescripcion";
            this.colUsoopprestador.Name = "colUsoopprestador";
            this.colUsoopprestador.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colUsoopprestador.Visible = true;
            this.colUsoopprestador.VisibleIndex = 6;
            // 
            // colUsoopempleado
            // 
            this.colUsoopempleado.Caption = "Uso O.P Empleado";
            this.colUsoopempleado.FieldName = "UsoOrdenPagoEmpleadoDescripcion";
            this.colUsoopempleado.Name = "colUsoopempleado";
            this.colUsoopempleado.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colUsoopempleado.Visible = true;
            this.colUsoopempleado.VisibleIndex = 7;
            // 
            // colusooptercero
            // 
            this.colusooptercero.Caption = "Uso O.P Tercero";
            this.colusooptercero.FieldName = "UsoOrdenPagoTerceroDescripcion";
            this.colusooptercero.Name = "colusooptercero";
            this.colusooptercero.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colusooptercero.Visible = true;
            this.colusooptercero.VisibleIndex = 8;
            // 
            // reposTextSi
            // 
            this.reposTextSi.AutoHeight = false;
            this.reposTextSi.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("reposTextSi.ContextImageOptions.Image")));
            this.reposTextSi.Name = "reposTextSi";
            // 
            // reposTextNo
            // 
            this.reposTextNo.AutoHeight = false;
            this.reposTextNo.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("reposTextNo.ContextImageOptions.Image")));
            this.reposTextNo.Name = "reposTextNo";
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportaXls)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExportaXls});
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
            // btnExportaXls
            // 
            this.btnExportaXls.Caption = "Exportar Excel";
            this.btnExportaXls.Id = 0;
            this.btnExportaXls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportaXls.ImageOptions.Image")));
            this.btnExportaXls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportaXls.ImageOptions.LargeImage")));
            this.btnExportaXls.Name = "btnExportaXls";
            this.btnExportaXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportaXls_ItemClick);
            // 
            // Usr_SubCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Usr_SubCuentas";
            this.Size = new System.Drawing.Size(1008, 406);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colUsorcprestatria;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposTextSi;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposTextNo;
        private DevExpress.XtraGrid.Columns.GridColumn colUsorcprestador;
        private DevExpress.XtraGrid.Columns.GridColumn colUsorcempleado;
        private DevExpress.XtraGrid.Columns.GridColumn colUsorctercero;
        private DevExpress.XtraGrid.Columns.GridColumn colUsoopprestador;
        private DevExpress.XtraGrid.Columns.GridColumn colUsoopempleado;
        private DevExpress.XtraGrid.Columns.GridColumn colusooptercero;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnExportaXls;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
