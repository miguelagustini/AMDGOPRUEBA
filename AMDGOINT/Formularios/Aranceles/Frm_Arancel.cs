using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using AMDGOINT.Formularios.Practicas;
using System.Globalization;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraSplashScreen;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_Arancel : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Practicasclass practcls = new Practicasclass();
        private Propiedadesgral prop = new Propiedadesgral();
        private Arancelesclass aranceles = new Arancelesclass();
        public ArancelesEncabezado arancelmain = new ArancelesEncabezado();
        private List<ArancelesHistorico> aranhisto = new List<ArancelesHistorico>();
        private List<EstructuraExcel> excelimport = new List<EstructuraExcel>();

        public bool Es_Popup { get; set; } = false;        
        private string ColumnaImpacto { get; set; } = "";
        private Point LocationSplash = new Point();

        public Frm_Arancel()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);            
            this.FormClosed += new FormClosedEventHandler(Formulario_Closed);            
            advGridView.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;
        }

        #region METODOS MANUALES

        //ABM DE REGISTROS
        private void Abm()
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Guid");
                campos.Add("Fecha");
                campos.Add("Observaciones");
                if (arancelmain.IDRegistro <= 0) { campos.Add("ID_UsuNew"); }
                campos.Add("ID_UsuModif");

                parametros.Add(arancelmain.IDLocal);
                parametros.Add(Convert.ToDateTime(datFecha.Text));
                parametros.Add(txtObservaciones.Text.Trim());

                if (arancelmain.IDRegistro <= 0) { parametros.Add(glob.GetIdUsuariolog()); }

                parametros.Add(glob.GetIdUsuariolog());

                //GUARDO EL ENCABEZADO
                if (arancelmain.IDRegistro <= 0)
                {
                    func.AccionBD(campos, parametros, "I", "ARANVALORIZAENC");
                    //RECUPERO EL ID AGREGADO EN CASO DE SER UN REGISTRO NUEVO
                    arancelmain.IDRegistro = GetIDaranguid(arancelmain.IDLocal);
                }
                else { func.AccionBD(campos, parametros, "U", "ARANVALORIZAENC", arancelmain.IDRegistro); }

                //GUARDAR DETALLES
                GuardaDetalles();

                Continuacion();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al guardar los registros.\n {e.Message}", 0);
                return;
            }
        }

        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                if (ctrls.MensajePregunta("¿Desea Continuar editando?") == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    Ibusqregistros();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET ID ARANCEL POR GUID
        private int GetIDaranguid(string g)
        {
            int retorno = 0;

            try
            {
                string c = "SELECT ID_Registro FROM ARANVALORIZAENC WHERE Guid = '" + g + "'";

                foreach (DataRow r in func.getColecciondatos(c).Rows) { retorno = Convert.ToInt32(r["ID_Registro"]); }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al obtener el arancel.\n {e.Message}", 0);
                return retorno;
            }
        }

        //GUARDO LOS DETALLES 
        private void GuardaDetalles()
        {
            try
            {
                if (arancelmain.IDRegistro <= 0) { return; }

                string qry = "";
                int contador = 0;
                int acumulado = 0;               

                ConexionBD cbd = new ConexionBD();
                SqlConnection con = cbd.Conectar();

                //VALORES A INSERTAR
                List<ArancelesValoriza> detinserted = arancelmain.detalles.Where(d => d.IDRegistro == 0).ToList();
                                
                foreach (ArancelesValoriza av in detinserted)
                {

                    qry += "INSERT INTO ARANVALORIZADET (ID_Encabezado, ID_PractAm, ValorPrepaga, ValorOs, ValorArt, ValorCaja," +
                           " ObsPrepaga, ObsOs, ObsArt, ObsCaja, ID_UsuNew) VALUES ";


                    qry += $"({arancelmain.IDRegistro}, {av.IDPractAm}, {av.ValorPrepaga.ToString(new CultureInfo("en-US"))}," +
                        $" {av.ValorOs.ToString(new CultureInfo("en-US"))}, {av.ValorArt.ToString(new CultureInfo("en-US"))}," +
                        $" {av.ValorCaja.ToString(new CultureInfo("en-US"))}, '{av.ObsPrepaga.Trim()}', '{av.ObsOs.Trim()}'," +
                        $" '{av.ObsArt.Trim()}', '{av.ObsCaja.Trim()}', {glob.GetIdUsuariolog()});";                    

                    if (contador == 1000 || ((detinserted.Count - 1) == acumulado))
                    {
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            using (var command = new SqlCommand())
                            {
                                if (qry != "")
                                {
                                    command.Connection = con;
                                    command.Transaction = transaction;
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = qry;
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }

                            }
                        }

                        qry = "";
                        contador = 0;
                    }

                    acumulado++;
                    contador++;

                }

                //VALORES A ACTUALIZAR
                List<ArancelesValoriza> detupdated = arancelmain.detalles.Where(d => d.IDRegistro > 0).ToList();

                contador = 0;
                acumulado = 0;
                foreach (ArancelesValoriza av in detupdated)
                {                    
                    qry += $"UPDATE ARANVALORIZADET SET ValorPrepaga = {av.ValorPrepaga.ToString(new CultureInfo("en-US"))}," +
                           $" ValorOs = {av.ValorOs.ToString(new CultureInfo("en-US"))}, ValorArt = {av.ValorArt.ToString(new CultureInfo("en-US"))}," +
                           $" ValorCaja = {av.ValorCaja.ToString(new CultureInfo("en-US"))}, ObsPrepaga = '{av.ObsPrepaga.Trim()}'," +
                           $" ObsOs = '{av.ObsOs.Trim()}', ObsArt = '{av.ObsArt.Trim()}', ObsCaja = '{av.ObsCaja.Trim()}'," +
                           $" ID_UsuModif = {glob.GetIdUsuariolog()}" +                           
                           $" WHERE ID_Registro = {av.IDRegistro};";

                    if (contador == 1000 || ((detupdated.Count - 1) == acumulado))
                    {
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            using (var command = new SqlCommand())
                            {
                                if (qry != "")
                                {
                                    command.Connection = con;
                                    command.Transaction = transaction;
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = qry;
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }

                            }
                        }

                        qry = "";
                        contador = 0;
                    }

                    acumulado++;
                    contador++;

                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrio un error al guardar los detalles.\n {e.Message}", 0);
                return;
            }
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            if (Es_Popup)
            {
                
            }
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            

            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            advGridView.Columns["GrupoOrden"].GroupIndex = -1;
            advGridView.Columns["GrupoPractica"].GroupIndex = -1;

            advGridView.Columns["GrupoPractica"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            advGridView.Columns["GrupoPractica"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            advGridView.SortInfo.Add(new GridColumnSortInfo(advGridView.Columns["GrupoPractica"], DevExpress.Data.ColumnSortOrder.Ascending));
            advGridView.Columns["GrupoPractica"].GroupIndex = 0;
            advGridView.OptionsView.ShowGroupPanel = false;

            pnlBottom.Height = 72;
        }               
        
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            
            advGridView.BeginDataUpdate();
            ScreenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScreenManager.SplashFormLocation = LocationSplash;
            ScreenManager.ShowWaitForm();            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //CARGAR REGISTROS
        private void CargarRegistros()
        {
            try
            {
                //SOLO SI ES NUEVO REGISTRO
                if (arancelmain.IDRegistro <= 0)
                {
                    aranceles.Agregardetalles();
                    arancelmain.detalles = aranceles.arancelesdetallelst;                    
                }

                //HISTORICO
                aranceles.CargarHistorico();
                aranhisto = aranceles.aranceleshistorico;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al cargar los registros.\n {e.Message}", 0);
                return;
            }
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            ScreenManager.CloseWaitForm();
            advGridView.EndDataUpdate();
            gridControl.DataSource = arancelmain.detalles;//.OrderBy(o => o.CodigoPractica);
            advGridView.ExpandAllGroups();
            datFecha.EditValue = arancelmain.Fecha;
            txtObservaciones.Text = arancelmain.Observacion;
                        
        }

        //ASIGNAR VALOR A CELDAS SELECCIONADAS
        private void SetValores(byte opcion = 0, decimal _valor = 0)
        {
            try
            {
                
                
                //POR CADA CELDA
                foreach (GridCell cell in advGridView.GetSelectedCells())
                {
                    if (!cell.Column.OptionsColumn.AllowEdit) { continue; }

                    //SI ES VALOR FIJO
                    if (opcion == 0)
                    {
                        advGridView.SetRowCellValue(cell.RowHandle, cell.Column, _valor);
                        advGridView.UpdateCurrentRow();
                    }
                    else
                    {
                        var valor = advGridView.GetRowCellValue(cell.RowHandle, cell.Column);

                        if (valor != null && Convert.ToDecimal(valor) > 0)
                        {
                            decimal val = (Convert.ToDecimal(valor) * (_valor / 100)) + Convert.ToDecimal(valor);
                            advGridView.SetRowCellValue(cell.RowHandle, cell.Column, val);
                            advGridView.UpdateCurrentRow();
                        }
                    }
                   
                }


            }
            catch (Exception r)
            {
                ctrls.MensajeInfo($"Ocurrió un error al valorizar.\n {r.Message}", 0);
                return;
            }
        }

        //PARAMETROS DE BUSQUEDA
        private void SetInputvalores(byte opcion = 0)
        {
            try
            {                
                ImputValores dialog = new ImputValores();

                if (XtraDialog.Show(dialog, "Ingrese el valor a determinar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dialog.txtValor.Focus();

                    var val = dialog.txtValor.Text.Trim();

                    if (val != null && val.ToString().Trim() != "")
                    {
                        SetValores(opcion, Convert.ToDecimal(val));
                    }
                    else
                    {
                        ctrls.MensajeInfo("El valor ingresado no es válido.", 1); SetInputvalores(opcion);
                    }
                    
                }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al definir los parámetros de valores." + e.Message, 0);
                return;
            }
        }

        //DETERMINO SI YA EXISTE UNA VALORIZACION CON ESA FECHA
        private bool ExisteValfecha()
        {
            bool retorno = false;

            try
            {
                if (datFecha.EditValue == null) { return retorno; }

                DateTime d = datFecha.DateTime;
                string c = $"SELECT * FROM ARANVALORIZAENC WHERE Fecha = '{d.Year}-{d.Month.ToString("00")}-{d.Day.ToString("00")}' AND ID_Registro <> {arancelmain.IDRegistro}";

                if (func.getColecciondatos(c).Rows.Count > 0) { retorno = true; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al validar la fecha.\n {e.Message}", 0);
                return retorno;
            }
        }

        //QUITO LA PRACTICA Y CAMBIO DISPONIBILIDAD
        private void Procesaaccpractica()
        {
            try
            {
                //ID DE LA PRACTICA
                var idpract = advGridView.GetFocusedRowCellValue(colIDPractica);

                //ID DEL REGISTRO
                var idregistro = advGridView.GetFocusedRowCellValue(colID_Registro);

                //CAMBIO EL ESTADO DE LA PRACTICA
                if (idpract != null && Convert.ToInt32(idpract) > 0)
                {
                    //practcls.Setestadoprac(false, Convert.ToInt32(idpract));
                }

                //QUITO LA PRACTICA DE LA VALORIZACION
                if (idregistro != null && Convert.ToInt64(idregistro) > 0)
                {
                    BorrarDetalle(Convert.ToInt64(idregistro));

                    advGridView.DeleteRow(advGridView.FocusedRowHandle);
                    advGridView.UpdateCurrentRow();
                }
                else
                {
                    advGridView.DeleteRow(advGridView.FocusedRowHandle);
                    advGridView.UpdateCurrentRow();
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al quitar la práctica.\n {e.Message}", 0);
                return;
            }
        }

        //BORRO LA PRACTICA DEL VALORIZADOR
        private void BorrarDetalle(long idregistro)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                func.AccionBD(campos, parametros, "D", "ARANVALORIZADET", idregistro);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al quitar la práctica del valorizador.\n {e.Message}", 0);
                return;
            }
        }
        
        //ASIGNO VALORES A GRID
        private void SetHistorico()
        {
            try
            {

                gridViewbk.BeginDataUpdate();
                gridControlbk.DataSource = "";
                List<Localhistoval> datos = new List<Localhistoval>();

                //OBTENGO ID PRACTICA
                int idpractica = 0;
                var idp = advGridView.GetFocusedRowCellValue(colIDPractica);
                if (idp != null) { idpractica = Convert.ToInt32(idp); } else { return; }

                if (advGridView.FocusedColumn == colValorOs)
                {
                    datos = aranhisto.Where(r => r.IDPractAm == idpractica).Select(sl => new Localhistoval
                    { Mes = sl.Mes, Anio = sl.Anio, Valor = sl.ValorOs })
                    .ToList();
                }
                else if (advGridView.FocusedColumn == colValorprepaga)
                {
                    datos = aranhisto.Where(r => r.IDPractAm == idpractica).Select(sl => new Localhistoval
                    { Mes = sl.Mes, Anio = sl.Anio, Valor = sl.ValorPrepaga })
                        .ToList();
                }
                else if (advGridView.FocusedColumn == colValorArt)
                {
                    datos = aranhisto.Where(r => r.IDPractAm == idpractica).Select(sl => new Localhistoval
                    { Mes = sl.Mes, Anio = sl.Anio, Valor = sl.ValorArt })
                        .ToList();
                }
                else if (advGridView.FocusedColumn == colValorCaja)
                {
                    datos = aranhisto.Where(r => r.IDPractAm == idpractica).Select(sl => new Localhistoval
                    { Mes = sl.Mes, Anio = sl.Anio, Valor = sl.ValorCaja })
                        .ToList();
                }


                gridControlbk.DataSource = datos;

                gridViewbk.EndDataUpdate();  
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al cambiar la valorización histórica {e.Message}", 0);
                return;
            }
        }
        
        //ACTUALIZO LOS VALORES DESDE UNA IMPORTACION
        private void Actualizavalimportado()
        {
            try
            {
                advGridView.BeginDataUpdate();

                if (ColumnaImpacto == "Val. Prepaga")
                {
                    foreach (ArancelesValoriza v in arancelmain.detalles)
                    {
                        v.ValorPrepaga = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.Valor).FirstOrDefault();
                        v.ObsPrepaga =  excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.NewObservacion).DefaultIfEmpty("").First();
                    }
                }
                else if (ColumnaImpacto == "Val. OS")
                {
                    foreach (ArancelesValoriza v in arancelmain.detalles)
                    {
                        v.ValorOs = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.Valor).FirstOrDefault();
                        v.ObsOs = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.NewObservacion).DefaultIfEmpty("").First();
                    }
                }
                else if (ColumnaImpacto == "Val. Caja")
                {
                    foreach (ArancelesValoriza v in arancelmain.detalles)
                    {
                        v.ValorCaja = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.Valor).FirstOrDefault();
                        v.ObsCaja = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.NewObservacion).DefaultIfEmpty("").First();
                    }
                }
                else if (ColumnaImpacto == "Val. ART")
                {
                    foreach (ArancelesValoriza v in arancelmain.detalles)
                    {
                        v.ValorArt = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.Valor).FirstOrDefault();
                        v.ObsArt = excelimport.Where(s => s.CodigoAM == v.CodigoPractica).Select(s => s.NewObservacion).DefaultIfEmpty("").First();
                    }
                }                

                advGridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actulizar los valores importados. \n {e.Message}", 0);
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

        //
        private Rectangle GetCellRect(GridView view, int rowHandle, GridColumn column)
        {
            // the GetGridViewInfo function can be found in article #2624  
            // GridViewInfo info = GetGridViewInfo(view);  
            GridViewInfo info = (GridViewInfo)view.GetViewInfo();
            GridCellInfo cell = info.GetGridCellInfo(rowHandle, column);
            if (cell != null)
                return cell.Bounds;
            return Rectangle.Empty;
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
            Ibusqregistros();
        }

        private void Formulario_Closed(object sender, FormClosedEventArgs e)
        {
            if (!Es_Popup)
            {
                if (this.Parent is XtraTabPage)
                {
                    XtraTabPage c = this.Parent as XtraTabPage;
                    XtraTabControl x = c.Parent as XtraTabControl;
                    x.TabPages.Remove(c);
                }
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (datFecha.Text == "")
            {
                ctrls.MensajeInfo("Debe ingresar una fecha para guardar ésta valorización.", 1);
                datFecha.Focus();
                return;
            }

            if (ExisteValfecha())
            {
                ctrls.MensajeInfo("Ya existe una valorización para la fecha ingresada.", 1);
                datFecha.Focus();
                return;
            }

            Abm();
        }

        private void bgwRegistros_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CargarRegistros();           
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Fbusqregistros();
        }

        private void advGridView_MouseDown(object sender, MouseEventArgs e)
        {
            //SI ES CLICK DERECHO
            if (MouseButtons.Right == e.Button)
            {
                GridHitInfo hitInfo = advGridView.CalcHitInfo((e as MouseEventArgs).Location);                                              

                if(hitInfo.InRowCell) { popupMenu.ShowPopup(gridControl.PointToScreen(e.Location)); }

            }            
        }

        private void btnPorcentaje_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetInputvalores(1);
        }

        private void btnValoresDefecto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetInputvalores(0);
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("'")) { e.Handled = true; }
        }

        private void btnQuitapractica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (advGridView.GetSelectedRows().Length > 1)
            { ctrls.MensajeInfo("Solo puede deshabilitar una practica a la vez.", 1); return; }

            if (ctrls.MensajePregunta("La práctica se quitará del valorizador y " +
                "no estará disponible para asociarse por falta de valor.\n ¿Continuar?") == DialogResult.Yes)
            {
                Procesaaccpractica();
            }
        }

        private void advGridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            int uno = Convert.ToInt32(advGridView.GetListSourceRowCellValue(e.ListSourceRowIndex1, advGridView.Columns["GrupoOrden"]));
            int dos = Convert.ToInt32(advGridView.GetListSourceRowCellValue(e.ListSourceRowIndex2, advGridView.Columns["GrupoOrden"]));

            if (uno < dos) { e.Result = -1; }
            else
            {
                if (uno > 2) { e.Result = 1; }
                else { e.Result = 0; }
            } 

            e.Handled = true;
        }

        private void advGridView_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.I && (advGridView.FocusedColumn == colValorArt || advGridView.FocusedColumn == colValorprepaga ||
                advGridView.FocusedColumn == colValorCaja || advGridView.FocusedColumn == colValorOs))
            {
                if (flyoutPanel1.IsPopupOpen) { flyoutPanel1.HideBeakForm(); }
                SetHistorico();
                flyoutPanel1.Size = new Size(290, 250);
                Rectangle r = GetCellRect(advGridView, advGridView.FocusedRowHandle, advGridView.FocusedColumn);
                flyoutPanel1.ShowBeakForm(new Point(r.X, r.Y));

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void advGridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (flyoutPanel1.IsPopupOpen) { flyoutPanel1.HideBeakForm(); }

        }
        private void advGridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (flyoutPanel1.IsPopupOpen) { flyoutPanel1.HideBeakForm(); }
        }

        private void btnAgregapractica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_PractPopup frmp = new Frm_PractPopup();
            frmp.Es_Popup = true;
            frmp.practlstuso = arancelmain.detalles;

            if (frmp.ShowDialog(this) == DialogResult.OK)
            {
                
                arancelmain.detalles.Add(frmp.practicanew);                                
                advGridView.RefreshData();
            }
        }

        private void btnImportaxls_Click(object sender, EventArgs e)
        {
            Frm_AranImportxls fr = new Frm_AranImportxls();

            if (fr.ShowDialog() == DialogResult.OK)
            {
                excelimport = fr.excelimport;
                ColumnaImpacto = fr.ColumnaImpacto;


                if (ctrls.MensajePregunta($"¿Aplicar los valores en {ColumnaImpacto} ?") == DialogResult.Yes)
                {
                    Actualizavalimportado();
                }

            }
        }
        
        private void btnExportxls_Click(object sender, EventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);            
        }

     
    }

    public class ImputValores : XtraUserControl
    {
        public TextEdit txtValor = new TextEdit();
        
        public ImputValores()
        {
            txtValor.KeyPress += new KeyPressEventHandler(txtKeyPress);
           
            LayoutControl lc = new LayoutControl();
            lc.Dock = DockStyle.Fill;

            txtValor.Properties.NullText = "0,00";
            txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtValor.Properties.Mask.EditMask = @"-?[0-9]+(\,[0-9][0-9]?)?";// @"[0-9]*(\,\[0-9]{0,2})";
            txtValor.Properties.Mask.UseMaskAsDisplayFormat = true;
            

            SeparatorControl separatorControl = new SeparatorControl();
            lc.AddItem(String.Empty, txtValor).TextVisible = false;            
            this.Controls.Add(lc);
            this.Height = 60;
            this.Dock = DockStyle.Top;
            
        }

        private void txtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("."))
            {
                e.KeyChar = Convert.ToChar(",");
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(delegate { FocoControl(); }));
        }

        private void FocoControl() { txtValor.Focus(); }
    }


    public class Localhistoval : ArancelesHistorico
    {
        public string AnioMes { get { return Mes + " " + Anio; } }
        
        public decimal Valor { get; set; } = 0;

    }
}