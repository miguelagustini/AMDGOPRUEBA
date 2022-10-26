using System;
using System.ComponentModel;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using AMDGOINT.Formularios.Auditoria.Anestesiologia.MC;
using System.Linq;
using AMDGOINT.Formularios.Auditoria.Anestesiologia.Reportes;
using DevExpress.XtraReports.UI;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista
{
    public partial class Frm_AnestesiaAuditMain : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Globales globales = new Globales();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();        
        private ConexionBD cnbd = new ConexionBD();
        private SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private List<Anestesiaenc> facturasanelst { get; set; } = new List<Anestesiaenc>();
        private Anestesiaenc anestesiacls = new Anestesiaenc();
        private Frm_AnestesiaAuditDet frmdetalle = new Frm_AnestesiaAuditDet();


        private bool CambiaRow { get; set; } = false;
        private int IDRegistro { get; set; } = 0;

        private int indexrow = -1;
        private Point LocationSplash = new Point();

        public Frm_AnestesiaAuditMain()
        {          
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LocationSplash = new Point(workingArea.Right - 250, workingArea.Top + 73);
            ctrls.setSplitter(splitter);

            SqlConnection = cnbd.Conectar();
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {            
            ctrls.PreferencesGrid(this, bgridView, accion: "R");

            notificacionesBD.ID_Consulta = 9;
            notificacionesBD.SqlConnection = SqlConnection;
            notificacionesBD.ListenerChange();

            ctrls.AgregaFormulario(frmdetalle, Tabdetalles);
            frmdetalle.Editable = false;
            
            //ICONOS            
            Tabdetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BOContact2_16x16;

            splashScreen.SplashFormStartPosition = SplashFormStartPosition.Manual;
            splashScreen.SplashFormLocation = LocationSplash;

            tmrEscucha.Start();

            //CREO CONEXION
            SqlConnection = cnbd.Conectar();
            //LA PASO A LA VARIABLE LOCAL
            anestesiacls.SqlConnection = SqlConnection;
        }

        //INICIO BUSQUEDA REGISTROS
        private void Ibusqregistros()
        {
            tmrEscucha.Stop();
            bgridView.BeginDataUpdate();
            facturasanelst.Clear();

            if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }
            

            if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
            while (bgwRegistros.CancellationPending)
            { if (!bgwRegistros.CancellationPending) { break; } }

            bgwRegistros.RunWorkerAsync();
        }

        //FIN BUSQUEDA REGISTROS
        private void Fbusqregistros()
        {
            bgridView.EndDataUpdate();
            gridControl.DataSource = facturasanelst;            
            
            if (bgridView.RowCount >= indexrow) { bgridView.FocusedRowHandle = indexrow; }            

            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            tmrEscucha.Start();
        }

        //MUESTRO EL FORMULARIO DE PRESTATARIAS
        private void MuestroFormulario(string acc)
        {
            try
            {
                Frm_AnestesiaAudit formulario = new Frm_AnestesiaAudit();                

                formulario.Anestesia = acc == "N" ? new Anestesiaenc() :
                                                      facturasanelst.Where(w => w.IDRegistro == IDRegistro).
                                                      DefaultIfEmpty(new Anestesiaenc()).FirstOrDefault().Clone();
                
                ctrls.AgregaFormulario(formulario, globales.GetMaintab(), true);

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al iniciar.\n {e.Message}", 0);
                return;
            }
        }

        //RETORNO LISTA REPORTE
        private List<Anestesiaenc> Getdatosresumen()
        {
            try
            {
                List<Anestesiaenc> retorno = new List<Anestesiaenc>();

                List<Anestesiaenc> listafiltrada = new List<Anestesiaenc>();

                for (int i = 0; i < bgridView.RowCount; i++)
                {
                    Anestesiaenc cust = bgridView.GetRow(i) as Anestesiaenc;
                    listafiltrada.Add(cust);
                }
                                
                foreach (Anestesiaenc a in listafiltrada)
                {
                    List<Anestesiagrp> ag = new List<Anestesiagrp>();

                    foreach (Anestesiagrp g in a.Grupos)
                    {
                        Anestesiadet deta = new Anestesiadet();
                        List<Anestesiadet> ad = new List<Anestesiadet>();
                        ad.AddRange(deta.Clone(g.Detalles.Where(w => w.Importe != w.ValorPorcNivelAm).ToList()));

                        if (ad.Count > 0)
                        {
                            Anestesiagrp grupo = new Anestesiagrp();
                            grupo = g.Clone();
                            grupo.Detalles.Clear();
                            grupo.Detalles = new BindingList<Anestesiadet>(ad);
                            ag.Add(grupo);
                        }
                    }

                    if (ag.Count() > 0)
                    {
                        Anestesiaenc enc = new Anestesiaenc();                        
                        enc = a.Clone();
                        enc.Grupos.Clear();
                        enc.Grupos = new BindingList<Anestesiagrp>(ag);
                        retorno.Add(enc);
                    }
                }

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al procesar la información.\n{e.Message}", 0);
                return new List<Anestesiaenc>();
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

            ctrls.PreferencesGrid(this, bgridView, "S");
        }


        //******************* EVENTOS botones *************************       
        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {            
            facturasanelst = anestesiacls.Clone(anestesiacls.GetRegistros());
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            Fbusqregistros();
        }
       
        private void bgridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {   
            IDRegistro = bgridView.GetFocusedRowCellValue(colIDRegistro) != null ? 
                         Convert.ToInt32(bgridView.GetFocusedRowCellValue(colIDRegistro)) : 0 ;
            Anestesiagrp g = new Anestesiagrp();
            frmdetalle.anestesiadetalles = new BindingList<Anestesiagrp>(g.Clone(facturasanelst.Where(w => w.IDRegistro == IDRegistro).SelectMany(s => s.Grupos).ToList()));
            frmdetalle.IDEncabezado = IDRegistro;
        }

        private void tmrescucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                Ibusqregistros();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }
     
        private void btnNuevobar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("N");
        }

        private void btnEditarbar_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            MuestroFormulario("E");
        }

        private void btnDiferencias_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Xrpt_Anestesiologia r = new Xrpt_Anestesiologia();
            r.DataSource = Getdatosresumen();
            ReportPrintTool printTool = new ReportPrintTool(r);
            printTool.ShowPreviewDialog();
        }
    }
}