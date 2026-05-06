using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppEscala.AppDatabase;

public interface IUnitOfWork
{
    ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
    Task AddRangeAsync<TEntity>(ICollection<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class;
    EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
    void UpdateRange<TEntity>(ICollection<TEntity> entities) where TEntity : class;
    void Remove<TEntity>(TEntity entity) where TEntity : class;
    void RemoveRange<TEntity>(ICollection<TEntity> entities) where TEntity : class;
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IQueryable<TResult> SqlQuery<TResult>(string sql, params object[] parameters);
    Task<string> GetCurrentDatabaseMigrationAsync(CancellationToken cancellationToken = default);
}

