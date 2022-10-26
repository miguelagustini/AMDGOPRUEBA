namespace AMDGOINT.Formularios.Profesionales
{
    partial class Frm_Femesfepreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Femesfepreview));
            this.pnlBase = new DevExpress.XtraEditors.PanelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProfesion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatricula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLibro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPiso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDpto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtros = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodPostal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSexo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecialidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelegacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.ScrManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportarxls = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.BorderColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.Options.UseBackColor = true;
            this.pnlBase.Appearance.Options.UseBorderColor = true;
            this.pnlBase.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBase.Controls.Add(this.pnlCenter);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(1);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(800, 325);
            this.pnlBase.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Appearance.Options.UseBackColor = true;
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.tableLayoutPanel1);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(800, 325);
            this.pnlCenter.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 325);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(794, 319);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProfesion,
            this.colMatricula,
            this.colLibro,
            this.colFolio,
            this.colNombre,
            this.colTipoDni,
            this.colDni,
            this.colCalle,
            this.colNumero,
            this.colPiso,
            this.colDpto,
            this.colOtros,
            this.colCodPostal,
            this.colTelefono,
            this.colSexo,
            this.colEspecialidad,
            this.colEmail,
            this.colCuit,
            this.colDelegacion,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            // 
            // colProfesion
            // 
            this.colProfesion.Caption = "Profesion";
            this.colProfesion.FieldName = "Profesion";
            this.colProfesion.Name = "colProfesion";
            this.colProfesion.Visible = true;
            this.colProfesion.VisibleIndex = 0;
            // 
            // colMatricula
            // 
            this.colMatricula.Caption = "Matricula";
            this.colMatricula.FieldName = "MatriculaProv";
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.Visible = true;
            this.colMatricula.VisibleIndex = 1;
            // 
            // colLibro
            // 
            this.colLibro.Caption = "Libro";
            this.colLibro.FieldName = "Libro";
            this.colLibro.Name = "colLibro";
            this.colLibro.Visible = true;
            this.colLibro.VisibleIndex = 2;
            // 
            // colFolio
            // 
            this.colFolio.Caption = "Folio";
            this.colFolio.FieldName = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.Visible = true;
            this.colFolio.VisibleIndex = 3;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "NewNombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 4;
            // 
            // colTipoDni
            // 
            this.colTipoDni.Caption = "Tipo Dni";
            this.colTipoDni.FieldName = "TipoDni";
            this.colTipoDni.Name = "colTipoDni";
            this.colTipoDni.Visible = true;
            this.colTipoDni.VisibleIndex = 5;
            // 
            // colDni
            // 
            this.colDni.Caption = "Dni";
            this.colDni.FieldName = "Documento";
            this.colDni.Name = "colDni";
            this.colDni.Visible = true;
            this.colDni.VisibleIndex = 6;
            // 
            // colCalle
            // 
            this.colCalle.Caption = "Calle";
            this.colCalle.FieldName = "Calle";
            this.colCalle.Name = "colCalle";
            this.colCalle.Visible = true;
            this.colCalle.VisibleIndex = 7;
            // 
            // colNumero
            // 
            this.colNumero.Caption = "Numero";
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 8;
            // 
            // colPiso
            // 
            this.colPiso.Caption = "Piso";
            this.colPiso.FieldName = "Piso";
            this.colPiso.Name = "colPiso";
            this.colPiso.Visible = true;
            this.colPiso.VisibleIndex = 9;
            // 
            // colDpto
            // 
            this.colDpto.Caption = "Dto";
            this.colDpto.FieldName = "Departamento";
            this.colDpto.Name = "colDpto";
            this.colDpto.Visible = true;
            this.colDpto.VisibleIndex = 10;
            // 
            // colOtros
            // 
            this.colOtros.Caption = "Otros";
            this.colOtros.FieldName = "OtrosDatos";
            this.colOtros.Name = "colOtros";
            this.colOtros.Visible = true;
            this.colOtros.VisibleIndex = 11;
            // 
            // colCodPostal
            // 
            this.colCodPostal.Caption = "Nro Localidad";
            this.colCodPostal.FieldName = "CodigoPostal";
            this.colCodPostal.Name = "colCodPostal";
            this.colCodPostal.Visible = true;
            this.colCodPostal.VisibleIndex = 12;
            // 
            // colTelefono
            // 
            this.colTelefono.Caption = "Telefono";
            this.colTelefono.FieldName = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.Visible = true;
            this.colTelefono.VisibleIndex = 13;
            // 
            // colSexo
            // 
            this.colSexo.Caption = "Sexo";
            this.colSexo.FieldName = "Sexo";
            this.colSexo.Name = "colSexo";
            this.colSexo.Visible = true;
            this.colSexo.VisibleIndex = 14;
            // 
            // colEspecialidad
            // 
            this.colEspecialidad.Caption = "Especialidad";
            this.colEspecialidad.FieldName = "Especialidad";
            this.colEspecialidad.Name = "colEspecialidad";
            this.colEspecialidad.Visible = true;
            this.colEspecialidad.VisibleIndex = 15;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Mail";
            this.colEmail.FieldName = "Mail";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 16;
            // 
            // colCuit
            // 
            this.colCuit.Caption = "C.U.I.T";
            this.colCuit.FieldName = "Cuit";
            this.colCuit.Name = "colCuit";
            this.colCuit.Visible = true;
            this.colCuit.VisibleIndex = 17;
            // 
            // colDelegacion
            // 
            this.colDelegacion.Caption = "Delegacion";
            this.colDelegacion.FieldName = "Delegacion";
            this.colDelegacion.Name = "colDelegacion";
            this.colDelegacion.Visible = true;
            this.colDelegacion.VisibleIndex = 18;
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // ScrManager
            // 
            this.ScrManager.ClosingDelay = 500;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportarxls)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.Id = 0;
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.LargeImage")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizar_ItemClick);
            // 
            // btnExportarxls
            // 
            this.btnExportarxls.Caption = "Exportar a Excel";
            this.btnExportarxls.Id = 1;
            this.btnExportarxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarxls.ImageOptions.Image")));
            this.btnExportarxls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportarxls.ImageOptions.LargeImage")));
            this.btnExportarxls.Name = "btnExportarxls";
            this.btnExportarxls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportarxls_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnActualizar,
            this.btnExportarxls});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 325);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 325);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 325);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Provincia";
            this.gridColumn1.FieldName = "Provincia";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 19;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Localidad";
            this.gridColumn2.FieldName = "Localidad";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 20;
            // 
            // Frm_Femesfepreview
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 325);
            this.Controls.Add(this.pnlBase);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_Femesfepreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Padron Femesfe";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlBase;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colProfesion;
        private DevExpress.XtraGrid.Columns.GridColumn colMatricula;
        private DevExpress.XtraGrid.Columns.GridColumn colLibro;
        private DevExpress.XtraGrid.Columns.GridColumn colFolio;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDni;
        private DevExpress.XtraGrid.Columns.GridColumn colDni;
        private DevExpress.XtraGrid.Columns.GridColumn colCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colPiso;
        private DevExpress.XtraGrid.Columns.GridColumn colDpto;
        private DevExpress.XtraGrid.Columns.GridColumn colOtros;
        private DevExpress.XtraGrid.Columns.GridColumn colCodPostal;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colSexo;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecialidad;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colCuit;
        private DevExpress.XtraGrid.Columns.GridColumn colDelegacion;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraSplashScreen.SplashScreenManager ScrManager;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.BarButtonItem btnExportarxls;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}