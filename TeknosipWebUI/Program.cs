using Microsoft.EntityFrameworkCore;
using TeknosipDataAccessLayer.Concrete;  // Context için

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Buraya ekleyin:
//builder.Services.AddDbContext<Context>(options =>
//    options.UseSqlServer("server=NARIN\\SQLEXPRESS;initial catalog=TeknosipDb;integrated security=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
