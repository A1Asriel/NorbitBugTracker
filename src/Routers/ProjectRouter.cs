﻿using NorbitBugTracker.Classes;

namespace NorbitBugTracker.Routers;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class ProjectRouter
{
    public static WebApplication AddProjectRouter(this WebApplication application)
    {
        RouteGroupBuilder projectGroup = application.MapGroup("/api/projects");
        projectGroup.MapGet("/", GetProjects);
        projectGroup.MapGet("/{id:long}", GetProject);
        projectGroup.MapGet("/{projectId:long}/reports", GetReports);
        projectGroup.MapPost("/create", CreateProject);
        projectGroup.MapGet("/{id:long}/delete", RemoveProject);
        projectGroup.MapPut("/{id:long}/edit", EditProject);
        return application;
    }

    private static IResult GetProjects()
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult GetProject(long id)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult GetReports(long projectId)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult CreateProject(Project project)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult RemoveProject(long id)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult EditProject(long id, Project project)
    {
        return Results.StatusCode(501);  // Not implemented
    }
}
