namespace ToDoApp.Shared;

public class WeatherForecast
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	public DateTime Date { get; set; }
	public int TemperatureC { get; set; }
	public string? Summary { get; set; }
}