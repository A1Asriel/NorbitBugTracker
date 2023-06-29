using Microsoft.EntityFrameworkCore;
using NorbitBugTracker.Classes;

namespace NorbitBugTracker.Contexts;

public sealed class UserContext: DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=1234;Database=nbt_user_db;Username=postgres;Password=12345678");
    }

    public UserContext()
    {
        Database.Migrate();
    }
}