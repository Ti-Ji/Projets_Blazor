using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Shared;

public class ToDoItem
{
	[Required] public int? Id { get; set; }
	[Required] public string? Name { get; set; }
	[Required] public DateTime? Date { get; set; }
	public TodoStatus? Status { get; set; }

	[Required]
	public int? StatusInt
	{
		get
		{
			if (Status != null) return (int)Status;
			return (int)TodoStatus.NotStarted;
		}
		set => Status = value != null ? (TodoStatus)value : TodoStatus.NotStarted;
	}
}