using Jumbula.Application.Responses;
using Jumbula.Domain.Entities.Common;

namespace Jumbula.Application.Services.EntityServices.Common;
public interface IBaseService<TEntity, TInput>
    where TEntity : class, IBaseEntity, new()
    where TInput : class
{
    Task<SingleResponse<TEntity>> Create(TInput input, CancellationToken cancellationToken = default);
    Task<SingleResponse<TCustomEntity>> Create<TCustomEntity>(TCustomEntity input, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity;
    Task<SingleResponse<TCustomEntity>> Create<TCustomEntity, TCustomInput>(TCustomInput input, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
        where TCustomInput : class;


    Task<SingleResponse<TEntity>> Update(Guid id, TInput input, CancellationToken cancellationToken = default);
    Task<SingleResponse<TCustomEntity>> Update<TCustomEntity>(TCustomEntity entity, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity;
    Task<SingleResponse<TCustomEntity>> Update<TCustomEntity, TCustomInput>(Guid id, TCustomInput input, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
        where TCustomInput : class;

    Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken = default);
    Task<JustResponse> Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken = default) where TCustomEntity : class, IBaseEntity;

    SingleResponse<TEntity> Get(Guid id);
    SingleResponse<TCustomEntity> Get<TCustomEntity>(Guid id) where TCustomEntity : class, IBaseEntity;

    IQueryable<TEntity> GetAll();
    IQueryable<TCustomEntity> GetAll<TCustomEntity>() where TCustomEntity : class, IBaseEntity;

    ListResponse<TEntity> Get();
    ListResponse<TCustomEntity> Get<TCustomEntity>() where TCustomEntity : class, IBaseEntity;

    IQueryable<TEntity> GetAllAsNoTracking();
    IQueryable<TCustomEntity> GetAllAsNoTracking<TCustomEntity>() where TCustomEntity : class, IBaseEntity;

    ListResponse<TEntity> GetAsNoTracking();
    ListResponse<TCustomEntity> GetAsNoTracking<TCustomEntity>() where TCustomEntity : class, IBaseEntity;
    Task<SingleResponse<TEntity>> GetAsNoTracking(Guid id, CancellationToken cancellationToken);
    Task<SingleResponse<TCustomEntity>> GetAsNoTracking<TCustomEntity>(Guid id, CancellationToken cancellationToken) where TCustomEntity : class, IBaseEntity;

    ListResponse<TCustomOutput> GetAsNoTrackingWithDto<TCustomOutput>() where TCustomOutput : class;
    ListResponse<TCustomOutput> GetAsNoTrackingWithDto<TCusomEntity, TCustomOutput>()
        where TCusomEntity : class, IBaseEntity
        where TCustomOutput : class;
}
