using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Drawing;

namespace AMDGOINT.Formularios.MesaEntrada.Vista
{
    public partial class Usr_GestionDocumentos : XtraUserControl
    {

        private Controles ctrls = new Controles();
        private MC.Documental _gestdocumental = new MC.Documental();
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public MC.Documental GestionDocumental
        {
            get { return _gestdocumental; }
            set
            {
                _gestdocumental = _gestdocumental != value ? value : _gestdocumental;
                NotifyPropertyChanged();
            }
        }
        
        public Usr_GestionDocumentos()
        {
            InitializeComponent();
            HandleDestroyed += new EventHandler(UsrHandleDestroyed);

            ctrls.PreferencesGrid(null, gridView, "R", this);
            reposDateedit.NullDate = DateTime.MinValue;
            reposDateedit.NullText = string.Empty;

            CargaCombo();
        }

        private void CargaCombo()
        {
            try
            {
                MC.Accion _accion = new MC.Accion(SqlConnection);
                cmbAcciones.DataSource = _accion.GetRegistros();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al cargar la lista de acciones.\n{e.Message}", 1);
                return;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (propertyname == "GestionDocumental") { AsignaDatos(); }
        }

        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Gestion>(GestionDocumental.Gestion);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar los registros.\n{e.Message}", 1);
                return;
            }
        }

        //INICIO EL ABM DE REGISTRO
        private void IGuardaRegistros()
        {
            try
            {                
                gridView.BeginDataUpdate();

                if (!splashScreen.IsSplashFormVisible) { splashScreen.ShowWaitForm(); }

                if (bgwRegistros.IsBusy) { bgwRegistros.CancelAsync(); }
                while (bgwRegistros.CancellationPending)
                { if (!bgwRegistros.CancellationPending) { break; } }

                bgwRegistros.RunWorkerAsync();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        //EJECUTO EL ABM DE REGISTRO
        private void GuardaRegistros(MC.Gestion g)
        {
            try
            {
                
                MC.Gestion _gestion = null; 

                if (g != null) { _gestion = g; } else { _gestion = gridView.GetRow(gridView.FocusedRowHandle) as MC.Gestion;}
                if (_gestion == null) { InsertaRegistrosnew(); return; }
                
                Dictionary<short, string> retorno = new Dictionary<short, string>();

                MC.Gestion _registrouso = GestionDocumental.Gestion.Where(w => w.IDLocal == _gestion.IDLocal).First();
                _registrouso.NroBusqueda = GestionDocumental.NroBusqueda;
                _registrouso.NroInternacion = GestionDocumental.NroInternacion;
                _registrouso.IDProfesionalCuenta = GestionDocumental.IDProfesionalCuenta;
                _registrouso.SqlConnection = SqlConnection;

                retorno = _registrouso.Abm();

                if (retorno.Count > 0)
                {
                    string mensajes = "";

                    foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                    {
                        mensajes += $"{i.Trim()}\n";
                    }

                    if (!string.IsNullOrWhiteSpace(mensajes))
                    { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
                }
                else
                {
                    if (_registrouso.IDRegistro <= 0) { _registrouso.IDRegistro = _registrouso.GetRegistrosbyGuid().IDRegistro; }                    
                }

            }
            catch (Exception)
            {
                gridView.EndDataUpdate();
            }
        }

        //FINALIZO EL ABM DE REGISTRO
        private void FGuardaRegistros()
        {
            if (splashScreen.IsSplashFormVisible) { splashScreen.CloseWaitForm(); }
            gridView.EndDataUpdate();
        }

        //MARCA REGISTRO PARA BORRAR
        private void MarcaRegistro()
        {
            try
            {
                
                if (ctrls.MensajePregunta($"¿Está seguro/a de borrar éste registro?") == DialogResult.No) { return; }
                
                MC.Gestion _gestion = gridView.GetRow(gridView.FocusedRowHandle) as MC.Gestion;
                if (_gestion == null) { return; }
                gridView.BeginDataUpdate();
                _gestion._BorraRegistro = true;
                GuardaRegistros(null);
                GestionDocumental.Gestion.RemoveAll(r => r == _gestion);
                gridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Hubo un inconveniente al marcar el registro.\n{e.Message}", 1);
                return;
            }
        }

        //INSERTA REGISTROS
        private void InsertaRegistrosnew()
        {
            try
            {
                foreach (MC.Gestion g in GestionDocumental.Gestion)
                {
                    if (g.IDRegistro <= 0)
                    {
                        GuardaRegistros(g);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                gridView.AddNewRow();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (gridView.RowCount <= 0) { return; }
                MarcaRegistro();
            }            
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            ctrls.PreferencesGrid(null, gridView, "S", this);
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {            
            IGuardaRegistros();
        }

        private void bgwRegistros_DoWork(object sender, DoWorkEventArgs e)
        {
            GuardaRegistros(null);
        }

        private void bgwRegistros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FGuardaRegistros();
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
