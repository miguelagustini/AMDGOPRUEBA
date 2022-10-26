namespace AMDGOINT.Formularios.Profesionales.Vista
{
    partial class Frm_DirecCont
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
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.gridViewConta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID_Detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ccolIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ccolIDDomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ccolTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposTelefono = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ccolEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewDomi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_Detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_Registro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_Profesional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repostext100 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repostext50 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPiso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repostext10 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDepartamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_Localidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCmblocalidades = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDregistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbTipo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tglEstado = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repostext150 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBorrar = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDomi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCmblocalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext150)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewConta
            // 
            this.gridViewConta.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewConta.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewConta.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewConta.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewConta.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewConta.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewConta.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewConta.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewConta.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewConta.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewConta.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewConta.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewConta.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewConta.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewConta.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewConta.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewConta.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewConta.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewConta.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewConta.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewConta.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewConta.Appearance.Row.Options.UseFont = true;
            this.gridViewConta.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewConta.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewConta.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewConta.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewConta.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewConta.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewConta.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewConta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID_Detalle,
            this.ccolIDRegistro,
            this.ccolIDDomicilio,
            this.ccolTelefono,
            this.ccolEmail,
            this.colBorrar});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colBorrar;
            gridFormatRule1.Name = "Borrar";
            formatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue1.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridViewConta.FormatRules.Add(gridFormatRule1);
            this.gridViewConta.GridControl = this.gridControl;
            this.gridViewConta.Name = "gridViewConta";
            this.gridViewConta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewConta.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridViewConta.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewConta.OptionsDetail.ShowDetailTabs = false;
            this.gridViewConta.OptionsFind.AllowFindPanel = false;
            this.gridViewConta.OptionsView.ShowGroupPanel = false;
            this.gridViewConta.OptionsView.ShowIndicator = false;
            this.gridViewConta.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridViewConta.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewConta_PopupMenuShowing);
            this.gridViewConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewConta_KeyDown);
            // 
            // ID_Detalle
            // 
            this.ID_Detalle.Caption = "IDDetalle";
            this.ID_Detalle.FieldName = "ID_Detalle";
            this.ID_Detalle.Name = "ID_Detalle";
            this.ID_Detalle.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // ccolIDRegistro
            // 
            this.ccolIDRegistro.Caption = "ID_Registro";
            this.ccolIDRegistro.FieldName = "ID_Registro";
            this.ccolIDRegistro.Name = "ccolIDRegistro";
            this.ccolIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // ccolIDDomicilio
            // 
            this.ccolIDDomicilio.Caption = "ID_Domicilio";
            this.ccolIDDomicilio.FieldName = "ID_Direccion";
            this.ccolIDDomicilio.Name = "ccolIDDomicilio";
            this.ccolIDDomicilio.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // ccolTelefono
            // 
            this.ccolTelefono.Caption = "Teléfono";
            this.ccolTelefono.ColumnEdit = this.reposTelefono;
            this.ccolTelefono.FieldName = "Telefono";
            this.ccolTelefono.Name = "ccolTelefono";
            this.ccolTelefono.Visible = true;
            this.ccolTelefono.VisibleIndex = 0;
            // 
            // reposTelefono
            // 
            this.reposTelefono.AutoHeight = false;
            this.reposTelefono.Mask.EditMask = "[^\']*";
            this.reposTelefono.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposTelefono.Mask.UseMaskAsDisplayFormat = true;
            this.reposTelefono.MaxLength = 50;
            this.reposTelefono.Name = "reposTelefono";
            // 
            // ccolEmail
            // 
            this.ccolEmail.Caption = "E-Mail";
            this.ccolEmail.ColumnEdit = this.reposEmail;
            this.ccolEmail.FieldName = "Email";
            this.ccolEmail.Name = "ccolEmail";
            this.ccolEmail.Visible = true;
            this.ccolEmail.VisibleIndex = 1;
            // 
            // reposEmail
            // 
            this.reposEmail.AutoHeight = false;
            this.reposEmail.Mask.EditMask = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,64}";
            this.reposEmail.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposEmail.Mask.UseMaskAsDisplayFormat = true;
            this.reposEmail.MaxLength = 150;
            this.reposEmail.Name = "reposEmail";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewConta;
            gridLevelNode1.RelationName = "Contactos";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridViewDomi;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbTipo,
            this.repCmblocalidades,
            this.reposEmail,
            this.reposTelefono,
            this.repostext10,
            this.repostext50,
            this.repostext100,
            this.repostext150,
            this.tglEstado});
            this.gridControl.Size = new System.Drawing.Size(610, 234);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDomi,
            this.gridViewConta});
            // 
            // gridViewDomi
            // 
            this.gridViewDomi.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDomi.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewDomi.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDomi.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewDomi.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewDomi.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewDomi.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDomi.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewDomi.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDomi.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewDomi.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewDomi.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewDomi.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewDomi.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewDomi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewDomi.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDomi.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDomi.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewDomi.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDomi.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewDomi.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewDomi.Appearance.Row.Options.UseFont = true;
            this.gridViewDomi.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewDomi.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridViewDomi.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewDomi.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewDomi.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewDomi.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewDomi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewDomi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_Detalle,
            this.colID_Registro,
            this.colID_Profesional,
            this.colDomicilio,
            this.colCalle,
            this.colNumero,
            this.colPiso,
            this.colDepartamento,
            this.colID_Localidad,
            this.colTipo,
            this.colEstado});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colEstado;
            gridFormatRule2.Name = "Inactivo";
            formatConditionRuleValue2.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue2.Appearance.Options.HighPriority = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = false;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridViewDomi.FormatRules.Add(gridFormatRule2);
            this.gridViewDomi.GridControl = this.gridControl;
            this.gridViewDomi.Name = "gridViewDomi";
            this.gridViewDomi.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDomi.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDomi.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridViewDomi.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewDomi.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewDomi.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDomi.OptionsFind.AllowFindPanel = false;
            this.gridViewDomi.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridViewDomi.OptionsView.ShowGroupPanel = false;
            this.gridViewDomi.OptionsView.ShowIndicator = false;
            this.gridViewDomi.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridViewDomi.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewDomi_PopupMenuShowing);
            this.gridViewDomi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewDomi_KeyDown);
            // 
            // colID_Detalle
            // 
            this.colID_Detalle.FieldName = "ID_Detalle";
            this.colID_Detalle.Name = "colID_Detalle";
            this.colID_Detalle.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colID_Registro
            // 
            this.colID_Registro.FieldName = "IDRegistro";
            this.colID_Registro.Name = "colID_Registro";
            this.colID_Registro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colID_Profesional
            // 
            this.colID_Profesional.FieldName = "IDProfesional";
            this.colID_Profesional.Name = "colID_Profesional";
            this.colID_Profesional.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDomicilio
            // 
            this.colDomicilio.FieldName = "Domicilio";
            this.colDomicilio.Name = "colDomicilio";
            this.colDomicilio.OptionsColumn.AllowEdit = false;
            this.colDomicilio.OptionsColumn.ReadOnly = true;
            this.colDomicilio.Visible = true;
            this.colDomicilio.VisibleIndex = 6;
            // 
            // colCalle
            // 
            this.colCalle.Caption = "Calle";
            this.colCalle.ColumnEdit = this.repostext100;
            this.colCalle.FieldName = "Calle";
            this.colCalle.Name = "colCalle";
            this.colCalle.Visible = true;
            this.colCalle.VisibleIndex = 1;
            // 
            // repostext100
            // 
            this.repostext100.AutoHeight = false;
            this.repostext100.Mask.EditMask = "[^\']*";
            this.repostext100.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repostext100.Mask.UseMaskAsDisplayFormat = true;
            this.repostext100.MaxLength = 100;
            this.repostext100.Name = "repostext100";
            // 
            // colNumero
            // 
            this.colNumero.Caption = "Nro.";
            this.colNumero.ColumnEdit = this.repostext50;
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 2;
            // 
            // repostext50
            // 
            this.repostext50.AutoHeight = false;
            this.repostext50.Mask.EditMask = "[^\']*";
            this.repostext50.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repostext50.Mask.UseMaskAsDisplayFormat = true;
            this.repostext50.MaxLength = 50;
            this.repostext50.Name = "repostext50";
            // 
            // colPiso
            // 
            this.colPiso.Caption = "Piso";
            this.colPiso.ColumnEdit = this.repostext10;
            this.colPiso.FieldName = "Piso";
            this.colPiso.Name = "colPiso";
            this.colPiso.Visible = true;
            this.colPiso.VisibleIndex = 4;
            // 
            // repostext10
            // 
            this.repostext10.AutoHeight = false;
            this.repostext10.Mask.EditMask = "[^\']*";
            this.repostext10.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repostext10.Mask.UseMaskAsDisplayFormat = true;
            this.repostext10.MaxLength = 10;
            this.repostext10.Name = "repostext10";
            // 
            // colDepartamento
            // 
            this.colDepartamento.Caption = "Dpto.";
            this.colDepartamento.ColumnEdit = this.repostext10;
            this.colDepartamento.FieldName = "Departamento";
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.Visible = true;
            this.colDepartamento.VisibleIndex = 3;
            // 
            // colID_Localidad
            // 
            this.colID_Localidad.Caption = "Localidad";
            this.colID_Localidad.ColumnEdit = this.repCmblocalidades;
            this.colID_Localidad.FieldName = "IDLocalidad";
            this.colID_Localidad.Name = "colID_Localidad";
            this.colID_Localidad.Visible = true;
            this.colID_Localidad.VisibleIndex = 0;
            // 
            // repCmblocalidades
            // 
            this.repCmblocalidades.AutoHeight = false;
            this.repCmblocalidades.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCmblocalidades.DisplayMember = "Localidad";
            this.repCmblocalidades.Name = "repCmblocalidades";
            this.repCmblocalidades.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.repCmblocalidades.ValueMember = "ID_Registro";
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDregistro,
            this.colLocalidad,
            this.colProvincia});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIDregistro
            // 
            this.colIDregistro.Caption = "ID_Registro";
            this.colIDregistro.FieldName = "ID_Registro";
            this.colIDregistro.Name = "colIDregistro";
            this.colIDregistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colLocalidad
            // 
            this.colLocalidad.Caption = "Localidades";
            this.colLocalidad.FieldName = "Localidad";
            this.colLocalidad.Name = "colLocalidad";
            this.colLocalidad.Visible = true;
            this.colLocalidad.VisibleIndex = 0;
            // 
            // colProvincia
            // 
            this.colProvincia.Caption = "Provincias";
            this.colProvincia.FieldName = "Provincia";
            this.colProvincia.Name = "colProvincia";
            this.colProvincia.Visible = true;
            this.colProvincia.VisibleIndex = 1;
            // 
            // colTipo
            // 
            this.colTipo.ColumnEdit = this.cmbTipo;
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 5;
            // 
            // cmbTipo
            // 
            this.cmbTipo.AutoHeight = false;
            this.cmbTipo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipo.Items.AddRange(new object[] {
            "Personal",
            "Laboral"});
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.ColumnEdit = this.tglEstado;
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            // 
            // tglEstado
            // 
            this.tglEstado.AutoHeight = false;
            this.tglEstado.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tglEstado.Name = "tglEstado";
            this.tglEstado.OffText = "Inactivo";
            this.tglEstado.OnText = "Activo";
            // 
            // repostext150
            // 
            this.repostext150.AutoHeight = false;
            this.repostext150.Mask.EditMask = "[^\']*";
            this.repostext150.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repostext150.Mask.UseMaskAsDisplayFormat = true;
            this.repostext150.MaxLength = 150;
            this.repostext150.Name = "repostext150";
            // 
            // colBorrar
            // 
            this.colBorrar.Caption = "Borrar";
            this.colBorrar.FieldName = "_BorraRegistro";
            this.colBorrar.Name = "colBorrar";
            this.colBorrar.OptionsColumn.ShowInCustomizationForm = false;
            this.colBorrar.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // Frm_DirecCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 234);
            this.Controls.Add(this.gridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_DirecCont";
            this.Text = "Direcciones y Contactos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DirecCont_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Contactos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDomi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCmblocalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repostext150)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDomi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewConta;
        private DevExpress.XtraGrid.Columns.GridColumn ccolIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn ccolIDDomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn ccolTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn ccolEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Detalle;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Registro;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Profesional;
        private DevExpress.XtraGrid.Columns.GridColumn colDomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Localidad;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn ID_Detalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repCmblocalidades;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colIDregistro;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalidad;
        private DevExpress.XtraGrid.Columns.GridColumn colProvincia;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbTipo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposEmail;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colPiso;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartamento;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repostext10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repostext50;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repostext100;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repostext150;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch tglEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrar;
    }
}