using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using AMDGOINT.Clases;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Negociacion.Vista
{
    public partial class Usr_Encabezado : XtraUserControl
    {
        private ConexionBD cnb = new ConexionBD();
        private Controles ctrl = new Controles();        
        private MC.Negociacion _negociacion = new MC.Negociacion();

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public MC.Negociacion Negociacion
        {
            get { return _negociacion; }
            set
            {
                if (_negociacion != value)
                {
                    _negociacion = value;
                    SetBindigs();
                }
            }
        }

        public Usr_Encabezado()
        {
            InitializeComponent();
        }

        private void SetBindigs()
        {
            try
            {
                datInicio.DataBindings.Clear();
                cmbValorbase.DataBindings.Clear();
                datImpacto.DataBindings.Clear();
                cmbAgrupadorval.DataBindings.Clear();
                
                datInicio.DataBindings.Add("EditValue", Negociacion, nameof(Negociacion.FechaInicio));                
                cmbValorbase.DataBindings.Add("EditValue", Negociacion, nameof(Negociacion.IDArancelValoriza));
                datImpacto.DataBindings.Add("EditValue", Negociacion, nameof(Negociacion.FechaImpacto));
                cmbAgrupadorval.DataBindings.Add("EditValue", Negociacion, nameof(Negociacion.AgrupadorID));

                SetHabilitacion();
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}.Hubo un inconveniente al asignar la fuente de datos.\n{e.Message}", 1);
                return;
            }
        }

        private void SetHabilitacion()
        {
            bool habilita = Negociacion.IDRegistro > 0 ? false : true;
            datInicio.Enabled = habilita;
            cmbValorbase.Enabled = habilita;
            datImpacto.Enabled = Negociacion.Estado > 0 ? false : true;
            cmbAgrupadorval.Enabled = habilita;
        }

        private void ParametrosInicio()
        {
            SqlConnection = SqlConnection.State == ConnectionState.Open ? SqlConnection : cnb.Conectar();

            datImpacto.Properties.NullDate = DateTime.MinValue;
            datImpacto.Properties.NullText = string.Empty;
            datInicio.Properties.NullDate = DateTime.MinValue;
            datInicio.Properties.NullText = string.Empty;

            cmbValorbase.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            cmbValorbase.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";

            CargaCombos();

        }

        private void CargaCombos(short cm = 0)
        {
            try
            {
                //VALORES BASE
                if (cm == 0 || cm == 1)
                {
                    Aranceles.MC.Arancel a = new Aranceles.MC.Arancel(SqlConnection);
                    List<Aranceles.MC.Arancel> aranlist = a.GetRegistros().Where(w => w.Estado).OrderByDescending(o => o.Fecha).ToList();
                                        
                    cmbValorbase.Properties.DataSource = aranlist;
                }

                //AGRUPADOR DE VALORES
                if (cm == 0 || cm == 2)
                {
                    MC.AgrupadorInfo a = new MC.AgrupadorInfo();
                    List<MC.AgrupadorInfo> lista = a.GetRegistros();

                    cmbAgrupadorval.Properties.DataSource = lista.OrderBy(o => o.Descripcion).ToList();
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo un inconveniente al cargar las listas de datos.\n{e.Message}", 1);
                return;
            }
        }

        //ASIGNO LAS PRESTADORAS ASOCIADAS A ESE AGRUPADOR DE VALOR
        private void SetPrestadoraslst()
        {
            try
            {
                MC.AgrupadorInfo a = cmbAgrupadorval.GetSelectedDataRow() as MC.AgrupadorInfo;

                gridView.BeginDataUpdate();
                if (Negociacion.IDRegistro > 0) { gridControl.DataSource = a.PrestatariasHisto.Where(w => w.IDEncabezado == Negociacion.IDRegistro).ToList(); }
                else { gridControl.DataSource = a.Prestatarias; }                
                gridView.EndDataUpdate();                
            }
            catch (Exception)
            {

            }
        }

        private void Usr_Encabezado_Load(object sender, EventArgs e)
        {
            ParametrosInicio();
        }

        private void cmbAgrupadorval_TextChanged(object sender, EventArgs e)
        {
            SetPrestadoraslst();
        }
    }
}
