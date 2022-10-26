namespace AMDGOINT.Formularios.Reclamos.Vista
{
    partial class Frm_Reclamo
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
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel2 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel3 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Reclamo));
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.pnlReclamo = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.datInicio = new DevExpress.XtraEditors.DateEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblEstado = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.trcUrgencia = new DevExpress.XtraEditors.TrackBarControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPrestataria = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlDetalles = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pnlEventos = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.bgwEmiteFactura = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.pnlReclamo.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcUrgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcUrgencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestataria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            this.pnlEventos.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager;
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1151, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 523);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1151, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 523);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1151, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 523);
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager1;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.pnlReclamo,
            this.panelContainer1});
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
            // pnlReclamo
            // 
            this.pnlReclamo.Controls.Add(this.dockPanel1_Container);
            customHeaderButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions1.Image")));
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipItem1.Text = "Guarda todos los cambios realizados si se cumplen con las condiciones básicas.";
            superToolTip1.Items.Add(toolTipItem1);
            this.pnlReclamo.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Guardar y Salir", true, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, superToolTip1, true, false, true, serializableAppearanceObject1, "Guardar", -1)});
            this.pnlReclamo.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.pnlReclamo.FloatVertical = true;
            this.pnlReclamo.ID = new System.Guid("13f68ef0-2fa5-47a0-b0b6-4eab11d3cec7");
            this.pnlReclamo.Location = new System.Drawing.Point(0, 0);
            this.pnlReclamo.Name = "pnlReclamo";
            this.pnlReclamo.Options.ShowCloseButton = false;
            this.pnlReclamo.Options.ShowMaximizeButton = false;
            this.pnlReclamo.OriginalSize = new System.Drawing.Size(1151, 199);
            this.pnlReclamo.Size = new System.Drawing.Size(1151, 199);
            this.pnlReclamo.Text = "Reclamo";
            this.pnlReclamo.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.pnlReclamo_CustomButtonClick);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tableLayoutPanel2);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 32);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1145, 163);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.00568F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.88636F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.36364F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.46023F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00976F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.datInicio, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblEstado, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtObservacion, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.trcUrgencia, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbPrestataria, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPeriodo, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1145, 163);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(3, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Periodo";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Iniciado el";
            // 
            // datInicio
            // 
            this.datInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datInicio.EditValue = null;
            this.datInicio.EnterMoveNextControl = true;
            this.datInicio.Location = new System.Drawing.Point(84, 7);
            this.datInicio.MenuManager = this.barManager1;
            this.datInicio.Name = "datInicio";
            this.datInicio.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datInicio.Size = new System.Drawing.Size(164, 24);
            this.datInicio.StyleController = this.styleText;
            this.datInicio.TabIndex = 0;
            // 
            // styleText
            // 
            this.styleText.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.styleText.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.Appearance.Options.UseBorderColor = true;
            this.styleText.Appearance.Options.UseFont = true;
            this.styleText.AppearanceFocused.BorderColor = System.Drawing.Color.Goldenrod;
            this.styleText.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.AppearanceFocused.Options.UseBorderColor = true;
            this.styleText.AppearanceFocused.Options.UseFont = true;
            this.styleText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl6.Location = new System.Drawing.Point(3, 127);
            this.labelControl6.Name = "labelControl6";
            this.tableLayoutPanel2.SetRowSpan(this.labelControl6, 2);
            this.labelControl6.Size = new System.Drawing.Size(75, 18);
            this.labelControl6.StyleController = this.styleLabels;
            this.labelControl6.TabIndex = 22;
            this.labelControl6.Text = "Estado";
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Appearance.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblEstado.Appearance.Options.UseFont = true;
            this.lblEstado.Appearance.Options.UseForeColor = true;
            this.lblEstado.Appearance.Options.UseTextOptions = true;
            this.lblEstado.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblEstado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblEstado.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tableLayoutPanel2.SetColumnSpan(this.lblEstado, 2);
            this.lblEstado.Location = new System.Drawing.Point(84, 124);
            this.lblEstado.Name = "lblEstado";
            this.tableLayoutPanel2.SetRowSpan(this.lblEstado, 2);
            this.lblEstado.Size = new System.Drawing.Size(305, 24);
            this.lblEstado.StyleController = this.styleLabels;
            this.lblEstado.TabIndex = 28;
            this.lblEstado.Text = "PRUEBA";
            this.lblEstado.TextChanged += new System.EventHandler(this.lblEstado_TextChanged);
            // 
            // txtObservacion
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtObservacion, 4);
            this.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacion.Location = new System.Drawing.Point(475, 3);
            this.txtObservacion.MenuManager = this.barManager1;
            this.txtObservacion.Name = "txtObservacion";
            this.tableLayoutPanel2.SetRowSpan(this.txtObservacion, 3);
            this.txtObservacion.Size = new System.Drawing.Size(667, 104);
            this.txtObservacion.TabIndex = 26;
            this.txtObservacion.TabStop = false;
            this.txtObservacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reposTexto_KeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl5.Location = new System.Drawing.Point(395, 127);
            this.labelControl5.Name = "labelControl5";
            this.tableLayoutPanel2.SetRowSpan(this.labelControl5, 2);
            this.labelControl5.Size = new System.Drawing.Size(74, 18);
            this.labelControl5.StyleController = this.styleLabels;
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Urgencia";
            // 
            // trcUrgencia
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.trcUrgencia, 4);
            this.trcUrgencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trcUrgencia.EditValue = null;
            this.trcUrgencia.Location = new System.Drawing.Point(475, 113);
            this.trcUrgencia.MenuManager = this.barManager1;
            this.trcUrgencia.Name = "trcUrgencia";
            this.trcUrgencia.Properties.LabelAppearance.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trcUrgencia.Properties.LabelAppearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.trcUrgencia.Properties.LabelAppearance.Options.UseFont = true;
            this.trcUrgencia.Properties.LabelAppearance.Options.UseForeColor = true;
            this.trcUrgencia.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trcUrgencia.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "Normal";
            trackBarLabel2.Label = "Rápido";
            trackBarLabel2.Value = 1;
            trackBarLabel3.Label = "Urgente";
            trackBarLabel3.Value = 2;
            this.trcUrgencia.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1,
            trackBarLabel2,
            trackBarLabel3});
            this.trcUrgencia.Properties.LargeChange = 2;
            this.trcUrgencia.Properties.Maximum = 2;
            this.trcUrgencia.Properties.ShowLabels = true;
            this.tableLayoutPanel2.SetRowSpan(this.trcUrgencia, 2);
            this.trcUrgencia.Size = new System.Drawing.Size(667, 47);
            this.trcUrgencia.TabIndex = 27;
            this.trcUrgencia.TabStop = false;
            this.trcUrgencia.EditValueChanged += new System.EventHandler(this.trcUrgencia_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(395, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 18);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Observación";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Prestataria";
            // 
            // cmbPrestataria
            // 
            this.cmbPrestataria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbPrestataria, 2);
            this.cmbPrestataria.EditValue = 0;
            this.cmbPrestataria.EnterMoveNextControl = true;
            this.cmbPrestataria.Location = new System.Drawing.Point(84, 44);
            this.cmbPrestataria.MenuManager = this.barManager1;
            this.cmbPrestataria.Name = "cmbPrestataria";
            this.cmbPrestataria.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPrestataria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrestataria.Properties.DisplayMember = "Prestataria";
            this.cmbPrestataria.Properties.NullText = "";
            this.cmbPrestataria.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbPrestataria.Properties.ValueMember = "IDPrestataria";
            this.cmbPrestataria.Size = new System.Drawing.Size(305, 24);
            this.cmbPrestataria.StyleController = this.styleText;
            this.cmbPrestataria.TabIndex = 1;
            this.cmbPrestataria.EditValueChanged += new System.EventHandler(this.cmbPrestataria_EditValueChanged);
            this.cmbPrestataria.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cmbPrestataria_EditValueChanging);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.searchLookUpEdit1View.Appearance.EvenRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cmNombre,
            this.cmCuit,
            this.cmIva,
            this.cmAbreviatura});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // cmNombre
            // 
            this.cmNombre.Caption = "Prestataria";
            this.cmNombre.FieldName = "Prestataria";
            this.cmNombre.Name = "cmNombre";
            this.cmNombre.Visible = true;
            this.cmNombre.VisibleIndex = 0;
            this.cmNombre.Width = 654;
            // 
            // cmCuit
            // 
            this.cmCuit.Caption = "Cuit";
            this.cmCuit.FieldName = "Cuit";
            this.cmCuit.Name = "cmCuit";
            this.cmCuit.Visible = true;
            this.cmCuit.VisibleIndex = 2;
            this.cmCuit.Width = 190;
            // 
            // cmIva
            // 
            this.cmIva.Caption = "Iva";
            this.cmIva.FieldName = "Iva";
            this.cmIva.Name = "cmIva";
            this.cmIva.Visible = true;
            this.cmIva.VisibleIndex = 3;
            this.cmIva.Width = 195;
            // 
            // cmAbreviatura
            // 
            this.cmAbreviatura.Caption = "Descripción";
            this.cmAbreviatura.FieldName = "Abreviatura";
            this.cmAbreviatura.Name = "cmAbreviatura";
            this.cmAbreviatura.Visible = true;
            this.cmAbreviatura.VisibleIndex = 1;
            this.cmAbreviatura.Width = 283;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeriodo.EditValue = "";
            this.txtPeriodo.EnterMoveNextControl = true;
            this.txtPeriodo.Location = new System.Drawing.Point(84, 80);
            this.txtPeriodo.MenuManager = this.barManager1;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPeriodo.Properties.Mask.EditMask = "\\d{4}\\-\\d{2}";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPeriodo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPeriodo.Size = new System.Drawing.Size(164, 24);
            this.txtPeriodo.StyleController = this.styleText;
            this.txtPeriodo.TabIndex = 2;
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.pnlDetalles;
            this.panelContainer1.Controls.Add(this.pnlDetalles);
            this.panelContainer1.Controls.Add(this.pnlEventos);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContainer1.ID = new System.Guid("99817e61-e2e4-448b-b800-312be4f7ee11");
            this.panelContainer1.Location = new System.Drawing.Point(0, 199);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(1151, 200);
            this.panelContainer1.Size = new System.Drawing.Size(1151, 324);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.Controls.Add(this.dockPanel3_Container);
            this.pnlDetalles.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.pnlDetalles.FloatVertical = true;
            this.pnlDetalles.ID = new System.Guid("b226d506-1531-4f85-81e1-585295dff0bd");
            this.pnlDetalles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pnlDetalles.ImageOptions.Image")));
            this.pnlDetalles.Location = new System.Drawing.Point(3, 26);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Options.ShowCloseButton = false;
            this.pnlDetalles.OriginalSize = new System.Drawing.Size(1145, 204);
            this.pnlDetalles.Size = new System.Drawing.Size(1145, 267);
            this.pnlDetalles.Text = "Debitos a reclamar";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(1145, 267);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // pnlEventos
            // 
            this.pnlEventos.Controls.Add(this.dockPanel2_Container);
            this.pnlEventos.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.pnlEventos.FloatVertical = true;
            this.pnlEventos.ID = new System.Guid("efa8af96-68e6-4b71-946c-f03fbb086451");
            this.pnlEventos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pnlEventos.ImageOptions.Image")));
            this.pnlEventos.Location = new System.Drawing.Point(3, 26);
            this.pnlEventos.Name = "pnlEventos";
            this.pnlEventos.Options.ShowCloseButton = false;
            this.pnlEventos.OriginalSize = new System.Drawing.Size(1145, 204);
            this.pnlEventos.Size = new System.Drawing.Size(1145, 267);
            this.pnlEventos.Text = "Eventos ";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1145, 267);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // bgwEmiteFactura
            // 
            this.bgwEmiteFactura.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEmiteFactura_DoWork);
            this.bgwEmiteFactura.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwEmiteFactura_RunWorkerCompleted);
            // 
            // Frm_Reclamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 523);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.pnlReclamo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Frm_Reclamo.IconOptions.Image")));
            this.MinimizeBox = false;
            this.Name = "Frm_Reclamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reclamo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ComprobanteElectronico_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_ComprobanteElectronico_FormClosed);
            this.Shown += new System.EventHandler(this.Frm_ComprobanteElectronico_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.pnlReclamo.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcUrgencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcUrgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestataria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.pnlDetalles.ResumeLayout(false);
            this.pnlEventos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposAlicsiva;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheck;
        private System.ComponentModel.BackgroundWorker bgwEmiteFactura;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel pnlDetalles;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel pnlEventos;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel pnlReclamo;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit datInicio;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblEstado;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TrackBarControl trcUrgencia;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbPrestataria;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn cmNombre;
        private DevExpress.XtraGrid.Columns.GridColumn cmCuit;
        private DevExpress.XtraGrid.Columns.GridColumn cmIva;
        private DevExpress.XtraGrid.Columns.GridColumn cmAbreviatura;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
    }
}