using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLNS.Data;
using QLNS.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QLNSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLNSContext") ?? throw new InvalidOperationException("Connection string 'QLNSContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie();
var app = builder.Build();

app.UseAuthentication();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData2.Initialize(services);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NhanViens}/{action=Index}/{id?}");

app.Run();
