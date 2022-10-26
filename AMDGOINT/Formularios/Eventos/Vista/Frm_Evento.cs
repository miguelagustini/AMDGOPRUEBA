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

namespace AMDGOINT.Formularios.Eventos.Vista
{
    public partial class Frm_Evento : XtraForm
    {
        private Globales glb = new Globales();
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private OverlayPanel OverlayPanel = new OverlayPanel();

        public byte Origen { get; set; } = 0;
        private MC.Evento Evento { get; set; } = new MC.Evento();        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_Evento()
        {
            InitializeComponent();            
        }
                

        private void ParametrosInicio()
        {
            try
            {                
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Evento.SqlConnection = SqlConnection;

                SetBindings();

                txtdescripcion.Focus();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al iniciar.\n{e.Message}", 1);
                return;
            }
        }

        private void SetBindings()
        {
            try
            {
                txtdescripcion.DataBindings.Add("EditValue", Evento, nameof(Evento.Descripcion));                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }
        
        //GENERA COMPROBANTE
        private void GuardoEvento()
        {
            try
            {

                if (Evento.ExisteRegistroDescripcion())
                {
                    ctrl.MensajeInfo($"{glb.GetNomUsuariolog()}, ¡éste evento ya está registrado!", 1);
                    return;
                }

                Dictionary<short, string> retorno = new Dictionary<short, string>();
                Evento.Origen = Origen;
                retorno = Evento.Abm();

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrl.MensajeInfo($"Hubo inconvenientes en la generación.\n{mensajes}", 1); }
                }
                else { DialogResult = System.Windows.Forms.DialogResult.OK; }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al guardar.\n{e.Message}", 1);                
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardoEvento();            
        }

        private void Frm_DebitosSelector_Shown(object sender, EventArgs e)
        {
            ParametrosInicio();
        }
        
        private void Frm_Evento_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            cnb.Desconectar();            
        }

        private void Frm_Evento_Load(object sender, EventArgs e)
        {
            
        }
    }
}
