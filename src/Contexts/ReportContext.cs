using Microsoft.EntityFrameworkCore;
using NorbitBugTracker.Classes;

namespace NorbitBugTracker.Contexts;

public sealed class ReportContext: DbContext
{
    public DbSet<Report> Reports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=1236;Database=nbt_report_db;Username=postgres;Password=12345678");
    }

    public ReportContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}