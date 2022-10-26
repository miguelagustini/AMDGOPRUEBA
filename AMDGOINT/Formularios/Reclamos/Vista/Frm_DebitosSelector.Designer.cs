namespace AMDGOINT.Formularios.Reclamos.Vista
{
    partial class Frm_DebitosSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DebitosSelector));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colRegistroProcesado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPracticaFecha = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAdmision = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPracticaCod = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPracticadesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPracticaFunc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFacturaAmdgo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFacturaprof = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPeriodoDebitado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFactCantidad = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposDecimales = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colFacturadoHonorarios = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colFacturadoGastos = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFacturadoMedicamentos = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFacturadoPorc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colDebitadoHonorarios = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDebitoGastos = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDebitadoMedic = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            this.SuspendLayout();
            // 
            // colRegistroProcesado
            // 
            this.colRegistroProcesado.Caption = "RegistroProcesado";
            this.colRegistroProcesado.FieldName = "RegistroProcesado";
            this.colRegistroProcesado.Name = "colRegistroProcesado";
            this.colRegistroProcesado.OptionsColumn.AllowEdit = false;
            this.colRegistroProcesado.OptionsColumn.ShowInCustomizationForm = false;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1285, 533);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(1157, 474);
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
            this.gridControl.Size = new System.Drawing.Size(1266, 465);
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
            this.gridBand5,
            this.gridBand6,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand7});
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSeleccion,
            this.colProfesionalCodigo,
            this.colProfesionalNombre,
            this.colPrestatariaCuenta,
            this.colPrestatariaNombre,
            this.colPacienteDoc,
            this.colPacienteNombre,
            this.colPracticaCod,
            this.colPracticadesc,
            this.colPracticaFunc,
            this.colDebitomot,
            this.colFactCantidad,
            this.colFacturadoHonorarios,
            this.colFacturadoGastos,
            this.colFacturadoMedicamentos,
            this.colFacturadoPorc,
            this.colDebitadoMedic,
            this.colDebitoGastos,
            this.colDebitadoHonorarios,
            this.colFacturaAmdgo,
            this.colFacturaprof,
            this.colAdmision,
            this.colPeriodoFacturado,
            this.colPeriodoDebitado,
            this.colPracticaFecha,
            this.colRegistroProcesado});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colRegistroProcesado;
            gridFormatRule1.Name = "RegistroProcesado";
            formatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsBehavior.SmartVertScrollBar = false;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
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
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 1;
            this.gridBand5.Width = 221;
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
            this.colDebitomot.Caption = "Motivo Debito";
            this.colDebitomot.FieldName = "DebitoMotivo";
            this.colDebitomot.Name = "colDebitomot";
            this.colDebitomot.Visible = true;
            this.colDebitomot.Width = 90;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.Caption = "Práctica";
            this.gridBand6.Columns.Add(this.colPracticaFecha);
            this.gridBand6.Columns.Add(this.colAdmision);
            this.gridBand6.Columns.Add(this.colPracticaCod);
            this.gridBand6.Columns.Add(this.colPracticadesc);
            this.gridBand6.Columns.Add(this.colPracticaFunc);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 2;
            this.gridBand6.Width = 286;
            // 
            // colPracticaFecha
            // 
            this.colPracticaFecha.Caption = "Fecha";
            this.colPracticaFecha.ColumnEdit = this.reposDate;
            this.colPracticaFecha.FieldName = "PracticaFecha";
            this.colPracticaFecha.Name = "colPracticaFecha";
            this.colPracticaFecha.Visible = true;
            this.colPracticaFecha.Width = 42;
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
            // colAdmision
            // 
            this.colAdmision.Caption = "Admisión Nro.";
            this.colAdmision.FieldName = "AdmisionCodigo";
            this.colAdmision.Name = "colAdmision";
            this.colAdmision.Visible = true;
            this.colAdmision.Width = 89;
            // 
            // colPracticaCod
            // 
            this.colPracticaCod.Caption = "Código";
            this.colPracticaCod.FieldName = "PracticaCodigo";
            this.colPracticaCod.Name = "colPracticaCod";
            this.colPracticaCod.Visible = true;
            this.colPracticaCod.Width = 47;
            // 
            // colPracticadesc
            // 
            this.colPracticadesc.Caption = "Práctica";
            this.colPracticadesc.FieldName = "PracticaNombre";
            this.colPracticadesc.Name = "colPracticadesc";
            this.colPracticadesc.Visible = true;
            this.colPracticadesc.Width = 54;
            // 
            // colPracticaFunc
            // 
            this.colPracticaFunc.Caption = "Función";
            this.colPracticaFunc.FieldName = "PracticaFuncion";
            this.colPracticaFunc.Name = "colPracticaFunc";
            this.colPracticaFunc.Visible = true;
            this.colPracticaFunc.Width = 54;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.Caption = "Comprobantes";
            this.gridBand2.Columns.Add(this.colFacturaAmdgo);
            this.gridBand2.Columns.Add(this.colFacturaprof);
            this.gridBand2.Columns.Add(this.colPeriodoDebitado);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 3;
            this.gridBand2.Width = 277;
            // 
            // colFacturaAmdgo
            // 
            this.colFacturaAmdgo.Caption = "Comp. Amdgo";
            this.colFacturaAmdgo.FieldName = "FacturaAmdgo";
            this.colFacturaAmdgo.Name = "colFacturaAmdgo";
            this.colFacturaAmdgo.Visible = true;
            this.colFacturaAmdgo.Width = 86;
            // 
            // colFacturaprof
            // 
            this.colFacturaprof.Caption = "Comp. Profesional";
            this.colFacturaprof.FieldName = "FacturaProfesional";
            this.colFacturaprof.Name = "colFacturaprof";
            this.colFacturaprof.Visible = true;
            this.colFacturaprof.Width = 111;
            // 
            // colPeriodoDebitado
            // 
            this.colPeriodoDebitado.Caption = "Pr. Debitado";
            this.colPeriodoDebitado.FieldName = "PeriodoDebitado";
            this.colPeriodoDebitado.Name = "colPeriodoDebitado";
            this.colPeriodoDebitado.Visible = true;
            this.colPeriodoDebitado.Width = 80;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(3)))));
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridBand3.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.Caption = "Facturado";
            this.gridBand3.Columns.Add(this.colFactCantidad);
            this.gridBand3.Columns.Add(this.colFacturadoHonorarios);
            this.gridBand3.Columns.Add(this.colFacturadoGastos);
            this.gridBand3.Columns.Add(this.colFacturadoMedicamentos);
            this.gridBand3.Columns.Add(this.colFacturadoPorc);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 4;
            this.gridBand3.Width = 337;
            // 
            // colFactCantidad
            // 
            this.colFactCantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.colFactCantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFactCantidad.Caption = "Cantidad";
            this.colFactCantidad.ColumnEdit = this.reposDecimales;
            this.colFactCantidad.FieldName = "FacturadoCantidad";
            this.colFactCantidad.Name = "colFactCantidad";
            this.colFactCantidad.Visible = true;
            this.colFactCantidad.Width = 58;
            // 
            // reposDecimales
            // 
            this.reposDecimales.AutoHeight = false;
            this.reposDecimales.Mask.EditMask = "n2";
            this.reposDecimales.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposDecimales.Mask.UseMaskAsDisplayFormat = true;
            this.reposDecimales.Name = "reposDecimales";
            // 
            // colFacturadoHonorarios
            // 
            this.colFacturadoHonorarios.AppearanceHeader.Options.UseTextOptions = true;
            this.colFacturadoHonorarios.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFacturadoHonorarios.Caption = "$ Honorarios";
            this.colFacturadoHonorarios.ColumnEdit = this.reposMoneda;
            this.colFacturadoHonorarios.FieldName = "FacturadoHonorarios";
            this.colFacturadoHonorarios.Name = "colFacturadoHonorarios";
            this.colFacturadoHonorarios.Visible = true;
            this.colFacturadoHonorarios.Width = 81;
            // 
            // reposMoneda
            // 
            this.reposMoneda.AutoHeight = false;
            this.reposMoneda.Mask.EditMask = "C2";
            this.reposMoneda.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposMoneda.Mask.UseMaskAsDisplayFormat = true;
            this.reposMoneda.Name = "reposMoneda";
            // 
            // colFacturadoGastos
            // 
            this.colFacturadoGastos.AppearanceHeader.Options.UseTextOptions = true;
            this.colFacturadoGastos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFacturadoGastos.Caption = "$ Gastos";
            this.colFacturadoGastos.ColumnEdit = this.reposMoneda;
            this.colFacturadoGastos.FieldName = "FacturadoGastos";
            this.colFacturadoGastos.Name = "colFacturadoGastos";
            this.colFacturadoGastos.Visible = true;
            this.colFacturadoGastos.Width = 56;
            // 
            // colFacturadoMedicamentos
            // 
            this.colFacturadoMedicamentos.AppearanceHeader.Options.UseTextOptions = true;
            this.colFacturadoMedicamentos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFacturadoMedicamentos.Caption = "$ Medicamentos";
            this.colFacturadoMedicamentos.ColumnEdit = this.reposMoneda;
            this.colFacturadoMedicamentos.FieldName = "FacturadoMedicamentos";
            this.colFacturadoMedicamentos.Name = "colFacturadoMedicamentos";
            this.colFacturadoMedicamentos.Visible = true;
            this.colFacturadoMedicamentos.Width = 101;
            // 
            // colFacturadoPorc
            // 
            this.colFacturadoPorc.AppearanceHeader.Options.UseTextOptions = true;
            this.colFacturadoPorc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFacturadoPorc.Caption = "% Iva";
            this.colFacturadoPorc.ColumnEdit = this.reposMoneda;
            this.colFacturadoPorc.FieldName = "FacturadoIvaPorcentaje";
            this.colFacturadoPorc.Name = "colFacturadoPorc";
            this.colFacturadoPorc.Visible = true;
            this.colFacturadoPorc.Width = 41;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tw Cen MT", 9.75F);
            this.gridBand4.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.Caption = "Debitado";
            this.gridBand4.Columns.Add(this.colDebitadoHonorarios);
            this.gridBand4.Columns.Add(this.colDebitoGastos);
            this.gridBand4.Columns.Add(this.colDebitadoMedic);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 5;
            this.gridBand4.Width = 238;
            // 
            // colDebitadoHonorarios
            // 
            this.colDebitadoHonorarios.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebitadoHonorarios.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebitadoHonorarios.Caption = "$ Honorarios";
            this.colDebitadoHonorarios.ColumnEdit = this.reposMoneda;
            this.colDebitadoHonorarios.FieldName = "DebitadoHonorarios";
            this.colDebitadoHonorarios.Name = "colDebitadoHonorarios";
            this.colDebitadoHonorarios.Visible = true;
            this.colDebitadoHonorarios.Width = 81;
            // 
            // colDebitoGastos
            // 
            this.colDebitoGastos.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebitoGastos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebitoGastos.Caption = "$ Gastos";
            this.colDebitoGastos.ColumnEdit = this.reposMoneda;
            this.colDebitoGastos.FieldName = "DebitadoGastos";
            this.colDebitoGastos.Name = "colDebitoGastos";
            this.colDebitoGastos.Visible = true;
            this.colDebitoGastos.Width = 56;
            // 
            // colDebitadoMedic
            // 
            this.colDebitadoMedic.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebitadoMedic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebitadoMedic.Caption = "$ Medicamentos";
            this.colDebitadoMedic.ColumnEdit = this.reposMoneda;
            this.colDebitadoMedic.FieldName = "DebitadoMedicamentos";
            this.colDebitadoMedic.Name = "colDebitadoMedic";
            this.colDebitadoMedic.Visible = true;
            this.colDebitadoMedic.Width = 101;
            // 
            // gridBand7
            // 
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 6;
            this.gridBand7.Width = 16;
            // 
            // Frm_DebitosSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.IconOptions.ShowIcon = false;
            this.MinimizeBox = false;
            this.Name = "Frm_DebitosSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de débitos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DebitosSelector_FormClosing);
            this.Load += new System.EventHandler(this.Frm_DebitosSelector_Load);
            this.Shown += new System.EventHandler(this.Frm_DebitosSelector_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDecimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
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
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPracticaCod;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPracticadesc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPracticaFunc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDebitomot;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFacturaAmdgo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFacturaprof;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFactCantidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDecimales;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFacturadoHonorarios;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFacturadoGastos;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFacturadoMedicamentos;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFacturadoPorc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDebitadoHonorarios;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDebitoGastos;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDebitadoMedic;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAdmision;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPeriodoFacturado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPeriodoDebitado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPracticaFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRegistroProcesado;
    }
}
