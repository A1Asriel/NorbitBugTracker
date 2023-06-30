using System.ComponentModel.DataAnnotations;

namespace NorbitBugTracker.Classes;

public class Project
{
    [Key]
    public required long Id
    {
        get; set;
    }
    [Required]
    public required string Name
    {
        get; set;
    }
    [Required]
    public required string Description
    {
        get; set;
    }
    [Required]
    public required Enums.AccessLevel Visibility
    {
        get; set;
    }
    public List<long> ProjectIDs { get; set; } = new List<long>();
    public List<string> Categories { get; set; } = new List<string>();
    // public File Image
}
