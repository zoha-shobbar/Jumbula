using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Entities;

namespace Jumbula.Application.Services.EntityServices;
public interface IFamilyService : IBaseService<Family, Family>
{
    SingleResponse<Family> GetFamily(Guid familyId);
}
