public class AddConnectedTaskRequest
{
    public Guid SourceTask {get; set;}
    public Guid TargetTask {get; set;}

    public AddConnectedTaskRequest(Guid sourceTask, Guid targetTask )
    {
        SourceTask = sourceTask;
        TargetTask = targetTask;
    }
}