using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AMDGOINT.Formularios.Reclamos.MC
{
    public class ImportacionDebitosEstructura
    {
        private static string tablaname = "[AmdgoSis].[dbo].[importaciondebitoscreditos]";
        public int movpcoda { get; set; } = 0;
        public decimal movpdebito { get; set; } = 0;
        public decimal movpcredito { get; set; } = 0;
        public string movpmotivo { get; set; } = "";
        public string movpcdob { get; set; } = "";
        public string movpprof { get; set; } = "";
        public string movpadmi { get; set; } = "";
        public string movppefa { get; set; } = "";
        public string movpcomprobante { get; set; } = "";

        public SqlConnection SqlConnection { get; set; } = new SqlConnection();


        //CONSTRUCTOR VACIO
        #region ESTRUCTURA
        public ImportacionDebitosEstructura() { }

        public ImportacionDebitosEstructura(SqlConnection conexion)
        {
            SqlConnection = conexion;
        }
        
        #endregion

        //EVENTOS DE CLASE
        #region PROPERTY CHANGED

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
        public ImportacionDebitosEstructura Clone()
        {
            ImportacionDebitosEstructura e = (ImportacionDebitosEstructura)MemberwiseClone();            

            return e;

        }

        //CLONE CON LISTAS
        public List<ImportacionDebitosEstructura> Clone(List<ImportacionDebitosEstructura> lst)
        {
            List<ImportacionDebitosEstructura> lista = new List<ImportacionDebitosEstructura>();

            foreach (ImportacionDebitosEstructura d in lst)
            {
                lista.Add(d.Clone());
            }

            return lista;

        }

        #endregion

    }
}
