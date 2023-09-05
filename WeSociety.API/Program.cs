using WeSociety.Infrastructure.ServiceRegistrations;
using WeSociety.Application.ServiceRegistrations;
using WeSociety.Persistence.ServiceRegistrations;
using WeSociety.API.ServiceRegistrations;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//API SERVICES
builder.Services.AddAPIServices();

//PERSISTENCE SERVICES
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddIdentity(builder.Configuration);

// INFRASTRUCTURE SERVICES
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddELKService(builder.Configuration);

//APPLICATION SERVICES
builder.Services.AddLogger();
builder.Services.AddAutoMapper();
builder.Services.AddMediatr();

var app = builder.Build();

app.ConfigureApiServices();
app.Run();