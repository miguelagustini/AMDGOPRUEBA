using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_PractDiscPopup : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();

        private List<DiscusionDetalle> practlst = new List<DiscusionDetalle>();
        private List<DiscusionDetalle> practcmb = new List<DiscusionDetalle>();
        public List<DiscusionDetalle> practlstuso = new List<DiscusionDetalle>();
        public DiscusionDetalle practicanew = new DiscusionDetalle();

        public bool Es_Popup { get; set; } = false;
        
        public Frm_PractDiscPopup()
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

            CargaCombos();
                        
        }

        private void CargaCombos(short cmb = 0)
        {
            try
            {
                cmbPracticas.Properties.DataSource = "";

                if (practlstuso.Count <= 0) { return; }

                practlst.Clear();

               string c = "SELECT PM.ID_Registro, PM.Codigo, PM.Descripcion, ISNULL(FU.Codigo,'') AS CodFuncion, ISNULL(FU.Descripcion,'') AS DescFuncion," +
                         " ISNULL(PG.Descripcion,'') As Grupo, ISNULL(PG.Orden,0) As GrupoOrden, ISNULL(PG.Observacion,'') As GrupoObs, " +
                         " ISNULL(PG.ID_Registro,0) As IDGrupo, ISNULL(FU.Letra,'') AS LetraFuncion, ISNULL(FU.ID_Registro, 0) AS IDFuncion," +
                         " PM.ID_Arancel, PM.ID_Gasto" +                         
                         " FROM PRACTAM PM" +
                         " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                         " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                         " WHERE PM.Estado = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    practlst.Add(new DiscusionDetalle
                    {
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoOs = r["Codigo"].ToString().Trim(),
                        CodigoPractica = r["Codigo"].ToString().Trim(),
                        DescripcionPractica = r["Descripcion"].ToString().Trim(),
                        CodigoFuncion = r["CodFuncion"].ToString().Trim(),
                        DescripcionFuncion = r["DescFuncion"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),
                        IDFuncion = Convert.ToInt32(r["IDFuncion"]),
                        IDArancel = Convert.ToInt32(r["ID_Arancel"]),
                        IDGasto = Convert.ToInt32(r["ID_Gasto"]),
                        GrupoPractica = r["Grupo"].ToString().Trim(),
                        GrupoOrden = Convert.ToInt32(r["GrupoOrden"]),
                        IDGrupo = Convert.ToInt32(r["IDGrupo"]),
                        GrupoObservacion = r["GrupoObs"].ToString().Trim()                        
                    });
                }

                practcmb = practlst.Where(s => !practlstuso.Any(l => s.IDPractAm == l.IDPractAm)).ToList();

                cmbPracticas.Properties.BeginUpdate();
                cmbPracticas.Properties.DataSource = practcmb;
                cmbPracticas.Properties.EndUpdate();
                //TODO
                //INDICE FUERA DE LA MATRIZ

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message, 0);
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
            cmbPracticas.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var idp = cmbPracticas.EditValue;

            if (idp != null)
            {
                practicanew = practcmb.Where(s => s.IDPractAm == Convert.ToInt32(idp)).First();
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }

          
        }
    }
}