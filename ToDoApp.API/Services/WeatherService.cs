using ToDoApp.Shared;

namespace ToDoApp.API.Services;

public class WeatherService : IWeatherService
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public IEnumerable<WeatherForecast> GetWeatherForecasts()
	{
		var rng = new Random();
		return Enumerable.Range(1, 5).Select(
			index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			}).ToArray();
	}
}

public interface IWeatherService
{
	IEnumerable<WeatherForecast> GetWeatherForecasts();
}