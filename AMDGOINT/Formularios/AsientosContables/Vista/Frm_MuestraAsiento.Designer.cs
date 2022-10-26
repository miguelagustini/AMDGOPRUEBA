namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    partial class Frm_MuestraAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MuestraAsiento));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPlanCuenta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPlanSubCuenta = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposImportes = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnQuitarAsiento = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvertirImporte = new DevExpress.XtraBars.BarButtonItem();
            this.btnAgregarAsiento = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanSubCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwRegistros
            // 
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.86159F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.89891F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.2395F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 376);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.simpleButton1, 2);
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(3, 317);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(125, 56);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Incorrecto";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(681, 317);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(132, 56);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Correcto";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 4);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposImportes,
            this.cmbPlanCuenta,
            this.cmbPlanSubCuenta});
            this.gridControl.Size = new System.Drawing.Size(810, 308);
            this.gridControl.TabIndex = 3;
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
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
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
            this.colCuenta,
            this.colSubCuenta,
            this.colDebe,
            this.colHaber});
            gridFormatRule1.Name = "Format0";
            gridFormatRule1.Rule = null;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_CustomDrawFooterCell);
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_InitNewRow);
            this.gridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView_ValidateRow);
            // 
            // colCuenta
            // 
            this.colCuenta.AppearanceCell.Options.UseTextOptions = true;
            this.colCuenta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCuenta.Caption = "Cuenta";
            this.colCuenta.ColumnEdit = this.cmbPlanCuenta;
            this.colCuenta.FieldName = "PlanCuentaID";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.Visible = true;
            this.colCuenta.VisibleIndex = 0;
            // 
            // cmbPlanCuenta
            // 
            this.cmbPlanCuenta.AutoHeight = false;
            this.cmbPlanCuenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlanCuenta.DisplayMember = "DescripcionExtendida";
            this.cmbPlanCuenta.Name = "cmbPlanCuenta";
            this.cmbPlanCuenta.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.cmbPlanCuenta.ValueMember = "IDRegistro";
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.colCodigo,
            this.colDescripcion});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "CodigoCorto";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colSubCuenta
            // 
            this.colSubCuenta.AppearanceCell.Options.UseTextOptions = true;
            this.colSubCuenta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSubCuenta.Caption = "Sub Cuenta";
            this.colSubCuenta.ColumnEdit = this.cmbPlanSubCuenta;
            this.colSubCuenta.FieldName = "PlanSubCuentaID";
            this.colSubCuenta.Name = "colSubCuenta";
            this.colSubCuenta.Visible = true;
            this.colSubCuenta.VisibleIndex = 1;
            // 
            // cmbPlanSubCuenta
            // 
            this.cmbPlanSubCuenta.AutoHeight = false;
            this.cmbPlanSubCuenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlanSubCuenta.DisplayMember = "DescripcionExtendida";
            this.cmbPlanSubCuenta.Name = "cmbPlanSubCuenta";
            this.cmbPlanSubCuenta.PopupView = this.repositoryItemSearchLookUpEdit2View;
            this.cmbPlanSubCuenta.ValueMember = "IDRegistro";
            this.cmbPlanSubCuenta.BeforePopup += new System.EventHandler(this.cmbPlanSubCuenta_BeforePopup);
            // 
            // repositoryItemSearchLookUpEdit2View
            // 
            this.repositoryItemSearchLookUpEdit2View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.repositoryItemSearchLookUpEdit2View.Appearance.EvenRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedCell.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemSearchLookUpEdit2View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.repositoryItemSearchLookUpEdit2View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit2View.Appearance.HeaderPanel.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit2View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit2View.Appearance.Row.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.repositoryItemSearchLookUpEdit2View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.repositoryItemSearchLookUpEdit2View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repositoryItemSearchLookUpEdit2View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.SelectedRow.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit2View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.repositoryItemSearchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.repositoryItemSearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit2View.Name = "repositoryItemSearchLookUpEdit2View";
            this.repositoryItemSearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit2View.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción";
            this.gridColumn2.FieldName = "Descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // colDebe
            // 
            this.colDebe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDebe.Caption = "Debe";
            this.colDebe.ColumnEdit = this.reposImportes;
            this.colDebe.FieldName = "ImporteDebe";
            this.colDebe.Name = "colDebe";
            this.colDebe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteDebe", "{0:N2}")});
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 2;
            // 
            // reposImportes
            // 
            this.reposImportes.AutoHeight = false;
            this.reposImportes.Mask.EditMask = "C2";
            this.reposImportes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposImportes.Mask.UseMaskAsDisplayFormat = true;
            this.reposImportes.Name = "reposImportes";
            // 
            // colHaber
            // 
            this.colHaber.AppearanceHeader.Options.UseTextOptions = true;
            this.colHaber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHaber.Caption = "Haber";
            this.colHaber.ColumnEdit = this.reposImportes;
            this.colHaber.FieldName = "ImporteHaber";
            this.colHaber.Name = "colHaber";
            this.colHaber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteHaber", "{0:N2}")});
            this.colHaber.Visible = true;
            this.colHaber.VisibleIndex = 3;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnQuitarAsiento),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInvertirImporte),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAgregarAsiento)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // btnQuitarAsiento
            // 
            this.btnQuitarAsiento.Caption = "Quitar Asiento";
            this.btnQuitarAsiento.Id = 0;
            this.btnQuitarAsiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarAsiento.ImageOptions.Image")));
            this.btnQuitarAsiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarAsiento.ImageOptions.LargeImage")));
            this.btnQuitarAsiento.Name = "btnQuitarAsiento";
            this.btnQuitarAsiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuitarAsiento_ItemClick);
            // 
            // btnInvertirImporte
            // 
            this.btnInvertirImporte.Caption = "Invertir Importe";
            this.btnInvertirImporte.Id = 1;
            this.btnInvertirImporte.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInvertirImporte.ImageOptions.Image")));
            this.btnInvertirImporte.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInvertirImporte.ImageOptions.LargeImage")));
            this.btnInvertirImporte.Name = "btnInvertirImporte";
            this.btnInvertirImporte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvertirImporte_ItemClick);
            // 
            // btnAgregarAsiento
            // 
            this.btnAgregarAsiento.Caption = "Agregar Asiento";
            this.btnAgregarAsiento.Id = 2;
            this.btnAgregarAsiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarAsiento.ImageOptions.Image")));
            this.btnAgregarAsiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarAsiento.ImageOptions.LargeImage")));
            this.btnAgregarAsiento.Name = "btnAgregarAsiento";
            this.btnAgregarAsiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregarAsiento_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnQuitarAsiento,
            this.btnInvertirImporte,
            this.btnAgregarAsiento});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(816, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 376);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(816, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 376);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(816, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 376);
            // 
            // Frm_MuestraAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 376);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.IconOptions.ShowIcon = false;
            this.MinimizeBox = false;
            this.Name = "Frm_MuestraAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asiento de caja automático";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_RetirosSelector_FormClosing);
            this.Load += new System.EventHandler(this.Frm_RetirosSelector_Load);
            this.Shown += new System.EventHandler(this.Frm_RetirosSelector_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanSubCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposImportes;
        private DevExpress.XtraGrid.Columns.GridColumn colHaber;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbPlanCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cmbPlanSubCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit2View;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnQuitarAsiento;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnInvertirImporte;
        private DevExpress.XtraBars.BarButtonItem btnAgregarAsiento;
    }
}
