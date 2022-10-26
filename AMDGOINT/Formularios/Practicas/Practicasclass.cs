using AMDGOINT.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AMDGOINT.Formularios.Practicas
{
    class Practicasclass
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        public List<Practicas> practicaslst = new List<Practicas>();
        public List<FuncionesAran> funcioneslst = new List<FuncionesAran>();

        public void GetPracticaslst()
        {
            try
            {
                practicaslst.Clear();

                string c = "SELECT  PM.ID_Registro, PM.Codigo, PM.Descripcion, PM.ID_Arancel, PM.ID_Gasto, PM.ID_Funcion, PM.ID_Grupo," +
                           " ISNULL(FUN.Descripcion, '') AS Funcion, ISNULL(GA.Descripcion, '') as Gasto, ISNULL(AR.Descripcion, '') as Arancel," +
                           " ISNULL(PG.Descripcion, '') as Grupo, PM.Estado, ISNULL(PG.Orden, 0) AS OrdenGrupo, ISNULL(PG.Observacion, 0) AS ObsGrupo" +
                           " FROM PRACTAM PM" +
                           " LEFT OUTER JOIN FUNCIONES FUN ON(FUN.ID_Registro = PM.ID_Funcion)"+ 
                           " LEFT OUTER JOIN GASTOS GA ON(GA.ID_Registro = PM.ID_Gasto)" +
                           " LEFT OUTER JOIN ARANCELES AR ON(AR.ID_Registro = PM.ID_Arancel)" +
                           " LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo)";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    practicaslst.Add(new Practicas
                    {
                        ID_Registro = Convert.ToInt32(r["ID_Registro"]),
                        ID_Arancel = Convert.ToInt32(r["ID_Arancel"]),
                        ID_Gasto = Convert.ToInt32(r["ID_Gasto"]),
                        ID_Funcion = Convert.ToInt32(r["ID_Funcion"]),
                        ID_Grupo = Convert.ToInt32(r["ID_Grupo"]),
                        GrupoOrden = Convert.ToInt32(r["OrdenGrupo"]),
                        GrupoObs = r["ObsGrupo"].ToString().Trim(),
                        Codigo = r["Codigo"].ToString().Trim(),
                        Descripcion = r["Descripcion"].ToString().Trim(),
                        Gasto = r["Gasto"].ToString().Trim(),
                        Arancel = r["Arancel"].ToString().Trim(),
                        Funcion = r["Funcion"].ToString().Trim(),
                        Grupo = r["Grupo"].ToString().Trim(),
                        Estado = Convert.ToBoolean(r["Estado"])
                    });
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar la lista de practicas Amdgo.\n" + e.Message, 0);
                return;
            }
        }

        public void Setestadoprac(bool estado, int idregistro)
        {
            try
            {
                ArrayList campos = new ArrayList();
                ArrayList parametros = new ArrayList();

                campos.Add("Estado");
                parametros.Add(estado);

                func.AccionBD(campos, parametros, "U", "PRACTAM", idregistro);
            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al cambiar el estado de la práctica.\n {e.Message}", 0);
                return;
            }
        }

        public void GetFuncioneslst()
        {
            try
            {
                funcioneslst.Clear();

                string c = "SELECT  ID_Registro, Codigo, Descripcion, Letra FROM FUNCIONES";

                foreach (DataRow r in func.getColecciondatos(c).Rows)
                {
                    funcioneslst.Add(new FuncionesAran
                    {
                        ID_Registro = Convert.ToInt32(r["ID_Registro"]),                        
                        Codigo = r["Codigo"].ToString().Trim(),
                        Descripcion = r["Descripcion"].ToString().Trim(),
                        Letra = r["Letra"].ToString().Trim()                        
                        
                    });
                }

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo("Ocurrió un error al consultar la lista de funciones Amdgo.\n" + e.Message, 0);
                return;
            }
        }
    }

    public class Practicas
    {
        public int ID_Registro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Gasto { get; set; } = "";
        public string Arancel { get; set; } = "";
        public string Funcion { get; set; } = "";
        public string Grupo { get; set; } = "";
        public string GrupoObs { get; set; } = "";
        public int GrupoOrden { get; set; } = 0;
        public int ID_Funcion { get; set; } = 0;
        public int ID_Gasto { get; set; } = 0;
        public int ID_Arancel { get; set; } = 0;
        public int ID_Grupo { get; set; } = 0;
        public bool Estado { get; set; } = true;
    }

    public class FuncionesAran
    {
        public int ID_Registro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Letra { get; set; } = "";
    }

    public class GruposPracticas
    {
        private Controles ctrls = new Controles();
        private Funciones func = new Funciones();

        public int ID_Registro { get; set; }
        public string Descripcion { get; set; }
        public short Orden { get; set; }
        public string Observacion { get; set; }

        //CLONE 
        public GruposPracticas Clone()
        {
            GruposPracticas d = (GruposPracticas)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<GruposPracticas> Clone(List<GruposPracticas> lst)
        {
            List<GruposPracticas> lista = new List<GruposPracticas>();

            foreach (GruposPracticas d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }


        public List<GruposPracticas> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<GruposPracticas> lista = new List<GruposPracticas>();

                string c = $"SELECT ID_Registro, Descripcion, Orden, Observacion FROM [AmdgoInterno].[dbo].[PRACTGRUPOS]";

                //OBTENGO LA TABLA
                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<GruposPracticas>(rdr));
                }

                cnn.Desconectar();

                return lista;

            }
            catch (Exception e)
            {
                ctrls.MensajeInfo($"Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<GruposPracticas>();
            }
        }
    }
}
