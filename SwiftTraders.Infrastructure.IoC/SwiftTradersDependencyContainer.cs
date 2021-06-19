using Microsoft.Extensions.DependencyInjection;
using SwiftTraders.ApplicationCore.Interfaces.Repositories;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using SwiftTraders.ApplicationCore.Services;
using SwiftTraders.Infrastructure.Repository;
using SwiftTraders.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.Infrastructure.IoC
{
    public static class SwiftTradersDependencyContainer
    {
        public static IServiceCollection AddSwiftService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAdvertService, AdvertService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
