using System.ComponentModel.DataAnnotations;
using NorbitBugTracker.Utils;

namespace NorbitBugTracker.Classes;

public class User
{
    [Key]
    public long Id { get; set; }
    [Required]
    public required string Login { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string Name { get; set; }
    public long Time { get => IDManager.IDtoTime(Id); }
    public Enums.AccessLevel AccessLevel { get; set; } = Enums.AccessLevel.User;
    public List<long> ReportIDs { get; set; } = new List<long>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}
