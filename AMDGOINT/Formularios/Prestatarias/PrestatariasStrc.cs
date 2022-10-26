namespace AMDGOINT.Formularios.Prestatarias
{
    class PrestatariasStrc
    {
        public int ID_Registro { get; set; } = 0;
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Abreviatura { get; set; } = "";
        public long Cuit { get; set; } = 0;
        public short ID_Iva { get; set; } = 0;
        public string Iva { get; set; } = "";
        public bool MiPyme { get; set; } = false;
        public int DiasVencimiento { get; set; } = 0;
        public decimal PorcIva { get; set; } = 0;

    }
}
