namespace AMDGOINT.Formularios.Prestatarias
{
    partial class Frm_PrDetPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrDetPopup));
            this.pnlBase = new DevExpress.XtraEditors.PanelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDatos = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPorcentaje = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAgrupador = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gaIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gaDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPorcentaje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgrupador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
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
            this.pnlBase.Size = new System.Drawing.Size(500, 237);
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
            this.pnlCenter.Size = new System.Drawing.Size(500, 172);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Controls.Add(this.grpDatos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 172);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpDatos
            // 
            this.grpDatos.Appearance.BackColor = System.Drawing.Color.Transparent;
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
            this.grpDatos.MinimumSize = new System.Drawing.Size(450, 130);
            this.grpDatos.Name = "grpDatos";
            this.tableLayoutPanel1.SetRowSpan(this.grpDatos, 3);
            this.grpDatos.Size = new System.Drawing.Size(494, 166);
            this.grpDatos.TabIndex = 25;
            this.grpDatos.Text = "Datos";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.19878F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.91684F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.00814F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.76797F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.934871F));
            this.tableLayoutPanel3.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCodigo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbPorcentaje, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelControl4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbAgrupador, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(490, 141);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Código";
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
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.EditValue = "\'\'";
            this.txtCodigo.EnterMoveNextControl = true;
            this.txtCodigo.Location = new System.Drawing.Point(72, 6);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.txtCodigo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtCodigo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCodigo.Properties.Mask.EditMask = "[^\']*";
            this.txtCodigo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCodigo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCodigo.Properties.MaxLength = 150;
            this.txtCodigo.Properties.Tag = "";
            this.txtCodigo.Properties.ValidateOnEnterKey = true;
            this.txtCodigo.Size = new System.Drawing.Size(175, 24);
            this.txtCodigo.StyleController = this.styleText;
            this.txtCodigo.TabIndex = 0;
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
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.txtNombre, 3);
            this.txtNombre.EditValue = "";
            this.txtNombre.EnterMoveNextControl = true;
            this.txtNombre.Location = new System.Drawing.Point(72, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNombre.Properties.Mask.EditMask = "[^\']*";
            this.txtNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtNombre.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNombre.Properties.MaxLength = 150;
            this.txtNombre.Size = new System.Drawing.Size(393, 24);
            this.txtNombre.StyleController = this.styleText;
            this.txtNombre.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(253, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "% Iva";
            // 
            // cmbPorcentaje
            // 
            this.cmbPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPorcentaje.EditValue = "0,00";
            this.cmbPorcentaje.EnterMoveNextControl = true;
            this.cmbPorcentaje.Location = new System.Drawing.Point(311, 6);
            this.cmbPorcentaje.Name = "cmbPorcentaje";
            this.cmbPorcentaje.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPorcentaje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPorcentaje.Properties.Items.AddRange(new object[] {
            "0,00",
            "10,50",
            "21,00"});
            this.cmbPorcentaje.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPorcentaje.Size = new System.Drawing.Size(154, 24);
            this.cmbPorcentaje.StyleController = this.styleText;
            this.cmbPorcentaje.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(3, 83);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 18);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Agrupador";
            // 
            // cmbAgrupador
            // 
            this.cmbAgrupador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cmbAgrupador, 3);
            this.cmbAgrupador.EditValue = 0;
            this.cmbAgrupador.EnterMoveNextControl = true;
            this.cmbAgrupador.Location = new System.Drawing.Point(72, 80);
            this.cmbAgrupador.Name = "cmbAgrupador";
            this.cmbAgrupador.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbAgrupador.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAgrupador.Properties.DisplayMember = "Descripcion";
            this.cmbAgrupador.Properties.NullText = "";
            this.cmbAgrupador.Properties.PopupView = this.gridView3;
            this.cmbAgrupador.Properties.ValueMember = "ID_Registro";
            this.cmbAgrupador.Size = new System.Drawing.Size(393, 24);
            this.cmbAgrupador.StyleController = this.styleText;
            this.cmbAgrupador.TabIndex = 3;
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
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBottom.Controls.Add(this.tableLayoutPanel2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 172);
            this.pnlBottom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBottom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(500, 65);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(500, 65);
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
            this.btnAplicar.Location = new System.Drawing.Point(351, 3);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAplicar.Size = new System.Drawing.Size(146, 59);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar cambios";
            this.btnAplicar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Frm_PrDetPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 237);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 237);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_PrDetPopup";
            this.Text = "Plan";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDatos)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPorcentaje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgrupador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.GroupControl grpDatos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPorcentaje;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GridLookUpEdit cmbAgrupador;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gaIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn gaCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gaDescripcion;
    }
}