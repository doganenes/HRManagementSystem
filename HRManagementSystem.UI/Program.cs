using Microsoft.EntityFrameworkCore;
using HRManagementSystem.DataAccess.Concrete;
using HRManagementSystem.Business;
using HRManagementSystem.DataAccess;
using HRManagementSystem.Business.DependencyResolvers.Microsoft;
using HRManagementSystem.DataAccess.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("Local");
    services.AddDependencies(configuration);
    services.AddControllersWithViews();
}
