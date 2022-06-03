using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Forecasts.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodWeatherForecastController : ControllerBase
{
    [HttpGet("default-forecast", Name = "GetDefaultWheaterForecast")]
    public async Task<IActionResult> GetDefault()
    {
        string message = "Good weather forecast";
        return Ok(message);
    }
    
    [HttpGet("temperature", Name = "GetCelsiusTemperature")]
    public async Task<IActionResult> GetTemperature(int? n1, int? n2)
    {
        int temperature = n1 + n2 ?? 77;
        return Ok(temperature);
    }
}