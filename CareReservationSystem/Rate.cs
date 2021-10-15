using System;
using System.Collections.Generic;

namespace CareReservationSystem
{
    public class RateConfig 
    {
        public string ProviderId {get;set;}

        public decimal BaseRateValue { get; set; }
        
        public string? Note { get; set; }


        public List<Rate> Rates {get; set;}

    }
    public class Rate
    {
        public decimal RateValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public RecurrencyType RecurrencyType { get; set; }

        public DayOfWeek? WeeklyOnDayofWeek { get; set; } // apply only for recurrency type = weekly

    }

    public enum RecurrencyType
    {
        NoRecurrent = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    }
}
