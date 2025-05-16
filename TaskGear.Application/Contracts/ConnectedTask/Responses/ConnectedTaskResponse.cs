using TaskGear.Core.Models;

public class ConnectedTaskResponse
{
    public Guid Id {get; set;}
    public Guid TaskId1{ get; set; }
    public Guid TaskId2 { get; set; }

    public ProjectTask Task1 {get; set;}
    public ProjectTask Task2 {get; set;}

    public ConnectedTaskResponse(ConnectedTask connectedTask)
    {
        Id = connectedTask.Id;
        TaskId1 = connectedTask.TaskId1;
        TaskId2 = connectedTask.TaskId2;
        Task1 = connectedTask.Task1;
        Task2 = connectedTask.Task2;
    }
}