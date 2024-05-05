using SetAPI.models;

namespace SetAPI.Dtos
{
    public class GameReadDto
    {

        public int GameId { get; set; }
        
        public string User { get; set; }

        public Card[] Deck { get; set; }

        public int CardsOnBoard { get; set; }

        public SetReadDto[] FoundSets { get; set; }

        public int SetsOnBoard { get; set; }

    }
}