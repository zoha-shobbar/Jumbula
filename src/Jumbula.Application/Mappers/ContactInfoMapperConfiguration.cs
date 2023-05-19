using AutoMapper;
using Jumbula.Application.Dtos;
using Jumbula.Domain.Entities;

namespace Jumbula.Application.Mappers;
public class ContactInfoMapperConfiguration : Profile
{
    public ContactInfoMapperConfiguration()
    {
        CreateMap<ContactInfoInputDto, ContactInfo>().ReverseMap();
        CreateMap<AddressInputDto, Address>().ReverseMap();
    }
}
