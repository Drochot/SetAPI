namespace SetAPI.Dtos
{
    public class CardReadDto
    {
        public int Id { get; set; }

        public CardColor Color { get; set; }

        public CardShape Shape { get; set; }

        public CardNumber Number { get; set; }

        public CardFill Fill { get; set; } 
    }
}