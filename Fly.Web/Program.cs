using Fly;
using Fly.Data;
using Fly.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Fly");
builder.Services.AddDbContextFactory<FlyDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient); 
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IFlightRepository, FlightRepository>();
builder.Services.AddSingleton<IPlaneRepository, PlaneRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<PlaneService>();
builder.Services.AddSingleton<FlightService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/Account/Login");
    options.AccessDeniedPath = new PathString("/Account/Login");
});

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
