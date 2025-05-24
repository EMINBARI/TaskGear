using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class ConnectedTask: IEntity
{
    public Guid Id {get; set;}
    public Guid SourceTaskId { get; set; }
    public Guid TargetTaskId { get; set; }

    public ProjectTask SourceTask { get; set; }
    public ProjectTask TargetTask { get; set; }
    
    public TaskRelationType taskRelationType { get; set; }
    
    public ConnectedTask() { }

    public ConnectedTask
    (
        Guid id, 
        Guid sourceTaskId, 
        ProjectTask sourceTask,
        Guid targetTaskId,
        ProjectTask targetTask
    )
    {  
        Id = id;
        SourceTaskId = sourceTaskId;
        SourceTask = sourceTask;
        TargetTaskId = targetTaskId;
        TargetTask = targetTask;
    }
}



