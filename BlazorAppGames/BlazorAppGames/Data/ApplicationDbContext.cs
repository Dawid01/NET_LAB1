using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorAppGames.Components.Models;

namespace BlazorAppGames.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{

public DbSet<BlazorAppGames.Components.Models.Game> Game { get; set; } = default!;
}