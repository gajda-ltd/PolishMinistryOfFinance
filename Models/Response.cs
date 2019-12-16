namespace PolishMinistryOfFinance.Models
{
    using System.Xml.Serialization;

    public sealed class Response
    {
        private const string DEFAULT_NAMESPACE = "http://www.mf.gov.pl/uslugiBiznesowe/uslugiDomenowe/AP/WeryfikacjaVAT/2018/03/01";

        [XmlElement(ElementName = "Kod", Namespace = DEFAULT_NAMESPACE)]
        public string Code { get; set; }
        [XmlElement(ElementName = "Komunikat", Namespace = DEFAULT_NAMESPACE)]
        public string Message { get; set; }
    }
}
