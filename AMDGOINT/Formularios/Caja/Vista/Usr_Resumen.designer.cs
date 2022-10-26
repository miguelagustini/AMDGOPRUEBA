namespace AMDGOINT.Formularios.Caja.Vista
{
    partial class Usr_Resumen
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), typeof(System.Windows.Forms.UserControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtEfectivo = new DevExpress.XtraEditors.TextEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTransferencias = new DevExpress.XtraEditors.TextEdit();
            this.txtCheques = new DevExpress.XtraEditors.TextEdit();
            this.txtSaldoArrastre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldoActual = new DevExpress.XtraEditors.TextEdit();
            this.txtSaldoDia = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEfectivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransferencias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheques.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoArrastre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoDia.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.txtEfectivo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTransferencias, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCheques, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoArrastre, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoActual, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoDia, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 217);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEfectivo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtEfectivo.Enabled = false;
            this.txtEfectivo.Location = new System.Drawing.Point(116, 5);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtEfectivo.Properties.Mask.EditMask = "C2";
            this.txtEfectivo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEfectivo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEfectivo.Size = new System.Drawing.Size(109, 24);
            this.txtEfectivo.StyleController = this.styleText;
            this.txtEfectivo.TabIndex = 8;
            // 
            // styleText
            // 
            this.styleText.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.styleText.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.Appearance.Options.UseBorderColor = true;
            this.styleText.Appearance.Options.UseFont = true;
            this.styleText.AppearanceDisabled.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
            this.styleText.AppearanceDisabled.Options.UseForeColor = true;
            this.styleText.AppearanceFocused.BorderColor = System.Drawing.Color.Goldenrod;
            this.styleText.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.AppearanceFocused.Options.UseBorderColor = true;
            this.styleText.AppearanceFocused.Options.UseFont = true;
            this.styleText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(107, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Efectivo";
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
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Transferencias";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(3, 78);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(107, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Cheques";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(272, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(112, 18);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Saldo de arrastre";
            // 
            // txtTransferencias
            // 
            this.txtTransferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransferencias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTransferencias.Enabled = false;
            this.txtTransferencias.Location = new System.Drawing.Point(116, 40);
            this.txtTransferencias.Name = "txtTransferencias";
            this.txtTransferencias.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtTransferencias.Properties.Mask.EditMask = "C2";
            this.txtTransferencias.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTransferencias.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTransferencias.Size = new System.Drawing.Size(109, 24);
            this.txtTransferencias.StyleController = this.styleText;
            this.txtTransferencias.TabIndex = 9;
            // 
            // txtCheques
            // 
            this.txtCheques.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheques.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCheques.Enabled = false;
            this.txtCheques.Location = new System.Drawing.Point(116, 75);
            this.txtCheques.Name = "txtCheques";
            this.txtCheques.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCheques.Properties.Mask.EditMask = "C2";
            this.txtCheques.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCheques.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCheques.Size = new System.Drawing.Size(109, 24);
            this.txtCheques.StyleController = this.styleText;
            this.txtCheques.TabIndex = 10;
            // 
            // txtSaldoArrastre
            // 
            this.txtSaldoArrastre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoArrastre.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoArrastre.Enabled = false;
            this.txtSaldoArrastre.Location = new System.Drawing.Point(390, 5);
            this.txtSaldoArrastre.Name = "txtSaldoArrastre";
            this.txtSaldoArrastre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSaldoArrastre.Properties.Mask.EditMask = "C2";
            this.txtSaldoArrastre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldoArrastre.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSaldoArrastre.Size = new System.Drawing.Size(109, 24);
            this.txtSaldoArrastre.StyleController = this.styleText;
            this.txtSaldoArrastre.TabIndex = 11;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl6.Location = new System.Drawing.Point(272, 43);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(112, 18);
            this.labelControl6.StyleController = this.styleLabels;
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Saldo del día";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl5.Location = new System.Drawing.Point(272, 78);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(112, 18);
            this.labelControl5.StyleController = this.styleLabels;
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Saldo Actual";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoActual.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoActual.Enabled = false;
            this.txtSaldoActual.Location = new System.Drawing.Point(390, 75);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSaldoActual.Properties.Mask.EditMask = "C2";
            this.txtSaldoActual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldoActual.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSaldoActual.Size = new System.Drawing.Size(109, 24);
            this.txtSaldoActual.StyleController = this.styleText;
            this.txtSaldoActual.TabIndex = 6;
            // 
            // txtSaldoDia
            // 
            this.txtSaldoDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoDia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoDia.Enabled = false;
            this.txtSaldoDia.Location = new System.Drawing.Point(390, 40);
            this.txtSaldoDia.Name = "txtSaldoDia";
            this.txtSaldoDia.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSaldoDia.Properties.Mask.EditMask = "C2";
            this.txtSaldoDia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldoDia.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSaldoDia.Size = new System.Drawing.Size(109, 24);
            this.txtSaldoDia.StyleController = this.styleText;
            this.txtSaldoDia.TabIndex = 13;
            // 
            // Usr_Resumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Usr_Resumen";
            this.Size = new System.Drawing.Size(618, 217);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEfectivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransferencias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheques.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoArrastre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoDia.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.TextEdit txtEfectivo;
        private DevExpress.XtraEditors.TextEdit txtSaldoActual;
        private DevExpress.XtraEditors.TextEdit txtTransferencias;
        private DevExpress.XtraEditors.TextEdit txtCheques;
        private DevExpress.XtraEditors.TextEdit txtSaldoArrastre;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtSaldoDia;
    }
}
