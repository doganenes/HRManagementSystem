using Microsoft.EntityFrameworkCore;
using HRManagementSystem.DataAccess.Concrete;
using HRManagementSystem.Business;
using HRManagementSystem.DataAccess;
using HRManagementSystem.Business.DependencyResolvers.Microsoft;
using HRManagementSystem.DataAccess.UnitOfWork;
using FluentValidation;
using HRManagementSystem.UI.Models;
using HRManagementSystem.UI.ValidationRules;
using AutoMapper;
using HRManagementSystem.UI.Mappings.AutoMapper;
using HRManagementSystem.Business.Helpers;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Configure(app, app.Environment);

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("Local");
    services.AddDependencies(configuration);
    services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
    services.AddControllersWithViews();

    var profiles = ProfileHelper.GetProfiles();
    profiles.Add(new UserCreateModelProfile());

    var mapperConfig = new MapperConfiguration(opt =>
    {
        opt.AddProfile(new UserCreateModelProfile());
        opt.AddProfiles(profiles);
    });

    var mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);
}

void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (!env.IsDevelopment())
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
}
