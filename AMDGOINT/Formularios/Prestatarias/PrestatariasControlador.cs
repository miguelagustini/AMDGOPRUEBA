using AMDGOINT.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace AMDGOINT.Formularios.Prestatarias
{
    class PrestatariasControlador
    {
        private Controles ctrl = new Controles();
        private Funciones func = new Funciones();

        //CARGO LA LISTA DE REGISTROS Y LOS ASIGNO A SU LISTA
        public List<PrestatariasStrc> CargarRegistros()
        {
            List<PrestatariasStrc> Prestatariaslist = new List<PrestatariasStrc>();

            try
            {                
                string consulta = "SELECT PR.ID_Registro, PR.Nombre, PR.Cuit, PR.ID_Iva," +
                    " CD.Abreviatura, PR.DiasVencimiento, PR.MiPyme, PR.Abreviatura AS Abreviat" +
                    " FROM PRESTATARIAS PR" +
                    " LEFT OUTER JOIN CONDSIVA CD ON(CD.ID_Registro = PR.ID_Iva)" +
                    " WHERE PR.Estado = 1";

                foreach (DataRow f in func.getColecciondatos(consulta).Rows)
                {
                    Prestatariaslist.Add(new PrestatariasStrc {
                        ID_Registro = Convert.ToInt32(f["ID_Registro"]),                        
                        Nombre = f["Nombre"].ToString(),
                        Cuit = Convert.ToInt64(f["Cuit"]),
                        ID_Iva = Convert.ToInt16(f["ID_Iva"]),
                        Iva = f["Abreviatura"].ToString(),                        
                        MiPyme = Convert.ToBoolean(f["MiPyme"]),
                        DiasVencimiento = Convert.ToInt32(f["DiasVencimiento"]),
                        Abreviatura = f["Abreviat"].ToString()

                    });
                }

                return Prestatariaslist;
            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al consultar los registros.\n" + e.Message, 0);
                return Prestatariaslist;
            }
        }

        //ACTUALIZO LA TABLA DE PRESTATARIAS
        public void ActualizoPrestataria(int idregistro, ArrayList campos, ArrayList parametros)
        {
            try
            {
                func.AccionBD(campos, parametros, "U", "PRESTATARIAS", idregistro);

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo("Ocurrió un error al actualizar el registro.\n" + e.Message, 0);
                return;
            }
        }
                       
    }
}
