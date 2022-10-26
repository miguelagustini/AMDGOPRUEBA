using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Facturas.Conceptos.Vista
{
    public partial class Frm_Concepto : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private MC.ConceptosComprobantes Conceptocls = new MC.ConceptosComprobantes();
                        
        public Frm_Concepto()
        {
            InitializeComponent();

            Load += new EventHandler(Formulario_Load);
            Shown += new EventHandler(Formulario_Shown);
            FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {   
            FormBorderStyle = ctrls.EstiloBordesform(true);


            txtCbu.DataBindings.Add("EditValue", Conceptocls, nameof(Conceptocls.Concepto));
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {
            txtCbu.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

            if (Conceptocls.ExisteRegistroDescripcion())
            {
                ctrls.MensajeInfo("Éste concepto ya está registrado.", 1);
                return;
            }


            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Conceptocls.Abm();

            if (retorno.Count > 0)
            {
                string mensajes = "";

                foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                {
                    mensajes += $"{i.Trim()}\n";
                }

                if (!string.IsNullOrWhiteSpace(mensajes)) { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }

                DialogResult = DialogResult.Abort;
            }
            else { DialogResult = DialogResult.OK; }
        }
    }
}