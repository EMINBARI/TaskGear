public class AddConnectedTaskRequest
{
    public Guid TaskId1 {get; set;}
    public Guid TaskId2 {get; set;}

    public AddConnectedTaskRequest(Guid taskId1,Guid taskId2 )
    {
        TaskId1 = taskId1;
        TaskId2 = taskId2;
    }
}