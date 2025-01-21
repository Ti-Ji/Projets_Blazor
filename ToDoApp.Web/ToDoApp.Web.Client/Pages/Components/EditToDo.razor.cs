using Microsoft.AspNetCore.Components;
using ToDoApp.Shared;

namespace ToDoApp.Web.Client.Pages.Components;

public partial class EditToDo
{
	[Parameter] public int? Id { get; set; }

	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? AdditionalAttributes { get; set; }
	[Parameter] public List<ToDoItem>? ToDoItems { get; set; }
	[Parameter] public EventCallback<ToDoItem> OnValidSubmit { get; set; }
	[Inject] private NavigationManager? NavigationManager { get; set; }

	private ToDoItem? _todoItem;

	protected override void OnParametersSet()
	{
		_todoItem = Id.HasValue && ToDoItems != null && ToDoItems.Count != 0
			? ToDoItems.FirstOrDefault(item => item.Id == Id)
			: new ToDoItem();
	}

	private async Task HandleValidSubmit()
	{
		await OnValidSubmit.InvokeAsync(_todoItem);
		NavigationManager?.NavigateTo("/ToDoList");
	}
}