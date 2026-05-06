using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppEscala.AppDatabase;

public sealed partial class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _Context;
    private IDbContextTransaction? _Transaction = default!;
    private readonly HashSet<int> _BeginTransactionCallTracking = [];

    public UnitOfWork(AppDbContext context)
    {
        _Context = context;
        _Context.Database.EnsureCreated();
    }

    public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
       => _Context.AddAsync(entity, cancellationToken);

    public Task AddRangeAsync<TEntity>(ICollection<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class
       => _Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

    public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
       => _Context.Update(entity);

    public void UpdateRange<TEntity>(ICollection<TEntity> entities) where TEntity : class
       => _Context.Set<TEntity>().UpdateRange(entities);

    public void Remove<TEntity>(TEntity entity) where TEntity : class
        => _Context.Remove(entity);

    public void RemoveRange<TEntity>(ICollection<TEntity> entities) where TEntity : class
        => _Context.Set<TEntity>().RemoveRange(entities);

    public DbSet<TEntity> Set<TEntity>() where TEntity : class
        => _Context.Set<TEntity>();

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_Transaction is null)
        {
            _Transaction = await _Context.Database.BeginTransactionAsync(cancellationToken);

            _BeginTransactionCallTracking.Clear();
        }

        _BeginTransactionCallTracking.Add(_BeginTransactionCallTracking.Count);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_Transaction is null)
            return;

        if (_BeginTransactionCallTracking.Last() == 0)
        {
            await _Transaction.CommitAsync(cancellationToken);
            _Transaction = null;
        }

        _BeginTransactionCallTracking.Remove(_BeginTransactionCallTracking.Last());
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_Transaction is null)
            return;

        if (_BeginTransactionCallTracking.Last() == 0)
        {
            await _Transaction.RollbackAsync(cancellationToken);
            _Transaction = null;
        }

        _BeginTransactionCallTracking.Remove(_BeginTransactionCallTracking.Last());
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => _Context.SaveChangesAsync(cancellationToken);

    public IQueryable<TResult> SqlQuery<TResult>(string sql, params object[] parameters)
        => _Context.Database.SqlQueryRaw<TResult>(sql: sql, parameters: parameters);

    public async Task<string> GetCurrentDatabaseMigrationAsync(CancellationToken cancellationToken = default)
        => (await _Context.Database.GetAppliedMigrationsAsync(cancellationToken)).Last();
}
