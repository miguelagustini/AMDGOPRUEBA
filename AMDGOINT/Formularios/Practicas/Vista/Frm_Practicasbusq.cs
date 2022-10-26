using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace AMDGOINT.Formularios.Practicas.Vista
{
    public partial class Frm_Practicasbusq : XtraForm
    {
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private MC.Practica Practica = new MC.Practica();
        private List<MC.Practica> Practicasnew { get; set; } = new List<MC.Practica>(); //LISTA DE PRACTICAS A SELECCIONAR (INTERNAS)

        public ArrayList PracticasID = new ArrayList();//LISTA DE PRACTICAS EXISTENTES A EXCLUIR POR ID (EXTERNAS)        
        public List<MC.Practica> PracticasRetorno { get; private set; } = new List<MC.Practica>();// LISTA DE PRACTICAS SELECCIONADAS A DEVOLVER (INTERNO Y EXTERNO)
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        public Frm_Practicasbusq()
        {
            InitializeComponent();
        }

        private void PrametrosInicio()
        {
            try
            {
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Practica.SqlConnection = SqlConnection;
                Ordenamientogrids();
                IBusqpracticas();
            }
            catch (Exception)
            {

            }
        }

        private void IBusqpracticas()
        {
            gridView.BeginInit();
            gridView.BeginDataUpdate();
            
            if (!bgwRegistros.IsBusy) { bgwRegistros.RunWorkerAsync(); }            
        }

        private void Listapracticas()
        {
            try
            {
                Practicasnew.Clear();
                Practicasnew = Practica.GetRegistros().Where(w => !PracticasID.Contains(w.IDRegistro) && w.FuncionLetra != "PP" && w.FuncionLetra != "AF").ToList();

            }
            catch (Exception)
            {
                ctrl.MensajeInfo("Huboo un inconveniente en la selecion de prácticas", 1);                
                return;
            }
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

        private void FBusqpracticas()
        {
            gridControl.DataSource = Practicasnew;

            gridView.EndInit();
            gridView.EndDataUpdate();
        }

        private void AsignaSeleccionados()
        {
            try
            {
                PracticasRetorno.Clear();

                foreach (int v in gridView.GetSelectedRows())
                {
                    if(!gridView.IsGroupRow(v))
                    PracticasRetorno.Add(gridView.GetRow(v) as MC.Practica);
                }

            }
            catch (Exception)
            {

            }
        }

        private void Usr_Practicasbusq_Load(object sender, EventArgs e)
        {
            PrametrosInicio();
        }

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            Listapracticas();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FBusqpracticas();
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

        private void gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            AsignaSeleccionados();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
