using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;
using TaskGear.Infrastructure.Sqlite;

public class TaskStateRepository : GenericRepository<TaskState>, ITaskStateRepository
{
    public TaskStateRepository(SqliteContext context) : base(context){}
}