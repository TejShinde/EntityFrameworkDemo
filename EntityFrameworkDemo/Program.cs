using EntityFrameworkDemo .Models;
using Microsoft .EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// read connection string from appsettings.json
var configuration = builder .Configuration .GetConnectionString("DefaultConnection");
// pass connectionstring to ApplicationDbContext class
builder .Services .AddDbContext<ApplicationDbContext>(option => option .UseSqlServer(configuration));


//builder .Services .AddCors(options => options .AddDefaultPolicy(
//                builder => builder .WithOrigins("http://localhost:4200") .AllowAnyMethod() .AllowAnyHeader()
//            ));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app .UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
