namespace TaskGear.Application.Services.Contracts;

public class AddTaskStateRequest 
{
    public required string Name {get; set;}

    public AddTaskStateRequest(string name)
    {
        Name = name;
    }
}