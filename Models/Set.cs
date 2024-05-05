using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SetAPI.models
{
    [PrimaryKey(nameof(GameId), nameof(SetNr))]
    public class Set
    {
        
        public int GameId { get; set; }

        public int SetNr { get; set; }

        [Required]
        public int[] Cards { get; set; }

    }
}