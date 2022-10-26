using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Prestatarias
{
    public partial class Frm_PrAgrupador : XtraForm
    {
        private Notificacionesbd notificacionesBD = new Notificacionesbd();
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();
        private PrestatariasControlador prestatariasctrl = new PrestatariasControlador();
        private List<Registros> registroslista = new List<Registros>();

        public bool Es_Popup { get; set; } = false;
        public int IDRegistro { get; set; } = 0;

        public Frm_PrAgrupador()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            
        }

        #region METODOS MANUALES

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);

            //pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);
                         
            notificacionesBD.ID_Consulta = 5;
            notificacionesBD.ListenerChange();

            tmrEscucha.Start();
        }
                
        //CARGA DE DATOS
        public void CargarRegistro()
        {
            try
            {                
                tmrEscucha.Stop();
                gridView.BeginDataUpdate();

                registroslista.Clear();


                string consulta = "SELECT PG.ID_Registro, PG.Codigo, PG.Descripcion, PT.Descripcion as Tipo" +
                    " FROM PRESTGRPVAL PG" +
                    " LEFT OUTER JOIN PRESTATIPOS PT ON(PT.ID_Registro = PG.ID_PrestaTipo)";
                    

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    registroslista.Add(new Registros {
                        ID_Registro = Convert.ToInt32(f["ID_Registro"]),                        
                        Codigo = f["Codigo"].ToString(),
                        Descripcion = f["Descripcion"].ToString(),
                        PrestaTipo = f["Tipo"].ToString()
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
            Frm_PrAgrpPopup frm = new Frm_PrAgrpPopup();
            frm.Es_Popup = true;            

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
        private void Frm_PrAgrupador_Shown(object sender, EventArgs e)
        {
            CargarRegistro();
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

}