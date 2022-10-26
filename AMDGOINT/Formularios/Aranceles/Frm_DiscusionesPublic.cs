using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using AMDGOINT.Formularios.Informes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Text;
using System.IO;
using System.Globalization;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_DiscusionesPublic : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();        
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Discusionescls discusiones = new Discusionescls();

        private int IDRegistro { get; set; } = 0;
        private int indexrow = -1;        
        private Point LocationSplash = new Point();

        public Frm_DiscusionesPublic()
        {
           
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            ctrls.setSplitter(splitter);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250,
                                      workingArea.Top + 73);
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {            
            ctrls.PreferencesGrid(this, bgridview, accion: "R");
            
            notificacionesBD.ID_Consulta = 7;
            notificacionesBD.ListenerChange();
                        
            reposdFecha.NullDate = DateTime.MinValue;
            reposdFecha.NullText = string.Empty;

            if (globales.GetIdUsuariolog() != 1) { }
        }
                
        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            screenManager.SplashFormStartPosition = SplashFormStartPosition.Manual;
            screenManager.SplashFormLocation = LocationSplash;
            if (!screenManager.IsSplashFormVisible) { screenManager.ShowWaitForm(); }
            

            tmrescucha.Stop();
            bgridview.BeginDataUpdate();
            
            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {            
            bgridview.EndDataUpdate();
            DateTime dat = new DateTime(2021, 09, 1);
            gridControl.DataSource = discusiones.encabezadoslst.Where(w => w.Estado == 2 && w.FechaImpacto >= dat);

            if (screenManager.IsSplashFormVisible) { screenManager.CloseWaitForm(); }               

            if (bgridview.RowCount >= indexrow) { bgridview.FocusedRowHandle = indexrow; }

            tmrescucha.Start();
        }               
        
        //EXPORTACION
        private void GeneraReporte()
        {
            try
            {
                if (IDRegistro <= 0) { return; }
                                
                //INICIO PARAMETROS
                Usr_Exportacion parametros = new Usr_Exportacion();
                if (XtraDialog.Show(parametros, "Parámetros de exportación", MessageBoxButtons.OKCancel) != DialogResult.OK) { return; }
                
                Xrpt_Aranceles report = new Xrpt_Aranceles();
                List<DiscusionEncabezado> li = new List<DiscusionEncabezado>();
                DiscusionEncabezado enc = new DiscusionEncabezado();
                enc = discusiones.encabezadoslst.Where(w => w.IDRegistro == IDRegistro).DefaultIfEmpty(new DiscusionEncabezado()).First().Clone();
                li.Add(enc);

                //ACTUALIZO LA OBSERVACION DE LOS GRUPOS SEGUN LO CARGADO EN DETALLES OBS
                foreach (DiscusionDetalle d in enc.Detalles.Where(w => w.Aplicado == 2))
                {
                    d.GrupoObservacion = enc.GruposObs.Where(w => w.IDGrupoPractica == d.IDGrupo).Select(s => s.Observacion).
                        DefaultIfEmpty(string.Empty).First();
                }

                //OBTENGO LISTA GENERAL
                li = li.Select(s => new DiscusionEncabezado
                {                        
                    PrestatariaConjunto = s.PrestatariaConjunto,
                    CuitPrestataria = s.CuitPrestataria,
                    CodigoGupo = s.CodigoGupo,
                    DescripcionGrupo = s.DescripcionGrupo,
                    CodigosConjuntos = s.CodigosConjuntos,
                    FechaImpacto = s.FechaImpacto,
                    Extras = s.Extras,
                    Otros = s.Otros,
                    Detalles = s.Detalles.Where(w => w.Aplicado >= 1).ToList()
                        
                }).ToList();


                report.DataSource = li;
                                               
                report.RequestParameters = false;
                foreach (var p in report.Parameters) { p.Visible = false; }
                report.Parameters["Hidecoseguro"].Value = parametros.VerCoseguro;
                report.Parameters["Hidecopago"].Value = parametros.VerCopago;

                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreview();
                parametros.Dispose();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al generar el reporte.\n {e.Message}", 0);
                return;
            }
        }

        #endregion

        //****************************************************************
        //******************* EVENTOS FORMULARIO *************************
        //****************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            splitter.SplitterPosition = (splitter.Height / 2);
            Ibusqregistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwRegistros.IsBusy) { e.Cancel = true; }

            ctrls.PreferencesGrid(this, bgridview, accion: "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            discusiones.ListarRegistros();
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }


        private void bgridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {            
            IDRegistro = 0;

            if (bgridview.RowCount <= 0) { return; }

            var idreg = bgridview.GetFocusedRowCellValue(colID_Registro);

            if (idreg != null)
            {
                IDRegistro = Convert.ToInt32(idreg);
                
            }
        }
        private void bgridView_ShownEditor(object sender, EventArgs e)
        {
            if (bgridview.ActiveEditor is MemoEdit)
            {

                (bgridview.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (bgridview.ActiveEditor as MemoEdit).Paint += Form1_Paint;
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

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;                
            }
        }
                    
        private void bgridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
                       
            if ((e.Column == colEstado) && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                e.DisplayText = "";                
            }

        }

        private void btnVer_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            GeneraReporte();
        }
    }
}