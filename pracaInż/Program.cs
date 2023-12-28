using pracaIn¿.Extensions;
using pracaIn¿.Models.Services;
using pracaIn¿.Services;
using Newtonsoft.Json;



var frontend = "_frontend";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(cors =>
{
    cors.AddPolicy(name: frontend, policy =>
    {

        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDBServices(builder.Configuration);
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IDashboardServices, DashboardServices>();
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IFactoryService, FactoryService>();
builder.Services.AddScoped<IDepartmenService, DepartmenService>();
builder.Services.AddScoped<IPrinterService, PrinterService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<ISoftwareService, SoftwareService>();
builder.Services.AddScoped<IInventoryservice, InventoryService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IPcLogService, PcLogService>();

builder.Services.AddControllers()
    .AddNewtonsoftJson();


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

app.UseCors(frontend);

app.MapControllers();

Copy.Start();
app.Run();

