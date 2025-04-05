using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class ConnectedTask: IEntity
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Task Task { get; set; }

    public ConnectedTask() {}
}



