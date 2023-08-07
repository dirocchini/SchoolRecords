using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.ApplicationServices.Services;
using SchoolRecords.Shared.Notifications;
using System.Reflection;

namespace SchoolRecords.ApplicationServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<NotificationContext>();

            return services;
        }
    }
}
