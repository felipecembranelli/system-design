using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
namespace CareReservationSystem
{
    class RateRepository
    {
        public void SetRate(RateConfig rateConfig)
        {
            var rate = new RateConfig {
                ProviderId = rateConfig.ProviderId,
                BaseRateValue = rateConfig.BaseRateValue,
                Rates = rateConfig.Rates
            };

            string json = JsonSerializer.Serialize(rate);

            var fileName = string.Format("CareReservationSystem/Data/rates_{0}.json", rateConfig.ProviderId);

            File.WriteAllText(fileName, json);
        }

        public RateConfig GetRatesByProviderId(string providerId)
        {
            var fileName = string.Format("CareReservationSystem/Data/rates_{0}.json", providerId);

            var content = File.ReadAllText(fileName);

            var rateConfig = JsonSerializer.Deserialize<RateConfig>(content);

            return rateConfig;
        }

        public decimal GetRateByDate(string providerId, DateTime startDate, DateTime finishDate)
        {
            var fileName = string.Format("CareReservationSystem/Data/rates_{0}.json", providerId);

            var content = File.ReadAllText(fileName);

            var rateConfig = JsonSerializer.Deserialize<RateConfig>(content);

            var rate = this.GetRateByDate(rateConfig.Rates, startDate, finishDate);

            return rate;
        }

        // Calculate the highest rate based on all the rates available for this provider
        private decimal GetRateByDate(List<Rate> rates, DateTime startDate, DateTime finishDate)        
        {
            var selectedRates = rates.Where(d => (startDate >= d.StartDate && startDate <= d.FinishDate)
                                                || (finishDate >= d.StartDate && finishDate <= d.FinishDate));


            var highestRate = 0m;

            if (selectedRates.Count() >0)
                highestRate = selectedRates.Max(r => r.RateValue);

            return highestRate;
        }
    }
}