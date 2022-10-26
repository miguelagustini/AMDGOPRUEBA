using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AMDGOINT.Formularios.AsientosContables.MC
{
    public class CierreEjercicio
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        private AsientosEnc Asiento = new AsientosEnc();
        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE        
        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private List<AsientosEnc> Asientos { get; set; } = new List<AsientosEnc>();
        private AsientosEnc NewAsientoCierre { get; set; } = new AsientosEnc();
        private AsientosEnc NewAsientoApertura { get; set; } = new AsientosEnc();
        private List<AsientosDet> Pases { get; set; } = new List<AsientosDet>();
        public string ProcesoActual { get; private set; } = string.Empty;
        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public CierreEjercicio() { }

        public CierreEjercicio(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //PROCESOS GENERALES
        #region PROCESOS GENERALES

        public Dictionary<short, string> CierraEjercicioContable()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                ProcesoActual = "Inicio del proceso";
                //LIMPIO E INSTANCIO LA LISTA DE ASIENTOS Y ENCABEZADOS
                Asientos.Clear();
                Pases.Clear();
                NewAsientoCierre = new AsientosEnc();
                NewAsientoApertura = new AsientosEnc();

                //OBTENGO LA LISTA DE ASIENTOS
                var dic = ObtieneAsientos();
                func.PreparaRetorno(retorno, dic);

                //ARMO EL GRUPO DE PASES
                if (retorno.Count <= 0)
                {
                    var r = CrearGrupoPases();
                    func.PreparaRetorno(retorno, r);
                    
                }

                //ASIENTOS Y PASES DE CIERRE / APERTURA
                if (retorno.Count <= 0)
                {
                    var r = CreaAsientosCierreApertura();
                    func.PreparaRetorno(retorno, r);

                }

                //GUARDADO
                if (retorno.Count <= 0)
                {
                    var r = AltaAsientos();
                    func.PreparaRetorno(retorno, r);

                }

                if (retorno.Count <= 0) { ProcesoActual = "Cierre del ejercicio finalizado exitosamente"; }

                return retorno;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Hubo inconvenientes en el procesamiento de cierre.\n{e.Message}", 0);
                return retorno;
            }
        }

        /// <summary>
        /// OBTENGO LA LISTA DE ASIENTOS, DESDE EL 1 DE MAYO DEL AÑO ANTERIOR, HASTA EL 30 DE ABRIL DEL AÑO CORRIENTE
        /// </summary>        
        private Dictionary<short, string> ObtieneAsientos()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            ProcesoActual = "Obtencion de los asientos del ejercicio";
            try
            {               
                Asiento.SqlConnection = SqlConnection;
                //TOMO REGISTROS DESDE EL 1 DE MAYO DEL AÑO ANTERIOR, HASTA EL 30 DE ABRIL DEL AÑO ACTUAL
                Asientos.AddRange(Asiento.GetRegistros().Where(w => w.AsientoFecha >= new DateTime(DateTime.Today.Year - 1, 5, 1) && w.AsientoFecha < new DateTime(DateTime.Today.Year, 5, 1)).ToList());

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}");
                return retorno;
            }
        }

        /// <summary>
        /// CREO LA LISTA DE PASES AGRUPADOS, LO QUE ME DA COMO RESULTADO EL SALDO DE CADA CUENTA / SUBCUENTA
        /// </summary>        
        private Dictionary<short, string> CrearGrupoPases()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            ProcesoActual = "Creación del grupo de pases";
            try
            {

                var lista = Asientos.SelectMany(s => s.Detalles)
                    .Where(w => !w.PlanCuentaCodigoLargo.StartsWith("4") && !w.PlanCuentaCodigoLargo.StartsWith("5"))
                    .GroupBy(g => new { g.PlanCuentaID, g.PlanSubCuentaID }).Select(s => new
                {
                    s.Key.PlanCuentaID,
                    s.Key.PlanSubCuentaID,
                    ImporteDebe = s.Sum(n => n.ImporteDebe),
                    ImporteHaber = s.Sum(n => n.ImporteHaber),

                });

                foreach (var v in lista)
                {
                    AsientosDet d = new AsientosDet();
                    d.PlanCuentaID = v.PlanCuentaID;
                    d.PlanSubCuentaID = v.PlanSubCuentaID;
                    d.ImporteDebe = v.ImporteDebe;
                    d.ImporteHaber = v.ImporteHaber;
                    Pases.Add(d);
                }

                return retorno;

            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}");
                return retorno;
            }
        }

        /// <summary>
        /// CREO LOS ASIENTOS Y PASES DE CIERRE Y APERTURA
        /// </summary>        
        private Dictionary<short, string> CreaAsientosCierreApertura()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();
            ProcesoActual = "Creación de asientos / pases de cierre y apertura";
            try
            {                
                decimal _diferencia = 0;
                
                //RECORRO LA AGRUPACION
                foreach (AsientosDet v in Pases)
                {
                    //DETERMINO LA DIFERENCIA ENTRE DEBE Y HABER
                    _diferencia = v.ImporteDebe - v.ImporteHaber;

                    if (_diferencia == 0) { continue; }

                    //ASIENTO DE CIERRE
                    NewAsientoCierre.Detalles.Add(new AsientosDet
                    {
                        PlanCuentaID = v.PlanCuentaID,
                        PlanSubCuentaID = v.PlanSubCuentaID,
                        Descripcion = "CIERRE DEL EJERCICIO",
                        ImporteDebe = v.ImporteDebe < v.ImporteHaber ? Math.Abs(_diferencia) : 0,
                        ImporteHaber = v.ImporteHaber < v.ImporteDebe ? Math.Abs(_diferencia) : 0                        
                    });

                    //ASIENTO DE APERTURA
                    NewAsientoApertura.Detalles.Add(new AsientosDet
                    {
                        PlanCuentaID = v.PlanCuentaID,
                        PlanSubCuentaID = v.PlanSubCuentaID,
                        Descripcion = "APERTURA DEL EJERCICIO",
                        ImporteDebe = v.ImporteDebe > v.ImporteHaber ? Math.Abs(_diferencia) : 0,
                        ImporteHaber = v.ImporteHaber > v.ImporteDebe ? Math.Abs(_diferencia) : 0                        
                    });
                }

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}");
                return retorno;
            }
        }

        /// <summary>
        /// INSERTO LOS NUEVOS ASIENTOS DE CIERRE
        /// ASIGNO LA FECHA DE CIERRE ANUAL A TODOS LOS ASIENTOS
        /// PONGO TODOS LOS NUMEROS DE ASIENTO DEL EJERCICIO ACTUAL EN CERO
        /// INSERTO LOS ASIENTOS DE APERTURA (SE INICIALIZA EN NUMERO DE ASIENTO 1)
        /// RENUMERO TODOS LOS ASIENTOS DEL EJERCICIO ACTUAL
        /// </summary>        
        private Dictionary<short, string> AltaAsientos()
        {
            //DICCIONARIO DE RETORNO
            Dictionary<short, string> retorno = new Dictionary<short, string>();

            try
            {
                //RESUMEN DE ASIENTO CIERRE                
                NewAsientoCierre.AsientoFecha = new DateTime(DateTime.Today.Year, 4, 30);
                NewAsientoCierre.Observacion = "ASIENTO DE CIERRE DEL EJERCICIO";
                NewAsientoCierre.AsientoCierre = true;

                //RESUMEN DE ASIENTO APERTURA
                NewAsientoApertura.AsientoFecha = new DateTime(DateTime.Today.Year, 5, 1);
                NewAsientoApertura.Observacion = "ASIENTO DE APERTURA DEL EJERCICIO";

                //EJECUTO ABM ASIENTOS CIERRE
                ProcesoActual = "Guardando Asiento de Cierre";
                var dic = NewAsientoCierre.Abm();
                func.PreparaRetorno(retorno, dic);
                
                //ASIGNO FECHA DE CIERRE DE EJERCICIO
                ProcesoActual = "Asignando fecha de cierre anual a los asientos del ejercicio";
                var dic1 = NewAsientoCierre.AsignoFechaCierraAnual();
                func.PreparaRetorno(retorno, dic1);

                //SETEO TODOS LOS NUMEROS DE ASIENTO A CERO PARA EL EJERCICIO ACTUAL
                ProcesoActual = "Reiniciando la numeración de asientos del nuevo ejercicio";
                var dic2 = NewAsientoApertura.ReinicioNumeracionAsientos();
                func.PreparaRetorno(retorno, dic2);

                //INSERTO ASIENTOS DE APERTURA DE EJERCICIO
                ProcesoActual = "Guardando los asientos de Apertura";
                var dic3 = NewAsientoApertura.Abm();
                func.PreparaRetorno(retorno, dic3);

                //EJECUTO LA RENUMERACION DE ASIENTOS
                ProcesoActual = "Renumerando los asientos del nuevo ejercicio";
                var dic4 = NewAsientoApertura.RenumeracionAsientos();
                func.PreparaRetorno(retorno, dic4);

                return retorno;
            }
            catch (Exception e)
            {
                retorno.Add(-1, $"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}");
                return retorno;
            }
        }

        #endregion
    }
}
