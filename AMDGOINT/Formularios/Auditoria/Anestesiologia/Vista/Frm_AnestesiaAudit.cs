using System;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using DevExpress.XtraTab;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using AMDGOINT.Formularios.Auditoria.Anestesiologia.MC;

namespace AMDGOINT.Formularios.Auditoria.Anestesiologia.Vista
{
    public partial class Frm_AnestesiaAudit : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();        
        private Propiedadesgral prop = new Propiedadesgral();
        public Anestesiaenc Anestesia { get; set; } = new Anestesiaenc();
        private Frm_AnestesiaAuditDet frmdetalle = new Frm_AnestesiaAuditDet();

        public bool Es_Popup { get; set; } = false;       

        private ConexionBD bc = new ConexionBD();
        private SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public Frm_AnestesiaAudit()
        {
            InitializeComponent();

            this.Load += new EventHandler(Formulario_Load);
            this.Shown += new EventHandler(Formulario_Shown);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);

        }

        #region METODOS MANUALES
               
        //ACCIONES DE CONTINUACION
        private void Continuacion()
        {
            try
            {
                if (Es_Popup) { this.DialogResult = DialogResult.OK; }
                else
                {
                    this.Close();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        //PARAMETROS DE INICIO
        private void ParametrosInicio()
        {
            SqlConnection = bc.Conectar();
            Anestesia.SqlConnection = SqlConnection;
                      
            this.FormBorderStyle = ctrls.EstiloBordesform(Es_Popup);
            pnlBase.Appearance.BorderColor = ctrls.Setcolorborde(Es_Popup);

            frmdetalle.Editable = true;
            ctrls.AgregaFormulario(frmdetalle, TabDetalles);            

            //ICONOS            
            TabDetalles.TabPages[0].ImageOptions.Image = Properties.Resources.BOContact2_16x16;

            TabDetalles.SelectedTabPageIndex = 0;

            //ENLAZO LAS PROPIEDADES A LOS CONTROLES
            SetBindings();
        }
                
        //CARGA DE DATOS
        private void SetBindings()
        {
            try
            {
                
                datcarga.DataBindings.Add("EditValue", Anestesia, nameof(Anestesia.FechaCarga));
                txtperiodo.DataBindings.Add("Text", Anestesia, nameof(Anestesia.Periodo));
                datfacturado.DataBindings.Add("EditValue", Anestesia, nameof(Anestesia.FechaFactura));
                txtnumero.DataBindings.Add("Text", Anestesia, nameof(Anestesia.NroFacturacion));
                txtentidad.DataBindings.Add("Text", Anestesia, nameof(Anestesia.Entidad));
                cmbPrestataria.DataBindings.Add("EditValue", Anestesia, nameof(Anestesia.IDPrestdetalle));
                                
                frmdetalle.anestesiadetalles = Anestesia.Grupos;
                frmdetalle.IDEncabezado = Anestesia.IDRegistro;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al enlazar las propiedades.\n" + e.Message, 0);
                return;

            }
        }
               
        //CARGA DE COMBOS
        private void CargaCombos(short cmb)
        {
            try
            {                   
                if (cmb == 0 || cmb == 1)
                {
                    string c = $"SELECT PD.ID_Registro, PD.Codigo, PD.Descripcion as Prestataria, CD.Abreviatura as Iva" +
                               $" FROM PRESTDETALLES PD" +
                               $" LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                               $" LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                               $" WHERE PR.Estado = 1 AND (PD.ID_Registro = 124 OR PD.ID_Registro = 28)" +
                               $" ORDER BY PD.Descripcion ASC";

                    cmbPrestataria.Properties.DataSource = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);                    
                }
               
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al cargar los combos.\n" + e.Message + " " + cmb, 0);                
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
            CargaCombos(0);
            datcarga.Focus();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            
        }
               
        private void Frm_Profesional_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Es_Popup)
            {
                if (this.Parent is XtraTabPage)
                {
                    XtraTabPage c = this.Parent as XtraTabPage;
                    XtraTabControl x = c.Parent as XtraTabControl;
                    
                    x.TabPages.Remove(c);
                }
            }

            if (SqlConnection.State != ConnectionState.Open) { SqlConnection.Close(); }
            bc.Desconectar();
            SqlConnection.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (Anestesia.FechaCarga <= DateTime.MinValue)
            {
                ctrls.MensajeInfo("Debe Ingresar una fecha de ingreso.", 1);
                datcarga.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(Anestesia.Periodo))
            {
                ctrls.MensajeInfo("Debe Ingresar un periodo.", 1);
                txtperiodo.Focus();
                return;
            }

            if (Anestesia.FechaFactura <= DateTime.MinValue)
            {
                ctrls.MensajeInfo("Debe Ingresar una fecha de facturación.", 1);
                datfacturado.Focus();
                return;
            }

            if (Anestesia.NroFacturacion <= 0)
            {
                ctrls.MensajeInfo("Debe Ingresar un número de facturación.", 1);
                txtnumero.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(Anestesia.Entidad))
            {
                ctrls.MensajeInfo("Debe Ingresar la entidad emisora.", 1);
                txtentidad.Focus();
                return;
            }

            if (Anestesia.IDPrestdetalle <= 0)
            {
                ctrls.MensajeInfo("Debe Ingresar la prestataria.", 1);
                cmbPrestataria.Focus();
                return;
            }

            if (Anestesia.Grupos.Count <= 0)
            {
                ctrls.MensajeInfo("No puede guardar registos sin detalles.", 1);                
                return;
            }


            Dictionary<short, string> retorno = new Dictionary<short, string>();

            retorno = Anestesia.Abm();

            if (retorno.Count > 0)
            {

                 string mensajes = "";

                 foreach (string i in retorno.Where(w => w.Key != 1).Select(s => s.Value))
                 {
                     mensajes += $"{i.Trim()}\n";
                 }

                 if (!string.IsNullOrWhiteSpace(mensajes)) { ctrls.MensajeInfo($"Hubo inconvenientes en el guardado.\n{mensajes}", 1); }
            }

            Continuacion();
        }

    }
}