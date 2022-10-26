using System;
using System.Collections.Generic;
using System.Linq;

namespace AMDGOINT.Formularios.Facturas.Prestatarias.MC
{
    public class Copias
    {

        #region PROPIEDADES

        public string IDLocal { get; } = Guid.NewGuid().ToString();

        public List<CopiasInfo> CopiasInfo { get; set; } = new List<CopiasInfo>();

        #endregion

        public Copias() { }

        public Copias(ComprobanteEnc f, short cantcopias, bool incluyepaciente, bool leyendaorg)
        {                        
            CopiasInfo c = new CopiasInfo();
            CopiasInfo = c.GetCopias(cantcopias, f, incluyepaciente, leyendaorg);

        }

        public List<Copias> GetCopias(List<ComprobanteEnc> facturas, short cant, bool incluyepaciente, bool leyendaorg)
        {
            List<Copias> c = new List<Copias>();
           
            foreach (ComprobanteEnc f in facturas)
            {
                Copias copia = new Copias(f, cant, incluyepaciente, leyendaorg);
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


        public List<ComprobanteEnc> Factura { get; set; } = new List<ComprobanteEnc>();
                             
        public List<CopiasInfo> GetCopias(short cant, ComprobanteEnc f, bool incluyepaciente, bool leyendaorg)
        {
            List<CopiasInfo> lista = new List<CopiasInfo>();
            GeneradorQr qr = new GeneradorQr();
            qr.GeneraQr(f);

            for (short i = 1; i <= cant; i++)
            {
                CopiasInfo c = new CopiasInfo();
                //c.Factura.Add(f);
                c.Factura.Add(ProcesaDetalles(f.Clone(), incluyepaciente, leyendaorg));
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


        private ComprobanteEnc ProcesaDetalles(ComprobanteEnc f, bool inclpaci, bool incluyefact, bool primeraimpresion = false)
        {
            //SI NO INCLUYE FACTURA ORIGINAL
            if (!incluyefact)
            {
                //DETALLES SI INCLUYE PACIENTES
                if (inclpaci)
                {
                    var det = f.Detalles
                        .Where(w => !w.DescripcionFacturaOriginal)
                        .GroupBy(g => new
                        {
                            g.PrestadorCuentaID,
                            g.PrestadorCuentaCodigo,
                            g.PrestadorNombre,
                            g.Descripcion,
                            g.DescripcionManual,
                            g.Periodo,
                            g.DescripcionGrupoRegistros,
                            g.PracticaOrigen,
                            g.PacienteDocumento,
                            g.PacienteNombre
                        })
                        .Select(s => new
                        {
                            s.Key.PrestadorCuentaID,
                            s.Key.PrestadorCuentaCodigo,
                            s.Key.PrestadorNombre,
                            s.Key.Descripcion,
                            s.Key.DescripcionManual,
                            s.Key.DescripcionGrupoRegistros,
                            s.Key.Periodo,
                            s.Key.PracticaOrigen,
                            s.Key.PacienteDocumento,
                            s.Key.PacienteNombre,
                            Cantidad = s.Sum(x => x.Cantidad),
                            Total = s.Sum(x => x.ImporteTotal)
                        }).ToList();

                    f.Detalles.Clear();

                    foreach (var d in det)
                    {
                        ComprobanteDet g = new ComprobanteDet();

                        g.PrestadorCuentaID = d.PrestadorCuentaID;
                        g.PrestadorCuentaCodigo = d.PrestadorCuentaCodigo;
                        g.PrestadorNombre = d.PrestadorNombre;
                        g.Descripcion = d.Descripcion;
                        g.DescripcionManual = d.DescripcionManual;
                        g.Periodo = d.Periodo;
                        g.PracticaOrigen = d.PracticaOrigen;
                        g.PacienteDocumento = d.PacienteDocumento;
                        g.PacienteNombre = d.PacienteNombre;
                        g.Cantidad = d.Cantidad;
                        g.ImporteTotal = d.Total;

                        f.Detalles.Add(g);
                    }
                }
                //DETALLES SI NO INCLUYE PACIENTES
                else
                {
                    var det = f.Detalles
                        .Where(w => !w.DescripcionFacturaOriginal)
                        .GroupBy(g => new
                        {
                            g.PrestadorCuentaID,
                            g.PrestadorCuentaCodigo,
                            g.PrestadorNombre,
                            g.Descripcion,
                            g.DescripcionManual,
                            g.DescripcionRelacion,
                            g.DescripcionGrupoRegistros,
                            g.Periodo,
                            g.PracticaOrigen
                        })
                        .Select(s => new
                        {
                            s.Key.PrestadorCuentaID,
                            s.Key.PrestadorCuentaCodigo,
                            s.Key.PrestadorNombre,
                            s.Key.Descripcion,
                            s.Key.DescripcionManual,
                            s.Key.DescripcionRelacion,
                            s.Key.DescripcionGrupoRegistros,
                            s.Key.Periodo,
                            s.Key.PracticaOrigen,
                            Cantidad = s.Sum(x => x.Cantidad),
                            Total = s.Sum(x => x.ImporteTotal)
                        }).ToList();

                    f.Detalles.Clear();

                    foreach (var d in det)
                    {
                        ComprobanteDet g = new ComprobanteDet();

                        g.PrestadorCuentaID = d.PrestadorCuentaID;
                        g.PrestadorCuentaCodigo = d.PrestadorCuentaCodigo;
                        g.PrestadorNombre = d.PrestadorNombre;
                        g.Descripcion = d.Descripcion;
                        g.DescripcionManual = d.DescripcionManual;
                        g.DescripcionRelacion = d.DescripcionRelacion;
                        g.Periodo = d.Periodo;
                        g.PracticaOrigen = d.PracticaOrigen;
                        g.Cantidad = d.Cantidad;
                        g.ImporteTotal = d.Total;

                        f.Detalles.Add(g);
                    }
                }
            }
            else
            {
                var det = f.Detalles.
                        Where(w => w.DescripcionFacturaOriginal).
                        GroupBy(g => new
                        {
                            g.PrestadorCuentaID,
                            g.PrestadorCuentaCodigo,
                            g.PrestadorNombre,
                            g.Descripcion,
                            g.DescripcionManual,
                            g.DescripcionRelacion,
                            g.DescripcionGrupoRegistros,
                            g.Periodo,
                            g.PracticaOrigen
                        })
                        .Select(s => new
                        {
                            s.Key.PrestadorCuentaID,
                            s.Key.PrestadorCuentaCodigo,
                            s.Key.PrestadorNombre,
                            s.Key.Descripcion,
                            s.Key.DescripcionManual,
                            s.Key.DescripcionRelacion,                            
                            s.Key.DescripcionGrupoRegistros,
                            s.Key.Periodo,
                            s.Key.PracticaOrigen,
                            Cantidad = s.Sum(x => x.Cantidad),
                            Total = s.Sum(x => x.ImporteTotal)
                        }).ToList();

                f.Detalles.Clear();

                foreach (var d in det)
                {
                    ComprobanteDet g = new ComprobanteDet();

                    g.PrestadorCuentaID = d.PrestadorCuentaID;
                    g.PrestadorCuentaCodigo = d.PrestadorCuentaCodigo;
                    g.PrestadorNombre = d.PrestadorNombre;
                    g.Descripcion = d.Descripcion;
                    g.DescripcionManual = d.DescripcionManual;
                    g.DescripcionRelacion = d.DescripcionRelacion;
                    g.Periodo = d.Periodo;
                    g.PracticaOrigen = d.PracticaOrigen;
                    
                    g.Cantidad = d.Cantidad;
                    g.ImporteTotal = d.Total;

                    f.Detalles.Add(g);
                }
            }
           
           
            return f;
        }

    }
}
