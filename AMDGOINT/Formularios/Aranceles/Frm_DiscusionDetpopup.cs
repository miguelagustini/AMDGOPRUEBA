using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using AMDGOINT.Formularios.Practicas;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;
using System.ComponentModel;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_DiscusionDetpopup : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Practicasclass practs = new Practicasclass();

        private DiscusionDetalle discusioncls = new DiscusionDetalle();

        public List<DiscusionDetalle> discusiondet { get; set; } = new List<DiscusionDetalle>();
        public List<DiscusionDetalle> practtotales { get; set; } = new List<DiscusionDetalle>();

        private List<FuncionesAran> funciones = new List<FuncionesAran>();

        private List<GruposPracticas> grupos = new List<GruposPracticas>();

        public bool Es_Popup { get; set; } = true;
        
        public Frm_DiscusionDetpopup()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);
            gridView.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;
            gridView.CustomColumnSort += GridView_CustomColumnSort;
        }

        #region METODOS MANUALES
                      
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
          
            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            gridView.Columns["GrupoOrden"].GroupIndex = -1;
            gridView.Columns["GrupoPractica"].GroupIndex = -1;

            gridView.Columns["GrupoPractica"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            gridView.Columns["GrupoPractica"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridView.SortInfo.Add(new GridColumnSortInfo(gridView.Columns["GrupoPractica"], DevExpress.Data.ColumnSortOrder.Ascending));
            
            gridView.Columns["GrupoPractica"].GroupIndex = 0;
            gridView.OptionsView.ShowGroupPanel = false;
        }

        private void CargaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<DiscusionDetalle>(discusiondet);
                gridView.EndDataUpdate();
                gridView.ExpandAllGroups();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo(e.Message, 0);
                return;
            }
        }

        private void CargarCombos(short i = 0)
        {
            try
            {
                if (i == 0 || i == 1)
                {
                    practs.GetFuncioneslst();

                    funciones.Clear();
                    funciones = practs.funcioneslst.Where(w => w.Letra != "").ToList();
                                       
                    reposCmbfunciones.DataSource = funciones;
                }

                if (i == 0 || i == 2)
                {
                    grupos.Clear();
                    GruposPracticas p = new GruposPracticas();
                    grupos.AddRange(p.GetRegistros());
                    
                    reposCmbgrupos.DataSource = grupos;
                }
                                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos. " + e.Message, 0);
                return;
            }
        }
        
        //Custom group row content  (option #2)
        private void GridView1_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            GridView view = sender as GridView;
            if (info.Column == colGrupoPractica)
            {
                var rowValue = view.GetGroupRowValue(info.RowHandle, info.Column);
                info.GroupText = rowValue.ToString();
            }
        }

        private void GridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            int uno = Convert.ToInt32(gridView.GetListSourceRowCellValue(e.ListSourceRowIndex1, gridView.Columns["GrupoOrden"]));
            int dos = Convert.ToInt32(gridView.GetListSourceRowCellValue(e.ListSourceRowIndex2, gridView.Columns["GrupoOrden"]));

            if (uno < dos) { e.Result = -1; }
            else if(uno > dos) { e.Result = 1; }
            else { e.Result = 0;  }

            e.Handled = true;
        }

        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            CargarCombos();
            CargaDatos();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;          
        }

        private void reposObservacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }

            try
            {
                GridView view = sender as GridView;

                gridView.BeginDataUpdate();

                

                var idl = view.GetFocusedRowCellValue(colIDregistro);
                var idf = view.GetFocusedRowCellValue(colIDFuncion);
                var idgro = view.GetFocusedRowCellValue(colIDGrupo);

                if (idl == null || idf == null) { return; }

                //ACTUALIZO LOS CODIGOS Y NOMBRE DE FUNCION CUANDO SE ACTUALIZA LA LINEA
                foreach (DiscusionDetalle d in discusiondet.Where(w => w.IDLocal == idl.ToString()))
                {
                    d.CodigoFuncion = funciones.Where(w => w.ID_Registro == Convert.ToInt32(idf)).Select(s => s.Codigo).DefaultIfEmpty("").First();
                    d.DescripcionFuncion = funciones.Where(w => w.ID_Registro == Convert.ToInt32(idf)).Select(s => s.Descripcion).DefaultIfEmpty("").First();
                    d.LetraFuncion = funciones.Where(w => w.ID_Registro == Convert.ToInt32(idf)).Select(s => s.Letra).DefaultIfEmpty("").First();
                    d.GrupoPractica = grupos.Where(w => w.ID_Registro == Convert.ToInt32(idgro)).Select(s => s.Descripcion).DefaultIfEmpty("").First();
                    d.GrupoOrden = grupos.Where(w => w.ID_Registro == Convert.ToInt32(idgro)).Select(s => s.Orden).First();
                    d.GrupoObservacion = grupos.Where(w => w.ID_Registro == Convert.ToInt32(idgro)).Select(s => s.Observacion).DefaultIfEmpty("").First();

                }

                gridView.EndDataUpdate();
            }
            catch (Exception x)
            {
                ctrls.MensajeInfo(x.Message, 1);
                gridView.EndDataUpdate();
                return;                
            }   
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }

            if (gridView.IsGroupRow(gridView.FocusedRowHandle))
            {
                GridView v = gridView;
                int childCount = gridView.GetChildRowCount(v.FocusedRowHandle);

                for (int i = 0; i < childCount; i++)
                {
                    //Get the handle of a child row with the required index 
                    int childHandle = v.GetChildRowHandle(v.FocusedRowHandle, i);

                    //If the child is a group row, then add its children to the list 
                    if (!v.IsGroupRow(childHandle))                                            
                    {
                        if (e.KeyData == Keys.Delete) { v.SetRowCellValue(childHandle, colBorrarregistro, true); }
                        else if (e.KeyData == Keys.Insert) { v.SetRowCellValue(childHandle, colBorrarregistro, false); }
                        e.Handled = true;
                    }
                }

                return;
            }

            if (e.KeyData == Keys.Delete)
            {
                if (!(bool)gridView.GetFocusedRowCellValue(colBorrarregistro))
                { gridView.SetFocusedRowCellValue(colBorrarregistro, true); }
                e.Handled = true;
                return;
            }
            else if (e.KeyData == Keys.Insert)
            {
                if ((bool)gridView.GetFocusedRowCellValue(colBorrarregistro))
                { gridView.SetFocusedRowCellValue(colBorrarregistro, false); }
                e.Handled = true;
                return;
            }
        }

        private void reposCmbgrupos_EditValueChanged(object sender, EventArgs e)
        {
            /*var edit = sender as GridLookUpEdit;

            DataRow r = (edit.Properties.GetRowByKeyValue(edit.EditValue) as DataRowView).Row;

            if (r != null)
            {
                //string s = r["Descripcion"].ToString();
                //gridView.SetFocusedRowCellValue(colGrupoPractica, r["Descripcion"].ToString());
                //gridView.SetFocusedRowCellValue(colGrupoOrden, r["Orden"].ToString());
            }*/
        }

        private void btnAgregapractica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_PractDiscPopup frmp = new Frm_PractDiscPopup();
            frmp.Es_Popup = true;
            frmp.practlstuso = practtotales;


            if (frmp.ShowDialog(this) == DialogResult.OK)
            {
                gridView.BeginDataUpdate();

                frmp.practicanew.FechaNeg = discusiondet.Select(s => s.FechaNeg).DefaultIfEmpty(DateTime.Now).First();
                frmp.practicanew.TipoValor = discusiondet.Select(s => s.TipoValor).DefaultIfEmpty((byte)0).First();                
                frmp.practicanew._NuevoRegistro = true;
                
                discusiondet.Add(frmp.practicanew);

                gridControl.DataSource = discusiondet;
                gridView.EndDataUpdate();
                gridView.ExpandAllGroups();
            }
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void btnTodos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //USAR OBS PARA TODOS LOS REGISTROS
            if (gridView.RowCount <= 0) { return; }

            gridView.SetFocusedRowCellValue(colUsaObs, 3);
            gridView.UpdateCurrentRow();
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //USAR OBS PARA REGISTROS ANTERIORES
            if (gridView.RowCount <= 0) { return; }

            gridView.SetFocusedRowCellValue(colUsaObs, 1);
            gridView.UpdateCurrentRow();
        }

        private void btnPosterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //USAR OBS PARA REGISTROS POSTERIORES
            if (gridView.RowCount <= 0) { return; }

            gridView.SetFocusedRowCellValue(colUsaObs, 2);
            gridView.UpdateCurrentRow();
        }

        private void popupMenu_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (gridView.FocusedColumn == colObservacion)
            {
                barsubobservacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barallobservac.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barsubobservacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barallobservac.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btnObsallant_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //USAR OBS PARA REGISTROS ANTERIORES
            if (gridView.RowCount <= 0) { return; }
            gridView.BeginDataUpdate();
            foreach (DiscusionDetalle d in discusiondet)
            {
                d._UsaObservacion = 4;
            }

            gridView.EndDataUpdate();
        }

        private void btnObsallpost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //USAR OBS PARA REGISTROS POSTERIORES
            if (gridView.RowCount <= 0) { return; }
            gridView.BeginDataUpdate();
            foreach (DiscusionDetalle d in discusiondet)
            {
                d._UsaObservacion = 5;
            }

            gridView.EndDataUpdate();
        }

        private void btnObsall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //USAR OBS PARA REGISTROS POSTERIORES
            if (gridView.RowCount <= 0) { return; }

            gridView.BeginDataUpdate();
            foreach (DiscusionDetalle d in discusiondet)
            {
                d._UsaObservacion = 6;
            }

            gridView.EndDataUpdate();            
        }

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridView.ActiveEditor is MemoEdit)
            {

                (gridView.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridView.ActiveEditor as MemoEdit).Paint += Form1_Paint;
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
    }

}