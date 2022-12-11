// Note: You can specify the "args" while running the dotnet command.
using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Use this when you want tot register anything with the DI-container.
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


var app = builder.Build();

// Configure the HTTP request pipeline.
// Note: The request pipeline containes multiple middle-wares that are configurable.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Middle-ware to use our static files present in WWWROOT folder.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// This routing is used to map our controllers to the corresponding requests.
// Note: The use of named parameters here.
// Note: The pattern here represents the pattern of routing for typical MVC application.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
