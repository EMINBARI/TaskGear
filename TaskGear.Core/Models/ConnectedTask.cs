using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class ConnectedTask: IEntity
{
    public Guid Id {get; set;}
    public Guid TaskId1 { get; set; }
    public Guid TaskId2{ get; set; }

    public ProjectTask Task1 { get; set; }
    public ProjectTask Task2{ get; set; }
    
    public ConnectedTask() {}

    public ConnectedTask
    (
        Guid id, 
        Guid taskId1, 
        ProjectTask task1,
        Guid taskId2,
        ProjectTask task2
    )
    {  
        Id = id;
        TaskId1 = taskId1;
        Task1 = task1;
        TaskId2 = taskId2;
        Task2 = task2;
    }
}



