using Application.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationIoC
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {

            services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationIoC).Assembly));
            services.AddValidatorsFromAssembly(typeof(ApplicationIoC).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddAutoMapper(typeof(ApplicationIoC).Assembly);

            return services;
        }
    }
}
