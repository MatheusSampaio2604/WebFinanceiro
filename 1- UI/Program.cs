using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Application.Interfaces;
using Application;
using Infra.Context;
using Infra.Repository;
using Infra.IdentityContext;
using FinanceiroWeb.Areas;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConnectionStrings(builder.Configuration);

//  MAPPER
builder.Services.AddAutoMapperConfiguration();

// Add services to the container.
builder.Services.DependenciesConfig();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();



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



app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
