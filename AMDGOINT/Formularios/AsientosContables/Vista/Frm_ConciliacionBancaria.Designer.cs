namespace AMDGOINT.Formularios.AsientosContables.Vista
{
    partial class Frm_ConciliacionBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConciliacionBancaria));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datFechaExtracto = new DevExpress.XtraEditors.DateEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaAsiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAsientoNro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaseNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposNumeros = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colImporteHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConciliado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reposConciliado = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.bgwBusqregistros = new System.ComponentModel.BackgroundWorker();
            this.bgwGuardar = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaExtracto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaExtracto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposConciliado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.datFechaExtracto, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAplicar, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.663366F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.33663F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // datFechaExtracto
            // 
            this.datFechaExtracto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.datFechaExtracto.EditValue = null;
            this.datFechaExtracto.Location = new System.Drawing.Point(3, 5);
            this.datFechaExtracto.Name = "datFechaExtracto";
            this.datFechaExtracto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFechaExtracto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFechaExtracto.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFechaExtracto.Properties.NullText = "Fecha de extracto...";
            this.datFechaExtracto.Size = new System.Drawing.Size(154, 24);
            this.datFechaExtracto.StyleController = this.styleText;
            this.datFechaExtracto.TabIndex = 17;
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
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(201, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(22, 29);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 38);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposDate,
            this.reposNumeros,
            this.reposConciliado});
            this.gridControl.Size = new System.Drawing.Size(1079, 363);
            this.gridControl.TabIndex = 19;
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
            this.colConciliado,
            this.colFechaAsiento,
            this.colCuenta,
            this.colSubCuenta,
            this.colAsientoNro,
            this.colPaseNumero,
            this.colDescripcion,
            this.colImporteDebe,
            this.colImporteHaber});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_RowCellClick);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colFechaAsiento
            // 
            this.colFechaAsiento.Caption = "Fecha";
            this.colFechaAsiento.ColumnEdit = this.reposDate;
            this.colFechaAsiento.FieldName = "AsientoFecha";
            this.colFechaAsiento.Name = "colFechaAsiento";
            this.colFechaAsiento.Visible = true;
            this.colFechaAsiento.VisibleIndex = 1;
            this.colFechaAsiento.Width = 104;
            // 
            // reposDate
            // 
            this.reposDate.AutoHeight = false;
            this.reposDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reposDate.Mask.EditMask = "dd-MM-yyyy";
            this.reposDate.Mask.UseMaskAsDisplayFormat = true;
            this.reposDate.Name = "reposDate";
            // 
            // colCuenta
            // 
            this.colCuenta.Caption = "Cuenta";
            this.colCuenta.FieldName = "PlanCuentaCompleto";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.Visible = true;
            this.colCuenta.VisibleIndex = 2;
            this.colCuenta.Width = 171;
            // 
            // colSubCuenta
            // 
            this.colSubCuenta.Caption = "Sub Cuenta";
            this.colSubCuenta.FieldName = "PlanSubCuentaCompleto";
            this.colSubCuenta.Name = "colSubCuenta";
            this.colSubCuenta.Visible = true;
            this.colSubCuenta.VisibleIndex = 3;
            this.colSubCuenta.Width = 171;
            // 
            // colAsientoNro
            // 
            this.colAsientoNro.Caption = "Asiento";
            this.colAsientoNro.FieldName = "AsientoNumero";
            this.colAsientoNro.Name = "colAsientoNro";
            this.colAsientoNro.Visible = true;
            this.colAsientoNro.VisibleIndex = 4;
            // 
            // colPaseNumero
            // 
            this.colPaseNumero.Caption = "Pase";
            this.colPaseNumero.FieldName = "PaseNumero";
            this.colPaseNumero.Name = "colPaseNumero";
            this.colPaseNumero.Visible = true;
            this.colPaseNumero.VisibleIndex = 5;
            this.colPaseNumero.Width = 56;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 6;
            this.colDescripcion.Width = 238;
            // 
            // colImporteDebe
            // 
            this.colImporteDebe.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporteDebe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporteDebe.Caption = "Debe";
            this.colImporteDebe.ColumnEdit = this.reposNumeros;
            this.colImporteDebe.FieldName = "ImporteDebe";
            this.colImporteDebe.Name = "colImporteDebe";
            this.colImporteDebe.Visible = true;
            this.colImporteDebe.VisibleIndex = 7;
            this.colImporteDebe.Width = 238;
            // 
            // reposNumeros
            // 
            this.reposNumeros.AutoHeight = false;
            this.reposNumeros.Mask.EditMask = "N2";
            this.reposNumeros.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposNumeros.Mask.UseMaskAsDisplayFormat = true;
            this.reposNumeros.Name = "reposNumeros";
            // 
            // colImporteHaber
            // 
            this.colImporteHaber.AppearanceHeader.Options.UseTextOptions = true;
            this.colImporteHaber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colImporteHaber.Caption = "Haber";
            this.colImporteHaber.ColumnEdit = this.reposNumeros;
            this.colImporteHaber.FieldName = "ImporteHaber";
            this.colImporteHaber.Name = "colImporteHaber";
            this.colImporteHaber.Visible = true;
            this.colImporteHaber.VisibleIndex = 8;
            this.colImporteHaber.Width = 259;
            // 
            // colConciliado
            // 
            this.colConciliado.AppearanceHeader.Options.UseTextOptions = true;
            this.colConciliado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConciliado.Caption = "...";
            this.colConciliado.ColumnEdit = this.reposConciliado;
            this.colConciliado.FieldName = "Conciliado";
            this.colConciliado.Name = "colConciliado";
            this.colConciliado.Visible = true;
            this.colConciliado.VisibleIndex = 0;
            this.colConciliado.Width = 35;
            // 
            // reposConciliado
            // 
            this.reposConciliado.AutoHeight = false;
            this.reposConciliado.Caption = "";
            this.reposConciliado.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Custom;
            this.reposConciliado.DisplayValueChecked = "Conciliado";
            this.reposConciliado.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.reposConciliado.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("reposConciliado.ImageOptions.ImageChecked")));
            this.reposConciliado.Name = "reposConciliado";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAplicar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.Image")));
            this.btnAplicar.Location = new System.Drawing.Point(931, 407);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(151, 54);
            this.btnAplicar.TabIndex = 20;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // styleLabels
            // 
            this.styleLabels.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleLabels.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.styleLabels.Appearance.Options.UseFont = true;
            this.styleLabels.Appearance.Options.UseForeColor = true;
            this.styleLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.styleLabels.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.styleLabels.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // bgwBusqregistros
            // 
            this.bgwBusqregistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBusqregistros_DoWork);
            this.bgwBusqregistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBusqregistros_RunWorkerCompleted);
            // 
            // bgwGuardar
            // 
            this.bgwGuardar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGuardar_DoWork);
            this.bgwGuardar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGuardar_RunWorkerCompleted);
            // 
            // Frm_ConciliacionBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_ConciliacionBancaria";
            this.Text = "Conciliación Bancaria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Frm_ConciliacionBancaria_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datFechaExtracto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFechaExtracto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposNumeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposConciliado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.DateEdit datFechaExtracto;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private System.ComponentModel.BackgroundWorker bgwBusqregistros;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaAsiento;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit reposDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colAsientoNro;
        private DevExpress.XtraGrid.Columns.GridColumn colPaseNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteDebe;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposNumeros;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteHaber;
        private DevExpress.XtraGrid.Columns.GridColumn colConciliado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit reposConciliado;
        private System.ComponentModel.BackgroundWorker bgwGuardar;
    }
}