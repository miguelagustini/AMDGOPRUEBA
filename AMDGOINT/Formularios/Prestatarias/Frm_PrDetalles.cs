using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Prestatarias
{
    public partial class Frm_PrDetalles : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();
        private PrestatariasControlador prestatariasctrl = new PrestatariasControlador();
        private List<Registros> registroslista = new List<Registros>();

        public bool Es_Popup { get; set; } = false;
        public int IDRegistro { get; set; } = 0;
        public int IDPrestataria { get; set; } = 0;

        public Frm_PrDetalles()
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
            if (IDRegistro > 0) { CargarRegistro();}

            notificacionesBD.ID_Consulta = 3;
            notificacionesBD.ListenerChange();

            ControlAcceso();
        }

        //Control de acceso usuario
        private void ControlAcceso()
        {
            try
            {
                btnAgregadetalle.Enabled = func.DevuelvePermiso("ProfEdit");
                btnEditardetalle.Enabled = func.DevuelvePermiso("ProfEdit");

            }
            catch (Exception)
            {
                btnAgregadetalle.Enabled = false;
                btnEditardetalle.Enabled = false;
                return;
            }
        }


        //CARGA DE DATOS
        public void CargarRegistro()
        {
            try
            {
                if (IDPrestataria <= 0) { return; }
                tmrEscucha.Stop();
                gridView.BeginDataUpdate();

                registroslista.Clear();


                string consulta = "SELECT PD.ID_Registro, PD.ID_Prestataria, PD.Codigo, PD.Descripcion, PD.PorcIva, PA.Codigo as Agrupador" +
                    " FROM PRESTDetalles PD" +
                    " LEFT OUTER JOIN PRESTGRPVAL PA ON(PA.ID_Registro = PD.ID_Agrupador)" +
                    " WHERE PD.ID_Prestataria = " + IDPrestataria;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    registroslista.Add(new Registros {
                        ID_Registro = Convert.ToInt32(f["ID_Registro"]),
                        ID_Prestataria = Convert.ToInt32(f["ID_Prestataria"]),
                        Codigo = f["Codigo"].ToString(),
                        Descripcion = f["Descripcion"].ToString(),
                        PorcIva = Convert.ToDecimal(f["PorcIva"]),
                        Agrupador = f["Agrupador"].ToString()                        
                    });
                }

                gridView.EndDataUpdate();
                gridControl.DataSource = registroslista;
                tmrEscucha.Start();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar el registro.\n" + e.Message, 0);
                return;

            }
        }

        //CARGA DETALLES
        private void MostrarForm(string acc)
        {
            Frm_PrDetPopup frm = new Frm_PrDetPopup();
            frm.Es_Popup = true;
            frm.IDPrestataria = IDPrestataria;


            if (acc == "N") { frm.IDRegistro = 0; }
            else { frm.IDRegistro = IDRegistro; }

            frm.ShowDialog(this);
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
            
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void tmrEscucha_Tick(object sender, EventArgs e)
        {
            if (notificacionesBD.Accionejecutada != SqlNotificationInfo.Truncate)
            {
                CargarRegistro();

                notificacionesBD.Accionejecutada = SqlNotificationInfo.Truncate;
            }
        }

        private void btnAgregadetalle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarForm("N");
        }

        private void btnEditardetalle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarForm("E");
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        private void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (popupMenu.Visible) { popupMenu.HidePopup(); }

            IDRegistro = 0;

            var idr = gridView.GetFocusedRowCellValue(colIDRegistro);

            if (idr != null)
            {
                IDRegistro = Convert.ToInt32(idr);
            }
        }

        private void popupMenu_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gridView.RowCount <= 0)
            {
                btnEditardetalle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnEditardetalle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
    }

    class Registros
    {
        public int ID_Registro { get; set; } = 0;
        public int ID_Prestataria { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Agrupador { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal PorcIva { get; set; } = 0;
        public string PrestaTipo { get; set; } = "";
    }
}