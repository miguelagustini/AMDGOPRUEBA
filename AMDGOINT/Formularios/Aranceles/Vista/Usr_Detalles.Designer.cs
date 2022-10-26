namespace AMDGOINT.Formularios.Aranceles.Vista
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usr_Detalles));
            this.colIncluir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposIncluir = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGrupoDescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupoorden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPracticacodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPracticadescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuncionletra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tglTipo = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposNumeros = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDefecto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdenlista = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDefiniciongral = new DevExpress.XtraBars.BarButtonItem();
            this.btnAgregapractica = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.reposIncluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colIncluir
            // 
            this.colIncluir.Caption = "Incluir";
            this.colIncluir.ColumnEdit = this.reposIncluir;
            this.colIncluir.FieldName = "PracticaIncluir";
            this.colIncluir.Name = "colIncluir";
            this.colIncluir.Visible = true;
            this.colIncluir.VisibleIndex = 4;
            this.colIncluir.Width = 80;
            // 
            // reposIncluir
            // 
            this.reposIncluir.AutoHeight = false;
            this.reposIncluir.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.reposIncluir.Name = "reposIncluir";
            this.reposIncluir.OffText = "Excluir";
            this.reposIncluir.OnText = "Incluir";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposNumeros,
            this.tglTipo,
            this.reposIncluir});
            this.gridControl.Size = new System.Drawing.Size(967, 432);
            this.gridControl.TabIndex = 0;
            this.gridControl.ToolTipController = this.toolTipController;
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
            this.colFuncionletra,
            this.colValorTipo,
            this.colValor,
            this.colIncluir,
            this.colDefecto,
            this.colOrdenlista});
            gridFormatRule1.Column = this.colIncluir;
            gridFormatRule1.ColumnApplyTo = this.colIncluir;
            gridFormatRule1.Name = "LetraRojaExclusion";
            formatConditionRuleValue1.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            formatConditionRuleValue1.Appearance.Options.HighPriority = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "Not [PracticaIncluir]";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsMenu.EnableGroupRowMenu = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView_CustomDrawGroupRow);
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView_CustomColumnSort);
            // 
            // colGrupoDescr
            // 
            this.colGrupoDescr.Caption = "Grupo";
            this.colGrupoDescr.FieldName = "GrupoDescripcion";
            this.colGrupoDescr.Name = "colGrupoDescr";
            this.colGrupoDescr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupoDescr.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupoDescr.Visible = true;
            this.colGrupoDescr.VisibleIndex = 0;
            this.colGrupoDescr.Width = 148;
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
            this.colPracticacodigo.FieldName = "PracticaCodigo";
            this.colPracticacodigo.Name = "colPracticacodigo";
            this.colPracticacodigo.OptionsColumn.AllowEdit = false;
            this.colPracticacodigo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticacodigo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticacodigo.OptionsColumn.ReadOnly = true;
            this.colPracticacodigo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticacodigo.Visible = true;
            this.colPracticacodigo.VisibleIndex = 1;
            this.colPracticacodigo.Width = 77;
            // 
            // colPracticadescr
            // 
            this.colPracticadescr.Caption = "Práctica";
            this.colPracticadescr.FieldName = "PracticaDescripcion";
            this.colPracticadescr.Name = "colPracticadescr";
            this.colPracticadescr.OptionsColumn.AllowEdit = false;
            this.colPracticadescr.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticadescr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticadescr.OptionsColumn.ReadOnly = true;
            this.colPracticadescr.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colPracticadescr.Visible = true;
            this.colPracticadescr.VisibleIndex = 2;
            this.colPracticadescr.Width = 377;
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
            this.colFuncionletra.VisibleIndex = 3;
            this.colFuncionletra.Width = 76;
            // 
            // colValorTipo
            // 
            this.colValorTipo.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorTipo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValorTipo.Caption = "Tipo Valor";
            this.colValorTipo.ColumnEdit = this.tglTipo;
            this.colValorTipo.FieldName = "ValorTipo";
            this.colValorTipo.Name = "colValorTipo";
            this.colValorTipo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colValorTipo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValorTipo.OptionsEditForm.VisibleIndex = 1;
            this.colValorTipo.Visible = true;
            this.colValorTipo.VisibleIndex = 5;
            this.colValorTipo.Width = 108;
            // 
            // tglTipo
            // 
            this.tglTipo.AutoHeight = false;
            this.tglTipo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tglTipo.Name = "tglTipo";
            this.tglTipo.OffText = "Porcentual %";
            this.tglTipo.OnText = "Fijo $";
            // 
            // colValor
            // 
            this.colValor.AppearanceCell.Options.UseTextOptions = true;
            this.colValor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.AppearanceHeader.Options.UseTextOptions = true;
            this.colValor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.Caption = "Valor";
            this.colValor.ColumnEdit = this.reposNumeros;
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colValor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colValor.OptionsEditForm.VisibleIndex = 2;
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 6;
            this.colValor.Width = 132;
            // 
            // reposNumeros
            // 
            this.reposNumeros.AutoHeight = false;
            this.reposNumeros.Mask.EditMask = "n2";
            this.reposNumeros.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumeros.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumeros.Name = "reposNumeros";
            // 
            // colDefecto
            // 
            this.colDefecto.AppearanceCell.Options.UseTextOptions = true;
            this.colDefecto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDefecto.AppearanceHeader.Options.UseTextOptions = true;
            this.colDefecto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDefecto.Caption = "Por Defecto";
            this.colDefecto.ColumnEdit = this.reposNumeros;
            this.colDefecto.FieldName = "ValorDefecto";
            this.colDefecto.Name = "colDefecto";
            this.colDefecto.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDefecto.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDefecto.OptionsEditForm.VisibleIndex = 3;
            this.colDefecto.Visible = true;
            this.colDefecto.VisibleIndex = 7;
            this.colDefecto.Width = 115;
            // 
            // colOrdenlista
            // 
            this.colOrdenlista.FieldName = "OrdenLista";
            this.colOrdenlista.Name = "colOrdenlista";
            this.colOrdenlista.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOrdenlista.OptionsColumn.ShowInCustomizationForm = false;
            this.colOrdenlista.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // toolTipController
            // 
            this.toolTipController.AutoPopDelay = 8000;
            this.toolTipController.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController_GetActiveObjectInfo);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDefiniciongral),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAgregapractica)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // btnDefiniciongral
            // 
            this.btnDefiniciongral.Caption = "Definición general";
            this.btnDefiniciongral.Id = 0;
            this.btnDefiniciongral.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDefiniciongral.ImageOptions.Image")));
            this.btnDefiniciongral.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDefiniciongral.ImageOptions.LargeImage")));
            this.btnDefiniciongral.Name = "btnDefiniciongral";
            this.btnDefiniciongral.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDefiniciongral_ItemClick);
            // 
            // btnAgregapractica
            // 
            this.btnAgregapractica.Caption = "Agregar prácticas";
            this.btnAgregapractica.Id = 1;
            this.btnAgregapractica.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregapractica.ImageOptions.Image")));
            this.btnAgregapractica.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregapractica.ImageOptions.LargeImage")));
            this.btnAgregapractica.Name = "btnAgregapractica";
            this.btnAgregapractica.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregapractica_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDefiniciongral,
            this.btnAgregapractica});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(967, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 432);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(967, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 432);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(967, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 432);
            // 
            // Usr_Detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Usr_Detalles";
            this.Size = new System.Drawing.Size(967, 432);
            ((System.ComponentModel.ISupportInitialize)(this.reposIncluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoDescr;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoorden;
        private DevExpress.XtraGrid.Columns.GridColumn colPracticacodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPracticadescr;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncionletra;
        private DevExpress.XtraGrid.Columns.GridColumn colValorTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
        private DevExpress.XtraGrid.Columns.GridColumn colDefecto;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumeros;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdenlista;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch tglTipo;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnDefiniciongral;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAgregapractica;
        private DevExpress.XtraGrid.Columns.GridColumn colIncluir;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch reposIncluir;
    }
}
