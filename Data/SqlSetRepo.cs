using Microsoft.EntityFrameworkCore.Internal;
using SetAPI.Data;
using SetAPI.models;

namespace SetAPI.Data
{
    public class SqlSetRepo : ISetRepo
    {
        private readonly SetContext _context;

        public SqlSetRepo(SetContext context)
        {
            _context = context;
        }

        // public void CreateCard(Card card)
        // {
        //     if(card == null)
        //     {
        //         throw new ArgumentNullException(nameof(card));
        //     }

        //     _context.Cards.Add(card);
        // }


        public void CreateGame(Game game)
        {
            if(game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Games.Add(game);
        }

        public void CreateSet(Set set)
        {
            if(set == null)
            {
                throw new ArgumentNullException(nameof(set));
            }
            if(set.Cards.Length < 3)
            {
                throw new InvalidDataException();
            }

            _context.Sets.Add(set);
        }

        public void DeleteGame(Game game)
        {
            if(game == null)
            {
                throw new ArgumentException(nameof(game));
            }
            _context.Games.Remove(game);
        }

        public void DeleteSet(Set set)
        {
            _context.Sets.Remove(set);
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _context.Cards.ToList();
        }

        public Card GetCardById(int id)
        {
            return _context.Cards.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Card> GetCardsById(int[] ids)
        {
            return _context.Cards.Where(r => ids.Contains(r.Id));
        }

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(p => p.GameId == id);
        }

        public IEnumerable<Game> GetGamesByUser(string user)
        {
            return _context.Games.ToList().Where(p => p.User == user);
        }

        public Set GetSet(int gameId, int setNr)
        {
            return _context.Sets.FirstOrDefault(p => p.SetNr == setNr && p.GameId == gameId);
        }

        public IEnumerable<Set> GetSetsByGameId(int gameId)
        {
            return _context.Sets.ToList().Where(p => p.GameId == gameId);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateGame(Game game)
        {
            //nothing
        }
    }
}