using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Application.Interfaces;
using Application;
using Infra.Context;
using Infra.Repository;
using Infra.IdentityContext;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApi.Token;
using Application.ViewModels;
using AutoMapper;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionIdentity = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionData = builder.Configuration.GetConnectionString("DataConnection") ?? throw new InvalidOperationException("Connection string 'DataConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionIdentity));
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionData));


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IFiiRepository, FiiRepository>();
builder.Services.AddScoped<IAcoesRepository, AcoesRepository>();
builder.Services.AddScoped<IValoresRepository, ValoresRepository>();
builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();
builder.Services.AddScoped<IQuantidadeRepository, QuantidadesRepository>();

builder.Services.AddScoped<IFiiApp, FiiApp>();
builder.Services.AddScoped<IAcoesApp, AcoesApp>();
builder.Services.AddScoped<IValoresApp, ValoresApp>();
builder.Services.AddScoped<IMensagemApp, MensagemApp>();
builder.Services.AddScoped<IQuantidadesApp, QuantidadesApp>();


builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "Testing.Security.Bearer",
        ValidAudience = "Testing.Security.Bearer",
        IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-26042002")
    };

    opt.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
            return Task.CompletedTask;
        }
    };
});


//Mapper
MapperConfiguration? config = new(cfg =>
{
    cfg.CreateMap<MensagemViewModel, Mensagem>();
    cfg.CreateMap<Mensagem, MensagemViewModel>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


builder.Logging.ClearProviders();

string? logsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
if (!Directory.Exists(logsDirectory)) Directory.CreateDirectory(logsDirectory);
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(Path.Combine(logsDirectory, "log.txt"), rollingInterval: RollingInterval.Day)
    .CreateLogger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
