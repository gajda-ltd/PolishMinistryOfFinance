namespace PolishMinistryOfFinance.Extensions
{
    using System.Xml;

    internal static class XmlDocumentExtensions
    {
        internal static string ExportToString(this XmlDocument source)
        {
            var stringWriter = new Utf8StringWriter();
            using (XmlWriter xmlTextWriter = XmlWriter.Create(
                stringWriter,
                new XmlWriterSettings
                {
                    Indent = true
                }))
            {
                source.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();

                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
