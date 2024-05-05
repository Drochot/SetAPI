using AutoMapper;
using SetAPI.Dtos;
using SetAPI.models;

namespace SetAPI.Profiles
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, GameReadDto>()
                .ForMember(d => d.Deck, o => o.MapFrom<GameCardsResolver>())
                .ForMember(d => d.FoundSets, o => o.MapFrom<GameSetsResolver>());
            CreateMap<GameCreateDto, Game>();
            CreateMap<Game, GameUpdateDto>();
            CreateMap<GameUpdateDto, Game>();

        }
    }
}