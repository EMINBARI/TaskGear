using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class TaskStateResponse 
{
    public Guid Id {get; set;}
    public string Name {get; set;}

    public TaskStateResponse(TaskState taskState)
    {
        Id = taskState.Id;
        Name = taskState.Name;
    }
}