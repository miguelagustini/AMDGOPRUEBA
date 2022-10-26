using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.OrdenesPago.Vista
{
    public partial class Usr_Detalles : UserControl
    {
        private Controles ctrls = new Controles();        
                                        
        public List<MC.OrdenPagoDet> Detalles { get; set; } = new List<MC.OrdenPagoDet>();
        private long _idorden = 0;
              
        public long IDOrdenPago
        {
            get { return _idorden; }
            set
            {
                _idorden = _idorden != value ? value : _idorden;
                SetBindings();
            }

        }

        public Usr_Detalles()
        {
            InitializeComponent();            
            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;

        }
        
        //EJECUTO LA BUSQUEDA DE REGISTROS
        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = Detalles;
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                gridView.EndDataUpdate();
                ctrls.MensajeInfo("Ocurrió un error al ejecutar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }
    }
}
