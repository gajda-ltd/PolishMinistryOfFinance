namespace PolishMinistryOfFinance.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TaxIdentificationNumberEntity
    {
        [Key]
        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string Message { get; set; }
    }
}