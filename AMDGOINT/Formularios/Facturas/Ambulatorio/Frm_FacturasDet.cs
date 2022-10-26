using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraGrid.Localization;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio
{
    public partial class Frm_FacturasDet : XtraForm
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        private Propiedadesgral prop = new Propiedadesgral();

        private List<FacturasEmitdetStruct> factdetalles = new List<FacturasEmitdetStruct>();
        public List<FacturasEmitdetStruct> factretorno = new List<FacturasEmitdetStruct>();
        public long IDEncabezado { get; set; } = 0;
        public bool EsPopup { get; set; } = false;

        public Frm_FacturasDet()
        {
            Localizer.Active = new EspañolLocalizer();
            GridLocalizer.Active = new EspañolLocalizerGrid();
            FilterUIElementResXLocalizer.Active = new EspañolLocalizerFiltros();

            InitializeComponent();
            this.Load += new EventHandler(Formulario_Load);
            this.FormClosing += new FormClosingEventHandler(Formulario_Closing);
        }

        #region METODOS MANUALES

        //INICIO LA BUSQUEDA DE REGISTROS
        public void Ibusquedareg()
        {
            try
            {
                bgridView.BeginDataUpdate();
                if (bgwDetalles.IsBusy) { bgwDetalles.CancelAsync(); }
                while (bgwDetalles.CancellationPending)
                { if (!bgwDetalles.CancellationPending) { break; } }

                bgwDetalles.RunWorkerAsync();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al iniciar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        //EJECUTO LA BUSQUEDA DE REGISTROS
        private void Ebusquedareg()
        {
            try
            {
                factdetalles.Clear();

                if (IDEncabezado <= 0) return;

                string consulta = "SELECT ID_Registro, ID_Encabezado, FechaPract, CodPract, DescrPract, Funcion," +
                    " DocuPaci, NombrePaci, Cantidad, Neto, Iva, Total, IvaPorc, NoGravado" +
                    " FROM FACTAMBUDET" +
                    " WHERE ID_ENCABEZADO = " + IDEncabezado;

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    if (bgwDetalles.CancellationPending) { return; }

                    factdetalles.Add(new FacturasEmitdetStruct {
                        IDRegistro = Convert.ToInt64(f["ID_Registro"]),
                        IDEncabezado = Convert.ToInt64(f["ID_Encabezado"]),
                        Fecha = Convert.ToDateTime(f["FechaPract"]),
                        Practica = f["CodPract"].ToString(),
                        PracticaNom = f["DescrPract"].ToString(),
                        Funcion = f["Funcion"].ToString(),
                        DocuPaci = Convert.ToInt64(f["DocuPaci"]),
                        NombrePaci = f["NombrePaci"].ToString(),
                        Cantidad = Convert.ToDecimal(f["Cantidad"]),
                        Neto = Convert.ToDecimal(f["Neto"]),
                        Iva = Convert.ToDecimal(f["Iva"]),
                        Total = Convert.ToDecimal(f["Total"]),
                        IvaPorc = Convert.ToDecimal(f["IvaPorc"]),
                        NoGravado = Convert.ToDecimal(f["NoGravado"]),
                    });
                }
            }
            catch (Exception e)
            {

                ctrls.MensajeInfo("Ocurrió un error al ejecutar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        //FINALIZO LA BUSQUEDA DE REGISTROS
        private void Fbusquedareg()
        {
            try
            {
                gridControl.DataSource = factdetalles;
                bgridView.EndDataUpdate();

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al finalizar la busqueda de detalles.\n" + e.Message, 0);
                return;
            }
        }

        //PARAMETROS DE INICIO
        private void Parametrosinicio()
        {
            if (EsPopup)
            {
                prop.RecuperaUbicacion(2, this);
                bgridView.OptionsSelection.MultiSelect = true;
                bgridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                Ibusquedareg();
            }
            else { tableLayoutPanel1.RowStyles[1].Height = 0; }

            ctrls.PreferencesGrid(this, bgridView, "R");
        }

        //CARGO LOS SELECCIONADOS EN LISTA
        public void SetListadet()
        {
            try
            {
                int[] seleccion = bgridView.GetSelectedRows();

                for (int i = 0; i < seleccion.Length; i++)
                {
                    factretorno.Add(new FacturasEmitdetStruct {
                        IDRegistro = Convert.ToInt64(bgridView.GetRowCellValue(seleccion[i], colIDRegistro)),
                        IvaPorc = Convert.ToDecimal(bgridView.GetRowCellValue(seleccion[i], colIvaporc)),
                        Neto = Convert.ToDecimal(bgridView.GetRowCellValue(seleccion[i], colNeto)),
                        Iva = Convert.ToDecimal(bgridView.GetRowCellValue(seleccion[i], colIva)),
                        NoGravado = Convert.ToDecimal(bgridView.GetRowCellValue(seleccion[i], colNoGravado)),
                        Total = Convert.ToDecimal(bgridView.GetRowCellValue(seleccion[i], colIvaporc)),
                    });
                }                                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al generar la lista.\n" + e.Message, 0);
                return;                    
            }
        }
        
        #endregion

        private void Formulario_Load(object sender, EventArgs e)
        {
            Parametrosinicio();
        }

        private void Formulario_Closing(object sender, FormClosingEventArgs e)
        {
            prop.GuardarUbicacion(2, this);
            ctrls.PreferencesGrid(this, bgridView, "S");
        }

        private void bgwDetalles_DoWork(object sender, DoWorkEventArgs e)
        {
            Ebusquedareg();
        }

        private void bgwDetalles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fbusquedareg();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SetListadet();
            if (factretorno.Count > 0) { this.DialogResult = System.Windows.Forms.DialogResult.OK; }
            else { this.DialogResult = System.Windows.Forms.DialogResult.Abort; }
        }
    }
}