using AMDGOINT.Datos;
using AMDGOINT.Formularios.Informes;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace AMDGOINT.Clases
{
    class Impresionglob
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();
        
        public Reportes datosrep { get; set; }

        public long IDRegistro {get; set;} = 0;
        public bool InclPaciente { get; set; } = false;
        public bool Imprimirdetallado { get; set; } = false;
        public long Registrostotal { get; set; } = 0;
        public long Registrosproces { get; set; } = 0;
        private string TipoComprobante { get; set; } = "FC";
        private string Letra { get; set; }

        #region FACTURAS
        //METODO DE LIMPIEZA PARA TODAS LAS TABLAS 
        public void Clearing()
        {
            datosrep.FacturasEnc.Clear();
            datosrep.FacturasDet.Clear();
            datosrep.GrupoFc.Clear();
        }

        //INICIO LA CRGA DE DATOS DE LA FACTURA
        public void CargaDatosfcambu(short del = 0, short copias = 0)
        {
            try
            {               
                //CARGO EL ENCABEZADO
                FEncabezadoambu(del);

                //GENERO EL MEMBRETE PARA LA FACTURA
                FMembrete(del, copias);

                //CARGO EL DETALLE
                FDetalleambu(del);

            }
            catch (Exception)
            {
                return;
            }
        }
        
        //MUESTRO EL REPORTE
        public void MuestraReporte()
        {
            try
            {               
                Xrpt_FacturaAmbu report = new Xrpt_FacturaAmbu();
                report.DataSource = datosrep;
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al mostrar el reporte.\n" + e.Message, 0);
                return;
            }
        }

        //RETORNO MS PARA USOS EN MEMORIA de ambulatorio
        public byte[] GetFacturamsambulatorio()
        {
            byte[] retorno = null;

            try
            {
                MemoryStream ms = new MemoryStream();

                Xrpt_FacturaAmbu report = new Xrpt_FacturaAmbu();
                report.DataSource = datosrep;
                report.ExportToPdf(ms);

                TextWriter textWriter = new StreamWriter(ms);
                textWriter.Flush(); // added this line
                retorno = ms.ToArray(); // simpler way of converting to array
                ms.Close();

                return retorno;
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar los archivos en memoria.\n" + e.Message, 0);
                return retorno;
            }
        }

        //GUARDO LOS PDF GENERADOS
        public void GuardaPdf(ArrayList listaids, string ubicacion)
        {
            Registrosproces = 0;
            Registrostotal = 0;
            GeneraDatosPdf(listaids, ubicacion);
        }

        //GENERO LOS DATOS DE PDF INDIVIDUALES
        private void GeneraDatosPdf(ArrayList listaids, string ubicacion)
        {
            try
            {
                Registrostotal = listaids.Count;

                foreach (long idreg in listaids)
                {
                    Registrosproces++;
                    IDRegistro = idreg;
                    CargaDatosfcambu();

                    string consulta = "SELECT CONCAT(Letra, ' ', RIGHT(CONCAT('0000', PuntoVenta),4), '-'," +
                    " RIGHT(CONCAT('00000000',Numero),8)) as Comprobante, NombreProf " +
                    " FROM FACTAMBUENC" +
                    " WHERE ID_Registro = " + idreg;

                    DataRow fila = func.getColecciondatos(consulta).Rows[0];
                    if (fila != null)
                    {
                        GuardaPdfFisico(ubicacion, fila["NombreProf"].ToString() + ", " + fila["Comprobante"].ToString());
                    }
                    
                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al generar los datos.\n" + e.Message,0);
                return;
            }
        }

        //GUARDO EL PDF EN FISICO
        private void GuardaPdfFisico(string ubicacion, string nombrecli)
        {
            try
            {
                string proc = Regex.Replace(nombrecli, "[^A-Za-z0-9- ]", "");
             
                Xrpt_FacturaAmbu report = new Xrpt_FacturaAmbu();
                report.DataSource = datosrep;

                //Ubicacion
                string path = ubicacion + @"\Facturas " + DateTime.Today.ToString("dd-MM-yyyy");
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

                //Creacion
                report.ExportToPdf(path + @"\" + proc + ".pdf");
                            
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar los archivos.\n" + e.Message, 0);
                return;
            }
        }        

        private void FMembrete(short del = 0, short copias = 0)
        {
            try
            {
                if (del == 0) { datosrep.GrupoFc.Clear(); }

                // ORIGINAL Y DUPLICADO
                if (copias == 0)
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        DataRow fila = datosrep.GrupoFc.NewRow();

                        fila["ID_Encabezado"] = IDRegistro;
                        fila["Grupo"] = i;

                        datosrep.GrupoFc.Rows.Add(fila);
                    }
                }
                else if (copias == 1) //SOLO ORIGINAL
                {
                    DataRow fila = datosrep.GrupoFc.NewRow();

                    fila["ID_Encabezado"] = IDRegistro;
                    fila["Grupo"] = 0;

                    datosrep.GrupoFc.Rows.Add(fila);
                }
                else //SOLO DUPLICADO
                {
                    DataRow fila = datosrep.GrupoFc.NewRow();

                    fila["ID_Encabezado"] = IDRegistro;
                    fila["Grupo"] = 1;

                    datosrep.GrupoFc.Rows.Add(fila);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrio un error al cargar el membrete.\n" + e.Message, 0);
                return;
            }
        }

        private void FEncabezadoambu(short del = 0)
        {
            try
            {

                if (del == 0) { datosrep.FacturasEnc.Clear(); }

                string consulta = "SELECT FE.ID_Registro AS ID_Encabezado, FE.Fecha as FechaEmision, FE.FechaDesde, FE.FechaHasta," +
                    " FE.Fecha AS FechaVto, FE.TipoComprobante, FE.Letra, FORMAT(FE.PuntoVenta, '0000') AS PuntoVenta," +
                    " FORMAT(FE.Numero, '00000000') AS Numero, FE.NombreProf AS EmNombre, FE.DomFiscalProf as EmDomicilio," +
                    " FE.CuitProf, CD.Descripcion as EmTiva, PF.IngrBrutos AS EmIngBrutos, FE.CuitProf as EmCuit," +
                    " PF.InicioActividad as EmIactividad, FE.NombrePres AS RENombre, FE.DomFiscalPres as ReDomicilio, FE.CuitPres AS ReCuit," +
                    " CD1.Descripcion as ReIva, 'Cuenta Corriente' as ReCondVenta, FE.Neto, FE.Neto21, FE.Neto105," +
                    " FE.Iva, FE.Iva21, FE.Iva105, FE.NoGravado, FE.Total," +
                    " FE.CaeNroAf AS AfCae, FE.VtoCaeAf AS AfFechaVto, FE.BarrasAf AS AfBarras, '" + InclPaciente + "' AS IncluyePaci" +
                    " FROM FACTAMBUENC FE" +
                    " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = FE.IvaProf)" +
                    " LEFT OUTER JOIN PROFESIONALES PF ON(PF.ID_Registro = FE.ID_Profesional)" +
                    " LEFT OUTER JOIN CONDSIVA CD1 ON(CD1.ID_Registro = FE.IvaPres)" +
                    " WHERE FE.ID_Registro = " + IDRegistro + " AND FE.EstadoAf = 'A'";
                                
                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    datosrep.FacturasEnc.ImportRow(fila);
                    TipoComprobante = fila["TipoComprobante"].ToString();                    
                }
                
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar el encabezado.\n" + e.Message, 0);
                return;
            }
        }
        
        private void FDetalleambu(short del = 0)
        {
            try
            {
                if (del == 0) { datosrep.FacturasDet.Clear(); }
                string consulta = "";

                if (TipoComprobante == "FC")
                {
                    if (InclPaciente)
                    {
                        consulta = "SELECT FD.ID_Encabezado, FD.CodPract AS CodPractica, FN.Descripcion AS Funcion," +
                            " FD.NombrePaci AS Paciente, FD.IvaPorc as PorcIva, SUM(FD.Cantidad) AS Cantidad," +
                            " SUM(FD.PrecioUnitario) AS PrecioUnit," +
                            //" IIF(FD.Neto > 0, FD.Neto, FD.NoGravado) AS PrecioUnit," +
                            " IIF(FD.Neto > 0, SUM(FD.Neto), SUM(FD.NoGravado)) AS SubTotal," +
                            " SUM(FD.Iva) AS Iva, SUM(FD.NoGravado) as NoGravado, SUM(FD.Total) AS Total" +
                            " FROM FACTAMBUDET FD" +
                            " LEFT OUTER JOIN FUNCIONES FN ON(FN.Codigo = FD.Funcion)" +
                            " LEFT OUTER JOIN FACTAMBUENC FA ON(FA.ID_Registro = FD.ID_Encabezado)" +                            
                            " WHERE FD.ID_Encabezado = " + IDRegistro + " AND FA.EstadoAf = 'A'" +
                            " GROUP BY FD.ID_Encabezado, FD.CodPract, FN.Descripcion, FD.NombrePaci, FD.IvaPorc, FD.Neto, FD.NoGravado" +                            
                            " ORDER BY FD.NombrePaci ASC";
                    }
                    else
                    {
                        consulta = "SELECT FD.ID_Encabezado, FD.CodPract AS CodPractica, FN.Descripcion AS Funcion," +
                            " FD.IvaPorc as PorcIva, SUM(FD.Cantidad) AS Cantidad," +
                            " SUM(FD.PrecioUnitario) AS PrecioUnit," +
                            //" IIF(FD.Neto > 0, FD.Neto, FD.NoGravado) AS PrecioUnit," +
                            " SUM(FD.Iva) AS Iva, IIF(FD.Neto > 0, SUM(FD.Neto), SUM(FD.NoGravado)) AS SubTotal," +
                            " FD.NoGravado AS NoGravado, SUM(FD.Total) AS Total" +
                            " FROM FACTAMBUDET FD" +
                            " LEFT OUTER JOIN FUNCIONES FN ON(FN.Codigo = FD.Funcion)" +
                            " LEFT OUTER JOIN FACTAMBUENC FA ON(FA.ID_Registro = FD.ID_Encabezado)" +
                            " WHERE FD.ID_Encabezado = " + IDRegistro + " AND FA.EstadoAf = 'A'" +                            
                            " GROUP BY FD.ID_Encabezado, FD.CodPract, FN.Descripcion, FD.IvaPorc, FD.Neto, FD.NoGravado";
                            
                    }
                }
                else 
                {
                    consulta = "SELECT FE.ID_Registro AS ID_Encabezado, '' AS CodPractica, '' AS Funcion, '' as Paciente," +                        
                               " 0 PorcIva, 0 AS Cantidad, 0 AS PrecioUnit, 0 AS Iva, 0 AS NoGravado, FE.Total," +
                               //" FR.Comprobante AS Descripcion," +
                               " IIF(FC.Numero > 0, CONCAT('Según factura Nº ', FORMAT(FC.PuntoVenta, '0000'), ' - ', FORMAT(FC.Numero, '00000000'))," +
                               " CONCAT('Según factura Nº ', FR.Comprobante)) AS Descripcion2" +                        
                               " FROM FACTAMBUENC FE" +
                               " LEFT OUTER JOIN FACTAMBUREL FR ON(" +
                               " (CASE WHEN FR.ID_NotaCredito > 0 THEN FR.ID_NotaCredito WHEN FR.ID_NotaDebito > 0" +
                               " THEN FR.ID_NotaDebito else FR.ID_NotaCredito end) = FE.ID_Registro)" +
                               " LEFT OUTER JOIN FACTAMBUENC FC ON(FC.ID_Registro = FR.ID_Factura)" +
                               " WHERE FE.ID_Registro = " + IDRegistro + " AND FE.EstadoAf = 'A'"; 
                }
                
                
                foreach (DataRow fila in func.getColecciondatos(consulta).Rows) { datosrep.FacturasDet.ImportRow(fila); }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar los detalles.\n" + e.Message, 0);
                return;
            }
        }

        #endregion

        #region FACTURAS PRESTATARIAS

        //METODO DE LIMPIEZA PARA TODAS LAS TABLAS 
        public void Clearingfcprestat()
        {
            datosrep.FactuPrestaEnc.Clear();
            datosrep.FactuPrestaDet.Clear();
            datosrep.GrupoFcPrest.Clear();
        }

        //INICIO LA CRGA DE DATOS DE LA FACTURA
        public void CargaDatosfcprestat(short del = 0)
        {
            try
            {
                //CARGO EL ENCABEZADO
                FEncabezadofcprest(del);

                //GENERO EL MEMBRETE PARA LA FACTURA
                FMembretefcprest(del);

                //CARGO EL DETALLE
                FDetallefcprest(del);

            }
            catch (Exception)
            {
                return;
            }
        }

        //MUESTRO EL REPORTE
        public void MuestraReporteFcprest()
        {
            try
            {
                Xrpt_FactPrestataria report = new Xrpt_FactPrestataria();
                report.DataSource = datosrep;
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al mostrar el reporte.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO LOS PDF GENERADOS
        public void GuardaPdffcprest(ArrayList listaids, string ubicacion, short param = 0)
        {
            Registrosproces = 0;
            Registrostotal = 0;
            GeneraDatosPdffcprest(listaids, ubicacion, param);
        }

        //GENERO LOS DATOS DE PDF INDIVIDUALES
        private void GeneraDatosPdffcprest(ArrayList listaids, string ubicacion, short param)
        {
            try
            {
                Registrostotal = listaids.Count;

                CultureInfo ci = new CultureInfo("es-Es");
                TextInfo textInfo = ci.TextInfo;
                
                foreach (long idreg in listaids)
                {
                    Registrosproces++;
                    IDRegistro = idreg;
                    CargaDatosfcprestat();

                    string consulta = "SELECT CONCAT(Letra, ' ', RIGHT(CONCAT('0000', PuntoVenta),4), '-'," +
                    " RIGHT(CONCAT('00000000',Numero),8)) as Comprobante, NombrePres, Paciente" +
                    " FROM FACTPRESENC" +
                    " WHERE ID_Registro = " + idreg;

                    DataRow fila = func.getColecciondatos(consulta).Rows[0];
                    if (fila != null)
                    {                        
                        string n = fila["NombrePres"].ToString();
                        if (fila["Paciente"].ToString() != "")
                        { n += ", " + fila["Paciente"].ToString(); }

                        if (param == 0) { GuardaPdfFisicofcprest(ubicacion, textInfo.ToTitleCase(n.ToLower()).Replace("/","") + ", " + fila["Comprobante"].ToString()); }
                        else { GuardaPdfFisicofcprest(ubicacion, fila["Comprobante"].ToString().Replace(" ", "")); }
                    }

                }
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al generar los datos.\n" + e.Message, 0);
                return;
            }
        }

        //GUARDO EL PDF EN FISICO
        private void GuardaPdfFisicofcprest(string ubicacion, string nombrecli)
        {
            try
            {
                string proc = Regex.Replace(nombrecli, "[^A-Za-z0-9- ]", "");


                Xrpt_FactPrestataria report = new Xrpt_FactPrestataria();
                report.DataSource = datosrep;

                //Ubicacion
                string path = ubicacion + @"\Facturas " + DateTime.Today.ToString("dd-MM-yyyy");
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

                //Creacion
                report.ExportToPdf(path + @"\" + proc + ".pdf");
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al guardar los archivos.\n" + e.Message, 0);
                return;
            }
        }

        private void FMembretefcprest(short del = 0)
        {
            try
            {
                if (del == 0) { datosrep.GrupoFcPrest.Clear(); }

                for (int i = 0; i <= 1; i++)
                {
                    DataRow fila = datosrep.GrupoFcPrest.NewRow();

                    fila["ID_Encabezado"] = IDRegistro;
                    fila["Grupo"] = i;

                    datosrep.GrupoFcPrest.Rows.Add(fila);
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrio un error al cargar el membrete.\n" + e.Message, 0);
                return;
            }
        }

        private void FEncabezadofcprest(short del = 0)
        {
            try
            {

                if (del == 0) { datosrep.FactuPrestaEnc.Clear(); }

                string consulta = "SELECT FE.ID_Registro AS ID_Encabezado, FE.Fecha as FechaEmision, FE.FechaDesde, FE.FechaHasta,"+
                                " FE.Fecha AS FechaVto, LTRIM(RTRIM(FE.TipoComprobante)) as TipoComprobante, LTRIM(RTRIM(FE.Letra)) as Letra," +
                                " FORMAT(FE.PuntoVenta, '0000') AS PuntoVenta, FORMAT(FE.Numero, '00000000') AS Numero, PE.Codigo as ReCodigo,"+ 
                                " FE.NombrePres AS RENombre, FE.DomFiscalPres as ReDomicilio, FE.CuitPres AS ReCuit," +
                                " CD.Descripcion as ReIva, FE.Neto, FE.Iva, FE.Total," +
                                " FE.CaeNroAf AS AfCae, FE.VtoCaeAf AS AfFechaVto, FE.BarrasAf AS AfBarras," +
                                " FE.Paciente, FE.NroDocumento AS Documento, FE.Periodo, '" + Imprimirdetallado + "' AS DetalleVisible," +
                                " FE.Cbu, FE.FechaVtoPago" +
                                " FROM FACTPRESENC FE" +
                                " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = FE.IvaPres)" +
                                " LEFT OUTER JOIN PRESTDETALLES PE ON(PE.ID_Registro = FE.ID_PrestDetalle)" +
                                " WHERE FE.ID_Registro = " + IDRegistro + " AND FE.EstadoAf = 'A'";

                foreach (DataRow fila in func.getColecciondatos(consulta).Rows)
                {
                    datosrep.FactuPrestaEnc.ImportRow(fila);
                    TipoComprobante = fila["TipoComprobante"].ToString();
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar el encabezado.\n" + e.Message, 0);
                return;
            }
        }

        private void FDetallefcprest(short del = 0)
        {
            try
            {
                string c = "";

                if (del == 0) { datosrep.FactuPrestaDet.Clear(); }
                if (InclPaciente)
                {
                    c = "SELECT FA.ID_Registro AS ID_Encabezado, ISNULL(IIF(FA.TipoComprobante = 'NCE' OR FA.TipoComprobante = 'NDE' OR FA.TipoComprobante = 'NC'" +
                           " OR FA.TipoComprobante = 'ND', IIF(FAR.PuntoVenta > 0, CONCAT('Según comprobante Nro. ', FAR.TipoComprobante, ' ', FAR.Letra, ' ', FORMAT(FAR.PuntoVenta, '0000'), '-', FORMAT(FAR.Numero, '00000000'))," +
                           " CONCAT('Según comprobante Nro. ', FR.Comprobante, ' ', FD.Descripcion))," +
                           " IIF(FX.Numero > 0, CONCAT('Según comprobante Nro. ', FX.Letra, ' ', FORMAT(FX.PuntoVenta, '0000'), '-', FORMAT(FX.Numero, '00000000')), FD.Descripcion)), FD.Descripcion) AS Descripcion," +
                           " ISNULL(SUM(FD.Cantidad), 0) AS Cantidad, ISNULL(SUM(FD.Neto), 0) AS Neto," +
                           " ISNULL(SUM(FD.Gastos), 0) AS Gastos, ISNULL(SUM(FD.Honorarios), 0) AS Honorarios," +
                           " ISNULL(SUM(FD.Iva), 0) AS Iva," +
                           " ISNULL(IIF(FD.Origen > 0, SUM(FD.Total), SUM(FA.Total)),0)  AS Total," +
                           " ISNULL(FD.Origen, '0') AS Origen, ISNULL(FD.CodProfesional, '') AS CodProfesional," +
                           " ISNULL(FD.Profesional, '') AS Profesional, ISNULL(FD.Periodo, 0) AS Periodo, FD.Paciente, FD.NroDocumento" +
                           " FROM FACTPRESENC FA" +
                           " LEFT OUTER JOIN FACTPRESDET FD ON(FD.ID_Encabezado = FA.ID_Registro)" +
                           " LEFT OUTER JOIN FACTPRESREL FR ON((CASE WHEN FR.ID_NotaCredito > 0 THEN FR.ID_NotaCredito WHEN FR.ID_NotaDebito > 0" +
                           " THEN FR.ID_NotaDebito else FR.ID_NotaCredito end) = FA.ID_Registro)" +
                           " LEFT OUTER JOIN FACTPRESENC FAR ON(FAR.ID_Registro = FR.ID_Factura)" +
                           " LEFT OUTER JOIN FACTPRESRX RX ON(RX.ID_Factura = FA.ID_Registro)" +
                           " LEFT OUTER JOIN FACTPRESENC FX ON(FX.ID_Registro = RX.ID_ComprobanteX)" +
                           " WHERE FA.ID_Registro = " + IDRegistro + " AND FA.EstadoAf = 'A'" +
                           " GROUP BY FA.ID_Registro, " +
                           " FAR.TipoComprobante, FAR.Letra, FAR.PuntoVenta, FAR.Numero, FR.Comprobante," +
                           " FD.Descripcion, FD.Origen, FD.CodProfesional, FD.Profesional," +
                           " FA.TipoComprobante, FD.Periodo, FX.Letra, FX.PuntoVenta, FX.Numero, FD.Paciente, FD.NroDocumento";
                }
                else
                {
                    c = "SELECT FA.ID_Registro AS ID_Encabezado, ISNULL(IIF(FA.TipoComprobante = 'NCE' OR FA.TipoComprobante = 'NDE' OR FA.TipoComprobante = 'NC'" +
                            //" OR FA.TipoComprobante = 'ND', IIF(FAR.PuntoVenta > 0, CONCAT('Según comprobante Nro. ', FAR.TipoComprobante, ' ', FAR.Letra, ' ', FORMAT(FAR.PuntoVenta, '0000'), '-', FORMAT(FAR.Numero, '00000000'))," +
                            " OR FA.TipoComprobante = 'ND', IIF(FAR.PuntoVenta > 0 AND FD.Descripcion IS NULL, CONCAT('Según comprobante Nro. ', FAR.TipoComprobante, ' ', FAR.Letra, ' ', FORMAT(FAR.PuntoVenta, '0000'), '-', FORMAT(FAR.Numero, '00000000'))," +
                            " CONCAT('Según comprobante Nro. ', FR.Comprobante, ' ', FD.Descripcion))," +
                            " IIF(FX.Numero > 0, CONCAT('Según comprobante Nro. ', FX.Letra, ' ', FORMAT(FX.PuntoVenta, '0000'), '-', FORMAT(FX.Numero, '00000000')), FD.Descripcion)), FD.Descripcion) AS Descripcion," +
                            " ISNULL(SUM(FD.Cantidad), 0) AS Cantidad, ISNULL(SUM(FD.Neto), 0) AS Neto," +
                            " ISNULL(SUM(FD.Gastos), 0) AS Gastos, ISNULL(SUM(FD.Honorarios), 0) AS Honorarios," +
                            " ISNULL(SUM(FD.Iva), 0) AS Iva," +
                            " ISNULL(IIF(FD.Origen >= 0, SUM(FD.Total), SUM(FA.Total)),0)  AS Total," +
                            " ISNULL(FD.Origen, '0') AS Origen, ISNULL(FD.CodProfesional, '') AS CodProfesional," +
                            " ISNULL(FD.Profesional, '') AS Profesional, ISNULL(FD.Periodo, 0) AS Periodo" +
                            " FROM FACTPRESENC FA" +
                            " LEFT OUTER JOIN FACTPRESDET FD ON(FD.ID_Encabezado = FA.ID_Registro)" +
                            " LEFT OUTER JOIN FACTPRESREL FR ON((CASE WHEN FR.ID_NotaCredito > 0 THEN FR.ID_NotaCredito WHEN FR.ID_NotaDebito > 0" +
                            " THEN FR.ID_NotaDebito else FR.ID_NotaCredito end) = FA.ID_Registro)" +
                            " LEFT OUTER JOIN FACTPRESENC FAR ON(FAR.ID_Registro = FR.ID_Factura)" +
                            " LEFT OUTER JOIN FACTPRESRX RX ON(RX.ID_Factura = FA.ID_Registro)" +
                            " LEFT OUTER JOIN FACTPRESENC FX ON(FX.ID_Registro = RX.ID_ComprobanteX)" +
                            " WHERE FA.ID_Registro = " + IDRegistro + " AND FA.EstadoAf = 'A'" +
                            " GROUP BY FA.ID_Registro, " +
                            " FAR.TipoComprobante, FAR.Letra, FAR.PuntoVenta, FAR.Numero, FR.Comprobante," +
                            " FD.Descripcion, FD.Origen, FD.CodProfesional, FD.Profesional," +
                            " FA.TipoComprobante, FD.Periodo, FX.Letra, FX.PuntoVenta, FX.Numero";
                }
                

                foreach (DataRow fila in func.getColecciondatos(c).Rows) { datosrep.FactuPrestaDet.ImportRow(fila); }


            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar los detalles.\n" + e.Message, 0);
                return;
            }
        }
        
        #endregion

    }
}
