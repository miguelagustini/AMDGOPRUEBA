using System;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Recibos.MC
{
    public class Copias
    {

        #region PROPIEDADES

        public string IDLocal { get; } = Guid.NewGuid().ToString();

        public List<CopiasInfo> CopiasInfo { get; set; } = new List<CopiasInfo>();

        #endregion

        public Copias() { }

        public Copias(ReciboEnc f, short cantcopias)
        {                        
            CopiasInfo c = new CopiasInfo();
            CopiasInfo = c.GetCopias(f, cantcopias);

        }

        public List<Copias> GetCopias(List<ReciboEnc> facturas, short cant)
        {
            List<Copias> c = new List<Copias>();

            foreach (ReciboEnc f in facturas)
            {
                Copias copia = new Copias(f, cant);
                c.Add(copia);
            }

            return c;
        }               

    }


    public class CopiasInfo
    {
        private short cantidad = 0;
        private string descripcion = "";                

        public short Cantidad
        {
            get { return cantidad; }
            set
            {
                if (cantidad != value) { cantidad = value; }
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (descripcion != value)
                {
                    descripcion = value;
                }
            }
        }


        public List<ReciboEnc> Recibo { get; set; } = new List<ReciboEnc>();
                             
        public List<CopiasInfo> GetCopias(ReciboEnc f, short cant)
        {
            List<CopiasInfo> lista = new List<CopiasInfo>();
                        
            for (short i = 1; i <= cant; i++)
            {
                CopiasInfo c = new CopiasInfo();
                c.Recibo.Add(f.Clone());
                c.Cantidad = i;

                switch (i)
                {
                    case 1: c.Descripcion = "ORIGINAL"; break;
                    case 2: c.Descripcion = "DUPLICADO"; break;
                    case 3: c.Descripcion = "TRIPLICADO"; break;
                    case 4: c.Descripcion = "CUADRIPLICADO"; break;
                    default: c.Descripcion = ""; break;
                }

                lista.Add(c);
            }

            return lista;
        }
    }
}
