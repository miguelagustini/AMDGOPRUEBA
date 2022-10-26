namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    partial class Frm_PFacturaUnica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PFacturaUnica));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.datFechafact = new DevExpress.XtraEditors.DateEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPrestataria = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDregistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDprestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidiva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.datFecha = new DevExpress.XtraEditors.DateEdit();
            this.cmbTipo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbPventa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.DSDatos = new AMDGOINT.Datos.DSDatos();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDdetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposPeriodo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposTextos = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtNroComprob = new DevExpress.XtraEditors.TextEdit();
            this.btnGenerar = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datFechafact.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechafact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestataria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPventa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroComprob.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.25532F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.74468F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 376);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Appearance.Options.UseBackColor = true;
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlTop, 2);
            this.pnlTop.Controls.Add(this.tableLayoutPanel2);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(787, 291);
            this.pnlTop.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.5849F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.98113F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.056602F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.11321F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.03774F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.22642F));
            this.tableLayoutPanel2.Controls.Add(this.datFechafact, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl8, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbPrestataria, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.datFecha, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbTipo, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbPventa, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.gridControl, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelControl6, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtNroComprob, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(787, 291);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // datFechafact
            // 
            this.datFechafact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datFechafact.EditValue = null;
            this.datFechafact.EnterMoveNextControl = true;
            this.datFechafact.Location = new System.Drawing.Point(313, 80);
            this.datFechafact.Name = "datFechafact";
            this.datFechafact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFechafact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFechafact.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFechafact.Size = new System.Drawing.Size(136, 24);
            this.datFechafact.StyleController = this.styleText;
            this.datFechafact.TabIndex = 5;
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
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl8.Location = new System.Drawing.Point(242, 83);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(65, 18);
            this.labelControl8.StyleController = this.styleLabels;
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Emitido";
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl5.Location = new System.Drawing.Point(3, 116);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(100, 18);
            this.labelControl5.StyleController = this.styleLabels;
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Detalles";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(242, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tipo";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(455, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(120, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Punto Venta";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(3, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(100, 18);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Prestataria";
            // 
            // cmbPrestataria
            // 
            this.cmbPrestataria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbPrestataria, 5);
            this.cmbPrestataria.EnterMoveNextControl = true;
            this.cmbPrestataria.Location = new System.Drawing.Point(109, 43);
            this.cmbPrestataria.Name = "cmbPrestataria";
            this.cmbPrestataria.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPrestataria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrestataria.Properties.DisplayMember = "Prestataria";
            this.cmbPrestataria.Properties.NullText = "";
            this.cmbPrestataria.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbPrestataria.Properties.ValueMember = "ID_Registro";
            this.cmbPrestataria.Size = new System.Drawing.Size(675, 24);
            this.cmbPrestataria.StyleController = this.styleText;
            this.cmbPrestataria.TabIndex = 3;
            this.cmbPrestataria.TextChanged += new System.EventHandler(this.cmbPrestataria_TextChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit1View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDregistro,
            this.colIDprestataria,
            this.colCodigo,
            this.colPrestataria,
            this.colCuit,
            this.colDomicilio,
            this.colIva,
            this.colidiva});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIDregistro
            // 
            this.colIDregistro.Caption = "ID_Registro";
            this.colIDregistro.FieldName = "ID_Registro";
            this.colIDregistro.Name = "colIDregistro";
            this.colIDregistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colIDprestataria
            // 
            this.colIDprestataria.Caption = "ID_Prestataria";
            this.colIDprestataria.FieldName = "ID_Prestataria";
            this.colIDprestataria.Name = "colIDprestataria";
            this.colIDprestataria.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            this.colCodigo.Width = 212;
            // 
            // colPrestataria
            // 
            this.colPrestataria.Caption = "Prestataria";
            this.colPrestataria.FieldName = "Prestataria";
            this.colPrestataria.Name = "colPrestataria";
            this.colPrestataria.Visible = true;
            this.colPrestataria.VisibleIndex = 1;
            this.colPrestataria.Width = 212;
            // 
            // colCuit
            // 
            this.colCuit.AppearanceCell.Options.UseTextOptions = true;
            this.colCuit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCuit.AppearanceHeader.Options.UseTextOptions = true;
            this.colCuit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCuit.Caption = "Cuit";
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.VisibleIndex = 2;
            this.colCuit.Width = 212;
            // 
            // colDomicilio
            // 
            this.colDomicilio.Caption = "Domicilio";
            this.colDomicilio.FieldName = "Domicilio";
            this.colDomicilio.Name = "colDomicilio";
            this.colDomicilio.Visible = true;
            this.colDomicilio.VisibleIndex = 3;
            this.colDomicilio.Width = 299;
            // 
            // colIva
            // 
            this.colIva.AppearanceCell.Options.UseTextOptions = true;
            this.colIva.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "Iva";
            this.colIva.FieldName = "Iva";
            this.colIva.Name = "colIva";
            this.colIva.Visible = true;
            this.colIva.VisibleIndex = 4;
            this.colIva.Width = 126;
            // 
            // colidiva
            // 
            this.colidiva.Caption = "idiva";
            this.colidiva.FieldName = "idiva";
            this.colidiva.Name = "colidiva";
            this.colidiva.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // datFecha
            // 
            this.datFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datFecha.EditValue = null;
            this.datFecha.Enabled = false;
            this.datFecha.Location = new System.Drawing.Point(109, 6);
            this.datFecha.Name = "datFecha";
            this.datFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Size = new System.Drawing.Size(127, 24);
            this.datFecha.StyleController = this.styleText;
            this.datFecha.TabIndex = 0;
            this.datFecha.TabStop = false;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.EnterMoveNextControl = true;
            this.cmbTipo.Location = new System.Drawing.Point(313, 6);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTipo.Size = new System.Drawing.Size(136, 24);
            this.cmbTipo.StyleController = this.styleText;
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.TextChanged += new System.EventHandler(this.cmbTipo_TextChanged);
            // 
            // cmbPventa
            // 
            this.cmbPventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPventa.EnterMoveNextControl = true;
            this.cmbPventa.Location = new System.Drawing.Point(581, 6);
            this.cmbPventa.Name = "cmbPventa";
            this.cmbPventa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPventa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPventa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPventa.Size = new System.Drawing.Size(203, 24);
            this.cmbPventa.StyleController = this.styleText;
            this.cmbPventa.TabIndex = 2;
            // 
            // gridControl
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gridControl, 6);
            this.gridControl.DataMember = "FacturaDetalle";
            this.gridControl.DataSource = this.DSDatos;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 142);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes,
            this.reposTextos,
            this.reposPeriodo});
            this.tableLayoutPanel2.SetRowSpan(this.gridControl, 4);
            this.gridControl.Size = new System.Drawing.Size(781, 128);
            this.gridControl.TabIndex = 10;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // DSDatos
            // 
            this.DSDatos.DataSetName = "DSDatos";
            this.DSDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDdetalle,
            this.colPeriodo,
            this.colDescripcion,
            this.colImporte});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.Save;
            this.gridView.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsView.EnableAppearanceOddRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colIDdetalle
            // 
            this.colIDdetalle.Caption = "IDDetalle";
            this.colIDdetalle.FieldName = "ID_Registro";
            this.colIDdetalle.Name = "colIDdetalle";
            this.colIDdetalle.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Período";
            this.colPeriodo.ColumnEdit = this.reposPeriodo;
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colPeriodo.ImageOptions.Image")));
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 0;
            this.colPeriodo.Width = 143;
            // 
            // reposPeriodo
            // 
            this.reposPeriodo.AutoHeight = false;
            this.reposPeriodo.Mask.EditMask = "\\d{4}\\/\\d{3}";
            this.reposPeriodo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposPeriodo.Name = "reposPeriodo";
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.ColumnEdit = this.reposTextos;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colDescripcion.ImageOptions.Image")));
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 790;
            // 
            // reposTextos
            // 
            this.reposTextos.AutoHeight = false;
            this.reposTextos.Mask.EditMask = "[^\']*";
            this.reposTextos.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposTextos.Mask.UseMaskAsDisplayFormat = true;
            this.reposTextos.Name = "reposTextos";
            // 
            // colImporte
            // 
            this.colImporte.AppearanceCell.Options.UseTextOptions = true;
            this.colImporte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporte.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporte.Caption = "Importe";
            this.colImporte.ColumnEdit = this.reposImportes;
            this.colImporte.FieldName = "Importe";
            this.colImporte.ImageOptions.Alignment = System.Drawing.StringAlignment.Far;
            this.colImporte.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colImporte.ImageOptions.Image")));
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "$ {0:#.##}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            this.colImporte.Width = 130;
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "n2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tableLayoutPanel2.SetColumnSpan(this.labelControl6, 4);
            this.labelControl6.Location = new System.Drawing.Point(109, 116);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(466, 18);
            this.labelControl6.StyleController = this.styleLabels;
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "F2: Nuevo detalle. / Enter: Editar. / F3 Borrar detalle.";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl7.Location = new System.Drawing.Point(3, 83);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(100, 18);
            this.labelControl7.StyleController = this.styleLabels;
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Comprobante";
            // 
            // txtNroComprob
            // 
            this.txtNroComprob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroComprob.EnterMoveNextControl = true;
            this.txtNroComprob.Location = new System.Drawing.Point(109, 80);
            this.txtNroComprob.Name = "txtNroComprob";
            this.txtNroComprob.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNroComprob.Properties.Mask.EditMask = "########;";
            this.txtNroComprob.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNroComprob.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNroComprob.Properties.MaxLength = 8;
            this.txtNroComprob.Size = new System.Drawing.Size(127, 24);
            this.txtNroComprob.StyleController = this.styleText;
            this.txtNroComprob.TabIndex = 4;
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
            this.btnGenerar.Location = new System.Drawing.Point(617, 300);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGenerar.Size = new System.Drawing.Size(173, 73);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // Frm_PFacturaUnica
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 376);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(522, 273);
            this.Name = "Frm_PFacturaUnica";
            this.Text = "Comprobante Manual";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datFechafact.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechafact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestataria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPventa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroComprob.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbPrestataria;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.DateEdit datFecha;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipo;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPventa;
        private DevExpress.XtraEditors.SimpleButton btnGenerar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn colIDregistro;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestataria;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colIDprestataria;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colIDdetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposTextos;
        private Datos.DSDatos DSDatos;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colidiva;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtNroComprob;
        private DevExpress.XtraEditors.DateEdit datFechafact;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}