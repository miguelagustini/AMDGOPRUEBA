using AMDGOINT.Formularios.Configuracion.Permisos.MC;
using DevExpress.XtraTab;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AMDGOINT.Clases
{
    class Globales
    {
        private Controles ctrl = new Controles();
        private ConexionBD conexion = new ConexionBD();
        private static int ID_Usuariolog { get; set; } = 0;
        private static string Usuariolog { get; set; } = "";
        private static bool Usuariosupervisor { get; set; } = false;
        private static XtraTabControl Maintab { get; set; } = new XtraTabControl();

        private static SqlConnection SqlConnection { get; set; } = new SqlConnection();
        private static List<Permiso> Permisos { get; set; } = new List<Permiso>();

        public void SetIdUsuariolog(int idusuario) { ID_Usuariolog = idusuario; }

        public int GetIdUsuariolog() { return ID_Usuariolog; }

        public void SetNomUsuariolog(string usuario) { Usuariolog = usuario; }

        public string GetNomUsuariolog() { return Usuariolog; }

        public void SetUsuariosuper(bool super) { Usuariosupervisor = super; }

        public bool GetUsuariosuper() { return Usuariosupervisor; }

        public void SetMaintab(XtraTabControl tab) { Maintab = tab; }

        public XtraTabControl GetMaintab() { return Maintab; }

        private void setConexion(SqlConnection sql)
        {
            SqlConnection = sql;
        }

        public SqlConnection GetConexion()
        {
            try
            {
                if (SqlConnection.State != ConnectionState.Open)
                { setConexion(conexion.Conectar()); }
                return SqlConnection;
            }
            catch (System.Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);                
                return new SqlConnection();
            }

        }

        private void setPermisos(List<Permiso> permiso)
        {
            Permisos.Clear();
            Permisos.AddRange(permiso);
        }

        public List<Permiso> GetPermisos(bool _forced = false)
        {
            try
            {
                if (_forced || Permisos.Count == 0)
                {
                    Permiso p = new Permiso();
                    setPermisos(p.GetPermisoUsuario());
                }

                return Permisos;
            }
            catch (System.Exception e)
            {
                ctrl.MensajeInfo($"{System.Reflection.MethodBase.GetCurrentMethod().Name}.\n{e.Message}", 1);
                return new List<Permiso>();
            }

        }

    }
}
