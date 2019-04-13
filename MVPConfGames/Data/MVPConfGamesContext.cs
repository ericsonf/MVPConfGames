using Microsoft.EntityFrameworkCore;
using MVPConfGames.Core.Entities;

namespace MVPConfGames.Data
{
    public class MVPConfGamesContext : DbContext
    {
        public MVPConfGamesContext(DbContextOptions<MVPConfGamesContext> options)
            : base(options) { }

        public DbSet<Console> Console { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
