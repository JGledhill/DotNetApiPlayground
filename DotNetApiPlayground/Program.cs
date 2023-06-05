/*
 * The Program.cs file is the entry point for the application.
 * This one uses top-level statements to create a simple web API.
 */

using DotNetApiPlayground.DAL;
using DotNetApiPlayground.Models;

var builder = WebApplication.CreateBuilder(args);

// Each of these lines adds a different service to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// This line adds a singleton instance of a BookRepository to the container.
// This allows the BookRepository to be injected into other classes.
// See the constructor in: Controllers/BookController.cs
builder.Services.AddScoped<IRepository<Book>, StaticBookRepository>();

// This line creates the application.
var app = builder.Build();

// The following lines configure the HTTP request pipeline.
// The order of these lines is important.
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0

// Use the environment variable to optionally enable Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// This line runs the API.
app.Run();