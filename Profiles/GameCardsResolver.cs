using AutoMapper;
using SetAPI.Data;
using SetAPI.Dtos;
using SetAPI.models;

namespace SetAPI.Profiles
{
    public class GameCardsResolver : IValueResolver<Game, GameReadDto, Card[]>
    {
        private readonly ISetRepo _repository;

        public GameCardsResolver(ISetRepo repository)
        {
            _repository = repository;
        }
        public Card[] Resolve(Game source, GameReadDto destination, Card[] destMember, ResolutionContext context)
        {
            var cardItems = _repository.GetCardsById(source.Deck);
            cardItems = cardItems.OrderBy(x => Array.IndexOf(source.Deck, x.Id));

            return cardItems.ToArray();
        }
    }
}