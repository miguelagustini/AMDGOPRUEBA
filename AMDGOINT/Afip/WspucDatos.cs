﻿using AMDGOINT.Clases;
using AMDGOINT.WSPDR.PROD;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AmdgoInterno.Afip
{
    class WspucDatos
    {
        private Controles ctrls = new Controles();

        public AfipProdLog login { get; set; }
        public persona Persona { get; set; }

        private PersonaServiceA5 srv = new PersonaServiceA5();

        private long Cuitempresa { get; set; } = 0;

        public bool loginafip(string certificadodir, string clavecert, long cuit)
        {
            try
            {
                Cuitempresa = cuit;
                AfipProdLog log = new AfipProdLog(certificadodir, clavecert);
                log.urlWSDL = "https://aws.afip.gov.ar/sr-padron/webservices/personaServiceA5?WSDL";// "https://awshomo.afip.gov.ar/sr-padron/webservices/personaServiceA5?wsdl";
                log.server = "ws_sr_constancia_inscripcion";
                log.HacerLogin(Cuitempresa, 1);
                login = log;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //CONSULTO EL NOMBRE DE LA PERSONA
        public Entidad GetEntidad(long cuit, string certificadodir, string clavecert, long cuitcertificado)
        {

            Entidad retorno = new Entidad();

            try
            {
                if (cuit == 0 || certificadodir == "" || clavecert == "" || cuitcertificado == 0) { return retorno; }

                //LOGIN
                if (!loginafip(certificadodir, clavecert, cuitcertificado)) { return retorno; }

                //Obtengo el xml
                personaReturn persona1 = new personaReturn();
                persona1 = srv.getPersona_v2(login.Token, login.Sign, Cuitempresa, cuit);
                

                //Convierto el xml a un string valido
                XmlSerializer xmlSrl = new XmlSerializer(persona1.GetType());
                StringWriter txtWrtr = new StringWriter();
                xmlSrl.Serialize(txtWrtr, persona1);

                //Paso ese string en formato xml valido, a un json para utilizar sus clases
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(txtWrtr.ToString());
                string json = JsonConvert.SerializeXmlNode(doc);

                var r = JsonConvert.DeserializeObject<Entidad>(json);

                return r;

            }
            catch (Exception e)
            {
                if (e.HResult != -2146233087) { ctrls.MensajeInfo("Ocurrió un error al consultar el padron." + e.Message, 0); }
                return retorno;
            }
        }

    }
}

public class Entidad
{
    public Xml xml { get; set; }
    public Personareturn personaReturn { get; set; }
}

public class Xml
{
    public string version { get; set; }
    public string encoding { get; set; }
}

public class Personareturn
{
    public string xmlnsxsd { get; set; }
    public string xmlnsxsi { get; set; }
    public Datosgenerales datosGenerales { get; set; }
    public Datosregimengeneral datosRegimenGeneral { get; set; }
    public Errorconstancia errorConstancia { get; set; }
    public Metadata metadata { get; set; }
}

public class Errorconstancia
{
    public string[] error { get; set; }
    public string idPersona { get; set; }
}

public class Datosgenerales
{
    [JsonConverter(typeof(SingleOrArrayConverter<Caracterizacion>))]
    public List<Caracterizacion> caracterizacion { get; set; }
    public string apellido { get; set; }
    public Domiciliofiscal domicilioFiscal { get; set; }
    public string estadoClave { get; set; }
    public DateTime fechaContratoSocial { get; set; }
    public string idPersona { get; set; }
    public string mesCierre { get; set; }
    public string nombre { get; set; }
    public string razonSocial { get; set; }
    public string tipoClave { get; set; }
    public string tipoPersona { get; set; }
}

public class Domiciliofiscal
{
    public string codPostal { get; set; }
    public string descripcionProvincia { get; set; }
    public string direccion { get; set; }
    public string idProvincia { get; set; }
    public string localidad { get; set; }
    public string tipoDomicilio { get; set; }
}

public class Caracterizacion
{
    public string descripcionCaracterizacion { get; set; }
    public string idCaracterizacion { get; set; }
    public string periodo { get; set; }
}

public class Datosregimengeneral
{
    [JsonConverter(typeof(SingleOrArrayConverter<Actividad>))]
    public List<Actividad> actividad { get; set; }

    [JsonConverter(typeof(SingleOrArrayConverter<Impuesto>))]
    public List<Impuesto> impuesto { get; set; }

    [JsonConverter(typeof(SingleOrArrayConverter<Regiman>))]
    public List<Regiman> regimen { get; set; }
}

public class Actividad
{
    public string descripcionActividad { get; set; }
    public string idActividad { get; set; }
    public string nomenclador { get; set; }
    public string orden { get; set; }
    public string periodo { get; set; }
}

public class Impuesto
{
    public string descripcionImpuesto { get; set; }
    public string idImpuesto { get; set; }
    public string periodo { get; set; }
}

public class Regiman
{
    public string descripcionRegimen { get; set; }
    public string idImpuesto { get; set; }
    public string idRegimen { get; set; }
    public string periodo { get; set; }
    public string tipoRegimen { get; set; }
}

public class Metadata
{
    public DateTime fechaHora { get; set; }
    public string servidor { get; set; }
}

public class SingleOrArrayConverter<T> : JsonConverter
{
    public override bool CanConvert(Type objecType)
    {
        return (objecType == typeof(List<T>));
    }

    public override object ReadJson(JsonReader reader, Type objecType, object existingValue,
        JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.Array)
        {
            return token.ToObject<List<T>>();
        }
        return new List<T> { token.ToObject<T>() };
    }

    public override bool CanWrite
    {
        get { return false; }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}




