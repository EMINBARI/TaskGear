using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;
using TaskGear.Infrastructure.Sqlite;

public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
{

    private readonly DbContext _context;
    public ProjectTaskRepository(SqliteContext context) : base(context){
        _context = context;
    }

    public new async Task<ProjectTask?> GetAsync(Guid entityId, CancellationToken cancellationToken)
    {
        return await _context.Set<ProjectTask>()
            .Include(t => t.Project.CreatedByUser)
            .Include(t => t.CreatedByMember)
            .Include(t => t.TaskState)
            .FirstOrDefaultAsync(t => t.Id == entityId, cancellationToken);
    }

    public new async Task<IEnumerable<ProjectTask>> GetAsync(Expression<Func<ProjectTask, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<ProjectTask>()
            // .Include(t => t.Project)
            .Include(t => t.Project.CreatedByUser)
            .Include(t => t.CreatedByMember)
            .Include(t => t.TaskState)
            .Where(predicate).ToListAsync(cancellationToken);
    }
}