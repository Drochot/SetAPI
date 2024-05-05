using System.ComponentModel.DataAnnotations;

namespace SetAPI.models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string User { get; set; }

        public int[] Deck { get; set; }

        public int CardsOnBoard { get; set; }

        // public int FoundSets { get; set; }
        
        public int SetsOnBoard { get; set; }

    }
}