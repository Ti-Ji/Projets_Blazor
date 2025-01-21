using Microsoft.AspNetCore.Components;
using ToDoApp.Shared;

namespace ToDoApp.Web.Client.Pages;

public partial class ToDos : ComponentBase
{
	[Parameter] public int? EditId { get; set; }

	private readonly List<ToDoItem> ToDoItems = new()
	{
		new ToDoItem { Id = 1, Name = "Task 1", Date = DateTime.Now, Status = TodoStatus.NotStarted },
		new ToDoItem { Id = 2, Name = "Task 2", Date = DateTime.Now.AddDays(1), Status = TodoStatus.InProgress },
		new ToDoItem { Id = 3, Name = "Task 3", Date = DateTime.Now.AddDays(2), Status = TodoStatus.Completed }
	};

	private void Callback(ToDoItem obj)
	{
		if (obj.Id == 0)
		{
			obj.Id = ToDoItems.Max(x => x.Id) + 1;
			ToDoItems.Add(obj);
		}
		else
		{
			var index = ToDoItems.FindIndex(x => x.Id == obj.Id);
			ToDoItems[index] = obj;
		}

		EditId = null;
	}

	private void SetItem(ToDoItem obj)
	{
		EditId = obj.Id;
		StateHasChanged();
	}
}