﻿using BookStore.Application.Mappers;
using BookStore.Application.Services;
using BookStore.Application.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddHttpContextAccessor();
            return services;
        }
    }
}