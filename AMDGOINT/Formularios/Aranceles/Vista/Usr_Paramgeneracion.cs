using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;

namespace AMDGOINT.Formularios.Aranceles.Vista
{
    public partial class Usr_Paramgeneracion : XtraUserControl
    {
        //false PORCENTAJE / true VALOR FIJO
        private bool tipovalor = false;
        private decimal valor = 0;
        private List<string> grupos = new List<string>();
        private List<string> grupossel = new List<string>();
        public bool Tipovalor
        {
            get { return tipovalor; }
            set
            {
                if (tipovalor != value) { tipovalor = value; }
            }
        }

        public decimal Valor
        {
            get { return valor; }
            set
            {
                if (valor != value) { valor = value; }
            }
        }


        public List<string> Grupos
        {
            get { return grupos; }
            set
            {
                if (grupos != value){ grupos = value; }
            }
        }

        public List<string> Gruposel
        {
            get { return grupossel; }
            private set
            {
                if (grupossel != value) { grupossel = value; }
            }
        }


        public Usr_Paramgeneracion()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            try
            {
                tglTipoValor.DataBindings.Add("EditValue", this, nameof(Tipovalor));
                txtValor.DataBindings.Add("EditValue", this, nameof(Valor));                
                
            }
            catch (Exception)
            {
                return;
            }            
        }

        private void ListaGrupos()
        {
            try
            {

                foreach (var g in Grupos.OrderBy(o => o.Substring(0)))
                {
                    cmbGrupos.Properties.Items.Add(g);
                }

            }
            catch (Exception )
            {
                return;
            }

        }

        private void Usr_Paramgeneracion_Load(object sender, EventArgs e)
        {
            ListaGrupos();
        }

        private void cmbGrupos_Validated(object sender, EventArgs e)
        {
            Gruposel = cmbGrupos.Properties.Items.GetCheckedValues().Select(s => s.ToString()).ToList();
        }
    }
}
