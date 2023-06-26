using NorbitBugTracker.Classes;

namespace NorbitBugTracker.Routers;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class UserRouter
{
    public static WebApplication AddUserRouter(this WebApplication application)
    {
        RouteGroupBuilder userGroup = application.MapGroup("/api/users");
        userGroup.MapGet("/", GetUsers);
        userGroup.MapGet("/{id:long}", GetUser);
        userGroup.MapPost("/register", AddUser);
        userGroup.MapGet("/{id:long}/delete", RemoveUser);
        userGroup.MapPut("/{id:long}/edit", EditUser);
        return application;
    }

    private static IResult GetUsers()
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult GetUser(long id)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult AddUser(User user)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult RemoveUser(long id)
    {
        return Results.StatusCode(501);  // Not implemented
    }

    private static IResult EditUser(long id, User user)
    {
        return Results.StatusCode(501);  // Not implemented
    }
}
