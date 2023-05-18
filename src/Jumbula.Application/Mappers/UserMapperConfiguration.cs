﻿using AutoMapper;
using Jumbula.Application.Dtos;
using Jumbula.Domain.Entities;

namespace Jumbula.Application.Mappers;
public class UserMapperConfiguration : Profile
{
    public UserMapperConfiguration()
    {
        CreateMap<SignUpBusinessInputDto, Business>().ReverseMap();
    }
}