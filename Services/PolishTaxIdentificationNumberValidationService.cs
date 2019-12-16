namespace PolishMinistryOfFinance.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using PolishMinistryOfFinance.Extensions;
    using PolishMinistryOfFinance.Models;

    public sealed class PolishTaxIdentificationNumberValidationService
    {
        private const string SERVICE_URL = "https://sprawdz-status-vat.mf.gov.pl";
        private readonly HttpClient httpClient = new HttpClient();

        public PolishTaxIdentificationNumberValidationService()
        {
            using (var cache = new CacheContext())
            {
                cache.Database.EnsureCreated();
            }
        }

        public void Refresh()
        {
            var numbers = new List<string>();
            using (var cache = new CacheContext())
            {
                numbers.AddRange(cache.TaxIdentificationNumbers.Where(w => w.Date < DateTime.Today).Select(s => s.Number).Distinct().ToList());
            }

            if (numbers.Any())
            {
                foreach (var number in numbers)
                {
                    var entity = this.Download(number);
                    this.Persist(entity);
                }
            }
        }

        public TaxIdentificationNumberEntity Check(string polishTaxIdentificationNumber, DateTime? date = null)
        {
            var entity = this.Query(polishTaxIdentificationNumber, date);

            if (entity != null)
            {
                return entity;
            }

            entity = this.Download(polishTaxIdentificationNumber);
            this.Persist(entity);
            return entity;
        }

        private TaxIdentificationNumberEntity Download(string polishTaxIdentificationNumber, DateTime? date = null)
        {
            var request = new SoapEnvelope<SoapRequest>
            {
                Body = new SoapRequest
                {
                    Date = date,
                    Nip = polishTaxIdentificationNumber,
                }
            }.Serialize();

            Console.WriteLine(request);

            var content = new StringContent(request, Encoding.UTF8, "text/xml");

            if (date.HasValue)
            {
                content.Headers.Add("SOAPAction", "http://www.mf.gov.pl/uslugiBiznesowe/uslugiDomenowe/AP/WeryfikacjaVAT/2018/03/01/WeryfikacjaVAT/SprawdzNIPNaDzien");
            }
            else
            {
                content.Headers.Add("SOAPAction", "http://www.mf.gov.pl/uslugiBiznesowe/uslugiDomenowe/AP/WeryfikacjaVAT/2018/03/01/WeryfikacjaVAT/SprawdzNIP");
            }

            var response = httpClient.PostAsync(SERVICE_URL, content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result.ToFormattedXml());

            return new TaxIdentificationNumberEntity
            {
                Date = DateTime.Today,
                Number = polishTaxIdentificationNumber,
                Message = result.Deserialize().Body.Response.Message
            };
        }

        private TaxIdentificationNumberEntity Query(string polishTaxIdentificationNumber, DateTime? date = null)
        {
            using (var cache = new CacheContext())
            {
                return cache.TaxIdentificationNumbers.SingleOrDefault(tin => tin.Number == polishTaxIdentificationNumber && tin.Date == date);
            }
        }

        private void Persist(TaxIdentificationNumberEntity entity)
        {
            using (var cache = new CacheContext())
            {
                var result = cache.TaxIdentificationNumbers.SingleOrDefault(tin => tin.Number == entity.Number);
                if (result != null)
                {
                    result.Date = entity.Date;
                    result.Message = entity.Message;
                }
                else
                {
                    cache.TaxIdentificationNumbers.Add(entity);
                }

                cache.SaveChanges();
            }
        }
    }
}
