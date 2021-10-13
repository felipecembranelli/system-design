using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CareReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RateController> _logger;

        public RateController(ILogger<RateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// set base rate.
        /// </summary>
        [HttpPost("SetBaseRate")]
        public void Post([FromBody] RateConfig data)
        {
                var db = new RateRepository();

                //var valueSet = JsonSerializer.Deserialize<RateConfig>(data);

                // db.SetBaseRate(data["ProviderId"].ToString(), 
                //                 decimal.Parse(data["RateValue"].ToString()), 
                //                 null,
                //                 (List<Rate>)data["NonRecurringRates"],
                //                 (List<WeeklyRate>)data["WeeklyRates"]);
        }

        // [HttpGet]
        // public IEnumerable<Rate> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
