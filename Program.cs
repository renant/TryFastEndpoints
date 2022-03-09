global using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using TryFastEndpointsApp.Context;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("DatabaseInMemory"));

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.Run();