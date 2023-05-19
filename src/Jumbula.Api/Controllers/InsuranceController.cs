using Jumbula.Api.Controllers.Common;
using Jumbula.Application.Dtos;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Entities;

namespace Jumbula.Api.Controllers;
public class InsuranceController : BaseController<Insurance, InsuranceInputDto>
{
    public InsuranceController(IBaseService<Insurance, InsuranceInputDto> service) : base(service)
    {
    }
}
