using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;

namespace AMDGOINT.Formularios.Reclamos.Vista
{
    public partial class Usr_Detalles : XtraUserControl
    {
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        private long _idreclamo = 0;
        private int _idprestataria = 0;
        public byte EstadoReclamo { get; set; } = 0;
        public string NombreCreditosExport { get; set; } = "";
        public long IDReclamo
        {
            get { return _idreclamo; }
            set
            {
                if (_idreclamo != value) { _idreclamo = value; }
                SetBindings();
            }
        }
        public int IDPrestataria
        {
            get { return _idprestataria; }
            set
            {
                if (_idprestataria != 0)
                {
                    ClearDetalles();                    
                }                
                _idprestataria = _idprestataria != value ? value : _idprestataria;
                CargaCombos(2);
            }
        }
        public List<MC.ReclamosDet> Detalles { get; set; } = new List<MC.ReclamosDet>();
        private bool Editable { get; set; } = false;        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private DataTable _dtprestatarias = new DataTable();

        public Usr_Detalles()
        {
            UsrConstructor();
        }

        #region METODOS MANUALES
        public Usr_Detalles(bool editable)
        {
            UsrConstructor(editable);
        }

        private void UsrConstructor(bool editable = false)
        {
            InitializeComponent();

            HandleDestroyed += new EventHandler(UsrHandleDestroyed);
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Editable = editable;
            gridViewDetalle.OptionsBehavior.Editable = Editable;
            ctrl.PreferencesGrid(null, gridViewDetalle, "R", this);

            datFecha.NullDate = DateTime.MinValue;
            datFecha.NullText = string.Empty;
        }

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            ctrl.PreferencesGrid(null, gridViewDetalle, "S", this);
            cnb.Desconectar();
        }

        private void SetBindings()
        {
            try
            {
                gridViewDetalle.BeginDataUpdate();
                gridControl.DataSource = null;
                gridControl.DataSource = new BindingList<MC.ReclamosDet>(Detalles);
                gridViewDetalle.EndDataUpdate();
                gridViewDetalle.RefreshData();

            }
            catch (Exception)
            {
                return;
            }
        }

