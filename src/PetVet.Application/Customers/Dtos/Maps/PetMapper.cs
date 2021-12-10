using AutoMapper;
using PetVet.Domain.Entities.Customers;

namespace PetVet.Application.Customers.Dtos.Maps
{
    public class PetMapper : Profile
    {
        public PetMapper()
        {
            var map = CreateMap<Pet, PetDto>();

            map.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            map.ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName})"));
            map.ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId));
        }
    }
}