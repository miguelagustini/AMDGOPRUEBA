using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class LiquidacionAmbulatoria : INotifyPropertyChanged
    {

        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE

        public DateTime PracticaFecha { get; set; } = DateTime.MinValue;
        public string PracticaFuncion { get; set; } = "";
        public string PracticaCodigo { get; set; } = "";
        public string PracticaDescripcion { get; set; } = "";
        public string PracticaCompleta { get { return PracticaCodigo + " " + PracticaDescripcion; } }
        public string PrestadorCobraCodigo { get; set; } = "";
        public string PrestadorCobraNombre { get; set; } = "";
        public string PrestadorCobraCompleto{ get { return PrestadorCobraCodigo + " " + PrestadorCobraNombre; } }
        public string PrestadorEfectorCodigo { get; set; } = "";
        public string PrestadorEfectorNombre { get; set; } = "";
        public string PrestadorEfectorCompleto { get { return PrestadorEfectorCodigo + " " + PrestadorEfectorNombre; } }
        public int PrestadorEfectorIDIva { get; set; } = 0;
        public string PacienteDocumento { get; set; } = "";
        public string PacienteNombre { get; set; } = "";
        public string PacienteCompleto { get { return PacienteDocumento + " " + PacienteNombre; } }
        public string Comprobante { get; set; } = "";
        public decimal Cantidad { get; set; } = 0;
        public decimal ImporteHonorarios { get; set; } = 0;
        public decimal ImporteGastos { get; set; } = 0;
        public decimal ImporteMedicamentos { get; set; } = 0;
        public decimal ImporteNeto { get; set; } = 0;
        public decimal ImporteIva { get; set; } = 0;
        public decimal ImporteTotal { get; set; } = 0;

        public string PrestadoraCodigo { get; set; } = "";
        public string PrestadoraNombre { get; set; } = "";
        public string PrestadoraCompleta { get { return PrestadoraCodigo + " " + PrestadoraNombre; } }
        public long PrestadoraCuit { get; set; } = 0;

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public LiquidacionAmbulatoria() { }

        public LiquidacionAmbulatoria(SqlConnection conexion)
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
        public LiquidacionAmbulatoria Clone()
        {
            LiquidacionAmbulatoria d = (LiquidacionAmbulatoria)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<LiquidacionAmbulatoria> Clone(List<LiquidacionAmbulatoria> lst)
        {
            List<LiquidacionAmbulatoria> lista = new List<LiquidacionAmbulatoria>();

            foreach (LiquidacionAmbulatoria d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<LiquidacionAmbulatoria> GetRegistrosAmbulatorioPrestataria(string prestcodigo, List<string> periodos, short tipoimpresion)
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<LiquidacionAmbulatoria> lista = new List<LiquidacionAmbulatoria>();

                //DEFINO EL PARAMETRO DE BUSQUEDA DE PERIODO (TIPO FACTURACION, ORIGEN DE PRACTICA Y FECHA)
                string orcondicional = "";
                periodos.ForEach(f => orcondicional += orcondicional.Length > 0 ? " OR MED.MED2MESA = '" + f + "'" : "MED.MED2MESA = '" + f + "'");

                string c = "";
                if (tipoimpresion == 0) //IMPRESION PARA PRESTADORA
                {
                    c = $"SELECT" +
                        $" SC.PrestadoraCodigo," + 
                        $" SC.PrestadoraNombre," +
                        $" SC.PrestadoraCuit," +
                        $" SC.PracticaFecha," +                        
                        $" SC.PrestadorEfectorCodigo," +
                        $" SC.PrestadorEfectorNombre," +                        
                        $" SC.PrestadorEfectorIDIva," +
                        $" SC.PracticaCodigo," +
                        $" SC.PracticaDescripcion, " +
                        $" SC.PacienteDocumento," +
                        $" SC.PacienteNombre," +
                        $" SC.Comprobante," +
                        $" SC.PracticaFuncion," +
                        $" SC.Cantidad," +
                        $" SUM(SC.ImporteHonorarios) AS ImporteHonorarios," +
                        $" SUM(SC.ImporteGastos) AS ImporteGastos," +
                        $" SUM(SC.ImporteMedicamentos) AS ImporteMedicamentos," +
                        $" SUM(SC.ImporteNeto) AS ImporteNeto," +
                        $" SUM(SC.ImporteIva) AS ImporteIva," +
                        $" SUM(SC.ImporteTotal) AS ImporteTotal" +
                        $" FROM" +
                        $" (SELECT MED.MED2COOB AS PrestadoraCodigo, PR.Nombre AS PrestadoraNombre, PR.Cuit AS PrestadoraCuit," +
                        $" CONVERT(datetime, MED.MED2FEPR, 105) AS PracticaFecha, ISNULL(MED.MED2CPRO, '') AS PrestadorEfectorCodigo," +
                        $" ISNULL(PCE.Descripcion, '') AS PrestadorEfectorNombre, ISNULL(PFE.ID_Iva, 0) AS PrestadorEfectorIDIva, ISNULL(LTRIM(RTRIM(MED.MED2PRAC)), '') AS PracticaCodigo," +
                        $" ISNULL(LTRIM(RTRIM(MED.med2pnom)), '') as PracticaDescripcion, ISNULL(LTRIM(RTRIM(MED.MED2PACI)), '') as PacienteNombre," +
                        $" ISNULL(MED.MED2DOCU, '') as PacienteDocumento, ISNULL(MED.MED2COMP, '') AS Comprobante," +
                        $" IIF((MED.MED2PRAC LIKE '34%' OR MED.MED2PRAC LIKE '1501%' OR MED.MED2PRAC LIKE '18%' OR MED.MED2FUNC = '99') OR(ISNULL(COUNT(DISTINCT(CHECKSUM(MED.MED2PRAC, MED.MED2FUNC))), 1) <= 1), '', MED.MED2FUNC) AS PracticaFuncion," +
                        $" IIF(MED.MED2PRAC LIKE '34%' OR MED.MED2PRAC LIKE '1501%' OR MED.MED2PRAC LIKE '18%' OR MED.MED2FUNC = '99', SUM(MED.MED2CANT) / ISNULL(COUNT(DISTINCT(CHECKSUM(MED.MED2PRAC, MED.MED2FUNC))), 1), SUM(MED.MED2CANT)) AS Cantidad," +
                        $" SUM(MED.MED2HONO) AS ImporteHonorarios, SUM(MED.MED2GAST) AS ImporteGastos," +
                        $" SUM(MED.MED2MEDI) AS ImporteMedicamentos, SUM(MED.MED2NETO) AS ImporteNeto, SUM(MED.MED21IVA) AS ImporteIva, SUM(MED.MED2TOTA) AS ImporteTotal" +
                        $" FROM AmdgoSis.dbo.ASOCMED2 MED" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PCE ON(PCE.Codigo = MED.MED2CPRO)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PFE ON(PFE.ID_Registro = PCE.ID_Profesional)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = MED.MED2COOB)" +
                        $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                        $" WHERE ({orcondicional}) AND (MED.MED2FACT = '3' OR MED.MED2FACT = '8') " + (!string.IsNullOrEmpty(prestcodigo) ? $" AND MED.MED2COOB = '{prestcodigo}'" : "") +
                        $" GROUP BY MED.MED2COOB, PR.Nombre, PR.Cuit, MED.MED2MESA, MED.MED2FEPR, MED.MED2CPRO, PCE.Descripcion, PFE.ID_Iva, MED.MED2PRAC, MED.med2pnom, MED.MED2PACI, MED.MED2DOCU, MED.MED2COMP , MED.MED2FUNC)" +
                        $" AS SC" +
                        $" GROUP BY SC.PrestadoraCodigo, SC.PrestadoraNombre, SC.PrestadoraCuit, SC.PracticaFecha, SC.PrestadorEfectorCodigo, SC.PrestadorEfectorNombre, SC.PrestadorEfectorIDIva," +
                        $" SC.PracticaCodigo, SC.PracticaDescripcion, SC.PacienteDocumento, SC.PacienteNombre, SC.Comprobante, SC.PracticaFuncion, SC.Cantidad";

                }
                else //IMPRESION INTERNA
                {
                     c = $"SELECT" +
                         $" MED.MED2COOB AS PrestadoraCodigo, PR.Nombre AS PrestadoraNombre, PR.Cuit AS PrestadoraCuit," +
                         $" CONVERT(datetime, MED.MED2FEPR, 105) AS PracticaFecha," +
                         $" ISNULL(MED.MED2PCOB,'') AS PrestadorCobraCodigo," +
                         $" ISNULL(PCC.Descripcion, '') AS PrestadorCobraNombre," +
                         $" ISNULL(MED.MED2CPRO, '') AS PrestadorEfectorCodigo," +
                         $" ISNULL(PCE.Descripcion, '') AS PrestadorEfectorNombre," +
                         $" ISNULL(LTRIM(RTRIM(MED.MED2PRAC)), '') AS PracticaCodigo," +
                         $" ISNULL(LTRIM(RTRIM(MED.med2pnom)), '') as PracticaDescripcion," +
                         $" ISNULL(LTRIM(RTRIM(MED.MED2PACI)), '') as PacienteNombre," +
                         $" ISNULL(MED.MED2DOCU, '') as PacienteDocumento," +
                         $" ISNULL(MED.MED2COMP, '') AS Comprobante," +
                         $" ISNULL(MED.MED2FUNC, '') AS PracticaFuncion," +                         
                         $" SUM(MED.MED2CANT) AS Cantidad," +
                         $" SUM(MED.MED2HONO) AS ImporteHonorarios," +
                         $" SUM(MED.MED2GAST) AS ImporteGastos," +
                         $" SUM(MED.MED2MEDI) AS ImporteMedicamentos," +
                         $" SUM(MED.MED2NETO) AS ImporteNeto," +
                         $" SUM(MED.MED21IVA) AS ImporteIva," +
                         $" SUM(MED.MED2TOTA) AS ImporteTotal" +
                         $" FROM AmdgoSis.dbo.ASOCMED2 MED" +
                         //--PROFESIONAL QUE COBRA
                         $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PCC ON(PCC.Codigo = MED.MED2PCOB)" +
                         $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PFC ON(PFC.ID_Registro = PCC.ID_Profesional)" +
                         //--PROFESIONAL EFECTOR
                         $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PCE ON(PCE.Codigo = MED.MED2CPRO)" +
                         $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PFE ON(PFE.ID_Registro = PCE.ID_Profesional)" +
                         //PRESTATARIA
                         $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = MED.MED2COOB)" +
                         $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria)" +
                         $" WHERE ({orcondicional}) AND (MED.MED2FACT = '3' OR MED.MED2FACT = '8') " + (!string.IsNullOrEmpty(prestcodigo) ? $" AND MED.MED2COOB = '{prestcodigo}'" : "") +
                         $" GROUP BY MED.MED2COOB, PR.Nombre, PR.Cuit, MED.MED2MESA, MED.MED2FEPR, MED.MED2CPRO, PCE.Descripcion, MED.MED2PRAC, MED.med2pnom, MED.MED2PACI, MED.MED2DOCU, MED.MED2COMP, MED.MED2FUNC," +
                         $" MED.MED2PCOB, PCC.Descripcion"; 
                }


                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<LiquidacionAmbulatoria>(rdr));
                }

                cnb.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<LiquidacionAmbulatoria>();
            }
        }

        #endregion


    }
}
