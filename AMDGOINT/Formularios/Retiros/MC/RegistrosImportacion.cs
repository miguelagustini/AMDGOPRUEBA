using System;
using System.Collections.Generic;

namespace AMDGOINT.Formularios.Retiros.MC
{
    public class RegistrosImportacion
    {
        private string _codigocuenta = "";
        private decimal _importe = 0;
        private string _observacion = "";
        private byte _tipomovimiento = 1;
        private DateTime _vencimiento = DateTime.MinValue;
        private string _codigoretiro = "";
        private byte _pagoforma = 0;
        private short idempresa = 0;

        public string CodigoCuenta
        {
            get { return _codigocuenta; }
            set { _codigocuenta = _codigocuenta != value.Trim() ? value.Trim() : _codigocuenta; }
        }

        public decimal Importe
        {
            get { return _importe; }
            set { _importe = _importe != value ? value : _importe; }
        }

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = _observacion != value.Trim() ? value.Trim() : _observacion; }
        }

        public short IDConcepto { get; set; } = 0;

        public string RetiroCodigo
        {
            get { return _codigoretiro; }
            set { _codigoretiro = _codigoretiro != value.Trim() ? value.Trim() : _codigoretiro; }
        }

        public byte TipoMovimiento
        {
            get { return _tipomovimiento; }
            set { _tipomovimiento = _tipomovimiento != value ? value : _tipomovimiento; }
        }

        public DateTime Vencimiento
        {
            get { return _vencimiento; }
            set { _vencimiento = _vencimiento != value ? value : _vencimiento; }
        }

        public short IDEmpresa
        {
            get { return idempresa; }
            set { idempresa = idempresa != value ? value : idempresa; }
        }

        public byte IDPagoForma
        {
            get { return _pagoforma; }
            set { _pagoforma = _pagoforma != value ? value : _pagoforma; }
        }

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public RegistrosImportacion() { }
        
        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public RegistrosImportacion Clone()
        {
            RegistrosImportacion d = (RegistrosImportacion)MemberwiseClone();            
            return d;
        }

        //CLONE CON LISTAS
        public List<RegistrosImportacion> Clone(List<RegistrosImportacion> lst)
        {
            List<RegistrosImportacion> lista = new List<RegistrosImportacion>();

            foreach (RegistrosImportacion d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

    }
}
