namespace AMDGOINT.Formularios.Facturas.Prestatarias.Vista
{
    partial class Frm_TasaInteres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TasaInteres));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCbu = new DevExpress.XtraEditors.TextEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCbu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.11167F));
            this.tableLayoutPanel1.Controls.Add(this.txtCbu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAplicar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.55319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.44681F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(415, 126);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtCbu
            // 
            this.txtCbu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCbu.Location = new System.Drawing.Point(3, 14);
            this.txtCbu.Name = "txtCbu";
            this.txtCbu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCbu.Properties.Mask.EditMask = "n3";
            this.txtCbu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCbu.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCbu.Size = new System.Drawing.Size(409, 24);
            this.txtCbu.StyleController = this.styleText;
            this.txtCbu.TabIndex = 2;
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
            this.btnAplicar.Location = new System.Drawing.Point(260, 56);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAplicar.Size = new System.Drawing.Size(152, 67);
            this.btnAplicar.TabIndex = 7;
            this.btnAplicar.Text = "Aplicar cambios";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
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
            // Frm_TasaInteres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 126);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frm_TasaInteres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tasa de Interés";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCbu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.TextEdit txtCbu;
    }
}