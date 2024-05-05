using SetAPI.models;

namespace SetAPI.Dtos
{
    public class SetReadDto
    {
        public int GameId { get; set; }

        public int SetNr { get; set; }

        public Card[] Cards { get; set; }
    }
}