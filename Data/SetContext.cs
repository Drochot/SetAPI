using Microsoft.EntityFrameworkCore;
using SetAPI.models;

namespace SetAPI.Data
{
    public class SetContext : DbContext
    {
        public SetContext(DbContextOptions<SetContext> opt) : base(opt)
        {
            
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}