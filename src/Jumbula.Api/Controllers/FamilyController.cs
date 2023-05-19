using Jumbula.Application.Constants;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices;
using Jumbula.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jumbula.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FamilyController : ControllerBase
{
    private readonly IFamilyService _service;

    public FamilyController(IFamilyService service)
	{
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = $"{nameof(RoleConstants.Parent)},{nameof(RoleConstants.Admin)}")]
    public SingleResponse<Family> GetFamily(Guid familyId)
    {
        return _service.GetFamily(familyId);
    }
    
}
