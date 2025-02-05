using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Services;

namespace ToDoApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController(IWeatherService weatherService) : ControllerBase
{
	[HttpGet(Name = "GetWeatherForecast")]
	public IActionResult Get()
	{
		var weatherForecasts = weatherService.GetWeatherForecasts();
		if (!weatherForecasts.Any()) return new NoContentResult();
		return Ok(weatherForecasts);
	}
}