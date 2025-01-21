using Bunit;
using FluentAssertions;
using ToDoApp.Shared;
using ToDoApp.Web.Client.Pages;

namespace ToDoApp.Web.Tests;

public class DisplayToDoTests :TestContext
{
	[Fact]
	public void DisplayToDoComponentRendersCorrectly()
	{
		// Act
		var cut = RenderComponent<ToDos>();

		// Assert
		cut.FindAll("td").Should().HaveCount(3);
		cut.Find("td > ul > fluent-card").ChildNodes[0].TextContent.Should().StartWith("Task 1 (21/01/2025)");
		cut.Find("td:nth-of-type(2) > ul > fluent-card").ChildNodes[0].TextContent.Should().StartWith("Task 2 (22/01/2025)");
		cut.Find("td:nth-of-type(3) > ul > fluent-card").ChildNodes[0].TextContent.Should().StartWith("Task 3 (23/01/2025)");
	}
}