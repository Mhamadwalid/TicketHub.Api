using TicketHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<QueueService>();

var app = builder.Build();

// Enable Swagger ALWAYS (even in production)
app.UseSwagger();
app.UseSwaggerUI();

// Optional: Show a welcome message on root
app.MapGet("/", () => "Welcome to TicketHub API");

// Enable routing and endpoints
app.UseAuthorization();
app.MapControllers();

app.Run();
