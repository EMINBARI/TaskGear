using TaskGear.Core.Repositories;
using TaskGear.Core.Models;
using Microsoft.EntityFrameworkCore;
using TaskGear.Infrastructure.Abstractions;

namespace TaskGear.Infrastructure.Sqlite.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SqliteContext context): base(context){ }
}