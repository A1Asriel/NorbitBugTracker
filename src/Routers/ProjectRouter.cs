using Microsoft.EntityFrameworkCore;
using NorbitBugTracker.Classes;
using NorbitBugTracker.Contexts;
using NorbitBugTracker.Utils;
using System.Xml.Linq;

namespace NorbitBugTracker.Routers;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class ProjectRouter
{
    public static WebApplication AddProjectRouter(this WebApplication application)
    {
        RouteGroupBuilder projectGroup = application.MapGroup("/api/projects");
        projectGroup.MapGet("/", GetAllProjectIDs);
        projectGroup.MapGet("/{id:long}", GetProject);
        projectGroup.MapPost("/create", CreateProject);
        projectGroup.MapGet("/{id:long}/delete", RemoveProject);
        projectGroup.MapPut("/{id:long}/edit", EditProject);
        return application;
    }

    private static IResult GetAllProjectIDs()
    {
        ProjectContext context = new();
        DbSet<Project> projects = context.Projects;
        List<long> projectids = new();
        foreach (Project project in projects)
        {
            projectids.Add(project.Id);
        }
        return Results.Ok(projectids);
    }

    private static IResult GetProject(long id)
    {
        ProjectContext context = new();
        DbSet<Project> projects = context.Projects;
        Project? project = projects.FirstOrDefault(x => x.Id == id);
        if (project == null)
            return Results.NotFound();
        else
            return Results.Ok(project);
    }

    private static IResult CreateProject(string name, string description, Enums.AccessLevel visibility)
    {
        ProjectContext context = new();
        Project project = new()
        {
            Id = IDManager.GetID(),
            Name = name,
            Description = description,
            Visibility = visibility
        };
        context.Add(project);
        context.SaveChanges();
        return Results.Ok(project);
    }

    private static IResult RemoveProject(long id)
    {
        ProjectContext context = new();
        DbSet<Project> projects = context.Projects;
        Project? project = projects.FirstOrDefault(x => x.Id == id);
        if (project == null)
            return Results.NotFound();
        projects.Remove(project);
        context.SaveChanges();
        return Results.Ok(project);
    }

    private static IResult EditProject(long id, string? name, string? description, Enums.AccessLevel? visibility)
    {
        ProjectContext context = new();
        DbSet<Project> projects = context.Projects;
        Project? project = projects.FirstOrDefault(x => x.Id == id);
        if (project == null)
            return Results.NotFound();
        if (name != null)
            project.Name = name;
        if (description != null)
            project.Description = description;
        if (visibility != null)
            project.Visibility = (Enums.AccessLevel)visibility;
        projects.Update(project);
        context.SaveChanges();
        return Results.Ok(project);
    }
}
