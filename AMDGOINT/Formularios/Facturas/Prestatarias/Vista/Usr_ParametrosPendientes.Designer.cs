namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    partial class Usr_ParametrosPendientes
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateFecha = new DevExpress.XtraEditors.DateEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.cmbTipocomprobante = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipocomprobante.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateFecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTipocomprobante, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 81);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tipos de emisión";
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
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha";
            // 
            // dateFecha
            // 
            this.dateFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFecha.EditValue = null;
            this.dateFecha.Location = new System.Drawing.Point(117, 6);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dateFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFecha.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.dateFecha.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateFecha.Size = new System.Drawing.Size(203, 24);
            this.dateFecha.StyleController = this.styleText;
            this.dateFecha.TabIndex = 3;
            this.dateFecha.TextChanged += new System.EventHandler(this.dateFecha_TextChanged);
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
            // cmbTipocomprobante
            // 
            this.cmbTipocomprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipocomprobante.EditValue = "";
            this.cmbTipocomprobante.Location = new System.Drawing.Point(117, 43);
            this.cmbTipocomprobante.Name = "cmbTipocomprobante";
            this.cmbTipocomprobante.Properties.AllowMultiSelect = true;
            this.cmbTipocomprobante.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbTipocomprobante.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipocomprobante.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(1)), "Facturación mensual ambulatoria", ((byte)(0))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(3)), "Facturación mensual internación", ((byte)(1))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(6)), "Facturación Covid-19", ((byte)(2))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(7)), "Refacturación diferencia de aranceles ambulatorio", ((byte)(3))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(8)), "Refacturación diferencia de aranceles internación", ((byte)(4))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(2)), "Facturación fuera de término ambulatorio", ((byte)(5))),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((byte)(4)), "Facturación fuera de término internación", ((byte)(6)))});
            this.cmbTipocomprobante.Size = new System.Drawing.Size(203, 24);
            this.cmbTipocomprobante.StyleController = this.styleText;
            this.cmbTipocomprobante.TabIndex = 4;
            this.cmbTipocomprobante.Validated += new System.EventHandler(this.cmbTipocomprobante_Validated);
            // 
            // Usr_ParametrosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Usr_ParametrosPendientes";
            this.Size = new System.Drawing.Size(323, 81);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipocomprobante.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.DateEdit dateFecha;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbTipocomprobante;
    }
}
