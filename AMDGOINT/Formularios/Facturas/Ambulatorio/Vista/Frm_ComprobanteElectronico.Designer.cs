namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    partial class Frm_ComprobanteElectronico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ComprobanteElectronico));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbIvaPrestataria = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.cmbIvaPrestador = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbProfesional = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEntidadCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidadcuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfpvta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntidadIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPrestadora = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrestatariaplan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadoraabre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadoracuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestadoraIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbComprobante = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCuitPrestador = new DevExpress.XtraEditors.TextEdit();
            this.txtCuitPrestadora = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtPventa = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtIvaporc = new DevExpress.XtraEditors.TextEdit();
            this.chkCompAnuladoPrest = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldFechaPractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemotext = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.coldCodigoPractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldDescripcionPractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldFuncion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldDocumentoPaciente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldNombrePaciente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDecimales = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.coldPrecioUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldPorcentajeIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposAlicuotas = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.coldNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldNoGravado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldtotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.bgwEmiteFactura = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIvaPrestataria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIvaPrestador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProfesional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestadora.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComprobante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuitPrestador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuitPrestadora.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPventa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIvaporc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompAnuladoPrest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemotext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposAlicuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnGenerar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(985, 499);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Appearance.Options.UseFont = true;
            this.btnGenerar.AppearanceHovered.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGenerar.AppearanceHovered.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.AppearanceHovered.Options.UseBackColor = true;
            this.btnGenerar.AppearanceHovered.Options.UseFont = true;
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGenerar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.ImageOptions.Image")));
            this.btnGenerar.Location = new System.Drawing.Point(787, 441);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGenerar.Size = new System.Drawing.Size(195, 55);
            this.btnGenerar.TabIndex = 11;
            this.btnGenerar.Text = "Generar comprobante";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(145)))));
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(979, 140);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Encabezado";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.25411F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.678245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.06764F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.Controls.Add(this.cmbIvaPrestataria, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbIvaPrestador, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl6, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbProfesional, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbPrestadora, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbComprobante, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCuitPrestador, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCuitPrestadora, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl8, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPventa, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl9, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtIvaporc, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkCompAnuladoPrest, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(975, 120);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cmbIvaPrestataria
            // 
            this.cmbIvaPrestataria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIvaPrestataria.EditValue = ((short)(0));
            this.cmbIvaPrestataria.Enabled = false;
            this.cmbIvaPrestataria.EnterMoveNextControl = true;
            this.cmbIvaPrestataria.Location = new System.Drawing.Point(671, 44);
            this.cmbIvaPrestataria.Name = "cmbIvaPrestataria";
            this.cmbIvaPrestataria.Properties.AllowFocused = false;
            this.cmbIvaPrestataria.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmbIvaPrestataria.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbIvaPrestataria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbIvaPrestataria.Properties.DisplayMember = "Descripcion";
            this.cmbIvaPrestataria.Properties.NullText = "";
            this.cmbIvaPrestataria.Properties.PopupView = this.gridView2;
            this.cmbIvaPrestataria.Properties.ValueMember = "IDRegistro";
            this.cmbIvaPrestataria.Size = new System.Drawing.Size(153, 24);
            this.cmbIvaPrestataria.StyleController = this.styleText;
            this.cmbIvaPrestataria.TabIndex = 28;
            this.cmbIvaPrestataria.TabStop = false;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
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
            // cmbIvaPrestador
            // 
            this.cmbIvaPrestador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIvaPrestador.EditValue = ((short)(0));
            this.cmbIvaPrestador.Enabled = false;
            this.cmbIvaPrestador.EnterMoveNextControl = true;
            this.cmbIvaPrestador.Location = new System.Drawing.Point(671, 7);
            this.cmbIvaPrestador.Name = "cmbIvaPrestador";
            this.cmbIvaPrestador.Properties.AllowFocused = false;
            this.cmbIvaPrestador.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmbIvaPrestador.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbIvaPrestador.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbIvaPrestador.Properties.DisplayMember = "Descripcion";
            this.cmbIvaPrestador.Properties.NullText = "";
            this.cmbIvaPrestador.Properties.PopupView = this.gridView1;
            this.cmbIvaPrestador.Properties.ValueMember = "IDRegistro";
            this.cmbIvaPrestador.Size = new System.Drawing.Size(153, 24);
            this.cmbIvaPrestador.StyleController = this.styleText;
            this.cmbIvaPrestador.TabIndex = 27;
            this.cmbIvaPrestador.TabStop = false;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl7.Location = new System.Drawing.Point(3, 10);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(105, 18);
            this.labelControl7.StyleController = this.styleLabels;
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Profesional";
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
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Prestadora";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(446, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Cuit";
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
            this.labelControl2.Location = new System.Drawing.Point(3, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "Comprobante";
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
            this.labelControl4.Location = new System.Drawing.Point(446, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 18);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Cuit";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl6.Location = new System.Drawing.Point(638, 47);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(27, 18);
            this.labelControl6.StyleController = this.styleLabels;
            this.labelControl6.TabIndex = 21;
            this.labelControl6.Text = "Iva";
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
            this.labelControl5.Location = new System.Drawing.Point(638, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 18);
            this.labelControl5.StyleController = this.styleLabels;
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "Iva";
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProfesional.EditValue = 0;
            this.cmbProfesional.EnterMoveNextControl = true;
            this.cmbProfesional.Location = new System.Drawing.Point(114, 7);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmbProfesional.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbProfesional.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProfesional.Properties.DisplayMember = "ProfesionalCompleto";
            this.cmbProfesional.Properties.NullText = "";
            this.cmbProfesional.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbProfesional.Properties.ValueMember = "IDCuenta";
            this.cmbProfesional.Size = new System.Drawing.Size(326, 24);
            this.cmbProfesional.StyleController = this.styleText;
            this.cmbProfesional.TabIndex = 0;
            this.cmbProfesional.EditValueChanged += new System.EventHandler(this.cmbProfesional_EditValueChanged);
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
            this.colEntidadCuenta,
            this.colEntidad,
            this.colEntidadcuit,
            this.colProfpvta,
            this.colEntidadIva});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colEntidadCuenta
            // 
            this.colEntidadCuenta.Caption = "Cuenta";
            this.colEntidadCuenta.FieldName = "CodigoCuenta";
            this.colEntidadCuenta.Name = "colEntidadCuenta";
            this.colEntidadCuenta.Visible = true;
            this.colEntidadCuenta.VisibleIndex = 0;
            // 
            // colEntidad
            // 
            this.colEntidad.Caption = "Nombre";
            this.colEntidad.FieldName = "Profesional";
            this.colEntidad.Name = "colEntidad";
            this.colEntidad.Visible = true;
            this.colEntidad.VisibleIndex = 1;
            // 
            // colEntidadcuit
            // 
            this.colEntidadcuit.AppearanceCell.Options.UseTextOptions = true;
            this.colEntidadcuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colEntidadcuit.Caption = "Cuit";
            this.colEntidadcuit.FieldName = "Cuit";
            this.colEntidadcuit.Name = "colEntidadcuit";
            this.colEntidadcuit.Visible = true;
            this.colEntidadcuit.VisibleIndex = 2;
            // 
            // colProfpvta
            // 
            this.colProfpvta.AppearanceCell.Options.UseTextOptions = true;
            this.colProfpvta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colProfpvta.Caption = "Punto Venta";
            this.colProfpvta.FieldName = "PuntoVenta";
            this.colProfpvta.Name = "colProfpvta";
            this.colProfpvta.Visible = true;
            this.colProfpvta.VisibleIndex = 3;
            // 
            // colEntidadIva
            // 
            this.colEntidadIva.Caption = "Iva";
            this.colEntidadIva.FieldName = "Iva";
            this.colEntidadIva.Name = "colEntidadIva";
            this.colEntidadIva.Visible = true;
            this.colEntidadIva.VisibleIndex = 4;
            // 
            // cmbPrestadora
            // 
            this.cmbPrestadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrestadora.EditValue = 0;
            this.cmbPrestadora.EnterMoveNextControl = true;
            this.cmbPrestadora.Location = new System.Drawing.Point(114, 44);
            this.cmbPrestadora.Name = "cmbPrestadora";
            this.cmbPrestadora.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmbPrestadora.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPrestadora.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrestadora.Properties.DisplayMember = "PrestadoraCompleta";
            this.cmbPrestadora.Properties.NullText = "";
            this.cmbPrestadora.Properties.PopupView = this.searchLookUpEdit2View;
            this.cmbPrestadora.Properties.ValueMember = "IDPrestatariaCuenta";
            this.cmbPrestadora.Size = new System.Drawing.Size(326, 24);
            this.cmbPrestadora.StyleController = this.styleText;
            this.cmbPrestadora.TabIndex = 1;
            this.cmbPrestadora.EditValueChanged += new System.EventHandler(this.cmbPrestadora_EditValueChanged);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.searchLookUpEdit2View.Appearance.EvenRow.Options.UseBackColor = true;
            this.searchLookUpEdit2View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit2View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit2View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit2View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.searchLookUpEdit2View.Appearance.FocusedCell.Options.UseFont = true;
            this.searchLookUpEdit2View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.searchLookUpEdit2View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit2View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit2View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit2View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.searchLookUpEdit2View.Appearance.FocusedRow.Options.UseFont = true;
            this.searchLookUpEdit2View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.searchLookUpEdit2View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit2View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit2View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit2View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit2View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit2View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.searchLookUpEdit2View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit2View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.searchLookUpEdit2View.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit2View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit2View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit2View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit2View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit2View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.searchLookUpEdit2View.Appearance.SelectedRow.Options.UseFont = true;
            this.searchLookUpEdit2View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.searchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrestatariaplan,
            this.colPrestadora,
            this.colPrestadoraabre,
            this.colPrestadoracuit,
            this.colPrestadoraIva});
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit2View.OptionsView.ShowIndicator = false;
            // 
            // colPrestatariaplan
            // 
            this.colPrestatariaplan.Caption = "Cuenta";
            this.colPrestatariaplan.FieldName = "CodigoPlan";
            this.colPrestatariaplan.Name = "colPrestatariaplan";
            this.colPrestatariaplan.Visible = true;
            this.colPrestatariaplan.VisibleIndex = 0;
            // 
            // colPrestadora
            // 
            this.colPrestadora.Caption = "Prestadora";
            this.colPrestadora.FieldName = "Prestataria";
            this.colPrestadora.Name = "colPrestadora";
            this.colPrestadora.Visible = true;
            this.colPrestadora.VisibleIndex = 1;
            // 
            // colPrestadoraabre
            // 
            this.colPrestadoraabre.Caption = "Apodo";
            this.colPrestadoraabre.FieldName = "Abreviatura";
            this.colPrestadoraabre.Name = "colPrestadoraabre";
            this.colPrestadoraabre.Visible = true;
            this.colPrestadoraabre.VisibleIndex = 2;
            // 
            // colPrestadoracuit
            // 
            this.colPrestadoracuit.AppearanceCell.Options.UseTextOptions = true;
            this.colPrestadoracuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPrestadoracuit.Caption = "Cuit";
            this.colPrestadoracuit.FieldName = "Cuit";
            this.colPrestadoracuit.Name = "colPrestadoracuit";
            this.colPrestadoracuit.Visible = true;
            this.colPrestadoracuit.VisibleIndex = 3;
            // 
            // colPrestadoraIva
            // 
            this.colPrestadoraIva.Caption = "Iva";
            this.colPrestadoraIva.FieldName = "Iva";
            this.colPrestadoraIva.Name = "colPrestadoraIva";
            this.colPrestadoraIva.Visible = true;
            this.colPrestadoraIva.VisibleIndex = 4;
            // 
            // cmbComprobante
            // 
            this.cmbComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbComprobante.EnterMoveNextControl = true;
            this.cmbComprobante.Location = new System.Drawing.Point(114, 80);
            this.cmbComprobante.Name = "cmbComprobante";
            this.cmbComprobante.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbComprobante.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComprobante.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbComprobante.Size = new System.Drawing.Size(326, 24);
            this.cmbComprobante.StyleController = this.styleText;
            this.cmbComprobante.TabIndex = 2;
            this.cmbComprobante.SelectedValueChanged += new System.EventHandler(this.cmbComprobante_SelectedValueChanged);
            // 
            // txtCuitPrestador
            // 
            this.txtCuitPrestador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuitPrestador.Enabled = false;
            this.txtCuitPrestador.Location = new System.Drawing.Point(486, 7);
            this.txtCuitPrestador.Name = "txtCuitPrestador";
            this.txtCuitPrestador.Properties.AllowFocused = false;
            this.txtCuitPrestador.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCuitPrestador.Size = new System.Drawing.Size(146, 24);
            this.txtCuitPrestador.StyleController = this.styleText;
            this.txtCuitPrestador.TabIndex = 25;
            this.txtCuitPrestador.TabStop = false;
            // 
            // txtCuitPrestadora
            // 
            this.txtCuitPrestadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuitPrestadora.Enabled = false;
            this.txtCuitPrestadora.Location = new System.Drawing.Point(486, 44);
            this.txtCuitPrestadora.Name = "txtCuitPrestadora";
            this.txtCuitPrestadora.Properties.AllowFocused = false;
            this.txtCuitPrestadora.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCuitPrestadora.Size = new System.Drawing.Size(146, 24);
            this.txtCuitPrestadora.StyleController = this.styleText;
            this.txtCuitPrestadora.TabIndex = 26;
            this.txtCuitPrestadora.TabStop = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl8.Location = new System.Drawing.Point(830, 10);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(54, 18);
            this.labelControl8.StyleController = this.styleLabels;
            this.labelControl8.TabIndex = 29;
            this.labelControl8.Text = "P. Venta";
            // 
            // txtPventa
            // 
            this.txtPventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPventa.Enabled = false;
            this.txtPventa.Location = new System.Drawing.Point(890, 7);
            this.txtPventa.Name = "txtPventa";
            this.txtPventa.Properties.AllowFocused = false;
            this.txtPventa.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtPventa.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPventa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPventa.Size = new System.Drawing.Size(82, 24);
            this.txtPventa.StyleController = this.styleText;
            this.txtPventa.TabIndex = 30;
            this.txtPventa.TabStop = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl9.Location = new System.Drawing.Point(830, 47);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(54, 18);
            this.labelControl9.StyleController = this.styleLabels;
            this.labelControl9.TabIndex = 31;
            this.labelControl9.Text = "% Iva";
            // 
            // txtIvaporc
            // 
            this.txtIvaporc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIvaporc.Enabled = false;
            this.txtIvaporc.Location = new System.Drawing.Point(890, 44);
            this.txtIvaporc.Name = "txtIvaporc";
            this.txtIvaporc.Properties.AllowFocused = false;
            this.txtIvaporc.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtIvaporc.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIvaporc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtIvaporc.Size = new System.Drawing.Size(82, 24);
            this.txtIvaporc.StyleController = this.styleText;
            this.txtIvaporc.TabIndex = 32;
            this.txtIvaporc.TabStop = false;
            // 
            // chkCompAnuladoPrest
            // 
            this.chkCompAnuladoPrest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.chkCompAnuladoPrest, 4);
            this.chkCompAnuladoPrest.Enabled = false;
            this.chkCompAnuladoPrest.Location = new System.Drawing.Point(446, 81);
            this.chkCompAnuladoPrest.Name = "chkCompAnuladoPrest";
            this.chkCompAnuladoPrest.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.chkCompAnuladoPrest.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.chkCompAnuladoPrest.Properties.Caption = "Comprobante anulado por la prestadora";
            this.chkCompAnuladoPrest.Size = new System.Drawing.Size(378, 22);
            this.chkCompAnuladoPrest.StyleController = this.styleLabels;
            this.chkCompAnuladoPrest.TabIndex = 33;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(145)))));
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.gridControl);
            buttonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions1.Image")));
            buttonImageOptions1.Location = DevExpress.XtraEditors.ButtonPanel.ImageLocation.AfterText;
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipItem1.Text = "Selección de reclamos disponibles para éste profesional y prestataria.";
            superToolTip1.Items.Add(toolTipItem1);
            this.groupControl2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Reclamos", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, superToolTip1, true, false, true, "RECLAMOS", -1)});
            this.groupControl2.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 149);
            this.groupControl2.LookAndFeel.SkinName = "Office 2013";
            this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(979, 286);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Detalles";
            this.groupControl2.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl2_CustomButtonClick);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 25);
            this.gridControl.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposDecimales,
            this.reposAlicuotas,
            this.reposMemotext});
            this.gridControl.Size = new System.Drawing.Size(975, 259);
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
            this.coldFechaPractica,
            this.colDescripcion,
            this.coldCodigoPractica,
            this.coldDescripcionPractica,
            this.coldFuncion,
            this.coldDocumentoPaciente,
            this.coldNombrePaciente,
            this.coldCantidad,
            this.coldPrecioUnitario,
            this.coldPorcentajeIva,
            this.coldNeto,
            this.coldNoGravado,
            this.coldIva,
            this.coldtotal,
            this.colSeleccion});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView_CustomSummaryCalculate);
            this.gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_SelectionChanged);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // coldFechaPractica
            // 
            this.coldFechaPractica.Caption = "Fecha";
            this.coldFechaPractica.FieldName = "FechaPract";
            this.coldFechaPractica.Name = "coldFechaPractica";
            this.coldFechaPractica.OptionsColumn.AllowEdit = false;
            this.coldFechaPractica.OptionsColumn.AllowFocus = false;
            this.coldFechaPractica.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldFechaPractica.Visible = true;
            this.coldFechaPractica.VisibleIndex = 1;
            this.coldFechaPractica.Width = 99;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.ColumnEdit = this.reposMemotext;
            this.colDescripcion.FieldName = "DescripcionManual";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsEditForm.ColumnSpan = 3;
            this.colDescripcion.OptionsEditForm.RowSpan = 3;
            this.colDescripcion.OptionsEditForm.UseEditorColRowSpan = false;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 2;
            this.colDescripcion.Width = 118;
            // 
            // reposMemotext
            // 
            this.reposMemotext.MaxLength = 300;
            this.reposMemotext.Name = "reposMemotext";
            this.reposMemotext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reposTexto_KeyDown);
            // 
            // coldCodigoPractica
            // 
            this.coldCodigoPractica.Caption = "Cod. Práctica";
            this.coldCodigoPractica.FieldName = "CodPract";
            this.coldCodigoPractica.Name = "coldCodigoPractica";
            this.coldCodigoPractica.OptionsColumn.AllowEdit = false;
            this.coldCodigoPractica.OptionsColumn.AllowFocus = false;
            this.coldCodigoPractica.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldCodigoPractica.Visible = true;
            this.coldCodigoPractica.VisibleIndex = 3;
            this.coldCodigoPractica.Width = 90;
            // 
            // coldDescripcionPractica
            // 
            this.coldDescripcionPractica.Caption = "Práctica";
            this.coldDescripcionPractica.FieldName = "DescrPract";
            this.coldDescripcionPractica.Name = "coldDescripcionPractica";
            this.coldDescripcionPractica.OptionsColumn.AllowEdit = false;
            this.coldDescripcionPractica.OptionsEditForm.ColumnSpan = 3;
            this.coldDescripcionPractica.OptionsEditForm.UseEditorColRowSpan = false;
            this.coldDescripcionPractica.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldDescripcionPractica.Visible = true;
            this.coldDescripcionPractica.VisibleIndex = 4;
            this.coldDescripcionPractica.Width = 90;
            // 
            // coldFuncion
            // 
            this.coldFuncion.Caption = "Funcion";
            this.coldFuncion.FieldName = "Funcion";
            this.coldFuncion.Name = "coldFuncion";
            this.coldFuncion.OptionsColumn.AllowEdit = false;
            this.coldFuncion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldFuncion.Visible = true;
            this.coldFuncion.VisibleIndex = 5;
            this.coldFuncion.Width = 90;
            // 
            // coldDocumentoPaciente
            // 
            this.coldDocumentoPaciente.AppearanceCell.Options.UseTextOptions = true;
            this.coldDocumentoPaciente.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.coldDocumentoPaciente.Caption = "Documento";
            this.coldDocumentoPaciente.FieldName = "DocuPaci";
            this.coldDocumentoPaciente.Name = "coldDocumentoPaciente";
            this.coldDocumentoPaciente.OptionsColumn.AllowEdit = false;
            this.coldDocumentoPaciente.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldDocumentoPaciente.Visible = true;
            this.coldDocumentoPaciente.VisibleIndex = 6;
            this.coldDocumentoPaciente.Width = 90;
            // 
            // coldNombrePaciente
            // 
            this.coldNombrePaciente.Caption = "Paciente";
            this.coldNombrePaciente.FieldName = "NombrePaci";
            this.coldNombrePaciente.Name = "coldNombrePaciente";
            this.coldNombrePaciente.OptionsColumn.AllowEdit = false;
            this.coldNombrePaciente.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldNombrePaciente.Visible = true;
            this.coldNombrePaciente.VisibleIndex = 7;
            this.coldNombrePaciente.Width = 90;
            // 
            // coldCantidad
            // 
            this.coldCantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.coldCantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldCantidad.Caption = "Cantidad";
            this.coldCantidad.ColumnEdit = this.reposDecimales;
            this.coldCantidad.FieldName = "Cantidad";
            this.coldCantidad.Name = "coldCantidad";
            this.coldCantidad.OptionsEditForm.StartNewRow = true;
            this.coldCantidad.Visible = true;
            this.coldCantidad.VisibleIndex = 9;
            this.coldCantidad.Width = 90;
            // 
            // reposDecimales
            // 
            this.reposDecimales.AutoHeight = false;
            this.reposDecimales.Mask.EditMask = "n2";
            this.reposDecimales.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimales.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimales.Name = "reposDecimales";
            // 
            // coldPrecioUnitario
            // 
            this.coldPrecioUnitario.AppearanceHeader.Options.UseTextOptions = true;
            this.coldPrecioUnitario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldPrecioUnitario.Caption = "P. Unitario";
            this.coldPrecioUnitario.ColumnEdit = this.reposDecimales;
            this.coldPrecioUnitario.FieldName = "PrecioUnitario";
            this.coldPrecioUnitario.Name = "coldPrecioUnitario";
            this.coldPrecioUnitario.Visible = true;
            this.coldPrecioUnitario.VisibleIndex = 10;
            this.coldPrecioUnitario.Width = 90;
            // 
            // coldPorcentajeIva
            // 
            this.coldPorcentajeIva.AppearanceCell.Options.UseTextOptions = true;
            this.coldPorcentajeIva.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldPorcentajeIva.AppearanceHeader.Options.UseTextOptions = true;
            this.coldPorcentajeIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldPorcentajeIva.Caption = "Iva %";
            this.coldPorcentajeIva.ColumnEdit = this.reposAlicuotas;
            this.coldPorcentajeIva.DisplayFormat.FormatString = "N2";
            this.coldPorcentajeIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldPorcentajeIva.FieldName = "IvaPorc";
            this.coldPorcentajeIva.Name = "coldPorcentajeIva";
            this.coldPorcentajeIva.Visible = true;
            this.coldPorcentajeIva.VisibleIndex = 8;
            this.coldPorcentajeIva.Width = 90;
            // 
            // reposAlicuotas
            // 
            this.reposAlicuotas.AutoHeight = false;
            this.reposAlicuotas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposAlicuotas.Items.AddRange(new object[] {
            "0,00",
            "10,5",
            "21,00"});
            this.reposAlicuotas.Name = "reposAlicuotas";
            this.reposAlicuotas.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // coldNeto
            // 
            this.coldNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.coldNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldNeto.Caption = "Neto Gravado";
            this.coldNeto.ColumnEdit = this.reposDecimales;
            this.coldNeto.FieldName = "Neto";
            this.coldNeto.Name = "coldNeto";
            this.coldNeto.OptionsColumn.AllowEdit = false;
            this.coldNeto.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldNeto.Visible = true;
            this.coldNeto.VisibleIndex = 11;
            this.coldNeto.Width = 90;
            // 
            // coldNoGravado
            // 
            this.coldNoGravado.AppearanceHeader.Options.UseTextOptions = true;
            this.coldNoGravado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldNoGravado.Caption = "Neto No Gravado";
            this.coldNoGravado.ColumnEdit = this.reposDecimales;
            this.coldNoGravado.FieldName = "NoGravado";
            this.coldNoGravado.Name = "coldNoGravado";
            this.coldNoGravado.OptionsColumn.AllowEdit = false;
            this.coldNoGravado.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldNoGravado.Visible = true;
            this.coldNoGravado.VisibleIndex = 12;
            this.coldNoGravado.Width = 90;
            // 
            // coldIva
            // 
            this.coldIva.AppearanceHeader.Options.UseTextOptions = true;
            this.coldIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldIva.Caption = "Iva $";
            this.coldIva.ColumnEdit = this.reposDecimales;
            this.coldIva.FieldName = "Iva";
            this.coldIva.Name = "coldIva";
            this.coldIva.OptionsColumn.AllowEdit = false;
            this.coldIva.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldIva.Visible = true;
            this.coldIva.VisibleIndex = 13;
            this.coldIva.Width = 90;
            // 
            // coldtotal
            // 
            this.coldtotal.AppearanceHeader.Options.UseTextOptions = true;
            this.coldtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.coldtotal.Caption = "Total";
            this.coldtotal.ColumnEdit = this.reposDecimales;
            this.coldtotal.FieldName = "Total";
            this.coldtotal.Name = "coldtotal";
            this.coldtotal.OptionsColumn.AllowEdit = false;
            this.coldtotal.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.coldtotal.Visible = true;
            this.coldtotal.VisibleIndex = 14;
            this.coldtotal.Width = 118;
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "gridColumn1";
            this.colSeleccion.FieldName = "Seleccionado";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsColumn.AllowEdit = false;
            this.colSeleccion.OptionsColumn.ShowInCustomizationForm = false;
            this.colSeleccion.OptionsColumn.ShowInExpressionEditor = false;
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
            // Frm_ComprobanteElectronico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 499);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_ComprobanteElectronico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante Electrónico Prestadores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ComprobanteElectronico_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_ComprobanteElectronico_FormClosed);
            this.Shown += new System.EventHandler(this.Frm_ComprobanteElectronico_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIvaPrestataria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIvaPrestador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProfesional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestadora.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComprobante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuitPrestador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuitPrestadora.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPventa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIvaporc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompAnuladoPrest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemotext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposAlicuotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbProfesional;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbPrestadora;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.ComboBoxEdit cmbComprobante;
        private DevExpress.XtraEditors.TextEdit txtCuitPrestador;
        private DevExpress.XtraEditors.TextEdit txtCuitPrestadora;
        private DevExpress.XtraEditors.SimpleButton btnGenerar;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbIvaPrestataria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbIvaPrestador;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidadcuit;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidadIva;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadora;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadoraabre;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadoracuit;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestadoraIva;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestatariaplan;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidadCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colProfpvta;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn coldFechaPractica;
        private DevExpress.XtraGrid.Columns.GridColumn coldCodigoPractica;
        private DevExpress.XtraGrid.Columns.GridColumn coldDescripcionPractica;
        private DevExpress.XtraGrid.Columns.GridColumn coldFuncion;
        private DevExpress.XtraGrid.Columns.GridColumn coldDocumentoPaciente;
        private DevExpress.XtraGrid.Columns.GridColumn coldNombrePaciente;
        private DevExpress.XtraGrid.Columns.GridColumn coldCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn coldPrecioUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn coldPorcentajeIva;
        private DevExpress.XtraGrid.Columns.GridColumn coldNeto;
        private DevExpress.XtraGrid.Columns.GridColumn coldNoGravado;
        private DevExpress.XtraGrid.Columns.GridColumn coldIva;
        private DevExpress.XtraGrid.Columns.GridColumn coldtotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimales;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposAlicsiva;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox reposAlicuotas;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtPventa;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtIvaporc;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
        private System.ComponentModel.BackgroundWorker bgwEmiteFactura;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemotext;
        private DevExpress.XtraEditors.CheckEdit chkCompAnuladoPrest;
    }
}