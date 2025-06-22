using TeknosipDataAccessLayer.Concrete;
using TeknosipEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using TeknosipBusinessLayer.Abstract;
using TeknosipBusinessLayer.Concrete;
using TeknosipDataAccessLayer.Abstract;
using TeknosipDataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddDataProtection()
    .SetApplicationName("TeknosipApp");

builder.Services.AddHttpClient();
builder.Services.AddScoped<IProblemService, ProblemManager>();
builder.Services.AddScoped<IProblemDal, EfProblemDal>();

builder.Services.AddScoped<ISectorService, SectorManager>();
builder.Services.AddScoped<ISectorDal, EfSectorDal>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Identity varsa Authentication da eklenmeli
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
