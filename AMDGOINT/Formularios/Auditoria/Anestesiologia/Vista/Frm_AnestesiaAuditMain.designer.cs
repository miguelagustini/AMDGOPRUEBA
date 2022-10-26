namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista
{
    partial class Frm_AnestesiaAuditMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AnestesiaAuditMain));
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnNuevobar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditarbar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnDiferencias = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitter = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFechaCarga = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPerido = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEntidad = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFechaFactura = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNumerofact = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPrestataria = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIDRegistro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Tabdetalles = new DevExpress.XtraTab.XtraTabControl();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.tmrEscucha = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).BeginInit();
            this.pblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabdetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(818, 54);
            this.pblTop.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnNuevobar);
            this.NavPanel.Buttons.Add(this.btnEditarbar);
            this.NavPanel.Buttons.Add(this.btnDiferencias);
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
            this.NavPanel.Size = new System.Drawing.Size(818, 54);
            this.NavPanel.TabIndex = 0;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btnNuevobar
            // 
            this.btnNuevobar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnNuevobar.Caption = "Nuevo";
            this.btnNuevobar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevobar.ImageOptions.Image")));
            this.btnNuevobar.Name = "btnNuevobar";
            this.btnNuevobar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnNuevobar_ElementClick);
            // 
            // btnEditarbar
            // 
            this.btnEditarbar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnEditarbar.Caption = "Editar";
            this.btnEditarbar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarbar.ImageOptions.Image")));
            this.btnEditarbar.Name = "btnEditarbar";
            this.btnEditarbar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditarbar_ElementClick);
            // 
            // btnDiferencias
            // 
            this.btnDiferencias.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnDiferencias.Caption = "Resúmen";
            this.btnDiferencias.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDiferencias.ImageOptions.Image")));
            this.btnDiferencias.Name = "btnDiferencias";
            this.btnDiferencias.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnDiferencias_ElementClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitter, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.7482F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 382);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // splitter
            // 
            this.splitter.Appearance.BackColor = System.Drawing.Color.White;
            this.splitter.Appearance.Options.UseBackColor = true;
            this.splitter.Collapsed = true;
            this.splitter.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Horizontal = false;
            this.splitter.Location = new System.Drawing.Point(3, 3);
            this.splitter.Name = "splitter";
            this.splitter.Panel1.Controls.Add(this.pnlCenter);
            this.splitter.Panel1.Text = "Panel1";
            this.splitter.Panel2.Controls.Add(this.Tabdetalles);
            this.splitter.Panel2.Text = "Panel2";
            this.splitter.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.splitter.Size = new System.Drawing.Size(812, 376);
            this.splitter.SplitterPosition = 163;
            this.splitter.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.gridControl);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(812, 366);
            this.pnlCenter.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.bgridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposFecha});
            this.gridControl.Size = new System.Drawing.Size(812, 366);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgridView});
            // 
            // bgridView
            // 
            this.bgridView.Appearance.BandPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridView.Appearance.BandPanel.Options.UseFont = true;
            this.bgridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.bgridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedCell.Options.UseFont = true;
            this.bgridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bgridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedRow.Options.UseFont = true;
            this.bgridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bgridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.bgridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bgridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.bgridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bgridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.Row.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.SelectedRow.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.bgridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.bgridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colIDRegistro,
            this.colFechaCarga,
            this.colPerido,
            this.colFechaFactura,
            this.colNumerofact,
            this.colEntidad,
            this.colPrestataria});
            this.bgridView.GridControl = this.gridControl;
            this.bgridView.Name = "bgridView";
            this.bgridView.OptionsBehavior.Editable = false;
            this.bgridView.OptionsDetail.EnableMasterViewMode = false;
            this.bgridView.OptionsFind.AlwaysVisible = true;
            this.bgridView.OptionsFind.FindDelay = 500;
            this.bgridView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.bgridView.OptionsFind.ShowCloseButton = false;
            this.bgridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bgridView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.bgridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.bgridView.OptionsView.ColumnAutoWidth = true;
            this.bgridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.bgridView.OptionsView.EnableAppearanceEvenRow = true;
            this.bgridView.OptionsView.EnableAppearanceOddRow = true;
            this.bgridView.OptionsView.ShowFooter = true;
            this.bgridView.OptionsView.ShowGroupPanel = false;
            this.bgridView.OptionsView.ShowIndicator = false;
            this.bgridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.bgridView_FocusedRowObjectChanged);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "...";
            this.gridBand2.MinWidth = 22;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.AllowMove = false;
            this.gridBand2.OptionsBand.AllowSize = false;
            this.gridBand2.OptionsBand.ShowInCustomizationForm = false;
            this.gridBand2.Visible = false;
            this.gridBand2.VisibleIndex = -1;
            this.gridBand2.Width = 22;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Datos de la facturación";
            this.gridBand1.Columns.Add(this.colFechaCarga);
            this.gridBand1.Columns.Add(this.colPerido);
            this.gridBand1.Columns.Add(this.colEntidad);
            this.gridBand1.Columns.Add(this.colFechaFactura);
            this.gridBand1.Columns.Add(this.colNumerofact);
            this.gridBand1.Columns.Add(this.colPrestataria);
            this.gridBand1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand1.ImageOptions.Image")));
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 1090;
            // 
            // colFechaCarga
            // 
            this.colFechaCarga.Caption = "Ingreso";
            this.colFechaCarga.ColumnEdit = this.reposFecha;
            this.colFechaCarga.FieldName = "FechaCarga";
            this.colFechaCarga.Name = "colFechaCarga";
            this.colFechaCarga.Visible = true;
            this.colFechaCarga.Width = 103;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // colPerido
            // 
            this.colPerido.Caption = "Período";
            this.colPerido.FieldName = "Periodo";
            this.colPerido.Name = "colPerido";
            this.colPerido.Visible = true;
            this.colPerido.Width = 110;
            // 
            // colEntidad
            // 
            this.colEntidad.Caption = "Entidad";
            this.colEntidad.FieldName = "Entidad";
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.Visible = true;
            this.colEntidad.Width = 257;
            // 
            // colFechaFactura
            // 
            this.colFechaFactura.Caption = "Facturado";
            this.colFechaFactura.ColumnEdit = this.reposFecha;
            this.colFechaFactura.FieldName = "FechaFactura";
            this.colFechaFactura.Name = "colFechaFactura";
            this.colFechaFactura.Visible = true;
            this.colFechaFactura.Width = 113;
            // 
            // colNumerofact
            // 
            this.colNumerofact.AppearanceCell.Options.UseTextOptions = true;
            this.colNumerofact.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNumerofact.Caption = "Facturación Nro.";
            this.colNumerofact.FieldName = "NroFacturacion";
            this.colNumerofact.Name = "colNumerofact";
            this.colNumerofact.Visible = true;
            this.colNumerofact.Width = 180;
            // 
            // colPrestataria
            // 
            this.colPrestataria.Caption = "Prestataria";
            this.colPrestataria.FieldName = "Prestataria";
            this.colPrestataria.Name = "colPrestataria";
            this.colPrestataria.Visible = true;
            this.colPrestataria.Width = 327;
            // 
            // colIDRegistro
            // 
            this.colIDRegistro.Caption = "IDRegistro";
            this.colIDRegistro.FieldName = "IDRegistro";
            this.colIDRegistro.Name = "colIDRegistro";
            this.colIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDRegistro.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // Tabdetalles
            // 
            this.Tabdetalles.AppearancePage.Header.BackColor = System.Drawing.Color.White;
            this.Tabdetalles.AppearancePage.Header.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabdetalles.AppearancePage.Header.Options.UseBackColor = true;
            this.Tabdetalles.AppearancePage.Header.Options.UseFont = true;
            this.Tabdetalles.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
            this.Tabdetalles.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Gainsboro;
            this.Tabdetalles.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabdetalles.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.Tabdetalles.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.Tabdetalles.AppearancePage.HeaderActive.Options.UseFont = true;
            this.Tabdetalles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Tabdetalles.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Tabdetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabdetalles.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.Tabdetalles.Location = new System.Drawing.Point(0, 0);
            this.Tabdetalles.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.Tabdetalles.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Tabdetalles.Name = "Tabdetalles";
            this.Tabdetalles.Size = new System.Drawing.Size(0, 0);
            this.Tabdetalles.TabIndex = 0;
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
            // tmrEscucha
            // 
            this.tmrEscucha.Tick += new System.EventHandler(this.tmrescucha_Tick);
            // 
            // Frm_AnestesiaAuditMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 436);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_AnestesiaAuditMain";
            this.Text = "Facturas Anestesiologia";
            ((System.ComponentModel.ISupportInitialize)(this.pblTop)).EndInit();
            this.pblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabdetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pblTop;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitter;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraTab.XtraTabControl Tabdetalles;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bgridView;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraBars.Navigation.NavButton btnNuevobar;
        private DevExpress.XtraBars.Navigation.NavButton btnEditarbar;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private System.Windows.Forms.Timer tmrEscucha;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFechaCarga;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPerido;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEntidad;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFechaFactura;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNumerofact;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPrestataria;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDRegistro;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraBars.Navigation.NavButton btnDiferencias;
    }
}