using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Aranceles.Vista
{
    public partial class Usr_Encabezado : XtraUserControl
    {
        private Controles ctrl = new Controles();
        private List<Binding> Binding = new List<Binding>();
        private MC.Arancel _arancel = new MC.Arancel();

        public MC.Arancel Arancel
        {
            get { return _arancel; }
            set
            {
                if (_arancel != value)
                {
                    _arancel = value;
                    SetBindigs();
                }
            }
        }
        
        public Usr_Encabezado()
        {
            InitializeComponent();
            
            datFecha.Properties.NullDate = DateTime.MinValue;
            datFecha.Properties.NullText = string.Empty;

            datFecha.Enabled = !Arancel.Estado;
            

        }

        private void SetBindigs()
        {
            try
            {
                datFecha.DataBindings.Clear();

                txtObservaciones.DataBindings.Clear();
                datFecha.DataBindings.Add("EditValue", Arancel, nameof(Arancel.Fecha));
                BoundAplicacion();
                Binding.Add(txtObservaciones.DataBindings.Add("EditValue", Arancel, nameof(Arancel.Observaciones)));
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}.Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }

        private void BoundAplicacion(string way = "E")
        {
            try
            {                
                foreach (var n in chkAplicacion.Properties.Items.GetCheckedValues())
                {
                    if (way == "E")
                    {
                        if ((short)n == 0) { chkAplicacion.Properties.Items[n].CheckState = Arancel.AplicaPrepaga ? CheckState.Checked : CheckState.Unchecked; }
                        else if ((short)n == 1) { chkAplicacion.Properties.Items[n].CheckState = Arancel.AplicaObrasocial ? CheckState.Checked : CheckState.Unchecked; }
                        else if ((short)n == 2) { chkAplicacion.Properties.Items[n].CheckState = Arancel.AplicaArt ? CheckState.Checked : CheckState.Unchecked; }
                        else if ((short)n == 3) { chkAplicacion.Properties.Items[n].CheckState = Arancel.AplicaCaja ? CheckState.Checked : CheckState.Unchecked; }
                    }
                    else
                    {
                        if ((short)n == 0) { Arancel.AplicaPrepaga = chkAplicacion.Properties.Items[n].CheckState == CheckState.Checked ? true : false; }
                        else if ((short)n == 1) { Arancel.AplicaObrasocial = chkAplicacion.Properties.Items[n].CheckState == CheckState.Checked ? true : false; }
                        else if ((short)n == 2) { Arancel.AplicaArt = chkAplicacion.Properties.Items[n].CheckState == CheckState.Checked ? true : false; }
                        else if ((short)n == 3) { Arancel.AplicaCaja = chkAplicacion.Properties.Items[n].CheckState == CheckState.Checked ? true : false; }
                    }  

                }                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo(e.Message, 1);
            }
        }


        private void chkAplicacion_TextChanged(object sender, EventArgs e)
        {
            //AL CAMBIAR LAS APLICACIONES, REASIGNO A LAS COLUMNAS CORRESPONDIENTES
            BoundAplicacion("S");
        }

        private void txtObservaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
