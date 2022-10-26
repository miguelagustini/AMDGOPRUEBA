namespace AMDGOINT.Formularios.Aranceles
{
    partial class Frm_Otros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Otros));
            this.colBorraRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBase = new DevExpress.XtraEditors.PanelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDEncabezado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposCodigos = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCodigoAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDescripcion = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.reposValortxt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).BeginInit();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCodigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposValortxt)).BeginInit();
            this.SuspendLayout();
            // 
            // colBorraRegistro
            // 
            this.colBorraRegistro.Caption = "BorraReg";
            this.colBorraRegistro.FieldName = "_BorraRegistro";
            this.colBorraRegistro.Name = "colBorraRegistro";
            this.colBorraRegistro.OptionsColumn.AllowEdit = false;
            this.colBorraRegistro.OptionsColumn.ShowInCustomizationForm = false;
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
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposMemo,
            this.reposCodigos,
            this.reposDescripcion,
            this.reposValortxt});
            this.gridControl.Size = new System.Drawing.Size(630, 224);
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
            this.colIDRegistro,
            this.colIDEncabezado,
            this.colCodigoos,
            this.colCodigoAm,
            this.colDescripcion,
            this.colObservacion,
            this.colValor,
            this.colBorraRegistro});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colBorraRegistro;
            gridFormatRule1.Name = "BorraRegistro";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Firebrick;
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "[_BorraRegistro]";
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
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            this.gridView.ShownEditor += new System.EventHandler(this.gridView_ShownEditor);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
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
            this.colIDEncabezado.OptionsColumn.AllowEdit = false;
            this.colIDEncabezado.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCodigoos
            // 
            this.colCodigoos.Caption = "Código Os";
            this.colCodigoos.ColumnEdit = this.reposCodigos;
            this.colCodigoos.FieldName = "CodigoOs";
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
            this.colCodigoAm.Caption = "Codigo Am";
            this.colCodigoAm.ColumnEdit = this.reposCodigos;
            this.colCodigoAm.FieldName = "CodigoAm";
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
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 4;
            this.colValor.Width = 192;
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
            // reposValortxt
            // 
            this.reposValortxt.AutoHeight = false;
            this.reposValortxt.Mask.EditMask = "[^\']*";
            this.reposValortxt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.reposValortxt.Mask.UseMaskAsDisplayFormat = true;
            this.reposValortxt.MaxLength = 35;
            this.reposValortxt.Name = "reposValortxt";
            // 
            // Frm_Otros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 295);
            this.Controls.Add(this.pnlBase);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_Otros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otros Varios";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposCodigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposValortxt)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colIDEncabezado;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit reposMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colBorraRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoos;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoAm;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposCodigos;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposValortxt;
    }
}