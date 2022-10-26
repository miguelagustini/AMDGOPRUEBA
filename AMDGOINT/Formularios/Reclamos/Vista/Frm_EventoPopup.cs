using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Reclamos.Vista
{
    public partial class Frm_EventoPopup : XtraForm
    {
        private Globales glb = new Globales();
        private Controles ctrl = new Controles();
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();

        public MC.ReclamosEventos Evento { get; set; } = new MC.ReclamosEventos();        
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private Eventos.MC.Evento Eventocls = new Eventos.MC.Evento();

        public Frm_EventoPopup()
        {
            InitializeComponent();

            datFecha.Properties.NullDate = DateTime.MinValue;
            datFecha.Properties.NullText = string.Empty;
        }

        private void ParametrosInicio()
        {
            try
            {                
                SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
                Evento.SqlConnection = SqlConnection;
                Eventocls.SqlConnection = SqlConnection;

                CargaCombos();
                SetBindings();

                
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
                datFecha.DataBindings.Add("EditValue", Evento, nameof(Evento.Fecha));
                cmbEvento.DataBindings.Add("EditValue", Evento, nameof(Evento.IDEvento));
                txtObservacion.DataBindings.Add("EditValue", Evento, nameof(Evento.Observacion));
                trcResponsable.DataBindings.Add("EditValue", Evento, nameof(Evento.Responsable));
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al establecer el bind de los componentes.\n{e.Message}", 1);
                return;
            }
        }

        private void CargaCombos()
        {
            try
            {                
                cmbEvento.Properties.DataSource = null;
                cmbEvento.Properties.DataSource = Eventocls.GetRegistros()?.Where(w => w.Origen == 0).ToList();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void AltaEvento()
        {
            try
            {

                Formularios.Eventos.Vista.Frm_Evento frm = new Formularios.Eventos.Vista.Frm_Evento();
                frm.SqlConnection = SqlConnection;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CargaCombos();
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el alta del evento.\n{e.Message}", 1);
                return;
            }
        }

        //GENERA EVENTO
        private void GuardoEvento()
        {
            try
            {
                if (Evento.IDEncabezado <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un evento sin un identificador de reclamo.", 1);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                if (Evento.IDEvento <= 0)
                {
                    ctrl.MensajeInfo("No se puede generar un evento sin un identificador de evento.", 1);
                    cmbEvento.Focus();
                    return;
                }

                if (Evento.Fecha == DateTime.MinValue)
                {
                    ctrl.MensajeInfo("No se puede generar un evento sin fecha.", 1);
                    datFecha.Focus();
                    return;
                }


                Dictionary<short, string> retorno = new Dictionary<short, string>();

                retorno = Evento.Abm();

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrl.MensajeInfo($"Hubo inconvenientes en la generación del evento.\n{mensajes}", 1); }
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

        private void cmbEvento_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph){ AltaEvento(); }
        }
    }
}
