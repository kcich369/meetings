using Meetings.Database.Extensions;
using Meetings.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterInfrastructure(builder.Configuration.GetConnectionString("MeetingsDatabase")!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () => { return "Ok"; })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

await builder.Services.MigrateDatabase();
app.Run();