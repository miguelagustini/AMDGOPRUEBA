using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraPivotGrid;
using System.Collections;
using DevExpress.Utils;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.ComponentModel;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Usr_Detalles : XtraUserControl
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrl = new Controles();
        private MC.Negociacion _negociacion = new MC.Negociacion();
        private MC.Detalles _detalle = new MC.Detalles();        
        private MC.FuncionesRecurrentes FunRec = new MC.FuncionesRecurrentes();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public MC.Negociacion Negociacion
        {
            get { return _negociacion; }
            set
            {
                if (_negociacion != value)
                {
                    _negociacion = value;
                    SetBindigs();
                }
            }
        }

        public Usr_Detalles()
        {
            InitializeComponent();
            HandleDestroyed += new EventHandler(UsrHandleDestroyed);
            ParametrosInicio();
            
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == System.Data.ConnectionState.Open ? SqlConnection : cnb.Conectar();
            FunRec.SqlConnection = SqlConnection;

            SetOptionsdefault();

            colGrupoDesc.SortMode = PivotSortMode.Custom;
            colPracticadescripcion.SortMode = PivotSortMode.Custom;
            ctrl.PreferencesGrid(null, dockManager, "R", this);

        }

        private void SetBindigs()
        {
            try
            {
                pivotControl.BeginUpdate();
                pivotControl.BeginInit();
                
                //ORDENO LA LISTA
                _detalle.OrdenaLista(Negociacion.Detalles);

                pivotControl.DataSource = Negociacion.Detalles;

                pivotControl.EndUpdate();
                pivotControl.EndInit();
                pivotControl.RefreshData();

                ListaFechas();
                ListaGrupos();                                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}.Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }

        //SELECTOR DE FECHAS
        private void ListaFechas()
        {
            try
            {
                foreach (DateTime d in Negociacion.Detalles.GroupBy(g => g.FechaNegociacion).Select(s => s.Key).ToList())
                {
                    cmbFechas.Properties.Items.Add(d.ToString("dd/MM/yyyy H:mm:ss"));
                }

            }
            catch (Exception)
            {

            }
        }

        private void ListaGrupos()
        {
            try
            {
                foreach (string g in Negociacion.Detalles.GroupBy(s => s.GrupoDescripcion).Select(s => s.Key).ToList())
                {
                    cmbGrupos.Properties.Items.Add(g);
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al cargar la lista de grupos.\n {e.Message}", 0);
                return;
            }

        }

        private void SetOptionsdefault(bool mode = true)//TRUE INICIO / FALSE CIERRE
        {
            chkDifpedidoval.EditValue = Properties.Settings.Default.Neg_coldifpedidoval;
            chkDifpedidoporc.EditValue = Properties.Settings.Default.Neg_coldifpedidoporc;
            chkDifpactadoval.EditValue = Properties.Settings.Default.Neg_coldifpactadoval;
            chkDifpactadoporc.EditValue = Properties.Settings.Default.Neg_coldifpactadoporc;
            chkDifnomencval.EditValue = Properties.Settings.Default.Neg_coldifnomencval;
            chkDifnomencporc.EditValue = Properties.Settings.Default.Neg_coldifnomencporc;
            chkCoseguro.EditValue = Properties.Settings.Default.Neg_colcoseguro;
            chkCopago.EditValue = Properties.Settings.Default.Neg_colcopago;

            Visibilidadcolumnas();
        }

        //VISIBILIDAD DE COLUMNAS
        private void Visibilidadcolumnas()
        {
            try
            {
                pivotControl.BeginInit();

                colDiferenciaPedidofijo.Visible = Properties.Settings.Default.Neg_coldifpedidoval;
                colDiferenciaPedidoporc.Visible = Properties.Settings.Default.Neg_coldifpedidoporc;
                colDiferenciaPactadofijo.Visible = Properties.Settings.Default.Neg_coldifpactadoval;
                colDiferenciaPactadoporc.Visible = Properties.Settings.Default.Neg_coldifpactadoporc;
                colDiferenciaNomenclfijo.Visible = Properties.Settings.Default.Neg_coldifnomencval;
                colDiferenciaNomenclporc.Visible = Properties.Settings.Default.Neg_coldifnomencporc;
                colCoseguro.Visible = Properties.Settings.Default.Neg_colcoseguro;
                colCopago.Visible = Properties.Settings.Default.Neg_colcopago; 

                pivotControl.EndInit();
                pivotControl.RefreshData();
            }
            catch (Exception)
            {
                pivotControl.EndInit();
                pivotControl.Refresh();
            }
        }

        //OBTENGO LA LISTA DE ITEMS SELECCIONADOS 
        private List<MC.Detalles> Getdetallesedit()
        {
            try
            {
                /***************************************************************************
                 ***************    OBTENGO LA LISTA DE CELDAS SELECCIONADAS ***************
                 *************************************************************************** 
                 ***************************************************************************/
                List<MC.Detalles> detalleslst = new List<MC.Detalles>();

                PivotGridCells cells = pivotControl.Cells;
                // Get the coordinates of the selected cells.
                Rectangle cellSelection = cells.Selection;
                // Get the index of the bottommost selected row.
                int maxRow = cellSelection.Y + cellSelection.Height;
                // Get the index of the rightmost selected column.
                int maxColumn = cellSelection.X + cellSelection.Width;
                // Iterate through the selected cells.
                for (int rowIndex = cellSelection.Y; rowIndex <= maxRow; rowIndex++)
                {
                    for (int colIndex = cellSelection.X; colIndex <= maxColumn; colIndex++)
                    {
                        if (cells.GetCellInfo(colIndex, rowIndex) != null && cells.GetCellInfo(colIndex, rowIndex).Selected)
                        {
                            PivotDrillDownDataSource ds = cells.GetCellInfo(colIndex, rowIndex).CreateDrillDownDataSource();

                            if (ds[0] != null)
                            {
                                detalleslst.Add((pivotControl.DataSource as List<MC.Detalles>)[ds[0].ListSourceRowIndex]);
                            }
                        }
                    }
                }

                return detalleslst.GroupBy(g => g.PracticaID).Select(s => s.First()).ToList();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al procesar las observaciones.\n{e.Message}", 0);
                return new List<MC.Detalles>();
            }
        }

        //REASIGNA FECHA SELECCIONADA
        private void ReasignaFecha()
        {
            try
            {

                List<MC.Detalles> details = Getdetallesedit();
                var fec = details?.GroupBy(g => g.FechaNegociacion)?.Select(s => s.Key).First();

                if (fec != null) { cmbFechas.EditValue = fec; }


                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Detalles>(details);
                gridView.EndDataUpdate();

            }
            catch (Exception)
            {
                //ctrl.MensajeInfo(e.Message, 1);
            }
        }

        //ACCIONAR
        private void Accionar()
        {
            try
            {


                

                pivotControl.BeginUpdate();
                pivotControl.BeginInit();

                //GENERACION
                if (Convert.ToInt16(radGroup.Properties.Items[radGroup.SelectedIndex].Tag) == 0)
                {
                    if (Negociacion.AgrupadorID <= 0)
                    {
                        ctrl.MensajeInfo("Debe seleccionar una obra social antes de utilizar ésta funcion.", 1);

                        pivotControl.EndUpdate();
                        pivotControl.EndInit();
                        pivotControl.RefreshData();

                        return;
                    }

                    if (ctrl.MensajePregunta("¿Crear nuevos registros a partir de la última negociación?") == System.Windows.Forms.DialogResult.No) { return; }
                    FunRec.GeneraDetalles(Negociacion); 
                }
                //COPIA DE VALORES
                else if (Convert.ToInt16(radGroup.Properties.Items[radGroup.SelectedIndex].Tag) == 1)
                {
                    if (cmbFechas.Text == "" || cmbFechas.Text == "Fecha de discusión")
                    {
                        ctrl.MensajeInfo("No hay una fecha seleccionada para proceder.", 1);
                        pivotControl.EndUpdate();
                        pivotControl.EndInit();
                        pivotControl.RefreshData();

                        return;
                    }

                    if (ctrl.MensajePregunta("¿Crear una copia de la valorización seleccionada?") == System.Windows.Forms.DialogResult.No) { return; }

                    if (cmbFechas.EditValue != null) { FunRec.CopiaValores(Negociacion.Detalles, Convert.ToDateTime(cmbFechas.Text)); }
                }
                //IMPORTACION DE VALORES
                else if (Convert.ToInt16(radGroup.Properties.Items[radGroup.SelectedIndex].Tag) == 3)
                {
                    ImportarPracticas();
                }
                //BORRAR DISCUSION
                else if (Convert.ToInt16(radGroup.Properties.Items[radGroup.SelectedIndex].Tag) == 5)
                {
                    if (cmbFechas.Text == "" || cmbFechas.Text == "Fecha de discusión")
                    {
                        ctrl.MensajeInfo("No hay una fecha seleccionada para proceder.", 1);
                        pivotControl.EndUpdate();
                        pivotControl.EndInit();
                        pivotControl.RefreshData();

                        return;
                    }

                    if (ctrl.MensajePregunta($"¿Está seguro de borrar la discusión con fecha {cmbFechas.Text}?") == System.Windows.Forms.DialogResult.No) { return; }

                    Negociacion.Detalles.RemoveAll(w => w.FechaNegociacion == Convert.ToDateTime(cmbFechas.Text));
                }
                //MODIFICAR
                else if (Convert.ToInt16(radGroup.Properties.Items[radGroup.SelectedIndex].Tag) == 6)
                {
                    if (cmbFechas.Text == "" || cmbFechas.Text == "Fecha de discusión")
                    {
                        ctrl.MensajeInfo("No hay una fecha seleccionada para proceder.", 1);
                        pivotControl.EndUpdate();
                        pivotControl.EndInit();
                        pivotControl.RefreshData();

                        return;
                    }

                   

                   
                }

                pivotControl.EndUpdate();
                pivotControl.EndInit();
                pivotControl.RefreshData();

                ListaFechas();
            }
            catch (Exception)
            {
                pivotControl.EndUpdate();
                pivotControl.EndInit();
                pivotControl.RefreshData();

            }
        }

        private void ImportarPracticas()
        {
            try
            {
                FunRec.ProcesaExcel(Negociacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region PIVOTCONTROL

        private void pivotControl_CustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
        {
           
            if (e.Field.FieldName == "GrupoDescripcion" || e.Field.FieldName == "PracticaDescripcion")
            {
                if (e.SortLocation == PivotSortLocation.Pivot)
                {
                    object orderValue1 = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrdenLista"),
                        orderValue2 = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrdenLista");
                    e.Result = Comparer.Default.Compare(orderValue1, orderValue2);
                }
                else
                {
                    e.Result = Comparer.Default.Compare(e.Value1.ToString().Split(' ')[1], e.Value2.ToString().Split(' ')[1]);
                }
                e.Handled = true;
            }
        }
        
        private void pivotControl_FocusedCellChanged(object sender, EventArgs e)
        {
            PivotGridControl pivot = (PivotGridControl)sender;
            if (pivot.Cells.Selection == Rectangle.Empty)
                pivot.Cells.MultiSelection.SetSelection(new Point[] { pivot.Cells.FocusedCell });

            ReasignaFecha();
        }

        private void pivotControl_CustomAppearance(object sender, PivotCustomAppearanceEventArgs e)
        {
            try
            {
                if ((e.DataField == colValor || e.DataField == colCoseguro || e.DataField == colCopago ||
                    e.DataField == colDiferenciaPedidoporc || e.DataField == colDiferenciaPedidofijo || e.DataField == colDiferenciaPactadofijo ||
                    e.DataField == colDiferenciaPactadoporc || e.DataField == colDiferenciaNomenclfijo || e.DataField == colDiferenciaNomenclporc)
                    && e.ColumnValueType == PivotGridValueType.Value && e.RowValueType == PivotGridValueType.Value)
                {
                    if (e.Focused)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#354f52");
                        e.Appearance.ForeColor = ColorTranslator.FromHtml("#edf6f9");
                    }

                    //VALORES APLICADOS
                    PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                    if (ds[0] == null) { e.Appearance.BackColor = ColorTranslator.FromHtml("#fec89a"); return; }
                    MC.Detalles detailed = (pivotControl.DataSource as List<MC.Detalles>)[ds[0].ListSourceRowIndex];

                    //APLICACION
                    if (detailed.Aplicado == 2)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#5e6472");
                        e.Appearance.ForeColor = ColorTranslator.FromHtml("#edf6f9");
                    }
                    else
                    {
                        //PORCENTAJE NEGATIVO EN NEGOCIACION
                        if (detailed.DifPedidoPorc < 0)
                        {
                            if (e.DataField == colValor || e.DataField == colDiferenciaPedidoporc || e.DataField == colDiferenciaPedidofijo)
                            { e.Appearance.BackColor = ColorTranslator.FromHtml("#d62828"); }
                        }

                        //DIFERENCIA NEGATIVA EN NEGOCIACION PACTADA
                        if (detailed.DifPactadoPorc < 0)
                        {
                            if (e.DataField == colValor || e.DataField == colDiferenciaPactadofijo || e.DataField == colDiferenciaPactadoporc)
                            { e.Appearance.BackColor = ColorTranslator.FromHtml("#d62828"); }
                        }

                        //DIFERENCIA NEGATIVA EN CALCULO POR NOMENCLADOR
                        if (detailed.DifNomencladoPorc < 0)
                        {
                            if (e.DataField == colValor || e.DataField == colDiferenciaNomenclporc)
                            {
                                e.Appearance.BackColor = ColorTranslator.FromHtml("#6a4c93");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void ChkColumnas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit ch = sender as CheckEdit;

                if (ch == null) { return; }                

                bool valor = (bool)ch.EditValue;
                
                switch (Convert.ToInt16(ch.Tag))
                {
                    case 0: Properties.Settings.Default.Neg_coldifpedidoval = valor; break;
                    case 1: Properties.Settings.Default.Neg_coldifpedidoporc = valor; break;
                    case 2: Properties.Settings.Default.Neg_coldifpactadoval = valor;  break;
                    case 3: Properties.Settings.Default.Neg_coldifpactadoporc = valor; break;
                    case 4: Properties.Settings.Default.Neg_coldifnomencval = valor;  break;
                    case 5: Properties.Settings.Default.Neg_coldifnomencporc = valor; break;
                    case 6: Properties.Settings.Default.Neg_colcoseguro = valor; break;
                    case 7: Properties.Settings.Default.Neg_colcopago = valor; break;
                }

                Properties.Settings.Default.Save();

                Visibilidadcolumnas();
            }
            catch (Exception)
            {
            }            
        }

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            ctrl.PreferencesGrid(null, dockManager, "S", this);
        }

        private void toolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            PivotGridControl pivotctrl = e.SelectedControl as PivotGridControl;
            if (pivotctrl == null) { return; }

            PivotGridHitInfo hitinfo = pivotctrl.CalcHitInfo(e.ControlMousePosition);

            if (hitinfo.HitTest == PivotGridHitTest.Cell)
            {
                string cellKey = string.Format("Cell|{0}|{1}", hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex);

                ToolTipControlInfo cellInfo = new ToolTipControlInfo(cellKey, "");
                cellInfo.SuperTip = new SuperToolTip();
                cellInfo.SuperTip.AllowHtmlText = DefaultBoolean.True;

                string colorsubt = "#1d3557";
                string cneg = "#e63946"; //COLOR PARA VALORES NEGATIVOS
                string cpos = "#0b090a"; //COLOR PARA VALORES POSITIVOS
                string val = "";
                PivotGridCells cells = pivotctrl.Cells;
                if (cells.GetCellInfo(hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex) != null)
                {
                    if (cells.GetCellInfo(hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex).DataField.FieldName == "Valor")
                    {
                        PivotDrillDownDataSource ds = cells.GetCellInfo(hitinfo.CellInfo.ColumnIndex, hitinfo.CellInfo.RowIndex).CreateDrillDownDataSource();

                        if (ds[0] != null)
                        {
                            MC.Detalles det = (pivotctrl.DataSource as List<MC.Detalles>)[ds[0].ListSourceRowIndex];
                                    
                            //DIFERENCIA SOBRE PEDIDO
                            if (!Properties.Settings.Default.Neg_coldifpedidoval || !Properties.Settings.Default.Neg_coldifpedidoporc)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Diferencia sobre Pedido</b></color>");

                                val = det.DifPedidoPorc < 0 ? cneg : cpos;

                                if (!Properties.Settings.Default.Neg_coldifpedidoporc) { cellInfo.SuperTip.Items.Add($"<color={val}>{Math.Round(det.DifPedidoPorc, 2).ToString(new CultureInfo("en-US"))} %</color>"); }
                                if (!Properties.Settings.Default.Neg_coldifpedidoval) { cellInfo.SuperTip.Items.Add($"<color={val}>{det.DifPedidoFijo.ToString(new CultureInfo("en-US"))} $</color>"); }

                            }
                                 
                            //DIFERENCIA SOBRE PACTADO
                            if (!Properties.Settings.Default.Neg_coldifpactadoval || !Properties.Settings.Default.Neg_coldifpactadoporc)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Diferencia sobre Pactado</b></color>");

                                val = det.DifPactadoPorc < 0 ? cneg : cpos;

                                if (!Properties.Settings.Default.Neg_coldifpactadoporc) { cellInfo.SuperTip.Items.Add($"<color={val}>{Math.Round(det.DifPactadoPorc, 2).ToString(new CultureInfo("en-US"))} %</color>"); }
                                if (!Properties.Settings.Default.Neg_coldifpactadoval) { cellInfo.SuperTip.Items.Add($"<color={val}>{det.DifPactadoFijo.ToString(new CultureInfo("en-US"))} $</color>"); }

                            }

                            //COSEGURO Y COPAGO
                            if (!Properties.Settings.Default.Neg_colcoseguro || !Properties.Settings.Default.Neg_colcopago)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Coseguros y Copagos</b></color>");

                                if (!Properties.Settings.Default.Neg_colcoseguro) { cellInfo.SuperTip.Items.Add($"Coseguro - {det.ValorCoseguro.ToString(new CultureInfo("en-US"))} $</color>"); }
                                if (!Properties.Settings.Default.Neg_colcopago) { cellInfo.SuperTip.Items.Add($"Copagos - {det.ValorCopago.ToString(new CultureInfo("en-US"))} $</color>"); }
                            }

                            //DIFERENCIAS SOBRE VALOR NOMENCLADOR
                            if (!Properties.Settings.Default.Neg_coldifnomencval)
                            {
                                cellInfo.SuperTip.Items.Add($"<color={colorsubt}><b>Diferencia sobre Nomenclador</b></color>");
                                val = det.ValorNomenclado > det.Valor ? cneg : cpos;
                                cellInfo.SuperTip.Items.Add($"<color={val}>{det.DifNomencladoFijo.ToString("N2")} $" +                                
                                $" ({det.ValorNomenclado.ToString("N2")})</color>");

                                if (det.FuncionLetra == "H" && FunRec.Getunidadgaleno(det.PracticaCodigo) > 0)
                                { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Galeno: {FunRec.Getunidadgaleno(det.PracticaCodigo)}</i></color>"); }
                                else if (det.FuncionLetra == "G" &&  FunRec.Getunidadgasto(det.PracticaCodigo) > 0)
                                { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Gastos: {FunRec.Getunidadgasto(det.PracticaCodigo)}</i></color>"); }
                                else if (det.FuncionLetra == "HA" && FunRec.Getcantidadayudantes(det.PracticaCodigo) > 0)
                                {
                                    cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>Cant. Ayudante: {FunRec.Getcantidadayudantes(det.PracticaCodigo)}</i></color>");
                                    cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Ayudante: {FunRec.Getunidadayudantes(det.PracticaCodigo)}</i></color>");
                                }
                                else if (det.FuncionLetra == "P")
                                {
                                    if (FunRec.Getunidadgaleno(det.PracticaCodigo) > 0) { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Galeno: {FunRec.Getunidadgaleno(det.PracticaCodigo)}</i></color>"); }
                                    if (FunRec.Getunidadgasto(det.PracticaCodigo) > 0) { cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Gastos: {FunRec.Getunidadgasto(det.PracticaCodigo)}</i></color>"); }
                                    if (FunRec.Getcantidadayudantes(det.PracticaCodigo) > 0)
                                    {
                                        cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>Cant. Ayudante: {FunRec.Getcantidadayudantes(det.PracticaCodigo)}</i></color>");
                                        cellInfo.SuperTip.Items.Add($"<color=#5c6b73><i>U. Ayudante: {FunRec.Getunidadayudantes(det.PracticaCodigo)}</i></color>");
                                    }
                                }
                            }

                            e.Info = cellInfo;
                        }
                    }
                }

            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Accionar();
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            
            pivotControl.RefreshData();
        }
    }
}
