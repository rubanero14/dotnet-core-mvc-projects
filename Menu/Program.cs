using Menu.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Source of learning FreeCodeCamp = https://youtu.be/6SAFgcMie4U

// Add services to the container.
builder.Services.AddControllersWithViews();

// DB Connection Services for DB connection string
builder.Services.AddDbContext<MenuContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
