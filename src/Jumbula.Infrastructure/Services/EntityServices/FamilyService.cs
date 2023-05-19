using AutoMapper;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices;
using Jumbula.Domain.Entities;
using Jumbula.Domain.Repositories.Common;
using LMS.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace Jumbula.Infrastructure.Services.EntityServices;
public class FamilyService : BaseService<Family, Family>, IFamilyService
{
    public FamilyService(IBaseRepository<Family> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public SingleResponse<Family> GetFamily(Guid familyId)
    {
        var result = GetAll()
            .Where(x => x.Id == familyId)
            .Include(x=>x.Parents)
            .Include(x=>x.Students)
            .Include(x=>x.Insurance)
            .FirstOrDefault();

        if (result is null)
            return ResponseStatus.NotFound;

        return result;
    }
}
