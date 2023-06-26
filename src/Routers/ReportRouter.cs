using NorbitBugTracker.Classes;

namespace NorbitBugTracker.Routers;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class ReportRouter
{
    public static WebApplication AddReportRouter(this WebApplication application)
    {
        RouteGroupBuilder reportGroup = application.MapGroup("/api/reports");
        reportGroup.MapGet("/", GetReports);
        reportGroup.MapPost("/create", CreateReport);
        reportGroup.MapPut("/{id:long}/edit", EditReport);
        reportGroup.MapPost("/{reportId:long}/comment", CreateComment);
        return application;
    }

    private static IResult GetReports()
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult CreateReport(Report report)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult EditReport(long id, Report report)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult CreateComment(long reportId, Comment comment)
    {
        return Results.StatusCode(501);  // Not implemented
    }
}
