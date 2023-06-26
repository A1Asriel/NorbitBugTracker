using System.ComponentModel.DataAnnotations;

namespace NorbitBugTracker.Classes;

public class Report
{
    [Key]
    public required long Id
    {
        get; set;
    }
    [Required]
    public required Project Project
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
    public required Enums.ReportType Type
    {
        get; set;
    }
    public string Category { get; set; } = "";
    public Enums.ReportPriority Priority { get; set; } = Enums.ReportPriority.Unassigned;
    public Enums.ReportStatus Status { get; set; } = Enums.ReportStatus.Open;
    // public List<File> Files { get; set; } = new List<File>();
    public List<Report> LinkedReports { get; set; } = new List<Report>();
    // public List<Tags>
    public List<Comment> Comments { get; set; } = new List<Comment>();
}
