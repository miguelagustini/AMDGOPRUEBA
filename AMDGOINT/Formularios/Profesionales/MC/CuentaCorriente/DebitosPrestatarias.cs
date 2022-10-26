using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Profesionales.MC.CuentaCorriente
{
    public class DebitosPrestatarias
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
        private string _periodorecupero = "";
        private string _motivodesc = "";
        private string _motivoobse = "";
        private DateTime _fechapago = DateTime.MinValue;        
        private decimal _importetotal = 0;
        private byte _movimientotipo = 0;

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        public int PrestadorCuentaID { get { return _prestadorid; } set { _prestadorid = _prestadorid != value ? value : _prestadorid; } }
        public string PrestadorCuentaCodigo { get { return _prestadorcodigo; } set { _prestadorcodigo = _prestadorcodigo != value.Trim() ? value.Trim() : _prestadorcodigo; } }
        public string PeriodoFacturacion { get { return _periodofacturacion; } set { _periodofacturacion = _periodofacturacion != value.Trim() ? value.Trim() : _periodofacturacion; } }
        public string PeriodoPago { get { return _periodopago; } set { _periodopago = _periodopago != value.Trim() ? value.Trim() : _periodopago; } }
        public string PeriodoPagoQuincena { get { return _periodopagoquin; } set { _periodopagoquin = _periodopagoquin != value.Trim() ? value.Trim() : _periodopagoquin; } }
        public string PeriodoRecupero { get { return _periodorecupero; } set { _periodorecupero = _periodorecupero != value.Trim() ? value.Trim() : _periodorecupero; } }
        public DateTime FechaPago { get { return _fechapago; } set { _fechapago = _fechapago != value ? value : _fechapago; } }
        public int PrestatariaCuentaID { get { return _perstatariactaid; } set { _perstatariactaid = _perstatariactaid != value ? value : _perstatariactaid; } }
        public string PrestatariaCuentaCodigo { get { return _prestatariacodigo; } set { _prestatariacodigo = _prestatariacodigo != value.Trim() ? value.Trim() : _prestatariacodigo; } }
        public string PrestatariaCuentaAbreviatura { get { return _prestatariactaabrevia; } set { _prestatariactaabrevia = _prestatariactaabrevia != value.Trim() ? value.Trim() : _prestatariactaabrevia; } }
        public string MotivoDebitoDescripcion { get { return _motivodesc; } set { _motivodesc = _motivodesc != value.Trim() ? value.Trim() : _motivodesc; } }
        public string MotivoDebitoObservacion { get { return _motivoobse; } set { _motivoobse = _motivoobse != value.Trim() ? value.Trim() : _motivoobse; } }

        public decimal ImporteTotal { get { return _importetotal; } set { _importetotal = _importetotal != value ? value : _importetotal; } }        
        public byte MovimientoTipo { get { return _movimientotipo; } set { _movimientotipo = _movimientotipo != value ? value : _movimientotipo; } }
        public string MovimientoDescripcion { get { return MovimientoTipo == 2 ? "Recupero" : "Débito"; } }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public DebitosPrestatarias() { }

        public DebitosPrestatarias(SqlConnection conexion) { SqlConnection = conexion; }

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
        public DebitosPrestatarias Clone()
        {
            DebitosPrestatarias d = (DebitosPrestatarias)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<DebitosPrestatarias> Clone(List<DebitosPrestatarias> lst)
        {
            List<DebitosPrestatarias> lista = new List<DebitosPrestatarias>();

            foreach (DebitosPrestatarias d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        public BindingList<DebitosPrestatarias> Clone(BindingList<DebitosPrestatarias> lst)
        {
            BindingList<DebitosPrestatarias> lista = new BindingList<DebitosPrestatarias>();

            foreach (DebitosPrestatarias d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS
        public List<DebitosPrestatarias> GetRegistros(int prestadorctaid)
        {
            try
            {
                List<DebitosPrestatarias> lista = new List<DebitosPrestatarias>();

                string c = $"SELECT ISNULL(PC.ID_Registro, 0) AS PrestadorCuentaID, ISNULL(PC.Codigo, '') AS PrestadorCuentaCodigo," +
                           $" ISNULL(PD.ID_Registro, 0) AS PrestatariaCuentaID, ISNULL(PD.Codigo, '') AS PrestatariaCuentaCodigo," +
                           $" ISNULL(PD.Abreviatura, '') AS PrestatariaCuentaAbreviatura," +
                           $" CAST(ISNULL(SB.OBAJRECU, 0) AS VARCHAR(6)) AS PeriodoRecupero, ISNULL(SB.OBAJFACT, '') AS PeriodoFacturacion, ISNULL(SB.OBAJPAGO, '') AS PeriodoPago," +
                           $" ISNULL(SB.OBAJPERE, '') AS PeriodoPagoQuincena, SB.OBAJFEAC AS FechaPago," +
                           $" ISNULL(SB.OBAJDEBD, '') AS MotivoDebitoDescripcion, ISNULL(SB.OBAJOBSE, '') AS MotivoDebitoObservacion," +
                           $" ISNULL(SB.OBAJIMPO, 0) AS ImporteTotal, CAST(ISNULL(SB.OBAJTIOP, 1) AS tinyint) AS MovimientoTipo" +
                           $" FROM AmdgoSis.dbo.SISTOBAJ SB" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = SB.OBAJCOPR)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PRESTDETALLES PD ON(PD.Codigo = SB.OBAJOBSO)" +
                           $" WHERE PC.ID_Registro = {prestadorctaid}";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DebitosPrestatarias>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<DebitosPrestatarias>();
            }
        }

        #endregion
    }
}
