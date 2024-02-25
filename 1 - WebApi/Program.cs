using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApi.Token;
using Serilog;
using WebApi.Areas;

var builder = WebApplication.CreateBuilder(args);

// Strings de Conexão
builder.Services.ConnectionStrings(builder.Configuration);

//  MAPPER
builder.Services.AddAutoMapperConfiguration();

// Add services to the container.
builder.Services.DependenciesConfig();

//
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
        IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-26042002-TesterBeta21")
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




builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


// builder.Logging.ClearProviders();

// string? logsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
// if (!Directory.Exists(logsDirectory)) Directory.CreateDirectory(logsDirectory);
// var logger = new LoggerConfiguration()
//     .WriteTo.Console()
//     .WriteTo.File(Path.Combine(logsDirectory, "log.txt"), rollingInterval: RollingInterval.Day)
//     .CreateLogger();


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
