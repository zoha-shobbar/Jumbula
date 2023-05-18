using Jumbula.Domain.Entities.Common;
using Jumbula.Domain.Repositories.Common;
using Jumbula.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Jumbula.Infrastructure.Repositories.Common;
public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    private readonly DataContext _dbContext;

    public BaseRepository(DataContext dataContext)
    {
        _dbContext = dataContext;
    }

    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TCustomEntity> Create<TCustomEntity>(TCustomEntity entity, CancellationToken cancellationToken) where TCustomEntity :BaseEntity
    {
        await _dbContext.Set<TCustomEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> Update(Guid id, TEntity entity, CancellationToken cancellationToken)
    {
        var onChangeEntity = _dbContext.Set<TEntity>().Find(entity.Id);
        onChangeEntity = entity;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TCustomEntity> Update<TCustomEntity>(Guid id, TCustomEntity entity, CancellationToken cancellationToken) where TCustomEntity : BaseEntity
    {
        var onChangeEntity = _dbContext.Set<TCustomEntity>().Find(entity.Id);
        onChangeEntity = entity;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);

        _dbContext.Set<TEntity>().Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken) where TCustomEntity : BaseEntity
    {
        var entity = _dbContext.Set<TCustomEntity>().Find(id);

        _dbContext.Set<TCustomEntity>().Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public TEntity? GetById(Guid id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public TCustomEntity? GetById<TCustomEntity>(Guid id) where TCustomEntity : BaseEntity
    {
        return _dbContext.Set<TCustomEntity>().Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>();
    }

    public IQueryable<TCustomEntity> GetAll<TCustomEntity>() where TCustomEntity :BaseEntity
    {
        return _dbContext.Set<TCustomEntity>();
    }

    public IQueryable<TEntity> GetAllAsNoTracking()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public IQueryable<TCustomEntity> GetAllAsNoTracking<TCustomEntity>() where TCustomEntity : BaseEntity
    {
        return _dbContext.Set<TCustomEntity>().AsNoTracking();
    }
}
