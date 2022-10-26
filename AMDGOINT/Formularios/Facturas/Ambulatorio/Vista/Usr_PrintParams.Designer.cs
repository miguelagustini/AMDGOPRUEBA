namespace AMDGOINT.Formularios.Facturas.Ambulatorio.Vista
{
    partial class Usr_PrintParams
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.spnCantidad = new DevExpress.XtraEditors.SpinEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.tglPacientes = new DevExpress.XtraEditors.ToggleSwitch();
            this.tglIncluyeFactura = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglPacientes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIncluyeFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.36337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.63663F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.spnCantidad, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tglIncluyeFactura, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tglPacientes, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.17986F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.05755F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.33813F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(333, 135);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(205, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Copias";
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
            // spnCantidad
            // 
            this.spnCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spnCantidad.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnCantidad.Location = new System.Drawing.Point(214, 9);
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spnCantidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnCantidad.Properties.IsFloatValue = false;
            this.spnCantidad.Properties.Mask.EditMask = "N00";
            this.spnCantidad.Properties.MaxValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spnCantidad.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnCantidad.Properties.NullText = "1";
            this.spnCantidad.Size = new System.Drawing.Size(116, 24);
            this.spnCantidad.StyleController = this.styleText;
            this.spnCantidad.TabIndex = 0;
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
            // tglPacientes
            // 
            this.tglPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tglPacientes.Location = new System.Drawing.Point(214, 101);
            this.tglPacientes.Name = "tglPacientes";
            this.tglPacientes.Properties.OffText = "No";
            this.tglPacientes.Properties.OnText = "Si";
            this.tglPacientes.Size = new System.Drawing.Size(116, 22);
            this.tglPacientes.StyleController = this.styleText;
            this.tglPacientes.TabIndex = 1;
            // 
            // tglIncluyeFactura
            // 
            this.tglIncluyeFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tglIncluyeFactura.Location = new System.Drawing.Point(214, 54);
            this.tglIncluyeFactura.Name = "tglIncluyeFactura";
            this.tglIncluyeFactura.Properties.OffText = "No";
            this.tglIncluyeFactura.Properties.OnText = "Si";
            this.tglIncluyeFactura.Size = new System.Drawing.Size(116, 22);
            this.tglIncluyeFactura.StyleController = this.styleText;
            this.tglIncluyeFactura.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(3, 56);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(205, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "¿Incluir leyenda factura original?";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(205, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "¿Incluir Pacientes?";
            // 
            // Usr_PrintParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Usr_PrintParams";
            this.Size = new System.Drawing.Size(333, 135);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglPacientes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglIncluyeFactura.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.SpinEdit spnCantidad;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.ToggleSwitch tglPacientes;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ToggleSwitch tglIncluyeFactura;
    }
}
