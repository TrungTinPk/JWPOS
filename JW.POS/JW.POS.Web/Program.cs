using JW.POS.Core;
using JW.POS.Product;
using JW.POS.User;
using JW.POS.Web.Services;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
var isDevelopment = builder.Environment.IsDevelopment();

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json");

var connectionString = builder.Configuration.GetConnectionString("TenantConnection");

// Add services to the container.

builder.Services
    .AddInternalService(builder.Configuration)
    .AddCoreService(connectionString, isDevelopment, isDevelopment)
    .AddProductService()
    .AddUserService()
    .AddControllersWithViews();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
