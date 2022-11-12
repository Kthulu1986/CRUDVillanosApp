using CRUDVillanosApp.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyIndiminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IndiminConnection"))
);

var app = builder.Build();

/*
 * ************************************************************
 * ------------------------------------------------------------
 * 11-11-2022
 * Configuración para la migración del contexto SQL SERVER
 * Nelson Huenchuleo 
 * ------------------------------------------------------------
 * ************************************************************
 */

//le decimos que represente las clase/tablas en la BD, program es la primera clase que se ejecuta en este proyecto CRUD
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MyIndiminContext>();
    context.Database.Migrate();
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
    pattern: "{controller=Ciudadano}/{action=Index}/{id?}");

app.Run();
