namespace AMDGOINT.Formularios.Principal
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.pnlTransparent = new TransControl_src.TransparentControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTransparent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTransparent
            // 
            this.pnlTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransparent.Controls.Add(this.tableLayoutPanel1);
            this.pnlTransparent.Location = new System.Drawing.Point(35, 121);
            this.pnlTransparent.MinimumSize = new System.Drawing.Size(100, 75);
            this.pnlTransparent.Name = "pnlTransparent";
            this.pnlTransparent.Opacity = 0.25D;
            this.pnlTransparent.Size = new System.Drawing.Size(314, 167);
            this.pnlTransparent.TabIndex = 1;
            this.pnlTransparent.Transparent = true;
            this.pnlTransparent.TransparentColor = System.Drawing.Color.White;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.80255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.19745F));
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLogin, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 167);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.Location = new System.Drawing.Point(106, 42);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPassword.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.txtPassword.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPassword.Properties.Mask.EditMask = "[^\']*";
            this.txtPassword.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPassword.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPassword.Properties.MaxLength = 50;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(205, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.ImageOptions.Image")));
            this.labelControl2.Location = new System.Drawing.Point(3, 38);
            this.labelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.labelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 30);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Contraseña";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.ImageOptions.Image")));
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.labelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.EnterMoveNextControl = true;
            this.txtUsuario.Location = new System.Drawing.Point(106, 6);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Properties.Appearance.Options.UseBackColor = true;
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Properties.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtUsuario.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtUsuario.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.txtUsuario.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtUsuario.Properties.Mask.EditMask = "[^\']*";
            this.txtUsuario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtUsuario.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUsuario.Properties.MaxLength = 50;
            this.txtUsuario.Size = new System.Drawing.Size(205, 22);
            this.txtUsuario.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseBorderColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.AppearanceHovered.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.AppearanceHovered.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnLogin.AppearanceHovered.Options.UseBackColor = true;
            this.btnLogin.AppearanceHovered.Options.UseBorderColor = true;
            this.btnLogin.AppearanceHovered.Options.UseFont = true;
            this.btnLogin.AppearanceHovered.Options.UseForeColor = true;
            this.btnLogin.AppearancePressed.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.AppearancePressed.Options.UseFont = true;
            this.btnLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.Image")));
            this.btnLogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(106, 74);
            this.btnLogin.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnLogin.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(205, 60);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 388);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Login
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 388);
            this.Controls.Add(this.pnlTransparent);
            this.Controls.Add(this.pictureBox1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Frm_Login.IconOptions.Image")));
            this.IsMdiContainer = true;
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Login_FormClosing);
            this.Shown += new System.EventHandler(this.Frm_Login_Shown);
            this.pnlTransparent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private TransControl_src.TransparentControl pnlTransparent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
    }
}