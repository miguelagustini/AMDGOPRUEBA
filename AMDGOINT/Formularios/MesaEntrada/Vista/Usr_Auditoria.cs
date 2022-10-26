using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using System.Runtime.CompilerServices;
using AMDGOINT.Clases;
using DevExpress.XtraEditors.ViewInfo;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using System.Drawing;

namespace AMDGOINT.Formularios.MesaEntrada.Vista
{
    public partial class Usr_Auditoria : XtraUserControl
    {
        private Controles ctrls = new Controles();

        private List<MC.Auditor> _auditores = new List<MC.Auditor>();
        public List<MC.Auditor> Auditores
        {
            get { return _auditores; }
            set
            {
                _auditores = _auditores != value ? value : _auditores;
                NotifyPropertyChanged();
            }            
        } 
   
        public Usr_Auditoria()
        {
            InitializeComponent();
            HandleDestroyed += new EventHandler(UsrHandleDestroyed);
            ctrls.PreferencesGrid(null, gridView, "R", this);
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (propertyname == "Auditores") { AsignaDatos(); }            
        }

        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = Auditores;                
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            ctrls.PreferencesGrid(null, gridView, "S", this);
        }

        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridView.ActiveEditor is MemoEdit)
            {
                (gridView.ActiveEditor as MemoEdit).TextChanged += Form1_TextChanged;
                (gridView.ActiveEditor as MemoEdit).Paint += Form1_Paint;
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

    }
}
