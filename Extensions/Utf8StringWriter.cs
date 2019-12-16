namespace PolishMinistryOfFinance.Extensions
{
    using System.IO;
    using System.Text;

    internal sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
