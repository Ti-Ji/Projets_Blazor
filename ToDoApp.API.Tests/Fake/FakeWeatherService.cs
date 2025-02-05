using ToDoApp.API.Services;
using ToDoApp.Shared;

namespace ToDoApp.API.Tests.Fake;

public class FakeWeatherService : IWeatherService
{
	public IEnumerable<WeatherForecast> GetWeatherForecasts()
	{
		return new List<WeatherForecast>
		{
			new() { Date = DateTime.Now, TemperatureC = 20, Summary = "Hot" },
			new() { Date = DateTime.Now, TemperatureC = 30, Summary = "Cold" }
		};
	}
}