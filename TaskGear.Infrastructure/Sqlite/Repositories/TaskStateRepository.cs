using Microsoft.EntityFrameworkCore;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;

public class TaskStateRepository : GenericRepository<TaskState>, ITaskStateRepository
{
    public TaskStateRepository(DbContext context) : base(context){}
}