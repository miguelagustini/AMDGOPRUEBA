using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Usr_Parametros : XtraUserControl
    {
        private Controles ctrl = new Controles();

        public bool Generacion { get; set; } = false;
        public bool Modificacion { get; set; } = false;
        public bool Importacion { get; set; } = false;
        public bool Exportacion { get; set; } = false;
        public bool Valorizacion { get; set; } = false;
        public bool Normalizacion { get; set; } = false;
        public bool Copiar { get; set; } = false;
        public byte CopiaNewTipo { get; set; } = 0;
        
        public List<string> Grupossel { get; private set; }
        public string FechaOperacion { get; set; } = "";
        public byte Tipovalor { get; set; } = 0;
        public decimal Porcentaje = 0;

        public Usr_Parametros(List<DateTime> FechasIn, List<string> GruposLst)
        {
            InitializeComponent();

            ListaFechas(FechasIn);
            ListaGrupos(GruposLst);
        }

        private void ListaFechas(List<DateTime> FechasIn)
        {
            try
            {
                cmbFechas.Properties.Items.Add("Nueva Fecha");

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

        private void ListaGrupos(List<string> GruposLst)
        {
            try
            {
                foreach (string g in GruposLst.OrderBy(o => o.Substring(0)))
                {
                    cmbGrupos.Properties.Items.Add(g);
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al cargar la lista de grupos.\n {e.Message}", 0);
                return;
            }

        }

        private void DisponibilidadCtrls()
        {
            if (cmbFechas.Text == "" || cmbFechas.Text == "Nueva Fecha")
            {
                if (Generacion)
                {
                    cmbGrupos.EditValue = null;
                    cmbGrupos.Enabled = false;
                    txtPorcentaje.Enabled = true;
                    txtPorcentaje.Text = "0,00";
                }
                else if (Exportacion || Normalizacion || Importacion || Modificacion || Valorizacion || Copiar)
                {
                    cmbGrupos.EditValue = null;
                    cmbGrupos.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    txtPorcentaje.Text = "0,00";
                }

            }
            else
            {
                if (Generacion || Copiar)
                {
                    cmbGrupos.EditValue = null;
                    cmbGrupos.Enabled = false;
                    txtPorcentaje.Enabled = true;
                    txtPorcentaje.Text = "0,00";
                }
                else if (Exportacion || Importacion)
                {
                    cmbGrupos.EditValue = null;
                    cmbGrupos.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    txtPorcentaje.Text = "0,00";
                }
                else if (Normalizacion || Modificacion)
                {
                    cmbGrupos.EditValue = null;
                    cmbGrupos.Enabled = true;
                    txtPorcentaje.Enabled = false;
                    txtPorcentaje.Text = "0,00";
                }
                else if (Valorizacion)
                {
                    cmbGrupos.EditValue = null;
                    cmbGrupos.Enabled = true;
                    txtPorcentaje.Enabled = true;
                    txtPorcentaje.Text = "0,00";
                }
            }
        }        

        private void cmbFechas_TextChanged(object sender, EventArgs e)
        {
            DisponibilidadCtrls();

            FechaOperacion = cmbFechas.Text.Trim();
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("."))
            {
                e.KeyChar = Convert.ToChar(",");
            }
        }

        private void cmbGrupos_TextChanged(object sender, EventArgs e)
        {
            Grupossel = cmbGrupos.Properties.Items.GetCheckedValues().Select(s => s.ToString()).ToList();                        
        }
                
        private void tglTipo_Toggled(object sender, EventArgs e)
        {
            Tipovalor = (byte)tglTipo.EditValue;
        }

        private void radGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generacion = false;
            Importacion = false;
            Modificacion = false;
            Valorizacion = false;
            Exportacion = false;
            Normalizacion = false;
            Copiar = false;

            switch (radGroup.SelectedIndex)
            {
                case 0: Generacion = true; break;
                case 1: Modificacion = true; break;
                case 2: Valorizacion = true; break;
                case 3: Importacion = true; break;
                case 4: Exportacion = true; break;
                case 5: Normalizacion = true; break;
                case 6: Copiar = true; break;
            }

            DisponibilidadCtrls();
        }

        private void txtPorcentaje_Validated(object sender, EventArgs e)
        {
            Porcentaje = 0;
            if (txtPorcentaje.Text != "")
            { Porcentaje = Convert.ToDecimal(txtPorcentaje.Text); }
        }
        
        private void tglNewtipo_Toggled(object sender, EventArgs e)
        {
            CopiaNewTipo = (byte)tglNewtipo.EditValue;
        }
    }
}
