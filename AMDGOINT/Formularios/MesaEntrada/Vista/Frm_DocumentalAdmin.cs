using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Linq;

namespace AMDGOINT.Formularios.MesaEntrada.Vista
{
    public partial class Frm_DocumentalAdmin : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrl = new Controles();
        private Point LocationSplash = new Point();

        private MC.Auditor Auditor { get; set; } = new MC.Auditor();
        private MC.Documental Documental { get; set; } = new MC.Documental();
        private MC.Gestion Gestiondocum { get; set; } = new MC.Gestion();
        private List<MC.Documental> Ordenes { get; set; } = new List<MC.Documental>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Usr_Auditoria UsrAuditores = new Usr_Auditoria();
        private Usr_GestionDocumentos UsrGestiondocumentos = new Usr_GestionDocumentos();

        public Frm_DocumentalAdmin()
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);

            //DETERMINO LA POSICION DEL SPLASH
            screenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;

            reposDatetime.NullDate = DateTime.MinValue;
            reposDatetime.NullText = string.Empty;
         
        }

        private void ParametrosInicio()
        {
            ctrl.PreferencesGrid(this, dockManager, "R");
            ctrl.PreferencesGrid(this, gridView, "R");

            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Documental.SqlConnection = SqlConnection;
            Auditor.SqlConnection = SqlConnection;
            Gestiondocum.SqlConnection = SqlConnection;

            //AUDITORES
            PnlAuditores.Controls.Add(UsrAuditores);
            UsrAuditores.Dock = DockStyle.Fill;

            //GESTION DE DOCUMENTAL
            PnlDevoluciones.Controls.Add(UsrGestiondocumentos);
            UsrGestiondocumentos.SqlConnection = SqlConnection;
            UsrGestiondocumentos.Dock = DockStyle.Fill;
        }

        #region METODOS MANUALES
       
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {

            if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
            screenManager.SetWaitFormCaption("Por favor, espere");
            screenManager.SetWaitFormDescription("Obteniendo registros...");

            //tmrescucha.Stop();

            gridView.BeginInit();
            gridView.BeginDataUpdate();

            if (!bgwBusqueda.IsBusy) { bgwBusqueda.RunWorkerAsync(); }
        }

        //ASIGNA REGISTROS
        private void EjecutaBusqueda()
        {
            try
            {
                Ordenes.Clear();
                Ordenes.AddRange(Documental.GetDocumental());                
            }
            catch (Exception)
            {

            }
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            gridControl.DataSource = Ordenes;
            gridView.EndDataUpdate();
            gridView.EndInit();

            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }            

            //tmrescucha.Start();
        }

        #endregion

        private void Frm_Negociacion_Load(object sender, EventArgs e)
        {
            
        }

        private void Frm_DocumentalAdmin_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
            Ibusqregistros();
        }

        private void Frm_DocumentalAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.PreferencesGrid(this, gridView, "S");
            ctrl.PreferencesGrid(this, dockManager, "S");
        }

        private void bgwBusqueda_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            EjecutaBusqueda();
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Fbusqregistros();
        }

        private void gridView_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            try
            {
                GridGroupRowInfo info = e.Info as GridGroupRowInfo;
                GridView view = sender as GridView;
                var rowValue = view.GetGroupRowValue(info.RowHandle, info.Column);
                info.GroupText = rowValue.ToString();
            }
            catch (Exception)
            {
            }
        }
                
        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            try
            {                
                MC.Documental _documental = gridView.GetRow(gridView.FocusedRowHandle) as MC.Documental;

                if (_documental != null && !gridView.IsGroupRow(gridView.FocusedRowHandle))
                {
                    UsrAuditores.Auditores = _documental.Auditores;
                    UsrGestiondocumentos.GestionDocumental = _documental;
                }
                else
                {
                    UsrAuditores.Auditores = new List<MC.Auditor>();
                    UsrGestiondocumentos.GestionDocumental = new MC.Documental();
                }
            }
            catch (Exception)
            {

            }
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