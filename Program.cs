using Todo.Data.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>();

var app = builder.Build();
app.MapControllers();

// app.MapGet("/", () => "Hello World!");

app.Run();
