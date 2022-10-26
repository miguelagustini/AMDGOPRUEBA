namespace AMDGOINT.Formularios.Informes
{
    partial class Frm_Pdfviewer
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
            this.pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(818, 415);
            this.pdfViewer.TabIndex = 0;
            // 
            // Frm_Pdfviewer
            // 
            this.ClientSize = new System.Drawing.Size(818, 415);
            this.Controls.Add(this.pdfViewer);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frm_Pdfviewer";
            this.Text = "PDF";
            this.ResumeLayout(false);

        }

        #endregion
                
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer;
    }
}