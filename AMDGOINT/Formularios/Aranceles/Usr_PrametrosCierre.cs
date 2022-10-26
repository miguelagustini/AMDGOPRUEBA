using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Usr_PrametrosCierre : XtraUserControl
    {
        private Controles ctrl = new Controles();
                
        public string FechaDiscusion { get; set; } = "";
        public byte Tipovalor { get; set; } = 0;        

        public Usr_PrametrosCierre(List<DateTime> FechasIn)
        {
            InitializeComponent();

            ListaFechas(FechasIn);
            
        }

        private void ListaFechas(List<DateTime> FechasIn)
        {
            try
            {
                foreach (DateTime f in FechasIn)
                {
                    cmbFechas.Properties.Items.Add(f.ToString("dd/MM/yyyy H:mm:ss"));
                }
              
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al cargar la lista de fechas.\n {e.Message}", 0);
                return;
            }            
            
        }

        private void tglTipo_Toggled(object sender, EventArgs e)
        {
            Tipovalor = (byte)tglTipo.EditValue;
        }

        private void cmbFechas_TextChanged(object sender, EventArgs e)
        {
            FechaDiscusion = cmbFechas.Text != "" ? cmbFechas.Text : "";
        }
    }
}
