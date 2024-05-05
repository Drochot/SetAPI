using SetAPI.models;

namespace SetAPI.Services
{
    public interface ISetService
    {
        public int CountSetsOnBoard(Card[] deck, int CardsOnBoard);
        public bool ValidateSet(Card[] cards);
        public bool CountSets(Card[] cards, int CardNumber);
        public Card[] FindHint(Card[] cards, int cardNumber);
        
        
    }
}