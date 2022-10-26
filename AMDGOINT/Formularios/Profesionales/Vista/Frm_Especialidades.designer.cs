namespace AMDGOINT.Formularios.Profesionales.Vista
{
    partial class Frm_Especialidades
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Especialidades));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDregistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEspecialidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbEspecialidad = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ccolIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ccolDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroregistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colRecertificado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEspecialidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbEspecialidad,
            this.reposNumber,
            this.reposDate,
            this.reposMemo});
            this.gridControl.Size = new System.Drawing.Size(610, 234);
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
            this.colIDregistro,
            this.colEspecialidad,
            this.colNroregistro,
            this.colVencimiento,
            this.colRecertificado,
            this.colObservacion});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView_InvalidRowException);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colIDregistro
            // 
            this.colIDregistro.Caption = "IDRegistro";
            this.colIDregistro.FieldName = "IDRegistro";
            this.colIDregistro.Name = "colIDregistro";
            this.colIDregistro.OptionsColumn.AllowEdit = false;
            this.colIDregistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colEspecialidad
            // 
            this.colEspecialidad.Caption = "Especialidad";
            this.colEspecialidad.ColumnEdit = this.cmbEspecialidad;
            this.colEspecialidad.FieldName = "IDEspecialidad";
            this.colEspecialidad.Name = "colEspecialidad";
            this.colEspecialidad.Visible = true;
            this.colEspecialidad.VisibleIndex = 0;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.cmbEspecialidad.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 25, true, true, true, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cmbEspecialidad.DisplayMember = "Descripcion";
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.cmbEspecialidad.ValueMember = "IDRegistro";
            this.cmbEspecialidad.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbEspecialidad_ButtonPressed);
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
            this.ccolIDRegistro,
            this.ccolDescripcion});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ccolIDRegistro
            // 
            this.ccolIDRegistro.Caption = "IDRegistro";
            this.ccolIDRegistro.FieldName = "IDRegistro";
            this.ccolIDRegistro.Name = "ccolIDRegistro";
            this.ccolIDRegistro.OptionsColumn.AllowEdit = false;
            // 
            // ccolDescripcion
            // 
            this.ccolDescripcion.Caption = "Especialidad";
            this.ccolDescripcion.FieldName = "Descripcion";
            this.ccolDescripcion.Name = "ccolDescripcion";
            this.ccolDescripcion.OptionsColumn.AllowEdit = false;
            this.ccolDescripcion.Visible = true;
            this.ccolDescripcion.VisibleIndex = 0;
            // 
            // colNroregistro
            // 
            this.colNroregistro.AppearanceCell.Options.UseTextOptions = true;
            this.colNroregistro.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNroregistro.Caption = "Registro Nro.";
            this.colNroregistro.ColumnEdit = this.reposNumber;
            this.colNroregistro.FieldName = "NroRegistro";
            this.colNroregistro.Name = "colNroregistro";
            this.colNroregistro.Visible = true;
            this.colNroregistro.VisibleIndex = 1;
            // 
            // reposNumber
            // 
            this.reposNumber.AutoHeight = false;
            this.reposNumber.Mask.EditMask = "d";
            this.reposNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumber.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumber.MaxLength = 10;
            this.reposNumber.Name = "reposNumber";
            // 
            // colVencimiento
            // 
            this.colVencimiento.AppearanceCell.Options.UseTextOptions = true;
            this.colVencimiento.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colVencimiento.Caption = "Vencimiento";
            this.colVencimiento.ColumnEdit = this.reposDate;
            this.colVencimiento.FieldName = "Vencimiento";
            this.colVencimiento.Name = "colVencimiento";
            this.colVencimiento.Visible = true;
            this.colVencimiento.VisibleIndex = 2;
            // 
            // reposDate
            // 
            this.reposDate.AutoHeight = false;
            this.reposDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.reposDate.Mask.EditMask = "dd/MM/yyyy";
            this.reposDate.Mask.UseMaskAsDisplayFormat = true;
            this.reposDate.Name = "reposDate";
            this.reposDate.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colRecertificado
            // 
            this.colRecertificado.Caption = "Recertificado";
            this.colRecertificado.FieldName = "Recertificado";
            this.colRecertificado.Name = "colRecertificado";
            this.colRecertificado.Visible = true;
            this.colRecertificado.VisibleIndex = 3;
            // 
            // colObservacion
            // 
            this.colObservacion.AppearanceCell.Options.UseTextOptions = true;
            this.colObservacion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colObservacion.Caption = "Observación";
            this.colObservacion.ColumnEdit = this.reposMemo;
            this.colObservacion.FieldName = "Observacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Visible = true;
            this.colObservacion.VisibleIndex = 4;
            // 
            // reposMemo
            // 
            this.reposMemo.MaxLength = 500;
            this.reposMemo.Name = "reposMemo";
            this.reposMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reposMemo_KeyDown);
            // 
            // Frm_Especialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 234);
            this.Controls.Add(this.gridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_Especialidades";
            this.Text = "Especialidades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ProfEspecialidades_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Contactos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEspecialidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colIDregistro;
        private DevExpress.XtraGrid.Columns.GridColumn colEspecialidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbEspecialidad;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ccolIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn ccolDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colNroregistro;
        private DevExpress.XtraGrid.Columns.GridColumn colVencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colRecertificado;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
    }
}