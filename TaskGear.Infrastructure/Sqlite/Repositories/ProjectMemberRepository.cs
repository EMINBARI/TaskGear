using TaskGear.Core.Repositories;
using TaskGear.Core.Models;
using Microsoft.EntityFrameworkCore;
using TaskGear.Infrastructure.Abstractions;
using System.Linq.Expressions;

namespace TaskGear.Infrastructure.Sqlite.Repositories;

public class ProjectMemberRepository : GenericRepository<ProjectMember>, IProjectMemberRepository
{

    private readonly DbContext _context;

    public ProjectMemberRepository(SqliteContext context): base(context){ 
        _context = context;
    }

    public new async Task<IEnumerable<ProjectMember>> GetAsync(Expression<Func<ProjectMember, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<ProjectMember>()
            .Include(pm => pm.Project)
            .Include(pm => pm.User)
            .Where(predicate).ToListAsync(cancellationToken);
    }
}