using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;

namespace Jumbula.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity, TInput> : ControllerBase
    where TEntity : class, IBaseEntity, new()
    where TInput : class
{
    private readonly IBaseService<TEntity, TInput> service;

    public BaseController(IBaseService<TEntity, TInput> service)
    {
        this.service = service;
    }

    [HttpGet]
    public ListResponse<TEntity> Get()
    {
        return service.Get();
    }


    [HttpPost]
    public async Task<SingleResponse<TEntity>> Post(TInput input)
    {
        var result = await service.Create(input);
        return result;
    }


    [HttpPut("{id}")]
    public async Task<SingleResponse<TEntity>> Put(Guid id, TInput input)
    {
        return await service.Update(id, input);
    }

    [HttpDelete("{id}")]
    public async Task<JustResponse> Remove(Guid id)
    {
        return await service.Delete(id);
    }
}
