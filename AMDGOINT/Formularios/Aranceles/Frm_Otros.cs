using System;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;
using System.ComponentModel;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_Otros : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();

        public List<DiscusionOtros> otroslst = new List<DiscusionOtros>(); 

        public bool Es_Popup { get; set; } = true;
        
        public Frm_Otros()
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
                gridView.BeginDataUpdate();
                gridControl.DataSource =new BindingList<DiscusionOtros>(otroslst);
                gridView.EndDataUpdate();
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

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {                
                gridView.AddNewRow();
                gridView.ShowEditForm();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Delete)
            {
                var v = gridView.GetFocusedRowCellValue(colBorraRegistro);

                if (v == null) { return; }

                gridView.SetFocusedRowCellValue(colBorraRegistro, !(bool)v);

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
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

        private void gridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }
    }
}