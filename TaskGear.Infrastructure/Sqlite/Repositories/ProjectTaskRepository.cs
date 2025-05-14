using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;
using TaskGear.Infrastructure.Sqlite;

public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
{
    public ProjectTaskRepository(SqliteContext context) : base(context){}
}