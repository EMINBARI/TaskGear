namespace TaskGear.Application.Services.Contracts;

public class UpdateTaskStateRequest 
{
    public Guid Id {get; set;}
   public required string Name {get; set;}

    public UpdateTaskStateRequest(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}