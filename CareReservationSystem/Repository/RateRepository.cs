using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace CareReservationSystem
{
    class RateRepository
    {
        public void SetBaseRate(string providerId, 
                                decimal rateValue, 
                                System.DateTime? activationDate,
                                List<Rate> nonRecurringRates,
                                List<WeeklyRate> weeklyRates)
        {
            var rate = new RateConfig {
                ProviderId = providerId,
                Date = System.DateTime.Now,
                BaseRateValue = rateValue,
                Note = "default rate",
                NonRecurringRates = nonRecurringRates,
                WeeklyRates = weeklyRates
            };

            string json = JsonSerializer.Serialize(rate);

            File.WriteAllText("rates.json", json);
        }

        public void SetRate(string providerId, 
                                decimal rateValue, 
                                System.DateTime? activationDate,
                                List<Rate> nonRecurringRates,
                                List<WeeklyRate> weeklyRates)
        {
            var rateConfig = new RateConfig {
                ProviderId = providerId,
                Date = System.DateTime.Now,
                BaseRateValue = rateValue,
                Note = "default rate",
                NonRecurringRates = nonRecurringRates,
                WeeklyRates = weeklyRates
            };

            string json = JsonSerializer.Serialize(rateConfig);

            File.WriteAllText("rates.json", json);
        }
    }
}