namespace PolishMinistryOfFinance.Extensions
{
    using PolishMinistryOfFinance.Models;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public static class SoapEnvelopeExtensions
    {
        public static SoapEnvelope<SoapResponse> Deserialize(this string @string)
        {
            var serializer = new XmlSerializer(typeof(SoapEnvelope<SoapResponse>));
            using (var textReader = new StringReader(@string))
            {
                return (SoapEnvelope<SoapResponse>)serializer.Deserialize(textReader);
            }
        }

        public static string Serialize(this SoapEnvelope<SoapRequest> @object)
        {
            var serializer = new XmlSerializer(typeof(SoapEnvelope<SoapRequest>));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
            };

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            namespaces.Add("ns", "http://www.mf.gov.pl/uslugiBiznesowe/uslugiDomenowe/AP/WeryfikacjaVAT/2018/03/01");

            using (var textWriter = new Utf8StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, @object, namespaces);
                }

                return textWriter.ToString();
            }
        }
    }
}