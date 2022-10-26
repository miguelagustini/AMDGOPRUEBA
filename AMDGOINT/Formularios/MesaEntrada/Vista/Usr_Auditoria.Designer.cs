namespace AMDGOINT.Formularios.MesaEntrada.Vista
{
    partial class Usr_Auditoria
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaAud = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDateedit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAuditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDateedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDateedit.CalendarTimeProperties)).BeginInit();
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
            this.reposDateedit,
            this.reposMemo});
            this.gridControl.Size = new System.Drawing.Size(655, 221);
            this.gridControl.TabIndex = 1;
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
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
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
            this.colFechaAud,
            this.colAuditor,
            this.colEstado,
            this.colObservacion});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.ShownEditor += new System.EventHandler(this.gridView_ShownEditor);
            // 
            // colFechaAud
            // 
            this.colFechaAud.Caption = "Fecha Auditoría";
            this.colFechaAud.ColumnEdit = this.reposDateedit;
            this.colFechaAud.FieldName = "AuditoriaFecha";
            this.colFechaAud.Name = "colFechaAud";
            this.colFechaAud.Visible = true;
            this.colFechaAud.VisibleIndex = 0;
            this.colFechaAud.Width = 202;
            // 
            // reposDateedit
            // 
            this.reposDateedit.AutoHeight = false;
            this.reposDateedit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDateedit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDateedit.Mask.EditMask = "dd-MM-yyyy H:m:s";
            this.reposDateedit.Mask.UseMaskAsDisplayFormat = true;
            this.reposDateedit.Name = "reposDateedit";
            // 
            // colAuditor
            // 
            this.colAuditor.Caption = "Auditor";
            this.colAuditor.FieldName = "AuditoriaPersona";
            this.colAuditor.Name = "colAuditor";
            this.colAuditor.Visible = true;
            this.colAuditor.VisibleIndex = 1;
            this.colAuditor.Width = 453;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "AuditoriaEstado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 2;
            // 
            // colObservacion
            // 
            this.colObservacion.Caption = "Observación";
            this.colObservacion.ColumnEdit = this.reposMemo;
            this.colObservacion.FieldName = "AuditoriaObservacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.Visible = true;
            this.colObservacion.VisibleIndex = 3;
            // 
            // reposMemo
            // 
            this.reposMemo.Name = "reposMemo";
            // 
            // Usr_Auditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "Usr_Auditoria";
            this.Size = new System.Drawing.Size(655, 221);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDateedit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDateedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAud;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDateedit;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
    }
}
