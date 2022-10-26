﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using AMDGOINT.Clases;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;
using DevExpress.Utils.Drawing;

namespace AMDGOINT.Formularios.Reclamos.Vista
{
    public partial class Usr_Eventos : XtraUserControl
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();

        private MC.ReclamosEventos Evento = new MC.ReclamosEventos();
        public List<MC.ReclamosEventos> Eventos { get; set; } = new List<MC.ReclamosEventos>();
        private long _idreclamo = 0;
        private DataTable _dteventos = new DataTable();
        private bool Editable { get; set; } = false;
        public long IDReclamo
        {
            get { return _idreclamo; }
            set
            {
                if (_idreclamo != value) { _idreclamo = value; }
                SetBindings();
            }
        }
        public SqlConnection SqlConnection = new SqlConnection();

        public Usr_Eventos()
        {
            UsrConstructor();
        }

        public Usr_Eventos(bool editable = false)
        {
            UsrConstructor(editable);
        }

        private void UsrConstructor(bool editable = false)
        {
            InitializeComponent();

            HandleDestroyed += new EventHandler(UsrHandleDestroyed);
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();
            Editable = editable;
            ctrl.PreferencesGrid(null, gridView, "R", this);

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;            
        }

        private void SetBindings()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.ReclamosEventos>(Eventos);
                gridView.EndDataUpdate();

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
                if (cmb == 0 || cmb == 1)
                {
                    string c = "SELECT IDRegistro, Descripcion FROM [AmdgoInterno].[dbo].[EVENTOS] WHERE Origen = 0";
                    _dteventos = null;
                    _dteventos = func.getColecciondatos(c, SqlConnection);
                    repCmbEvento.DataSource = null;
                    repCmbEvento.DataSource = _dteventos;
                }                               

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar los combos.\n{e.Message}", 1);
                return;
            }
        }

        private void SetEventosReposds(object sndr)
        {
            try
            {
                repCmbEvento.DataSource = null;
                repCmbEvento.DataSource = _dteventos;

                if (sndr != null)
                {
                    SearchLookUpEdit cmb = sndr as SearchLookUpEdit;
                    cmb.Properties.DataSource = null;
                    cmb.Properties.DataSource = _dteventos;

                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al asignar el ds de prestatarias.\n{e.Message}", 1);
                return;
            }
        }

        private void AltaEvento()
        {
            try
            {
                Formularios.Eventos.Vista.Frm_Evento frm = new Formularios.Eventos.Vista.Frm_Evento();
                frm.SqlConnection = SqlConnection;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargaCombos();                    
                }
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al generar el alta del evento.\n{e.Message}",1);
                return;
            }
        }

        private void Usr_Eventos_Load(object sender, EventArgs e)
        {
            CargaCombos();
        }

        private void UsrHandleDestroyed(object sender, EventArgs e)
        {
            ctrl.PreferencesGrid(null, gridView, "S", this);
            cnb.Desconectar();
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oem4) { e.SuppressKeyPress = true; }
        }

        private void repCmbEvento_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) { AltaEvento(); }                
        }

        private void repCmbEvento_BeforePopup(object sender, EventArgs e)
        {
            SetEventosReposds(sender);
        }

        private void gridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            //CENTRADO DE FORM
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F2 && Editable)
            {
                gridView.AddNewRow();                
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

        private void gridView_EditFormShowing(object sender, DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs e)
        {
            e.Allow = Editable;
        }
    }
}
