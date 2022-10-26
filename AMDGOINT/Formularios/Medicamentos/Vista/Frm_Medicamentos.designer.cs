namespace AMDGOINT.Formularios.Medicamentos.Vista
{
    partial class Frm_Medicamentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Medicamentos));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colEstadoAsoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repoEstado = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.colEstadoAsocDesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBaja = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.colMonodroga = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnImportar = new DevExpress.XtraBars.Navigation.NavButton();
            this.Imprimir = new DevExpress.XtraBars.Navigation.NavButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColIDRegistro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repoDecimal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTroquel = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodBarra = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNombre = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPresentacion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIoma1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIoma2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIoma3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLaboratorio = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPrecioCompleto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposPrecio = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colUnidades = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPrecio = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFecha = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repoDate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMarcaProdContrDesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colImportadoDesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTipoDeventa = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodPamiDesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodLab = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNroRegistro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBajaDesc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTamanio = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGravamen = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colHomonimo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgwImportacion = new System.ComponentModel.BackgroundWorker();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.repoEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate)).BeginInit();
            this.SuspendLayout();
            // 
            // colEstadoAsoc
            // 
            this.colEstadoAsoc.ColumnEdit = this.repoEstado;
            this.colEstadoAsoc.FieldName = "EstadoAsoc";
            this.colEstadoAsoc.Name = "colEstadoAsoc";
            this.colEstadoAsoc.OptionsColumn.ShowInCustomizationForm = false;
            this.colEstadoAsoc.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colEstadoAsoc.Width = 20;
            // 
            // repoEstado
            // 
            this.repoEstado.AutoHeight = false;
            this.repoEstado.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repoEstado.Name = "repoEstado";
            this.repoEstado.OffText = "Inactivo ";
            this.repoEstado.OnText = "Activo ";
            // 
            // colEstadoAsocDesc
            // 
            this.colEstadoAsocDesc.Caption = "Estado Asoc";
            this.colEstadoAsocDesc.FieldName = "EstadoAsocDescripcion";
            this.colEstadoAsocDesc.Name = "colEstadoAsocDesc";
            this.colEstadoAsocDesc.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colEstadoAsocDesc.Width = 113;
            // 
            // colBaja
            // 
            this.colBaja.FieldName = "Baja";
            this.colBaja.Name = "colBaja";
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // colMonodroga
            // 
            this.colMonodroga.FieldName = "Monodroga";
            this.colMonodroga.Name = "colMonodroga";
            this.colMonodroga.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colMonodroga.Visible = true;
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Buttons.Add(this.btnImportar);
            this.tileNavPane1.Buttons.Add(this.Imprimir);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.Size = new System.Drawing.Size(1011, 55);
            this.tileNavPane1.TabIndex = 1;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // btnImportar
            // 
            this.btnImportar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnImportar.Caption = "Importar";
            this.btnImportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.ImageOptions.Image")));
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnImportar_ElementClick);
            // 
            // Imprimir
            // 
            this.Imprimir.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.Imprimir.Caption = "Imprimir";
            this.Imprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Imprimir.ImageOptions.Image")));
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButton2_ElementClick);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 55);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposPrecio,
            this.repoDecimal,
            this.repoEstado,
            this.repoDate});
            this.gridControl.Size = new System.Drawing.Size(1011, 374);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.ActiveFilterEnabled = false;
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            this.gridBand2});
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.ColIDRegistro,
            this.colTroquel,
            this.colCodBarra,
            this.colNombre,
            this.colPresentacion,
            this.colIoma1,
            this.colIoma2,
            this.colIoma3,
            this.colLaboratorio,
            this.colPrecioCompleto,
            this.colUnidades,
            this.colPrecio,
            this.colFecha,
            this.colMarcaProdContrDesc,
            this.colImportadoDesc,
            this.colTipoDeventa,
            this.colIva,
            this.colCodPamiDesc,
            this.colCodLab,
            this.colNroRegistro,
            this.colBajaDesc,
            this.colTamanio,
            this.colGravamen,
            this.colHomonimo,
            this.colEstadoAsocDesc,
            this.colEstadoAsoc,
            this.colMonodroga,
            this.colBaja});
            gridFormatRule1.Column = this.colEstadoAsoc;
            gridFormatRule1.ColumnApplyTo = this.colEstadoAsocDesc;
            gridFormatRule1.Name = "iconoEstadoAsoc";
            formatConditionRuleIconSet1.AllowAnimation = DevExpress.Utils.DefaultBoolean.False;
            gridFormatRule1.Rule = formatConditionRuleIconSet1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colBaja;
            gridFormatRule2.Name = "redColumns";
            formatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue1.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule2.Rule = formatConditionRuleValue1;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.EditFormShowing += new DevExpress.XtraGrid.Views.Grid.EditFormShowingEventHandler(this.gridView_EditFormShowing);
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Datos AlfaBeta";
            this.gridBand1.Columns.Add(this.ColIDRegistro);
            this.gridBand1.Columns.Add(this.colTroquel);
            this.gridBand1.Columns.Add(this.colCodBarra);
            this.gridBand1.Columns.Add(this.colNombre);
            this.gridBand1.Columns.Add(this.colPresentacion);
            this.gridBand1.Columns.Add(this.colIoma1);
            this.gridBand1.Columns.Add(this.colIoma2);
            this.gridBand1.Columns.Add(this.colIoma3);
            this.gridBand1.Columns.Add(this.colLaboratorio);
            this.gridBand1.Columns.Add(this.colPrecioCompleto);
            this.gridBand1.Columns.Add(this.colUnidades);
            this.gridBand1.Columns.Add(this.colPrecio);
            this.gridBand1.Columns.Add(this.colFecha);
            this.gridBand1.Columns.Add(this.colMarcaProdContrDesc);
            this.gridBand1.Columns.Add(this.colImportadoDesc);
            this.gridBand1.Columns.Add(this.colTipoDeventa);
            this.gridBand1.Columns.Add(this.colIva);
            this.gridBand1.Columns.Add(this.colCodPamiDesc);
            this.gridBand1.Columns.Add(this.colCodLab);
            this.gridBand1.Columns.Add(this.colNroRegistro);
            this.gridBand1.Columns.Add(this.colMonodroga);
            this.gridBand1.Columns.Add(this.colBajaDesc);
            this.gridBand1.Columns.Add(this.colTamanio);
            this.gridBand1.Columns.Add(this.colGravamen);
            this.gridBand1.Columns.Add(this.colEstadoAsoc);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 1158;
            // 
            // ColIDRegistro
            // 
            this.ColIDRegistro.ColumnEdit = this.repoDecimal;
            this.ColIDRegistro.FieldName = "IDRegistro";
            this.ColIDRegistro.Name = "ColIDRegistro";
            this.ColIDRegistro.OptionsColumn.AllowEdit = false;
            this.ColIDRegistro.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repoDecimal
            // 
            this.repoDecimal.AutoHeight = false;
            this.repoDecimal.Mask.EditMask = "N0";
            this.repoDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repoDecimal.Mask.UseMaskAsDisplayFormat = true;
            this.repoDecimal.Name = "repoDecimal";
            // 
            // colTroquel
            // 
            this.colTroquel.AppearanceCell.Options.UseTextOptions = true;
            this.colTroquel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTroquel.FieldName = "Troquel";
            this.colTroquel.Name = "colTroquel";
            this.colTroquel.OptionsColumn.AllowEdit = false;
            this.colTroquel.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colTroquel.Visible = true;
            this.colTroquel.Width = 86;
            // 
            // colCodBarra
            // 
            this.colCodBarra.Caption = "Cód. Barra";
            this.colCodBarra.FieldName = "CodBarra";
            this.colCodBarra.Name = "colCodBarra";
            this.colCodBarra.OptionsColumn.AllowEdit = false;
            this.colCodBarra.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colCodBarra.Visible = true;
            this.colCodBarra.Width = 112;
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNombre.Visible = true;
            this.colNombre.Width = 116;
            // 
            // colPresentacion
            // 
            this.colPresentacion.FieldName = "Presentacion";
            this.colPresentacion.Name = "colPresentacion";
            this.colPresentacion.OptionsColumn.AllowEdit = false;
            this.colPresentacion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPresentacion.Visible = true;
            this.colPresentacion.Width = 122;
            // 
            // colIoma1
            // 
            this.colIoma1.ColumnEdit = this.repoDecimal;
            this.colIoma1.FieldName = "Ioma1";
            this.colIoma1.Name = "colIoma1";
            this.colIoma1.OptionsColumn.AllowEdit = false;
            this.colIoma1.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colIoma1.Width = 32;
            // 
            // colIoma2
            // 
            this.colIoma2.FieldName = "Ioma2";
            this.colIoma2.Name = "colIoma2";
            this.colIoma2.OptionsColumn.AllowEdit = false;
            this.colIoma2.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colIoma2.Width = 32;
            // 
            // colIoma3
            // 
            this.colIoma3.FieldName = "Ioma3";
            this.colIoma3.Name = "colIoma3";
            this.colIoma3.OptionsColumn.AllowEdit = false;
            this.colIoma3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colIoma3.Width = 32;
            // 
            // colLaboratorio
            // 
            this.colLaboratorio.FieldName = "Laboratorio";
            this.colLaboratorio.Name = "colLaboratorio";
            this.colLaboratorio.OptionsColumn.AllowEdit = false;
            this.colLaboratorio.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colLaboratorio.Visible = true;
            this.colLaboratorio.Width = 80;
            // 
            // colPrecioCompleto
            // 
            this.colPrecioCompleto.ColumnEdit = this.reposPrecio;
            this.colPrecioCompleto.FieldName = "PrecioCompleto";
            this.colPrecioCompleto.Name = "colPrecioCompleto";
            this.colPrecioCompleto.OptionsColumn.AllowEdit = false;
            this.colPrecioCompleto.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPrecioCompleto.Visible = true;
            this.colPrecioCompleto.Width = 108;
            // 
            // reposPrecio
            // 
            this.reposPrecio.AutoHeight = false;
            this.reposPrecio.Mask.EditMask = "C2";
            this.reposPrecio.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposPrecio.Mask.UseMaskAsDisplayFormat = true;
            this.reposPrecio.Name = "reposPrecio";
            // 
            // colUnidades
            // 
            this.colUnidades.ColumnEdit = this.repoDecimal;
            this.colUnidades.FieldName = "Unidades";
            this.colUnidades.Name = "colUnidades";
            this.colUnidades.OptionsColumn.AllowEdit = false;
            this.colUnidades.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colUnidades.Visible = true;
            this.colUnidades.Width = 65;
            // 
            // colPrecio
            // 
            this.colPrecio.Caption = "Precio Unitario";
            this.colPrecio.ColumnEdit = this.reposPrecio;
            this.colPrecio.FieldName = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.OptionsColumn.AllowEdit = false;
            this.colPrecio.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPrecio.Visible = true;
            this.colPrecio.Width = 111;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Actualizado";
            this.colFecha.ColumnEdit = this.repoDate;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colFecha.Visible = true;
            this.colFecha.Width = 81;
            // 
            // repoDate
            // 
            this.repoDate.AutoHeight = false;
            this.repoDate.Mask.EditMask = "dd-MM-yyyy";
            this.repoDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.repoDate.Mask.UseMaskAsDisplayFormat = true;
            this.repoDate.Name = "repoDate";
            // 
            // colMarcaProdContrDesc
            // 
            this.colMarcaProdContrDesc.Caption = "Tipo de producto";
            this.colMarcaProdContrDesc.FieldName = "MarcaProdContrDesc";
            this.colMarcaProdContrDesc.Name = "colMarcaProdContrDesc";
            this.colMarcaProdContrDesc.OptionsColumn.AllowEdit = false;
            this.colMarcaProdContrDesc.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colMarcaProdContrDesc.Visible = true;
            this.colMarcaProdContrDesc.Width = 120;
            // 
            // colImportadoDesc
            // 
            this.colImportadoDesc.Caption = "Importado";
            this.colImportadoDesc.FieldName = "ImportadoDesc";
            this.colImportadoDesc.Name = "colImportadoDesc";
            this.colImportadoDesc.OptionsColumn.AllowEdit = false;
            this.colImportadoDesc.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colImportadoDesc.Width = 86;
            // 
            // colTipoDeventa
            // 
            this.colTipoDeventa.Caption = "Tipo de venta";
            this.colTipoDeventa.FieldName = "TipoDeVentaDesc";
            this.colTipoDeventa.Name = "colTipoDeventa";
            this.colTipoDeventa.OptionsColumn.AllowEdit = false;
            this.colTipoDeventa.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colTipoDeventa.Width = 103;
            // 
            // colIva
            // 
            this.colIva.FieldName = "Iva";
            this.colIva.Name = "colIva";
            this.colIva.OptionsColumn.AllowEdit = false;
            this.colIva.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colIva.Width = 32;
            // 
            // colCodPamiDesc
            // 
            this.colCodPamiDesc.Caption = "Código de descuento de PAMI";
            this.colCodPamiDesc.FieldName = "CodPamiDesc";
            this.colCodPamiDesc.Name = "colCodPamiDesc";
            this.colCodPamiDesc.OptionsColumn.AllowEdit = false;
            this.colCodPamiDesc.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colCodPamiDesc.Width = 182;
            // 
            // colCodLab
            // 
            this.colCodLab.Caption = "Código de Lab.";
            this.colCodLab.ColumnEdit = this.repoDecimal;
            this.colCodLab.FieldName = "CodLab";
            this.colCodLab.Name = "colCodLab";
            this.colCodLab.OptionsColumn.AllowEdit = false;
            this.colCodLab.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colCodLab.Width = 49;
            // 
            // colNroRegistro
            // 
            this.colNroRegistro.ColumnEdit = this.repoDecimal;
            this.colNroRegistro.FieldName = "NroRegistro";
            this.colNroRegistro.Name = "colNroRegistro";
            this.colNroRegistro.OptionsColumn.AllowEdit = false;
            this.colNroRegistro.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colNroRegistro.Width = 70;
            // 
            // colBajaDesc
            // 
            this.colBajaDesc.Caption = "Baja";
            this.colBajaDesc.FieldName = "BajaDesc";
            this.colBajaDesc.Name = "colBajaDesc";
            this.colBajaDesc.OptionsColumn.AllowEdit = false;
            this.colBajaDesc.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colBajaDesc.Visible = true;
            this.colBajaDesc.Width = 82;
            // 
            // colTamanio
            // 
            this.colTamanio.Caption = "Tamaño";
            this.colTamanio.FieldName = "TamanioDesc";
            this.colTamanio.Name = "colTamanio";
            this.colTamanio.OptionsColumn.AllowEdit = false;
            this.colTamanio.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colTamanio.Width = 48;
            // 
            // colGravamen
            // 
            this.colGravamen.FieldName = "Gravamen";
            this.colGravamen.Name = "colGravamen";
            this.colGravamen.OptionsColumn.AllowEdit = false;
            this.colGravamen.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colGravamen.Width = 85;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Datos AMDGO";
            this.gridBand2.Columns.Add(this.colHomonimo);
            this.gridBand2.Columns.Add(this.colEstadoAsocDesc);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 74;
            // 
            // colHomonimo
            // 
            this.colHomonimo.FieldName = "Homonimo";
            this.colHomonimo.Name = "colHomonimo";
            this.colHomonimo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colHomonimo.Visible = true;
            this.colHomonimo.Width = 74;
            // 
            // bgwImportacion
            // 
            this.bgwImportacion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwImportacion_DoWork);
            this.bgwImportacion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwImportacion_RunWorkerCompleted);
            // 
            // navButton1
            // 
            this.navButton1.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.navButton1.Caption = "Importar";
            this.navButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navButton1.ImageOptions.Image")));
            this.navButton1.Name = "navButton1";
            // 
            // Frm_Medicamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 429);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.tileNavPane1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Medicamentos";
            this.Text = " Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Medicamentos_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Medicamentos_Load);
            this.Shown += new System.EventHandler(this.Frm_Medicamentos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.repoEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTroquel;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoDecimal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNombre;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPresentacion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIoma1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIoma2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIoma3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLaboratorio;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPrecio;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposPrecio;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFecha;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMarcaProdContrDesc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImportadoDesc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTipoDeventa;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIva;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodPamiDesc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodLab;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNroRegistro;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBajaDesc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodBarra;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnidades;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTamanio;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGravamen;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEstadoAsoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repoEstado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHomonimo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEstadoAsocDesc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPrecioCompleto;
        private DevExpress.XtraBars.Navigation.NavButton btnImportar;
        private System.ComponentModel.BackgroundWorker bgwImportacion;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColIDRegistro;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoDate;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMonodroga;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBaja;
        private DevExpress.XtraBars.Navigation.NavButton Imprimir;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
    }
}