using Microsoft.EntityFrameworkCore;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;
using TaskGear.Infrastructure.Sqlite;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{

    private readonly DbContext _context;
    public ProjectRepository(SqliteContext context): base(context){
        _context = context;
     }

    public new async Task<Project?> GetAsync(Guid entityId, CancellationToken cancellationToken)
    {
        return await _context.Set<Project>()
            .Include(p => p.CreatedByUser)
            .FirstOrDefaultAsync(x => x.Id == entityId, cancellationToken);
    }
}