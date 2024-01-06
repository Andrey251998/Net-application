using Hangfire;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Space_App_ASP_MVC.Controllers;
using Space_App_ASP_MVC.Models;
using spaceBLL.Interfaces;
using spaceBLL.Services;
using spaceDAL.EntityFramework;
using spaceDAL.Interfaces;
using spaceDAL.Repositories;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<Application_context>(options => options.UseSqlServer("Server = localhost; Database = space; User = sa; Password = 123;"));
builder.Services.AddHangfire(h => h.UseSqlServerStorage("Server=localhost;Database=space;User=sa;Password=123;"));
builder.Services.AddHangfireServer();
builder.Services.AddScoped<IOrderService, UserService>();
builder.Services.AddScoped<IClient, ClientService>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseHangfireDashboard();

app.MapControllerRoute(
     name: "default",
      pattern: "{action}",
      defaults: new { controller = "Home", action = "Index" });

app.Run();
