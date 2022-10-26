namespace AMDGOINT.Formularios.Aranceles.Vista
{
    partial class Frm_Arancel
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
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Arancel));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.Dockdatosgral = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPracticas = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.ScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.bgwGuardado = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.Dockdatosgral.SuspendLayout();
            this.dockPracticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            this.SuspendLayout();
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
            // dockManager
            // 
            this.dockManager.DockingOptions.ShowCloseButton = false;
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.Dockdatosgral,
            this.dockPracticas});
            this.dockManager.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // Dockdatosgral
            // 
            this.Dockdatosgral.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(111)))), ((int)(((byte)(81)))));
            this.Dockdatosgral.Appearance.Options.UseBorderColor = true;
            this.Dockdatosgral.Controls.Add(this.dockPanel2_Container);
            customHeaderButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions1.Image")));
            this.Dockdatosgral.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Guardar y salir", true, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject1, ((short)(0)), -1)});
            this.Dockdatosgral.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.Dockdatosgral.FloatVertical = true;
            this.Dockdatosgral.ID = new System.Guid("7a619fa9-b230-4e59-b594-1e1495be4781");
            this.Dockdatosgral.Location = new System.Drawing.Point(0, 0);
            this.Dockdatosgral.Name = "Dockdatosgral";
            this.Dockdatosgral.OriginalSize = new System.Drawing.Size(1108, 248);
            this.Dockdatosgral.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.Dockdatosgral.SavedIndex = 0;
            this.Dockdatosgral.Size = new System.Drawing.Size(966, 248);
            this.Dockdatosgral.Text = "Datos Generales";
            this.Dockdatosgral.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.Dockdatosgral_CustomButtonClick);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 29);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(966, 218);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPracticas
            // 
            this.dockPracticas.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(83)))));
            this.dockPracticas.Appearance.Options.UseBorderColor = true;
            this.dockPracticas.Controls.Add(this.dockPanel1_Container);
            this.dockPracticas.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPracticas.ID = new System.Guid("108be364-dad5-48e3-a6c8-d75812d0272a");
            this.dockPracticas.Location = new System.Drawing.Point(0, 248);
            this.dockPracticas.Name = "dockPracticas";
            this.dockPracticas.Options.ShowCloseButton = false;
            this.dockPracticas.OriginalSize = new System.Drawing.Size(966, 200);
            this.dockPracticas.Size = new System.Drawing.Size(966, 161);
            this.dockPracticas.Text = "Prácticas";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(966, 138);
            this.dockPanel1_Container.TabIndex = 0;
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
            // ScreenManager
            // 
            this.ScreenManager.ClosingDelay = 500;
            // 
            // bgwGuardado
            // 
            this.bgwGuardado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGuardado_DoWork);
            this.bgwGuardado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGuardado_RunWorkerCompleted);
            // 
            // Frm_Arancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 409);
            this.Controls.Add(this.dockPracticas);
            this.Controls.Add(this.Dockdatosgral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_Arancel";
            this.Text = "Arancel base";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Arancel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.Dockdatosgral.ResumeLayout(false);
            this.dockPracticas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraSplashScreen.SplashScreenManager ScreenManager;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPracticas;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel Dockdatosgral;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private System.ComponentModel.BackgroundWorker bgwGuardado;
    }
}