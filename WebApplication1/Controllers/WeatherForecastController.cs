using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly UserManager<User> userManager;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ApplicationDbContext _applicationDb, 
            UserManager<User> _userManager)
        {
            _logger = logger;
            applicationDb = _applicationDb;
            userManager = _userManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Task<IEnumerable<WeatherForecast>> Get()
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            var tcs = new TaskCompletionSource<IEnumerable<WeatherForecast>>();
            tcs.SetResult(result);
            return tcs.Task;

        }
    }
}
