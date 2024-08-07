//1.- PRIMERO A�ADIR REFERENCIA
using CrudContacto.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//2.- SEGUNDO A�ADIR CONTEXTO
//builder.Services.AddDbContext<PRUEBASContext>();
builder.Services.AddDbContext<DBPRUEBASContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
