using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Controllers;
using ToDoApp.API.Tests.Fake;
using ToDoApp.Shared;

namespace ToDoApp.API.Tests;

public class WeatherServiceTestsWithFake
{
	[Fact]
	public void GetWeatherForecasts_ReturnStatutOk()
	{
		//Arrange
		var fakeService = new FakeWeatherService();
		var controller = new WeatherForecastController(fakeService);

		//Act
		var result = controller.Get();

		//Assert
		result.Should().BeOfType<OkObjectResult>();
		((List<WeatherForecast>)((OkObjectResult)result).Value).Count.Should().Be(2);
	}
}