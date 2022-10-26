using System;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Facturas.Ambulatorio.MC
{
    public class Copias
    {

        #region PROPIEDADES

        public string IDLocal { get; } = Guid.NewGuid().ToString();

        public List<CopiasInfo> CopiasInfo { get; set; } = new List<CopiasInfo>();

        #endregion

        public Copias() { }

        public Copias(FacturaEnc f, short cantcopias, bool inclpaci, bool incluyefact)
        {                        
            CopiasInfo c = new CopiasInfo();
            CopiasInfo = c.GetCopias(cantcopias, f, inclpaci, incluyefact);            

        }

        public List<Copias> GetCopias(List<FacturaEnc> facturas, short cant, bool inclpaci, bool incluyefact)
        {
            List<Copias> c = new List<Copias>();

            foreach (FacturaEnc f in facturas)
            {
                Copias copia = new Copias(f, cant, inclpaci, incluyefact);
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


        public List<FacturaEnc> Factura { get; set; } = new List<FacturaEnc>();
                             
        public List<CopiasInfo> GetCopias(short cant, FacturaEnc f, bool inclpaci, bool incluyefact)
        {
            List<CopiasInfo> lista = new List<CopiasInfo>();

            GeneradorQr qr = new GeneradorQr();
            qr.GeneraQr(f);

            for (short i = 1; i <= cant; i++)
            {
                CopiasInfo c = new CopiasInfo();
                c.Factura.Add(ProcesaDetalles(f.Clone(), inclpaci, incluyefact));
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


        private FacturaEnc ProcesaDetalles(FacturaEnc f, bool inclpaci, bool incluyefact)
        {
            f.DetallesPrint.Clear();

            //SI NO INCLUYE FACTURA ORIGINAL
            if (!incluyefact)
            {
                //DETALLES SI INCLUYE PACIENTES
                if (inclpaci)
                {
                    var det = f.Detalles.
                        Where(w => w.IDRegistro > 0)
                        .GroupBy(g => new
                        {
                            g.CodPract,
                            g.FuncionDesc,
                            g.DocuPaci,
                            g.NombrePaci,
                            g.Descripcionrel,
                            g.DescripcionManual,
                            g.IvaPorc
                        })
                        .Select(s => new
                        {
                            s.Key.CodPract,
                            s.Key.FuncionDesc,
                            s.Key.DocuPaci,
                            s.Key.NombrePaci,
                            s.Key.Descripcionrel,
                            s.Key.DescripcionManual,
                            s.Key.IvaPorc,
                            Cantidad = s.Sum(x => x.Cantidad),
                            PrecioUnitario = s.Sum(x => x.PrecioUnitario),
                            Neto = s.Sum(x => x.Neto),
                            NoGravado = s.Sum(x => x.NoGravado),
                            Iva = s.Sum(x => x.Iva),
                            Total = s.Sum(x => x.Total)
                        }).ToList();

                    foreach (var d in det)
                    {
                        DetallesPrint dp = new DetallesPrint();

                        dp.CodPract = d.CodPract;
                        dp.FuncionDesc = d.FuncionDesc;
                        dp.DocuPaci = d.DocuPaci;
                        dp.NombrePaci = d.NombrePaci;
                        dp.Descripcionrel = d.Descripcionrel;
                        dp.DescripcionManual = d.DescripcionManual;
                        dp.IvaPorc = d.IvaPorc;
                        dp.Cantidad = d.Cantidad;
                        dp.PrecioUnitario = d.PrecioUnitario;
                        dp.Iva = d.Iva;
                        dp.Neto = d.Neto;
                        dp.NoGravado = d.NoGravado;
                        dp.Total = d.Total;

                        f.DetallesPrint.Add(dp);
                    }
                }
                //DETALLES SI NO INCLUYE PACIENTES
                else
                {
                    var det = f.Detalles
                        .Where(w => w.IDRegistro > 0)
                        .GroupBy(g => new
                        {
                            g.CodPract,
                            g.FuncionDesc,
                            g.Descripcionrel,
                            g.DescripcionManual,
                            g.IvaPorc,
                            g.PrecioUnitario
                        })
                        .Select(s => new
                        {
                            s.Key.CodPract,
                            s.Key.FuncionDesc,
                            s.Key.Descripcionrel,
                            s.Key.DescripcionManual,
                            s.Key.IvaPorc,
                            s.Key.PrecioUnitario,
                            Cantidad = s.Sum(x => x.Cantidad),
                            Neto = s.Sum(x => x.Neto),
                            NoGravado = s.Sum(x => x.NoGravado),
                            Iva = s.Sum(x => x.Iva),
                            Total = s.Sum(x => x.Total)
                        }).ToList();

                    foreach (var d in det)
                    {
                        DetallesPrint dp = new DetallesPrint();

                        dp.CodPract = d.CodPract;
                        dp.FuncionDesc = d.FuncionDesc;
                        dp.Descripcionrel = d.Descripcionrel;
                        dp.DescripcionManual = d.DescripcionManual;
                        dp.IvaPorc = d.IvaPorc;
                        dp.Cantidad = d.Cantidad;
                        dp.PrecioUnitario = d.PrecioUnitario;
                        dp.Iva = d.Iva;
                        dp.Neto = d.Neto;
                        dp.NoGravado = d.NoGravado;
                        dp.Total = d.Total;

                        f.DetallesPrint.Add(dp);
                    }
                }
            }
            else
            {

                var det = f.Detalles
                    .Where(w => w.IDRegistro == 0)
                    .GroupBy(g => new
                    {
                        g.CodPract,
                        g.FuncionDesc,
                        g.Descripcionrel,
                        g.DescripcionManual,
                        g.IvaPorc,
                        g.PrecioUnitario
                    })
                    .Select(s => new
                    {
                        s.Key.CodPract,
                        s.Key.FuncionDesc,
                        s.Key.Descripcionrel,
                        s.Key.DescripcionManual,
                        s.Key.IvaPorc,
                        s.Key.PrecioUnitario,
                        Cantidad = s.Sum(x => x.Cantidad),
                        Neto = s.Sum(x => x.Neto),
                        NoGravado = s.Sum(x => x.NoGravado),
                        Iva = s.Sum(x => x.Iva),
                        Total = s.Sum(x => x.Total)
                    }).ToList();

                foreach (var d in det)
                {
                    DetallesPrint dp = new DetallesPrint();

                    dp.CodPract = d.CodPract;
                    dp.FuncionDesc = d.FuncionDesc;
                    dp.Descripcionrel = d.Descripcionrel;
                    dp.DescripcionManual = d.DescripcionManual;
                    dp.IvaPorc = d.IvaPorc;
                    dp.Cantidad = d.Cantidad;
                    dp.PrecioUnitario = d.PrecioUnitario;
                    dp.Iva = d.Iva;
                    dp.Neto = d.Neto;
                    dp.NoGravado = d.NoGravado;
                    dp.Total = d.Total;

                    f.DetallesPrint.Add(dp);
                }
            }

            return f;
        }

    }
}
