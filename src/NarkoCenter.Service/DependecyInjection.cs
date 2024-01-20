using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.Service.Files;
using System.Reflection;

namespace NarkoCenter.Service
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IFileService, FileService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "Narko.Center";
                options.Configuration = "127.0.0.1:6379";
            });

            return services;
        }
    }
}