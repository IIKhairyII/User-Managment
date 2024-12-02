using Application.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class InfrastructureIoC
    {

        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
