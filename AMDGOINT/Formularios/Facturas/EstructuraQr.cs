using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Facturas
{
    [Serializable]
    public class EstructuraQr
    {
        private int _ver = 1;
        private string _fecha = "";
        private long _cuit = 0;
        private int _pventa = 0;
        private int _tipocomp = 0;
        private long _nrocomp = 0;
        private decimal _importe = 0;
        private string _moneda = "PES";
        private decimal _ctz = 1;
        private int _tipodocrec = 80;
        private long _nrodocrec = 0;
        private string _tipocodaut = "E";
        private long _codaut = 0;

        public int ver
        {
            get { return _ver; }
            set { _ver = _ver != value ? value : ver; }
        }

        public string fecha
        {
            get { return _fecha; }
            set { _fecha = _fecha != value ? value : _fecha; }
        }

        public long cuit
        {
            get { return _cuit; }
            set { _cuit = _cuit != value ? value : _cuit; }
        }

        public int ptoVta
        {
            get { return _pventa; }
            set { _pventa = _pventa != value ? value : _pventa; }
        }

        public int tipoCmp
        {
            get { return _tipocomp; }
            set { _tipocomp = _tipocomp != value ? value : _tipocomp; }
        }

        public long nroCmp
        {
            get { return _nrocomp; }
            set { _nrocomp = _nrocomp != value ? value : _nrocomp; }
        }

        public decimal importe
        {
            get { return _importe; }
            set { _importe = _importe != value ? value : _importe; }
        }

        public string moneda
        {
            get { return _moneda; }
            set { _moneda = _moneda != value.Trim() ? value.Trim() : _moneda; }
        }

        public decimal ctz
        {
            get { return _ctz; }
            set { _ctz = _ctz != value ? value : _ctz; }
        }

        public int tipoDocRec
        {
            get { return _tipodocrec; }
            set { _tipodocrec = _tipodocrec != value ? value : _tipodocrec; }
        }

        public long nroDocRec
        {
            get { return _nrodocrec; }
            set { _nrodocrec = _nrodocrec != value ? value : _nrodocrec; }
        }

        public string tipoCodAut
        {
            get { return _tipocodaut; }
            set { _tipocodaut = _tipocodaut != value ? value : _tipocodaut; }
        }

        public long codAut
        {
            get { return _codaut; }
            set { _codaut = _codaut != value ? value : _codaut; }
        }


        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public EstructuraQr() { }

        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public EstructuraQr Clone()
        {
            EstructuraQr d = (EstructuraQr)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<EstructuraQr> Clone(List<EstructuraQr> lst)
        {
            List<EstructuraQr> lista = new List<EstructuraQr>();

            foreach (EstructuraQr d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion
    }
}
