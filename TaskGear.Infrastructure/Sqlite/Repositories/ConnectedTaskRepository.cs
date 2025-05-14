using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Abstractions;
using TaskGear.Infrastructure.Sqlite;

public class ConnectedTaskRepository : GenericRepository<ConnectedTask>, IConnectedTaskRepository
{
    public ConnectedTaskRepository(SqliteContext context) : base(context) {}
}