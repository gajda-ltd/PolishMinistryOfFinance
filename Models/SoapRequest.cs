namespace PolishMinistryOfFinance.Models
{
    using System;
    using System.Xml.Serialization;

    public sealed class SoapRequest
    {
        private const string DEFAULT_NAMESPACE = "http://www.mf.gov.pl/uslugiBiznesowe/uslugiDomenowe/AP/WeryfikacjaVAT/2018/03/01";

        [XmlElement(ElementName = "NIP", Namespace = DEFAULT_NAMESPACE)]
        public string Nip { get; set; }
        [XmlElement(ElementName = "Data", Namespace = DEFAULT_NAMESPACE, DataType = "date", IsNullable = true)]
        public DateTime? Date { get; set; }
        [XmlIgnore]
        public bool DateSpecified => this.Date.HasValue;
    }
}
