namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    partial class Frm_GeneradorLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GeneradorLiquidacion));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPrestatarias = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.dateFecha = new DevExpress.XtraEditors.DateEdit();
            this.cmbTipocomprobante = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cmbTipocomprobanteInt = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.radTipo = new DevExpress.XtraEditors.RadioGroup();
            this.bgwCargar = new System.ComponentModel.BackgroundWorker();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tglSepararRI = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestatarias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipocomprobante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipocomprobanteInt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglSepararRI.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tableLayoutPanel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 211);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(576, 93);
            this.panelControl1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnAplicar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(576, 93);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(165)))), ((int)(((byte)(194)))));
            this.btnAplicar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(415, 3);
            this.btnAplicar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnAplicar.Size = new System.Drawing.Size(158, 78);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Generar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(576, 211);
            this.panelControl2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.68702F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbPrestatarias, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateFecha, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTipocomprobante, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbTipocomprobanteInt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.radTipo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tglSepararRI, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 211);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(3, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(135, 15);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Prestataria";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(135, 15);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Fecha";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(135, 15);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Ambulatorio";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl6.Location = new System.Drawing.Point(3, 118);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(135, 15);
            this.labelControl6.StyleController = this.styleLabels;
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Internación";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl5.Location = new System.Drawing.Point(3, 154);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(135, 15);
            this.labelControl5.StyleController = this.styleLabels;
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Tipo Impresión";
            // 
            // cmbPrestatarias
            // 
            this.cmbPrestatarias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrestatarias.EditValue = 0;
            this.cmbPrestatarias.Location = new System.Drawing.Point(144, 6);
            this.cmbPrestatarias.Name = "cmbPrestatarias";
            this.cmbPrestatarias.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPrestatarias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrestatarias.Properties.DisplayMember = "PrestadoraCompleta";
            this.cmbPrestatarias.Properties.NullText = "";
            this.cmbPrestatarias.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbPrestatarias.Properties.ValueMember = "IDRegistro";
            this.cmbPrestatarias.Size = new System.Drawing.Size(429, 24);
            this.cmbPrestatarias.StyleController = this.styleText;
            this.cmbPrestatarias.TabIndex = 14;
            this.cmbPrestatarias.EditValueChanged += new System.EventHandler(this.cmbPrestatarias_EditValueChanged);
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
            this.colCodigo,
            this.colDescripcion,
            this.colAbreviatura});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Nombre";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colAbreviatura
            // 
            this.colAbreviatura.Caption = "Abreviado";
            this.colAbreviatura.FieldName = "Abreviatura";
            this.colAbreviatura.Name = "colAbreviatura";
            this.colAbreviatura.Visible = true;
            this.colAbreviatura.VisibleIndex = 2;
            // 
            // styleText
            // 
            this.styleText.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.styleText.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.Appearance.Options.UseBorderColor = true;
            this.styleText.Appearance.Options.UseFont = true;
            this.styleText.AppearanceDisabled.BackColor = System.Drawing.Color.Silver;
            this.styleText.AppearanceDisabled.Options.UseBackColor = true;
            this.styleText.AppearanceFocused.BorderColor = System.Drawing.Color.Goldenrod;
            this.styleText.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.AppearanceFocused.Options.UseBorderColor = true;
            this.styleText.AppearanceFocused.Options.UseFont = true;
            this.styleText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // dateFecha
            // 
            this.dateFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFecha.EditValue = null;
            this.dateFecha.Location = new System.Drawing.Point(144, 42);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dateFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFecha.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.dateFecha.Properties.Mask.EditMask = "MM-yyyy";
            this.dateFecha.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateFecha.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateFecha.Size = new System.Drawing.Size(429, 24);
            this.dateFecha.StyleController = this.styleText;
            this.dateFecha.TabIndex = 15;
            this.dateFecha.TextChanged += new System.EventHandler(this.dateFecha_TextChanged);
            // 
            // cmbTipocomprobante
            // 
            this.cmbTipocomprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipocomprobante.EditValue = "";
            this.cmbTipocomprobante.Location = new System.Drawing.Point(144, 78);
            this.cmbTipocomprobante.Name = "cmbTipocomprobante";
            this.cmbTipocomprobante.Properties.AllowMultiSelect = true;
            this.cmbTipocomprobante.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbTipocomprobante.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipocomprobante.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(1)), "Facturación mensual ambulatoria", ((byte)(0))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(7)), "Refacturación diferencia de aranceles ambulatorio", ((byte)(3))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(2)), "Facturación fuera de término ambulatorio", ((byte)(5)))});
            this.cmbTipocomprobante.Size = new System.Drawing.Size(429, 24);
            this.cmbTipocomprobante.StyleController = this.styleText;
            this.cmbTipocomprobante.TabIndex = 16;
            this.cmbTipocomprobante.TextChanged += new System.EventHandler(this.cmbTipocomprobante_TextChanged);
            this.cmbTipocomprobante.Validated += new System.EventHandler(this.cmbTipocomprobante_Validated);
            // 
            // cmbTipocomprobanteInt
            // 
            this.cmbTipocomprobanteInt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipocomprobanteInt.EditValue = "";
            this.cmbTipocomprobanteInt.Location = new System.Drawing.Point(144, 114);
            this.cmbTipocomprobanteInt.Name = "cmbTipocomprobanteInt";
            this.cmbTipocomprobanteInt.Properties.AllowMultiSelect = true;
            this.cmbTipocomprobanteInt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbTipocomprobanteInt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipocomprobanteInt.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(3)), "Facturación mensual internación", ((byte)(1))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(6)), "Facturación Covid-19", ((byte)(2))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(8)), "Refacturación diferencia de aranceles internación", ((byte)(4))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(4)), "Facturación fuera de término internación", ((byte)(6)))});
            this.cmbTipocomprobanteInt.Size = new System.Drawing.Size(429, 24);
            this.cmbTipocomprobanteInt.StyleController = this.styleText;
            this.cmbTipocomprobanteInt.TabIndex = 17;
            this.cmbTipocomprobanteInt.TextChanged += new System.EventHandler(this.cmbTipocomprobanteInt_TextChanged);
            this.cmbTipocomprobanteInt.Validated += new System.EventHandler(this.cmbTipocomprobante_Validated);
            // 
            // radTipo
            // 
            this.radTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTipo.EditValue = true;
            this.radTipo.Location = new System.Drawing.Point(144, 147);
            this.radTipo.Name = "radTipo";
            this.radTipo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Prestatrias", true, null, "Prestatrias"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Interno", true, null, "Interno")});
            this.radTipo.Size = new System.Drawing.Size(429, 30);
            this.radTipo.TabIndex = 18;
            this.radTipo.SelectedIndexChanged += new System.EventHandler(this.radTipo_SelectedIndexChanged);
            // 
            // bgwCargar
            // 
            this.bgwCargar.WorkerSupportsCancellation = true;
            this.bgwCargar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCargar_DoWork);
            this.bgwCargar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCargar_RunWorkerCompleted);
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(3, 188);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(135, 15);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Separar RI";
            // 
            // tglSepararRI
            // 
            this.tglSepararRI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tglSepararRI.Location = new System.Drawing.Point(144, 186);
            this.tglSepararRI.Name = "tglSepararRI";
            this.tglSepararRI.Properties.OffText = "No";
            this.tglSepararRI.Properties.OnText = "Si";
            this.tglSepararRI.Size = new System.Drawing.Size(429, 18);
            this.tglSepararRI.TabIndex = 20;
            // 
            // Frm_GeneradorLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 304);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Frm_GeneradorLiquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Liquidaciones";
            this.Shown += new System.EventHandler(this.Frm_GeneradorLiquidacion_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestatarias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipocomprobante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipocomprobanteInt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglSepararRI.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private System.ComponentModel.BackgroundWorker bgwCargar;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbPrestatarias;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colAbreviatura;
        private DevExpress.XtraEditors.DateEdit dateFecha;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbTipocomprobante;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbTipocomprobanteInt;
        private DevExpress.XtraEditors.RadioGroup radTipo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ToggleSwitch tglSepararRI;
    }
}