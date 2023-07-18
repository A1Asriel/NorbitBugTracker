using Microsoft.EntityFrameworkCore;
using NorbitBugTracker.Classes;
using NorbitBugTracker.Contexts;
using NorbitBugTracker.Utils;

namespace NorbitBugTracker.Routers;

/// <summary>
/// Роутер для работы API отчётов
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
        reportGroup.MapPost("/{reportId1:long}/link", LinkReport);
        reportGroup.MapPost("/{reportId1:long}/unlink", UnlinkReport);
        return application;
    }

    private static IResult GetAllReportIDs()
    {
        ReportContext context = new();
        DbSet<Report> reports = context.Reports;
        List<long> reportids = new();
        foreach (Report report in reports)
        {
            reportids.Add(report.Id);
        }
        return Results.Ok(reportids);
    }

    private static IResult GetReport(long id)
    {
        ReportContext context = new();
        DbSet<Report> reports = context.Reports;
        Report? report = reports.FirstOrDefault(x => x.Id == id);
        if (report == null)
            return Results.NotFound();
        else
            return Results.Ok(report);
    }

    private static IResult CreateReport(long userId, long projectId, string name, string description, Enums.ReportType type, string? category)
    {
        ReportContext context = new();
        UserContext userContext = new();
        ProjectContext projectContext = new();
        DbSet<User> users = userContext.Users;
        DbSet<Project> projects = projectContext.Projects;
        User? user = users.FirstOrDefault(x => x.Id == userId);
        Project? project = projects.FirstOrDefault(x => x.Id == projectId);
        if (user == null || user.AccessLevel <= 0 || project == null)
            return Results.StatusCode(403);
        Report report = new()
        {
            Id = IDManager.GetID(),
            UserId = userId,
            ProjectId = projectId,
            Name = name,
            Description = description,
            Type = type,
            Category = category
        };
        context.Add(report);
        context.SaveChanges();
        user.ReportIDs.Add(report.Id);
        users.Update(user);
        userContext.SaveChanges();
        project.ProjectIDs.Add(project.Id);
        projects.Update(project);
        projectContext.SaveChanges();
        return Results.Ok(report);
    }

    private static IResult EditReport(long id, string? name, string? description, Enums.ReportType? type, string? category, Enums.ReportPriority? priority, Enums.ReportStatus? status)
    {
        ReportContext context = new();
        DbSet<Report> reports = context.Reports;
        Report? report = reports.FirstOrDefault(x => x.Id == id);
        if (report == null)
            return Results.NotFound();

        if (name != null)
            report.Name = name;
        if (description != null)
            report.Description = description;
        if (type != null)
            report.Type = (Enums.ReportType)type;
        if (priority != null)
            report.Priority = (Enums.ReportPriority)priority;
        if (status != null)
            report.Status = (Enums.ReportStatus)status;
        reports.Update(report);
        context.SaveChanges();
        return Results.Ok(report);
    }

    private static IResult LinkReport(long reportId1, long reportId2)
    {
        ReportContext reportContext = new();
        DbSet<Report> reports = reportContext.Reports;
        Report? report1 = reports.FirstOrDefault(x => x.Id == reportId1);
        Report? report2 = reports.FirstOrDefault(x => x.Id == reportId2);
        if (report1 == null || report2 == null)
            return Results.NotFound();
        if (report1.LinkedReportIDs.Contains(reportId2) && report2.LinkedReportIDs.Contains(reportId1))
            return Results.StatusCode(403);
        report1.LinkedReportIDs.Add(reportId2);
        report2.LinkedReportIDs.Add(reportId1);
        reports.Update(report1);
        reports.Update(report2);
        reportContext.SaveChanges();
        return Results.Ok(report1);
    }

    private static IResult UnlinkReport(long reportId1, long reportId2)
    {
        ReportContext reportContext = new();
        DbSet<Report> reports = reportContext.Reports;
        Report? report1 = reports.FirstOrDefault(x => x.Id == reportId1);
        Report? report2 = reports.FirstOrDefault(x => x.Id == reportId2);
        if (report1 == null || report2 == null)
            return Results.NotFound();
        if (!report1.LinkedReportIDs.Contains(reportId2) && !report2.LinkedReportIDs.Contains(reportId1))
            return Results.StatusCode(403);
        report1.LinkedReportIDs.Remove(reportId2);
        report2.LinkedReportIDs.Remove(reportId1);
        reports.Update(report1);
        reports.Update(report2);
        reportContext.SaveChanges();
        return Results.Ok(report1);
    }
}
