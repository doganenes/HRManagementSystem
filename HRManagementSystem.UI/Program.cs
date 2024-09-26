using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.DependencyResolvers.Microsoft;
using HRManagementSystem.Business.Helpers;
using HRManagementSystem.UI.Mappings.AutoMapper;
using HRManagementSystem.UI.Models;
using HRManagementSystem.UI.ValidationRules;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(opt =>
        {
            opt.Cookie.Name = "HRManagementSystemCookie";
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            opt.ExpireTimeSpan = TimeSpan.FromDays(7);
            opt.LoginPath = new PathString("/Account/SignIn");
            opt.LogoutPath = new PathString("/Account/LogOut");
            opt.AccessDeniedPath = new PathString("/Error/AccessDeniedPage");
        });


ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Configure(app, app.Environment);

app.Run();

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

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseAuthorization();

    app.MapDefaultControllerRoute();
}