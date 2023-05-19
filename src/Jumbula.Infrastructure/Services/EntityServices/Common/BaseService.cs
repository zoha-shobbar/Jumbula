using AutoMapper;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Entities.Common;
using Jumbula.Domain.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Services.EntityServices.Common;
public class BaseService<TEntity, TInput> : IBaseService<TEntity, TInput>
    where TEntity : class,IBaseEntity, new()
    where TInput : class
{
    private readonly IBaseRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public virtual async Task<SingleResponse<TEntity>> Create(TInput input, CancellationToken cancellationToken = default)
    {
        TEntity entity = new();

        if (input is not TEntity)
            entity = _mapper.Map<TInput, TEntity>(input);

        await _repository.Create(entity, cancellationToken);

        if (entity.Id == Guid.Empty)
        {
            return ResponseStatus.UnknownError;
        }

        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Create<TCustomEntity, TCustomInput>(TCustomInput input, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
        where TCustomInput : class
    {
        var entity = _mapper.Map<TCustomInput, TCustomEntity>(input);

        await _repository.Create(entity, cancellationToken);

        if (entity.Id == Guid.Empty)
        {
            return ResponseStatus.UnknownError;
        }

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Create<TCustomEntity>(TCustomEntity entity, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
    {
        await _repository.Create(entity, cancellationToken);

        if (entity.Id == Guid.Empty)
        {
            return ResponseStatus.UnknownError;
        }

        return SingleResponse<TCustomEntity>.Success(entity);
    }


    public virtual async Task<SingleResponse<TEntity>> Update(Guid id, TInput input, CancellationToken cancellationToken = default)
    {
        var entity = _repository.GetById(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        entity = _mapper.Map<TEntity>(input);
        entity.Id = id;

        await _repository.Update(id, entity, cancellationToken);

        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Update<TCustomEntity>(TCustomEntity input, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
    {
        var entity = _repository.GetById<TCustomEntity>(input.Id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        await _repository.Update(entity.Id, entity, cancellationToken);

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Update<TCustomEntity, TCustomInput>(Guid id, TCustomInput input, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
        where TCustomInput : class
    {
        var entity = _repository.GetById<TCustomEntity>(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        entity = _mapper.Map<TCustomEntity>(input);
        entity.Id = id;

        await _repository.Update(id, entity, cancellationToken);

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual async Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = _repository.GetById(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        await _repository.Delete(id, cancellationToken);

        return ResponseStatus.Success;
    }

    public virtual async Task<JustResponse> Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken = default)
        where TCustomEntity : class, IBaseEntity
    {
        var entity = _repository.GetById<TCustomEntity>(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        await _repository.Delete<TCustomEntity>(id, cancellationToken);

        return ResponseStatus.Success;
    }

    public virtual SingleResponse<TEntity> Get(Guid id)
    {
        var entity = _repository.GetById<TEntity>(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual SingleResponse<TCustomEntity> Get<TCustomEntity>(Guid id) where TCustomEntity : class, IBaseEntity
    {
        var entity = _repository.GetById<TCustomEntity>(id);

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual ListResponse<TEntity> Get()
    {
        var entity = _repository.GetAll();

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        return ListResponse<TEntity>.Success(entity);
    }

    public virtual ListResponse<TCustomEntity> Get<TCustomEntity>() where TCustomEntity : class, IBaseEntity
    {
        var entity = _repository.GetAll<TCustomEntity>();

        if (entity == null)
        {
            return ResponseStatus.NotFound;
        }

        return ListResponse<TCustomEntity>.Success(entity);
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return _repository.GetAll();
    }

    public virtual IQueryable<TCustomEntity> GetAll<TCustomEntity>() where TCustomEntity : class, IBaseEntity
    {
        return _repository.GetAll<TCustomEntity>();
    }

    public virtual IQueryable<TEntity> GetAllAsNoTracking()
    {
        return _repository.GetAllAsNoTracking();
    }

    public virtual IQueryable<TCustomEntity> GetAllAsNoTracking<TCustomEntity>() where TCustomEntity : class, IBaseEntity
    {
        return _repository.GetAllAsNoTracking<TCustomEntity>();
    }

    public virtual ListResponse<TEntity> GetAsNoTracking()
    {
        var entities = _repository.GetAllAsNoTracking();
        return ListResponse<TEntity>.Success(entities);
    }

    public virtual async Task<SingleResponse<TEntity>> GetAsNoTracking(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAllAsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            return ResponseStatus.NotFound;

        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> GetAsNoTracking<TCustomEntity>(Guid id, CancellationToken cancellationToken) where TCustomEntity : BaseEntity
    {
        var entity = await _repository.GetAllAsNoTracking<TCustomEntity>()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            return ResponseStatus.NotFound;

        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual ListResponse<TCustomEntity> GetAsNoTracking<TCustomEntity>() where TCustomEntity : class, IBaseEntity
    {
        var entities = _repository.GetAllAsNoTracking<TCustomEntity>();
        return ListResponse<TCustomEntity>.Success(entities);
    }

    public virtual ListResponse<TCustomOutput> GetAsNoTrackingWithDto<TCustomOutput>() where TCustomOutput : class
    {
        var entities = _repository.GetAllAsNoTracking();

        var result = _mapper.Map<IQueryable<TEntity>, IQueryable<TCustomOutput>>(entities);

        return ListResponse<TCustomOutput>.Success(result);
    }

    public virtual ListResponse<TCustomOutput> GetAsNoTrackingWithDto<TCusomEntity, TCustomOutput>()
        where TCusomEntity : class, IBaseEntity
        where TCustomOutput : class
    {
        var entities = _repository.GetAllAsNoTracking<TCusomEntity>();

        var result = _mapper.Map<IQueryable<TCusomEntity>, IQueryable<TCustomOutput>>(entities);

        return ListResponse<TCustomOutput>.Success(result);
    }
}
