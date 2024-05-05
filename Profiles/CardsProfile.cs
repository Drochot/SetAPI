using AutoMapper;
using SetAPI.Dtos;
using SetAPI.models;

namespace SetAPI.Profiles
{
    public class CardsProfile : Profile
    {
        public CardsProfile()
        {
            CreateMap<Card, CardReadDto>();
            CreateMap<CardCreateDto, Card>();
        }
    }
}