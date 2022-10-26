using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.Data;

namespace AMDGOINT.Formularios.Profesionales
{
    class ProfControlador
    {
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();
        public List<ProfStruct> profesionaleslst = new List<ProfStruct>();
        

        //CARGO LA LISTA DE REGISTROS Y LOS ASIGNO A SU LISTA
        public void CargarRegistros()
        {
            profesionaleslst.Clear();

            try
            {                
                string consulta = "SELECT PR.ID_Registro, PR.Codigo, PR.Nombre, PR.Cuit, PR.ID_Iva, PR.DomFiscal, PR.IngrBrutos," +
                    " PR.InicioActividad, PR.PuntoVenta, CD.Abreviatura, PR.Email," +
                    " PR.MatriculaProv, PR.Libro, PR.Folio, PT.Descripcion AS Titulo, PC.Descripcion AS Categoria," +
                    " PR.FechaVtoCateg, PR.MatriculaNac, PR.FechaNacimiento, PR.FechaIngreso, PU.Descripcion as Universidad, PR.FechaGraduacion," +
                    " PR.CodigoArteCurar, PR.NroActa, PR.RegNacPrestador, PR.VtoRegNacPrestador, PR.Observaciones," +
                    " PF.Descripcion AS Referencia, PR.Estado" +
                    " FROM PROFESIONALES PR" +
                    " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +                    
                    " LEFT OUTER JOIN PROFTITULOS PT ON(PT.ID_Registro = PR.ID_Titulo)" +
                    " LEFT OUTER JOIN PROFCATEGORIA PC ON(PC.ID_Registro = PR.ID_Categoria)"+ 
                    " LEFT OUTER JOIN PROFUNIVERSIDADES PU ON(PU.ID_Registro = PR.ID_Universidad)" +
                    " LEFT OUTER JOIN PROFEREFERENCIAS PF ON(PF.ID_Registro = PR.ID_Referencia)";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    DateTime fecha = new DateTime();
                    if (f["InicioActividad"] != DBNull.Value) { fecha = Convert.ToDateTime(f["InicioActividad"]); }

                    profesionaleslst.Add(new ProfStruct
                    {
                        ID_Registro = Convert.ToInt32(f["ID_Registro"]),
                        Codigo = f["Codigo"].ToString(),
                        Nombre = f["Nombre"].ToString(),
                        Cuit = Convert.ToInt64(f["Cuit"]),
                        ID_Iva = Convert.ToInt16(f["ID_Iva"]),
                        Iva = f["Abreviatura"].ToString(),
                        Domfiscal = f["DomFiscal"].ToString(),
                        IngresosBr = f["IngrBrutos"].ToString(),
                        FecInicioa = fecha,
                        PuntoVenta = Convert.ToInt32(f["PuntoVenta"].ToString()),
                        Email = f["Email"].ToString(),                        
                        Libro = f["Libro"].ToString(),
                        Folio = f["Folio"].ToString(),
                        Titulo = f["Titulo"].ToString(),
                        Categoria = f["Categoria"].ToString(),
                        FechaVtocateg = f["FechaVtoCateg"].ToString(),
                        MatriculaNac = f["MatriculaNac"].ToString(),
                        MatriculaProv = f["MatriculaProv"].ToString(),
                        FechaNacimiento = f["FechaNacimiento"].ToString(),
                        FechaIngreso = f["FechaIngreso"].ToString(),
                        Universidad = f["Universidad"].ToString(),
                        FechaGraduacion = f["FechaGraduacion"].ToString(),
                        CodigoArteCurar = f["CodigoArteCurar"].ToString(),
                        NroActa = Convert.ToInt32(f["NroActa"]),
                        RegNacPrestador = f["RegNacPrestador"].ToString(),
                        VtoRegNacPrestador = f["VtoRegNacPrestador"].ToString(),
                        Observaciones = f["Observaciones"].ToString(),
                        Referencia = f["Referencia"].ToString(),
                        Estado = f["Estado"].ToString()

                    });
                }
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar los registros.\n" + e.Message, 0);
                return;
            }
        }

