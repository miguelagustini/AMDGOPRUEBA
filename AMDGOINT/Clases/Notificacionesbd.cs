using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AMDGOINT.Clases
{
    class Notificacionesbd
    {
        private ConexionBD conexion = new ConexionBD();

        public SqlNotificationInfo Accionejecutada { get; set; }
        public int ID_Consulta { get; set; } = 0;
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();
        
        
        //CONSTRUCTOR
        public Notificacionesbd()
        {
            try
            {
                // Stop an existing services on this connection string
                // just be sure
                SqlDependency.Stop(conexion.Getcadena);
                SqlDependency.Stop(conexion.GetcadenaDos);
                //SqlDependency.Start(conexion.GetcadenaDos);
                // Start the dependency
                // User must have SUBSCRIBE QUERY NOTIFICATIONS permission
                // Database must also have SSB enabled
                // ALTER DATABASE Chatter SET ENABLE_BROKER
                //SqlDependency.Start(m_ConnectionString);

                // Create the connection
                // m_sqlConn = new SqlConnection(m_ConnectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        //PONGO A LA ESCUCHA DE CAMBIOS AL SQL
        public void ListenerChange()
        {
            try
            {
                if (ID_Consulta <= 0 || GetConsulta() == "") { return; }

                if (ID_Consulta < 201)
                {                    
                    SqlCommand cmd = new SqlCommand(GetConsulta(), SqlConnection.State == ConnectionState.Open ? SqlConnection : conexion.Conectar());
                    cmd.Notification = null;                    
                    SqlDependency dependency = new SqlDependency(cmd);                    
                    dependency.OnChange += new OnChangeEventHandler(OnChange);                    
                    SqlDependency.Start(conexion.Getcadena);                     
                    cmd.ExecuteReader();

                    if (SqlConnection.State != ConnectionState.Open) { conexion.Desconectar(); }
                }
                else
                {                    
                    SqlCommand cmd = new SqlCommand(GetConsulta(), conexion.ConectarContabilidad());
                    cmd.Notification = null;
                    SqlDependency dependency = new SqlDependency(cmd);
                    SqlDependency.Start(conexion.GetcadenaDos);
                    dependency.OnChange += new OnChangeEventHandler(OnChange);                   
                    
                    cmd.ExecuteNonQuery();

                    if (SqlConnection.State != ConnectionState.Open) { conexion.Desconectar(); }
                }                                
            }
            catch (Exception e)
            {
                string a = e.Message;
                return;
            }
        }
        
        void OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = sender as SqlDependency;
            // Las notificaciones solo se realizan de a uno. 
            // Por ende removemos la existente para poder agregar una nueva.                                    
            dependency.OnChange -= OnChange;

            if (e.Type == SqlNotificationType.Change)
            {
                Accionejecutada = e.Info;
            }
            
            ListenerChange();            
        }

       
        //RETORNO LA CONSULTA 
        private string GetConsulta()
        {            
            switch (ID_Consulta)
            {
                //PRESTATARIAS
                case 1:
                    return "SELECT ID_Registro, Nombre, Cuit, ID_Iva, DomicilioFiscal," +
                            " Art, DiasVencimiento, MiPyme"+
                            " FROM [dbo].PRESTATARIAS";
                //PROFESIONALES
                case 2:
                    return "SELECT Nombre, TimeModif, Estado" +
                           " FROM [dbo].PROFESIONALES";
                //PRESTATARIAS DETALLES
                case 3:
                    return "SELECT ID_Registro, ID_Prestataria, Codigo, Descripcion, PorcIva, ID_Agrupador" +
                           " FROM [dbo].PRESTDETALLES";
                //PRACTICAS MAIN
                case 4:
                    return "SELECT  ID_Registro, Codigo, Descripcion, ID_Arancel, ID_Gasto, ID_Funcion, ID_Grupo, Estado" +
                           " FROM [dbo].PRACTAM";
                //PRESTATARIAS AGRUPADOR
                case 5:
                    return "SELECT ID_Registro, Codigo, Descripcion" +
                           " FROM [dbo].PRESTGRPVAL";                
                //ARANCELES
                case 6:
                    return "SELECT ID_Registro, Fecha, Observaciones, Estado" +
                           " FROM [dbo].ARANVALORIZAENC";
                //DISCUSIONES ENCABEZADO
                case 7:
                    return "SELECT ID_Registro, ID_AranValoriza, ID_GrupoValor, Guid, FechaInicio, FechaCierre, Estado, ID_UsuModif, TimeModif" +
                           " FROM [dbo].DISCUSIONENC";
                //DISCUSIONES DETALLE
                case 8:
                    return "SELECT ID_Registro, ID_Encabezado, Guid, FechaNeg, ID_Practica, CodigoOs, ID_Funcion, Observacion," +
                           " Valor, ValorCoseguro, EsAmdgo, ID_UsuModif ,TimeModif" +
                           " FROM [dbo].DISCUSIONDET";
                //ANESTESIA ENC
                case 9:
                    return "SELECT ID_UsuModif FROM [dbo].AUDIANESTESIAENC";
                //RECIBOS
                case 10:
                    return "SELECT IDUsuNew, IDUsuModif, EnviadoDos FROM [dbo].RECIBOSENC";
                //RECLAMOS
                case 11:
                    return "SELECT Urgencia, Estado, TimeModif FROM [dbo].RECLAMOSENC";
                //RECLAMOS
                case 12:
                    return "SELECT Estado, TimeModif, IDUsuNew, IDUsuModif FROM [dbo].DEVOLUCIONESENC";


                //*******************************************************************************************************************
                //******************************* BASE DE DATOS CONTABILIDAD ********************************************************
                //*******************************************************************************************************************
                //RETIROS
                case 201:
                    return "SELECT IDUsuModif, TimeModif FROM [dbo].[rt_RETIROENCABEZADOS]";
                case 202:
                    return "SELECT IDUsuModif, TimeModif, EnviadoDos, IDUsuNew, TimeNew FROM [dbo].[rt_RETIRODETALLES]";
                case 203:
                    return "SELECT IDUsuModif, TimeModif FROM [dbo].[EMPRESAS]";
                case 204:
                    return "SELECT IDUsuModif, TimeModif FROM [dbo].[EMPLEADOS]";
                case 205:
                    return "SELECT Descripcion, UsoReciboPrestataria, Seleccionable, Estado, TimeModif FROM [dbo].[pc_PLANCUENTAS]";
                case 206:
                    return "SELECT IDRegistro, TimeModif, Estado FROM [dbo].[ts_ORDENESPAGOENC]";
                case 207:
                    return "SELECT IDRegistro, Estado, TimeModif FROM [dbo].[ts_CAJAMOVIMIENTOS]";
                case 208:
                    return "SELECT IDRegistro, AsientoNumero, AsientoFecha, FechaCierreMensual, FechaCierreAnual, Observacion, IDUsuModif, TimeModif FROM [dbo].[ts_ASIENTOSCNTBLENC]";
                case 209:
                    return "SELECT IDRegistro, TimeModif FROM [dbo].[pc_CONFIGASIENTOS]";
                default: return "";

            }

        }
        
    }
}
