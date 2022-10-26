using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using System.Threading;

namespace AMDGOINT.Formularios.GlobalForms
{
    public partial class FormEspera : WaitForm
    {
        public FormEspera()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {            
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.Point)
            {
                this.Size = (Size)arg;
                
            }
        }

        #endregion

        public enum WaitFormCommand
        {
            Point
        }

        private void FormEspera_Load(object sender, EventArgs e)
        {
            
        }
    }
}