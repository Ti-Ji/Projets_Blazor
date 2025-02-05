using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApp.API.Controllers;
using ToDoApp.API.Services;
using ToDoApp.Shared;

namespace ToDoApp.API.Tests2;

public class UnitTest1
{
	[Fact]
	public void Test1()
	{
		//test WeatherForecastController
		//Arrange
		var mockService = new Mock<IWeatherService>();
		mockService.Setup(x => x.GetWeatherForecasts()).Returns(new List<WeatherForecast>
		{
			new WeatherForecast { Date = DateTime.Now, TemperatureC = 20, Summary = "Hot" },
			new WeatherForecast { Date = DateTime.Now, TemperatureC = 30, Summary = "Cold" }
		});
		
		var controller = new WeatherForecastController(mockService.Object);
		
		//Act
		var result = controller.Get();
		
		//Assert
		result.Should().BeOfType<OkObjectResult>();
		((List<WeatherForecast>)((OkObjectResult)result).Value).Count.Should().Be(2);
	}
	
	[Fact]
	public void Test2()
	{
		//test WeatherForecastController
		//Arrange
		var mockService = new Mock<IWeatherService>();
		mockService.Setup(x => x.GetWeatherForecasts()).Returns(new List<WeatherForecast>());
		
		var controller = new WeatherForecastController(mockService.Object);
		
		//Act
		var result = controller.Get();
		
		//Assert
		result.Should().BeOfType<NoContentResult>();
	}
}