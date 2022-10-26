using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;

namespace AMDGOINT.Formularios.Reclamos.Vista
{
    public partial class Frm_Exportacion : XtraForm
    {
        private ConexionBD cnb = new ConexionBD();
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
                        
        public List<MC.ReclamosDet> Detalles { get; set; } = new List<MC.ReclamosDet>();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        

        public Frm_Exportacion()
        {
            InitializeComponent();

            tglModoExportacion.EditValue = Properties.Settings.Default.ReclamoExportOption;
        }

        #region METODOS MANUALES
        
        private void ParametrosInicio()
        {                                    
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();            
            ctrl.PreferencesGrid(this, gridViewDetalle, "R");
            datFecha.NullDate = DateTime.MinValue;
            datFecha.NullText = string.Empty;
        }


        private void SetBindings()
        {
            try
            {
                gridViewDetalle.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.ReclamosDet>(Detalles);
                gridViewDetalle.EndDataUpdate();

            }
            catch (Exception)
            {
                return;
            }
        }

        private void CargaCombos(short cmb = 0)
        {
            try
            {
                if (cmb == 0 || cmb == 1) //PROFESIONAL CUENTA
                {
                    string c = "SELECT PC.ID_Registro AS IDRegistro, PC.Codigo AS PrestadorCuenta, PC.Descripcion as PrestadorCuentaDescripcion, PF.Cuit as PrestadorCuit," +
                               " CONCAT(PC.Codigo, ' ', PC.Descripcion) AS PrestadorCompleto, PF.ID_Iva AS IDIva, CD.Abreviatura AS IvaAbreviado" +
                               " FROM PROFESIONALES PF" +
                               " LEFT OUTER JOIN PROFCUENTAS PC ON(PC.ID_Profesional = PF.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PF.ID_Iva)" +
                               " WHERE PC.Codigo is not null" +
                               " ORDER BY PF.Nombre ASC";

                    reposCmbPrestador.DataSource = func.getColecciondatos(c, SqlConnection);
                }

                if (cmb == 0 || cmb == 2) //PRESTATARIA PLANES
                {
                    string c = "SELECT PD.ID_Registro AS IDRegistro, PD.Codigo AS PrestatariaCuenta, PD.Descripcion as PrestatariaCuentaDescripcion, PR.Cuit AS PrestatariaCuit," +
                               " CONCAT(PD.Codigo, ' ', PD.Descripcion) AS PrestatariaCompleta, PD.PorcIva" +
                               " FROM PRESTATARIAS PR" +
                               " LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Prestataria = PR.ID_Registro)" +
                               " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                               " LEFT OUTER JOIN AmdgoContable.dbo.pc_PLANSUBCUENTAS PSC ON(PSC.IDRegistro = PD.IDPlanSubCuenta)" +
                              $" WHERE PD.ID_Registro IS NOT NULL AND PD.Visible = 1";

                    reposCmbPrestatariaCuenta.DataSource = null;
                    reposCmbPrestatariaCuenta.DataSource = func.getColecciondatos(c, SqlConnection);

                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void Usr_Detalles_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
            CargaCombos();
            SetBindings();
        }

        #endregion


        #region  GRILLA

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridViewDetalle.ActiveEditor is MemoEdit)
            {
                (gridViewDetalle.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridViewDetalle.ActiveEditor as MemoEdit).Paint += Form1_Paint;
            }            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawFocusRectangle(e.Graphics, e.ClipRectangle);
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            if (sender is MemoEdit)
            {
                MemoEditViewInfo vi = (sender as MemoEdit).GetViewInfo() as MemoEditViewInfo;
                var cache = new GraphicsCache((sender as MemoEdit).CreateGraphics());
                int h = (vi as IHeightAdaptable).CalcHeight(cache, vi.MaskBoxRect.Width);
                var args = new ObjectInfoArgs();
                args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, h);
                var rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
                cache.Dispose();
                (sender as MemoEdit).Height = rect.Height;
            }
        }

        private void gridViewDetalle_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
             popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        
        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void reposCmbPrestatariaCuenta_BeforePopup(object sender, EventArgs e)
        {
            //SetdsPrestatariasRepos(sender);
        }

        #endregion

        private void btnExportaXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctrl.ExportaraExcelgrd(gridControl, Properties.Settings.Default.ReclamoExportOption ? DevExpress.Export.ExportType.WYSIWYG : DevExpress.Export.ExportType.DataAware);
        }


        private void Frm_Exportacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.PreferencesGrid(this, gridViewDetalle, "S");            
            Properties.Settings.Default.Save();

            cnb.Desconectar();
        }

        private void tglModoExportacion_EditValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReclamoExportOption = (bool)tglModoExportacion.EditValue;
        }
    }
}
