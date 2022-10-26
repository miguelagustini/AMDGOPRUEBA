namespace AMDGOINT.Formularios.Informes
{
    partial class Xrpt_Memo
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xrpt_Memo));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.HideCoseguro = new DevExpress.XtraReports.Parameters.Parameter();
            this.HideCopago = new DevExpress.XtraReports.Parameters.Parameter();
            this.GroupHeaderAgrupador = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeaderPlanes = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GrupoSeleccion = new DevExpress.XtraReports.Parameters.Parameter();
            this.FechaNeg = new DevExpress.XtraReports.Parameters.Parameter();
            this.subReportDiscusion = new DevExpress.XtraReports.UI.XRSubreport();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 12F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subReportDiscusion});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            // 
            // HideCoseguro
            // 
            this.HideCoseguro.Description = "OcultaCoseguro";
            this.HideCoseguro.Name = "HideCoseguro";
            this.HideCoseguro.Type = typeof(bool);
            this.HideCoseguro.ValueInfo = "False";
            this.HideCoseguro.Visible = false;
            // 
            // HideCopago
            // 
            this.HideCopago.Description = "Oculta el Copago";
            this.HideCopago.Name = "HideCopago";
            this.HideCopago.Type = typeof(bool);
            this.HideCopago.ValueInfo = "False";
            this.HideCopago.Visible = false;
            // 
            // GroupHeaderAgrupador
            // 
            this.GroupHeaderAgrupador.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.GroupHeaderAgrupador.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AgrupadorCodigo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderAgrupador.HeightF = 134.5834F;
            this.GroupHeaderAgrupador.Level = 1;
            this.GroupHeaderAgrupador.Name = "GroupHeaderAgrupador";
            this.GroupHeaderAgrupador.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry;
            this.GroupHeaderAgrupador.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeaderAgrupador_BeforePrint);
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(141)))), ((int)(((byte)(34)))));
            this.xrTable1.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow5,
            this.xrTableRow7});
            this.xrTable1.SizeF = new System.Drawing.SizeF(722.0001F, 134.5834F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.BackColor = System.Drawing.Color.OliveDrab;
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBackColor = false;
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.Weight = 1.49851393002747D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell1.CanGrow = false;
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox2});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 1.0433666247155802D;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.xrPictureBox2.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPictureBox2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox2.ImageSource"));
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(112.393F, 77.02782F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.xrPictureBox2.StylePriority.UseBackColor = false;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell2.Font = new System.Drawing.Font("Tw Cen MT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseForeColor = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Asociación Médica del Departamento General Obligado";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 5.6591057642428932D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.BackColor = System.Drawing.Color.Transparent;
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell15,
            this.xrTableCell5});
            this.xrTableRow5.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.StylePriority.UseBackColor = false;
            this.xrTableRow5.StylePriority.UseFont = false;
            this.xrTableRow5.Weight = 0.548500391582267D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Prestataria:";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell3.Weight = 2.613094397716019D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AgrupadorCodigoNombre]")});
            this.xrTableCell15.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell15.Weight = 10.020784765939503D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Cuit]")});
            this.xrTableCell5.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell5.Weight = 4.1523488645175384D;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.BackColor = System.Drawing.Color.Transparent;
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22,
            this.xrTableCell24,
            this.xrTableCell25});
            this.xrTableRow7.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.StylePriority.UseBackColor = false;
            this.xrTableRow7.StylePriority.UseFont = false;
            this.xrTableRow7.Weight = 0.57119704764224466D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell22.CanGrow = false;
            this.xrTableCell22.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "Códigos";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell22.Weight = 2.1615076439634624D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell24.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CodigosDescripciones]")});
            this.xrTableCell24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell24.Multiline = true;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell24.Weight = 8.2890188857051932D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell25.CanGrow = false;
            this.xrTableCell25.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?FechaNeg")});
            this.xrTableCell25.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell25.ForeColor = System.Drawing.Color.Olive;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseForeColor = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell25.TextFormatString = "{0:MMMM-yyyy}";
            this.xrTableCell25.Weight = 3.4347513695330103D;
            // 
            // GroupHeaderPlanes
            // 
            this.GroupHeaderPlanes.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeaderPlanes.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("PlanCodigo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderPlanes.HeightF = 134.5834F;
            this.GroupHeaderPlanes.Name = "GroupHeaderPlanes";
            this.GroupHeaderPlanes.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry;
            this.GroupHeaderPlanes.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeaderPlanes_BeforePrint);
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(141)))), ((int)(((byte)(34)))));
            this.xrTable2.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow3,
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(722.0001F, 134.5834F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.BackColor = System.Drawing.Color.OliveDrab;
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell6});
            this.xrTableRow2.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBackColor = false;
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.Weight = 1.49851393002747D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell4.CanGrow = false;
            this.xrTableCell4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1});
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 1.0433666247155802D;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(112.393F, 77.02782F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.xrPictureBox1.StylePriority.UseBackColor = false;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell6.Font = new System.Drawing.Font("Tw Cen MT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseForeColor = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Asociación Médica del Departamento General Obligado";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 5.6591057642428932D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.BackColor = System.Drawing.Color.Transparent;
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow3.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.StylePriority.UseBackColor = false;
            this.xrTableRow3.StylePriority.UseFont = false;
            this.xrTableRow3.Weight = 0.548500391582267D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell7.CanGrow = false;
            this.xrTableCell7.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Prestataria:";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell7.Weight = 2.613094397716019D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NombreLegal]")});
            this.xrTableCell8.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell8.Weight = 10.020784765939503D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Cuit]")});
            this.xrTableCell9.Font = new System.Drawing.Font("Tw Cen MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell9.Weight = 4.1523488645175384D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.BackColor = System.Drawing.Color.Transparent;
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
            this.xrTableRow4.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.StylePriority.UseBackColor = false;
            this.xrTableRow4.StylePriority.UseFont = false;
            this.xrTableRow4.Weight = 0.57119704764224466D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell10.CanGrow = false;
            this.xrTableCell10.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell10.Weight = 2.1615076439634624D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PlanCodigoNombre]")});
            this.xrTableCell11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell11.Weight = 8.2890188857051932D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell12.CanGrow = false;
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?FechaNeg")});
            this.xrTableCell12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell12.ForeColor = System.Drawing.Color.Olive;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UseForeColor = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell12.TextFormatString = "{0:MMMM-yyyy}";
            this.xrTableCell12.Weight = 3.4347513695330103D;
            // 
            // GrupoSeleccion
            // 
            this.GrupoSeleccion.Description = "Determina como se imprimirá el reporte (grupo o plan)";
            this.GrupoSeleccion.Name = "GrupoSeleccion";
            this.GrupoSeleccion.Type = typeof(bool);
            this.GrupoSeleccion.ValueInfo = "False";
            this.GrupoSeleccion.Visible = false;
            // 
            // FechaNeg
            // 
            this.FechaNeg.Description = "Fecha de Negociacion";
            this.FechaNeg.Name = "FechaNeg";
            this.FechaNeg.Type = typeof(System.DateTime);
            this.FechaNeg.ValueInfo = "2021-12-16";
            this.FechaNeg.Visible = false;
            // 
            // subReportDiscusion
            // 
            this.subReportDiscusion.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.subReportDiscusion.Name = "subReportDiscusion";
            this.subReportDiscusion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("HideCoseguro", this.HideCoseguro));
            this.subReportDiscusion.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("HideCopago", this.HideCopago));
            this.subReportDiscusion.ReportSource = new AMDGOINT.Formularios.Informes.Xrpt_Negociacion();
            this.subReportDiscusion.SizeF = new System.Drawing.SizeF(722.0001F, 23F);
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(AMDGOINT.Formularios.Aranceles.Prestadoras);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Xrpt_Memo
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeaderAgrupador,
            this.GroupHeaderPlanes});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(45, 80, 12, 100);
            this.PageHeight = 1400;
            this.PaperKind = System.Drawing.Printing.PaperKind.Legal;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.GrupoSeleccion,
            this.FechaNeg,
            this.HideCoseguro,
            this.HideCopago});
            this.Version = "19.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Xrpt_Memo_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderAgrupador;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderPlanes;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.Parameters.Parameter GrupoSeleccion;
        private DevExpress.XtraReports.UI.XRSubreport subReportDiscusion;
        private DevExpress.XtraReports.Parameters.Parameter FechaNeg;
        private DevExpress.XtraReports.Parameters.Parameter HideCoseguro;
        private DevExpress.XtraReports.Parameters.Parameter HideCopago;
    }
}
