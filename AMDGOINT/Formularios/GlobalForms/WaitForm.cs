using System;
using System.Windows.Forms;

namespace AmdgoInterno.Formularios.GlobalForms
{
    public partial class WaitForm : DevExpress.XtraWaitForm.WaitForm
    {        
        public WaitForm()
        {
            InitializeComponent();           
        }

        #region Overrides

        public void SetTitulo(string titulo)
        {
            labelControl1.Text = titulo;
        }

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            
        }

        public override void SetDescription(string description)
        {
            //base.SetDescription(description);            
            labelControl1.Text = description;
        }
        
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {
            this.Left = Screen.GetWorkingArea(this).Right - this.Width;
            this.Top = 95;//Screen.GetWorkingArea(this).Bottom - this.Height;
        }
    }
}