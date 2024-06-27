using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Interfaces;
using Gestion_Academica.Data.Repositories.Mocks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EstudiantesContext>(options=>options.UseInMemoryDatabase("Students"));

builder.Services.AddScoped<IAEstudianteRepository,MockEstudianteRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
