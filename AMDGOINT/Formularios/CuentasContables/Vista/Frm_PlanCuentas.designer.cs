namespace AMDGOINT.Formularios.CuentasContables.Vista
{
    partial class Frm_PlanCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PlanCuentas));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AMDGOINT.Formularios.GlobalForms.FormEspera), true, true, DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual, new System.Drawing.Point(0, 0), true);
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.bgwObtienereg = new System.ComponentModel.BackgroundWorker();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelDetalles = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelEncabezado = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeView = new DevExpress.XtraTreeList.TreeList();
            this.treCodigoLargo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treCodigoCorto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treDescripcion = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treUsaReciboPrestataria = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treUsoReciboPerstador = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treUsoReciboEmpleado = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeUsoReciboTercero = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeCuentaTipo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treEstado = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeUsoOpPrestador = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeUsoOpEmpleado = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeUsoOptercero = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.reposTextSi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reposTextNo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.NavPanel = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnNuevo = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnEditar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnActualizar = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnImpresion = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.btnPrevisualizacion = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.btnExcel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.timerEscucha = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.panelDetalles.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreen
            // 
            this.splashScreen.ClosingDelay = 500;
            // 
            // navButton1
            // 
            this.navButton1.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButton1.Caption = "navButton2";
            this.navButton1.Name = "navButton1";
            // 
            // bgwObtienereg
            // 
            this.bgwObtienereg.WorkerSupportsCancellation = true;
            this.bgwObtienereg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwObtienereg_DoWork);
            this.bgwObtienereg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwObtienereg_RunWorkerCompleted);
            // 
            // dockManager
            // 
            this.dockManager.DockingOptions.ShowCloseButton = false;
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelDetalles,
            this.panelEncabezado});
            this.dockManager.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
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
            // panelDetalles
            // 
            this.panelDetalles.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.panelDetalles.Appearance.Options.UseBorderColor = true;
            this.panelDetalles.Controls.Add(this.dockPanel2_Container);
            this.panelDetalles.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelDetalles.FloatVertical = true;
            this.panelDetalles.ID = new System.Guid("e05846cb-dbbd-4d12-ae8d-6ea554aeb5aa");
            this.panelDetalles.Location = new System.Drawing.Point(0, 275);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.OriginalSize = new System.Drawing.Size(200, 175);
            this.panelDetalles.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelDetalles.SavedIndex = 0;
            this.panelDetalles.Size = new System.Drawing.Size(1082, 175);
            this.panelDetalles.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelDetalles.Text = "Detalle";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 24);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1082, 151);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.dockPanel1_Container);
            this.panelEncabezado.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelEncabezado.ID = new System.Guid("32d67652-40b1-48b7-afe8-19c2d531847f");
            this.panelEncabezado.Location = new System.Drawing.Point(0, 52);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.OriginalSize = new System.Drawing.Size(1082, 200);
            this.panelEncabezado.Size = new System.Drawing.Size(1082, 223);
            this.panelEncabezado.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Top;
            this.panelEncabezado.Text = "Comprobantes";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeView);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1082, 200);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.treeView.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.treeView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeView.Appearance.FocusedCell.Options.UseFont = true;
            this.treeView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.treeView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeView.Appearance.FocusedRow.Options.UseFont = true;
            this.treeView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.treeView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.treeView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.treeView.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeView.Appearance.Row.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.treeView.Appearance.Row.Options.UseFont = true;
            this.treeView.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeView.Appearance.SelectedRow.Font = new System.Drawing.Font("Tw Cen MT", 9F);
            this.treeView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeView.Appearance.SelectedRow.Options.UseFont = true;
            this.treeView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeView.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treCodigoLargo,
            this.treCodigoCorto,
            this.treDescripcion,
            this.treUsaReciboPrestataria,
            this.treUsoReciboPerstador,
            this.treUsoReciboEmpleado,
            this.treeUsoReciboTercero,
            this.treeCuentaTipo,
            this.treEstado,
            this.treeUsoOpPrestador,
            this.treeUsoOpEmpleado,
            this.treeUsoOptercero});
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.OptionsBehavior.Editable = false;
            this.treeView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.treeView.OptionsView.ShowIndicator = false;
            this.treeView.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reposTextSi,
            this.reposTextNo});
            this.treeView.Size = new System.Drawing.Size(1082, 200);
            this.treeView.TabIndex = 0;
            this.treeView.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.TreeView_CustomNodeCellEdit);
            this.treeView.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeView_FocusedNodeChanged);
            // 
            // treCodigoLargo
            // 
            this.treCodigoLargo.Caption = "Código";
            this.treCodigoLargo.FieldName = "CodigoLargo";
            this.treCodigoLargo.Name = "treCodigoLargo";
            this.treCodigoLargo.Visible = true;
            this.treCodigoLargo.VisibleIndex = 0;
            // 
            // treCodigoCorto
            // 
            this.treCodigoCorto.Caption = "Puntero";
            this.treCodigoCorto.FieldName = "CodigoCorto";
            this.treCodigoCorto.Name = "treCodigoCorto";
            this.treCodigoCorto.Visible = true;
            this.treCodigoCorto.VisibleIndex = 1;
            // 
            // treDescripcion
            // 
            this.treDescripcion.Caption = "Plan";
            this.treDescripcion.FieldName = "Descripcion";
            this.treDescripcion.Name = "treDescripcion";
            this.treDescripcion.Visible = true;
            this.treDescripcion.VisibleIndex = 2;
            // 
            // treUsaReciboPrestataria
            // 
            this.treUsaReciboPrestataria.Caption = "Uso Recibo Prestatarias";
            this.treUsaReciboPrestataria.FieldName = "UsoReciboPrestatariaDescripcion";
            this.treUsaReciboPrestataria.Name = "treUsaReciboPrestataria";
            this.treUsaReciboPrestataria.Visible = true;
            this.treUsaReciboPrestataria.VisibleIndex = 4;
            // 
            // treUsoReciboPerstador
            // 
            this.treUsoReciboPerstador.Caption = "Uso Recibo Prestadores";
            this.treUsoReciboPerstador.FieldName = "UsoReciboPrestadorDescripcion";
            this.treUsoReciboPerstador.Name = "treUsoReciboPerstador";
            this.treUsoReciboPerstador.Visible = true;
            this.treUsoReciboPerstador.VisibleIndex = 5;
            // 
            // treUsoReciboEmpleado
            // 
            this.treUsoReciboEmpleado.Caption = "Uso Recibo Empleados";
            this.treUsoReciboEmpleado.FieldName = "UsoReciboEmpleadoDescripcion";
            this.treUsoReciboEmpleado.Name = "treUsoReciboEmpleado";
            this.treUsoReciboEmpleado.Visible = true;
            this.treUsoReciboEmpleado.VisibleIndex = 6;
            // 
            // treeUsoReciboTercero
            // 
            this.treeUsoReciboTercero.Caption = "Uso Recibo Terceros";
            this.treeUsoReciboTercero.FieldName = "UsoReciboTerceroDescripcion";
            this.treeUsoReciboTercero.Name = "treeUsoReciboTercero";
            this.treeUsoReciboTercero.Visible = true;
            this.treeUsoReciboTercero.VisibleIndex = 7;
            // 
            // treeCuentaTipo
            // 
            this.treeCuentaTipo.Caption = "Cuenta Tipo";
            this.treeCuentaTipo.FieldName = "CuentaTipoDescripcion";
            this.treeCuentaTipo.Name = "treeCuentaTipo";
            this.treeCuentaTipo.Visible = true;
            this.treeCuentaTipo.VisibleIndex = 3;
            // 
            // treEstado
            // 
            this.treEstado.Caption = "Estado";
            this.treEstado.FieldName = "EstadoDescripcion";
            this.treEstado.Name = "treEstado";
            this.treEstado.Visible = true;
            this.treEstado.VisibleIndex = 11;
            // 
            // treeUsoOpPrestador
            // 
            this.treeUsoOpPrestador.Caption = "Uso O.P Prestador";
            this.treeUsoOpPrestador.FieldName = "UsoOrdenPagoPrestadorDescripcion";
            this.treeUsoOpPrestador.Name = "treeUsoOpPrestador";
            this.treeUsoOpPrestador.Visible = true;
            this.treeUsoOpPrestador.VisibleIndex = 8;
            // 
            // treeUsoOpEmpleado
            // 
            this.treeUsoOpEmpleado.Caption = "Uso O.P Empleado";
            this.treeUsoOpEmpleado.FieldName = "UsoOrdenPagoEmpleadoDescripcion";
            this.treeUsoOpEmpleado.Name = "treeUsoOpEmpleado";
            this.treeUsoOpEmpleado.Visible = true;
            this.treeUsoOpEmpleado.VisibleIndex = 9;
            // 
            // treeUsoOptercero
            // 
            this.treeUsoOptercero.Caption = "Uso O.P Tercero";
            this.treeUsoOptercero.FieldName = "UsoOrdenPagoTerceroDescripcion";
            this.treeUsoOptercero.Name = "treeUsoOptercero";
            this.treeUsoOptercero.Visible = true;
            this.treeUsoOptercero.VisibleIndex = 10;
            // 
            // reposTextSi
            // 
            this.reposTextSi.AutoHeight = false;
            this.reposTextSi.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("reposTextSi.ContextImageOptions.Image")));
            this.reposTextSi.Name = "reposTextSi";
            // 
            // reposTextNo
            // 
            this.reposTextNo.AutoHeight = false;
            this.reposTextNo.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("reposTextNo.ContextImageOptions.Image")));
            this.reposTextNo.Name = "reposTextNo";
            // 
            // NavPanel
            // 
            this.NavPanel.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.Appearance.Options.UseFont = true;
            this.NavPanel.AppearanceHovered.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavPanel.AppearanceHovered.Options.UseFont = true;
            this.NavPanel.Buttons.Add(this.btnNuevo);
            this.NavPanel.Buttons.Add(this.btnEditar);
            this.NavPanel.Buttons.Add(this.btnActualizar);
            this.NavPanel.Buttons.Add(this.btnImpresion);
            // 
            // tileNavCategory1
            // 
            this.NavPanel.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.NavPanel.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.NavPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(1082, 52);
            this.NavPanel.TabIndex = 8;
            this.NavPanel.Text = "tileNavPane1";
            this.NavPanel.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.NavPanel_ElementClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnNuevo.Caption = "Nuevo";
            this.btnNuevo.Enabled = false;
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnNuevo_ElementClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnEditar.Caption = "Editar";
            this.btnEditar.Enabled = false;
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditar_ElementClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnActualizar_ElementClick);
            // 
            // btnImpresion
            // 
            this.btnImpresion.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnImpresion.Caption = "Impresión";
            this.btnImpresion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImpresion.ImageOptions.Image")));
            this.btnImpresion.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.btnPrevisualizacion,
            this.btnExcel});
            this.btnImpresion.Name = "btnImpresion";
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipItem1.Text = "Opciones de Impresión";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnImpresion.SuperTip = superToolTip1;
            // 
            // 
            // 
            this.btnImpresion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            tileItemElement3.Text = "Opciones de Impresión";
            this.btnImpresion.Tile.Elements.Add(tileItemElement3);
            // 
            // btnPrevisualizacion
            // 
            this.btnPrevisualizacion.Caption = "Previsualización";
            this.btnPrevisualizacion.Name = "btnPrevisualizacion";
            // 
            // 
            // 
            this.btnPrevisualizacion.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevisualizacion.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnPrevisualizacion.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement1.ImageOptions.ImageToTextIndent = 10;
            tileItemElement1.Text = "Previsualización";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.btnPrevisualizacion.Tile.Elements.Add(tileItemElement1);
            this.btnPrevisualizacion.Tile.Name = "btnPrevisualizacion";
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Lista Excel";
            this.btnExcel.Name = "btnExcel";
            // 
            // 
            // 
            this.btnExcel.Tile.AppearanceItem.Normal.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Tile.AppearanceItem.Normal.Options.UseFont = true;
            this.btnExcel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement2.ImageOptions.ImageToTextIndent = 10;
            tileItemElement2.Text = "Lista Excel";
            this.btnExcel.Tile.Elements.Add(tileItemElement2);
            this.btnExcel.Tile.Name = "btnListaExcel";
            // 
            // timerEscucha
            // 
            this.timerEscucha.Interval = 1000;
            this.timerEscucha.Tick += new System.EventHandler(this.timerEscucha_Tick);
            // 
            // Frm_PlanCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 450);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.NavPanel);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::AMDGOINT.Properties.Resources.iconfinder_medical_healthcare_hospital_29_4082084;
            this.Name = "Frm_PlanCuentas";
            this.Text = "Cuentas Contables";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.panelDetalles.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reposTextNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private System.ComponentModel.BackgroundWorker bgwObtienereg;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel panelEncabezado;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelDetalles;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Navigation.TileNavPane NavPanel;
        private DevExpress.XtraBars.Navigation.TileNavCategory btnImpresion;
        private DevExpress.XtraBars.Navigation.TileNavItem btnPrevisualizacion;
        private DevExpress.XtraBars.Navigation.TileNavItem btnExcel;
        private DevExpress.XtraBars.Navigation.NavButton btnNuevo;
        private DevExpress.XtraBars.Navigation.NavButton btnEditar;
        private System.Windows.Forms.Timer timerEscucha;
        private DevExpress.XtraBars.Navigation.NavButton btnActualizar;
        private DevExpress.XtraTreeList.TreeList treeView;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treCodigoLargo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treCodigoCorto;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treDescripcion;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treUsaReciboPrestataria;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeCuentaTipo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposTextSi;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit reposTextNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treUsoReciboPerstador;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treUsoReciboEmpleado;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeUsoReciboTercero;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeUsoOpPrestador;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeUsoOpEmpleado;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeUsoOptercero;
    }
}