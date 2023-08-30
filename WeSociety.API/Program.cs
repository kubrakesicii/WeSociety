using WeSociety.Persistence;
using WeSociety.Application;
using WeSociety.Infrastructure;
using WeSociety.API;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAPIServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureApiServices();
app.Run();