        private void CargaCombos(short cmb = 0)
        {
            try
            {
                if (cmb == 0 || cmb == 1) //PROFESIONAL CUENTA
                {
                    string c = "SELECT PC.ID_Registro AS IDRegistro, PC.Codigo AS PrestadorCuenta, PC.Descripcion as PrestadorCuentaDescripcion, PF.Cuit as PrestadorCuit," +
                               " CONCAT(PC.Codigo, ' ', PC.Descripcion) AS PrestadorCompleto, PF.ID_Iva AS IDIva, CD.Abreviatura AS IvaAbreviado" +
                               " FROM PROFESIONALES PF" +
                               " LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PF.ID_Iva)" +
                               " WHERE PC.Codigo is not null" +
                               " ORDER BY PF.Nombre ASC";

                    reposCmbPrestador.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                if (cmb == 0 || cmb == 2) //PRESTATARIA PLANES
                {
                    string c = "SELECT PD.ID_Registro AS IDRegistro, PD.Codigo AS PrestatariaCuenta, PD.Descripcion as PrestatariaCuentaDescripcion, PR.Cuit AS PrestatariaCuit," +
                               " CONCAT(PD.Codigo, ' ', PD.Descripcion) AS PrestatariaCompleta, PD.PorcIva" +
                               " FROM PRESTATARIAS PR" +
                               " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Prestataria = PR.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                               " LEFT OUTER JOIN AmdgoContable.dbo.pc_PLANSUBCUENTAS PSC ON(PSC.IDRegistro = PD.IDPlanSubCuenta)" +
                               $" WHERE PR.ID_Registro = {IDPrestataria} AND PD.ID_Registro IS NOT NULL AND PD.Visible = 1";

                    
                    _dtprestatarias = null;
                    _dtprestatarias = func.getColecciondatos(c, SqlConnection);

                    reposCmbPrestatariaCuenta.DataSource = null;
                    reposCmbPrestatariaCuenta.DataSource = _dtprestatarias;


                }


            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void Usr_Detalles_Load(object sender, EventArgs e)
        {
            CargaCombos();
        }

        private void SelectorDebitos()
        {
            try
            {

                if (ParentForm is Frm_Reclamo)
                {
                    Frm_Reclamo padre = ParentForm as Frm_Reclamo;

                    if (padre.Reclamo.PrestatariaID == 0)
                    {
                        ctrl.MensajeInfo("La información de la prestataria no está completa.", 1);
                        return;
                    }
                    if (string.IsNullOrEmpty(padre.Reclamo.Periodo))
                    {
                        ctrl.MensajeInfo("La información del período no esta completo.", 1);
                        return;
                    }

                    Frm_DebitosSelector debitossel = new Frm_DebitosSelector();
                    debitossel.SqlConnection = SqlConnection;
                    debitossel.PrestatariaCuentaID = padre.Reclamo.PrestatariaID;
                    debitossel.Periodo = padre.Reclamo.Periodo;




                    if (debitossel.ShowDialog() != DialogResult.OK ||
                       debitossel.Detalles.Where(w => w.Seleccionado).Count() <= 0)
                    {
                        debitossel.Dispose();
                        return;
                    }

                    List<MC.ReclamosDet> rdlst = debitossel.Detalles.Where(w => w.Seleccionado).ToList();

                    gridViewDetalle.BeginDataUpdate();
                    Detalles.AddRange(rdlst.Where(w => !Detalles.Select(s => s.IDAsocTran).Contains(w.IDAsocTran)));
                    gridViewDetalle.EndDataUpdate();

                    debitossel.Dispose();


                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar los débitos.\n{e.Message}", 1);
                return;
            }
        }

        private void ClearDetalles()
        {
           /* gridViewDetalle.BeginDataUpdate();
            Detalles.Clear();
            gridViewDetalle.EndDataUpdate();*/
        }

        private void SetdsPrestatariasRepos(object sndr)
        {
            try
            {
               /* reposCmbPrestatariaCuenta.DataSource = null;
                reposCmbPrestatariaCuenta.DataSource = _dtprestatarias;

                if (sndr != null)
                {
                    SearchLookUpEdit cmb = sndr as SearchLookUpEdit;
                    cmb.Properties.DataSource = null;
                    cmb.Properties.DataSource = _dtprestatarias;

                }*/
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el ds de prestatarias.\n{e.Message}", 1);
                return;
            }
        }

        private void BorrarReclamo()
        {
            try
            {
                if (gridViewDetalle.RowCount <= 0 || !Editable) { return; }

                MC.ReclamosDet _det = gridViewDetalle.GetRow(gridViewDetalle.FocusedRowHandle) as MC.ReclamosDet;

                if (_det is null) { return; }


                if (ctrl.MensajePregunta("¿" + (_det._BorrarRegistro ? "Insertar" : "Eliminar") + " éste detalle?") != DialogResult.Yes) { return; }

                gridViewDetalle.BeginDataUpdate();

                if (_det.IDRegistro <= 0){ Detalles.RemoveAll(w => w == _det); }
                else { _det._BorrarRegistro = !_det._BorrarRegistro; }

                gridViewDetalle.EndDataUpdate();
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("Hubo un inconveniente al procesar el borrado.", 1);
                gridViewDetalle.EndDataUpdate();
                return;
            }
        }

        private bool PuedoEditarCelda()
        {
            try
            {
                GridView view = gridViewDetalle as GridView;

                if (view.IsGroupRow(view.FocusedRowHandle)) { return false; }

                MC.ReclamosDet _rd = view.GetRow(view.FocusedRowHandle) as MC.ReclamosDet;

                if (!view.FocusedColumn.FieldName.Equals("PrestatariaExpediente") &&
                                !view.FocusedColumn.FieldName.Equals("PrestatariaLote") &&
                                !view.FocusedColumn.FieldName.Equals("ReclamadoCantidad") &&
                                !view.FocusedColumn.FieldName.Equals("ReclamadoHonorarios") &&
                                !view.FocusedColumn.FieldName.Equals("ReclamadoGastos") &&
                                !view.FocusedColumn.FieldName.Equals("ReclamadoMedicamentos") &&
                                !view.FocusedColumn.FieldName.Equals("ReclamadoIvaPorcentaje") &&
                                !view.FocusedColumn.FieldName.Equals("RecuperadoCantidad") &&
                                !view.FocusedColumn.FieldName.Equals("RecuperadoHonorarios") &&
                                !view.FocusedColumn.FieldName.Equals("RecuperadoGastos") &&
                                !view.FocusedColumn.FieldName.Equals("RecuperadoMedicamentos") &&
                                !view.FocusedColumn.FieldName.Equals("RecuperadoIvaPorcentaje") &&
                                !view.FocusedColumn.FieldName.Equals("Observacion") &&
                                !view.FocusedColumn.FieldName.Equals("RequiereFacturaProfesional") &&
                                !view.FocusedColumn.FieldName.Equals("RequiereFacturaAmdgo") &&
                                _rd.IDAsocTran > 0)
                {
                    return false;
                }
                else { return true; }
                                
            }
            catch (Exception n)
            {
                ctrl.MensajeInfo("Hubo un inconveniente al asignar las ediciones.", 1);
                return false;
            }
        }

        private void RepetirValorCelda()
        {
            try
            {
                if (PuedoEditarCelda())
                {
                    
                    int parentrow = gridViewDetalle.GetParentRowHandle(gridViewDetalle.FocusedRowHandle);
                    string _filedname = gridViewDetalle.FocusedColumn.FieldName;
                    var v = gridViewDetalle.GetRowCellValue(gridViewDetalle.FocusedRowHandle, gridViewDetalle.FocusedColumn);

                    if (v == null || string.IsNullOrEmpty(_filedname)) { ctrl.MensajeInfo("No se obtuvo valor para procesar", 1); return; }

                    gridViewDetalle.BeginDataUpdate();
                    AsignaItemsGrupos(parentrow, _filedname, v);
                    gridViewDetalle.EndDataUpdate();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al procesar el valor.\n{e.Message}", 1);
                gridViewDetalle.EndDataUpdate();
                return;
            }
        }

        private void AsignaItemsGrupos(int filagrupo, string _filedname, object v)
        {
            try
            {
                int cantidaditems = 0;
                if (gridViewDetalle.IsGroupRow(filagrupo))
                {
                    //obtengo el numero de items en el grupo                
                    cantidaditems = gridViewDetalle.GetChildRowCount(filagrupo);

                    for (int i = 0; i < cantidaditems; i++)
                    {
                        //obtengo el handle del item segun su index
                        int childHandle = gridViewDetalle.GetChildRowHandle(filagrupo, i);

                        //el la fila hijo tambien es un grupo, agrego sus items con el mismo metodos
                        if (gridViewDetalle.IsGroupRow(childHandle))
                        {
                            AsignaItemsGrupos(childHandle, _filedname, v);
                        }
                        else
                        {
                            //cambio el valor del reclamo
                            MC.ReclamosDet p = gridViewDetalle.GetRow(childHandle) as MC.ReclamosDet;
                            if (p != null) { p.GetType().GetProperty(_filedname).SetValue(p, v); }
                        }
                    }
                }
                else
                {
                    cantidaditems = gridViewDetalle.RowCount;

                    for (int i = 0; i < cantidaditems; i++)
                    {
                        //cambio el valor del reclamo
                        MC.ReclamosDet p = gridViewDetalle.GetRow(i) as MC.ReclamosDet;
                        if (p != null) { p.GetType().GetProperty(_filedname).SetValue(p, v); }
                        
                    }
                }
                

              
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al procesar el valor.\n{e.Message}", 1);                
                return;
            }
        }

        private void ExportarCreditos()
        {
            try
            {
                if (!func.DevuelvePermiso("ReclExpCredi", SqlConnection))
                {
                    ctrl.MensajeInfo("No posee permisos para generar un archivo de créditos", 1);
                    return;
                }

                if (EstadoReclamo != 1)
                {
                    ctrl.MensajeInfo("No puede generar créditos de reclamos sin cerrar.", 1);
                    return;
                }

                MC.ReclamosDet d = new MC.ReclamosDet();
                d.GeneraExcelCreditos(Detalles.Where(w => w.RecuperadoImporteTotal > 0 && w.IDAsocTran > 0).ToList(), NombreCreditosExport);

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar la exportación.\n{e.Message}", 1);
                return;
            }
        }

        #endregion

        private void btnSeleccionDebitos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectorDebitos();
        }

        private void btnBorrarRegistros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrarReclamo();
        }



        #region  GRILLA

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridViewDetalle.ActiveEditor is MemoEdit)
            {
                (gridViewDetalle.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridViewDetalle.ActiveEditor as MemoEdit).Paint += Form1_Paint;
            }            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawFocusRectangle(e.Graphics, e.ClipRectangle);
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            if (sender is MemoEdit)
            {
                MemoEditViewInfo vi = (sender as MemoEdit).GetViewInfo() as MemoEditViewInfo;
                var cache = new GraphicsCache((sender as MemoEdit).CreateGraphics());
                int h = (vi as IHeightAdaptable).CalcHeight(cache, vi.MaskBoxRect.Width);
                var args = new ObjectInfoArgs();
                args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, h);
                var rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
                cache.Dispose();
                (sender as MemoEdit).Height = rect.Height;
            }
        }

