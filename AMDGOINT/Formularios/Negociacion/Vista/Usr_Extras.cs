using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Windows.Forms;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Usr_Extras : XtraUserControl
    {        
        private Controles ctrl = new Controles();
        private MC.Negociacion _negociacion = new MC.Negociacion();
        
        public MC.Negociacion Negociacion
        {
            get { return _negociacion; }
            set
            {
                if (_negociacion != value)
                {
                    _negociacion = value;
                    SetBindigs();
                }
            }
        }
        
        public Usr_Extras()
        {
            InitializeComponent();
            HandleDestroyed += new EventHandler(UsrHandleDestroyed);            
        }

        #region METODOS MANUALES

        private void SetBindigs()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Extra>(Negociacion.Extras);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}.Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }
        

        #endregion

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            
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

        private void gridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                gridView.AddNewRow();                                
            }
            else if (e.KeyData == Keys.Delete)
            {
                var v = gridView.GetFocusedRowCellValue(colBorraRegistro);
                if (v == null) { return; }
                gridView.SetFocusedRowCellValue(colBorraRegistro, !(bool)v);
            }
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
