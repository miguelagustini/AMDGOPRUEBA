using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Aranceles.Vista
{
    public partial class Usr_Detalles : XtraUserControl
    {
        private Controles ctrl = new Controles();
        private List<MC.Detalles> _detalles = new List<MC.Detalles>();

        public List<MC.Detalles> Detalles
        {
            get { return _detalles; }
            set
            {
                if (_detalles != value)
                {
                    _detalles = value;
                    SetBindigs();
                }
            }
        }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Usr_Detalles()
        {
            InitializeComponent();
            Ordenamientogrids();

        }

        private void Ordenamientogrids()
        {
            try
            {
                gridView.BeginDataUpdate();

                gridView.Columns["GrupoOrden"].GroupIndex = -1;
                gridView.Columns["GrupoDescripcion"].GroupIndex = -1;

                //ORDENO 
                gridView.Columns["GrupoDescripcion"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
                gridView.Columns["GrupoDescripcion"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                gridView.SortInfo.Add(new GridColumnSortInfo(gridView.Columns["GrupoDescripcion"], DevExpress.Data.ColumnSortOrder.Ascending));

                gridView.Columns["GrupoDescripcion"].GroupIndex = 0;

                gridView.OptionsView.ShowGroupPanel = false;
                gridView.EndDataUpdate();

            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
            }
        }

        private void SetBindigs()
        {
            try
            {
                gridView.BeginInit();
                gridView.BeginDataUpdate();

                gridControl.DataSource = Detalles;

                gridView.EndInit();
                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}.Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }

        private void Definevaloresgral()
        {
            try
            {
                Usr_Paramgeneracion prm = new Usr_Paramgeneracion();
                prm.Grupos = Detalles.GroupBy(g => new { g.GrupoDescripcion }).Select(s => s.First().GrupoDescripcion).ToList();

                if (XtraDialog.Show(prm, "Parámetros de edición", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AsignaValores(prm.Tipovalor, prm.Valor, prm.Gruposel);

                }

                prm.Dispose();
            }
            catch (Exception)
            {

            }
        }

        private void AgregarPracticas()
        {
            try
            {
                Practicas.Vista.Frm_Practicasbusq prm = new Practicas.Vista.Frm_Practicasbusq();
                
                prm.SqlConnection = SqlConnection;
                prm.PracticasID.AddRange(Detalles.GroupBy(g => g.IDPractica).Select(s => s.First().IDPractica).ToList());

                if (prm.ShowDialog(this) == DialogResult.OK)
                {
                    gridView.BeginDataUpdate();

                    foreach (Practicas.MC.Practica p in prm.PracticasRetorno)
                    {
                        MC.Detalles d = new MC.Detalles();
                        d.IDPractica = p.IDRegistro;
                        d.PracticaCodigo = p.Codigo;
                        d.PracticaDescripcion = p.Descripcion;
                        d.GrupoId = p.IDGrupo;
                        d.GrupoDescripcion = p.GrupoDescripcion;
                        d.GrupoOrden = p.GrupoOrden;
                        d.FuncionID = p.IDFuncion;
                        d.FuncionLetra = p.FuncionLetra;
                        d.FuncionCodigo = p.FuncionCodigo;
                        d.FuncionDescripcion = p.FuncionDescripcion;

                        Detalles.Add(d);
                    }
                    
                    gridView.EndDataUpdate();
                }

                prm.Dispose();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al agregar la práctica.\n{e.Message}",1);
                return;
            }
        }

        private void IniciaSimulacion()
        {
            if (ctrl.MensajePregunta("Está a punto de iniciar una simulación de negociación.\n" +
                "Este proceso puede tardar ¿Continuar de todos modos?") != DialogResult.Yes) { return; }
        }

        //ASIGNA VALORES GRID
        private void AsignaValores(bool tipovalor, decimal valor, List<string> aplicaen)
        {
            try
            {
                gridView.BeginDataUpdate();

                //GRUPO
                if (aplicaen.Count > 0)
                {
                    foreach (MC.Detalles i in Detalles.Where(w => aplicaen.Contains(w.GrupoDescripcion)))
                    {
                        i.ValorTipo = tipovalor;
                        i.Valor = valor;
                    }
                }

                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al actualizar los valores.\n{e.Message}", 1);
                return;
            }
        }

        private void gridView_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            GridView view = sender as GridView;
            if (info.Column == colGrupoDescr)
            {
                var rowValue = view.GetGroupRowValue(info.RowHandle, info.Column);
                info.GroupText = rowValue.ToString();
            }
        }

        private void gridView_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            try
            {
                object val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "OrdenLista");
                object val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "OrdenLista");
                e.Result = System.Collections.Comparer.Default.Compare(val1, val2);
                e.Handled = true;

            }
            catch (Exception)
            {

            }
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).Width = (int)Math.Round((double)this.Width / 2, 0);
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;            
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (gridView.RowCount <= 0) { return; }
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void toolTipController_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            try
            {
                //CON ESTO DETERMINO DESDE QUE CONTROL ES LLAMADO EN CASO DE HABERLO ASIGNADO A MAS DE UNO
                //if (e.Info == null && e.SelectedControl == gridControl)
                GridView view = gridControl.FocusedView as GridView;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                string text = "";

                if (info.InRowCell && info.Column == colFuncionletra)
                {
                    MC.Detalles detail = view.GetRow(info.RowHandle) as MC.Detalles;
                    text = detail.FuncionDescripcion;                    
                }
                else if (info.InColumn && info.Column == colValorTipo)
                {   
                    text = "Determina si el valor de la práctica será calculado por porcentaje de aumento\no se le asignará un valor fijo.";                    
                }
                else if (info.InColumn && info.Column == colDefecto)
                {                    
                    text = "Asignar un valor a éste campo, provocará que la práctica sea agregada con éste valor por defecto\n" +
                        "para todas aquellas negociaciones donde no la hayan pactado con anterioridad.\n" +
                        "Si la práctica existe, se calculará según el tipo de valor seleccionado en (Tipo de Valor).";                    
                }
                else if (info.InColumn && info.Column == colPracticacodigo)
                {
                    text = "Código de la práctica.";                    
                }
                else if (info.InColumn && info.Column == colPracticadescr)
                {
                    text = "Nombre de la práctica.";                    
                }
                else if (info.InColumn && info.Column == colFuncionletra)
                {
                    text = "Función.";                    
                }
                else if (info.InColumn && info.Column == colValor)
                {
                    text = "Valor de cálculo porcentual o valor fijo.";                    
                }
                else if (info.InColumn && info.Column == colIncluir)
                {
                    text = "Esto determina si la práctica será incluída o excluída de las negociaciones a generar.";
                }

                //APLICO EL HINT SI HAY TEXTO
                if (!string.IsNullOrWhiteSpace(text)) { e.Info = new DevExpress.Utils.ToolTipControlInfo(cellKey, text); }
            }
            catch (Exception)
            {

            }
        }
        
        private void btnDefiniciongral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DEFINICION DE VALORES GENERALES  (POR GRUPO)
            Definevaloresgral();
        }
        
        private void btnAgregapractica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgregarPracticas();
        }

        private void btnSimularNegociacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IniciaSimulacion();
        }
    }
}
