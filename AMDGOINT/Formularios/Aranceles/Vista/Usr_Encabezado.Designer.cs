namespace AMDGOINT.Formularios.Aranceles.Vista
{
    partial class Usr_Encabezado
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.datFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkAplicacion = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAplicacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.94215F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.05785F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtObservaciones, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.datFecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkAplicacion, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 126);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(228, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(105, 15);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Aplicar valores en";
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtObservaciones
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtObservaciones, 5);
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Location = new System.Drawing.Point(96, 37);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtObservaciones.Properties.MaxLength = 1500;
            this.txtObservaciones.Size = new System.Drawing.Size(631, 86);
            this.txtObservaciones.StyleController = this.styleText;
            this.txtObservaciones.TabIndex = 3;
            this.txtObservaciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObservaciones_KeyDown);
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
            // datFecha
            // 
            this.datFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datFecha.EditValue = "";
            this.datFecha.Location = new System.Drawing.Point(96, 5);
            this.datFecha.Name = "datFecha";
            this.datFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.ClassicNew;
            this.datFecha.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.datFecha.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datFecha.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.datFecha.Size = new System.Drawing.Size(126, 24);
            this.datFecha.StyleController = this.styleText;
            this.datFecha.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 15);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(87, 15);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Observaciones";
            // 
            // chkAplicacion
            // 
            this.chkAplicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.chkAplicacion, 2);
            this.chkAplicacion.EditValue = "";
            this.chkAplicacion.Location = new System.Drawing.Point(339, 5);
            this.chkAplicacion.Name = "chkAplicacion";
            this.chkAplicacion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkAplicacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkAplicacion.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((short)(0)), "Prepagas"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((short)(1)), "Obras Sociales"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((short)(2)), "ART"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(((short)(3)), "Caja")});
            this.chkAplicacion.Properties.SelectAllItemVisible = false;
            this.chkAplicacion.Size = new System.Drawing.Size(187, 24);
            this.chkAplicacion.StyleController = this.styleText;
            this.chkAplicacion.TabIndex = 5;
            this.chkAplicacion.TextChanged += new System.EventHandler(this.chkAplicacion_TextChanged);
            // 
            // Usr_Encabezado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Usr_Encabezado";
            this.Size = new System.Drawing.Size(730, 126);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAplicacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.DateEdit datFecha;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkAplicacion;
    }
}
