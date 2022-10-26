namespace AMDGOINT.Formularios.Aranceles
{
    partial class Frm_Respuestasos
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Respuestasos));
            this.coBorrareg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDRespuesta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDEncabezado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTexto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRespuesta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposSpinnro = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colBorrareg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBase = new DevExpress.XtraEditors.PanelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposSpinnro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            this.SuspendLayout();
            // 
            // coBorrareg
            // 
            this.coBorrareg.Caption = "Borrar";
            this.coBorrareg.FieldName = "_BorraRegistro";
            this.coBorrareg.Name = "coBorrareg";
            this.coBorrareg.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridViewos
            // 
            this.gridViewos.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewos.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewos.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewos.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewos.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewos.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewos.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewos.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewos.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewos.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewos.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewos.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewos.Appearance.Row.Options.UseFont = true;
            this.gridViewos.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewos.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewos.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewos.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coIDRegistro,
            this.colIDRespuesta,
            this.coObservacion,
            this.coBorrareg});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.coBorrareg;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.True;
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Firebrick;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[_BorraRegistro]";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.gridViewos.FormatRules.Add(gridFormatRule1);
            this.gridViewos.GridControl = this.gridControl;
            this.gridViewos.Name = "gridViewos";
            this.gridViewos.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridViewos.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewos.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewos.OptionsFilter.AllowFilterEditor = false;
            this.gridViewos.OptionsMenu.EnableColumnMenu = false;
            this.gridViewos.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewos.OptionsView.RowAutoHeight = true;
            this.gridViewos.OptionsView.ShowGroupPanel = false;
            this.gridViewos.OptionsView.ShowIndicator = false;
            this.gridViewos.ViewCaption = "Posibles Respuestas";
            this.gridViewos.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridViewos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewos_KeyDown);
            // 
            // coIDRegistro
            // 
            this.coIDRegistro.Caption = "IDRegistro";
            this.coIDRegistro.FieldName = "IDRegistro";
            this.coIDRegistro.Name = "coIDRegistro";
            this.coIDRegistro.OptionsColumn.AllowEdit = false;
            this.coIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            this.coIDRegistro.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colIDRespuesta
            // 
            this.colIDRespuesta.Caption = "IDRespuesta";
            this.colIDRespuesta.FieldName = "IDRespuesta";
            this.colIDRespuesta.Name = "colIDRespuesta";
            this.colIDRespuesta.OptionsColumn.AllowEdit = false;
            this.colIDRespuesta.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDRespuesta.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // coObservacion
            // 
            this.coObservacion.Caption = "Observación";
            this.coObservacion.ColumnEdit = this.reposMemo;
            this.coObservacion.FieldName = "Observacion";
            this.coObservacion.Name = "coObservacion";
            this.coObservacion.Visible = true;
            this.coObservacion.VisibleIndex = 0;
            // 
            // reposMemo
            // 
            this.reposMemo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.reposMemo.MaxLength = 5000;
            this.reposMemo.Name = "reposMemo";
            this.reposMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reposMemo_KeyDown);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewos;
            gridLevelNode1.RelationName = "RespuestaOs";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridViewam;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMemo,
            this.reposSpinnro});
            this.gridControl.Size = new System.Drawing.Size(630, 224);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewam,
            this.gridViewos});
            // 
            // gridViewam
            // 
            this.gridViewam.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewam.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewam.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewam.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewam.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewam.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewam.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewam.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewam.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewam.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewam.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewam.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewam.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewam.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewam.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewam.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewam.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewam.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewam.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewam.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewam.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewam.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewam.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewam.Appearance.Row.Options.UseFont = true;
            this.gridViewam.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridViewam.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.gridViewam.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridViewam.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewam.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewam.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDRegistro,
            this.colIDEncabezado,
            this.colTexto,
            this.colRespuesta,
            this.colBorrareg});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colBorrareg;
            gridFormatRule2.Name = "BorraRegistro";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Firebrick;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "[_BorraRegistro]";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule2.StopIfTrue = true;
            this.gridViewam.FormatRules.Add(gridFormatRule2);
            this.gridViewam.GridControl = this.gridControl;
            this.gridViewam.Name = "gridViewam";
            this.gridViewam.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewam.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewam.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridViewam.OptionsCustomization.AllowGroup = false;
            this.gridViewam.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewam.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewam.OptionsDetail.ShowDetailTabs = false;
            this.gridViewam.OptionsEditForm.EditFormColumnCount = 1;
            this.gridViewam.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridViewam.OptionsMenu.EnableColumnMenu = false;
            this.gridViewam.OptionsPrint.ExpandAllDetails = true;
            this.gridViewam.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewam.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewam.OptionsView.RowAutoHeight = true;
            this.gridViewam.OptionsView.ShowGroupPanel = false;
            this.gridViewam.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridViewam.ShownEditor += new System.EventHandler(this.gridView_ShownEditor);
            this.gridViewam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewam_KeyDown);
            // 
            // colIDRegistro
            // 
            this.colIDRegistro.Caption = "IDRegistro";
            this.colIDRegistro.FieldName = "IDRegistro";
            this.colIDRegistro.Name = "colIDRegistro";
            this.colIDRegistro.OptionsColumn.AllowEdit = false;
            this.colIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colIDEncabezado
            // 
            this.colIDEncabezado.Caption = "IDEncabezado";
            this.colIDEncabezado.FieldName = "IDEncabezado";
            this.colIDEncabezado.Name = "colIDEncabezado";
            // 
            // colTexto
            // 
            this.colTexto.Caption = "Mensaje";
            this.colTexto.ColumnEdit = this.reposMemo;
            this.colTexto.FieldName = "Texto";
            this.colTexto.Name = "colTexto";
            this.colTexto.OptionsEditForm.RowSpan = 8;
            this.colTexto.OptionsEditForm.StartNewRow = true;
            this.colTexto.OptionsEditForm.UseEditorColRowSpan = false;
            this.colTexto.Visible = true;
            this.colTexto.VisibleIndex = 0;
            this.colTexto.Width = 766;
            // 
            // colRespuesta
            // 
            this.colRespuesta.Caption = "Nro. Respuesta";
            this.colRespuesta.ColumnEdit = this.reposSpinnro;
            this.colRespuesta.FieldName = "Numero";
            this.colRespuesta.Name = "colRespuesta";
            this.colRespuesta.Visible = true;
            this.colRespuesta.VisibleIndex = 1;
            this.colRespuesta.Width = 146;
            // 
            // reposSpinnro
            // 
            this.reposSpinnro.AutoHeight = false;
            this.reposSpinnro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposSpinnro.IsFloatValue = false;
            this.reposSpinnro.Mask.EditMask = "N00";
            this.reposSpinnro.MaxLength = 3;
            this.reposSpinnro.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.reposSpinnro.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reposSpinnro.Name = "reposSpinnro";
            this.reposSpinnro.NullText = "1";
            // 
            // colBorrareg
            // 
            this.colBorrareg.Caption = "Borrar";
            this.colBorrareg.FieldName = "_BorraRegistro";
            this.colBorrareg.Name = "colBorrareg";
            this.colBorrareg.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // pnlBase
            // 
            this.pnlBase.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.BorderColor = System.Drawing.Color.White;
            this.pnlBase.Appearance.Options.UseBackColor = true;
            this.pnlBase.Appearance.Options.UseBorderColor = true;
            this.pnlBase.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBase.Controls.Add(this.pnlCenter);
            this.pnlBase.Controls.Add(this.pnlBottom);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(1);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(636, 295);
            this.pnlBase.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Appearance.Options.UseBackColor = true;
            this.pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCenter.Controls.Add(this.tableLayoutPanel1);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(636, 230);
            this.pnlCenter.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 230);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBottom.Controls.Add(this.tableLayoutPanel2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 230);
            this.pnlBottom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBottom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(636, 65);
            this.pnlBottom.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel2.Controls.Add(this.btnAplicar, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(636, 65);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Appearance.Options.UseFont = true;
            this.btnAplicar.AppearanceHovered.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAplicar.AppearanceHovered.Options.UseFont = true;
            this.btnAplicar.AppearancePressed.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.AppearancePressed.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.AppearancePressed.Options.UseBackColor = true;
            this.btnAplicar.AppearancePressed.Options.UseFont = true;
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(487, 3);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAplicar.Size = new System.Drawing.Size(146, 59);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar cambios";
            this.btnAplicar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
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
            // Frm_Respuestasos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 295);
            this.Controls.Add(this.pnlBase);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_Respuestasos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respuestas a Negociación";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposSpinnro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlBase;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewam;
        private DevExpress.XtraGrid.Columns.GridColumn colIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colTexto;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colRespuesta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewos;
        private DevExpress.XtraGrid.Columns.GridColumn colIDEncabezado;
        private DevExpress.XtraGrid.Columns.GridColumn coIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colIDRespuesta;
        private DevExpress.XtraGrid.Columns.GridColumn coObservacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit reposSpinnro;
        private DevExpress.XtraGrid.Columns.GridColumn coBorrareg;
        private DevExpress.XtraGrid.Columns.GridColumn colBorrareg;
    }
}