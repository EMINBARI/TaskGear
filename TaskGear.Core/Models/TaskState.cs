using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class TaskState: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public TaskState() {}

    public TaskState(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

}