namespace AMDGOINT.Formularios.Negociacion.Vista
{
    partial class Frm_Analisis
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
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup1 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Analisis));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions2 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions3 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.colDesPrestataria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colFechaImpacto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colFechaNegociacion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colFuncion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.reposPorcentaje = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDiferenciaPactadoAnterior = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colValor = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCodPrestataria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pvControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.colGrupoPractica = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colGrupoOrden = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCodigoPractica = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDescripcionPractica = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCodigoFuncion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDescripcionFuncion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colValorPactadoAnterior = new DevExpress.XtraPivotGrid.PivotGridField();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockGraficos = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.chart = new DevExpress.XtraCharts.ChartControl();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionContentContainer14 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.cmbPrestadoras = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.styleText = new DevExpress.XtraEditors.StyleController(this.components);
            this.accordionContentContainer15 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.chkDiferenciapactadoporc = new DevExpress.XtraEditors.CheckEdit();
            this.chkValorpactadoanterior = new DevExpress.XtraEditors.CheckEdit();
            this.accordionControlElement15 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement16 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement19 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnExportarxls = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.styleLabels = new DevExpress.XtraEditors.StyleController(this.components);
            this.bgwRegistros = new System.ComponentModel.BackgroundWorker();
            this.ScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.colCodigoOs = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPorcentaje = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPrestataria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.accControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionContentContainer1 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colGrupoPracticaFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer2 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colGrupoOrdenFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer3 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colCodigoPracticaFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer4 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colDescripcionPracticaFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer5 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colCodigoFuncionFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer6 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colDescripcionFuncionFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer7 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colFuncionFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer8 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colValorFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer9 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colCodPrestatariaFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer10 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colDesPrestatariaFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer11 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colValorAnteriorFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer12 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colPorcenDiferenciaFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionContentContainer13 = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.colFechaInpactoFilterUIEditorContainerEdit = new DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement6 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement7 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement8 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement9 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement10 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement11 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement12 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement13 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement14 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement17 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            ((System.ComponentModel.ISupportInitialize)(this.reposPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockGraficos.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            this.dockPanel3.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.accordionControl1.SuspendLayout();
            this.accordionContentContainer14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestadoras.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).BeginInit();
            this.accordionContentContainer15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiferenciapactadoporc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkValorpactadoanterior.Properties)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accControl)).BeginInit();
            this.accControl.SuspendLayout();
            this.accordionContentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colGrupoPracticaFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colGrupoOrdenFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colCodigoPracticaFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colDescripcionPracticaFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colCodigoFuncionFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colDescripcionFuncionFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colFuncionFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colValorFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colCodPrestatariaFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colDesPrestatariaFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colValorAnteriorFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colPorcenDiferenciaFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.accordionContentContainer13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colFechaInpactoFilterUIEditorContainerEdit.Properties)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.hideContainerLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // colDesPrestataria
            // 
            this.colDesPrestataria.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colDesPrestataria.AreaIndex = 0;
            this.colDesPrestataria.Caption = "Prestataria";
            this.colDesPrestataria.FieldName = "Prestataria";
            this.colDesPrestataria.Name = "colDesPrestataria";
            // 
            // colFechaImpacto
            // 
            this.colFechaImpacto.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colFechaImpacto.AreaIndex = 1;
            this.colFechaImpacto.Caption = "Vigencia";
            this.colFechaImpacto.FieldName = "FechaImpacto";
            this.colFechaImpacto.Name = "colFechaImpacto";
            // 
            // colFechaNegociacion
            // 
            this.colFechaNegociacion.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colFechaNegociacion.AreaIndex = 2;
            this.colFechaNegociacion.Caption = "Fecha Negociacion";
            this.colFechaNegociacion.FieldName = "FechaNegociacionpresent";
            this.colFechaNegociacion.Name = "colFechaNegociacion";
            // 
            // colFuncion
            // 
            this.colFuncion.Appearance.Header.Options.UseTextOptions = true;
            this.colFuncion.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFuncion.Appearance.Value.Options.UseTextOptions = true;
            this.colFuncion.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFuncion.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colFuncion.AreaIndex = 3;
            this.colFuncion.Caption = "F";
            this.colFuncion.FieldName = "FuncionLetra";
            this.colFuncion.Name = "colFuncion";
            this.colFuncion.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFuncion.Width = 40;
            // 
            // reposPorcentaje
            // 
            this.reposPorcentaje.AutoHeight = false;
            this.reposPorcentaje.Mask.EditMask = "n2";
            this.reposPorcentaje.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.reposPorcentaje.Mask.UseMaskAsDisplayFormat = true;
            this.reposPorcentaje.Name = "reposPorcentaje";
            // 
            // colDiferenciaPactadoAnterior
            // 
            this.colDiferenciaPactadoAnterior.Appearance.Header.Options.UseTextOptions = true;
            this.colDiferenciaPactadoAnterior.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDiferenciaPactadoAnterior.Appearance.Value.Options.UseTextOptions = true;
            this.colDiferenciaPactadoAnterior.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDiferenciaPactadoAnterior.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colDiferenciaPactadoAnterior.AreaIndex = 2;
            this.colDiferenciaPactadoAnterior.Caption = "Diferencia %";
            this.colDiferenciaPactadoAnterior.FieldName = "DifPactadoPorc";
            this.colDiferenciaPactadoAnterior.Name = "colDiferenciaPactadoAnterior";
            // 
            // colValor
            // 
            this.colValor.Appearance.Header.Options.UseTextOptions = true;
            this.colValor.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.Appearance.Value.Options.UseTextOptions = true;
            this.colValor.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValor.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colValor.AreaIndex = 0;
            this.colValor.Caption = "Valor";
            this.colValor.FieldName = "Valor";
            this.colValor.Name = "colValor";
            // 
            // colCodPrestataria
            // 
            this.colCodPrestataria.AreaIndex = 0;
            this.colCodPrestataria.Caption = "Código";
            this.colCodPrestataria.FieldName = "PrestadoraCodigo";
            this.colCodPrestataria.Name = "colCodPrestataria";
            // 
            // pvControl
            // 
            this.pvControl.Appearance.ColumnHeaderArea.Options.UseTextOptions = true;
            this.pvControl.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pvControl.Appearance.DataHeaderArea.Options.UseTextOptions = true;
            this.pvControl.Appearance.DataHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pvControl.Appearance.FieldHeader.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold);
            this.pvControl.Appearance.FieldHeader.Options.UseFont = true;
            this.pvControl.Appearance.FieldValueTotal.Options.UseTextOptions = true;
            this.pvControl.Appearance.FieldValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pvControl.Appearance.FilterHeaderArea.Options.UseTextOptions = true;
            this.pvControl.Appearance.FilterHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pvControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.colGrupoPractica,
            this.colGrupoOrden,
            this.colCodigoPractica,
            this.colDescripcionPractica,
            this.colCodigoFuncion,
            this.colDescripcionFuncion,
            this.colFuncion,
            this.colValor,
            this.colCodPrestataria,
            this.colDesPrestataria,
            this.colValorPactadoAnterior,
            this.colDiferenciaPactadoAnterior,
            this.colFechaNegociacion,
            this.colFechaImpacto});
            pivotGridGroup1.Fields.Add(this.colDesPrestataria);
            pivotGridGroup1.Fields.Add(this.colFechaImpacto);
            pivotGridGroup1.Fields.Add(this.colFechaNegociacion);
            this.pvControl.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup1});
            this.pvControl.Location = new System.Drawing.Point(0, 0);
            this.pvControl.MenuManager = this.barManager1;
            this.pvControl.Name = "pvControl";
            this.pvControl.OptionsBehavior.ApplyBestFitOnFieldDragging = true;
            this.pvControl.OptionsChartDataSource.MaxAllowedPointCountInSeries = 0;
            this.pvControl.OptionsChartDataSource.MaxAllowedSeriesCount = 0;
            this.pvControl.OptionsCustomization.AllowEdit = false;
            this.pvControl.OptionsLayout.StoreFormatRules = true;
            this.pvControl.OptionsMenu.EnableHeaderAreaMenu = false;
            this.pvControl.OptionsView.FilterSeparatorBarPadding = 0;
            this.pvControl.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pvControl.OptionsView.ShowColumnGrandTotals = false;
            this.pvControl.OptionsView.ShowColumnTotals = false;
            this.pvControl.OptionsView.ShowRowGrandTotals = false;
            this.pvControl.OptionsView.ShowRowTotals = false;
            this.pvControl.Size = new System.Drawing.Size(1264, 442);
            this.pvControl.TabIndex = 26;
            this.pvControl.CustomFieldSort += new DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventHandler(this.pivotControl_CustomFieldSort);
            this.pvControl.PopupMenuShowing += new DevExpress.XtraPivotGrid.PopupMenuShowingEventHandler(this.pvControl_PopupMenuShowing);
            this.pvControl.CustomAppearance += new DevExpress.XtraPivotGrid.PivotCustomAppearanceEventHandler(this.pvControl_CustomAppearance);
            // 
            // colGrupoPractica
            // 
            this.colGrupoPractica.Appearance.Value.Font = new System.Drawing.Font("Tw Cen MT", 9F, System.Drawing.FontStyle.Bold);
            this.colGrupoPractica.Appearance.Value.Options.UseFont = true;
            this.colGrupoPractica.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colGrupoPractica.AreaIndex = 0;
            this.colGrupoPractica.Caption = "Grupo";
            this.colGrupoPractica.FieldName = "GrupoDescripcion";
            this.colGrupoPractica.Name = "colGrupoPractica";
            this.colGrupoPractica.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupoPractica.Width = 140;
            // 
            // colGrupoOrden
            // 
            this.colGrupoOrden.AreaIndex = 0;
            this.colGrupoOrden.Caption = "Grupo Orden";
            this.colGrupoOrden.FieldName = "GrupoOrden";
            this.colGrupoOrden.Name = "colGrupoOrden";
            this.colGrupoOrden.Options.ShowInCustomizationForm = false;
            this.colGrupoOrden.Visible = false;
            // 
            // colCodigoPractica
            // 
            this.colCodigoPractica.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colCodigoPractica.AreaIndex = 1;
            this.colCodigoPractica.Caption = "Código";
            this.colCodigoPractica.FieldName = "PracticaCodigo";
            this.colCodigoPractica.Name = "colCodigoPractica";
            // 
            // colDescripcionPractica
            // 
            this.colDescripcionPractica.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colDescripcionPractica.AreaIndex = 2;
            this.colDescripcionPractica.Caption = "Práctica";
            this.colDescripcionPractica.FieldName = "PracticaDescripcion";
            this.colDescripcionPractica.Name = "colDescripcionPractica";
            this.colDescripcionPractica.Width = 400;
            // 
            // colCodigoFuncion
            // 
            this.colCodigoFuncion.AreaIndex = 0;
            this.colCodigoFuncion.Caption = "Codigo Funcion";
            this.colCodigoFuncion.FieldName = "FuncionCodigo";
            this.colCodigoFuncion.Name = "colCodigoFuncion";
            this.colCodigoFuncion.Visible = false;
            // 
            // colDescripcionFuncion
            // 
            this.colDescripcionFuncion.AreaIndex = 0;
            this.colDescripcionFuncion.Caption = "Descripcion Funcion";
            this.colDescripcionFuncion.FieldName = "FuncionDescripcion";
            this.colDescripcionFuncion.Name = "colDescripcionFuncion";
            this.colDescripcionFuncion.Visible = false;
            // 
            // colValorPactadoAnterior
            // 
            this.colValorPactadoAnterior.Appearance.Header.Options.UseTextOptions = true;
            this.colValorPactadoAnterior.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorPactadoAnterior.Appearance.Value.Options.UseTextOptions = true;
            this.colValorPactadoAnterior.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValorPactadoAnterior.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colValorPactadoAnterior.AreaIndex = 1;
            this.colValorPactadoAnterior.Caption = "Valor Ant.";
            this.colValorPactadoAnterior.FieldName = "ValorAnteriorPactado";
            this.colValorPactadoAnterior.Name = "colValorPactadoAnterior";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExportarxls});
            this.barManager1.MaxItemId = 36;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemToggleSwitch1,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit2});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1312, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 472);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1312, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 472);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1312, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 472);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight,
            this.hideContainerLeft});
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockGraficos
            // 
            this.dockGraficos.Controls.Add(this.dockPanel2_Container);
            customHeaderButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions1.Image")));
            customHeaderButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions2.Image")));
            customHeaderButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions3.Image")));
            this.dockGraficos.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("", true, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Gráfico de barras", -1, true, null, true, false, true, serializableAppearanceObject1, ((byte)(0)), -1),
            new DevExpress.XtraBars.Docking.CustomHeaderButton("", true, customHeaderButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Barras apiladas", -1, true, null, true, false, true, serializableAppearanceObject2, ((byte)(1)), -1),
            new DevExpress.XtraBars.Docking.CustomHeaderButton("", true, customHeaderButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Dona", -1, true, null, true, false, true, serializableAppearanceObject3, ((byte)(2)), -1)});
            this.dockGraficos.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockGraficos.FloatVertical = true;
            this.dockGraficos.ID = new System.Guid("131a7784-5824-4511-835b-a49d09915034");
            this.dockGraficos.Location = new System.Drawing.Point(0, 0);
            this.dockGraficos.Name = "dockGraficos";
            this.dockGraficos.Options.ShowCloseButton = false;
            this.dockGraficos.OriginalSize = new System.Drawing.Size(402, 472);
            this.dockGraficos.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockGraficos.SavedIndex = 0;
            this.dockGraficos.Size = new System.Drawing.Size(402, 472);
            this.dockGraficos.Text = "Gráfico";
            this.dockGraficos.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dockGraficos.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.dockGraficos_CustomButtonClick);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.chart);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 32);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(395, 437);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // chart
            // 
            this.chart.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chart.DataSource = this.pvControl;
            xyDiagram1.AxisX.GridLines.MinorVisible = true;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Title.MaxLineCount = 5;
            xyDiagram1.AxisX.Title.Text = "Grupo Código Práctica F";
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "H";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "A";
            xyDiagram1.AxisX.VisualRange.SideMarginsValue = 0.5D;
            xyDiagram1.AxisY.Label.TextPattern = "{V}";
            xyDiagram1.AxisY.Title.Text = "Valor Valor Ant. Diferencia %";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.RuntimePaneResize = true;
            this.chart.Diagram = xyDiagram1;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Legend.MaxHorizontalPercentage = 30D;
            this.chart.Legend.Name = "Default Legend";
            this.chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.SelectionMode = DevExpress.XtraCharts.ElementSelectionMode.Single;
            this.chart.SeriesDataMember = "Series";
            this.chart.SeriesSelectionMode = DevExpress.XtraCharts.SeriesSelectionMode.Point;
            this.chart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chart.SeriesTemplate.ArgumentDataMember = "Arguments";
            this.chart.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            sideBySideBarSeriesLabel1.MaxLineCount = 4;
            this.chart.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chart.SeriesTemplate.LegendName = "Default Legend";
            this.chart.SeriesTemplate.LegendTextPattern = "{V}";
            this.chart.SeriesTemplate.SeriesDataMember = "Series";
            this.chart.SeriesTemplate.TopNOptions.Count = 100;
            this.chart.SeriesTemplate.ValueDataMembersSerializable = "Values";
            this.chart.Size = new System.Drawing.Size(395, 437);
            this.chart.TabIndex = 0;
            this.chart.ToolTipOptions.ShowForSeries = true;
            this.chart.ObjectHotTracked += new DevExpress.XtraCharts.HotTrackEventHandler(this.chart_ObjectHotTracked);
            this.chart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chart_CustomDrawSeriesPoint);
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel3.FloatSize = new System.Drawing.Size(429, 352);
            this.dockPanel3.ID = new System.Guid("c53d547c-10c9-4b1a-98cb-6683496db838");
            this.dockPanel3.Location = new System.Drawing.Point(0, 0);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.Options.ShowCloseButton = false;
            this.dockPanel3.OriginalSize = new System.Drawing.Size(240, 200);
            this.dockPanel3.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel3.SavedIndex = 0;
            this.dockPanel3.Size = new System.Drawing.Size(240, 472);
            this.dockPanel3.Text = "Selectores";
            this.dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.accordionControl1);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(233, 443);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Controls.Add(this.accordionContentContainer14);
            this.accordionControl1.Controls.Add(this.accordionContentContainer15);
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement15});
            this.accordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.Size = new System.Drawing.Size(233, 443);
            this.accordionControl1.TabIndex = 6;
            this.accordionControl1.Text = "accordionControl1";
            // 
            // accordionContentContainer14
            // 
            this.accordionContentContainer14.Controls.Add(this.cmbPrestadoras);
            this.accordionContentContainer14.Name = "accordionContentContainer14";
            this.accordionContentContainer14.Size = new System.Drawing.Size(214, 43);
            this.accordionContentContainer14.TabIndex = 4;
            // 
            // cmbPrestadoras
            // 
            this.cmbPrestadoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrestadoras.EditValue = "Prestadoras";
            this.cmbPrestadoras.Location = new System.Drawing.Point(30, 12);
            this.cmbPrestadoras.Name = "cmbPrestadoras";
            this.cmbPrestadoras.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbPrestadoras.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrestadoras.Properties.IncrementalSearch = true;
            this.cmbPrestadoras.Properties.NullText = "Prestadoras";
            this.cmbPrestadoras.Properties.NullValuePrompt = "Prestadoras";
            this.cmbPrestadoras.Size = new System.Drawing.Size(166, 24);
            this.cmbPrestadoras.StyleController = this.styleText;
            this.cmbPrestadoras.TabIndex = 6;
            this.cmbPrestadoras.Popup += new System.EventHandler(this.cmbPrestadoras_Popup);
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
            // accordionContentContainer15
            // 
            this.accordionContentContainer15.Controls.Add(this.chkDiferenciapactadoporc);
            this.accordionContentContainer15.Controls.Add(this.chkValorpactadoanterior);
            this.accordionContentContainer15.Name = "accordionContentContainer15";
            this.accordionContentContainer15.Size = new System.Drawing.Size(214, 63);
            this.accordionContentContainer15.TabIndex = 5;
            // 
            // chkDiferenciapactadoporc
            // 
            this.chkDiferenciapactadoporc.Location = new System.Drawing.Point(30, 29);
            this.chkDiferenciapactadoporc.Name = "chkDiferenciapactadoporc";
            this.chkDiferenciapactadoporc.Properties.Caption = "Diferencia pactado en %";
            this.chkDiferenciapactadoporc.Size = new System.Drawing.Size(167, 20);
            this.chkDiferenciapactadoporc.TabIndex = 10;
            this.chkDiferenciapactadoporc.Tag = "1";
            this.chkDiferenciapactadoporc.CheckedChanged += new System.EventHandler(this.ChkColumnas_CheckedChanged);
            // 
            // chkValorpactadoanterior
            // 
            this.chkValorpactadoanterior.Location = new System.Drawing.Point(30, 3);
            this.chkValorpactadoanterior.Name = "chkValorpactadoanterior";
            this.chkValorpactadoanterior.Properties.Caption = "Valor pactado anterior";
            this.chkValorpactadoanterior.Size = new System.Drawing.Size(167, 20);
            this.chkValorpactadoanterior.TabIndex = 9;
            this.chkValorpactadoanterior.Tag = "0";
            this.chkValorpactadoanterior.CheckedChanged += new System.EventHandler(this.ChkColumnas_CheckedChanged);
            // 
            // accordionControlElement15
            // 
            this.accordionControlElement15.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement16,
            this.accordionControlElement19});
            this.accordionControlElement15.Expanded = true;
            this.accordionControlElement15.Name = "accordionControlElement15";
            this.accordionControlElement15.Text = "Parametrización";
            // 
            // accordionControlElement16
            // 
            this.accordionControlElement16.ContentContainer = this.accordionContentContainer14;
            this.accordionControlElement16.Expanded = true;
            this.accordionControlElement16.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement16.ImageOptions.Image")));
            this.accordionControlElement16.Name = "accordionControlElement16";
            this.accordionControlElement16.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement16.Text = "Principal";
            // 
            // accordionControlElement19
            // 
            this.accordionControlElement19.ContentContainer = this.accordionContentContainer15;
            this.accordionControlElement19.Expanded = true;
            this.accordionControlElement19.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement19.ImageOptions.Image")));
            this.accordionControlElement19.Name = "accordionControlElement19";
            this.accordionControlElement19.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement19.Text = "Columnas";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("97324678-34ea-47c1-a590-ddc4893c68d1");
            this.dockPanel1.Location = new System.Drawing.Point(21, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(1072, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.SavedIndex = 1;
            this.dockPanel1.SavedSizeFactor = 1.20504D;
            this.dockPanel1.Size = new System.Drawing.Size(1270, 472);
            this.dockPanel1.Text = "Detalles";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.pvControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1264, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnExportarxls
            // 
            this.btnExportarxls.Caption = "Exportar";
            this.btnExportarxls.Id = 35;
            this.btnExportarxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarxls.ImageOptions.Image")));
            this.btnExportarxls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportarxls.ImageOptions.LargeImage")));
            this.btnExportarxls.Name = "btnExportarxls";
            this.btnExportarxls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportarxls_ItemClick);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            // bgwRegistros
            // 
            this.bgwRegistros.WorkerSupportsCancellation = true;
            this.bgwRegistros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRegistros_DoWork);
            this.bgwRegistros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRegistros_RunWorkerCompleted);
            // 
            // ScreenManager
            // 
            this.ScreenManager.ClosingDelay = 500;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportarxls)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // colCodigoOs
            // 
            this.colCodigoOs.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colCodigoOs.AreaIndex = 0;
            this.colCodigoOs.Caption = "Código Os";
            this.colCodigoOs.FieldName = "CodigoOs";
            this.colCodigoOs.Name = "colCodigoOs";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 1;
            this.pivotGridField1.Caption = "Código Os";
            this.pivotGridField1.FieldName = "CodigoOs";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // colPorcentaje
            // 
            this.colPorcentaje.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colPorcentaje.AreaIndex = 1;
            this.colPorcentaje.Caption = "%";
            this.colPorcentaje.FieldName = "Porcentaje";
            this.colPorcentaje.Name = "colPorcentaje";
            // 
            // colPrestataria
            // 
            this.colPrestataria.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colPrestataria.AreaIndex = 2;
            this.colPrestataria.Caption = "Codigo";
            this.colPrestataria.FieldName = "Prestataria";
            this.colPrestataria.Name = "colPrestataria";
            // 
            // accControl
            // 
            this.accControl.Controls.Add(this.accordionContentContainer1);
            this.accControl.Controls.Add(this.accordionContentContainer2);
            this.accControl.Controls.Add(this.accordionContentContainer3);
            this.accControl.Controls.Add(this.accordionContentContainer4);
            this.accControl.Controls.Add(this.accordionContentContainer5);
            this.accControl.Controls.Add(this.accordionContentContainer6);
            this.accControl.Controls.Add(this.accordionContentContainer7);
            this.accControl.Controls.Add(this.accordionContentContainer8);
            this.accControl.Controls.Add(this.accordionContentContainer9);
            this.accControl.Controls.Add(this.accordionContentContainer10);
            this.accControl.Controls.Add(this.accordionContentContainer11);
            this.accControl.Controls.Add(this.accordionContentContainer12);
            this.accControl.Controls.Add(this.accordionContentContainer13);
            this.accControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.accControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1});
            this.accControl.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Single;
            this.accControl.Location = new System.Drawing.Point(0, 0);
            this.accControl.MinimumSize = new System.Drawing.Size(280, 0);
            this.accControl.Name = "accControl";
            this.accControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accControl.Size = new System.Drawing.Size(280, 475);
            this.accControl.TabIndex = 6;
            this.accControl.Text = "accordionControl1";
            // 
            // accordionContentContainer1
            // 
            this.accordionContentContainer1.Controls.Add(this.colGrupoPracticaFilterUIEditorContainerEdit);
            this.accordionContentContainer1.Name = "accordionContentContainer1";
            this.accordionContentContainer1.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer1.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer1.TabIndex = 1;
            // 
            // colGrupoPracticaFilterUIEditorContainerEdit
            // 
            this.colGrupoPracticaFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colGrupoPracticaFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colGrupoPracticaFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colGrupoPracticaFilterUIEditorContainerEdit.Name = "colGrupoPracticaFilterUIEditorContainerEdit";
            this.colGrupoPracticaFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colGrupoPracticaFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colGrupoPracticaFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer2
            // 
            this.accordionContentContainer2.Controls.Add(this.colGrupoOrdenFilterUIEditorContainerEdit);
            this.accordionContentContainer2.Name = "accordionContentContainer2";
            this.accordionContentContainer2.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer2.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer2.TabIndex = 2;
            // 
            // colGrupoOrdenFilterUIEditorContainerEdit
            // 
            this.colGrupoOrdenFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colGrupoOrdenFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colGrupoOrdenFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colGrupoOrdenFilterUIEditorContainerEdit.Name = "colGrupoOrdenFilterUIEditorContainerEdit";
            this.colGrupoOrdenFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colGrupoOrdenFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colGrupoOrdenFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer3
            // 
            this.accordionContentContainer3.Controls.Add(this.colCodigoPracticaFilterUIEditorContainerEdit);
            this.accordionContentContainer3.Name = "accordionContentContainer3";
            this.accordionContentContainer3.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer3.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer3.TabIndex = 3;
            // 
            // colCodigoPracticaFilterUIEditorContainerEdit
            // 
            this.colCodigoPracticaFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colCodigoPracticaFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colCodigoPracticaFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colCodigoPracticaFilterUIEditorContainerEdit.Name = "colCodigoPracticaFilterUIEditorContainerEdit";
            this.colCodigoPracticaFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colCodigoPracticaFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colCodigoPracticaFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer4
            // 
            this.accordionContentContainer4.Controls.Add(this.colDescripcionPracticaFilterUIEditorContainerEdit);
            this.accordionContentContainer4.Name = "accordionContentContainer4";
            this.accordionContentContainer4.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer4.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer4.TabIndex = 4;
            // 
            // colDescripcionPracticaFilterUIEditorContainerEdit
            // 
            this.colDescripcionPracticaFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colDescripcionPracticaFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colDescripcionPracticaFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colDescripcionPracticaFilterUIEditorContainerEdit.Name = "colDescripcionPracticaFilterUIEditorContainerEdit";
            this.colDescripcionPracticaFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colDescripcionPracticaFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colDescripcionPracticaFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer5
            // 
            this.accordionContentContainer5.Controls.Add(this.colCodigoFuncionFilterUIEditorContainerEdit);
            this.accordionContentContainer5.Name = "accordionContentContainer5";
            this.accordionContentContainer5.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer5.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer5.TabIndex = 5;
            // 
            // colCodigoFuncionFilterUIEditorContainerEdit
            // 
            this.colCodigoFuncionFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colCodigoFuncionFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colCodigoFuncionFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colCodigoFuncionFilterUIEditorContainerEdit.Name = "colCodigoFuncionFilterUIEditorContainerEdit";
            this.colCodigoFuncionFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colCodigoFuncionFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colCodigoFuncionFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer6
            // 
            this.accordionContentContainer6.Controls.Add(this.colDescripcionFuncionFilterUIEditorContainerEdit);
            this.accordionContentContainer6.Name = "accordionContentContainer6";
            this.accordionContentContainer6.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer6.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer6.TabIndex = 6;
            // 
            // colDescripcionFuncionFilterUIEditorContainerEdit
            // 
            this.colDescripcionFuncionFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colDescripcionFuncionFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colDescripcionFuncionFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colDescripcionFuncionFilterUIEditorContainerEdit.Name = "colDescripcionFuncionFilterUIEditorContainerEdit";
            this.colDescripcionFuncionFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colDescripcionFuncionFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colDescripcionFuncionFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer7
            // 
            this.accordionContentContainer7.Controls.Add(this.colFuncionFilterUIEditorContainerEdit);
            this.accordionContentContainer7.Name = "accordionContentContainer7";
            this.accordionContentContainer7.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer7.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer7.TabIndex = 7;
            // 
            // colFuncionFilterUIEditorContainerEdit
            // 
            this.colFuncionFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colFuncionFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colFuncionFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colFuncionFilterUIEditorContainerEdit.Name = "colFuncionFilterUIEditorContainerEdit";
            this.colFuncionFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colFuncionFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colFuncionFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer8
            // 
            this.accordionContentContainer8.Controls.Add(this.colValorFilterUIEditorContainerEdit);
            this.accordionContentContainer8.Name = "accordionContentContainer8";
            this.accordionContentContainer8.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer8.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer8.TabIndex = 8;
            // 
            // colValorFilterUIEditorContainerEdit
            // 
            this.colValorFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colValorFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colValorFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colValorFilterUIEditorContainerEdit.Name = "colValorFilterUIEditorContainerEdit";
            this.colValorFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colValorFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colValorFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer9
            // 
            this.accordionContentContainer9.Controls.Add(this.colCodPrestatariaFilterUIEditorContainerEdit);
            this.accordionContentContainer9.Name = "accordionContentContainer9";
            this.accordionContentContainer9.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer9.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer9.TabIndex = 9;
            // 
            // colCodPrestatariaFilterUIEditorContainerEdit
            // 
            this.colCodPrestatariaFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colCodPrestatariaFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colCodPrestatariaFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colCodPrestatariaFilterUIEditorContainerEdit.Name = "colCodPrestatariaFilterUIEditorContainerEdit";
            this.colCodPrestatariaFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colCodPrestatariaFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colCodPrestatariaFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer10
            // 
            this.accordionContentContainer10.Controls.Add(this.colDesPrestatariaFilterUIEditorContainerEdit);
            this.accordionContentContainer10.Name = "accordionContentContainer10";
            this.accordionContentContainer10.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer10.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer10.TabIndex = 10;
            // 
            // colDesPrestatariaFilterUIEditorContainerEdit
            // 
            this.colDesPrestatariaFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colDesPrestatariaFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colDesPrestatariaFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colDesPrestatariaFilterUIEditorContainerEdit.Name = "colDesPrestatariaFilterUIEditorContainerEdit";
            this.colDesPrestatariaFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colDesPrestatariaFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colDesPrestatariaFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer11
            // 
            this.accordionContentContainer11.Controls.Add(this.colValorAnteriorFilterUIEditorContainerEdit);
            this.accordionContentContainer11.Name = "accordionContentContainer11";
            this.accordionContentContainer11.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer11.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer11.TabIndex = 11;
            // 
            // colValorAnteriorFilterUIEditorContainerEdit
            // 
            this.colValorAnteriorFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colValorAnteriorFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colValorAnteriorFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colValorAnteriorFilterUIEditorContainerEdit.Name = "colValorAnteriorFilterUIEditorContainerEdit";
            this.colValorAnteriorFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colValorAnteriorFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colValorAnteriorFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer12
            // 
            this.accordionContentContainer12.Controls.Add(this.colPorcenDiferenciaFilterUIEditorContainerEdit);
            this.accordionContentContainer12.Name = "accordionContentContainer12";
            this.accordionContentContainer12.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer12.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer12.TabIndex = 12;
            // 
            // colPorcenDiferenciaFilterUIEditorContainerEdit
            // 
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.Name = "colPorcenDiferenciaFilterUIEditorContainerEdit";
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colPorcenDiferenciaFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionContentContainer13
            // 
            this.accordionContentContainer13.Controls.Add(this.colFechaInpactoFilterUIEditorContainerEdit);
            this.accordionContentContainer13.Name = "accordionContentContainer13";
            this.accordionContentContainer13.Padding = new System.Windows.Forms.Padding(-1);
            this.accordionContentContainer13.Size = new System.Drawing.Size(261, 38);
            this.accordionContentContainer13.TabIndex = 13;
            // 
            // colFechaInpactoFilterUIEditorContainerEdit
            // 
            this.colFechaInpactoFilterUIEditorContainerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colFechaInpactoFilterUIEditorContainerEdit.EditValue = "filterUIEditorContainerEdit1";
            this.colFechaInpactoFilterUIEditorContainerEdit.Location = new System.Drawing.Point(34, 6);
            this.colFechaInpactoFilterUIEditorContainerEdit.Name = "colFechaInpactoFilterUIEditorContainerEdit";
            this.colFechaInpactoFilterUIEditorContainerEdit.Properties.LookupUIEditorType = DevExpress.Utils.Filtering.LookupUIEditorType.Default;
            this.colFechaInpactoFilterUIEditorContainerEdit.Size = new System.Drawing.Size(193, 22);
            this.colFechaInpactoFilterUIEditorContainerEdit.TabIndex = 0;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.accordionControlElement4,
            this.accordionControlElement5,
            this.accordionControlElement6,
            this.accordionControlElement7,
            this.accordionControlElement8,
            this.accordionControlElement9,
            this.accordionControlElement10,
            this.accordionControlElement11,
            this.accordionControlElement12,
            this.accordionControlElement13,
            this.accordionControlElement14});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.HeaderVisible = false;
            this.accordionControlElement1.Name = "accordionControlElement1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ContentContainer = this.accordionContentContainer1;
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Grupo";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.ContentContainer = this.accordionContentContainer2;
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Grupo Orden";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.ContentContainer = this.accordionContentContainer3;
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "AM";
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.ContentContainer = this.accordionContentContainer4;
            this.accordionControlElement5.Expanded = true;
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement5.Text = "Práctica";
            // 
            // accordionControlElement6
            // 
            this.accordionControlElement6.ContentContainer = this.accordionContentContainer5;
            this.accordionControlElement6.Expanded = true;
            this.accordionControlElement6.Name = "accordionControlElement6";
            this.accordionControlElement6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement6.Text = "Codigo Funcion";
            // 
            // accordionControlElement7
            // 
            this.accordionControlElement7.ContentContainer = this.accordionContentContainer6;
            this.accordionControlElement7.Expanded = true;
            this.accordionControlElement7.Name = "accordionControlElement7";
            this.accordionControlElement7.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement7.Text = "Descripcion Funcion";
            // 
            // accordionControlElement8
            // 
            this.accordionControlElement8.ContentContainer = this.accordionContentContainer7;
            this.accordionControlElement8.Expanded = true;
            this.accordionControlElement8.Name = "accordionControlElement8";
            this.accordionControlElement8.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement8.Text = "F";
            // 
            // accordionControlElement9
            // 
            this.accordionControlElement9.ContentContainer = this.accordionContentContainer8;
            this.accordionControlElement9.Expanded = true;
            this.accordionControlElement9.Name = "accordionControlElement9";
            this.accordionControlElement9.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement9.Text = "Valor";
            // 
            // accordionControlElement10
            // 
            this.accordionControlElement10.ContentContainer = this.accordionContentContainer9;
            this.accordionControlElement10.Expanded = true;
            this.accordionControlElement10.Name = "accordionControlElement10";
            this.accordionControlElement10.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement10.Text = "Código";
            // 
            // accordionControlElement11
            // 
            this.accordionControlElement11.ContentContainer = this.accordionContentContainer10;
            this.accordionControlElement11.Expanded = true;
            this.accordionControlElement11.Name = "accordionControlElement11";
            this.accordionControlElement11.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement11.Text = "Prestataria";
            // 
            // accordionControlElement12
            // 
            this.accordionControlElement12.ContentContainer = this.accordionContentContainer11;
            this.accordionControlElement12.Expanded = true;
            this.accordionControlElement12.Name = "accordionControlElement12";
            this.accordionControlElement12.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement12.Text = "Valor Ant.";
            // 
            // accordionControlElement13
            // 
            this.accordionControlElement13.ContentContainer = this.accordionContentContainer12;
            this.accordionControlElement13.Expanded = true;
            this.accordionControlElement13.Name = "accordionControlElement13";
            this.accordionControlElement13.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement13.Text = "Diferencia %";
            // 
            // accordionControlElement14
            // 
            this.accordionControlElement14.ContentContainer = this.accordionContentContainer13;
            this.accordionControlElement14.Expanded = true;
            this.accordionControlElement14.Name = "accordionControlElement14";
            this.accordionControlElement14.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement14.Text = "Fecha Negociacion";
            // 
            // accordionControlElement17
            // 
            this.accordionControlElement17.Expanded = true;
            this.accordionControlElement17.Name = "accordionControlElement17";
            this.accordionControlElement17.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement17.Text = "Columnas";
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hideContainerRight.Controls.Add(this.dockGraficos);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1291, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(21, 472);
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hideContainerLeft.Controls.Add(this.dockPanel3);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(21, 472);
            // 
            // Frm_Analisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 472);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Frm_Analisis.IconOptions.Image")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "Frm_Analisis";
            this.Text = "Análisis de negociaciones";
            ((System.ComponentModel.ISupportInitialize)(this.reposPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockGraficos.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.accordionControl1.ResumeLayout(false);
            this.accordionContentContainer14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrestadoras.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleText)).EndInit();
            this.accordionContentContainer15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDiferenciapactadoporc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkValorpactadoanterior.Properties)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accControl)).EndInit();
            this.accControl.ResumeLayout(false);
            this.accordionContentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colGrupoPracticaFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colGrupoOrdenFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colCodigoPracticaFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colDescripcionPracticaFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colCodigoFuncionFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colDescripcionFuncionFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colFuncionFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colValorFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colCodPrestatariaFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colDesPrestatariaFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colValorAnteriorFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colPorcenDiferenciaFilterUIEditorContainerEdit.Properties)).EndInit();
            this.accordionContentContainer13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colFechaInpactoFilterUIEditorContainerEdit.Properties)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.hideContainerLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.StyleController styleText;
        private DevExpress.XtraEditors.StyleController styleLabels;
        private System.ComponentModel.BackgroundWorker bgwRegistros;
        private DevExpress.XtraSplashScreen.SplashScreenManager ScreenManager;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraPivotGrid.PivotGridControl pvControl;
        private DevExpress.XtraPivotGrid.PivotGridField colGrupoPractica;
        private DevExpress.XtraPivotGrid.PivotGridField colGrupoOrden;
        private DevExpress.XtraPivotGrid.PivotGridField colCodigoPractica;
        private DevExpress.XtraPivotGrid.PivotGridField colDescripcionPractica;
        private DevExpress.XtraPivotGrid.PivotGridField colCodigoFuncion;
        private DevExpress.XtraPivotGrid.PivotGridField colDescripcionFuncion;
        private DevExpress.XtraPivotGrid.PivotGridField colFuncion;
        private DevExpress.XtraPivotGrid.PivotGridField colValor;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField colCodigoOs;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraPivotGrid.PivotGridField colCodPrestataria;
        private DevExpress.XtraPivotGrid.PivotGridField colDesPrestataria;
        private DevExpress.XtraPivotGrid.PivotGridField colPorcentaje;
        private DevExpress.XtraPivotGrid.PivotGridField colPrestataria;
        private DevExpress.XtraBars.BarButtonItem btnExportarxls;
        private DevExpress.XtraPivotGrid.PivotGridField colValorPactadoAnterior;
        private DevExpress.XtraPivotGrid.PivotGridField colDiferenciaPactadoAnterior;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposPorcentaje;
        private DevExpress.XtraPivotGrid.PivotGridField colFechaNegociacion;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockGraficos;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraCharts.ChartControl chart;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl accControl;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer1;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colGrupoPracticaFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer2;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colGrupoOrdenFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer3;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colCodigoPracticaFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer4;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colDescripcionPracticaFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer5;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colCodigoFuncionFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer6;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colDescripcionFuncionFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer7;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colFuncionFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer8;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colValorFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer9;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colCodPrestatariaFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer10;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colDesPrestatariaFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer11;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colValorAnteriorFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer12;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colPorcenDiferenciaFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer13;
        private DevExpress.XtraEditors.Filtering.FilterUIEditorContainerEdit colFechaInpactoFilterUIEditorContainerEdit;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement6;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement7;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement8;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement9;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement10;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement11;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement12;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement13;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement14;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement15;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement16;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement17;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer14;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer accordionContentContainer15;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement19;
        private DevExpress.XtraEditors.CheckEdit chkDiferenciapactadoporc;
        private DevExpress.XtraEditors.CheckEdit chkValorpactadoanterior;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbPrestadoras;
        private DevExpress.XtraPivotGrid.PivotGridField colFechaImpacto;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
    }
}