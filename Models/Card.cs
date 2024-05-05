using System.ComponentModel.DataAnnotations;

namespace SetAPI.models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public CardColor Color { get; set; }

        [Required]
        public CardShape Shape { get; set; }

        [Required]
        public CardNumber Number { get; set; }

        [Required]
        public CardFill Fill { get; set; }

    }
}

public enum CardColor
{
    Red,
    Blue,
    Green
}
public enum CardShape
{
    Diamond,
    Pill,
    Wave
}
public enum CardNumber
{
    One,
    Two,
    Three
}
public enum CardFill
{
    Empty,
    Striped,
    Full
}