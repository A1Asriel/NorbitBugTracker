using System.ComponentModel.DataAnnotations;

namespace NorbitBugTracker.Classes;

public class User
{
    [Key]
    public required long Id
    {
        get; set;
    }
    [Required]
    public required string Login
    {
        get; set;
    }
    [Required]
    public required string Password
    {
        get; set;
    }
    [Required]
    public required string Name
    {
        get; set;
    }
    public Enums.AccessLevel AccessLevel = Enums.AccessLevel.User;
    public List<Report> Reports { get; set; } = new List<Report>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}
