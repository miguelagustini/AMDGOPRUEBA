namespace AMDGOINT.Formularios.Aranceles.Vista
{
    partial class Frm_Simulacion
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pvControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pvControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.06085F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.939148F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 493);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pvControl
            // 
            this.pvControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tableLayoutPanel1.SetColumnSpan(this.pvControl, 2);
            this.pvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvControl.Location = new System.Drawing.Point(3, 3);
            this.pvControl.Name = "pvControl";
            this.pvControl.Size = new System.Drawing.Size(898, 438);
            this.pvControl.TabIndex = 0;
            // 
            // Frm_Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_Simulacion";
            this.Text = "Simulación de Aranceles";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraPivotGrid.PivotGridControl pvControl;
    }
}