using DreamyReefs.Controllers;
using DreamyReefs.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using DreamyReefs.Models;
using DreamyReefs.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Conexion>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddScoped<ReservacionController>();
//builder.Services.AddControllersWithViews().AddFluentValidation();
//builder.Services.AddTransient<IValidator<AccesoWeb>, Validadores>();
//builder.Services.AddTransient<IValidator<Empresa>, EmpresasValidator>();
//builder.Services.AddTransient<IValidator<Reservacion>, ReservacionValidator>();
//builder.Services.AddTransient<IValidator<Review>, ReviewValidator>();
//builder.Services.AddTransient<IValidator<Tours>, TourValidator>();
//builder.Services.AddTransient<IValidator<Transportes>, TransporteValidator>();


// Configure session management
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
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

// Enable session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/Windows");

app.Run();
    