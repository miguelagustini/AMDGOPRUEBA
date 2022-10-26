namespace AMDGOINT.Formularios.Prestatarias
{
    partial class Frm_PrAgrupador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrAgrupador));
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDPrestataria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestatipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tmrEscucha = new System.Windows.Forms.Timer(this.components);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnAgregadetalle = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditardetalle = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 320);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.tableLayoutPanel1.SetRowSpan(this.gridControl, 2);
            this.gridControl.Size = new System.Drawing.Size(494, 314);
            this.gridControl.TabIndex = 0;
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
            this.colIDRegistro,
            this.colIDPrestataria,
            this.colCodigo,
            this.colDescripcion,
            this.colPrestatipo});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_PopupMenuShowing);
            this.gridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView_FocusedRowObjectChanged);
            // 
            // colIDRegistro
            // 
            this.colIDRegistro.Caption = "ID_Registro";
            this.colIDRegistro.FieldName = "ID_Registro";
            this.colIDRegistro.Name = "colIDRegistro";
            this.colIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colIDPrestataria
            // 
            this.colIDPrestataria.Caption = "ID Prestataria";
            this.colIDPrestataria.FieldName = "ID_Prestataria";
            this.colIDPrestataria.Name = "colIDPrestataria";
            this.colIDPrestataria.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
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
            // colPrestatipo
            // 
            this.colPrestatipo.Caption = "Tipo Prestataria";
            this.colPrestatipo.FieldName = "PrestaTipo";
            this.colPrestatipo.Name = "colPrestatipo";
            this.colPrestatipo.Visible = true;
            this.colPrestatipo.VisibleIndex = 2;
            // 
            // tmrEscucha
            // 
            this.tmrEscucha.Tick += new System.EventHandler(this.tmrEscucha_Tick);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHeaderItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAgregadetalle),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditardetalle)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.popupMenu_BeforePopup);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Opciones";
            this.barHeaderItem1.Id = 0;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // btnAgregadetalle
            // 
            this.btnAgregadetalle.Caption = "Agregar Agrupador";
            this.btnAgregadetalle.Id = 1;
            this.btnAgregadetalle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregadetalle.ImageOptions.Image")));
            this.btnAgregadetalle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregadetalle.ImageOptions.LargeImage")));
            this.btnAgregadetalle.Name = "btnAgregadetalle";
            this.btnAgregadetalle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregadetalle_ItemClick);
            // 
            // btnEditardetalle
            // 
            this.btnEditardetalle.Caption = "Editar Agrupador";
            this.btnEditardetalle.Id = 2;
            this.btnEditardetalle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditardetalle.ImageOptions.Image")));
            this.btnEditardetalle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEditardetalle.ImageOptions.LargeImage")));
            this.btnEditardetalle.Name = "btnEditardetalle";
            this.btnEditardetalle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditardetalle_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barHeaderItem1,
            this.btnAgregadetalle,
            this.btnEditardetalle});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(500, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 320);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(500, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 320);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(500, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 320);
            // 
            // Frm_PrAgrupador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_PrAgrupador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agrupadores";
            this.Shown += new System.EventHandler(this.Frm_PrAgrupador_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colIDRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colIDPrestataria;
        private System.Windows.Forms.Timer tmrEscucha;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarButtonItem btnAgregadetalle;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnEditardetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestatipo;
    }
}