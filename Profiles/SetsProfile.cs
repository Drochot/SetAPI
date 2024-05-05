using AutoMapper;
using SetAPI.Dtos;
using SetAPI.models;

namespace SetAPI.Profiles
{
    public class SetsProfile : Profile
    {
        public SetsProfile()
        {
            CreateMap<Set, SetReadDto>()
                .ForMember(d => d.Cards, o => o.MapFrom<SetCardsResolver>());
            CreateMap<SetCreateDto, Set>();
        }
    }
}