        //GENERO LA LISTA PARA FEMESFE
        public List<ProfesionalesFemefse> GetListaFemesfe()
        {
            List<ProfesionalesFemefse> femefseslst = new List<ProfesionalesFemefse>();
            try
            {                
                string c = "SELECT PF.ID_Registro AS ID_Profesional, PF.MatriculaProv, PF.Folio, PF.Libro, PF.Nombre, PD.Domicilio, PD.Calle," +
                           " PD.Numero, PD.Piso, PD.Departamento, ISNULL(LO.CodPostal, '') AS CodigoPostal, PC.Telefono," +
                           " ISNULL(ES.Descripcion, '') AS Especialidad, PC.Email, PF.Cuit, PF.Sexo, ISNULL(LO.Descripcion, '') as Localidad, " +
                           " ISNULL(PRV.Descripcion,'') as Provincia" +
                           " FROM PROFDIRECCIONES PD" +
                           " LEFT OUTER JOIN PROFESIONALES PF ON(PF.ID_Registro = PD.ID_Profesional)" +
                           " LEFT OUTER JOIN PROFCONTACTOS PC ON(PC.ID_Direccion = PD.ID_Registro AND PC.ID_Registro = " +
                           "             (SELECT MIN(PC1.ID_Registro) FROM PROFCONTACTOS PC1 WHERE PC1.ID_Direccion = PD.ID_Registro))" +
                           " LEFT OUTER JOIN LOCALIDADES LO ON(LO.ID_Registro = PD.ID_Localidad)" +
                           " LEFT OUTER JOIN PROVINCIAS PRV ON(PRV.ID_Registro = LO.ID_Provincia)" +
                           " LEFT OUTER JOIN PROFESPECIALIDAD PE ON(PE.ID_Profesional = PF.ID_Registro" +
                           " AND PE.ID_Registro = (SELECT MIN(PE1.ID_Registro) from PROFESPECIALIDAD PE1 WHERE PE1.ID_Profesional = PF.ID_Registro))" +
                           " LEFT OUTER JOIN ESPECIALIDADESMED ES ON(ES.ID_Registro = PE.ID_Especialidad)" +
                           //" WHERE PD.Tipo = 'L' AND(PF.ID_Titulo = 1 OR PF.ID_Titulo = 2) AND PF.ID_Referencia = 0 AND PF.Estado = 1" +
                           " WHERE PD.Tipo = 'L' AND PF.Estado = 1 AND PF.ID_Referencia = 0 AND PF.Visible = 1";


                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    femefseslst.Add(new ProfesionalesFemefse
                    {
                        ID_Registro = (int)r["ID_Profesional"],
                        MatriculaProv = r["MatriculaProv"].ToString().Trim(),
                        Folio = r["Folio"].ToString().Trim(),
                        Libro = r["Libro"].ToString().Trim(),
                        Nombre = r["Nombre"].ToString().Trim(),
                        Cuit = (long)r["Cuit"],
                        Calle = r["Calle"].ToString().Trim(),
                        Numero = r["Numero"].ToString().Trim(),
                        Piso = r["Piso"].ToString().Trim(),
                        Departamento = r["Departamento"].ToString().Trim(),
                        Localidad = r["Localidad"].ToString().Trim(),
                        CodigoPostal = r["CodigoPostal"].ToString().Trim(),
                        Telefono = r["Telefono"].ToString().Trim(),
                        Especialidad =  r["Especialidad"].ToString().Trim(),
                        Mail  = r["Email"].ToString().Trim(),
                        Sexo = r["Sexo"].ToString().Trim(),
                        Provincia = r["Provincia"].ToString().Trim()
                    });

                }

                return femefseslst;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar la lista.\n" + e.Message, 0);
                return femefseslst;
            }
        }

        //GENERO EXCEL PADRON (PROVISIORIO)
        public List<ProfStruct> GetPadron()
        {
            try
            {
                List<ProfStruct> lista = new List<ProfStruct>();

                string consulta = "SELECT PR.ID_Registro, PR.Codigo, PR.Nombre, PR.Cuit, PR.MatriculaProv, PR.MatriculaNac" +
                   " FROM PROFESIONALES PR" +
                   " PR.Estado = 1";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    lista.Add(new ProfStruct
                    {
                        ID_Registro = Convert.ToInt32(f["ID_Registro"]),
                        Codigo = f["Codigo"].ToString(),
                        Nombre = f["Nombre"].ToString(),
                        Cuit = Convert.ToInt64(f["Cuit"]),                        
                        MatriculaNac = f["MatriculaNac"].ToString(),
                        MatriculaProv = f["MatriculaProv"].ToString()
                    });
                }



                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error.\n" + e.Message, 0);
                return new List<ProfStruct>();
            }
        }

        /*public List<ProfDirecciones> GetDirecciones()
        {
            try
            {
                List<ProfStruct> lista = new List<ProfStruct>();

               // string consulta = "SELECT PD.ID_Registro, PD.ID_Profesional, PD.Domicilio, LO.Descripcion AS Localidad, LO.CodPostal" +
               //    FROM[AmdgoInterno].[dbo].[PROFDIRECCIONES] PD
               // LEFT OUTER JOIN LOCALIDADES LO ON(LO.ID_Registro = PD.ID_Localidad)

               /* foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    lista.Add(new ProfStruct
                    {
                        ID_Registro = Convert.ToInt32(f["ID_Registro"]),
                        Codigo = f["Codigo"].ToString(),
                        Nombre = f["Nombre"].ToString(),
                        Cuit = Convert.ToInt64(f["Cuit"]),
                        MatriculaNac = f["MatriculaNac"].ToString(),
                        MatriculaProv = f["MatriculaProv"].ToString()
                    });
                }



                return lista;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error.\n" + e.Message, 0);
                return new List<ProfStruct>();
            }
        }*/
    }
}
