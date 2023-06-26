using NorbitBugTracker.Routers;
using NorbitBugTracker.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
