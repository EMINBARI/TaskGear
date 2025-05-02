using TaskGear.Core.Repositories;
using TaskGear.Core.Models;
using Microsoft.EntityFrameworkCore;
using TaskGear.Infrastructure.Abstractions;

namespace TaskGear.Infrastructure.Sqlite.Repositories;

public class ProjectMemberRepository : GenericRepository<ProjectMember>, IProjectMemberRepository
{
    public ProjectMemberRepository(SqliteContext context): base(context){ }
}