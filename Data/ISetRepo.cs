using SetAPI.models;

namespace SetAPI.Data
{
    public interface ISetRepo
    {
        bool SaveChanges();

        IEnumerable<Card> GetAllCards();
        Card GetCardById(int id);
        IEnumerable<Card> GetCardsById(int[] ids);
        // void CreateCard(Card card);

        void CreateGame(Game game);
        Game GetGameById(int id);
        IEnumerable<Game> GetGamesByUser(string user);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        IEnumerable<Set> GetSetsByGameId(int gameId);

        void DeleteSet(Set set);
        void CreateSet(Set set);
        Set GetSet(int gameId, int SetNr);
    }
}