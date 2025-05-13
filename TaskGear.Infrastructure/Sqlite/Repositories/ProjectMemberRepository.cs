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

    public new async Task<ProjectMember?> GetAsync(Guid entityId, CancellationToken cancellationToken)
    {
        return await _context.Set<ProjectMember>()
            .Include(m => m.Project)
            .Include(m => m.User)
            .FirstOrDefaultAsync(x => x.Id == entityId, cancellationToken);

    }

    public new async Task<IEnumerable<ProjectMember>> GetAsync(Expression<Func<ProjectMember, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<ProjectMember>()
            .Include(m => m.Project)
            .Include(m => m.User)
            .Where(predicate).ToListAsync(cancellationToken);
    }
}