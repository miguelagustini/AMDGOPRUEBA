namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    partial class Frm_FacturasDet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FacturasDet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bgridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.banPractica = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFecha = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.reposFecha = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCodPrac = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDesPrac = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFuncion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.banPaciente = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colDocupaci = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNombrepaci = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.banValores = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCantidad = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNeto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIva = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNoGravado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIDRegistro = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIDEncabezado = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIvaporc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.bgwDetalles = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 265);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.LookAndFeel.SkinName = "The Bezier";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.bgridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposFecha});
            this.gridControl.Size = new System.Drawing.Size(727, 182);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgridView});
            // 
            // bgridView
            // 
            this.bgridView.Appearance.BandPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.bgridView.Appearance.OddRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bgridView.Appearance.OddRow.Options.UseBackColor = true;
            this.bgridView.Appearance.Row.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.Row.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.bgridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bgridView.Appearance.SelectedRow.Options.UseFont = true;
            this.bgridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.bgridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.banPractica,
            this.banPaciente,
            this.banValores});
            this.bgridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bgridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colIDRegistro,
            this.colIDEncabezado,
            this.colFecha,
            this.colCodPrac,
            this.colDesPrac,
            this.colDocupaci,
            this.colNombrepaci,
            this.colFuncion,
            this.colCantidad,
            this.colNeto,
            this.colIva,
            this.colNoGravado,
            this.colTotal,
            this.colIvaporc});
            this.bgridView.GridControl = this.gridControl;
            this.bgridView.Name = "bgridView";
            this.bgridView.OptionsBehavior.Editable = false;
            this.bgridView.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.bgridView.OptionsView.ColumnAutoWidth = true;
            // 
            // banPractica
            // 
            this.banPractica.Caption = "Practica";
            this.banPractica.Columns.Add(this.colFecha);
            this.banPractica.Columns.Add(this.colCodPrac);
            this.banPractica.Columns.Add(this.colDesPrac);
            this.banPractica.Columns.Add(this.colFuncion);
            this.banPractica.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("banPractica.ImageOptions.Image")));
            this.banPractica.Name = "banPractica";
            this.banPractica.VisibleIndex = 0;
            this.banPractica.Width = 278;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.ColumnEdit = this.reposFecha;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.Width = 153;
            // 
            // reposFecha
            // 
            this.reposFecha.AutoHeight = false;
            this.reposFecha.Mask.EditMask = "dd/MM/yyyy";
            this.reposFecha.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.reposFecha.Mask.UseMaskAsDisplayFormat = true;
            this.reposFecha.Name = "reposFecha";
            // 
            // colCodPrac
            // 
            this.colCodPrac.Caption = "Código";
            this.colCodPrac.FieldName = "Practica";
            this.colCodPrac.Name = "colCodPrac";
            this.colCodPrac.Visible = true;
            this.colCodPrac.Width = 125;
            // 
            // colDesPrac
            // 
            this.colDesPrac.Caption = "Descripción";
            this.colDesPrac.FieldName = "PracticaNom";
            this.colDesPrac.Name = "colDesPrac";
            this.colDesPrac.RowIndex = 1;
            this.colDesPrac.Visible = true;
            this.colDesPrac.Width = 226;
            // 
            // colFuncion
            // 
            this.colFuncion.AppearanceCell.Options.UseTextOptions = true;
            this.colFuncion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFuncion.AppearanceHeader.Options.UseTextOptions = true;
            this.colFuncion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFuncion.Caption = "Func.";
            this.colFuncion.FieldName = "Funcion";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.RowIndex = 1;
            this.colFuncion.Visible = true;
            this.colFuncion.Width = 52;
            // 
            // banPaciente
            // 
            this.banPaciente.Caption = "Paciente";
            this.banPaciente.Columns.Add(this.colDocupaci);
            this.banPaciente.Columns.Add(this.colNombrepaci);
            this.banPaciente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("banPaciente.ImageOptions.Image")));
            this.banPaciente.Name = "banPaciente";
            this.banPaciente.VisibleIndex = 1;
            this.banPaciente.Width = 355;
            // 
            // colDocupaci
            // 
            this.colDocupaci.Caption = "Documento";
            this.colDocupaci.FieldName = "DocuPaci";
            this.colDocupaci.Name = "colDocupaci";
            this.colDocupaci.Visible = true;
            this.colDocupaci.Width = 150;
            // 
            // colNombrepaci
            // 
            this.colNombrepaci.Caption = "Nombre";
            this.colNombrepaci.FieldName = "NombrePaci";
            this.colNombrepaci.Name = "colNombrepaci";
            this.colNombrepaci.Visible = true;
            this.colNombrepaci.Width = 205;
            // 
            // banValores
            // 
            this.banValores.AppearanceHeader.Options.UseTextOptions = true;
            this.banValores.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.banValores.Caption = "Valores";
            this.banValores.Columns.Add(this.colCantidad);
            this.banValores.Columns.Add(this.colNeto);
            this.banValores.Columns.Add(this.colIva);
            this.banValores.Columns.Add(this.colNoGravado);
            this.banValores.Columns.Add(this.colTotal);
            this.banValores.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("banValores.ImageOptions.Image")));
            this.banValores.Name = "banValores";
            this.banValores.VisibleIndex = 2;
            this.banValores.Width = 430;
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
            this.colCantidad.Width = 95;
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
            this.colNeto.Width = 87;
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
            this.colIva.Width = 65;
            // 
            // colNoGravado
            // 
            this.colNoGravado.AppearanceCell.Options.UseTextOptions = true;
            this.colNoGravado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNoGravado.AppearanceHeader.Options.UseTextOptions = true;
            this.colNoGravado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNoGravado.Caption = "No Gravado";
            this.colNoGravado.FieldName = "NoGravado";
            this.colNoGravado.Name = "colNoGravado";
            this.colNoGravado.Visible = true;
            this.colNoGravado.Width = 95;
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
            this.colTotal.Width = 88;
            // 
            // colIDRegistro
            // 
            this.colIDRegistro.Caption = "ID_Registro";
            this.colIDRegistro.FieldName = "IDRegistro";
            this.colIDRegistro.Name = "colIDRegistro";
            this.colIDRegistro.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDRegistro.Visible = true;
            // 
            // colIDEncabezado
            // 
            this.colIDEncabezado.Caption = "ID_Encabezado";
            this.colIDEncabezado.FieldName = "IDEncabezado";
            this.colIDEncabezado.Name = "colIDEncabezado";
            this.colIDEncabezado.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDEncabezado.Visible = true;
            // 
            // colIvaporc
            // 
            this.colIvaporc.Caption = "Iva Porc";
            this.colIvaporc.FieldName = "IvaPorc";
            this.colIvaporc.Name = "colIvaporc";
            this.colIvaporc.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.Appearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseBackColor = true;
            this.btnAceptar.Appearance.Options.UseBorderColor = true;
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.AppearanceHovered.BackColor = System.Drawing.Color.Silver;
            this.btnAceptar.AppearanceHovered.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseFont = true;
            this.btnAceptar.AppearancePressed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.AppearancePressed.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.AppearancePressed.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.AppearancePressed.Options.UseBackColor = true;
            this.btnAceptar.AppearancePressed.Options.UseBorderColor = true;
            this.btnAceptar.AppearancePressed.Options.UseFont = true;
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(584, 191);
            this.btnAceptar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnAceptar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(146, 71);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Generar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // bgwDetalles
            // 
            this.bgwDetalles.WorkerSupportsCancellation = true;
            this.bgwDetalles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDetalles_DoWork);
            this.bgwDetalles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDetalles_RunWorkerCompleted);
            // 
            // Frm_FacturasDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 265);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Frm_FacturasDet";
            this.Text = "Detalles";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposFecha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private System.ComponentModel.BackgroundWorker bgwDetalles;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView bgridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDRegistro;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDEncabezado;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFecha;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodPrac;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDesPrac;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDocupaci;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNombrepaci;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFuncion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNeto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIva;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCantidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposFecha;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIvaporc;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand banPractica;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand banPaciente;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand banValores;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoGravado;
    }
}