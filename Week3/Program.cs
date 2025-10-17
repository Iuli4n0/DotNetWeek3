using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;
using Week3.Database; 
using Week3.Middleware;
using Week3.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Database context (in-memory )
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=BooksDb.sqlite"));


// mediatr for CQRS
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookCommandValidator>();

var app = builder.Build();

// create db and tables
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();


//builder.Services.AddValidatorsFromAssemblyContaining<Program>();

app.UseAuthorization();
app.MapControllers();

app.Run();