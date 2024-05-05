namespace SetAPI.Dtos
{
    public class SetCreateDto
    {
        public int GameId { get; set; }

        public int SetNr { get; set; }

        public int[] Cards { get; set; }
    }
}