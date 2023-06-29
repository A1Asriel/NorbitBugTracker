using Microsoft.EntityFrameworkCore;
using NorbitBugTracker.Classes;

namespace NorbitBugTracker.Contexts;

public sealed class ProjectContext: DbContext
{
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=1235;Database=nbt_project_db;Username=postgres;Password=12345678");
    }

    public ProjectContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}