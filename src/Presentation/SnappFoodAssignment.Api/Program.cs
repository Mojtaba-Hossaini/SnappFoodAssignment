using Microsoft.Extensions.DependencyInjection;
using SnappFoodAssignment.InfraStructure.EFCore.Extensions;
using SnappFoodAssignment.Application.Extensions;
using SnappFoodAssignment.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("SnapfoodSqlConnectionString"));
builder.Services.AddApplicationServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();
app.Run();
