using TaskGear.Core.Models;

public class ConnectedTaskResponse
{
    public Guid Id {get; set;}
    public Guid SourceTaskId{ get; set; }
    public Guid TargetTaskId { get; set; }

    public ProjectTask SourceTask {get; set;}
    public ProjectTask TargetTask {get; set;}

    public ConnectedTaskResponse(ConnectedTask connectedTask)
    {
        Id = connectedTask.Id;
        SourceTaskId = connectedTask.SourceTaskId;
        TargetTaskId = connectedTask.TargetTaskId;
        SourceTask = connectedTask.SourceTask;
        TargetTask = connectedTask.TargetTask;
    }
}