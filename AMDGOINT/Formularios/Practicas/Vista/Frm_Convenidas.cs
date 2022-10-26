using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.Utils.Filtering.Internal;
using System.Data.SqlClient;
using System.Linq;

namespace AMDGOINT.Formularios.Practicas.Vista
{
    public partial class Frm_Convenidas : XtraForm
    {
        private Controles ctrls = new Controles();
        private List<MC.Convenidas> detalles = new List<MC.Convenidas>();
        

        public List<MC.Convenidas> Detalles
        {
            get { return detalles; }
            set
            {
                detalles = detalles != value ? value : detalles;
                SetBindings();
            }
        }

        public Frm_Convenidas()
        {            
            InitializeComponent();
        }
        
        //ASIGNACION DE ENLACES        
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
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }


    }

}