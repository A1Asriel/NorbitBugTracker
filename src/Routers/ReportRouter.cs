namespace NorbitBugTracker.Routers;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class ReportRouter
{
    public static WebApplication AddReportRouter(this WebApplication application)
    {
        RouteGroupBuilder reportGroup = application.MapGroup("/api/reports");
        reportGroup.MapGet("/", GetAllReportIDs);
        reportGroup.MapGet("/{id:long}", GetReport);
        reportGroup.MapPost("/create", CreateReport);
        reportGroup.MapPut("/{id:long}/edit", EditReport);
        reportGroup.MapPost("/{reportId:long}/comment", CreateComment);
        reportGroup.MapPost("/{reportId1:long}/link", LinkReport);
        reportGroup.MapPost("/{reportId1:long}/unlink", UnlinkReport);
        return application;
    }

    private static IResult GetAllReportIDs()
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult GetReport(long id)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult CreateReport(long projectId, long userId, string name, string description, Enums.ReportType type, string? category)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult EditReport(long id, string? name, string? description, Enums.ReportType? type, string? category, Enums.ReportPriority? priority, Enums.ReportStatus? status)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult CreateComment(long reportId, long userId, string content)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult LinkReport(long reportId1, long reportId2)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult UnlinkReport(long reportId1, long reportId2)
    {
        return Results.StatusCode(501);  // Not implemented
    }
}
