using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Frm_Negociacion : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrl = new Controles();


        public MC.Negociacion Negociacion { get; set; } = new MC.Negociacion();
        public List<MC.Detalles> DetallesGlobal { get; set; } = new List<MC.Detalles>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        private MC.Detalles Detallecls = new MC.Detalles();
        private Usr_Encabezado UsrEncabezado = new Usr_Encabezado();
        private Usr_Detalles UsrDetalle = new Usr_Detalles();
        private Usr_Observaciones UsrObservaciones = new Usr_Observaciones();
        private Usr_Extras UsrExtras = new Usr_Extras();
        private Usr_Anexos UsrAnexos = new Usr_Anexos();

        public Frm_Negociacion()
        {
            InitializeComponent();            
        }

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            UsrEncabezado.SqlConnection = SqlConnection;
            UsrDetalle.SqlConnection = SqlConnection;
            Negociacion.SqlConnection = SqlConnection;

            SetControles();
            SetBindigs();
        }

        #region METODOS MANUALES

        private void SetControles()
        {
            try
            {
                PanelHeader.Controls.Add(UsrEncabezado);
                UsrEncabezado.Dock = DockStyle.Fill;

                PanelDetalles.Controls.Add(UsrDetalle);
                UsrDetalle.Dock = DockStyle.Fill;

                PanelObservaciones.Controls.Add(UsrObservaciones);
                UsrObservaciones.Dock = DockStyle.Fill;

                PanelExtras.Controls.Add(UsrExtras);
                UsrExtras.Dock = DockStyle.Fill;

                PanelAnexos.Controls.Add(UsrAnexos);
                UsrAnexos.Dock = DockStyle.Fill;
                                
            }
            catch (Exception)
            {

            }
        }

        private void SetBindigs()
        {
            try
            {
                //ENCABEZADO
                UsrEncabezado.Negociacion = Negociacion;
                //DETALLES
               // Detallecls.DefineValorPactado(DetallesGlobal, Negociacion.Detalles);
               // Detallecls.DefineValorAnterior(DetallesGlobal, Negociacion.Detalles);
               // Detallecls.DefineValorNomenclado(Negociacion.Detalles);

                UsrDetalle.Negociacion = Negociacion;
                UsrObservaciones.Negociacion = Negociacion;
                UsrExtras.Negociacion = Negociacion;
                UsrAnexos.Negociacion = Negociacion;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }
        
        #endregion

        private void Frm_Negociacion_Load(object sender, EventArgs e)
        {
            
        }

        private void Frm_Negociacion_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void PanelDetalles_Click(object sender, EventArgs e)
        {

        }
    }
}