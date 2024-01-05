using Hangfire;
using Microsoft.EntityFrameworkCore;
using Space_App_ASP_MVC.Models;
using spaceBLL.Interfaces;
using spaceBLL.Services;
using spaceDAL.EntityFramework;
using spaceDAL.Interfaces;
using spaceDAL.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddHangfire(h => h.UseSqlServerStorage("Server=192.168.0.106,1433;Database=space;User=sa;Password=123;"));
builder.Services.AddHangfireServer();
//builder.Services.AddDbContext<Application_context>(options => options.UseSqlServer
//(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderService, UserService>();
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
