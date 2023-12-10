using Meetings.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Database.Context;

public sealed class AppDbContext: DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken token = default) => base.SaveChangesAsync(token);

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity => base.Set<TEntity>();
    
}