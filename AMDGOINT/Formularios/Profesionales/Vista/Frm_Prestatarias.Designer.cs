namespace AMDGOINT.Formularios.Profesionales.Vista
{
    partial class Frm_Prestatarias
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Prestatarias));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_Registro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_Prestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPrestataria = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colpIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFechas = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposchkempadrona = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestataria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposchkempadrona)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbPrestataria});
            this.gridControl.Size = new System.Drawing.Size(604, 228);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_Registro,
            this.colID_Prestataria,
            this.colEstado});
            gridFormatRule1.Name = "Format0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsFind.FindDelay = 300;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewDomi_KeyDown);
            // 
            // colID_Registro
            // 
            this.colID_Registro.FieldName = "IDRegistro";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.AllowEdit = false;
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colID_Prestataria
            // 
            this.colID_Prestataria.Caption = "Prestataria";
            this.colID_Prestataria.ColumnEdit = this.cmbPrestataria;
            this.colID_Prestataria.FieldName = "IDPrestataria";
            this.colID_Prestataria.Name = "colID_Prestataria";
            this.colID_Prestataria.OptionsEditForm.RowSpan = 2;
            this.colID_Prestataria.Visible = true;
            this.colID_Prestataria.VisibleIndex = 0;
            // 
            // cmbPrestataria
            // 
            this.cmbPrestataria.AutoHeight = false;
            this.cmbPrestataria.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrestataria.DisplayMember = "Nombre";
            this.cmbPrestataria.Name = "cmbPrestataria";
            this.cmbPrestataria.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.cmbPrestataria.ValueMember = "IDRegistro";
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colpIDRegistro,
            this.colpNombre,
            this.colpAbreviatura});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colpIDRegistro
            // 
            this.colpIDRegistro.Caption = "IDRegistro";
            this.colpIDRegistro.FieldName = "IDRegistro";
            this.colpIDRegistro.Name = "colpIDRegistro";
            this.colpIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colpNombre
            // 
            this.colpNombre.Caption = "Prestataria";
            this.colpNombre.FieldName = "Nombre";
            this.colpNombre.Name = "colpNombre";
            this.colpNombre.Visible = true;
            this.colpNombre.VisibleIndex = 0;
            this.colpNombre.Width = 539;
            // 
            // colpAbreviatura
            // 
            this.colpAbreviatura.Caption = "Descripción";
            this.colpAbreviatura.FieldName = "Abreviatura";
            this.colpAbreviatura.Name = "colpAbreviatura";
            this.colpAbreviatura.Visible = true;
            this.colpAbreviatura.VisibleIndex = 1;
            this.colpAbreviatura.Width = 173;
            // 
            // colEstado
            // 
            this.colEstado.AppearanceCell.Options.UseTextOptions = true;
            this.colEstado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEstado.AppearanceHeader.Options.UseTextOptions = true;
            this.colEstado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEstado.Caption = "Empadronado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.MaxWidth = 95;
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsEditForm.StartNewRow = true;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 1;
            this.colEstado.Width = 95;
            // 
            // reposFechas
            // 
            this.reposFechas.AutoHeight = false;
            this.reposFechas.Mask.EditMask = "dd/MM/yyyy";
            this.reposFechas.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFechas.Mask.UseMaskAsDisplayFormat = true;
            this.reposFechas.Name = "reposFechas";
            // 
            // reposchkempadrona
            // 
            this.reposchkempadrona.AutoHeight = false;
            this.reposchkempadrona.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("reposchkempadrona.ImageOptions.ImageChecked")));
            this.reposchkempadrona.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("reposchkempadrona.ImageOptions.ImageUnchecked")));
            this.reposchkempadrona.Name = "reposchkempadrona";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 234);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Frm_Prestatarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 234);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_Prestatarias";
            this.Text = "Prestatarias";
            this.Load += new System.EventHandler(this.Frm_Contactos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestataria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposchkempadrona)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Registro;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Prestataria;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFechas;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposchkempadrona;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbPrestataria;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colpIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colpNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colpAbreviatura;
    }
}