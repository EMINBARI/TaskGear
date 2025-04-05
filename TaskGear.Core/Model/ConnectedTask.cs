namespace TaskGear.Core.Model
{
    public class ConnectedTask
    {
        public Guid Id { get; set; }
        
        public Guid TaskId { get; set; }
        public Task Task { get; set; }

    }
}