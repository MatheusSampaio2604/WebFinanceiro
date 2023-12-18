using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Application.Interfaces;
using Application;
using Infra.Context;
using Infra.Repository;
using Infra.IdentityContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionIdentity = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionData = builder.Configuration.GetConnectionString("DataConnection") ?? throw new InvalidOperationException("Connection string 'DataConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionIdentity));
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionData));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IAcoesRepository, AcoesRepository>();
builder.Services.AddScoped<IFiiRepository, FiiRepository>();
builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();
builder.Services.AddScoped<IQuantidadeRepository, QuantidadesRepository>();
builder.Services.AddScoped<IValoresRepository, ValoresRepository>();

builder.Services.AddScoped<IAcoesApp, AcoesApp>();
builder.Services.AddScoped<IFiiApp, FiiApp>();
builder.Services.AddScoped<IMensagemApp, MensagemApp>();
builder.Services.AddScoped<IQuantidadesApp, QuantidadesApp>();
builder.Services.AddScoped<IValoresApp, ValoresApp>();



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
