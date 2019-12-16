namespace PolishMinistryOfFinance
{
    using System;
    using System.Collections.Generic;
    using PolishMinistryOfFinance.Services;

    class Program
    {
        static void Main(string[] args)
        {
            var service = new PolishTaxIdentificationNumberValidationService();

            service.Refresh();

            var examples = new List<string> { "8721124883", "8133379681", "5241019127" };

            foreach (var example in examples)
            {
                var status = service.Check(example, DateTime.Today);
                Console.WriteLine($"{status.Number}: {status.Message}");
            }
        }
    }
}
