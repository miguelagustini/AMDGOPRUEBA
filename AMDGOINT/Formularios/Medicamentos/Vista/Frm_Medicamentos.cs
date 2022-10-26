using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraSplashScreen;

namespace AMDGOINT.Formularios.Medicamentos.Vista
{
    public partial class Frm_Medicamentos : XtraForm
    {
        private Controles ctrl = new Controles();
        private ConexionBD conexion = new ConexionBD();
        private Globales glb = new Globales();

        private List<MC.Medicamento> Medicamentos { get; set; } = new List<MC.Medicamento>();
        private MC.Medicamento Medicamento = new MC.Medicamento();
        private MC.MedicamentosProc MedicamentosProc = new MC.MedicamentosProc();
        private string path = "";
        private Point LocationSplash = new Point();

        public Frm_Medicamentos()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;
        }
        
        private void parametrosInicio()
        {            
            ctrl.PreferencesGrid(this, gridView, "R");
        }

        #region METODOS MANUALES

        //VALIDACIONES PREVIAS AL PROCESAMIENTO
        private bool validacionesPrev(string ruta)
        {
            try
            {
                //VALIDO QUE EL ARCHIVO EXISTA
                if (!File.Exists(ruta + @"\Manual.dat") ||
                    !File.Exists(ruta + @"\Manextra.txt") ||
                    !File.Exists(ruta + @"\Monodro.txt"))
                {                    
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {              
                return false;
            }
        }

        //LOADING, PUEDE RECIBIR 2 PARAMETROS (MOSTRAR/OCULTAR)
        private void splash(string l)
        {
            if (l.Equals("Mostrar") && !splashScreen.IsSplashFormVisible)
            {
                splashScreen.ShowWaitForm();
            }

            if (l.Equals("Ocultar") && splashScreen.IsSplashFormVisible)
            {
                splashScreen.CloseWaitForm();
            }
        }

        private void ShowGridPreview(GridControl grid)
        {
            // Check whether the GridControl can be previewed.
            if (!grid.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grid.ShowPrintPreview();
        }
                
        #region METODOS BUSQUEDA REGISTROS 
        private void IBusqRegistros() {

            splash("Mostrar");

            gridView.BeginDataUpdate();
            if (bgwRegistros.IsBusy){
                return;
            }

            //Ejecuta el metodo DoWork 
            bgwRegistros.RunWorkerAsync(); 
        }

        private void EjecutarBusqueda()
        {
            Medicamentos.Clear();
            Medicamentos.AddRange(Medicamento.GetRegistros());
        }

        private void FBusquedaRegistros()
        {
            //BindingList permite la edición de los registros
            gridControl.DataSource = new BindingList<MC.Medicamento>(Medicamentos);
            gridView.EndDataUpdate();

            splash("Ocultar");
        }
        #endregion

        #region METODOS IMPORTACION ARCHIVOS
        private void IImportMed()
        {

            if (!glb.GetPermisos().Where(w => w.Clave == "MedImport" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
            {
                ctrl.MensajeInfo("No tiene acceso a la importación de medicamentos AlfaBeta.", 1);
                return;
            }

            splash("Mostrar");

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                //SLECCIONO LA RUTA DEL ARCHIVO CON EL METODO .SelectedPath
                path = folderBrowser.SelectedPath;
                if (validacionesPrev(path)){
                    gridView.BeginDataUpdate();
                    if (bgwImportacion.IsBusy)
                    {
                        return;
                    }
                    //Ejecuta el metodo DoWork 
                    bgwImportacion.RunWorkerAsync();
                } else
                {
                    //Uso el manejador de errores de la clase Controles
                    ctrl.MensajeInfo("Faltan archivos. Asegurese de estar importando los siguientes archivos con sus correspondientes nombres(Manual.dat, Manextra.txt, Monodro.txt)", 1);
                }                                               
            }

            
        }

        private void EjecutarImportMed()
        {
            MedicamentosProc.cargaDatos(path);
        }

        private void FImportMed()
        {
            gridView.EndDataUpdate();
            IBusqRegistros();

            splash("Ocultar");
        }
        
        #endregion
        
        #endregion

        //Acciones Backgound Registros
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarBusqueda();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FBusquedaRegistros();
        }
        
        //Acciones Backgound de Importación
        #region ACCIONES BACKGROUND

        private void bgwImportacion_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarImportMed();
            MedicamentosProc.enviarDatosBD(Medicamentos);
        }

        private void bgwImportacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FImportMed();
        }

        #endregion


        private void Frm_Medicamentos_Load(object sender, EventArgs e)
        {
            parametrosInicio();
        }

        private void Frm_Medicamentos_Shown(object sender, EventArgs e)
        {
            IBusqRegistros();
        }

        private void btnImportar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            IImportMed();
        }

        private void ActualizarRegistro()
        {
            try
            {
                //Fila actual
                MC.Medicamento medicamento = gridView.GetRow(gridView.FocusedRowHandle) as MC.Medicamento;

                if (medicamento == null) { return; }

                gridView.BeginDataUpdate();

                bool t = Medicamentos.Exists(w => w.Homonimo == medicamento.Homonimo
                && w.NroRegistro != medicamento.NroRegistro);   //IDENTIFICA SI YA HOMONIMO EXISTE EN LA BD     

                medicamento.Abm(t);
                IBusqRegistros();
                gridView.EndDataUpdate();


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            ActualizarRegistro();
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView v = gridView;
            GridColumn c = new GridColumn();

            MC.Medicamento medicamento = v.GetRow(v.FocusedRowHandle) as MC.Medicamento;

            if (medicamento != null)
            {
                string errorstring = "";
                
                bool existeHomonimo = Medicamentos.Where(w => w.Homonimo == medicamento.Homonimo 
                && w.Homonimo!=0 && w.IDRegistro != medicamento.IDRegistro).Count() > 0;
                                
                if (existeHomonimo)
                {            
                    if (ctrl.MensajePregunta($"Ya existe el Código Homonimo con el valor {medicamento.Homonimo}.\n" +
                    $"¿Desea reemplazar al anterior?") == DialogResult.Yes)
                    {                      
                        e.Valid = true;
                    }
                    else
                    {
                        e.Valid = false;
                    }
                }

                if (medicamento.Precio == 0)
                {
                    e.Valid = false; c = colPrecio; errorstring = "El precio del medicamento es $0";
                }

                if (!e.Valid) { v.SetColumnError(c, errorstring); }
            }
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void Frm_Medicamentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.PreferencesGrid(this, gridView, "S");
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            ShowGridPreview(gridControl);
        }

        private void gridView_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {
            try
            {
                if (!glb.GetPermisos().Where(w => w.Clave == "MedEdit" && w.UsuarioID == glb.GetIdUsuariolog()).Select(s => s.Acceso).First())
                {
                    ctrl.MensajeInfo("No tiene acceso a la edición de medicamentos.", 1);
                    e.Allow = false;
                }
                
            }
            catch (Exception)
            {
                e.Allow = false;
            }
        }
    }
}