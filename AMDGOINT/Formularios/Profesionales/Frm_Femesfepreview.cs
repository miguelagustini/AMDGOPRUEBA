using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraSplashScreen;
using System.Drawing;

namespace AMDGOINT.Formularios.Profesionales
{
    public partial class Frm_Femesfepreview : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        private ProfControlador profcontrol = new ProfControlador();
        private List<ProfesionalesFemefse> profesionaleslst = new List<ProfesionalesFemefse>();


        public bool Es_Popup { get; set; } = false;
            
        public Frm_Femesfepreview()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES
                     
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            ScrManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            ScrManager.SplashFormLocation = new Point(this.Width - 198, 61);

        }

        private void Ibusqregistros()
        {
            ScrManager.ShowWaitForm();
            gridControl.DataSource = "";

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        private void CargaRegistros()
        {
            try
            {
                profesionaleslst = profcontrol.GetListaFemesfe();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrio un error al consultar los registros.\n" + e.Message, 0);
                return;
            }
        }

        private void Fbusqregistros()
        {
            gridControl.DataSource = profesionaleslst;
            ScrManager.CloseWaitForm();
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

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void bgwRegistros_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CargaRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Fbusqregistros();
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Ibusqregistros();
        }

        private void btnExportarxls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrls.ExportaraExcelgrd(gridControl);
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(e.Point);
        }
    }
}