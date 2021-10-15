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
        [HttpPost("SetRate")]
        public void Post([FromBody] RateConfig data)
        {
                var db = new RateRepository();

                db.SetRate(data);
        }

        [HttpGet("GetRates")]
        public RateConfig GetRates(string providerId)
        {
            var db = new RateRepository();

            return db.GetRatesByProviderId(providerId);

        }

        [HttpGet("GetRateByDate")]
        public decimal GetRateByDate(string providerId, DateTime startDate, DateTime finishDate)
        {
            var db = new RateRepository();

            return db.GetRateByDate(providerId, startDate, finishDate);

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
