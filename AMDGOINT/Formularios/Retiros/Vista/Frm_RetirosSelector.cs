using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;
using System.Collections;

namespace AMDGOINT.Formularios.Retiros.Vista
{
    public partial class Frm_RetirosSelector : XtraForm
    {
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private OverlayPanel OverlayPanel = new OverlayPanel();
        public List<MC.Retiros> Detalles { get; set; } = new List<MC.Retiros>();
        private MC.Retiros Detalle = new Retiros.MC.Retiros();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public int IDTercero { get; set; } = 0;
        public int IDPrestador { get; set; } = 0;

        public Frm_RetirosSelector()
        {
            InitializeComponent();

            reposFechas.NullDate = DateTime.MinValue;
            reposFechas.NullText = string.Empty;
        }

        private void ParametrosInicio()
        {
            try
            {
                ctrl.PreferencesGrid(this, gridView, "R");
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Detalle.SqlConnection = SqlConnection;
                IbusqDetalles();

            }
            catch (Exception)
            {

            }
        }

        private void IbusqDetalles()
        {
            try
            {
                if (bgwRegistros.IsBusy) { return; }
                OverlayPanel.Mostrar(this);
                gridView.BeginDataUpdate();
                bgwRegistros.RunWorkerAsync();

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                return;
            }
        }

        private void BusqDetalles()
        {
            try
            {
                Detalle.SqlConnection = SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection;
                Detalles.Clear();
                Detalles.AddRange(Detalle.GetRetirosPedientesPago(IDTercero, IDPrestador));
                gridControl.DataSource = Detalles;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        private void FbusqDetalles()
        {
            try
            {
                gridView.EndDataUpdate();
                OverlayPanel.Ocultar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar la lista.\n{e.Message}", 1);
                gridView.EndDataUpdate();
                return;
            }

        }

        //CREO LA COLECCION DE RETIROS EN CASO DE SELECCIONAR UN GRUPO
        private void SetRetirosLista(int filaprocesar)
        {
            try
            {               
                int groupRowHandle = filaprocesar;
                AsignaItemsGrupos(groupRowHandle);
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes al crear la lista de retiros.\n{e.Message}", 1);
                
                return;
            }
        }

        private void AsignaItemsGrupos(int filagrupo)
        {
            try
            {
                //obtengo el numero de items en el grupo
                int cantidaditems = gridView.GetChildRowCount(filagrupo);

                for (int i = 0; i < cantidaditems; i++)
                {
                    //obtengo el handle del item segun su index
                    int childHandle = gridView.GetChildRowHandle(filagrupo, i);

                    //el la fila hijo tambien es un grupo, agrego sus items con el mismo metodos
                    if (gridView.IsGroupRow(childHandle))
                    {
                        //AsignaItemsGrupos(childHandle);
                        SetRetirosLista(childHandle);
                    }
                    else
                    {                        
                        MC.Retiros d = gridView.GetRow(childHandle) as MC.Retiros;
                        if (d == null) { return; }
                        d.Seleccionado = gridView.IsRowSelected(childHandle);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //MARCA SELECCION DE FILAS EN ORIGEN DATOS
        private void MarcaSeleccionado(bool esgrupo)
        {
            try
            {
                gridView.BeginDataUpdate();

                if (esgrupo)
                {
                    SetRetirosLista(gridView.FocusedRowHandle);
                }
                else
                {                    
                    MC.Retiros d = gridView.GetRow(gridView.FocusedRowHandle) as MC.Retiros;
                    if (d != null)
                    {
                        d.Seleccionado = gridView.IsRowSelected(gridView.FocusedRowHandle);
                    } 
                    
                }

                gridView.EndDataUpdate();
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo seleccionar.", 1);
                gridView.EndDataUpdate();
                return;
            }
        }

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            BusqDetalles();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FbusqDetalles();
        }


        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                MarcaSeleccionado(gridView.IsGroupRow(gridView.FocusedRowHandle));                
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Frm_RetirosSelector_Load(object sender, EventArgs e)
        {

        }

        private void Frm_RetirosSelector_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_RetirosSelector_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            ctrl.PreferencesGrid(this, gridView, "S");
        }
    }
}
