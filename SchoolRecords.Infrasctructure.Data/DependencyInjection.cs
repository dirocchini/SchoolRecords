using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolRecords.Domain.Interfaces;
using SchoolRecords.Infrasctructure.Data.Repositories;

namespace SchoolRecords.Infrasctructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchoolingRepository, SchoolingRepository>();
            return services;
        }
    }
}
