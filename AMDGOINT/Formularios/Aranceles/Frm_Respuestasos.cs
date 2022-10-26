using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_Respuestasos : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        
        public List<DiscusionRespuestasAM> respuestaslst = new List<DiscusionRespuestasAM>(); 

        public bool Es_Popup { get; set; } = true;
        public int IDEncabezado { get; set; } = 0;
        
        public Frm_Respuestasos()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES
                      
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {            
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);            
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);        
        }

        //CARGA REGISTROS
        private void CargaRegistros()
        {
            try
            {
                gridViewam.BeginDataUpdate();                
                gridControl.DataSource = new BindingList<DiscusionRespuestasAM>(respuestaslst);
                gridViewam.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al consultar cargar los datos.\n {e.Message}", 0);
                return;
            }
        }
                       
        #endregion

        //**************************************************************************
        //***********************  EVENTOS DEL FORMULARIO  *************************
        //**************************************************************************
        private void Formulario_Load(object sender, EventArgs e)
        {
            ParametrosInicio();                        
        }

        private void Formulario_Shown(object sender, EventArgs e)
        {            
            CargaRegistros();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridViewam.ActiveEditor is MemoEdit)
            {
               
                (gridViewam.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridViewam.ActiveEditor as MemoEdit).Paint += Form1_Paint;
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

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridViewam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {                
                gridViewam.AddNewRow();
                gridViewam.ShowEditForm();
                
                e.SuppressKeyPress = true;
                e.Handled = true;
                
            }
            else if (e.KeyData == Keys.F4)
            {
                gridViewam.ExpandMasterRow(gridViewam.FocusedRowHandle);                
                GridView view = gridViewam.GetDetailView(gridViewam.FocusedRowHandle, 
                                                        gridViewam.GetRelationIndex(gridViewam.FocusedRowHandle,"RespuestaOs")) as GridView;
                if (view != null)
                {
                    view.AddNewRow();                    
                    view.ShowEditForm();
                }
                e.SuppressKeyPress = true;
                e.Handled = true;

            }
            else if (e.KeyData == Keys.Delete || e.KeyData == Keys.Insert)
            {                 
                gridViewam.SetFocusedRowCellValue(colBorrareg, e.KeyData == Keys.Delete ? true : false);

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void gridViewos_KeyDown(object sender, KeyEventArgs e)
        {
            gridViewam.ExpandMasterRow(gridViewam.FocusedRowHandle);
            GridView view = gridViewam.GetDetailView(gridViewam.FocusedRowHandle,
                                                        gridViewam.GetRelationIndex(gridViewam.FocusedRowHandle, "RespuestaOs")) as GridView;
            if (view == null) { return; }

            if (e.KeyData == Keys.F4)
            {
                view.AddNewRow();
                view.ShowEditForm();                
                e.SuppressKeyPress = true;
                e.Handled = true;

            }
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Insert)
            {
                view.SetFocusedRowCellValue(coBorrareg, e.KeyData == Keys.Delete ? true : false);

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}