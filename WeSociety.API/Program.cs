using WeSociety.Persistence;
using WeSociety.Application;
using WeSociety.Infrastructure;
using WeSociety.API;
using WeSociety.Infrastructure.ServiceRegistrations;
using WeSociety.Application.ServiceRegistrations;
using WeSociety.Persistence.ServiceRegistrations;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAPIServices();

//PERSISTENCE SERVICES
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddIdentity(builder.Configuration);
//builder.Services.AddPersistenceServices(builder.Configuration);

// INFRASTRUCTURE SERVICES
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddELKService(builder.Configuration);
//builder.Services.AddInfrastructureServices(builder.Configuration);

//APPLICATION SERVICES
builder.Services.AddDecorators();
builder.Services.AddLogger();
builder.Services.AddAutoMapper();
builder.Services.AddMediatr();
//builder.Services.AddApplicationServices();


var app = builder.Build();

app.ConfigureApiServices();
app.Run();