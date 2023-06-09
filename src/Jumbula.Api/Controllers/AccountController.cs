﻿using Jumbula.Api.Extensions;
using Jumbula.Application.Constants;
using Jumbula.Application.Dtos;
using Jumbula.Application.Dtos.Jwt;
using Jumbula.Application.Responses;
using Jumbula.Application.Services.EntityServices;
using Jumbula.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("[action]/{familyId}")]
    public async Task<SingleResponse<AccessToken>> RegisterParent(Guid familyId, SignUpParentInputDto input)
    {
        return await _service.RegisterParent(familyId, input);
    }

    [HttpPost("[action]")]
    public async Task<SingleResponse<AccessToken>> RegisterParent(SignUpParentInputDto input)
    {
        return await _service.RegisterParent(null, input);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleConstants.Parent)}")]
    public async Task<SingleResponse<Student>> RegisterStudent(SignUpStudentInputDto input)
    {
        Guid userId = User.GetUserId();
        return await _service.RegisterStudent(userId, input);
    }
}
