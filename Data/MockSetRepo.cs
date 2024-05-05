using SetAPI.models;

namespace SetAPI.Data
{
    public class MockSetRepo : ISetRepo
    {
        public void CreateCard(Card card)
        {
            throw new NotImplementedException();
        }

        public void CreateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void CreateSet(Set set)
        {
            throw new NotImplementedException();
        }

        public void DeleteGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void DeleteSet(Set set)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Card> GetAllCards()
        {
            var cards = new List<Card> 
            {
                new Card{Id=0, Color=CardColor.Red, Fill=CardFill.Full, Number=CardNumber.Three, Shape=CardShape.Wave },
                new Card{Id=1, Color=CardColor.Blue, Fill=CardFill.Striped, Number=CardNumber.One, Shape=CardShape.Pill },
                new Card{Id=2, Color=CardColor.Green, Fill=CardFill.Empty, Number=CardNumber.Two, Shape=CardShape.Diamond }
            };

            return cards;
        }

        public Card GetCardById(int id)
        {
            return new Card{Id=0, Color=CardColor.Red, Fill=CardFill.Full, Number=CardNumber.Three, Shape=CardShape.Wave };
        }

        public IEnumerable<Card> GetCardsById(int[] ids)
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGamesByUser(string user)
        {
            throw new NotImplementedException();
        }

        public Set GetSet(int gameId, int SetNr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Set> GetSetsByGameId(int gameId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}