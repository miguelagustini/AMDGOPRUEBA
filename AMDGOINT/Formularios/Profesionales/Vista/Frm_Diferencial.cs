using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;

namespace AMDGOINT.Formularios.Profesionales.Vista
{
    public partial class Frm_Diferencial : XtraForm
    {
        private Controles ctrls = new Controles();
               
        private int idprofesional = 0;

        public List<MC.Diferencial> Diferenciallst { get; set; } = new List<MC.Diferencial>();
                
        public int IDProfesional
        {
            get { return idprofesional; }
            set
            {
                if (idprofesional != value)
                {
                    idprofesional = value;                                        
                }

                NotifyPropertyChanged();
            }
        }

        public bool Es_Popup { get; set; } = false;
        public bool Editable { get; set; } = false;
        
        public Frm_Diferencial()
        {
            InitializeComponent();

            reposDate.NullDate = DateTime.MinValue;
            reposDate.NullText = string.Empty;
        }

        #region METODOS MANUALES

        private void ParametrosInicio()
        {            
            FormBorderStyle = FormBorderStyle.None;                         
            gridView.OptionsBehavior.Editable = Editable;                        
            AsignaDatos();

        }
        
        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {           
            if (propertyname == "IDProfesional") { AsignaDatos(); }
            
        }
             
        private void AsignaDatos()
        {
            try
            {
                gridView.BeginDataUpdate();
                gridControl.DataSource = new BindingList<MC.Diferencial>(Diferenciallst);
                gridView.EndDataUpdate();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al actualizar las direcciones.\n{e.Message}", 1);
                return;
            }
        }

       
        #endregion

        private void Frm_Contactos_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void Frm_DirecCont_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void gridViewDomi_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Editable) { return; }

            if (e.KeyCode == Keys.F2)
            {
                gridView.AddNewRow();
                
            }           
        }

        private void gridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {            
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void reposMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Oem4)
            {
                e.SuppressKeyPress = true;
            }
        }
    }

}