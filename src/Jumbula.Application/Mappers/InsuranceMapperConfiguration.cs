using AutoMapper;
using Jumbula.Application.Dtos;
using Jumbula.Domain.Entities;

namespace Jumbula.Application.Mappers;
public class InsuranceMapperConfiguration : Profile
{
    public InsuranceMapperConfiguration()
    {
        CreateMap<InsuranceInputDto, Insurance>().ReverseMap();
    }
}
