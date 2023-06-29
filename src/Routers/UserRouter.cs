using Microsoft.EntityFrameworkCore;
using NorbitBugTracker.Contexts;
using NorbitBugTracker.Classes;
using NorbitBugTracker.Utils;

namespace NorbitBugTracker.Routers;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class UserRouter
{
    public static WebApplication AddUserRouter(this WebApplication application)
    {
        RouteGroupBuilder userGroup = application.MapGroup("/api/users");
        userGroup.MapGet("/", GetAllUserIDs);
        userGroup.MapGet("/{id:long}", GetUser);
        userGroup.MapPost("/register", AddUser);
        userGroup.MapGet("/{id:long}/delete", RemoveUser);
        userGroup.MapPut("/{id:long}/edit", EditUser);
        return application;
    }

    private static IResult GetAllUserIDs()
    {
        UserContext context = new();
        DbSet<User> users = context.Users;
        List<long> userids = new();
        foreach (User user in users)
        {
            userids.Add(user.Id);
        }
        return Results.Ok(userids);
    }

    private static IResult GetUser(long id)
    {
        UserContext context = new();
        DbSet<User> users = context.Users;
        User? user = users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return Results.NotFound();
        else
            return Results.Ok(user);
    }

    private static IResult AddUser(string login, string password, string name)
    {
        UserContext context = new();
        DbSet<User> users = context.Users;
        User? check_user = users.FirstOrDefault(x => x.Login == login);
        if (check_user != null)
            return Results.Forbid();

        User user = new User()
        {
            Id = IDManager.GetID(),
            Login = login,
            Password = password,
            Name = name
        };
        context.Add(user);
        context.SaveChanges();
        return Results.Ok(user.Id);
    }

    private static IResult RemoveUser(long id)
    {
        UserContext context = new();
        DbSet<User> users = context.Users;
        User? user = users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return Results.NotFound();

        user.AccessLevel = Enums.AccessLevel.None;
        users.Update(user);
        context.SaveChanges();
        return Results.Ok(user);
    }

    private static IResult EditUser(long id, string? login, string? password, string? name)
    {
        UserContext context = new();
        DbSet<User> users = context.Users;
        User? user = users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return Results.NotFound();

        if (login != null) user.Login = login;
        if (password != null) user.Password = password;
        if (name != null) user.Name = name;
        users.Update(user);
        context.SaveChanges();
        return Results.Ok(user);
    }
}
