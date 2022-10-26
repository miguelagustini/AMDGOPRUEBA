namespace AMDGOINT.Formularios.Devoluciones.Vista
{
    partial class Frm_OrdenesIntSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_OrdenesIntSelector));
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPeriodoFacturado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProfesionalCodigo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProfesionalNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPrestatariaCuenta = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPrestatariaNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSeleccion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPacienteDoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPacienteNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDebitomot = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAdmision = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposDecimales = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.875F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1285, 337);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(1157, 278);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 56);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Continuar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposDecimales,
            this.reposMoneda,
            this.reposDate});
            this.gridControl.Size = new System.Drawing.Size(1266, 269);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.gridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand5});
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSeleccion,
            this.colProfesionalCodigo,
            this.colProfesionalNombre,
            this.colPrestatariaCuenta,
            this.colPrestatariaNombre,
            this.colPacienteDoc,
            this.colPacienteNombre,
            this.colDebitomot,
            this.colAdmision,
            this.colPeriodoFacturado});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_SelectionChanged);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.Caption = "Detalles";
            this.gridBand1.Columns.Add(this.colPeriodoFacturado);
            this.gridBand1.Columns.Add(this.colProfesionalCodigo);
            this.gridBand1.Columns.Add(this.colProfesionalNombre);
            this.gridBand1.Columns.Add(this.colPrestatariaCuenta);
            this.gridBand1.Columns.Add(this.colPrestatariaNombre);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 404;
            // 
            // colPeriodoFacturado
            // 
            this.colPeriodoFacturado.Caption = "Pr. Facturado";
            this.colPeriodoFacturado.FieldName = "PeriodoFacturado";
            this.colPeriodoFacturado.Name = "colPeriodoFacturado";
            this.colPeriodoFacturado.Visible = true;
            this.colPeriodoFacturado.Width = 85;
            // 
            // colProfesionalCodigo
            // 
            this.colProfesionalCodigo.Caption = "Prestador Cta.";
            this.colProfesionalCodigo.FieldName = "ProfesionalCuentaCodigo";
            this.colProfesionalCodigo.Name = "colProfesionalCodigo";
            this.colProfesionalCodigo.Visible = true;
            this.colProfesionalCodigo.Width = 89;
            // 
            // colProfesionalNombre
            // 
            this.colProfesionalNombre.Caption = "Prestador";
            this.colProfesionalNombre.FieldName = "ProfesionalCuentaNombre";
            this.colProfesionalNombre.Name = "colProfesionalNombre";
            this.colProfesionalNombre.Visible = true;
            this.colProfesionalNombre.Width = 64;
            // 
            // colPrestatariaCuenta
            // 
            this.colPrestatariaCuenta.Caption = "Prestataria Cta.";
            this.colPrestatariaCuenta.FieldName = "PrestatariaCuentaCodigo";
            this.colPrestatariaCuenta.Name = "colPrestatariaCuenta";
            this.colPrestatariaCuenta.Visible = true;
            this.colPrestatariaCuenta.Width = 96;
            // 
            // colPrestatariaNombre
            // 
            this.colPrestatariaNombre.Caption = "Prestataria";
            this.colPrestatariaNombre.FieldName = "PrestatariaCuentaNombre";
            this.colPrestatariaNombre.Name = "colPrestatariaNombre";
            this.colPrestatariaNombre.Visible = true;
            this.colPrestatariaNombre.Width = 70;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.Caption = "Paciente";
            this.gridBand5.Columns.Add(this.colSeleccion);
            this.gridBand5.Columns.Add(this.colPacienteDoc);
            this.gridBand5.Columns.Add(this.colPacienteNombre);
            this.gridBand5.Columns.Add(this.colDebitomot);
            this.gridBand5.Columns.Add(this.colAdmision);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 1;
            this.gridBand5.Width = 310;
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "...";
            this.colSeleccion.FieldName = "Seleccionado";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsColumn.ShowInCustomizationForm = false;
            this.colSeleccion.OptionsColumn.ShowInExpressionEditor = false;
            this.colSeleccion.Width = 21;
            // 
            // colPacienteDoc
            // 
            this.colPacienteDoc.Caption = "Documento";
            this.colPacienteDoc.FieldName = "PacienteDocumento";
            this.colPacienteDoc.Name = "colPacienteDoc";
            this.colPacienteDoc.Visible = true;
            this.colPacienteDoc.Width = 73;
            // 
            // colPacienteNombre
            // 
            this.colPacienteNombre.Caption = "Paciente";
            this.colPacienteNombre.FieldName = "PacienteNombre";
            this.colPacienteNombre.Name = "colPacienteNombre";
            this.colPacienteNombre.Visible = true;
            this.colPacienteNombre.Width = 58;
            // 
            // colDebitomot
            // 
            this.colDebitomot.Caption = "Motivo Internación";
            this.colDebitomot.FieldName = "DebitoMotivo";
            this.colDebitomot.Name = "colDebitomot";
            this.colDebitomot.Visible = true;
            this.colDebitomot.Width = 90;
            // 
            // colAdmision
            // 
            this.colAdmision.Caption = "Admisión Nro.";
            this.colAdmision.FieldName = "AdmisionCodigo";
            this.colAdmision.Name = "colAdmision";
            this.colAdmision.Visible = true;
            this.colAdmision.Width = 89;
            // 
            // reposDecimales
            // 
            this.reposDecimales.AutoHeight = false;
            this.reposDecimales.Mask.EditMask = "n2";
            this.reposDecimales.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimales.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimales.Name = "reposDecimales";
            // 
            // reposMoneda
            // 
            this.reposMoneda.AutoHeight = false;
            this.reposMoneda.Mask.EditMask = "C2";
            this.reposMoneda.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposMoneda.Mask.UseMaskAsDisplayFormat = true;
            this.reposMoneda.Name = "reposMoneda";
            // 
            // reposDate
            // 
            this.reposDate.AutoHeight = false;
            this.reposDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.Mask.EditMask = "yyyy-MM-dd";
            this.reposDate.Mask.UseMaskAsDisplayFormat = true;
            this.reposDate.Name = "reposDate";
            // 
            // Frm_OrdenesIntSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 337);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.IconOptions.ShowIcon = false;
            this.MinimizeBox = false;
            this.Name = "Frm_OrdenesIntSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Órdenes Internación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_OrdenesIntSelector_FormClosing);
            this.Load += new System.EventHandler(this.Frm_OrdenesIntSelector_Load);
            this.Shown += new System.EventHandler(this.Frm_OrdenesIntSelector_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSeleccion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProfesionalCodigo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProfesionalNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPrestatariaCuenta;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPrestatariaNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPacienteDoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPacienteNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDebitomot;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimales;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAdmision;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPeriodoFacturado;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
    }
}
