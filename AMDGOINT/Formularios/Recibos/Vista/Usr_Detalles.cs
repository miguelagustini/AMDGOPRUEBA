using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;

namespace AMDGOINT.Formularios.Recibos.Vista
{
    public partial class Usr_Detalles : UserControl
    {
        private Controles ctrls = new Controles();        
                                        
        public List<MC.ReciboDet> Detalles { get; set; } = new List<MC.ReciboDet>();
        private long _idrecibo = 0;
              
        public long IDRecibo
        {
            get { return _idrecibo; }
            set
            {
                _idrecibo = _idrecibo != value ? value : _idrecibo;
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
