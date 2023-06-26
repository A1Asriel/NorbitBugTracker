using System.ComponentModel.DataAnnotations;

namespace NorbitBugTracker.Classes;

public class Comment
{
    [Key]
    public required long Id
    {
        get; set;
    }
    [Required]
    public required User User
    {
        get; set;
    }
    [Required]
    public required string Content
    {
        get; set;
    }
}
