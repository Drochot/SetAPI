using AutoMapper;
using SetAPI.Data;
using SetAPI.Dtos;
using SetAPI.models;

namespace SetAPI.Profiles
{
    public class SetCardsResolver : IValueResolver<Set, SetReadDto, Card[]>
    {
        private readonly ISetRepo _repository;

        public SetCardsResolver(ISetRepo repository)
        {
            _repository = repository;
        }
        public Card[] Resolve(Set source, SetReadDto destination, Card[] destMember, ResolutionContext context)
        {
            return _repository.GetCardsById(source.Cards).ToArray();
        }
    }
}