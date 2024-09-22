using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.Business.Mappings.AutoMapper;
using HRManagementSystem.Business.Services;
using HRManagementSystem.Business.ValidationRules.Advertisement;
using HRManagementSystem.Business.ValidationRules.AppUser;
using HRManagementSystem.Business.ValidationRules.Gender;
using HRManagementSystem.Business.ValidationRules.ProvidedService;
using HRManagementSystem.DataAccess.Concrete;
using HRManagementSystem.DataAccess.UnitOfWork;
using HRManagementSystem.Dtos;
using HRManagementSystem.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
        }
    }
}
