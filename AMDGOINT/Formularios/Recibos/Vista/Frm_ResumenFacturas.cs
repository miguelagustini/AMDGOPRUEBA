using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Linq;

namespace AMDGOINT.Formularios.Recibos.Vista
{
    public partial class Frm_ResumenFacturas : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private OverlayPanel OverlayPanel = new OverlayPanel();
                
        public List<MC.DetalleExtendido> Recibos { get; set; } = new List<MC.DetalleExtendido>();   
        private List<MC.ReciboEnc> _recibos { get; set; } = new List<MC.ReciboEnc>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        public Frm_ResumenFacturas()
        {
            InitializeComponent();
            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;
        }

        #region METODOS MANUALES
        
        private void ParametrosInicio()
        {                                    
            
            ctrl.PreferencesGrid(this, ViewResumenFacturas, "R");
            
        }


      
        private void ExportarRegistros()
        {
            try
            {
                OverlayPanel.Mostrar(this);
                ViewResumenFacturas.BeginDataUpdate();

                if (tglModo.IsOn)
                {                   
                    
                    for (int i = 0; i < (ViewResumenFacturas.RowCount - 1); i++)
                    {
                        ViewResumenFacturas.ExpandMasterRow(i, 0);
                    }
                }

                ctrl.ExportaraExcelgrd(gridControl, tglModo.IsOn ? DevExpress.Export.ExportType.WYSIWYG : DevExpress.Export.ExportType.DataAware);

                ViewResumenFacturas.EndDataUpdate();
                OverlayPanel.Ocultar();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);                
                return;
            }
        }


        private void Usr_Detalles_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Frm_ResumenFacturas_Shown(object sender, EventArgs e)
        {
            ViewResumenFacturas.BeginDataUpdate();
            gridControl.DataSource = new BindingList<MC.DetalleExtendido>(Recibos.OrderByDescending(o => o.FechaEmision).ToList());
            ViewResumenFacturas.EndDataUpdate();
        }

        #endregion
                        
        private void Frm_Exportacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.PreferencesGrid(this, ViewResumenFacturas, "S");                        
            cnb.Desconectar();
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarRegistros();
        }
    }
}
