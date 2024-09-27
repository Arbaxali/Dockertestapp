using Microsoft.AspNetCore.Mvc;
using TestWebapp.Services;
using TestWebapp.Models;


namespace TestWebapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecas")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("InsertNameAndDob")]
        public ActionResult<NameDobModel> InsertNameDob([FromBody] NameDobModel payload)
        {
            if (payload == null)
            {
                return BadRequest("Payload is null");
            }

            var result = NameMapper.Mapper(payload);

 

            var jsonResponse = result.ToString(); // Convert JObject to JSON string

            return Content(jsonResponse, "application/json");




        }
    }
}
