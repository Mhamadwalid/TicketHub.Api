using Microsoft.OpenApi.Models;
using TicketHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // This is needed for Swagger
builder.Services.AddSwaggerGen();           // This registers Swagger
builder.Services.AddSingleton<QueueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // This generates the Swagger JSON
    app.UseSwaggerUI();       // This generates the Swagger UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
