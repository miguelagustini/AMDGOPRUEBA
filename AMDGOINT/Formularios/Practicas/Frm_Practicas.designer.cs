namespace AMDGOINT.Formularios.Practicas
{
    partial class Frm_Practicas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Practicas));
            this.pnlBase = new DevExpress.XtraEditors.PanelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDatos = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cmbFuncion = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fuID_Registro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fuCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fuDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbArancel = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.arIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.arCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.arDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbGasto = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gaIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gaDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbGrupo = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFuncion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbArancel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGasto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrupo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.BorderColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.Options.UseBackColor = true;
            this.pnlBase.Appearance.Options.UseBorderColor = true;
            this.pnlBase.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBase.Controls.Add(this.pnlCenter);
            this.pnlBase.Controls.Add(this.pnlBottom);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(1);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(724, 325);
            this.pnlBase.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Appearance.Options.UseBackColor = true;
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.tableLayoutPanel1);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(724, 260);
            this.pnlCenter.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.grpDatos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.56863F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 260);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpDatos
            // 
            this.grpDatos.Appearance.BackColor = System.Drawing.Color.White;
            this.grpDatos.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.grpDatos.Appearance.Options.UseBackColor = true;
            this.grpDatos.Appearance.Options.UseBorderColor = true;
            this.grpDatos.AppearanceCaption.BackColor = System.Drawing.Color.SteelBlue;
            this.grpDatos.AppearanceCaption.BackColor2 = System.Drawing.Color.SteelBlue;
            this.grpDatos.AppearanceCaption.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatos.AppearanceCaption.Options.UseBackColor = true;
            this.grpDatos.AppearanceCaption.Options.UseFont = true;
            this.grpDatos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tableLayoutPanel1.SetColumnSpan(this.grpDatos, 7);
            this.grpDatos.Controls.Add(this.tableLayoutPanel3);
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Location = new System.Drawing.Point(3, 3);
            this.grpDatos.LookAndFeel.SkinName = "The Bezier";
            this.grpDatos.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpDatos.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(718, 254);
            this.grpDatos.TabIndex = 25;
            this.grpDatos.Text = "Datos";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.12805F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.10366F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.65244F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.37195F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.7439F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.Controls.Add(this.txtDescripcion, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCodigo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbFuncion, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbArancel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbGasto, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelControl4, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.cmbGrupo, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(714, 229);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.EditValue = "";
            this.txtDescripcion.EnterMoveNextControl = true;
            this.txtDescripcion.Location = new System.Drawing.Point(312, 6);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDescripcion.Properties.Mask.EditMask = "[^\']*";
            this.txtDescripcion.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDescripcion.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDescripcion.Properties.MaxLength = 300;
            this.txtDescripcion.Size = new System.Drawing.Size(359, 24);
            this.txtDescripcion.StyleController = this.styleText;
            this.txtDescripcion.TabIndex = 1;
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
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(227, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Descripción";
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
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl7.Location = new System.Drawing.Point(3, 9);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(69, 18);
            this.labelControl7.StyleController = this.styleLabels;
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.EditValue = "";
            this.txtCodigo.EnterMoveNextControl = true;
            this.txtCodigo.Location = new System.Drawing.Point(78, 6);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCodigo.Properties.Mask.EditMask = "[^\']*";
            this.txtCodigo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCodigo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCodigo.Properties.MaxLength = 8;
            this.txtCodigo.Size = new System.Drawing.Size(143, 24);
            this.txtCodigo.StyleController = this.styleText;
            this.txtCodigo.TabIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl8.Location = new System.Drawing.Point(3, 46);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(69, 18);
            this.labelControl8.StyleController = this.styleLabels;
            this.labelControl8.TabIndex = 24;
            this.labelControl8.Text = "Función";
            // 
            // cmbFuncion
            // 
            this.cmbFuncion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cmbFuncion, 3);
            this.cmbFuncion.EditValue = 0;
            this.cmbFuncion.EnterMoveNextControl = true;
            this.cmbFuncion.Location = new System.Drawing.Point(78, 43);
            this.cmbFuncion.Name = "cmbFuncion";
            this.cmbFuncion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbFuncion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFuncion.Properties.DisplayMember = "Descripcion";
            this.cmbFuncion.Properties.NullText = "";
            this.cmbFuncion.Properties.PopupView = this.gridView2;
            this.cmbFuncion.Properties.ValueMember = "ID_Registro";
            this.cmbFuncion.Size = new System.Drawing.Size(406, 24);
            this.cmbFuncion.StyleController = this.styleText;
            this.cmbFuncion.TabIndex = 2;
            this.cmbFuncion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFuncion_KeyDown);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.fuID_Registro,
            this.fuCodigo,
            this.fuDescripcion});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // fuID_Registro
            // 
            this.fuID_Registro.Caption = "ID_Registro";
            this.fuID_Registro.FieldName = "ID_Registro";
            this.fuID_Registro.Name = "fuID_Registro";
            // 
            // fuCodigo
            // 
            this.fuCodigo.Caption = "Código";
            this.fuCodigo.FieldName = "Codigo";
            this.fuCodigo.Name = "fuCodigo";
            this.fuCodigo.Visible = true;
            this.fuCodigo.VisibleIndex = 0;
            this.fuCodigo.Width = 105;
            // 
            // fuDescripcion
            // 
            this.fuDescripcion.Caption = "Descripción";
            this.fuDescripcion.FieldName = "Descripcion";
            this.fuDescripcion.Name = "fuDescripcion";
            this.fuDescripcion.Visible = true;
            this.fuDescripcion.VisibleIndex = 1;
            this.fuDescripcion.Width = 843;
            // 
            // cmbArancel
            // 
            this.cmbArancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cmbArancel, 3);
            this.cmbArancel.EditValue = 0;
            this.cmbArancel.EnterMoveNextControl = true;
            this.cmbArancel.Location = new System.Drawing.Point(78, 80);
            this.cmbArancel.Name = "cmbArancel";
            this.cmbArancel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbArancel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbArancel.Properties.DisplayMember = "Descripcion";
            this.cmbArancel.Properties.NullText = "";
            this.cmbArancel.Properties.PopupView = this.gridView1;
            this.cmbArancel.Properties.ValueMember = "ID_Registro";
            this.cmbArancel.Size = new System.Drawing.Size(406, 24);
            this.cmbArancel.StyleController = this.styleText;
            this.cmbArancel.TabIndex = 3;
            this.cmbArancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbArancel_KeyDown);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.arIDRegistro,
            this.arCodigo,
            this.arDescripcion});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // arIDRegistro
            // 
            this.arIDRegistro.Caption = "ID_Registro";
            this.arIDRegistro.FieldName = "ID_Registro";
            this.arIDRegistro.Name = "arIDRegistro";
            // 
            // arCodigo
            // 
            this.arCodigo.Caption = "Código";
            this.arCodigo.FieldName = "Codigo";
            this.arCodigo.Name = "arCodigo";
            this.arCodigo.Visible = true;
            this.arCodigo.VisibleIndex = 0;
            this.arCodigo.Width = 96;
            // 
            // arDescripcion
            // 
            this.arDescripcion.Caption = "Descripción";
            this.arDescripcion.FieldName = "Descripcion";
            this.arDescripcion.Name = "arDescripcion";
            this.arDescripcion.Visible = true;
            this.arDescripcion.VisibleIndex = 1;
            this.arDescripcion.Width = 852;
            // 
            // cmbGasto
            // 
            this.cmbGasto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cmbGasto, 3);
            this.cmbGasto.EditValue = 0;
            this.cmbGasto.EnterMoveNextControl = true;
            this.cmbGasto.Location = new System.Drawing.Point(78, 117);
            this.cmbGasto.Name = "cmbGasto";
            this.cmbGasto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbGasto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGasto.Properties.DisplayMember = "Descripcion";
            this.cmbGasto.Properties.NullText = "";
            this.cmbGasto.Properties.PopupView = this.gridView3;
            this.cmbGasto.Properties.ValueMember = "ID_Registro";
            this.cmbGasto.Size = new System.Drawing.Size(406, 24);
            this.cmbGasto.StyleController = this.styleText;
            this.cmbGasto.TabIndex = 4;
            this.cmbGasto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGasto_KeyDown);
            // 
            // gridView3
            // 
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gaIDRegistro,
            this.gaCodigo,
            this.gaDescripcion});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gaIDRegistro
            // 
            this.gaIDRegistro.Caption = "ID_Registro";
            this.gaIDRegistro.FieldName = "ID_Registro";
            this.gaIDRegistro.Name = "gaIDRegistro";
            // 
            // gaCodigo
            // 
            this.gaCodigo.Caption = "Código";
            this.gaCodigo.FieldName = "Codigo";
            this.gaCodigo.Name = "gaCodigo";
            this.gaCodigo.Visible = true;
            this.gaCodigo.VisibleIndex = 0;
            this.gaCodigo.Width = 104;
            // 
            // gaDescripcion
            // 
            this.gaDescripcion.Caption = "Descripción";
            this.gaDescripcion.FieldName = "Descripcion";
            this.gaDescripcion.Name = "gaDescripcion";
            this.gaDescripcion.Visible = true;
            this.gaDescripcion.VisibleIndex = 1;
            this.gaDescripcion.Width = 844;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(3, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Arancel";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 120);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Gasto";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(3, 157);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 18);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cmbGrupo, 3);
            this.cmbGrupo.EditValue = 0;
            this.cmbGrupo.EnterMoveNextControl = true;
            this.cmbGrupo.Location = new System.Drawing.Point(78, 154);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbGrupo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGrupo.Properties.DisplayMember = "Descripcion";
            this.cmbGrupo.Properties.NullText = "";
            this.cmbGrupo.Properties.PopupView = this.gridView4;
            this.cmbGrupo.Properties.ValueMember = "ID_Registro";
            this.cmbGrupo.Size = new System.Drawing.Size(406, 24);
            this.cmbGrupo.StyleController = this.styleText;
            this.cmbGrupo.TabIndex = 5;
            // 
            // gridView4
            // 
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView4.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grIDRegistro,
            this.grDescripcion});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // grIDRegistro
            // 
            this.grIDRegistro.Caption = "ID_Registro";
            this.grIDRegistro.FieldName = "ID_Registro";
            this.grIDRegistro.Name = "grIDRegistro";
            // 
            // grDescripcion
            // 
            this.grDescripcion.Caption = "Descripción";
            this.grDescripcion.FieldName = "Descripcion";
            this.grDescripcion.Name = "grDescripcion";
            this.grDescripcion.Visible = true;
            this.grDescripcion.VisibleIndex = 0;
            this.grDescripcion.Width = 847;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBottom.Controls.Add(this.tableLayoutPanel2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 260);
            this.pnlBottom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBottom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(724, 65);
            this.pnlBottom.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel2.Controls.Add(this.btnAplicar, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(724, 65);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Appearance.Options.UseFont = true;
            this.btnAplicar.AppearanceHovered.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAplicar.AppearanceHovered.Options.UseFont = true;
            this.btnAplicar.AppearancePressed.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.AppearancePressed.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearancePressed.Options.UseBackColor = true;
            this.btnAplicar.AppearancePressed.Options.UseFont = true;
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(575, 3);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAplicar.Size = new System.Drawing.Size(146, 59);
            this.btnAplicar.TabIndex = 6;
            this.btnAplicar.Text = "Aplicar cambios";
            this.btnAplicar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Frm_Practicas
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 325);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MaximumSize = new System.Drawing.Size(724, 325);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 0);
            this.Name = "Frm_Practicas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestataria";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFuncion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbArancel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGasto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrupo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlBase;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GridLookUpEdit cmbFuncion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn fuID_Registro;
        private DevExpress.XtraGrid.Columns.GridColumn fuDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn fuCodigo;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.GroupControl grpDatos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.GridLookUpEdit cmbArancel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn arIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn arDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn arCodigo;
        private DevExpress.XtraEditors.GridLookUpEdit cmbGasto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gaIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn gaDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gaCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GridLookUpEdit cmbGrupo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn grIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn grDescripcion;
    }
}