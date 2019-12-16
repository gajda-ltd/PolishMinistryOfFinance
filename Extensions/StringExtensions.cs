namespace PolishMinistryOfFinance.Extensions
{
    using System.Xml;

    internal static class StringExtensions
    {
        internal static string ToFormattedXml(this string source)
        {
            var xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(source);
            }
            catch
            {
                return source;
            }

            return xmlDocument.ExportToString();
        }
    }
}
