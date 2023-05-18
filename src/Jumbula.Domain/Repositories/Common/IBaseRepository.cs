using Jumbula.Domain.Entities.Common;

namespace Jumbula.Domain.Repositories.Common;
public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
    Task<TCustomEntity> Create<TCustomEntity>(TCustomEntity entity, CancellationToken cancellationToken)
        where TCustomEntity : BaseEntity;

    Task<TEntity> Update(Guid id, TEntity entity, CancellationToken cancellationToken);
    Task<TCustomEntity> Update<TCustomEntity>(Guid id, TCustomEntity entity, CancellationToken cancellationToken)
        where TCustomEntity :  BaseEntity;

    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken) where TCustomEntity :  BaseEntity;

    TEntity? GetById(Guid id);
    TCustomEntity? GetById<TCustomEntity>(Guid id)
        where TCustomEntity :  BaseEntity;

    IQueryable<TEntity> GetAll();
    IQueryable<TCustomEntity> GetAll<TCustomEntity>() where TCustomEntity :  BaseEntity;

    IQueryable<TEntity> GetAllAsNoTracking();
    IQueryable<TCustomEntity> GetAllAsNoTracking<TCustomEntity>() where TCustomEntity :  BaseEntity;
}