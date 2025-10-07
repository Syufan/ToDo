using Serilog;
using TODO.server.Services.Interfaces;
using TODO.server.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

// Add services to the container.
builder.Services.AddSingleton<IToDoItemService, ToDoItemService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string AllowOrigins = "AllowOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(AllowOrigins);
app.MapControllers();
app.Run();