        private void gridViewDetalle_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            gridViewDetalle.Focus();
             popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridViewDetalle_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            try
            {
                //CENTRADO DE FORM
                (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;

                GridView view = sender as GridView;
                MC.ReclamosDet _det = view.GetRow(view.FocusedRowHandle) as MC.ReclamosDet;

                //DESHABILITO LOS CONTROLES QUE NO CORRESPONDEN
                foreach (Control c in e.BindableControls)
                {
                    if (!c.DataBindings[0].BindingMemberInfo.BindingField.Equals("PrestatariaExpediente") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("PrestatariaLote") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoCantidad") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoHonorarios") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoGastos") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoMedicamentos") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoIvaPorcentaje") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoCantidad") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoHonorarios") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoGastos") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoMedicamentos") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoIvaPorcentaje") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("Observacion") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RequiereFacturaProfesional") &&
                                !c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RequiereFacturaAmdgo") &&                                
                                _det.IDAsocTran > 0) 
                    {
                        if (c is TextEdit)
                        {
                            TextEdit t = c as TextEdit;
                            t.Enabled = false;
                        }
                        else if (c is ComboBoxEdit)
                        {
                            ComboBoxEdit t = c as ComboBoxEdit;
                            t.Enabled = false;
                        }
                        else if (c is SearchLookUpEdit)
                        {
                            SearchLookUpEdit t = c as SearchLookUpEdit;
                            t.Enabled = false;
                        }
                    }
                    else
                    {
                        if (c is TextEdit)
                        {
                            TextEdit t = c as TextEdit;
                            t.Enabled = true;
                        }
                        else if (c is ComboBoxEdit)
                        {
                            ComboBoxEdit t = c as ComboBoxEdit;
                            t.Enabled = true;
                        }
                        else if (c is SearchLookUpEdit)
                        {
                            SearchLookUpEdit t = c as SearchLookUpEdit;
                            t.Enabled = true;
                        }
                    }
                }

                //CAMBIO DE COLORES PARA MEJOR RECONOCIMIENTO DE VALORES

                Color _color = new Color();
                //DESHABILITO LOS CONTROLES QUE NO CORRESPONDEN
                foreach (Control c in e.BindableControls)
                {
                    if (c.DataBindings[0].BindingMemberInfo.BindingField.Equals("FacturadoCantidad") ||
                        c.DataBindings[0].BindingMemberInfo.BindingField.Equals("FacturadoHonorarios") ||
                        c.DataBindings[0].BindingMemberInfo.BindingField.Equals("FacturadoGastos") ||
                        c.DataBindings[0].BindingMemberInfo.BindingField.Equals("FacturadoMedicamentos") ||
                        c.DataBindings[0].BindingMemberInfo.BindingField.Equals("FacturadoIvaPorcentaje"))
                    {
                        _color = Color.FromArgb(251, 86, 7);
                    }
                    else if (c.DataBindings[0].BindingMemberInfo.BindingField.Equals("DebitadoCantidad") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("DebitadoHonorarios") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("DebitadoGastos") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("DebitadoMedicamentos") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("DebitadoIvaPorcentaje"))
                    {
                        _color = Color.FromArgb(217, 4, 41);
                    }
                    else if (c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoCantidad") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoHonorarios") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoGastos") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoMedicamentos") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("ReclamadoIvaPorcentaje"))
                    {
                        _color = Color.FromArgb(24, 78, 119);
                    }
                    else if (c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoCantidad") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoHonorarios") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoGastos") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoMedicamentos") ||
                            c.DataBindings[0].BindingMemberInfo.BindingField.Equals("RecuperadoIvaPorcentaje"))
                    {
                        _color = Color.FromArgb(49, 87, 44);
                    }
                    
                    if (c is TextEdit && !_color.IsEmpty)
                    {
                        TextEdit t = c as TextEdit;
                        t.Properties.Appearance.ForeColor = _color;
                        t.Properties.AppearanceDisabled.ForeColor = _color;
                        //t.Properties.AppearanceDisabled.FontStyleDelta = FontStyle.Bold;
                    }
                    else if (c is ComboBoxEdit && !_color.IsEmpty)
                    {
                        ComboBoxEdit t = c as ComboBoxEdit;
                        t.Properties.Appearance.ForeColor = _color;
                        t.Properties.AppearanceDisabled.ForeColor = _color;
                        //t.Properties.AppearanceDisabled.FontStyleDelta = FontStyle.Bold;
                    }

                }

                //e.BindableControls["ProfesionalCuentaID"].Enabled = _det.IDAsocTranImp == 0; //view.Columns["ProfesionalCuentaID"].OptionsColumn.AllowEdit;

            }
            catch (Exception s)
            {
                ctrl.MensajeInfo(s.Message, 1);
                return;
            }
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void gridViewDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && Editable)
            {
                if (IDPrestataria <= 0) { ctrl.MensajeInfo("debe seleccionar una prestataria para ingresar detalles.", 1); return; }

                gridViewDetalle.AddNewRow();
            }
        }
        
        private void gridViewDetalle_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            e.Allow = Editable;
        }

        private void reposCmbPrestatariaCuenta_BeforePopup(object sender, EventArgs e)
        {
            SetdsPrestatariasRepos(sender);
        }

        #endregion

        private void btnExportaXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrl.ExportaraExcelgrd(gridControl);
        }

        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            btnBorrarRegistros.Visibility = Editable ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnSeleccionDebitos.Visibility = Editable ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnUsarValorTodas.Visibility = Editable ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnExportaCreditos.Visibility = !Editable && EstadoReclamo == 1 ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void gridViewDetalle_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {                
                e.Cancel = !PuedoEditarCelda();                

            }
            catch (Exception n)
            {
                ctrl.MensajeInfo("Hubo un inconveniente al asignar las ediciones.", 1);
                return;                
            }                              
        }

        private void btnUsarValorTodas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RepetirValorCelda();
        }

        private void btnExportaCreditos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportarCreditos();            
        }
    }
}
