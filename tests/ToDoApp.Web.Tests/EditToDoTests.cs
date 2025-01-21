using AngleSharp.Dom;
using Bunit;
using FluentAssertions;
using ToDoApp.Shared;
using ToDoApp.Web.Client.Pages.Components;

namespace ToDoApp.Web.Tests;

public class EditToDoTests:TestContext
{
		[Fact]
		public void EditToDoComponentRendersCorrectly()
		{
			// Arrange
			var todoItem = new ToDoItem { Id = 1, Name = "Test ToDo", Status = 0 };

			// Act
			var cut = RenderComponent<EditToDo>(parameters => parameters
				.Add(p => p.Id, todoItem.Id)
				.Add(p => p.ToDoItems, new List<ToDoItem> { todoItem })
			);

			// Assert
			cut.Find("#name").GetAttribute("Value").Should().Be(todoItem.Name);
			cut.Find("#status > option").TextContent.Should().Be("Not Started");
		}
}