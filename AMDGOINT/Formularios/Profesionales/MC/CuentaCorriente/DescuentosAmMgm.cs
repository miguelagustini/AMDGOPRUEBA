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
    public class DescuentosAmMgm: INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        #region PROPIEDADES

        private int _idcuenta = 0;
        private string _cuentacodigo = "";
        private string _periodo = "";
        private DateTime _fecha = DateTime.MinValue;
        private string _codigoretiro = "";
        private string _descrretiro = "";
        private byte _debitocredito = 1;
        private decimal _total = 0;
        private string _observacion = "";

        public int PrestadorCuentaID { get { return _idcuenta; } set { _idcuenta = _idcuenta != value ? value : _idcuenta; } }
        public string PrestadorCuentaCodigo { get { return _cuentacodigo; } set { _cuentacodigo = _cuentacodigo != value.Trim() ? value.Trim() : _cuentacodigo; } }
        public string PagoPeriodo { get { return _periodo; } set { _periodo = _periodo != value.Trim() ? value.Trim() : _periodo; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = _fecha != value ? value : _fecha; } }
        public string RetiroCodigo { get { return _codigoretiro; } set { _codigoretiro = _codigoretiro != value.Trim() ? value.Trim() : _codigoretiro; } }
        public string RetiroDescripcion { get { return _descrretiro; } set { _descrretiro = _descrretiro != value.Trim() ? value.Trim() : _descrretiro; } }
        public byte MovimientoTipo { get { return _debitocredito; } set { _debitocredito = _debitocredito != value ? value : _debitocredito; } }
        public string MovimientoTipoDescripcion { get { return MovimientoTipo == 2 ? "Crédito" : "Débito"; } }
        public decimal ImporteTotal { get { return _total; } set { _total = _total != value ? value : _total; } }
        public string Observacion { get { return _observacion; } set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; } }

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public DescuentosAmMgm() { }

        public DescuentosAmMgm(SqlConnection conexion) { SqlConnection = conexion; }

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
        public DescuentosAmMgm Clone()
        {
            DescuentosAmMgm d = (DescuentosAmMgm)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<DescuentosAmMgm> Clone(List<DescuentosAmMgm> lst)
        {
            List<DescuentosAmMgm> lista = new List<DescuentosAmMgm>();

            foreach (DescuentosAmMgm d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }
        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS
        public List<DescuentosAmMgm> GetRegistros(int prestadorctaid)
        {
            try
            {
                List<DescuentosAmMgm> lista = new List<DescuentosAmMgm>();

                string c = $"SELECT ISNULL(retipago, '') as PagoPeriodo, retifech as Fecha, ISNULL(RC.Codigo, '') AS RetiroCodigo, ISNULL(RC.Descripcion, '') as RetiroDescripcion," +
                           $" CAST(ISNULL(retitiop, 1) AS TINYINT) as MovimientoTipo, ISNULL(retiimpo, 0) as ImporteTotal, ISNULL(retiobse, '') as Observacion, ISNULL(PC.Codigo, '') AS PrestadorCuentaCodigo," +
                           $" ISNULL(PC.ID_Registro, 0) AS PrestadorCuentaID" +
                           $" FROM AmdgoSis.dbo.SISTRETI" +
                           $" LEFT OUTER JOIN AmdgoContable.dbo.rt_RETIROCONCEPTOS RC on(RC.Codigo = ltrim(rtrim(reticore)))" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC on(PC.Codigo = LTRIM(RTRIM(reticome)))" +
                           $" WHERE PC.ID_Registro = {prestadorctaid}";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DescuentosAmMgm>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<DescuentosAmMgm>();
            }
        }

        #endregion
    }
}
