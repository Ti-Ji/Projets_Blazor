using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ToDoApp.API.Services;
using ToDoApp.Shared;

namespace ToDoApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController(IWeatherService weatherService) : ControllerBase
{

	[HttpGet(Name = "GetWeatherForecast")]
	public IActionResult Get()
	{
		var weatherForecasts = weatherService.GetWeatherForecasts();
		if (!weatherForecasts.Any())
		{
			return new NoContentResult();
		}
		return Ok(weatherForecasts);
	}
}