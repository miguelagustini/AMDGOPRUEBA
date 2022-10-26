namespace AMDGOINT.Formularios.Profesionales.Especialidad.Vista
{
    partial class Frm_Especialidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Especialidad));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.00847F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.99152F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAplicar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Descripción";
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
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(110, 6);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDescripcion.Properties.Mask.EditMask = "[^\']*";
            this.txtDescripcion.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDescripcion.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDescripcion.Properties.MaxLength = 150;
            this.txtDescripcion.Size = new System.Drawing.Size(485, 24);
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
            // btnAplicar
            // 
            this.btnAplicar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnAplicar.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAplicar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Appearance.Options.UseBackColor = true;
            this.btnAplicar.Appearance.Options.UseBorderColor = true;
            this.btnAplicar.Appearance.Options.UseFont = true;
            this.btnAplicar.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAplicar.AppearanceHovered.BorderColor = System.Drawing.Color.Silver;
            this.btnAplicar.AppearanceHovered.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAplicar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnAplicar.AppearanceHovered.Options.UseFont = true;
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(435, 40);
            this.btnAplicar.LookAndFeel.SkinName = "Office 2019 White";
            this.btnAplicar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnAplicar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAplicar.Size = new System.Drawing.Size(160, 57);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // Frm_Especialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 100);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MaximumSize = new System.Drawing.Size(600, 132);
            this.MinimizeBox = false;
            this.Name = "Frm_Especialidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Especialidad";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
    }
}