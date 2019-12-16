namespace PolishMinistryOfFinance.Models
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]

    public sealed class SoapEnvelope<T>
    {
        public string Header { get; set; } = string.Empty;
        public T Body { get; set; }
    }
}