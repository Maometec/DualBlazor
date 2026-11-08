using DualBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DualBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeather")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (Summaries.Length <= 0 && Summaries.Length >= 9)
        {
            var value = Summaries.GetValue(id);
            return Ok(value);
        }

        return NotFound();
    }
}
