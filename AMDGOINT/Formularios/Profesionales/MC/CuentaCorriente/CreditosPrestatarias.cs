using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Profesionales.MC.CuentaCorriente
{
    public class CreditosPrestatarias : INotifyPropertyChanged
    {

        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        #region PROPIEDADES

        private int _prestadorid = 0;
        private string _prestadorcodigo = "";
        private string _periodofacturacion = "";
        private int _perstatariactaid = 0;
        private string _prestatariacodigo = "";
        private string _prestatariactaabrevia = "";
        private string _periodopago = "";
        private string _periodopagoquin = "";
        private DateTime _fechapago = DateTime.MinValue;
        private decimal _porcpago = 0;
        private decimal _importeneto = 0;
        private decimal _importeiva = 0;
        private decimal _importetotal = 0;
        private decimal _importeintereses = 0;
        private byte _movimientotipo = 0;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public int PrestadorCuentaID { get { return _prestadorid; } set { _prestadorid = _prestadorid != value ? value : _prestadorid; } }
        public string PrestadorCuentaCodigo { get { return _prestadorcodigo; } set { _prestadorcodigo = _prestadorcodigo != value.Trim() ? value.Trim() : _prestadorcodigo; } }
        public string PeriodoFacturacion { get { return _periodofacturacion; } set { _periodofacturacion = _periodofacturacion != value.Trim() ? value.Trim() : _periodofacturacion; } }
        public string PeriodoPago { get { return _periodopago; } set { _periodopago = _periodopago != value.Trim() ? value.Trim() : _periodopago; } }
        public string PeriodoPagoQuincena { get { return _periodopagoquin; } set { _periodopagoquin = _periodopagoquin != value.Trim() ? value.Trim() : _periodopagoquin; } }
        public DateTime FechaPago { get { return _fechapago; } set { _fechapago = _fechapago != value ? value : _fechapago; } }
        public int PrestatariaCuentaID { get { return _perstatariactaid; } set { _perstatariactaid = _perstatariactaid != value ? value : _perstatariactaid; } }
        public string PrestatariaCuentaCodigo { get { return _prestatariacodigo; } set { _prestatariacodigo = _prestatariacodigo != value.Trim() ? value.Trim() : _prestatariacodigo; } }
        public string PrestatariaCuentaAbreviatura { get { return _prestatariactaabrevia; } set { _prestatariactaabrevia = _prestatariactaabrevia != value.Trim() ? value.Trim() : _prestatariactaabrevia; } }
        public decimal PagoPorcentaje { get { return _porcpago; } set { _porcpago = _porcpago != value ? value : _porcpago; } }
        public decimal PagoImporteNeto { get { return _importeneto; } set { _importeneto = _importeneto != value ? value : _importeneto; } }
        public decimal PagoImporteIva { get { return _importeiva; } set { _importeiva = _importeiva != value ? value : _importeiva; } }
        public decimal PagoImporteTotal { get { return _importetotal; } set { _importetotal = _importetotal != value ? value : _importetotal; } }
        public decimal PagoImporteIntereses { get { return _importeintereses; } set { _importeintereses = _importeintereses != value ? value : _importeintereses; } }
        public byte MovimientoInteresTipo { get { return _movimientotipo; } set { _movimientotipo = _movimientotipo != value ? value : _movimientotipo; } }
        public string MovimientoDescripcion { get { return MovimientoInteresTipo == 2 ? "Crédito" : "Débito"; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public CreditosPrestatarias() { }

        public CreditosPrestatarias(SqlConnection conexion) { SqlConnection = conexion; }

        #endregion

        #region PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        //CLONE 
        #region CLONACION
        public CreditosPrestatarias Clone()
        {
            CreditosPrestatarias d = (CreditosPrestatarias)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<CreditosPrestatarias> Clone(List<CreditosPrestatarias> lst)
        {
            List<CreditosPrestatarias> lista = new List<CreditosPrestatarias>();

            foreach (CreditosPrestatarias d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        
        public BindingList<CreditosPrestatarias> Clone(BindingList<CreditosPrestatarias> lst)
        {
            BindingList<CreditosPrestatarias> lista = new BindingList<CreditosPrestatarias>();

            foreach (CreditosPrestatarias d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS
        public List<CreditosPrestatarias> GetRegistros(int prestadorctaid)
        {
            try
            {
                List<CreditosPrestatarias> lista = new List<CreditosPrestatarias>();

                string c = $"SELECT ISNULL(PC.ID_Registro, 0) AS PrestadorCuentaID, ISNULL(PC.Codigo, '') AS PrestadorCuentaCodigo, SF.factperi AS PeriodoFacturacion," +
                           $" ISNULL(PD.ID_Registro, 0) AS PrestatariaCuentaID, ISNULL(PD.Codigo, '') AS PrestatariaCuentaCodigo, ISNULL(PD.Abreviatura, '') AS PrestatariaCuentaAbreviatura," +
                           $" ISNULL(SF.factpago, '') AS PeriodoPago, ISNULL(SF.factpere, '') as PeriodoPagoQuincena, SF.factfepa AS FechaPago," +
                           $" ISNULL(SF.factporp, 0) AS PagoPorcentaje, SF.facttopa AS PagoImporteNeto, SF.facttiva AS PagoImporteIva, SF.factimpa AS PagoImporteTotal," +
                           $" CAST(ISNULL(SF.factinte, 2) AS tinyint) AS MovimientoInteresTipo, SF.factintp AS PagoImporteIntereses" +
                           $" FROM AmdgoSis.dbo.SISTFACT SF" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = SF.FACTCOPR)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = SF.factcobr)" +
                           $" WHERE PC.ID_Registro = {prestadorctaid}";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<CreditosPrestatarias>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<CreditosPrestatarias>();
            }
        }

        #endregion
    }
}
