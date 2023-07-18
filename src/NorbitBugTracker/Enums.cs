namespace NorbitBugTracker;

public static class Enums
{
    public enum ReportType
    {
        Bug,
        Suggestion,
        Other
    }

    public enum ReportStatus
    {
        Open,
        Assigned,
        Resolved,
        Closed
    }

    public enum ReportPriority
    {
        Unassigned,
        None,
        Low,
        Medium,
        High,
        Urgent,
        Critical
    }

    public enum AccessLevel
    {
        None,
        User,
        Admin
    }
}
