using System.ComponentModel.DataAnnotations;

namespace NorbitBugTracker.Classes;

public class Comment
{
    [Key]
    public long Id { get; set; }
    [Required]
    public required long UserID { get; set; }
    [Required]
    public required string Content { get; set; }
}
