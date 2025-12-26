using System.Reflection;
using FlowApprove.Repository.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var serviceAssembly = Assembly.Load("FlowApprove.Service");
var repositoryAssembly = Assembly.Load("FlowApprove.Repository");

builder.Services.Scan(scan =>
{
    scan.FromAssemblies(repositoryAssembly)
        .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
        .AsMatchingInterface()
        .WithScopedLifetime();
});

builder.Services.Scan(scan =>
{
    scan.FromAssemblies(serviceAssembly)
        .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
        .AsMatchingInterface()
        .WithScopedLifetime();
});


builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = $"{builder.Configuration["Redis:Host"]}:{builder.Configuration["Redis:Port"]}"; });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

