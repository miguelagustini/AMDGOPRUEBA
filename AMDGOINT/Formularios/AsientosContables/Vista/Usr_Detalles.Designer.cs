namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    partial class Usr_Detalles
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel2 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel3 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewAsientosdet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCuentaNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposText150 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFechas = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.reposCmbCuenta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colpCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpCodigol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCmbSubcuenta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trcModoPago = new DevExpress.XtraEditors.Repository.RepositoryItemTrackBar();
            this.cmbBancos = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentaNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAsientosdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposText150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbSubcuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcModoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBancos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridViewAsientosdet;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMoneda,
            this.reposText150,
            this.reposFechas,
            this.reposCmbCuenta,
            this.reposCmbSubcuenta,
            this.trcModoPago,
            this.cmbBancos});
            this.gridControl.Size = new System.Drawing.Size(985, 375);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAsientosdet});
            // 
            // gridViewAsientosdet
            // 
            this.gridViewAsientosdet.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridViewAsientosdet.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewAsientosdet.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewAsientosdet.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewAsientosdet.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewAsientosdet.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewAsientosdet.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewAsientosdet.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewAsientosdet.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewAsientosdet.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewAsientosdet.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewAsientosdet.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewAsientosdet.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridViewAsientosdet.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewAsientosdet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewAsientosdet.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.gridViewAsientosdet.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewAsientosdet.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewAsientosdet.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewAsientosdet.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewAsientosdet.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewAsientosdet.Appearance.Row.Options.UseFont = true;
            this.gridViewAsientosdet.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewAsientosdet.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewAsientosdet.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewAsientosdet.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewAsientosdet.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewAsientosdet.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewAsientosdet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewAsientosdet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCuentaNumero,
            this.colCuentaNombre,
            this.colSubCuenta,
            this.colPase,
            this.colDescripcion,
            this.colDebe,
            this.colHaber});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Borrar";
            formatConditionRuleValue1.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Name = "ImporteNegativo";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue2.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridViewAsientosdet.FormatRules.Add(gridFormatRule1);
            this.gridViewAsientosdet.FormatRules.Add(gridFormatRule2);
            this.gridViewAsientosdet.GridControl = this.gridControl;
            this.gridViewAsientosdet.Name = "gridViewAsientosdet";
            this.gridViewAsientosdet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewAsientosdet.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridViewAsientosdet.OptionsCustomization.AllowGroup = false;
            this.gridViewAsientosdet.OptionsEditForm.EditFormColumnCount = 1;
            this.gridViewAsientosdet.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridViewAsientosdet.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewAsientosdet.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridViewAsientosdet.OptionsView.RowAutoHeight = true;
            this.gridViewAsientosdet.OptionsView.ShowDetailButtons = false;
            this.gridViewAsientosdet.OptionsView.ShowFooter = true;
            this.gridViewAsientosdet.OptionsView.ShowGroupPanel = false;
            this.gridViewAsientosdet.OptionsView.ShowIndicator = false;
            // 
            // colCuentaNombre
            // 
            this.colCuentaNombre.Caption = "Cuenta Nombre";
            this.colCuentaNombre.FieldName = "PlanCuentaNombre";
            this.colCuentaNombre.Name = "colCuentaNombre";
            this.colCuentaNombre.Visible = true;
            this.colCuentaNombre.VisibleIndex = 1;
            this.colCuentaNombre.Width = 217;
            // 
            // colSubCuenta
            // 
            this.colSubCuenta.Caption = "SubCuenta";
            this.colSubCuenta.FieldName = "PlanSubCuentaCompleto";
            this.colSubCuenta.Name = "colSubCuenta";
            this.colSubCuenta.Visible = true;
            this.colSubCuenta.VisibleIndex = 2;
            this.colSubCuenta.Width = 239;
            // 
            // colPase
            // 
            this.colPase.Caption = "Pase";
            this.colPase.FieldName = "PaseNumero";
            this.colPase.Name = "colPase";
            this.colPase.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPase.Visible = true;
            this.colPase.VisibleIndex = 3;
            this.colPase.Width = 83;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.ColumnEdit = this.reposText150;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 4;
            this.colDescripcion.Width = 418;
            // 
            // reposText150
            // 
            this.reposText150.AutoHeight = false;
            this.reposText150.MaxLength = 150;
            this.reposText150.Name = "reposText150";
            // 
            // colDebe
            // 
            this.colDebe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebe.Caption = "$ Debe";
            this.colDebe.ColumnEdit = this.reposMoneda;
            this.colDebe.FieldName = "ImporteDebe";
            this.colDebe.Name = "colDebe";
            this.colDebe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteDebe", "{0:C2}")});
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 5;
            this.colDebe.Width = 116;
            // 
            // reposMoneda
            // 
            this.reposMoneda.AutoHeight = false;
            this.reposMoneda.Mask.EditMask = "C2";
            this.reposMoneda.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposMoneda.Mask.UseMaskAsDisplayFormat = true;
            this.reposMoneda.Name = "reposMoneda";
            // 
            // colHaber
            // 
            this.colHaber.AppearanceHeader.Options.UseTextOptions = true;
            this.colHaber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHaber.Caption = "$ Haber";
            this.colHaber.ColumnEdit = this.reposMoneda;
            this.colHaber.FieldName = "ImporteHaber";
            this.colHaber.Name = "colHaber";
            this.colHaber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteHaber", "{0:C2}")});
            this.colHaber.Visible = true;
            this.colHaber.VisibleIndex = 6;
            this.colHaber.Width = 128;
            // 
            // reposFechas
            // 
            this.reposFechas.AutoHeight = false;
            this.reposFechas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposFechas.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposFechas.Mask.EditMask = "yyyy-MM-dd";
            this.reposFechas.Mask.UseMaskAsDisplayFormat = true;
            this.reposFechas.Name = "reposFechas";
            // 
            // reposCmbCuenta
            // 
            this.reposCmbCuenta.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.reposCmbCuenta.AutoHeight = false;
            this.reposCmbCuenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposCmbCuenta.DisplayMember = "DescripcionExtendida";
            this.reposCmbCuenta.Name = "reposCmbCuenta";
            this.reposCmbCuenta.NullText = "";
            this.reposCmbCuenta.PopupView = this.gridView1;
            this.reposCmbCuenta.ValueMember = "IDRegistro";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colpCodigo,
            this.colpCodigol,
            this.colpDescripcion});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colpCodigo
            // 
            this.colpCodigo.Caption = "Código Corto";
            this.colpCodigo.FieldName = "CodigoCorto";
            this.colpCodigo.Name = "colpCodigo";
            this.colpCodigo.Visible = true;
            this.colpCodigo.VisibleIndex = 0;
            // 
            // colpCodigol
            // 
            this.colpCodigol.Caption = "Código Largo";
            this.colpCodigol.FieldName = "CodigoLargo";
            this.colpCodigol.Name = "colpCodigol";
            this.colpCodigol.Visible = true;
            this.colpCodigol.VisibleIndex = 2;
            // 
            // colpDescripcion
            // 
            this.colpDescripcion.Caption = "Descripción";
            this.colpDescripcion.FieldName = "Descripcion";
            this.colpDescripcion.Name = "colpDescripcion";
            this.colpDescripcion.Visible = true;
            this.colpDescripcion.VisibleIndex = 1;
            // 
            // reposCmbSubcuenta
            // 
            this.reposCmbSubcuenta.AutoHeight = false;
            this.reposCmbSubcuenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposCmbSubcuenta.DisplayMember = "DescripcionExtendida";
            this.reposCmbSubcuenta.Name = "reposCmbSubcuenta";
            this.reposCmbSubcuenta.NullText = "";
            this.reposCmbSubcuenta.PopupView = this.gridView3;
            this.reposCmbSubcuenta.ValueMember = "IDRegistro";
            // 
            // gridView3
            // 
            this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView3.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsCodigo,
            this.colsDescripcion});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colsCodigo
            // 
            this.colsCodigo.Caption = "Código";
            this.colsCodigo.FieldName = "Codigo";
            this.colsCodigo.Name = "colsCodigo";
            this.colsCodigo.Visible = true;
            this.colsCodigo.VisibleIndex = 0;
            // 
            // colsDescripcion
            // 
            this.colsDescripcion.Caption = "Descripción";
            this.colsDescripcion.FieldName = "Descripcion";
            this.colsDescripcion.Name = "colsDescripcion";
            this.colsDescripcion.Visible = true;
            this.colsDescripcion.VisibleIndex = 1;
            // 
            // trcModoPago
            // 
            this.trcModoPago.LabelAppearance.Options.UseTextOptions = true;
            this.trcModoPago.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "Efectivo";
            trackBarLabel2.Label = "Transferencia";
            trackBarLabel2.Value = 1;
            trackBarLabel3.Label = "Cheque";
            trackBarLabel3.Value = 2;
            this.trcModoPago.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1,
            trackBarLabel2,
            trackBarLabel3});
            this.trcModoPago.LargeChange = 3;
            this.trcModoPago.Maximum = 2;
            this.trcModoPago.Name = "trcModoPago";
            this.trcModoPago.ShowLabels = true;
            // 
            // cmbBancos
            // 
            this.cmbBancos.AutoHeight = false;
            this.cmbBancos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBancos.DisplayMember = "Descripcion";
            this.cmbBancos.Name = "cmbBancos";
            this.cmbBancos.NullText = "";
            this.cmbBancos.PopupView = this.gridView5;
            this.cmbBancos.ValueMember = "IDRegistro";
            // 
            // gridView5
            // 
            this.gridView5.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.gridView5.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView5.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView5.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView5.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView5.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView5.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView5.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView5.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView5.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView5.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView5.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView5.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView5.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView5.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView5.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView5.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView5.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView5.Appearance.Row.Options.UseFont = true;
            this.gridView5.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView5.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridView5.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView5.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView5.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Código";
            this.gridColumn3.FieldName = "Codigo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Banco";
            this.gridColumn4.FieldName = "Descripcion";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // colCuentaNumero
            // 
            this.colCuentaNumero.Caption = "Cuenta Nro.";
            this.colCuentaNumero.FieldName = "PlanCuentaCodigoLargo";
            this.colCuentaNumero.Name = "colCuentaNumero";
            this.colCuentaNumero.Visible = true;
            this.colCuentaNumero.VisibleIndex = 0;
            this.colCuentaNumero.Width = 146;
            // 
            // Usr_Detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "Usr_Detalles";
            this.Size = new System.Drawing.Size(985, 375);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAsientosdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposText150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCmbSubcuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcModoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBancos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAsientosdet;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposText150;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaNombre;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposCmbCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colpCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colpCodigol;
        private DevExpress.XtraGrid.Columns.GridColumn colpDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCuenta;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit reposCmbSubcuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colsCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colsDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTrackBar trcModoPago;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbBancos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colPase;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colHaber;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposFechas;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaNumero;
    }
}
