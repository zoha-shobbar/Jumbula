using Jumbula.Application.Dtos;
using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jumbula.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService accountService)
    {
        _service = accountService;
    }

    [HttpPost("[action]")]
    public async Task<SingleResponse<AccessToken>> SignIn(SignInInputDto input)
    {
        return await _service.SignIn(input);
    }


    [HttpPost("[action]")]
    public async Task<SingleResponse<AccessToken>> RegisterBusiness(SignUpBusinessInputDto input)
    {
        return await _service.RegisterBusiness(input);
    }
}
