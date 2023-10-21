using Microsoft.EntityFrameworkCore;
using ProjetoEcomerce.Data;
using ProjetoEcomerce.Repositorio;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<UsuarioContext>(o => o.UseSqlServer("Data Source=EMANUEL;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True"));
builder.Services.AddScoped<IUsuarioRepositoriocs, UsuarioRepositorio>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
