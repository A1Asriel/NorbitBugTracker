using NorbitBugTracker.Routers;
using NorbitBugTracker.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/getID", () => { return Results.Ok(IDManager.GetID()); });

app.AddUserRouter();
app.AddProjectRouter();
app.AddReportRouter();

app.Run();
