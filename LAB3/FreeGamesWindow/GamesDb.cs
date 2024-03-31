using Microsoft.EntityFrameworkCore;

namespace Lab;

internal class GamesDb: DbContext
{
    public DbSet<Game> Games { get; set; }

    public GamesDb()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=games.db");
    }

}