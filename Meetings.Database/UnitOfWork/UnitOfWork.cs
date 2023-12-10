using Meetings.Database.Context;
using Meetings.Domain.UnitOfWork;

namespace Meetings.Database.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAppDbContext _dbContext;

    public UnitOfWork(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken token) => _dbContext.SaveChangesAsync(token);
}