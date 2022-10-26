namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    partial class Frm_CierreEjercicio
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
            this.tglModoExportacion = new DevExpress.XtraBars.BarEditItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInformacion = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.bgwProcesaCierre = new System.ComponentModel.BackgroundWorker();
            this.tmrLabel = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // tglModoExportacion
            // 
            this.tglModoExportacion.Edit = null;
            this.tglModoExportacion.Id = 8;
            this.tglModoExportacion.Name = "tglModoExportacion";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.33782F));
            this.tableLayoutPanel1.Controls.Add(this.lblInformacion, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 276);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // lblInformacion
            // 
            this.lblInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInformacion.Appearance.Options.UseTextOptions = true;
            this.lblInformacion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInformacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInformacion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblInformacion.Location = new System.Drawing.Point(3, 124);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(663, 149);
            this.lblInformacion.StyleController = this.styleLabels;
            this.lblInformacion.TabIndex = 0;
            this.lblInformacion.Text = "Iniciando";
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // bgwProcesaCierre
            // 
            this.bgwProcesaCierre.WorkerReportsProgress = true;
            this.bgwProcesaCierre.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcesaCierre_DoWork);
            this.bgwProcesaCierre.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwProcesaCierre_ProgressChanged);
            this.bgwProcesaCierre.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcesaCierre_RunWorkerCompleted);
            // 
            // tmrLabel
            // 
            this.tmrLabel.Interval = 300;
            this.tmrLabel.Tick += new System.EventHandler(this.tmrLabel_Tick);
            // 
            // Frm_CierreEjercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 276);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CierreEjercicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre del ejercicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Exportacion_FormClosing);
            this.Load += new System.EventHandler(this.Frm_CierreEjercicio_Load);
            this.Shown += new System.EventHandler(this.Frm_ResumenFacturas_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.BarEditItem tglModoExportacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblInformacion;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private System.ComponentModel.BackgroundWorker bgwProcesaCierre;
        private System.Windows.Forms.Timer tmrLabel;
    }
}
