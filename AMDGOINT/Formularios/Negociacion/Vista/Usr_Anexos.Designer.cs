namespace AMDGOINT.Formularios.Negociacion.Vista
{
    partial class Usr_Anexos
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colBorraRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigoos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCodigos = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCodigoAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDescripcion = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposValortxt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCodigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposValortxt)).BeginInit();
            this.SuspendLayout();
            // 
            // colBorraRegistro
            // 
            this.colBorraRegistro.Caption = "BorraReg";
            this.colBorraRegistro.FieldName = "BorraRegistro";
            this.colBorraRegistro.Name = "colBorraRegistro";
            this.colBorraRegistro.OptionsColumn.AllowEdit = false;
            this.colBorraRegistro.OptionsColumn.ShowInCustomizationForm = false;
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
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMemo,
            this.reposCodigos,
            this.reposDescripcion,
            this.reposValortxt});
            this.gridControl.Size = new System.Drawing.Size(628, 421);
            this.gridControl.TabIndex = 1;
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
            this.colCodigoos,
            this.colCodigoAm,
            this.colDescripcion,
            this.colObservacion,
            this.colValor,
            this.colBorraRegistro});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colBorraRegistro;
            gridFormatRule1.Name = "BorraRegistro";
            formatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Firebrick;
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[BorraRegistro]";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colCodigoos
            // 
            this.colCodigoos.Caption = "Código Prestadora";
            this.colCodigoos.ColumnEdit = this.reposCodigos;
            this.colCodigoos.FieldName = "PracticaCodigoPrestadora";
            this.colCodigoos.Name = "colCodigoos";
            this.colCodigoos.Visible = true;
            this.colCodigoos.VisibleIndex = 0;
            this.colCodigoos.Width = 94;
            // 
            // reposCodigos
            // 
            this.reposCodigos.AutoHeight = false;
            this.reposCodigos.Mask.EditMask = "[a-zA-Z0-9-]+";
            this.reposCodigos.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposCodigos.Mask.UseMaskAsDisplayFormat = true;
            this.reposCodigos.MaxLength = 10;
            this.reposCodigos.Name = "reposCodigos";
            // 
            // colCodigoAm
            // 
            this.colCodigoAm.Caption = "Código Amdgo";
            this.colCodigoAm.ColumnEdit = this.reposCodigos;
            this.colCodigoAm.FieldName = "PracticaCodigoAmdgo";
            this.colCodigoAm.Name = "colCodigoAm";
            this.colCodigoAm.Visible = true;
            this.colCodigoAm.VisibleIndex = 1;
            this.colCodigoAm.Width = 106;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.ColumnEdit = this.reposDescripcion;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 2;
            this.colDescripcion.Width = 441;
            // 
            // reposDescripcion
            // 
            this.reposDescripcion.AutoHeight = false;
            this.reposDescripcion.Mask.EditMask = "[^\']*";
            this.reposDescripcion.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposDescripcion.Mask.UseMaskAsDisplayFormat = true;
            this.reposDescripcion.MaxLength = 200;
            this.reposDescripcion.Name = "reposDescripcion";
            // 
            // colObservacion
            // 
            this.colObservacion.Caption = "Observación";
            this.colObservacion.ColumnEdit = this.reposMemo;
            this.colObservacion.FieldName = "Observacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Visible = true;
            this.colObservacion.VisibleIndex = 3;
            this.colObservacion.Width = 257;
            // 
            // reposMemo
            // 
            this.reposMemo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.reposMemo.MaxLength = 1000;
            this.reposMemo.Name = "reposMemo";
            this.reposMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reposMemo_KeyDown);
            // 
            // colValor
            // 
            this.colValor.AppearanceCell.Options.UseTextOptions = true;
            this.colValor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.AppearanceHeader.Options.UseTextOptions = true;
            this.colValor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.Caption = "Valor";
            this.colValor.ColumnEdit = this.reposValortxt;
            this.colValor.FieldName = "Importe";
            this.colValor.Name = "colValor";
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 4;
            this.colValor.Width = 192;
            // 
            // reposValortxt
            // 
            this.reposValortxt.AutoHeight = false;
            this.reposValortxt.Mask.EditMask = "[^\']*";
            this.reposValortxt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposValortxt.Mask.UseMaskAsDisplayFormat = true;
            this.reposValortxt.MaxLength = 35;
            this.reposValortxt.Name = "reposValortxt";
            // 
            // Usr_Anexos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "Usr_Anexos";
            this.Size = new System.Drawing.Size(628, 421);
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCodigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposValortxt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoos;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposCodigos;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoAm;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposValortxt;
        private DevExpress.XtraGrid.Columns.GridColumn colBorraRegistro;
    }
}
