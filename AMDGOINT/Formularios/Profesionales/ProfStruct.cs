using System;
using System.Collections.Generic;

namespace AMDGOINT.Formularios.Profesionales
{
    public class ProfStruct
    {
        public int ID_Registro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Domfiscal { get; set; } = "";
        public string Email { get; set; } = "";
        public long Cuit { get; set; } = 0;
        public short ID_Iva { get; set; } = 0;
        public string Iva { get; set; } = "";
        public string IngresosBr { get; set; } = "";
        public DateTime FecInicioa { get; set; } 
        public int PuntoVenta { get; set; } = 0;        
        public string Libro { get; set; } = "";
        public string Folio { get; set; } = "";
        public string Titulo { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string FechaVtocateg { get; set; } = "";
        public string MatriculaNac { get; set; } = "";
        public string MatriculaProv { get; set; } = "";
        public string FechaNacimiento { get; set; } = "";
        public string FechaIngreso { get; set; } = "";
        public string Universidad { get; set; } = "";
        public string FechaGraduacion { get; set; } = "";
        public string CodigoArteCurar { get; set; } = "";
        public int NroActa { get; set; } = 0;
        public string RegNacPrestador { get; set; } = "";
        public string VtoRegNacPrestador { get; set; } = "";
        public string Observaciones { get; set; } = "";
        public string Referencia { get; set; } = "";
        public string Estado { get; set; } = "";

        public List<ProfDirecciones> Direcciones { get; set; } = new List<ProfDirecciones>();
        public List<ProfEspecialidad> Especialidades { get; set; } = new List<ProfEspecialidad>();

    }

    public class ProfesionalesFemefse : ProfStruct
    {
        public int IDRegistro { get; set; } = 0;
        public short Profesion { get; private set; } = 1;        
        public string NewNombre
        {
            get
            {
                string _new = "";

                if (!Nombre.Contains(","))
                {
                    string[] prev = Nombre.Replace(",", "").Split(' ');

                    short count = 0;
                    foreach (var palabra in prev)
                    {
                        _new += count == 0 ? palabra + ", " : palabra + " ";
                        count++;
                    }
                }
                else { _new = Nombre; }

                return _new.Trim();
            } 
        }
        public long Documento
        {
            get
            {
                if (Cuit.ToString().Length >= 11)
                {
                    return Convert.ToInt64(Cuit.ToString().Substring(2, 8));
                }
                else { return 0; }
            }            
        }
        public string Sexo { get; set; } = "M";
        public short TipoDni
        {
            get
            {
                if (Documento.ToString().Length <= 7 && Sexo == "M") { return 6; }
                else if (Documento.ToString().Length <= 7 && Sexo == "F") { return 1; }
                else if (Documento.ToString().Length == 8 && (Sexo == "F" || Sexo == "M" || Sexo == "")) { return 2; }
                else { return 99; }
            }
        }
        public string Calle { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Piso { get; set; } = "";
        public string Departamento { get; set; } = "";
        public string OtrosDatos { get; set; } = "";
        public string Localidad { get; set; } = "";
        public string CodigoPostal { get; set; } = "";
        public string FullLocalidad
        {
            get
            {
                if (Localidad != "" && CodigoPostal != "") { return Localidad + " (" + CodigoPostal + ")"; }
                else if (Localidad != "" && CodigoPostal == "") { return Localidad; }
                else { return  ""; }


            }
        } 
        public string Telefono { get; set; } = "";        
        public string Especialidad { get; set; } = "";
        public string Mail { get; set; } = "";        
        public string Delegacion { get; set; } = "General Obligado";
        public string Provincia { get; set; } = "";

    }

    public class ProfDirecciones
    {
        public int IDRegistro { get; set; } = 0;
        public int IDProfesional { get; set; } = 0;
        public string Domicilio { get; set; } = "";
        public string Tipo { get; set; } = "";
        public string Localidad { get; set; } = "";
        public string CodPostal { get; set; } = "";
        public List<ProfContactos> Contactos { get; set; } = new List<ProfContactos>();

    }

    public class ProfContactos
    {
        public int IDRegistro { get; set; } = 0;
        public int IDDireccion { get; set; } = 0;
        public string Telefono { get; set; } = "";
        public string Email { get; set; } = "";        
    }

    public class ProfEspecialidad
    {
        public int IDRegistro { get; set; } = 0;
        public int IDProfesional { get; set; } = 0;
        public string Especialidad { get; set; } = "";
        public string NroRegistro { get; set; } = "";
        public bool Recertificado { get; set; } = false;
    }

}
