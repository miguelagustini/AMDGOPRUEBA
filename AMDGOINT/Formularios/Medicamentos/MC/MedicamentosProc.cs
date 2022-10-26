using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AMDGOINT.Formularios.Medicamentos.MC
{
    class MedicamentosProc
    {
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS
        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();


        public List<Medicamento> listamedic = new List<Medicamento>();
        public List<MedicamentosMonodro> listamonodrog = new List<MedicamentosMonodro>();
        public List<MedicamentosXtra> listamanextra = new List<MedicamentosXtra>();
        #endregion

        private string[] lineasManual;
        private string[] lineasMonodro;
        private string[] lineasManextra;


        private bool leerArchivos(string ruta)
        {
            try
            {
                //LEO EL ARCHIVO                
                lineasManual = File.ReadAllLines(ruta + @"\Manual.dat", Encoding.UTF8);
                lineasMonodro = File.ReadAllLines(ruta + @"\Monodro.txt", Encoding.UTF8);
                lineasManextra = File.ReadAllLines(ruta + @"\Manextra.txt", Encoding.UTF8);
                return true;
            }

            catch (Exception)
            {
                return false;
            }

        }

        public void cargaDatos(string ruta)
        {
            listamanextra.Clear();
            listamedic.Clear();
            listamonodrog.Clear();


            if (leerArchivos(ruta))
            {
                procesoMonodro();
                procesoManextras();
                procesoManual();
            }

        }


        //PROCESO LA LISTA DE REGISTROS EN Monodro.txt
        private Dictionary<int, string> procesoMonodro()
        {
            Dictionary<int, string> lineasIncompatibles = new Dictionary<int, string>();
            int contador = 0;
            try
            {
                foreach (string linea in lineasMonodro)
                {
                    contador++;
                    int codigo = 0;
                    string descripcion = "";

                    //COMPRUEBE QUE LA CANTIDAD DE CARACTERES SEA CORRECTA
                    if (linea.Length != 37) {
                        lineasIncompatibles.Add(contador, "No coinciden la cantidad de caracteres");
                    }

                    //CODIGO DE LA MONODROGA
                    if (!string.IsNullOrEmpty(linea.Substring(0, 5)))
                    {
                        codigo = Convert.ToInt32(linea.Substring(0, 5));
                    }

                    //DESCRIPCION    
                    descripcion = func.ValidaCadena(linea.Substring(5, 32).Replace("'", "´"));

                    listamonodrog.Add(new MedicamentosMonodro()
                    {
                        Codigo = codigo,
                        Descripcion = descripcion
                    });
                }
                return lineasIncompatibles;
            }
            catch (Exception e)
            {
                lineasIncompatibles.Add(0, $"Ocurrió un error al procesar los datos en Monodroga. \n {e.Message}");
                return lineasIncompatibles;
            }

        }

        //PROCESO LA LISTA DE REGISTROS EN Monodro.txt
        private Dictionary<int, string> procesoManextras()
        {
            Dictionary<int, string> lineasIncompatibles = new Dictionary<int, string>();
            int contador = 0;

            try
            {
                foreach (string linea in lineasManextra)
                {
                    contador++;
                    //COMPRUEBE QUE LA CANTIDAD DE CARACTERES SEA CORRECTA
                    if (linea.Length != 53)
                    {
                        lineasIncompatibles.Add(contador, "No coinciden la cantidad de caracteres");
                    }

                    int nroregis = 0, tamanopres = 0, accfarma = 0, monodrog = 0,
                        formafarma = 0, unipotencia = 0, tipouni = 0, viaadmin = 0;
                    string potencia = "";

                    //NUMERO DE REGISTRO
                    if (!string.IsNullOrEmpty(linea.Substring(0, 5)))
                    { nroregis = Convert.ToInt32(linea.Substring(0, 5)); }

                    //TAMAÑO RELATIVO DE LA PRESENTACION
                    if (!string.IsNullOrEmpty(linea.Substring(5, 2)))
                    { tamanopres = Convert.ToInt32(linea.Substring(5, 2)); }

                    //ACCION FARMACOLOGICA
                    if (!string.IsNullOrEmpty(linea.Substring(7, 5)))
                    { accfarma = Convert.ToInt32(linea.Substring(7, 5)); }

                    //MONODROGA
                    if (!string.IsNullOrEmpty(linea.Substring(12, 5)))
                    { monodrog = Convert.ToInt32(linea.Substring(12, 5)); }

                    //FORMA FARMACEUTICA
                    if (!string.IsNullOrEmpty(linea.Substring(17, 5)))
                    { formafarma = Convert.ToInt32(linea.Substring(17, 5)); }

                    //POTENCIA
                    potencia = linea.Substring(22, 16).Replace("'", "´");

                    //UNIDAD DE POTENCIA
                    if (!string.IsNullOrEmpty(linea.Substring(38, 5)))
                    { unipotencia = Convert.ToInt32(linea.Substring(38, 5)); }

                    //TIPO DE UNIDADES
                    if (!string.IsNullOrEmpty(linea.Substring(43, 5)))
                    { tipouni = Convert.ToInt32(linea.Substring(43, 5)); }

                    //VIA DE ADMINISTRACION
                    if (!string.IsNullOrEmpty(linea.Substring(48, 5)))
                    { viaadmin = Convert.ToInt32(linea.Substring(48, 5)); }

                    listamanextra.Add(new MedicamentosXtra()
                    {
                        NroRegistro = nroregis,
                        TamanoPresenta = tamanopres,
                        AccionFarma = accfarma,
                        Droga = monodrog,
                        FormaFarma = formafarma,
                        Potencia = potencia,
                        UnidadPotencia = unipotencia,
                        TipoUnidades = tipouni,
                        ViaAdministracion = viaadmin
                    });
                }

                return lineasIncompatibles;

            }
            catch (Exception e)
            {

                lineasIncompatibles.Add(0, $"Ocurrió un error al procesar los datos en Manextra. \n {e.Message}");
                return lineasIncompatibles;
            }
        }

        //PROCESO LA LISTA DE REGISTROS OBTENIDOS DEL MANUAL .DAT O .TXT
        private Dictionary<int, string> procesoManual()
        {
            Dictionary<int, string> lineasIncompatibles = new Dictionary<int, string>();

            string donde = "";
            int cantl = 0;

            try
            {
                foreach (string linea in lineasManual)
                {
                    cantl++;

                    //COMPRUEBE QUE LA CANTIDAD DE CARACTERES SEA CORRECTA
                    if (linea.Length != 37)
                    {
                        lineasIncompatibles.Add(cantl, "No coinciden la cantidad de caracteres");
                    }

                    long troquel = 0;
                    int codlab = 0, nroregis = 0, unidad = 0;
                    decimal precio = 0, preciocomp = 0, ioma1 = 0;
                    bool importado, baja = true;
                    string nombre, presentacion, ioma2, ioma3, desclab, marca, tamano,
                         tipovta, iva, coddctopami, heladera, sifar, gravamen,
                        codbarras, monodrog = "";
                    DateTime fecha = new DateTime();

                    //NUMERO DE TROQUEL
                    donde = "troquel";
                    if (!string.IsNullOrEmpty(linea.Substring(0, 7)))
                    { troquel = Convert.ToInt64(linea.Substring(0, 7)); }

                    //NOMBRE          
                    donde = "NOMBRE";
                    nombre = func.ValidaCadena(linea.Substring(7, 44).Replace("'", "´"));

                    //PRESENTACION
                    donde = "PRESENTACION";

                    presentacion = func.ValidaCadena(linea.Substring(51, 24).Replace("'", "´"));

                    //IOMA1
                    donde = "IOMA1";

                    if (!string.IsNullOrEmpty(linea.Substring(75, 8)) &&
                        Convert.ToInt32(linea.Substring(75, 8)) > 0)
                    { ioma1 = Convert.ToInt32(linea.Substring(75, 8)) / 100; }

                    //IOMA2      
                    donde = "IOMA2";

                    ioma2 = linea.Substring(83, 1).Replace("'", "´");

                    //IOMA3     
                    donde = "IOMA3";

                    ioma3 = linea.Substring(84, 1).Replace("'", "´");

                    //LABORATORIO
                    donde = "LABORATORIO";

                    desclab = func.ValidaCadena(linea.Substring(85, 15).Replace("'", "´"));

                    //PRECIO
                    donde = $"PRECIO {cantl} " + linea.Substring(145, 4).TrimStart('0') + " - " + linea.Substring(145, 4);

                    if (linea.Substring(100, 10).ToString() != "" &&
                        Convert.ToInt64(linea.Substring(100, 10)) > 0)
                    {
                        //PRECIO COMPLETO SIN DIVIDIR
                        preciocomp = (Convert.ToDecimal(linea.Substring(100, 10)) / 100);

                        precio = (preciocomp / Convert.ToInt16(linea.Substring(145, 4).TrimStart('0')));

                    }

                    //FECHA
                    donde = "FECHA";
                    if (linea.Substring(110, 8).ToString() != "" &&
                        linea.Substring(110, 8) != null)
                    {
                        string fec = linea.Substring(110, 8);
                        fec = fec.Insert(4, "-");
                        fec = fec.Insert(7, "-");
                        fecha = Convert.ToDateTime(fec);
                    }

                    //MARCA
                    donde = "MARCA";
                    marca = linea.Substring(118, 1).Replace("'", "´");

                    //IMPORTADO
                    donde = "IMPORTADO";
                    importado = Convert.ToBoolean(Convert.ToInt16(linea.Substring(119, 1)));

                    //TIPO VENTA
                    donde = "VENTA";
                    tipovta = linea.Substring(120, 1).Replace("'", "´");

                    //IVA
                    donde = "IVA";
                    iva = linea.Substring(121, 1);

                    //CODIGO DESCUENTO DE PAMI
                    donde = "PAMI";
                    coddctopami = linea.Substring(122, 1).Replace("'", "´");

                    //CODIGO DE LABORATORIO
                    donde = "LABORATORIO";
                    if (linea.Substring(123, 3).ToString() != "")
                    { codlab = Convert.ToInt32(linea.Substring(123, 3).Replace("'", "´")); }

                    //NUMERO DE REGISTRO
                    donde = "REGISTRO";
                    if (linea.Substring(126, 5).ToString() != "")
                    { nroregis = Convert.ToInt32(linea.Substring(126, 5)); }

                    //BAJA
                    donde = "BAJA";
                    baja = Convert.ToBoolean(Convert.ToInt16(linea.Substring(131, 1)));

                    //CODIGO DE BARRA
                    donde = "BARRA";
                    codbarras = linea.Substring(132, 13).ToString();

                    //UNIDADES
                    donde = "UNIDADES";
                    if (linea.Substring(145, 4).ToString() != "")
                    { unidad = Convert.ToInt32(linea.Substring(145, 4)); }

                    //TAMAÑO
                    donde = "TAMAÑO";
                    tamano = linea.Substring(149, 1).ToString();

                    //HELADERA
                    donde = "HELADERA";
                    heladera = linea.Substring(150, 1).ToString();

                    //SIFAR
                    donde = "SIFAR";
                    sifar = linea.Substring(151, 1).ToString();

                    //***** 1 ESPACIO EN BLANCO

                    //GRAVAMEN
                    donde = "GRAVAMEN";
                    gravamen = linea.Substring(153, 1).ToString();

                    //MONODROGA
                    donde = "MONODROGA";
                    foreach (var lis in from xtrainfo in listamanextra
                                        where xtrainfo.NroRegistro.Equals(nroregis)
                                        join drog in listamonodrog
                                        on xtrainfo.Droga equals drog.Codigo
                                        select new { drog.Descripcion })
                    {
                        monodrog = lis.Descripcion.ToString();
                    }

                     
                    listamedic.Add(new Medicamento()
                    {
                        Troquel = troquel,
                        Nombre = nombre,
                        Presentacion = presentacion,
                        Ioma1 = ioma1,
                        Ioma2 = ioma2,
                        Ioma3 = ioma3,
                        Laboratorio = desclab,
                        Precio = precio,
                        PrecioCompleto = preciocomp,
                        Fecha = fecha,
                        MarcaProdContr = marca,
                        Importado = importado,
                        TipoDeVenta = tipovta,
                        Iva = iva,
                        CodPami = coddctopami,
                        CodLab = codlab,
                        NroRegistro = nroregis,
                        Baja = baja,
                        CodBarra = codbarras,
                        Unidades = unidad,
                        Tamanio = tamano,
                        Gravamen = gravamen,
                        Monodroga = monodrog,

                    });

                }
                return lineasIncompatibles;

            }
            catch (Exception e)
            {
                lineasIncompatibles.Add(0, $"Ocurrió un error al procesar los datos en Manual.DAT. \n {e.Message}");
                return lineasIncompatibles;
            }
        }


        //CREO LA LISTA DE MEDICAMENTOS PARA INSERTAR EN LA BD
        public void enviarDatosBD(List <Medicamento> MedicamentosBD)
        {

            Medicamento medicamento = new Medicamento();
            Asocdrog xasocdrog = new Asocdrog();

            List<Medicamento> listaAlta = new List<Medicamento>();
            List<Medicamento> listaModificacion = new List<Medicamento>();

            //listaAlta = listamedic.Except(MedicamentosBD).ToList();  //(Forma de identificar los elementos que no coinciden)

           listaAlta = listamedic.Where(_medicamento => !MedicamentosBD.Select(_troq => _troq.Troquel).Contains(_medicamento.Troquel)).ToList();
           listaModificacion = listamedic.Where(_medicamento => MedicamentosBD.Select(_troq => _troq.Troquel).Contains(_medicamento.Troquel)).ToList();

            if (listaAlta.Count != 0)
            {
                medicamento.AltaLista(listaAlta);
            }

            if (listaModificacion.Count != 0)
            {
                medicamento.ModificacionLista(listaModificacion);
            }
        }
     


    }

        //REFERENCIA A TXT DE INFORMACION ADICIONAL
        //OTROGADA POR ALFA BETA (MANEXTRA.TXT)
        public class MedicamentosXtra
        {
            public string ID_Registro { get; } = Guid.NewGuid().ToString();
            //MANUAL.DAT
            public int NroRegistro { get; set; } = 0;
            //TAMANOS.TXT
            public int TamanoPresenta { get; set; } = 0;
            //ACCIOFAR.TXT
            public int AccionFarma { get; set; } = 0;
            //MONODRO.TXT
            public int Droga { get; set; } = 0;
            //FORMAS.TXT
            public int FormaFarma { get; set; } = 0;
            //(SIN RELACION EXTERNA)
            public string Potencia { get; set; } = "";
            //UPOTENCI.TXT
            public int UnidadPotencia { get; set; } = 0;
            //TIPOUNID.TXT
            public int TipoUnidades { get; set; } = 0;
            //VIAS.TXT
            public int ViaAdministracion { get; set; } = 0;
        }

        public class MedicamentosMonodro
        {
            //CODIGO
            public int Codigo { get; set; } = 0;
            //DESCRIPCION
            public string Descripcion { get; set; } = "";
        }

    }
