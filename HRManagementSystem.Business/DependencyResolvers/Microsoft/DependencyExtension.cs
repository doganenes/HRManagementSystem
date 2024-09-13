﻿using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.Business.Mappings.AutoMapper;
using HRManagementSystem.Business.Services;
using HRManagementSystem.Business.ValidationRules;
using HRManagementSystem.DataAccess.Concrete;
using HRManagementSystem.DataAccess.UnitOfWork;
using HRManagementSystem.Dtos.ProvidedServiceDtos;
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

            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProvidedServiceProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
        }

    }
}