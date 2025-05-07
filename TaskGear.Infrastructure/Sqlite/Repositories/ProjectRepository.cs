using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;
using TaskGear.Infrastructure.Sqlite;

class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(SqliteContext context): base(context){ }
}