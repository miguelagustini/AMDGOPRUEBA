namespace AMDGOINT.Formularios.Practicas.Vista
{
    partial class Frm_Practicasbusq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Practicasbusq));
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGrupoDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupoorden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPracticacodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPracticadescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuncionletra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposNumeros = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tglTipo = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglTipo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposNumeros,
            this.tglTipo});
            this.gridControl.Size = new System.Drawing.Size(570, 186);
            this.gridControl.TabIndex = 1;
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
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
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
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGrupoDescr,
            this.colGrupoorden,
            this.colPracticacodigo,
            this.colPracticadescr,
            this.colFuncionletra});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindDelay = 300;
            this.gridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsMenu.EnableGroupRowMenu = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView_CustomDrawGroupRow);
            this.gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView_SelectionChanged);
            // 
            // colGrupoDescr
            // 
            this.colGrupoDescr.Caption = "Grupo";
            this.colGrupoDescr.FieldName = "GrupoDescripcion";
            this.colGrupoDescr.Name = "colGrupoDescr";
            this.colGrupoDescr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupoDescr.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupoDescr.Visible = true;
            this.colGrupoDescr.VisibleIndex = 1;
            this.colGrupoDescr.Width = 159;
            // 
            // colGrupoorden
            // 
            this.colGrupoorden.Caption = "Orden";
            this.colGrupoorden.FieldName = "GrupoOrden";
            this.colGrupoorden.Name = "colGrupoorden";
            this.colGrupoorden.OptionsColumn.ShowInCustomizationForm = false;
            this.colGrupoorden.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colPracticacodigo
            // 
            this.colPracticacodigo.Caption = "Código";
            this.colPracticacodigo.FieldName = "Codigo";
            this.colPracticacodigo.Name = "colPracticacodigo";
            this.colPracticacodigo.OptionsColumn.AllowEdit = false;
            this.colPracticacodigo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticacodigo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticacodigo.OptionsColumn.ReadOnly = true;
            this.colPracticacodigo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticacodigo.Visible = true;
            this.colPracticacodigo.VisibleIndex = 2;
            this.colPracticacodigo.Width = 83;
            // 
            // colPracticadescr
            // 
            this.colPracticadescr.Caption = "Práctica";
            this.colPracticadescr.FieldName = "Descripcion";
            this.colPracticadescr.Name = "colPracticadescr";
            this.colPracticadescr.OptionsColumn.AllowEdit = false;
            this.colPracticadescr.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticadescr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticadescr.OptionsColumn.ReadOnly = true;
            this.colPracticadescr.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticadescr.Visible = true;
            this.colPracticadescr.VisibleIndex = 3;
            this.colPracticadescr.Width = 475;
            // 
            // colFuncionletra
            // 
            this.colFuncionletra.Caption = "Func.";
            this.colFuncionletra.FieldName = "FuncionLetra";
            this.colFuncionletra.Name = "colFuncionletra";
            this.colFuncionletra.OptionsColumn.AllowEdit = false;
            this.colFuncionletra.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colFuncionletra.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFuncionletra.OptionsColumn.ReadOnly = true;
            this.colFuncionletra.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colFuncionletra.Visible = true;
            this.colFuncionletra.VisibleIndex = 4;
            this.colFuncionletra.Width = 71;
            // 
            // reposNumeros
            // 
            this.reposNumeros.AutoHeight = false;
            this.reposNumeros.Mask.EditMask = "n2";
            this.reposNumeros.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumeros.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumeros.Name = "reposNumeros";
            // 
            // tglTipo
            // 
            this.tglTipo.AutoHeight = false;
            this.tglTipo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tglTipo.Name = "tglTipo";
            this.tglTipo.OffText = "Porcentual %";
            this.tglTipo.OnText = "Fijo $";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.36111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.63889F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 254);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(448, 195);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 56);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Continuar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Frm_Practicasbusq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 254);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.IconOptions.ShowIcon = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Practicasbusq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de prácticas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Usr_Practicasbusq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglTipo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoorden;
        private DevExpress.XtraGrid.Columns.GridColumn colPracticacodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPracticadescr;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncionletra;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumeros;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch tglTipo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
    }
}
