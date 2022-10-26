using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Afip
{
    public class Entidad
    {
        private string _cuit = "";
        private string _domicilio = "";
        private string _nombreapellido = "";
        private string _razonsocial = "";

        public string Cuit
        {
            get { return _cuit; }
            set { _cuit = _cuit != value.Trim() ? value.Trim() : _cuit; }
        }

        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = _domicilio != value.Trim() ? value.Trim() : _domicilio; }
        }

        public string NombreApellido
        {
            get { return _nombreapellido; }
            set { _nombreapellido = _nombreapellido != value.Trim() ? value.Trim() : _nombreapellido; }
        }

        public string RazonSocial
        {
            get { return _razonsocial; }
            set { _razonsocial = _razonsocial != value.Trim() ? value.Trim() : _razonsocial; }
        }

    }
}
