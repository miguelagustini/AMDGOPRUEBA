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

namespace AMDGOINT.Formularios.Devoluciones.Vista
{
    public partial class Usr_Detalles : XtraUserControl
    {
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        private long _iddevolucion = 0;
        private int _idprestador = 0;
        public long IDDevolucion
        {
            get { return _iddevolucion; }
            set
            {
                if (_iddevolucion != value) { _iddevolucion = value; }
                SetBindings();
            }
        }
        public int IDPrestador
        {
            get { return _idprestador; }
            set
            {
                if (_idprestador != 0 && Editable)
                {
                    ClearDetalles();                    
                }                
                _idprestador = _idprestador != value ? value : _idprestador;
                CargaCombos(2);
            }
        }
        public List<MC.DevolucionesDet> Detalles { get; set; } = new List<MC.DevolucionesDet>();
        private bool Editable { get; set; } = false;        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
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
            ctrl.PreferencesGrid(null, ViewDetallesDevo, "R", this);

            datFecha.NullDate = DateTime.MinValue;
            datFecha.NullText = string.Empty;
        }

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            ctrl.PreferencesGrid(null, ViewDetallesDevo, "S", this);
            cnb.Desconectar();
        }

        private void SetBindings()
        {
            try
            {
                ViewDetallesDevo.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.DevolucionesDet>(Detalles);
                ViewDetallesDevo.EndDataUpdate();

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
                               $" WHERE PC.Codigo is not null AND PF.ID_Registro = {IDPrestador}" +
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
                               $" WHERE PD.ID_Registro IS NOT NULL AND PD.Visible = 1";
                                        
                    reposCmbPrestatariaCuenta.DataSource = func.getColecciondatos(c, SqlConnection);

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

                if (ParentForm is Frm_Devolucion)
                {
                    Frm_Devolucion padre = ParentForm as Frm_Devolucion;

                    if (padre.Devolucion.PrestadorID == 0)
                    {
                        ctrl.MensajeInfo("La información del prestador no está completa.", 1);
                        return;
                    }
                    /*if (string.IsNullOrEmpty(padre.Devolucion.Periodo))
                    {
                        ctrl.MensajeInfo("La información del período no esta completo.", 1);
                        return;
                    }*/

                    Frm_DebitosSelector debitossel = new Frm_DebitosSelector();
                    debitossel.SqlConnection = SqlConnection;
                    debitossel.PrestadorID = padre.Devolucion.PrestadorID;
                    debitossel.Periodo = padre.Devolucion.Periodo;

                    if (debitossel.ShowDialog() != DialogResult.OK ||
                       debitossel.Detalles.Where(w => w.Seleccionado).Count() <= 0)
                    {
                        debitossel.Dispose();
                        return;
                    }

                    List<MC.DevolucionesDet> rdlst = debitossel.Detalles.Where(w => w.Seleccionado).ToList();

                    ViewDetallesDevo.BeginDataUpdate();
                    Detalles.AddRange(rdlst.Where(w => !Detalles.Select(s => s.IDAsocTranImp).Contains(w.IDAsocTranImp)));
                    ViewDetallesDevo.EndDataUpdate();

                    debitossel.Dispose();


                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar los débitos.\n{e.Message}", 1);
                return;
            }
        }

        private void SelectorOrdenesAmb()
        {
            try
            {

                if (ParentForm is Frm_Devolucion)
                {
                    Frm_Devolucion padre = ParentForm as Frm_Devolucion;

                    if (padre.Devolucion.PrestadorID == 0)
                    {
                        ctrl.MensajeInfo("La información del prestador no está completa.", 1);
                        return;
                    }
                    /*if (string.IsNullOrEmpty(padre.Devolucion.Periodo))
                    {
                        ctrl.MensajeInfo("La información del período no esta completo.", 1);
                        return;
                    }*/

                    Frm_OrdenesSelector debitossel = new Frm_OrdenesSelector();
                    debitossel.SqlConnection = SqlConnection;
                    debitossel.PrestadorID = padre.Devolucion.PrestadorID;
                    debitossel.Periodo = padre.Devolucion.Periodo;

                    if (debitossel.ShowDialog() != DialogResult.OK ||
                       debitossel.Detalles.Where(w => w.Seleccionado).Count() <= 0)
                    {
                        debitossel.Dispose();
                        return;
                    }

                    List<MC.DevolucionesDet> rdlst = debitossel.Detalles.Where(w => w.Seleccionado).ToList();

                    ViewDetallesDevo.BeginDataUpdate();
                    Detalles.AddRange(rdlst.Where(w => !Detalles.Select(s => s.IDAsocMedDos).Contains(w.IDAsocMedDos)));
                    ViewDetallesDevo.EndDataUpdate();

                    debitossel.Dispose();


                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al consultar los débitos.\n{e.Message}", 1);
                return;
            }
        }

        private void SelectorOrdenesInt()
        {
            try
            {

                if (ParentForm is Frm_Devolucion)
                {
                    Frm_Devolucion padre = ParentForm as Frm_Devolucion;

                    if (padre.Devolucion.PrestadorID == 0)
                    {
                        ctrl.MensajeInfo("La información del prestador no está completa.", 1);
                        return;
                    }
                  /*  if (string.IsNullOrEmpty(padre.Devolucion.Periodo))
                    {
                        ctrl.MensajeInfo("La información del período no esta completo.", 1);
                        return;
                    }*/

                    Frm_OrdenesIntSelector debitossel = new Frm_OrdenesIntSelector();
                    debitossel.SqlConnection = SqlConnection;
                    debitossel.PrestadorID = padre.Devolucion.PrestadorID;
                    debitossel.Periodo = padre.Devolucion.Periodo;

                    if (debitossel.ShowDialog() != DialogResult.OK ||
                       debitossel.Detalles.Where(w => w.Seleccionado).Count() <= 0)
                    {
                        debitossel.Dispose();
                        return;
                    }

                    List<MC.DevolucionesDet> rdlst = debitossel.Detalles.Where(w => w.Seleccionado).ToList();

                    ViewDetallesDevo.BeginDataUpdate();
                    Detalles.AddRange(rdlst.Where(w => !Detalles.Select(s => s.IdentificadorInternacionLocal).Contains(w.IdentificadorInternacionLocal)));
                    ViewDetallesDevo.EndDataUpdate();

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
            ViewDetallesDevo.BeginDataUpdate();
            Detalles.Clear();
            ViewDetallesDevo.EndDataUpdate();
        }
               
        private void BorrarDetalle()
        {
            try
            {
                if (ViewDetallesDevo.RowCount <= 0 || !Editable) { return; }

                MC.DevolucionesDet _det = ViewDetallesDevo.GetRow(ViewDetallesDevo.FocusedRowHandle) as MC.DevolucionesDet;

                if (_det is null) { return; }


                if (ctrl.MensajePregunta("¿" + (_det._BorrarRegistro ? "Insertar" : "Eliminar") + " éste detalle?") != DialogResult.Yes) { return; }

                ViewDetallesDevo.BeginDataUpdate();

                if (_det.IDRegistro <= 0){ Detalles.RemoveAll(w => w == _det); }
                else { _det._BorrarRegistro = !_det._BorrarRegistro; }

                ViewDetallesDevo.EndDataUpdate();
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("Hubo un inconveniente al procesar el borrado.", 1);
                ViewDetallesDevo.EndDataUpdate();
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
            BorrarDetalle();
        }

        #region  GRILLA

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (ViewDetallesDevo.ActiveEditor is MemoEdit)
            {
                (ViewDetallesDevo.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (ViewDetallesDevo.ActiveEditor as MemoEdit).Paint += Form1_Paint;
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
                ViewDetallesDevo.Focus();
             popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridViewDetalle_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            try
            {
                //CENTRADO DE FORM
                (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;                              
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
                if (IDPrestador <= 0) { ctrl.MensajeInfo("debe seleccionar una prestataria para ingresar detalles.", 1); return; }

                ViewDetallesDevo.AddNewRow();
            }
        }
        
        private void gridViewDetalle_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            e.Allow = Editable;
        }

        private void reposCmbPrestatariaCuenta_BeforePopup(object sender, EventArgs e)
        {
            
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
            btnSeleccionOrdenesAmb.Visibility = Editable ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnSeleccionOrdenes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectorOrdenesAmb();
        }

        private void btnSeleccionOrdenesInt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectorOrdenesInt();
        }
    }
}
