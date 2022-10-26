namespace AMDGOINT.Formularios.Prestatarias
{
    partial class Frm_PrestatariasMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrestatariasMain));
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.pblTop = new DevExpress.XtraEditors.PanelControl();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btNuevoBar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditarbar = new DevExpress.XtraBars.Navigation.NavButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitter = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAbrevia = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCuit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMipime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDiasVto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colID_Registro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.reposCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabdetalles = new DevExpress.XtraTab.XtraTabControl();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.tmrescucha = new System.Windows.Forms.Timer(this.components);
            this.tmrDetalles = new System.Windows.Forms.Timer(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.reposCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // pblTop
            // 
            this.pblTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pblTop.Controls.Add(this.NavPanel);
            this.pblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblTop.Location = new System.Drawing.Point(0, 0);
            this.pblTop.Name = "pblTop";
            this.pblTop.Size = new System.Drawing.Size(704, 52);
            this.pblTop.TabIndex = 0;
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btNuevoBar);
            this.NavPanel.Buttons.Add(this.btnEditarbar);
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
            this.NavPanel.Size = new System.Drawing.Size(704, 52);
            this.NavPanel.TabIndex = 0;
            this.NavPanel.Text = "tileNavPane1";
            // 
            // btNuevoBar
            // 
            this.btNuevoBar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btNuevoBar.Caption = "Nuevo";
            this.btNuevoBar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btNuevoBar.ImageOptions.Image")));
            this.btNuevoBar.Name = "btNuevoBar";
            this.btNuevoBar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btNuevoBar_ElementClick);
            // 
            // btnEditarbar
            // 
            this.btnEditarbar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnEditarbar.Caption = "Editar";
            this.btnEditarbar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarbar.ImageOptions.Image")));
            this.btnEditarbar.Name = "btnEditarbar";
            this.btnEditarbar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditarbar_ElementClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitter, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.7482F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 278);
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
            this.splitter.Panel2.Controls.Add(this.tabdetalles);
            this.splitter.Panel2.Text = "Panel2";
            this.splitter.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.splitter.Size = new System.Drawing.Size(698, 272);
            this.splitter.SplitterPosition = 65;
            this.splitter.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.gridControl);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(698, 262);
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
            this.reposCheck});
            this.gridControl.Size = new System.Drawing.Size(698, 262);
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
            this.gridBand3,
            this.gridBand1,
            this.gridBand4});
            this.bgridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID_Registro,
            this.colNombre,
            this.colAbrevia,
            this.colCuit,
            this.colIva,
            this.colMipime,
            this.colDiasVto});
            this.bgridView.GridControl = this.gridControl;
            this.bgridView.Name = "bgridView";
            this.bgridView.OptionsBehavior.Editable = false;
            this.bgridView.OptionsCustomization.AllowBandMoving = false;
            this.bgridView.OptionsFind.AlwaysVisible = true;
            this.bgridView.OptionsFind.FindDelay = 500;
            this.bgridView.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.bgridView.OptionsFind.ShowCloseButton = false;
            this.bgridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bgridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.bgridView.OptionsView.ColumnAutoWidth = true;
            this.bgridView.OptionsView.EnableAppearanceEvenRow = true;
            this.bgridView.OptionsView.EnableAppearanceOddRow = true;
            this.bgridView.OptionsView.ShowFooter = true;
            this.bgridView.OptionsView.ShowGroupPanel = false;
            this.bgridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.bgridView_PopupMenuShowing);
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
            // gridBand3
            // 
            this.gridBand3.Caption = "Datos de Profesionales";
            this.gridBand3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand3.ImageOptions.Image")));
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.OptionsBand.AllowMove = false;
            this.gridBand3.Visible = false;
            this.gridBand3.VisibleIndex = -1;
            this.gridBand3.Width = 118;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Datos de Prestatarias";
            this.gridBand1.Columns.Add(this.colNombre);
            this.gridBand1.Columns.Add(this.colAbrevia);
            this.gridBand1.Columns.Add(this.colCuit);
            this.gridBand1.Columns.Add(this.colIva);
            this.gridBand1.Columns.Add(this.colMipime);
            this.gridBand1.Columns.Add(this.colDiasVto);
            this.gridBand1.Columns.Add(this.colID_Registro);
            this.gridBand1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand1.ImageOptions.Image")));
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 841;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Prestataria";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.Width = 221;
            // 
            // colAbrevia
            // 
            this.colAbrevia.Caption = "Descripción";
            this.colAbrevia.FieldName = "Abreviatura";
            this.colAbrevia.Name = "colAbrevia";
            this.colAbrevia.Visible = true;
            this.colAbrevia.Width = 199;
            // 
            // colCuit
            // 
            this.colCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCuit.Caption = "Cuit";
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.Width = 138;
            // 
            // colIva
            // 
            this.colIva.AppearanceCell.Options.UseTextOptions = true;
            this.colIva.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIva.Caption = "Iva";
            this.colIva.FieldName = "Iva";
            this.colIva.Name = "colIva";
            this.colIva.Visible = true;
            this.colIva.Width = 65;
            // 
            // colMipime
            // 
            this.colMipime.AppearanceCell.Options.UseTextOptions = true;
            this.colMipime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMipime.AppearanceHeader.Options.UseTextOptions = true;
            this.colMipime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMipime.Caption = "Mi Pyme";
            this.colMipime.FieldName = "MiPyme";
            this.colMipime.Name = "colMipime";
            this.colMipime.Visible = true;
            this.colMipime.Width = 109;
            // 
            // colDiasVto
            // 
            this.colDiasVto.AppearanceCell.Options.UseTextOptions = true;
            this.colDiasVto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiasVto.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiasVto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiasVto.Caption = "Dias Vto.";
            this.colDiasVto.FieldName = "DiasVencimiento";
            this.colDiasVto.Name = "colDiasVto";
            this.colDiasVto.Visible = true;
            this.colDiasVto.Width = 109;
            // 
            // colID_Registro
            // 
            this.colID_Registro.FieldName = "ID_Registro";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            this.colID_Registro.RowIndex = 2;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridBand4.Caption = "Importes";
            this.gridBand4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand4.ImageOptions.Image")));
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.AllowMove = false;
            this.gridBand4.Visible = false;
            this.gridBand4.VisibleIndex = -1;
            this.gridBand4.Width = 156;
            // 
            // reposCheck
            // 
            this.reposCheck.AutoHeight = false;
            this.reposCheck.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.reposCheck.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("reposCheck.ImageOptions.ImageChecked")));
            this.reposCheck.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("reposCheck.ImageOptions.ImageUnchecked")));
            this.reposCheck.Name = "reposCheck";
            // 
            // tabdetalles
            // 
            this.tabdetalles.AppearancePage.Header.BackColor = System.Drawing.Color.White;
            this.tabdetalles.AppearancePage.Header.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabdetalles.AppearancePage.Header.Options.UseBackColor = true;
            this.tabdetalles.AppearancePage.Header.Options.UseFont = true;
            this.tabdetalles.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
            this.tabdetalles.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Gainsboro;
            this.tabdetalles.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabdetalles.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabdetalles.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.tabdetalles.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabdetalles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tabdetalles.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tabdetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabdetalles.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.tabdetalles.Location = new System.Drawing.Point(0, 0);
            this.tabdetalles.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.tabdetalles.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabdetalles.Name = "tabdetalles";
            this.tabdetalles.Size = new System.Drawing.Size(0, 0);
            this.tabdetalles.TabIndex = 0;
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // tmrescucha
            // 
            this.tmrescucha.Interval = 200;
            this.tmrescucha.Tick += new System.EventHandler(this.tmrescucha_Tick);
            // 
            // tmrDetalles
            // 
            this.tmrDetalles.Tick += new System.EventHandler(this.tmrDetalles_Tick);
            // 
            // Frm_PrestatariasMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 330);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pblTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_PrestatariasMain";
            this.Text = "Prestatarias";
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
            ((System.ComponentModel.ISupportInitialize)(this.reposCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabdetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pblTop;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SplitContainerControl splitter;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraTab.XtraTabControl tabdetalles;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bgridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID_Registro;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCuit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIva;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheck;
        private System.Windows.Forms.Timer tmrescucha;
        private DevExpress.XtraBars.Navigation.NavButton btNuevoBar;
        private DevExpress.XtraBars.Navigation.NavButton btnEditarbar;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDiasVto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMipime;
        private System.Windows.Forms.Timer tmrDetalles;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAbrevia;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}