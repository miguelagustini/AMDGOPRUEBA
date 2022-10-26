using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AMDGOINT.Clases;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AMDGOINT.Formularios.Prestatarias.Vista
{
    public partial class Usr_MovimientosCmpr : UserControl
    {
        private Controles ctrls = new Controles();        
        private List<MC.MovimientosEncabezado> movimientos = new List<MC.MovimientosEncabezado>();
                
        public List<MC.MovimientosEncabezado> MovimientosComprobantes
        {
            get { return movimientos; }
            set
            {
                movimientos = movimientos != value ? value : movimientos;
                SetBindings();
            }
        }

        public Usr_MovimientosCmpr()
        {
            InitializeComponent();
          
        }

        #region METODOS MANUALES

        //ASIGNACION DE ENLACES        
        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.MovimientosEncabezado>(MovimientosComprobantes);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }
        
        #endregion

        private void Usr_Contactos_Load(object sender, EventArgs e)
        {
            
        }

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {

        }
    }
}
