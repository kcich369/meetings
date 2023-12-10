using Meetings.Domain.Entities.Base;
using Meetings.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Database.Context;

public interface IAppDbContext : IUnitOfWork
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
}