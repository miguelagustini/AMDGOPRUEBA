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
    public class CuentaCorriente: INotifyPropertyChanged
    {
        //REFERENCIAS A CLASES DE USO
        #region REFERENCIAS A CLASES
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();
        #endregion

        #region PROPIEDADES
                
        private string _periodo = "";
        private string _cuentacodigo = "";
        private string _profname = "";
        private int _cuentaid = 0;
        private decimal _netoparcial = 0;
        private decimal _totcreditosos = 0;
        private decimal _totdebitosos = 0;
        private decimal _totalfinal = 0;


        public string PagoPeriodo { get { return _periodo; } set { _periodo = _periodo != value.Trim() ? value.Trim() : _periodo; } }
        public string PrestadorCuentaCodigo { get { return _cuentacodigo; } set { _cuentacodigo = _cuentacodigo != value.Trim() ? value.Trim() : _cuentacodigo; } }
        public string PrestadorNombre { get { return _profname; } set { _profname = _profname != value.Trim() ? value.Trim() : _profname; } }
        public int PrestadorCuentaID { get { return _cuentaid; } set { _cuentaid = _cuentaid != value ? value : _cuentaid; } }
        public decimal ImporteCreditos { get { return _totcreditosos; } set { _totcreditosos = _totcreditosos != value ? value : _totcreditosos; } }
        public decimal ImporteDebitos { get { return _totdebitosos; } set { _totdebitosos = _totdebitosos != value ? value : _totdebitosos; } }
        public decimal ImporteDescuentos { get { return DescuentosAmMgm.Sum(s => s.ImporteTotal); } }
        public decimal ImporteNetoParcial { get { return _netoparcial; } set { _netoparcial = _netoparcial != value ? value : _netoparcial; } }
        public decimal ImporteTotal { get { return _totalfinal; } set { _totalfinal = _totalfinal != value ? value : _totalfinal; } }
        

        public virtual List<DescuentosAmMgm> DescuentosAmMgm { get; set; } =  new List<DescuentosAmMgm>();
        public virtual List<CreditosPrestatarias> CreditosPrestatarias { get; set; } = new List<CreditosPrestatarias>();
        public virtual List<DebitosPrestatarias> DebitosPrestatarias { get; set; } = new List<DebitosPrestatarias>();
                
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        public CuentaCorriente() { }

        public CuentaCorriente(SqlConnection conexion) { SqlConnection = conexion; }

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
        public CuentaCorriente Clone()
        {
            CuentaCorriente d = (CuentaCorriente)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<CuentaCorriente> Clone(List<CuentaCorriente> lst)
        {
            List<CuentaCorriente> lista = new List<CuentaCorriente>();

            foreach (CuentaCorriente d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO LISTA 
        #region CONSULTA DE DATOS

        public List<CuentaCorriente> GetRegistros()
        {
            try
            {
                List<CuentaCorriente> lista = new List<CuentaCorriente>();
                lista.AddRange(GetResumen());
                                
                CreditosPrestatarias cr = new CreditosPrestatarias(SqlConnection);
                BindingList<CreditosPrestatarias> crlst = new BindingList<CreditosPrestatarias>(cr.GetRegistros(PrestadorCuentaID));

                DebitosPrestatarias cd = new DebitosPrestatarias(SqlConnection);
                BindingList<DebitosPrestatarias> cdlst = new BindingList<DebitosPrestatarias>(cd.GetRegistros(PrestadorCuentaID));

                DescuentosAmMgm des = new DescuentosAmMgm();
                List<DescuentosAmMgm> deslst = des.GetRegistros(PrestadorCuentaID);

                foreach (CuentaCorriente c in lista)
                {
                    c.CreditosPrestatarias = cr.Clone(crlst.Where(w => w.PeriodoPago == c.PagoPeriodo).ToList());
                    c.DescuentosAmMgm = des.Clone(deslst.Where(w => w.PagoPeriodo == c.PagoPeriodo).ToList());

                    c.DebitosPrestatarias = cd.Clone(cdlst.Where(w => w.PeriodoPago == c.PagoPeriodo).ToList());
                }

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name} Hubo inconvenientes al obtener los registros.\n{e.Message}", 1);
                return new List<CuentaCorriente>();
            }
        }

        private List<CuentaCorriente> GetResumen()
        {
            try
            {
                List<CuentaCorriente> lista = new List<CuentaCorriente>();

                string c = $"SELECT AU.IMPUPAGO AS PagoPeriodo, AU.IMPULABO  AS PrestadorCuentaCodigo, ISNULL(PC.ID_Registro,0) AS PrestadorCuentaID," +
                           $" SUM(ISNULL(AU.IMPUNETB,0)) AS ImporteNetoParcial, SUM(ISNULL(AU.INFOCRED, 0)) AS ImporteCreditos, SUM(ISNULL(INFODNEG, 0)) AS ImporteDebitos," +
                           $" SUM(ISNULL(AU.INFONETF, 0)) AS ImporteTotal, ISNULL(PF.Nombre,'') AS PrestadorNombre" +
                           $" FROM AmdgoSis.dbo.ASOCIMPU AU" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = AU.IMPULABO)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" WHERE PC.ID_Registro = {PrestadorCuentaID}" +
                           $" GROUP BY AU.IMPUPAGO, AU.IMPULABO , PC.ID_Registro, PF.Nombre" +
                           $" ORDER BY AU.IMPUPAGO DESC";

                //OBTENGO LA TABLA
                ConexionBD cnb = new ConexionBD();

                //OBTENGO LA TABLA
                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State != ConnectionState.Open ? cnb.Conectar() : SqlConnection))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<CuentaCorriente>(rdr));
                }

                cnb.Desconectar();

                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"Ocurrió un error al consultar las cuentas.\n{e.Message}", 0);
                return new List<CuentaCorriente>();
            }
        }

        #endregion
    }
}
