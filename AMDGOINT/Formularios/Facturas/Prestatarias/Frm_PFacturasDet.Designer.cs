namespace AMDGOINT.Formularios.Facturas.Prestatarias
{
    partial class Frm_PFacturasDet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PFacturasDet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCodprofesional = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProfesional = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCondIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPeriodo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPaciente = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNrodocumento = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCantidad = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNeto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGastos = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHonorarios = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIDRegistro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIDEncabezado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPuntero = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colOrigen = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgwDetalles = new System.ComponentModel.BackgroundWorker();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnExel = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.54864F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.45136F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 243);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 2);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.bgridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(715, 206);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgridView});
            // 
            // bgridView
            // 
            this.bgridView.Appearance.BandPanel.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgridView.Appearance.BandPanel.Options.UseFont = true;
            this.bgridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedCell.Options.UseFont = true;
            this.bgridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bgridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.FocusedRow.Options.UseFont = true;
            this.bgridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bgridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.bgridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bgridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.bgridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.bgridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bgridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.Row.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.SelectedRow.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.bgridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.bgridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colIDRegistro,
            this.colIDEncabezado,
            this.colPeriodo,
            this.colDescripcion,
            this.colNrodocumento,
            this.colPaciente,
            this.colCantidad,
            this.colNeto,
            this.colGastos,
            this.colHonorarios,
            this.colIva,
            this.colTotal,
            this.colPuntero,
            this.colOrigen,
            this.colCodprofesional,
            this.colProfesional,
            this.colCondIva});
            this.bgridView.GridControl = this.gridControl;
            this.bgridView.Name = "bgridView";
            this.bgridView.OptionsBehavior.Editable = false;
            this.bgridView.OptionsCustomization.AllowBandMoving = false;
            this.bgridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.bgridView.OptionsMenu.ShowConditionalFormattingItem = true;
            this.bgridView.OptionsPrint.EnableAppearanceOddRow = true;
            this.bgridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.bgridView.OptionsView.ColumnAutoWidth = true;
            this.bgridView.OptionsView.EnableAppearanceEvenRow = true;
            this.bgridView.OptionsView.ShowFooter = true;
            this.bgridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.bgridView_PopupMenuShowing);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Profesionales";
            this.gridBand1.Columns.Add(this.colCodprofesional);
            this.gridBand1.Columns.Add(this.colProfesional);
            this.gridBand1.Columns.Add(this.colCondIva);
            this.gridBand1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand1.ImageOptions.Image")));
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 323;
            // 
            // colCodprofesional
            // 
            this.colCodprofesional.Caption = "Código";
            this.colCodprofesional.FieldName = "CodProfesional";
            this.colCodprofesional.Name = "colCodprofesional";
            this.colCodprofesional.Visible = true;
            this.colCodprofesional.Width = 131;
            // 
            // colProfesional
            // 
            this.colProfesional.Caption = "Profesional";
            this.colProfesional.FieldName = "Profesional";
            this.colProfesional.Name = "colProfesional";
            this.colProfesional.Visible = true;
            this.colProfesional.Width = 108;
            // 
            // colCondIva
            // 
            this.colCondIva.Caption = "Condición";
            this.colCondIva.FieldName = "CondIva";
            this.colCondIva.Name = "colCondIva";
            this.colCondIva.Visible = true;
            this.colCondIva.Width = 84;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Detalles";
            this.gridBand2.Columns.Add(this.colPeriodo);
            this.gridBand2.Columns.Add(this.colDescripcion);
            this.gridBand2.Columns.Add(this.colPaciente);
            this.gridBand2.Columns.Add(this.colNrodocumento);
            this.gridBand2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand2.ImageOptions.Image")));
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.AllowMove = false;
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 325;
            // 
            // colPeriodo
            // 
            this.colPeriodo.Caption = "Período";
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Visible = true;
            this.colPeriodo.Width = 79;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.Width = 89;
            // 
            // colPaciente
            // 
            this.colPaciente.Caption = "Paciente";
            this.colPaciente.FieldName = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.Visible = true;
            this.colPaciente.Width = 79;
            // 
            // colNrodocumento
            // 
            this.colNrodocumento.Caption = "Documento";
            this.colNrodocumento.FieldName = "NroDocumento";
            this.colNrodocumento.Name = "colNrodocumento";
            this.colNrodocumento.Visible = true;
            this.colNrodocumento.Width = 78;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridBand3.Caption = "Importes";
            this.gridBand3.Columns.Add(this.colCantidad);
            this.gridBand3.Columns.Add(this.colNeto);
            this.gridBand3.Columns.Add(this.colGastos);
            this.gridBand3.Columns.Add(this.colHonorarios);
            this.gridBand3.Columns.Add(this.colIva);
            this.gridBand3.Columns.Add(this.colTotal);
            this.gridBand3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gridBand3.ImageOptions.Image")));
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.OptionsBand.AllowMove = false;
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 417;
            // 
            // colCantidad
            // 
            this.colCantidad.AppearanceCell.Options.UseTextOptions = true;
            this.colCantidad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.Width = 78;
            // 
            // colNeto
            // 
            this.colNeto.AppearanceCell.Options.UseTextOptions = true;
            this.colNeto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNeto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNeto.Caption = "Neto";
            this.colNeto.FieldName = "Neto";
            this.colNeto.Name = "colNeto";
            this.colNeto.Visible = true;
            this.colNeto.Width = 62;
            // 
            // colGastos
            // 
            this.colGastos.AppearanceCell.Options.UseTextOptions = true;
            this.colGastos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colGastos.AppearanceHeader.Options.UseTextOptions = true;
            this.colGastos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colGastos.Caption = "Gastos";
            this.colGastos.FieldName = "Gastos";
            this.colGastos.Name = "colGastos";
            this.colGastos.Visible = true;
            this.colGastos.Width = 70;
            // 
            // colHonorarios
            // 
            this.colHonorarios.AppearanceCell.Options.UseTextOptions = true;
            this.colHonorarios.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHonorarios.AppearanceHeader.Options.UseTextOptions = true;
            this.colHonorarios.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHonorarios.Caption = "Honorarios";
            this.colHonorarios.FieldName = "Honorarios";
            this.colHonorarios.Name = "colHonorarios";
            this.colHonorarios.Visible = true;
            this.colHonorarios.Width = 86;
            // 
            // colIva
            // 
            this.colIva.AppearanceCell.Options.UseTextOptions = true;
            this.colIva.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.AppearanceHeader.Options.UseTextOptions = true;
            this.colIva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIva.Caption = "Iva";
            this.colIva.FieldName = "Iva";
            this.colIva.Name = "colIva";
            this.colIva.Visible = true;
            this.colIva.Width = 68;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.Caption = "Total";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.Width = 53;
            // 
            // colIDRegistro
            // 
            this.colIDRegistro.Caption = "IDRegistro";
            this.colIDRegistro.FieldName = "IDRegistro";
            this.colIDRegistro.Name = "colIDRegistro";
            this.colIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDRegistro.Visible = true;
            // 
            // colIDEncabezado
            // 
            this.colIDEncabezado.Caption = "IDEncabezado";
            this.colIDEncabezado.FieldName = "IDEncabezado";
            this.colIDEncabezado.Name = "colIDEncabezado";
            this.colIDEncabezado.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDEncabezado.Visible = true;
            // 
            // colPuntero
            // 
            this.colPuntero.Caption = "Puntero";
            this.colPuntero.FieldName = "Puntero";
            this.colPuntero.Name = "colPuntero";
            this.colPuntero.OptionsColumn.ShowInCustomizationForm = false;
            this.colPuntero.Visible = true;
            // 
            // colOrigen
            // 
            this.colOrigen.Caption = "Origen";
            this.colOrigen.FieldName = "Origen";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.OptionsColumn.ShowInCustomizationForm = false;
            this.colOrigen.Visible = true;
            // 
            // bgwDetalles
            // 
            this.bgwDetalles.WorkerSupportsCancellation = true;
            this.bgwDetalles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDetalles_DoWork);
            this.bgwDetalles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDetalles_RunWorkerCompleted);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExel)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // btnExel
            // 
            this.btnExel.Caption = "Exportar a Exel";
            this.btnExel.Id = 0;
            this.btnExel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExel.ImageOptions.Image")));
            this.btnExel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExel.ImageOptions.LargeImage")));
            this.btnExel.Name = "btnExel";
            this.btnExel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExel_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExel});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(721, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 243);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(721, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 243);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(721, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 243);
            // 
            // Frm_PFacturasDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 243);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimizeBox = false;
            this.Name = "Frm_PFacturasDet";
            this.Text = "Detalles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_PFacturasDet_FormClosing);
            this.Load += new System.EventHandler(this.Frm_PFacturasDet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bgridView;
        private System.ComponentModel.BackgroundWorker bgwDetalles;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDRegistro;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDEncabezado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPeriodo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescripcion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNrodocumento;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPaciente;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCantidad;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNeto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGastos;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHonorarios;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIva;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPuntero;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colOrigen;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodprofesional;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProfesional;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCondIva;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem btnExel;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}