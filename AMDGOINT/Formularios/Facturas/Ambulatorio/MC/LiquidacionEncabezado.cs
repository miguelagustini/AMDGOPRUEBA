using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class LiquidacionEncabezado: INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE

        private List<string> _periodocompletado { get; set; } = new List<string>();        
        public List<string> ParamTipoComrpobante { get; set; } = new List<string>();

        public string Periodo { get; set; } = "";        
        public DateTime PeriodoFecha
        {
            get
            {
                if (!string.IsNullOrEmpty(Periodo))
                {                    
                    return new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
                }
                else { return DateTime.MinValue; }                

            }
        }
        public string PrestadoraCodigo { get; set; } = "";
        public string PrestadoraNombre { get; set; } = "";
        public string PrestadoraCompleta { get { return PrestadoraCodigo + " " + PrestadoraNombre; } }
        public long PrestadoraCuit { get; set; } = 0;
        public string PrestadoraIvaAbreviatura { get; set; } = "";
        public short TipoImpresion { get; set; } = 0;
        public bool SeparaRI { get; set; } = false;
        public List<LiquidacionAmbulatoria> Detalles { get; set; } = new List<LiquidacionAmbulatoria>();
        public List<LiquidacionInternacion> DetallesInternacion { get; set; } = new List<LiquidacionInternacion>();


        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public LiquidacionEncabezado() { }

        public LiquidacionEncabezado(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public LiquidacionEncabezado Clone()
        {
            LiquidacionEncabezado d = (LiquidacionEncabezado)MemberwiseClone();
            LiquidacionAmbulatoria a = new LiquidacionAmbulatoria();
            LiquidacionInternacion i = new LiquidacionInternacion();

            d.Detalles = a.Clone(Detalles);
            d.DetallesInternacion = i.Clone(DetallesInternacion);
            return d;

        }

        //CLONE CON LISTAS
        public List<LiquidacionEncabezado> Clone(List<LiquidacionEncabezado> lst)
        {
            List<LiquidacionEncabezado> lista = new List<LiquidacionEncabezado>();

            foreach (LiquidacionEncabezado d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public void GetRegistros()
        {
            try
            {
                ConformaParametrosBusqueda();

                if (ParamTipoComrpobante.Contains("1") || ParamTipoComrpobante.Contains("2") || ParamTipoComrpobante.Contains("7"))
                {
                    //AMBULATORIO
                    LiquidacionAmbulatoria det = new LiquidacionAmbulatoria(SqlConnection);
                    Detalles.Clear();
                    Detalles.AddRange(det.GetRegistrosAmbulatorioPrestataria(PrestadoraCodigo, _periodocompletado, TipoImpresion));

                    if (TipoImpresion == 0)
                    {
                        //PASO TODOS LOS MO Y EX A 0 PARA AGRUPAR RI POR UN LADO Y EL RESTO POR OTRO
                        if (SeparaRI) { Detalles.Where(w => w.PrestadorEfectorIDIva > 1).ToList().ForEach(f => f.PrestadorEfectorIDIva = 0); }
                        else { Detalles.ForEach(f => f.PrestadorEfectorIDIva = 0); }
                    }
                }
                else
                {
                    //INTERNACION
                    LiquidacionInternacion inte = new LiquidacionInternacion(SqlConnection);
                    DetallesInternacion.Clear();
                    DetallesInternacion.AddRange(inte.GetRegistrosInternacionPrestataria(PrestadoraCodigo, _periodocompletado));
                }

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return;
            }
        }

        private void ConformaParametrosBusqueda()
        {
            try
            {
                _periodocompletado.Clear();

                if (string.IsNullOrEmpty(Periodo) || ParamTipoComrpobante.Count <= 0)
                {
                    return;
                }
                else
                {
                    foreach (string t in ParamTipoComrpobante)
                    {
                        _periodocompletado.Add(Periodo + t);
                    }
                }

                return;
            }
            catch (Exception)
            {
                ctrl.MensajeInfo("No se pudo definir los parámetros de búsqueda.", 1);
                return;
            }
        }

        #endregion
    }
}
