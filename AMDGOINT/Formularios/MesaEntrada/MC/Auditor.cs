using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.MesaEntrada.MC
{
    public class Auditor : INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES DE CLASE
                
        private string _nrointernacion = "";
        private string _nrobusqueda = "";
        private string _nrolote = "";
        private DateTime _fechaauditoria = DateTime.MinValue;
        private string _personaauditoria = "";
        private string _auditoriaobs = "";
        private string _auditoriaestado = "";

        public string NroInternacion
        {
            get { return _nrointernacion; }
            set { _nrointernacion = _nrointernacion != value.Trim() ? value.Trim() : _nrointernacion; }
        }

        public string NroBusqueda
        {
            get { return _nrobusqueda; }
            set { _nrobusqueda = _nrobusqueda != value.Trim() ? value.Trim() : _nrobusqueda; }
        }

        public string NroLote
        {
            get { return _nrolote; }
            set { _nrolote = _nrolote != value.Trim() ? value.Trim() : _nrolote; }
        }

        public DateTime AuditoriaFecha
        {
            get { return _fechaauditoria; }
            set { _fechaauditoria = _fechaauditoria != value ? value : _fechaauditoria; }
        }
        
        public string AuditoriaPersona
        {
            get { return _personaauditoria; }
            set { _personaauditoria = _personaauditoria != value.Trim() ? value.Trim() : _personaauditoria; }
        }

        public string AuditoriaObservacion
        {
            get { return _auditoriaobs; }
            set { _auditoriaobs = _auditoriaobs != value.Trim() ? value.Trim() : _auditoriaobs; }
        }

        public string AuditoriaEstado
        {
            get { return _auditoriaestado; }
            set { _auditoriaestado = _auditoriaestado != value.Trim() ? value.Trim() : _auditoriaestado; }
        }

        //PROPIEDAD DISPONIBLE PARA CONEXION
        public SqlConnection SqlConnection { get; set; } = new SqlConnection();

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public Auditor() { }

        public Auditor(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //PROPERTYES
        #region PROPERTIES

        //EVENTOS DE PROPERTY CHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion
               
        //CLONACION
        #region CLONE

        //CLONE 
        public Auditor Clone()
        {
            Auditor d = (Auditor)MemberwiseClone();
            return d;

        }

        //CLONE CON LISTAS
        public List<Auditor> Clone(List<Auditor> lst)
        {
            List<Auditor> lista = new List<Auditor>();

            foreach (Auditor d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

        //RETORNO DE LISTA 
        #region CONSULTA DE DATOS

        public List<Auditor> GetRegistros()
        {
            try
            {

                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<Auditor> lista = new List<Auditor>();

                string c = $"SELECT MD.MED2NBUS AS NroBusqueda, MD.MED2LOTE AS NroLote,'' AS NroInternacion, AU.AUDIFEAU AS AuditoriaFecha, AP.PERSNOMB AS AuditoriaPersona," +
                           $" ISNULL(MD.MED2AUDI,'') AS AuditoriaObservacion, ISNULL(AU.AUDIESTD,'') AS AuditoriaEstado" +
                           $" FROM AmdgoSis.dbo.ASOCMED2 MD" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = MD.MED2CPRO)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCAUDCONT AU ON(AU.AUDIPUNT = MD.MED2PUNT AND AU.AUDININT = '' AND AU.AUDINBUS = MD.MED2NBUS)" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPERS AP ON(AP.PERSCODI = AU.AUDIPERS)" +
                           $" WHERE FORMAT(CONVERT(datetime, MD.MED2FEPR, 105), 'yyyy-MM') > '2021-09' AND MD.MED2MESA LIKE '%1'" +
                           $" AND MD.MED2NBUS IN (SELECT AU1.AUDINBUS FROM AmdgoSis.dbo.ASOCAUDCONT AU1 WHERE AU1.AUDIESTD = '5')" +
                           $" UNION" +
                           $" SELECT '' AS NroBusqueda, '' AS NroLote, AI.MOVONINT AS NroInternacion, AU.AUDIFEAU AS AuditoriaFecha, AP.PERSNOMB AS AuditoriaPersona," +
                           $" '' AS AuditoriaObservacion, ISNULL(AU.AUDIESTD,'') AS AuditoriaEstado" +
                           $" FROM AmdgoSis.dbo.ASOCSAN1 AI" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCAUDCONT AU ON(AU.AUDININT = AI.MOVONINT AND AU.AUDININT <> '')" +
                           $" LEFT OUTER JOIN AmdgoSis.dbo.ASOCPERS AP ON(AP.PERSCODI = AU.AUDIPERS)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFCUENTAS PC ON(PC.Codigo = AI.MOVOCSAN)" +
                           $" LEFT OUTER JOIN AmdgoInterno.dbo.PROFESIONALES PF ON(PF.ID_Registro = PC.ID_Profesional)" +
                           $" WHERE FORMAT(CONVERT(datetime, AI.MOVOFEEN, 105), 'yyyy-MM') > '2021-09' AND" +
                           $" AI.MOVONINT IN (SELECT AU1.AUDININT FROM AmdgoSis.dbo.ASOCAUDCONT AU1 WHERE AU1.AUDIESTD = '5')";
                           

                //OBTENGO LA TABLA
                DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    Auditor a = new Auditor();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value) { GetType().GetProperty(co.ColumnName).SetValue(a, r[co]); }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<Auditor>();
            }
        }

        #endregion

    }
}
