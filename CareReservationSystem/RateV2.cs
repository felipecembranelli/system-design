using System;
using System.Collections.Generic;

namespace CareReservationSystem
{
    public class RateConfig
    {
        public string ProviderId {get;set;}
        
        public DateTime Date { get; set; }

        public decimal BaseRateValue { get; set; }

        public string Note { get; set; }

        public List<Rate> NonRecurringRates { get; set; }

        public List<WeeklyRate> WeeklyRates { get; set; }

        public List<MonthlyRate> MonthlyRates { get; set; }
    }

    public class Rate 
    {
        public DateTime Date { get; set; }

        public decimal RateValue { get; set; }

    }

    public class WeeklyRate 
    {
        public string[] WeekDays { get; set; }

        public decimal RateValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

    }

    public class MonthlyRate 
    {
        public string[] MonthDays { get; set; }

        public decimal RateValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

    }

    public class YearlyRate 
    {
        public string[] MonthDays { get; set; }

        public decimal RateValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

    }
}
