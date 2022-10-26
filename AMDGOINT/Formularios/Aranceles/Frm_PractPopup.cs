using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections;
using AMDGOINT.Clases;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Aranceles
{
    public partial class Frm_PractPopup : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Globales glob = new Globales();
        private Propiedadesgral prop = new Propiedadesgral();

        private List<ArancelesValoriza> practlst = new List<ArancelesValoriza>();
        private List<ArancelesValoriza> practcmb = new List<ArancelesValoriza>();
        public List<ArancelesValoriza> practlstuso = new List<ArancelesValoriza>();
        public ArancelesValoriza practicanew = new ArancelesValoriza();

        public bool Es_Popup { get; set; } = false;
        
        public Frm_PractPopup()
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
                         " ISNULL(PG.Descripcion,'') As Grupo, 0 AS ValorPrepaga, 0 AS ValorArt, 0 AS ValorOs, 0 AS ValorCaja," +
                         " '' as ObsPrepaga, '' as ObsOs, '' as ObsArt, '' as ObsCaja, ISNULL(FU.Codigo,'') AS LetraFuncion" +                         
                         " FROM PRACTAM PM" +
                         " LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion)" +
                         " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)" +
                         " WHERE PM.Estado = 1";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    practlst.Add(new ArancelesValoriza
                    {
                        IDPractAm = Convert.ToInt32(r["ID_Registro"]),
                        CodigoPractica = r["Codigo"].ToString().Trim(),
                        DescripcionPractica = r["Descripcion"].ToString().Trim(),                        
                        CodigoFuncion = r["CodFuncion"].ToString().Trim(),
                        LetraFuncion = r["LetraFuncion"].ToString().Trim(),                       
                        DescripcionFuncion = r["DescFuncion"].ToString().Trim(),
                        GrupoPractica = r["Grupo"].ToString().Trim(),
                        ValorPrepaga = Convert.ToDecimal(r["ValorPrepaga"]),
                        ValorOs = Convert.ToDecimal(r["ValorOs"]),
                        ValorArt = Convert.ToDecimal(r["ValorArt"]),
                        ValorCaja = Convert.ToDecimal(r["ValorCaja"]),
                        ObsPrepaga = r["ObsPrepaga"].ToString().Trim(),
                        ObsOs = r["ObsOs"].ToString().Trim(),
                        ObsArt = r["ObsArt"].ToString().Trim(),
                        ObsCaja = r["ObsCaja"].ToString().Trim()

                    });
                }

                practcmb = practlst.Where(s => !practlstuso.Any(l => s.IDPractAm == l.IDPractAm)).ToList();
                
                cmbPracticas.Properties.DataSource = practcmb;

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