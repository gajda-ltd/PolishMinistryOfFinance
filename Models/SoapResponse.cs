namespace PolishMinistryOfFinance.Models
{
    using System.Xml.Serialization;

    public sealed class SoapResponse
    {
        private const string DEFAULT_NAMESPACE = "http://www.mf.gov.pl/uslugiBiznesowe/uslugiDomenowe/AP/WeryfikacjaVAT/2018/03/01";

        [XmlElement(ElementName = "WynikOperacji", Namespace = DEFAULT_NAMESPACE)]
        public Response Response { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();

        public SoapResponse()
        {
            xmlns.Add(string.Empty, DEFAULT_NAMESPACE);
        }
    }
}
