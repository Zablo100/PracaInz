using pracaIn¿.Extensions;
using pracaIn¿.Models.Services;
using pracaIn¿.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDBServices(builder.Configuration);
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IDashboardServices, DashboardServices>();
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IFactoryService, FactoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
