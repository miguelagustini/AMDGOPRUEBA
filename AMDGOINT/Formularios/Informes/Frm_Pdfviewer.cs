using System.IO;

namespace AMDGOINT.Formularios.Informes
{
    public partial class Frm_Pdfviewer : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Pdfviewer()
        {
            InitializeComponent();
        }

        public void CargaVista(MemoryStream archivo)
        {
            if (archivo is null) { return; }

            pdfViewer.LoadDocument(archivo);
            pdfViewer.Refresh();
        }


    }
}