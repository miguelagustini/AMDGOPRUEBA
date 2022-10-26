namespace AMDGOINT.Formularios.Aranceles
{
    partial class Frm_Generadordisc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Generadordisc));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodpractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescpractica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupoorden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipovalor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposTipoval = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.colValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposNumero = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTip = new DevExpress.Utils.ToolTipController(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tglNuevaValoriza = new DevExpress.XtraEditors.ToggleSwitch();
            this.cmbValorizacion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.datNegociacion = new DevExpress.XtraEditors.DateEdit();
            this.bgwCargar = new System.ComponentModel.BackgroundWorker();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bgwGeneracion = new System.ComponentModel.BackgroundWorker();
            this.colValordos = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTipoval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglNuevaValoriza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValorizacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNegociacion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNegociacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tableLayoutPanel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 310);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(738, 93);
            this.panelControl1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Controls.Add(this.btnAplicar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(738, 93);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(165)))), ((int)(((byte)(194)))));
            this.btnAplicar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(569, 3);
            this.btnAplicar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnAplicar.Size = new System.Drawing.Size(158, 78);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Finalizar y Generar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(3, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(359, 60);
            this.labelControl4.StyleController = this.styleLabels;
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = resources.GetString("labelControl4.Text");
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(738, 310);
            this.panelControl2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.44715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.79675F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tglNuevaValoriza, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbValorizacion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.datNegociacion, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 310);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 5);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 63);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposNumero,
            this.reposTipoval});
            this.tableLayoutPanel1.SetRowSpan(this.gridControl, 2);
            this.gridControl.Size = new System.Drawing.Size(732, 244);
            this.gridControl.TabIndex = 0;
            this.gridControl.ToolTipController = this.toolTip;
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
            this.colCodpractica,
            this.colDescpractica,
            this.colFuncion,
            this.colGrupoorden,
            this.colGrupo,
            this.colTipovalor,
            this.colValor,
            this.colValordos});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsMenu.EnableGroupRowMenu = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodpractica, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView_CustomDrawGroupRow);
            this.gridView.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView_EditFormPrepared);
            // 
            // colCodpractica
            // 
            this.colCodpractica.Caption = "Código";
            this.colCodpractica.FieldName = "CodigoPractica";
            this.colCodpractica.Name = "colCodpractica";
            this.colCodpractica.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colCodpractica.Visible = true;
            this.colCodpractica.VisibleIndex = 0;
            this.colCodpractica.Width = 132;
            // 
            // colDescpractica
            // 
            this.colDescpractica.Caption = "Práctica";
            this.colDescpractica.FieldName = "DescripcionPractica";
            this.colDescpractica.Name = "colDescpractica";
            this.colDescpractica.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colDescpractica.Visible = true;
            this.colDescpractica.VisibleIndex = 1;
            this.colDescpractica.Width = 132;
            // 
            // colFuncion
            // 
            this.colFuncion.Caption = "Función";
            this.colFuncion.FieldName = "LetraFuncion";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colFuncion.Visible = true;
            this.colFuncion.VisibleIndex = 2;
            this.colFuncion.Width = 72;
            // 
            // colGrupoorden
            // 
            this.colGrupoorden.Caption = "Orden";
            this.colGrupoorden.FieldName = "GrupoOrden";
            this.colGrupoorden.Name = "colGrupoorden";
            this.colGrupoorden.OptionsColumn.AllowEdit = false;
            this.colGrupoorden.OptionsColumn.AllowFocus = false;
            this.colGrupoorden.OptionsColumn.ShowInCustomizationForm = false;
            this.colGrupoorden.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colGrupo
            // 
            this.colGrupo.Caption = "Grupo";
            this.colGrupo.FieldName = "GrupoPractica";
            this.colGrupo.FieldNameSortGroup = "GrupoOrden";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupo.Visible = true;
            this.colGrupo.VisibleIndex = 3;
            this.colGrupo.Width = 151;
            // 
            // colTipovalor
            // 
            this.colTipovalor.AppearanceHeader.Options.UseTextOptions = true;
            this.colTipovalor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTipovalor.Caption = "Tipo";
            this.colTipovalor.ColumnEdit = this.reposTipoval;
            this.colTipovalor.FieldName = "TipoValor";
            this.colTipovalor.Name = "colTipovalor";
            this.colTipovalor.Visible = true;
            this.colTipovalor.VisibleIndex = 4;
            this.colTipovalor.Width = 78;
            // 
            // reposTipoval
            // 
            this.reposTipoval.AutoHeight = false;
            this.reposTipoval.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.reposTipoval.Name = "reposTipoval";
            this.reposTipoval.OffText = "%";
            this.reposTipoval.OnText = "$";
            this.reposTipoval.ValueOff = ((byte)(0));
            this.reposTipoval.ValueOn = ((byte)(1));
            // 
            // colValor
            // 
            this.colValor.AppearanceHeader.Options.UseTextOptions = true;
            this.colValor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.Caption = "% Incremento / $ Fijo";
            this.colValor.ColumnEdit = this.reposNumero;
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.Visible = true;
            this.colValor.VisibleIndex = 5;
            this.colValor.Width = 170;
            // 
            // reposNumero
            // 
            this.reposNumero.AutoHeight = false;
            this.reposNumero.Mask.EditMask = "n2";
            this.reposNumero.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumero.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumero.Name = "reposNumero";
            // 
            // toolTip
            // 
            this.toolTip.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTip_GetActiveObjectInfo);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(141, 15);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Valorización Base";
            // 
            // tglNuevaValoriza
            // 
            this.tglNuevaValoriza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tglNuevaValoriza.Location = new System.Drawing.Point(150, 9);
            this.tglNuevaValoriza.Name = "tglNuevaValoriza";
            this.tglNuevaValoriza.Properties.AllowFocused = false;
            this.tglNuevaValoriza.Properties.OffText = "Existente";
            this.tglNuevaValoriza.Properties.OnText = "Nueva";
            this.tglNuevaValoriza.Size = new System.Drawing.Size(141, 18);
            this.tglNuevaValoriza.TabIndex = 4;
            this.tglNuevaValoriza.Toggled += new System.EventHandler(this.tglNuevaValoriza_Toggled);
            // 
            // cmbValorizacion
            // 
            this.cmbValorizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValorizacion.EditValue = 0;
            this.cmbValorizacion.EnterMoveNextControl = true;
            this.cmbValorizacion.Location = new System.Drawing.Point(297, 6);
            this.cmbValorizacion.Name = "cmbValorizacion";
            this.cmbValorizacion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbValorizacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbValorizacion.Properties.DisplayMember = "Fecha";
            this.cmbValorizacion.Properties.NullText = "";
            this.cmbValorizacion.Properties.PopupView = this.gridView1;
            this.cmbValorizacion.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposFecha});
            this.cmbValorizacion.Properties.UseCtrlScroll = true;
            this.cmbValorizacion.Properties.ValueMember = "ID_Registro";
            this.cmbValorizacion.Size = new System.Drawing.Size(141, 24);
            this.cmbValorizacion.StyleController = this.styleText;
            this.cmbValorizacion.TabIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IDRegistro";
            this.gridColumn1.FieldName = "ID_Registro";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.ColumnEdit = this.reposFecha;
            this.gridColumn2.FieldName = "Fecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 220;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.reposFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Observaciones";
            this.gridColumn3.FieldName = "Observaciones";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 728;
            // 
            // styleText
            // 
            this.styleText.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.styleText.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.Appearance.Options.UseBorderColor = true;
            this.styleText.Appearance.Options.UseFont = true;
            this.styleText.AppearanceDisabled.BackColor = System.Drawing.Color.Silver;
            this.styleText.AppearanceDisabled.Options.UseBackColor = true;
            this.styleText.AppearanceFocused.BorderColor = System.Drawing.Color.Goldenrod;
            this.styleText.AppearanceFocused.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleText.AppearanceFocused.Options.UseBorderColor = true;
            this.styleText.AppearanceFocused.Options.UseFont = true;
            this.styleText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tableLayoutPanel1.SetColumnSpan(this.labelControl2, 3);
            this.labelControl2.Location = new System.Drawing.Point(3, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(435, 15);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "F2 Panel de valorización / Enter: editar";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(444, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(107, 15);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Negociación";
            // 
            // datNegociacion
            // 
            this.datNegociacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datNegociacion.EditValue = null;
            this.datNegociacion.EnterMoveNextControl = true;
            this.datNegociacion.Location = new System.Drawing.Point(557, 6);
            this.datNegociacion.Name = "datNegociacion";
            this.datNegociacion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datNegociacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNegociacion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNegociacion.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.datNegociacion.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.datNegociacion.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datNegociacion.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.datNegociacion.Size = new System.Drawing.Size(178, 24);
            this.datNegociacion.StyleController = this.styleText;
            this.datNegociacion.TabIndex = 1;
            // 
            // bgwCargar
            // 
            this.bgwCargar.WorkerSupportsCancellation = true;
            this.bgwCargar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCargar_DoWork);
            this.bgwCargar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCargar_RunWorkerCompleted);
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // popupMenu
            // 
            this.popupMenu.Name = "popupMenu";
            // 
            // bgwGeneracion
            // 
            this.bgwGeneracion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGeneracion_DoWork);
            this.bgwGeneracion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGeneracion_RunWorkerCompleted);
            // 
            // colValordos
            // 
            this.colValordos.AppearanceHeader.Options.UseTextOptions = true;
            this.colValordos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValordos.Caption = "Valor por defecto";
            this.colValordos.ColumnEdit = this.reposNumero;
            this.colValordos.FieldName = "ValorDos";
            this.colValordos.Name = "colValordos";
            this.colValordos.Visible = true;
            this.colValordos.VisibleIndex = 6;
            this.colValordos.Width = 129;
            // 
            // Frm_Generadordisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 403);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Frm_Generadordisc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Memos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Generadordisc_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Generadordisc_Load);
            this.Shown += new System.EventHandler(this.Frm_Generadordisc_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Generadordisc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTipoval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglNuevaValoriza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbValorizacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNegociacion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNegociacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbValorizacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.ToggleSwitch tglNuevaValoriza;
        private System.ComponentModel.BackgroundWorker bgwCargar;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraGrid.Columns.GridColumn colCodpractica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescpractica;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncion;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoorden;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupo;
        private DevExpress.XtraGrid.Columns.GridColumn colValor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumero;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colTipovalor;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch reposTipoval;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.Utils.ToolTipController toolTip;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit datNegociacion;
        private System.ComponentModel.BackgroundWorker bgwGeneracion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn colValordos;
    }
}