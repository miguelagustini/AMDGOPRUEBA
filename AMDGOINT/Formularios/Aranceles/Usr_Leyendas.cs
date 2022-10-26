using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Usr_Leyendas : DevExpress.XtraEditors.XtraUserControl
    {
        public Usr_Leyendas()
        {
            InitializeComponent();
        }

        private void CargaRegistros()
        {
            List<Colores> c = new List<Colores>();

            c.Add(new Colores { Valor = ">= 75"});
            c.Add(new Colores { Valor = ">= 50"});
            c.Add(new Colores { Valor = ">= 25" });
            c.Add(new Colores { Valor = "> 0" });
            c.Add(new Colores { Valor = "= 0" });
            c.Add(new Colores { Valor = ">= -25" });
            c.Add(new Colores { Valor = ">= -50" });
            c.Add(new Colores { Valor = "< -50" });

            gridView.BeginDataUpdate();
            gridControl.DataSource = c;
            gridView.EndDataUpdate();
            
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == colColor)
            {
                var v = gridView.GetRowCellValue(e.RowHandle, colValor);

                if (v != null)
                {
                    if (v.ToString() == ">= 75")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#272F7F");
                    }
                    else if (v.ToString() == ">= 50")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#1A4301");
                    }
                    else if (v.ToString() == ">= 25")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#538D22");
                    }
                    else if (v.ToString() == "> 0")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#AAD576");
                    }
                    //CERO
                    else if (v.ToString() == "= 0")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#EEF5E6");
                        

                    }
                    //NEGATIVOS
                    else if (v.ToString() == ">= -25")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#FFBA08");
                        

                    }
                    else if (v.ToString() == ">= -50")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#E85D04");
                        

                    }
                    else if (v.ToString() == "< -50")
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#9D0208");
                        

                    }
                }
            }
        }

        private void Usr_Leyendas_Load(object sender, EventArgs e)
        {
            CargaRegistros();
        }
    }

    class Colores
    {
        public string Valor { get; set; } = "";
    }
}
