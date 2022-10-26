using AMDGOINT.Clases;
using AMDGOINT.Formularios.AsientosContables.Vista;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.AsientosContables.MC
{
    public class Impresion
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private ReporteDet DetalleExtensivo = new ReporteDet();        
        private List<ReporteDet> Detalles { get; set; } = new List<ReporteDet>();
        
        
        #endregion

        #region PROPIEDADES
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        public bool IncluirCuentasCero { get; set; } = true;        
        public DateTime FechaDesde { get; set; } = DateTime.Today;
        public DateTime FechaHasta { get; set; } = DateTime.Today;
        public int IDPlanCuenta { get; set; } = 0;
        public int IDPlanSubCuenta { get; set; } = 0;
        public string Ejercicio { get; set; } = "A";
        public short ModoImpresion { get; set; } = 0; //LIBRIO DIARIO = 1 // MAYOR DE CUENTA = 2 // BALANCE DE INTEGRACION = 3 // BALANCE MENSUAL = 4
        private decimal SaldoAnterior { get; set; } = 0;

        private List<ReporteDet> DetallesProcesados { get; set; } = new List<ReporteDet>();
        private List<CuentasContables.MC.Cuentas> CuentasContables { get; set; } = new List<CuentasContables.MC.Cuentas>();
        #endregion


        #region OBTENCION DE REGISTROS
              
        
        public bool GetRegistros()
        {
            bool retorno = true;

            try
            {
                if (FechaDesde > FechaHasta) { return false; }
                                
                Detalles.Clear();
                DetalleExtensivo.SqlConnection = SqlConnection;

                if (ModoImpresion == 1) //LIBRO DIARIO 
                {
                    try
                    {
                        Detalles.AddRange(DetalleExtensivo.GetRegistros(FechaDesde, FechaHasta, IDPlanCuenta, IDPlanSubCuenta, _histoactual: Ejercicio));
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }
                else if (ModoImpresion == 2) //MAYORIZACION DE CUENTA
                {
                    try
                    {
                        Detalles.AddRange(DetalleExtensivo.GetRegistros(FechaDesde, FechaHasta, IDPlanCuenta, IDPlanSubCuenta, false, Ejercicio));
                        DatosMayorCuenta();
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }
                else if (ModoImpresion == 3)//- BALANCE
                {
                    try
                    {
                        Detalles.AddRange(DetalleExtensivo.GetRegistros(FechaDesde, FechaHasta, IDPlanCuenta, IDPlanSubCuenta, _histoactual: Ejercicio));
                        DatosBalance();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                
                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);                
                return false;
            }
        }
        
        private void DatosMayorCuenta()
        {
            try
            {
                SaldoAnterior = Detalles.Where(w => w.AsientoFecha.Date < FechaDesde).Sum(s => s.ImporteDebe) - 
                                Detalles.Where(w => w.AsientoFecha.Date < FechaDesde).Sum(s => s.ImporteHaber);
                DetallesProcesados.Clear();
                int cont = 0;
                
                Detalles.Where(w => w.AsientoFecha.Date >= FechaDesde 
                                        && w.AsientoFecha.Date <= FechaHasta )
                    .OrderBy(o => o.AsientoNumero).ThenBy(t => t.PaseNumero).ThenBy(f => f.AsientoFecha).ToList()
                    .ForEach(f => f.IDCalculado = cont++);

                DetallesProcesados.AddRange(Detalles.Where(w => w.AsientoFecha.Date >= FechaDesde
                                                            && w.AsientoFecha.Date <= FechaHasta)
                                                    .OrderBy(o => o.AsientoNumero)
                                                    .ThenBy(t => t.PaseNumero)
                                                    .ThenBy(f => f.AsientoFecha)
                .Select(x => new ReporteDet
                {
                    AsientoNumero = x.AsientoNumero,
                    AsientoFecha = x.AsientoFecha,
                    IDRegistro = x.IDRegistro,
                    IDEncabezado = x.IDEncabezado,
                    PaseNumero = x.PaseNumero,
                    Observacion = x.Observacion,
                    Descripcion = x.Descripcion,
                    PlanCuentaID = x.PlanCuentaID,
                    PlanCuentaCodigoCorto = x.PlanCuentaCodigoCorto,
                    PlanCuentaCodigoLargo = x.PlanCuentaCodigoLargo,
                    PlanCuentaNombre = x.PlanCuentaNombre,
                    PlanSubCuentaID = x.PlanSubCuentaID,
                    PlanSubCuentaCodigoCorto = x.PlanSubCuentaCodigoCorto,
                    PlanSubCuentaNombre = x.PlanSubCuentaNombre,
                    ImporteDebe = x.ImporteDebe,
                    ImporteHaber = x.ImporteHaber,
                    Saldo = SaldoAnterior + Detalles.Where(n => n.AsientoFecha.Date >= FechaDesde && n.AsientoFecha.Date <= x.AsientoFecha && n.IDCalculado <= x.IDCalculado)
                                            .OrderBy(o => o.AsientoNumero).ThenBy(t => t.PaseNumero).ThenBy(f => f.AsientoFecha)
                                            .Sum(z => z.ImporteDebe - z.ImporteHaber)

                }).ToList());
             
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al conformar los encabezados.\n{e.Message}", 0);
                return;
            }
        }

        private void DatosBalance()
        {
            try
            {
                //OBTENGO EL PLAN DE CUENTAS
                CuentasContables.MC.Cuentas cuentas = new CuentasContables.MC.Cuentas(SqlConnection);
                CuentasContables.Clear();
                CuentasContables.AddRange(cuentas.GetRegistros());

                //ASIGNO LOS VALORES DEBE Y HABER 
                DetallesProcesados.Clear();
                DetallesProcesados.AddRange(Detalles.Where(w => !w.AsientoCierre).GroupBy(g => new { g.PlanCuentaID }).Select(s => new ReporteDet
                {  
                    PlanCuentaID = s.First().PlanCuentaID,                    
                    ImporteDebe = s.Sum(d => d.ImporteDebe),
                    ImporteHaber = s.Sum(h => h.ImporteHaber)                    
                }).ToList());

                foreach (CuentasContables.MC.Cuentas c in CuentasContables)
                {
                    c.ImporteDebe = DetallesProcesados.Where(w => w.PlanCuentaID == c.IDRegistro).Sum(s => s.ImporteDebe);
                    c.ImporteHaber = DetallesProcesados.Where(w => w.PlanCuentaID == c.IDRegistro).Sum(s => s.ImporteHaber);
                } 

            
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return ;
            }
        }

        public void MuestraReporte()
        {
            try
            {

                XtraReport rpt = null;

                switch (ModoImpresion)
                {
                    case 1:
                        rpt = new Xrpt_LibroAsientos();
                        rpt.DataSource = Detalles;
                        break;

                    case 2:
                        rpt = new Xrpt_MayorCuenta();
                        rpt.Parameters["SaldoAnterior"].Value = SaldoAnterior;
                        rpt.Parameters["FechaDesde"].Value = FechaDesde;
                        rpt.Parameters["FechaHasta"].Value = FechaHasta;                        
                        rpt.DataSource = DetallesProcesados;
                        break;

                    case 3:
                        rpt = new Xrpt_Balance();
                        rpt.Parameters["FechaDesde"].Value = FechaDesde;
                        rpt.Parameters["FechaHasta"].Value = FechaHasta;                        
                        rpt.Parameters["InlcuirCuentasCero"].Value = IncluirCuentasCero;
                        rpt.DataSource = CuentasContables;
                        break;
                }

                if (rpt != null)
                {
                    
                    ReportPrintTool printTool = new ReportPrintTool(rpt);
                    printTool.ShowPreviewDialog();
                    printTool.Dispose();
                    rpt.Dispose();
                }
                
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un inconveniente al moestrar el reporte.\n{e.Message}", 1);
                return;
            }
        }

        #endregion
    }
}
