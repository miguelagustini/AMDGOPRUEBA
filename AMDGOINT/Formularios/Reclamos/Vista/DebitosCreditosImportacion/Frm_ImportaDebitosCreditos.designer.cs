namespace AMDGOINT.Formularios.Reclamos.Vista.DebitosCreditosImportacion
{
    partial class Frm_ImportaDebitosCreditos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportaDebitosCreditos));
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewimpo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObraSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmisionNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodoFacturado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnImportar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnInsertarRegistros = new DevExpress.XtraBars.Navigation.NavButton();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bgwInsertaRegistros = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewimpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "C2";
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
            this.gridControl.MainView = this.gridViewimpo;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1082, 375);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewimpo});
            // 
            // gridViewimpo
            // 
            this.gridViewimpo.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridViewimpo.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewimpo.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewimpo.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewimpo.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewimpo.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewimpo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewimpo.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewimpo.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewimpo.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewimpo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewimpo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewimpo.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewimpo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewimpo.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewimpo.Appearance.Row.Options.UseFont = true;
            this.gridViewimpo.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewimpo.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewimpo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewimpo.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewimpo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewimpo.ChildGridLevelName = "gridViewdet";
            this.gridViewimpo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDebito,
            this.colCredito,
            this.colMovito,
            this.colObraSocial,
            this.colPrestador,
            this.colAdmisionNumero,
            this.colPeriodoFacturado,
            this.colComprobante});
            this.gridViewimpo.GridControl = this.gridControl;
            this.gridViewimpo.Name = "gridViewimpo";
            this.gridViewimpo.OptionsBehavior.Editable = false;
            this.gridViewimpo.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewimpo.OptionsFind.AlwaysVisible = true;
            this.gridViewimpo.OptionsFind.FindDelay = 500;
            this.gridViewimpo.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.gridViewimpo.OptionsFind.ShowCloseButton = false;
            this.gridViewimpo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewimpo.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridViewimpo.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewimpo.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewimpo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewimpo.OptionsView.RowAutoHeight = true;
            this.gridViewimpo.OptionsView.ShowFooter = true;
            this.gridViewimpo.OptionsView.ShowGroupPanel = false;
            this.gridViewimpo.OptionsView.ShowIndicator = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID Registro";
            this.colID.FieldName = "movpcoda";
            this.colID.Name = "colID";
            this.colID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "movpcoda", "{0}")});
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colDebito
            // 
            this.colDebito.Caption = "Debito";
            this.colDebito.ColumnEdit = this.reposImportes;
            this.colDebito.FieldName = "movpdebito";
            this.colDebito.Name = "colDebito";
            this.colDebito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "movpdebito", "{0:C2}")});
            this.colDebito.Visible = true;
            this.colDebito.VisibleIndex = 1;
            // 
            // colCredito
            // 
            this.colCredito.Caption = "Crédito";
            this.colCredito.ColumnEdit = this.reposImportes;
            this.colCredito.FieldName = "movpcredito";
            this.colCredito.Name = "colCredito";
            this.colCredito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "movpcredito", "{0:C2}")});
            this.colCredito.Visible = true;
            this.colCredito.VisibleIndex = 2;
            // 
            // colMovito
            // 
            this.colMovito.Caption = "Motivo";
            this.colMovito.FieldName = "movpmotivo";
            this.colMovito.Name = "colMovito";
            this.colMovito.Visible = true;
            this.colMovito.VisibleIndex = 3;
            // 
            // colObraSocial
            // 
            this.colObraSocial.Caption = "Prestadora";
            this.colObraSocial.FieldName = "movpcdob";
            this.colObraSocial.Name = "colObraSocial";
            this.colObraSocial.Visible = true;
            this.colObraSocial.VisibleIndex = 4;
            // 
            // colPrestador
            // 
            this.colPrestador.Caption = "Prestador";
            this.colPrestador.FieldName = "movpprof";
            this.colPrestador.Name = "colPrestador";
            this.colPrestador.Visible = true;
            this.colPrestador.VisibleIndex = 5;
            // 
            // colAdmisionNumero
            // 
            this.colAdmisionNumero.Caption = "Nro. Admisión";
            this.colAdmisionNumero.FieldName = "movpadmi";
            this.colAdmisionNumero.Name = "colAdmisionNumero";
            this.colAdmisionNumero.Visible = true;
            this.colAdmisionNumero.VisibleIndex = 6;
            // 
            // colPeriodoFacturado
            // 
            this.colPeriodoFacturado.Caption = "Periodo Facturado";
            this.colPeriodoFacturado.FieldName = "movppefa";
            this.colPeriodoFacturado.Name = "colPeriodoFacturado";
            this.colPeriodoFacturado.Visible = true;
            this.colPeriodoFacturado.VisibleIndex = 7;
            // 
            // colComprobante
            // 
            this.colComprobante.Caption = "Comprobante";
            this.colComprobante.FieldName = "movpcomprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 8;
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
            // dockManager
            // 
            this.dockManager.DockingOptions.ShowCloseButton = false;
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
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
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.dockPanel1_Container);
            this.panelEncabezado.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelEncabezado.ID = new System.Guid("32d67652-40b1-48b7-afe8-19c2d531847f");
            this.panelEncabezado.Location = new System.Drawing.Point(0, 52);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.OriginalSize = new System.Drawing.Size(1082, 200);
            this.panelEncabezado.Size = new System.Drawing.Size(1082, 398);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Registros";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1082, 375);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnImportar);
            this.NavPanel.Buttons.Add(this.btnInsertarRegistros);
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
            // 
            // btnImportar
            // 
            this.btnImportar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnImportar.Caption = "Importar";
            this.btnImportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.ImageOptions.Image")));
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnImportar_ElementClick);
            // 
            // btnInsertarRegistros
            // 
            this.btnInsertarRegistros.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnInsertarRegistros.Caption = "Insertar Registros";
            this.btnInsertarRegistros.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertarRegistros.ImageOptions.Image")));
            this.btnInsertarRegistros.Name = "btnInsertarRegistros";
            this.btnInsertarRegistros.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnInsertarRegistros_ElementClick);
            // 
            // bgwInsertaRegistros
            // 
            this.bgwInsertaRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInsertaRegistros_DoWork);
            this.bgwInsertaRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwInsertaRegistros_RunWorkerCompleted);
            // 
            // Frm_ImportaDebitosCreditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 450);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.NavPanel);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_ImportaDebitosCreditos";
            this.Text = "Importación de debitos creditos";
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewimpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewimpo;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private System.ComponentModel.BackgroundWorker bgwObtienereg;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel panelEncabezado;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraBars.Navigation.NavButton btnImportar;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colMovito;
        private DevExpress.XtraGrid.Columns.GridColumn colObraSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestador;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmisionNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodoFacturado;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private DevExpress.XtraBars.Navigation.NavButton btnInsertarRegistros;
        private System.ComponentModel.BackgroundWorker bgwInsertaRegistros;
    }
}