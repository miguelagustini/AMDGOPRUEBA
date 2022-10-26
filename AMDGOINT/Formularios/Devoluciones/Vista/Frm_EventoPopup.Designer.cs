namespace AMDGOINT.Formularios.Devoluciones.Vista
{
    partial class Frm_EventoPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EventoPopup));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.datFecha = new DevExpress.XtraEditors.DateEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.cmbEvento = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEvento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.81967F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.18033F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.datFecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbEvento, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtObservacion, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 228);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(428, 169);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 56);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Finalizar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 18);
            this.labelControl1.StyleController = this.styleLabels;
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Fecha";
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
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(3, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(102, 18);
            this.labelControl2.StyleController = this.styleLabels;
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Evento";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(3, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(102, 18);
            this.labelControl3.StyleController = this.styleLabels;
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Observación";
            // 
            // datFecha
            // 
            this.datFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.datFecha.EditValue = null;
            this.datFecha.EnterMoveNextControl = true;
            this.datFecha.Location = new System.Drawing.Point(111, 6);
            this.datFecha.Name = "datFecha";
            this.datFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.datFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFecha.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.datFecha.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datFecha.Size = new System.Drawing.Size(236, 24);
            this.datFecha.StyleController = this.styleText;
            this.datFecha.TabIndex = 0;
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
            // cmbEvento
            // 
            this.cmbEvento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cmbEvento, 2);
            this.cmbEvento.EnterMoveNextControl = true;
            this.cmbEvento.Location = new System.Drawing.Point(111, 42);
            this.cmbEvento.Name = "cmbEvento";
            this.cmbEvento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.cmbEvento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 25, true, true, true, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cmbEvento.Properties.DisplayMember = "Descripcion";
            this.cmbEvento.Properties.NullText = "";
            this.cmbEvento.Properties.PopupView = this.searchLookUpEdit1View;
            this.cmbEvento.Properties.ValueMember = "IDRegistro";
            this.cmbEvento.Size = new System.Drawing.Size(442, 24);
            this.cmbEvento.StyleController = this.styleText;
            this.cmbEvento.TabIndex = 1;
            this.cmbEvento.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbEvento_ButtonPressed);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.searchLookUpEdit1View.Appearance.EvenRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.FocusedCell.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.searchLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // txtObservacion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtObservacion, 2);
            this.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservacion.EnterMoveNextControl = true;
            this.txtObservacion.Location = new System.Drawing.Point(111, 75);
            this.txtObservacion.Name = "txtObservacion";
            this.tableLayoutPanel1.SetRowSpan(this.txtObservacion, 2);
            this.txtObservacion.Size = new System.Drawing.Size(442, 88);
            this.txtObservacion.TabIndex = 2;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Evento";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            // 
            // Frm_EventoPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 228);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.IconOptions.ShowIcon = false;
            this.MinimizeBox = false;
            this.Name = "Frm_EventoPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de evento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Evento_FormClosing);
            this.Shown += new System.EventHandler(this.Frm_DebitosSelector_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEvento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit datFecha;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbEvento;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
    }
}
