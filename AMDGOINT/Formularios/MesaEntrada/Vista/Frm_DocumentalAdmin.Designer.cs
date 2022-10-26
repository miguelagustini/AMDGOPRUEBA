namespace AMDGOINT.Formularios.MesaEntrada.Vista
{
    partial class Frm_DocumentalAdmin
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DocumentalAdmin));
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.PnlAuditores = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.PnlDevoluciones = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcuentaprof = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechapresentacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDatetime = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colNrobusqueda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNrolote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNrointernacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaciente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.reposMemodos = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.bgwBusqueda = new System.ComponentModel.BackgroundWorker();
            this.screenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.tileNavSubItem1 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.tileNavSubItem2 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.tileNavSubItem4 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.tileNavSubItem6 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.colPrestadora = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.PnlAuditores.SuspendLayout();
            this.PnlDevoluciones.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDatetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDatetime.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemodos)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1,
            this.dockPanel1});
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
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.PnlAuditores);
            this.panelContainer1.Controls.Add(this.PnlDevoluciones);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("bfce2448-b3ce-4962-8dae-9b536b0e96bd");
            this.panelContainer1.Location = new System.Drawing.Point(0, 257);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(1202, 200);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // PnlAuditores
            // 
            this.PnlAuditores.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(125)))), ((int)(((byte)(160)))));
            this.PnlAuditores.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.PnlAuditores.Appearance.Options.UseBorderColor = true;
            this.PnlAuditores.Controls.Add(this.dockPanel2_Container);
            this.PnlAuditores.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.PnlAuditores.FloatVertical = true;
            this.PnlAuditores.ID = new System.Guid("3a199c80-26c9-4eb4-bb22-192ee14e1862");
            this.PnlAuditores.Location = new System.Drawing.Point(0, 0);
            this.PnlAuditores.Name = "PnlAuditores";
            this.PnlAuditores.Options.ShowCloseButton = false;
            this.PnlAuditores.OriginalSize = new System.Drawing.Size(200, 200);
            this.PnlAuditores.Size = new System.Drawing.Size(601, 200);
            this.PnlAuditores.Text = "Auditores";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 24);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(601, 176);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // PnlDevoluciones
            // 
            this.PnlDevoluciones.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(100)))), ((int)(((byte)(20)))));
            this.PnlDevoluciones.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.PnlDevoluciones.Appearance.Options.UseBorderColor = true;
            this.PnlDevoluciones.Appearance.Options.UseForeColor = true;
            this.PnlDevoluciones.Controls.Add(this.controlContainer1);
            this.PnlDevoluciones.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.PnlDevoluciones.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PnlDevoluciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.PnlDevoluciones.ID = new System.Guid("ec96862f-2a09-44fa-96bc-32108b69932a");
            this.PnlDevoluciones.Location = new System.Drawing.Point(601, 0);
            this.PnlDevoluciones.Name = "PnlDevoluciones";
            this.PnlDevoluciones.Options.ShowCloseButton = false;
            this.PnlDevoluciones.OriginalSize = new System.Drawing.Size(200, 200);
            this.PnlDevoluciones.Size = new System.Drawing.Size(601, 200);
            this.PnlDevoluciones.Text = "Registro de devoluciones";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(1, 24);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(600, 176);
            this.controlContainer1.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.dockPanel1.Appearance.Options.UseBorderColor = true;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("42ec6e1c-5429-40c0-80c0-14e8cd48e703");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(558, 200);
            this.dockPanel1.Size = new System.Drawing.Size(1202, 257);
            this.dockPanel1.Text = "Documental";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1202, 234);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposDatetime,
            this.reposMemo,
            this.reposMemodos});
            this.gridControl.Size = new System.Drawing.Size(1202, 234);
            this.gridControl.TabIndex = 12;
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
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            this.colPrestadora,
            this.colcuentaprof,
            this.colFechapresentacion,
            this.colNrobusqueda,
            this.colNrolote,
            this.colNrointernacion,
            this.colPractica,
            this.colPaciente});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView_CustomDrawGroupRow);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            // 
            // colcuentaprof
            // 
            this.colcuentaprof.Caption = "Profesional";
            this.colcuentaprof.FieldName = "CuentaInformacion";
            this.colcuentaprof.Name = "colcuentaprof";
            this.colcuentaprof.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colcuentaprof.Visible = true;
            this.colcuentaprof.VisibleIndex = 1;
            this.colcuentaprof.Width = 150;
            // 
            // colFechapresentacion
            // 
            this.colFechapresentacion.Caption = "Presentado";
            this.colFechapresentacion.ColumnEdit = this.reposDatetime;
            this.colFechapresentacion.FieldName = "FechaPresentacion";
            this.colFechapresentacion.Name = "colFechapresentacion";
            this.colFechapresentacion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colFechapresentacion.Visible = true;
            this.colFechapresentacion.VisibleIndex = 2;
            this.colFechapresentacion.Width = 100;
            // 
            // reposDatetime
            // 
            this.reposDatetime.AutoHeight = false;
            this.reposDatetime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDatetime.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDatetime.Mask.EditMask = "yyyy-MM-dd";
            this.reposDatetime.Mask.UseMaskAsDisplayFormat = true;
            this.reposDatetime.Name = "reposDatetime";
            // 
            // colNrobusqueda
            // 
            this.colNrobusqueda.Caption = "Nro. Búsqueda";
            this.colNrobusqueda.FieldName = "NroBusqueda";
            this.colNrobusqueda.Name = "colNrobusqueda";
            this.colNrobusqueda.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNrobusqueda.Visible = true;
            this.colNrobusqueda.VisibleIndex = 3;
            this.colNrobusqueda.Width = 100;
            // 
            // colNrolote
            // 
            this.colNrolote.Caption = "Nro. Lote";
            this.colNrolote.FieldName = "NroLote";
            this.colNrolote.Name = "colNrolote";
            this.colNrolote.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNrolote.Visible = true;
            this.colNrolote.VisibleIndex = 4;
            this.colNrolote.Width = 100;
            // 
            // colNrointernacion
            // 
            this.colNrointernacion.Caption = "Nro. Internación";
            this.colNrointernacion.FieldName = "NroInternacion";
            this.colNrointernacion.Name = "colNrointernacion";
            this.colNrointernacion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNrointernacion.Visible = true;
            this.colNrointernacion.VisibleIndex = 5;
            this.colNrointernacion.Width = 100;
            // 
            // colPractica
            // 
            this.colPractica.Caption = "Práctica";
            this.colPractica.FieldName = "PracticaCompleta";
            this.colPractica.Name = "colPractica";
            this.colPractica.Visible = true;
            this.colPractica.VisibleIndex = 6;
            this.colPractica.Width = 214;
            // 
            // colPaciente
            // 
            this.colPaciente.Caption = "Paciente";
            this.colPaciente.FieldName = "PacienteCompleto";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.Visible = true;
            this.colPaciente.VisibleIndex = 7;
            this.colPaciente.Width = 214;
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // reposMemodos
            // 
            this.reposMemodos.Name = "reposMemodos";
            // 
            // bgwBusqueda
            // 
            this.bgwBusqueda.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBusqueda_DoWork);
            this.bgwBusqueda.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBusqueda_RunWorkerCompleted);
            // 
            // screenManager
            // 
            this.screenManager.ClosingDelay = 500;
            // 
            // tileNavSubItem1
            // 
            this.tileNavSubItem1.Caption = "Planes Fesalud";
            this.tileNavSubItem1.Name = "tileNavSubItem1";
            this.tileNavSubItem1.Tag = ((short)(1));
            // 
            // 
            // 
            this.tileNavSubItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement1.Text = "Planes Fesalud";
            this.tileNavSubItem1.Tile.Elements.Add(tileItemElement1);
            this.tileNavSubItem1.Tile.Name = "tileBarItem1";
            this.tileNavSubItem1.Tile.Tag = ((short)(1));
            // 
            // tileNavSubItem2
            // 
            this.tileNavSubItem2.Caption = "Créditos de ayuda económica";
            this.tileNavSubItem2.Name = "tileNavSubItem2";
            this.tileNavSubItem2.Tag = ((short)(2));
            // 
            // 
            // 
            this.tileNavSubItem2.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement2.Text = "Créditos de ayuda económica";
            this.tileNavSubItem2.Tile.Elements.Add(tileItemElement2);
            this.tileNavSubItem2.Tile.Name = "tileBarItem2";
            this.tileNavSubItem2.Tile.Tag = ((short)(2));
            // 
            // tileNavSubItem4
            // 
            this.tileNavSubItem4.Caption = "Fondo solidario automotor";
            this.tileNavSubItem4.Name = "tileNavSubItem4";
            this.tileNavSubItem4.Tag = ((short)(3));
            // 
            // 
            // 
            this.tileNavSubItem4.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement3.Text = "Fondo solidario automotor";
            this.tileNavSubItem4.Tile.Elements.Add(tileItemElement3);
            this.tileNavSubItem4.Tile.Name = "tileBarItem6";
            this.tileNavSubItem4.Tile.Tag = ((short)(4));
            // 
            // tileNavSubItem6
            // 
            this.tileNavSubItem6.Caption = "RIB, DJG, INGB";
            this.tileNavSubItem6.Name = "tileNavSubItem6";
            this.tileNavSubItem6.Tag = ((short)(4));
            // 
            // 
            // 
            this.tileNavSubItem6.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            tileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileItemElement4.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement4.Text = "RIB, DJG, INGB";
            this.tileNavSubItem6.Tile.Elements.Add(tileItemElement4);
            this.tileNavSubItem6.Tile.Name = "tileBarItem8";
            this.tileNavSubItem6.Tile.Tag = ((short)(6));
            // 
            // colPrestadora
            // 
            this.colPrestadora.Caption = "Prestadora";
            this.colPrestadora.FieldName = "Prestadora";
            this.colPrestadora.Name = "colPrestadora";
            this.colPrestadora.Visible = true;
            this.colPrestadora.VisibleIndex = 0;
            // 
            // Frm_DocumentalAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 457);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.panelContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_DocumentalAdmin";
            this.Text = "Administración de documental";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DocumentalAdmin_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Negociacion_Load);
            this.Shown += new System.EventHandler(this.Frm_DocumentalAdmin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.PnlAuditores.ResumeLayout(false);
            this.PnlDevoluciones.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDatetime.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDatetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemodos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private System.ComponentModel.BackgroundWorker bgwBusqueda;
        private DevExpress.XtraSplashScreen.SplashScreenManager screenManager;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem1;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem2;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem4;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem6;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colcuentaprof;
        private DevExpress.XtraGrid.Columns.GridColumn colFechapresentacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colNrobusqueda;
        private DevExpress.XtraGrid.Columns.GridColumn colNrolote;
        private DevExpress.XtraGrid.Columns.GridColumn colNrointernacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colPractica;
        private DevExpress.XtraGrid.Columns.GridColumn colPaciente;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemodos;
        private DevExpress.XtraBars.Docking.DockPanel PnlAuditores;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel PnlDevoluciones;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadora;
    }
}