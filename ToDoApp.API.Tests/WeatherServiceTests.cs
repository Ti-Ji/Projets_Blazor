using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApp.API.Controllers;
using ToDoApp.API.Services;
using ToDoApp.Shared;

namespace ToDoApp.API.Tests;

public class WeatherServiceTests
{
	[Fact]
	public void GetWeatherForecasts_ReturnStatutNoContent()
	{
		//Arrange
		var mockService = new Mock<IWeatherService>();
		mockService.Setup(x => x.GetWeatherForecasts()).Returns(new List<WeatherForecast>());
		var controller = new WeatherForecastController(mockService.Object);

		//Act
		var result = controller.Get();

		//Assert
		result.Should().BeOfType<NoContentResult>();
	}

	[Fact]
	public void GetWeatherForecasts_ReturnStatutOk()
	{
		//Arrange
		var mockService = new Mock<IWeatherService>();
		mockService.Setup(x => x.GetWeatherForecasts()).Returns(
			new List<WeatherForecast>
			{
				new() { Date = DateTime.Now, TemperatureC = 20, Summary = "Hot" },
				new() { Date = DateTime.Now, TemperatureC = 30, Summary = "Cold" }
			});
		var controller = new WeatherForecastController(mockService.Object);

		//Act
		var result = controller.Get();

		//Assert
		result.Should().BeOfType<OkObjectResult>();
		((List<WeatherForecast>)((OkObjectResult)result).Value).Count.Should().Be(2);
	}
}