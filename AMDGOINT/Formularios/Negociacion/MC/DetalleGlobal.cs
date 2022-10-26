using AMDGOINT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace AMDGOINT.Formularios.Negociacion.MC
{
    public class DetalleGlobal : Detalles, INotifyPropertyChanged
    {
        //INSTANCIAMIENTO DE CLASES UTILIZADAS
        #region INSTANCIAMIENTO DE CLASES UTILIZADAS

        private Funciones func = new Funciones();
        private Controles ctrl = new Controles();
        private Globales glb = new Globales();

        #endregion

        //PROPIEDADES
        #region PROPIEDADES
        private string _codigoprestadora;
        private string _descripcionprestadora;
        private string _prestadorasincluidas;

        public string PrestadoraCodigo
        {
            get { return _codigoprestadora; }
            set { _codigoprestadora = _codigoprestadora != value.Trim() ? value.Trim() : _codigoprestadora; }
        }

        public string PrestadoraDescripcion
        {
            get { return _descripcionprestadora; }
            set { _descripcionprestadora = _descripcionprestadora != value.Trim() ? value.Trim() : _descripcionprestadora; }
        }

        public string PrestadorasIncluidas
        {
            get { return _prestadorasincluidas; }
            set { _prestadorasincluidas = _prestadorasincluidas != value.Trim() ? value.Trim() : _prestadorasincluidas; }
        }
                
        public string Prestataria
        {
            get { return PrestadoraDescripcion + " " + PrestadoraCodigo; }
        }

        public string FechaNegociacionpresent
        {
            get { return FechaNegociacion.Year.ToString() + "-" + FechaNegociacion.Month.ToString("00"); }
        }

        public string FechaImpactopresent
        {
            get { return FechaImpacto.Year.ToString() + "-" + FechaImpacto.Month.ToString("00"); }
        }

        #endregion

        //CONSTRUCTORES
        #region CONSTRUCTORES

        //CONSTRUCTOR VACIO
        public DetalleGlobal() { }

        public DetalleGlobal(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }

        #endregion

        //EVENTOS DE PROPERTY CHANGED
        #region PROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion

        //CLONACION
        #region CLONE

        //CLONE 
        public new DetalleGlobal Clone()
        {
            DetalleGlobal d = (DetalleGlobal)MemberwiseClone();
            return d;
        }

        //CLONE CON LISTAS
        public List<DetalleGlobal> Clone(List<DetalleGlobal> lst)
        {
            List<DetalleGlobal> lista = new List<DetalleGlobal>();

            lst.ForEach(f => lista.Add(f.Clone()));

            return lista;
        }

        #endregion

        //METODOS
        #region
        public List<DetalleGlobal> GetRegistrosAnalisis()
        {
            try
            {
                //CONSULTO LA LISTA GENERAL DE PROFESIONALES
                List<DetalleGlobal> lista = new List<DetalleGlobal>();

                string c = $"SELECT " +
                            //--ENCABEZADO
                            $"AE.Fecha AS FechaNegociacion, DE.FechaImpacto AS FechaImpacto, PRG.Codigo AS PrestadoraCodigo, PRG.Descripcion AS PrestadoraDescripcion, " +
                            $"ISNULL(STUFF((SELECT DISTINCT ',' + CONCAT('(', PD.Codigo, ' ', PD.Descripcion, ')') " +
                                           $"FROM DISCGRPVALHIST DH " +
                                           $"LEFT OUTER JOIN PRESTDETALLES PD ON(PD.ID_Registro = DH.ID_PrestDetalle) " +
                                           $"LEFT OUTER JOIN PRESTATARIAS PR ON(PR.ID_Registro = PD.ID_Prestataria) " +
                                           $"WHERE DH.ID_Encabezado = DE.ID_Registro " +
                                           $"FOR XML PATH('')), 1, LEN(','), ''), '') AS PrestadorasIncluidas, " +
                            //--DETALLES
                            $"PM.Codigo as PracticaCodigo, PM.Descripcion AS PracticaDescripcion, FU.Codigo AS FuncionCodigo, " +
                            $"FU.Descripcion AS FuncionDescripcion, FU.Letra AS FuncionLetra, PG.Descripcion AS GrupoDescripcion, PG.Orden AS GrupoOrden, DD.Valor, " +
                            $"ISNULL((SELECT TOP 1 DT.Valor " +
                                    $" FROM DISCUSIONDET DT " +
                                    $" WHERE DT.Aplicado = 2 AND DT.ID_Practica = DD.ID_Practica " +
                                    $" AND DT.ID_Encabezado = (SELECT TOP 1 F.ID_Registro " +
                                    $" FROM DISCUSIONENC F " +
                                    $" WHERE F.FechaImpacto < DE.FechaImpacto " +
                                    $" AND F.ID_GrupoValor = DE.ID_GrupoValor " +
                                    $" AND F.ID_AranValoriza <> DE.ID_AranValoriza " +
                                    $" ORDER BY F.FechaImpacto DESC)),0) AS ValorAnteriorPactado " +
                            $"FROM DISCUSIONENC DE " +
                            //--ENCABEZADOS
                            $"LEFT OUTER JOIN PRESTGRPVAL PRG ON(PRG.ID_Registro = DE.ID_GrupoValor) " +
                            $"LEFT OUTER JOIN ARANVALORIZAENC AE ON(AE.ID_Registro = DE.ID_AranValoriza) " +
                            //--DETALLES
                            $"LEFT OUTER JOIN DISCUSIONDET DD ON(DD.ID_Encabezado = DE.ID_Registro) " +
                            $"LEFT OUTER JOIN PRACTAM PM ON(PM.ID_Registro = DD.ID_Practica) " +
                            $"LEFT OUTER JOIN FUNCIONES FU ON(FU.ID_Registro = PM.ID_Funcion) " +
                            $"LEFT OUTER JOIN PRACTGRUPOS PG ON(PG.ID_Registro = PM.ID_Grupo) " +
                            $" WHERE DE.Visible = 1 AND DE.Estado = 2 AND DD.Aplicado = 2 AND DD.ID_Funcion <> 10 AND DD.ID_Funcion <> 4 ";  //AND DE.ID_Registro > 122 " +
                            //--SOLO MAXIMA FECHA POR NEGOCIACION Y APLICACION, YA QUE SE PUEDEN DAR EN 2 O MAS PARTES EL AUMENTO
                            /*$"AND DE.FechaImpacto = (SELECT MAX(FF.FechaImpacto) " +
                                                    $" FROM DISCUSIONENC FF" +
                                                    $" WHERE FF.Visible = 1 AND FF.ID_AranValoriza = DE.ID_AranValoriza" +
                                                    $" AND FF.ID_GrupoValor = DE.ID_GrupoValor AND FF.Estado = 2)";*/


                ConexionBD cnn = new ConexionBD();

                using (SqlCommand cmd = new SqlCommand(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : cnn.Conectar()))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    lista.AddRange(func.ConvertToList<DetalleGlobal>(rdr));
                }

                cnn.Desconectar();

                //OBTENGO LA TABLA
                /*DataTable tbl = func.getColecciondatos(c, SqlConnection.State == ConnectionState.Open ? SqlConnection : null);

                //POR CADA FILA
                foreach (DataRow r in tbl.Rows)
                {
                    //INSTANCIO NUEVO ENCABEZADO
                    DetalleGlobal a = new DetalleGlobal();

                    //POR CADA COLUMNA OBTENGO EL VALOR DE LA PROPIEDAD
                    foreach (DataColumn co in tbl.Columns)
                    {
                        if (r[co] != DBNull.Value)
                        {
                            GetType().GetProperty(co.ColumnName).SetValue(a, r[co]);
                        }
                    }

                    lista.Add(a);
                }

                tbl.Dispose();*/

                return lista;

            }
            catch (Exception e)
            {
                ctrl.MensajeInfo($"{GetType().Name}. Ocurrió un error al consultar los registros.\n{e.Message}", 0);
                return new List<DetalleGlobal>();
            }
        }
        #endregion
    }
}
